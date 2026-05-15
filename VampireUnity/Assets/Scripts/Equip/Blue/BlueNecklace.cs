using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BlueNecklace : EquipBase
{
    private bool isSend = false; //是否发送消息

    public BlueNecklace() : base( "BlueNecklaceFight", SuitType.None,new EquipTable()){}

     private void Awake()
        {
            SpriteRenderer = transform.Find("BlueNecklaceSprite").GetComponent<SpriteRenderer>();
            EquipAttributes.EquipName = "BlueNecklace";
            EquipAttributes.EquipLevel = 10;

            EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Blue;
            EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Necklace;
            EquipAttributes.Quality = 3;
            
            SetBaseAttribute();
            InitEntry();
        }
       
}
