using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Skill2AddDan :EquipBase
{
    private bool isSend = false; //是否发送消息

    public Skill2AddDan() : base( "Skill2AddDan", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "Skill2AddDan";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.Skill2AddDan;
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 4;
        EquipAttributes.orangeid = 28;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        
        InitEntry();
    }
}
