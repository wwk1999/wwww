using System.Collections.Generic;

namespace Config
{
    public class WeaponCaiLiao
    {
        public PropConfig.PropType PropType;
        public int Quality;
        public int Count;
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

        public static Dictionary<WeaponType, HunQiEx> HunQiExDic = new Dictionary<WeaponType, HunQiEx>()
        {
            { WeaponType.Primary,new HunQiEx(){Level1 = 30,Level2 = 50,Level3 = 80,Level4 = 120,Level5 = 180}},
            { WeaponType.Du,new HunQiEx(){Level1 = 50,Level2 = 80,Level3 = 120,Level4 = 180,Level5 = 250}},
            { WeaponType.PuTong3,new HunQiEx(){Level1 = 100,Level2 = 150,Level3 = 200,Level4 = 280,Level5 = 400}},
            { WeaponType.XuKong,new HunQiEx(){Level1 = 100,Level2 = 150,Level3 = 200,Level4 = 280,Level5 = 400}},
            { WeaponType.Fire,new HunQiEx(){Level1 = 150,Level2 = 220,Level3 = 300,Level4 = 400,Level5 = 550}},
            { WeaponType.LvQuan,new HunQiEx(){Level1 = 150,Level2 = 220,Level3 = 300,Level4 = 400,Level5 = 550}},
            { WeaponType.HeiDong,new HunQiEx(){Level1 = 200,Level2 = 300,Level3 = 400,Level4 = 550,Level5 = 700}},
            { WeaponType.JianQi,new HunQiEx(){Level1 = 200,Level2 = 300,Level3 = 400,Level4 = 550,Level5 = 700}},
        };

        public static Dictionary<WeaponType, WeaponHunQiDesc> WeaponHunQiDic =
            new Dictionary<WeaponType, WeaponHunQiDesc>()
            {
                { WeaponType.Primary ,new WeaponHunQiDesc(){HunQi1 = "Lv.1:武器伤害+10%",HunQi2 = "Lv.2:基础攻击速度+0.2",HunQi3 = "Lv.3:魔法弹数量+1",HunQi4 = "Lv.4:武器伤害+20%",HunQi5 = "Lv.5:魔法弹数量+1"} },
                { WeaponType.Du ,new WeaponHunQiDesc(){HunQi1 = "Lv.1:武器伤害+10%",HunQi2 = "Lv.2:基础攻击速度+0.2",HunQi3 = "Lv.3:中毒伤害翻倍",HunQi4 = "Lv.4:武器伤害+20%",HunQi5 = "Lv.5:击中生成毒液圈"} },
                { WeaponType.PuTong3 ,new WeaponHunQiDesc(){HunQi1 = "Lv.1:武器伤害+10%",HunQi2 = "Lv.2:基础攻击速度+0.2",HunQi3 = "Lv.3:武器伤害+20%",HunQi4 = "Lv.4:基础攻击速度+0.2",HunQi5 = "Lv.5:魔法弹数量+2"} },
                { WeaponType.XuKong ,new WeaponHunQiDesc(){HunQi1 = "Lv.1:武器伤害+10%",HunQi2 = "Lv.2:基础攻击速度+0.2",HunQi3 = "Lv.3:魔法弹数量+1",HunQi4 = "Lv.4:武器伤害+20%",HunQi5 = "Lv.5:魔法弹数量+1"} },
                { WeaponType.Fire ,new WeaponHunQiDesc(){HunQi1 = "Lv.1:武器伤害+10%",HunQi2 = "Lv.2:基础攻击速度+0.2",HunQi3 = "Lv.3:爆炸造成灼烧效果",HunQi4 = "Lv.4:武器伤害+20%",HunQi5 = "Lv.5:爆炸范围扩大"} },
                { WeaponType.LvQuan ,new WeaponHunQiDesc(){HunQi1 = "Lv.1:武器伤害+10%",HunQi2 = "Lv.2:基础攻击速度+0.2",HunQi3 = "Lv.3:魔法弹大小+20%",HunQi4 = "Lv.4:武器伤害+20%",HunQi5 = "Lv.5:魔法弹数量+1"} },
                { WeaponType.HeiDong ,new WeaponHunQiDesc(){HunQi1 = "Lv.1:武器伤害+10%",HunQi2 = "Lv.2:基础攻击速度+0.2",HunQi3 = "Lv.3:爆炸范围增加20%",HunQi4 = "Lv.4:武器伤害+20%",HunQi5 = "Lv.5:魔法弹数量+1"} },
                { WeaponType.JianQi ,new WeaponHunQiDesc(){HunQi1 = "Lv.1:武器伤害+10%",HunQi2 = "Lv.2:基础攻击速度+0.2",HunQi3 = "Lv.3:剑气数量+1",HunQi4 = "Lv.4:武器伤害+20%",HunQi5 = "Lv.5:剑气数量+1"} }
            };
        
        
        public static Dictionary<WeaponType, WeaponAttribute> WeaponBaseAttributeDic =
            new Dictionary<WeaponType, WeaponAttribute>()
            {
                { WeaponType.Primary ,new WeaponAttribute(){Attack = 10,Crit = 10,Hp = 30,Defense = 5,AttackSpeed = 1}},
                { WeaponType.Du ,new WeaponAttribute(){Attack = 20,Crit = 20,Hp = 50,Defense = 10,AttackSpeed = 1}},
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
                { WeaponType.HuoQuXian ,new WeaponAttribute(){Attack = 150,Crit = 150,Hp = 500,Defense = 80,AttackSpeed = 1f}},

                { WeaponType.HeiDong ,new WeaponAttribute(){Attack = 300,Crit = 300,Hp = 1000,Defense = 150,AttackSpeed = 0.7f}},
                { WeaponType.JianQi ,new WeaponAttribute(){Attack = 200,Crit = 200,Hp = 7000,Defense = 100,AttackSpeed = 3f}},
                { WeaponType.IcePen ,new WeaponAttribute(){Attack = 200,Crit = 200,Hp = 7000,Defense = 100,AttackSpeed = 3f}},
                { WeaponType.DianLuoLei5 ,new WeaponAttribute(){Attack = 200,Crit = 200,Hp = 7000,Defense = 100,AttackSpeed = 3f}},
                { WeaponType.HeiAnHuiXuan ,new WeaponAttribute(){Attack = 200,Crit = 200,Hp = 7000,Defense = 100,AttackSpeed = 3f}},
            };

