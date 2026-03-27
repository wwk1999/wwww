using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class EquipKong : MonoBehaviour
{
  public GameObject baoshi;
  public Image bg;
  public Image image;

  public void SetKong(BaoShiInfo baoShiInfo)
  {
    if (baoShiInfo.BaoShiType == BaoShiType.None)
    {
      baoshi.gameObject.SetActive(false);
      return;
    }
    baoshi.gameObject.SetActive(true);
    bg.sprite = ResourcesConfig.GetEquipColorBgByQuality(baoShiInfo.Quality);
    image.sprite = ResourcesConfig.GetBaoShiSprite(baoShiInfo);
  }
}
