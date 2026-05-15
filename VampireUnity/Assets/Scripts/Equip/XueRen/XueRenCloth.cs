using Mysql;
using UnityEngine;
using Random = System.Random;

public class XueRenCloth : EquipBase
{
    private bool isSend = false; //是否发送消息

    public XueRenCloth() : base( "XueRenClothFight", SuitType.None,new EquipTable()){}
    
    private void Awake()
    {
        SpriteRenderer = transform.Find("XueRenClothSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "XueRenCloth";
        EquipAttributes.EquipLevel = 30;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloth;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.XueRen;
        //暂时写死
        EquipAttributes.Quality = 4;
        
        SetBaseAttribute();
        InitEntry();
    }
    
    
}
