 using Mysql;
using UnityEngine;
using Random = System.Random;

public class XueRenCloak : EquipBase
{
    private bool isSend = false; //是否发送消息

    public XueRenCloak() : base( "XueRenCloakFight", SuitType.None,new EquipTable()){}
    
    private void Awake()
    {
        SpriteRenderer = transform.Find("XueRenCloakSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "XueRenCloak";
        EquipAttributes.EquipLevel = 30;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloak;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.XueRen;
        //暂时写死
        EquipAttributes.Quality = 4;
        SetBaseAttribute();  
        
        InitEntry();
    }
    
   

}
