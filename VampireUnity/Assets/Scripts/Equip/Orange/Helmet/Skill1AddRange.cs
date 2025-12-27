using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Skill1AddRange :EquipBase
{
    private bool isSend = false; //是否发送消息
    public Skill1AddRange() : base( "Skill1AddRange", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "Skill1AddRange";
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 3;
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.Skill1AddRange;
        //暂时写死
        EquipAttributes.Quality = 5;
        SetBaseAttribute();
        InitEntry();
    }
}
