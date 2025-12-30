using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class PurpleCloak1 :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleCloak1() : base( "PurpleCloakFight1", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleCloakSprite1").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 25;
        EquipAttributes.EquipName = "PurpleCloak1";
        EquipAttributes.suitid = 7;
        EquipAttributes.equip_type_id = 1;
        EquipAttributes.Quality = 4;
        SetBaseAttribute();   
        
        InitEntry();
    }
}
