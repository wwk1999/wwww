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
            EquipAttributes.EquipLevel = 1;

            EquipAttributes.EquipName = "PrimaryHelmet";
            EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Helmet;
            EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Primary;
            EquipAttributes.Quality = 1;

            SetBaseAttribute();

        }
       
    }
}