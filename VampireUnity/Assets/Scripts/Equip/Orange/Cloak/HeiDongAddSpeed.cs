using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HeiDongAddSpeed :EquipBase
{
    private bool isSend = false; //是否发送消息

    public HeiDongAddSpeed() : base( "HeiDongAddSpeed", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "HeiDongAddSpeed";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.HeiDongAddSpeed;
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 1;
        EquipAttributes.orangeid = 5;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        
        InitEntry();
    }
}
