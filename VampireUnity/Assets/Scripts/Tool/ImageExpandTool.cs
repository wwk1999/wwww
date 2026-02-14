#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

public class ImageExpandTool : EditorWindow
{
    private string folderPath = "";
    private Vector2 scrollPosition;
    private string[] supportedFormats = { ".png", ".jpg", ".jpeg" };

    [MenuItem("Tool/扩充图片到1:1比例", priority = 4)]
    public static void ShowWindow()
    {
        ImageExpandTool window = GetWindow<ImageExpandTool>("图片扩充工具");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("图片扩充工具", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        // 文件夹选择
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("文件夹路径:", GUILayout.Width(100));
        EditorGUILayout.TextField(folderPath);
        if (GUILayout.Button("选择文件夹", GUILayout.Width(100)))
        {
            string path = EditorUtility.OpenFolderPanel("选择包含图片的文件夹", "Assets", "");
            if (!string.IsNullOrEmpty(path))
            {
                // 转换为相对路径（如果在Assets目录下）
                if (path.StartsWith(Application.dataPath))
                {
                    folderPath = "Assets" + path.Substring(Application.dataPath.Length);
                }
                else
                {
                    folderPath = path;
                }
            }
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        // 说明
        EditorGUILayout.HelpBox(
            "说明：\n" +
            "1. 选择包含图片的文件夹\n" +
            "2. 点击扩充按钮开始处理\n" +
            "3. 图片将扩充到1:1比例，按宽高较大值作为目标尺寸\n" +
            "4. 扩充部分用透明填充，以中心点对称扩充\n" +
            "5. 扩充后的图片会覆盖原文件",
            MessageType.Info);

        EditorGUILayout.Space();

        // 扩充按钮
        GUI.enabled = !string.IsNullOrEmpty(folderPath);
        if (GUILayout.Button("开始扩充", GUILayout.Height(30)))
        {
            ExpandImages();
        }
        GUI.enabled = true;
    }

    private void ExpandImages()
    {
        if (string.IsNullOrEmpty(folderPath))
        {
            EditorUtility.DisplayDialog("错误", "请先选择文件夹", "确定");
            return;
        }

        string fullPath = folderPath;
        if (folderPath.StartsWith("Assets"))
        {
            fullPath = Path.Combine(Application.dataPath, folderPath.Substring(7));
        }

        if (!Directory.Exists(fullPath))
        {
            EditorUtility.DisplayDialog("错误", "文件夹不存在", "确定");
            return;
        }

        // 获取所有支持的图片文件
        string[] imageFiles = GetImageFiles(fullPath);
        
        if (imageFiles.Length == 0)
        {
            EditorUtility.DisplayDialog("提示", "未找到支持的图片文件", "确定");
            return;
        }

        // 确认对话框
        if (!EditorUtility.DisplayDialog(
            "确认扩充",
            $"找到 {imageFiles.Length} 张图片，将扩充到1:1比例。\n" +
            "扩充后的图片将覆盖原文件，此操作不可撤销！\n\n" +
            "是否继续？",
            "继续",
            "取消"))
        {
            return;
        }

        int successCount = 0;
        int failCount = 0;

        // 处理每张图片
        for (int i = 0; i < imageFiles.Length; i++)
        {
            string filePath = imageFiles[i];
            EditorUtility.DisplayProgressBar(
                "扩充图片",
                $"正在处理: {Path.GetFileName(filePath)} ({i + 1}/{imageFiles.Length})",
                (float)(i + 1) / imageFiles.Length);

            try
            {
                if (ExpandImage(filePath))
                {
                    successCount++;
                }
                else
                {
                    failCount++;
                    Debug.LogWarning($"[图片扩充] 扩充失败: {filePath}");
                }
            }
            catch (System.Exception e)
            {
                failCount++;
                Debug.LogError($"[图片扩充] 处理图片时出错: {filePath}\n错误: {e.Message}");
            }
        }

        EditorUtility.ClearProgressBar();

        // 刷新资源数据库（如果在Assets目录下）
        if (folderPath.StartsWith("Assets"))
        {
            AssetDatabase.Refresh();
        }

        // 显示结果
        EditorUtility.DisplayDialog(
            "扩充完成",
            $"处理完成！\n" +
            $"成功: {successCount} 张\n" +
            $"失败: {failCount} 张",
            "确定");

        Debug.Log($"[图片扩充] 处理完成 - 成功: {successCount}, 失败: {failCount}");
    }

    private string[] GetImageFiles(string folderPath)
    {
        System.Collections.Generic.List<string> imageFiles = new System.Collections.Generic.List<string>();

        foreach (string format in supportedFormats)
        {
            string[] files = Directory.GetFiles(folderPath, "*" + format, SearchOption.TopDirectoryOnly);
            imageFiles.AddRange(files);
        }

        return imageFiles.ToArray();
    }

    private bool ExpandImage(string imagePath)
    {
        // 读取图片数据
        byte[] imageData = File.ReadAllBytes(imagePath);
        Texture2D originalTexture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
        
        if (!originalTexture.LoadImage(imageData))
        {
            Debug.LogWarning($"[图片扩充] 无法加载图片: {imagePath}");
            return false;
        }

        int originalWidth = originalTexture.width;
        int originalHeight = originalTexture.height;

        // 计算目标尺寸（取宽高中的较大值）
        int targetSize = Mathf.Max(originalWidth, originalHeight);

        // 如果已经是1:1比例，不需要处理
        if (originalWidth == targetSize && originalHeight == targetSize)
        {
            Debug.Log($"[图片扩充] 图片已经是1:1比例，跳过: {imagePath}");
            DestroyImmediate(originalTexture);
            return true;
        }

        // 计算偏移量（中心点对齐）
        int offsetX = (targetSize - originalWidth) / 2;
        int offsetY = (targetSize - originalHeight) / 2;

        // 创建新的纹理并扩充
        Texture2D expandedTexture = new Texture2D(targetSize, targetSize, TextureFormat.RGBA32, false);
        
        // 填充透明背景
        Color[] transparentPixels = new Color[targetSize * targetSize];
        for (int i = 0; i < transparentPixels.Length; i++)
        {
            transparentPixels[i] = Color.clear;
        }
        expandedTexture.SetPixels(transparentPixels);
        
        // 复制原始图片到中心
        Color[] originalPixels = originalTexture.GetPixels();
        expandedTexture.SetPixels(offsetX, offsetY, originalWidth, originalHeight, originalPixels);
        expandedTexture.Apply();

        // 编码为PNG格式（保证透明通道）
        byte[] encodedData = expandedTexture.EncodeToPNG();

        // 写入文件（覆盖原文件）
        File.WriteAllBytes(imagePath, encodedData);

        // 清理
        DestroyImmediate(originalTexture);
        DestroyImmediate(expandedTexture);

        return true;
    }
}
#endif