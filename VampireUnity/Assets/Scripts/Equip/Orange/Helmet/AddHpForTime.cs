using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AddHpForTime :EquipBase
{
    private bool isSend = false; //是否发送消息
    public AddHpForTime() : base( "AddHpForTime", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "AddHpForTime";
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 3;
        EquipAttributes.orangeid = 15;

        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.AddHpForTime;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        InitEntry();
    }
}
