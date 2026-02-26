using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class NormalAddDamage :EquipBase
{
    private bool isSend = false; //是否发送消息

    public NormalAddDamage() : base( "NormalAddDamage", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "NormalAddDamage";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.NormalAddDamage;
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 4;
        EquipAttributes.orangeid = 24;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute(); 
        
        InitEntry();
    }
}
