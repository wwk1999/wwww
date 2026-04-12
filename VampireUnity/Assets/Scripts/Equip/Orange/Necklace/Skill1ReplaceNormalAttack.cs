using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Skill1ReplaceNormalAttack :EquipBase
{
    private bool isSend = false; //是否发送消息

    public Skill1ReplaceNormalAttack() : base( "Skill1ReplaceNormalAttack", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "Skill1ReplaceNormalAttack";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.Skill1ReplaceNormalAttack;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Necklace;

        EquipAttributes.orangeid = 27;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        
        InitEntry();
    }
}
