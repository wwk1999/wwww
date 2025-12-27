using UnityEngine;
using Random = System.Random;
using Mysql;

public class TreeManNecklace : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManNecklace() : base( "TreeManNecklaceFight", SuitType.TreeMan,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManNecklaceSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "TreeManNecklace";
        EquipAttributes.EquipLevel = 5;
        EquipAttributes.suitid = 101;
        EquipAttributes.equip_type_id = 4;
        EquipAttributes.Quality = 2;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
