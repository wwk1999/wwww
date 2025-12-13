using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CloakFortureAdd :EquipBase
{
    private bool isSend = false; //是否发送消息

    public CloakFortureAdd() : base( "CloakFortureAdd", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("OrangeRingSprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "CloakFortureAdd";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.CloakFortureAdd;
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 1;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.CRIT=random.Next(4,8);
        EquipAttributes.Damage=random.Next(4,8);     
        
        InitEntry();
    }
}
