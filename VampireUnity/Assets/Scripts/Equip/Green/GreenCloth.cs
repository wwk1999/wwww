using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class GreenCloth : EquipBase
{
    private bool isSend = false; //是否发送消息

    public GreenCloth() : base( "GreenClothFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("GreenClothSprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipLevel = 5;

        EquipAttributes.EquipName = "GreenCloth";
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Green;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloth;
        EquipAttributes.Quality = 2;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
