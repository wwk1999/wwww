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
            { 10, new EquipAttribute(20,40,40,10) },
            { 15, new EquipAttribute(30,60,60,15) },
            { 20, new EquipAttribute(40,80,80,20) },
            { 25, new EquipAttribute(50,100,100,25) },
            { 30, new EquipAttribute(70,140,140,35) },
            { 35, new EquipAttribute(100,200,200,50) },
            { 40, new EquipAttribute(130,260,260,80) },
            { 45, new EquipAttribute(160,320,320,100) },
            { 50, new EquipAttribute(200,400,400,125) },
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
    }
}