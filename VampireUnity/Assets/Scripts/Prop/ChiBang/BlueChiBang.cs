using UnityEngine;

public class BlueChiBang : PropBase
{
    public BlueChiBang() : base( new PropTable()){}
            
    private void Awake()
    {
        propTables.EquipName = "BlueChiBang";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.ChiBang;
        propTables.Quality = 3;
    }
}