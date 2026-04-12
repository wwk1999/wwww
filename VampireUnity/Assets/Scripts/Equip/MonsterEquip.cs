namespace Equip
{
    //怪物掉落装备的基本属性
    public class MonsterEquip
    {

        public PlayerEquipConfig.EquipType EquipType;
        public PlayerEquipConfig.EquipLevel EquipLevel;
        public float Probability;
        public bool Orange = false;

        public MonsterEquip( PlayerEquipConfig.EquipType equipType,PlayerEquipConfig.EquipLevel equipLevel=PlayerEquipConfig.EquipLevel.None, float probability=0,bool orange=false)
        {
            EquipType = equipType;
            EquipLevel = equipLevel;
            Probability = probability;
            Orange = orange;
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