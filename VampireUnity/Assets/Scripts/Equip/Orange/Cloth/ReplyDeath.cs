using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ReplyDeath :EquipBase
{
    private bool isSend = false; //是否发送消息
    public ReplyDeath() : base( "ReplyDeath", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "ReplyDeath";
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 2;
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.ReplyDeath;
        //暂时写死
        EquipAttributes.Quality = 5;
        SetBaseAttribute();
        InitEntry();
    }
}
