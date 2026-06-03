using System;
using Config;
using Equip;
using Spine.Unity;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ChiBangWindow : MonoBehaviour
{
   private ChiBangType CurrentClickChiBangType=ChiBangType.None;
   public TextMeshProUGUI AllLevel;
   public Slider AllLevelSlider;
   public TextMeshProUGUI AllLevelLeftText;
   public TextMeshProUGUI AllLevelRightText;

   public GameObject ChiBangContent;
   public GameObject RightContent;

   public GameObject Blue1;
   public GameObject Blue2;
   public GameObject Blue3;
   public GameObject Blue4;
   public GameObject Blue5;
   public GameObject Blue6;
   public GameObject Blue7;
   public GameObject Blue8;
   
   public GameObject Green1;
   public GameObject Green2;
   public GameObject Green3;
   public GameObject Green4;
   public GameObject Green5;
   public GameObject Green6;
   
   public GameObject Purple1;
   public GameObject Purple2;
   public GameObject Purple3;
   public GameObject Purple4;
   public GameObject Purple5;
   public GameObject Purple6;
   public GameObject Purple7;

   public GameObject Orange1;
   public GameObject Orange2;
   public GameObject Orange3;

   public GameObject Red1;

   public TextMeshProUGUI XjLevel;
   public Slider XjSlider;
   public TextMeshProUGUI XjLeftText;
   public TextMeshProUGUI XjRightText;
   
   public TextMeshProUGUI LevelText;
   public Slider LevelSlider;
   public TextMeshProUGUI LevelLeftText;
   public TextMeshProUGUI LevelRightText;

   public GameObject YuMaoContent;
   
   public TextMeshProUGUI AttackText;
   public TextMeshProUGUI DefenseText;
   public TextMeshProUGUI HpText;
   public TextMeshProUGUI CritText;
   public TextMeshProUGUI CiTiaoText;

   public Button InstallButton;
   public Button ExitButton;


   public void ShowChiBangList()
   {
      foreach (Transform item in ChiBangContent.transform)
      {
         Destroy(item.gameObject);
      }

      foreach (var item in PlayerData.S.ChiBangList)
      {
         ChiBangItem1 chiBangInfo = Instantiate(Resources.Load<GameObject>("Prefabs/Window/ChiBangItem"),ChiBangContent.transform).GetComponent<ChiBangItem1>();
         chiBangInfo.ChiBangInfo = item.Value;
         chiBangInfo.SetChiBang();
      }
   }
   private void OnEnable()
   {
      CurrentClickChiBangType=ChiBangType.None;
      AllLevel.text = "Lv." + PlayerData.S.AllChiBangLevel;
      AllLevelSlider.maxValue = 100;
      AllLevelSlider.value = PlayerData.S.AllChiBangLevelEx;
      ShowChiBangList();
      AllLevelLeftText.text = PlayerData.S.AllChiBangLevelEx.ToString();
      AllLevelRightText.text = "100";
     
      RightContent.SetActive(false);
   }

   public void ShowChiBangInfo(ChiBangInfo chiBangInfo)
   {
      RightContent.SetActive(true);
      Blue1.SetActive(false);
      Blue2.SetActive(false);
      Blue3.SetActive(false);
      Blue4.SetActive(false);
      Blue5.SetActive(false);
      Blue6.SetActive(false);
      Blue7.SetActive(false);
      Blue8.SetActive(false);
   
      Green1.SetActive(false);
      Green2.SetActive(false);
      Green3.SetActive(false);
      Green4.SetActive(false);
      Green5.SetActive(false);
      Green6.SetActive(false);
   
      Purple1.SetActive(false);
      Purple2.SetActive(false);
      Purple3.SetActive(false);
      Purple4.SetActive(false);
      Purple5.SetActive(false);
      Purple6.SetActive(false);
      Purple7.SetActive(false);

      Orange1.SetActive(false);
      Orange2.SetActive(false);
      Orange3.SetActive(false);

      Red1.SetActive(false);
      
       switch (chiBangInfo.ChiBangType)
      {
         case ChiBangType.Blue1:
            Blue1.gameObject.SetActive(true);
            Blue1.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "animation_ui", true);
            break;
         case ChiBangType.Blue2:
            Blue2.gameObject.SetActive(true);
            Blue2.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            break;
         case ChiBangType.Blue3:
            Blue3.gameObject.SetActive(true);
            Blue3.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            break;
         case ChiBangType.Blue4:
            Blue4.gameObject.SetActive(true);
            Blue4.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "dj", true);
            break;
         case ChiBangType.Blue5:
            Blue5.gameObject.SetActive(true);
            Blue5.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "dj", true);
            break;
         case ChiBangType.Blue6:
            Blue6.gameObject.SetActive(true);
            Blue6.GetComponent<Animator>().Play("NewSequenceAnim");
            break;
         case ChiBangType.Blue7:
            Blue7.gameObject.SetActive(true);
            Blue7.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "wings", true);
            break;
         case ChiBangType.Blue8:
            Blue8.gameObject.SetActive(true);
            Blue8.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            break;
         
         
         
         case ChiBangType.Green1:
            Green1.gameObject.SetActive(true);
            Green1.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            break;
         case ChiBangType.Green2:
            Green2.gameObject.SetActive(true);
            Green2.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            break;
         case ChiBangType.Green3:
            Green3.gameObject.SetActive(true);
            Green3.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "idle", true);
            break;
         case ChiBangType.Green4:
            Green4.gameObject.SetActive(true);
            Green4.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "animation", true);
            break;
         case ChiBangType.Green5:
            Green5.gameObject.SetActive(true);
            Green5.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "animation", true);
            break;
         case ChiBangType.Green6:
            Green6.gameObject.SetActive(true);
            Green6.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "animation", true);
            break;
         
         
         
         
         case ChiBangType.Purple1:
            Purple1.gameObject.SetActive(true);
            Purple1.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "standby_2", true);
            break;
         case ChiBangType.Purple2:
            Purple2.gameObject.SetActive(true);
            Purple2.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "standby", true);
            break;
         case ChiBangType.Purple3:
            Purple3.gameObject.SetActive(true);
            Purple3.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "animation_ui", true);
            break;
         case ChiBangType.Purple4:
            Purple4.gameObject.SetActive(true);
            Purple4.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "animation_ui", true);
            break;
         case ChiBangType.Purple5:
            Purple5.gameObject.SetActive(true);
            Purple5.GetComponent<Animator>().Play("NewSequenceAnim");
            break;
         case ChiBangType.Purple6:
            Purple6.gameObject.SetActive(true);
            Purple6.GetComponent<Animator>().Play("NewSequenceAnim");
            break;
         case ChiBangType.Purple7:
            Purple7.gameObject.SetActive(true);
            Purple7.GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "animation", true);
            break;
         
         
         
         
         case ChiBangType.Orange1:
            Orange1.gameObject.SetActive(true);
            Orange1.GetComponent<Animator>().Play("NewSequenceAnim");
            break;
         case ChiBangType.Orange2:
            Orange2.gameObject.SetActive(true);
            Orange2.GetComponent<Animator>().Play("NewSequenceAnim");
            break;
         case ChiBangType.Orange3:
            Orange3.gameObject.SetActive(true);
            Orange3.GetComponent<Animator>().Play("NewSequenceAnim");
            break;
         
         case ChiBangType.Red1:
            Red1.gameObject.SetActive(true);
            Red1.GetComponent<Animator>().Play("NewSequenceAnim");
            break;
      }

      foreach (Transform item in YuMaoContent.transform)
      {
         Destroy(item.gameObject);
      }

      if (BagController.S.PropList.ContainsKey(401)&&BagController.S.PropList[401].Count>0)
      {
         var yumao = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/YuMaoItem"), YuMaoContent.transform)
            .GetComponent<YuMaoItem>();
         yumao.propId = 401;
         yumao.SetYuMao();
      }
      
      if (BagController.S.PropList.ContainsKey(402)&&BagController.S.PropList[402].Count>0)
      {
         var yumao = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/YuMaoItem"), YuMaoContent.transform)
            .GetComponent<YuMaoItem>();
         yumao.propId = 402;
         yumao.SetYuMao();
      }
      
      if (BagController.S.PropList.ContainsKey(403)&&BagController.S.PropList[403].Count>0)
      {
         var yumao = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/YuMaoItem"), YuMaoContent.transform)
            .GetComponent<YuMaoItem>();
         yumao.propId = 403;
         yumao.SetYuMao();
      }
      
      if (BagController.S.PropList.ContainsKey(404)&&BagController.S.PropList[404].Count>0)
      {
         var yumao = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/YuMaoItem"), YuMaoContent.transform)
            .GetComponent<YuMaoItem>();
         yumao.propId = 404;
         yumao.SetYuMao();
      }
      
      if (BagController.S.PropList.ContainsKey(405)&&BagController.S.PropList[405].Count>0)
      {
         var yumao = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/YuMaoItem"), YuMaoContent.transform)
            .GetComponent<YuMaoItem>();
         yumao.propId = 405;
         yumao.SetYuMao();
      }
      
      if (BagController.S.PropList.ContainsKey(406)&&BagController.S.PropList[406].Count>0)
      {
         var yumao = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/YuMaoItem"), YuMaoContent.transform)
            .GetComponent<YuMaoItem>();
         yumao.propId = 406;
         yumao.SetYuMao();
      }

      XjLevel.text = "ST." + chiBangInfo.Xj + "：";
      XjSlider.maxValue=ChiBangConfig.ChiBangXjDic[chiBangInfo.Xj];
      XjSlider.value=chiBangInfo.XjEx;
      XjLeftText.text=chiBangInfo.XjEx.ToString();
      XjRightText.text=ChiBangConfig.ChiBangXjDic[chiBangInfo.Xj].ToString();
      
      LevelText.text="Lv." + chiBangInfo.Level + "：";
      LevelSlider.maxValue=ChiBangConfig.ChiBangExDic[chiBangInfo.Level];
      LevelSlider.value=chiBangInfo.LevelEx;
      LevelLeftText.text=chiBangInfo.LevelEx.ToString();
      LevelRightText.text=ChiBangConfig.ChiBangExDic[chiBangInfo.Level].ToString();
      ChiBangAttribute chiBangAttribute =ChiBangConfig.ChiBangBaseAttributeDic[ChiBangConfig.GetChiBangQuality(chiBangInfo.ChiBangType)];
      float levelscale=ChiBangConfig.ChiBangLevelAttributeDic[chiBangInfo.Level];
      float xjscale = ((chiBangInfo.Xj - 1) * 0.2f) + 1.0f;
      float attack = chiBangAttribute.attack * levelscale*xjscale;
      float defense = chiBangAttribute.defense * levelscale*xjscale;
      float hp = chiBangAttribute.maxHp * levelscale*xjscale;
      float crit = chiBangAttribute.Crit * levelscale*xjscale;
      AttackText.text=Mathf.RoundToInt(attack).ToString();
      DefenseText.text=Mathf.RoundToInt(defense).ToString();
      CritText.text=Mathf.RoundToInt(crit).ToString();
      HpText.text=Mathf.RoundToInt(hp).ToString();
      CiTiaoText.text=ChiBangConfig.ChiBangCiTiaoDic[chiBangInfo.ChiBangType];
   }

   public void ChiBangClick(object[] obj)
   {
      ChiBangInfo chiBangInfo=obj[0] as ChiBangInfo;
      CurrentClickChiBangType=chiBangInfo.ChiBangType;
      ShowChiBangInfo(chiBangInfo);
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("YuMaoClick",YuMaoClick);
      ObserverModuleManager.S.UnRegisterEvent("ChiBangClick",ChiBangClick);
   }

   public void YuMaoClick(object[] obj)
   {
      int propId=(int)obj[0];
      BagController.S.PropList[propId].Count--;
      PlayerData.S.ChiBangList[CurrentClickChiBangType].LevelEx += ChiBangConfig.YuMaoExDic[propId%10];
      while (PlayerData.S.ChiBangList[CurrentClickChiBangType].LevelEx >=
             ChiBangConfig.ChiBangExDic[PlayerData.S.ChiBangList[CurrentClickChiBangType].Level])
      {
         PlayerData.S.ChiBangList[CurrentClickChiBangType].LevelEx -=
            ChiBangConfig.ChiBangExDic[PlayerData.S.ChiBangList[CurrentClickChiBangType].Level];
         PlayerData.S.ChiBangList[CurrentClickChiBangType].Level++;
      }
      ShowChiBangInfo(PlayerData.S.ChiBangList[CurrentClickChiBangType]);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("YuMaoClick",YuMaoClick);
      ObserverModuleManager.S.RegisterEvent("ChiBangClick",ChiBangClick);
      ExitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      InstallButton.onClick.AddListener(() =>
      {
         PlayerData.S.playerChiBangType = CurrentClickChiBangType;
         ShowChiBangList();
         ObserverModuleManager.S.SendEvent("ShowChiBang");
      });
   }
}
