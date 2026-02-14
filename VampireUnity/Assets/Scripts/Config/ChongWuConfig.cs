using System.Collections.Generic;
using UnityEngine;

public class ChongWuConfig
{
    public enum ChongWuSKillType
    {
        None,
        AddAttack,
        AddDefense,
        AddHp,
        AddCrit,
        AddYuanSu,
        AddAttackSpeed,
        AddMoveSpeed,
        AddFinalDamage,
        HuoSkillCd,
        HuoSkillDamage,
        IceSkillCd,
        IceSkillDamage,
        DianSkillCd,
        DianSkillDamage,
        HeiAnSkillCd,
        HeiAnSkillDamage,
    }
    
    public class MinMax
    {
        public float min;
        public float max;
    }

    public class ChongWuAttribute
    {
        public float Attack;
        public float Defence;
        public float Hp;
        public float Crit;
    }

    public static Dictionary<int, int> ShiWuDic = new Dictionary<int, int>()
    {
        {1,20},
        {2,50},
        {3,100},
        {4,200},
        {5,500},
        {6,1000},
    };
    
    public static Dictionary<int, int> XingJiDic = new Dictionary<int, int>()
    {
        {0,100},
        {1,300},
        {2,1000},
        {3,2000},
        {4,5000},
        {5,10000},
    };

    public static Dictionary<ChongWuYuanSuType, List<ChongWuSKillType>> ChongWuSkillDic =
        new Dictionary<ChongWuYuanSuType, List<ChongWuSKillType>>()
        {
            { ChongWuYuanSuType.Ice ,new List<ChongWuSKillType>() { ChongWuSKillType.AddAttack , ChongWuSKillType.AddCrit , ChongWuSKillType.AddHp , ChongWuSKillType.AddDefense , ChongWuSKillType.AddAttackSpeed , ChongWuSKillType.AddFinalDamage , ChongWuSKillType.AddYuanSu , ChongWuSKillType.AddMoveSpeed ,ChongWuSKillType.IceSkillCd,ChongWuSKillType.IceSkillDamage}},
            { ChongWuYuanSuType.Huo ,new List<ChongWuSKillType>() { ChongWuSKillType.AddAttack , ChongWuSKillType.AddCrit , ChongWuSKillType.AddHp , ChongWuSKillType.AddDefense , ChongWuSKillType.AddAttackSpeed , ChongWuSKillType.AddFinalDamage , ChongWuSKillType.AddYuanSu , ChongWuSKillType.AddMoveSpeed ,ChongWuSKillType.HuoSkillCd,ChongWuSKillType.HuoSkillDamage}},
            { ChongWuYuanSuType.Dian ,new List<ChongWuSKillType>() { ChongWuSKillType.AddAttack , ChongWuSKillType.AddCrit , ChongWuSKillType.AddHp , ChongWuSKillType.AddDefense , ChongWuSKillType.AddAttackSpeed , ChongWuSKillType.AddFinalDamage , ChongWuSKillType.AddYuanSu , ChongWuSKillType.AddMoveSpeed ,ChongWuSKillType.DianSkillCd,ChongWuSKillType.DianSkillDamage}},
            { ChongWuYuanSuType.HeiAn ,new List<ChongWuSKillType>() { ChongWuSKillType.AddAttack , ChongWuSKillType.AddCrit , ChongWuSKillType.AddHp , ChongWuSKillType.AddDefense , ChongWuSKillType.AddAttackSpeed , ChongWuSKillType.AddFinalDamage , ChongWuSKillType.AddYuanSu , ChongWuSKillType.AddMoveSpeed ,ChongWuSKillType.HeiAnSkillCd,ChongWuSKillType.HeiAnSkillDamage}},
        };
    

