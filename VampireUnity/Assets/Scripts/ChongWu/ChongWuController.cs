using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChongWuController:XSingleton<ChongWuController>
{
    public int CurrentChongWuPageNum = 1;
    public List<ChongWuListItem>CurrentPageItemList=new List<ChongWuListItem>();
    public bool isLeftMouseDown = false;
    public ChongWuTable FuChongWuTable;

    private void Update()
    {
    }

    public static List<int> GetUniqueRandomDigits(int count)
    {
        if (count < 1 || count > 6)
            throw new System.ArgumentOutOfRangeException(nameof(count), "参数必须介于1到6之间。");

        List<int> candidates = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        List<int> result = new List<int>();

        for (int i = 0; i < count; i++)
        {
            int index = UnityEngine.Random.Range(0, candidates.Count);
            result.Add(candidates[index]);
            candidates.RemoveAt(index);
        }

        return result;
    }
    
    //开宠物蛋
    public ChongWuTable GetOriginChongWuTable(ChongWuType chongWuType)
    {
        int quality = ChongWuConfig.GetChongWuQualityByType(chongWuType);
        ChongWuConfig.MinMax zizhiMinMax = ChongWuConfig.ChongWuZiZhiDic[quality];
        ChongWuConfig.MinMax xuemaiMinMax = ChongWuConfig.ChongWuXueMaiDic[quality];
        int zizhi = Mathf.RoundToInt(Random.Range(zizhiMinMax.min, zizhiMinMax.max));
        float xuemai = Random.Range(xuemaiMinMax.min, xuemaiMinMax.max);
        float xuemaiRounded = float.Parse(xuemai.ToString("F2"));
        YuanSuType yuanSuType = ChongWuConfig.GetChongWuYuanSuByType(chongWuType);
        string Name=ChongWuConfig.ChongWuNamDic[chongWuType];
        List<ChongWuConfig.ChongWuSKillType> ChongWuSkillList = null;
        switch (yuanSuType)
        {
            case YuanSuType.Ice:
                ChongWuSkillList = ChongWuConfig.ChongWuSkillDic[YuanSuType.Ice];
                break;
            case YuanSuType.Huo:
                ChongWuSkillList = ChongWuConfig.ChongWuSkillDic[YuanSuType.Huo];
                break;
            case YuanSuType.Dian:
                ChongWuSkillList = ChongWuConfig.ChongWuSkillDic[YuanSuType.Dian];
                break;
            case YuanSuType.HeiAn:
                ChongWuSkillList = ChongWuConfig.ChongWuSkillDic[YuanSuType.HeiAn];
                break;
        }

        List<int> skillIndexList = GetUniqueRandomDigits(quality);
        List<ChongWuSkillItem> finalSkillList = new List<ChongWuSkillItem>();
        foreach (var item in skillIndexList)
        {
            finalSkillList.Add(new ChongWuSkillItem() { Level = 1, SKillType = ChongWuSkillList[item] });
        }
        
        ChongWuTable chongWuTable = new ChongWuTable()
        {
            ChongWuId = PlayerData.S.FlagChongWuId,
            ChongWuType = chongWuType,
            Quality = quality,
            ZiZhi = zizhi,
            XueMai = xuemaiRounded,
            YuanSuType=yuanSuType,
            XingJi = 0,
            Level = 1,
            Ex = 0,
            Name = Name,
            SkillList = finalSkillList,
        };
        PlayerData.S.FlagChongWuId++;
        return chongWuTable;
    }
}
