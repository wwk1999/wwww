using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChongWuItemSwitch : MonoBehaviour
{
   public Button ChuZhangButton;
   public Button FenJieButton;
   [NonSerialized]public ChongWuListItem ClickChongWuItem;

   private void Start()
   {
      FenJieButton.onClick.AddListener(() =>
      {
         PlayerData.S.ChongWuJingHua += ChongWuConfig.ChongWuJingHuaDic[ClickChongWuItem.chongWuTable.Quality];
         PlayerData.S.ChongWuDic.Remove(ClickChongWuItem.chongWuTable.ChongWuId);
         if (ClickChongWuItem.chongWuTable.ChongWuId == PlayerData.S.ZhuChongWuId)
         {
            PlayerData.S.ZhuChongWuId = 0;
         }
         ObserverModuleManager.S.SendEvent("FenJie");
         ObserverModuleManager.S.SendEvent("HideChongWuItemMask");
         StoreController.S.SaveStoreData();
         Destroy(gameObject);
      });
      
      ChuZhangButton.onClick.AddListener(() =>
         {
            if (ClickChongWuItem.chongWuTable.ChongWuId == PlayerData.S.FuChongWuId1 ||
                ClickChongWuItem.chongWuTable.ChongWuId == PlayerData.S.FuChongWuId2 ||
                ClickChongWuItem.chongWuTable.ChongWuId == PlayerData.S.FuChongWuId3)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"不能将副宠设为主宠");
               return;
            }
            
            PlayerData.S.ZhuChongWuId = ClickChongWuItem.chongWuTable.ChongWuId;
            ObserverModuleManager.S.SendEvent("ChongWuChuZhan");
            ObserverModuleManager.S.SendEvent("HideChongWuItemMask");
            ObserverModuleManager.S.SendEvent("ReFreshFuChongZhuChong");
            StoreController.S.SaveStoreData();
            Destroy(gameObject);
         }
      );

   }
}
