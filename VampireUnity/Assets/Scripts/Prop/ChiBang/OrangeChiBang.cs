using UnityEngine;

public class OrangeChiBang : PropBase
{
    public OrangeChiBang() : base( new PropTable()){}
            
    private void Awake()
    {
        propTables.EquipName = "OrangeChiBang";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.ChiBang;
        propTables.Quality = 5;
    }
}