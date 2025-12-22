using System.Collections.Generic;

namespace Config
{
    public class WeaponCaiLiao
    {
        public PropConfig.PropType PropType;
        public int Quality;
        public int Count;
    }
    public class WeaponConfig
    {
        public static Dictionary<WeaponType, List<WeaponCaiLiao>> CaiLiaoDic 
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
                        new WeaponCaiLiao() { PropType = PropConfig.PropType.WeaponFragment, Quality = 2,  Count = 3 }
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
            };
        
    }
}