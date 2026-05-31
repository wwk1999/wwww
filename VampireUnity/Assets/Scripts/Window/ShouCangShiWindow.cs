using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShouCangShiWindow : MonoBehaviour
{
   public Button ExitButton;
   public Button InfoButton;
   public Button EquipButton;
   public Button ChongWuButton;
   public Button ChiBangButton;
   public GameObject Content;

   public TextMeshProUGUI Left;
   public TextMeshProUGUI Right;
   public TextMeshProUGUI Level;
   public TextMeshProUGUI Attack;
   public TextMeshProUGUI Defense;
   public TextMeshProUGUI Crit;
   public TextMeshProUGUI Hp;

   public Slider slider;

   public void SetInfo()
   {
      int count = 0;
      foreach (var item in PlayerData.S.ShouCangShiEquipDic)
      {
         if (item.Value)
         {
            count += ShouCangShiConfig.ShouCangShiQualityCountDic[5];
         }
      }
      
      foreach (var item in PlayerData.S.ShouCangShiChongWu)
      {
         if (item.Value)
         {
            int quality = ChongWuConfig.GetChongWuQualityByType(item.Key);
            count += ShouCangShiConfig.ShouCangShiQualityCountDic[quality];
         }
      }
      
      
      foreach (var item in PlayerData.S.ShouCangShiChiBangDic)
      {
         if (item.Value)
         {
            int quality = ChiBangConfig.GetChiBangQuality(item.Key);
            count += ShouCangShiConfig.ShouCangShiQualityCountDic[quality];
         }
      }

      int level = count / 10;
      int left = count % 10;
      int right = 10;

      float attack = level * ShouCangShiConfig.BaseAttack;
      float defense = level * ShouCangShiConfig.BaseDefense;
      float crit = level * ShouCangShiConfig.BaseCrit;
      float hp = level * ShouCangShiConfig.BaseHp;

      Left.text=left.ToString();
      Right.text=right.ToString();
      Level.text=level.ToString();
      Attack.text = attack.ToString();
      Defense.text = defense.ToString();
      Crit.text = crit.ToString();
      Hp.text = hp.ToString();

      slider.maxValue = 10;
      slider.value = left;
   }
   
   public IEnumerator  ShowEquip()
   {
      foreach (Transform item in Content.transform)
      {
         Destroy(item.gameObject);
      }

      int count = 0;
      for (int i = 1; i <= 78; i++)
      {
         ShouCangShiItem item = Instantiate(Resources.Load("Prefabs/Window/ShouCangShiItem"),Content.transform).GetComponent<ShouCangShiItem>();
         item.Type = ShouCangShiItemType.Equip;
         item.orangeId = i;
         item.Show();
         count++;
         if (count >= 13)
         {
            count = 0;
            yield return null;
         }
      }
      foreach (var item in PlayerData.S.ShouCangShiEquipDic)
      {
         PlayerData.S.ShouCangShiLastEquipDic[item.Key]=item.Value;
      }
   }
   
   
   public IEnumerator  ShowChiBang()
   {
      foreach (Transform item in Content.transform)
      {
         Destroy(item.gameObject);
      }

      int count = 0;
      for (int i = 1; i <= 25; i++)
      {
         ShouCangShiItem item = Instantiate(Resources.Load("Prefabs/Window/ShouCangShiItem"),Content.transform).GetComponent<ShouCangShiItem>();
         item.Type = ShouCangShiItemType.ChiBang;
         item.ChiBangType = (ChiBangType)i;
         item.Show();
         count++;
         if (count >= 10)
         {
            count = 0;
            yield return null;
         }
      }
      foreach (var item in PlayerData.S.ShouCangShiChiBangDic)
      {
         PlayerData.S.ShouCangShiLastChiBangDic[item.Key]=item.Value;
      }
   }
   
   
   public IEnumerator  ShowChongWu()
   {
      foreach (Transform item in Content.transform)
      {
         Destroy(item.gameObject);
      }

      int count = 0;
      for (int i = 1; i <= 57; i++)
      {
         ShouCangShiItem item = Instantiate(Resources.Load("Prefabs/Window/ShouCangShiItem"),Content.transform).GetComponent<ShouCangShiItem>();
         item.Type = ShouCangShiItemType.ChongWu;
         item.ChongWuType = (ChongWuType)i;
         item.Show();
         count++;
         if (count >= 10)
         {
            count = 0;
            yield return null;
         }
      }

      foreach (var item in PlayerData.S.ShouCangShiChongWu)
      {
         PlayerData.S.ShouCangShiLastChongWu[item.Key]=item.Value;
      }
   }

   private void OnEnable()
   {
      SwitchLiang(ShouCangShiItemType.Equip);
      StartCoroutine(ShowEquip());
      SetInfo();
   }

   public void SwitchLiang(ShouCangShiItemType type)
   {
      switch (type)
      {
         case ShouCangShiItemType.Equip:
            EquipButton.image.sprite = ResourcesConfig.ShouCangShiAnNiuLiang;
            ChiBangButton.image.sprite = ResourcesConfig.ShouCangShiAnNiuAn;
            ChongWuButton.image.sprite = ResourcesConfig.ShouCangShiAnNiuAn;
            EquipButton.transform.localScale=new Vector3(1.05f,1.05f,1.05f);
            ChiBangButton.transform.localScale=new Vector3(1f,1f,1f);
            ChongWuButton.transform.localScale=new Vector3(1f,1f,1f);
            break;
         case ShouCangShiItemType.ChiBang:
            EquipButton.image.sprite = ResourcesConfig.ShouCangShiAnNiuAn;
            ChiBangButton.image.sprite = ResourcesConfig.ShouCangShiAnNiuLiang;
            ChongWuButton.image.sprite = ResourcesConfig.ShouCangShiAnNiuAn;
            EquipButton.transform.localScale=new Vector3(1f,1f,1f);
            ChiBangButton.transform.localScale=new Vector3(1.05f,1.05f,1.05f);
            ChongWuButton.transform.localScale=new Vector3(1f,1f,1f);
            break;
         case ShouCangShiItemType.ChongWu:
            EquipButton.image.sprite = ResourcesConfig.ShouCangShiAnNiuAn;
            ChiBangButton.image.sprite = ResourcesConfig.ShouCangShiAnNiuAn;
            ChongWuButton.image.sprite = ResourcesConfig.ShouCangShiAnNiuLiang;
            EquipButton.transform.localScale=new Vector3(1f,1f,1f);
            ChiBangButton.transform.localScale=new Vector3(1f,1f,1f);
            ChongWuButton.transform.localScale=new Vector3(1.05f,1.05f,1.05f);
            break;
      }
   }

   private void Start()
   {
      EquipButton.onClick.AddListener(() =>
      {
         SwitchLiang(ShouCangShiItemType.Equip);
         StartCoroutine(ShowEquip());
      });
      
      ChiBangButton.onClick.AddListener(() =>
      {
         SwitchLiang(ShouCangShiItemType.ChiBang);
         StartCoroutine(ShowChiBang());
      });
      
      ChongWuButton.onClick.AddListener(() =>
      {
         SwitchLiang(ShouCangShiItemType.ChongWu);
         StartCoroutine(ShowChongWu());
      });
      

   ExitButton.onClick.AddListener(() => { gameObject.SetActive(false); });
   }
}
