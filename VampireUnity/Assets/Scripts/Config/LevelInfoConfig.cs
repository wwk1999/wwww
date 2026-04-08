using System.Collections;
using System.Collections.Generic;
using Equip;
using UnityEngine;

public class DiaoLuoConfig
{
    public int SuitId = 0;
    public int EquipType;
    public int PropId;
    public int OrangeId=0;

    public DiaoLuoConfig(int suitid,int equipType,int prop=0,int  orangeid=0)
    {
        SuitId = suitid;
        EquipType = equipType;
        PropId = prop;
        OrangeId=orangeid;
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
    JiaChong,
    WenZi,
    ZhaoZeBoss,
    ShaChong,
    ShaNiao,
    ShaXiYi,
    XianRenZhang,
    XieZi,
    XueRen,
    XueZhangLang,
    XueQiE,
    YingShu,
    XueRenBoss,
    ShiRenBoss,
    QingWa,
    // 小怪
    ChaiLangRen1,
    ChaiLangRen2,
    ChaiLangRen3,
    ChaiLangRen4,
    CiZhu,
    DaoCaoRen,
    DiJing2,
    DiJing3,
    DiJingShouWei1,
    DiJingShouWei2,
    DiJingShouWei3,
    HeiXiong,
    JianChiZhu,
    KuLou1,
    KuLou2,
    KuLou3,
    KuLou4,
    KuLou5,
    KuLou6,
    LuJiaoCiKe1,
    LuJiaoCiKe2,
    NiuTouRen1,
    NiuTouRen2,
    NiuTouRen3,
    ShanZei3,
    ShiJiaChong,
    ShiShiGui,
    ShiXiangGui,
    ShouRen1,
    ShouRen2,
    ShouRen3,
    ShuangTouLong1,
    ShuangTouLong2,
    ShuangTouLong3,
    TuJiu,
    WuYa,
    YouHunLingZhu,
    YouLang,
    YouLing1,
    YouLing2,
    YuRen1,
    YuRen2,
    YuRen3,
    //精英怪
    DaZongXiong,        // 大棕熊
    DiJingZhangLao,     // 地精长老
    FengHeGuai,         // 风和怪
    KuangShiMuZhu,      // 狂食母蛛
    LuJiaoDouShi,       // 鹿角斗士
    RongYanGuai,        // 熔岩怪
    ShiFuBoss,          // 师傅BOSS
    ShuangTouRen,       // 双头人
    WuYaoZhiWang,       // 巫妖之王
    WuYaoZhiWang2,      // 巫妖之王2
    YeShouZhanShi,      // 野兽战士
    ZhiZhuNvWang,       // 蜘蛛女王
}
public class BaoShiDiaoLuo
{
    public int Quality;
    public int count;
}

public class ChongWuDiaoLuoItem
{
    public PropConfig.PropType type;
    public int Quality;
}
public class LevelInfoConfig
{

