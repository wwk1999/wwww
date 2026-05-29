using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Skill3AddRange :EquipBase
{
    private bool isSend = false; //是否发送消息

    public Skill3AddRange() : base( "Skill3AddRange", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "Skill3AddRange";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Ring;

        EquipAttributes.orangeid = 36;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();   
        
        InitEntry();
    }
}
