using UnityEngine;

public class PurpleChiBang : PropBase
{
    public PurpleChiBang() : base( new PropTable()){}
            
    private void Awake()
    {
        propTables.EquipName = "PurpleChiBang";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.ChiBang;
        propTables.Quality = 5;
    }
}