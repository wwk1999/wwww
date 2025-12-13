using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AllReplyAddPercent :EquipBase
{
    private bool isSend = false; //是否发送消息
    public AllReplyAddPercent() : base( "AllReplyAddPercent", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("OrangeClothSprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "AllReplyAddPercent";
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 2;
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.AllReplyAddPercent;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.CRIT=random.Next(4,8);
        EquipAttributes.Damage=random.Next(4,8);  
        InitEntry();
    }
}
