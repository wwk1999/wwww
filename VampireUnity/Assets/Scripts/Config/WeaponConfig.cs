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
    public class WeaponConfig
    {
        public static Dictionary<WeaponType, WeaponAttribute> WeaponBaseAttributeDic =
            new Dictionary<WeaponType, WeaponAttribute>()
            {
                { WeaponType.Primary ,new WeaponAttribute(){Attack = 10,Crit = 10,Hp = 30,Defense = 5,AttackSpeed = 1}},
                { WeaponType.Du ,new WeaponAttribute(){Attack = 20,Crit = 20,Hp = 50,Defense = 10,AttackSpeed = 1}},
                { WeaponType.PuTong3 ,new WeaponAttribute(){Attack = 40,Crit = 40,Hp = 100,Defense = 20,AttackSpeed = 1}},
                { WeaponType.XuKong ,new WeaponAttribute(){Attack = 60,Crit = 60,Hp = 150,Defense = 30,AttackSpeed = 1}},
                { WeaponType.Fire ,new WeaponAttribute(){Attack = 100,Crit = 10,Hp = 300,Defense = 50,AttackSpeed = 1}},
                { WeaponType.LvQuan ,new WeaponAttribute(){Attack = 150,Crit = 150,Hp = 500,Defense = 80,AttackSpeed = 0.7f}},
                { WeaponType.HeiDong ,new WeaponAttribute(){Attack = 300,Crit = 300,Hp = 1000,Defense = 150,AttackSpeed = 0.7f}},
                { WeaponType.JianQi ,new WeaponAttribute(){Attack = 200,Crit = 200,Hp = 7000,Defense = 100,AttackSpeed = 3f}},
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
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.LingHun, Quality = 1,  Count = 2000  },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.JingCui, Quality = 4,  Count = 8 },
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 4,  Count = 8 }
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