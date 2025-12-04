#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 工具：选择一个文件夹，将里面所有图片打成一张图集（多 Sprite）。
/// 菜单：Tool/生成图集（从文件夹）
/// 生成的图集 PNG 会放在同一个文件夹下。
/// </summary>
public class FolderToAtlasTool : EditorWindow
{
    private DefaultAsset folderAsset;
    private string atlasName = "NewAtlas";
    private int maxAtlasSize = 4096;
    private int padding = 2;

    [MenuItem("Tool/生成图集（从文件夹）")]
    private static void OpenWindow()
    {
        var window = GetWindow<FolderToAtlasTool>("生成图集（从文件夹）");
        window.minSize = new Vector2(380, 160);
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("文件夹打图集工具", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("1. 选择一个仅包含序列帧图片的文件夹（Project 中）");
        folderAsset = (DefaultAsset)EditorGUILayout.ObjectField("图片文件夹", folderAsset, typeof(DefaultAsset), false);

        EditorGUILayout.Space();
        atlasName = EditorGUILayout.TextField("图集名（文件名）", atlasName);
        maxAtlasSize = EditorGUILayout.IntPopup("最大尺寸", maxAtlasSize, new[] { "1024", "2048", "4096" }, new[] { 1024, 2048, 4096 });
        padding = EditorGUILayout.IntSlider("间距 (Padding)", padding, 0, 16);

        EditorGUILayout.Space();
        if (GUILayout.Button("生成图集", GUILayout.Height(30)))
        {
            GenerateAtlas();
        }
    }

    private void GenerateAtlas()
    {
        if (folderAsset == null)
        {
            EditorUtility.DisplayDialog("错误", "请先选择一个包含图片的文件夹。", "确定");
            return;
        }

        if (string.IsNullOrEmpty(atlasName))
        {
            EditorUtility.DisplayDialog("错误", "请先输入图集名。", "确定");
            return;
        }

        string folderPath = AssetDatabase.GetAssetPath(folderAsset);
        if (string.IsNullOrEmpty(folderPath) || !AssetDatabase.IsValidFolder(folderPath))
        {
            EditorUtility.DisplayDialog("错误", "所选对象不是有效的文件夹，请重新选择。", "确定");
            return;
        }

        // 找到文件夹下所有 Texture2D
        string[] guids = AssetDatabase.FindAssets("t:Texture2D", new[] { folderPath });
        if (guids == null || guids.Length == 0)
        {
            EditorUtility.DisplayDialog("错误", "该文件夹下没有找到任何图片（Texture2D）。", "确定");
            return;
        }

        var pathList = guids
            .Select(g => AssetDatabase.GUIDToAssetPath(g))
            .Where(p => !string.IsNullOrEmpty(p))
            .OrderBy(p => Path.GetFileNameWithoutExtension(p))
            .ToList();

        if (pathList.Count == 0)
        {
            EditorUtility.DisplayDialog("错误", "该文件夹下没有可用的图片。", "确定");
            return;
        }

        // 确保源图片可读并且是 Sprite 类型
        foreach (var path in pathList)
        {
            var srcImporter = AssetImporter.GetAtPath(path) as TextureImporter;
            if (srcImporter == null) continue;

            bool dirty = false;

            if (!srcImporter.isReadable)
            {
                srcImporter.isReadable = true;
                dirty = true;
            }

            if (srcImporter.textureType != TextureImporterType.Sprite)
            {
                srcImporter.textureType = TextureImporterType.Sprite;
                dirty = true;
            }

            if (dirty)
            {
                srcImporter.SaveAndReimport();
            }
        }

        // 加载所有 Texture2D
        var textures = new List<Texture2D>();
        foreach (var path in pathList)
        {
            var tex = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
            if (tex != null)
            {
                textures.Add(tex);
            }
        }

        if (textures.Count == 0)
        {
            EditorUtility.DisplayDialog("错误", "未能加载到任何 Texture2D。", "确定");
            return;
        }

        // 打包到一张图集
        var atlas = new Texture2D(2, 2, TextureFormat.RGBA32, false);
        Rect[] rects = atlas.PackTextures(textures.ToArray(), padding, maxAtlasSize);

        string atlasAssetPath = Path.Combine(folderPath, atlasName + ".png").Replace("\\", "/");

        // 计算磁盘路径（项目根目录 + 资源相对路径）
        string projectRoot = Path.GetDirectoryName(Application.dataPath);
        string atlasDiskPath = Path.Combine(projectRoot, atlasAssetPath);

        Directory.CreateDirectory(Path.GetDirectoryName(atlasDiskPath) ?? projectRoot);

        // 为避免压缩格式问题，拷贝到 RGBA32 纹理再编码
        var atlasReadable = new Texture2D(atlas.width, atlas.height, TextureFormat.RGBA32, false);
        atlasReadable.SetPixels(atlas.GetPixels());
        atlasReadable.Apply();

        byte[] pngData = atlasReadable.EncodeToPNG();
        File.WriteAllBytes(atlasDiskPath, pngData);

        AssetDatabase.ImportAsset(atlasAssetPath);

        // 设置为多 Sprite 图集
        var importer = AssetImporter.GetAtPath(atlasAssetPath) as TextureImporter;
        if (importer == null)
        {
            EditorUtility.DisplayDialog("错误", "无法获取图集 TextureImporter。", "确定");
            return;
        }

        importer.textureType = TextureImporterType.Sprite;
        importer.spriteImportMode = SpriteImportMode.Multiple;

        var metas = new SpriteMetaData[textures.Count];
        for (int i = 0; i < textures.Count; i++)
        {
            Rect r = rects[i];
            var meta = new SpriteMetaData
            {
                name = $"{atlasName}_{i:D3}",
                rect = new Rect(
                    r.x * atlas.width,
                    r.y * atlas.height,
                    r.width * atlas.width,
                    r.height * atlas.height
                ),
                pivot = new Vector2(0.5f, 0.5f),
                alignment = (int)SpriteAlignment.Center
            };
            metas[i] = meta;
        }

        importer.spritesheet = metas;
        importer.SaveAndReimport();

        AssetDatabase.Refresh();

        EditorUtility.DisplayDialog("完成", $"已在文件夹中生成图集：{atlasAssetPath}", "确定");
    }
}

#endif


