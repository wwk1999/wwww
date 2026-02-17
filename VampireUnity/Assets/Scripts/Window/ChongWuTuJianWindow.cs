using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChongWuTuJianWindow : MonoBehaviour
{
   public Button ShiLaiMuButton;
   public Button Dian1Button;
   public Button Huo1Button;
   public Button HeiAn1Button;
   public Button Ice1Button;
   public Button LongButton;
   public Button KongButton;
   public Button HuLiButton;
   public Button Huo2Button;
   public Button HeiAn2Button;
   public Button Ice2Button;
   public Button Dian2Button;
   public Button YuanGuShenLinButton;


   public TextMeshProUGUI Desc;
   public GameObject Name1;
   public GameObject Name2;
   public GameObject Name3;
   public GameObject Name4;
   public Image Image1;
   public Image Image2;
   public Image Image3;
   public Image Image4;

   public Button ExitButton;

   private void OnEnable()
   {
      ShowTuJian(ChongWuConfig.ChongWuTuJianType.ShiLaiMu);
   }

   private void Start()
   {
      ExitButton.onClick.AddListener(() =>
      {
         Destroy(gameObject);
      });
      ShiLaiMuButton.onClick.AddListener(() =>
      {
         ShowTuJian(ChongWuConfig.ChongWuTuJianType.ShiLaiMu);
      });
      
      Huo1Button.onClick.AddListener(() =>
      {
         ShowTuJian(ChongWuConfig.ChongWuTuJianType.Huo1);
      });
      
      Dian1Button.onClick.AddListener(() =>
      {
         ShowTuJian(ChongWuConfig.ChongWuTuJianType.Dian1);
      });
      
      Ice1Button.onClick.AddListener(() =>
      {
         ShowTuJian(ChongWuConfig.ChongWuTuJianType.Ice1);
      });
      
      HeiAn1Button.onClick.AddListener(() =>
      {
         ShowTuJian(ChongWuConfig.ChongWuTuJianType.HeiAn1);
      });
      
      
      Huo2Button.onClick.AddListener(() =>
      {
         ShowTuJian(ChongWuConfig.ChongWuTuJianType.Huo2);
      });
      
      Dian2Button.onClick.AddListener(() =>
      {
         ShowTuJian(ChongWuConfig.ChongWuTuJianType.Dian2);
      });
      
      Ice2Button.onClick.AddListener(() =>
      {
         ShowTuJian(ChongWuConfig.ChongWuTuJianType.Ice2);
      });
      
      HeiAn2Button.onClick.AddListener(() =>
      {
         ShowTuJian(ChongWuConfig.ChongWuTuJianType.HeiAn2);
      });
      
      LongButton.onClick.AddListener(() =>
      {
         ShowTuJian(ChongWuConfig.ChongWuTuJianType.Long);
      });
      
      KongButton.onClick.AddListener(() =>
      {
         ShowTuJian(ChongWuConfig.ChongWuTuJianType.KongZhongBaZhu);
      });
      
      HuLiButton.onClick.AddListener(() =>
      {
         ShowTuJian(ChongWuConfig.ChongWuTuJianType.HuLi);
      });
      
      YuanGuShenLinButton.onClick.AddListener(() =>
      {
         ShowTuJian(ChongWuConfig.ChongWuTuJianType.YuanGuShenLin);
      });
   }

   public void ShowTuJian(ChongWuConfig.ChongWuTuJianType type)
   {
      List<ChongWuType>list=ChongWuConfig.TuJianDic[type];
      Image1.sprite = ResourcesConfig.GetChongWuSprite(list[0]);
      Image2.sprite = ResourcesConfig.GetChongWuSprite(list[1]);
      Image3.sprite = ResourcesConfig.GetChongWuSprite(list[2]);
      Image4.sprite = ResourcesConfig.GetChongWuSprite(list[3]);

      int quality1 = ChongWuConfig.GetChongWuQualityByType(list[0]);
      int quality2 = ChongWuConfig.GetChongWuQualityByType(list[1]);
      int quality3 = ChongWuConfig.GetChongWuQualityByType(list[2]);
      int quality4 = ChongWuConfig.GetChongWuQualityByType(list[3]);

      Desc.text = ChongWuConfig.TuJianDescDic[type];

      Name1.transform.Find("Name1").gameObject.SetActive(false);
      Name1.transform.Find("Name2").gameObject.SetActive(false);
      Name1.transform.Find("Name3").gameObject.SetActive(false);
      Name1.transform.Find("Name4").gameObject.SetActive(false);
      Name1.transform.Find("Name5").gameObject.SetActive(false);
      Name1.transform.Find("Name6").gameObject.SetActive(false);
      
      Name2.transform.Find("Name1").gameObject.SetActive(false);
      Name2.transform.Find("Name2").gameObject.SetActive(false);
      Name2.transform.Find("Name3").gameObject.SetActive(false);
      Name2.transform.Find("Name4").gameObject.SetActive(false);
      Name2.transform.Find("Name5").gameObject.SetActive(false);
      Name2.transform.Find("Name6").gameObject.SetActive(false);

      Name3.transform.Find("Name1").gameObject.SetActive(false);
      Name3.transform.Find("Name2").gameObject.SetActive(false);
      Name3.transform.Find("Name3").gameObject.SetActive(false);
      Name3.transform.Find("Name4").gameObject.SetActive(false);
      Name3.transform.Find("Name5").gameObject.SetActive(false);
      Name3.transform.Find("Name6").gameObject.SetActive(false);
      
      Name4.transform.Find("Name1").gameObject.SetActive(false);
      Name4.transform.Find("Name2").gameObject.SetActive(false);
      Name4.transform.Find("Name3").gameObject.SetActive(false);
      Name4.transform.Find("Name4").gameObject.SetActive(false);
      Name4.transform.Find("Name5").gameObject.SetActive(false);
      Name4.transform.Find("Name6").gameObject.SetActive(false);
      
      switch (quality1)
      {
         case 1:
            Name1.transform.Find("Name1").gameObject.SetActive(true);
            Name1.transform.Find("Name1").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[0]];
            break;
         case 2:
            Name1.transform.Find("Name2").gameObject.SetActive(true);
            Name1.transform.Find("Name2").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[0]];
            break;
         case 3:
            Name1.transform.Find("Name3").gameObject.SetActive(true);
            Name1.transform.Find("Name3").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[0]];
            break;
         case 4:
            Name1.transform.Find("Name4").gameObject.SetActive(true);
            Name1.transform.Find("Name4").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[0]];
            break;
         case 5:
            Name1.transform.Find("Name5").gameObject.SetActive(true);
            Name1.transform.Find("Name5").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[0]];
            break;
         case 6:
            Name1.transform.Find("Name6").gameObject.SetActive(true);
            Name1.transform.Find("Name6").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[0]];
            break;
      }
      
      
      switch (quality2)
      {
         case 1:
            Name2.transform.Find("Name1").gameObject.SetActive(true);
            Name2.transform.Find("Name1").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[1]];
            break;
         case 2:
            Name2.transform.Find("Name2").gameObject.SetActive(true);
            Name2.transform.Find("Name2").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[1]];
            break;
         case 3:
            Name2.transform.Find("Name3").gameObject.SetActive(true);
            Name2.transform.Find("Name3").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[1]];
            break;
         case 4:
            Name2.transform.Find("Name4").gameObject.SetActive(true);
            Name2.transform.Find("Name4").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[1]];
            break;
         case 5:
            Name2.transform.Find("Name5").gameObject.SetActive(true);
            Name2.transform.Find("Name5").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[1]];
            break;
         case 6:
            Name2.transform.Find("Name6").gameObject.SetActive(true);
            Name2.transform.Find("Name6").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[1]];
            break;
      }
      
      
      switch (quality3)
      {
         case 1:
            Name3.transform.Find("Name1").gameObject.SetActive(true);
            Name3.transform.Find("Name1").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[2]];
            break;
         case 2:
            Name3.transform.Find("Name2").gameObject.SetActive(true);
            Name3.transform.Find("Name2").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[2]];
            break;
         case 3:
            Name3.transform.Find("Name3").gameObject.SetActive(true);
            Name3.transform.Find("Name3").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[2]];
            break;
         case 4:
            Name3.transform.Find("Name4").gameObject.SetActive(true);
            Name3.transform.Find("Name4").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[2]];
            break;
         case 5:
            Name3.transform.Find("Name5").gameObject.SetActive(true);
            Name3.transform.Find("Name5").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[2]];
            break;
         case 6:
            Name3.transform.Find("Name6").gameObject.SetActive(true);
            Name3.transform.Find("Name6").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[2]];
            break;
      }
      
      
      switch (quality4)
      {
         case 1:
            Name4.transform.Find("Name1").gameObject.SetActive(true);
            Name4.transform.Find("Name1").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[3]];
            break;
         case 2:
            Name4.transform.Find("Name2").gameObject.SetActive(true);
            Name4.transform.Find("Name2").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[3]];
            break;
         case 3:
            Name4.transform.Find("Name3").gameObject.SetActive(true);
            Name4.transform.Find("Name3").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[3]];
            break;
         case 4:
            Name4.transform.Find("Name4").gameObject.SetActive(true);
            Name4.transform.Find("Name4").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[3]];
            break;
         case 5:
            Name4.transform.Find("Name5").gameObject.SetActive(true);
            Name4.transform.Find("Name5").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[3]];
            break;
         case 6:
            Name4.transform.Find("Name6").gameObject.SetActive(true);
            Name4.transform.Find("Name6").GetComponent<TextMeshProUGUI>().text = ChongWuConfig.ChongWuNamDic[list[3]];
            break;
      }

   }

}
