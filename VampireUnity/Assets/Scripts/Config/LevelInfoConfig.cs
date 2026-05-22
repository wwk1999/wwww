using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Equip;
using NUnit.Framework;
using Skill.NormalAttack.Primary;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class DiaoLuoConfig
{
    public PlayerEquipConfig.EquipLevel EquipLevel = PlayerEquipConfig.EquipLevel.None;
    public PlayerEquipConfig.EquipType SuitType;
    public int PropId;
    public bool IsOrange;

    public DiaoLuoConfig(PlayerEquipConfig.EquipLevel equipLevel,PlayerEquipConfig.EquipType suitType=PlayerEquipConfig.EquipType.None,int propId=0,bool  isOrange=false)
    {
        EquipLevel = equipLevel;
        SuitType = suitType;
        PropId = propId;
        IsOrange=isOrange;
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
    ChaiLangRen1,//1
    ChaiLangRen2,//1
    ChaiLangRen3,
    ChaiLangRen4,
    CiZhu,//1
    DaoCaoRen,//1
    DiJing2,//1
    DiJing3,//1
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
    ShanZei3,
    ShiJiaChong,//1
    ShiShiGui,
    ShiXiangGui,
    ShuangTouLong1,//1
    ShuangTouLong2,//1
    ShuangTouLong3,//1
    TuJiu,//1
    WuYa,//1
    YouLang,//1
    YouLing1,//1
    YouLing2,//1
    YuRen1,//1
    YuRen2,//1
    YuRen3,//1
    cat,
    queen,
    egg,
    onyx,
    xiaohuoling,
    xiaoshuguai,
    xiaozhizhu,
    shanyang,
    yanshu,
    niguai1,
    niguai2,
    niguai3,
    lang,
    zibaolaoshu,
    mogu,
    she,
    woniu,
    xiezi1,
    xiezi2,
    yezhu,
    xuelaoshu,
    //精英怪
    zhumodaocaoren,
    xiongbuou,
    rongyanboss,
    paopao,
    banrenma1,
    banrenma2,
    banrenma3,
    NiuTouRen1,//1
    NiuTouRen2,//1
    NiuTouRen3,//1
    ShouRen1,//1
    ShouRen2,//1
    ShouRen3,//1
    YouHunLingZhu,
    DaZongXiong,        // 1
    DiJingZhangLao,     // 1
    FengHeGuai,         // 1
    KuangShiMuZhu,      // 1
    LuJiaoDouShi,       // 1
    RongYanGuai,        // 1
    ShiFuBoss,          // 师傅BOSS
    ShuangTouRen,       // 双头人
    YeShouZhanShi,      // 野兽战士
    ZhiZhuNvWang,       // 蜘蛛女王
    
    //boss
    WuYaoZhiWang,       // 巫妖之王
    WuYaoZhiWang2, 
    //异界怪物
    //小怪
    DaLong,
    Emo1,
    Emo2,
    Emo3,
    HongLong1,
    HongLong2,
    HongLong3,
    LanLong1,
    LanLong2,
    LanLong3,
    LvLang,
    LvLong1,
    LvLong2,
    LvLong3,
    
    //boss
    LeiShou,
    KuiJia,
    HuoLang,
    BaoZi,
    ShuangDao,
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
    
     public static Dictionary<int, List<ChongWuDiaoLuoItem>> WeaponDiaoLuoDic = new Dictionary<int, List<ChongWuDiaoLuoItem>>()
    {
        {1,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.WeaponFragment,Quality = 1}}},
        {2,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.WeaponFragment,Quality = 2}}},
        {3,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.WeaponFragment,Quality = 3}}},
        {4,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.WeaponFragment,Quality = 4}}},
        {5,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.WeaponFragment,Quality = 5}}},
        {6,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.WeaponFragment,Quality = 6}}},
    };

    public static Dictionary<int, List<ChongWuDiaoLuoItem>> ChongWuDiaoLuoDic = new Dictionary<int, List<ChongWuDiaoLuoItem>>()
    {
        {1,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 1}}},
        {2,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 2}}},
        {3,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 3}}},
        {4,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 4},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 4}}},
        {5,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 5},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 5},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 5}}},
        {6,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 5},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 6},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 6}}},
    };

    public static Dictionary<int, List<ChiBangType>> ChiBangDiaoLuoDic = new Dictionary<int, List<ChiBangType>>()
    {
        {1,new List<ChiBangType>() { ChiBangType.Green1,ChiBangType.Green2,ChiBangType.Green3,ChiBangType.Green4,ChiBangType.Green5,ChiBangType.Green6 }},
        {2,new List<ChiBangType>() { ChiBangType.Blue1,ChiBangType.Blue2,ChiBangType.Blue3,ChiBangType.Blue4,ChiBangType.Blue5,ChiBangType.Blue6 ,ChiBangType.Blue7,ChiBangType.Blue8}},
        {3,new List<ChiBangType>() { ChiBangType.Blue1,ChiBangType.Blue2,ChiBangType.Blue3,ChiBangType.Blue4,ChiBangType.Blue5,ChiBangType.Blue6,ChiBangType.Blue7,ChiBangType.Blue8,ChiBangType.Purple1,ChiBangType.Purple2,ChiBangType.Purple3 }},
        {4,new List<ChiBangType>() { ChiBangType.Purple1,ChiBangType.Purple2,ChiBangType.Purple3,ChiBangType.Purple4,ChiBangType.Purple5,ChiBangType.Purple6 ,ChiBangType.Purple7}},
        {5,new List<ChiBangType>() { ChiBangType.Orange1,ChiBangType.Orange2,ChiBangType.Orange3}},
        {6,new List<ChiBangType>() { ChiBangType.Orange1,ChiBangType.Orange2,ChiBangType.Orange3,ChiBangType.Red1}},
    };

   public static MonsterBase GetMonster(MonsterTypeByName type)
{
    switch (type)
    {
        case MonsterTypeByName.None:
            return null;
        case MonsterTypeByName.Snot:
            return QueueController.S.SnotMonsterQueue.Dequeue();
        case MonsterTypeByName.Bat:
            return QueueController.S.BatMonsterQueue.Dequeue();
        case MonsterTypeByName.Spider:
            return QueueController.S.SpiderMonsterQueue.Dequeue();
        case MonsterTypeByName.Bee:
            return QueueController.S.EliteBeeMonsterQueue.Dequeue();
        case MonsterTypeByName.XiaoHuo:
            return QueueController.S.XiaoHuoMonsterQueue.Dequeue();
        case MonsterTypeByName.DaZui:
            return QueueController.S.EliteDaZuiMonsterQueue.Dequeue();
        case MonsterTypeByName.DunDi:
            return QueueController.S.DunDiMonsterQueue.Dequeue();
        case MonsterTypeByName.ChongZi:
            return QueueController.S.ChongZiMonsterQueue.Dequeue();
  
        case MonsterTypeByName.ShiRenHua:
            return QueueController.S.ShiRenHuaMonsterQueue.Dequeue();
        case MonsterTypeByName.JiaChong:
            return QueueController.S.JiaChongMonsterQueue.Dequeue();
        case MonsterTypeByName.WenZi:
            return QueueController.S.WenZiMonsterQueue.Dequeue();
   
        case MonsterTypeByName.ShaChong:
            return QueueController.S.ShaChongQueue.Dequeue();
        case MonsterTypeByName.ShaNiao:
            return QueueController.S.ShaNiaoQueue.Dequeue();
        case MonsterTypeByName.ShaXiYi:
            return QueueController.S.ShaXiYiQueue.Dequeue();
        case MonsterTypeByName.XianRenZhang:
            return QueueController.S.XianRenZhangQueue.Dequeue();
        
        case MonsterTypeByName.XueRen:
            return QueueController.S.XueRenQueue.Dequeue();
        case MonsterTypeByName.XueZhangLang:
            return QueueController.S.XueZhangLangQueue.Dequeue();
        case MonsterTypeByName.XueQiE:
            return QueueController.S.XueQiEQueue.Dequeue();
        case MonsterTypeByName.YingShu:
            return QueueController.S.YingShuQueue.Dequeue();
        
       
        case MonsterTypeByName.QingWa:
            return QueueController.S.QingWaMonsterQueue.Dequeue();
        // 小怪
        case MonsterTypeByName.ChaiLangRen1:
            return QueueController.S.chailangren1Queue.Dequeue();
        case MonsterTypeByName.ChaiLangRen2:
            return QueueController.S.chailangren2Queue.Dequeue();
        case MonsterTypeByName.ChaiLangRen3:
            return QueueController.S.chailangren3Queue.Dequeue();
        case MonsterTypeByName.ChaiLangRen4:
            return QueueController.S.chailangren4Queue.Dequeue();
        case MonsterTypeByName.CiZhu:
            return QueueController.S.cizhuQueue.Dequeue();
        case MonsterTypeByName.DaoCaoRen:
            return QueueController.S.daocaorenQueue.Dequeue();
        case MonsterTypeByName.DiJing2:
            return QueueController.S.dijing2Queue.Dequeue();
        case MonsterTypeByName.DiJing3:
            return QueueController.S.dijing3Queue.Dequeue();
        case MonsterTypeByName.DiJingShouWei1:
            return QueueController.S.dijingshouwei1Queue.Dequeue();
        case MonsterTypeByName.DiJingShouWei2:
            return QueueController.S.dijingshouwei2Queue.Dequeue();
        case MonsterTypeByName.DiJingShouWei3:
            return QueueController.S.dijingshouwei3Queue.Dequeue();
        case MonsterTypeByName.HeiXiong:
            return QueueController.S.heixiongQueue.Dequeue();
        case MonsterTypeByName.JianChiZhu:
            return QueueController.S.jianchizhuQueue.Dequeue();
        case MonsterTypeByName.KuLou1:
            return QueueController.S.kulou1Queue.Dequeue();
        case MonsterTypeByName.KuLou2:
            return QueueController.S.kulou2Queue.Dequeue();
        case MonsterTypeByName.KuLou3:
            return QueueController.S.kulou3Queue.Dequeue();
        case MonsterTypeByName.KuLou4:
            return QueueController.S.kulou4Queue.Dequeue();
        case MonsterTypeByName.KuLou5:
            return QueueController.S.kulou5Queue.Dequeue();
        case MonsterTypeByName.KuLou6:
            return QueueController.S.kulou6Queue.Dequeue();
        case MonsterTypeByName.LuJiaoCiKe1:
            return QueueController.S.lujiaocikeQueue.Dequeue();
        case MonsterTypeByName.LuJiaoCiKe2:
            return QueueController.S.lujiaocike2Queue.Dequeue();
        case MonsterTypeByName.NiuTouRen1:
            return QueueController.S.niutouren1Queue.Dequeue();
        case MonsterTypeByName.NiuTouRen2:
            return QueueController.S.niutouren2Queue.Dequeue();
        case MonsterTypeByName.NiuTouRen3:
            return QueueController.S.niutouren3Queue.Dequeue();
        case MonsterTypeByName.ShanZei3:
            return QueueController.S.shanzei3Queue.Dequeue();
        case MonsterTypeByName.ShiJiaChong:
            return QueueController.S.shijiachongQueue.Dequeue();
        case MonsterTypeByName.ShiShiGui:
            return QueueController.S.shishiguiQueue.Dequeue();
        case MonsterTypeByName.ShiXiangGui:
            return QueueController.S.shixiangguiQueue.Dequeue();
        case MonsterTypeByName.ShouRen1:
            return QueueController.S.shouren1Queue.Dequeue();
        case MonsterTypeByName.ShouRen2:
            return QueueController.S.shouren2Queue.Dequeue();
        case MonsterTypeByName.ShouRen3:
            return QueueController.S.shouren3Queue.Dequeue();
        case MonsterTypeByName.ShuangTouLong1:
            return QueueController.S.shuangtoulongQueue.Dequeue();
        case MonsterTypeByName.ShuangTouLong2:
            return QueueController.S.shuangtoulong2Queue.Dequeue();
        case MonsterTypeByName.ShuangTouLong3:
            return QueueController.S.shuangtoulong3Queue.Dequeue();
        case MonsterTypeByName.TuJiu:
            return QueueController.S.tujiuQueue.Dequeue();
        case MonsterTypeByName.WuYa:
            return QueueController.S.wuyaQueue.Dequeue();
        case MonsterTypeByName.YouHunLingZhu:
            return QueueController.S.youhunlingzhuQueue.Dequeue();
        case MonsterTypeByName.YouLang:
            return QueueController.S.youlangQueue.Dequeue();
        case MonsterTypeByName.YouLing1:
            return QueueController.S.youlingQueue.Dequeue();
        case MonsterTypeByName.YouLing2:
            return QueueController.S.youling2Queue.Dequeue();
        case MonsterTypeByName.YuRen1:
            return QueueController.S.yuren1Queue.Dequeue();
        case MonsterTypeByName.YuRen2:
            return QueueController.S.yuren2Queue.Dequeue();
        case MonsterTypeByName.YuRen3:
            return QueueController.S.yuren3Queue.Dequeue();
        case MonsterTypeByName.cat:
            return QueueController.S.catQueue.Dequeue();
        case MonsterTypeByName.egg:
            return QueueController.S.eggQueue.Dequeue();
        case MonsterTypeByName.lang:
            return QueueController.S.langQueue.Dequeue();
        case MonsterTypeByName.mogu:
            return QueueController.S.moguQueue.Dequeue();
        case MonsterTypeByName.niguai1:
            return QueueController.S.niguai1Queue.Dequeue();
        case MonsterTypeByName.niguai2:
            return QueueController.S.niguai2Queue.Dequeue();
        case MonsterTypeByName.niguai3:
            return QueueController.S.niguai3Queue.Dequeue();
        case MonsterTypeByName.onyx:
            return QueueController.S.onyxQueue.Dequeue();
        case MonsterTypeByName.queen:
            return QueueController.S.queenQueue.Dequeue();
        case MonsterTypeByName.shanyang:
            return QueueController.S.shanyangQueue.Dequeue();
        case MonsterTypeByName.she:
            return QueueController.S.sheQueue.Dequeue();
        case MonsterTypeByName.woniu:
            return QueueController.S.woniuQueue.Dequeue();
        case MonsterTypeByName.xiaohuoling:
            return QueueController.S.xiaohuolingQueue.Dequeue();
        case MonsterTypeByName.xiaozhizhu:
            return QueueController.S.xiaozhizhuQueue.Dequeue();
        case MonsterTypeByName.xiaoshuguai:
            return QueueController.S.xiaoshuguaiQueue.Dequeue();
        case MonsterTypeByName.xiezi1:
            return QueueController.S.xiezi1Queue.Dequeue();
        case MonsterTypeByName.xiezi2:
            return QueueController.S.xiezi2Queue.Dequeue();
        case MonsterTypeByName.xuelaoshu:
            return QueueController.S.xuelaoshuQueue.Dequeue();
        case MonsterTypeByName.yanshu:
            return QueueController.S.yanshuQueue.Dequeue();
        case MonsterTypeByName.yezhu:
            return QueueController.S.yezhuQueue.Dequeue();
        case MonsterTypeByName.zibaolaoshu:
            return QueueController.S.zibaolaoshuQueue.Dequeue();
        
        
        
        
        // 精英怪
        case MonsterTypeByName.DaZongXiong:
            return QueueController.S.dazongxiongQueue.Dequeue();
        case MonsterTypeByName.DiJingZhangLao:
            return QueueController.S.DijingzhanglaoQueue.Dequeue();
        case MonsterTypeByName.FengHeGuai:
            return QueueController.S.fengheguaiQueue.Dequeue();
        case MonsterTypeByName.KuangShiMuZhu:
            return QueueController.S.kuangshimuzhuQueue.Dequeue();
        case MonsterTypeByName.LuJiaoDouShi:
            return QueueController.S.lujiaodoushiQueue.Dequeue();
        case MonsterTypeByName.RongYanGuai:
            return QueueController.S.rongyanguaiQueue.Dequeue();
        case MonsterTypeByName.ShiFuBoss:
            return QueueController.S.shifubossQueue.Dequeue();
        case MonsterTypeByName.ShuangTouRen:
            return QueueController.S.shuangtourenQueue.Dequeue();
        case MonsterTypeByName.WuYaoZhiWang:
            return QueueController.S.wuyaozhiwangQueue.Dequeue();
        case MonsterTypeByName.WuYaoZhiWang2:
            return QueueController.S.wuyaozhiwang2Queue.Dequeue();
        case MonsterTypeByName.YeShouZhanShi:
            return QueueController.S.YeShouZhanShiQueue.Dequeue();
        case MonsterTypeByName.ZhiZhuNvWang:
            return QueueController.S.ZhiZhuNvWangQueue.Dequeue();
        
        case MonsterTypeByName.banrenma1:
            return QueueController.S.banrenma1Queue.Dequeue();
        case MonsterTypeByName.banrenma2:
            return QueueController.S.banrenma2Queue.Dequeue();
        case MonsterTypeByName.banrenma3:
            return QueueController.S.banrenma3Queue.Dequeue();
        case MonsterTypeByName.paopao:
            return QueueController.S.paopaoQueue.Dequeue();
        case MonsterTypeByName.rongyanboss:
            return QueueController.S.rongyanbossQueue.Dequeue();
        case MonsterTypeByName.xiongbuou:
            return QueueController.S.xiongbuouQueue.Dequeue();
        case MonsterTypeByName.zhumodaocaoren:
            return QueueController.S.zhumodaocaorenQueue.Dequeue();
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
    
     public static Dictionary<int, float> LevelMonsterCreateSpeedDic =
        new Dictionary<int, float>()
        {
            {3,1f},
            {6,1f},
            {9,1f},
            {12,1f},
            {15,1f},
            
            {16,1f},
            {17,1f},
            {18,1f},
            {19,1f},
            {20,1f},
            {21,1f},
            {22,1f},
            {23,1f},
            {24,1f},
            {25,1f},
            {26,1f},
            {27,1f},
            {28,1f},
            {29,1f},
            {30,1f},
            {31,1f},
            {32,1f},
            {33,1f},
            {34,1f},
            {35,1f},
            
            
            {101,1f},
            {102,1f},
            {103,1f},
            {104,1f},
            {105,1f},
            {106,1f},

            
            {201,1f},
            {202,1f},
            {203,1f},
            {204,1f},
            {205,1f},
            {206,1f},

            
            {301,1f},
            {302,1f},
            {303,1f},
            {304,1f},
            {305,1f},
            {306,1f},

        };
    
    
    
    public static Dictionary<int, List<MonsterTypeByName>> LevelMonsterDic =
        new Dictionary<int, List<MonsterTypeByName>>()
        {
            {3,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Bat,MonsterTypeByName.Spider,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {6,new List<MonsterTypeByName>() { MonsterTypeByName.ChongZi ,MonsterTypeByName.DunDi,MonsterTypeByName.DaZui,MonsterTypeByName.XiaoHuo,MonsterTypeByName.HuoShanBoss}},
            {9,new List<MonsterTypeByName>() { MonsterTypeByName.ZhaoZeBoss ,MonsterTypeByName.ShiRenHua,MonsterTypeByName.WenZi,MonsterTypeByName.QingWa,MonsterTypeByName.JiaChong}},
            {12,new List<MonsterTypeByName>() { MonsterTypeByName.ShaChong ,MonsterTypeByName.ShaNiao,MonsterTypeByName.ShaXiYi,MonsterTypeByName.XianRenZhang,MonsterTypeByName.XieZi}},
            {15,new List<MonsterTypeByName>() { MonsterTypeByName.XueZhangLang ,MonsterTypeByName.XueQiE,MonsterTypeByName.YingShu,MonsterTypeByName.XueRen,MonsterTypeByName.XueRenBoss}},
            
            {16,new List<MonsterTypeByName>() { MonsterTypeByName.XueZhangLang ,MonsterTypeByName.XueQiE,MonsterTypeByName.YingShu,MonsterTypeByName.XueRen,MonsterTypeByName.XueRenBoss}},
            {17,new List<MonsterTypeByName>() { MonsterTypeByName.XueZhangLang ,MonsterTypeByName.XueQiE,MonsterTypeByName.YingShu,MonsterTypeByName.XueRen,MonsterTypeByName.XueRenBoss}},
            {18,new List<MonsterTypeByName>() { MonsterTypeByName.XueZhangLang ,MonsterTypeByName.XueQiE,MonsterTypeByName.YingShu,MonsterTypeByName.XueRen,MonsterTypeByName.XueRenBoss}},
            {19,new List<MonsterTypeByName>()},
            {20,new List<MonsterTypeByName>()},
            {21,new List<MonsterTypeByName>()},
            {22,new List<MonsterTypeByName>()},
            {23,new List<MonsterTypeByName>()},
            {24,new List<MonsterTypeByName>()},
            {25,new List<MonsterTypeByName>()},
            {26,new List<MonsterTypeByName>()},
            {27,new List<MonsterTypeByName>()},
            {28,new List<MonsterTypeByName>()},
            {29,new List<MonsterTypeByName>()},
            {30,new List<MonsterTypeByName>()},
            {31,new List<MonsterTypeByName>()},
            {32,new List<MonsterTypeByName>()},
            {33,new List<MonsterTypeByName>()},
            {34,new List<MonsterTypeByName>()},
            {35,new List<MonsterTypeByName>()},
            
            
            {201,new List<MonsterTypeByName>() { MonsterTypeByName.cat ,MonsterTypeByName.egg,MonsterTypeByName.paopao}},
            {202,new List<MonsterTypeByName>() { MonsterTypeByName.CiZhu ,MonsterTypeByName.she,MonsterTypeByName.banrenma1}},
            {203,new List<MonsterTypeByName>() { MonsterTypeByName.YouLang ,MonsterTypeByName.onyx,MonsterTypeByName.banrenma2}},
            {204,new List<MonsterTypeByName>() { MonsterTypeByName.TuJiu ,MonsterTypeByName.WuYa,MonsterTypeByName.banrenma3}},
            {205,new List<MonsterTypeByName>() { MonsterTypeByName.xuelaoshu ,MonsterTypeByName.lang,MonsterTypeByName.xiongbuou}},
            {206,new List<MonsterTypeByName>() { MonsterTypeByName.xiezi1 ,MonsterTypeByName.xiezi2,MonsterTypeByName.zhumodaocaoren}},

            
            {101,new List<MonsterTypeByName>() { MonsterTypeByName.YuRen1 ,MonsterTypeByName.KuLou1,MonsterTypeByName.ShouRen1}},
            {102,new List<MonsterTypeByName>() { MonsterTypeByName.YuRen2 ,MonsterTypeByName.KuLou2,MonsterTypeByName.ShouRen2}},
            {103,new List<MonsterTypeByName>() { MonsterTypeByName.YuRen3 ,MonsterTypeByName.KuLou3,MonsterTypeByName.ShouRen3}},
            {104,new List<MonsterTypeByName>() { MonsterTypeByName.niguai1 ,MonsterTypeByName.KuLou4,MonsterTypeByName.NiuTouRen1}},
            {105,new List<MonsterTypeByName>() { MonsterTypeByName.niguai2 ,MonsterTypeByName.KuLou5,MonsterTypeByName.NiuTouRen2}},
            {106,new List<MonsterTypeByName>() { MonsterTypeByName.niguai3 ,MonsterTypeByName.KuLou6,MonsterTypeByName.NiuTouRen3}},

            
            {301,new List<MonsterTypeByName>() { MonsterTypeByName.ChaiLangRen1 ,MonsterTypeByName.ChaiLangRen2,MonsterTypeByName.ShuangTouRen}},
            {302,new List<MonsterTypeByName>() { MonsterTypeByName.ChaiLangRen3 ,MonsterTypeByName.ChaiLangRen4,MonsterTypeByName.RongYanGuai}},
            {303,new List<MonsterTypeByName>() { MonsterTypeByName.DiJing2 ,MonsterTypeByName.DiJing3,MonsterTypeByName.DiJingZhangLao}},
            {304,new List<MonsterTypeByName>() { MonsterTypeByName.DaoCaoRen ,MonsterTypeByName.HeiXiong,MonsterTypeByName.rongyanboss}},
            {305,new List<MonsterTypeByName>() { MonsterTypeByName.queen ,MonsterTypeByName.shanyang,MonsterTypeByName.FengHeGuai}},
            {306,new List<MonsterTypeByName>() { MonsterTypeByName.ShiShiGui ,MonsterTypeByName.ShiXiangGui,MonsterTypeByName.DaZongXiong}},

        };
    public static int[] LevelMonsterCount= new int[1000];//关卡敌人数量
   
    public static void InitGameLevel()
    {
       
        LevelMonsterCount[3] = 40;
        LevelMonsterCount[6] = 60;
        LevelMonsterCount[9] = 90;
        LevelMonsterCount[12] = 100;
        LevelMonsterCount[15] = 10;
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
        
        LevelMonsterCount[101] = 10;
        LevelMonsterCount[102] = 120;
        LevelMonsterCount[103] = 140;
        LevelMonsterCount[104] = 180;
        LevelMonsterCount[105] = 250;
        LevelMonsterCount[106] = 300;
        
        
        LevelMonsterCount[201] = 100;
        LevelMonsterCount[202] = 120;
        LevelMonsterCount[203] = 140;
        LevelMonsterCount[204] = 180;
        LevelMonsterCount[205] = 250;
        LevelMonsterCount[206] = 300;
        
        
        
        
        LevelMonsterCount[301] = 100;
        LevelMonsterCount[302] = 120;
        LevelMonsterCount[303] = 140;
        LevelMonsterCount[304] = 180;
        LevelMonsterCount[305] = 250;
        LevelMonsterCount[306] = 300;
    }

    public static List<DiaoLuoConfig> GetDiaoLuoList(int GameLevel)
    {
        if (!LevelMonsterDic.ContainsKey(GameLevel))
        {
            return new List<DiaoLuoConfig>();
        }
        
        var monsterlist = LevelMonsterDic[GameLevel];
        List<DiaoLuoConfig> diaoLuoList = new List<DiaoLuoConfig>();
        List<MonsterEquip> equiplist = new List<MonsterEquip>();
        List<MonsterProp> proplist = new List<MonsterProp>();
        
        foreach (var item in monsterlist)
        {
            var key = new MonsterDiaoLuoType()
                { GameLevel = GameLevel, MonsterType = MonsterConfig.MonsterTypeDic[item] };
            
            if (!MonsterConfig.MonsterInfoDic.ContainsKey(key))
            {
                // 如果找不到对应的数据，使用默认值
                continue;
            }
            
            MonsterInfo info = MonsterConfig.MonsterInfoDic[key];
            foreach (var item1 in info.MonsterPropList)
            {
                if (!proplist.Contains(item1))
                {
                    proplist.Add(item1);
                }
            }
        }

        foreach (var item in monsterlist)
        {
            var key = new MonsterDiaoLuoType()
                { GameLevel = GameLevel, MonsterType = MonsterConfig.MonsterTypeDic[item] };
            
            if (!MonsterConfig.MonsterInfoDic.ContainsKey(key))
            {
                // 如果找不到对应的数据，跳过
                continue;
            }
            
            MonsterInfo info = MonsterConfig.MonsterInfoDic[key];
            if (info.orangeEquip)
            {
                MonsterEquip monsterEquip = new MonsterEquip(equipLevel:PlayerEquipConfig.EquipLevel.None,equipType:PlayerEquipConfig.EquipType.None,orange:true);
                equiplist.Add(monsterEquip);
                break;
            }
            foreach (var item1 in info.MonsterEquipList)
            {
                if (!equiplist.Contains(item1))
                {
                    equiplist.Add(item1);
                }
            }

        }

        if (proplist.Count > 0)
        {
            foreach (var item1 in proplist)
            {
                DiaoLuoConfig diaoluo = new DiaoLuoConfig(equipLevel:PlayerEquipConfig.EquipLevel.None,propId:PropConfig.GetPropId(item1.PropItem.PropType,item1.PropItem.Quality));
                diaoLuoList.Add(diaoluo);
            }
        }

        if (equiplist.Count > 0)
        {
            foreach (var item1 in equiplist)
            {
                DiaoLuoConfig diaoluo = new DiaoLuoConfig(equipLevel:item1.EquipLevel,suitType:item1.EquipType,isOrange:item1.Orange);
                diaoLuoList.Add(diaoluo);
            }
        }

        return diaoLuoList;
    }

    public static int NormalMonsterQueueCount = 150;
    public static int EliteMonsterQueueCount = 15;

    public static IEnumerator InitMonsterQueueAsync(int perFrame=10)
    {
        var monsterlist = LevelMonsterDic[CurrentGameLevel];

        foreach (var item in monsterlist)
        {
            int total = 0;
            if (MonsterConfig.MonsterTypeDic[item] == MonsterType.Normal)
                total = NormalMonsterQueueCount;
            else if (MonsterConfig.MonsterTypeDic[item] == MonsterType.Elite)
                total = EliteMonsterQueueCount;

            for (int i = 0; i < total; i++)
            {
                Entrance.InitMonster(item); // 假设这个方法是同步实例化
                if (i % perFrame == perFrame - 1)
                    yield return null; // 每创建 perFrame 个，让出一帧
            }
        }
    }
    
   
    public static IEnumerator InitSkillAsync(int perFrame = 10)
{
    // 预热容量
    const int defaultCapacity = 10;

    // 收集需要预加载的技能信息：预制体路径、组件类型、获取当前队列数量的委托、入队委托、需要实例化的数量
    var skillsToPreload = new List<(string prefabPath, System.Type componentType, Func<int> getCount, System.Action<Component> enqueue, int needCount)>();

    void AddSkill(bool condition, string path, System.Type type, Func<int> getCount, System.Action<Component> enqueue, int capacity = defaultCapacity)
    {
        if (!condition) return;
        int current = getCount();
        if (current < capacity)
        {
            skillsToPreload.Add((path, type, getCount, enqueue, capacity - current));
        }
    }

    var a1 = SkillJiaDian.S.Alpha1;
    var a2 = SkillJiaDian.S.Alpha2;
    var a3 = SkillJiaDian.S.Alpha3;
    var a4 = SkillJiaDian.S.Alpha4;
    var a5 = SkillJiaDian.S.Alpha5;

    // ========== 冰系 ==========
    AddSkill(a1 == SkillType.Ice3 || a2 == SkillType.Ice3 || a3 == SkillType.Ice3 || a4 == SkillType.Ice3 || a5 == SkillType.Ice3,
        "Prefabs/Skill/IceExplosion", typeof(IceExplosion),
        () => QueueController.S.IceExQueue.Count, c => QueueController.S.IceExQueue.Enqueue(c as IceExplosion));

    AddSkill(a1 == SkillType.Ice1 || a2 == SkillType.Ice1 || a3 == SkillType.Ice1 || a4 == SkillType.Ice1 || a5 == SkillType.Ice1,
        "Prefabs/Skill/IceSkill/IceSkill1", typeof(IceSkill1),
        () => QueueController.S.IceSkill1Queue.Count, c => QueueController.S.IceSkill1Queue.Enqueue(c as IceSkill1));

    // 注意原条件中 (a1 != SkillType.Ice4) 可能为笔误，保持原逻辑
    AddSkill((a1 == SkillType.Ice4) || a2 == SkillType.Ice4 || a3 == SkillType.Ice4 || a4 == SkillType.Ice4 || a5 == SkillType.Ice4,
        "Prefabs/Skill/IceSkill/IceSkill4", typeof(IceSkill4),
        () => QueueController.S.IceSkill4Queue.Count, c => QueueController.S.IceSkill4Queue.Enqueue(c as IceSkill4));

    AddSkill((a1 == SkillType.Ice5) || a2 == SkillType.Ice5 || a3 == SkillType.Ice5 || a4 == SkillType.Ice5 || a5 == SkillType.Ice5,
        "Prefabs/Skill/IceSkill/IceSkill5", typeof(IceSkill5),
        () => QueueController.S.IceSkill5Queue.Count, c => QueueController.S.IceSkill5Queue.Enqueue(c as IceSkill5));

    // ========== 火系 ==========
    AddSkill(a1 == SkillType.Huo1 || a2 == SkillType.Huo1 || a3 == SkillType.Huo1 || a4 == SkillType.Huo1 || a5 == SkillType.Huo1,
        "Prefabs/Skill/HuoSkill/HuoSkill1", typeof(HuoSkill1),
        () => QueueController.S.HuoSkill1Queue.Count, c => QueueController.S.HuoSkill1Queue.Enqueue(c as HuoSkill1));

    AddSkill(a1 == SkillType.Huo3 || a2 == SkillType.Huo3 || a3 == SkillType.Huo3 || a4 == SkillType.Huo3 || a5 == SkillType.Huo3,
        "Prefabs/Skill/HuoSkill/HuoSkill3", typeof(HuoSkill3),
        () => QueueController.S.HuoSkill3Queue.Count, c => QueueController.S.HuoSkill3Queue.Enqueue(c as HuoSkill3));

    AddSkill((a1 == SkillType.Huo4) || a2 == SkillType.Huo4 || a3 == SkillType.Huo4 || a4 == SkillType.Huo4 || a5 == SkillType.Huo4,
        "Prefabs/Skill/HuoSkill/HuoSkill4", typeof(HuoSkill4),
        () => QueueController.S.HuoSkill4Queue.Count, c => QueueController.S.HuoSkill4Queue.Enqueue(c as HuoSkill4));

    AddSkill((a1 == SkillType.Huo5) || a2 == SkillType.Huo5 || a3 == SkillType.Huo5 || a4 == SkillType.Huo5 || a5 == SkillType.Huo5,
        "Prefabs/Skill/HuoSkill/HuoSkill5", typeof(HuoSkill5),
        () => QueueController.S.HuoSkill5Queue.Count, c => QueueController.S.HuoSkill5Queue.Enqueue(c as HuoSkill5));

    // ========== 电系 ==========
    AddSkill(a1 == SkillType.Dian2 || a2 == SkillType.Dian2 || a3 == SkillType.Dian2 || a4 == SkillType.Dian2 || a5 == SkillType.Dian2,
        "Prefabs/Skill/DianSkill/DianSkill2", typeof(DianSkill2),
        () => QueueController.S.DianSkill2Queue.Count, c => QueueController.S.DianSkill2Queue.Enqueue(c as DianSkill2));

    AddSkill(a1 == SkillType.Dian3 || a2 == SkillType.Dian3 || a3 == SkillType.Dian3 || a4 == SkillType.Dian3 || a5 == SkillType.Dian3,
        "Prefabs/Skill/DianSkill/DianSkill3", typeof(DianSkill3),
        () => QueueController.S.DianSkill3Queue.Count, c => QueueController.S.DianSkill3Queue.Enqueue(c as DianSkill3));

    AddSkill((a1 == SkillType.Dian4) || a2 == SkillType.Dian4 || a3 == SkillType.Dian4 || a4 == SkillType.Dian4 || a5 == SkillType.Dian4,
        "Prefabs/Skill/DianSkill/DianSkill4", typeof(DianSkill4),
        () => QueueController.S.DianSkill4Queue.Count, c => QueueController.S.DianSkill4Queue.Enqueue(c as DianSkill4));

    AddSkill((a1 == SkillType.Dian5) || a2 == SkillType.Dian5 || a3 == SkillType.Dian5 || a4 == SkillType.Dian5 || a5 == SkillType.Dian5,
        "Prefabs/Skill/DianSkill/DianSkill5", typeof(DianSkill5),
        () => QueueController.S.DianSkill5Queue.Count, c => QueueController.S.DianSkill5Queue.Enqueue(c as DianSkill5));

    // ========== 黑暗系 ==========
    AddSkill(a1 == SkillType.HeiAn3 || a2 == SkillType.HeiAn3 || a3 == SkillType.HeiAn3 || a4 == SkillType.HeiAn3 || a5 == SkillType.HeiAn3,
        "Prefabs/Skill/HeiAnSkill/HeiAnSkill3", typeof(HeiAnSkill3),
        () => QueueController.S.HeiAnSkill3Queue.Count, c => QueueController.S.HeiAnSkill3Queue.Enqueue(c as HeiAnSkill3));

    AddSkill(a1 == SkillType.HeiAn1 || a2 == SkillType.HeiAn1 || a3 == SkillType.HeiAn1 || a4 == SkillType.HeiAn1 || a5 == SkillType.HeiAn1,
        "Prefabs/Skill/HeiAnSkill/HeiAnSkill1", typeof(HeiAnSkill1),
        () => QueueController.S.HeiAnSkill1Queue.Count, c => QueueController.S.HeiAnSkill1Queue.Enqueue(c as HeiAnSkill1));

    AddSkill((a1 == SkillType.HeiAn4) || a2 == SkillType.HeiAn4 || a3 == SkillType.HeiAn4 || a4 == SkillType.HeiAn4 || a5 == SkillType.HeiAn4,
        "Prefabs/Skill/HeiAnSkill/HeiAnSkill4", typeof(HeiAnSkill4),
        () => QueueController.S.HeiAnSkill4Queue.Count, c => QueueController.S.HeiAnSkill4Queue.Enqueue(c as HeiAnSkill4));

    AddSkill((a1 == SkillType.HeiAn5) || a2 == SkillType.HeiAn5 || a3 == SkillType.HeiAn5 || a4 == SkillType.HeiAn5 || a5 == SkillType.HeiAn5,
        "Prefabs/Skill/HeiAnSkill/HeiAnSkill5", typeof(HeiAnSkill5),
        () => QueueController.S.HeiAnSkill5Queue.Count, c => QueueController.S.HeiAnSkill5Queue.Enqueue(c as HeiAnSkill5));

    // ========== 分帧实例化 Component 技能 ==========
    int totalInstantiated = 0;
    foreach (var skill in skillsToPreload)
    {
        // 每个技能只需要加载一次预制体
        GameObject prefab = Resources.Load<GameObject>(skill.prefabPath);
        if (prefab == null)
        {
            Debug.LogError($"技能预制体加载失败: {skill.prefabPath}");
            continue;
        }

        Component sourceComp = prefab.GetComponent(skill.componentType);
        if (sourceComp == null)
        {
            Debug.LogError($"预制体 {skill.prefabPath} 上找不到组件 {skill.componentType}");
            continue;
        }

        for (int i = 0; i < skill.needCount; i++)
        {
            Component instance = Object.Instantiate(sourceComp, QueueController.S.transform);
            instance.gameObject.SetActive(false);
            skill.enqueue(instance);

            totalInstantiated++;
            if (totalInstantiated % perFrame == 0)
                yield return null;
        }
    }

    // ========== 处理 Dian1 的 GameObject 技能（各 10 个，但需检查队列已有数量） ==========
    bool hasDian1 = a1 == SkillType.Dian1 || a2 == SkillType.Dian1 || a3 == SkillType.Dian1 || a4 == SkillType.Dian1 || a5 == SkillType.Dian1;
    if (hasDian1)
    {
        // DianPeng
        int dianPengCurrent = QueueController.S.DianQuanPengQueue.Count;
        if (dianPengCurrent < defaultCapacity)
        {
            GameObject dianPengPrefab = Resources.Load<GameObject>("Prefabs/Skill/DianQuan/DianPeng");
            if (dianPengPrefab != null)
            {
                int need = defaultCapacity - dianPengCurrent;
                for (int i = 0; i < need; i++)
                {
                    GameObject obj = Object.Instantiate(dianPengPrefab, QueueController.S.transform);
                    obj.SetActive(false);
                    QueueController.S.DianQuanPengQueue.Enqueue(obj);
                    totalInstantiated++;
                    if (totalInstantiated % perFrame == 0)
                        yield return null;
                }
            }
            else Debug.LogError("DianPeng 预制体加载失败");
        }

        // DianQuan
        int dianQuanCurrent = QueueController.S.DianQuanQueue.Count;
        if (dianQuanCurrent < defaultCapacity)
        {
            GameObject dianQuanPrefab = Resources.Load<GameObject>("Prefabs/Skill/DianQuan/DianQuan");
            if (dianQuanPrefab != null)
            {
                int need = defaultCapacity - dianQuanCurrent;
                for (int i = 0; i < need; i++)
                {
                    GameObject obj = Object.Instantiate(dianQuanPrefab, QueueController.S.transform);
                    obj.SetActive(false);
                    QueueController.S.DianQuanQueue.Enqueue(obj);
                    totalInstantiated++;
                    if (totalInstantiated % perFrame == 0)
                        yield return null;
                }
            }
            else Debug.LogError("DianQuan 预制体加载失败");
        }
    }

    Debug.Log($"技能池预热完成，共实例化 {totalInstantiated} 个技能对象");
}
    
    
   public static IEnumerator InitPlayerHurtAndToolsAsync(int perFrame = 10)
{
    const int targetCapacity = 100; // 目标容量

    // 获取当前队列已有的数量
    int currentPlayerHurt = QueueController.S.PlayerHurtQueue.Count;
    int currentCircle = QueueController.S.CircleQueue.Count;
    int currentSqrt = QueueController.S.SqrtQueue.Count;

    // 如果所有队列都已经达到目标容量，直接跳过
    if (currentPlayerHurt >= targetCapacity && currentCircle >= targetCapacity && currentSqrt >= targetCapacity)
    {
        Debug.Log($"PlayerHurt + CircleAttack + SqrtAttack 池已满（≥{targetCapacity}），无需预热");
        yield break;
    }

    // 计算每个队列还需要创建的数量
    int needPlayerHurt = Mathf.Max(0, targetCapacity - currentPlayerHurt);
    int needCircle = Mathf.Max(0, targetCapacity - currentCircle);
    int needSqrt = Mathf.Max(0, targetCapacity - currentSqrt);

    // 需要创建的总对象数（用于分帧进度）
    int totalToCreate = needPlayerHurt + needCircle + needSqrt;
    if (totalToCreate == 0) yield break;

    // 提前加载预制体
    PlayerHurt playerHurtPrefab = Resources.Load<PlayerHurt>("Prefabs/Player/PlayerHurt");
    CircleAttack circlePrefab = Resources.Load<CircleAttack>("Prefabs/Tool/CircleAttack");
    SqrtAttack sqrtPrefab = Resources.Load<SqrtAttack>("Prefabs/Tool/SqrtAttack");

    if (playerHurtPrefab == null || circlePrefab == null || sqrtPrefab == null)
    {
        Debug.LogError("预制体加载失败，请检查路径");
        yield break;
    }

    int createdCount = 0; // 已创建的对象计数

    // 分别创建不足的部分，并分帧
    // 先创建 PlayerHurt
    for (int i = 0; i < needPlayerHurt; i++)
    {
        PlayerHurt playerHurt = Object.Instantiate(playerHurtPrefab, QueueController.S.transform);
        playerHurt.gameObject.SetActive(false);
        QueueController.S.PlayerHurtQueue.Enqueue(playerHurt);
        createdCount++;
        if (createdCount % perFrame == 0)
            yield return null;
    }

    // 创建 CircleAttack
    for (int i = 0; i < needCircle; i++)
    {
        CircleAttack circle = Object.Instantiate(circlePrefab, QueueController.S.transform);
        circle.gameObject.SetActive(false);
        QueueController.S.CircleQueue.Enqueue(circle);
        createdCount++;
        if (createdCount % perFrame == 0)
            yield return null;
    }

    // 创建 SqrtAttack
    for (int i = 0; i < needSqrt; i++)
    {
        SqrtAttack sqrt = Object.Instantiate(sqrtPrefab, QueueController.S.transform);
        sqrt.gameObject.SetActive(false);
        QueueController.S.SqrtQueue.Enqueue(sqrt);
        createdCount++;
        if (createdCount % perFrame == 0)
            yield return null;
    }

    Debug.Log($"PlayerHurt + CircleAttack + SqrtAttack 池预热完成，共实例化 {createdCount} 个对象（目标{targetCapacity}，已有：PlayerHurt={currentPlayerHurt}，Circle={currentCircle}，Sqrt={currentSqrt}）");
}
    
    
public static IEnumerator InitMonsterHurtTextAsync(int perFrame = 10)
{
    const int targetCapacity = 200; // 目标容量

    // 获取当前队列已有的数量
    int currentCount = QueueController.S.MonsterHurtTextQueue.Count;

    // 如果已经达到或超过目标容量，直接跳过
    if (currentCount >= targetCapacity)
    {
        Debug.Log($"MonsterHurtText 池已满（≥{targetCapacity}），无需预热");
        yield break;
    }

    // 计算还需要创建的数量
    int needCount = targetCapacity - currentCount;

    // 提前加载预制体
    GameObject prefab = Resources.Load<GameObject>("Prefabs/Tool/MonsterHurtText");
    if (prefab == null)
    {
        Debug.LogError("预制体 MonsterHurtText 加载失败，请检查路径");
        yield break;
    }

    int createdCount = 0;
    for (int i = 0; i < needCount; i++)
    {
        GameObject monsterHurtText = Object.Instantiate(prefab, QueueController.S.transform);
        monsterHurtText.SetActive(false);
        QueueController.S.MonsterHurtTextQueue.Enqueue(monsterHurtText.GetComponent<MonsterHurtText>());
        createdCount++;

        // 每实例化 perFrame 个，让出一帧
        if (createdCount % perFrame == 0)
            yield return null;
    }

    Debug.Log($"MonsterHurtText 池预热完成，共实例化 {createdCount} 个（目标{targetCapacity}，原有{currentCount}）");
}
    
    public static IEnumerator InitNormalAttackPoolAsync(int perFrame = 10)
{
    WeaponType weaponType = PlayerData.S.playerWeaponType;
    
    // ===== 根据当前武器类型，预先加载所有需要的预制体 =====
    // 为了通用，定义结构存储预制体和对应的队列添加方法
    var tasks = new List<System.Action>();
    
    // 辅助函数：加载 GameObject 预制体并加入队列
    void AddGameObjectTask(string path, Queue<GameObject> queue)
    {
        if (queue.Count > 100)
        {
            return;
        }
        GameObject prefab = Resources.Load<GameObject>(path);
        if (prefab == null)
        {
            Debug.LogError($"预制体加载失败: {path}");
            return;
        }
        tasks.Add(() =>
        {
            GameObject obj = UnityEngine.Object.Instantiate(prefab, QueueController.S.transform);
            obj.SetActive(false);
            queue.Enqueue(obj);
        });
    }
    
    // 辅助函数：加载带组件脚本的预制体并加入队列（队列存储组件）
    void AddComponentTask<T>(string path, Queue<T> queue) where T : Component
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        if (prefab == null)
        {
            Debug.LogError($"预制体加载失败: {path}");
            return;
        }
        T component = prefab.GetComponent<T>();
        if (component == null)
        {
            Debug.LogError($"预制体 {path} 上找不到组件 {typeof(T)}");
            return;
        }
        tasks.Add(() =>
        {
            T instance = UnityEngine.Object.Instantiate(component, QueueController.S.transform);
            instance.gameObject.SetActive(false);
            queue.Enqueue(instance);
        });
    }
    
    // 根据武器类型添加对应的实例化任务
    switch (weaponType)
    {
        case WeaponType.Primary:
            AddGameObjectTask("Prefabs/Skill/NormalAttack/Primary", QueueController.S.PrimaryQueue);
            AddGameObjectTask("Prefabs/Skill/NormalAttack/PuTongPeng3", QueueController.S.PuTong3PengQueue);
            break;
        case WeaponType.LanBao:
            AddGameObjectTask("Prefabs/Skill/2NormalAttackPrefab", QueueController.S.LvQuanQueue);
            break;
        case WeaponType.HeiDong:
            AddGameObjectTask("Prefabs/Skill/NormalAttack/HeiDongPro", QueueController.S.HeiDongQueue);
            AddGameObjectTask("Prefabs/Skill/NormalAttack/HeiDongNext", QueueController.S.HeiDongNextQueue);
            AddGameObjectTask("Prefabs/Skill/NormalAttack/HeiDongPeng", QueueController.S.HeiDongPengQueue);
            break;
        case WeaponType.HuoBaoZha:
            AddComponentTask<HuoBaoZha>("Prefabs/Skill/NormalAttack/HuoBaoZha", QueueController.S.HuoBaoZhaQueue);
            AddComponentTask<HuoYanBaoZhaNext>("Prefabs/Skill/NormalAttack/HuoBaoZhaNext", QueueController.S.HuoYanBaoZhaNextQueue);
            break;
        case WeaponType.IceBaoZha:
            AddComponentTask<IceBaoZha>("Prefabs/Skill/NormalAttack/IceBaoZha", QueueController.S.IceBaoZhaQueue);
            AddComponentTask<IceBaoZhaNext>("Prefabs/Skill/NormalAttack/IceBaoZhaNext", QueueController.S.IceBaoZhaNextQueue);
            break;
        case WeaponType.DianBaoZha:
            AddComponentTask<DianBaoZha>("Prefabs/Skill/NormalAttack/DianBaoZha", QueueController.S.DianBaoZhaQueue);
            AddComponentTask<DianBaoZhaNext>("Prefabs/Skill/NormalAttack/DianBaoZhaNext", QueueController.S.DianBaoZhaNextQueue);
            break;
        case WeaponType.LuoLei:
            AddGameObjectTask("Prefabs/Skill/NormalAttack/LuoLei", QueueController.S.LuoLeiQueue);
            break;
        case WeaponType.PuTong3:
            AddGameObjectTask("Prefabs/Skill/NormalAttack/PuTong3", QueueController.S.PuTong3Queue);
            AddGameObjectTask("Prefabs/Skill/NormalAttack/PuTongPeng3", QueueController.S.PuTong3PengQueue);
            break;
        case WeaponType.Fire:
            AddGameObjectTask("Prefabs/Skill/NormalAttack/Fire", QueueController.S.FireQueue);
            AddGameObjectTask("Prefabs/Skill/NormalAttack/FirePeng", QueueController.S.FirePengQueue);
            AddGameObjectTask("Prefabs/Skill/NormalAttack/FireBaoZha", QueueController.S.FireBaoZha1Queue);
            break;
        case WeaponType.XuKong:
            AddGameObjectTask("Prefabs/Skill/NormalAttack/XuKong", QueueController.S.XuKongQueue);
            AddGameObjectTask("Prefabs/Skill/NormalAttack/XuKongPeng", QueueController.S.XuKongPengQueue);
            break;
        case WeaponType.LvQuan:
            AddGameObjectTask("Prefabs/Skill/NormalAttack/LvQuan", QueueController.S.LvQuanQueue);
            break;
        case WeaponType.JianQi:
            AddComponentTask<PlayerJianQi>("Prefabs/Skill/NormalAttack/PlayerJianQi", QueueController.S.PlayerJianQiQueue);
            AddGameObjectTask("Prefabs/Skill/NormalAttack/ZiPeng", QueueController.S.ZiBaoZhaQueue);
            break;
        default:
            Debug.LogWarning($"未处理的武器类型: {weaponType}");
            yield break;
    }
    
    if (tasks.Count == 0)
    {
        Debug.LogWarning("当前武器类型没有需要预热的普通攻击技能");
        yield break;
    }
    
    // ===== 分帧实例化 100 次 =====
    int totalInstantiated = 0;
    int totalIterations = 100;
    
    for (int i = 0; i < totalIterations; i++)
    {
        // 执行当前轮次的所有实例化任务
        foreach (var task in tasks)
        {
            task();
            totalInstantiated++;
            if (totalInstantiated % perFrame == 0)
                yield return null;
        }
    }
    
    Debug.Log($"普通攻击池预热完成，武器类型: {weaponType}，共实例化 {totalInstantiated} 个对象");
}
    
    
    public static IEnumerator InitPengEffectsAsync(int perFrame = 10)
{
    var a1 = SkillJiaDian.S.Alpha1;
    var a2 = SkillJiaDian.S.Alpha2;
    var a3 = SkillJiaDian.S.Alpha3;
    var a4 = SkillJiaDian.S.Alpha4;
    var a5 = SkillJiaDian.S.Alpha5;
    var weaponYuanSu = WeaponConfig.WeaponYuanSuTypeDic[PlayerData.S.playerWeaponType];

    // 定义需要预热的元素及对应预制体路径、队列
    var elements = new List<(bool needPreload, string path, Queue<GameObject> queue)>();

    // 冰系判定
    bool needIce = weaponYuanSu == YuanSuType.Ice ||
                   a1 == SkillType.Ice1 || a1 == SkillType.Ice2 || a1 == SkillType.Ice3 || a1 == SkillType.Ice4 || a1 == SkillType.Ice5 ||
                   a2 == SkillType.Ice1 || a2 == SkillType.Ice2 || a2 == SkillType.Ice3 || a2 == SkillType.Ice4 || a2 == SkillType.Ice5 ||
                   a3 == SkillType.Ice1 || a3 == SkillType.Ice2 || a3 == SkillType.Ice3 || a3 == SkillType.Ice4 || a3 == SkillType.Ice5 ||
                   a4 == SkillType.Ice1 || a4 == SkillType.Ice2 || a4 == SkillType.Ice3 || a4 == SkillType.Ice4 || a4 == SkillType.Ice5 ||
                   a5 == SkillType.Ice1 || a5 == SkillType.Ice2 || a5 == SkillType.Ice3 || a5 == SkillType.Ice4 || a5 == SkillType.Ice5;
    elements.Add((needIce, "Prefabs/Skill/Peng/IcePeng", QueueController.S.IcePengQueue));

    // 黑暗系判定
    bool needHeiAn = weaponYuanSu == YuanSuType.HeiAn ||
                     a1 == SkillType.HeiAn1 || a1 == SkillType.HeiAn2 || a1 == SkillType.HeiAn3 || a1 == SkillType.HeiAn4 || a1 == SkillType.HeiAn5 ||
                     a2 == SkillType.HeiAn1 || a2 == SkillType.HeiAn2 || a2 == SkillType.HeiAn3 || a2 == SkillType.HeiAn4 || a2 == SkillType.HeiAn5 ||
                     a3 == SkillType.HeiAn1 || a3 == SkillType.HeiAn2 || a3 == SkillType.HeiAn3 || a3 == SkillType.HeiAn4 || a3 == SkillType.HeiAn5 ||
                     a4 == SkillType.HeiAn1 || a4 == SkillType.HeiAn2 || a4 == SkillType.HeiAn3 || a4 == SkillType.HeiAn4 || a4 == SkillType.HeiAn5 ||
                     a5 == SkillType.HeiAn1 || a5 == SkillType.HeiAn2 || a5 == SkillType.HeiAn3 || a5 == SkillType.HeiAn4 || a5 == SkillType.HeiAn5;
    elements.Add((needHeiAn, "Prefabs/Skill/Peng/HeiAnPeng", QueueController.S.HeiAnPengQueue));

    // 火系判定
    bool needHuo = weaponYuanSu == YuanSuType.Huo ||
                   a1 == SkillType.Huo1 || a1 == SkillType.Huo2 || a1 == SkillType.Huo3 || a1 == SkillType.Huo4 || a1 == SkillType.Huo5 ||
                   a2 == SkillType.Huo1 || a2 == SkillType.Huo2 || a2 == SkillType.Huo3 || a2 == SkillType.Huo4 || a2 == SkillType.Huo5 ||
                   a3 == SkillType.Huo1 || a3 == SkillType.Huo2 || a3 == SkillType.Huo3 || a3 == SkillType.Huo4 || a3 == SkillType.Huo5 ||
                   a4 == SkillType.Huo1 || a4 == SkillType.Huo2 || a4 == SkillType.Huo3 || a4 == SkillType.Huo4 || a4 == SkillType.Huo5 ||
                   a5 == SkillType.Huo1 || a5 == SkillType.Huo2 || a5 == SkillType.Huo3 || a5 == SkillType.Huo4 || a5 == SkillType.Huo5;
    elements.Add((needHuo, "Prefabs/Skill/Peng/HuoPeng", QueueController.S.HuoPengQueue));

    // 电系判定
    bool needDian = weaponYuanSu == YuanSuType.Dian ||
                    a1 == SkillType.Dian1 || a1 == SkillType.Dian2 || a1 == SkillType.Dian3 || a1 == SkillType.Dian4 || a1 == SkillType.Dian5 ||
                    a2 == SkillType.Dian1 || a2 == SkillType.Dian2 || a2 == SkillType.Dian3 || a2 == SkillType.Dian4 || a2 == SkillType.Dian5 ||
                    a3 == SkillType.Dian1 || a3 == SkillType.Dian2 || a3 == SkillType.Dian3 || a3 == SkillType.Dian4 || a3 == SkillType.Dian5 ||
                    a4 == SkillType.Dian1 || a4 == SkillType.Dian2 || a4 == SkillType.Dian3 || a4 == SkillType.Dian4 || a4 == SkillType.Dian5 ||
                    a5 == SkillType.Dian1 || a5 == SkillType.Dian2 || a5 == SkillType.Dian3 || a5 == SkillType.Dian4 || a5 == SkillType.Dian5;
    elements.Add((needDian, "Prefabs/Skill/Peng/DianPeng", QueueController.S.DianPengQueue));

    int totalInstantiated = 0;
    const int totalCount = 200;  // 每个元素预热200个

    foreach (var (needPreload, path, queue) in elements)
    {
        if (!needPreload) continue;

        // 预先加载预制体
        GameObject prefab = Resources.Load<GameObject>(path);
        if (prefab == null)
        {
            Debug.LogError($"爆炸特效预制体加载失败: {path}");
            continue;
        }

        // 分帧实例化200个
        for (int i = 0; i < totalCount; i++)
        {
            if (queue.Count > 200)
            {
                break;
            }
            GameObject peng = UnityEngine.Object.Instantiate(prefab, QueueController.S.transform);
            peng.SetActive(false);
            queue.Enqueue(peng);

            totalInstantiated++;
            if (totalInstantiated % perFrame == 0)
                yield return null;  // 每实例化 perFrame 个，让出一帧
        }
    }

    Debug.Log($"爆炸特效池预热完成，共实例化 {totalInstantiated} 个对象");
}
    
    public static IEnumerator InitSpecialWeaponPoolsAsync(int perFrame = 10)
{
    WeaponType currentWeapon = PlayerData.S.playerWeaponType;

    // 定义一个任务：包含实例化并加入队列的动作（无参数，每次调用创建一个对象）
    List<System.Action> tasks = new List<System.Action>();

    // 辅助：添加普通 GameObject 类型任务
    void AddGameObjectTask(string path, Queue<GameObject> queue)
    {
        if (queue.Count > 100)
        {
            return;
        }
        GameObject prefab = Resources.Load<GameObject>(path);
        if (prefab == null)
        {
            Debug.LogError($"预制体加载失败: {path}");
            return;
        }
        tasks.Add(() =>
        {
            GameObject obj = UnityEngine.Object.Instantiate(prefab, QueueController.S.transform);
            obj.SetActive(false);
            queue.Enqueue(obj);
        });
    }

    // 辅助：添加 Component 类型任务（队列存储组件）
    void AddComponentTask<T>(string path, Queue<T> queue) where T : Component
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        if (prefab == null)
        {
            Debug.LogError($"预制体加载失败: {path}");
            return;
        }
        T component = prefab.GetComponent<T>();
        if (component == null)
        {
            Debug.LogError($"预制体 {path} 上找不到组件 {typeof(T)}");
            return;
        }
        tasks.Add(() =>
        {
            T instance = UnityEngine.Object.Instantiate(component, QueueController.S.transform);
            instance.gameObject.SetActive(false);
            queue.Enqueue(instance);
        });
    }

    // 根据武器类型添加对应的预热任务（每个任务代表一次实例化，最终会执行 count 次）
    int count = 100;  // 每个对象预热 100 个

    switch (currentWeapon)
    {
        case WeaponType.HeiAnBaoZha:
            AddGameObjectTask("Prefabs/Skill/NormalAttack/HeiAnBaoZha", QueueController.S.HeiAnBaoZhaQueue);
            AddGameObjectTask("Prefabs/Skill/NormalAttack/HeiAnBaoZhaNext", QueueController.S.HeiAnBaoZhaNextQueue);
            break;

        case WeaponType.Huo7:
            AddComponentTask<Huo7Item>("Prefabs/Skill/NormalAttack/Huo7Item", QueueController.S.Huo7Queue);
            break;

        case WeaponType.Ice7:
            AddComponentTask<Ice7Item>("Prefabs/Skill/NormalAttack/Ice7Item", QueueController.S.Ice7Queue);
            break;

        case WeaponType.DianLuoLei5:
            AddComponentTask<DianLuoLei>("Prefabs/Skill/NormalAttack/DianLuoLei", QueueController.S.DianLuoLeiQueue);
            AddComponentTask<DianLuoLeiNext>("Prefabs/Skill/NormalAttack/DianLuoLeiNext", QueueController.S.DianLuoLeiNextQueue);
            break;

        case WeaponType.PrimaryDian:
            AddComponentTask<PrimaryDian>("Prefabs/Skill/NormalAttack/PrimaryDian", QueueController.S.PrimaryDianQueue);
            break;

        case WeaponType.PrimaryHuo:
            AddComponentTask<PrimaryHuo>("Prefabs/Skill/NormalAttack/PrimaryHuo", QueueController.S.PrimaryHuoQueue);
            break;

        case WeaponType.PrimaryHeiAn:
            AddComponentTask<PrimaryHeiAn>("Prefabs/Skill/NormalAttack/PrimaryHeiAn", QueueController.S.PrimaryHeiAnQueue);
            break;

        case WeaponType.IcePen:
            AddComponentTask<IcePen>("Prefabs/Skill/NormalAttack/IcePen", QueueController.S.IcePenQueue);
            break;

        case WeaponType.HuoFenLie:
            AddComponentTask<HuoFenLie>("Prefabs/Skill/NormalAttack/HuoFenLie", QueueController.S.HuoFenLieQueue);
            AddComponentTask<HuoFenLieDan>("Prefabs/Skill/NormalAttack/HuoFenLieDan", QueueController.S.HuoFenLieDanQueue);
            AddComponentTask<HuoFenLieBaoZha>("Prefabs/Skill/NormalAttack/HuoFenLieBaoZha", QueueController.S.HuoFenLieBaoZhaQueue);
            break;

        case WeaponType.Ice4BaoZha:
            AddComponentTask<Ice4BaoZha>("Prefabs/Skill/NormalAttack/Ice4BaoZha", QueueController.S.Ice4BaoZhaQueue);
            AddComponentTask<Ice4BaoZhaItem>("Prefabs/Skill/NormalAttack/Ice4BaoZhaItem", QueueController.S.Ice4BaoZhaItemQueue);
            break;

        case WeaponType.DianJiSu:
            AddComponentTask<DianJiSu>("Prefabs/Skill/NormalAttack/DianJiSu", QueueController.S.DianJiSuQueue);
            break;

        case WeaponType.HeiAnHuiXuan:
            AddComponentTask<HeiAnHuiXuan>("Prefabs/Skill/NormalAttack/HeiAnHuiXuan", QueueController.S.HeiAnHuiXuanQueue);
            break;

        case WeaponType.HuoDiPen:
            AddComponentTask<HuoDiPen>("Prefabs/Skill/NormalAttack/HuoDiPen", QueueController.S.HuoDiPenQueue);
            break;

        case WeaponType.HeiAnQuXian:
            AddComponentTask<HuoQuXian>("Prefabs/Skill/NormalAttack/HeiAnQuXian", QueueController.S.HeiAnQuXianQueue);
            break;

        default:
            // 当前武器类型不需要特殊预热
            yield break;
    }

    if (tasks.Count == 0)
        yield break;

    // 分帧实例化：每个任务执行 count 次，每 perFrame 次实例化后让出一帧
    int totalInstantiated = 0;
    for (int i = 0; i < count; i++)           // 外层循环100次
    {
        foreach (var task in tasks)           // 内层循环当前武器类型的所有任务
        {
            task();                           // 执行一次实例化+入队
            totalInstantiated++;
            if (totalInstantiated % perFrame == 0)
                yield return null;            // 让主线程处理 UI 动画
        }
    }

    Debug.Log($"特殊武器池预热完成，武器类型: {currentWeapon}，共实例化 {totalInstantiated} 个对象");
}
    
    
    public static IEnumerator InitBaoXueAndDanMuAsync(int perFrame =10)
    {
        // 1. 加载 BaoXue 预制体并获取组件
        GameObject baoXuePrefab = Resources.Load<GameObject>("Prefabs/Monster/BaoXue");
        if (baoXuePrefab == null)
        {
            Debug.LogError("BaoXue 预制体加载失败");
        }
        else
        {
            BaoXue baoXueComp = baoXuePrefab.GetComponent<BaoXue>();
            if (baoXueComp == null)
            {
                Debug.LogError("BaoXue 预制体上没有 BaoXue 组件");
            }
            else
            {
                // 分帧实例化 100 个 BaoXue
                for (int i = 0; i < 100; i++)
                {
                    if (QueueController.S.BaoXueQueue.Count > 100)
                    {
                        break;
                    }
                    BaoXue instance = UnityEngine.Object.Instantiate(baoXueComp, QueueController.S.transform);
                    instance.gameObject.SetActive(false);
                    QueueController.S.BaoXueQueue.Enqueue(instance);

                    if ((i + 1) % perFrame == 0)
                        yield return null;
                }
            }
        }

        // 2. 加载 DanMu 预制体并获取组件
        GameObject danMuPrefab = Resources.Load<GameObject>("Prefabs/MonsterDanMu/DanMu");
        if (danMuPrefab == null)
        {
            Debug.LogError("DanMu 预制体加载失败");
        }
        else
        {
            DanMu danMuComp = danMuPrefab.GetComponent<DanMu>();
            if (danMuComp == null)
            {
                Debug.LogError("DanMu 预制体上没有 DanMu 组件");
            }
            else
            {
                // 分帧实例化 100 个 DanMu（父对象使用 QueueController.S.transform）
                for (int i = 0; i < 100; i++)
                {
                    if (QueueController.S.DanMuQueue.Count > 100)
                    {
                        break;
                    }
                    DanMu instance = UnityEngine.Object.Instantiate(danMuComp, QueueController.S.transform);
                    instance.gameObject.SetActive(false);
                    QueueController.S.DanMuQueue.Enqueue(instance);

                    if ((i + 1) % perFrame == 0)
                        yield return null;
                }
            }
        }

        Debug.Log("BaoXue 和 DanMu 池预热完成，各 100 个");
    }
    
    
    
    public static IEnumerator InitPropQueueAsync(int perFrame = 10)
    {
        var monsterlist = LevelMonsterDic[CurrentGameLevel];
        List<MonsterProp> proplist = new List<MonsterProp>();

        foreach (var item in monsterlist)
        {
            MonsterInfo info = MonsterConfig.MonsterInfoDic[new MonsterDiaoLuoType()
            {
                GameLevel = CurrentGameLevel,
                MonsterType = MonsterConfig.MonsterTypeDic[item]
            }];
            foreach (var item1 in info.MonsterPropList)
            {
                if (!proplist.Contains(item1))
                    proplist.Add(item1);
            }
        }
        int totalInstantiated = 0;
        foreach (var propType in proplist)
        {
            for (int i = 0; i < 20; i++)
            {
                Entrance.InitProp(propType);   // 假设这是同步实例化
                totalInstantiated++;

                // 每实例化 perFrame 个，让出一帧
                if (totalInstantiated % perFrame == 0)
                    yield return null;
            }
        }
    }
    
    public static IEnumerator InitEquipQueueAsync(int perFrame = 10)
    {
        List<MonsterEquip> equiplist = new List<MonsterEquip>();
        var monsterlist = LevelMonsterDic[CurrentGameLevel];

        foreach (var item in monsterlist)
        {
            MonsterInfo info = MonsterConfig.MonsterInfoDic[new MonsterDiaoLuoType()
            {
                GameLevel = CurrentGameLevel,
                MonsterType = MonsterConfig.MonsterTypeDic[item]
            }];
            if (info.orangeEquip == true)
            {
                // 注意：如果 Entrance.InitOrangeQueue() 内部也是大批量实例化，建议也改为异步分帧
                Entrance.InitOrangeQueue();
                yield break;  // 直接退出协程
            }
            else
            {
                foreach (var item1 in info.MonsterEquipList)
                {
                    if (!equiplist.Contains(item1))
                    {
                        equiplist.Add(item1);
                    }
                }
            }
        }

        int totalInstantiated = 0;
        foreach (var equipType in equiplist)
        {
            for (int i = 0; i < 20; i++)
            {
                Entrance.InitEquip(equipType);
                totalInstantiated++;
                if (totalInstantiated % perFrame == 0)
                    yield return null;
            }
        }
    }
}
