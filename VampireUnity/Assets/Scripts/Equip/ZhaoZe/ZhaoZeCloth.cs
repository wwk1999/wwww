using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ZhaoZeCloth : EquipBase
{
    private bool isSend = false; //是否发送消息
    public ZhaoZeCloth() : base( "ZhaoZeClothFight", SuitType.None,new EquipTable()){}
    private void Awake()
    {
        SpriteRenderer = transform.Find("ZhaoZeClothSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "ZhaoZeCloth";
        EquipAttributes.EquipLevel = 20;

        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloth;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.ZhaoZe;
        EquipAttributes.Quality = 3;
        
        SetBaseAttribute();
        InitEntry();
    }
}
