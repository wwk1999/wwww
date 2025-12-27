using UnityEngine;
using Random = System.Random;
using Mysql;

public class TreeManRing : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManRing() : base( "TreeManRingFight", SuitType.TreeMan,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManRingSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "TreeManRing";
        EquipAttributes.EquipLevel = 5;
        EquipAttributes.suitid = 101;
        EquipAttributes.equip_type_id = 5;
        EquipAttributes.Quality = 2;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
