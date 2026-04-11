using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChongWuDanFight : PropBase
{
    public ChongWuDanFight() : base( new PropTable()){}
    [NonSerialized]public int quality;
    public Sprite image;

    public void OnEnable()
    {
        base.OnEnable();
        propTables.EquipName = "ChongWuDan";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.ChongWuDan;
        propTables.Quality = quality;
        if (quality == 3)
        {
            image = ResourcesConfig.NormalChongWuDan;
        }
        else
        {
            image = ResourcesConfig.GaoJiChongWuDan;
        }
    }
}
