using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ZhaoZeNecklace : EquipBase
{
    private bool isSend = false; //是否发送消息

    public ZhaoZeNecklace() : base( "ZhaoZeNecklaceFight", SuitType.None,new EquipTable()){}

     private void Awake()
        {
            SpriteRenderer = transform.Find("ZhaoZeNecklaceSprite").GetComponent<SpriteRenderer>();
            EquipAttributes.EquipName = "ZhaoZeNecklace";
            EquipAttributes.EquipLevel = 20;

            EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Necklace;
            EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.ZhaoZe;
            EquipAttributes.Quality = 3;
            
            SetBaseAttribute();
            InitEntry();
        }
       
}
