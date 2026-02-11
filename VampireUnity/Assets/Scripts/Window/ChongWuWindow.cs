using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChongWuWindow : MonoBehaviour
{
  public Button ExitButton;
  public GameObject ChongWuList;
  public Button Left;
  public Button Right;
  public TextMeshProUGUI PageNum;

  private int CurrentChongWuPageNum = 1;
  private int MaxChongWuPageNum => (int)Math.Ceiling(PlayerData.S.ChongWuList.Count / 6.0);
  private void OnEnable()
  {
    CurrentChongWuPageNum = 1;
    ShowChongWuPage();
  }

  public void SetPageNum()
  {
    PageNum.text=CurrentChongWuPageNum.ToString();
  }

  public void ShowChongWuPage()
  {
    foreach (Transform item in ChongWuList.transform)
    {
      Destroy(item.gameObject);
    }
    int originIndex=(CurrentChongWuPageNum-1)*6;
    ChongWuTable table1 = null;
    ChongWuTable table2 = null;
    ChongWuTable table3 = null;
    ChongWuTable table4 = null;
    ChongWuTable table5 = null;
    ChongWuTable table6= null;
    if (PlayerData.S.ChongWuList[originIndex] != null)
    {
      table1 = PlayerData.S.ChongWuList[originIndex];
    }
    if (PlayerData.S.ChongWuList[originIndex+1] != null)
    {
      table2 = PlayerData.S.ChongWuList[originIndex+1];
    }
    if (PlayerData.S.ChongWuList[originIndex+2] != null)
    {
      table3 = PlayerData.S.ChongWuList[originIndex+2];
    }
    if (PlayerData.S.ChongWuList[originIndex+3] != null)
    {
      table4 = PlayerData.S.ChongWuList[originIndex+3];
    }
    if (PlayerData.S.ChongWuList[originIndex+4] != null)
    {
      table5 = PlayerData.S.ChongWuList[originIndex+4];
    }
    if (PlayerData.S.ChongWuList[originIndex+5] != null)
    {
      table6 = PlayerData.S.ChongWuList[originIndex+5];
    }

    if (table1 != null)
    {
      ChongWuList chongwuList1=Instantiate(Resources.Load("Prefabs/Window/ChongWuList"),ChongWuList.transform).GameObject().GetComponent<ChongWuList>();
      chongwuList1.SetChongWuList(table1, table2, table3);
    }
    if (table4 != null)
    {
      ChongWuList chongwuList2=Instantiate(Resources.Load("Prefabs/Window/ChongWuList"),ChongWuList.transform).GameObject().GetComponent<ChongWuList>();
      chongwuList2.SetChongWuList(table4, table5, table6);
    }
  }

  private void Start()
  {
    Left.onClick.AddListener(() =>
    {
      if (CurrentChongWuPageNum <= 1)
      {
        return;
      }
      CurrentChongWuPageNum--;
      ShowChongWuPage();
      SetPageNum();
    });
    Left.onClick.AddListener(() =>
    {
      if (CurrentChongWuPageNum >= MaxChongWuPageNum)
      {
        return;
      }
      CurrentChongWuPageNum++;
      ShowChongWuPage();
      SetPageNum();
    });
    ExitButton.onClick.AddListener(() =>
    {
      gameObject.SetActive(false);
    });
  }
}