    public static Dictionary<int, int> ChongWuExDic = new Dictionary<int, int>()
    {
        {1,100},
        {2,120},
        {3,140},
        {4,160},
        {5,180},
        {6,200},
        {7,220},
        {8,240},
        {9,260},
        {10,280},
        
        {11,300},
        {12,320},
        {13,340},
        {14,360},
        {15,380},
        {16,400},
        {17,420},
        {18,440},
        {19,460},
        {20,480},

        {21,500},
        {22,520},
        {23,540},
        {24,560},
        {25,580},
        {26,600},
        {27,620},
        {28,640},
        {29,660},
        {30,680},
        
        {31,700},
        {32,800},
        {33,850},
        {34,900},
        {35,950},
        {36,1000},
        {37,1050},
        {38,1100},
        {39,1150},
        {40,1200},
        
        {41,1250},
        {42,1300},
        {43,1350},
        {44,1400},
        {45,1450},
        {46,1500},
        {47,1550},
        {48,1600},
        {49,1650},
        {50,1700},
        
        {51,1750},
        {52,1800},
        {53,1850},
        {54,1900},
        {55,1950},
        {56,2000},
        {57,2150},
        {58,2200},
        {59,2250},
        {60,2300},
        
        {61,2400},
        {62,2500},
        {63,2600},
        {64,2700},
        {65,2800},
        {66,2900},
        {67,3000},
        {68,3100},
        {69,3200},
        {70,3300},
        
        {71,3400},
        {72,3500},
        {73,3600},
        {74,3700},
        {75,3800},
        {76,3900},
        {77,4000},
        {78,4200},
        {79,4400},
        {80,4600},
        
        {81,4800},
        {82,5000},
        {83,5200},
        {84,5400},
        {85,5600},
        {86,5800},
        {87,6000},
        {88,6200},
        {89,6400},
        {90,6600},
        
        {91,6900},
        {92,7200},
        {93,7500},
        {94,7800},
        {95,8100},
        {96,8400},
        {97,8700},
        {98,9000},
        {99,9500},
        {100,10000},
    };

