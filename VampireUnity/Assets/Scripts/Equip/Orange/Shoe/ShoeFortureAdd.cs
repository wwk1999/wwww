using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ShoeFortureAdd :EquipBase
{
    private bool isSend = false; //是否发送消息

    public ShoeFortureAdd() : base( "ShoeFortureAdd", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "ShoeFortureAdd";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.ShoeFortureAdd;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Shoe;

        EquipAttributes.orangeid = 42;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        InitEntry();
    }
}
