using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XueMaiDanFight : PropBase
{
    public XueMaiDanFight() : base( new PropTable()){}
    [NonSerialized]public int quality;
    public Sprite image;

    public void OnEnable()
    {
        base.OnEnable();
        propTables.EquipName = "XueMaiDan";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.XueMaiDan;
        propTables.Quality = quality;
        if (quality == 3)
        {
            image = ResourcesConfig.NormalXueMaiDan;
        }
        else
        {
            image = ResourcesConfig.GaoJiXueMaiDan;
        }
    }
}
