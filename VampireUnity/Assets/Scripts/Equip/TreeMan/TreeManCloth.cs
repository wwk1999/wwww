using Mysql;
using UnityEngine;
using Random = System.Random;

public class TreeManCloth : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManCloth() : base( "TreeManClothFight", SuitType.None,new EquipTable()){}
    
    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManClothSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "TreeManCloth";
        EquipAttributes.EquipLevel = 5;
        EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Cloth;
        EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.TreeMan;
        //暂时写死
        EquipAttributes.Quality = 2;
        
        SetBaseAttribute();
        InitEntry();
    }
    
    
}
