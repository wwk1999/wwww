using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HpReductionReplyAdd50 :EquipBase
{
    private bool isSend = false; //是否发送消息
    public HpReductionReplyAdd50() : base( "HpReductionReplyAdd50", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "HpReductionReplyAdd50";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloth;

        EquipAttributes.orangeid = 13;

        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.HpReductionReplyAdd50;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        InitEntry();
    }
}
