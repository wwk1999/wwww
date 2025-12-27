using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GreenHelmet : EquipBase
{
    private bool isSend = false; //是否发送消息

    public GreenHelmet() : base( "GreenHelmetFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("GreenHelmetSprite").GetComponent<SpriteRenderer>();
       
        Random random = new Random();
        EquipAttributes.EquipLevel = 5;

        EquipAttributes.EquipName = "GreenHelmet";
        EquipAttributes.suitid = 2;
        EquipAttributes.equip_type_id = 3;
        EquipAttributes.Quality = 2;
        SetBaseAttribute();
        InitEntry();
    }
    
}
