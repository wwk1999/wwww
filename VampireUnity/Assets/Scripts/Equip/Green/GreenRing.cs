using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GreenRing : EquipBase
{
    private bool isSend = false; //是否发送消息

    public GreenRing() : base( "GreenRingFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("GreenRingSprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipLevel = 5;
        EquipAttributes.EquipName = "GreenRing";
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Green;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Ring;
        EquipAttributes.Quality = 2;
        SetBaseAttribute();
        InitEntry();
    }
   
}
