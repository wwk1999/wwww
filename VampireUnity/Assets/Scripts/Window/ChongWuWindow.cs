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

    public GameObject LevelInfo;
    private GameObject IceWhite1;
    private GameObject HuoWhite1;
    private GameObject DianWhite1;
    private GameObject HeiAnWhite1;
    private GameObject HeiAnWhite2;
    
    private GameObject IceGreen1;
    private GameObject IceGreen2;
    private GameObject IceGreen3;
    private GameObject HuoGreen1;
    private GameObject HuoGreen2;
    private GameObject DianGreen1;
    private GameObject DianGreen2;
    private GameObject HeiAnGreen1;
    private GameObject HeiAnGreen2;
    private GameObject HeiAnGreen3;

    private GameObject IceBlue1;
    private GameObject IceBlue2;
    private GameObject HuoBlue1;
    private GameObject HuoBlue2;
    private GameObject HuoBlue3;
    private GameObject DianBlue1;
    private GameObject DianBlue2;
    private GameObject HeiAnBlue1;
    private GameObject HeiAnBlue2;
    private GameObject HeiAnBlue3;

    private GameObject IcePurple1_q;
    private GameObject IcePurple2_q;
    private GameObject IcePurple3_q;
    private GameObject HuoPurple1_q;
    private GameObject HuoPurple2_q;
    private GameObject HuoPurple3_q;
    private GameObject DianPurple1_q;
    private GameObject DianPurple2_q;
    private GameObject DianPurple3_q;
    private GameObject HeiAnPurple1_q;
    private GameObject HeiAnPurple2_q;
    private GameObject HeiAnPurple3_q;
    
    private GameObject IcePurple1_h;
    private GameObject IcePurple2_h;
    private GameObject IcePurple3_h;
    private GameObject HuoPurple1_h;
    private GameObject HuoPurple2_h;
    private GameObject HuoPurple3_h;
    private GameObject DianPurple1_h;
    private GameObject DianPurple2_h;
    private GameObject DianPurple3_h;
    private GameObject HeiAnPurple1_h;
    private GameObject HeiAnPurple2_h;
    private GameObject HeiAnPurple3_h;
    
    private GameObject IceOrange1_q;
    private GameObject HuoOrange1_q;
    private GameObject DianOrange1_q;
    private GameObject HeiAnOrange1_q;

    private GameObject IceOrange1_h;
    private GameObject HuoOrange1_h;
    private GameObject DianOrange1_h;
    private GameObject HeiAnOrange1_h;


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

    public void RefreshChongWuCurrentPage(object[] obj)
    {
        ShowChongWuPage();
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
        ObserverModuleManager.S.UnRegisterEvent("RefreshChongWuCurrentPage", RefreshChongWuCurrentPage);

    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("RefreshChongWuCurrentPage", RefreshChongWuCurrentPage);
        ObserverModuleManager.S.RegisterEvent("ShowChongWuItemMask", ShowChongWuItemMask);
        ObserverModuleManager.S.RegisterEvent("HideChongWuItemMask", HideChongWuItemMask);
        
        
        
        IceWhite1=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰White1").gameObject;
        HuoWhite1=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火White1").gameObject;
        DianWhite1=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/电White1").gameObject;
        HeiAnWhite1=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗White1").gameObject;
        HeiAnWhite2=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗White2").gameObject;

        IceGreen1=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰Green1").gameObject;
        IceGreen2=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰Green2").gameObject;
        IceGreen3=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰Green3").gameObject;
        HuoGreen1=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火Green1").gameObject;
        HuoGreen2=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火Green2").gameObject;
        DianGreen1=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/电Green1").gameObject;
        DianGreen2=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/电Green2").gameObject;
        HeiAnGreen1=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗Green1").gameObject;
        HeiAnGreen2=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗Green2").gameObject;
        HeiAnGreen3=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗Green3").gameObject;

        IceBlue1=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰Blue1").gameObject;
        IceBlue2=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰Blue2").gameObject;
        HuoBlue1=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火blue1").gameObject;
        HuoBlue2=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火blue2").gameObject;
        HuoBlue3=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火blue3").gameObject;
        DianBlue1=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/电blue1").gameObject;
        DianBlue2=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/电blue2").gameObject;
        HeiAnBlue1=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗blue1").gameObject;
        HeiAnBlue2=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗blue2").gameObject;
        HeiAnBlue3=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗blue3").gameObject;
        
        IcePurple1_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰purple1_前").gameObject;
        IcePurple2_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰purple2_前").gameObject;
        IcePurple3_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰purple3_前").gameObject;
        HuoPurple1_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火purple1_前").gameObject;
        HuoPurple2_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火purple2_前").gameObject;
        HuoPurple3_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火purple3_前").gameObject;
        DianPurple1_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/电purple1_前").gameObject;
        DianPurple2_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/电purple2_前").gameObject;
        DianPurple3_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/电purple3_前").gameObject;
        HeiAnPurple1_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗purple1_前").gameObject;
        HeiAnPurple2_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗purple2_前").gameObject;
        HeiAnPurple3_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗purple3_前").gameObject;
        
        IcePurple1_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰purple1_后").gameObject;
        IcePurple2_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰purple2_后").gameObject;
        IcePurple3_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰purple3_后").gameObject;
        HuoPurple1_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火purple1_后").gameObject;
        HuoPurple2_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火purple2_后").gameObject;
        HuoPurple3_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火purple3_后").gameObject;
        DianPurple1_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/电purple1_后").gameObject;
        DianPurple2_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/电purple2_后").gameObject;
        DianPurple3_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/电purple3_后").gameObject;
        HeiAnPurple1_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗purple1_后").gameObject;
        HeiAnPurple2_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗purple2_后").gameObject;
        HeiAnPurple3_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗purple3_后").gameObject;
        
        IceOrange1_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰Orange1_后").gameObject;
        HuoOrange1_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火Orange1_后").gameObject;
        DianOrange1_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/电Orange1_后").gameObject;
        HeiAnOrange1_h=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗Orange1_后").gameObject;
        
        IceOrange1_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/冰Orange1_前").gameObject;
        HuoOrange1_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/火Orange1_前").gameObject;
        DianOrange1_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/电Orange1_前").gameObject;
        HeiAnOrange1_q=transform.Find("Mask/BagBG/InfoPanel/ImagePanel/ChongWuSke/黑暗Orange1_前").gameObject;



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
