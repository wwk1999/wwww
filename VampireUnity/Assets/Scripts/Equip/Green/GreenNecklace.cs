using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class GreenNecklace : EquipBase
{
    private bool isSend = false; //是否发送消息

   public GreenNecklace() : base( "GreenNecklaceFight", SuitType.None,new EquipTable()){}

        private void Awake()
        {
            SpriteRenderer = transform.Find("GreenNecklaceSprite").GetComponent<SpriteRenderer>();
            Random random = new Random();
            EquipAttributes.EquipLevel = 5;
            EquipAttributes.EquipName = "GreenNecklace";
            EquipAttributes.suitid = 2;
            EquipAttributes.equip_type_id = 4;
            EquipAttributes.Quality = 2;
            SetBaseAttribute();
            InitEntry();
        }
        
}
