using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FinalDamageReductionPercent :EquipBase
{
    private bool isSend = false; //是否发送消息
    public FinalDamageReductionPercent() : base( "FinalDamageReductionPercent", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "FinalDamageReductionPercent";
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 3;
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.FinalDamageReductionPercent;
        //暂时写死
        EquipAttributes.Quality = 5;
        SetBaseAttribute();
        InitEntry();
    }
}
