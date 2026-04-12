using Mysql;
using UnityEngine;
using Random = System.Random;

namespace Equip
{
    public class PrimaryNecklace:EquipBase
    {
        private bool isSend = false; //是否发送消息

        public PrimaryNecklace() : base( "PrimaryNecklaceFight", SuitType.None,new EquipTable()){}

        private void Awake()
        {
            SpriteRenderer = transform.Find("PrimaryNecklaceSprite").GetComponent<SpriteRenderer>();
            Random random = new Random();
            EquipAttributes.EquipLevel = 1;

            EquipAttributes.EquipName = "PrimaryNecklace";
            EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Necklace;
            EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Primary;
            EquipAttributes.Quality = 1;
            
            SetBaseAttribute();
        }
        
    }
}