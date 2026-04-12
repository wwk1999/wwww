using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ExAdd :EquipBase
{
    private bool isSend = false; //是否发送消息

    public ExAdd() : base( "ExAdd", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "ExAdd";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.ExAdd;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Shoe;

        EquipAttributes.orangeid = 39;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute(); 
        
        InitEntry();
    }
}