    public static Dictionary<int, List<ChongWuDiaoLuoItem>> ChongWuDiaoLuoDic = new Dictionary<int, List<ChongWuDiaoLuoItem>>()
    {
        {1,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 1}}},
        {2,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 2}}},
        {3,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 3}}},
        {4,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 4},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 4}}},
        {5,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 4},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 4},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 5,},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 5},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 5}}},
        {6,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 4},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 4},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 5,},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 5},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 5},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 6},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 6}}},

    };

   public static MonsterBase GetMonster(MonsterTypeByName type)
{
    switch (type)
    {
        case MonsterTypeByName.None:
            return null;
        case MonsterTypeByName.Snot:
            return GameController.S.SnotMonsterQueue.Dequeue();
        case MonsterTypeByName.Bat:
            return GameController.S.BatMonsterQueue.Dequeue();
        case MonsterTypeByName.Spider:
            return GameController.S.SpiderMonsterQueue.Dequeue();
        case MonsterTypeByName.Bee:
            return GameController.S.EliteBeeMonsterQueue.Dequeue();
        case MonsterTypeByName.XiaoHuo:
            return GameController.S.XiaoHuoMonsterQueue.Dequeue();
        case MonsterTypeByName.DaZui:
            return GameController.S.EliteDaZuiMonsterQueue.Dequeue();
        case MonsterTypeByName.DunDi:
            return GameController.S.DunDiMonsterQueue.Dequeue();
        case MonsterTypeByName.ChongZi:
            return GameController.S.ChongZiMonsterQueue.Dequeue();
  
        case MonsterTypeByName.ShiRenHua:
            return GameController.S.ShiRenHuaMonsterQueue.Dequeue();
        case MonsterTypeByName.JiaChong:
            return GameController.S.JiaChongMonsterQueue.Dequeue();
        case MonsterTypeByName.WenZi:
            return GameController.S.WenZiMonsterQueue.Dequeue();
   
        case MonsterTypeByName.ShaChong:
            return GameController.S.ShaChongQueue.Dequeue();
        case MonsterTypeByName.ShaNiao:
            return GameController.S.ShaNiaoQueue.Dequeue();
        case MonsterTypeByName.ShaXiYi:
            return GameController.S.ShaXiYiQueue.Dequeue();
        case MonsterTypeByName.XianRenZhang:
            return GameController.S.XianRenZhangQueue.Dequeue();
        
        case MonsterTypeByName.XueRen:
            return GameController.S.XueRenQueue.Dequeue();
        case MonsterTypeByName.XueZhangLang:
            return GameController.S.XueZhangLangQueue.Dequeue();
        case MonsterTypeByName.XueQiE:
            return GameController.S.XueQiEQueue.Dequeue();
        case MonsterTypeByName.YingShu:
            return GameController.S.YingShuQueue.Dequeue();
        
       
        case MonsterTypeByName.QingWa:
            return GameController.S.QingWaMonsterQueue.Dequeue();
        // 小怪
        case MonsterTypeByName.ChaiLangRen1:
            return GameController.S.chailangren1Queue.Dequeue();
        case MonsterTypeByName.ChaiLangRen2:
            return GameController.S.chailangren2Queue.Dequeue();
        case MonsterTypeByName.ChaiLangRen3:
            return GameController.S.chailangren3Queue.Dequeue();
        case MonsterTypeByName.ChaiLangRen4:
            return GameController.S.chailangren4Queue.Dequeue();
        case MonsterTypeByName.CiZhu:
            return GameController.S.cizhuQueue.Dequeue();
        case MonsterTypeByName.DaoCaoRen:
            return GameController.S.daocaorenQueue.Dequeue();
        case MonsterTypeByName.DiJing2:
            return GameController.S.dijing2Queue.Dequeue();
        case MonsterTypeByName.DiJing3:
            return GameController.S.dijing3Queue.Dequeue();
        case MonsterTypeByName.DiJingShouWei1:
            return GameController.S.dijingshouwei1Queue.Dequeue();
        case MonsterTypeByName.DiJingShouWei2:
            return GameController.S.dijingshouwei2Queue.Dequeue();
        case MonsterTypeByName.DiJingShouWei3:
            return GameController.S.dijingshouwei3Queue.Dequeue();
        case MonsterTypeByName.HeiXiong:
            return GameController.S.heixiongQueue.Dequeue();
        case MonsterTypeByName.JianChiZhu:
            return GameController.S.jianchizhuQueue.Dequeue();
        case MonsterTypeByName.KuLou1:
            return GameController.S.kulou1Queue.Dequeue();
        case MonsterTypeByName.KuLou2:
            return GameController.S.kulou2Queue.Dequeue();
        case MonsterTypeByName.KuLou3:
            return GameController.S.kulou3Queue.Dequeue();
        case MonsterTypeByName.KuLou4:
            return GameController.S.kulou4Queue.Dequeue();
        case MonsterTypeByName.KuLou5:
            return GameController.S.kulou5Queue.Dequeue();
        case MonsterTypeByName.KuLou6:
            return GameController.S.kulou6Queue.Dequeue();
        case MonsterTypeByName.LuJiaoCiKe1:
            return GameController.S.lujiaocikeQueue.Dequeue();
        case MonsterTypeByName.LuJiaoCiKe2:
            return GameController.S.lujiaocike2Queue.Dequeue();
        case MonsterTypeByName.NiuTouRen1:
            return GameController.S.niutouren1Queue.Dequeue();
        case MonsterTypeByName.NiuTouRen2:
            return GameController.S.niutouren2Queue.Dequeue();
        case MonsterTypeByName.NiuTouRen3:
            return GameController.S.niutouren3Queue.Dequeue();
        case MonsterTypeByName.ShanZei3:
            return GameController.S.shanzei3Queue.Dequeue();
        case MonsterTypeByName.ShiJiaChong:
            return GameController.S.shijiachongQueue.Dequeue();
        case MonsterTypeByName.ShiShiGui:
            return GameController.S.shishiguiQueue.Dequeue();
        case MonsterTypeByName.ShiXiangGui:
            return GameController.S.shixiangguiQueue.Dequeue();
        case MonsterTypeByName.ShouRen1:
            return GameController.S.shouren1Queue.Dequeue();
        case MonsterTypeByName.ShouRen2:
            return GameController.S.shouren2Queue.Dequeue();
        case MonsterTypeByName.ShouRen3:
            return GameController.S.shouren3Queue.Dequeue();
        case MonsterTypeByName.ShuangTouLong1:
            return GameController.S.shuangtoulongQueue.Dequeue();
        case MonsterTypeByName.ShuangTouLong2:
            return GameController.S.shuangtoulong2Queue.Dequeue();
        case MonsterTypeByName.ShuangTouLong3:
            return GameController.S.shuangtoulong3Queue.Dequeue();
        case MonsterTypeByName.TuJiu:
            return GameController.S.tujiuQueue.Dequeue();
        case MonsterTypeByName.WuYa:
            return GameController.S.wuyaQueue.Dequeue();
        case MonsterTypeByName.YouHunLingZhu:
            return GameController.S.youhunlingzhuQueue.Dequeue();
        case MonsterTypeByName.YouLang:
            return GameController.S.youlangQueue.Dequeue();
        case MonsterTypeByName.YouLing1:
            return GameController.S.youlingQueue.Dequeue();
        case MonsterTypeByName.YouLing2:
            return GameController.S.youling2Queue.Dequeue();
        case MonsterTypeByName.YuRen1:
            return GameController.S.yuren1Queue.Dequeue();
        case MonsterTypeByName.YuRen2:
            return GameController.S.yuren2Queue.Dequeue();
        case MonsterTypeByName.YuRen3:
            return GameController.S.yuren3Queue.Dequeue();
        // 精英怪
        case MonsterTypeByName.DaZongXiong:
            return GameController.S.dazongxiongQueue.Dequeue();
        case MonsterTypeByName.DiJingZhangLao:
            return GameController.S.DijingzhanglaoQueue.Dequeue();
        case MonsterTypeByName.FengHeGuai:
            return GameController.S.fengheguaiQueue.Dequeue();
        case MonsterTypeByName.KuangShiMuZhu:
            return GameController.S.kuangshimuzhuQueue.Dequeue();
        case MonsterTypeByName.LuJiaoDouShi:
            return GameController.S.lujiaodoushiQueue.Dequeue();
        case MonsterTypeByName.RongYanGuai:
            return GameController.S.rongyanguaiQueue.Dequeue();
        case MonsterTypeByName.ShiFuBoss:
            return GameController.S.shifubossQueue.Dequeue();
        case MonsterTypeByName.ShuangTouRen:
            return GameController.S.shuangtourenQueue.Dequeue();
        case MonsterTypeByName.WuYaoZhiWang:
            return GameController.S.wuyaozhiwangQueue.Dequeue();
        case MonsterTypeByName.WuYaoZhiWang2:
            return GameController.S.wuyaozhiwang2Queue.Dequeue();
        case MonsterTypeByName.YeShouZhanShi:
            return GameController.S.YeShouZhanShiQueue.Dequeue();
        case MonsterTypeByName.ZhiZhuNvWang:
            return GameController.S.ZhiZhuNvWangQueue.Dequeue();
        default:
            return null;
    }
}
    public static void FaBaoShi()
    {
        BaoShiDiaoLuo baoShiDiaoLuo = null;
        switch (CurrentGameLevel)
        {
            case 3:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[3];
                break;
            case 6:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[6];
                break;
            case 9:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[9];
                break;
            case 12:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[12];
                break;
            case 15:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[15];
                break;
            
            case 16:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[16];
                break;
            case 17:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[17];
                break;
            case 18:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[18];
                break;
            case 19:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[19];
                break;
            case 20:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[20];
                break;
            case 21:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[21];
                break;
            case 22:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[22];
                break;
            case 23:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[23];
                break;
            case 24:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[24];
                break;
            case 25:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[25];
                break;
            case 26:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[26];
                break;
            case 27:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[27];
                break;
            case 28:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[28];
                break;
            case 29:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[29];
                break;
            case 30:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[30];
                break;
            case 31:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[31];
                break;
            case 32:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[32];
                break;
            case 33:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[33];
                break;
            case 34:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[34];
                break;
            case 35:
                baoShiDiaoLuo = BaoShiDiaoLuoDic[35];
                break;
        }

        for (int i = 0; i < baoShiDiaoLuo.count; i++)
        {
            int random = Random.Range(1, 11);
            int code = (random + 5) * 100 + baoShiDiaoLuo.Quality;
            BagController.S.DebugTool1(code, "");
        }
        
        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已获取通关奖励");
    }
    
    
    public static Dictionary<int, BaoShiDiaoLuo> BaoShiDiaoLuoDic = new Dictionary<int, BaoShiDiaoLuo>()
    {
        {3,new BaoShiDiaoLuo(){Quality = 1,count = 3}},
        {6,new BaoShiDiaoLuo(){Quality = 1,count = 5}},
        {9,new BaoShiDiaoLuo(){Quality = 1,count = 10}},
        {12,new BaoShiDiaoLuo(){Quality = 2,count = 5}},
        {15,new BaoShiDiaoLuo(){Quality = 2,count = 10}},
        
        {16,new BaoShiDiaoLuo(){Quality = 3,count = 5}},
        {17,new BaoShiDiaoLuo(){Quality = 3,count = 7}},
        {18,new BaoShiDiaoLuo(){Quality = 3,count = 9}},
        
        {19,new BaoShiDiaoLuo(){Quality = 3,count = 12}},
        {20,new BaoShiDiaoLuo(){Quality = 3,count = 15}},
        {21,new BaoShiDiaoLuo(){Quality = 4,count = 5}},
        {22,new BaoShiDiaoLuo(){Quality = 4,count = 7}},
        {23,new BaoShiDiaoLuo(){Quality = 4,count = 9}},
        {24,new BaoShiDiaoLuo(){Quality = 4,count = 12}},
        {25,new BaoShiDiaoLuo(){Quality = 4,count = 15}},

        {26,new BaoShiDiaoLuo(){Quality = 5,count = 4}},
        {27,new BaoShiDiaoLuo(){Quality = 5,count = 6}},
        {28,new BaoShiDiaoLuo(){Quality = 5,count = 8}},
        {29,new BaoShiDiaoLuo(){Quality = 5,count = 10}},
        {30,new BaoShiDiaoLuo(){Quality = 5,count = 12}},
        {31,new BaoShiDiaoLuo(){Quality = 5,count = 15}},
        {32,new BaoShiDiaoLuo(){Quality = 6,count =3}},
        {33,new BaoShiDiaoLuo(){Quality = 6,count = 5}},
        {34,new BaoShiDiaoLuo(){Quality = 6,count = 7}},
        {35,new BaoShiDiaoLuo(){Quality = 6,count = 10}},


    };
    
    
    
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
    public static List<DiaoLuoConfig> LevelDiaoLuo13 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> LevelDiaoLuo14 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> LevelDiaoLuo15 = new List<DiaoLuoConfig>();//关卡1掉落列表
    public static List<DiaoLuoConfig> MJDiaoLuo = new List<DiaoLuoConfig>();//关卡1掉落列表


    
    

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
    public static List<MonsterTypeByName> LevelMonster13 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster14 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster15 = new List<MonsterTypeByName>();//关卡敌人列表

    public static List<MonsterTypeByName> LevelMonster101 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster102 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster103 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster104 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster105 = new List<MonsterTypeByName>();//关卡敌人列表
    public static List<MonsterTypeByName> LevelMonster106 = new List<MonsterTypeByName>();//关卡敌人列表

   
    public static void InitGameLevel()
    {
        LevelMonsterCount[0] = 0;
        LevelMonsterCount[1] = 20;
        LevelMonsterCount[2] = 30;
        LevelMonsterCount[3] = 50;
        LevelMonsterCount[4] = 50;
        LevelMonsterCount[5] = 60;
        LevelMonsterCount[6] = 70;
        LevelMonsterCount[7] = 70;
        LevelMonsterCount[8] = 80;
        LevelMonsterCount[9] = 90;
        LevelMonsterCount[10] = 90;
        LevelMonsterCount[11] = 100;
        LevelMonsterCount[12] = 100;
        LevelMonsterCount[13] = 100;
        LevelMonsterCount[14] = 100;
        LevelMonsterCount[15] = 100;
        LevelMonsterCount[16] = 110;
        LevelMonsterCount[17] = 120;
        LevelMonsterCount[18] = 130;
        LevelMonsterCount[19] = 140;
        LevelMonsterCount[20] = 2;
        LevelMonsterCount[21] = 160;
        
        LevelMonsterCount[22] = 170;
        LevelMonsterCount[23] = 180;
        LevelMonsterCount[24] = 190;
        LevelMonsterCount[25] = 200;
        LevelMonsterCount[26] = 210;
        LevelMonsterCount[27] = 220;
        LevelMonsterCount[28] = 230;
        LevelMonsterCount[29] = 240;
        LevelMonsterCount[30] = 250;
        LevelMonsterCount[31] = 260;
        LevelMonsterCount[32] = 270;
        LevelMonsterCount[33] = 280;
        LevelMonsterCount[34] = 290;
        LevelMonsterCount[35] = 300;
        LevelMonsterCount[36] = 300;
        LevelMonsterCount[37] = 300;
        LevelMonsterCount[38] = 300;
        LevelMonsterCount[39] = 300;
        LevelMonsterCount[40] = 300;
        LevelMonsterCount[41] = 300;
        LevelMonsterCount[42] = 300;
        LevelMonsterCount[43] = 300;
        LevelMonsterCount[44] = 300;
        LevelMonsterCount[45] = 300;
        LevelMonsterCount[46] = 300;
        
        LevelMonsterCount[101] = 100;
        LevelMonsterCount[102] = 120;
        LevelMonsterCount[103] = 140;
        LevelMonsterCount[104] = 180;
        LevelMonsterCount[105] = 250;
        LevelMonsterCount[106] = 300;

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
            LevelMonster2.Add(MonsterTypeByName.Bee);
        }
        
        if (IsOneGame)
        {
            LevelMonster3.Add(MonsterTypeByName.Bat);
            LevelMonster3.Add(MonsterTypeByName.Snot);
            LevelMonster3.Add(MonsterTypeByName.Spider);
            LevelMonster3.Add(MonsterTypeByName.Bee);
            LevelMonster3.Add(MonsterTypeByName.TreeMan);

        }
        
        if (IsOneGame)
        {
            LevelMonster4.Add(MonsterTypeByName.XiaoHuo);
            LevelMonster4.Add(MonsterTypeByName.ChongZi);
            LevelMonster4.Add(MonsterTypeByName.DunDi);
        }
        
        if (IsOneGame)
        {
            LevelMonster5.Add(MonsterTypeByName.XiaoHuo);
            LevelMonster5.Add(MonsterTypeByName.ChongZi);
            LevelMonster5.Add(MonsterTypeByName.DunDi);
            LevelMonster5.Add(MonsterTypeByName.DaZui);

        }
        
        if (IsOneGame)
        {
            LevelMonster6.Add(MonsterTypeByName.XiaoHuo);
            LevelMonster6.Add(MonsterTypeByName.ChongZi);
            LevelMonster6.Add(MonsterTypeByName.DunDi);
            LevelMonster6.Add(MonsterTypeByName.DaZui);
            LevelMonster6.Add(MonsterTypeByName.HuoShanBoss);
        }
        
        if (IsOneGame)
        {
            LevelMonster7.Add(MonsterTypeByName.JiaChong);
            LevelMonster7.Add(MonsterTypeByName.QingWa);
            LevelMonster7.Add(MonsterTypeByName.WenZi);
        }
        
        if (IsOneGame)
        {
            LevelMonster8.Add(MonsterTypeByName.JiaChong);
            LevelMonster8.Add(MonsterTypeByName.QingWa);
            LevelMonster8.Add(MonsterTypeByName.WenZi);
            LevelMonster8.Add(MonsterTypeByName.ShiRenHua);
        }
        
        if (IsOneGame)
        {
            LevelMonster9.Add(MonsterTypeByName.JiaChong);
            LevelMonster9.Add(MonsterTypeByName.QingWa);
            LevelMonster9.Add(MonsterTypeByName.WenZi);
            LevelMonster9.Add(MonsterTypeByName.ShiRenHua);
            LevelMonster9.Add(MonsterTypeByName.ZhaoZeBoss);
        }
        
        if (IsOneGame)
        {
            LevelMonster10.Add(MonsterTypeByName.ShaChong);
            LevelMonster10.Add(MonsterTypeByName.XianRenZhang);
            LevelMonster10.Add(MonsterTypeByName.ShaNiao);
        }
        
        if (IsOneGame)
        {
            LevelMonster11.Add(MonsterTypeByName.ShaChong);
            LevelMonster11.Add(MonsterTypeByName.ShaNiao);
            LevelMonster11.Add(MonsterTypeByName.XianRenZhang);
            LevelMonster11.Add(MonsterTypeByName.ShaXiYi);
        }
        
        if (IsOneGame)
        {
            LevelMonster12.Add(MonsterTypeByName.ShaChong);
            LevelMonster12.Add(MonsterTypeByName.ShaNiao);
            LevelMonster12.Add(MonsterTypeByName.XianRenZhang);
            LevelMonster12.Add(MonsterTypeByName.ShaXiYi);
            LevelMonster12.Add(MonsterTypeByName.XieZi);
        }
        
        if (IsOneGame)
        {
            LevelMonster13.Add(MonsterTypeByName.XueQiE);
            LevelMonster13.Add(MonsterTypeByName.XueZhangLang);
            LevelMonster13.Add(MonsterTypeByName.XueRen);
        }
        
        if (IsOneGame)
        {
            LevelMonster14.Add(MonsterTypeByName.XueQiE);
            LevelMonster14.Add(MonsterTypeByName.XueZhangLang);
            LevelMonster14.Add(MonsterTypeByName.XueRen);
            LevelMonster14.Add(MonsterTypeByName.YingShu);
        }
        
        if (IsOneGame)
        {
            LevelMonster15.Add(MonsterTypeByName.XueQiE);
            LevelMonster15.Add(MonsterTypeByName.XueZhangLang);
            LevelMonster15.Add(MonsterTypeByName.XueRen);
            LevelMonster15.Add(MonsterTypeByName.YingShu);
            LevelMonster15.Add(MonsterTypeByName.XueRenBoss);
        }
        
        if (IsOneGame)
        {
            LevelMonster101.Add(MonsterTypeByName.ChaiLangRen1);
            LevelMonster101.Add(MonsterTypeByName.ChaiLangRen2);
            LevelMonster101.Add(MonsterTypeByName.DaZongXiong);

        }
        
        if (IsOneGame)
        {
            LevelMonster102.Add(MonsterTypeByName.ChaiLangRen3);
            LevelMonster102.Add(MonsterTypeByName.ChaiLangRen4);
            LevelMonster102.Add(MonsterTypeByName.FengHeGuai);

        }
        
        if (IsOneGame)
        {
            LevelMonster103.Add(MonsterTypeByName.CiZhu);
            LevelMonster103.Add(MonsterTypeByName.DaoCaoRen);
            LevelMonster103.Add(MonsterTypeByName.KuangShiMuZhu);
        }
        
        if (IsOneGame)
        {
            LevelMonster104.Add(MonsterTypeByName.DiJing2);
            LevelMonster104.Add(MonsterTypeByName.DiJing3);
            LevelMonster104.Add(MonsterTypeByName.DiJingZhangLao);
        }
        
        if (IsOneGame)
        {
            LevelMonster105.Add(MonsterTypeByName.TuJiu);
            LevelMonster105.Add(MonsterTypeByName.WuYa);
            LevelMonster105.Add(MonsterTypeByName.LuJiaoDouShi);
        }
        
        if (IsOneGame)
        {
            LevelMonster106.Add(MonsterTypeByName.HeiXiong);
            LevelMonster106.Add(MonsterTypeByName.JianChiZhu);
            LevelMonster106.Add(MonsterTypeByName.RongYanGuai);
        }
        
        
        if (IsOneGame)
        {
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,1));
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,2));
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,3));
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,4));
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,5));
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,6));
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,6,prop:101));
            LevelDiaoLuo1.Add(new DiaoLuoConfig(1,6,prop:201));

        }

        if (IsOneGame)
        {
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,1));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,2));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,3));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,4));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,5));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,6));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,6,prop:101));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,6,prop:201));
            
            LevelDiaoLuo2.Add(new DiaoLuoConfig(2,1));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(2,2));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(2,3));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(2,4));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(2,5));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(2,6));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,6,prop:102));
            LevelDiaoLuo2.Add(new DiaoLuoConfig(1,6,prop:202));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,1));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,2));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,3));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,4));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,5));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,6));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,6,prop:101));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,6,prop:401));
            
            LevelDiaoLuo3.Add(new DiaoLuoConfig(2,1));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(2,2));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(2,3));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(2,4));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(2,5));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(2,6));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,6,prop:102));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(1,6,prop:402));
            
            LevelDiaoLuo3.Add(new DiaoLuoConfig(101,1));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(101,2));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(101,3));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(101,4));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(101,5));
            LevelDiaoLuo3.Add(new DiaoLuoConfig(101,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo4.Add(new DiaoLuoConfig(1,6,prop:101));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(1,6,prop:201));
            
            LevelDiaoLuo4.Add(new DiaoLuoConfig(2,1));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(2,2));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(2,3));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(2,4));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(2,5));
            LevelDiaoLuo4.Add(new DiaoLuoConfig(2,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo5.Add(new DiaoLuoConfig(1,6,prop:101));
            LevelDiaoLuo5.Add(new DiaoLuoConfig(1,6,prop:201));
            
            LevelDiaoLuo5.Add(new DiaoLuoConfig(2,1));
            LevelDiaoLuo5.Add(new DiaoLuoConfig(2,2));
            LevelDiaoLuo5.Add(new DiaoLuoConfig(2,3));
            LevelDiaoLuo5.Add(new DiaoLuoConfig(2,4));
            LevelDiaoLuo5.Add(new DiaoLuoConfig(2,5));
            LevelDiaoLuo5.Add(new DiaoLuoConfig(2,6));
            
            LevelDiaoLuo5.Add(new DiaoLuoConfig(1,6,prop:102));
            LevelDiaoLuo5.Add(new DiaoLuoConfig(1,6,prop:202));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo6.Add(new DiaoLuoConfig(1,6,prop:101));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(1,6,prop:401));
            
            LevelDiaoLuo6.Add(new DiaoLuoConfig(2,1));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(2,2));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(2,3));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(2,4));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(2,5));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(2,6));
            
            LevelDiaoLuo6.Add(new DiaoLuoConfig(1,6,prop:102));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(1,6,prop:402));
            
            LevelDiaoLuo6.Add(new DiaoLuoConfig(102,1));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(102,2));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(102,3));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(102,4));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(102,5));
            LevelDiaoLuo6.Add(new DiaoLuoConfig(102,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo7.Add(new DiaoLuoConfig(1,6,prop:102));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(1,6,prop:202));
            
            LevelDiaoLuo7.Add(new DiaoLuoConfig(3,1));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(3,2));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(3,3));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(3,4));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(3,5));
            LevelDiaoLuo7.Add(new DiaoLuoConfig(3,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo8.Add(new DiaoLuoConfig(1,6,prop:102));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(1,6,prop:202));
            
            LevelDiaoLuo8.Add(new DiaoLuoConfig(3,1));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(3,2));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(3,3));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(3,4));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(3,5));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(3,6));
            
            LevelDiaoLuo8.Add(new DiaoLuoConfig(102,1));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(102,2));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(102,3));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(102,4));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(102,5));
            LevelDiaoLuo8.Add(new DiaoLuoConfig(102,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo9.Add(new DiaoLuoConfig(1,6,prop:102));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(1,6,prop:402));
            
            LevelDiaoLuo9.Add(new DiaoLuoConfig(1,6,prop:103));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(1,6,prop:403));
            
            LevelDiaoLuo9.Add(new DiaoLuoConfig(3,1));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(3,2));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(3,3));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(3,4));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(3,5));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(3,6));
            
            LevelDiaoLuo9.Add(new DiaoLuoConfig(102,1));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(102,2));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(102,3));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(102,4));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(102,5));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(102,6));
            
            LevelDiaoLuo9.Add(new DiaoLuoConfig(103,1));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(103,2));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(103,3));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(103,4));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(103,5));
            LevelDiaoLuo9.Add(new DiaoLuoConfig(103,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo10.Add(new DiaoLuoConfig(1,6,prop:102));
            LevelDiaoLuo10.Add(new DiaoLuoConfig(1,6,prop:202));
            
            LevelDiaoLuo10.Add(new DiaoLuoConfig(3,1));
            LevelDiaoLuo10.Add(new DiaoLuoConfig(3,2));
            LevelDiaoLuo10.Add(new DiaoLuoConfig(3,3));
            LevelDiaoLuo10.Add(new DiaoLuoConfig(3,4));
            LevelDiaoLuo10.Add(new DiaoLuoConfig(3,5));
            LevelDiaoLuo10.Add(new DiaoLuoConfig(3,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo11.Add(new DiaoLuoConfig(1,6,prop:102));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(1,6,prop:202));
            
            LevelDiaoLuo11.Add(new DiaoLuoConfig(1,6,prop:103));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(1,6,prop:203));
            
            LevelDiaoLuo11.Add(new DiaoLuoConfig(3,1));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(3,2));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(3,3));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(3,4));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(3,5));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(3,6));
            
            LevelDiaoLuo11.Add(new DiaoLuoConfig(103,1));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(103,2));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(103,3));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(103,4));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(103,5));
            LevelDiaoLuo11.Add(new DiaoLuoConfig(103,6));
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo12.Add(new DiaoLuoConfig(1,6,prop:102));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(1,6,prop:402));
            
            LevelDiaoLuo12.Add(new DiaoLuoConfig(1,6,prop:103));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(1,6,prop:403));
            
            LevelDiaoLuo12.Add(new DiaoLuoConfig(3,1));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(3,2));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(3,3));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(3,4));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(3,5));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(3,6));
            
            LevelDiaoLuo12.Add(new DiaoLuoConfig(103,1));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(103,2));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(103,3));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(103,4));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(103,5));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(103,6));
            
            LevelDiaoLuo12.Add(new DiaoLuoConfig(4,1));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(4,2));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(4,3));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(4,4));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(4,5));
            LevelDiaoLuo12.Add(new DiaoLuoConfig(4,6));
        }
        
        if (IsOneGame)
        {
            
            LevelDiaoLuo13.Add(new DiaoLuoConfig(1,6,prop:103));
            LevelDiaoLuo13.Add(new DiaoLuoConfig(1,6,prop:203));
            
            LevelDiaoLuo13.Add(new DiaoLuoConfig(103,1));
            LevelDiaoLuo13.Add(new DiaoLuoConfig(103,2));
            LevelDiaoLuo13.Add(new DiaoLuoConfig(103,3));
            LevelDiaoLuo13.Add(new DiaoLuoConfig(103,4));
            LevelDiaoLuo13.Add(new DiaoLuoConfig(103,5));
            LevelDiaoLuo13.Add(new DiaoLuoConfig(103,6));
        }
        
        
        if (IsOneGame)
        {
            LevelDiaoLuo14.Add(new DiaoLuoConfig(1,6,prop:103));
            LevelDiaoLuo14.Add(new DiaoLuoConfig(1,6,prop:203));
            
            LevelDiaoLuo14.Add(new DiaoLuoConfig(103,1));
            LevelDiaoLuo14.Add(new DiaoLuoConfig(103,2));
            LevelDiaoLuo14.Add(new DiaoLuoConfig(103,3));
            LevelDiaoLuo14.Add(new DiaoLuoConfig(103,4));
            LevelDiaoLuo14.Add(new DiaoLuoConfig(103,5));
            LevelDiaoLuo14.Add(new DiaoLuoConfig(103,6));
            
            LevelDiaoLuo14.Add(new DiaoLuoConfig(4,1));
            LevelDiaoLuo14.Add(new DiaoLuoConfig(4,2));
            LevelDiaoLuo14.Add(new DiaoLuoConfig(4,3));
            LevelDiaoLuo14.Add(new DiaoLuoConfig(4,4));
            LevelDiaoLuo14.Add(new DiaoLuoConfig(4,5));
            LevelDiaoLuo14.Add(new DiaoLuoConfig(4,6));
        }
        
        
        if (IsOneGame)
        {
            LevelDiaoLuo15.Add(new DiaoLuoConfig(1,6,prop:103));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(1,6,prop:403));
            
            LevelDiaoLuo15.Add(new DiaoLuoConfig(103,1));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(103,2));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(103,3));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(103,4));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(103,5));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(103,6));
            
            LevelDiaoLuo15.Add(new DiaoLuoConfig(1,6,prop:104));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(1,6,prop:404));
            
            LevelDiaoLuo15.Add(new DiaoLuoConfig(4,1));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(4,2));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(4,3));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(4,4));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(4,5));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(4,6));
            
            LevelDiaoLuo15.Add(new DiaoLuoConfig(7,1));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(7,2));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(7,3));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(7,4));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(7,5));
            LevelDiaoLuo15.Add(new DiaoLuoConfig(7,6));
        }
        
        
        if (IsOneGame)
        {
            MJDiaoLuo.Add(new DiaoLuoConfig(1,6,prop:103));
        }
    }
   public static LevelInfoItem LevelInfoItem1= new LevelInfoItem
   {
       Level = 1,
       LevelType = LevelType.Normal,
       DiaoLuoIconList = new List<Sprite>(),
       DiaoLuoNameList = new List<string>()
   };
    public static LevelInfoItem LevelInfoItem2 = new LevelInfoItem
    {
         Level = 2,
         LevelType = LevelType.Elite,
         DiaoLuoIconList = new List<Sprite>(),
            DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem3 = new LevelInfoItem
    {
         Level = 3,
         LevelType = LevelType.Boss,
         DiaoLuoIconList = new List<Sprite>(),
            DiaoLuoNameList = new List<string>()
    };

    public static LevelInfoItem LevelInfoItem4= new LevelInfoItem
    {
        Level = 4,
        LevelType = LevelType.Normal,
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem5= new LevelInfoItem
    {
        Level = 5,
        LevelType = LevelType.Elite,
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem6= new LevelInfoItem
    {
        Level = 6,
        LevelType = LevelType.Boss,
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem7= new LevelInfoItem
    {
        Level = 7,
        LevelType = LevelType.Normal,
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem8= new LevelInfoItem
    {
        Level = 8,
        LevelType = LevelType.Elite,
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem9= new LevelInfoItem
    {
        Level = 9,
        LevelType = LevelType.Boss,
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static void init()
    {
        //关卡1
        if (IsOneGame)
        {
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
            LevelInfoItem4.LevelInfoDir = false;
            LevelInfoItem4.LevelInfoPos = new Vector2(441, -73);
            
            
            //关卡5
            LevelInfoItem5.LevelInfoDir = true;
            LevelInfoItem5.LevelInfoPos = new Vector2(1220, -161);
            
            //关卡6
            LevelInfoItem6.LevelInfoDir = true;
            LevelInfoItem6.LevelInfoPos = new Vector2(715, -400);
            
            
            //关卡7
            LevelInfoItem7.LevelInfoDir = false;
            LevelInfoItem7.LevelInfoPos = new Vector2(468, -365);
            
            
            //关卡8
            LevelInfoItem8.LevelInfoDir = false;
            LevelInfoItem8.LevelInfoPos = new Vector2(618, -547);
            
            //关卡9
            LevelInfoItem9.LevelInfoDir = false;
            LevelInfoItem9.LevelInfoPos = new Vector2(886, -501);
        }
    }
    
    public static List<DiaoLuoConfig> GetDiaoLuoList()
    {
        switch (CurrentGameLevel)
        {
            case 3:
                return LevelDiaoLuo3;
            case 6:
                return LevelDiaoLuo6;
            case 9:
                return LevelDiaoLuo9;
            case 12:
                return LevelDiaoLuo12;
            case 15:
                return LevelDiaoLuo15;
            default:
                return MJDiaoLuo;
        }

        return null;
    }

    public static  bool IsHaveDiaoLuo(List<DiaoLuoConfig> list, DiaoLuoConfig diaoluo)
    {
        if (list == null)
            return false;
        foreach (var item in list)
        {
            if (item.PropId == diaoluo.PropId && diaoluo.PropId != 0)
            {
                return true;
            }

            if (item.OrangeId == diaoluo.OrangeId && diaoluo.OrangeId != 0)
            {
                return true;
            }

            if (item.SuitId == diaoluo.SuitId && diaoluo.SuitId != 0)
            {
                return true;
            }
        }

        return false;
    }
}
