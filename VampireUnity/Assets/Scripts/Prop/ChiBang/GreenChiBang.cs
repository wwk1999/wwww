using UnityEngine;

public class GreenChiBang : PropBase
{
    public GreenChiBang() : base( new PropTable()){}
            
    private void Awake()
    {
        propTables.EquipName = "GreenChiBang";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.ChiBang;
        propTables.Quality = 2;
    }
}