using System;
using System.Collections.Generic;
using Config;
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
   
   public TextMeshProUGUI texiao1;
   public TextMeshProUGUI texiao2;
   public TextMeshProUGUI texiao3;
   public TextMeshProUGUI texiao4;
   public TextMeshProUGUI texiao5;
   public TextMeshProUGUI texiao6;
   public TextMeshProUGUI texiao7;

   public Button upButton;

   public TextMeshProUGUI weaponName1;
   public TextMeshProUGUI weaponName2;
   public TextMeshProUGUI weaponName3;
   public TextMeshProUGUI weaponName4;
   public TextMeshProUGUI weaponName5;
   public TextMeshProUGUI weaponName6;
   public TextMeshProUGUI weaponName7;

   public GameObject jieSuoContent;
   public Button JieSuoButton;

   public GameObject AttributeContent;
   public Button primaryShowButton; 
   public Button duShowButton;
   public Button puTong3ShowButton;
   public Button xukongShowButton; 
   public Button fireShowButton; 
   public Button lvQuanShowButton; 
   public Button heiDongShowButton;

   public ShenJiCaiLiao ShenJiCaiLiao;
   [NonSerialized] public WeaponType currentJieSuoType = WeaponType.None;

   public void HideNameAndDesc()
   {
      desc1.gameObject.SetActive(false);
      desc2.gameObject.SetActive(false);
      desc3.gameObject.SetActive(false);
      desc4.gameObject.SetActive(false);
      desc5.gameObject.SetActive(false);
      desc6.gameObject.SetActive(false);
      desc7.gameObject.SetActive(false);
      
      weaponName1.gameObject.SetActive(false);
      weaponName2.gameObject.SetActive(false);
      weaponName3.gameObject.SetActive(false);
      weaponName4.gameObject.SetActive(false);
      weaponName5.gameObject.SetActive(false);
      weaponName6.gameObject.SetActive(false);
      weaponName7.gameObject.SetActive(false);
      
      texiao1.gameObject.SetActive(false);
      texiao2.gameObject.SetActive(false);
      texiao3.gameObject.SetActive(false);
      texiao4.gameObject.SetActive(false);
      texiao5.gameObject.SetActive(false);
      texiao6.gameObject.SetActive(false);
      texiao7.gameObject.SetActive(false);

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
      }

      foreach (Transform item in AttributeContent.transform)
      {
         Destroy(item.gameObject);
      }

      var weaponAttribute = WeaponConfig.WeaponAttributeDic[weaponType];
      GameObject attack = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"),AttributeContent.transform);
      attack.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = "攻击力 :";
      attack.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = weaponAttribute.Attack.ToString();
      
      GameObject defense = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"),AttributeContent.transform);
      defense.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = "防御 :";
      defense.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = weaponAttribute.Defense.ToString();
      
      GameObject crit = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"),AttributeContent.transform);
      crit.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = "暴击 :";
      crit.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = weaponAttribute.Crit.ToString();
      
      GameObject hp = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"),AttributeContent.transform);
      hp.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = "生命值 :";
      hp.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = weaponAttribute.Hp.ToString();
      
      GameObject attackspeed = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/WeaponItem"),AttributeContent.transform);
      attackspeed.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = "攻击速度 :";
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
      }

      foreach (Transform child in jieSuoContent.transform)
      {
         Destroy(child.gameObject);
      }

      var cailiao = WeaponConfig.JieSuoCaiLiaoDic[weaponType];
      foreach (var item in cailiao)
      {
         var weaponItem = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/CaiLiaoItem"),jieSuoContent.transform);
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
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.WhiteJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("WhiteEdge");
                     break;
                  case 2:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.GreenJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("GreenEdge");
                     break;
                  case 3:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.BlueJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("BlueEdge");
                     break;
                  case 4:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.PurpleJingCui;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("PurpleEdge");
                     break;
                  case 5:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.OrangeJingCui;
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
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.WhiteWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("WhiteEdge");
                     break;
                  case 2:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.GreenWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("GreenEdge");
                     break;
                  case 3:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.BlueWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("BlueEdge");
                     break;
                  case 4:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.PurpleWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("PurpleEdge");
                     break;
                  case 5:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.OrangeWeaponFragment;
                     weaponItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                     weaponItem.transform.Find("prop/Edge").GetComponent<Animator>().Play("OrangeEdge");
                     break;
                  case 6:
                     weaponItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.RedWeaponFragment;
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
   }
   
   private void OnEnable()
   {
      RefreshWeaponList();
   }

   public void JieSuo()
   {
      switch (currentJieSuoType)
      {
         case WeaponType.Du:
            if (GlobalPlayerAttribute.BloodEnergy < 300 || !BagController.S.PropList.ContainsKey(202) ||
                BagController.S.PropList[202].Count < 3 || !BagController.S.PropList.ContainsKey(302) ||
                BagController.S.PropList[302].Count < 3)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
               return;
            }
            GlobalPlayerAttribute.BloodEnergy -= 300;
            BagController.S.PropList[202].Count -= 3;
            BagController.S.PropList[302].Count -= 3;
            PlayerData.S.duWeaponLevel = 1;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"恭喜成功解锁新武器！");
            RefreshWeaponList();
            break;
         
         case WeaponType.PuTong3:
            if (GlobalPlayerAttribute.BloodEnergy < 500 || !BagController.S.PropList.ContainsKey(203) ||
                BagController.S.PropList[203].Count < 3 || !BagController.S.PropList.ContainsKey(303) ||
                BagController.S.PropList[303].Count < 3)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
               return;
            }
            GlobalPlayerAttribute.BloodEnergy -= 500;
            BagController.S.PropList[203].Count -= 3;
            BagController.S.PropList[303].Count -= 3;
            PlayerData.S.puTong3WeaponLevel = 1;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"恭喜成功解锁新武器！");
            RefreshWeaponList();
            break;
         
         case WeaponType.XuKong:
            if (GlobalPlayerAttribute.BloodEnergy < 800 || !BagController.S.PropList.ContainsKey(203) ||
                BagController.S.PropList[203].Count < 5 || !BagController.S.PropList.ContainsKey(303) ||
                BagController.S.PropList[303].Count < 5)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
               return;
            }
            GlobalPlayerAttribute.BloodEnergy -= 800;
            BagController.S.PropList[203].Count -= 5;
            BagController.S.PropList[303].Count -= 5;
            PlayerData.S.xuKongWeaponLevel = 1;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"恭喜成功解锁新武器！");
            RefreshWeaponList();
            break;
         case WeaponType.Fire:
            if (GlobalPlayerAttribute.BloodEnergy < 1500 || !BagController.S.PropList.ContainsKey(204) ||
                BagController.S.PropList[204].Count < 5 || !BagController.S.PropList.ContainsKey(304) ||
                BagController.S.PropList[304].Count < 5)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
               return;
            }
            GlobalPlayerAttribute.BloodEnergy -= 1500;
            BagController.S.PropList[204].Count -= 5;
            BagController.S.PropList[304].Count -= 5;
            PlayerData.S.fireWeaponLevel = 1;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"恭喜成功解锁新武器！");
            RefreshWeaponList();
            break;
         
         case WeaponType.LvQuan:
            if (GlobalPlayerAttribute.BloodEnergy < 2000 || !BagController.S.PropList.ContainsKey(204) ||
                BagController.S.PropList[204].Count < 8 || !BagController.S.PropList.ContainsKey(304) ||
                BagController.S.PropList[304].Count < 8)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
               return;
            }
            GlobalPlayerAttribute.BloodEnergy -= 2000;
            BagController.S.PropList[204].Count -= 8;
            BagController.S.PropList[304].Count -= 8;
            PlayerData.S.lvQuanWeaponLevel = 1;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"恭喜成功解锁新武器！");
            RefreshWeaponList();
            break;
         
         case WeaponType.HeiDong:
            if (GlobalPlayerAttribute.BloodEnergy < 3000 || !BagController.S.PropList.ContainsKey(205) ||
                BagController.S.PropList[205].Count < 5 || !BagController.S.PropList.ContainsKey(305) ||
                BagController.S.PropList[305].Count < 5)
            {
               ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
               return;
            }
            GlobalPlayerAttribute.BloodEnergy -= 3000;
            BagController.S.PropList[205].Count -= 5;
            BagController.S.PropList[305].Count -= 5;
            PlayerData.S.heiDongWeaponLevel = 1;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"恭喜成功解锁新武器！");
            RefreshWeaponList();
            break;
      }
   }

   private void Awake()
   {
      primaryShowButton.onClick.AddListener(()=>
      {
         ShenJiCaiLiao.showType = WeaponType.Primary;
         ShowAttribute(WeaponType.Primary);
      });
      
      duShowButton.onClick.AddListener(()=>
      {
         ShenJiCaiLiao.showType = WeaponType.Du;
         ShowAttribute(WeaponType.Du);
      });
      
      puTong3ShowButton.onClick.AddListener(()=>
      {
         ShenJiCaiLiao.showType = WeaponType.PuTong3;
         ShowAttribute(WeaponType.PuTong3);
      });
      
      xukongShowButton.onClick.AddListener(()=>
      {
         ShenJiCaiLiao.showType = WeaponType.XuKong;
         ShowAttribute(WeaponType.XuKong);
      });
      
      fireShowButton.onClick.AddListener(()=>
      {
         ShenJiCaiLiao.showType = WeaponType.Fire;
         ShowAttribute(WeaponType.Fire);
      });
      
      lvQuanShowButton.onClick.AddListener(()=>
      {
         ShenJiCaiLiao.showType = WeaponType.LvQuan;
         ShowAttribute(WeaponType.LvQuan);
      });
      
      heiDongShowButton.onClick.AddListener(()=>
      {
         ShenJiCaiLiao.showType = WeaponType.HeiDong;
         ShowAttribute(WeaponType.HeiDong);
      });
      
      
      
      
      
      
      JieSuoButton.onClick.AddListener(() =>
      {
         JieSuo();
      });
      duJieSuoButton.onClick.AddListener(() =>
      {
         currentJieSuoType = WeaponType.Du;
         ShowJieSuo(WeaponType.Du);
      });
      puTong3JieSuoButton.onClick.AddListener(() =>
      {
         currentJieSuoType = WeaponType.PuTong3;
         ShowJieSuo(WeaponType.PuTong3);
      });
      xukongJieSuoButton.onClick.AddListener(() =>
      {
         currentJieSuoType = WeaponType.XuKong;
         ShowJieSuo(WeaponType.XuKong);
      });
      fireJieSuoButton.onClick.AddListener(() =>
      {
         currentJieSuoType = WeaponType.Fire;
         ShowJieSuo(WeaponType.Fire);
      });
      lvQuanJieSuoButton.onClick.AddListener(() =>
      {
         currentJieSuoType = WeaponType.LvQuan;
         ShowJieSuo(WeaponType.LvQuan);
      });
      heiDongJieSuoButton.onClick.AddListener(() =>
      {
         currentJieSuoType = WeaponType.HeiDong;
         ShowJieSuo(WeaponType.HeiDong);
      });
      
      
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
