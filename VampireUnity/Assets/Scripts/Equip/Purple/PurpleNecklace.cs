using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PurpleNecklace :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleNecklace() : base( "PurpleNecklaceFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleNecklaceSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 25;

        EquipAttributes.EquipName = "PurpleNecklace";
        EquipAttributes.suitid = 4;
        EquipAttributes.equip_type_id = 4;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute(); 
        
        InitEntry();
    }
}
