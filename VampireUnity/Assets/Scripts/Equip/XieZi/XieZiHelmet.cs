using UnityEngine;
using Random = System.Random;
using Mysql;
public class XieZiHelmet : EquipBase
{
    private bool isSend = false; //是否发送消息

    public XieZiHelmet() : base( "XieZiHelmetFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("XieZiHelmetSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "XieZiHelmet";
        EquipAttributes.EquipLevel = 25;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Helmet;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.XieZi;
        EquipAttributes.Quality = 4;
        
        SetBaseAttribute();
        InitEntry();
    }
    
}
