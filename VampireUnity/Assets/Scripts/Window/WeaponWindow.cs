using System;
using System.Collections.Generic;
using Gloabl;
using Mysql;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;


public class WeaponWindow : MonoBehaviour
{
   public Image weaponPanelImage;//武器界面image
   public Button primaryInstallButton; // 初始武器安装按钮
   public Button twoInstallButton; // 第二个武器安装按钮
   public Button threeInstallButton; // 第三个武器安装按钮
   public Button fourInstallButton; // 第四个武器安装按钮
   public Button lvQuanInstallButton; // 绿圈武器安装按钮
   public Button HeiDongInstallButton; // 绿圈武器安装按钮
   public Button DuInstallButton;
   public Button PuTong3InstallButton;
   public Button exitButton; // 退出按钮


   
   private void Awake()
   {
      primaryInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.Primary;
         //GameController.S.gamePlayer.weaponType = WeaponType.Primary;
      });
      twoInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.LanBao;
        // GameController.S.gamePlayer.weaponType = WeaponType.Two;
      });
      threeInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.Fire;
      });
      fourInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.XuKong;
      });
      
      lvQuanInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.LvQuan;
      });
      
      HeiDongInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.HeiDong;
      });
      
      DuInstallButton.onClick.AddListener(() =>
      {
         GlobalPlayerAttribute.CurrentWeaponType= WeaponType.Du;
      });
      
      PuTong3InstallButton.onClick.AddListener(() =>
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
