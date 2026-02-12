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
    public Button ChongWuItemMaskButton;

    private int MaxChongWuPageNum => (int)Math.Ceiling(PlayerData.S.ChongWuList.Count / 6.0);

    private void OnEnable()
    {
        ChongWuController.S.CurrentChongWuPageNum = 1;
        ShowChongWuPage();
        SetPageNum();
    }

    public void SetPageNum()
    {
        PageNum.text = ChongWuController.S.CurrentChongWuPageNum.ToString();
    }

    public void ShowChongWuItemMask(object[] obj)
    {
        ChongWuItemMaskButton.gameObject.SetActive(true);
    }

    public void HideChongWuItemMask(object[] obj)
    {
        ChongWuItemMaskButton.gameObject.SetActive(false);
    }

    public void ShowChongWuPage()
    {
        ChongWuController.S.CurrentPageItemList.Clear();
        foreach (Transform item in ChongWuList.transform)
        {
            Destroy(item.gameObject);
        }

        int originIndex = (ChongWuController.S.CurrentChongWuPageNum - 1) * 6;
        ChongWuTable table1 = null;
        ChongWuTable table2 = null;
        ChongWuTable table3 = null;
        ChongWuTable table4 = null;
        ChongWuTable table5 = null;
        ChongWuTable table6 = null;
        if (originIndex < PlayerData.S.ChongWuList.Count)
        {
            table1 = PlayerData.S.ChongWuList[originIndex];
        }

        if (originIndex + 1 < PlayerData.S.ChongWuList.Count)
        {
            table2 = PlayerData.S.ChongWuList[originIndex + 1];
        }

        if (originIndex + 2 < PlayerData.S.ChongWuList.Count)
        {
            table3 = PlayerData.S.ChongWuList[originIndex + 2];
        }

        if (originIndex + 3 < PlayerData.S.ChongWuList.Count)
        {
            table4 = PlayerData.S.ChongWuList[originIndex + 3];
        }

        if (originIndex + 4 < PlayerData.S.ChongWuList.Count)
        {
            table5 = PlayerData.S.ChongWuList[originIndex + 4];
        }

        if (originIndex + 5 < PlayerData.S.ChongWuList.Count)
        {
            table6 = PlayerData.S.ChongWuList[originIndex + 5];
        }

        if (table1 != null)
        {
            ChongWuList chongwuList1 = Instantiate(Resources.Load("Prefabs/Window/ChongWuList"), ChongWuList.transform)
                .GameObject().GetComponent<ChongWuList>();
            chongwuList1.SetChongWuList(table1, table2, table3);
            if (chongwuList1.ChongWuListItem1 != null)
            {
                if (chongwuList1.ChongWuListItem1.chongWuTable.ChongWuId == PlayerData.S.ZhuChongWuId)
                {
                    chongwuList1.ChongWuListItem1.ShowGou();
                }
                else
                {
                    chongwuList1.ChongWuListItem1.HideGou();
                }

                ChongWuController.S.CurrentPageItemList.Add(chongwuList1.ChongWuListItem1);
            }

            if (chongwuList1.ChongWuListItem2 != null)
            {
                if (chongwuList1.ChongWuListItem2.chongWuTable.ChongWuId == PlayerData.S.ZhuChongWuId)
                {
                    chongwuList1.ChongWuListItem2.ShowGou();
                }
                else
                {
                    chongwuList1.ChongWuListItem2.HideGou();
                }

                ChongWuController.S.CurrentPageItemList.Add(chongwuList1.ChongWuListItem2);
            }

            if (chongwuList1.ChongWuListItem3 != null)
            {
                if (chongwuList1.ChongWuListItem3.chongWuTable.ChongWuId == PlayerData.S.ZhuChongWuId)
                {
                    chongwuList1.ChongWuListItem3.ShowGou();
                }
                else
                {
                    chongwuList1.ChongWuListItem3.HideGou();
                }

                ChongWuController.S.CurrentPageItemList.Add(chongwuList1.ChongWuListItem3);
            }
        }

        if (table4 != null)
        {
            ChongWuList chongwuList2 = Instantiate(Resources.Load("Prefabs/Window/ChongWuList"), ChongWuList.transform)
                .GameObject().GetComponent<ChongWuList>();
            chongwuList2.SetChongWuList(table4, table5, table6);
            if (chongwuList2.ChongWuListItem1 != null)
            {
                if (chongwuList2.ChongWuListItem1.chongWuTable.ChongWuId == PlayerData.S.ZhuChongWuId)
                {
                    chongwuList2.ChongWuListItem1.ShowGou();
                }
                else
                {
                    chongwuList2.ChongWuListItem1.HideGou();
                }

                ChongWuController.S.CurrentPageItemList.Add(chongwuList2.ChongWuListItem1);
            }

            if (chongwuList2.ChongWuListItem2 != null)
            {
                if (chongwuList2.ChongWuListItem2.chongWuTable.ChongWuId == PlayerData.S.ZhuChongWuId)
                {
                    chongwuList2.ChongWuListItem2.ShowGou();
                }
                else
                {
                    chongwuList2.ChongWuListItem2.HideGou();
                }

                ChongWuController.S.CurrentPageItemList.Add(chongwuList2.ChongWuListItem2);
            }

            if (chongwuList2.ChongWuListItem3 != null)
            {
                if (chongwuList2.ChongWuListItem3.chongWuTable.ChongWuId == PlayerData.S.ZhuChongWuId)
                {
                    chongwuList2.ChongWuListItem3.ShowGou();
                }
                else
                {
                    chongwuList2.ChongWuListItem3.HideGou();
                }

                ChongWuController.S.CurrentPageItemList.Add(chongwuList2.ChongWuListItem3);
            }
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("ShowChongWuItemMask", ShowChongWuItemMask);
        ObserverModuleManager.S.UnRegisterEvent("HideChongWuItemMask", HideChongWuItemMask);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("ShowChongWuItemMask", ShowChongWuItemMask);
        ObserverModuleManager.S.RegisterEvent("HideChongWuItemMask", HideChongWuItemMask);

        ChongWuItemMaskButton.onClick.AddListener(() =>
        {
            GameObject obj = transform.Find("ChongWuItemSwitch(Clone)").gameObject;
            if (obj != null)
            {
                Destroy(obj.gameObject);
            }

            ChongWuItemMaskButton.gameObject.SetActive(false);
        });
        Left.onClick.AddListener(() =>
        {
            if (ChongWuController.S.CurrentChongWuPageNum <= 1)
            {
                return;
            }

            ChongWuController.S.CurrentChongWuPageNum--;
            ShowChongWuPage();
            SetPageNum();
        });
        Right.onClick.AddListener(() =>
        {
            if (ChongWuController.S.CurrentChongWuPageNum >= MaxChongWuPageNum)
            {
                return;
            }

            ChongWuController.S.CurrentChongWuPageNum++;
            ShowChongWuPage();
            SetPageNum();
        });
        ExitButton.onClick.AddListener(() => { gameObject.SetActive(false); });
    }
}
