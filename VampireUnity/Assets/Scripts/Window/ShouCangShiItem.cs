using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShouCangShiItem : MonoBehaviour
{
   [NonSerialized]public ShouCangShiItemType Type=ShouCangShiItemType.None;
   [NonSerialized] public int orangeId=0;
   [NonSerialized] public ChongWuType ChongWuType=ChongWuType.None;
   [NonSerialized] public ChiBangType ChiBangType=ChiBangType.None;

   public GameObject mask;
   public Image image;
   public TextMeshProUGUI Name1;
   public TextMeshProUGUI Name2;
   public TextMeshProUGUI Name3;
   public TextMeshProUGUI Name4;
   public TextMeshProUGUI Name5;
   public TextMeshProUGUI Name6;

   public TextMeshProUGUI Quality1;
   public TextMeshProUGUI Quality2;
   public TextMeshProUGUI Quality3;
   public TextMeshProUGUI Quality4;
   public TextMeshProUGUI Quality5;
   public TextMeshProUGUI Quality6;

   public Image bgImage;
   public Image New;

   public void Show()
   {
      switch (Type)
      {
         case ShouCangShiItemType.Equip:
            Quality1.gameObject.SetActive(false);
            Quality2.gameObject.SetActive(false);
            Quality3.gameObject.SetActive(false);
            Quality4.gameObject.SetActive(false);
            Quality5.gameObject.SetActive(true);
            Quality6.gameObject.SetActive(false);
            Name1.gameObject.SetActive(false);
            Name2.gameObject.SetActive(false);
            Name3.gameObject.SetActive(false);
            Name4.gameObject.SetActive(false);
            Name5.gameObject.SetActive(true);
            Name6.gameObject.SetActive(false);
            bgImage.sprite = ResourcesConfig.OrangeBg;
            EquipTable equipTable=new EquipTable();
            equipTable.OrangeEntry1=EntryConfig.OrangeIdEntryDic[orangeId];
            image.sprite = ResourcesConfig.GetEquipSprite(equipTable);
            if (PlayerData.S.ShouCangShiEquipDic[orangeId])
            {
               mask.SetActive(false);
               Name5.text = EntryConfig.OrangeIdNameDic[orangeId];
               image.color = Color.white;
            }
            else
            {
               image.color = Color.black;
               mask.SetActive(true);
               Name5.text = "????";
            }

            if (PlayerData.S.ShouCangShiEquipDic[orangeId] && !PlayerData.S.ShouCangShiLastEquipDic[orangeId])
            {
               New.gameObject.SetActive(true);
            }
            else
            {
               New.gameObject.SetActive(false);
            }
            break;
         case ShouCangShiItemType.ChiBang:
            int quality=ChiBangConfig.GetChiBangQuality(ChiBangType);
            Quality1.gameObject.SetActive(quality==1);
            Quality2.gameObject.SetActive(quality==2);
            Quality3.gameObject.SetActive(quality==3);
            Quality4.gameObject.SetActive(quality==4);
            Quality5.gameObject.SetActive(quality==5);
            Quality6.gameObject.SetActive(quality==6);
            
            Name1.gameObject.SetActive(quality==1);
            Name2.gameObject.SetActive(quality==2);
            Name3.gameObject.SetActive(quality==3);
            Name4.gameObject.SetActive(quality==4);
            Name5.gameObject.SetActive(quality==5);
            Name6.gameObject.SetActive(quality==6);
            

            switch (quality)
            {
               case 1:
                  bgImage.sprite = ResourcesConfig.WhiteBg;
                  break;
               case 2:
                  bgImage.sprite = ResourcesConfig.GreenBg;
                  break;
               case 3:
                  bgImage.sprite = ResourcesConfig.BlueBg;
                  break;
               case 4:
                  bgImage.sprite = ResourcesConfig.PurpleBg;
                  break;
               case 5:
                  bgImage.sprite = ResourcesConfig.OrangeBg;
                  break;
               case 6:
                  bgImage.sprite = ResourcesConfig.RedBg;
                  break;
            }
            image.sprite=ChiBangConfig.GetChiBangSprite(ChiBangType);
            
            
            if (PlayerData.S.ShouCangShiChiBangDic[ChiBangType])
            {
               image.color = Color.white;

               mask.SetActive(false);
               Name1.text = ChiBangConfig.GetChiBangName(ChiBangType);
               Name2.text = ChiBangConfig.GetChiBangName(ChiBangType);
               Name3.text = ChiBangConfig.GetChiBangName(ChiBangType);
               Name4.text = ChiBangConfig.GetChiBangName(ChiBangType);
               Name5.text = ChiBangConfig.GetChiBangName(ChiBangType);
               Name6.text = ChiBangConfig.GetChiBangName(ChiBangType);
            }
            else
            {
               image.color = Color.black;

               mask.SetActive(true);
               Name1.text = "????";
               Name2.text = "????";
               Name3.text = "????";
               Name4.text = "????";
               Name5.text = "????";
               Name6.text = "????";
            }

            if (PlayerData.S.ShouCangShiChiBangDic[ChiBangType] && !PlayerData.S.ShouCangShiLastChiBangDic[ChiBangType])
            {
               New.gameObject.SetActive(true);
            }
            else
            {
               New.gameObject.SetActive(false);
            }
            break;
         
         
         
         case ShouCangShiItemType.ChongWu:
            int quality1=ChongWuConfig.GetChongWuQualityByType(ChongWuType);
            Quality1.gameObject.SetActive(quality1==1);
            Quality2.gameObject.SetActive(quality1==2);
            Quality3.gameObject.SetActive(quality1==3);
            Quality4.gameObject.SetActive(quality1==4);
            Quality5.gameObject.SetActive(quality1==5);
            Quality6.gameObject.SetActive(quality1==6);
            
            
            Name1.gameObject.SetActive(quality1==1);
            Name2.gameObject.SetActive(quality1==2);
            Name3.gameObject.SetActive(quality1==3);
            Name4.gameObject.SetActive(quality1==4);
            Name5.gameObject.SetActive(quality1==5);
            Name6.gameObject.SetActive(quality1==6);

            switch (quality1)
            {
               case 1:
                  bgImage.sprite = ResourcesConfig.WhiteBg;
                  break;
               case 2:
                  bgImage.sprite = ResourcesConfig.GreenBg;
                  break;
               case 3:
                  bgImage.sprite = ResourcesConfig.BlueBg;
                  break;
               case 4:
                  bgImage.sprite = ResourcesConfig.PurpleBg;
                  break;
               case 5:
                  bgImage.sprite = ResourcesConfig.OrangeBg;
                  break;
               case 6:
                  bgImage.sprite = ResourcesConfig.RedBg;
                  break;
            }
            image.sprite=ResourcesConfig.GetChongWuSprite(ChongWuType);
            
            
            if (PlayerData.S.ShouCangShiChongWu[ChongWuType])
            {
               image.color = Color.white;

               mask.SetActive(false);
               Name1.text = ChongWuConfig.ChongWuNameDic[ChongWuType];
               Name2.text = ChongWuConfig.ChongWuNameDic[ChongWuType];
               Name3.text = ChongWuConfig.ChongWuNameDic[ChongWuType];
               Name4.text = ChongWuConfig.ChongWuNameDic[ChongWuType];
               Name5.text = ChongWuConfig.ChongWuNameDic[ChongWuType];
               Name6.text = ChongWuConfig.ChongWuNameDic[ChongWuType];

            }
            else
            {
               image.color = Color.black;

               mask.SetActive(true);
               Name1.text = "????";
               Name2.text = "????";
               Name3.text = "????";
               Name4.text = "????";
               Name5.text = "????";
               Name6.text = "????";
            }

            if (PlayerData.S.ShouCangShiChongWu[ChongWuType] && !PlayerData.S.ShouCangShiLastChongWu[ChongWuType])
            {
               New.gameObject.SetActive(true);
            }
            else
            {
               New.gameObject.SetActive(false);
            }
            break;
      }
   }
}
