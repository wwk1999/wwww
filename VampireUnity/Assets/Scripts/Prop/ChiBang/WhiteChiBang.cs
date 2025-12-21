using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteChiBang : PropBase
{
    public WhiteChiBang() : base( new PropTable()){}
            
    private void Awake()
    {
        propTables.EquipName = "WhiteChiBang";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.ChiBang;
        propTables.Quality = 1;
    }
}
