using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PropGrid : MonoBehaviour
{
  [NonSerialized]public int propType;
  public TextMeshProUGUI Count;

  public void SetCount(int num)
  {
    if (num == 0)
    {
      gameObject.SetActive(false);
    }
    else
    {
      Count.text = num.ToString();
    }
  }
}
