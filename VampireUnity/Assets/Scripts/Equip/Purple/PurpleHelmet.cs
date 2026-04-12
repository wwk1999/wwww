using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PurpleHelmet :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleHelmet() : base( "PurpleHelmetFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleHelmetSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 25;

        EquipAttributes.EquipName = "PurpleHelmet";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Helmet;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Purple;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute();  
        
        InitEntry();
    }
}
