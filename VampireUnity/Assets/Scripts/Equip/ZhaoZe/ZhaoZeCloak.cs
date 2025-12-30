using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class ZhaoZeCloak : EquipBase
{
    private bool isSend = false; //是否发送消息
    public ZhaoZeCloak() : base( "ZhaoZeCloakFight", SuitType.None,new EquipTable()){}
    private void Awake()
    {
        SpriteRenderer = transform.Find("ZhaoZeCloakSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "ZhaoZeCloak";
        EquipAttributes.EquipLevel = 20;

        EquipAttributes.suitid = 6;
        EquipAttributes.equip_type_id = 1;
        //暂时写死
        EquipAttributes.Quality = 3;
        SetBaseAttribute();

        InitEntry();
    }
   
}
