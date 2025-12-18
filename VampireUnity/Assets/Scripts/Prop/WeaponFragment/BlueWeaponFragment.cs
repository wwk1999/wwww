using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueWeaponFragment : PropBase
{
    public BlueWeaponFragment() : base( new PropTable()){}
    
    private void Awake()
    {
        propTables.EquipName = "BlueWeaponFragment";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.WeaponFragment;
        propTables.Quality = 3;
    }
}
