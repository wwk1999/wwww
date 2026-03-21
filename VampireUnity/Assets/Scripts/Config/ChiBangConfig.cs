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
        public ChiBangType ChiBangType=ChiBangType.None;
        public int Level=1;
        public int LevelEx=0;
        public int Xj=1;
        public int XjEx=0;
    }
    
    public class ChiBangAttribute
    {
        public float maxHp;
        public float attack;
        public float defense;
        public float Crit;
    }
    
    public class ChiBangConfig
    {
        public static Dictionary<ChiBangType, string> ChiBangCiTiaoDic = new Dictionary<ChiBangType, string>()
        {
            { ChiBangType.Green1 ,"移动速度+5%"},
            { ChiBangType.Green2 ,"黑暗元素伤害+5%"},
            { ChiBangType.Green3 ,"冰霜元素伤害+5%"},
            { ChiBangType.Green4 ,"火焰元素伤害+5%"},
            { ChiBangType.Green5 ,"治疗药剂效果+10%"},
            { ChiBangType.Green6 ,"最终伤害+5%"},
            
            { ChiBangType.Blue1 ,"雷电元素伤害+10%"},
            { ChiBangType.Blue2 ,"攻击速度+10%"},
            { ChiBangType.Blue3 ,"火焰元素伤害+10%"},
            { ChiBangType.Blue4 ,"冰霜元素伤害+10%"},
            { ChiBangType.Blue5 ,"移动速度+10%"},
            { ChiBangType.Blue6 ,"最终伤害+10%"},
            { ChiBangType.Blue7 ,"最终伤害+10%"},
            { ChiBangType.Blue8 ,"黑暗元素伤害+10%"},

            { ChiBangType.Purple1 ,"雷电,火焰元素伤害+10%"},
            { ChiBangType.Purple2 ,"火焰元素伤害+15%"},
            { ChiBangType.Purple3 ,"火焰,黑暗元素伤害+10%"},
            { ChiBangType.Purple4 ,"火焰元素伤害+15%"},
            { ChiBangType.Purple5 ,"最终伤害+15%"},
            { ChiBangType.Purple6 ,"黑暗元素伤害+15%"},
            { ChiBangType.Purple7 ,"冰霜元素伤害+15%"},
            
            { ChiBangType.Orange1 ,"火焰,雷电元素伤害+20%"},
            { ChiBangType.Orange2 ,"黑暗,冰霜元素伤害+20%"},
            { ChiBangType.Orange3 ,"最终伤害+20%"},
            
            { ChiBangType.Red1 ,"所有元素伤害+25%"},
        };
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

        public static Dictionary<int, int> ChiBangXjDic = new Dictionary<int, int>()
        {
            {1,1},
            {2,2},
            {3,4},
            {4,10},
        };
        
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
        
        public static Dictionary<int, int> YuMaoExDic = new Dictionary<int, int>()
        {
            {1,30},
            {2,100},
            {3,500},
            {4,2000},
            {5,10000},
            {6,100000},
        };
        
         public static Dictionary<int, float> ChiBangLevelAttributeDic = new Dictionary<int, float>()
        {
           {1,1.0f },
         {2,1.1f },
         {3,1.2f },
         {4,1.3f },
         {5,1.4f },
         {6,1.5f },
         {7,1.6f },
         {8,1.7f },
         {9,1.8f },
         {10,1.9f },
         
         
         {11,2.0f },
         {12,2.15f },
         {13,2.3f },
         {14,2.45f },
         {15,2.6f },
         {16,2.75f },
         {17,2.9f },
         {18,3.05f },
         {19,3.2f },
         {20,3.35f },
         
         
         {21,3.5f },
         {22,3.65f },
         {23,3.8f },
         {24,3.95f },
         {25,4.05f },
         {26,4.15f },
         {27,4.3f },
         {28,4.45f },
         {29,4.6f },
         {30,4.75f },
         
         
         {31,4.9f },
         {32,5.05f },
         {33,5.2f },
         {34,5.35f },
         {35,5.5f },
         {36,5.65f },
         {37,5.8f },
         {38,5.95f },
         {39,6.05f },
         {40,6.2f },
         
         {41,6.35f },
         {42,6.5f },
         {43,6.65f },
         {44,6.8f },
         {45,6.95f },
         {46,7.05f },
         {47,7.15f },
         {48,7.3f },
         {49,7.45f },
         {50,7.65f },
         
         {51,7.8f },
         {52,8f },
         {53,8.2f },
         {54,8.4f },
         {55,8.6f },
         {56,8.8f },
         {57,9f },
         {58,9.2f },
         {59,9.4f },
         {60,9.6f },
         
         {61,9.8f },
         {62,10f },
         {63,10.2f },
         {64,10.4f },
         {65,10.6f },
         {66,10.8f },
         {67,11f },
         {68,11.2f },
         {69,11.4f },
         {70,11.6f },
         
         {71,11.8f },
         {72,12f },
         {73,12.2f },
         {74,12.4f },
         {75,12.6f },
         {76,12.8f },
         {77,13f },
         {78,13.2f },
         {79,13.4f },
         {80,13.6f },
         
         {81,13.9f },
         {82,14.2f },
         {83,14.5f },
         {84,14.8f },
         {85,15.1f },
         {86,15.4f },
         {87,15.7f },
         {88,16f },
         {89,16.4f },
         {90,16.8f },
         
         {91,17.2f },
         {92,17.6f },
         {93,18f },
         {94,18.4f },
         {95,18.8f },
         {96,19.2f },
         {97,19.6f },
         {98,20f },
         {99,21f },
         {100,22f },
        };

        public static Dictionary<int, ChiBangAttribute> ChiBangBaseAttributeDic =
            new Dictionary<int, ChiBangAttribute>()
            {
                { 2, new ChiBangAttribute() { attack = 10, defense = 10, maxHp = 50, Crit = 50 } },
                { 3, new ChiBangAttribute() { attack = 20, defense = 20, maxHp = 100, Crit = 100 } },
                { 4, new ChiBangAttribute() { attack = 40, defense = 40, maxHp = 200, Crit = 200 } },
                { 5, new ChiBangAttribute() { attack = 100, defense = 100, maxHp = 500, Crit = 500 } },
                { 6, new ChiBangAttribute() { attack = 200, defense = 200, maxHp = 1000, Crit = 1000 } },
            };

        public static Dictionary<int, int> ChiBangExDic = new Dictionary<int, int>()
        {
            {1,50},
            {2,100},
            {3,200},
            {4,300},
            {5,400},
            {6,500},
            {7,600},
            {8,700},
            {9,800},
            {10,1000},
            
            {11,1200},
            {12,1400},
            {13,1600},
            {14,1800},
            {15,2000},
            {16,2200},
            {17,2400},
            {18,2600},
            {19,2800},
            {20,3000},
            
            {21,3200},
            {22,3400},
            {23,3600},
            {24,3800},
            {25,4000},
            {26,4200},
            {27,4400},
            {28,4600},
            {29,4800},
            {30,5000},
            
            {31,5500},
            {32,6000},
            {33,6500},
            {34,7000},
            {35,7500},
            {36,8000},
            {37,8500},
            {38,9000},
            {39,9500},
            {40,10000},
            
            {41,11000},
            {42,12000},
            {43,13000},
            {44,14000},
            {45,15000},
            {46,16000},
            {47,17000},
            {48,18000},
            {49,19000},
            {50,20000},
            
            {51,22000},
            {52,24000},
            {53,26000},
            {54,28000},
            {55,30000},
            {56,32000},
            {57,34000},
            {58,36000},
            {59,38000},
            {60,40000},
            
            {61,42000},
            {62,44000},
            {63,46000},
            {64,48000},
            {65,50000},
            {66,54000},
            {67,58000},
            {68,62000},
            {69,66000},
            {70,70000},
            
            {71,75000},
            {72,80000},
            {73,85000},
            {74,90000},
            {75,95000},
            {76,100000},
            {77,110000},
            {78,120000},
            {79,130000},
            {80,140000},
            
            {81,150000},
            {82,160000},
            {83,170000},
            {84,180000},
            {85,190000},
            {86,200000},
            {87,220000},
            {88,240000},
            {89,260000},
            {90,280000},
            
            {91,300000},
            {92,330000},
            {93,360000},
            {94,390000},
            {95,420000},
            {96,450000},
            {97,500000},
            {98,550000},
            {99,600000},
            {100,700000},
        };
    }
}