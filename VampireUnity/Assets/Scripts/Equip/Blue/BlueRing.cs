using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BlueRing : EquipBase
{
    private bool isSend = false; //是否发送消息

    public BlueRing() : base( "BlueRingFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("BlueRingSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "BlueRing";
        EquipAttributes.EquipLevel = 10;

        EquipAttributes.suitid = 3;
        EquipAttributes.equip_type_id = 5;
        EquipAttributes.Quality = 3;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
