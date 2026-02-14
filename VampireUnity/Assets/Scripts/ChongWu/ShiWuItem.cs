using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiWuItem : MonoBehaviour
{
   [NonSerialized] public int Quatity;
   [NonSerialized] public int ChongWuId;
   public Button button;

   private void Start()
   {
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
      });
   }
}
