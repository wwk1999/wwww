using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class JianSuAddAttack :EquipBase
{
    private bool isSend = false; //是否发送消息

    public JianSuAddAttack() : base( "JianSuAddAttack", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "JianSuAddAttack";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.JianSuAddAttack;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Shoe;

        EquipAttributes.orangeid = 40;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();  
        
        InitEntry();
    }
}
