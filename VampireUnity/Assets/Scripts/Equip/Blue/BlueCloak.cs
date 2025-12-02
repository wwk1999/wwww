using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class BlueCloak : EquipBase
{
    private bool isSend = false; //是否发送消息
    public BlueCloak() : base( "BlueCloakFight", SuitType.None,new EquipTable()){}
    private void Awake()
    {
        SpriteRenderer = transform.Find("BlueCloakSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        System.Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "BlueCloak";
        EquipAttributes.suitid = 3;
        EquipAttributes.equip_type_id = 1;
        //暂时写死
        EquipAttributes.Quality = 3;
        
        EquipAttributes.CRIT=random.Next(4,8);
        EquipAttributes.Damage=random.Next(4,8);
    }
   
}
