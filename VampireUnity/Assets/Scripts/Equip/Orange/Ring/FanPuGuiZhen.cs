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
        SpriteRenderer = transform.Find("OrangeCloakSprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "FanPuGuiZhen";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.FanPuGuiZhen;
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 5;
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.CRIT=random.Next(4,8);
        EquipAttributes.Damage=random.Next(4,8);  
        InitEntry();
    }
}
