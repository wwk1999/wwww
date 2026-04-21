using System.Collections;
using System.Collections.Generic;
using Equip;
using NUnit.Framework;
using UnityEngine;

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

    public static Dictionary<int, List<ChongWuDiaoLuoItem>> ChongWuDiaoLuoDic = new Dictionary<int, List<ChongWuDiaoLuoItem>>()
    {
        {1,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 1}}},
        {2,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 2}}},
        {3,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 3}}},
        {4,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 4},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 4}}},
        {5,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 4},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 4},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 5,},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 5},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 5}}},
        {6,new List<ChongWuDiaoLuoItem>(){new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 1},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 2},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 3},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 4},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 4},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuDan,Quality = 5,},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 5},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 5},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.ChongWuShiWu,Quality = 6},new ChongWuDiaoLuoItem(){type = PropConfig.PropType.SkillShu,Quality = 6}}},
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
        case MonsterTypeByName.cat:
            return GameController.S.catQueue.Dequeue();
        case MonsterTypeByName.egg:
            return GameController.S.eggQueue.Dequeue();
        case MonsterTypeByName.lang:
            return GameController.S.langQueue.Dequeue();
        case MonsterTypeByName.mogu:
            return GameController.S.moguQueue.Dequeue();
        case MonsterTypeByName.niguai1:
            return GameController.S.niguai1Queue.Dequeue();
        case MonsterTypeByName.niguai2:
            return GameController.S.niguai2Queue.Dequeue();
        case MonsterTypeByName.niguai3:
            return GameController.S.niguai3Queue.Dequeue();
        case MonsterTypeByName.onyx:
            return GameController.S.onyxQueue.Dequeue();
        case MonsterTypeByName.queen:
            return GameController.S.queenQueue.Dequeue();
        case MonsterTypeByName.shanyang:
            return GameController.S.shanyangQueue.Dequeue();
        case MonsterTypeByName.she:
            return GameController.S.sheQueue.Dequeue();
        case MonsterTypeByName.woniu:
            return GameController.S.woniuQueue.Dequeue();
        case MonsterTypeByName.xiaohuoling:
            return GameController.S.xiaohuolingQueue.Dequeue();
        case MonsterTypeByName.xiaozhizhu:
            return GameController.S.xiaozhizhuQueue.Dequeue();
        case MonsterTypeByName.xiaoshuguai:
            return GameController.S.xiaoshuguaiQueue.Dequeue();
        case MonsterTypeByName.xiezi1:
            return GameController.S.xiezi1Queue.Dequeue();
        case MonsterTypeByName.xiezi2:
            return GameController.S.xiezi2Queue.Dequeue();
        case MonsterTypeByName.xuelaoshu:
            return GameController.S.xuelaoshuQueue.Dequeue();
        case MonsterTypeByName.yanshu:
            return GameController.S.yanshuQueue.Dequeue();
        case MonsterTypeByName.yezhu:
            return GameController.S.yezhuQueue.Dequeue();
        case MonsterTypeByName.zibaolaoshu:
            return GameController.S.zibaolaoshuQueue.Dequeue();
        
        
        
        
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
        
        case MonsterTypeByName.banrenma1:
            return GameController.S.banrenma1Queue.Dequeue();
        case MonsterTypeByName.banrenma2:
            return GameController.S.banrenma2Queue.Dequeue();
        case MonsterTypeByName.banrenma3:
            return GameController.S.banrenma3Queue.Dequeue();
        case MonsterTypeByName.paopao:
            return GameController.S.paopaoQueue.Dequeue();
        case MonsterTypeByName.rongyanboss:
            return GameController.S.rongyanbossQueue.Dequeue();
        case MonsterTypeByName.xiongbuou:
            return GameController.S.xiongbuouQueue.Dequeue();
        case MonsterTypeByName.zhumodaocaoren:
            return GameController.S.zhumodaocaorenQueue.Dequeue();
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
    
    public static Dictionary<int, List<MonsterTypeByName>> LevelMonsterDic =
        new Dictionary<int, List<MonsterTypeByName>>()
        {
            {3,new List<MonsterTypeByName>() { MonsterTypeByName.ChaiLangRen4 ,MonsterTypeByName.xiongbuou,MonsterTypeByName.niguai1}},
            {6,new List<MonsterTypeByName>() { MonsterTypeByName.ChongZi ,MonsterTypeByName.DunDi,MonsterTypeByName.DaZui,MonsterTypeByName.XiaoHuo,MonsterTypeByName.HuoShanBoss}},
            {9,new List<MonsterTypeByName>() { MonsterTypeByName.ZhaoZeBoss ,MonsterTypeByName.ShiRenHua,MonsterTypeByName.WenZi,MonsterTypeByName.QingWa,MonsterTypeByName.JiaChong}},
            {12,new List<MonsterTypeByName>() { MonsterTypeByName.ShaChong ,MonsterTypeByName.ShaNiao,MonsterTypeByName.ShaXiYi,MonsterTypeByName.XianRenZhang,MonsterTypeByName.XieZi}},
            {15,new List<MonsterTypeByName>() { MonsterTypeByName.XueZhangLang ,MonsterTypeByName.XueQiE,MonsterTypeByName.YingShu,MonsterTypeByName.XueRen,MonsterTypeByName.XueRenBoss}},
            
            {16,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {17,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {18,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {19,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {20,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {21,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {22,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {23,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {24,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {25,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {26,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {27,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {28,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {29,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {30,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {31,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {32,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {33,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {34,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            {35,new List<MonsterTypeByName>() { MonsterTypeByName.Snot ,MonsterTypeByName.Spider,MonsterTypeByName.Bat,MonsterTypeByName.Bee,MonsterTypeByName.TreeMan}},
            
            
            {101,new List<MonsterTypeByName>() { MonsterTypeByName.cat ,MonsterTypeByName.egg,MonsterTypeByName.paopao}},
            {102,new List<MonsterTypeByName>() { MonsterTypeByName.CiZhu ,MonsterTypeByName.she,MonsterTypeByName.banrenma1}},
            {103,new List<MonsterTypeByName>() { MonsterTypeByName.YouLang ,MonsterTypeByName.onyx,MonsterTypeByName.banrenma2}},
            {104,new List<MonsterTypeByName>() { MonsterTypeByName.TuJiu ,MonsterTypeByName.WuYa,MonsterTypeByName.banrenma3}},
            {105,new List<MonsterTypeByName>() { MonsterTypeByName.xuelaoshu ,MonsterTypeByName.lang,MonsterTypeByName.xiongbuou}},
            {106,new List<MonsterTypeByName>() { MonsterTypeByName.xiezi1 ,MonsterTypeByName.xiezi2,MonsterTypeByName.zhumodaocaoren}},

            
            {201,new List<MonsterTypeByName>() { MonsterTypeByName.YuRen1 ,MonsterTypeByName.KuLou1,MonsterTypeByName.ShouRen1}},
            {202,new List<MonsterTypeByName>() { MonsterTypeByName.YuRen2 ,MonsterTypeByName.KuLou2,MonsterTypeByName.ShouRen2}},
            {203,new List<MonsterTypeByName>() { MonsterTypeByName.YuRen3 ,MonsterTypeByName.KuLou3,MonsterTypeByName.ShouRen3}},
            {204,new List<MonsterTypeByName>() { MonsterTypeByName.niguai1 ,MonsterTypeByName.KuLou4,MonsterTypeByName.NiuTouRen1}},
            {205,new List<MonsterTypeByName>() { MonsterTypeByName.niguai2 ,MonsterTypeByName.KuLou5,MonsterTypeByName.NiuTouRen2}},
            {206,new List<MonsterTypeByName>() { MonsterTypeByName.niguai3 ,MonsterTypeByName.KuLou6,MonsterTypeByName.NiuTouRen3}},

            
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

    public static void InitMonsterQueue()
    {
        var monsterlist = LevelMonsterDic[CurrentGameLevel];
        foreach (var item in monsterlist)
        {
            int count = 0;
            if (MonsterConfig.MonsterTypeDic[item] == MonsterType.Normal)
            {
                count = 150;
            }
            if (MonsterConfig.MonsterTypeDic[item] == MonsterType.Elite)
            {
                count = 15;
            }

            for (int i = 0; i < count; i++)
            {
                Entrance.InitMonster(item);
            }
        }
    }

    public static void InitPropQueue()
    {
        var monsterlist = LevelMonsterDic[CurrentGameLevel];
        List<MonsterProp> proplist = new List<MonsterProp>();
        foreach (var item in monsterlist)
        {
            MonsterInfo info = MonsterConfig.MonsterInfoDic[new MonsterDiaoLuoType() { GameLevel = CurrentGameLevel, MonsterType = MonsterConfig.MonsterTypeDic[item] }];
            foreach (var item1 in info.MonsterPropList)
            {
                if (!proplist.Contains(item1))
                {
                    proplist.Add(item1);
                }
            }
        }
        foreach (var item in proplist)
        {
            for (int i = 0; i < 20; i++)
            {
                Entrance.InitProp(item);
            }
        }
    }
   

    public static void InitEquipQueue()
    {
        List<MonsterEquip> equiplist = new List<MonsterEquip>();
        var monsterlist = LevelMonsterDic[CurrentGameLevel];
        
        foreach (var item in monsterlist)
        {
            MonsterInfo info=MonsterConfig.MonsterInfoDic[new MonsterDiaoLuoType(){GameLevel = CurrentGameLevel,MonsterType = MonsterConfig.MonsterTypeDic[item]}];
            if (info.orangeEquip == true)
            {
                Entrance.InitOrangeQueue();
                return;
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

        foreach (var item in equiplist)
        {
            for (int i = 0; i < 20; i++)
            {
                Entrance.InitEquip(item);
            }
        }
    }
}