    public static Dictionary<int, ChongWuAttribute> ChongWuAttributeDic = new Dictionary<int, ChongWuAttribute>()
{
    {1, new ChongWuAttribute(){Attack = 5, Defence = 3, Crit = 8, Hp = 10} },      // 3*0.9=2.7→3
    {2, new ChongWuAttribute(){Attack = 6, Defence = 4, Crit = 10, Hp = 12} },     // 4*0.9=3.6→4
    {3, new ChongWuAttribute(){Attack = 7, Defence = 5, Crit = 12, Hp = 14} },     // 5*0.9=4.5→5
    {4, new ChongWuAttribute(){Attack = 8, Defence = 6, Crit = 14, Hp = 16} },     // 6*0.9=5.4→6
    {5, new ChongWuAttribute(){Attack = 9, Defence = 7, Crit = 16, Hp = 18} },     // 7*0.9=6.3→7
    {6, new ChongWuAttribute(){Attack = 10, Defence = 9, Crit = 20, Hp = 21} },    // 9*0.9=8.1→9
    {7, new ChongWuAttribute(){Attack = 12, Defence = 10, Crit = 23, Hp = 25} },   // 11*0.9=9.9→10
    {8, new ChongWuAttribute(){Attack = 14, Defence = 12, Crit = 26, Hp = 29} },   // 13*0.9=11.7→12
    {9, new ChongWuAttribute(){Attack = 16, Defence = 14, Crit = 29, Hp = 33} },   // 15*0.9=13.5→14
    {10, new ChongWuAttribute(){Attack = 18, Defence = 16, Crit = 32, Hp = 37} },  // 17*0.9=15.3→16
    
    {11, new ChongWuAttribute(){Attack = 20, Defence = 18, Crit = 35, Hp = 40} },  // 19*0.9=17.1→18
    {12, new ChongWuAttribute(){Attack = 22, Defence = 19, Crit = 38, Hp = 43} },  // 21*0.9=18.9→19
    {13, new ChongWuAttribute(){Attack = 24, Defence = 21, Crit = 41, Hp = 46} },  // 23*0.9=20.7→21
    {14, new ChongWuAttribute(){Attack = 26, Defence = 23, Crit = 44, Hp = 49} },  // 25*0.9=22.5→23
    {15, new ChongWuAttribute(){Attack = 28, Defence = 25, Crit = 47, Hp = 52} },  // 27*0.9=24.3→25
    {16, new ChongWuAttribute(){Attack = 30, Defence = 27, Crit = 50, Hp = 55} },  // 29*0.9=26.1→27
    {17, new ChongWuAttribute(){Attack = 32, Defence = 28, Crit = 53, Hp = 58} },  // 31*0.9=27.9→28
    {18, new ChongWuAttribute(){Attack = 34, Defence = 30, Crit = 56, Hp = 61} },  // 33*0.9=29.7→30
    {19, new ChongWuAttribute(){Attack = 36, Defence = 32, Crit = 59, Hp = 64} },  // 35*0.9=31.5→32
    {20, new ChongWuAttribute(){Attack = 38, Defence = 34, Crit = 62, Hp = 67} },  // 37*0.9=33.3→34
    
    {31, new ChongWuAttribute(){Attack = 40, Defence = 36, Crit = 65, Hp = 70} },  // 39*0.9=35.1→36
    {32, new ChongWuAttribute(){Attack = 45, Defence = 42, Crit = 70, Hp = 73} },  // 46*0.9=41.4→42
    {33, new ChongWuAttribute(){Attack = 50, Defence = 48, Crit = 75, Hp = 76} },  // 53*0.9=47.7→48
    {34, new ChongWuAttribute(){Attack = 55, Defence = 50, Crit = 80, Hp = 79} },  // 55*0.9=49.5→50
    {35, new ChongWuAttribute(){Attack = 60, Defence = 52, Crit = 85, Hp = 86} },  // 57*0.9=51.3→52
    {36, new ChongWuAttribute(){Attack = 65, Defence = 55, Crit = 90, Hp = 95} },  // 61*0.9=54.9→55
    {37, new ChongWuAttribute(){Attack = 70, Defence = 62, Crit = 95, Hp = 98} },  // 68*0.9=61.2→62
    {38, new ChongWuAttribute(){Attack = 75, Defence = 66, Crit = 100, Hp = 101} }, // 73*0.9=65.7→66
    {39, new ChongWuAttribute(){Attack = 80, Defence = 70, Crit = 105, Hp = 104} }, // 77*0.9=69.3→70
    {40, new ChongWuAttribute(){Attack = 85, Defence = 74, Crit = 110, Hp = 107} }, // 82*0.9=73.8→74
    
    {41, new ChongWuAttribute(){Attack = 90, Defence = 80, Crit = 115, Hp = 112} }, // 88*0.9=79.2→80
    {42, new ChongWuAttribute(){Attack = 95, Defence = 83, Crit = 120, Hp = 124} }, // 92*0.9=82.8→83
    {43, new ChongWuAttribute(){Attack = 100, Defence = 88, Crit = 125, Hp = 130} }, // 97*0.9=87.3→88
    {44, new ChongWuAttribute(){Attack = 105, Defence = 92, Crit = 130, Hp = 135} }, // 102*0.9=91.8→92
    {45, new ChongWuAttribute(){Attack = 110, Defence = 97, Crit = 135, Hp = 140} }, // 107*0.9=96.3→97
    {46, new ChongWuAttribute(){Attack = 115, Defence = 100, Crit = 140, Hp = 143} }, // 111*0.9=99.9→100
    {47, new ChongWuAttribute(){Attack = 120, Defence = 107, Crit = 150, Hp = 151} }, // 118*0.9=106.2→107
    {48, new ChongWuAttribute(){Attack = 125, Defence = 112, Crit = 160, Hp = 163} }, // 124*0.9=111.6→112
    {49, new ChongWuAttribute(){Attack = 130, Defence = 115, Crit = 170, Hp = 172} }, // 127*0.9=114.3→115
    {50, new ChongWuAttribute(){Attack = 135, Defence = 119, Crit = 180, Hp = 186} }, // 132*0.9=118.8→119
    
    {51, new ChongWuAttribute(){Attack = 140, Defence = 127, Crit = 190, Hp = 192} }, // 141*0.9=126.9→127
    {52, new ChongWuAttribute(){Attack = 145, Defence = 132, Crit = 200, Hp = 205} }, // 146*0.9=131.4→132
    {53, new ChongWuAttribute(){Attack = 150, Defence = 137, Crit = 210, Hp = 220} }, // 152*0.9=136.8→137
    {54, new ChongWuAttribute(){Attack = 155, Defence = 141, Crit = 220, Hp = 225} }, // 156*0.9=140.4→141
    {55, new ChongWuAttribute(){Attack = 160, Defence = 145, Crit = 230, Hp = 233} }, // 161*0.9=144.9→145
    {56, new ChongWuAttribute(){Attack = 165, Defence = 150, Crit = 240, Hp = 243} }, // 166*0.9=149.4→150
    {57, new ChongWuAttribute(){Attack = 170, Defence = 154, Crit = 250, Hp = 251} }, // 171*0.9=153.9→154
    {58, new ChongWuAttribute(){Attack = 175, Defence = 161, Crit = 260, Hp = 263} }, // 178*0.9=160.2→161
    {59, new ChongWuAttribute(){Attack = 180, Defence = 164, Crit = 270, Hp = 272} }, // 182*0.9=163.8→164
    {60, new ChongWuAttribute(){Attack = 185, Defence = 169, Crit = 280, Hp = 286} }, // 187*0.9=168.3→169
    
    {61, new ChongWuAttribute(){Attack = 195, Defence = 172, Crit = 290, Hp = 292} }, // 191*0.9=171.9→172
    {62, new ChongWuAttribute(){Attack = 205, Defence = 186, Crit = 300, Hp = 306} }, // 206*0.9=185.4→186
    {63, new ChongWuAttribute(){Attack = 215, Defence = 191, Crit = 310, Hp = 310} }, // 212*0.9=190.8→191
    {64, new ChongWuAttribute(){Attack = 225, Defence = 204, Crit = 320, Hp = 326} }, // 226*0.9=203.4→204
    {65, new ChongWuAttribute(){Attack = 235, Defence = 208, Crit = 330, Hp = 333} }, // 231*0.9=207.9→208
    {66, new ChongWuAttribute(){Attack = 245, Defence = 222, Crit = 350, Hp = 353} }, // 246*0.9=221.4→222
    {67, new ChongWuAttribute(){Attack = 255, Defence = 226, Crit = 370, Hp = 371} }, // 251*0.9=225.9→226
    {68, new ChongWuAttribute(){Attack = 265, Defence = 242, Crit = 390, Hp = 393} }, // 268*0.9=241.2→242
    {69, new ChongWuAttribute(){Attack = 275, Defence = 245, Crit = 410, Hp = 412} }, // 272*0.9=244.8→245
    {70, new ChongWuAttribute(){Attack = 285, Defence = 259, Crit = 430, Hp = 436} }, // 287*0.9=258.3→259
    
    {71, new ChongWuAttribute(){Attack = 295, Defence = 262, Crit = 450, Hp = 452} }, // 291*0.9=261.9→262
    {72, new ChongWuAttribute(){Attack = 305, Defence = 277, Crit = 470, Hp = 477} }, // 307*0.9=276.3→277
    {73, new ChongWuAttribute(){Attack = 315, Defence = 281, Crit = 490, Hp = 490} }, // 312*0.9=280.8→281
    {74, new ChongWuAttribute(){Attack = 325, Defence = 295, Crit = 510, Hp = 517} }, // 327*0.9=294.3→295
    {75, new ChongWuAttribute(){Attack = 335, Defence = 298, Crit = 530, Hp = 533} }, // 331*0.9=297.9→298
    {76, new ChongWuAttribute(){Attack = 345, Defence = 313, Crit = 550, Hp = 553} }, // 347*0.9=312.3→313
    {77, new ChongWuAttribute(){Attack = 355, Defence = 316, Crit = 570, Hp = 571} }, // 351*0.9=315.9→316
    {78, new ChongWuAttribute(){Attack = 365, Defence = 323, Crit = 590, Hp = 593} }, // 358*0.9=322.2→323
    {79, new ChongWuAttribute(){Attack = 275, Defence = 335, Crit = 610, Hp = 612} }, // 372*0.9=334.8→335
    {80, new ChongWuAttribute(){Attack = 385, Defence = 349, Crit = 630, Hp = 637} }, // 387*0.9=348.3→349
    
    {81, new ChongWuAttribute(){Attack = 395, Defence = 352, Crit = 650, Hp = 652} }, // 391*0.9=351.9→352
    {82, new ChongWuAttribute(){Attack = 405, Defence = 368, Crit = 670, Hp = 678} }, // 408*0.9=367.2→368
    {83, new ChongWuAttribute(){Attack = 415, Defence = 371, Crit = 690, Hp = 690} }, // 412*0.9=370.8→371
    {84, new ChongWuAttribute(){Attack = 425, Defence = 386, Crit = 710, Hp = 718} }, // 428*0.9=385.2→386
    {85, new ChongWuAttribute(){Attack = 435, Defence = 388, Crit = 730, Hp = 733} }, // 431*0.9=387.9→388
    {86, new ChongWuAttribute(){Attack = 445, Defence = 404, Crit = 750, Hp = 753} }, // 448*0.9=403.2→404
    {87, new ChongWuAttribute(){Attack = 455, Defence = 406, Crit = 770, Hp = 771} }, // 451*0.9=405.9→406
    {88, new ChongWuAttribute(){Attack = 465, Defence = 422, Crit = 790, Hp = 793} }, // 468*0.9=421.2→422
    {89, new ChongWuAttribute(){Attack = 475, Defence = 425, Crit = 810, Hp = 812} }, // 472*0.9=424.8→425
    {90, new ChongWuAttribute(){Attack = 485, Defence = 440, Crit = 830, Hp = 838} }, // 488*0.9=439.2→440
    
    {91, new ChongWuAttribute(){Attack = 505, Defence = 451, Crit = 850, Hp = 852} }, // 501*0.9=450.9→451
    {92, new ChongWuAttribute(){Attack = 525, Defence = 477, Crit = 870, Hp = 879} }, // 529*0.9=476.1→477
    {93, new ChongWuAttribute(){Attack = 545, Defence = 488, Crit = 890, Hp = 890} }, // 542*0.9=487.8→488
    {94, new ChongWuAttribute(){Attack = 565, Defence = 513, Crit = 910, Hp = 919} }, // 569*0.9=512.1→513
    {95, new ChongWuAttribute(){Attack = 585, Defence = 523, Crit = 930, Hp = 933} }, // 581*0.9=522.9→523
    {96, new ChongWuAttribute(){Attack = 605, Defence = 549, Crit = 950, Hp = 953} }, // 609*0.9=548.1→549
    {97, new ChongWuAttribute(){Attack = 625, Defence = 559, Crit = 970, Hp = 971} }, // 621*0.9=558.9→559
    {98, new ChongWuAttribute(){Attack = 655, Defence = 594, Crit = 990, Hp = 993} }, // 659*0.9=593.1→594
    {99, new ChongWuAttribute(){Attack = 685, Defence = 614, Crit = 1010, Hp = 1102} }, // 682*0.9=613.8→614
    {100, new ChongWuAttribute(){Attack = 735, Defence = 666, Crit = 1100, Hp = 1109} } // 739*0.9=665.1→666
};
    public static Dictionary<int, float> NormalChongWuDanGaiLv = new Dictionary<int, float>()
    {
        { 1, 40 },
        { 2, 30 },
        { 3, 20 },
        { 4, 10 },
    };
    
