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
            EquipAttributes.EquipLevel = 1;
            EquipAttributes.EquipName = "PrimaryShoe";
            EquipAttributes.EquipType = PlayerEquipConfig.EquipType.Shoe;
            EquipAttributes.EquipQuality = PlayerEquipConfig.EquipLevel.Primary;
            EquipAttributes.Quality = 1;
            SetBaseAttribute();        
        }
       
    }
}