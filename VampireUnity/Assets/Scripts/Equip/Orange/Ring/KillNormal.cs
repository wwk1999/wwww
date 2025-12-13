using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class KillNormal :EquipBase
{
    private bool isSend = false; //是否发送消息

    public KillNormal() : base( "KillNormal", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("OrangeRingSprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "KillNormal";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.KillNormal;
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 5;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.CRIT=random.Next(4,8);
        EquipAttributes.Damage=random.Next(4,8);     
        
        InitEntry();
    }
}
