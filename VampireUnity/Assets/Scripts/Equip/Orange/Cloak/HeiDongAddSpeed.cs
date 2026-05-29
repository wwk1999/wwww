using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HeiDongAddSpeed :EquipBase
{
    private bool isSend = false; //是否发送消息

    public HeiDongAddSpeed() : base( "HeiDongAddSpeed", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "HeiDongAddSpeed";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloak;

        EquipAttributes.orangeid = 5;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        
        InitEntry();
    }
}
