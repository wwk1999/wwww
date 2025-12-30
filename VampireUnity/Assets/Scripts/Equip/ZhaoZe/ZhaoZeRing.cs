using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ZhaoZeRing : EquipBase
{
    private bool isSend = false; //是否发送消息

    public ZhaoZeRing() : base( "ZhaoZeRingFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("ZhaoZeRingSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "ZhaoZeRing";
        EquipAttributes.EquipLevel = 20;

        EquipAttributes.suitid = 3;
        EquipAttributes.equip_type_id = 5;
        EquipAttributes.Quality = 3;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
