using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DashCd :EquipBase
{
    private bool isSend = false; //是否发送消息

    public DashCd() : base( "DashCd", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "DashCd";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.DashCd;
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 6;
        //暂时写死
        EquipAttributes.Quality = 5;
        SetBaseAttribute();
        InitEntry();
    }
}
