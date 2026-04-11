using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiSuiYeFight : PropBase
{
    public XiSuiYeFight() : base( new PropTable()){}
    [NonSerialized]public int quality;
    public Sprite image;

    public void OnEnable()
    {
        base.OnEnable();
        propTables.EquipName = "XiSuiYe";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.XiSuiYe;
        propTables.Quality = quality;
        if (quality == 3)
        {
            image = ResourcesConfig.NormalXiSuiYe;
        }
        else
        {
            image = ResourcesConfig.GaoJiXiSuiYe;
        }
    }
}