        public static Dictionary<WeaponType, YuanSuType> WeaponYuanSuTypeDic = new Dictionary<WeaponType, YuanSuType>()
        {
            {WeaponType.Primary,YuanSuType.Ice},
            {WeaponType.Du,YuanSuType.Huo},
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
            {WeaponType.HuoQuXian,YuanSuType.Huo},

        };
        
        
        
        
        
        public static Dictionary<WeaponType, List<WeaponCaiLiao>> JieSuoCaiLiaoDic 
            = new Dictionary<WeaponType, List<WeaponCaiLiao>>()
            {
                { 
                    WeaponType.Du, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 300  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 2,  Count = 3 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 2,  Count = 3 }
                    } 
                },
                
                { 
                    WeaponType.PuTong3, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 500  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 3,  Count = 3 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 3,  Count = 3 }
                    } 
                },
                
                { 
                    WeaponType.XuKong, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 800  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 3,  Count = 5 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 3,  Count = 5 }
                    } 
                },
                
                { 
                    WeaponType.Fire, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 1500  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 4,  Count = 5 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 4,  Count = 5 }
                    } 
                },
                
                { 
                    WeaponType.LvQuan, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 1500  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 4,  Count = 5 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 4,  Count = 5 }
                    } 
                },
                
                { 
                    WeaponType.HeiDong, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 3000  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 5,  Count = 5 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 5,  Count = 5 }
                    } 
                },
                
                { 
                    WeaponType.JianQi, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 3000  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 5,  Count = 5 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 5,  Count = 5 }
                    } 
                },
            };
        
        
        
        
        
        
        
        
         public static Dictionary<WeaponType, List<WeaponCaiLiao>> ShenJiCaiLiaoDic 
            = new Dictionary<WeaponType, List<WeaponCaiLiao>>()
            {
                { 
                    WeaponType.Primary, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 100  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 1,  Count = 3 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 1,  Count = 3 }
                    } 
                },
                { 
                    WeaponType.Du, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 200  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 2,  Count = 2 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 2,  Count = 2 }
                    } 
                },
                
                { 
                    WeaponType.PuTong3, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 300  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 3,  Count = 2 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 3,  Count = 2 }
                    } 
                },
                
                { 
                    WeaponType.XuKong, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 500  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 3,  Count = 3 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 3,  Count = 3 }
                    } 
                },
                
                { 
                    WeaponType.Fire, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 800  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 4,  Count = 3 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 4,  Count = 3 }
                    } 
                },
                
                { 
                    WeaponType.LvQuan, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 1000  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 4,  Count = 5 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 4,  Count = 5 }
                    } 
                },
                
                { 
                    WeaponType.HeiDong, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 1500  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 5,  Count = 3 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 5,  Count = 3 }
                    } 
                },
                
                { 
                    WeaponType.JianQi, 
                    new List<WeaponCaiLiao>()
                    {
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 1500  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 5,  Count = 3 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 5,  Count = 3 }
                    } 
                },
            };
        
    }
}