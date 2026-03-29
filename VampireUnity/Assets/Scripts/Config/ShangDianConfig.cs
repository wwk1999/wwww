using System.Collections.Generic;
using UnityEngine;

public class ShangDianConfig
{
    public class ShangPingItem
    {
        public PropConfig.PropType type;
        public int quality;

        public override int GetHashCode()
        {
            return type.GetHashCode() ^ quality.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ShangPingItem other = (ShangPingItem)obj;
            return type == other.type && quality == other.quality;
        }
    }

    public static Sprite GetShangPingSprite(ShangPingItem item)
    {
        switch (item.type)
      {
         case PropConfig.PropType.WeaponFragment:
            switch (item.quality)
            {
               case 1:
                  return ResourcesConfig.WhiteWeaponFragment;
                  break;
               case 2:
                  return ResourcesConfig.GreenWeaponFragment;
                  break;
               case 3:
                  return ResourcesConfig.BlueWeaponFragment;
                  break;
               case 4:
                  return ResourcesConfig.PurpleWeaponFragment;
                  break;
               case 5:
                  return ResourcesConfig.OrangeWeaponFragment;
                  break;
               case 6:
                  return ResourcesConfig.RedWeaponFragment;
                  break;
            }

            break;
         case PropConfig.PropType.ChiBang:
            switch (item.quality)
            {
               case 1:
                  return ResourcesConfig.WhiteChiBang;
                  break;
               case 2:
                  return ResourcesConfig.GreenChiBang;
                  break;
               case 3:
                  return ResourcesConfig.BlueChiBang;
                  break;
               case 4:
                  return ResourcesConfig.PurpleChiBang;
                  break;
               case 5:
                  return ResourcesConfig.OrangeChiBang;
                  break;
               case 6:
                  return ResourcesConfig.RedChiBang;
                  break;
            }

            break;
         case PropConfig.PropType.ChongWuDan:
            switch (item.quality)
            {
               case 3:
                  return ResourcesConfig.NormalChongWuDan;
                  break;
               case 5:
                  return ResourcesConfig.GaoJiChongWuDan;
                  break;
            }

            break;

         case PropConfig.PropType.XiSuiYe:
            switch (item.quality)
            {
               case 3:
                  return ResourcesConfig.NormalXiSuiYe;
                  break;
               case 5:
                  return ResourcesConfig.GaoJiXiSuiYe;
                  break;
            }

            break;

         case PropConfig.PropType.XueMaiDan:
            switch (item.quality)
            {
               case 3:
                  return ResourcesConfig.NormalXueMaiDan;
                  break;
               case 5:
                  return ResourcesConfig.GaoJiXueMaiDan;
                  break;
            }

            break;

         case PropConfig.PropType.HpYaoShui:
            switch (item.quality)
            {
               case 1:
                  return ResourcesConfig.Hp1;
                  break;
               case 2:
                  return ResourcesConfig.Hp2;
                  break;
               case 3:
                  return ResourcesConfig.Hp3;
                  break;
               case 4:
                  return ResourcesConfig.Hp4;
                  break;
               case 5:
                  return ResourcesConfig.Hp5;
                  break;
               case 6:
                  return ResourcesConfig.Hp6;
                  break;
            }

            break;

         case PropConfig.PropType.ExYaoShui:
            return ResourcesConfig.Ex;
            break;
         case PropConfig.PropType.DiaoLuoYaoShui:
            return ResourcesConfig.DiaoLuo;
            break;

         case PropConfig.PropType.SkillShu:
            switch (item.quality)
            {
               case 1:
                  return ResourcesConfig.ChongWuSkill1;
                  break;
               case 2:
                  return ResourcesConfig.ChongWuSkill2;
                  break;
               case 3:
                  return ResourcesConfig.ChongWuSkill3;
                  break;
               case 4:
                  return ResourcesConfig.ChongWuSkill4;
                  break;
               case 5:
                  return ResourcesConfig.ChongWuSkill5;
                  break;
               case 6:
                  return ResourcesConfig.ChongWuSkill6;
                  break;
            }

            break;

         case PropConfig.PropType.DaKongShi:
            return ResourcesConfig.DaKongShi;
            break;

      }

      return null;
    }

    public static List<ShangPingItem> NormalShangDian = new List<ShangPingItem>()
    {
        new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 1},
        new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 2},
        new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 3},
        new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 4},
        new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.WeaponFragment,quality = 6},


        new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 1},
        new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 2},
        new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 3},
        new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 4},
        new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.ChiBang,quality = 6},

        
        new ShangPingItem(){type = PropConfig.PropType.ChongWuDan,quality = 3},
        new ShangPingItem(){type = PropConfig.PropType.XiSuiYe,quality = 3},
        new ShangPingItem(){type = PropConfig.PropType.XueMaiDan,quality = 3},
        
        new ShangPingItem(){type = PropConfig.PropType.ChongWuDan,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.XiSuiYe,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.XueMaiDan,quality = 5},
        
        new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 1},
        new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 2},
        new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 3},
        new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 4},
        new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 6},

        
        new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 1},
        new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 2},
        new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 3},
        new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 4},
        new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 6},
        
        new ShangPingItem(){type = PropConfig.PropType.ExYaoShui,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.DiaoLuoYaoShui,quality = 5},
        new ShangPingItem(){type = PropConfig.PropType.DaKongShi,quality = 5},

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

    public static Dictionary<ShangPingItem,int> ShangPingCountDic =
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
            { new ShangPingItem(){type = PropConfig.PropType.HpYaoShui,quality = 6},1000 },

            
            { new ShangPingItem(){type = PropConfig.PropType.ExYaoShui,quality = 5},200 },
            { new ShangPingItem(){type = PropConfig.PropType.DiaoLuoYaoShui,quality = 5},200 },

            { new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 1},100 },
            { new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 2},250 },
            { new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 3},500 },
            { new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 4},1000 },
            { new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 5},2000 },
            { new ShangPingItem(){type = PropConfig.PropType.SkillShu,quality = 6},5000 },

            { new ShangPingItem(){type = PropConfig.PropType.DaKongShi,quality = 5},2500 },
        };
}
