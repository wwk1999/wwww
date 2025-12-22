using System;
using System.Collections.Generic;
using Gloabl;
using Mysql;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WeaponWindow : MonoBehaviour
{
   public Button primaryInstallButton; // 初始武器安装按钮
   public Button duInstallButton;//毒武器安装按钮
   public Button puTong3InstallButton;//普通3安装按钮
   public Button xukongInstallButton; //虚空武器安装按钮
   public Button fireInstallButton; // fire爆炸武器安装按钮
   public Button lvQuanInstallButton; // 绿圈武器安装按钮
   public Button heiDongInstallButton; // 黑洞武器安装按钮
   public Button exitButton; // 退出按钮

   
   public Button primaryJieSuoButton; // 初始武器解锁按钮
   public Button duJieSuoButton;//毒武器解锁按钮
   public Button puTong3JieSuoButton;//普通3解锁按钮
   public Button xukongJieSuoButton; //虚空武器解锁按钮
   public Button fireJieSuoButton; // fire爆炸武器解锁按钮
   public Button lvQuanJieSuoButton; // 绿圈武器解锁按钮
   public Button heiDongJieSuoButton; // 黑洞武器解锁按钮
   
   
   public Image primaryMask;//初始武器mask
   public Image duMask;//毒武器mask
   public Image puTong3Mask;//普通3mask
   public Image xukongMask; //虚空武器mask
   public Image fireMask; // fire爆炸武器mask
   public Image lvQuanMask; // 绿圈武器mask
   public Image heiDongMask; // 黑洞武器mask


   public GameObject InfoPanel;
   public GameObject UpPanel;


   public Image weaponImage;
   public TextMeshProUGUI desc;
   public TextMeshProUGUI teXiao;
   public Button upButton;

   public TextMeshProUGUI weaponName;
   public GameObject infoContent;
   public Button JieSuoButton;

   public void RefreshWeaponList()
   {
      InfoPanel.SetActive(false);
      UpPanel.SetActive(false);
      if (PlayerData.S.primaryWeaponLevel >= 1)
      {
         primaryJieSuoButton.gameObject.SetActive(false);
         primaryMask.gameObject.SetActive(false);
      }
      else
      {
         primaryJieSuoButton.gameObject.SetActive(true);
         primaryMask.gameObject.SetActive(true);
      }
      
      if (PlayerData.S.duWeaponLevel >= 1)
      {
         duJieSuoButton.gameObject.SetActive(false);
         duMask.gameObject.SetActive(false);
      }
      else
      {
         duJieSuoButton.gameObject.SetActive(true);
         duMask.gameObject.SetActive(true);
      }
      
      if (PlayerData.S.puTong3WeaponLevel >= 1)
      {
         puTong3JieSuoButton.gameObject.SetActive(false);
         puTong3Mask.gameObject.SetActive(false);
      }
      else
      {
         puTong3JieSuoButton.gameObject.SetActive(true);
         puTong3Mask.gameObject.SetActive(true);
      }
      
      if (PlayerData.S.xuKongWeaponLevel >= 1)
      {
         xukongJieSuoButton.gameObject.SetActive(false);
         xukongMask.gameObject.SetActive(false);
      }
      else
      {
         xukongJieSuoButton.gameObject.SetActive(true);
         xukongMask.gameObject.SetActive(true);
      }
      
      if (PlayerData.S.lvQuanWeaponLevel >= 1)
      {
         lvQuanJieSuoButton.gameObject.SetActive(false);
         lvQuanMask.gameObject.SetActive(false);
      }
      else
      {
         lvQuanJieSuoButton.gameObject.SetActive(true);
         lvQuanMask.gameObject.SetActive(true);
      }
      
      if (PlayerData.S.fireWeaponLevel >= 1)
      {
         fireJieSuoButton.gameObject.SetActive(false);
         fireMask.gameObject.SetActive(false);
      }
      else
      {
         fireJieSuoButton.gameObject.SetActive(true);
         fireMask.gameObject.SetActive(true);
      }
      
      if (PlayerData.S.heiDongWeaponLevel >= 1)
      {
         heiDongJieSuoButton.gameObject.SetActive(false);
         heiDongMask.gameObject.SetActive(false);
      }
      else
      {
         heiDongJieSuoButton.gameObject.SetActive(true);
         heiDongMask.gameObject.SetActive(true);
      }
   }
   
   private void OnEnable()
   {
      RefreshWeaponList();
   }

   private void Awake()
   {
      primaryInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.Primary;
      });
      fireInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.Fire;
      });
      xukongInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.XuKong;
      });
      
      lvQuanInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.LvQuan;
      });
      
      heiDongInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.HeiDong;
      });
      
      duInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.Du;
      });
      
      puTong3InstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.PuTong3;
      });
      
      exitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
         WindowController.S.RoleWindow.SetActive(true);
      });
   }
}
