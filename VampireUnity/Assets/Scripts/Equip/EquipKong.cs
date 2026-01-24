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
  public Animator animator;

  public void SetKong(BaoShiInfo baoShiInfo)
  {
    if (baoShiInfo.BaoShiType == BaoShiType.None)
    {
      baoshi.gameObject.SetActive(false);
      return;
    }
    bg.sprite = ResourcesConfig.GetEquipColorBgByQuality(baoShiInfo.Quality);
    image.sprite = ResourcesConfig.GetBaoShiSprite(baoShiInfo);
    switch (baoShiInfo.Quality)
    {
      case 1:
        animator.Play("WhiteEdge");
        break;
      case 2:
        animator.Play("GreenEdge");
        break;
      case 3:
        animator.Play("BlueEdge");
        break;
      case 4:
        animator.Play("PurpleEdge");
        break;
      case 5:
        animator.Play("OrangeEdge");
        break;
      case 6:
        animator.Play("RedEdge");
        break;
    }
  }
}
