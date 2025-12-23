#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

/// <summary>
/// 构建报告资源查看器
/// 在 Unity 菜单 Tool/查看构建报告资源
/// 作用：解析 Build Report，列出被打包的具体资源，支持搜索与大文件过滤
/// </summary>
public class BuildReportViewer : EditorWindow
{
    private BuildReport buildReport;
    private Vector2 scrollPosition;
    private Dictionary<string, List<PackedAssetInfo>> assetGroups = new Dictionary<string, List<PackedAssetInfo>>();
    private string searchFilter = "";
    private bool showOnlyLargeAssets;
    private long sizeThreshold = 1024 * 1024; // 1MB

    [MenuItem("Tool/查看构建报告资源", priority = 3)]
    private static void OpenWindow()
    {
        var window = GetWindow<BuildReportViewer>("构建报告资源查看器");
        window.minSize = new Vector2(800, 500);

        // 尝试加载最近构建（兼容旧版没有 lastBuildReport 的情况）
        window.buildReport = window.TryGetLastBuildReport();
        if (window.buildReport != null)
        {
            window.ParseBuildReport();
        }
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("构建报告资源查看器", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        // 选择或加载构建报告
        EditorGUILayout.BeginHorizontal();
        buildReport = (BuildReport)EditorGUILayout.ObjectField("构建报告", buildReport, typeof(BuildReport), false);
        if (GUILayout.Button("加载最近构建", GUILayout.Width(110)))
        {
            buildReport = TryGetLastBuildReport();
            if (buildReport == null)
            {
                EditorUtility.DisplayDialog("提示", "没有找到最近的构建报告，请先执行一次 Build。", "确定");
            }
            else
            {
                ParseBuildReport();
            }
        }
        if (GUILayout.Button("解析报告", GUILayout.Width(90)))
        {
            ParseBuildReport();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        if (buildReport == null)
        {
            EditorGUILayout.HelpBox(
                "请选择一个构建报告，或点击“加载最近构建”。\n构建报告文件通常位于 Library/LastBuild.buildreport。",
                MessageType.Info);
            return;
        }

        // 基本信息
        EditorGUILayout.LabelField($"平台: {buildReport.summary.platform}", EditorStyles.boldLabel);
        EditorGUILayout.LabelField($"输出路径: {buildReport.summary.outputPath}");
        EditorGUILayout.LabelField($"总大小: {FormatBytes((ulong)buildReport.summary.totalSize)}");
        EditorGUILayout.LabelField($"文件数量: {buildReport.GetFiles()?.Length ?? 0}");
        EditorGUILayout.Space();

        // 搜索与过滤
        EditorGUILayout.BeginHorizontal();
        searchFilter = EditorGUILayout.TextField("搜索资源路径:", searchFilter);
        showOnlyLargeAssets = EditorGUILayout.ToggleLeft("只显示大文件 (>1MB)", showOnlyLargeAssets, GUILayout.Width(180));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        if (assetGroups.Count == 0)
        {
            EditorGUILayout.HelpBox("点击“解析报告”按钮来解析构建报告。", MessageType.Info);
            return;
        }

        DisplayAssets();
    }

    private void ParseBuildReport()
    {
        assetGroups.Clear();

        if (buildReport == null || buildReport.GetFiles() == null)
            return;

        // 兼容旧版 Unity：只能拿到 BuildFile（打包出来的文件），不能直接拿到其中每个资源
        // 这里将每个 BuildFile 作为一条“资源记录”展示出来，方便看到哪些打包文件占空间
        foreach (var file in buildReport.GetFiles())
        {
            string fileName = Path.GetFileName(file.path);
            if (!assetGroups.ContainsKey(fileName))
            {
                assetGroups[fileName] = new List<PackedAssetInfo>();
            }

            assetGroups[fileName].Add(new PackedAssetInfo
            {
                assetPath = file.path,   // 无法细分到具体 Asset，只能显示打包文件路径
                filePath = file.path,
                fileSize = (long)file.size
            });
        }

        // 按文件名排序
        var sortedKeys = assetGroups.Keys.OrderBy(k => k).ToList();
        var sortedGroups = new Dictionary<string, List<PackedAssetInfo>>();
        foreach (var key in sortedKeys)
        {
            sortedGroups[key] = assetGroups[key];
        }
        assetGroups = sortedGroups;
    }

    private void DisplayAssets()
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        long totalAssetSize = 0;
        int displayedCount = 0;

        foreach (var group in assetGroups)
        {
            string fileName = group.Key;
            var assets = group.Value;

            var filteredAssets = assets.Where(a =>
                (string.IsNullOrEmpty(searchFilter) ||
                 a.assetPath.IndexOf(searchFilter, System.StringComparison.OrdinalIgnoreCase) >= 0) &&
                (!showOnlyLargeAssets || a.fileSize > sizeThreshold)
            ).ToList();

            if (filteredAssets.Count == 0)
                continue;

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField($"文件: {fileName}", EditorStyles.boldLabel);
            EditorGUILayout.LabelField($"大小: {FormatBytes((ulong)assets.First().fileSize)}", GUILayout.Width(120));
            EditorGUILayout.LabelField($"资源数: {filteredAssets.Count}", GUILayout.Width(90));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(2);

            EditorGUI.indentLevel++;
            foreach (var asset in filteredAssets)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Space(20);

                if (GUILayout.Button(asset.assetPath, EditorStyles.linkLabel, GUILayout.ExpandWidth(true)))
                {
                    var obj = AssetDatabase.LoadAssetAtPath<Object>(asset.assetPath);
                    if (obj != null)
                    {
                        EditorGUIUtility.PingObject(obj);
                        Selection.activeObject = obj;
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUI.indentLevel--;

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(5);

            totalAssetSize += assets.First().fileSize;
            displayedCount += filteredAssets.Count;
        }

        EditorGUILayout.EndScrollView();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField($"显示 {displayedCount} 个资源（过滤后），合计文件大小: {FormatBytes((ulong)totalAssetSize)}", EditorStyles.centeredGreyMiniLabel);
    }

    private BuildReport TryGetLastBuildReport()
    {
        // 1) 高版本 Unity: 通过 BuildPipeline.lastBuildReport 属性
        var prop = typeof(BuildPipeline).GetProperty("lastBuildReport", BindingFlags.Public | BindingFlags.Static);
        if (prop != null)
        {
            try
            {
                var report = prop.GetValue(null) as BuildReport;
                if (report != null) return report;
            }
            catch
            {
                // ignore
            }
        }

        // 2) 兼容旧版本：直接从默认路径加载
        const string defaultReportPath = "Library/LastBuild.buildreport";
        var assetReport = AssetDatabase.LoadAssetAtPath<BuildReport>(defaultReportPath);
        if (assetReport != null) return assetReport;

        return null;
    }

    private string FormatBytes(ulong bytes)
    {
        string[] sizes = { "B", "KB", "MB", "GB" };
        double len = bytes;
        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len /= 1024;
        }
        return $"{len:0.##} {sizes[order]}";
    }

    private class PackedAssetInfo
    {
        public string assetPath;
        public string filePath;
        public long fileSize;
    }
}
#endif

