using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class WhiteWeaponFragment : PropBase
{
    public WhiteWeaponFragment() : base( new PropTable()){}
    
    private void Awake()
    {
        propTables.EquipName = "WhiteWeaponFragment";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.WeaponFragment;
        propTables.Quality = 1;
    }

}
