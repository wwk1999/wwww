using UnityEngine;
using Random = System.Random;
using Mysql;

public class XueRenRing : EquipBase
{
    private bool isSend = false; //是否发送消息

    public XueRenRing() : base( "XueRenRingFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("XueRenRingSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "XueRenRing";
        EquipAttributes.EquipLevel = 30;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Ring;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.XueRen;
        EquipAttributes.Quality = 4;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
