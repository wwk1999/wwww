using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GreenShoe : EquipBase
{
    private bool isSend = false; //是否发送消息

    public GreenShoe() : base( "GreenShoeFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("GreenShoeSprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipLevel = 5;
        EquipAttributes.EquipName = "GreenShoe";
        EquipAttributes.suitid = 2;
        EquipAttributes.equip_type_id = 6;
        EquipAttributes.Quality = 2;
        SetBaseAttribute();
        InitEntry();
    }
    
}
