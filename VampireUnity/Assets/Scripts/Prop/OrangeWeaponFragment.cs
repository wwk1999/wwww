using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeWeaponFragment : PropBase
{
    public OrangeWeaponFragment() : base( new PropTable()){}
    
    private void Awake()
    {
        propTables.EquipName = "OrangeWeaponFragment";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.WeaponFragment;
        propTables.Quality = 5;
    }
}
