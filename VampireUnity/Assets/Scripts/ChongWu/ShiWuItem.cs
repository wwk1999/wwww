using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShiWuItem : MonoBehaviour
{
   [NonSerialized] public int Quatity;
   [NonSerialized] public int ChongWuId;
   public Button button;
   public Image bg;
   public TextMeshProUGUI count;
   public TextMeshProUGUI Name1;
   public TextMeshProUGUI Name2;
   public TextMeshProUGUI Name3;
   public TextMeshProUGUI Name4;
   public TextMeshProUGUI Name5;
   public TextMeshProUGUI Name6;

   public void SetShiWuItem()
   {
      button.onClick.RemoveAllListeners();
      button.onClick.AddListener(() =>
      {
         var table=PlayerData.S.ChongWuDic[ChongWuId];
         switch (Quatity)
         {
            case 1:
               if (PlayerData.S.ChongWuShiWu1 <= 0)
               {
                  ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"宠物食物不足");
                  return;
               }
               PlayerData.S.ChongWuShiWu1--;
               table.Ex += ChongWuConfig.ShiWuDic[1];
               break;
            case 2:
               if (PlayerData.S.ChongWuShiWu2 <= 0)
               {
                  ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"宠物食物不足");
                  return;
               }
               PlayerData.S.ChongWuShiWu2--;
               table.Ex += ChongWuConfig.ShiWuDic[2];
               break;
            case 3:
               if (PlayerData.S.ChongWuShiWu3 <= 0)
               {
                  ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"宠物食物不足");
                  return;
               }
               PlayerData.S.ChongWuShiWu3--;
               table.Ex += ChongWuConfig.ShiWuDic[3];
               break;
            case 4:
               if (PlayerData.S.ChongWuShiWu4 <= 0)
               {
                  ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"宠物食物不足");
                  return;
               }
               PlayerData.S.ChongWuShiWu4--;
               table.Ex += ChongWuConfig.ShiWuDic[4];
               break;
            case 5:
               if (PlayerData.S.ChongWuShiWu5 <= 0)
               {
                  ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"宠物食物不足");
                  return;
               }
               PlayerData.S.ChongWuShiWu5--;
               table.Ex += ChongWuConfig.ShiWuDic[5];
               break;
            case 6:
               if (PlayerData.S.ChongWuShiWu6 <= 0)
               {
                  ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"宠物食物不足");
                  return;
               }
               PlayerData.S.ChongWuShiWu6--;
               table.Ex += ChongWuConfig.ShiWuDic[6];
               break;
         }

         while (table.Ex>=ChongWuConfig.ChongWuExDic[table.Level])
         {
            table.Ex-=ChongWuConfig.ChongWuExDic[table.Level];
            table.Level++;
         }
         ObserverModuleManager.S.SendEvent("RefreshWeiYangPage");
         ObserverModuleManager.S.SendEvent("RefreshChongWuPage");
      });
      
      
      
      Name1.gameObject.SetActive(false);
      Name2.gameObject.SetActive(false);
      Name3.gameObject.SetActive(false);
      Name4.gameObject.SetActive(false);
      Name5.gameObject.SetActive(false);
      Name6.gameObject.SetActive(false);

      switch (Quatity)
      {
         case 1:
            bg.sprite = ResourcesConfig.ChongWuShiWuBgWhite;
            Name1.gameObject.SetActive(true);
            Name1.text = ChongWuConfig.ChongWuShiWuNameDic[1];
            break;
         case 2:
            bg.sprite = ResourcesConfig.ChongWuShiWuBgGreen;
            Name2.gameObject.SetActive(true);
            Name2.text = ChongWuConfig.ChongWuShiWuNameDic[2];
            break;
         case 3:
            bg.sprite = ResourcesConfig.ChongWuShiWuBgBlue;
            Name3.gameObject.SetActive(true);
            Name3.text = ChongWuConfig.ChongWuShiWuNameDic[3];
            break;
         case 4:
            bg.sprite = ResourcesConfig.ChongWuShiWuBgPurple;
            Name4.gameObject.SetActive(true);
            Name4.text = ChongWuConfig.ChongWuShiWuNameDic[4];
            break;
         case 5:
            bg.sprite = ResourcesConfig.ChongWuShiWuBgOrange;
            Name5.gameObject.SetActive(true);
            Name5.text = ChongWuConfig.ChongWuShiWuNameDic[5];
            break;
         case 6:
            bg.sprite = ResourcesConfig.ChongWuShiWuBgRed;
            Name6.gameObject.SetActive(true);
            Name6.text = ChongWuConfig.ChongWuShiWuNameDic[6];
            break;

      }
   }
   
}
