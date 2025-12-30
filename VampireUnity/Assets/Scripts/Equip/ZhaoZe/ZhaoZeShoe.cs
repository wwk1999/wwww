using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ZhaoZeShoe : EquipBase
{
    private bool isSend = false; //是否发送消息

    public ZhaoZeShoe() : base( "ZhaoZeShoeFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("ZhaoZeShoeSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "ZhaoZeShoe";
        EquipAttributes.EquipLevel = 20;
        EquipAttributes.suitid = 3;
        EquipAttributes.equip_type_id = 6;
        EquipAttributes.Quality = 3;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
