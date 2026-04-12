using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FanPuGuiZhen :EquipBase
{
    private bool isSend = false; //是否发送消息
    public FanPuGuiZhen() : base( "OrangeCloakFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "FanPuGuiZhen";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.FanPuGuiZhen;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Ring;

        EquipAttributes.orangeid = 31;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        InitEntry();
    }
}
