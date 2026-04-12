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
        EquipAttributes.EquipLevel = 30;
        EquipAttributes.EquipName = "PurpleCloak1";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloak;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Purple1;
        EquipAttributes.Quality = 4;
        SetBaseAttribute();   
        
        InitEntry();
    }
}
