using UnityEngine;
using Random = System.Random;

namespace Equip
{
    public class PrimaryCloak:EquipBase
    {
        private bool isSend = false; //是否发送消息

        public PrimaryCloak() : base( "PrimaryCloakFight", SuitType.None,new EquipTable()){}

        private void Awake()
        {
            SpriteRenderer = transform.Find("PrimaryCloakSprite").GetComponent<SpriteRenderer>();
             Random random = new Random();
            EquipAttributes.EquipName = "PrimaryCloak";
            EquipAttributes.suitid = 1;
            EquipAttributes.equip_type_id = 1;
            EquipAttributes.Quality = 1;
            
            //装备属性
            EquipAttributes.CRIT=random.Next(4,8);
            EquipAttributes.Damage=random.Next(4,8);
        }
    }
}