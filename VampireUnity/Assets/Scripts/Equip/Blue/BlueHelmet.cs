using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BlueHelmet : EquipBase
{
    private bool isSend = false; //是否发送消息

    public BlueHelmet() : base( "BlueClothFight", SuitType.None,new EquipTable()){}
    private void Awake()
    {
        SpriteRenderer = transform.Find("BlueHelmetSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "BlueHelmet";
        EquipAttributes.EquipLevel = 10;

        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Primary;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Helmet;
        EquipAttributes.Quality = 3;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
