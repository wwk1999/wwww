using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BlueCloth : EquipBase
{
    private bool isSend = false; //是否发送消息
    public BlueCloth() : base( "BlueClothFight", SuitType.None,new EquipTable()){}
    private void Awake()
    {
        SpriteRenderer = transform.Find("BlueClothSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "BlueCloth";
        EquipAttributes.EquipLevel = 10;

        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Primary;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloth;
        EquipAttributes.Quality = 3;
        
        SetBaseAttribute();
        InitEntry();
    }
}
