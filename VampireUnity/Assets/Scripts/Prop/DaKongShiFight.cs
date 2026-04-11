using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaKongShiFight : PropBase
{
    public DaKongShiFight() : base( new PropTable()){}
    [NonSerialized]public int quality;

    public void OnEnable()
    {
        base.OnEnable();
        propTables.EquipName = "DaKongShi";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.DaKongShi;
        propTables.Quality = quality;
    }
}
