using System;
using System.Collections.Generic;
using Config;
using Gloabl;
using Mysql;
using Spine.Unity;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class WeaponWindow : MonoBehaviour
{
   public Button primaryInstallButton; // 初始武器安装按钮
   public Button duInstallButton; //毒武器安装按钮
   public Button puTong3InstallButton; //普通3安装按钮
   public Button xukongInstallButton; //虚空武器安装按钮
   public Button fireInstallButton; // fire爆炸武器安装按钮
   public Button lvQuanInstallButton; // 绿圈武器安装按钮
   public Button heiDongInstallButton; // 黑洞武器安装按钮
   public Button jianQiInstallButton; // 剑气武器安装按钮
   public Button exitButton; // 退出按钮


   public Button primaryJieSuoButton; // 初始武器解锁按钮
   public Button duJieSuoButton; //毒武器解锁按钮
   public Button puTong3JieSuoButton; //普通3解锁按钮
   public Button xukongJieSuoButton; //虚空武器解锁按钮
   public Button fireJieSuoButton; // fire爆炸武器解锁按钮
   public Button lvQuanJieSuoButton; // 绿圈武器解锁按钮
   public Button heiDongJieSuoButton; // 黑洞武器解锁按钮
   public Button jianQiJieSuoButton; // 剑气武器解锁按钮

   public Button primaryShowButton;
   public Button duShowButton;
   public Button puTong3ShowButton;
   public Button xukongShowButton;
   public Button fireShowButton;
   public Button lvQuanShowButton;
   public Button heiDongShowButton;
   public Button jianQiShowButton;


   public Image primaryMask; //初始武器mask
   public Image duMask; //毒武器mask
   public Image puTong3Mask; //普通3mask
   public Image xukongMask; //虚空武器mask
   public Image fireMask; // fire爆炸武器mask
   public Image lvQuanMask; // 绿圈武器mask
   public Image heiDongMask; // 黑洞武器mask
   public Image jianQiMask; // 剑气武器mask



   public GameObject InfoPanel;
   public GameObject UpPanel;
   public GameObject JieSuoPanel;
   public GameObject AttributePanel;


   public Image weaponImage;
   public TextMeshProUGUI desc1;
   public TextMeshProUGUI desc2;
   public TextMeshProUGUI desc3;
   public TextMeshProUGUI desc4;
   public TextMeshProUGUI desc5;
   public TextMeshProUGUI desc6;
   public TextMeshProUGUI desc7;
   public TextMeshProUGUI desc8;


   public TextMeshProUGUI texiao1;
   public TextMeshProUGUI texiao2;
   public TextMeshProUGUI texiao3;
   public TextMeshProUGUI texiao4;
   public TextMeshProUGUI texiao5;
   public TextMeshProUGUI texiao6;
   public TextMeshProUGUI texiao7;
   public TextMeshProUGUI texiao8;


   public Button upButton;

   public TextMeshProUGUI weaponName1;
   public TextMeshProUGUI weaponName2;
   public TextMeshProUGUI weaponName3;
   public TextMeshProUGUI weaponName4;
   public TextMeshProUGUI weaponName5;
   public TextMeshProUGUI weaponName6;
   public TextMeshProUGUI weaponName7;
   public TextMeshProUGUI weaponName8;


   public GameObject jieSuoContent;
   public Button JieSuoButton;

   public GameObject AttributeContent;

   public ShenJiCaiLiao ShenJiCaiLiao;

   public GameObject PrimaryEquipIcon;
   public GameObject DuEquipIcon;
   public GameObject PuTong3EquipIcon;
   public GameObject XuKongEquipIcon;
   public GameObject FireEquipIcon;
   public GameObject LvQuanEquipIcon;
   public GameObject HeiDongEquipIcon;
   public GameObject JianQiEquipIcon;


   public TextMeshProUGUI WeaponName1;
   public TextMeshProUGUI WeaponName2;
   public TextMeshProUGUI WeaponName3;
   public TextMeshProUGUI WeaponName4;
   public TextMeshProUGUI WeaponName5;
   public TextMeshProUGUI WeaponName6;
   public TextMeshProUGUI WeaponName7;
   public TextMeshProUGUI WeaponName8;

   
   public TextMeshProUGUI Desc1;
   public TextMeshProUGUI Desc2;
   public TextMeshProUGUI Desc3;
   public TextMeshProUGUI Desc4;
   public TextMeshProUGUI Desc5;
   public TextMeshProUGUI Desc6;
   public TextMeshProUGUI Desc7;
   public TextMeshProUGUI Desc8;

   
   public TextMeshProUGUI TeXiao1;
   public TextMeshProUGUI TeXiao2;
   public TextMeshProUGUI TeXiao3;
   public TextMeshProUGUI TeXiao4;
   public TextMeshProUGUI TeXiao5;
   public TextMeshProUGUI TeXiao6;
   public TextMeshProUGUI TeXiao7;
   public TextMeshProUGUI TeXiao8;
   
   public TextMeshProUGUI Equip1;
   public TextMeshProUGUI Equip2;
   public TextMeshProUGUI Equip3;
   public TextMeshProUGUI Equip4;
   public TextMeshProUGUI Equip5;
   public TextMeshProUGUI Equip6;
   public TextMeshProUGUI Equip7;
   public TextMeshProUGUI Equip8;
   
   public TextMeshProUGUI YiEquip1;
   public TextMeshProUGUI YiEquip2;
   public TextMeshProUGUI YiEquip3;
   public TextMeshProUGUI YiEquip4;
   public TextMeshProUGUI YiEquip5;
   public TextMeshProUGUI YiEquip6;
   public TextMeshProUGUI YiEquip7;
   public TextMeshProUGUI YiEquip8;
   
   public TextMeshProUGUI ShenJiText;
   public TextMeshProUGUI JieSuoText;
   public  TextMeshProUGUI WeaponInfoName1;
   public  TextMeshProUGUI WeaponInfoName2;
   public  TextMeshProUGUI WeaponInfoName3;
   public  TextMeshProUGUI WeaponInfoName4;
   public  TextMeshProUGUI WeaponInfoName5;
   public  TextMeshProUGUI WeaponInfoName6;
   public  TextMeshProUGUI WeaponInfoName7;
   public  TextMeshProUGUI WeaponInfoName8;
   
   //魂器

   public TextMeshProUGUI HunQi1Desc;
   
   public TextMeshProUGUI HunQi2Desc;
   
   public TextMeshProUGUI HunQi3Desc;
   
   public TextMeshProUGUI HunQi4Desc;
   
   public TextMeshProUGUI HunQi5Desc;
   
   public TextMeshProUGUI AllHunQiText;
   public TextMeshProUGUI AllHunQiLevel;
   
   public Button AttributeButton;
   public Button HunQiButton;
   public GameObject HunQiPanel;
   public TextMeshProUGUI AttributeButtonText;
   public TextMeshProUGUI HunQiButtonText;
   
   public Slider HunQiExSlider;
   public TextMeshProUGUI HunQiCurrentEx;
   public TextMeshProUGUI HunQiMaxEx;
   public TextMeshProUGUI HunQiLevel;



   public void SwitchLanguage()
   {
            WeaponName1.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName1;
            WeaponName2.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName2;
            WeaponName3.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName3;
            WeaponName4.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName4;
            WeaponName5.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName5;
            WeaponName6.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName6;
            WeaponName7.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName7;
            WeaponName8.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName8;
            
            Desc1.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Desc1;
            Desc2.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Desc2;
            Desc3.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Desc3;
            Desc4.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Desc4;
            Desc5.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Desc5;
            Desc6.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Desc6;
            Desc7.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Desc7;
            Desc8.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Desc8;
            
            TeXiao1.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.TeXiao1;
            TeXiao2.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.TeXiao2;
            TeXiao3.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.TeXiao3;
            TeXiao4.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.TeXiao4;
            TeXiao5.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.TeXiao5;
            TeXiao6.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.TeXiao6;
            TeXiao7.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.TeXiao7;
            TeXiao8.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.TeXiao8;
            
            Equip1.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Install;
            Equip2.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Install;
            Equip3.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Install;
            Equip4.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Install;
            Equip5.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Install;
            Equip6.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Install;
            Equip7.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Install;
            Equip8.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Install;
            
            YiEquip1.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.YiInstall;
            YiEquip2.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.YiInstall;
            YiEquip3.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.YiInstall;
            YiEquip4.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.YiInstall;
            YiEquip5.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.YiInstall;
            YiEquip6.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.YiInstall;
            YiEquip7.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.YiInstall;
            YiEquip8.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.YiInstall;
            
            ShenJiText.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.ShenJi;
            JieSuoText.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.JieSuo;
            WeaponInfoName1.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName1;
            WeaponInfoName2.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName2;
            WeaponInfoName3.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName3;
            WeaponInfoName4.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName4;
            WeaponInfoName5.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName5;
            WeaponInfoName6.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName6;
            WeaponInfoName7.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName7;
            WeaponInfoName8.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName8;

            HunQiButtonText.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.HunQi;
           AttributeButtonText.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.Attribute;

   }


   
   [NonSerialized] public WeaponType currentJieSuoType = WeaponType.None;
   [NonSerialized] public WeaponType currentShowType = WeaponType.None;

   public void SetHunQiPanel()
   {
      HunQi1Desc.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage
         .WeaponHunQiDic[currentShowType].HunQi1;
      HunQi2Desc.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage
         .WeaponHunQiDic[currentShowType].HunQi2;
      HunQi3Desc.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage
         .WeaponHunQiDic[currentShowType].HunQi3;
      HunQi4Desc.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage
         .WeaponHunQiDic[currentShowType].HunQi4;
      HunQi5Desc.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage
         .WeaponHunQiDic[currentShowType].HunQi5;
      
      switch (currentShowType)
      {
         case WeaponType.Primary:
            HunQiLevel.text="Lv "+PlayerData.S.primaryHunQiLevel;
            HunQiExSlider.value = PlayerData.S.primaryHunQiEx;
            HunQiCurrentEx.text = PlayerData.S.primaryHunQiEx.ToString();
            switch (PlayerData.S.primaryHunQiLevel)
            {
               case 0:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Primary].Level1;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Primary].Level1.ToString();
                  break;
               case 1:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Primary].Level2;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Primary].Level2.ToString();
                  break;
               case 2:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Primary].Level3;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Primary].Level3.ToString();
                  break;
               case 3:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Primary].Level4;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Primary].Level4.ToString();
                  break;
               case 4:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Primary].Level5;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Primary].Level5.ToString();
                  break;
            }
            break;
         
         case WeaponType.Du:
            HunQiLevel.text="Lv "+PlayerData.S.duHunQiLevel;
            HunQiExSlider.value = PlayerData.S.duHunQiEx;
            HunQiCurrentEx.text = PlayerData.S.duHunQiEx.ToString();
            switch (PlayerData.S.duHunQiLevel)
            {
               case 0:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Du].Level1;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Du].Level1.ToString();
                  break;
               case 1:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Du].Level2;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Du].Level2.ToString();
                  break;
               case 2:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Du].Level3;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Du].Level3.ToString();
                  break;
               case 3:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Du].Level4;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Du].Level4.ToString();
                  break;
               case 4:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Du].Level5;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Du].Level5.ToString();
                  break;
            }
            break;
         
         case WeaponType.PuTong3:
            HunQiLevel.text="Lv "+PlayerData.S.puTong3HunQiLevel;
            HunQiExSlider.value = PlayerData.S.puTong3HunQiEx;
            HunQiCurrentEx.text = PlayerData.S.puTong3HunQiEx.ToString();
            switch (PlayerData.S.puTong3HunQiLevel)
            {
               case 0:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level1;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level1.ToString();
                  break;
               case 1:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level2;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level2.ToString();
                  break;
               case 2:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level3;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level3.ToString();
                  break;
               case 3:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level4;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level4.ToString();
                  break;
               case 4:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level5;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level5.ToString();
                  break;
            }
            break;
         
         
         case WeaponType.XuKong:
            HunQiLevel.text="Lv "+PlayerData.S.xuKongHunQiLevel;
            HunQiExSlider.value = PlayerData.S.xuKongHunQiEx;
            HunQiCurrentEx.text = PlayerData.S.xuKongHunQiEx.ToString();
            switch (PlayerData.S.xuKongHunQiLevel)
            {
               case 0:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.XuKong].Level1;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.XuKong].Level1.ToString();
                  break;
               case 1:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.XuKong].Level2;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.XuKong].Level2.ToString();
                  break;
               case 2:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.XuKong].Level3;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.XuKong].Level3.ToString();
                  break;
               case 3:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.XuKong].Level4;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.XuKong].Level4.ToString();
                  break;
               case 4:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.XuKong].Level5;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.XuKong].Level5.ToString();
                  break;
            }
            break;
         
         case WeaponType.Fire:
            HunQiLevel.text="Lv "+PlayerData.S.fireHunQiLevel;
            HunQiExSlider.value = PlayerData.S.fireHunQiEx;
            HunQiCurrentEx.text = PlayerData.S.fireHunQiEx.ToString();
            switch (PlayerData.S.fireHunQiLevel)
            {
               case 0:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Fire].Level1;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Fire].Level1.ToString();
                  break;
               case 1:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Fire].Level2;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Fire].Level2.ToString();
                  break;
               case 2:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Fire].Level3;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Fire].Level3.ToString();
                  break;
               case 3:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Fire].Level4;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Fire].Level4.ToString();
                  break;
               case 4:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.Fire].Level5;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.Fire].Level5.ToString();
                  break;
            }
            break;
         
         case WeaponType.LvQuan:
            HunQiLevel.text="Lv "+PlayerData.S.lvQuanHunQiLevel;
            HunQiExSlider.value = PlayerData.S.lvQuanHunQiEx;
            HunQiCurrentEx.text = PlayerData.S.lvQuanHunQiEx.ToString();
            switch (PlayerData.S.lvQuanHunQiLevel)
            {
               case 0:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level1;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level1.ToString();
                  break;
               case 1:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level2;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level2.ToString();
                  break;
               case 2:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level3;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level3.ToString();
                  break;
               case 3:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level4;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level4.ToString();
                  break;
               case 4:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level5;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level5.ToString();
                  break;
            }
            break;
         
         case WeaponType.HeiDong:
            HunQiLevel.text="Lv "+PlayerData.S.heiDongHunQiLevel;
            HunQiExSlider.value = PlayerData.S.heiDongHunQiEx;
            HunQiCurrentEx.text = PlayerData.S.heiDongHunQiEx.ToString();
            switch (PlayerData.S.heiDongHunQiLevel)
            {
               case 0:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level1;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level1.ToString();
                  break;
               case 1:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level2;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level2.ToString();
                  break;
               case 2:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level3;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level3.ToString();
                  break;
               case 3:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level4;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level4.ToString();
                  break;
               case 4:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level5;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level5.ToString();
                  break;
            }
            break;
         
         case WeaponType.JianQi:
            HunQiLevel.text="Lv "+PlayerData.S.jianQiHunQiLevel;
            HunQiExSlider.value = PlayerData.S.jianQiHunQiEx;
            HunQiCurrentEx.text = PlayerData.S.jianQiHunQiEx.ToString();
            switch (PlayerData.S.jianQiHunQiLevel)
            {
               case 0:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.JianQi].Level1;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.JianQi].Level1.ToString();
                  break;
               case 1:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.JianQi].Level2;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.JianQi].Level2.ToString();
                  break;
               case 2:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.JianQi].Level3;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.JianQi].Level3.ToString();
                  break;
               case 3:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.JianQi].Level4;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.JianQi].Level4.ToString();
                  break;
               case 4:
                  HunQiExSlider.maxValue = WeaponConfig.HunQiExDic[WeaponType.JianQi].Level5;
                  HunQiMaxEx.text =WeaponConfig.HunQiExDic[WeaponType.JianQi].Level5.ToString();
                  break;
            }
            break;
      }
   }

   public void RefreshEquipIcon()
   {
      PrimaryEquipIcon.gameObject.SetActive(false);
      DuEquipIcon.gameObject.SetActive(false);
      PuTong3EquipIcon.gameObject.SetActive(false);
      XuKongEquipIcon.gameObject.SetActive(false);
      FireEquipIcon.gameObject.SetActive(false);
      LvQuanEquipIcon.gameObject.SetActive(false);
      HeiDongEquipIcon.gameObject.SetActive(false);
      JianQiEquipIcon.gameObject.SetActive(false);

      switch (PlayerData.S.playerWeaponType)
      {
         case WeaponType.Primary:
            PrimaryEquipIcon.gameObject.SetActive(true);
            break;
         case WeaponType.Du:
            DuEquipIcon.gameObject.SetActive(true);
            break;
         case WeaponType.PuTong3:
            PuTong3EquipIcon.gameObject.SetActive(true);
            break;
         case WeaponType.XuKong:
            XuKongEquipIcon.gameObject.SetActive(true);
            break;
         case WeaponType.Fire:
            FireEquipIcon.gameObject.SetActive(true);
            break;
         case WeaponType.LvQuan:
            LvQuanEquipIcon.gameObject.SetActive(true);
            break;
         case WeaponType.HeiDong:
            HeiDongEquipIcon.gameObject.SetActive(true);
            break;
         case WeaponType.JianQi:
            JianQiEquipIcon.gameObject.SetActive(true);
            break;
      }
   }
   
   public void HideNameAndDesc()
   {
      desc1.gameObject.SetActive(false);
      desc2.gameObject.SetActive(false);
      desc3.gameObject.SetActive(false);
      desc4.gameObject.SetActive(false);
      desc5.gameObject.SetActive(false);
      desc6.gameObject.SetActive(false);
      desc7.gameObject.SetActive(false);
      desc8.gameObject.SetActive(false);


      weaponName1.gameObject.SetActive(false);
      weaponName2.gameObject.SetActive(false);
      weaponName3.gameObject.SetActive(false);
      weaponName4.gameObject.SetActive(false);
      weaponName5.gameObject.SetActive(false);
      weaponName6.gameObject.SetActive(false);
      weaponName7.gameObject.SetActive(false);
      weaponName8.gameObject.SetActive(false);


      texiao1.gameObject.SetActive(false);
      texiao2.gameObject.SetActive(false);
      texiao3.gameObject.SetActive(false);
      texiao4.gameObject.SetActive(false);
      texiao5.gameObject.SetActive(false);
      texiao6.gameObject.SetActive(false);
      texiao7.gameObject.SetActive(false);
      texiao8.gameObject.SetActive(false);


   }

   public void ShowAttribute(WeaponType weaponType)
   {
      HideNameAndDesc();
      upButton.gameObject.SetActive(true);
      JieSuoPanel.gameObject.SetActive(false);
      AttributePanel.gameObject.SetActive(true);
      InfoPanel.SetActive(true);
      UpPanel.SetActive(true);

      switch (weaponType)
      {
         case WeaponType.Primary:
            desc1.gameObject.SetActive(true);
            weaponName1.gameObject.SetActive(true);  
            texiao1.gameObject.SetActive(true);
            if (PlayerData.S.primaryWeaponLevel < 2)
            {
               weaponName1.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName1;;
            }
            else
            {
               var level = PlayerData.S.primaryWeaponLevel - 1;
               weaponName1.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName1+"+"+level;
            }
            break;
         case WeaponType.Du:
            desc2.gameObject.SetActive(true);
            weaponName2.gameObject.SetActive(true);
            texiao2.gameObject.SetActive(true);
            if (PlayerData.S.duWeaponLevel < 2)
            {
               weaponName2.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName2;;
            }
            else
            {
               var level = PlayerData.S.duWeaponLevel - 1;
               weaponName2.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName1+"+"+level;
            }
            break;
         case WeaponType.PuTong3:
            desc3.gameObject.SetActive(true);
            weaponName3.gameObject.SetActive(true);
            texiao3.gameObject.SetActive(true);
            if (PlayerData.S.puTong3WeaponLevel < 2)
            {
               weaponName3.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName3;
            }
            else
            {
               var level = PlayerData.S.puTong3WeaponLevel - 1;
               weaponName3.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName3+"+"+level;
            }
            break;
         case WeaponType.XuKong:
            desc4.gameObject.SetActive(true);
            weaponName4.gameObject.SetActive(true);
            texiao4.gameObject.SetActive(true);
            if (PlayerData.S.xuKongWeaponLevel < 2)
            {
               weaponName4.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName4;
            }
            else
            {
               var level = PlayerData.S.xuKongWeaponLevel - 1;
               weaponName4.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName4+"+"+level;
            }
            break;
         case WeaponType.Fire:
            desc5.gameObject.SetActive(true);
            weaponName5.gameObject.SetActive(true);
            texiao5.gameObject.SetActive(true);
            if (PlayerData.S.fireWeaponLevel < 2)
            {
               weaponName5.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName5;
            }
            else
            {
               var level = PlayerData.S.fireWeaponLevel - 1;
               weaponName5.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName5+"+"+level;
            }
            break;
         case WeaponType.LvQuan:
            desc6.gameObject.SetActive(true);
            weaponName6.gameObject.SetActive(true);
            texiao6.gameObject.SetActive(true);
            if (PlayerData.S.lvQuanWeaponLevel < 2)
            {
               weaponName6.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName6;
            }
            else
            {
               var level = PlayerData.S.lvQuanWeaponLevel - 1;
               weaponName6.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName6+"+"+level;
            }
            break;
         case WeaponType.HeiDong:
            desc7.gameObject.SetActive(true);
            weaponName7.gameObject.SetActive(true);
            texiao7.gameObject.SetActive(true);
            if (PlayerData.S.heiDongWeaponLevel < 2)
            {
               weaponName7.text =LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName7;
            }
            else
            {
               var level = PlayerData.S.heiDongWeaponLevel - 1;
               weaponName7.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName7+"+"+level;
            }
            break;
         
         case WeaponType.JianQi:
            desc8.gameObject.SetActive(true);
            weaponName8.gameObject.SetActive(true);
            texiao8.gameObject.SetActive(true);
            if (PlayerData.S.heiDongWeaponLevel < 2)
            {
               weaponName7.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName8;
            }
            else
            {
               var level = PlayerData.S.jianQiWeaponLevel - 1;
               weaponName7.text=LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.WeaponName8+"+"+level;
            }
            break;
      }

      foreach (Transform item in AttributeContent.transform)
      {
         Destroy(item.gameObject);
      }

      var weaponAttribute = WeaponConfig.WeaponBaseAttributeDic[weaponType];
      int level1 = 0;
      switch (weaponType)
      {
         case WeaponType.Primary:
            level1 = PlayerData.S.primaryWeaponLevel;
            break;
         case WeaponType.Du:
            level1 = PlayerData.S.duWeaponLevel;
            break;
         case WeaponType.PuTong3:
            level1 = PlayerData.S.puTong3WeaponLevel;
            break;
         case WeaponType.XuKong:
            level1 = PlayerData.S.xuKongWeaponLevel;
            break;
         case WeaponType.Fire:
            level1 = PlayerData.S.fireWeaponLevel;
            break;
         case WeaponType.LvQuan:
            level1 = PlayerData.S.lvQuanWeaponLevel;
            break;
         case WeaponType.HeiDong:
            level1 = PlayerData.S.heiDongWeaponLevel;
            break;
      }
      GameObject attack =
         Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"), AttributeContent.transform);
      attack.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack+" :";
      attack.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = Mathf.RoundToInt(weaponAttribute.Attack*(1+(level1-1)*GlobalPlayerAttribute.WeaponShenJiPercent)).ToString();

      GameObject defense =
         Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"), AttributeContent.transform);
      defense.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense+" :";
      defense.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
         Mathf.RoundToInt(weaponAttribute.Defense * (1 + (level1 - 1) * GlobalPlayerAttribute.WeaponShenJiPercent)).ToString();

      GameObject crit = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"), AttributeContent.transform);
      crit.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit+" :";
      crit.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
         Mathf.RoundToInt(weaponAttribute.Crit * (1 + (level1 - 1) * GlobalPlayerAttribute.WeaponShenJiPercent)).ToString();

      GameObject hp = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"), AttributeContent.transform);
      hp.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp+" :";
      hp.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
         Mathf.RoundToInt(weaponAttribute.Hp * (1 + (level1 - 1) * GlobalPlayerAttribute.WeaponShenJiPercent)).ToString();

      GameObject attackspeed =
         Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"), AttributeContent.transform);
      attackspeed.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack+" :";
      attackspeed.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = weaponAttribute.AttackSpeed.ToString();
   }

   public void ShowJieSuo(WeaponType weaponType)
   {
      HideNameAndDesc();
      upButton.gameObject.SetActive(false);
      JieSuoPanel.gameObject.SetActive(true);
      AttributePanel.gameObject.SetActive(false);
      InfoPanel.SetActive(true);
      UpPanel.SetActive(true);
      switch (weaponType)
      {
         case WeaponType.Primary:
            desc1.gameObject.SetActive(true);
            weaponName1.gameObject.SetActive(true);
            texiao1.gameObject.SetActive(true);
            break;
         case WeaponType.Du:
            desc2.gameObject.SetActive(true);
            weaponName2.gameObject.SetActive(true);
            texiao2.gameObject.SetActive(true);
            break;
         case WeaponType.PuTong3:
            desc3.gameObject.SetActive(true);
            weaponName3.gameObject.SetActive(true);
            texiao3.gameObject.SetActive(true);
            break;
         case WeaponType.XuKong:
            desc4.gameObject.SetActive(true);
            weaponName4.gameObject.SetActive(true);
            texiao4.gameObject.SetActive(true);
            break;
         case WeaponType.Fire:
            desc5.gameObject.SetActive(true);
            weaponName5.gameObject.SetActive(true);
            texiao5.gameObject.SetActive(true);
            break;
         case WeaponType.LvQuan:
            desc6.gameObject.SetActive(true);
            weaponName6.gameObject.SetActive(true);
            texiao6.gameObject.SetActive(true);
            break;
         case WeaponType.HeiDong:
            desc7.gameObject.SetActive(true);
            weaponName7.gameObject.SetActive(true);
            texiao7.gameObject.SetActive(true);
            break;
         case WeaponType.JianQi:
            desc8.gameObject.SetActive(true);
            weaponName8.gameObject.SetActive(true);
            texiao8.gameObject.SetActive(true);
            break;
      }

      foreach (Transform child in jieSuoContent.transform)
      {
         Destroy(child.gameObject);
      }

      var cailiao = WeaponConfig.JieSuoCaiLiaoDic[weaponType];
      foreach (var item in cailiao)
      {
         var weaponItem = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/CaiLiaoItem"), jieSuoContent.transform);
         switch (item.PropType)
         {
            case PropConfig.PropType.LingHun:
               weaponItem.transform.Find("prop/ImageBg").gameObject.SetActive(false);
               weaponItem.transform.Find("prop/Edge").gameObject.SetActive(false);
               weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.LingHun;
               weaponItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = item.Count.ToString();
               break;
            case PropConfig.PropType.JingCui:
               switch (item.Quality)
               {
                  case 1:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.WhiteJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("WhiteEdge");
                     break;
                  case 2:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.GreenJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("GreenEdge");
                     break;
                  case 3:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.BlueJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("BlueEdge");
                     break;
                  case 4:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.PurpleJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("PurpleEdge");
                     break;
                  case 5:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.OrangeJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("OrangeEdge");
                     break;
                  case 6:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.RedJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("RedEdge");
                     break;
               }

               weaponItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = item.Count.ToString();
               break;
            case PropConfig.PropType.WeaponFragment:
               switch (item.Quality)
               {
                  case 1:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.WhiteWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("WhiteEdge");
                     break;
                  case 2:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.GreenWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("GreenEdge");
                     break;
                  case 3:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.BlueWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("BlueEdge");
                     break;
                  case 4:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.PurpleWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("PurpleEdge");
                     break;
                  case 5:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.OrangeWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("OrangeEdge");
                     break;
                  case 6:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.RedWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("RedEdge");
                     break;
               }

               weaponItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = item.Count.ToString();
               break;
         }
      }
   }


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
      
      if (PlayerData.S.jianQiWeaponLevel >= 1)
      {
         jianQiJieSuoButton.gameObject.SetActive(false);
         jianQiMask.gameObject.SetActive(false);
      }
      else
      {
         jianQiJieSuoButton.gameObject.SetActive(true);
         jianQiMask.gameObject.SetActive(true);
      }
   }

   private void OnEnable()
   {
      RefreshWeaponList();
      RefreshEquipIcon();
      SwitchLanguage();
      AllHunQiText.text = LanguageConfig.LanguageItems[PlayerData.S.langType].WeaponWindowLanguage.AllHunQiLevel;
      AllHunQiLevel.text = (PlayerData.S.primaryHunQiLevel + PlayerData.S.duHunQiLevel +
                            PlayerData.S.puTong3HunQiLevel + PlayerData.S.fireHunQiLevel +
                            PlayerData.S.xuKongHunQiLevel + PlayerData.S.lvQuanHunQiLevel +
                            PlayerData.S.heiDongHunQiLevel + PlayerData.S.jianQiHunQiLevel).ToString();
   }

   public void JieSuo()
   {
      switch (currentJieSuoType)
      {
         case WeaponType.Du:
            if (GlobalPlayerAttribute.BloodEnergy < 300 || !BagController.S.PropList.ContainsKey(202) ||
                BagController.S.PropList[202].Count < 3 || !BagController.S.PropList.ContainsKey(102) ||
                BagController.S.PropList[102].Count < 3)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "材料不足");
               return;
            }

            GlobalPlayerAttribute.BloodEnergy -= 300;
            BagController.S.PropList[202].Count -= 3;
            BagController.S.PropList[102].Count -= 3;
            PlayerData.S.duWeaponLevel = 1;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "恭喜成功解锁新武器！");
            RefreshWeaponList();
            break;

         case WeaponType.PuTong3:
            if (GlobalPlayerAttribute.BloodEnergy < 500 || !BagController.S.PropList.ContainsKey(203) ||
                BagController.S.PropList[203].Count < 3 || !BagController.S.PropList.ContainsKey(103) ||
                BagController.S.PropList[103].Count < 3)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "材料不足");
               return;
            }

            GlobalPlayerAttribute.BloodEnergy -= 500;
            BagController.S.PropList[203].Count -= 3;
            BagController.S.PropList[103].Count -= 3;
            PlayerData.S.puTong3WeaponLevel = 1;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "恭喜成功解锁新武器！");
            RefreshWeaponList();
            break;

         case WeaponType.XuKong:
            if (GlobalPlayerAttribute.BloodEnergy < 800 || !BagController.S.PropList.ContainsKey(203) ||
                BagController.S.PropList[203].Count < 5 || !BagController.S.PropList.ContainsKey(103) ||
                BagController.S.PropList[103].Count < 5)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "材料不足");
               return;
            }

            GlobalPlayerAttribute.BloodEnergy -= 800;
            BagController.S.PropList[203].Count -= 5;
            BagController.S.PropList[103].Count -= 5;
            PlayerData.S.xuKongWeaponLevel = 1;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "恭喜成功解锁新武器！");
            RefreshWeaponList();
            break;
         case WeaponType.Fire:
            if (GlobalPlayerAttribute.BloodEnergy < 1500 || !BagController.S.PropList.ContainsKey(204) ||
                BagController.S.PropList[204].Count < 5 || !BagController.S.PropList.ContainsKey(104) ||
                BagController.S.PropList[104].Count < 5)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "材料不足");
               return;
            }

            GlobalPlayerAttribute.BloodEnergy -= 1500;
            BagController.S.PropList[204].Count -= 5;
            BagController.S.PropList[104].Count -= 5;
            PlayerData.S.fireWeaponLevel = 1;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "恭喜成功解锁新武器！");
            RefreshWeaponList();
            break;

         case WeaponType.LvQuan:
            if (GlobalPlayerAttribute.BloodEnergy < 2000 || !BagController.S.PropList.ContainsKey(204) ||
                BagController.S.PropList[204].Count < 5 || !BagController.S.PropList.ContainsKey(104) ||
                BagController.S.PropList[104].Count < 5)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "材料不足");
               return;
            }

            GlobalPlayerAttribute.BloodEnergy -= 2000;
            BagController.S.PropList[204].Count -= 5;
            BagController.S.PropList[104].Count -= 5;
            PlayerData.S.lvQuanWeaponLevel = 1;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "恭喜成功解锁新武器！");
            RefreshWeaponList();
            break;

         case WeaponType.HeiDong:
            if (GlobalPlayerAttribute.BloodEnergy < 3000 || !BagController.S.PropList.ContainsKey(205) ||
                BagController.S.PropList[205].Count < 5 || !BagController.S.PropList.ContainsKey(105) ||
                BagController.S.PropList[105].Count < 5)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "材料不足");
               return;
            }

            GlobalPlayerAttribute.BloodEnergy -= 3000;
            BagController.S.PropList[205].Count -= 5;
            BagController.S.PropList[105].Count -= 5;
            PlayerData.S.heiDongWeaponLevel = 1;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "恭喜成功解锁新武器！");
            RefreshWeaponList();
            break;
         
         case WeaponType.JianQi:
            if (GlobalPlayerAttribute.BloodEnergy < 3000 || !BagController.S.PropList.ContainsKey(205) ||
                BagController.S.PropList[205].Count < 5 || !BagController.S.PropList.ContainsKey(105) ||
                BagController.S.PropList[105].Count < 5)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "材料不足");
               return;
            }

            GlobalPlayerAttribute.BloodEnergy -= 3000;
            BagController.S.PropList[205].Count -= 5;
            BagController.S.PropList[105].Count -= 5;
            PlayerData.S.jianQiWeaponLevel = 1;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "恭喜成功解锁新武器！");
            RefreshWeaponList();
            break;
      }
   }

   private void Awake()
   {
      primaryShowButton.onClick.AddListener(() =>
      {
         currentShowType = WeaponType.Primary;
         ShenJiCaiLiao.showType = WeaponType.Primary;
         AttributeButton.gameObject.SetActive(true);
         HunQiButton.gameObject.SetActive(true);
         SetHunQiPanel();
         ShowAttribute(WeaponType.Primary);
      });

      duShowButton.onClick.AddListener(() =>
      {
         currentShowType = WeaponType.Du;
         ShenJiCaiLiao.showType = WeaponType.Du;
         AttributeButton.gameObject.SetActive(true);
         HunQiButton.gameObject.SetActive(true);
         SetHunQiPanel();
         ShowAttribute(WeaponType.Du);
      });

      puTong3ShowButton.onClick.AddListener(() =>
      {
         currentShowType = WeaponType.PuTong3;
         ShenJiCaiLiao.showType = WeaponType.PuTong3; 
         AttributeButton.gameObject.SetActive(true);
         HunQiButton.gameObject.SetActive(true);
         SetHunQiPanel();
         ShowAttribute(WeaponType.PuTong3);
      });

      xukongShowButton.onClick.AddListener(() =>
      {
         currentShowType = WeaponType.XuKong;
         ShenJiCaiLiao.showType = WeaponType.XuKong;
         AttributeButton.gameObject.SetActive(true);
         HunQiButton.gameObject.SetActive(true);
         SetHunQiPanel();
         ShowAttribute(WeaponType.XuKong);
      });

      fireShowButton.onClick.AddListener(() =>
      {
         currentShowType = WeaponType.Fire;
         ShenJiCaiLiao.showType = WeaponType.Fire;
         AttributeButton.gameObject.SetActive(true);
         HunQiButton.gameObject.SetActive(true);
         SetHunQiPanel();
         ShowAttribute(WeaponType.Fire);
      });

      lvQuanShowButton.onClick.AddListener(() =>
      {
         currentShowType = WeaponType.LvQuan;
         ShenJiCaiLiao.showType = WeaponType.LvQuan;
         AttributeButton.gameObject.SetActive(true);
         HunQiButton.gameObject.SetActive(true);
         SetHunQiPanel();
         ShowAttribute(WeaponType.LvQuan);
      });

      heiDongShowButton.onClick.AddListener(() =>
      {
         currentShowType = WeaponType.HeiDong;
         ShenJiCaiLiao.showType = WeaponType.HeiDong;
         AttributeButton.gameObject.SetActive(true);
         HunQiButton.gameObject.SetActive(true);
         SetHunQiPanel();
         ShowAttribute(WeaponType.HeiDong);
      });
      
      jianQiShowButton.onClick.AddListener(() =>
      {
         currentShowType = WeaponType.JianQi;
         ShenJiCaiLiao.showType = WeaponType.JianQi;
         AttributeButton.gameObject.SetActive(true);
         HunQiButton.gameObject.SetActive(true);
         SetHunQiPanel();
         ShowAttribute(WeaponType.JianQi);
      });
      


      AttributeButton.onClick.AddListener(() =>
      {
         AttributePanel.gameObject.SetActive(true);
         HunQiPanel.gameObject.SetActive(false);
      });
      
      HunQiButton.onClick.AddListener(() =>
      {
         AttributePanel.gameObject.SetActive(false);
         HunQiPanel.gameObject.SetActive(true);
      });




      JieSuoButton.onClick.AddListener(() => { JieSuo(); });
      duJieSuoButton.onClick.AddListener(() =>
      {
         currentJieSuoType = WeaponType.Du;
         ShowJieSuo(WeaponType.Du);
         AttributeButton.gameObject.SetActive(false);
         HunQiButton.gameObject.SetActive(false);
         AttributePanel.gameObject.SetActive(false);
         HunQiPanel.gameObject.SetActive(false);
      });
      puTong3JieSuoButton.onClick.AddListener(() =>
      {
         currentJieSuoType = WeaponType.PuTong3;
         ShowJieSuo(WeaponType.PuTong3);
         AttributeButton.gameObject.SetActive(false);
         HunQiButton.gameObject.SetActive(false);
         AttributePanel.gameObject.SetActive(false);
         HunQiPanel.gameObject.SetActive(false);
      });
      xukongJieSuoButton.onClick.AddListener(() =>
      {
         currentJieSuoType = WeaponType.XuKong;
         ShowJieSuo(WeaponType.XuKong);
         AttributeButton.gameObject.SetActive(false);
         HunQiButton.gameObject.SetActive(false);
         AttributePanel.gameObject.SetActive(false);
         HunQiPanel.gameObject.SetActive(false);
      });
      fireJieSuoButton.onClick.AddListener(() =>
      {
         currentJieSuoType = WeaponType.Fire;
         ShowJieSuo(WeaponType.Fire);
         AttributeButton.gameObject.SetActive(false);
         HunQiButton.gameObject.SetActive(false);
         AttributePanel.gameObject.SetActive(false);
         HunQiPanel.gameObject.SetActive(false);
      });
      lvQuanJieSuoButton.onClick.AddListener(() =>
      {
         currentJieSuoType = WeaponType.LvQuan;
         ShowJieSuo(WeaponType.LvQuan);
         AttributeButton.gameObject.SetActive(false);
         HunQiButton.gameObject.SetActive(false);
         AttributePanel.gameObject.SetActive(false);
         HunQiPanel.gameObject.SetActive(false);
      });
      heiDongJieSuoButton.onClick.AddListener(() =>
      {
         currentJieSuoType = WeaponType.HeiDong;
         ShowJieSuo(WeaponType.HeiDong);
         AttributeButton.gameObject.SetActive(false);
         HunQiButton.gameObject.SetActive(false);
         AttributePanel.gameObject.SetActive(false);
         HunQiPanel.gameObject.SetActive(false);
      });
      
      jianQiJieSuoButton.onClick.AddListener(() =>
      {
         currentJieSuoType = WeaponType.JianQi;
         ShowJieSuo(WeaponType.JianQi);
         AttributeButton.gameObject.SetActive(false);
         HunQiButton.gameObject.SetActive(false);
         AttributePanel.gameObject.SetActive(false);
         HunQiPanel.gameObject.SetActive(false);
      });



      primaryInstallButton.onClick.AddListener(() => { PlayerData.S.playerWeaponType = WeaponType.HeiAnHuiXuan; StoreController.S.SaveStoreData();RefreshEquipIcon();});
      fireInstallButton.onClick.AddListener(() => { PlayerData.S.playerWeaponType = WeaponType.Fire; StoreController.S.SaveStoreData();RefreshEquipIcon();});
      xukongInstallButton.onClick.AddListener(() => { PlayerData.S.playerWeaponType = WeaponType.XuKong; StoreController.S.SaveStoreData();RefreshEquipIcon();});

      lvQuanInstallButton.onClick.AddListener(() => {PlayerData.S.playerWeaponType = WeaponType.LvQuan; StoreController.S.SaveStoreData();RefreshEquipIcon();});

      heiDongInstallButton.onClick.AddListener(() => { PlayerData.S.playerWeaponType= WeaponType.HeiDong;StoreController.S.SaveStoreData(); RefreshEquipIcon();});
      jianQiInstallButton.onClick.AddListener(() => { PlayerData.S.playerWeaponType= WeaponType.JianQi;StoreController.S.SaveStoreData(); RefreshEquipIcon();});

      duInstallButton.onClick.AddListener(() => { PlayerData.S.playerWeaponType= WeaponType.Du; StoreController.S.SaveStoreData();RefreshEquipIcon();});

      puTong3InstallButton.onClick.AddListener(() => { PlayerData.S.playerWeaponType = WeaponType.PuTong3; StoreController.S.SaveStoreData();RefreshEquipIcon();});

      exitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
         WindowController.S.RoleWindow.SetActive(true);
      });
      upButton.onClick.AddListener(() =>
      {
         ShenJi();
      });
   }


   public void ShenJi()
   {
      var cailiaoList = WeaponConfig.ShenJiCaiLiaoDic[currentShowType];


      foreach (var cailiao in cailiaoList)
      {
         switch (cailiao.PropType)
         {
            case PropConfig.PropType.LingHun:
               if (GlobalPlayerAttribute.BloodEnergy < cailiao.Count)
               {
                  ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足！");
                  return;
               }
               break;
            case PropConfig.PropType.JingCui:
               switch (cailiao.Quality)
               {
                  case 1:
                     if (!BagController.S.PropList.ContainsKey(201) ||
                         BagController.S.PropList[201].Count < cailiao.Count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "材料不足！");
                        return;
                     }

                     break;
                  case 2:
                     if (!BagController.S.PropList.ContainsKey(202) ||
                         BagController.S.PropList[202].Count < cailiao.Count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "材料不足！");
                        return;
                     }

                     break;
                  case 3:
                     if (!BagController.S.PropList.ContainsKey(203) ||
                         BagController.S.PropList[203].Count < cailiao.Count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "材料不足！");
                        return;
                     }

                     break;
                  case 4:
                     if (!BagController.S.PropList.ContainsKey(204) ||
                         BagController.S.PropList[204].Count < cailiao.Count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "材料不足！");
                        return;
                     }

                     break;
                  case 5:
                     if (!BagController.S.PropList.ContainsKey(205) ||
                         BagController.S.PropList[205].Count < cailiao.Count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "材料不足！");
                        return;
                     }

                     break;
                  case 6:
                     if (!BagController.S.PropList.ContainsKey(206) ||
                         BagController.S.PropList[206].Count < cailiao.Count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "材料不足！");
                        return;
                     }
                     break;
               }

               break;

            case PropConfig.PropType.WeaponFragment:
               switch (cailiao.Quality)
               {
                  case 1:
                     if (!BagController.S.PropList.ContainsKey(101) ||
                         BagController.S.PropList[101].Count < cailiao.Count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足！");
                        return;
                     }
                     break;
                  case 2:
                     if (!BagController.S.PropList.ContainsKey(102) ||
                         BagController.S.PropList[102].Count < cailiao.Count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足！");
                        return;
                     }
                     break;
                  case 3:
                     if (!BagController.S.PropList.ContainsKey(103) ||
                         BagController.S.PropList[103].Count < cailiao.Count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足！");
                        return;
                     }
                     break;
                  case 4:
                     if (!BagController.S.PropList.ContainsKey(104) ||
                         BagController.S.PropList[104].Count < cailiao.Count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足！");
                        return;
                     }
                     break;
                  case 5:
                     if (!BagController.S.PropList.ContainsKey(105) ||
                         BagController.S.PropList[105].Count < cailiao.Count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足！");
                        return;
                     }
                     break;
                  case 6:
                     if (!BagController.S.PropList.ContainsKey(106) ||
                         BagController.S.PropList[106].Count < cailiao.Count)
                     {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足！");
                        return;
                     }
                     break;
               }
               
               break;
         }
      }


      foreach (var cailiao in cailiaoList)
      {
         switch (cailiao.PropType)
         {
            case PropConfig.PropType.LingHun:
               GlobalPlayerAttribute.BloodEnergy -= cailiao.Count;
               break;
            case PropConfig.PropType.JingCui:
               switch (cailiao.Quality)
               {
                  case 1:
                     BagController.S.PropList[201].Count -= cailiao.Count;
                     break;
                  case 2:
                     BagController.S.PropList[202].Count -= cailiao.Count;
                     break;
                  case 3:
                     BagController.S.PropList[203].Count -= cailiao.Count;
                     break;
                  case 4:
                     BagController.S.PropList[204].Count -= cailiao.Count;
                     break;
                  case 5:
                     BagController.S.PropList[205].Count -= cailiao.Count;
                     break;
                  case 6:
                     BagController.S.PropList[206].Count -= cailiao.Count;
                     break;
               }
               break;

            case PropConfig.PropType.WeaponFragment:
               switch (cailiao.Quality)
               {
                  case 1:
                     BagController.S.PropList[101].Count -= cailiao.Count;
                     break;
                  case 2:
                     BagController.S.PropList[102].Count -= cailiao.Count;
                     break;
                  case 3:
                     BagController.S.PropList[103].Count -= cailiao.Count;
                     break;
                  case 4:
                     BagController.S.PropList[104].Count -= cailiao.Count;
                     break;
                  case 5:
                     BagController.S.PropList[105].Count -= cailiao.Count;
                     break;
                  case 6:
                     BagController.S.PropList[106].Count -= cailiao.Count;
                     break;
               }
               break;
         }
      }

      switch (currentShowType)
      {
         case WeaponType.Primary:
            PlayerData.S.primaryWeaponLevel++;
            break;
         case WeaponType.Du:
            PlayerData.S.duWeaponLevel++;
            break;
         case WeaponType.PuTong3:
            PlayerData.S.puTong3WeaponLevel++;
            break;
         case WeaponType.XuKong:
            PlayerData.S.xuKongWeaponLevel++;
            break;
         case WeaponType.Fire:
            PlayerData.S.fireWeaponLevel++;
            break;
         case WeaponType.LvQuan:
            PlayerData.S.lvQuanWeaponLevel++;
            break;
         case WeaponType.HeiDong:
            PlayerData.S.heiDongWeaponLevel++;
            break;
      }
      ShowAttribute(currentShowType);
      StoreController.S.SaveStoreData();
   }
}