    public static Dictionary<int, float> GaoJiChongWuDanGaiLv = new Dictionary<int, float>()
    {
        { 1, 20 },
        { 2, 25 },
        { 3, 30 },
        { 4, 20 },
        { 5, 5 },
    };

    public static Dictionary<int, int> ChongWuJingHuaDic = new Dictionary<int, int>()
    {
        {1,10},
        {2,20},
        {3,50},
        {4,100},
        {5,500},
        {6,1000},
    };

    public static Dictionary<int, List<ChongWuType>> ChongWuQualityDic = new Dictionary<int, List<ChongWuType>>()
    {
        { 1, new List<ChongWuType>() { ChongWuType.icewhite1, ChongWuType.dianwhite1,ChongWuType.heianwhite1,ChongWuType.huowhite1,ChongWuType.heianwhite2,} },
        { 2, new List<ChongWuType>() { ChongWuType.icegreen1, ChongWuType.icegreen2,ChongWuType.icegreen3,ChongWuType.huogreen1,ChongWuType.huogreen2,ChongWuType.diangreen1,ChongWuType.diangreen2,ChongWuType.heiangreen1,ChongWuType.heiangreen2,ChongWuType.heiangreen3} },
        { 3, new List<ChongWuType>() { ChongWuType.iceblue1, ChongWuType.iceblue2,ChongWuType.huoblue1,ChongWuType.huoblue2,ChongWuType.huoblue3,ChongWuType.dianblue1,ChongWuType.dianblue2,ChongWuType.heianblue1,ChongWuType.heianblue2,ChongWuType.heianblue3} },
        { 4, new List<ChongWuType>() { ChongWuType.icepurple1_q, ChongWuType.icepurple2_q,ChongWuType.icepurple3_q,ChongWuType.huopurple1_q,ChongWuType.huopurple2_q,ChongWuType.huopurple3_q,ChongWuType.dianpurple1_q,ChongWuType.dianpurple2_q,ChongWuType.dianpurple3_q,ChongWuType.heianpurple1_q,ChongWuType.heianpurple2_q,ChongWuType.heianpurple3_q} },
        { 5, new List<ChongWuType>() { ChongWuType.iceorange1_q,ChongWuType.huoorange1_q,ChongWuType.dianorange1_q,ChongWuType.heianorange1_q} },
    };

