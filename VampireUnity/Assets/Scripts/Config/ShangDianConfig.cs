using System.Collections.Generic;

public class ShangDianConfig
{
    public class ShangPingItem
    {
        public PropConfig.PropType type;
        public int quality;
    }

    public static List<ShangPingItem> NormalShangDian = new List<ShangPingItem>()
    {
        new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 1},
        new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 2},
        new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 3},
        new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 4},


        new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 1},
        new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 2},
        new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 3},
        new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 5},

        
        new ShangPingItem(){type = PropConfig.PropType.ChongWuDan,quality = 3},
        new ShangPingItem(){type = PropConfig.PropType.XiSuiYe,quality = 3},
        new ShangPingItem(){type = PropConfig.PropType.XueMaiDan,quality = 3},
        
        new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 1},
        new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 2},
        new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 3},
        new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 4},

        
        new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 1},
        new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 2},
        new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 3},
        new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 4},

    };
    
    
    public static List<ShangPingItem> GaoJiShangDian = new List<ShangPingItem>()
    {
        new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 6},

        new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 6},
        
        new ShangPingItem(){type = PropConfig.PropType.ChongWuDan,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.XiSuiYe,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.XueMaiDan,quality = 5},
        
        new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 6},

        
        new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 6},
      
        new ShangPingItem(){type = PropConfig.PropType.ExYaoShui,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.DiaoLuoYaoShui,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.DaKongShi,quality = 5},

    };

    public static Dictionary<ShangPingItem,int> ShangPingDic =
        new Dictionary<ShangPingItem,int>()
        {
            { new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 1},10 },
            { new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 2},30 },
            { new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 3},100 },
            { new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 4},250 },
            { new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 5},500 },
            { new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 6},1000 },
            
            { new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 1},10 },
            { new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 2},30 },
            { new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 3},100 },
            { new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 4},250 },
            { new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 5},500 },
            { new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 6},1000 },
            
            { new ShangPingItem(){type = PropConfig.PropType.ChongWuDan,quality = 3},200 },
            { new ShangPingItem(){type = PropConfig.PropType.ChongWuDan,quality = 5},1000 },
            
            { new ShangPingItem(){type = PropConfig.PropType.XiSuiYe,quality = 3},100 },
            { new ShangPingItem(){type = PropConfig.PropType.XiSuiYe,quality = 5},300 },

            { new ShangPingItem(){type = PropConfig.PropType.XueMaiDan,quality = 3},100 },
            { new ShangPingItem(){type = PropConfig.PropType.XueMaiDan,quality = 5},300 },
            
            { new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 1},10 },
            { new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 2},25 },
            { new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 3},50 },
            { new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 4},100 },
            { new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 5},300 },
            
            { new ShangPingItem(){type = PropConfig.PropType.ExYaoShui,quality = 4},200 },
            { new ShangPingItem(){type = PropConfig.PropType.DiaoLuoYaoShui,quality = 4},200 },

            { new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 1},100 },
            { new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 2},250 },
            { new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 3},500 },
            { new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 4},1000 },
            { new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 5},2000 },
            { new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 6},5000 },

            { new ShangPingItem(){type = PropConfig.PropType.DaKongShi,quality = 5},2500 },
        };
}
