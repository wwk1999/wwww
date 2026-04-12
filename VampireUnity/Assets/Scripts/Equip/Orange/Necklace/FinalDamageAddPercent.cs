using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FinalDamageAddPercent :EquipBase
{
    private bool isSend = false; //是否发送消息

    public FinalDamageAddPercent() : base( "FinalDamageAddPercent", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "FinalDamageAddPercent";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.FinalDamageAddPercent;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Necklace;

        EquipAttributes.orangeid = 22;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        
        InitEntry();
    }
}
