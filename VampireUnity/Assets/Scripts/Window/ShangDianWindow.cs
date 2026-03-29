using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShangDianWindow : MonoBehaviour
{
   public GameObject Content;
   public Button ExitButton;

   private void OnEnable()
   {
      ShowShangDian();
   }

   private void Start()
   {
      ExitButton.onClick.AddListener(() =>
      {
         Destroy(gameObject);
      });
      
   }

   public void ShowShangDian(bool IsNormal=true)
   {
      foreach (Transform item in Content.transform)
      {
         Destroy(item.gameObject);
      }
      List<ShangDianConfig.ShangPingItem>ItemList=new List<ShangDianConfig.ShangPingItem>();
      if (IsNormal)
      {
         ItemList = ShangDianConfig.NormalShangDian;
      }
      else
      {
         ItemList = ShangDianConfig.GaoJiShangDian;
      }

      foreach (var Item in ItemList)
      {
         var shangdianitem = Instantiate(Resources.Load("Prefabs/Window/ShangDianItem"),Content.transform);
         ShangDianItem ShangDianItem=shangdianitem.GetComponent<ShangDianItem>();
         ShangDianItem.PropId=PropConfig.GetPropId(Item.type,Item.quality);
         ShangDianItem.PropType=Item.type;
         ShangDianItem.Quality=Item.quality;
         ShangDianItem.SetItem(Item);
      }
   }
}
