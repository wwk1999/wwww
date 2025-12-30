using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class PurpleCloak :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleCloak() : base( "PurpleCloakFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleCloakSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 20;
        EquipAttributes.EquipName = "PurpleCloak";
        EquipAttributes.suitid = 4;
        EquipAttributes.equip_type_id = 1;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute();   
        
        InitEntry();
    }
}
