using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChongWuPeiYangWindow : MonoBehaviour
{
    public TextMeshProUGUI title;
    public GameObject Quality1;
    public GameObject Quality2;
    public GameObject Quality3;
    public GameObject Quality4;
    public GameObject Quality5;
    public GameObject Quality6;
    public TextMeshProUGUI ZiZhiCount;
    public TextMeshProUGUI LeftXueMaiCount;


    public int CurrentChongWuId;
    public TextMeshProUGUI NameLevelCount;
    public TextMeshProUGUI Name1;
    public TextMeshProUGUI Name2;
    public TextMeshProUGUI Name3;
    public TextMeshProUGUI Name4;
    public TextMeshProUGUI Name5;
    public TextMeshProUGUI Name6;
    public Image YuanSuIcon;
    public Button WeiYangButton;
    public Button ChongZhiButton;
    public Button XiangQingButton;
    public GameObject ChuZhanText;
    public Button ExitButton;
    public GameObject XiangQingPanel;
    public GameObject WeiYangPanel;
    public GameObject ChongZhiPanel;
    
    [Header("详情Panel")]
    public TextMeshProUGUI LevelCount;
    public Slider ExSlider;
    public TextMeshProUGUI CurrentExp;
    public TextMeshProUGUI MaxExp;
    public GameObject XX1;
    public GameObject XX2;
    public GameObject XX3;
    public GameObject XX4;
    public GameObject XX5;
    public GameObject XX6;
    public Slider JingHuaSlider;
    public TextMeshProUGUI CurrentJingHua;
    public TextMeshProUGUI MaxJingHua;
    public TextMeshProUGUI XueMaiCount;
    public TextMeshProUGUI YuanSuDamage;
    public TextMeshProUGUI ZiZhi;
    public TextMeshProUGUI Attack;
    public TextMeshProUGUI Defense;
    public TextMeshProUGUI Hp;
    public TextMeshProUGUI Crit;
    public GameObject SkillContent;
    public Button ChuZhanButton;
    public Button ZhuFuButton;

    [Header("喂养Panel")] 
    public TextMeshProUGUI CurrentLevel;
    public Slider WeiYangExSlider;
    public TextMeshProUGUI CurrentEx;
    public TextMeshProUGUI MaxEx;
    public GameObject ShiWuContent;
    public Button ShenJi1;
    public Button ShenJi5;

    [Header("重置Panel")] 
    public Slider ZiZhiSlider;
    public Slider XueMaiSlider;
    public TextMeshProUGUI CurrentZiZhi;
    public TextMeshProUGUI MaxZiZhi;
    public TextMeshProUGUI CurrentXueMai;
    public TextMeshProUGUI MaxXueMai;
    public Button ZiZhiButton;
    public Button XueMaiButton;
    public GameObject YaoShui;
    public TextMeshProUGUI CurrentYaoCount;
    public Button ChongZhiButton1;
    private bool IsZiZhiPanel = true;
    public TextMeshProUGUI ZiZhiWanMei;
    public TextMeshProUGUI XueMaiWanMei;
    public Button JinHuaButton;


    public void SetChongZhiPanel(bool isZiZhiPanel=true)
    {
        var table = PlayerData.S.ChongWuDic[CurrentChongWuId];
        XueMaiWanMei.gameObject.SetActive(table.XueMai==ChongWuConfig.ChongWuXueMaiDic[table.Quality].max);
        ZiZhiWanMei.gameObject.SetActive(table.ZiZhi==ChongWuConfig.ChongWuZiZhiDic[table.Quality].max);

        switch (table.Quality)
        {
            case 1:
                ZiZhiSlider.maxValue = ChongWuConfig.ChongWuZiZhiDic[1].max;
                ZiZhiSlider.value = table.ZiZhi;
                CurrentZiZhi.text=table.ZiZhi.ToString();
                MaxZiZhi.text= ChongWuConfig.ChongWuZiZhiDic[1].max.ToString();
                XueMaiSlider.maxValue=ChongWuConfig.ChongWuXueMaiDic[1].max;
                XueMaiSlider.value = table.XueMai;
                CurrentXueMai.text=table.XueMai.ToString();
                MaxXueMai.text= ChongWuConfig.ChongWuXueMaiDic[1].max.ToString();
                YaoShui.transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                YaoShui.transform.Find("Edge").GetComponent<Animator>().Play("BlueEdge");
                if (isZiZhiPanel)
                {
                    IsZiZhiPanel = true;
                    CurrentYaoCount.text=BagController.S.PropList[1703].Count.ToString();
                    YaoShui.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.NormalXiSuiYe;
                }
                else
                {
                    IsZiZhiPanel = false;
                    CurrentYaoCount.text=BagController.S.PropList[1803].Count.ToString();
                    YaoShui.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.NormalXueMaiDan;
                }
                break;
            
            case 2:
                ZiZhiSlider.maxValue = ChongWuConfig.ChongWuZiZhiDic[2].max;
                ZiZhiSlider.value = table.ZiZhi;
                CurrentZiZhi.text=table.ZiZhi.ToString();
                MaxZiZhi.text= ChongWuConfig.ChongWuZiZhiDic[2].max.ToString();
                XueMaiSlider.maxValue=ChongWuConfig.ChongWuXueMaiDic[2].max;
                XueMaiSlider.value = table.XueMai;
                CurrentXueMai.text=table.XueMai.ToString();
                MaxXueMai.text= ChongWuConfig.ChongWuXueMaiDic[2].max.ToString();
                YaoShui.transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                YaoShui.transform.Find("Edge").GetComponent<Animator>().Play("BlueEdge");
                if (isZiZhiPanel)
                {
                    IsZiZhiPanel = true;
                    CurrentYaoCount.text=BagController.S.PropList[1703].Count.ToString();
                    YaoShui.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.NormalXiSuiYe;
                }
                else
                {
                    IsZiZhiPanel = false;
                    CurrentYaoCount.text=BagController.S.PropList[1803].Count.ToString();
                    YaoShui.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.NormalXueMaiDan;
                }
                break;
            
            case 3:
                ZiZhiSlider.maxValue = ChongWuConfig.ChongWuZiZhiDic[3].max;
                ZiZhiSlider.value = table.ZiZhi;
                CurrentZiZhi.text=table.ZiZhi.ToString();
                MaxZiZhi.text= ChongWuConfig.ChongWuZiZhiDic[3].max.ToString();
                XueMaiSlider.maxValue=ChongWuConfig.ChongWuXueMaiDic[3].max;
                XueMaiSlider.value = table.XueMai;
                CurrentXueMai.text=table.XueMai.ToString();
                MaxXueMai.text= ChongWuConfig.ChongWuXueMaiDic[3].max.ToString();
                YaoShui.transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                YaoShui.transform.Find("Edge").GetComponent<Animator>().Play("BlueEdge");
                if (isZiZhiPanel)
                {
                    IsZiZhiPanel = true;
                    CurrentYaoCount.text=BagController.S.PropList[1703].Count.ToString();
                    YaoShui.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.NormalXiSuiYe;
                }
                else
                {
                    IsZiZhiPanel = false;
                    CurrentYaoCount.text=BagController.S.PropList[1803].Count.ToString();
                    YaoShui.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.NormalXueMaiDan;
                }
                break;
            
            case 4:
                ZiZhiSlider.maxValue = ChongWuConfig.ChongWuZiZhiDic[4].max;
                ZiZhiSlider.value = table.ZiZhi;
                CurrentZiZhi.text=table.ZiZhi.ToString();
                MaxZiZhi.text= ChongWuConfig.ChongWuZiZhiDic[4].max.ToString();
                XueMaiSlider.maxValue=ChongWuConfig.ChongWuXueMaiDic[4].max;
                XueMaiSlider.value = table.XueMai;
                CurrentXueMai.text=table.XueMai.ToString();
                MaxXueMai.text= ChongWuConfig.ChongWuXueMaiDic[4].max.ToString();
                YaoShui.transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                YaoShui.transform.Find("Edge").GetComponent<Animator>().Play("OrangeEdge");
                if (isZiZhiPanel)
                {
                    IsZiZhiPanel = true;
                    CurrentYaoCount.text=BagController.S.PropList[1705].Count.ToString();
                    YaoShui.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.GaoJiXiSuiYe;
                }
                else
                {
                    IsZiZhiPanel = false;
                    CurrentYaoCount.text=BagController.S.PropList[1805].Count.ToString();
                    YaoShui.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.GaoJiXueMaiDan;
                }
                break;
            
            case 5:
                ZiZhiSlider.maxValue = ChongWuConfig.ChongWuZiZhiDic[5].max;
                ZiZhiSlider.value = table.ZiZhi;
                CurrentZiZhi.text=table.ZiZhi.ToString();
                MaxZiZhi.text= ChongWuConfig.ChongWuZiZhiDic[5].max.ToString();
                XueMaiSlider.maxValue=ChongWuConfig.ChongWuXueMaiDic[5].max;
                XueMaiSlider.value = table.XueMai;
                CurrentXueMai.text=table.XueMai.ToString();
                MaxXueMai.text= ChongWuConfig.ChongWuXueMaiDic[5].max.ToString();
                YaoShui.transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                YaoShui.transform.Find("Edge").GetComponent<Animator>().Play("OrangeEdge");
                if (isZiZhiPanel)
                {
                    IsZiZhiPanel = true;
                    CurrentYaoCount.text=BagController.S.PropList[1705].Count.ToString();
                    YaoShui.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.GaoJiXiSuiYe;
                }
                else
                {
                    IsZiZhiPanel = false;
                    CurrentYaoCount.text=BagController.S.PropList[1805].Count.ToString();
                    YaoShui.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.GaoJiXueMaiDan;
                }
                break;
            
        }
    }
    
    
    public void SetWeiYangPanel()
    {
        var table = PlayerData.S.ChongWuDic[CurrentChongWuId];
        CurrentLevel.text = "Lv "+table.Level;
        WeiYangExSlider.maxValue = ChongWuConfig.ChongWuExDic[table.Level];
        WeiYangExSlider.value = table.Ex;
        CurrentEx.text=table.Ex.ToString();
        MaxEx.text=ChongWuConfig.ChongWuExDic[table.Level].ToString();
        title.text = "喂养";

        foreach (Transform item in ShiWuContent.transform)
        {
            Destroy(item.gameObject);
        }
        for (int i = 0; i<6; i++)
        {
            ShiWuItem shiwu=Instantiate(Resources.Load<GameObject>("Prefabs/Window/ShiWuItem"),ShiWuContent.transform).GetComponent<ShiWuItem>();
            shiwu.Quatity = i + 1;
            shiwu.ChongWuId = CurrentChongWuId;
            shiwu.SetShiWuItem();
        }
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

    private void Awake()
    {
          IceWhite1=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰White1").gameObject;
        HuoWhite1=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火White1").gameObject;
        DianWhite1=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/电White1").gameObject;
        HeiAnWhite1=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗White1").gameObject;
        HeiAnWhite2=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗White2").gameObject;

        IceGreen1=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰Green1").gameObject;
        IceGreen2=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰Green2").gameObject;
        IceGreen3=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰Green3").gameObject;
        HuoGreen1=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火Green1").gameObject;
        HuoGreen2=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火Green2").gameObject;
        DianGreen1=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/电Green1").gameObject;
        DianGreen2=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/电Green2").gameObject;
        HeiAnGreen1=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗Green1").gameObject;
        HeiAnGreen2=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗Green2").gameObject;
        HeiAnGreen3=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗Green3").gameObject;

        IceBlue1=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰Blue1").gameObject;
        IceBlue2=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰Blue2").gameObject;
        HuoBlue1=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火blue1").gameObject;
        HuoBlue2=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火blue2").gameObject;
        HuoBlue3=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火blue3").gameObject;
        DianBlue1=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/电blue1").gameObject;
        DianBlue2=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/电blue2").gameObject;
        HeiAnBlue1=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗blue1").gameObject;
        HeiAnBlue2=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗blue2").gameObject;
        HeiAnBlue3=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗blue3").gameObject;
        
        IcePurple1_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰purple1_前").gameObject;
        IcePurple2_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰purple2_前").gameObject;
        IcePurple3_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰purple3_前").gameObject;
        HuoPurple1_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火purple1_前").gameObject;
        HuoPurple2_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火purple2_前").gameObject;
        HuoPurple3_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火purple3_前").gameObject;
        DianPurple1_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/电purple1_前").gameObject;
        DianPurple2_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/电purple2_前").gameObject;
        DianPurple3_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/电purple3_前").gameObject;
        HeiAnPurple1_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗purple1_前").gameObject;
        HeiAnPurple2_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗purple2_前").gameObject;
        HeiAnPurple3_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗purple3_前").gameObject;
        
        IcePurple1_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰purple1_后").gameObject;
        IcePurple2_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰purple2_后").gameObject;
        IcePurple3_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰purple3_后").gameObject;
        HuoPurple1_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火purple1_后").gameObject;
        HuoPurple2_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火purple2_后").gameObject;
        HuoPurple3_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火purple3_后").gameObject;
        DianPurple1_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/电purple1_后").gameObject;
        DianPurple2_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/电purple2_后").gameObject;
        DianPurple3_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/电purple3_后").gameObject;
        HeiAnPurple1_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗purple1_后").gameObject;
        HeiAnPurple2_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗purple2_后").gameObject;
        HeiAnPurple3_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗purple3_后").gameObject;
        
        IceOrange1_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰Orange1_后").gameObject;
        HuoOrange1_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火Orange1_后").gameObject;
        DianOrange1_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/电Orange1_后").gameObject;
        HeiAnOrange1_h=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗Orange1_后").gameObject;
        
        IceOrange1_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/冰Orange1_前").gameObject;
        HuoOrange1_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/火Orange1_前").gameObject;
        DianOrange1_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/电Orange1_前").gameObject;
        HeiAnOrange1_q=transform.Find("Mask/BagBG/LeftPanel/ImagePanel/ChongWuSke/黑暗Orange1_前").gameObject;
        
    }
    
    public void ShowXiangQingPanel()
    {
        XiangQingPanel.SetActive(true);
        WeiYangPanel.SetActive(false);
        ChongZhiPanel.SetActive(false);
        SetXiangQingPage(CurrentChongWuId);
    }
    
    public void ShowChongZhiPanel()
    {
        XiangQingPanel.SetActive(false);
        WeiYangPanel.SetActive(false);
        ChongZhiPanel.SetActive(true);
        SetChongZhiPanel();
    }
    
    public void ShowWeiYangPanel()
    {
        XiangQingPanel.SetActive(false);
        WeiYangPanel.SetActive(true);
        ChongZhiPanel.SetActive(false);
        SetWeiYangPanel();
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
    
     public void HideSke()
    {
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

    public void RefreshWeiYangPage(object[] obj)
    {
        SetWeiYangPanel();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("RefreshWeiYangPage",RefreshWeiYangPage);
    }

    private void Start()
    {
        JinHuaButton.onClick.AddListener(() =>
        {
            var table=PlayerData.S.ChongWuDic[CurrentChongWuId];
            if (table.Quality < 4)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"史诗以上宠物才可以进化");
                return;
            }

            if (table.ZiZhi < ChongWuConfig.ChongWuZiZhiDic[table.Quality].max ||
                table.XueMai < ChongWuConfig.ChongWuXueMaiDic[table.Quality].max)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"资质和血脉达到完美才可以进化");
                return;
            }

            table.ChongWuType = ChongWuConfig.ChongWuJinHuaDic[table.ChongWuType];
            table.Quality++;
            SetChongZhiPanel();
            SetWeiYangPanel();
            ObserverModuleManager.S.SendEvent("RefreshChongWuPage");
        });
        ZiZhiButton.onClick.AddListener(() =>
        {
            SetChongZhiPanel(true);
        });
        XueMaiButton.onClick.AddListener(() =>
        {
            SetChongZhiPanel(false);
        });
        ChongZhiButton1.onClick.AddListener(() =>
        {
            var table=PlayerData.S.ChongWuDic[CurrentChongWuId];
            if (IsZiZhiPanel)
            {
                if (table.Quality <= 3)
                {
                    if (!BagController.S.PropList.ContainsKey(1703) || BagController.S.PropList[1703].Count < 1)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                        return;
                    }

                    BagController.S.PropList[1703].Count--;
                    int random = Random.Range(ChongWuConfig.ChongWuZiZhiDic[table.Quality].min,
                        ChongWuConfig.ChongWuZiZhiDic[table.Quality].max+1);
                    table.ZiZhi = random;
                    SetChongZhiPanel(true);
                    ObserverModuleManager.S.SendEvent("RefreshChongWuPage");
                }
                else
                {
                    if (!BagController.S.PropList.ContainsKey(1705) || BagController.S.PropList[1705].Count < 1)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                        return;
                    }

                    BagController.S.PropList[1705].Count--;
                    int random = Random.Range(ChongWuConfig.ChongWuZiZhiDic[table.Quality].min,
                        ChongWuConfig.ChongWuZiZhiDic[table.Quality].max+1);
                    table.ZiZhi = random;
                    SetChongZhiPanel(true);
                    ObserverModuleManager.S.SendEvent("RefreshChongWuPage");

                }
            }
            else
            {
                if (table.Quality <= 3)
                {
                    if (!BagController.S.PropList.ContainsKey(1803) || BagController.S.PropList[1803].Count < 1)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                        return;
                    }

                    BagController.S.PropList[1803].Count--;
                    int random = Random.Range(ChongWuConfig.ChongWuXueMaiDic[table.Quality].min,
                        ChongWuConfig.ChongWuXueMaiDic[table.Quality].max+1);
                    table.XueMai = random;
                    SetChongZhiPanel(false);
                    ObserverModuleManager.S.SendEvent("RefreshChongWuPage");

                }
                else
                {
                    if (!BagController.S.PropList.ContainsKey(1805) || BagController.S.PropList[1805].Count < 1)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                        return;
                    }

                    BagController.S.PropList[1805].Count--;
                    int random = Random.Range(ChongWuConfig.ChongWuXueMaiDic[table.Quality].min,
                        ChongWuConfig.ChongWuXueMaiDic[table.Quality].max+1);
                    table.XueMai = random;
                    SetChongZhiPanel(false);
                    ObserverModuleManager.S.SendEvent("RefreshChongWuPage");
                }
            }
        });
        ShenJi1.onClick.AddListener(() =>
        {
            if (PlayerData.S.ChongWuShiWu1 <= 0 && PlayerData.S.ChongWuShiWu2 <= 0 && PlayerData.S.ChongWuShiWu3 <= 0 &&
                PlayerData.S.ChongWuShiWu4 <= 0 && PlayerData.S.ChongWuShiWu5 <= 0 && PlayerData.S.ChongWuShiWu6 <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"没有宠物食物");
            }
            var table=PlayerData.S.ChongWuDic[CurrentChongWuId];
            while (table.Ex<ChongWuConfig.ChongWuExDic[table.Level])
            {
                if (PlayerData.S.ChongWuShiWu1 <= 0 && PlayerData.S.ChongWuShiWu2 <= 0 && PlayerData.S.ChongWuShiWu3 <= 0 &&
                    PlayerData.S.ChongWuShiWu4 <= 0 && PlayerData.S.ChongWuShiWu5 <= 0 && PlayerData.S.ChongWuShiWu6 <= 0)
                {
                    break;
                }
                if (PlayerData.S.ChongWuShiWu1 > 0)
                {
                    PlayerData.S.ChongWuShiWu1--;
                    table.Ex += ChongWuConfig.ShiWuDic[1];
                    continue;
                }
                if (PlayerData.S.ChongWuShiWu2 > 0)
                {
                    PlayerData.S.ChongWuShiWu2--;
                    table.Ex += ChongWuConfig.ShiWuDic[2];
                    continue;
                }
                if (PlayerData.S.ChongWuShiWu3 > 0)
                {
                    PlayerData.S.ChongWuShiWu3--;
                    table.Ex += ChongWuConfig.ShiWuDic[3];
                    continue;
                }
                if (PlayerData.S.ChongWuShiWu4 > 0)
                {
                    PlayerData.S.ChongWuShiWu4--;
                    table.Ex += ChongWuConfig.ShiWuDic[4];
                    continue;
                }
                if (PlayerData.S.ChongWuShiWu5 > 0)
                {
                    PlayerData.S.ChongWuShiWu5--;
                    table.Ex += ChongWuConfig.ShiWuDic[5];
                    continue;
                }
                if (PlayerData.S.ChongWuShiWu6 > 0)
                {
                    PlayerData.S.ChongWuShiWu6--;
                    table.Ex += ChongWuConfig.ShiWuDic[6];
                    continue;
                }
            }

            while (table.Ex >= ChongWuConfig.ChongWuExDic[table.Level])
            {
                table.Ex -= ChongWuConfig.ChongWuExDic[table.Level];
                table.Level++;
            }
            SetWeiYangPanel();
            SetXiangQingPage(CurrentChongWuId);
            ObserverModuleManager.S.SendEvent("RefreshChongWuPage");

        });
        
          ShenJi5.onClick.AddListener(() =>
        {
            if (PlayerData.S.ChongWuShiWu1 <= 0 && PlayerData.S.ChongWuShiWu2 <= 0 && PlayerData.S.ChongWuShiWu3 <= 0 &&
                PlayerData.S.ChongWuShiWu4 <= 0 && PlayerData.S.ChongWuShiWu5 <= 0 && PlayerData.S.ChongWuShiWu6 <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"没有宠物食物");
            }
            var table=PlayerData.S.ChongWuDic[CurrentChongWuId];
            int originLevel = table.Level;
            while (table.Level - originLevel < 5)
            {
                if (PlayerData.S.ChongWuShiWu1 <= 0 && PlayerData.S.ChongWuShiWu2 <= 0 &&
                    PlayerData.S.ChongWuShiWu3 <= 0 &&
                    PlayerData.S.ChongWuShiWu4 <= 0 && PlayerData.S.ChongWuShiWu5 <= 0 &&
                    PlayerData.S.ChongWuShiWu6 <= 0)
                {
                    break;
                }
                while (table.Ex < ChongWuConfig.ChongWuExDic[table.Level])
                {
                    if (PlayerData.S.ChongWuShiWu1 <= 0 && PlayerData.S.ChongWuShiWu2 <= 0 &&
                        PlayerData.S.ChongWuShiWu3 <= 0 &&
                        PlayerData.S.ChongWuShiWu4 <= 0 && PlayerData.S.ChongWuShiWu5 <= 0 &&
                        PlayerData.S.ChongWuShiWu6 <= 0)
                    {
                        break;
                    }

                    if (PlayerData.S.ChongWuShiWu1 > 0)
                    {
                        PlayerData.S.ChongWuShiWu1--;
                        table.Ex += ChongWuConfig.ShiWuDic[1];
                        continue;
                    }

                    if (PlayerData.S.ChongWuShiWu2 > 0)
                    {
                        PlayerData.S.ChongWuShiWu2--;
                        table.Ex += ChongWuConfig.ShiWuDic[2];
                        continue;
                    }

                    if (PlayerData.S.ChongWuShiWu3 > 0)
                    {
                        PlayerData.S.ChongWuShiWu3--;
                        table.Ex += ChongWuConfig.ShiWuDic[3];
                        continue;
                    }

                    if (PlayerData.S.ChongWuShiWu4 > 0)
                    {
                        PlayerData.S.ChongWuShiWu4--;
                        table.Ex += ChongWuConfig.ShiWuDic[4];
                        continue;
                    }

                    if (PlayerData.S.ChongWuShiWu5 > 0)
                    {
                        PlayerData.S.ChongWuShiWu5--;
                        table.Ex += ChongWuConfig.ShiWuDic[5];
                        continue;
                    }

                    if (PlayerData.S.ChongWuShiWu6 > 0)
                    {
                        PlayerData.S.ChongWuShiWu6--;
                        table.Ex += ChongWuConfig.ShiWuDic[6];
                        continue;
                    }
                }

                while (table.Ex >= ChongWuConfig.ChongWuExDic[table.Level])
                {
                    table.Ex -= ChongWuConfig.ChongWuExDic[table.Level];
                    table.Level++;
                }
            }
            SetWeiYangPanel();
            SetXiangQingPage(CurrentChongWuId);
            ObserverModuleManager.S.SendEvent("RefreshChongWuPage");

        });
        
        
        ChongZhiButton.onClick.AddListener(() =>
        {
            ShowChongZhiPanel();
        });
        
        WeiYangButton.onClick.AddListener(() =>
        {
            ShowWeiYangPanel();
        });
        
        XiangQingButton.onClick.AddListener(() =>
        {
            ShowXiangQingPanel();
        });
        
        ZhuFuButton.onClick.AddListener(() =>
        {
            var table = PlayerData.S.ChongWuDic[CurrentChongWuId];
            if (table.Level < 20 && table.XingJi >= 1)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"等级不足");
                return;
            }
            if (table.Level < 40 && table.XingJi >= 2)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"等级不足");
                return;
            }
            if (table.Level < 60 && table.XingJi >= 3)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"等级不足");
                return;
            }
            if (table.Level < 80 && table.XingJi >= 4)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"等级不足");
                return;
            }
            if (table.Level < 100 && table.XingJi >= 5)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"等级不足");
                return;
            }
            if (PlayerData.S.ChongWuJingHua < ChongWuConfig.XingJiDic[table.XingJi])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"宠物精华数量不足");
                return;
            }
            PlayerData.S.ChongWuJingHua-= ChongWuConfig.XingJiDic[table.XingJi];
            table.XingJi++;
            SetXiangQingPage(table.ChongWuId);
        });
        ChuZhanButton.onClick.AddListener(() =>
        {
            int index = (ChongWuController.S.CurrentChongWuPageNum - 1) * 6;
            
            PlayerData.S.ZhuChongWuId = CurrentChongWuId;
            ObserverModuleManager.S.SendEvent("ChongWuChuZhan");
            ChuZhanText.gameObject.SetActive(true);
        });
        ExitButton.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }

    public void SetName(ChongWuTable table)
    {
        Name1.gameObject.SetActive(false);
        Name2.gameObject.SetActive(false);
        Name3.gameObject.SetActive(false);
        Name4.gameObject.SetActive(false);
        Name5.gameObject.SetActive(false);
        Name6.gameObject.SetActive(false);
        switch (table.Quality)
        {
            case 1:
                Name1.gameObject.SetActive(true);
                Name1.text = table.Name;
                break;
            case 2:
                Name2.gameObject.SetActive(true);
                Name2.text = table.Name;
                break;
            case 3:
                Name3.gameObject.SetActive(true);
                Name3.text = table.Name;
                break;
            case 4:
                Name4.gameObject.SetActive(true);
                Name4.text = table.Name;
                break;
            case 5:
                Name5.gameObject.SetActive(true);
                Name5.text = table.Name;
                break;
            case 6:
                Name6.gameObject.SetActive(true);
                Name6.text = table.Name;
                break;
        }
    }
    

    public void RefreshChongWuInfo(int chongWuId)
    {
        HideSke();
        CurrentChongWuId=chongWuId;
        ChongWuTable table=PlayerData.S.ChongWuDic[chongWuId];
        ShowSke(table);    
        NameLevelCount.text = table.Level.ToString();

        switch (table.YuanSuType)
        {
            case YuanSuType.Ice:
                YuanSuIcon.sprite = ResourcesConfig.IceIcon;
                break;
            case YuanSuType.Huo:
                YuanSuIcon.sprite = ResourcesConfig.HuoIcon;
                break;
            case YuanSuType.Dian:
                YuanSuIcon.sprite = ResourcesConfig.DianIcon;
                break;
            case YuanSuType.HeiAn:
                YuanSuIcon.sprite = ResourcesConfig.HeiAnIcon;
                break;
        }
        SetName(table);    
        ChuZhanText.gameObject.SetActive(CurrentChongWuId==PlayerData.S.ZhuChongWuId);
        Quality1.gameObject.SetActive(false);
        Quality2.gameObject.SetActive(false);
        Quality3.gameObject.SetActive(false);
        Quality4.gameObject.SetActive(false);
        Quality5.gameObject.SetActive(false);
        Quality6.gameObject.SetActive(false);

        switch (table.Quality)
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

        ZiZhiCount.text = table.ZiZhi.ToString();
        LeftXueMaiCount.text = table.XueMai.ToString();
    }

    public void SetXiangQingPage(int chongWuId)
    {
        
        CurrentChongWuId=chongWuId;
        ChongWuTable table=PlayerData.S.ChongWuDic[chongWuId];
        RefreshChongWuInfo(chongWuId);
        
        ChuZhanButton.interactable=!(chongWuId==PlayerData.S.ZhuChongWuId);

        
        LevelCount.text = table.Level.ToString();
        CurrentExp.text = table.Ex.ToString();
        MaxExp.text = ChongWuConfig.ChongWuExDic[table.Level].ToString();
        ExSlider.maxValue = ChongWuConfig.ChongWuExDic[table.Level];
        ExSlider.value = table.Ex;
        XX1.gameObject.SetActive(table.XingJi>=1);
        XX2.gameObject.SetActive(table.XingJi>=2);
        XX3.gameObject.SetActive(table.XingJi>=3);
        XX4.gameObject.SetActive(table.XingJi>=4);
        XX5.gameObject.SetActive(table.XingJi>=5);
        XX6.gameObject.SetActive(table.XingJi>=6);
        CurrentJingHua.text = PlayerData.S.ChongWuJingHua.ToString();
        MaxJingHua.text=ChongWuConfig.XingJiDic[table.XingJi].ToString();
        JingHuaSlider.maxValue = ChongWuConfig.XingJiDic[table.XingJi];
        JingHuaSlider.value=PlayerData.S.ChongWuJingHua;
        XueMaiCount.text = table.XueMai.ToString();
        YuanSuDamage.text=Mathf.RoundToInt(table.XueMai*table.Level).ToString();
        ZiZhi.text = table.ZiZhi.ToString();
        Attack.text = Mathf.RoundToInt(table.ZiZhi / 100.0f * ChongWuConfig.ChongWuAttributeDic[table.Level].Attack).ToString();
        Defense.text = Mathf.RoundToInt(table.ZiZhi / 100.0f * ChongWuConfig.ChongWuAttributeDic[table.Level].Defence).ToString();
        Hp.text = Mathf.RoundToInt(table.ZiZhi / 100.0f * ChongWuConfig.ChongWuAttributeDic[table.Level].Hp).ToString();
        Crit.text = Mathf.RoundToInt(table.ZiZhi / 100.0f * ChongWuConfig.ChongWuAttributeDic[table.Level].Crit).ToString();

        foreach (Transform item in SkillContent.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in table.SkillList)
        {
            var skillItem=Instantiate(Resources.Load<GameObject>("Prefabs/Window/ChongWuSkillItem"),SkillContent.transform);
            switch (item.Level)
            {
                case 1:
                    skillItem.transform.Find("Edge").GetComponent<Animator>().Play("WhiteEdge");
                    skillItem.transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                    break;
                case 2:
                    skillItem.transform.Find("Edge").GetComponent<Animator>().Play("GreenEdge");
                    skillItem.transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
                    break;
                case 3:
                    skillItem.transform.Find("Edge").GetComponent<Animator>().Play("BlueEdge");
                    skillItem.transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                    break;
                case 4:
                    skillItem.transform.Find("Edge").GetComponent<Animator>().Play("PurpleEdge");
                    skillItem.transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
                    break;
                case 5:
                    skillItem.transform.Find("Edge").GetComponent<Animator>().Play("OrangeEdge");
                    skillItem.transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                    break;
                case 6:
                    skillItem.transform.Find("Edge").GetComponent<Animator>().Play("RedEdge");
                    skillItem.transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
                    break;
            }

            skillItem.transform.Find("Image").GetComponent<Image>().sprite =
                ResourcesConfig.GetChongWuSkillSprite(item.SKillType);
        }

    }
}
