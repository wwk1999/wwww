using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChongWuWindow : MonoBehaviour
{
  public Button ExitButton;

  private void Start()
  {
    ExitButton.onClick.AddListener(() =>
    {
      gameObject.SetActive(false);
    });
  }
}
