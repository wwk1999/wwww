using Mysql;
using UnityEngine;
using Random = System.Random;

public class TreeManCloak : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManCloak() : base( "TreeManCloakFight", SuitType.TreeMan,new EquipTable()){}
    
    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManCloakSprite").GetComponent<SpriteRenderer>();
        EquipAttributes.EquipName = "TreeManCloak";
        EquipAttributes.EquipLevel = 5;
        EquipAttributes.suitid = 101;
        EquipAttributes.equip_type_id = 1;
        //暂时写死
        EquipAttributes.Quality = 2;
        SetBaseAttribute();  
        
        InitEntry();
    }
    
   

}
