using Mysql;
using UnityEngine;
using Random = System.Random;

public class XieZiCloak : EquipBase
{
    private bool isSend = false; //是否发送消息

    public XieZiCloak() : base( "XieZiCloakFight", SuitType.None,new EquipTable()){}
    
    private void Awake()
    {
        SpriteRenderer = transform.Find("XieZiCloakSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "XieZiCloak";
        EquipAttributes.EquipLevel = 25;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloak;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.XieZi;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute();  
        
        InitEntry();
    }
    
   

}
