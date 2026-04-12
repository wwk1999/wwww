using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PurpleRing :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleRing() : base( "PurpleRingFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleRingSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 25;

        EquipAttributes.EquipName = "PurpleRing";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Ring;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Purple;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute();     
        
        InitEntry();
    }
}
