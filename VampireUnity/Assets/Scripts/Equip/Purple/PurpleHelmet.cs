using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PurpleHelmet :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleHelmet() : base( "PurpleHelmetFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleHelmetSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 25;

        EquipAttributes.EquipName = "PurpleHelmet";
        EquipAttributes.suitid = 4;
        EquipAttributes.equip_type_id = 3;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute();  
        
        InitEntry();
    }
}
