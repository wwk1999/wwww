using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class ZhaoZeCloak : EquipBase
{
    private bool isSend = false; //是否发送消息
    public ZhaoZeCloak() : base( "ZhaoZeCloakFight", SuitType.None,new EquipTable()){}
    private void Awake()
    {
        SpriteRenderer = transform.Find("ZhaoZeCloakSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "ZhaoZeCloak";
        EquipAttributes.EquipLevel = 20;

        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloak;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.ZhaoZe;
        //暂时写死
        EquipAttributes.Quality = 3;
        SetBaseAttribute();

        InitEntry();
    }
   
}
