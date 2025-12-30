using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PurpleNecklace1 :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleNecklace1() : base( "PurpleNecklaceFight1", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleNecklaceSprite1").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 25;
        EquipAttributes.EquipName = "PurpleNecklace1";
        EquipAttributes.suitid = 7;
        EquipAttributes.equip_type_id = 4;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute(); 
        
        InitEntry();
    }
}
