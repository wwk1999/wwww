using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChongWuPeiYangWindow : MonoBehaviour
{
    private int CurrentChongWuId;
    public TextMeshProUGUI NameLevelCount;
    public TextMeshProUGUI Name;
    public Image QualityIcon;
    public Image YuanSuIcon;
    public Button WeiYangButton;
    public Button ChongZhiButton;
    public Button XiangQingButton;
    public TextMeshProUGUI ChuZhanText;
    public Button ExitButton;

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

    private void Start()
    {
        ExitButton.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }

    public void SetXiangQingPage(int chongWuId)
    {
        HideSke();
        CurrentChongWuId=chongWuId;
        ChongWuTable table=PlayerData.S.ChongWuDic[chongWuId];
        ShowSke(table);
        NameLevelCount.text = table.Level.ToString();
        switch (table.Quality)
        {
            case 1:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality1;
                break;
            case 2:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality1;
                break;
            case 3:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality1;
                break;
            case 4:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality1;
                break;
            case 5:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality1;
                break;
            case 6:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality1;
                break;
        }

        switch (table.ChongWuYuanSuType)
        {
            case ChongWuYuanSuType.Ice:
                YuanSuIcon.sprite = ResourcesConfig.IceIcon;
                break;
            case ChongWuYuanSuType.Huo:
                YuanSuIcon.sprite = ResourcesConfig.HuoIcon;
                break;
            case ChongWuYuanSuType.Dian:
                YuanSuIcon.sprite = ResourcesConfig.DianIcon;
                break;
            case ChongWuYuanSuType.HeiAn:
                YuanSuIcon.sprite = ResourcesConfig.HeiAnIcon;
                break;
        }
        Name.text = table.Name;
        ChuZhanText.gameObject.SetActive(CurrentChongWuId==PlayerData.S.ZhuChongWuId);
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
                ResourcesConfig.GetSkillSprite(item.SKillType);
        }

    }
}
