using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HelmetFortureAdd :EquipBase
{
    private bool isSend = false; //是否发送消息
    public HelmetFortureAdd() : base( "HelmetFortureAdd", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "HelmetFortureAdd";
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 3;
        EquipAttributes.orangeid = 18;

        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.HelmetFortureAdd;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        InitEntry();
    }
}
