using System.Collections.Generic;
using UnityEngine;

public class ChongWuController:XSingleton<ChongWuController>
{
    public ChongWuTable GetOriginChongWuTable(ChongWuType chongWuType)
    {
        int quality = ChongWuConfig.GetChongWuQualityByType(chongWuType);
        ChongWuConfig.MinMax zizhiMinMax = ChongWuConfig.ChongWuZiZhiDic[quality];
        ChongWuConfig.MinMax xuemaiMinMax = ChongWuConfig.ChongWuXueMaiDic[quality];
        int zizhi = Mathf.RoundToInt(Random.Range(zizhiMinMax.min, zizhiMinMax.max));
        int xuemai = Mathf.RoundToInt(Random.Range(xuemaiMinMax.min, xuemaiMinMax.max));
        ChongWuYuanSuType chongWuYuanSuType = ChongWuConfig.GetChongWuYuanSuByType(chongWuType);
        string Name=ChongWuConfig.ChongWuNamDic[chongWuType];
        ChongWuTable chongWuTable = new ChongWuTable()
        {
            ChongWuType = chongWuType,
            Quality = quality,
            ZiZhi = zizhi,
            XueMai = xuemai,
            ChongWuYuanSuType=chongWuYuanSuType,
            XingJi = 0,
            Level = 1,
            name = Name,
        };
        return chongWuTable;
    }
}
