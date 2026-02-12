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
         PlayerData.S.ChongWuList.Remove(ClickChongWuItem.chongWuTable);
         ObserverModuleManager.S.SendEvent("RefreshChongWuCurrentPage");
         ObserverModuleManager.S.SendEvent("HideChongWuItemMask");
         StoreController.S.SaveStoreData();
         Destroy(gameObject);
      });
      
      ChuZhangButton.onClick.AddListener(() =>
         {
            int index = (ChongWuController.S.CurrentChongWuPageNum - 1) * 6;
            
            //取消勾
            if (PlayerData.S.ChongWuList.Count >= index + 1)
            {
               ChongWuController.S.CurrentPageItemList[0].HideGou();
            }
            if (PlayerData.S.ChongWuList.Count >= index + 2)
            {
               ChongWuController.S.CurrentPageItemList[1].HideGou();
            }
            if (PlayerData.S.ChongWuList.Count >= index + 3)
            {
               ChongWuController.S.CurrentPageItemList[2].HideGou();
            }
            if (PlayerData.S.ChongWuList.Count >= index + 4)
            {
               ChongWuController.S.CurrentPageItemList[3].HideGou();
            }
            if (PlayerData.S.ChongWuList.Count >= index + 5)
            {
               ChongWuController.S.CurrentPageItemList[4].HideGou();
            }
            if (PlayerData.S.ChongWuList.Count >= index + 6)
            {
               ChongWuController.S.CurrentPageItemList[5].HideGou();
            }
            
            //勾选勾
            ClickChongWuItem.ShowGou();
            PlayerData.S.ZhuChongWuId = ClickChongWuItem.chongWuTable.ChongWuId;
            ObserverModuleManager.S.SendEvent("HideChongWuItemMask");
            StoreController.S.SaveStoreData();
            Destroy(gameObject);
         }
      );

   }
}
