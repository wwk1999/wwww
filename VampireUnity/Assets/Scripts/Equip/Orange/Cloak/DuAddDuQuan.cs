using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DuAddDuQuan :EquipBase
{
    private bool isSend = false; //是否发送消息

    public DuAddDuQuan() : base( "DuAddDuQuan", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "DuAddDuQuan";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.DuAddDuQuan;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloak;

        EquipAttributes.orangeid = 3;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();   
        
        InitEntry();
    }
}
