using System.Collections.Generic;
using UnityEngine;

public enum WeaponCiTiao
{
    None,
    SanShe,
    BaoZha,
    JiSu,
    FanWei,
    ChuanTou,
}
namespace Config
{
    
    public class WeaponCaiLiao
    {
        public PropConfig.PropType PropType;
        public int Quality;
        public int Count;
    }

    public class WeaponJieSuoDesc
    {
        public YuanSuType YuanSuType;
        public int quality;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            WeaponJieSuoDesc other = (WeaponJieSuoDesc)obj;
            return YuanSuType == other.YuanSuType && quality == other.quality;
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(YuanSuType, quality);
        }
    }

    public class WeaponAttribute
    {
        public float Attack;
        public float Crit;
        public float Hp;
        public float Defense;
        public float AttackSpeed;

    }

    public class WeaponHunQiDesc
    {
        public string HunQi1;
        public string HunQi2;
        public string HunQi3;
        public string HunQi4;
        public string HunQi5;
    }

    public class WeaponJieSuoItem
    {
        public  PropConfig.PropType _propType;
        public int quality;
        public int count;
    }

    public class HunQiEx
    {
        public int Level1;
        public int Level2;
        public int Level3;
        public int Level4;
        public int Level5;
    }
    public class WeaponConfig
    {

        public static Dictionary<WeaponType, List<int>> WeaponDamageDic = new Dictionary<WeaponType, List<int>>()
        {
            { WeaponType.Primary, new List<int>(){100} },
            { WeaponType.PrimaryHuo, new List<int>(){100} },
            { WeaponType.PrimaryDian, new List<int>(){100} },
            { WeaponType.PrimaryHeiAn, new List<int>(){100} },
            { WeaponType.IceBaoZha, new List<int>(){100,120} },
            { WeaponType.DianBaoZha, new List<int>(){100,120} },
            { WeaponType.HuoBaoZha, new List<int>(){100,120} },
            { WeaponType.HeiAnBaoZha, new List<int>(){100,120}},
            { WeaponType.XuKong, new List<int>(){150} },
            { WeaponType.PuTong3, new List<int>(){150} },
            { WeaponType.Fire, new List<int>(){100,150} },
            { WeaponType.LvQuan, new List<int>(){150} },
            { WeaponType.DianJiSu, new List<int>(){20} },
            { WeaponType.DianSanShe, new List<int>(){20} },
            { WeaponType.Huo7, new List<int>(){200} },
            { WeaponType.HuoFenLie, new List<int>(){150,200} },
            { WeaponType.HeiAnHuiXuan, new List<int>(){200, 200} },
            { WeaponType.HeiAnQuXian, new List<int>(){200} },
            { WeaponType.Ice7, new List<int>(){200} },
            { WeaponType.Ice4BaoZha, new List<int>(){150,200} },
            { WeaponType.JianQi, new List<int>(){200} },
            { WeaponType.HuoDiPen, new List<int>(){300} },
            { WeaponType.IcePen, new List<int>(){300}},
            { WeaponType.HeiDong, new List<int>(){150,300} },
            { WeaponType.DianLuoLei5, new List<int>(){150,260} },
        };
        
        
        public static Dictionary<WeaponType, List<WeaponCiTiao>> WeaponCiTiaoDic = new Dictionary<WeaponType, List<WeaponCiTiao>>()
        {
            { WeaponType.Primary, new List<WeaponCiTiao>() { WeaponCiTiao.None } },//冰
            { WeaponType.PrimaryDian, new List<WeaponCiTiao>() { WeaponCiTiao.None } },//冰
            { WeaponType.PrimaryHuo, new List<WeaponCiTiao>() { WeaponCiTiao.None } },//冰
            { WeaponType.PrimaryHeiAn, new List<WeaponCiTiao>() { WeaponCiTiao.None } },//冰
            { WeaponType.DianBaoZha, new List<WeaponCiTiao>() { WeaponCiTiao.BaoZha } },//冰
            { WeaponType.HuoBaoZha, new List<WeaponCiTiao>() { WeaponCiTiao.BaoZha } },//冰
            { WeaponType.HeiAnBaoZha, new List<WeaponCiTiao>() { WeaponCiTiao.BaoZha } },//冰
            { WeaponType.IceBaoZha, new List<WeaponCiTiao>() { WeaponCiTiao.BaoZha } },//冰
            { WeaponType.XuKong, new List<WeaponCiTiao>() { WeaponCiTiao.ChuanTou } },//冰
            { WeaponType.PuTong3, new List<WeaponCiTiao>() { WeaponCiTiao.SanShe } },//冰
            { WeaponType.Fire, new List<WeaponCiTiao>() { WeaponCiTiao.BaoZha} },//冰
            { WeaponType.LvQuan, new List<WeaponCiTiao>() { WeaponCiTiao.ChuanTou } },//冰
            { WeaponType.DianJiSu, new List<WeaponCiTiao>() { WeaponCiTiao.JiSu } },//冰
            { WeaponType.DianSanShe, new List<WeaponCiTiao>() { WeaponCiTiao.FanWei } },//冰
            { WeaponType.Huo7, new List<WeaponCiTiao>() { WeaponCiTiao.SanShe } },//冰
            { WeaponType.HuoFenLie, new List<WeaponCiTiao>() { WeaponCiTiao.BaoZha,WeaponCiTiao.FanWei } },//冰
            { WeaponType.HeiAnHuiXuan, new List<WeaponCiTiao>() { WeaponCiTiao.ChuanTou ,WeaponCiTiao.SanShe} },//冰
            { WeaponType.HeiAnQuXian, new List<WeaponCiTiao>() { WeaponCiTiao.JiSu } },//冰
            { WeaponType.Ice7, new List<WeaponCiTiao>() { WeaponCiTiao.SanShe } },//冰
            { WeaponType.Ice4BaoZha, new List<WeaponCiTiao>() { WeaponCiTiao.BaoZha,WeaponCiTiao.FanWei } },//冰
            { WeaponType.JianQi, new List<WeaponCiTiao>() { WeaponCiTiao.JiSu,WeaponCiTiao.ChuanTou } },//冰
            { WeaponType.HuoDiPen, new List<WeaponCiTiao>() { WeaponCiTiao.FanWei } },//冰
            { WeaponType.IcePen, new List<WeaponCiTiao>() { WeaponCiTiao.FanWei } },//冰
            { WeaponType.HeiDong, new List<WeaponCiTiao>() { WeaponCiTiao.ChuanTou,WeaponCiTiao.FanWei,WeaponCiTiao.BaoZha } },//冰
            { WeaponType.DianLuoLei5, new List<WeaponCiTiao>() { WeaponCiTiao.BaoZha,WeaponCiTiao.FanWei } },//冰
        };


        public static Dictionary<WeaponType, int> WeaponQualityDic = new Dictionary<WeaponType, int>()
        {
            { WeaponType.Primary, 1 },//冰
            { WeaponType.PrimaryDian, 1 },//电
            { WeaponType.PrimaryHuo, 1 },//火
            { WeaponType.PrimaryHeiAn, 1 },//黑暗
            { WeaponType.DianBaoZha, 2 },//电
            { WeaponType.IceBaoZha, 2 },//冰
            { WeaponType.HuoBaoZha, 2 },//火
            { WeaponType.HeiAnBaoZha, 2 },//黑暗
            { WeaponType.XuKong, 3 },//黑暗
            { WeaponType.PuTong3, 3 },//冰
            { WeaponType.Fire, 3 },//电
            { WeaponType.LvQuan, 3 },//火
            { WeaponType.DianJiSu, 4 },//电
            { WeaponType.DianSanShe, 4 },//电
            { WeaponType.Huo7, 4 },//火
            { WeaponType.HuoFenLie, 4 },//火
            { WeaponType.HeiAnHuiXuan, 4 },//黑暗
            { WeaponType.HeiAnQuXian, 4 },//黑暗
            { WeaponType.Ice7, 4 },//冰
            { WeaponType.Ice4BaoZha, 4 },//冰
            { WeaponType.JianQi, 4 },//火
            { WeaponType.HuoDiPen, 5 },//火
            { WeaponType.IcePen, 5 },//冰
            { WeaponType.HeiDong, 5 },//黑暗
            { WeaponType.DianLuoLei5, 5 },//电
        };
        
        public static Dictionary<WeaponType, List<WeaponJieSuoItem>> WeaponJieSuoDic = new Dictionary<WeaponType, List<WeaponJieSuoItem>>()
        {
            { WeaponType.HuoBaoZha, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 300},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =2,count = 3},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 2,count = 3}} },//冰
            { WeaponType.IceBaoZha, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 300},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =2,count = 3},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 2,count = 3}} },//冰
            { WeaponType.DianBaoZha, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 300},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =2,count = 3},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 2,count = 3}} },//冰
            { WeaponType.HeiAnBaoZha, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 300},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =2,count = 3},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 2,count = 3}} },//冰
            { WeaponType.XuKong, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 800},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =3,count = 8},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 3,count = 8}} },//冰
            { WeaponType.Fire, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 800},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =3,count = 8},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 3,count = 8}} },//冰
            { WeaponType.PuTong3, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 800},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =3,count = 8},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 3,count = 8}} },//冰
            { WeaponType.LvQuan, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 800},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =3,count = 8},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 3,count = 8}} },//冰
            { WeaponType.DianJiSu, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 2000},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =4,count = 15},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 4,count = 15}} },//冰
            { WeaponType.DianSanShe, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 2000},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =4,count = 15},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 4,count = 15}} },//冰
            { WeaponType.Huo7, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 2000},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =4,count = 15},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 4,count = 15}} },//冰
            { WeaponType.HuoFenLie, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 2000},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =4,count = 15},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 4,count = 15}} },//冰
            { WeaponType.HeiAnHuiXuan, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 2000},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =4,count = 15},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 4,count = 15}} },//冰
            { WeaponType.HeiAnQuXian, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 2000},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =4,count = 15},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 4,count = 15}} },//冰
            { WeaponType.Ice7, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 2000},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =4,count = 15},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 4,count = 15}} },//冰
            { WeaponType.Ice4BaoZha, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 2000},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =4,count = 15},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 4,count = 15}} },//冰
            { WeaponType.JianQi, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 2000},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =4,count = 15},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 4,count = 15}} },//冰
            { WeaponType.HuoDiPen, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 10000},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =5,count = 30},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 5,count = 30}} },//冰
            { WeaponType.IcePen, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 10000},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =5,count = 30},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 5,count = 30}} },//冰
            { WeaponType.HeiDong, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 10000},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =5,count = 30},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 5,count = 30}} },//冰
            { WeaponType.DianLuoLei5, new List<WeaponJieSuoItem>(){new WeaponJieSuoItem(){_propType = PropConfig.PropType.LingHun,count = 10000},new WeaponJieSuoItem(){_propType = PropConfig.PropType.WeaponFragment,quality =5,count = 30},new WeaponJieSuoItem(){_propType = PropConfig.PropType.JingCui,quality = 5,count = 30}} },//冰
        };
        
        public static Dictionary<WeaponType, string> WeaponTeXiaoDic = new Dictionary<WeaponType, string>()
        {
            { WeaponType.Primary, $"释放冰魔法弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.Primary][0]}%</color>的冰霜伤害" },    
            { WeaponType.PrimaryHuo, $"释放火魔法弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.PrimaryHuo][0]}%</color>的火焰伤害" },           
            { WeaponType.PrimaryDian, $"释放电魔法弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.PrimaryDian][0]}%</color>的雷电伤害" },          
            { WeaponType.PrimaryHeiAn, $"释放冰魔法弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.PrimaryHeiAn][0]}%</color>的黑暗伤害" },            
            
            { WeaponType.HuoBaoZha,$"释放火焰爆弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.HuoBaoZha][0]}%</color>的火焰伤害,随后产生小范围爆炸造成<color=green>{WeaponDamageDic[WeaponType.HuoBaoZha][1]}%</color>的火焰伤害"},
            { WeaponType.DianBaoZha,$"释放雷电爆弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.DianBaoZha][0]}%</color>的雷电伤害,随后产生小范围爆炸造成<color=green>{WeaponDamageDic[WeaponType.DianBaoZha][1]}%</color>的雷电伤害"},
            { WeaponType.IceBaoZha,$"释放冰霜爆弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.IceBaoZha][0]}%</color>的冰霜伤害,随后产生小范围爆炸造成<color=green>{WeaponDamageDic[WeaponType.IceBaoZha][1]}%</color>的冰霜伤害"},
            { WeaponType.HeiAnBaoZha,$"释放黑暗爆弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.HeiAnBaoZha][0]}%</color>的黑暗伤害,随后产生小范围爆炸造成<color=green>{WeaponDamageDic[WeaponType.HeiAnBaoZha][1]}%</color>的黑暗伤害"},
            
            { WeaponType.DianJiSu,$"急速释放电光弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.DianJiSu][0]}%</color>的雷电伤害"},
            { WeaponType.DianLuoLei5,$"释放五雷弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.DianLuoLei5][0]}%</color>的雷电伤害，随后召唤5道落雷造成<color=green>{WeaponDamageDic[WeaponType.DianLuoLei5][1]}%</color>的雷电伤害"},
            { WeaponType.DianSanShe,$"持续施放镭射光线，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.DianSanShe][0]}%</color>的雷电伤害"},
            { WeaponType.HuoDiPen,$"召唤火焰炎晶，造成大范围的<color=green>{WeaponDamageDic[WeaponType.HuoDiPen][0]}%</color>的火焰伤害"},
            { WeaponType.Huo7,$"释放七颗炎弹，对命中的敌人造成<color=green>{WeaponDamageDic[WeaponType.Huo7][0]}%</color>的火焰伤害"},
            { WeaponType.HuoFenLie,$"释放爆炎弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.HuoFenLie][0]}%</color>的火焰伤害，随后分裂4个炎弹爆炸造成<color=green>{WeaponDamageDic[WeaponType.HuoFenLie][1]}%</color>的火焰伤害"},
            { WeaponType.HeiAnHuiXuan,$"释放七颗魔力弹穿透敌人造成<color=green>{WeaponDamageDic[WeaponType.HeiAnHuiXuan][0]}%</color>的黑暗伤害，随后回归，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.HeiAnHuiXuan][1]}%</color>的黑暗伤害"},
            { WeaponType.HeiAnQuXian,$"急速释放魔曲弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.HeiAnQuXian][0]}%</color>的黑暗伤害"},
            { WeaponType.Ice7,$"释放七颗冰弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.Ice7][0]}%</color>的冰霜伤害"},
            { WeaponType.Ice4BaoZha,$"释放四象冰弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.Ice4BaoZha][0]}%</color>的冰霜伤害，随后召唤四道冰锥对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.Ice4BaoZha][1]}%</color>的冰霜伤害"},
            { WeaponType.IcePen,$"召唤万里冰霜，造成大范围的<color=green>{WeaponDamageDic[WeaponType.IcePen][0]}%</color>的冰霜伤害"},
            { WeaponType.JianQi,$"急速释放火焰剑气穿透敌人，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.JianQi][0]}%</color>的火焰伤害"},
            { WeaponType.XuKong,$"释放虚空弹穿透敌人，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.XuKong][0]}%</color>的黑暗伤害"},
            { WeaponType.PuTong3,$"释放三颗冰弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.Ice7][0]}%</color>的冰霜伤害"},
            { WeaponType.Fire,$"释放落雷弹，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.Fire][0]}%</color>的雷电伤害,随后召唤一道落雷造成<color=green>{WeaponDamageDic[WeaponType.Fire][1]}%</color>的雷电伤害"},
            { WeaponType.HeiDong,$"释放黑洞缓慢前行，对命中敌人造成<color=green>{WeaponDamageDic[WeaponType.HeiDong][0]}%</color>的黑暗伤害，随后坍塌造成<color=green>{WeaponDamageDic[WeaponType.HeiDong][1]}%</color>的黑暗伤害"},
            { WeaponType.LvQuan,$"释放源火球缓慢前行，对命中的敌人造成<color=green>{WeaponDamageDic[WeaponType.LvQuan][0]}%</color>的火焰伤害"},

        };
        


        public static Dictionary<WeaponType, string> WeaponNameDic = new Dictionary<WeaponType, string>()
        {
            { WeaponType.Primary,"冰原木杖"},
            { WeaponType.PrimaryDian,"电原木杖"},
            { WeaponType.PrimaryHuo,"火原木杖"},
            { WeaponType.PrimaryHeiAn,"黑暗原木杖"},
            
            { WeaponType.HuoBaoZha,"火爆杖"},
            { WeaponType.DianBaoZha,"电爆杖"},
            { WeaponType.IceBaoZha,"冰爆杖"},
            
            { WeaponType.DianJiSu,"电光四射"},
            { WeaponType.DianLuoLei5,"五雷杖"},
            { WeaponType.DianSanShe,"镭射杖"},
            { WeaponType.HuoDiPen,"熔岩杖"},
            { WeaponType.Huo7,"散炎杖"},
            { WeaponType.HuoFenLie,"爆炎杖"},
            { WeaponType.HeiAnHuiXuan,"魔力回旋"},
            { WeaponType.HeiAnQuXian,"魔曲杖"},
            { WeaponType.HeiAnBaoZha,"魔爆杖"},
            { WeaponType.Ice7,"散冰杖"},
            { WeaponType.Ice4BaoZha,"四象冰杖"},
            { WeaponType.IcePen,"万里冰封"},
            { WeaponType.JianQi,"刀光剑影"},
            { WeaponType.XuKong,"虚空杖"},
            { WeaponType.PuTong3,"三叉冰杖"},
            { WeaponType.Fire,"落雷杖"},
            { WeaponType.HeiDong,"黑洞坍塌"},
            { WeaponType.LvQuan,"源极杖"},

        };

        public static Sprite GetWeaponSprite(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Primary:
                    return ResourcesConfig.Primary;
                case WeaponType.PrimaryDian:
                    return ResourcesConfig.PrimaryDian;
                case WeaponType.PrimaryHuo:
                    return ResourcesConfig.PrimaryHuo;
                case WeaponType.PrimaryHeiAn:
                    return ResourcesConfig.PrimaryHeiAn;
                
                case WeaponType.HuoBaoZha:
                    return ResourcesConfig.Du;
                case WeaponType.DianBaoZha:
                    return ResourcesConfig.DianBaoZha;
                case WeaponType.HeiAnBaoZha:
                    return ResourcesConfig.HeiAnBaoZha;
                case WeaponType.IceBaoZha:
                    return ResourcesConfig.IceBaoZha;
                
                case WeaponType.LuoLei:
                    return ResourcesConfig.Fire;
                case WeaponType.XuKong:
                    return ResourcesConfig.XuKong;
                case WeaponType.LvQuan:
                    return ResourcesConfig.LvQuan;
                case WeaponType.PuTong3:
                    return ResourcesConfig.PuTong3;
                case WeaponType.Fire:
                    return ResourcesConfig.Fire;
                
                case WeaponType.Huo7:
                    return ResourcesConfig.Huo7;
                case WeaponType.HuoFenLie:
                    return ResourcesConfig.HuoFenLie;
                case WeaponType.JianQi:
                    return ResourcesConfig.JianQi;
                case WeaponType.HeiAnHuiXuan:
                    return ResourcesConfig.HeiAnHuiXuan;
                case WeaponType.HeiAnQuXian:
                    return ResourcesConfig.HeiAnQuXian;
                case WeaponType.Ice4BaoZha:
                    return ResourcesConfig.Ice4BaoZha;
                case WeaponType.Ice7:
                    return ResourcesConfig.Ice7;
                case WeaponType.DianJiSu:
                    return ResourcesConfig.DianJiSu;
                case WeaponType.DianSanShe:
                    return ResourcesConfig.DianSanShe;
                
                case WeaponType.HuoDiPen:
                    return ResourcesConfig.HuoDiPen;
                case WeaponType.HeiDong:
                    return ResourcesConfig.HeiDong;
                case WeaponType.IcePen:
                    return ResourcesConfig.IcePen;
                case WeaponType.DianLuoLei5:
                    return ResourcesConfig.DianLuoLei5;
            }

            return null;
        }

        public static Dictionary<WeaponJieSuoDesc, string> WeaponJieSuoDescDic =
            new Dictionary<WeaponJieSuoDesc, string>()
            {
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.Ice,quality = 2},$"{WeaponNameDic[WeaponType.Primary]}的等级>5"},
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.Huo,quality = 2},$"{WeaponNameDic[WeaponType.PrimaryHuo]}的等级>5"},
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.Dian,quality = 2},$"{WeaponNameDic[WeaponType.PrimaryDian]}的等级>5"},
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.HeiAn,quality = 2},$"{WeaponNameDic[WeaponType.PrimaryHeiAn]}的等级>5"},
                
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.Ice,quality = 3},$"{WeaponNameDic[WeaponType.IceBaoZha]}的等级>10"},
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.Huo,quality = 3},$"{WeaponNameDic[WeaponType.HuoBaoZha]}的等级>5"},
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.Dian,quality = 3},$"{WeaponNameDic[WeaponType.DianBaoZha]}的等级>5"},
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.HeiAn,quality = 3},$"{WeaponNameDic[WeaponType.HeiAnBaoZha]}的等级>5"},
                
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.Ice,quality = 4},"冰系法杖的总等级>30"},
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.Huo,quality = 4},"火系法杖的总等级>30"}, 
                 {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.Dian,quality = 4},"电系法杖的总等级>30"},
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.HeiAn,quality = 4},"黑暗系法杖的总等级>30"},
                
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.Ice,quality = 5},"冰系法杖的总等级>100"},
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.Huo,quality = 5},"火系法杖的总等级>100"}, 
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.Dian,quality = 5},"电系法杖的总等级>100"},
                {new WeaponJieSuoDesc(){YuanSuType = YuanSuType.HeiAn,quality = 5},"黑暗系法杖的总等级>100"}
            };

        public static Dictionary<float, float> WeaponLevelAttributeDic = new Dictionary<float, float>()
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
        public static Dictionary<WeaponType, WeaponAttribute> WeaponBaseAttributeDic =
            new Dictionary<WeaponType, WeaponAttribute>()
            {
                { WeaponType.Primary ,new WeaponAttribute(){Attack = 10,Crit = 10,Hp = 30,Defense = 5,AttackSpeed = 1}},
                { WeaponType.PrimaryDian ,new WeaponAttribute(){Attack = 10,Crit = 10,Hp = 30,Defense = 5,AttackSpeed = 1}},
                { WeaponType.PrimaryHuo ,new WeaponAttribute(){Attack = 10,Crit = 10,Hp = 30,Defense = 5,AttackSpeed = 1}},
                { WeaponType.PrimaryHeiAn ,new WeaponAttribute(){Attack = 10,Crit = 10,Hp = 30,Defense = 5,AttackSpeed = 1}},
                { WeaponType.DianBaoZha ,new WeaponAttribute(){Attack = 10,Crit = 10,Hp = 30,Defense = 5,AttackSpeed = 1}},
                { WeaponType.IceBaoZha ,new WeaponAttribute(){Attack = 10,Crit = 10,Hp = 30,Defense = 5,AttackSpeed = 1}},
                { WeaponType.HuoBaoZha ,new WeaponAttribute(){Attack = 20,Crit = 20,Hp = 50,Defense = 10,AttackSpeed = 1}},
                { WeaponType.PuTong3 ,new WeaponAttribute(){Attack = 40,Crit = 40,Hp = 100,Defense = 20,AttackSpeed = 1}},
                { WeaponType.XuKong ,new WeaponAttribute(){Attack = 60,Crit = 60,Hp = 150,Defense = 30,AttackSpeed = 1}},
                { WeaponType.HeiAnBaoZha ,new WeaponAttribute(){Attack = 60,Crit = 60,Hp = 150,Defense = 30,AttackSpeed = 1f}},
                { WeaponType.Fire ,new WeaponAttribute(){Attack = 150,Crit = 150,Hp = 500,Defense = 80,AttackSpeed = 1}},
                { WeaponType.LvQuan ,new WeaponAttribute(){Attack = 150,Crit = 150,Hp = 500,Defense = 80,AttackSpeed = 0.7f}},
                { WeaponType.DianSanShe ,new WeaponAttribute(){Attack = 150,Crit = 150,Hp = 500,Defense = 80,AttackSpeed = 1f}},
                { WeaponType.HuoFenLie ,new WeaponAttribute(){Attack = 150,Crit = 150,Hp = 500,Defense = 80,AttackSpeed = 1f}},
                { WeaponType.Huo7 ,new WeaponAttribute(){Attack = 150,Crit = 150,Hp = 500,Defense = 80,AttackSpeed = 1f}},
                { WeaponType.Ice4BaoZha ,new WeaponAttribute(){Attack = 150,Crit = 150,Hp = 500,Defense = 80,AttackSpeed = 1f}},
                { WeaponType.Ice7 ,new WeaponAttribute(){Attack = 150,Crit = 150,Hp = 500,Defense = 80,AttackSpeed = 1f}},
                { WeaponType.DianJiSu ,new WeaponAttribute(){Attack = 150,Crit = 150,Hp = 500,Defense = 80,AttackSpeed = 1f}},
                { WeaponType.HeiAnQuXian ,new WeaponAttribute(){Attack = 150,Crit = 150,Hp = 500,Defense = 80,AttackSpeed = 1f}},
                { WeaponType.HuoDiPen ,new WeaponAttribute(){Attack = 150,Crit = 150,Hp = 500,Defense = 80,AttackSpeed = 1f}},
                { WeaponType.HeiDong ,new WeaponAttribute(){Attack = 300,Crit = 300,Hp = 1000,Defense = 150,AttackSpeed = 0.7f}},
                { WeaponType.JianQi ,new WeaponAttribute(){Attack = 200,Crit = 200,Hp = 7000,Defense = 100,AttackSpeed = 3f}},
                { WeaponType.IcePen ,new WeaponAttribute(){Attack = 200,Crit = 200,Hp = 7000,Defense = 100,AttackSpeed = 3f}},
                { WeaponType.DianLuoLei5 ,new WeaponAttribute(){Attack = 200,Crit = 200,Hp = 7000,Defense = 100,AttackSpeed = 3f}},
                { WeaponType.HeiAnHuiXuan ,new WeaponAttribute(){Attack = 200,Crit = 200,Hp = 7000,Defense = 100,AttackSpeed = 3f}},
            };

        public static Dictionary<WeaponType, YuanSuType> WeaponYuanSuTypeDic = new Dictionary<WeaponType, YuanSuType>()
        {
            {WeaponType.Primary,YuanSuType.Ice},
            {WeaponType.PrimaryHuo,YuanSuType.Huo},
            {WeaponType.PrimaryDian,YuanSuType.Dian},
            {WeaponType.PrimaryHeiAn,YuanSuType.HeiAn},
            {WeaponType.DianBaoZha,YuanSuType.Dian},
            {WeaponType.IceBaoZha,YuanSuType.Ice},
            {WeaponType.HuoBaoZha,YuanSuType.Huo},
            {WeaponType.PuTong3,YuanSuType.Ice},
            {WeaponType.XuKong,YuanSuType.Dian},
            {WeaponType.Fire,YuanSuType.Dian},
            {WeaponType.LvQuan,YuanSuType.HeiAn},
            {WeaponType.HeiDong,YuanSuType.HeiAn},
            {WeaponType.JianQi,YuanSuType.Huo},
            {WeaponType.DianSanShe,YuanSuType.Dian},
            {WeaponType.HeiAnBaoZha,YuanSuType.HeiAn},
            {WeaponType.Huo7,YuanSuType.Huo},
            {WeaponType.HuoFenLie,YuanSuType.Huo},
            {WeaponType.Ice4BaoZha,YuanSuType.Ice},
            {WeaponType.Ice7,YuanSuType.Ice},
            {WeaponType.IcePen,YuanSuType.Ice},
            {WeaponType.DianLuoLei5,YuanSuType.Dian},
            {WeaponType.DianJiSu,YuanSuType.Dian},
            {WeaponType.HeiAnHuiXuan,YuanSuType.HeiAn},
            {WeaponType.HeiAnQuXian,YuanSuType.HeiAn},
            {WeaponType.HuoDiPen,YuanSuType.Huo},
        };
    }
}