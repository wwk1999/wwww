using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BlueShoe : EquipBase
{
    private bool isSend = false; //是否发送消息

    public BlueShoe() : base( "BlueShoeFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("BlueShoeSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "BlueShoe";
        EquipAttributes.EquipLevel = 15;
        EquipAttributes.suitid = 3;
        EquipAttributes.equip_type_id = 6;
        EquipAttributes.Quality = 3;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
