using Mysql;
using UnityEngine;
using Random = System.Random;

namespace Equip
{
    public class PrimaryRing:EquipBase
    {
        private bool isSend = false; //是否发送消息

        public PrimaryRing() : base( "PrimaryRingFight", SuitType.None,new EquipTable()){}

        private void Awake()
        {
            SpriteRenderer = transform.Find("PrimaryRingSprite").GetComponent<SpriteRenderer>();
            Random random = new Random();
            EquipAttributes.EquipLevel = 1;

            EquipAttributes.EquipName = "PrimaryRing";
            EquipAttributes.suitid =1;
            EquipAttributes.equip_type_id = 5;
            EquipAttributes.Quality = 1;
            SetBaseAttribute();
            
        }
       
    }
}