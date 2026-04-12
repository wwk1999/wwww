using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class NecklaceFortureAdd :EquipBase
{
    private bool isSend = false; //是否发送消息

    public NecklaceFortureAdd() : base( "NecklaceFortureAdd", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "NecklaceFortureAdd";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.NecklaceFortureAdd;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Necklace;

        EquipAttributes.orangeid = 23;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute(); 
        
        InitEntry();
    }
}
