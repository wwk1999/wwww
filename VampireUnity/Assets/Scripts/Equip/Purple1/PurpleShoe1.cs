using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class PurpleShoe1 :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleShoe1() : base( "PurpleShoeFight1", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleShoeSprite1").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 30;
        EquipAttributes.EquipName = "PurpleShoe1";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Shoe;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Purple1;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute();  
        
        InitEntry();
    }
}
