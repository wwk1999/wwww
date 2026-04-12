using UnityEngine;
using Random = System.Random;
using Mysql;

public class TreeManShoe : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManShoe() : base( "TreeManShoeFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManShoeSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "TreeManShoe";
        EquipAttributes.EquipLevel = 5;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Shoe;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.TreeMan;
        EquipAttributes.Quality = 2;
        
        SetBaseAttribute();
        InitEntry();
            
    }
    
}
