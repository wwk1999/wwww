using UnityEngine;
using Random = System.Random;
using Mysql;

public class XieZiNecklace : EquipBase
{
    private bool isSend = false; //是否发送消息

    public XieZiNecklace() : base( "XieZiNecklaceFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("XieZiNecklaceSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "XieZiNecklace";
        EquipAttributes.EquipLevel = 25;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Necklace;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.XieZi;
        EquipAttributes.Quality = 4;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
