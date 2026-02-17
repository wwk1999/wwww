using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Spine.Unity;
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
    public TextMeshProUGUI LevelCount;
    public TextMeshProUGUI ChongWuName1;
    public TextMeshProUGUI ChongWuName2;
    public TextMeshProUGUI ChongWuName3;
    public TextMeshProUGUI ChongWuName4;
    public TextMeshProUGUI ChongWuName5;
    public TextMeshProUGUI ChongWuName6;

    public TextMeshProUGUI ChongWujingHua;
    public GameObject Quality;
    public GameObject ZiZhi;
    public GameObject XueMai;
    public GameObject Quality1;
    public GameObject Quality2;
    public GameObject Quality3;
    public GameObject Quality4;
    public GameObject Quality5;
    public GameObject Quality6;

    public TextMeshProUGUI ZiZhiCount;
    public TextMeshProUGUI XueMaiCount;

    public Button PeiYangButton;

    public FuChongItem fuChongWuItem1;
    public FuChongItem fuChongWuItem2;
    public FuChongItem fuChongWuItem3;

    public Button FuChongButton;
    public Button ZhuChongButton;
    public Button TuJianButton;
    public GameObject FuChongPanel;
    public GameObject PingJiPanel;
    public GameObject InfoPanel;

    public void ShowFuChong()
    {
        FuChongButton.gameObject.SetActive(false);
        PingJiPanel.gameObject.SetActive(false);
        InfoPanel.gameObject.SetActive(false);
        FuChongPanel.gameObject.SetActive(true);
    }

    public void ShowZhuChong()
    {
        FuChongButton.gameObject.SetActive(true);
        PingJiPanel.gameObject.SetActive(true);
        InfoPanel.gameObject.SetActive(true);
        FuChongPanel.gameObject.SetActive(false);

    }
    
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


    private int MaxChongWuPageNum => (int)Math.Ceiling(PlayerData.S.ChongWuDic.Count / 6.0);

    public void ShowPeiYangWindowObj(object[] obj)
    {
        int id = (int)obj[0];
        ShowPeiYangWindow(id);
    }
    public void ShowPeiYangWindow(int id)
    {            
        var canvasRect = GetComponentInParent<Canvas>().transform as RectTransform;
        var peiyangWindow=Instantiate(Resources.Load("Prefabs/Window/ChongWuPeiYangWindow")) as GameObject;
        peiyangWindow.GetComponent<ChongWuPeiYangWindow>().SetXiangQingPage(id);
    }
    
    public void ShowQuality(int quality)
    {
        Quality1.gameObject.SetActive(false);
        Quality2.gameObject.SetActive(false);
        Quality3.gameObject.SetActive(false);
        Quality4.gameObject.SetActive(false);
        Quality5.gameObject.SetActive(false);
        Quality6.gameObject.SetActive(false);
        switch (quality)
        {
            case 1:
                Quality1.gameObject.SetActive(true);
                break;
            case 2:
                Quality2.gameObject.SetActive(true);
                break;
            case 3:
                Quality3.gameObject.SetActive(true);
                break;
            case 4:
                Quality4.gameObject.SetActive(true);
                break;
            case 5:
                Quality5.gameObject.SetActive(true);
                break;
            case 6:
                Quality6.gameObject.SetActive(true);
                break;
        }
    }
    
    public void InitHide()
    {
        Quality.gameObject.SetActive(false);
        ZiZhi.gameObject.SetActive(false);
        XueMai.gameObject.SetActive(false);
        LevelInfo.gameObject.SetActive(false);
        IceWhite1.gameObject.SetActive(false);
        HuoWhite1.gameObject.SetActive(false);
        DianWhite1.gameObject.SetActive(false);
        HeiAnWhite1.gameObject.SetActive(false);
        HeiAnWhite2.gameObject.SetActive(false);

        IceGreen1.gameObject.SetActive(false);
        IceGreen2.gameObject.SetActive(false);
        IceGreen3.gameObject.SetActive(false);
        HuoGreen1.gameObject.SetActive(false);
        HuoGreen2.gameObject.SetActive(false);
        DianGreen1.gameObject.SetActive(false);
        DianGreen2.gameObject.SetActive(false);
        HeiAnGreen1.gameObject.SetActive(false);
        HeiAnGreen2.gameObject.SetActive(false);
        HeiAnGreen3.gameObject.SetActive(false);

        IceBlue1.gameObject.SetActive(false);
        IceBlue2.gameObject.SetActive(false);
        HuoBlue1.gameObject.SetActive(false);
        HuoBlue2.gameObject.SetActive(false);
        HuoBlue3.gameObject.SetActive(false);
        DianBlue1.gameObject.SetActive(false);
        DianBlue2.gameObject.SetActive(false);
        HeiAnBlue1.gameObject.SetActive(false);
        HeiAnBlue2.gameObject.SetActive(false);
        HeiAnBlue3.gameObject.SetActive(false);

        IcePurple1_q.gameObject.SetActive(false);
        IcePurple2_q.gameObject.SetActive(false);
        IcePurple3_q.gameObject.SetActive(false);
        HuoPurple1_q.gameObject.SetActive(false);
        HuoPurple2_q.gameObject.SetActive(false);
        HuoPurple3_q.gameObject.SetActive(false);
        DianPurple1_q.gameObject.SetActive(false);
        DianPurple2_q.gameObject.SetActive(false);
        DianPurple3_q.gameObject.SetActive(false);
        HeiAnPurple1_q.gameObject.SetActive(false);
        HeiAnPurple2_q.gameObject.SetActive(false);
        HeiAnPurple3_q.gameObject.SetActive(false);

        IcePurple1_h.gameObject.SetActive(false);
        IcePurple2_h.gameObject.SetActive(false);
        IcePurple3_h.gameObject.SetActive(false);
        HuoPurple1_h.gameObject.SetActive(false);
        HuoPurple2_h.gameObject.SetActive(false);
        HuoPurple3_h.gameObject.SetActive(false);
        DianPurple1_h.gameObject.SetActive(false);
        DianPurple2_h.gameObject.SetActive(false);
        DianPurple3_h.gameObject.SetActive(false);
        HeiAnPurple1_h.gameObject.SetActive(false);
        HeiAnPurple2_h.gameObject.SetActive(false);
        HeiAnPurple3_h.gameObject.SetActive(false);

        IceOrange1_q.gameObject.SetActive(false);
        HuoOrange1_q.gameObject.SetActive(false);
        DianOrange1_q.gameObject.SetActive(false);
        HeiAnOrange1_q.gameObject.SetActive(false);

        IceOrange1_h.gameObject.SetActive(false);
        HuoOrange1_h.gameObject.SetActive(false);
        DianOrange1_h.gameObject.SetActive(false);
        HeiAnOrange1_h.gameObject.SetActive(false);
    }

    public void ShowSke(ChongWuTable table)
    {
        switch (table.ChongWuType)
        {
            case ChongWuType.icewhite1:
                IceWhite1.gameObject.SetActive(true);
                break;
            case ChongWuType.huowhite1:
                HuoWhite1.gameObject.SetActive(true);
                break;
            case ChongWuType.dianwhite1:
                DianWhite1.gameObject.SetActive(true);
                break;
            case ChongWuType.heianwhite1:
                HeiAnWhite1.gameObject.SetActive(true);
                break;
            case ChongWuType.heianwhite2:
                HeiAnWhite2.gameObject.SetActive(true);
                break;
            
            case ChongWuType.icegreen1:
                IceGreen1.gameObject.SetActive(true);
                break;
            case ChongWuType.icegreen2:
                IceGreen2.gameObject.SetActive(true);
                break;
            case ChongWuType.icegreen3:
                IceGreen3.gameObject.SetActive(true);
                break;
            case ChongWuType.huogreen1:
                HuoGreen1.gameObject.SetActive(true);
                break;
            case ChongWuType.huogreen2:
                HuoGreen2.gameObject.SetActive(true);
                break;
            case ChongWuType.diangreen1:
                DianGreen1.gameObject.SetActive(true);
                break;
            case ChongWuType.diangreen2:
                DianGreen2.gameObject.SetActive(true);
                break;
            case ChongWuType.heiangreen1:
                HeiAnGreen1.gameObject.SetActive(true);
                break;
            case ChongWuType.heiangreen2:
                HeiAnGreen2.gameObject.SetActive(true);
                break;
            case ChongWuType.heiangreen3:
                HeiAnGreen3.gameObject.SetActive(true);
                break;
            
            
            case ChongWuType.iceblue1:
                IceBlue1.gameObject.SetActive(true);
                break;
            case ChongWuType.iceblue2:
                IceBlue2.gameObject.SetActive(true);
                break;
            case ChongWuType.huoblue1:
                HuoBlue1.gameObject.SetActive(true);
                break;
            case ChongWuType.huoblue2:
                HuoBlue2.gameObject.SetActive(true);
                break;
            case ChongWuType.huoblue3:
                HuoBlue3.gameObject.SetActive(true);
                break;
            case ChongWuType.dianblue1:
                DianBlue1.gameObject.SetActive(true);
                break;
            case ChongWuType.dianblue2:
                DianBlue2.gameObject.SetActive(true);
                break;
            case ChongWuType.heianblue1:
                HeiAnBlue1.gameObject.SetActive(true);
                break;
            case ChongWuType.heianblue2:
                HeiAnBlue2.gameObject.SetActive(true);
                break;
            case ChongWuType.heianblue3:
                HeiAnBlue3.gameObject.SetActive(true);
                break;
            
            
            case ChongWuType.icepurple1_q:
                IcePurple1_q.gameObject.SetActive(true);
                break;
            case ChongWuType.icepurple2_q:
                IcePurple2_q.gameObject.SetActive(true);
                break;
            case ChongWuType.icepurple3_q:
                IcePurple3_q.gameObject.SetActive(true);
                break;
            case ChongWuType.huopurple1_q:
                HuoPurple1_q.gameObject.SetActive(true);
                break;
            case ChongWuType.huopurple2_q:
                HuoPurple2_q.gameObject.SetActive(true);
                break;
            case ChongWuType.huopurple3_q:
                HuoPurple3_q.gameObject.SetActive(true);
                break;
            case ChongWuType.dianpurple1_q:
                DianPurple1_q.gameObject.SetActive(true);
                break;
            case ChongWuType.dianpurple2_q:
                DianPurple2_q.gameObject.SetActive(true);
                break;
            case ChongWuType.dianpurple3_q:
                DianPurple3_q.gameObject.SetActive(true);
                break;
            case ChongWuType.heianpurple1_q:
                HeiAnPurple1_q.gameObject.SetActive(true);
                break;
            case ChongWuType.heianpurple2_q:
                HeiAnPurple2_q.gameObject.SetActive(true);
                break;
            case ChongWuType.heianpurple3_q:
                HeiAnPurple3_q.gameObject.SetActive(true);
                break;
            
            
            case ChongWuType.icepurple1_h:
                IcePurple1_h.gameObject.SetActive(true);
                break;
            case ChongWuType.icepurple2_h:
                IcePurple2_h.gameObject.SetActive(true);
                break;
            case ChongWuType.icepurple3_h:
                IcePurple3_h.gameObject.SetActive(true);
                break;
            case ChongWuType.huopurple1_h:
                HuoPurple1_h.gameObject.SetActive(true);
                break;
            case ChongWuType.huopurple2_h:
                HuoPurple2_h.gameObject.SetActive(true);
                break;
            case ChongWuType.huopurple3_h:
                HuoPurple3_h.gameObject.SetActive(true);
                break;
            case ChongWuType.dianpurple1_h:
                DianPurple1_h.gameObject.SetActive(true);
                break;
            case ChongWuType.dianpurple2_h:
                DianPurple2_h.gameObject.SetActive(true);
                break;
            case ChongWuType.dianpurple3_h:
                DianPurple3_h.gameObject.SetActive(true);
                break;
            case ChongWuType.heianpurple1_h:
                HeiAnPurple1_h.gameObject.SetActive(true);
                break;
            case ChongWuType.heianpurple2_h:
                HeiAnPurple2_h.gameObject.SetActive(true);
                break;
            case ChongWuType.heianpurple3_h:
                HeiAnPurple3_h.gameObject.SetActive(true);
                break;
            
            case ChongWuType.heianorange1_q:
                HeiAnOrange1_h.gameObject.SetActive(true);
                break;
            case ChongWuType.iceorange1_q:
                IceOrange1_h.gameObject.SetActive(true);
                break;
            case ChongWuType.huoorange1_q:
                HuoOrange1_h.gameObject.SetActive(true);
                break;
            case ChongWuType.dianorange1_q:
                DianOrange1_h.gameObject.SetActive(true);
                break;
            
            case ChongWuType.heianorange1_h:
                HeiAnOrange1_h.gameObject.SetActive(true);
                break;
            case ChongWuType.iceorange1_h:
                IceOrange1_h.gameObject.SetActive(true);
                break;
            case ChongWuType.huoorange1_h:
                HuoOrange1_h.gameObject.SetActive(true);
                break;
            case ChongWuType.dianorange1_h:
                DianOrange1_h.gameObject.SetActive(true);
                break;
        }
    }

    public void SetName()
    {
        ChongWuName1.gameObject.SetActive(false);
        ChongWuName2.gameObject.SetActive(false);
        ChongWuName3.gameObject.SetActive(false);
        ChongWuName4.gameObject.SetActive(false);
        ChongWuName5.gameObject.SetActive(false);
        ChongWuName6.gameObject.SetActive(false);
        ChongWuTable table = PlayerData.S.ChongWuDic[PlayerData.S.ZhuChongWuId];
        switch (table.Quality)
        {
            case 1:
                ChongWuName1.gameObject.SetActive(true);
                ChongWuName1.text=table.Name;
                break;
            case 2:
                ChongWuName2.gameObject.SetActive(true);
                ChongWuName2.text=table.Name;
                break;
            case 3:
                ChongWuName3.gameObject.SetActive(true);
                ChongWuName3.text=table.Name;
                break;
            case 4:
                ChongWuName4.gameObject.SetActive(true);
                ChongWuName4.text=table.Name;
                break;
            case 5:
                ChongWuName5.gameObject.SetActive(true);
                ChongWuName5.text=table.Name;
                break;
            case 6:
                ChongWuName6.gameObject.SetActive(true);
                ChongWuName6.text=table.Name;
                break;
        }
    }

    public void ShowZhuChongWu()
    {
        if (PlayerData.S.ZhuChongWuId == 0)
        {
            return;
        }
        ChongWuTable table = PlayerData.S.ChongWuDic[PlayerData.S.ZhuChongWuId];
        ShowSke(table);
        Quality.gameObject.SetActive(true);
        ZiZhi.gameObject.SetActive(true);
        XueMai.gameObject.SetActive(true);
        LevelInfo.gameObject.SetActive(true);
        LevelCount.text = table.Level.ToString();
        SetName();
        ChongWujingHua.text = PlayerData.S.ChongWuJingHua.ToString();
        switch (table.Quality)
        {
            case 1:
                ShowQuality(1);
                break;
            case 2:
                ShowQuality(2);
                break;
            case 3:
                ShowQuality(3);
                break;
            case 4:
                ShowQuality(4);
                break;
            case 5:
                ShowQuality(5);
                break;
            case 6:
                ShowQuality(6);
                break;
        }

        ZiZhiCount.text = table.ZiZhi.ToString();
        XueMaiCount.text = table.XueMai.ToString();
    }
    
    private void OnEnable()
    {
        InitHide();
        if (PlayerData.S.ZhuChongWuId != 0)
        {
            ShowZhuChongWu();
        }
        ChongWuController.S.CurrentChongWuPageNum = 1;
        ShowChongWuPage();
        SetPageNum();
    }

    public void RefreshChongWuPage(object[] obj)
    {
        ShowZhuChongWu();
        ShowChongWuPage();
    }

    public void SetPageNum()
    {
        PageNum.text = ChongWuController.S.CurrentChongWuPageNum.ToString();
    }

    public void FenJie(object[] obj)
    {
        if (PlayerData.S.ZhuChongWuId==0)
        {
            InitHide();
        }
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
        ChongWujingHua.text = PlayerData.S.ChongWuJingHua.ToString();
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
        List<ChongWuTable> List = PlayerData.S.ChongWuDic.Values.ToList();
        if (originIndex < List.Count)
        {
            table1 = List[originIndex];
        }

        if (originIndex + 1 < List.Count)
        {
            table2 = List[originIndex + 1];
        }

        if (originIndex + 2 < List.Count)
        {
            table3 = List[originIndex + 2];
        }

        if (originIndex + 3 < List.Count)
        {
            table4 = List[originIndex + 3];
        }

        if (originIndex + 4 < List.Count)
        {
            table5 = List[originIndex + 4];
        }

        if (originIndex + 5 < List.Count)
        {
            table6 = List[originIndex + 5];
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
        ObserverModuleManager.S.UnRegisterEvent("FenJie", FenJie);
        ObserverModuleManager.S.UnRegisterEvent("ShowChongWuItemMask", ShowChongWuItemMask);
        ObserverModuleManager.S.UnRegisterEvent("HideChongWuItemMask", HideChongWuItemMask);
        ObserverModuleManager.S.UnRegisterEvent("ShowPeiYangWindow",ShowPeiYangWindowObj);
        ObserverModuleManager.S.UnRegisterEvent("ChongWuChuZhan", ChongWuChuZhan);
        ObserverModuleManager.S.UnRegisterEvent("RefreshChongWuPage", RefreshChongWuPage);
        ObserverModuleManager.S.UnRegisterEvent("ResetFuChongWu", ResetFuChongWu);

    }

    private void Awake()
    {
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
        
    }

    public void ChongWuChuZhan(object[] obj)
    {
        InitHide();
        ShowZhuChongWu();
    }
    
    public void ResetFuChongWu(object[] obj)
    {
        fuChongWuItem1.ShowFuChong();
        fuChongWuItem2.ShowFuChong();
        fuChongWuItem3.ShowFuChong();
    }
    

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("FenJie", FenJie);
        ObserverModuleManager.S.RegisterEvent("ShowChongWuItemMask", ShowChongWuItemMask);
        ObserverModuleManager.S.RegisterEvent("HideChongWuItemMask", HideChongWuItemMask);
        ObserverModuleManager.S.RegisterEvent("ShowPeiYangWindow",ShowPeiYangWindowObj);
        ObserverModuleManager.S.RegisterEvent("ChongWuChuZhan", ChongWuChuZhan);
        ObserverModuleManager.S.RegisterEvent("RefreshChongWuPage", RefreshChongWuPage);
        ObserverModuleManager.S.RegisterEvent("ResetFuChongWu", ResetFuChongWu);

        FuChongButton.onClick.AddListener(() =>
        {
            ShowFuChong();
        });
        ZhuChongButton.onClick.AddListener(() =>
        {
            ShowZhuChong();
        });
        
        TuJianButton.onClick.AddListener(() =>
        {
            var tujian=Instantiate(Resources.Load<GameObject>("Prefabs/Window/ChongWuTuJianWindow"));
        });
        
        PeiYangButton.onClick.AddListener(() =>
        {
            ShowPeiYangWindow(PlayerData.S.ZhuChongWuId);
        });
        
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
