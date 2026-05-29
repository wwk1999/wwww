using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PuTong3ChuanTou :EquipBase
{
    private bool isSend = false; //是否发送消息

    public PuTong3ChuanTou() : base( "PuTong3ChuanTou", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "PuTong3ChuanTou";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloak;

        EquipAttributes.orangeid = 7;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        
        InitEntry();
    }
}
