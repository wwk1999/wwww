using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LvQuanAddScale :EquipBase
{
    private bool isSend = false; //是否发送消息

    public LvQuanAddScale() : base( "LvQuanAddScale", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "LvQuanAddScale";
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeEntry.LvQuanAddScale;
        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 1;
        EquipAttributes.orangeid = 6;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        
        InitEntry();
    }
}
