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
            { 55, new EquipAttribute(150,250,250,75) },
            { 60, new EquipAttribute(180,300,300,100) },
            { 65, new EquipAttribute(210,370,370,140) },
            { 70, new EquipAttribute(240,440,440,180) },
            { 75, new EquipAttribute(280,520,520,230) },
            { 80, new EquipAttribute(350,600,600,290) },
            { 85, new EquipAttribute(420,700,700,360) },
            { 90, new EquipAttribute(500,820,820,420) },
            { 95, new EquipAttribute(600,950,950,500) },
            { 100, new EquipAttribute(750,1100,1100,600) },
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