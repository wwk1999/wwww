using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Skill1YiDianDouble :EquipBase
{
    private bool isSend = false; //是否发送消息

    public Skill1YiDianDouble() : base( "Skill1YiDianDouble", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "Skill1YiDianDouble";
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Ring;

        EquipAttributes.orangeid = 34;

        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();     
        
        InitEntry();
    }
}
