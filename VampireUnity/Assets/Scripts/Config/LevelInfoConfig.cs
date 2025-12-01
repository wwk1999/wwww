using System.Collections;
using System.Collections.Generic;
using Equip;
using UnityEngine;

public class DiaoLuoConfig
{
    public int SuitId = 0;
    public int EquipType;
    public DiaoLuoConfig(int suitid,int equipType)
    {
        SuitId = suitid;
        EquipType = equipType;
    }
}

public enum MonsterTypeByName
{
    None,
    Snot,
    Bat,
    Spider,
    Bee,
    TreeMan,
    XiaoHuo,
    DaZui,
    DunDi,
    ChongZi,
    HuoShanBoss,
    ShiRenHua,
    XiYi,
    JiaChong,
    ShiRenBoss,
    QingWa
}
public class LevelInfoConfig 
{
    public static bool IsOneGame = true; //第一次游戏
    public static int CurrentGameLevel = 1; // 当前游戏关卡

    public static int MaxGameLevel
    {
        get=>PlayerData.S.maxGameLevel;
        set=>PlayerData.S.maxGameLevel=value;
    }
    public static LevelType CurrentGameLevelType = LevelType.Normal;
    public static List<DiaoLuoConfig> LevelDiaoLuo1 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> LevelDiaoLuo2 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> LevelDiaoLuo3 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> LevelDiaoLuo4 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> LevelDiaoLuo5 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> LevelDiaoLuo6 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> LevelDiaoLuo7 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> LevelDiaoLuo8 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> LevelDiaoLuo9 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> LevelDiaoLuo10 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> LevelDiaoLuo11 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> LevelDiaoLuo12 = new List<DiaoLuoConfig>();//关卡1掉落列表

    

    public static int[] LevelMonsterCount= new int[100];//关卡敌人数量

