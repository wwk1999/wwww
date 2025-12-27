using UnityEngine;
using Random = System.Random;
using Mysql;
public class TreeManHelmet : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManHelmet() : base( "TreeManHelmetFight", SuitType.TreeMan,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManHelmetSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "TreeManHelmet";
        EquipAttributes.EquipLevel = 5;
        EquipAttributes.suitid = 101;
        EquipAttributes.equip_type_id = 3;
        EquipAttributes.Quality = 2;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