    public static Dictionary<int, MinMax> ChongWuZiZhiDic = new Dictionary<int, MinMax>()
    {
        {1,new MinMax(){min = 60,max = 100} },
        {2,new MinMax(){min = 80,max = 120} },
        {3,new MinMax(){min = 100,max = 140} },
        {4,new MinMax(){min = 120,max = 160} },
        {5,new MinMax(){min = 150,max = 200} },
        {6,new MinMax(){min = 200,max = 300} },
    };
    
    public static Dictionary<int, MinMax> ChongWuXueMaiDic = new Dictionary<int, MinMax>()
    {
        {1,new MinMax(){min = 0.6f,max = 1f} },
        {2,new MinMax(){min = 0.8f,max = 1.2f} },
        {3,new MinMax(){min = 1f,max = 1.4f} },
        {4,new MinMax(){min = 1.2f,max = 1.6f} },
        {5,new MinMax(){min = 1.5f,max = 2f} },
        {6,new MinMax(){min = 2f,max = 3f} },
    };

    public static Dictionary<ChongWuType, string> ChongWuNamDic = new Dictionary<ChongWuType, string>()
    {
        { ChongWuType.dianwhite1,"熔电粘液怪" },
        { ChongWuType.dianblue1,"胶电仔" },
        { ChongWuType.dianblue2,"雷葱头" },
        { ChongWuType.diangreen1,"电泡球" },
        { ChongWuType.diangreen2,"雷啾" },
        { ChongWuType.dianorange1_q,"雷翼龙" },
        { ChongWuType.dianorange1_h,"雷翼龙" },
        { ChongWuType.dianpurple1_q,"雷甲" },
        { ChongWuType.dianpurple1_h,"雷甲" },
        { ChongWuType.dianpurple2_q,"电翎凤" },
        { ChongWuType.dianpurple2_h,"电翎凤" },
        { ChongWuType.dianpurple3_q,"雷球姬" },
        { ChongWuType.dianpurple3_h,"雷球姬" },

        
        { ChongWuType.heianblue1,"黑魔仔" },
        { ChongWuType.heianblue2,"咒猫" },
        { ChongWuType.heianblue3,"岩魔猪" },
        { ChongWuType.heiangreen1,"暗泡" },
        { ChongWuType.heiangreen2,"虚空史莱姆" },
        { ChongWuType.heiangreen3,"岩猪" },
        { ChongWuType.heianorange1_q,"暗黑主宰" },
        { ChongWuType.heianorange1_h,"暗黑主宰" },
        { ChongWuType.heianpurple1_q,"魇龙" },
        { ChongWuType.heianpurple1_h,"魇龙" },
        { ChongWuType.heianpurple2_q,"恶魔之龙" },
        { ChongWuType.heianpurple2_h,"恶魔之龙" },
        { ChongWuType.heianpurple3_q,"魂狼" },
        { ChongWuType.heianpurple3_h,"魂狼" },
        { ChongWuType.heianwhite1,"黑暗粘液怪" },
        { ChongWuType.heianwhite2,"黑暗史莱姆" },
        
        
        { ChongWuType.huoblue1,"熔岩仔" },
        { ChongWuType.huoblue2,"烈焰魔狐" },
        { ChongWuType.huoblue3,"炎雀儿" },
        { ChongWuType.huogreen1,"熔岩史莱姆" },
        { ChongWuType.huogreen2,"烈焰狐" },
        { ChongWuType.huoorange1_q,"火焰行者" },
        { ChongWuType.huoorange1_h,"火焰行者" },
        { ChongWuType.huopurple1_q,"葫芦猫" },
        { ChongWuType.huopurple1_h,"葫芦猫" },
        { ChongWuType.huopurple2_q,"竹炎熊猫" },
        { ChongWuType.huopurple2_h,"竹炎熊猫" },
        { ChongWuType.huopurple3_q,"焰狐仙" },
        { ChongWuType.huopurple3_h,"焰狐仙" },
        { ChongWuType.huowhite1,"火叶球" },
        
        
        { ChongWuType.iceblue1,"冰霜仔" },
        { ChongWuType.iceblue2,"霜甲兽" },
        { ChongWuType.icegreen1,"冰史莱姆" },
        { ChongWuType.icegreen2,"冰滴仔" },
        { ChongWuType.icegreen3,"小霜甲兽" },
        { ChongWuType.iceorange1_q,"霜龙皇" },
        { ChongWuType.iceorange1_h,"霜龙皇" },
        { ChongWuType.icepurple1_q,"霜翼蝶" },
        { ChongWuType.icepurple1_h,"霜翼蝶" },
        { ChongWuType.icepurple2_q,"霜角猫" },
        { ChongWuType.icepurple2_h,"霜角猫" },
        { ChongWuType.icepurple3_q,"霜华狐" },
        { ChongWuType.icepurple3_h,"霜华狐" },
        { ChongWuType.icewhite1,"冰晶粘液怪" },
    };
    

