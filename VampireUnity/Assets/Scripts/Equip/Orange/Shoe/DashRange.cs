using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DashRange :EquipBase
{
    private bool isSend = false; //是否发送消息

    public DashRange() : base( "DashRange", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("OrangeRingSprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "DashRange";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.DashRange;
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 6;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.CRIT=random.Next(4,8);
        EquipAttributes.Damage=random.Next(4,8);     
        
        InitEntry();
    }
}
