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
        EquipAttributes.EquipLevel = 30;
        EquipAttributes.EquipName = "PurpleRing1";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Ring;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Purple1;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute();     
        
        InitEntry();
    }
}
