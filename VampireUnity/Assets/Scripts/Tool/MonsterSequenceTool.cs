#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

/// <summary>
/// 工具：怪物序列帧
/// 功能：
/// 1. 选择一个包含多张序列帧图片的文件夹（支持多个动作）
///    - 命名规则：attack_00, attack_01, run_00, run_01 等
///    - 下划线前部分视为“动作名”，例如 attack / run
/// 2. 填写动画控制器名字、帧率
/// 3. 先把该文件夹里所有图片打成一张图集
/// 4. 再按动作名拆分并生成多个 AnimationClip
/// 5. 生成一个 AnimatorController，把每个动画作为一个状态加入其中
/// 资源都会生成在原文件夹下：
///   - {ControllerName}_Atlas.png
///   - {ControllerName}.controller
///   - {动作名}.anim
/// </summary>
public class MonsterSequenceTool : EditorWindow
{
    private DefaultAsset folderAsset;
    private string controllerName = "MonsterController";
    private float frameRate = 12f;
    private int maxAtlasSize = 4096;
    private int padding = 2;

    [MenuItem("Tool/怪物序列帧")]
    private static void OpenWindow()
    {
        var window = GetWindow<MonsterSequenceTool>("怪物序列帧");
        window.minSize = new Vector2(420, 200);
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("怪物序列帧工具", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("1. 选择一个仅包含序列帧图片的文件夹（Project 中）");
        folderAsset = (DefaultAsset)EditorGUILayout.ObjectField("图片文件夹", folderAsset, typeof(DefaultAsset), false);

        EditorGUILayout.Space();
        controllerName = EditorGUILayout.TextField("动画控制器名", controllerName);
        frameRate = EditorGUILayout.FloatField("统一帧率 (FPS)", frameRate);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("图集选项", EditorStyles.boldLabel);
        maxAtlasSize = EditorGUILayout.IntPopup(
            "最大图集尺寸",
            maxAtlasSize,
            new[] { "1024", "2048", "4096", "8192", "16384" },
            new[] { 1024, 2048, 4096, 8192, 16384 });
        padding = EditorGUILayout.IntSlider("间距 (Padding)", padding, 0, 16);

        EditorGUILayout.Space();
        if (GUILayout.Button("生成怪物序列帧资源", GUILayout.Height(30)))
        {
            Generate();
        }
    }

    private void Generate()
    {
        if (folderAsset == null)
        {
            EditorUtility.DisplayDialog("错误", "请先选择一个包含图片的文件夹。", "确定");
            return;
        }

        if (string.IsNullOrEmpty(controllerName))
        {
            EditorUtility.DisplayDialog("错误", "请先输入动画控制器名。", "确定");
            return;
        }

        if (frameRate <= 0)
        {
            EditorUtility.DisplayDialog("错误", "帧率必须大于 0。", "确定");
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

        // 记录每张图片的“动作名”和顺序
        var frameInfos = new List<FrameInfo>();
        foreach (var path in pathList)
        {
            string fileName = Path.GetFileNameWithoutExtension(path);
            ParseName(fileName, out string actionName, out int index);
            frameInfos.Add(new FrameInfo
            {
                Path = path,
                FileName = fileName,
                ActionName = actionName,
                Index = index
            });
        }

        // 确保源图片可读并且是 Sprite 类型
        foreach (var info in frameInfos)
        {
            var srcImporter = AssetImporter.GetAtPath(info.Path) as TextureImporter;
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
        foreach (var info in frameInfos)
        {
            var tex = AssetDatabase.LoadAssetAtPath<Texture2D>(info.Path);
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

        string atlasAssetPath = Path.Combine(folderPath, controllerName + "_Atlas.png").Replace("\\", "/");
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

        // 按原文件顺序创建 SpriteMetaData，名字沿用文件名，方便按动作名分组
        var metas = new SpriteMetaData[textures.Count];
        for (int i = 0; i < textures.Count; i++)
        {
            Rect r = rects[i];
            string spriteName = frameInfos[i].FileName; // 例如 attack_00
            var meta = new SpriteMetaData
            {
                name = spriteName,
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

        // 从图集路径中加载所有 Sprite，并按名字保存到字典
        var allAssets = AssetDatabase.LoadAllAssetsAtPath(atlasAssetPath);
        var spriteDict = allAssets
            .OfType<Sprite>()
            .ToDictionary(s => s.name, s => s);

        if (spriteDict.Count == 0)
        {
            EditorUtility.DisplayDialog("错误", "图集中未能加载到任何 Sprite。", "确定");
            return;
        }

        // 按动作名分组，生成多个 AnimationClip
        var clips = new Dictionary<string, AnimationClip>();
        var groups = frameInfos
            .GroupBy(f => f.ActionName)
            .OrderBy(g => g.Key, System.StringComparer.Ordinal);

        foreach (var group in groups)
        {
            string actionName = group.Key;
            var orderedFrames = group
                .OrderBy(f => f.Index)
                .ThenBy(f => f.FileName, System.StringComparer.Ordinal)
                .ToList();

            var actionSprites = new List<Sprite>();
            foreach (var fi in orderedFrames)
            {
                if (spriteDict.TryGetValue(fi.FileName, out var s))
                {
                    actionSprites.Add(s);
                }
            }

            if (actionSprites.Count == 0)
                continue;

            var clip = CreateAnimationClip(folderPath, actionName, actionSprites, frameRate);
            if (clip != null)
            {
                clips[actionName] = clip;
            }
        }

        if (clips.Count == 0)
        {
            EditorUtility.DisplayDialog("错误", "没有生成任何动画，请检查命名规则。", "确定");
            return;
        }

        // 创建 AnimatorController，并把每个动作作为一个状态
        var controller = CreateAnimatorController(folderPath, controllerName, clips);
        if (controller == null)
        {
            EditorUtility.DisplayDialog("错误", "创建 AnimatorController 失败。", "确定");
            return;
        }

        AssetDatabase.Refresh();

        EditorUtility.DisplayDialog(
            "完成",
            $"已生成图集、动画控制器和 {clips.Count} 个动画。\n图集: {atlasAssetPath}\n控制器: {controllerName}.controller",
            "确定");
    }

    /// <summary>
    /// 从文件名中提取动画名和帧索引
    /// 规则：找到最后一个下划线 '_'，取它前面的部分，如果这部分包含 '-'，则取最后一个 '-' 后面的部分作为动画名
    /// 例如：【只有在【冰糖撞果冻】购买才可以免费更新】dashiguai_guang-attack1_00 -> attack1
    /// 例如：【只有在【冰糖撞果冻】购买才可以免费更新】dashiguai_guang-beatback_08 -> beatback
    /// </summary>
    private static void ParseName(string fileName, out string actionName, out int index)
    {
        actionName = fileName;
        index = 0;

        // 找到最后一个下划线的位置
        int underscoreIndex = fileName.LastIndexOf('_');
        if (underscoreIndex > 0 && underscoreIndex < fileName.Length - 1)
        {
            // 取最后一个下划线前面的部分
            string beforeUnderscore = fileName.Substring(0, underscoreIndex);
            
            // 如果这部分包含 '-'，取最后一个 '-' 后面的部分作为动画名
            int dashIndex = beforeUnderscore.LastIndexOf('-');
            if (dashIndex >= 0 && dashIndex < beforeUnderscore.Length - 1)
            {
                actionName = beforeUnderscore.Substring(dashIndex + 1);
            }
            else
            {
                actionName = beforeUnderscore;
            }
            
            // 取最后一个下划线后面的部分作为帧索引
            string suffix = fileName.Substring(underscoreIndex + 1);
            if (!int.TryParse(suffix, out index))
            {
                index = 0;
            }
        }
    }

    private class FrameInfo
    {
        public string Path;
        public string FileName;
        public string ActionName;
        public int Index;
    }

    private static AnimationClip CreateAnimationClip(string folderPath, string actionName, List<Sprite> sprites, float fps)
    {
        string clipPath = Path.Combine(folderPath, actionName + ".anim").Replace("\\", "/");

        AnimationClip clip = new AnimationClip
        {
            frameRate = fps
        };

        var keyframes = new ObjectReferenceKeyframe[sprites.Count];
        for (int i = 0; i < sprites.Count; i++)
        {
            keyframes[i] = new ObjectReferenceKeyframe
            {
                time = i / fps,
                value = sprites[i]
            };
        }

        var binding = new EditorCurveBinding
        {
            type = typeof(SpriteRenderer),
            path = "",
            propertyName = "m_Sprite"
        };

        AnimationUtility.SetObjectReferenceCurve(clip, binding, keyframes);

        AssetDatabase.CreateAsset(clip, clipPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.ImportAsset(clipPath);

        return AssetDatabase.LoadAssetAtPath<AnimationClip>(clipPath);
    }

    private static AnimatorController CreateAnimatorController(
        string folderPath,
        string controllerName,
        Dictionary<string, AnimationClip> clips)
    {
        string controllerPath = Path.Combine(folderPath, controllerName + ".controller").Replace("\\", "/");

        AnimatorController controller = AnimatorController.CreateAnimatorControllerAtPath(controllerPath);
        var stateMachine = controller.layers[0].stateMachine;

        AnimatorState defaultState = null;

        foreach (var kv in clips.OrderBy(k => k.Key, System.StringComparer.Ordinal))
        {
            string actionName = kv.Key;
            var clip = kv.Value;

            var state = stateMachine.AddState(actionName);
            state.motion = clip;

            if (defaultState == null)
            {
                defaultState = state;
                stateMachine.defaultState = state;
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.ImportAsset(controllerPath);

        return controller;
    }
}

#endif



