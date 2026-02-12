using System.Collections.Generic;
using UnityEngine;

public class ChongWuController:XSingleton<ChongWuController>
{
    public int CurrentChongWuPageNum = 1;
    public List<ChongWuListItem>CurrentPageItemList=new List<ChongWuListItem>();
    //开宠物蛋
    public ChongWuTable GetOriginChongWuTable(ChongWuType chongWuType)
    {
        int quality = ChongWuConfig.GetChongWuQualityByType(chongWuType);
        ChongWuConfig.MinMax zizhiMinMax = ChongWuConfig.ChongWuZiZhiDic[quality];
        ChongWuConfig.MinMax xuemaiMinMax = ChongWuConfig.ChongWuXueMaiDic[quality];
        int zizhi = Mathf.RoundToInt(Random.Range(zizhiMinMax.min, zizhiMinMax.max));
        float xuemai = Random.Range(xuemaiMinMax.min, xuemaiMinMax.max);
        float xuemaiRounded = float.Parse(xuemai.ToString("F2"));
        ChongWuYuanSuType chongWuYuanSuType = ChongWuConfig.GetChongWuYuanSuByType(chongWuType);
        string Name=ChongWuConfig.ChongWuNamDic[chongWuType];
        ChongWuTable chongWuTable = new ChongWuTable()
        {
            ChongWuId = PlayerData.S.FlagChongWuId,
            ChongWuType = chongWuType,
            Quality = quality,
            ZiZhi = zizhi,
            XueMai = xuemaiRounded,
            ChongWuYuanSuType=chongWuYuanSuType,
            XingJi = 0,
            Level = 1,
            Name = Name,
        };
        PlayerData.S.FlagChongWuId++;
        return chongWuTable;
    }
}
