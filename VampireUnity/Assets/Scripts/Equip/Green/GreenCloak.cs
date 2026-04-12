using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GreenCloak : EquipBase
{
    private bool isSend = false; //是否发送消息

    public GreenCloak() : base( "GreenCloakFight", SuitType.None,new EquipTable()){}
    private void Awake()
    {
        SpriteRenderer = transform.Find("GreenCloakSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 5;
        EquipAttributes.EquipName = "GreenCloak";
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Green;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloak;
        //暂时写死
        EquipAttributes.Quality = 2;
        
        SetBaseAttribute();
        
        InitEntry();
    }
}
