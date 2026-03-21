using System;
using Config;
using Equip;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChiBangWindow : MonoBehaviour
{
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


   private void OnEnable()
   {
      AllLevel.text = "Lv." + PlayerData.S.AllChiBangLevel;
      AllLevelSlider.value = PlayerData.S.AllChiBangLevelEx;
      AllLevelSlider.maxValue = 100;
      AllLevelLeftText.text = PlayerData.S.AllChiBangLevelEx.ToString();
      AllLevelRightText.text = "100";
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
      RightContent.SetActive(false);
   }
}
