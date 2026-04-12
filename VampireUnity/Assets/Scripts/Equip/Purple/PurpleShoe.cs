using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class PurpleShoe :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PurpleShoe() : base( "PurpleShoeFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("PurpleShoeSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipLevel = 25;

        EquipAttributes.EquipName = "PurpleShoe";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Shoe;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Purple;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute();  
        
        InitEntry();
    }
}
