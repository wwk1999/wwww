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

    private string SavePath => Path.Combine(Application.persistentDataPath, "store.json");

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > saveTime)
        {
            SaveStoreData();
            currentTime = 0;
        }
    }

    public void SaveStoreData(StoreDefine.StoreData data = null)
    {
        try
        {
            Debug.Log("开始保存数据...");
            StoreData = data ?? StoreData ?? new StoreDefine.StoreData();
            Debug.Log("StoreData 初始化完成");


            Debug.Log("复制Player数据...");
            StoreData.Player.CopyFromRuntime(PlayerData.S);
            Debug.Log("复制Equip数据...");
            StoreData.Equip.CopyFromRuntime(EquipIDData.S);
            Debug.Log("复制Skill数据...");
            StoreData.Skill.CopyFromRuntime(SkillData.S);
            Debug.Log("复制SkillJiaDian数据...");
            StoreData.SkillJiaDian1.CopyFromRuntime(SkillJiaDian.S);
            Debug.Log("数据复制完成");


            Debug.Log("开始序列化...");
            var json = JsonConvert.SerializeObject(StoreData, Newtonsoft.Json.Formatting.None);
            Debug.Log($"序列化完成，JSON长度: {json.Length}");

            Debug.Log($"保存路径: {SavePath}");
            File.WriteAllText(SavePath, json);
            Debug.Log("文件写入完成");

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
