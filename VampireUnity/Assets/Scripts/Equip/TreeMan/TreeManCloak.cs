using Mysql;
using UnityEngine;
using Random = System.Random;

public class TreeManCloak : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManCloak() : base( "TreeManCloakFight", SuitType.None,new EquipTable()){}
    
    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManCloakSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "TreeManCloak";
        EquipAttributes.EquipLevel = 5;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloak;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.TreeMan;
        //暂时写死
        EquipAttributes.Quality = 2;
        SetBaseAttribute();  
        
        InitEntry();
    }
    
   

}
