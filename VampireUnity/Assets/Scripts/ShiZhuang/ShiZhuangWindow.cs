using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class ShiZhuangWindow : MonoBehaviour
{
  public SkeletonGraphic ske;
  public GameObject ListContent;
  public GameObject JieSuoContent;
  public GameObject AttributeContent;
  public Button ExitButton;

  private void Start()
  {
    ExitButton.onClick.AddListener(() =>
    {
      gameObject.SetActive(false);
    });
  }

  private void OnEnable()
  {
    ske.gameObject.SetActive(false);
    foreach (Transform item in AttributeContent.transform)
    {
      Destroy(item.gameObject);
    }
    foreach (Transform item in JieSuoContent.transform)
    {
      Destroy(item.gameObject);
    }
    foreach (Transform item in ListContent.transform)
    {
      Destroy(item.gameObject);
    }

    foreach (var item in ShiZhuangConfig.ShiZhuangNameDic)
    {
      ShiZhuangItem shizhuangitem=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ShiZhuangItem"),ListContent.transform).GetComponent<ShiZhuangItem>();
      shizhuangitem.Type = item.Key;
      shizhuangitem.SetShiZhuangItem();
    }
  }
}
