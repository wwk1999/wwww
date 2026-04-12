using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ZhaoZeShoe : EquipBase
{
    private bool isSend = false; //是否发送消息

    public ZhaoZeShoe() : base( "ZhaoZeShoeFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("ZhaoZeShoeSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "ZhaoZeShoe";
        EquipAttributes.EquipLevel = 20;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Shoe;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.ZhaoZe;
        EquipAttributes.Quality = 3;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
