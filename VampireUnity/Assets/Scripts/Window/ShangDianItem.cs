using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShangDianItem : MonoBehaviour
{
   public Image bg;
   public Animator animator;
   public Image image;

   public void SetItem(ShangDianConfig.ShangPingItem  item)
   {
      switch (item.quality)
      {
         case 1:
            bg.sprite = ResourcesConfig.WhiteBg;
            animator.Play("WhiteEdge");
            break;
         case 2:
            bg.sprite = ResourcesConfig.GreenBg;
            animator.Play("GreenEdge");
            break;
         case 3:
            bg.sprite = ResourcesConfig.BlueBg;
            animator.Play("BlueEdge");
            break;
         case 4:
            bg.sprite = ResourcesConfig.PurpleBg;
            animator.Play("PurpleEdge");
            break;
         case 5:
            bg.sprite = ResourcesConfig.OrangeBg;
            animator.Play("OrangeEdge");
            break;
         case 6:
            bg.sprite = ResourcesConfig.RedBg;
            animator.Play("RedEdge");
            break;
      }

      switch (item.type)
      {
         case PropConfig.PropType.WeaponFragment:
            switch (item.quality)
            {
               case 1:
                  image.sprite = ResourcesConfig.WhiteWeaponFragment;
                  break;
               case 2:
                  image.sprite = ResourcesConfig.GreenWeaponFragment;
                  break;
               case 3:
                  image.sprite = ResourcesConfig.BlueWeaponFragment;
                  break;
               case 4:
                  image.sprite = ResourcesConfig.PurpleWeaponFragment;
                  break;
               case 5:
                  image.sprite = ResourcesConfig.OrangeWeaponFragment;
                  break;
               case 6:
                  image.sprite = ResourcesConfig.RedWeaponFragment;
                  break;
            }
            break;
         case PropConfig.PropType.ChiBang:
            switch (item.quality)
            {
               case 1:
                  image.sprite = ResourcesConfig.WhiteChiBang;
                  break;
               case 2:
                  image.sprite = ResourcesConfig.GreenChiBang;
                  break;
               case 3:
                  image.sprite = ResourcesConfig.BlueChiBang;
                  break;
               case 4:
                  image.sprite = ResourcesConfig.PurpleChiBang;
                  break;
               case 5:
                  image.sprite = ResourcesConfig.OrangeChiBang;
                  break;
               case 6:
                  image.sprite = ResourcesConfig.RedChiBang;
                  break;
            }
            break;
         case PropConfig.PropType.ChongWuDan:
            switch (item.quality)
            {
               case 3:
                  image.sprite = ResourcesConfig.NormalChongWuDan;
                  break;
               case 5:
                  image.sprite = ResourcesConfig.GaoJiChongWuDan;
                  break;
            }
            break;
         
         case PropConfig.PropType.XiSuiYe:
            switch (item.quality)
            {
               case 3:
                  image.sprite = ResourcesConfig.NormalXiSuiYe;
                  break;
               case 5:
                  image.sprite = ResourcesConfig.GaoJiXiSuiYe;
                  break;
            }
            break;
         
         case PropConfig.PropType.XueMaiDan:
            switch (item.quality)
            {
               case 3:
                  image.sprite = ResourcesConfig.NormalXueMaiDan;
                  break;
               case 5:
                  image.sprite = ResourcesConfig.GaoJiXueMaiDan;
                  break;
            }
            break;
         
         case PropConfig.PropType.HpYaoShui:
            switch (item.quality)
            {
               case 1:
                  image.sprite = ResourcesConfig.Hp1;
                  break;
               case 2:
                  image.sprite = ResourcesConfig.Hp2;
                  break;
               case 3:
                  image.sprite = ResourcesConfig.Hp3;
                  break;
               case 4:
                  image.sprite = ResourcesConfig.Hp4;
                  break;
               case 5:
                  image.sprite = ResourcesConfig.Hp5;
                  break;
               case 6:
                  image.sprite = ResourcesConfig.Hp6;
                  break;
            }
            break;
         
         case PropConfig.PropType.ExYaoShui:
            image.sprite = ResourcesConfig.Ex;
            break;
         case PropConfig.PropType.DiaoLuoYaoShui:
            image.sprite = ResourcesConfig.DiaoLuo;
            break;
         
         case PropConfig.PropType.SkillShu:
            switch (item.quality)
            {
               case 1:
                  image.sprite = ResourcesConfig.ChongWuSkill1;
                  break;
               case 2:
                  image.sprite = ResourcesConfig.ChongWuSkill2;
                  break;
               case 3:
                  image.sprite = ResourcesConfig.ChongWuSkill3;
                  break;
               case 4:
                  image.sprite = ResourcesConfig.ChongWuSkill4;
                  break;
               case 5:
                  image.sprite = ResourcesConfig.ChongWuSkill5;
                  break;
               case 6:
                  image.sprite = ResourcesConfig.ChongWuSkill6;
                  break;
            }
            break;
         
         case PropConfig.PropType.DaKongShi:
            image.sprite = ResourcesConfig.DaKongShi;
            break;

      }
   }
}
