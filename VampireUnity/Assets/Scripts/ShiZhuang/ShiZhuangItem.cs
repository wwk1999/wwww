using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;

public class ShiZhuangItem : MonoBehaviour
{
   public TextMeshProUGUI Name1;
   public TextMeshProUGUI Name2;
   public TextMeshProUGUI Name3;
   public TextMeshProUGUI Name4;
   public TextMeshProUGUI Name5;
   public TextMeshProUGUI Name6;

   [NonSerialized]public ShiZhuangType Type;

   public void SetShiZhuangItem()
   {
      int quality = ShiZhuangConfig.ShiZhuangQualityDic[Type];
      Name1.gameObject.SetActive(false);
      Name2.gameObject.SetActive(false);
      Name3.gameObject.SetActive(false);
      Name4.gameObject.SetActive(false);
      Name5.gameObject.SetActive(false);
      Name6.gameObject.SetActive(false);
      switch (quality)
      {
         case 1:
            Name1.gameObject.SetActive(true);
            Name1.text=ShiZhuangConfig.ShiZhuangNameDic[Type];
            break;
         case 2:
            Name2.gameObject.SetActive(true);
            Name2.text=ShiZhuangConfig.ShiZhuangNameDic[Type];
            break;
         case 3:
            Name3.gameObject.SetActive(true);
            Name3.text=ShiZhuangConfig.ShiZhuangNameDic[Type];
            break;
         case 4:
            Name4.gameObject.SetActive(true);
            Name4.text=ShiZhuangConfig.ShiZhuangNameDic[Type];
            break;
         case 5:
            Name5.gameObject.SetActive(true);
            Name5.text=ShiZhuangConfig.ShiZhuangNameDic[Type];
            break;
         case 6:
            Name6.gameObject.SetActive(true);
            Name6.text=ShiZhuangConfig.ShiZhuangNameDic[Type];
            break;
      }
   }
}
