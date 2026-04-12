using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponItem : MonoBehaviour
{
   public WeaponType  type;
   public Image weaponImage;
   public GameObject yiZhuangBeiIcon;
   public Button intallbutton;
   public GameObject suo;
   public Button suoButton;
   public GameObject mask;
   public Button bgButton;
   public TextMeshProUGUI Name1;
   public TextMeshProUGUI Name2;
   public TextMeshProUGUI Name3;
   public TextMeshProUGUI Name4;
   public TextMeshProUGUI Name5;
   public TextMeshProUGUI Name6;
   public Image bg;
   public TextMeshProUGUI levelText;


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
   public void SetName(int quality, string name)
   {
      Name1.gameObject.SetActive(false);
      Name2.gameObject.SetActive(false);
      Name3.gameObject.SetActive(false);
      Name4.gameObject.SetActive(false);
      Name5.gameObject.SetActive(false);
      Name6.gameObject.SetActive(false);

      levelText.text = "Lv." + GetWeaponLevel(type);
      switch (quality)
      {
         case 1:
            Name1.gameObject.SetActive(true);
            Name1.text = name;
            break;
         case 2:
            Name2.gameObject.SetActive(true);
            Name2.text = name;
            break;
         case 3:
            Name3.gameObject.SetActive(true);
            Name3.text = name;
            break;
         case 4:
            Name4.gameObject.SetActive(true);
            Name4.text = name;
            break;
         case 5:
            Name5.gameObject.SetActive(true);
            Name5.text = name;
            break;
         case 6:
            Name6.gameObject.SetActive(true);
            Name6.text = name;
            break;
      }
   }

   public void SetWeapon()
   {
      switch (WeaponConfig.WeaponQualityDic[type])
      {
         case 1:
            bg.sprite = ResourcesConfig.WhiteBg;
            break;
         case 2:
            bg.sprite = ResourcesConfig.GreenBg;
            break;
         case 3:
            bg.sprite = ResourcesConfig.BlueBg;
            break;
         case 4:
            bg.sprite = ResourcesConfig.PurpleBg;
            break;
         case 5:
            bg.sprite = ResourcesConfig.OrangeBg;
            break;
         case 6:
            bg.sprite = ResourcesConfig.RedBg;
            break;
      }
      
      switch (type)
      {
         case WeaponType.Primary:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.Primary);
            SetName(WeaponConfig.WeaponQualityDic[WeaponType.Primary], WeaponConfig.WeaponNameDic[WeaponType.Primary]);
            suo.gameObject.SetActive(false);
            mask.SetActive(false);
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.Primary;
            });
            weaponImage.sprite = ResourcesConfig.Primary;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.Primary);
            });
            break;
         case WeaponType.PrimaryHuo:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.PrimaryHuo);
            SetName(WeaponConfig.WeaponQualityDic[WeaponType.PrimaryHuo], WeaponConfig.WeaponNameDic[WeaponType.PrimaryHuo]);
            suo.gameObject.SetActive(false);
            mask.SetActive(false);
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.PrimaryHuo;
            });
            weaponImage.sprite = ResourcesConfig.PrimaryHuo;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.PrimaryHuo);
            });
            break;
         case WeaponType.PrimaryDian:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.PrimaryDian);
            SetName(WeaponConfig.WeaponQualityDic[WeaponType.PrimaryDian], WeaponConfig.WeaponNameDic[WeaponType.PrimaryDian]);
            suo.gameObject.SetActive(false);
            mask.SetActive(false);
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.PrimaryDian;
            });
            weaponImage.sprite = ResourcesConfig.PrimaryDian;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.PrimaryDian);
            });
            break;
         case WeaponType.PrimaryHeiAn:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.PrimaryHeiAn);
            SetName(WeaponConfig.WeaponQualityDic[WeaponType.PrimaryHeiAn], WeaponConfig.WeaponNameDic[WeaponType.PrimaryHeiAn]);
            suo.gameObject.SetActive(false);
            mask.SetActive(false);
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.PrimaryHeiAn;
            });
            weaponImage.sprite = ResourcesConfig.PrimaryHeiAn;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.PrimaryHeiAn);
            });
            break;
         
         case WeaponType.HuoBaoZha:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.HuoBaoZha);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.HuoBaoZha], WeaponConfig.WeaponNameDic[WeaponType.HuoBaoZha]);

            if (PlayerData.S.HuoBaoZhaWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.HuoBaoZha;
            });
            weaponImage.sprite = ResourcesConfig.Du;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.HuoBaoZha);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.HuoBaoZha);
            });
            break;
         
         
         case WeaponType.DianBaoZha:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.DianBaoZha);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.DianBaoZha], WeaponConfig.WeaponNameDic[WeaponType.DianBaoZha]);

            if (PlayerData.S.dianBaoZhaLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.DianBaoZha;
            });
            weaponImage.sprite = ResourcesConfig.DianBaoZha;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.DianBaoZha);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.DianBaoZha);
            });
            break;
         
         
         case WeaponType.IceBaoZha:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.IceBaoZha);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.IceBaoZha], WeaponConfig.WeaponNameDic[WeaponType.IceBaoZha]);

            if (PlayerData.S.iceBaoZhaLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.IceBaoZha;
            });
            weaponImage.sprite = ResourcesConfig.IceBaoZha;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.IceBaoZha);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.IceBaoZha);
            });
            break;
         
         
         case WeaponType.HeiDong:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.HeiDong);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.HeiDong], WeaponConfig.WeaponNameDic[WeaponType.HeiDong]);

            if (PlayerData.S.heiDongWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.HeiDong;
            });
            weaponImage.sprite = ResourcesConfig.HeiDong;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.HeiDong);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.HeiDong);
            });
            break;
         
         case WeaponType.LvQuan:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.LvQuan);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.LvQuan], WeaponConfig.WeaponNameDic[WeaponType.LvQuan]);

            if (PlayerData.S.lvQuanWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.LvQuan;
            });
            weaponImage.sprite = ResourcesConfig.LvQuan;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.LvQuan);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.LvQuan);
            });
            break;
         
         case WeaponType.Fire:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.Fire);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.Fire], WeaponConfig.WeaponNameDic[WeaponType.Fire]);

            if (PlayerData.S.fireWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.Fire;
            });
            weaponImage.sprite = ResourcesConfig.Fire;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.Fire);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.Fire);
            });
            break;
         
         case WeaponType.XuKong:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.XuKong);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.XuKong], WeaponConfig.WeaponNameDic[WeaponType.XuKong]);

            if (PlayerData.S.xuKongWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.XuKong;
            });
            weaponImage.sprite = ResourcesConfig.XuKong;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.XuKong);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.XuKong);
            });
            break;
         
         case WeaponType.JianQi:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.JianQi);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.JianQi], WeaponConfig.WeaponNameDic[WeaponType.JianQi]);

            if (PlayerData.S.jianQiWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.JianQi;
            });
            weaponImage.sprite = ResourcesConfig.JianQi;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.JianQi);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.JianQi);
            });
            break;
         
         
         
         case WeaponType.PuTong3:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.PuTong3);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.PuTong3], WeaponConfig.WeaponNameDic[WeaponType.PuTong3]);

            if (PlayerData.S.puTong3WeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.PuTong3;
            });
            weaponImage.sprite = ResourcesConfig.PuTong3;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.PuTong3);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.PuTong3);
            });
            break;
         
         
         case WeaponType.IcePen:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.IcePen);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.IcePen], WeaponConfig.WeaponNameDic[WeaponType.IcePen]);

            if (PlayerData.S.IcePenWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.IcePen;
            });
            weaponImage.sprite = ResourcesConfig.IcePen;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.IcePen);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.IcePen);
            });
            break;
         
         
         case WeaponType.Ice7:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.Ice7);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.Ice7], WeaponConfig.WeaponNameDic[WeaponType.Ice7]);

            if (PlayerData.S.Ice7WeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.Ice7;
            });
            weaponImage.sprite = ResourcesConfig.Ice7;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.Ice7);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.Ice7);
            });
            break;
         
         
         case WeaponType.Ice4BaoZha:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.Ice4BaoZha);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.Ice4BaoZha], WeaponConfig.WeaponNameDic[WeaponType.Ice4BaoZha]);

            if (PlayerData.S.Ice4BaoZhaWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.Ice4BaoZha;
            });
            weaponImage.sprite = ResourcesConfig.Ice4BaoZha;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.Ice4BaoZha);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.Ice4BaoZha);
            });
            break;
         
         
         case WeaponType.HuoFenLie:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.HuoFenLie);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.HuoFenLie], WeaponConfig.WeaponNameDic[WeaponType.HuoFenLie]);

            if (PlayerData.S.HuoFenLieWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.HuoFenLie;
            });
            weaponImage.sprite = ResourcesConfig.HuoFenLie;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.HuoFenLie);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.HuoFenLie);
            });
            break;
         
         
         case WeaponType.HuoDiPen:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.HuoDiPen);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.HuoDiPen], WeaponConfig.WeaponNameDic[WeaponType.HuoDiPen]);

            if (PlayerData.S.HuoDiPenWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.HuoDiPen;
            });
            weaponImage.sprite = ResourcesConfig.HuoDiPen;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.HuoDiPen);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.HuoDiPen);
            });
            break;
         
         
         
         case WeaponType.Huo7:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.Huo7);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.Huo7], WeaponConfig.WeaponNameDic[WeaponType.Huo7]);

            if (PlayerData.S.Huo7WeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.Huo7;
            });
            weaponImage.sprite = ResourcesConfig.Huo7;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.Huo7);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.Huo7);
            });
            break;
         
         
         case WeaponType.HeiAnQuXian:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.HeiAnQuXian);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.HeiAnQuXian], WeaponConfig.WeaponNameDic[WeaponType.HeiAnQuXian]);

            if (PlayerData.S.HeiAnQuXianWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.HeiAnQuXian;
            });
            weaponImage.sprite = ResourcesConfig.HeiAnQuXian;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.HeiAnQuXian);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.HeiAnQuXian);
            });
            break;
         
         
         case WeaponType.HeiAnHuiXuan:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.HeiAnHuiXuan);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.HeiAnHuiXuan], WeaponConfig.WeaponNameDic[WeaponType.HeiAnHuiXuan]);

            if (PlayerData.S.HeiAnHuiXuanWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.HeiAnHuiXuan;
            });
            weaponImage.sprite = ResourcesConfig.HeiAnHuiXuan;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.HeiAnHuiXuan);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.HeiAnHuiXuan);
            });
            break;
         
         
         case WeaponType.HeiAnBaoZha:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.HeiAnBaoZha);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.HeiAnBaoZha], WeaponConfig.WeaponNameDic[WeaponType.HeiAnBaoZha]);

            if (PlayerData.S.HeiAnBaoZhaWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.HeiAnBaoZha;
            });
            weaponImage.sprite = ResourcesConfig.HeiAnBaoZha;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.HeiAnBaoZha);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.HeiAnBaoZha);
            });
            break;
         
         
         case WeaponType.DianSanShe:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.DianSanShe);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.DianSanShe], WeaponConfig.WeaponNameDic[WeaponType.DianSanShe]);

            if (PlayerData.S.DianSanSheWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.DianSanShe;
            });
            weaponImage.sprite = ResourcesConfig.DianSanShe;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.DianSanShe);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.DianSanShe);
            });
            break;
         
         
         case WeaponType.DianLuoLei5:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.DianLuoLei5);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.DianLuoLei5], WeaponConfig.WeaponNameDic[WeaponType.DianLuoLei5]);

            if (PlayerData.S.DianLuoLei5WeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.DianLuoLei5;
            });
            weaponImage.sprite = ResourcesConfig.DianLuoLei5;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.DianLuoLei5);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.DianLuoLei5);
            });
            break;
         
         
         case WeaponType.DianJiSu:
            yiZhuangBeiIcon.gameObject.SetActive(PlayerData.S.playerWeaponType==WeaponType.DianJiSu);

            SetName(WeaponConfig.WeaponQualityDic[WeaponType.DianJiSu], WeaponConfig.WeaponNameDic[WeaponType.DianJiSu]);

            if (PlayerData.S.DianJiSuWeaponLevel < 1)
            {
               suo.gameObject.SetActive(true);
               mask.SetActive(true);
            }
            else
            {
               suo.gameObject.SetActive(false);
               mask.SetActive(false);
            }
            intallbutton.onClick.RemoveAllListeners();
            intallbutton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("ClearYiZhuangBei");
               yiZhuangBeiIcon.gameObject.SetActive(true);
               PlayerData.S.playerWeaponType = WeaponType.DianJiSu;
            });
            weaponImage.sprite = ResourcesConfig.DianJiSu;
            bgButton.onClick.RemoveAllListeners();
            bgButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("BgButtonClick",WeaponType.DianJiSu);
            });
            suoButton.onClick.RemoveAllListeners();
            suoButton.onClick.AddListener(() =>
            {
               ObserverModuleManager.S.SendEvent("SuoButtonClick",WeaponType.DianJiSu);
            });
            break;
      }
   }
}
