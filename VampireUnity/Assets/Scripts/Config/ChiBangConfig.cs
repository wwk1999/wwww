using System.Collections.Generic;

namespace Config
{
    public class ChiBangAttribute
    {
        public float maxHp;
        public float attack;
        public float defense;
        public float critDamage;
        public float attackSpeed;
        public float moveSpeed;
        public float forture;
        public float finalDamage;
    }
    public class ChiBangConfig
    {
        public static Dictionary<int, int> ChiBangExDic = new Dictionary<int, int>()
        {
            {0,10},
            {1,50},
            {2,250},
            {3,1000},
            {4,5000},
            {5,20000},
            {6,100000},
        };

        public static Dictionary<int, ChiBangAttribute> ChiBangAttributeDic = new Dictionary<int, ChiBangAttribute>()
        {
            { 1, new ChiBangAttribute { maxHp = 100, attack = 30, defense = 10 } },
            { 2, new ChiBangAttribute { maxHp = 300, attack = 50, defense = 20,critDamage = 10 } },
            { 3, new ChiBangAttribute { maxHp = 800, attack = 120, defense = 40 ,critDamage = 20 ,attackSpeed = 0.1f} },
            { 4, new ChiBangAttribute { maxHp = 2000, attack = 300, defense = 100 ,critDamage = 30 ,attackSpeed = 0.15f,moveSpeed = 0.3f } },
            { 5, new ChiBangAttribute { maxHp = 5000, attack = 800, defense = 300 ,critDamage = 40 ,attackSpeed = 0.2f,moveSpeed = 0.6f} },
            { 6, new ChiBangAttribute { maxHp = 20000, attack = 3000, defense = 1200 ,critDamage = 50 ,attackSpeed = 0.3f,moveSpeed = 1f,finalDamage = 1} },
        };
    }
}