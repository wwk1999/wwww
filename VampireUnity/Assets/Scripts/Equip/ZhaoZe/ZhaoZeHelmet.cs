using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ZhaoZeHelmet : EquipBase
{
    private bool isSend = false; //是否发送消息

    public ZhaoZeHelmet() : base( "ZhaoZeClothFight", SuitType.None,new EquipTable()){}
    private void Awake()
    {
        SpriteRenderer = transform.Find("ZhaoZeHelmetSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "ZhaoZeHelmet";
        EquipAttributes.EquipLevel = 20;

        EquipAttributes.suitid = 3;
        EquipAttributes.equip_type_id = 3;
        EquipAttributes.Quality = 3;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
