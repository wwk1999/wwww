using System;
using System.Collections;
using System.Collections.Generic;
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
}
