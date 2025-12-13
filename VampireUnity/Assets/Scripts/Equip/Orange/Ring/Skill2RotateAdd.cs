using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Skill2RotateAdd :EquipBase
{
    private bool isSend = false; //是否发送消息

    public Skill2RotateAdd() : base( "Skill2RotateAdd", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("OrangeRingSprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "Skill2RotateAdd";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.Skill2RotateAdd;
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 5;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.CRIT=random.Next(4,8);
        EquipAttributes.Damage=random.Next(4,8);     
        
        InitEntry();
    }
}
