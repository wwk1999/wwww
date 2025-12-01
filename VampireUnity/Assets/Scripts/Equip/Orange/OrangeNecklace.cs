using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class OrangeNecklace :EquipBase
{
    private bool isSend = false; //是否发送消息

    public OrangeNecklace() : base( "OrangeNecklaceFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("OrangeNecklaceSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "OrangeNecklace";
        EquipAttributes.suitid = 5;
        EquipAttributes.suitname = "None";
        EquipAttributes.equip_type_id = 4;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.CRIT=random.Next(4,8);
        EquipAttributes.CRITDamage=random.Next(6,10);
            
    }
}
