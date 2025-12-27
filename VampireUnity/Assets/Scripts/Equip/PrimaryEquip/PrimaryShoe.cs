using Mysql;
using UnityEngine;
using Random = System.Random;

namespace Equip
{
    public class PrimaryShoe:EquipBase
    {
        private bool isSend = false; //是否发送消息

        public PrimaryShoe() : base( "PrimaryShoeFight", SuitType.None,new EquipTable()){}

        private void Awake()
        {
            SpriteRenderer = transform.Find("PrimaryShoeSprite").GetComponent<SpriteRenderer>();
            Random random = new Random();
            EquipAttributes.EquipLevel = 1;

            EquipAttributes.EquipName = "PrimaryShoe";
            EquipAttributes.suitid = 1;
            EquipAttributes.equip_type_id = 6;
            EquipAttributes.Quality = 1;
            SetBaseAttribute();        
        }
       
    }
}