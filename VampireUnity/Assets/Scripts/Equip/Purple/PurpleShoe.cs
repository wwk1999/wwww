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
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "PurpleShoe";
        EquipAttributes.suitid = 4;
        EquipAttributes.equip_type_id = 6;
        //暂时写死
        EquipAttributes.Quality = 4;
        EquipAttributes.Defense=random.Next(1,4);
        EquipAttributes.HP=random.Next(10,20);     
        
        InitEntry();
    }
}
