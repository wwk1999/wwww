using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenWeaponFragment : PropBase
{
    public GreenWeaponFragment() : base( new PropTable()){}
    
    private void Awake()
    {
        propTables.EquipName = "GreenWeaponFragment";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.WeaponFragment;
        propTables.Quality = 2;
    }
}
