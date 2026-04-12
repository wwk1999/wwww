using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class MoveSpeedAdd :EquipBase
{
    private bool isSend = false; //是否发送消息

    public MoveSpeedAdd() : base( "MoveSpeedAdd", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "MoveSpeedAdd";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.MoveSpeedAdd;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Shoe;

        EquipAttributes.orangeid = 41;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        InitEntry();
    }
}
