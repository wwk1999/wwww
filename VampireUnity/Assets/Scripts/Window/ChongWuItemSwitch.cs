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
            
            int index = (ChongWuController.S.CurrentChongWuPageNum - 1) * 6;
            
            //取消勾
            if (PlayerData.S.ChongWuDic.Count >= index + 1)
            {
               ChongWuController.S.CurrentPageItemList[0].HideGou();
            }
            if (PlayerData.S.ChongWuDic.Count >= index + 2)
            {
               ChongWuController.S.CurrentPageItemList[1].HideGou();
            }
            if (PlayerData.S.ChongWuDic.Count >= index + 3)
            {
               ChongWuController.S.CurrentPageItemList[2].HideGou();
            }
            if (PlayerData.S.ChongWuDic.Count >= index + 4)
            {
               ChongWuController.S.CurrentPageItemList[3].HideGou();
            }
            if (PlayerData.S.ChongWuDic.Count >= index + 5)
            {
               ChongWuController.S.CurrentPageItemList[4].HideGou();
            }
            if (PlayerData.S.ChongWuDic.Count >= index + 6)
            {
               ChongWuController.S.CurrentPageItemList[5].HideGou();
            }
            
            //勾选勾
            ClickChongWuItem.ShowGou();
            PlayerData.S.ZhuChongWuId = ClickChongWuItem.chongWuTable.ChongWuId;
            ObserverModuleManager.S.SendEvent("ChongWuChuZhan");
            ObserverModuleManager.S.SendEvent("HideChongWuItemMask");
            StoreController.S.SaveStoreData();
            Destroy(gameObject);
         }
      );

   }
}
