using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FinalDamageReductionFixed :EquipBase
{
    private bool isSend = false; //是否发送消息
    public FinalDamageReductionFixed() : base( "FinalDamageReductionFixed", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.FinalDamageReductionFixed;
        EquipAttributes.EquipName = "FinalDamageReductionFixed";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloth;

        EquipAttributes.orangeid = 12;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        InitEntry();
    }
}
