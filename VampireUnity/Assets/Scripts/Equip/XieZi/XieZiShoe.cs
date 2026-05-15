using UnityEngine;
using Random = System.Random;
using Mysql;

public class XieZiShoe : EquipBase
{
    private bool isSend = false; //是否发送消息

    public XieZiShoe() : base( "XieZiShoeFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("XieZiShoeSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "XieZiShoe";
        EquipAttributes.EquipLevel = 25;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Shoe;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.XieZi;
        EquipAttributes.Quality = 4;
        
        SetBaseAttribute();
        InitEntry();
            
    }
    
}
