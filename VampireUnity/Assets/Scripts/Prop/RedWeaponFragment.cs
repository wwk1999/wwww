using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWeaponFragment : PropBase
{
    public RedWeaponFragment() : base( new PropTable()){}
    
    private void Awake()
    {
        propTables.EquipName = "RedWeaponFragment";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.WeaponFragment;
        propTables.Quality = 6;
    }
}
