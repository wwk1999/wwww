using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DashRange :EquipBase
{
    private bool isSend = false; //是否发送消息

    public DashRange() : base( "DashRange", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "DashRange";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.DashRange;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Shoe;

        EquipAttributes.orangeid = 38;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        
        InitEntry();
    }
}
