#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

public static class ClearSaveTool
{
    [MenuItem("Tool/清除存档", priority = 0)]
    public static void ClearSaveData()
    {
        var path1 = Path.Combine(Application.persistentDataPath, "store1.json");
        if (File.Exists(path1))
        {
            File.Delete(path1);
            EditorUtility.DisplayDialog("清除存档", $"已删除存档：\n{path1}", "确定");
        }
        else
        {
            EditorUtility.DisplayDialog("清除存档", $"未找到存档文件：\n{path1}", "确定");
        }
        
        var path2 = Path.Combine(Application.persistentDataPath, "store2.json");
        if (File.Exists(path2))
        {
            File.Delete(path2);
            EditorUtility.DisplayDialog("清除存档", $"已删除存档：\n{path2}", "确定");
        }
        else
        {
            EditorUtility.DisplayDialog("清除存档", $"未找到存档文件：\n{path2}", "确定");
        }
        
        var path3 = Path.Combine(Application.persistentDataPath, "store3.json");
        if (File.Exists(path3))
        {
            File.Delete(path3);
            EditorUtility.DisplayDialog("清除存档", $"已删除存档：\n{path3}", "确定");
        }
        else
        {
            EditorUtility.DisplayDialog("清除存档", $"未找到存档文件：\n{path3}", "确定");
        }
    }
}
#endif





