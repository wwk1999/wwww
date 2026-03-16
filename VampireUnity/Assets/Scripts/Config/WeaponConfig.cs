using System.Collections.Generic;

public enum WeaponTeXiao
{
    None,
    FenLie,
    BaoZha,
    JiSu,
    FanWei,
}
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
            { WeaponType.HeiAnHuiXuan, new List<int>(){200} },
            { WeaponType.HeiAnQuXian, new List<int>(){200} },
            { WeaponType.Ice7, new List<int>(){200} },
            { WeaponType.Ice4BaoZha, new List<int>(){150,200} },
            { WeaponType.JianQi, new List<int>(){200} },
            { WeaponType.HuoDiPen, new List<int>(){300} },
            { WeaponType.IcePen, new List<int>(){300}},
            { WeaponType.HeiDong, new List<int>(){150,300} },
            { WeaponType.DianLuoLei5, new List<int>(){150,260} },
        };


        public static Dictionary<WeaponType, int> WeaponQualityDic = new Dictionary<WeaponType, int>()
        {
            { WeaponType.Primary, 1 },
            { WeaponType.PrimaryDian, 1 },
            { WeaponType.PrimaryHuo, 1 },
            { WeaponType.PrimaryHeiAn, 1 },
            { WeaponType.DianBaoZha, 2 },
            { WeaponType.IceBaoZha, 2 },
            { WeaponType.HuoBaoZha, 2 },
            { WeaponType.HeiAnBaoZha, 2 },
            { WeaponType.XuKong, 3 },//黑暗
            { WeaponType.PuTong3, 3 },//冰
            { WeaponType.Fire, 3 },//电
            { WeaponType.LvQuan, 3 },//火
            { WeaponType.DianJiSu, 4 },
            { WeaponType.DianSanShe, 4 },
            { WeaponType.Huo7, 4 },
            { WeaponType.HuoFenLie, 4 },
            { WeaponType.HeiAnHuiXuan, 4 },
            { WeaponType.HeiAnQuXian, 4 },
            { WeaponType.Ice7, 4 },
            { WeaponType.Ice4BaoZha, 4 },
            { WeaponType.JianQi, 4 },
            { WeaponType.HuoDiPen, 5 },
            { WeaponType.IcePen, 5 },
            { WeaponType.HeiDong, 5 },
            { WeaponType.DianLuoLei5, 5 },
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

        public static Dictionary<int, float> WeaponLevelAttributeDic = new Dictionary<int, float>()
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
            {WeaponType.PrimaryDian,YuanSuType.Dian},
            {WeaponType.PrimaryHuo,YuanSuType.Huo},
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
        
        
        
        
        
        public static Dictionary<WeaponType, List<WeaponCaiLiao>> JieSuoCaiLiaoDic 
            = new Dictionary<WeaponType, List<WeaponCaiLiao>>()
            {
                { 
                    WeaponType.HuoBaoZha, 
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
                    WeaponType.HuoBaoZha, 
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