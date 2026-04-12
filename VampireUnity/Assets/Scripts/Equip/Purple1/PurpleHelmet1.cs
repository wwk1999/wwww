using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PurpleHelmet1 :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleHelmet1() : base( "PurpleHelmetFight1", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleHelmetSprite1").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 30;
        EquipAttributes.EquipName = "PurpleHelmet1";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Helmet;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Purple1;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute();  
        
        InitEntry();
    }
}
