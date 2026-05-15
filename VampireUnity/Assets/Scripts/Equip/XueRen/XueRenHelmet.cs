using UnityEngine;
using Random = System.Random;
using Mysql;
public class XueRenHelmet : EquipBase
{
    private bool isSend = false; //是否发送消息

    public XueRenHelmet() : base( "XueRenHelmetFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("XueRenHelmetSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "XueRenHelmet";
        EquipAttributes.EquipLevel = 30;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Helmet;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.XueRen;
        EquipAttributes.Quality = 4;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
