using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShenHuaCaiLiaoFight : PropBase
{
    public ShenHuaCaiLiaoFight() : base( new PropTable()){}
    [NonSerialized]public int quality;
    public Sprite image;

    public void OnEnable()
    {
        base.OnEnable();
        propTables.EquipName = "ShenHuaCaiLiao";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.ShenHuaCaiLiao;
        propTables.Quality = quality;
        switch (quality)
        {
            case 1:
                image = ResourcesConfig.FuMoZhiGu;
                break;
            case 2:
                image = ResourcesConfig.GoldBlood;
                break;
            case 3:
                image = ResourcesConfig.JuDaYaChi;
                break;
            case 4:
                image = ResourcesConfig.ZuiEYanZhu;
                break;
        }
    }
}
