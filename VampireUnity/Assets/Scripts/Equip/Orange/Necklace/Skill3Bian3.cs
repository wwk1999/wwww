using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Skill3Bian3 :EquipBase
{
    private bool isSend = false; //是否发送消息

    public Skill3Bian3() : base( "Skill3Bian3", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "Skill3Bian3";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.Skill3Bian3;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Necklace;

        EquipAttributes.orangeid = 29;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute(); 
        
        InitEntry();
    }
}