    public static int GetChongWuQualityByType(ChongWuType chongWuType)
    {
        switch (chongWuType)
        {
            case ChongWuType.icewhite1:
            case ChongWuType.huowhite1:
            case ChongWuType.dianwhite1:
            case ChongWuType.heianwhite1:
            case ChongWuType.heianwhite2:
                return 1;
            case ChongWuType.icegreen1:
            case ChongWuType.icegreen2:
            case ChongWuType.icegreen3:
            case ChongWuType.huogreen1:
            case ChongWuType.huogreen2:
            case ChongWuType.diangreen1:
            case ChongWuType.diangreen2:
            case ChongWuType.heiangreen1:
            case ChongWuType.heiangreen2:
            case ChongWuType.heiangreen3:
                return 2;

            case ChongWuType.iceblue1:
            case ChongWuType.iceblue2:
            case ChongWuType.huoblue1:
            case ChongWuType.huoblue2:
            case ChongWuType.huoblue3:
            case ChongWuType.dianblue1:
            case ChongWuType.dianblue2:
            case ChongWuType.heianblue1:
            case ChongWuType.heianblue2:
            case ChongWuType.heianblue3:
                return 3;
            
            case ChongWuType.icepurple1_q:
            case ChongWuType.icepurple2_q:
            case ChongWuType.icepurple3_q:
            case ChongWuType.huopurple1_q:
            case ChongWuType.huopurple2_q:
            case ChongWuType.huopurple3_q:
            case ChongWuType.dianpurple1_q:
            case ChongWuType.dianpurple2_q:
            case ChongWuType.dianpurple3_q:
            case ChongWuType.heianpurple1_q:
            case ChongWuType.heianpurple2_q:
            case ChongWuType.heianpurple3_q:
                
            case ChongWuType.icepurple1_h:
            case ChongWuType.icepurple2_h:
            case ChongWuType.icepurple3_h:
            case ChongWuType.huopurple1_h:
            case ChongWuType.huopurple2_h:
            case ChongWuType.huopurple3_h:
            case ChongWuType.dianpurple1_h:
            case ChongWuType.dianpurple2_h:
            case ChongWuType.dianpurple3_h:
            case ChongWuType.heianpurple1_h:
            case ChongWuType.heianpurple2_h:
            case ChongWuType.heianpurple3_h:
                return 4;
            case ChongWuType.iceorange1_q:
            case ChongWuType.iceorange1_h:
            case ChongWuType.huoorange1_q:
            case ChongWuType.huoorange1_h:
            case ChongWuType.dianorange1_q:
            case ChongWuType.dianorange1_h:
            case ChongWuType.heianorange1_q:
            case ChongWuType.heianorange1_h:
                return 5;
        }
        return 0;
    }


