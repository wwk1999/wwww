using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BlueHelmet : EquipBase
{
    private bool isSend = false; //是否发送消息

    public BlueHelmet() : base( "BlueClothFight", SuitType.None,new EquipTable()){}
    private void Awake()
    {
        SpriteRenderer = transform.Find("BlueHelmetSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "BlueHelmet";
        EquipAttributes.EquipLevel = 10;

        EquipAttributes.suitid = 3;
        EquipAttributes.equip_type_id = 3;
        EquipAttributes.Quality = 3;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
