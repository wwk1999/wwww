using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class PurpleShoe1 :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleShoe1() : base( "PurpleShoeFight1", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleShoeSprite1").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 25;
        EquipAttributes.EquipName = "PurpleShoe1";
        EquipAttributes.suitid = 7;
        EquipAttributes.equip_type_id = 6;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute();  
        
        InitEntry();
    }
}