    public static ChongWuYuanSuType GetChongWuYuanSuByType(ChongWuType chongWuType)
    {
        switch (chongWuType)
        {
            case  ChongWuType.icepurple1_q:
            case  ChongWuType.icepurple1_h:
            case  ChongWuType.icepurple2_q:
            case  ChongWuType.icepurple2_h:
            case  ChongWuType.icepurple3_q:
            case  ChongWuType.icepurple3_h:
            case  ChongWuType.iceorange1_h:
            case  ChongWuType.iceorange1_q:
            case  ChongWuType.icewhite1:
            case  ChongWuType.icegreen1:
            case  ChongWuType.icegreen2:
            case  ChongWuType.icegreen3:
            case  ChongWuType.iceblue1:
            case  ChongWuType.iceblue2:
                return ChongWuYuanSuType.Ice;
            
            case  ChongWuType.huopurple1_q:
            case  ChongWuType.huopurple1_h:
            case  ChongWuType.huopurple2_q:
            case  ChongWuType.huopurple2_h:
            case  ChongWuType.huopurple3_q:
            case  ChongWuType.huopurple3_h:
            case  ChongWuType.huoorange1_h:
            case  ChongWuType.huoorange1_q:
            case  ChongWuType.huowhite1:
            case  ChongWuType.huogreen1:
            case  ChongWuType.huogreen2:
            case  ChongWuType.huoblue1:
            case  ChongWuType.huoblue2:
            case  ChongWuType.huoblue3:
                return ChongWuYuanSuType.Huo;
            
            case  ChongWuType.dianpurple1_q:
            case  ChongWuType.dianpurple1_h:
            case  ChongWuType.dianpurple2_q:
            case  ChongWuType.dianpurple2_h:
            case  ChongWuType.dianpurple3_q:
            case  ChongWuType.dianpurple3_h:
            case  ChongWuType.dianorange1_h:
            case  ChongWuType.dianorange1_q:
            case  ChongWuType.dianwhite1:
            case  ChongWuType.diangreen1:
            case  ChongWuType.diangreen2:
            case  ChongWuType.dianblue1:
            case  ChongWuType.dianblue2:
                return ChongWuYuanSuType.Dian;

            
            case  ChongWuType.heianpurple1_q:
            case  ChongWuType.heianpurple1_h:
            case  ChongWuType.heianpurple2_q:
            case  ChongWuType.heianpurple2_h:
            case  ChongWuType.heianpurple3_q:
            case  ChongWuType.heianpurple3_h:
            case  ChongWuType.heianorange1_h:
            case  ChongWuType.heianorange1_q:
            case  ChongWuType.heianwhite1:
            case  ChongWuType.heianwhite2:
            case  ChongWuType.heiangreen1:
            case  ChongWuType.heiangreen2:
            case  ChongWuType.heiangreen3:
            case  ChongWuType.heianblue1:
            case  ChongWuType.heianblue2:
            case  ChongWuType.heianblue3:
                return ChongWuYuanSuType.HeiAn;
        }
        return ChongWuYuanSuType.None;
    }

    public static ChongWuType GetChongWuType(int Quality)
    {
        switch (Quality)
        {
            case 1:
                int count1=ChongWuQualityDic[1].Count;
                int random1=Random.Range(0, count1);
                return ChongWuQualityDic[1][random1];
            case 2:
                int count2=ChongWuQualityDic[2].Count;
                int random2=Random.Range(0, count2);
                return ChongWuQualityDic[2][random2];
            case 3:
                int count3=ChongWuQualityDic[3].Count;
                int random3=Random.Range(0, count3);
                return ChongWuQualityDic[3][random3];
            case 4:
                int count4=ChongWuQualityDic[4].Count;
                int random4=Random.Range(0, count4);
                return ChongWuQualityDic[4][random4];
            case 5:
                int count5=ChongWuQualityDic[5].Count;
                int random5=Random.Range(0, count5);
                return ChongWuQualityDic[5][random5];
        }

        return ChongWuType.None;
    }
}
