using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BlueRing : EquipBase
{
    private bool isSend = false; //是否发送消息

    public BlueRing() : base( "BlueRingFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("BlueRingSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.Blue;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "BlueRing";
        EquipAttributes.suitid = 3;
        EquipAttributes.equip_type_id = 5;
        EquipAttributes.Quality = 3;
        
        EquipAttributes.Damage=random.Next(2,5);
        EquipAttributes.CRIT=random.Next(3,6);
            
    }
    
}
