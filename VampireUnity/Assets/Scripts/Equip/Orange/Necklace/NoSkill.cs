using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class NoSkill :EquipBase
{
    private bool isSend = false; //是否发送消息

    public NoSkill() : base( "NoSkill", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("OrangeNecklaceSprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "NoSkill";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.NoSkill;
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 4;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.CRIT=random.Next(4,8);
        EquipAttributes.Damage=random.Next(4,8);    
        
        InitEntry();
    }
}
