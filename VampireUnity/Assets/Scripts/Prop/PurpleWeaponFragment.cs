using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleWeaponFragment : PropBase
{
    public PurpleWeaponFragment() : base( new PropTable()){}
    
    private void Awake()
    {
        propTables.EquipName = "PurpleWeaponFragment";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.WeaponFragment;
        propTables.Quality = 4;
    }
}
