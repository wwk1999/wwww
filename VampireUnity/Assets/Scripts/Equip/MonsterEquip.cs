using System;

namespace Equip
{
    //怪物掉落装备的基本属性
    public class MonsterEquip
    {
        public PlayerEquipConfig.EquipType EquipType;
        public PlayerEquipConfig.EquipLevel EquipLevel;
        public float Probability;
        public bool Orange = false;

        public MonsterEquip(PlayerEquipConfig.EquipType equipType,
            PlayerEquipConfig.EquipLevel equipLevel = PlayerEquipConfig.EquipLevel.None,
            float probability = 0,
            bool orange = false)
        {
            EquipType = equipType;
            EquipLevel = equipLevel;
            Probability = probability;
            Orange = orange;
        }

        // 重写 Equals：不比较概率
        public override bool Equals(object obj)
        {
            if (obj is MonsterEquip other)
            {
                return EquipType == other.EquipType &&
                       EquipLevel == other.EquipLevel &&
                       Orange == other.Orange;
            }
            return false;
        }

        // 重写 GetHashCode：只使用参与比较的字段
        public override int GetHashCode()
        {
            return HashCode.Combine(EquipType, EquipLevel, Orange);
        }
    }
    
    public class MonsterOrangeEntryEquip
    {

        public EntryConfig.OrangeEntry OrangeEntry;
        public int Probability;

        public MonsterOrangeEntryEquip(EntryConfig.OrangeEntry orangeEntry,int probability)
        {
            OrangeEntry = orangeEntry;
            Probability = probability;
        }
    }
}