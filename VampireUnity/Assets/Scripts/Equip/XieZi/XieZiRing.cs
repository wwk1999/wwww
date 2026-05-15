using UnityEngine;
using Random = System.Random;
using Mysql;

public class XieZiRing : EquipBase
{
    private bool isSend = false; //是否发送消息

    public XieZiRing() : base( "XieZiRingFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("XieZiRingSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "XieZiRing";
        EquipAttributes.EquipLevel = 25;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Ring;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.XieZi;
        EquipAttributes.Quality = 4;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
