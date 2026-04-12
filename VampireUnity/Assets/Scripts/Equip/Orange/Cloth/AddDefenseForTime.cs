using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AddDefenseForTime :EquipBase
{
    private bool isSend = false; //是否发送消息
    public AddDefenseForTime() : base( "AddDefenseForTime", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "AddDefenseForTime";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloth;

        EquipAttributes.orangeid = 9;

        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.AddDefenseForTime;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        InitEntry();
    }
}
