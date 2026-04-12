using System.Collections;
using System.Collections.Generic;
using Equip;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterInfo
{
    public float attack;
    public float defence;
    public float hp;
    public float ex;
    public float linghun;
    public bool orangeEquip=false;
    public List<MonsterEquip>  MonsterEquipList=new List<MonsterEquip>();
    public List<MonsterProp>  MonsterPropList=new List<MonsterProp>();
}

public class MonsterDiaoLuoType
{
    public int GameLevel;
    public MonsterType MonsterType;
    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        
        MonsterDiaoLuoType other = (MonsterDiaoLuoType)obj;
        return GameLevel == other.GameLevel && MonsterType == other.MonsterType;
    }
    
    public override int GetHashCode()
    {
        return GameLevel.GetHashCode() ^ MonsterType.GetHashCode();
    }
}

public class MonsterConfig
{
   public static Dictionary<MonsterTypeByName, MonsterType> MonsterTypeDic =
    new Dictionary<MonsterTypeByName, MonsterType>()
    {
        // ========== 普通怪 (Normal) ==========
        { MonsterTypeByName.None, MonsterType.Normal },
        { MonsterTypeByName.Snot, MonsterType.Normal },
        { MonsterTypeByName.Bat, MonsterType.Normal },
        { MonsterTypeByName.Spider, MonsterType.Normal },
        { MonsterTypeByName.Bee, MonsterType.Normal },
        { MonsterTypeByName.TreeMan, MonsterType.Normal },
        { MonsterTypeByName.XiaoHuo, MonsterType.Normal },
        { MonsterTypeByName.DaZui, MonsterType.Normal },
        { MonsterTypeByName.DunDi, MonsterType.Normal },
        { MonsterTypeByName.ChongZi, MonsterType.Normal },
        { MonsterTypeByName.ShiRenHua, MonsterType.Normal },
        { MonsterTypeByName.JiaChong, MonsterType.Normal },
        { MonsterTypeByName.WenZi, MonsterType.Normal },
        { MonsterTypeByName.ShaChong, MonsterType.Normal },
        { MonsterTypeByName.ShaNiao, MonsterType.Normal },
        { MonsterTypeByName.ShaXiYi, MonsterType.Normal },
        { MonsterTypeByName.XianRenZhang, MonsterType.Normal },
        { MonsterTypeByName.XieZi, MonsterType.Normal },
        { MonsterTypeByName.XueRen, MonsterType.Normal },
        { MonsterTypeByName.XueZhangLang, MonsterType.Normal },
        { MonsterTypeByName.XueQiE, MonsterType.Normal },
        { MonsterTypeByName.YingShu, MonsterType.Normal },
        { MonsterTypeByName.QingWa, MonsterType.Normal },
        
        // 小怪系列
        { MonsterTypeByName.ChaiLangRen1, MonsterType.Normal },
        { MonsterTypeByName.ChaiLangRen2, MonsterType.Normal },
        { MonsterTypeByName.ChaiLangRen3, MonsterType.Normal },
        { MonsterTypeByName.ChaiLangRen4, MonsterType.Normal },
        { MonsterTypeByName.CiZhu, MonsterType.Normal },
        { MonsterTypeByName.DaoCaoRen, MonsterType.Normal },
        { MonsterTypeByName.DiJing2, MonsterType.Normal },
        { MonsterTypeByName.DiJing3, MonsterType.Normal },
        { MonsterTypeByName.DiJingShouWei1, MonsterType.Normal },
        { MonsterTypeByName.DiJingShouWei2, MonsterType.Normal },
        { MonsterTypeByName.DiJingShouWei3, MonsterType.Normal },
        { MonsterTypeByName.KuLou1, MonsterType.Normal },
        { MonsterTypeByName.KuLou2, MonsterType.Normal },
        { MonsterTypeByName.KuLou3, MonsterType.Normal },
        { MonsterTypeByName.KuLou4, MonsterType.Normal },
        { MonsterTypeByName.KuLou5, MonsterType.Normal },
        { MonsterTypeByName.KuLou6, MonsterType.Normal },
        { MonsterTypeByName.LuJiaoCiKe1, MonsterType.Normal },
        { MonsterTypeByName.LuJiaoCiKe2, MonsterType.Normal },
        { MonsterTypeByName.ShanZei3, MonsterType.Normal },
        { MonsterTypeByName.ShiJiaChong, MonsterType.Normal },
        { MonsterTypeByName.ShiShiGui, MonsterType.Normal },
        { MonsterTypeByName.ShiXiangGui, MonsterType.Normal },
        { MonsterTypeByName.ShuangTouLong1, MonsterType.Normal },
        { MonsterTypeByName.ShuangTouLong2, MonsterType.Normal },
        { MonsterTypeByName.ShuangTouLong3, MonsterType.Normal },
        { MonsterTypeByName.TuJiu, MonsterType.Normal },
        { MonsterTypeByName.WuYa, MonsterType.Normal },
        { MonsterTypeByName.YouLang, MonsterType.Normal },
        { MonsterTypeByName.YouLing1, MonsterType.Normal },
        { MonsterTypeByName.YouLing2, MonsterType.Normal },
        { MonsterTypeByName.YuRen1, MonsterType.Normal },
        { MonsterTypeByName.YuRen2, MonsterType.Normal },
        { MonsterTypeByName.YuRen3, MonsterType.Normal },
        
        // ========== 精英怪 (Elite) ==========
        { MonsterTypeByName.DaZongXiong, MonsterType.Elite },
        { MonsterTypeByName.DiJingZhangLao, MonsterType.Elite },
        { MonsterTypeByName.FengHeGuai, MonsterType.Elite },
        { MonsterTypeByName.KuangShiMuZhu, MonsterType.Elite },
        { MonsterTypeByName.LuJiaoDouShi, MonsterType.Elite },
        { MonsterTypeByName.RongYanGuai, MonsterType.Elite },
        { MonsterTypeByName.ShuangTouRen, MonsterType.Elite },
        { MonsterTypeByName.YeShouZhanShi, MonsterType.Elite },
        { MonsterTypeByName.ZhiZhuNvWang, MonsterType.Elite },
        { MonsterTypeByName.ShouRen1, MonsterType.Elite },
        { MonsterTypeByName.ShouRen2, MonsterType.Elite },
        { MonsterTypeByName.ShouRen3, MonsterType.Elite },
        { MonsterTypeByName.YouHunLingZhu, MonsterType.Elite },
        { MonsterTypeByName.NiuTouRen1, MonsterType.Elite },
        { MonsterTypeByName.NiuTouRen2, MonsterType.Elite },
        { MonsterTypeByName.NiuTouRen3, MonsterType.Elite },
        { MonsterTypeByName.HeiXiong, MonsterType.Elite },
        { MonsterTypeByName.JianChiZhu, MonsterType.Elite },

        
        // ========== BOSS ==========
        { MonsterTypeByName.HuoShanBoss, MonsterType.Boss },
        { MonsterTypeByName.ZhaoZeBoss, MonsterType.Boss },
        { MonsterTypeByName.XueRenBoss, MonsterType.Boss },
        { MonsterTypeByName.ShiRenBoss, MonsterType.Boss },
        { MonsterTypeByName.ShiFuBoss, MonsterType.Boss },
        { MonsterTypeByName.WuYaoZhiWang, MonsterType.Boss },
        { MonsterTypeByName.WuYaoZhiWang2, MonsterType.Boss },
        
        
        // ========== 异界怪物 - 小怪 ==========
        { MonsterTypeByName.DaLong, MonsterType.Normal },
        { MonsterTypeByName.Emo1, MonsterType.Normal },
        { MonsterTypeByName.Emo2, MonsterType.Normal },
        { MonsterTypeByName.Emo3, MonsterType.Normal },
        { MonsterTypeByName.HongLong1, MonsterType.Normal },
        { MonsterTypeByName.HongLong2, MonsterType.Normal },
        { MonsterTypeByName.HongLong3, MonsterType.Normal },
        { MonsterTypeByName.LanLong1, MonsterType.Normal },
        { MonsterTypeByName.LanLong2, MonsterType.Normal },
        { MonsterTypeByName.LanLong3, MonsterType.Normal },
        { MonsterTypeByName.LvLang, MonsterType.Normal },
        { MonsterTypeByName.LvLong1, MonsterType.Normal },
        { MonsterTypeByName.LvLong2, MonsterType.Normal },
        { MonsterTypeByName.LvLong3, MonsterType.Normal },
        
        // ========== 异界怪物 - BOSS ==========
        { MonsterTypeByName.LeiShou, MonsterType.Boss },
        { MonsterTypeByName.KuiJia, MonsterType.Boss },
        { MonsterTypeByName.HuoLang, MonsterType.Boss },
        { MonsterTypeByName.BaoZi, MonsterType.Boss },
        { MonsterTypeByName.ShuangDao, MonsterType.Boss },
    };
    public static Dictionary<MonsterDiaoLuoType, MonsterInfo> MonsterInfoDic =
        new Dictionary<MonsterDiaoLuoType, MonsterInfo>()
        {
            {
                new MonsterDiaoLuoType() { GameLevel = 3, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 3, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 3, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 6, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 6, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 6, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 9, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 9, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 9, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 12, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 12, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 12, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 15, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 15, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 15, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 16, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 16, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 16, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 17, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 17, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 17, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 18, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 18, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 18, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 19, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 19, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 19, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 20, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 20, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 20, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 21, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 21, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 21, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 22, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 22, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 22, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 23, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 23, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 23, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 24, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 24, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 24, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 25, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 25, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 25, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 26, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 26, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 26, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 27, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 27, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 27, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 28, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 28, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 28, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 29, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 29, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 29, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 30, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 30, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 30, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 101, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 101, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 101, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 102, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 102, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 102, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 103, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 103, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 103, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 104, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 104, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 104, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 105, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 105, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 105, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 106, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 106, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 106, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 201, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 201, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 201, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 202, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 202, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 202, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 203, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 203, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 203, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 204, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 204, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 204, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 205, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 205, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 205, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 206, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 206, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 206, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
           
            
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 301, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 301, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 301, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 302, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 302, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 302, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 303, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 303, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 303, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 304, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 304, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 304, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 305, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 305, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 305, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 306, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 306, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 306, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },

        };

}
