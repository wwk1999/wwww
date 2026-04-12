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
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Helmet;

        EquipAttributes.orangeid = 17;

        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.FinalDamageReductionPercent;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        InitEntry();
    }
}
