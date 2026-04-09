using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChongWuTuJianWindow : MonoBehaviour
{
   public TextMeshProUGUI TitleName;

   
   public TextMeshProUGUI Name1;
   public TextMeshProUGUI Name2;
   public TextMeshProUGUI Name3;
   public TextMeshProUGUI Name4;
   public Image Image1;
   public Image Image2;
   public Image Image3;
   public Image Image4;

   public TextMeshProUGUI AttackText;
   public TextMeshProUGUI HpText;
   public TextMeshProUGUI YuanSuText;
   public Image YuanSuImage;

   public Button ExitButton;
   public GameObject ListContent;

   private void OnEnable()
   {
      foreach (Transform item in ListContent.transform)
      {
         Destroy(item.gameObject);
      }

      foreach (var item in ChongWuConfig.TuJianQualityDic)
      {
         var tujianitem =
            Instantiate(Resources.Load<GameObject>("Prefabs/Window/TuJianItem"),ListContent.transform).GetComponent<TuJianItem>();
         tujianitem.type = item.Key;
         tujianitem.SetChongWuTuJianItem();
      }
      ShowTuJian(ChongWuConfig.ChongWuTuJianType.ShiLaiMu);
   }

   public void TuJianClick(object[] obj)
   {
      ChongWuConfig.ChongWuTuJianType type = (ChongWuConfig.ChongWuTuJianType)obj[0];
      ShowTuJian(type);
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("TuJianClick",TuJianClick);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("TuJianClick",TuJianClick);
      ExitButton.onClick.AddListener(() =>
      {
         Destroy(gameObject);
      });
   }

   public void ShowTuJian(ChongWuConfig.ChongWuTuJianType type)
   {
      List<ChongWuType>list=ChongWuConfig.TuJianDic[type];
      Image1.sprite = ResourcesConfig.GetChongWuSprite(list[0]);
      Image2.sprite = ResourcesConfig.GetChongWuSprite(list[1]);
      Image3.sprite = ResourcesConfig.GetChongWuSprite(list[2]);
      Image4.sprite = ResourcesConfig.GetChongWuSprite(list[3]);
      Name1.text = ChongWuConfig.ChongWuNameDic[list[0]];
      Name2.text = ChongWuConfig.ChongWuNameDic[list[1]];
      Name3.text = ChongWuConfig.ChongWuNameDic[list[2]];
      Name4.text = ChongWuConfig.ChongWuNameDic[list[3]];
      
      TitleName.text=ChongWuConfig.TuJianNameDic[type];
      AttackText.text = ChongWuConfig.TuJianDescDic[type][0];
      HpText.text = ChongWuConfig.TuJianDescDic[type][1];
      YuanSuText.text = ChongWuConfig.TuJianDescDic[type][2];

      switch (ChongWuConfig.TuJianYuanSuTypeDic[type])
      {
         case YuanSuType.All:
            YuanSuImage.sprite = ResourcesConfig.YuanSuIconAll;
            break;
         case YuanSuType.Ice:
            YuanSuImage.sprite = ResourcesConfig.YuanSuIconIce;
            break;
         case YuanSuType.Huo:
            YuanSuImage.sprite = ResourcesConfig.YuanSuIconHuo;
            break;
         case YuanSuType.Dian:
            YuanSuImage.sprite = ResourcesConfig.YuanSuIconDian;
            break;
         case YuanSuType.HeiAn:
            YuanSuImage.sprite = ResourcesConfig.YuanSuIconHeiAn;
            break;
      }
   }

}