    public static List<MonsterTypeByName> LevelMonster1 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster2 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster3 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster4 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster5 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster6 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster7 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster8 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster9 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster10 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster11 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster12 = new List<MonsterTypeByName>();//关卡敌人列表

   
    public static void InitGameLevel()
    {
        LevelMonsterCount[0] = 0;
        LevelMonsterCount[1] = 50;
        LevelMonsterCount[2] = 100;
        LevelMonsterCount[3] = 100;
        LevelMonsterCount[4] = 50;
        LevelMonsterCount[5] = 100;
        LevelMonsterCount[6] = 100;
        LevelMonsterCount[7] = 50;
        LevelMonsterCount[8] = 100;
        LevelMonsterCount[9] = 100;
        LevelMonsterCount[10] = 50;
        LevelMonsterCount[11] = 100;
        LevelMonsterCount[12] = 100;
        LevelMonsterCount[13] = 50;
        LevelMonsterCount[14] = 100;
        LevelMonsterCount[15] = 100;
        LevelMonsterCount[16] = 50;
        LevelMonsterCount[17] = 100;
        LevelMonsterCount[18] = 100;
        LevelMonsterCount[19] = 50;
        LevelMonsterCount[20] = 100;
        LevelMonsterCount[21] = 100;
        
        
        if (IsOneGame)
        {
            LevelMonster1.Add(MonsterTypeByName.Bat);
            LevelMonster1.Add(MonsterTypeByName.Snot);
            LevelMonster1.Add(MonsterTypeByName.Spider);
        }
        
        if (IsOneGame)
        {
            LevelMonster2.Add(MonsterTypeByName.Bat);
            LevelMonster2.Add(MonsterTypeByName.Snot);
            LevelMonster2.Add(MonsterTypeByName.Spider);
        }
        
        if (IsOneGame)
        {
            LevelMonster3.Add(MonsterTypeByName.Bat);
            LevelMonster3.Add(MonsterTypeByName.Snot);
            LevelMonster3.Add(MonsterTypeByName.Spider);
            LevelMonster3.Add(MonsterTypeByName.Bee);
        }
        
        if (IsOneGame)
        {
            LevelMonster4.Add(MonsterTypeByName.Bat);
            LevelMonster4.Add(MonsterTypeByName.Snot);
            LevelMonster4.Add(MonsterTypeByName.Spider);
            LevelMonster4.Add(MonsterTypeByName.Bee);
            LevelMonster4.Add(MonsterTypeByName.TreeMan);
        }
        
        if (IsOneGame)
        {
            LevelMonster5.Add(MonsterTypeByName.XiaoHuo);
            LevelMonster5.Add(MonsterTypeByName.ChongZi);
            LevelMonster5.Add(MonsterTypeByName.DunDi);
        }
        
        if (IsOneGame)
        {
            LevelMonster6.Add(MonsterTypeByName.XiaoHuo);
            LevelMonster6.Add(MonsterTypeByName.ChongZi);
            LevelMonster6.Add(MonsterTypeByName.DunDi);
        }
        
        if (IsOneGame)
        {
            LevelMonster7.Add(MonsterTypeByName.XiaoHuo);
            LevelMonster7.Add(MonsterTypeByName.ChongZi);
            LevelMonster7.Add(MonsterTypeByName.DunDi);
            LevelMonster7.Add(MonsterTypeByName.DaZui);
        }
        
        if (IsOneGame)
        {
            LevelMonster8.Add(MonsterTypeByName.XiaoHuo);
            LevelMonster8.Add(MonsterTypeByName.ChongZi);
            LevelMonster8.Add(MonsterTypeByName.DunDi);
            LevelMonster8.Add(MonsterTypeByName.DaZui);
            LevelMonster8.Add(MonsterTypeByName.HuoShanBoss);
        }
        
        if (IsOneGame)
        {
            LevelMonster9.Add(MonsterTypeByName.JiaChong);
            LevelMonster9.Add(MonsterTypeByName.XiYi);
            LevelMonster9.Add(MonsterTypeByName.QingWa);
        }
        
        if (IsOneGame)
        {
            LevelMonster10.Add(MonsterTypeByName.JiaChong);
            LevelMonster10.Add(MonsterTypeByName.XiYi);
            LevelMonster10.Add(MonsterTypeByName.QingWa);
        }
        
        if (IsOneGame)
        {
            LevelMonster11.Add(MonsterTypeByName.JiaChong);
            LevelMonster11.Add(MonsterTypeByName.XiYi);
            LevelMonster11.Add(MonsterTypeByName.QingWa);
            LevelMonster11.Add(MonsterTypeByName.ShiRenHua);
        }
        
        if (IsOneGame)
        {
            LevelMonster12.Add(MonsterTypeByName.JiaChong);
            LevelMonster12.Add(MonsterTypeByName.XiYi);
            LevelMonster12.Add(MonsterTypeByName.QingWa);
            LevelMonster11.Add(MonsterTypeByName.ShiRenHua);
            LevelMonster11.Add(MonsterTypeByName.ShiRenBoss);
        }
        
        
        if (IsOneGame)
        {
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,1));
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,2));
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,3));
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,4));
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,5));
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,6));
        }

        if (IsOneGame)
        {
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,1));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,2));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,3));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,4));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,5));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,1));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,2));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,3));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,4));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,5));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo4.Add(new DiaoLuoConfig(1,1));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(1,2));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(1,3));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(1,4));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(1,5));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(1,6));
            
            LevelDiaoLuo4.Add(new DiaoLuoConfig(101,1));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(101,2));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(101,3));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(101,4));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(101,5));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(101,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo5.Add(new DiaoLuoConfig(1,1));
            LevelDiaoLuo5.Add(new DiaoLuoConfig(1,2));
            LevelDiaoLuo5.Add(new DiaoLuoConfig(1,3));
            LevelDiaoLuo5.Add(new DiaoLuoConfig(1,4));
            LevelDiaoLuo5.Add(new DiaoLuoConfig(1,5));
            LevelDiaoLuo5.Add(new DiaoLuoConfig(1,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo6.Add(new DiaoLuoConfig(1,1));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(1,2));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(1,3));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(1,4));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(1,5));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(1,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo7.Add(new DiaoLuoConfig(1,1));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(1,2));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(1,3));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(1,4));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(1,5));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(1,6));
            
            LevelDiaoLuo7.Add(new DiaoLuoConfig(2,1));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(2,2));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(2,3));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(2,4));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(2,5));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(2,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo8.Add(new DiaoLuoConfig(1,1));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(1,2));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(1,3));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(1,4));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(1,5));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(1,6));
            
            LevelDiaoLuo8.Add(new DiaoLuoConfig(2,1));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(2,2));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(2,3));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(2,4));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(2,5));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(2,6));
            
            LevelDiaoLuo8.Add(new DiaoLuoConfig(102,1));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(102,2));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(102,3));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(102,4));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(102,5));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(102,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo9.Add(new DiaoLuoConfig(2,1));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(2,2));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(2,3));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(2,4));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(2,5));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(2,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo10.Add(new DiaoLuoConfig(2,1));
            LevelDiaoLuo10.Add(new DiaoLuoConfig(2,2));
            LevelDiaoLuo10.Add(new DiaoLuoConfig(2,3));
            LevelDiaoLuo10.Add(new DiaoLuoConfig(2,4));
            LevelDiaoLuo10.Add(new DiaoLuoConfig(2,5));
            LevelDiaoLuo10.Add(new DiaoLuoConfig(2,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo11.Add(new DiaoLuoConfig(2,1));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(2,2));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(2,3));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(2,4));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(2,5));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(2,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo12.Add(new DiaoLuoConfig(2,1));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(2,2));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(2,3));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(2,4));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(2,5));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(2,6));
            
            LevelDiaoLuo12.Add(new DiaoLuoConfig(103,1));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(103,2));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(103,3));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(103,4));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(103,5));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(103,6));
        }
    }
   public static LevelInfoItem LevelInfoItem1= new LevelInfoItem
   {
       Level = 1,
       LevelType = LevelType.Normal,
       MonsterIconList = new List<Sprite>(),
       DiaoLuoIconList = new List<Sprite>(),
       DiaoLuoNameList = new List<string>()
   };
    public static LevelInfoItem LevelInfoItem2 = new LevelInfoItem
    {
         Level = 2,
         LevelType = LevelType.Elite,
         MonsterIconList = new List<Sprite>(),
         DiaoLuoIconList = new List<Sprite>(),
            DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem3 = new LevelInfoItem
    {
         Level = 3,
         LevelType = LevelType.Boss,
         MonsterIconList = new List<Sprite>(),
         DiaoLuoIconList = new List<Sprite>(),
            DiaoLuoNameList = new List<string>()
    };

    public static LevelInfoItem LevelInfoItem4= new LevelInfoItem
    {
        Level = 4,
        LevelType = LevelType.Normal,
        MonsterIconList = new List<Sprite>(),
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem5= new LevelInfoItem
    {
        Level = 5,
        LevelType = LevelType.Elite,
        MonsterIconList = new List<Sprite>(),
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem6= new LevelInfoItem
    {
        Level = 6,
        LevelType = LevelType.Boss,
        MonsterIconList = new List<Sprite>(),
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem7= new LevelInfoItem
    {
        Level = 7,
        LevelType = LevelType.Normal,
        MonsterIconList = new List<Sprite>(),
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem8= new LevelInfoItem
    {
        Level = 8,
        LevelType = LevelType.Elite,
        MonsterIconList = new List<Sprite>(),
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem9= new LevelInfoItem
    {
        Level = 9,
        LevelType = LevelType.Boss,
        MonsterIconList = new List<Sprite>(),
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static void init()
    {
        //关卡1
        if (IsOneGame)
        {
            LevelInfoItem1.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem1.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem1.MonsterIconList.Add(ResourcesConfig.Spidericon);

            LevelInfoItem1.DiaoLuoIconList.Add(ResourcesConfig.PrimaryCloak);
            LevelInfoItem1.DiaoLuoIconList.Add(ResourcesConfig.PrimaryCloth);
            LevelInfoItem1.DiaoLuoIconList.Add(ResourcesConfig.PrimaryShoe);
            LevelInfoItem1.DiaoLuoIconList.Add(ResourcesConfig.PrimaryHelmet);
            LevelInfoItem1.DiaoLuoIconList.Add(ResourcesConfig.PrimaryNecklace);
            LevelInfoItem1.DiaoLuoIconList.Add(ResourcesConfig.PrimaryRing);

            LevelInfoItem1.DiaoLuoNameList.Add("新手披风");
            LevelInfoItem1.DiaoLuoNameList.Add("新手衣服");
            LevelInfoItem1.DiaoLuoNameList.Add("新手鞋子");
            LevelInfoItem1.DiaoLuoNameList.Add("新手头盔");
            LevelInfoItem1.DiaoLuoNameList.Add("新手项链");
            LevelInfoItem1.DiaoLuoNameList.Add("新手戒指");

            LevelInfoItem1.LevelInfoDir = true;
            LevelInfoItem1.LevelInfoPos = new Vector2(374, -407);
            LevelInfoItem1.LoopScrollPos = new Vector2(-334, -34);

            //关卡2
            LevelInfoItem2.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem2.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem2.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem2.MonsterIconList.Add(ResourcesConfig.EliteBeeIcon);

            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.PrimaryCloak);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.PrimaryCloth);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.PrimaryShoe);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.PrimaryHelmet);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.PrimaryNecklace);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.PrimaryRing);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.WhiteDivision);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.WhiteExplosion);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.WhiteDuration);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.WhiteScale);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.WhitePenetrate);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.WhiteExtremeSpeed);

            LevelInfoItem2.DiaoLuoNameList.Add("新手披风");
            LevelInfoItem2.DiaoLuoNameList.Add("新手衣服");
            LevelInfoItem2.DiaoLuoNameList.Add("新手鞋子");
            LevelInfoItem2.DiaoLuoNameList.Add("新手头盔");
            LevelInfoItem2.DiaoLuoNameList.Add("新手项链");
            LevelInfoItem2.DiaoLuoNameList.Add("新手戒指");
            LevelInfoItem2.DiaoLuoNameList.Add("初级源石：分裂");
            LevelInfoItem2.DiaoLuoNameList.Add("初级源石：爆炸");
            LevelInfoItem2.DiaoLuoNameList.Add("初级源石：持续");
            LevelInfoItem2.DiaoLuoNameList.Add("初级源石：缩放");
            LevelInfoItem2.DiaoLuoNameList.Add("初级源石：穿透");
            LevelInfoItem2.DiaoLuoNameList.Add("初级源石：极速");

            LevelInfoItem2.LevelInfoDir = true;
            LevelInfoItem2.LevelInfoPos = new Vector2(374, -200);
            LevelInfoItem2.LoopScrollPos = new Vector2(-335, 169);

            //关卡3
            LevelInfoItem3.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem3.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem3.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem3.MonsterIconList.Add(ResourcesConfig.EliteBeeIcon);
            LevelInfoItem3.MonsterIconList.Add(ResourcesConfig.BossTreeManIcon);
            
            
            
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.WhiteDivision);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.WhiteExplosion);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.WhiteDuration);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.WhiteScale);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.WhitePenetrate);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.WhiteExtremeSpeed);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.PrimaryCloak);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.PrimaryCloth);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.PrimaryShoe);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.PrimaryHelmet);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.PrimaryNecklace);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.PrimaryRing);
          
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.TreeManCloak);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.TreeManCloth);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.TreeManShoe);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.TreeManHelmet);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.TreeManNecklace);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.TreeManRing);

            LevelInfoItem3.DiaoLuoNameList.Add("新手披风");
            LevelInfoItem3.DiaoLuoNameList.Add("新手衣服");
            LevelInfoItem3.DiaoLuoNameList.Add("新手鞋子");
            LevelInfoItem3.DiaoLuoNameList.Add("新手头盔");
            LevelInfoItem3.DiaoLuoNameList.Add("新手项链");
            LevelInfoItem3.DiaoLuoNameList.Add("新手戒指");
            LevelInfoItem3.DiaoLuoNameList.Add("初级源石：分裂");
            LevelInfoItem3.DiaoLuoNameList.Add("初级源石：爆炸");
            LevelInfoItem3.DiaoLuoNameList.Add("初级源石：持续");
            LevelInfoItem3.DiaoLuoNameList.Add("初级源石：缩放");
            LevelInfoItem3.DiaoLuoNameList.Add("初级源石：穿透");
            LevelInfoItem3.DiaoLuoNameList.Add("初级源石：极速");
            LevelInfoItem3.DiaoLuoNameList.Add("树人披风");
            LevelInfoItem3.DiaoLuoNameList.Add("树人衣服");
            LevelInfoItem3.DiaoLuoNameList.Add("树人鞋子");
            LevelInfoItem3.DiaoLuoNameList.Add("树人头盔");
            LevelInfoItem3.DiaoLuoNameList.Add("树人项链");
            LevelInfoItem3.DiaoLuoNameList.Add("树人戒指");

            LevelInfoItem3.LevelInfoDir = false;
            LevelInfoItem3.LevelInfoPos = new Vector2(-22, -3);
            LevelInfoItem3.LoopScrollPos = new Vector2(-597, 364);

            //关卡4
            LevelInfoItem4.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem4.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem4.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem4.LevelInfoDir = false;
            LevelInfoItem4.LevelInfoPos = new Vector2(441, -73);
            
            
            //关卡5
            LevelInfoItem5.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem5.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem5.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem5.MonsterIconList.Add(ResourcesConfig.EliteBeeIcon);
            LevelInfoItem5.LevelInfoDir = true;
            LevelInfoItem5.LevelInfoPos = new Vector2(1220, -161);
            
            //关卡6
            LevelInfoItem6.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem6.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem6.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem6.MonsterIconList.Add(ResourcesConfig.EliteBeeIcon);
            LevelInfoItem6.MonsterIconList.Add(ResourcesConfig.BossTreeManIcon);
            LevelInfoItem6.LevelInfoDir = true;
            LevelInfoItem6.LevelInfoPos = new Vector2(715, -400);
            
            
            //关卡7
            LevelInfoItem7.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem7.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem7.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem7.LevelInfoDir = false;
            LevelInfoItem7.LevelInfoPos = new Vector2(468, -365);
            
            
            //关卡8
            LevelInfoItem8.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem8.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem8.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem8.MonsterIconList.Add(ResourcesConfig.EliteBeeIcon);
            LevelInfoItem8.LevelInfoDir = false;
            LevelInfoItem8.LevelInfoPos = new Vector2(618, -547);
            
            //关卡9
            LevelInfoItem9.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem9.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem9.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem9.MonsterIconList.Add(ResourcesConfig.EliteBeeIcon);
            LevelInfoItem9.MonsterIconList.Add(ResourcesConfig.BossTreeManIcon);
            LevelInfoItem9.LevelInfoDir = false;
            LevelInfoItem9.LevelInfoPos = new Vector2(886, -501);
        }
    }
}
