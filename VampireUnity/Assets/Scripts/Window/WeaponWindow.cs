using System;
using System.Collections.Generic;
using Config;
using Gloabl;
using Mysql;
using Spine.Unity;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class WeaponWindow : MonoBehaviour
{

   public GameObject LevelPanel;
   public GameObject ExpPanel;

   public Image WeaponImage;
   public GameObject WeaponListContent;
   public Button exitButton; // 退出按钮

   public GameObject InfoPanel;
   public GameObject UpPanel;
   public GameObject JieSuoPanel;
   public GameObject AttributePanel;
   
   
   public TextMeshProUGUI weaponName1;
   public TextMeshProUGUI weaponName2;
   public TextMeshProUGUI weaponName3;
   public TextMeshProUGUI weaponName4;
   public TextMeshProUGUI weaponName5;
   public TextMeshProUGUI weaponName6;


   public GameObject jieSuoContent;
   public Button JieSuoButton;

   public GameObject AttributeContent;

   public TextMeshProUGUI WeaponName1;
   public TextMeshProUGUI WeaponName2;
   public TextMeshProUGUI WeaponName3;
   public TextMeshProUGUI WeaponName4;
   public TextMeshProUGUI WeaponName5;
   public TextMeshProUGUI WeaponName6;
   
   public TextMeshProUGUI JieSuoText;
   
   public TextMeshProUGUI AllHunQiText;

   public TextMeshProUGUI JieSuoDesc;
   
   public TextMeshProUGUI InfoDesc;
   public GameObject CiTiaoContent;

   public TextMeshProUGUI LevelText;
   public Slider LevelSlider;
   public TextMeshProUGUI CurrentExp;
   public TextMeshProUGUI MaxExp;




   public void SwitchLanguage()
   {
            WeaponName1.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName1;
            WeaponName2.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName2;
            WeaponName3.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName3;
            WeaponName4.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName4;
            WeaponName5.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName5;
            WeaponName6.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName6;
          
            JieSuoText.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.JieSuo;
      
   }


   
   [NonSerialized] public WeaponType currentJieSuoType = WeaponType.None;
   [NonSerialized] public WeaponType currentShowType = WeaponType.None;

   public void RefreshEquipIcon()
   {
      
   }
   
   public void HideName()
   {
      weaponName1.gameObject.SetActive(false);
      weaponName2.gameObject.SetActive(false);
      weaponName3.gameObject.SetActive(false);
      weaponName4.gameObject.SetActive(false);
      weaponName5.gameObject.SetActive(false);
   }

   public void ShowAttribute(WeaponType weaponType)
   {
      HideName();
      JieSuoPanel.gameObject.SetActive(false);
      AttributePanel.gameObject.SetActive(true);
      InfoPanel.SetActive(true);
      UpPanel.SetActive(true);
      InfoDesc.text = "攻击特效：" + WeaponConfig.WeaponTeXiaoDic[weaponType];
      foreach (Transform item in CiTiaoContent.transform)
      {
         Destroy(item.gameObject);
      }

      foreach (var item in WeaponConfig.WeaponCiTiaoDic[weaponType])
      {
         switch (item)
         {
            case WeaponCiTiao.FanWei:
               Instantiate(Resources.Load<GameObject>("Prefabs/Weapon/FanWeiCiTiao"), CiTiaoContent.transform);
               break;
            case WeaponCiTiao.BaoZha:
               Instantiate(Resources.Load<GameObject>("Prefabs/Weapon/BaoZhaCiTiao"), CiTiaoContent.transform);
               break;
            case WeaponCiTiao.ChuanTou:
               Instantiate(Resources.Load<GameObject>("Prefabs/Weapon/ChuanTouCiTiao"), CiTiaoContent.transform);
               break;
            case WeaponCiTiao.JiSu:
               Instantiate(Resources.Load<GameObject>("Prefabs/Weapon/JiSuCiTiao"), CiTiaoContent.transform);
               break;
            case WeaponCiTiao.SanShe:
               Instantiate(Resources.Load<GameObject>("Prefabs/Weapon/SanSheCiTiao"), CiTiaoContent.transform);
               break;
         }
      }
      switch (WeaponConfig.WeaponQualityDic[weaponType])
      {
         case 1:
            weaponName1.gameObject.SetActive(true);
            weaponName1.text = WeaponConfig.WeaponNameDic[weaponType];
            break;
         case 2:
            weaponName2.gameObject.SetActive(true);
            weaponName2.text = WeaponConfig.WeaponNameDic[weaponType];
            break;
         case 3:
            weaponName3.gameObject.SetActive(true);
            weaponName3.text = WeaponConfig.WeaponNameDic[weaponType];
            break;
         case 4:
            weaponName4.gameObject.SetActive(true);
            weaponName4.text = WeaponConfig.WeaponNameDic[weaponType];
            break;
         case 5:
            weaponName5.gameObject.SetActive(true);
            weaponName5.text = WeaponConfig.WeaponNameDic[weaponType];
            break;
         case 6:
            weaponName6.gameObject.SetActive(true);
            weaponName6.text = WeaponConfig.WeaponNameDic[weaponType];
            break;
      }

      LevelText.text = "Lv." + GetWeaponLevel(weaponType);
      LevelSlider.maxValue = GlobalPlayerAttribute.ExpDic[GetWeaponLevel(weaponType)];
      MaxExp.text=GlobalPlayerAttribute.ExpDic[GetWeaponLevel(weaponType)].ToString();
      CurrentExp.text=GetWeaponExp(weaponType).ToString();
      LevelSlider.value = GetWeaponExp(weaponType);

      foreach (Transform item in AttributeContent.transform)
      {
         Destroy(item.gameObject);
      }

      var weaponBaseAttribute = WeaponConfig.WeaponBaseAttributeDic[weaponType];
      var weaponAttribute = new WeaponAttribute
         { Attack = weaponBaseAttribute.Attack * WeaponConfig.WeaponLevelAttributeDic[GetWeaponLevel(weaponType)], Defense = weaponBaseAttribute.Defense * WeaponConfig.WeaponLevelAttributeDic[GetWeaponLevel(weaponType)],Hp = weaponBaseAttribute.Hp * WeaponConfig.WeaponLevelAttributeDic[GetWeaponLevel(weaponType)],Crit = weaponBaseAttribute.Crit * WeaponConfig.WeaponLevelAttributeDic[GetWeaponLevel(weaponType)],AttackSpeed = weaponBaseAttribute.AttackSpeed};
      var attack = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"), AttributeContent.transform);
      attack.GetComponent<WeaponItem1>().SetWeaponItem(AttributeType.Attack,(int)weaponAttribute.Attack);
      
      var defense = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"), AttributeContent.transform);
      defense.GetComponent<WeaponItem1>().SetWeaponItem(AttributeType.Defense,(int)weaponAttribute.Defense);

      var hp = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"), AttributeContent.transform);
      hp.GetComponent<WeaponItem1>().SetWeaponItem(AttributeType.Hp,(int)weaponAttribute.Hp);

      
      var crit = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"), AttributeContent.transform);
      crit.GetComponent<WeaponItem1>().SetWeaponItem(AttributeType.Crit,(int)weaponAttribute.Crit);

      var attackSpeed = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"), AttributeContent.transform);
      attackSpeed.GetComponent<WeaponItem1>().SetWeaponItem(AttributeType.AttackSpeed,(int)weaponAttribute.AttackSpeed);

   }
   
   public float GetWeaponExp(WeaponType type)
   {
      switch (type)
      {
         case WeaponType.Primary:
            return PlayerData.S.primaryWeaponExp;
         case WeaponType.PrimaryHuo:
   return PlayerData.S.primaryHuoExp;
         case WeaponType.PrimaryDian:
            return PlayerData.S.primaryDianExp;
         case WeaponType.PrimaryHeiAn:
            return PlayerData.S.primaryHeiAnExp;
         case WeaponType.IceBaoZha:
            return PlayerData.S.iceBaoZhaExp;
         case WeaponType.DianBaoZha:
            return PlayerData.S.dianBaoZhaExp;
         case WeaponType.HuoBaoZha:
            return PlayerData.S.HuoBaoZhaExp;
         case WeaponType.HeiAnBaoZha:
            return PlayerData.S.HeiAnBaoZhaWeaponExp;
         case WeaponType.XuKong:
            return PlayerData.S.xuKongWeaponExp;
         case WeaponType.PuTong3:
            return PlayerData.S.puTong3WeaponExp;
         case WeaponType.Fire:
            return PlayerData.S.fireWeaponExp;
         case WeaponType.LvQuan:
            return PlayerData.S.lvQuanWeaponExp;
         case WeaponType.DianJiSu:
            return PlayerData.S.DianJiSuWeaponExp;
         case WeaponType.DianSanShe:
            return PlayerData.S.DianSanSheWeaponExp;
         case WeaponType.Huo7:
            return PlayerData.S.Huo7WeaponExp;
         case WeaponType.HuoFenLie:
            return PlayerData.S.HuoFenLieWeaponExp;
         case WeaponType.HeiAnHuiXuan:
            return PlayerData.S.HeiAnHuiXuanWeaponExp;
         case WeaponType.HeiAnQuXian:
            return PlayerData.S.HeiAnQuXianWeaponExp;
         case WeaponType.Ice7:
            return PlayerData.S.Ice7WeaponExp;
         case WeaponType.Ice4BaoZha:
            return PlayerData.S.Ice4BaoZhaWeaponExp;
         case WeaponType.JianQi:
            return PlayerData.S.jianQiWeaponExp;
         case WeaponType.HuoDiPen:
            return PlayerData.S.HuoDiPenWeaponExp;
         case WeaponType.IcePen:
            return PlayerData.S.IcePenWeaponExp;
         case WeaponType.HeiDong:
            return PlayerData.S.heiDongWeaponExp;
         case WeaponType.DianLuoLei5:
            return PlayerData.S.DianLuoLei5WeaponExp;
      }

      return 0;
   }
   
   
   public float GetWeaponLevel(WeaponType type)
   {
      switch (type)
      {
         case WeaponType.Primary:
            return PlayerData.S.primaryWeaponLevel;
         case WeaponType.PrimaryHuo:
   return PlayerData.S.primaryHuoLevel;
         case WeaponType.PrimaryDian:
            return PlayerData.S.primaryDianLevel;
         case WeaponType.PrimaryHeiAn:
            return PlayerData.S.primaryHeiAnLevel;
         case WeaponType.IceBaoZha:
            return PlayerData.S.iceBaoZhaLevel;
         case WeaponType.DianBaoZha:
            return PlayerData.S.dianBaoZhaLevel;
         case WeaponType.HuoBaoZha:
            return PlayerData.S.HuoBaoZhaWeaponLevel;
         case WeaponType.HeiAnBaoZha:
            return PlayerData.S.HeiAnBaoZhaWeaponLevel;
         case WeaponType.XuKong:
            return PlayerData.S.xuKongWeaponLevel;
         case WeaponType.PuTong3:
            return PlayerData.S.puTong3WeaponLevel;
         case WeaponType.Fire:
            return PlayerData.S.fireWeaponLevel;
         case WeaponType.LvQuan:
            return PlayerData.S.lvQuanWeaponLevel;
         case WeaponType.DianJiSu:
            return PlayerData.S.DianJiSuWeaponLevel;
         case WeaponType.DianSanShe:
            return PlayerData.S.DianSanSheWeaponLevel;
         case WeaponType.Huo7:
            return PlayerData.S.Huo7WeaponLevel;
         case WeaponType.HuoFenLie:
            return PlayerData.S.HuoFenLieWeaponLevel;
         case WeaponType.HeiAnHuiXuan:
            return PlayerData.S.HeiAnHuiXuanWeaponLevel;
         case WeaponType.HeiAnQuXian:
            return PlayerData.S.HeiAnQuXianWeaponLevel;
         case WeaponType.Ice7:
            return PlayerData.S.Ice7WeaponLevel;
         case WeaponType.Ice4BaoZha:
            return PlayerData.S.Ice4BaoZhaWeaponLevel;
         case WeaponType.JianQi:
            return PlayerData.S.jianQiWeaponLevel;
         case WeaponType.HuoDiPen:
            return PlayerData.S.HuoDiPenWeaponLevel;
         case WeaponType.IcePen:
            return PlayerData.S.IcePenWeaponLevel;
         case WeaponType.HeiDong:
            return PlayerData.S.heiDongWeaponLevel;
         case WeaponType.DianLuoLei5:
            return PlayerData.S.DianLuoLei5WeaponLevel;
      }

      return 0;
   }

   public void ShowJieSuo(WeaponType weaponType)
   {
      HideName();
      WeaponImage.sprite = WeaponConfig.GetWeaponSprite(weaponType);
      JieSuoPanel.gameObject.SetActive(true);
      AttributePanel.gameObject.SetActive(false);
      InfoPanel.SetActive(true);
      UpPanel.SetActive(true);
      InfoDesc.text = "攻击特效：" + WeaponConfig.WeaponTeXiaoDic[weaponType];
      foreach (Transform item in CiTiaoContent.transform)
      {
         Destroy(item.gameObject);
      }

      foreach (var item in WeaponConfig.WeaponCiTiaoDic[weaponType])
      {
         switch (item)
         {
            case WeaponCiTiao.FanWei:
               Instantiate(Resources.Load<GameObject>("Prefabs/Weapon/FanWeiCiTiao"), CiTiaoContent.transform);
               break;
            case WeaponCiTiao.BaoZha:
               Instantiate(Resources.Load<GameObject>("Prefabs/Weapon/BaoZhaCiTiao"), CiTiaoContent.transform);
               break;
            case WeaponCiTiao.ChuanTou:
               Instantiate(Resources.Load<GameObject>("Prefabs/Weapon/ChuanTouCiTiao"), CiTiaoContent.transform);
               break;
            case WeaponCiTiao.JiSu:
               Instantiate(Resources.Load<GameObject>("Prefabs/Weapon/JiSuCiTiao"), CiTiaoContent.transform);
               break;
            case WeaponCiTiao.SanShe:
               Instantiate(Resources.Load<GameObject>("Prefabs/Weapon/SanSheCiTiao"), CiTiaoContent.transform);
               break;
         }
      }
      string desc = WeaponConfig.WeaponJieSuoDescDic[
         new WeaponJieSuoDesc()
         {
            YuanSuType = WeaponConfig.WeaponYuanSuTypeDic[weaponType],
            quality = WeaponConfig.WeaponQualityDic[weaponType]
         }];
      JieSuoDesc.text = desc;
      switch (WeaponConfig.WeaponQualityDic[weaponType])
      {
         case 1:
            weaponName1.gameObject.SetActive(true);
            weaponName1.text = WeaponConfig.WeaponNameDic[weaponType];
            break;
         case 2:
            weaponName2.gameObject.SetActive(true);
            weaponName2.text = WeaponConfig.WeaponNameDic[weaponType];
            break;
         case 3:
            weaponName3.gameObject.SetActive(true);
            weaponName3.text = WeaponConfig.WeaponNameDic[weaponType];
            break;
         case 4:
            weaponName4.gameObject.SetActive(true);
            weaponName4.text = WeaponConfig.WeaponNameDic[weaponType];
            break;
         case 5:
            weaponName5.gameObject.SetActive(true);
            weaponName5.text = WeaponConfig.WeaponNameDic[weaponType];
            break;
         case 6:
            weaponName6.gameObject.SetActive(true);
            weaponName6.text = WeaponConfig.WeaponNameDic[weaponType];
            break;
      }
      foreach (Transform child in jieSuoContent.transform)
      {
         Destroy(child.gameObject);
      }

      var cailiao = WeaponConfig.WeaponJieSuoDic[weaponType];
      foreach (var item in cailiao)
      {
         var weaponItem = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/CaiLiaoItem"), jieSuoContent.transform);
         switch (item._propType)
         {
            case PropConfig.PropType.LingHun:
               weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
               weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.LingHun;
               weaponItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = item.count.ToString();
               break;
            case PropConfig.PropType.JingCui:
               switch (item.quality)
               {
                  case 1:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.WhiteJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                     break;
                  case 2:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.GreenJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
                     break;
                  case 3:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.BlueJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                     break;
                  case 4:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.PurpleJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
                     break;
                  case 5:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.OrangeJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                     break;
                  case 6:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.RedJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
                     break;
               }

               weaponItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = item.count.ToString();
               break;
            case PropConfig.PropType.WeaponFragment:
               switch (item.quality)
               {
                  case 1:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.WhiteWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                     break;
                  case 2:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.GreenWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
                     break;
                  case 3:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.BlueWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                     break;
                  case 4:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.PurpleWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
                     break;
                  case 5:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.OrangeWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                     break;
                  case 6:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.RedWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
                     break;
               }

               weaponItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = item.count.ToString();
               break;
         }
      }
   }


   public void RefreshWeaponList()
   {
      InfoPanel.SetActive(false);
      UpPanel.SetActive(false);
   }

   public void ShowWeaponList()
   {
      foreach (Transform item in WeaponListContent.transform)
      {
         Destroy(item.gameObject);
      }
      foreach (var item in WeaponConfig.WeaponQualityDic)
      {
         var weaponItem = Instantiate(Resources.Load("Prefabs/Weapon/WeaponItem"),WeaponListContent.transform).GetComponent<WeaponItem>();
         weaponItem.type = item.Key;
         weaponItem.SetWeapon();
      }
   }

   private void OnEnable()
   {
      ShowWeaponList();
      RefreshWeaponList();
      RefreshEquipIcon();
      SwitchLanguage();
      AllHunQiText.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.AllHunQiLevel;
     
   }

   public void JieSuo()
   {
      List<WeaponJieSuoItem> items = WeaponConfig.WeaponJieSuoDic[currentJieSuoType];
      foreach (var item in items)
      {
         switch (item._propType)
         {
            case PropConfig.PropType.LingHun:
               if (GlobalPlayerAttribute.BloodEnergy < item.count)
               {
                  ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
                  return;
               }
               break;
            case PropConfig.PropType.WeaponFragment:
               switch (item.quality)
               {
                  case 2:
                     if (!BagController.S.PropList.ContainsKey(102) || BagController.S.PropList[102].Count < item.count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
                     }
                     return;
                  case 3:
                     if (!BagController.S.PropList.ContainsKey(103) || BagController.S.PropList[103].Count < item.count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
                     }
                     return;
                  case 4:
                     if (!BagController.S.PropList.ContainsKey(104) || BagController.S.PropList[104].Count < item.count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
                     }
                     return;
                  case 5:
                     if (!BagController.S.PropList.ContainsKey(105) || BagController.S.PropList[105].Count < item.count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
                     }
                     return;
               }
               break;
            
            
            case PropConfig.PropType.JingCui:
               switch (item.quality)
               {
                  case 2:
                     if (!BagController.S.PropList.ContainsKey(202) || BagController.S.PropList[202].Count < item.count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
                     }
                     return;
                  case 3:
                     if (!BagController.S.PropList.ContainsKey(203) || BagController.S.PropList[203].Count < item.count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
                     }
                     return;
                  case 4:
                     if (!BagController.S.PropList.ContainsKey(204) || BagController.S.PropList[204].Count < item.count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
                     }
                     return;
                  case 5:
                     if (!BagController.S.PropList.ContainsKey(205) || BagController.S.PropList[205].Count < item.count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
                     }
                     return;
               }
               break;
         }
      }
      switch (currentJieSuoType)
      {
         case WeaponType.HuoBaoZha:
            if (PlayerData.S.primaryHuoLevel<5)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.HuoBaoZhaWeaponLevel = 1;

            break;
         
         case WeaponType.IceBaoZha:
            if (PlayerData.S.primaryWeaponLevel<5)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.iceBaoZhaLevel = 1;

            break;
         
         case WeaponType.DianBaoZha:
            if (PlayerData.S.primaryDianLevel<5)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.dianBaoZhaLevel = 1;

            break;
         
         case WeaponType.HeiAnBaoZha:
            if (PlayerData.S.primaryHeiAnLevel<5)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.HeiAnBaoZhaWeaponLevel = 1;

            break;

         case WeaponType.PuTong3:
            if (PlayerData.S.iceBaoZhaLevel<10)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.puTong3WeaponLevel = 1;

            break;

         case WeaponType.XuKong:
            if (PlayerData.S.HeiAnBaoZhaWeaponLevel<10)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.xuKongWeaponLevel = 1;

            break;
         case WeaponType.Fire:
            if (PlayerData.S.dianBaoZhaLevel<10)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.fireWeaponLevel = 1;

            break;

         case WeaponType.LvQuan:
            if (PlayerData.S.HuoBaoZhaWeaponLevel<10)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.lvQuanWeaponLevel = 1;

            break;
         
         case WeaponType.Ice7:
            if (PlayerData.S.IceAllLevel<30)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.Ice7WeaponLevel = 1;

            break;
         
         case WeaponType.Huo7:
            if (PlayerData.S.HuoAllLevel<30)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.Huo7WeaponLevel = 1;

            break;
         
         case WeaponType.DianJiSu:
            if (PlayerData.S.DianAllLevel<30)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.DianJiSuWeaponLevel = 1;

            break;
         
         case WeaponType.DianSanShe:
            if (PlayerData.S.DianAllLevel<10)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.DianSanSheWeaponLevel = 1;

            break;
         
         case WeaponType.HuoFenLie:
            if (PlayerData.S.HuoAllLevel<30)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.HuoFenLieWeaponLevel = 1;

            break;
         
         case WeaponType.JianQi:
            if (PlayerData.S.HuoAllLevel <30)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.jianQiWeaponLevel = 1;

            break;
         
         case WeaponType.HeiAnQuXian:
            if (PlayerData.S.HeiAnAllLevel<30)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.HeiAnQuXianWeaponLevel = 1;

            break;
         
         case WeaponType.HeiAnHuiXuan:
            if (PlayerData.S.HeiAnHuiXuanWeaponLevel<30)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.HeiAnHuiXuanWeaponLevel = 1;

            break;
         
         case WeaponType.Ice4BaoZha:
            if (PlayerData.S.IceAllLevel<30)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.Ice4BaoZhaWeaponLevel = 1;

            break;

         case WeaponType.HeiDong:
            if (PlayerData.S.HeiAnAllLevel<100)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.heiDongWeaponLevel = 1;

            break;
         
         
         case WeaponType.IcePen:
            if (PlayerData.S.IceAllLevel<100)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.IcePenWeaponLevel = 1;

            break;
         
         case WeaponType.HuoDiPen:
            if (PlayerData.S.HuoAllLevel<100)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.HuoDiPenWeaponLevel = 1;

            break;
         
         
         case WeaponType.DianLuoLei5:
            if (PlayerData.S.DianAllLevel<100)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "条件不满足");
               return;
            }
            PlayerData.S.DianLuoLei5WeaponLevel = 1;
            break;
      }

      foreach (var item in items)
      {
         switch (item._propType)
         {
            case PropConfig.PropType.LingHun:
               GlobalPlayerAttribute.BloodEnergy -= item.count;
               break;
            case PropConfig.PropType.WeaponFragment:
               switch (item.quality)
               {
                  case 2:
                     BagController.S.PropList[102].Count -= item.count;
                     break;
                  case 3:
                     BagController.S.PropList[103].Count -= item.count;
                     break;
                  case 4:
                     BagController.S.PropList[104].Count -= item.count;
                     break;
                  case 5:
                     BagController.S.PropList[105].Count -= item.count;
                     break;
               }

               break;

            case PropConfig.PropType.JingCui:
               switch (item.quality)
               {
                  case 2:
                     BagController.S.PropList[202].Count -= item.count;
                     break;
                  case 3:
                     BagController.S.PropList[203].Count -= item.count;
                     break;
                  case 4:
                     BagController.S.PropList[204].Count -= item.count;
                     break;
                  case 5:
                     BagController.S.PropList[205].Count -= item.count;
                     break;
               }
               break;
         }
      }
      ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "恭喜成功解锁新武器！");
      RefreshWeaponList();
      
   }

   public void SuoButtonClick(object[] obj)
   {
      LevelPanel.gameObject.SetActive(false);
      ExpPanel.gameObject.SetActive(false);
      WeaponType type = (WeaponType)obj[0];

      switch (type)
      {
         case WeaponType.HuoBaoZha:
            currentJieSuoType = WeaponType.HuoBaoZha;
            ShowJieSuo(WeaponType.HuoBaoZha);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.DianBaoZha:
            currentJieSuoType = WeaponType.DianBaoZha;
            ShowJieSuo(WeaponType.DianBaoZha);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.IceBaoZha:
            currentJieSuoType = WeaponType.IceBaoZha;
            ShowJieSuo(WeaponType.IceBaoZha);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.PuTong3:
            currentJieSuoType = WeaponType.PuTong3;
            ShowJieSuo(WeaponType.PuTong3);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.LvQuan:
            currentJieSuoType = WeaponType.LvQuan;
            ShowJieSuo(WeaponType.LvQuan);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.XuKong:
            currentJieSuoType = WeaponType.XuKong;
            ShowJieSuo(WeaponType.XuKong);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.Fire:
            currentJieSuoType = WeaponType.Fire;
            ShowJieSuo(WeaponType.Fire);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.HeiDong:
            currentJieSuoType = WeaponType.HeiDong;
            ShowJieSuo(WeaponType.HeiDong);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.JianQi:
            currentJieSuoType = WeaponType.JianQi;
            ShowJieSuo(WeaponType.JianQi);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.IcePen:
            currentJieSuoType = WeaponType.IcePen;
            ShowJieSuo(WeaponType.IcePen);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.Ice7:
            currentJieSuoType = WeaponType.Ice7;
            ShowJieSuo(WeaponType.Ice7);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.Ice4BaoZha:
            currentJieSuoType = WeaponType.Ice4BaoZha;
            ShowJieSuo(WeaponType.Ice4BaoZha);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.Huo7:
            currentJieSuoType = WeaponType.Huo7;
            ShowJieSuo(WeaponType.Huo7);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.HuoFenLie:
            currentJieSuoType = WeaponType.HuoFenLie;
            ShowJieSuo(WeaponType.HuoFenLie);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.HuoDiPen:
            currentJieSuoType = WeaponType.HuoDiPen;
            ShowJieSuo(WeaponType.HuoDiPen);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.HeiAnQuXian:
            currentJieSuoType = WeaponType.HeiAnQuXian;
            ShowJieSuo(WeaponType.HeiAnQuXian);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.HeiAnHuiXuan:
            currentJieSuoType = WeaponType.HeiAnHuiXuan;
            ShowJieSuo(WeaponType.HeiAnHuiXuan);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.HeiAnBaoZha:
            currentJieSuoType = WeaponType.HeiAnBaoZha;
            ShowJieSuo(WeaponType.HeiAnBaoZha);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.DianLuoLei5:
            currentJieSuoType = WeaponType.DianLuoLei5;
            ShowJieSuo(WeaponType.DianLuoLei5);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.DianSanShe:
            currentJieSuoType = WeaponType.DianSanShe;
            ShowJieSuo(WeaponType.DianSanShe);
            AttributePanel.gameObject.SetActive(false);
            break;
         
         case WeaponType.DianJiSu:
            currentJieSuoType = WeaponType.DianJiSu;
            ShowJieSuo(WeaponType.DianJiSu);
            AttributePanel.gameObject.SetActive(false);
            break;
      }
   }

   public void ClealYiZhuangBei(object[] obj)
   {
      foreach (Transform item in WeaponListContent.transform)
      {
         WeaponItem weaponItem = item.gameObject.GetComponent<WeaponItem>();
         weaponItem.yiZhuangBeiIcon.gameObject.SetActive(false);
      }
   }


   public void BgButtonClick(object[] obj)
   {
      LevelPanel.gameObject.SetActive(true);
      ExpPanel.gameObject.SetActive(true);
      WeaponType type = (WeaponType)obj[0];
      WeaponImage.sprite=WeaponConfig.GetWeaponSprite(type);
      switch (type)
      {
         case WeaponType.Primary:
            currentShowType = WeaponType.Primary;
            ShowAttribute(WeaponType.Primary);
            break;
         
         case WeaponType.PrimaryDian:
            currentShowType = WeaponType.PrimaryDian;
            ShowAttribute(WeaponType.PrimaryDian);
            break;
         
         case WeaponType.PrimaryHuo:
            currentShowType = WeaponType.PrimaryHuo;
            ShowAttribute(WeaponType.PrimaryHuo);
            break;
         
         case WeaponType.PrimaryHeiAn:
            currentShowType = WeaponType.PrimaryHeiAn;
            ShowAttribute(WeaponType.PrimaryHeiAn);
            break;
         
         case WeaponType.HuoBaoZha:
            currentShowType = WeaponType.HuoBaoZha;
            ShowAttribute(WeaponType.HuoBaoZha);
            break;
         
         case WeaponType.DianBaoZha:
            currentShowType = WeaponType.DianBaoZha;
            ShowAttribute(WeaponType.DianBaoZha);
            break;
         
         case WeaponType.IceBaoZha:
            currentShowType = WeaponType.IceBaoZha;
            ShowAttribute(WeaponType.IceBaoZha);
            break;
         
         case WeaponType.LvQuan:
            currentShowType = WeaponType.LvQuan;
            ShowAttribute(WeaponType.LvQuan);
            break;
         
         
         case WeaponType.XuKong:
            currentShowType = WeaponType.XuKong;
            ShowAttribute(WeaponType.XuKong);
            break;
         
         case WeaponType.PuTong3:
            currentShowType = WeaponType.PuTong3;
            ShowAttribute(WeaponType.PuTong3);
            break;
         
         case WeaponType.Fire:
            currentShowType = WeaponType.Fire;
            ShowAttribute(WeaponType.Fire);
            break;
         
         case WeaponType.JianQi:
            currentShowType = WeaponType.JianQi;
            ShowAttribute(WeaponType.JianQi);
            break;
         
         case WeaponType.HeiDong:
            currentShowType = WeaponType.HeiDong;
            ShowAttribute(WeaponType.HeiDong);
            break;
      }
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("BgButtonClick",BgButtonClick);
      ObserverModuleManager.S.UnRegisterEvent("SuoButtonClick",SuoButtonClick);
      ObserverModuleManager.S.UnRegisterEvent("ClearYiZhuangBei",ClealYiZhuangBei);
   }

   private void Awake()
   {
      ObserverModuleManager.S.RegisterEvent("ClearYiZhuangBei",ClealYiZhuangBei);
      ObserverModuleManager.S.RegisterEvent("BgButtonClick",BgButtonClick);
      ObserverModuleManager.S.RegisterEvent("SuoButtonClick",SuoButtonClick);

      
      JieSuoButton.onClick.AddListener(() => { JieSuo(); });
      
      exitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
         WindowController.S.RoleWindow.SetActive(true);
      });
   }
}
