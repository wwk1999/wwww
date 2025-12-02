using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class OrangeHelmet :EquipBase
{
    private bool isSend = false; //是否发送消息

    public OrangeHelmet() : base( "OrangeHelmetFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("OrangeHelmetSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "OrangeHelmet";
        EquipAttributes.suitid = 5;
        EquipAttributes.equip_type_id = 3;
        //暂时写死
        EquipAttributes.Quality = 5;
        
        EquipAttributes.Defense=random.Next(1,4);
        EquipAttributes.HP=random.Next(10,20);            
    }
}
