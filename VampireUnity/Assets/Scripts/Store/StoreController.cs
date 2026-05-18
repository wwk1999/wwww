using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class StoreController : XSingleton<StoreController>
{
    public StoreDefine.StoreData StoreData;
    private float currentTime = 0;
    private float saveTime = 10;
    public int CurrentSaveSlot = 1;
    public bool IsGame = false;

    private string SavePath => GetSavePath();


    public string GetSavePath()
    {
        switch (CurrentSaveSlot)
        {
            case 1:
                return Path.Combine(Application.persistentDataPath, "store1.json");
            case 2:
                return Path.Combine(Application.persistentDataPath, "store2.json");
            case 3:
                return Path.Combine(Application.persistentDataPath, "store3.json");
            default:
                // 默认返回存档槽1的路径，避免空路径导致的错误
                return Path.Combine(Application.persistentDataPath, "store1.json");
        }
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > saveTime&&IsGame)
        {
            SaveStoreData();
            currentTime = 0;
        }
    }

    public void SaveStoreData(StoreDefine.StoreData data = null)
    {
        try
        {
            StoreData = data ?? StoreData ?? new StoreDefine.StoreData();
            StoreData.Player.CopyFromRuntime(PlayerData.S);
            StoreData.Equip.CopyFromRuntime(EquipIDData.S);
            StoreData.Skill.CopyFromRuntime(SkillData.S);
            StoreData.SkillJiaDian1.CopyFromRuntime(SkillJiaDian.S);
            var json = JsonConvert.SerializeObject(StoreData, Newtonsoft.Json.Formatting.None);

            File.WriteAllText(SavePath, json);

            Debug.Log($"保存数据成功->{SavePath}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"保存数据失败: {e.Message}");
            Debug.LogError($"异常类型: {e.GetType().Name}");
            Debug.LogError($"堆栈跟踪: {e.StackTrace}");

            // 检查各个单例对象是否存在
            Debug.Log($"PlayerData.S 存在: {PlayerData.S != null}");
            Debug.Log($"EquipIDData.S 存在: {EquipIDData.S != null}");
            Debug.Log($"SkillData.S 存在: {SkillData.S != null}");
            Debug.Log($"SkillJiaDian.S 存在: {SkillJiaDian.S != null}");
        }
    }

    public bool GetStoreIsEmpty(int slot)
    {
        switch (slot)
        {
            case 1:
                var path1 = Path.Combine(Application.persistentDataPath, "store1.json");
                return !File.Exists(path1);
            case 2:
                var path2 = Path.Combine(Application.persistentDataPath, "store2.json");
                return !File.Exists(path2);
            case 3:
                var path3 = Path.Combine(Application.persistentDataPath, "store3.json");
                return !File.Exists(path3);
        }
        return true;
    }

    public StoreDefine.StoreData GetStoreData(int slot)
    {
        switch (slot)
        {
            case 1:
                var path1 = Path.Combine(Application.persistentDataPath, "store1.json");
                var json1 = File.ReadAllText(path1);
                StoreData = JsonConvert.DeserializeObject<StoreDefine.StoreData>(json1);
                return StoreData;
            case 2:
                var path2 = Path.Combine(Application.persistentDataPath, "store2.json");
                var json2 = File.ReadAllText(path2);
                StoreData = JsonConvert.DeserializeObject<StoreDefine.StoreData>(json2);
                return StoreData;
            case 3:
                var path3 = Path.Combine(Application.persistentDataPath, "store3.json");
                var json3 = File.ReadAllText(path3);
                StoreData = JsonConvert.DeserializeObject<StoreDefine.StoreData>(json3);
                return StoreData;
        }

        return null;
    }

    public void LoadStoreData()
    {
        var path = SavePath;
        if (!File.Exists(path))
        {
            StoreData = new StoreDefine.StoreData();
            StoreData.Player.CopyFromRuntime(PlayerData.S);
            StoreData.Equip.CopyFromRuntime(EquipIDData.S);
            StoreData.Skill.CopyFromRuntime(SkillData.S);
            StoreData.SkillJiaDian1.CopyFromRuntime(SkillJiaDian.S);

            SaveStoreData(StoreData);
            Debug.Log("首次创建存档");
            return;
        }

        try
        {
            var json = File.ReadAllText(path);
            StoreData = JsonConvert.DeserializeObject<StoreDefine.StoreData>(json);
            StoreData.Player.ApplyToRuntime(PlayerData.S);
            StoreData.Equip.ApplyToRuntime(EquipIDData.S);
            StoreData.Skill.ApplyToRuntime(SkillData.S);
            StoreData.SkillJiaDian1.ApplyToRuntime(SkillJiaDian.S);



            BagController.S.WhiteEquipidTable.Clear();
            BagController.S.GreenEquipidTable.Clear();
            BagController.S.BlueEquipidTable.Clear();
            BagController.S.PurpleEquipidTable.Clear();
            BagController.S.OrangeEquipidTable.Clear();
            BagController.S.RedEquipidTable.Clear();

            foreach (var equip in BagController.S.EquipIdList)
            {
                if (equip.Value.Quality == 1) // 白色装备
                {
                    BagController.S.WhiteEquipidTable.Add(equip.Value);
                }
                else if (equip.Value.Quality == 2) // 绿色装备
                {
                    BagController.S.GreenEquipidTable.Add(equip.Value);
                }
                else if (equip.Value.Quality == 3) // 蓝色装备
                {
                    BagController.S.BlueEquipidTable.Add(equip.Value);
                }
                else if (equip.Value.Quality == 4) // 紫色装备
                {
                    BagController.S.PurpleEquipidTable.Add(equip.Value);
                }
                else if (equip.Value.Quality == 5) // 金色装备
                {
                    BagController.S.OrangeEquipidTable.Add(equip.Value);
                }
                else if (equip.Value.Quality == 6) // 红色装备
                {
                    BagController.S.RedEquipidTable.Add(equip.Value);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        Debug.Log("加载数据完成");
    }
}
