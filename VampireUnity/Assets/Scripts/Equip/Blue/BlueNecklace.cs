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
            EquipAttributes.EquipLevel = 15;

            EquipAttributes.suitid =3;
            EquipAttributes.equip_type_id = 4;
            EquipAttributes.Quality = 3;
            
            SetBaseAttribute();
            InitEntry();
        }
       
}
