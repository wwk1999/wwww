using System.Collections.Generic;
using UnityEngine;


public enum ChiBangType
{
    None,
    Blue1,
    Blue2,
    Blue3,
    Blue4,
    Blue5,
    Blue6,
    Blue7,
    Blue8,

    Green1,
    Green2,
    Green3,
    Green4,
    Green5,
    Green6,
    
    Purple1,
    Purple2,
    Purple3,
    Purple4,
    Purple5,
    Purple6,
    Purple7,
    
    Orange1,
    Orange2,
    Orange3,
    
    Red1,
}
namespace Config
{

    public class ChiBangInfo
    {
        public ChiBangType ChiBangType;
        public int Level;
        public int LevelEx;
        public int Xj;
        public int XjEx;
    }
    
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
        public static string GetChiBangName(ChiBangType chiBangType)
        {
            switch (chiBangType)
            {
                case ChiBangType.Green1:
                    return "流光";
                case ChiBangType.Green2:
                    return "墨羽";
                case ChiBangType.Green3:
                    return "青空翎";
                case ChiBangType.Green4:
                    return "炽羽鹰";
                case ChiBangType.Green5:
                    return "花蝶翼";
                case ChiBangType.Green6:
                    return "雪羽灵";

                case ChiBangType.Blue1:
                    return "霜魂";
                case ChiBangType.Blue2:
                    return "紫电闪";
                case ChiBangType.Blue3:
                    return "炽羽龙";
                case ChiBangType.Blue4:
                    return "苍穹冰翼";
                case ChiBangType.Blue5:
                    return "极光之羽";
                case ChiBangType.Blue6:
                    return "玄冰凤";
                case ChiBangType.Blue7:
                    return "阴阳天羽";
                case ChiBangType.Blue8:
                    return "魔蝠影";

                case ChiBangType.Purple1:
                    return "紫凰圣羽";
                case ChiBangType.Purple2:
                    return "赤煌龙";
                case ChiBangType.Purple3:
                    return "混沌双生";
                case ChiBangType.Purple4:
                    return "熔金火羽";
                case ChiBangType.Purple5:
                    return "星陨战翼";
                case ChiBangType.Purple6:
                    return "幻蝶妖翼";
                case ChiBangType.Purple7:
                    return "玄冰凤凰羽";

                case ChiBangType.Orange1:
                    return "炽阳神翼";
                case ChiBangType.Orange2:
                    return "虹渊魔翼";
                case ChiBangType.Orange3:
                    return "业火魔翼";

                case ChiBangType.Red1:
                    return "涅槃凤翎";

                default:
                    return "未知翅膀";
            }
        }
        
        public static Sprite GetChiBangSprite(ChiBangType chiBangType)
        {
            switch (chiBangType)
            {
                case  ChiBangType.Blue1:
                    return ResourcesConfig.Blue1;
                case  ChiBangType.Blue2:
                    return ResourcesConfig.Blue2;
                case  ChiBangType.Blue3:
                    return ResourcesConfig.Blue3;
                case  ChiBangType.Blue4:
                    return ResourcesConfig.Blue4;
                case  ChiBangType.Blue5:
                    return ResourcesConfig.Blue5;
                case  ChiBangType.Blue6:
                    return ResourcesConfig.Blue6;
                case  ChiBangType.Blue7:
                    return ResourcesConfig.Blue7;
                case  ChiBangType.Blue8:
                    return ResourcesConfig.Blue8;
                
                
                case  ChiBangType.Green1:
                    return ResourcesConfig.Green1;
                case  ChiBangType.Green2:
                    return ResourcesConfig.Green2;
                case  ChiBangType.Green3:
                    return ResourcesConfig.Green3;
                case  ChiBangType.Green4:
                    return ResourcesConfig.Green4;
                case  ChiBangType.Green5:
                    return ResourcesConfig.Green5;
                case  ChiBangType.Green6:
                    return ResourcesConfig.Green6;
               
                
                case  ChiBangType.Purple1:
                    return ResourcesConfig.Purple1;
                case  ChiBangType.Purple2:
                    return ResourcesConfig.Purple2;
                case  ChiBangType.Purple3:
                    return ResourcesConfig.Purple3;
                case  ChiBangType.Purple4:
                    return ResourcesConfig.Purple4;
                case  ChiBangType.Purple5:
                    return ResourcesConfig.Purple5;
                case  ChiBangType.Purple6:
                    return ResourcesConfig.Purple6;
                case  ChiBangType.Purple7:
                    return ResourcesConfig.Purple7;
          
                
                
                case  ChiBangType.Orange1:
                    return ResourcesConfig.Orange1;
                case  ChiBangType.Orange2:
                    return ResourcesConfig.Orange2;
                case  ChiBangType.Orange3:
                    return ResourcesConfig.Orange3;
               
                case  ChiBangType.Red1:
                    return ResourcesConfig.Red1;
            }

            return null;
        }

        
        public static int GetChiBangQuality(ChiBangType chiBangType)
        {
            switch (chiBangType)
            {
                case  ChiBangType.Blue1:
                case  ChiBangType.Blue2:
                case  ChiBangType.Blue3:
                case  ChiBangType.Blue4:
                case  ChiBangType.Blue5:
                case  ChiBangType.Blue6:
                case  ChiBangType.Blue7:
                case  ChiBangType.Blue8:
                    return 3;
                
                case  ChiBangType.Green1:
                case  ChiBangType.Green2:
                case  ChiBangType.Green3:
                case  ChiBangType.Green4:
                case  ChiBangType.Green5:
                case  ChiBangType.Green6:
                    return 2;
                
                case  ChiBangType.Purple1:
                case  ChiBangType.Purple2:
                case  ChiBangType.Purple3:
                case  ChiBangType.Purple4:
                case  ChiBangType.Purple5:
                case  ChiBangType.Purple6:
                case  ChiBangType.Purple7:
                    return 4;
                
                case  ChiBangType.Orange1:
                case  ChiBangType.Orange2:
                case  ChiBangType.Orange3:
                    return 5;
                case  ChiBangType.Red1:
                    return 6;
            }

            return 0;
        }
        
        public static Dictionary<int, int> ChiBangExDic = new Dictionary<int, int>()
        {
            {0,10},
            {1,100},
            {2,500},
            {3,3000},
            {4,20000},
            {5,100000},
            {6,1000000},
        };

        public static Dictionary<int, ChiBangAttribute> ChiBangAttributeDic = new Dictionary<int, ChiBangAttribute>()
        {
            { 0, new ChiBangAttribute { maxHp = 0, attack = 0, defense = 0 } },
            { 1, new ChiBangAttribute { maxHp = 100, attack = 30, defense = 10 } },
            { 2, new ChiBangAttribute { maxHp = 300, attack = 50, defense = 20,critDamage = 10 } },
            { 3, new ChiBangAttribute { maxHp = 800, attack = 120, defense = 40 ,critDamage = 20 ,attackSpeed = 0.1f} },
            { 4, new ChiBangAttribute { maxHp = 2000, attack = 300, defense = 100 ,critDamage = 30 ,attackSpeed = 0.15f,moveSpeed = 0.3f } },
            { 5, new ChiBangAttribute { maxHp = 5000, attack = 800, defense = 300 ,critDamage = 40 ,attackSpeed = 0.2f,moveSpeed = 0.6f,forture = 0.5f } },
            { 6, new ChiBangAttribute { maxHp = 20000, attack = 3000, defense = 1200 ,critDamage = 50 ,attackSpeed = 0.3f,moveSpeed = 1f,forture = 1f,finalDamage = 1} },
        };
    }
}