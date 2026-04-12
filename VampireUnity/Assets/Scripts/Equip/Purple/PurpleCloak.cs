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
        EquipAttributes.EquipLevel = 25;
        EquipAttributes.EquipName = "PurpleCloak";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloak;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Purple;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute();   
        
        InitEntry();
    }
}
