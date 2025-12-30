using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class BlueCloak : EquipBase
{
    private bool isSend = false; //是否发送消息
    public BlueCloak() : base( "BlueCloakFight", SuitType.None,new EquipTable()){}
    private void Awake()
    {
        SpriteRenderer = transform.Find("BlueCloakSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "BlueCloak";
        EquipAttributes.EquipLevel = 15;

        EquipAttributes.suitid = 3;
        EquipAttributes.equip_type_id = 1;
        //暂时写死
        EquipAttributes.Quality = 3;
        SetBaseAttribute();

        InitEntry();
    }
   
}
