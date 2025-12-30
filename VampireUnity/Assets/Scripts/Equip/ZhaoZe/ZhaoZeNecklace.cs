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

            EquipAttributes.suitid =6;
            EquipAttributes.equip_type_id = 4;
            EquipAttributes.Quality = 3;
            
            SetBaseAttribute();
            InitEntry();
        }
       
}
