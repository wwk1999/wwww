using UnityEngine;
using Random = System.Random;
using Mysql;

public class XueRenNecklace : EquipBase
{
    private bool isSend = false; //是否发送消息

    public XueRenNecklace() : base( "XueRenNecklaceFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("XueRenNecklaceSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "XueRenNecklace";
        EquipAttributes.EquipLevel = 30;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Necklace;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.XueRen;
        EquipAttributes.Quality = 4;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
