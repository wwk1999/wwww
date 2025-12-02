using UnityEngine;
using Random = System.Random;
using Mysql;
public class TreeManHelmet : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManHelmet() : base( "TreeManHelmetFight", SuitType.TreeMan,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManHelmetSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "TreeManHelmet";
        EquipAttributes.suitid = 101;
        EquipAttributes.equip_type_id = 3;
        EquipAttributes.Quality = 2;
        
        EquipAttributes.Defense=random.Next(4,7);
        EquipAttributes.HP=random.Next(12,20);
            
    }
    
}
