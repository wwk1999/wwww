using Mysql;
using UnityEngine;
using Random = System.Random;

public class XieZiCloth : EquipBase
{
    private bool isSend = false; //是否发送消息

    public XieZiCloth() : base( "XieZiClothFight", SuitType.None,new EquipTable()){}
    
    private void Awake()
    {
        SpriteRenderer = transform.Find("XieZiClothSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "XieZiCloth";
        EquipAttributes.EquipLevel = 25;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloth;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.XieZi;
        //暂时写死
        EquipAttributes.Quality = 4;
        
        SetBaseAttribute();
        InitEntry();
    }
    
    
}
