using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ZhaoZeHelmet : EquipBase
{
    private bool isSend = false; //是否发送消息

    public ZhaoZeHelmet() : base( "ZhaoZeClothFight", SuitType.None,new EquipTable()){}
    private void Awake()
    {
        SpriteRenderer = transform.Find("ZhaoZeHelmetSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "ZhaoZeHelmet";
        EquipAttributes.EquipLevel = 20;

        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Helmet;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.ZhaoZe;
        EquipAttributes.Quality = 3;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
