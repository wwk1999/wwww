using Mysql;
using UnityEngine;
using Random = System.Random;

namespace Equip
{
    public class PrimaryCloth:EquipBase
    {
        private bool isSend = false; //是否发送消息
        public PrimaryCloth() : base( "PrimaryClothFight", SuitType.None,new EquipTable()){}

        private void Awake()
        {
            SpriteRenderer = transform.Find("PrimaryClothSprite").GetComponent<SpriteRenderer>();
             Random random = new Random();
            EquipAttributes.EquipName = "PrimaryCloth";
            EquipAttributes.suitid = 1;
            EquipAttributes.equip_type_id = 2;
            EquipAttributes.Quality = 1;
            
            EquipAttributes.Defense=random.Next(2,4);
            EquipAttributes.HP=random.Next(10,20);
            
        }
       
    }
}