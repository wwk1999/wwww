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
        EquipAttributes.EquipLevel = 10;

        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Primary;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloak;
        //暂时写死
        EquipAttributes.Quality = 3;
        SetBaseAttribute();

        InitEntry();
    }
   
}
