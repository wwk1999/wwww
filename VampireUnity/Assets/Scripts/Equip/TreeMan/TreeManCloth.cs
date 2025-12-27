using Mysql;
using UnityEngine;
using Random = System.Random;

public class TreeManCloth : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManCloth() : base( "TreeManClothFight", SuitType.TreeMan,new EquipTable()){}
    
    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManClothSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "TreeManCloth";
        EquipAttributes.EquipLevel = 5;
        EquipAttributes.suitid = 101;
        EquipAttributes.equip_type_id = 2;
        //暂时写死
        EquipAttributes.Quality = 2;
        
        SetBaseAttribute();
        InitEntry();
    }
    
    
}
