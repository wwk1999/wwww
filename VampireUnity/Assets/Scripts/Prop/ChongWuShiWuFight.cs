using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChongWuShiWuFight : PropBase
{
    public ChongWuShiWuFight() : base( new PropTable()){}
    [NonSerialized]public int quality;
    public Sprite image;

    public void OnEnable()
    {
        base.OnEnable();
        propTables.EquipName = "ChongWuShiWu";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.ChongWuShiWu;
        propTables.Quality = quality;
        switch (quality)
        {
            case 1:
                image = ResourcesConfig.ChongWuShiWuWhite;
                break;
            case 2:
                image = ResourcesConfig.ChongWuShiWuGreen;
                break;
            case 3:
                image = ResourcesConfig.ChongWuShiWuBlue;
                break;
            case 4:
                image = ResourcesConfig.ChongWuShiWuPurple;
                break;
            case 5:
                image = ResourcesConfig.ChongWuShiWuOrange;
                break;
            case 6:
                image = ResourcesConfig.ChongWuShiWuRed;
                break;
        }
    }
}
