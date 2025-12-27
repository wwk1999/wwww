using Mysql;
using UnityEngine;
using Random = System.Random;

namespace Equip
{
    public class PrimaryHelmet:EquipBase
    {
        private bool isSend = false; //是否发送消息

        public PrimaryHelmet() : base( "PrimaryHelmetFight", SuitType.None,new EquipTable()){}

        private void Awake()
        {
            SpriteRenderer = transform.Find("PrimaryHelmetSprite").GetComponent<SpriteRenderer>();
            Random random = new Random();
            EquipAttributes.EquipName = "PrimaryHelmet";
            EquipAttributes.suitid = 1;
            EquipAttributes.equip_type_id = 3;
            EquipAttributes.Quality = 1;
            
            EquipAttributes.Defense=random.Next(1,3);
            EquipAttributes.HP=random.Next(8,15);
            
        }
       
    }
}