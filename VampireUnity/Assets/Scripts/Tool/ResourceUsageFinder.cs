#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 资源使用情况查找工具
/// 功能：选择一个文件夹，找出该文件夹中被项目使用的资源，并显示使用位置
/// </summary>
public class ResourceUsageFinder : EditorWindow
{
    private DefaultAsset folderAsset;
    private Vector2 scrollPosition;
    private List<ResourceUsageInfo> usageList = new List<ResourceUsageInfo>();
    private bool isScanning = false;
    private string scanStatus = "";

    [MenuItem("Tool/查找资源使用情况", priority = 2)]
    private static void OpenWindow()
    {
        var window = GetWindow<ResourceUsageFinder>("资源使用情况查找");
        window.minSize = new Vector2(600, 400);
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("资源使用情况查找工具", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        // 文件夹选择
        EditorGUILayout.LabelField("1. 选择一个文件夹（Project 中）");
        folderAsset = (DefaultAsset)EditorGUILayout.ObjectField("目标文件夹", folderAsset, typeof(DefaultAsset), false);

        EditorGUILayout.Space();

        // 说明
        EditorGUILayout.HelpBox(
            "功能说明：\n" +
            "• 扫描选中文件夹中的所有资源\n" +
            "• 只检查资源是否在游戏中被真正使用\n" +
            "• 检查范围：场景文件、代码文件、Resources文件夹\n" +
            "• 点击结果可以定位到使用位置",
            MessageType.Info);

        EditorGUILayout.Space();

        // 扫描按钮
        GUI.enabled = folderAsset != null && !isScanning;
        if (GUILayout.Button("开始扫描", GUILayout.Height(30)))
        {
            ScanResources();
        }
        GUI.enabled = true;

        if (isScanning)
        {
            EditorGUILayout.HelpBox($"正在扫描... {scanStatus}", MessageType.Info);
        }

        EditorGUILayout.Space();

        // 结果显示
        if (usageList.Count > 0)
        {
            EditorGUILayout.LabelField($"找到 {usageList.Count} 个被使用的资源", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

            foreach (var usage in usageList)
            {
                DrawUsageInfo(usage);
            }

            EditorGUILayout.EndScrollView();
        }
    }

    private void ScanResources()
    {
        if (folderAsset == null)
        {
            EditorUtility.DisplayDialog("错误", "请先选择一个文件夹。", "确定");
            return;
        }

        string folderPath = AssetDatabase.GetAssetPath(folderAsset);
        if (string.IsNullOrEmpty(folderPath) || !AssetDatabase.IsValidFolder(folderPath))
        {
            EditorUtility.DisplayDialog("错误", "所选对象不是有效的文件夹，请重新选择。", "确定");
            return;
        }

        isScanning = true;
        usageList.Clear();

        try
        {
            // 获取文件夹下所有资源
            string[] allGuids = AssetDatabase.FindAssets("", new[] { folderPath });
            Dictionary<string, string> folderResources = new Dictionary<string, string>(); // GUID -> Path

            foreach (string guid in allGuids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                if (!string.IsNullOrEmpty(path) && !path.EndsWith(".meta"))
                {
                    folderResources[guid] = path;
                }
            }

            if (folderResources.Count == 0)
            {
                EditorUtility.DisplayDialog("提示", "文件夹中没有找到任何资源。", "确定");
                return;
            }

            scanStatus = "正在建立索引...";
            Repaint();

            // 优化：先建立反向索引（GUID -> 使用位置列表）
            Dictionary<string, HashSet<string>> guidToUsages = BuildReverseIndex(folderResources.Keys.ToHashSet());

            scanStatus = $"正在匹配资源...";
            Repaint();

            // 对每个文件夹资源查找使用情况（直接从索引中查找）
            foreach (var kvp in folderResources)
            {
                string guid = kvp.Key;
                string assetPath = kvp.Value;
                
                if (guidToUsages.TryGetValue(guid, out HashSet<string> usages) && usages.Count > 0)
                {
                    usageList.Add(new ResourceUsageInfo
                    {
                        resourcePath = assetPath,
                        usagePaths = usages.ToList()
                    });
                }
            }

            // 按资源路径排序
            usageList.Sort((a, b) => string.Compare(a.resourcePath, b.resourcePath));
        }
        catch (Exception e)
        {
            EditorUtility.DisplayDialog("错误", $"扫描过程中出错：\n{e.Message}", "确定");
            Debug.LogError($"[资源使用情况查找] 错误: {e}");
        }
        finally
        {
            isScanning = false;
            scanStatus = "";
            Repaint();
        }
    }

    // 建立反向索引：只扫描真正被游戏使用的资源（代码、场景、Resources文件夹）
    private Dictionary<string, HashSet<string>> BuildReverseIndex(HashSet<string> targetGuids)
    {
        Dictionary<string, HashSet<string>> guidToUsages = new Dictionary<string, HashSet<string>>();
        
        // 初始化字典
        foreach (string guid in targetGuids)
        {
            guidToUsages[guid] = new HashSet<string>();
            
            // 检查资源是否在Resources文件夹中（Resources文件夹中的资源可能被代码动态加载）
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            if (!string.IsNullOrEmpty(assetPath) && IsInResourcesFolder(assetPath))
            {
                guidToUsages[guid].Add("[Resources文件夹]");
            }
        }

        // 1. 扫描场景文件（场景中使用的资源才是真正被用到的）
        scanStatus = "正在扫描场景文件...";
        Repaint();
        string[] allScenes = AssetDatabase.FindAssets("t:SceneAsset");
        ScanFilesForGuids(allScenes, targetGuids, guidToUsages);

        // 2. 扫描代码文件（检查Resources.Load、AssetDatabase.LoadAssetAtPath等）
        scanStatus = "正在扫描代码文件...";
        Repaint();
        string[] allScripts = AssetDatabase.FindAssets("t:MonoScript");
        ScanScriptsForResources(allScripts, targetGuids, guidToUsages);

        return guidToUsages;
    }

    // 检查资源是否在Resources文件夹中
    private bool IsInResourcesFolder(string assetPath)
    {
        return assetPath.IndexOf("/Resources/", StringComparison.OrdinalIgnoreCase) >= 0;
    }

    // 扫描文件中的GUID引用
    private void ScanFilesForGuids(string[] fileGuids, HashSet<string> targetGuids, Dictionary<string, HashSet<string>> guidToUsages)
    {
        for (int i = 0; i < fileGuids.Length; i++)
        {
            string fileGuid = fileGuids[i];
            string filePath = AssetDatabase.GUIDToAssetPath(fileGuid);
            
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                continue;

            try
            {
                string content = File.ReadAllText(filePath);
                
                // 检查每个目标GUID
                foreach (string targetGuid in targetGuids)
                {
                    if (content.Contains(targetGuid))
                    {
                        guidToUsages[targetGuid].Add(filePath);
                    }
                }
            }
            catch
            {
                // 忽略无法读取的文件
            }
        }
    }

    // 扫描代码文件中的Resources.Load等引用
    private void ScanScriptsForResources(string[] scriptGuids, HashSet<string> targetGuids, Dictionary<string, HashSet<string>> guidToUsages)
    {
        // 建立资源路径到GUID的映射（使用HashSet提高查找速度）
        Dictionary<string, HashSet<string>> pathToGuids = new Dictionary<string, HashSet<string>>();
        foreach (string guid in targetGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            if (string.IsNullOrEmpty(path))
                continue;

            AddPathMapping(pathToGuids, path, guid);
            AddPathMapping(pathToGuids, path.Replace("\\", "/"), guid);
            
            string fileName = Path.GetFileNameWithoutExtension(path);
            string fileNameWithExt = Path.GetFileName(path);
            AddPathMapping(pathToGuids, fileName, guid);
            AddPathMapping(pathToGuids, fileNameWithExt, guid);
            
            // Resources路径
            string resourcesPath = ConvertToResourcesPath(path);
            if (!string.IsNullOrEmpty(resourcesPath))
            {
                AddPathMapping(pathToGuids, resourcesPath, guid);
                AddPathMapping(pathToGuids, resourcesPath.Replace("\\", "/"), guid);
                string resourceName = Path.GetFileNameWithoutExtension(resourcesPath);
                AddPathMapping(pathToGuids, resourceName, guid);
            }
        }

        for (int i = 0; i < scriptGuids.Length; i++)
        {
            string scriptGuid = scriptGuids[i];
            string scriptPath = AssetDatabase.GUIDToAssetPath(scriptGuid);
            
            if (string.IsNullOrEmpty(scriptPath) || !File.Exists(scriptPath))
                continue;

            try
            {
                string content = File.ReadAllText(scriptPath);
                
                // 只检查包含Load关键字的脚本
                bool hasResourcesLoad = content.Contains("Resources.Load") || content.Contains("Resources.LoadAll");
                bool hasAssetDatabaseLoad = content.Contains("AssetDatabase.LoadAssetAtPath");
                
                if (!hasResourcesLoad && !hasAssetDatabaseLoad)
                    continue;
                
                // 检查Resources.Load引用
                if (hasResourcesLoad)
                {
                    foreach (var kvp in pathToGuids)
                    {
                        string searchKey = kvp.Key;
                        HashSet<string> guids = kvp.Value;
                        
                        // 检查是否包含资源路径（使用引号包围）
                        if (content.Contains($"\"{searchKey}\"") || content.Contains($"'{searchKey}'"))
                        {
                            foreach (string guid in guids)
                            {
                                guidToUsages[guid].Add(scriptPath);
                            }
                        }
                    }
                }

                // 检查AssetDatabase.LoadAssetAtPath引用
                if (hasAssetDatabaseLoad)
                {
                    foreach (var kvp in pathToGuids)
                    {
                        string searchKey = kvp.Key;
                        HashSet<string> guids = kvp.Value;
                        
                        if (content.Contains($"\"{searchKey}\"") || content.Contains($"'{searchKey}'"))
                        {
                            foreach (string guid in guids)
                            {
                                guidToUsages[guid].Add(scriptPath);
                            }
                        }
                    }
                }
            }
            catch
            {
                // 忽略无法读取的文件
            }
        }
    }

    private void AddPathMapping(Dictionary<string, HashSet<string>> pathToGuids, string path, string guid)
    {
        if (string.IsNullOrEmpty(path))
            return;
            
        if (!pathToGuids.ContainsKey(path))
        {
            pathToGuids[path] = new HashSet<string>();
        }
        pathToGuids[path].Add(guid);
    }


    private string ConvertToResourcesPath(string assetPath)
    {
        // 检查是否在Resources文件夹下
        int resourcesIndex = assetPath.IndexOf("/Resources/", StringComparison.OrdinalIgnoreCase);
        if (resourcesIndex >= 0)
        {
            string relativePath = assetPath.Substring(resourcesIndex + "/Resources/".Length);
            // 去掉扩展名
            return Path.ChangeExtension(relativePath, null);
        }
        return null;
    }

    private void DrawUsageInfo(ResourceUsageInfo usage)
    {
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        
        // 资源路径（可点击）
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("资源:", GUILayout.Width(50));
        if (GUILayout.Button(usage.resourcePath, EditorStyles.linkLabel))
        {
            PingAsset(usage.resourcePath);
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(2);

        // 使用位置列表
        EditorGUILayout.LabelField($"使用位置 ({usage.usagePaths.Count}):", EditorStyles.miniLabel);
        EditorGUI.indentLevel++;
        foreach (string usagePath in usage.usagePaths)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(20);
            
            // 显示使用类型图标
            string typeLabel = GetUsageTypeLabel(usagePath);
            EditorGUILayout.LabelField(typeLabel, GUILayout.Width(60));
            
            // Resources文件夹标记不能点击
            if (usagePath == "[Resources文件夹]")
            {
                EditorGUILayout.LabelField(usagePath, EditorStyles.label);
            }
            else
            {
                if (GUILayout.Button(usagePath, EditorStyles.linkLabel))
                {
                    PingAsset(usagePath);
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUI.indentLevel--;

        EditorGUILayout.EndVertical();
        EditorGUILayout.Space(5);
    }

    private string GetUsageTypeLabel(string path)
    {
        if (path == "[Resources文件夹]")
            return "[Resources]";
        else if (path.EndsWith(".unity"))
            return "[场景]";
        else if (path.EndsWith(".cs"))
            return "[代码]";
        else
            return "[其他]";
    }

    private void PingAsset(string path)
    {
        UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
        if (obj != null)
        {
            EditorGUIUtility.PingObject(obj);
            Selection.activeObject = obj;
        }
    }

    private class ResourceUsageInfo
    {
        public string resourcePath;
        public List<string> usagePaths = new List<string>();
    }
}
#endif

