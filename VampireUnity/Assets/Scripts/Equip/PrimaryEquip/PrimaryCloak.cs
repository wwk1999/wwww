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
             EquipAttributes.EquipLevel = 1;

            EquipAttributes.EquipName = "PrimaryCloak";
            EquipAttributes.suitid = 1;
            EquipAttributes.equip_type_id = 1;
            EquipAttributes.Quality = 1;
            
            SetBaseAttribute();
        }
    }
}