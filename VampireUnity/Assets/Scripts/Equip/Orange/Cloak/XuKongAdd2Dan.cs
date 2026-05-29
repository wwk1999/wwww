using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class XuKongAdd2Dan :EquipBase
{
    private bool isSend = false; //是否发送消息

    public XuKongAdd2Dan() : base( "XuKongAdd2Dan", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "XuKongAdd2Dan";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloak;

        EquipAttributes.orangeid = 8;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();  
        
        InitEntry();
    }
}
