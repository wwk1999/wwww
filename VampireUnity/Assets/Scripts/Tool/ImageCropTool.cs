#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

public class ImageCropTool : EditorWindow
{
    private string folderPath = "";
    private int targetWidth = 300;
    private int targetHeight = 300;
    private Vector2 scrollPosition;
    private string[] supportedFormats = { ".png", ".jpg", ".jpeg" };

    [MenuItem("Tool/裁剪图片", priority = 1)]
    public static void ShowWindow()
    {
        ImageCropTool window = GetWindow<ImageCropTool>("图片裁剪工具");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("图片裁剪工具", EditorStyles.boldLabel);
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

        // 目标尺寸输入
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("目标宽度:", GUILayout.Width(100));
        targetWidth = EditorGUILayout.IntField(targetWidth);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("目标高度:", GUILayout.Width(100));
        targetHeight = EditorGUILayout.IntField(targetHeight);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        // 说明
        EditorGUILayout.HelpBox(
            "说明：\n" +
            "1. 选择包含图片的文件夹\n" +
            "2. 输入目标尺寸（宽度和高度）\n" +
            "3. 点击裁剪按钮开始处理\n" +
            "4. 图片将从中心裁剪，裁剪后的图片会覆盖原文件",
            MessageType.Info);

        EditorGUILayout.Space();

        // 裁剪按钮
        GUI.enabled = !string.IsNullOrEmpty(folderPath) && targetWidth > 0 && targetHeight > 0;
        if (GUILayout.Button("开始裁剪", GUILayout.Height(30)))
        {
            CropImages();
        }
        GUI.enabled = true;
    }

    private void CropImages()
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
            "确认裁剪",
            $"找到 {imageFiles.Length} 张图片，将裁剪为 {targetWidth}x{targetHeight} 尺寸。\n" +
            "裁剪后的图片将覆盖原文件，此操作不可撤销！\n\n" +
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
                "裁剪图片",
                $"正在处理: {Path.GetFileName(filePath)} ({i + 1}/{imageFiles.Length})",
                (float)(i + 1) / imageFiles.Length);

            try
            {
                if (CropImage(filePath, targetWidth, targetHeight))
                {
                    successCount++;
                }
                else
                {
                    failCount++;
                    Debug.LogWarning($"[图片裁剪] 裁剪失败: {filePath}");
                }
            }
            catch (System.Exception e)
            {
                failCount++;
                Debug.LogError($"[图片裁剪] 处理图片时出错: {filePath}\n错误: {e.Message}");
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
            "裁剪完成",
            $"处理完成！\n" +
            $"成功: {successCount} 张\n" +
            $"失败: {failCount} 张",
            "确定");

        Debug.Log($"[图片裁剪] 处理完成 - 成功: {successCount}, 失败: {failCount}");
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

    private bool CropImage(string imagePath, int targetWidth, int targetHeight)
    {
        // 读取图片数据
        byte[] imageData = File.ReadAllBytes(imagePath);
        Texture2D originalTexture = new Texture2D(2, 2);
        
        if (!originalTexture.LoadImage(imageData))
        {
            Debug.LogWarning($"[图片裁剪] 无法加载图片: {imagePath}");
            return false;
        }

        int originalWidth = originalTexture.width;
        int originalHeight = originalTexture.height;

        // 检查原始尺寸是否小于目标尺寸
        if (originalWidth < targetWidth || originalHeight < targetHeight)
        {
            Debug.LogWarning($"[图片裁剪] 图片尺寸 ({originalWidth}x{originalHeight}) 小于目标尺寸 ({targetWidth}x{targetHeight}): {imagePath}");
            return false;
        }

        // 计算裁剪区域（从中心裁剪）
        int cropX = (originalWidth - targetWidth) / 2;
        int cropY = (originalHeight - targetHeight) / 2;

        // 创建新的纹理并裁剪
        Texture2D croppedTexture = new Texture2D(targetWidth, targetHeight, originalTexture.format, false);
        Color[] pixels = originalTexture.GetPixels(cropX, cropY, targetWidth, targetHeight);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();

        // 根据原文件扩展名决定编码格式
        string extension = Path.GetExtension(imagePath).ToLower();
        byte[] encodedData = null;

        if (extension == ".jpg" || extension == ".jpeg")
        {
            encodedData = croppedTexture.EncodeToJPG();
        }
        else if (extension == ".png")
        {
            encodedData = croppedTexture.EncodeToPNG();
        }
        else
        {
            Debug.LogWarning($"[图片裁剪] 不支持的图片格式: {extension}，将转换为PNG格式: {imagePath}");
            encodedData = croppedTexture.EncodeToPNG();
        }

        // 写入文件（覆盖原文件）
        File.WriteAllBytes(imagePath, encodedData);

        // 清理
        DestroyImmediate(originalTexture);
        DestroyImmediate(croppedTexture);

        return true;
    }
}
#endif

