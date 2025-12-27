using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ClothFortureAdd :EquipBase
{
    private bool isSend = false; //是否发送消息
    public ClothFortureAdd() : base( "ClothFortureAdd", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "ClothFortureAdd";
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 2;
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.ClothFortureAdd;
        //暂时写死
        EquipAttributes.Quality = 5;
        SetBaseAttribute();
        InitEntry();
    }
}
