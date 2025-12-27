using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class GreenCloth : EquipBase
{
    private bool isSend = false; //是否发送消息

    public GreenCloth() : base( "GreenClothFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("GreenClothSprite").GetComponent<SpriteRenderer>();
        Random random = new Random();
        EquipAttributes.EquipName = "GreenCloth";
        EquipAttributes.suitid = 2;
        EquipAttributes.equip_type_id = 2;
        EquipAttributes.Quality = 2;
        
        EquipAttributes.Defense=random.Next(5,10);
        EquipAttributes.HP=random.Next(25,40);
        InitEntry();
    }
    
}
