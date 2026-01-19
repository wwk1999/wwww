using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Skill2AddRange :EquipBase
{
    private bool isSend = false; //是否发送消息
    public Skill2AddRange() : base( "Skill2AddRange", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "Skill2AddRange";
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 3;
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.Skill2AddRange;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        InitEntry();
    }
}
