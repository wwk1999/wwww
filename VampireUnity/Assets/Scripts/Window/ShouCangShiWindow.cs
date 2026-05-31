using System;
using System.Collections;
using System.Collections.Generic;
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
