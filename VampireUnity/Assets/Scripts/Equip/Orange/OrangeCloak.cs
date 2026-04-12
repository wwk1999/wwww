using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class OrangeCloak :EquipBase
{
    private bool isSend = false; //是否发送消息
    public OrangeCloak() : base( "OrangeCloakFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("OrangeCloakSprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "OrangeCloak";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Shoe;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        InitEntry();
    }
}
