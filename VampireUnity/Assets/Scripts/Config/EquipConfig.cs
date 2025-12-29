using System.Collections.Generic;

namespace Config
{
    public class EquipAttribute
    {
        public float Attack;
        public float Crit;
        public float Hp;
        public float Defense;

        public EquipAttribute(float attack, float crit, float hp, float defense)
        {
            Attack = attack;
            Crit = crit;
            Hp = hp;
            Defense = defense;
        }
    }
    public class EquipConfig
    {
        public static Dictionary<int, EquipAttribute> EquipBaseAttributeDic = new Dictionary<int, EquipAttribute>()
        {
            { 1, new EquipAttribute(5,10,10,3) },
            { 5, new EquipAttribute(10,20,20,5) },
            { 10, new EquipAttribute(15,30,30,10) },
            { 15, new EquipAttribute(20,40,40,15) },
            { 20, new EquipAttribute(30,50,50,20) },
            { 25, new EquipAttribute(40,60,60,25) },
            { 30, new EquipAttribute(50,80,80,30) },
            { 35, new EquipAttribute(70,100,100,35) },
            { 40, new EquipAttribute(90,130,130,40) },
            { 45, new EquipAttribute(110,160,160,45) },
            { 50, new EquipAttribute(130,200,200,50) },
        };

        public static Dictionary<int, float> EquipQualityDic = new Dictionary<int, float>()
        {
            { 1, 1 },
            { 2, 1.25f },
            { 3, 1.5f },
            { 4, 2f },
            { 5, 2.5f },
            { 6, 3.5f },
        };
        
        public static Dictionary<int, float> EquipEntryQualityDic = new Dictionary<int, float>()
        {
            { 2, 1f },
            { 3, 1.25f },
            { 4, 1.5f },
            { 5, 2f },
            { 6, 3f },
        };
    }
}