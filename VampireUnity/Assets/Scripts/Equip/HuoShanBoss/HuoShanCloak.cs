using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HuoShanCloak : EquipBase
{
    private bool isSend = false; //是否发送消息

    public HuoShanCloak() : base( "HuoShanCloakFight", SuitType.HuoShan,new EquipTable()){}
    
    private void Awake()
    {
        SpriteRenderer = transform.Find("HuoShanCloakSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.Blue;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "HuoShanCloak";
        EquipAttributes.suitid = 102;
        EquipAttributes.equip_type_id = 1;
        //暂时写死
        EquipAttributes.Quality = 3;
        EquipAttributes.CRIT=random.Next(4,8);

        EquipAttributes.CRIT=random.Next(4,8);
        EquipAttributes.Damage=random.Next(4,8);
        
        InitEntry();
    }
   
}
