using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PurpleCloth1 :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleCloth1() : base( "PurpleClothFight1", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleClothSprite1").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 25;
        EquipAttributes.EquipName = "PurpleCloth1";
        EquipAttributes.suitid = 4;
        EquipAttributes.equip_type_id = 2;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute(); 
        
        InitEntry();
    }
}
