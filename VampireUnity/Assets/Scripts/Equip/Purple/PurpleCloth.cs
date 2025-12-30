using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PurpleCloth :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleCloth() : base( "PurpleClothFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleClothSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 20;

        EquipAttributes.EquipName = "PurpleCloth";
        EquipAttributes.suitid = 4;
        EquipAttributes.equip_type_id = 2;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute(); 
        
        InitEntry();
    }
}
