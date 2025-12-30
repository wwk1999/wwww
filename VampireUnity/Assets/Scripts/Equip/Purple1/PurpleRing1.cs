using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PurpleRing1 :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleRing1() : base( "PurpleRingFight1", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleRingSprite1").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 25;
        EquipAttributes.EquipName = "PurpleRing1";
        EquipAttributes.suitid = 7;
        EquipAttributes.equip_type_id = 5;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute();     
        
        InitEntry();
    }
}
