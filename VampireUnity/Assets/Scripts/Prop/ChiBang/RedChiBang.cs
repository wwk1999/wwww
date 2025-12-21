using UnityEngine;

public class RedChiBang : PropBase
{
    public RedChiBang() : base( new PropTable()){}
            
    private void Awake()
    {
        propTables.EquipName = "RedChiBang";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.ChiBang;
        propTables.Quality = 6;
    }
}