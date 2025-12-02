using UnityEngine;
using Random = System.Random;
using Mysql;

public class TreeManNecklace : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManNecklace() : base( "TreeManNecklaceFight", SuitType.TreeMan,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManNecklaceSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "TreeManNecklace";
        EquipAttributes.suitid = 101;
        EquipAttributes.equip_type_id = 4;
        EquipAttributes.Quality = 2;
        
        EquipAttributes.CRIT=random.Next(4,8);
        EquipAttributes.Damage=random.Next(4,8);
        InitEntry();
    }
    
}
