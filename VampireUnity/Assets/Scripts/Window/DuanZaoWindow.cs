using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Config;
using Equip;
using TMPro;
using Tool;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum PanelType
{
    None,
    XiLian,
    HeCheng,
    JinJie,
    XiangQian
}

public enum HeChengType
{
    None,
    GreenWeaponFragment,
    BlueWeaponFragment,
    PurpleWeaponFragment,
    OrangeWeaponFragment,
    RedWeaponFragment,
    GreenJingCui,
    BlueJingCui,
    PurpleJingCui,
    OrangeJingCui,
    RedJingCui,
    ShenHuaZhiXin
}
public class DuanZaoWindow : MonoBehaviour
{
    public GameObject xiLianPanel;
    public GameObject heChongPanel;
    public GameObject jinJiePanel;
    
    public Button heChongButton;
    public Button jinJieButton;
    public Button xiLianButton;
    public Button exitButton;

    
    //合成界面

    public Button weaponFragmentButton;
    public Button weaponFragmentItem1Button;
    public Button weaponFragmentItem2Button;
    public Button weaponFragmentItem3Button;
    public Button weaponFragmentItem4Button;
    public Button weaponFragmentItem5Button;

    public Button jingCuiButton;
    public Button jingCuiItem1Button;
    public Button jingCuiItem2Button;
    public Button jingCuiItem3Button;
    public Button jingCuiItem4Button;
    public Button jingCuiItem5Button;

    public Image item1ColorBg;
    public Image item1Image;
    
    public Image item2ColorBg;
    public Image item2Image;
    
    public Image item3ColorBg;
    public Image item3Image;
    
    public Image item4ColorBg;
    public Image item4Image;
    
    public Image itemColorBg;
    public Image itemImage;


    public Toggle toggle;
    public GameObject gou;
    public Button heCheng;
    private bool _toggleState = false;
    private HeChengType _heChengType = HeChengType.None;

    public Button otherButton;
    public Button shenHuaZhiXinButton;
    
    
    
    
    //洗练界面
    public GameObject equipContent;
    public GameObject equipInfo;
    public Button xiLian;
    public Image equipBg;
    public Image image;
    public Text level;
    public Text baseAttribute1;
    public Text baseAttribute2;
    public TextMeshProUGUI baseAttribute1Value;
    public TextMeshProUGUI baseAttribute2Value;
    public GameObject fuJiaContent;
    public TextMeshProUGUI pageNumText;
    public Button right;
    public Button left;
    private int PageNum = 1;
    public TextMeshProUGUI redEquipName;
    public TextMeshProUGUI orangeEquipName;
    public TextMeshProUGUI purpleEquipName;
    public TextMeshProUGUI blueEquipName;
    public TextMeshProUGUI greenEquipName;
 
    private int clickEquipid=0;


    public TextMeshProUGUI TopHeChengText;
    public TextMeshProUGUI TopXiLianText;
    public TextMeshProUGUI TopJinJieText;
    public TextMeshProUGUI WeaponFragmentText;
    public TextMeshProUGUI WeaponFragment2Text;
    public TextMeshProUGUI WeaponFragment3Text;
    public TextMeshProUGUI WeaponFragment4Text;
    public TextMeshProUGUI WeaponFragment5Text;
    public TextMeshProUGUI WeaponFragment6Text;
    public TextMeshProUGUI JingCuiText;
    public TextMeshProUGUI JingCui2Text;
    public TextMeshProUGUI JingCui3Text;
    public TextMeshProUGUI JingCui4Text;
    public TextMeshProUGUI JingCui5Text;
    public TextMeshProUGUI JingCui6Text;
    public TextMeshProUGUI ShenHuaZhiXin;
    public TextMeshProUGUI ShenHuaZhiXinText;
    public TextMeshProUGUI HeChengButtonText;
    public TextMeshProUGUI YiJianHeChen;

    
    public TextMeshProUGUI BaseAttribute;
    public TextMeshProUGUI FuJiaAttribute;
    public TextMeshProUGUI XiLianButton;

    //进阶界面
    
    public TextMeshProUGUI LinHun;
    public TextMeshProUGUI JingCui;
    public TextMeshProUGUI ShenHuaZhiXinCaiLiao;
    public TextMeshProUGUI JinJieButton;
    public TextMeshProUGUI jinJiePageNumText;
    public Button jinJieRight;
    public Button jinJieLeft;
    public Image jinJieEquipImage;
    public Image jinJieEquipBg;
    public Button jinJie;
    public GameObject jinJieEquipContent;
    private int jinJiePageNum = 1;
    private int jinJieEquipId = 0;

    
    //镶嵌界面
    public GameObject XiangQianPanel;
    public GameObject XiangQianEquipPanel;
    public Button TopXiangQianButton;
    public GameObject XiangQianEquipContent;
    public Button XiangQianRight;
    public Button XiangQianLeft;
    private int XiangQianPageNum = 1;
    private int XiangQianEquipId = 0;
    public Image XiangQianEquipImage;
    public Image XiangQianEquipBg;
    public TextMeshProUGUI XiangQianPageNumText;
    public Button XiangQian;
    public Button XiangQianQuXiaButton;


    public TextMeshProUGUI XiangQianGreenName;
    public TextMeshProUGUI XiangQianBlueName;
    public TextMeshProUGUI XiangQianPurpleName;
    public TextMeshProUGUI XiangQianOrangeName;
    public TextMeshProUGUI XiangQianRedName;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI LevelCount;
    public TextMeshProUGUI Quality;
    public TextMeshProUGUI XiangQianGreenQuality;
    public TextMeshProUGUI XiangQianBlueQuality;
    public TextMeshProUGUI XiangQianPurpleQuality;
    public TextMeshProUGUI XiangQianOrangeQuality;
    public TextMeshProUGUI XiangQianRedQuality;

    public Button XiangQianEquipButton;
    public Button XiangQianBaoShiButton;
    public GameObject XiangQianKongContent;
    private XiangQianBaoShiGrid ClickBaoShi=null;
    private EquipTable XiangQianEquipTable=null;
    private bool isEquipPage=true;

    public void SwitchLanguage()
    {
        TopHeChengText.text = LanguageConfig.LanguageItems[PlayerData.S.langType].DuanZaoWindowLanguage.HeCheng;
        TopXiLianText.text = LanguageConfig.LanguageItems[PlayerData.S.langType].DuanZaoWindowLanguage.XiLian;
        TopJinJieText.text = LanguageConfig.LanguageItems[PlayerData.S.langType].DuanZaoWindowLanguage.JinJie;

        WeaponFragmentText.text = LanguageConfig.LanguageItems[PlayerData.S.langType].DuanZaoWindowLanguage.WeaponFragment;
        WeaponFragment2Text.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.GreenWeaponFragment;
        WeaponFragment3Text.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.BlueWeaponFragment;
        WeaponFragment4Text.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.PurpleWeaponFragment;
        WeaponFragment5Text.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.OrangeWeaponFragment;
        WeaponFragment6Text.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.RedWeaponFragment;
        
        JingCuiText.text = LanguageConfig.LanguageItems[PlayerData.S.langType].DuanZaoWindowLanguage.JingCui;
        JingCui2Text.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.GreenJingCui;
        JingCui3Text.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.BlueJingCui;
        JingCui4Text.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.PurpleJingCui;
        JingCui5Text.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.OrangeJingCui;
        JingCui6Text.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.RedJingCui;

        
        ShenHuaZhiXin.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.ShenHuaZhiXin;
        ShenHuaZhiXinText.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.ShenHuaZhiXin;
        HeChengButtonText.text = LanguageConfig.LanguageItems[PlayerData.S.langType].DuanZaoWindowLanguage.HeCheng;
        YiJianHeChen.text = LanguageConfig.LanguageItems[PlayerData.S.langType].DuanZaoWindowLanguage.YiJianHeCheng;

        BaseAttribute.text = LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.BaseAttribute;
        FuJiaAttribute.text = LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.FuJiaAttribute;
        XiLianButton.text = LanguageConfig.LanguageItems[PlayerData.S.langType].DuanZaoWindowLanguage.XiLian;

        LinHun.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.LinHun+" X 10000";
        JingCui.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.OrangeJingCui+" X 10";
        ShenHuaZhiXinCaiLiao.text = LanguageConfig.LanguageItems[PlayerData.S.langType].PropLanguage.ShenHuaZhiXin+" X 1";
        JinJieButton.text = LanguageConfig.LanguageItems[PlayerData.S.langType].DuanZaoWindowLanguage.JinJie;
    }
    
    private void OnEnable()
    {
        SwitchLanguage();
    }

    public void ShowXiangQianBag()
    {
         foreach (Transform child in XiangQianEquipContent.transform)
        {
            Destroy(child.gameObject);
        }

        if (isEquipPage)
        {
            int startIndex = (XiangQianPageNum - 1) * 32;
            int endIndex = Mathf.Min(XiangQianPageNum * 32, BagController.S.EquipIdList.Count);

            List<EquipTable> list = BagController.S.EquipIdList.Values.ToList();

            for (int i = startIndex; i < endIndex; i++)
            {
                GameObject xilianGrid = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XiangQianGrid"),
                    XiangQianEquipContent.transform);
                xilianGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                    ResourcesConfig.GetEquipSprite(list[i]);
                xilianGrid.GetComponent<XiangQianGrid>().equipTable = list[i];
                switch (list[i].Quality)
                {
                    case 1:
                        xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.WhiteBg;
                        break;
                    case 2:
                        xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.GreenBg;
                        break;
                    case 3:
                        xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.BlueBg;
                        break;
                    case 4:
                        xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.PurpleBg;
                        break;
                    case 5:
                        xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.OrangeBg;
                        break;
                    case 6:
                        xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.RedBg;
                        break;
                }
            }
        }
        else
        {
            int startIndex = (XiangQianPageNum - 1) * 35;
            int endIndex = Mathf.Min(XiangQianPageNum * 35, BagController.S.PropList.Count);
            List<PropTable> list = BagController.S.PropList.Values.ToList();
             for (int i = startIndex; i < endIndex; i++)
            {
                if (list[i].PropType == PropConfig.PropType.WeaponFragment ||
                    list[i].PropType == PropConfig.PropType.JingCui ||
                    list[i].PropType == PropConfig.PropType.ShenHuaCaiLiao ||
                    list[i].PropType == PropConfig.PropType.ChiBang || list[i].PropType == PropConfig.PropType.LingHun|| list[i].PropType == PropConfig.PropType.None)
                {
                    continue;
                }
                GameObject xilianGrid = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XiangQianBaoShiGrid"),
                    XiangQianEquipContent.transform);
                xilianGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                    ResourcesConfig.GetPropSprite(list[i]);
                xilianGrid.transform.Find("parent/Count").GetComponent<TextMeshProUGUI>().text = list[i].Count.ToString();
                xilianGrid.GetComponent<XiangQianBaoShiGrid>().propTable = list[i];
                switch (list[i].Quality)
                {
                    case 1:
                        xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.WhiteBg;
                        break;
                    case 2:
                        xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.GreenBg;
                        break;
                    case 3:
                        xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.BlueBg;
                        break;
                    case 4:
                        xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.PurpleBg;
                        break;
                    case 5:
                        xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.OrangeBg;
                        break;
                    case 6:
                        xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.RedBg;
                        break;
                }
            }
        }
    }

    public void ShowJinJieBag()
    {
        jinJieEquipImage.gameObject.SetActive(false);
        jinJieEquipBg.gameObject.SetActive(false);
        foreach (Transform child in jinJieEquipContent.transform)
        {
            Destroy(child.gameObject);
        }
        int startIndex = (jinJiePageNum - 1) * 35;
        int endIndex = Mathf.Min(jinJiePageNum * 35, BagController.S.EquipIdList.Count);
        List<EquipTable> list = BagController.S.EquipIdList.Values.ToList();
        for (int i = startIndex; i < endIndex; i++)
        {
            GameObject jinjieGrid = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/JinJieGrid"),jinJieEquipContent.transform);
            jinjieGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite = ResourcesConfig.GetEquipSprite(list[i]);
            jinjieGrid.GetComponent<JinJIeGrid>().equipTable = list[i];
            switch (list[i].Quality)
            {
                case 1:
                    jinjieGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.WhiteBg;
                    break;
                case 2:
                    jinjieGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.GreenBg;
                    break;
                case 3:
                    jinjieGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.BlueBg;
                    break;
                case 4:
                    jinjieGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.PurpleBg;
                    break;
                case 5:
                    jinjieGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.OrangeBg;
                    break;
                case 6:
                    jinjieGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.RedBg;
                    break;
            }
        }
    }
    
    public void ShowXiLianBag()
    {
        equipInfo.gameObject.SetActive(false);
        foreach (Transform child in equipContent.transform)
        {
            Destroy(child.gameObject);
        }
        int startIndex = (PageNum - 1) * 40;
        int endIndex = Mathf.Min(PageNum * 40, BagController.S.EquipIdList.Count);

        List<EquipTable> list = BagController.S.EquipIdList.Values.ToList();

        for (int i = startIndex; i < endIndex; i++)
        {
            GameObject xilianGrid = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XiLianGrid"),equipContent.transform);
            xilianGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite = ResourcesConfig.GetEquipSprite(list[i]);
            xilianGrid.GetComponent<XiLianGrid>().equipTable = list[i];
            switch (list[i].Quality)
            {
                case 1:
                    xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.WhiteBg;
                    break;
                case 2:
                    xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.GreenBg;
                    break;
                case 3:
                    xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.BlueBg;
                    break;
                case 4:
                    xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.PurpleBg;
                    break;
                case 5:
                    xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.OrangeBg;
                    break;
                case 6:
                    xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.RedBg;
                    break;
            }
        }
    }

    public void ShowWeaponFragmentItem1()
    {
        ShowItems();
        _heChengType = HeChengType.GreenWeaponFragment;
        item1ColorBg.sprite = ResourcesConfig.WhiteBg;
        item1Image.sprite = ResourcesConfig.WhiteWeaponFragment;
        
        item2ColorBg.sprite = ResourcesConfig.WhiteBg;
        item2Image.sprite = ResourcesConfig.WhiteWeaponFragment;
        
        item3ColorBg.sprite = ResourcesConfig.WhiteBg;
        item3Image.sprite = ResourcesConfig.WhiteWeaponFragment;
        
        item4ColorBg.sprite = ResourcesConfig.WhiteBg;
        item4Image.sprite = ResourcesConfig.WhiteWeaponFragment;
        
        itemColorBg.sprite = ResourcesConfig.GreenBg;
        itemImage.sprite = ResourcesConfig.GreenWeaponFragment;
    }
    
    public void ShowWeaponFragmentItem2()
    {
        ShowItems();
        _heChengType = HeChengType.BlueWeaponFragment;

        item1ColorBg.sprite = ResourcesConfig.GreenBg;
        item1Image.sprite = ResourcesConfig.GreenWeaponFragment;
        
        item2ColorBg.sprite = ResourcesConfig.GreenBg;
        item2Image.sprite = ResourcesConfig.GreenWeaponFragment;
        
        item3ColorBg.sprite = ResourcesConfig.GreenBg;
        item3Image.sprite = ResourcesConfig.GreenWeaponFragment;
        
        item4ColorBg.sprite = ResourcesConfig.GreenBg;
        item4Image.sprite = ResourcesConfig.GreenWeaponFragment;
        
        itemColorBg.sprite = ResourcesConfig.BlueBg;
        itemImage.sprite = ResourcesConfig.BlueWeaponFragment;
    }
    
    public void ShowWeaponFragmentItem3()
    {
        ShowItems();
        _heChengType = HeChengType.PurpleWeaponFragment;

        item1ColorBg.sprite = ResourcesConfig.BlueBg;
        item1Image.sprite = ResourcesConfig.BlueWeaponFragment;
        
        item2ColorBg.sprite = ResourcesConfig.BlueBg;
        item2Image.sprite = ResourcesConfig.BlueWeaponFragment;
        
        item3ColorBg.sprite = ResourcesConfig.BlueBg;
        item3Image.sprite = ResourcesConfig.BlueWeaponFragment;
        
        item4ColorBg.sprite = ResourcesConfig.BlueBg;
        item4Image.sprite = ResourcesConfig.BlueWeaponFragment;
        
        itemColorBg.sprite = ResourcesConfig.PurpleBg;
        itemImage.sprite = ResourcesConfig.PurpleWeaponFragment;
    }
    
    public void ShowWeaponFragmentItem4()
    {
        ShowItems();
        _heChengType = HeChengType.OrangeWeaponFragment;

        item1ColorBg.sprite = ResourcesConfig.PurpleBg;
        item1Image.sprite = ResourcesConfig.PurpleWeaponFragment;
        
        item2ColorBg.sprite = ResourcesConfig.PurpleBg;
        item2Image.sprite = ResourcesConfig.PurpleWeaponFragment;
        
        item3ColorBg.sprite = ResourcesConfig.PurpleBg;
        item3Image.sprite = ResourcesConfig.PurpleWeaponFragment;
        
        item4ColorBg.sprite = ResourcesConfig.PurpleBg;
        item4Image.sprite = ResourcesConfig.PurpleWeaponFragment;
        
        itemColorBg.sprite = ResourcesConfig.OrangeBg;
        itemImage.sprite = ResourcesConfig.OrangeWeaponFragment;
    }
    
    public void ShowWeaponFragmentItem5()
    {
        ShowItems();
        _heChengType = HeChengType.RedWeaponFragment;

        item1ColorBg.sprite = ResourcesConfig.OrangeBg;
        item1Image.sprite = ResourcesConfig.OrangeWeaponFragment;
        
        item2ColorBg.sprite = ResourcesConfig.OrangeBg;
        item2Image.sprite = ResourcesConfig.OrangeWeaponFragment;
        
        item3ColorBg.sprite = ResourcesConfig.OrangeBg;
        item3Image.sprite = ResourcesConfig.OrangeWeaponFragment;
        
        item4ColorBg.sprite = ResourcesConfig.OrangeBg;
        item4Image.sprite = ResourcesConfig.OrangeWeaponFragment;
        
        itemColorBg.sprite = ResourcesConfig.RedBg;
        itemImage.sprite = ResourcesConfig.RedWeaponFragment;
    }
    
    public void ShowJingCUiItem1()
    {
        ShowItems();
        _heChengType = HeChengType.GreenJingCui;

        item1ColorBg.sprite = ResourcesConfig.WhiteBg;
        item1Image.sprite = ResourcesConfig.WhiteJingCui;
        
        item2ColorBg.sprite = ResourcesConfig.WhiteBg;
        item2Image.sprite = ResourcesConfig.WhiteJingCui;
        
        item3ColorBg.sprite = ResourcesConfig.WhiteBg;
        item3Image.sprite = ResourcesConfig.WhiteJingCui;
        
        item4ColorBg.sprite = ResourcesConfig.WhiteBg;
        item4Image.sprite = ResourcesConfig.WhiteJingCui;
        
        itemColorBg.sprite = ResourcesConfig.GreenBg;
        itemImage.sprite = ResourcesConfig.GreenJingCui;
    }
    
    public void ShowJingCUiItem2()
    {
        ShowItems();
        _heChengType = HeChengType.BlueJingCui;

        item1ColorBg.sprite = ResourcesConfig.GreenBg;
        item1Image.sprite = ResourcesConfig.GreenJingCui;
        
        item2ColorBg.sprite = ResourcesConfig.GreenBg;
        item2Image.sprite = ResourcesConfig.GreenJingCui;
        
        item3ColorBg.sprite = ResourcesConfig.GreenBg;
        item3Image.sprite = ResourcesConfig.GreenJingCui;
        
        item4ColorBg.sprite = ResourcesConfig.GreenBg;
        item4Image.sprite = ResourcesConfig.GreenJingCui;
        
        itemColorBg.sprite = ResourcesConfig.BlueBg;
        itemImage.sprite = ResourcesConfig.BlueJingCui;
    }
    
    public void ShowJingCUiItem3()
    {
        ShowItems();
        _heChengType = HeChengType.PurpleJingCui;

        item1ColorBg.sprite = ResourcesConfig.BlueBg;
        item1Image.sprite = ResourcesConfig.BlueJingCui;
        
        item2ColorBg.sprite = ResourcesConfig.BlueBg;
        item2Image.sprite = ResourcesConfig.BlueJingCui;
        
        item3ColorBg.sprite = ResourcesConfig.BlueBg;
        item3Image.sprite = ResourcesConfig.BlueJingCui;
        
        item4ColorBg.sprite = ResourcesConfig.BlueBg;
        item4Image.sprite = ResourcesConfig.BlueJingCui;
        
        itemColorBg.sprite = ResourcesConfig.PurpleBg;
        itemImage.sprite = ResourcesConfig.PurpleJingCui;
    }
    
    public void ShowJingCUiItem4()
    {
        ShowItems();
        _heChengType = HeChengType.OrangeJingCui;

        item1ColorBg.sprite = ResourcesConfig.PurpleBg;
        item1Image.sprite = ResourcesConfig.PurpleJingCui;
        
        item2ColorBg.sprite = ResourcesConfig.PurpleBg;
        item2Image.sprite = ResourcesConfig.PurpleJingCui;
        
        item3ColorBg.sprite = ResourcesConfig.PurpleBg;
        item3Image.sprite = ResourcesConfig.PurpleJingCui;
        
        item4ColorBg.sprite = ResourcesConfig.PurpleBg;
        item4Image.sprite = ResourcesConfig.PurpleJingCui;
        
        itemColorBg.sprite = ResourcesConfig.OrangeBg;
        itemImage.sprite = ResourcesConfig.OrangeJingCui;
    }
    
    public void ShowJingCUiItem5()
    {
        ShowItems();
        _heChengType = HeChengType.RedJingCui;

        item1ColorBg.sprite = ResourcesConfig.OrangeBg;
        item1Image.sprite = ResourcesConfig.OrangeJingCui;
        
        item2ColorBg.sprite = ResourcesConfig.OrangeBg;
        item2Image.sprite = ResourcesConfig.OrangeJingCui;
        
        item3ColorBg.sprite = ResourcesConfig.OrangeBg;
        item3Image.sprite = ResourcesConfig.OrangeJingCui;
        
        item4ColorBg.sprite = ResourcesConfig.OrangeBg;
        item4Image.sprite = ResourcesConfig.OrangeJingCui;
        
        itemColorBg.sprite = ResourcesConfig.RedBg;
        itemImage.sprite = ResourcesConfig.RedJingCui;
    }
    
    public void ShowShenHuaZhiXinItem()
    {
        ShowItems();
        _heChengType = HeChengType.ShenHuaZhiXin;

        item1ColorBg.sprite = ResourcesConfig.OrangeBg;
        item1Image.sprite = ResourcesConfig.FuMoZhiGu;
        
        item2ColorBg.sprite = ResourcesConfig.OrangeBg;
        item2Image.sprite = ResourcesConfig.GoldBlood;
        
        item3ColorBg.sprite = ResourcesConfig.OrangeBg;
        item3Image.sprite = ResourcesConfig.JuDaYaChi;
        
        item4ColorBg.sprite = ResourcesConfig.OrangeBg;
        item4Image.sprite = ResourcesConfig.ZuiEYanZhu;
        
        itemColorBg.sprite = ResourcesConfig.RedBg;
        itemImage.sprite = ResourcesConfig.ShenHuaZhiXin;
    }
    
    public void ShowItems()
    {
        item1ColorBg.gameObject.SetActive(true);
        item1Image.gameObject.SetActive(true);
        
        item2ColorBg.gameObject.SetActive(true);
        item2Image.gameObject.SetActive(true);
        
        item3ColorBg.gameObject.SetActive(true);
        item3Image.gameObject.SetActive(true);
        
        item4ColorBg.gameObject.SetActive(true);
        item4Image.gameObject.SetActive(true);
        
        itemColorBg.gameObject.SetActive(true);
        itemImage.gameObject.SetActive(true);
    }

    public void HeCheng()
    {
        switch (_heChengType)
        {
            case HeChengType.GreenWeaponFragment:
                if (!BagController.S.PropList.ContainsKey(101) || BagController.S.PropList[101].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState)
                {
                    int count = BagController.S.PropList[101].Count;

                    BagController.S.PropList[101].Count %=  4;
                    if (BagController.S.PropList.ContainsKey(102))
                    {
                        BagController.S.PropList[102].Count += count / 4;
                    }
                    else
                    {
                        BagController.S.PropList.Add(102,new PropTable(PropConfig.PropType.WeaponFragment,count/4,"",2,"GreenWeaponFragment"));
                    }
                }
                else
                {
                    BagController.S.PropList[101].Count -=  4;
                    if (BagController.S.PropList.ContainsKey(102))
                    {
                        BagController.S.PropList[102].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(102,new PropTable(PropConfig.PropType.WeaponFragment,1,"",2,"GreenWeaponFragment"));
                    }
                }
                break;
            
            case HeChengType.BlueWeaponFragment:
                if (!BagController.S.PropList.ContainsKey(102) || BagController.S.PropList[102].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState)
                {
                    int count = BagController.S.PropList[102].Count;

                    BagController.S.PropList[102].Count %=  4;
                    if (BagController.S.PropList.ContainsKey(103))
                    {
                        BagController.S.PropList[103].Count += count / 4;
                    }
                    else
                    {
                        BagController.S.PropList.Add(103,new PropTable(PropConfig.PropType.WeaponFragment,count/4,"",3,"BlueWeaponFragment"));
                    }                }
                else
                {
                    BagController.S.PropList[102].Count -=  4;
                    if (BagController.S.PropList.ContainsKey(103))
                    {
                        BagController.S.PropList[103].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(103,new PropTable(PropConfig.PropType.WeaponFragment,1,"",3,"BlueWeaponFragment"));
                    }                       }
                break;
            
            case HeChengType.PurpleWeaponFragment:
                if (!BagController.S.PropList.ContainsKey(103) || BagController.S.PropList[103].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState == true)
                {
                    int count = BagController.S.PropList[103].Count;

                    BagController.S.PropList[103].Count %=  4;
                    if (BagController.S.PropList.ContainsKey(104))
                    {
                        BagController.S.PropList[104].Count += count / 4;
                    }
                    else
                    {
                        BagController.S.PropList.Add(104,new PropTable(PropConfig.PropType.WeaponFragment,count/4,"",4,"PurpleWeaponFragment"));
                    }
                }
                else
                {
                    BagController.S.PropList[103].Count -=  4;
                    if (BagController.S.PropList.ContainsKey(104))
                    {
                        BagController.S.PropList[104].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(104,new PropTable(PropConfig.PropType.WeaponFragment,1,"",4,"PurpleWeaponFragment"));
                    }                       
                }
                break;
            
            case HeChengType.OrangeWeaponFragment:
                if (!BagController.S.PropList.ContainsKey(104) || BagController.S.PropList[104].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState == true)
                {
                    int count = BagController.S.PropList[104].Count;

                    BagController.S.PropList[104].Count %=  4;
                    if (BagController.S.PropList.ContainsKey(105))
                    {
                        BagController.S.PropList[105].Count += count / 4;
                    }
                    else
                    {
                        BagController.S.PropList.Add(105,new PropTable(PropConfig.PropType.WeaponFragment,count/4,"",5,"OrangeWeaponFragment"));
                    }                       
                }
                else
                {
                    BagController.S.PropList[104].Count -=  4;
                    if (BagController.S.PropList.ContainsKey(105))
                    {
                        BagController.S.PropList[105].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(105,new PropTable(PropConfig.PropType.WeaponFragment,1,"",5,"OrangeWeaponFragment"));
                    }                          }
                break;
            
            case HeChengType.RedWeaponFragment:
                if (!BagController.S.PropList.ContainsKey(105) || BagController.S.PropList[105].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState)
                {
                    int count = BagController.S.PropList[105].Count;

                    BagController.S.PropList[105].Count %=  4;
                    if (BagController.S.PropList.ContainsKey(106))
                    {
                        BagController.S.PropList[106].Count += count / 4;
                    }
                    else
                    {
                        BagController.S.PropList.Add(106,new PropTable(PropConfig.PropType.WeaponFragment,count/4,"",6,"RedWeaponFragment"));
                    }                          
                }
                else
                {
                    BagController.S.PropList[105].Count -=  4;
                    if (BagController.S.PropList.ContainsKey(106))
                    {
                        BagController.S.PropList[106].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(106,new PropTable(PropConfig.PropType.WeaponFragment,1,"",6,"RedWeaponFragment"));
                    }                   
                }
                break;
            
            
            
            
            
            
            
            
            case HeChengType.GreenJingCui:
                if (!BagController.S.PropList.ContainsKey(201) || BagController.S.PropList[201].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState)
                {
                    int count = BagController.S.PropList[201].Count;

                    BagController.S.PropList[201].Count %=  4;
                    if (BagController.S.PropList.ContainsKey(202))
                    {
                        BagController.S.PropList[202].Count += count / 4;
                    }
                    else
                    {
                        BagController.S.PropList.Add(202,new PropTable(PropConfig.PropType.JingCui,count/4,"",2,"GreenJingCui"));
                    }
                }
                else
                {
                    BagController.S.PropList[201].Count -=  4;
                    if (BagController.S.PropList.ContainsKey(202))
                    {
                        BagController.S.PropList[202].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(202,new PropTable(PropConfig.PropType.JingCui,1,"",2,"GreenJingCui"));
                    }
                }
                break;
            
            case HeChengType.BlueJingCui:
                if (!BagController.S.PropList.ContainsKey(202) || BagController.S.PropList[202].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState)
                {
                    int count = BagController.S.PropList[202].Count;

                    BagController.S.PropList[202].Count %=  4;
                    if (BagController.S.PropList.ContainsKey(203))
                    {
                        BagController.S.PropList[203].Count += count / 4;
                    }
                    else
                    {
                        BagController.S.PropList.Add(203,new PropTable(PropConfig.PropType.JingCui,count/4,"",3,"BlueJingCui"));
                    }                }
                else
                {
                    BagController.S.PropList[202].Count -=  4;
                    if (BagController.S.PropList.ContainsKey(203))
                    {
                        BagController.S.PropList[203].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(203,new PropTable(PropConfig.PropType.JingCui,1,"",3,"BlueJingCui"));
                    }                       }
                break;
            
            case HeChengType.PurpleJingCui:
                if (!BagController.S.PropList.ContainsKey(203) || BagController.S.PropList[203].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState == true)
                {
                    int count = BagController.S.PropList[203].Count;

                    BagController.S.PropList[203].Count %=  4;
                    if (BagController.S.PropList.ContainsKey(204))
                    {
                        BagController.S.PropList[204].Count += count / 4;
                    }
                    else
                    {
                        BagController.S.PropList.Add(204,new PropTable(PropConfig.PropType.JingCui,count/4,"",4,"PurpleJingCui"));
                    }
                }
                else
                {
                    BagController.S.PropList[203].Count -=  4;
                    if (BagController.S.PropList.ContainsKey(204))
                    {
                        BagController.S.PropList[204].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(204,new PropTable(PropConfig.PropType.JingCui,1,"",4,"PurpleJingCui"));
                    }                       }
                break;
            
            case HeChengType.OrangeJingCui:
                if (!BagController.S.PropList.ContainsKey(204) || BagController.S.PropList[204].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState == true)
                {
                    int count = BagController.S.PropList[204].Count;

                    BagController.S.PropList[204].Count %=  4;
                    if (BagController.S.PropList.ContainsKey(205))
                    {
                        BagController.S.PropList[205].Count += count / 4;
                    }
                    else
                    {
                        BagController.S.PropList.Add(205,new PropTable(PropConfig.PropType.JingCui,count/4,"",5,"OrangeJingCui"));
                    }                       
                }
                else
                {
                    BagController.S.PropList[204].Count -=  4;
                    if (BagController.S.PropList.ContainsKey(205))
                    {
                        BagController.S.PropList[205].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(205,new PropTable(PropConfig.PropType.JingCui,1,"",5,"OrangeJingCui"));
                    }                          }
                break;
            
            case HeChengType.RedJingCui:
                if (!BagController.S.PropList.ContainsKey(205) || BagController.S.PropList[205].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState)
                {
                    int count = BagController.S.PropList[205].Count;

                    BagController.S.PropList[205].Count %=  4;
                    if (BagController.S.PropList.ContainsKey(206))
                    {
                        BagController.S.PropList[206].Count += count / 4;
                    }
                    else
                    {
                        BagController.S.PropList.Add(206,new PropTable(PropConfig.PropType.JingCui,count/4,"",6,"RedJingCui"));
                    }                          
                }
                else
                {
                    BagController.S.PropList[205].Count -=  4;
                    if (BagController.S.PropList.ContainsKey(206))
                    {
                        BagController.S.PropList[206].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(206,new PropTable(PropConfig.PropType.JingCui,1,"",6,"RedJingCui"));
                    }                   
                }
                break;
            
            
            
            
            
            
            
            
            
            case HeChengType.ShenHuaZhiXin:
                if (!BagController.S.PropList.ContainsKey(301) || BagController.S.PropList[301].Count < 1)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }
                if (!BagController.S.PropList.ContainsKey(302) || BagController.S.PropList[302].Count < 1)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }
                if (!BagController.S.PropList.ContainsKey(303) || BagController.S.PropList[303].Count < 1)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }
                if (!BagController.S.PropList.ContainsKey(304) || BagController.S.PropList[304].Count < 1)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }
                
                if (_toggleState)
                {
                    int count1 = BagController.S.PropList[301].Count;
                    int count2 = BagController.S.PropList[302].Count;
                    int count3 = BagController.S.PropList[303].Count;
                    int count4 = BagController.S.PropList[304].Count;

                    int minCOunt=math.min(count1, count2);
                    minCOunt=math.min(minCOunt, count3);
                    minCOunt=math.min(minCOunt, count4);
                    BagController.S.PropList[301].Count -=  minCOunt;
                    BagController.S.PropList[302].Count -=  minCOunt;
                    BagController.S.PropList[303].Count -=  minCOunt;
                    BagController.S.PropList[304].Count -=  minCOunt;
                    if (BagController.S.PropList.ContainsKey(305))
                    {
                        BagController.S.PropList[305].Count +=  minCOunt;
                    }
                    else
                    {
                        BagController.S.PropList.Add(305,new PropTable(PropConfig.PropType.ShenHuaCaiLiao,minCOunt,"",6));
                    }
                    

                }
                else
                {
                    BagController.S.PropList[301].Count -=  1;
                    BagController.S.PropList[302].Count -=  1;
                    BagController.S.PropList[303].Count -=  1;
                    BagController.S.PropList[304].Count -=  1;
                    if (BagController.S.PropList.ContainsKey(305))
                    {
                        BagController.S.PropList[305].Count +=  1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(305,new PropTable(PropConfig.PropType.ShenHuaCaiLiao,1,"",6));
                    }                
                }
                break;
        }
        
        StoreController.S.SaveStoreData();
    }

    public void ResetItems()
    {
        item1ColorBg.gameObject.SetActive(false);
        item1Image.gameObject.SetActive(false);
        
        item2ColorBg.gameObject.SetActive(false);
        item2Image.gameObject.SetActive(false);
        
        item3ColorBg.gameObject.SetActive(false);
        item3Image.gameObject.SetActive(false);
        
        item4ColorBg.gameObject.SetActive(false);
        item4Image.gameObject.SetActive(false);
        
        itemColorBg.gameObject.SetActive(false);
        itemImage.gameObject.SetActive(false);
    }
    public void ShowPanel(PanelType panelType)
    {
        switch (panelType)
        {
            case PanelType.HeCheng:
                xiLianPanel.SetActive(false);
                heChongPanel.SetActive(true);
                jinJiePanel.SetActive(false);
                XiangQianPanel.SetActive(false);
                ResetItems();
                _toggleState = false;
                gou.gameObject.SetActive(_toggleState);
                break;
            case PanelType.XiLian:
                xiLianPanel.SetActive(true);
                heChongPanel.SetActive(false);
                jinJiePanel.SetActive(false);
                XiangQianPanel.SetActive(false);
                ShowXiLianBag();
                clickEquipid = 0;
                break;
            case PanelType.JinJie:
                xiLianPanel.SetActive(false);
                heChongPanel.SetActive(false);
                jinJiePanel.SetActive(true);
                XiangQianPanel.SetActive(false);
                ShowJinJieBag();
                jinJiePageNum = 1;
                break;
            case PanelType.XiangQian:
                xiLianPanel.SetActive(false);
                heChongPanel.SetActive(false);
                jinJiePanel.SetActive(false);
                XiangQianPanel.SetActive(true);
                isEquipPage = true;
                XiangQianPageNum = 1;
                XiangQianEquipTable = null;
                ClickBaoShi = null;
                XiangQianEquipPanel.gameObject.SetActive(false);
                ShowXiangQianBag();
                break;
        }
    }

    public void JinJieEquip(object[] obj)
    {
        EquipTable equip=obj[0] as EquipTable;
        if (equip == null)
        {
            return;
        }

        if (equip.Quality != 5)
        {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"传说装备才能进阶");
            return;
        }

        jinJieEquipId = equip.equipid;
        jinJieEquipImage.gameObject.SetActive(true);
        jinJieEquipBg.gameObject.SetActive(true);
        jinJieEquipImage.sprite = ResourcesConfig.GetEquipSprite(equip);
        jinJieEquipBg.sprite = ResourcesConfig.OrangeBg;
    }

    public void JinJie()
    {
        if (GlobalPlayerAttribute.BloodEnergy < 10000 || !BagController.S.PropList.ContainsKey(206) || BagController.S
                .PropList
                    [206].Count < 10 || !BagController.S.PropList.ContainsKey(305) ||
            BagController.S.PropList[305].Count < 1)
        {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
            return;
        }

        GlobalPlayerAttribute.BloodEnergy -= 10000;
        BagController.S.PropList[206].Count -= 10;
        BagController.S.PropList[305].Count -= 1;

        BagController.S.EquipIdList[jinJieEquipId].Quality = 6;
        jinJieEquipBg.sprite = ResourcesConfig.RedBg;
        ShowJinJieBag();
    }

    public void XiLianEquip(object[] obj)
    {
        EquipTable equip=obj[0] as EquipTable;
        if (equip == null)
        {
            return;
        }

        if (equip.Quality < 2)
        {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"优秀以上品质才能洗练");
            return;
        }
        equipInfo.gameObject.SetActive(true);
        clickEquipid = equip.equipid;
        switch (equip.Quality)
        {
            case 2:
                greenEquipName.gameObject.SetActive(true);
                blueEquipName.gameObject.SetActive(false);
                purpleEquipName.gameObject.SetActive(false);
                orangeEquipName.gameObject.SetActive(false);
                redEquipName.gameObject.SetActive(false);
                if (equip.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                {
                    greenEquipName.text = EquipName.EquipNameDic[equip.EquipName];
                }
                else
                {
                    greenEquipName.text = EntryConfig.OrangeIdNameDic[equip.orangeid];
                }
              
                equipBg.sprite = ResourcesConfig.GreenBg;
                break;
            
            case 3:
                greenEquipName.gameObject.SetActive(false);
                blueEquipName.gameObject.SetActive(true);
                purpleEquipName.gameObject.SetActive(false);
                orangeEquipName.gameObject.SetActive(false);
                redEquipName.gameObject.SetActive(false);
                if (equip.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                {
                    blueEquipName.text = EquipName.EquipNameDic[equip.EquipName];
                }
                else
                {
                    blueEquipName.text = EntryConfig.OrangeIdNameDic[equip.orangeid];
                }
            
                equipBg.sprite = ResourcesConfig.BlueBg;
                break;
            
            case 4:
                greenEquipName.gameObject.SetActive(false);
                blueEquipName.gameObject.SetActive(false);
                purpleEquipName.gameObject.SetActive(true);
                orangeEquipName.gameObject.SetActive(false);
                redEquipName.gameObject.SetActive(false);
                if (equip.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                {
                    purpleEquipName.text = EquipName.EquipNameDic[equip.EquipName];
                }
                else
                {
                    purpleEquipName.text = EntryConfig.OrangeIdNameDic[equip.orangeid];
                }
             
                equipBg.sprite = ResourcesConfig.PurpleBg;
                break;
            
            case 5:
                greenEquipName.gameObject.SetActive(false);
                blueEquipName.gameObject.SetActive(false);
                purpleEquipName.gameObject.SetActive(false);
                orangeEquipName.gameObject.SetActive(true);
                redEquipName.gameObject.SetActive(false);
                if (equip.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                {
                    orangeEquipName.text = EquipName.EquipNameDic[equip.EquipName];
                }
                else
                {
                    orangeEquipName.text = EntryConfig.OrangeIdNameDic[equip.orangeid];
                }
             
                equipBg.sprite = ResourcesConfig.OrangeBg;
                break;
            
            case 6:
                greenEquipName.gameObject.SetActive(false);
                blueEquipName.gameObject.SetActive(false);
                purpleEquipName.gameObject.SetActive(false);
                orangeEquipName.gameObject.SetActive(false);
                redEquipName.gameObject.SetActive(true);
                if (equip.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                {
                    redEquipName.text = EquipName.EquipNameDic[equip.EquipName];
                }
                else
                {
                    redEquipName.text =EntryConfig.OrangeIdNameDic[equip.orangeid];
                }
             
                equipBg.sprite = ResourcesConfig.RedBg;
                break;
        }

        image.sprite = ResourcesConfig.GetEquipSprite(equip);
        baseAttribute1.text = (equip.EquipType == PlayerEquipConfig.EquipType.Cloth || equip.EquipType == PlayerEquipConfig.EquipType.Helmet || equip.EquipType == PlayerEquipConfig.EquipType.Shoe)
            ? LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp+" :"
            : LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack+" :";
        baseAttribute2.text = (equip.EquipType == PlayerEquipConfig.EquipType.Cloth || equip.EquipType == PlayerEquipConfig.EquipType.Helmet || equip.EquipType == PlayerEquipConfig.EquipType.Shoe)
            ? LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense+" :"
            : LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit+" :";

        baseAttribute1Value.text = (equip.EquipType == PlayerEquipConfig.EquipType.Cloth || equip.EquipType == PlayerEquipConfig.EquipType.Helmet || equip.EquipType == PlayerEquipConfig.EquipType.Shoe)
            ? equip.HP.ToString()
            : equip.Damage.ToString();
        
        baseAttribute2Value.text = (equip.EquipType == PlayerEquipConfig.EquipType.Cloth || equip.EquipType == PlayerEquipConfig.EquipType.Helmet || equip.EquipType == PlayerEquipConfig.EquipType.Shoe)
            ? equip.Defense.ToString()
            : equip.CRIT.ToString();
        foreach (Transform child in fuJiaContent.transform)
        {
            Destroy(child.gameObject);
        }
        
        foreach (var item in equip.defenseEntryInfos)
        {
            var fuJiaAttributeItem =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/XiLianFuJiaAttribute"),fuJiaContent.transform);
            fuJiaAttributeItem.transform.Find("BaseAttributeName").GetComponent<Text>().text =
                EntryConfig.DefenseEntryNameDic[item.DefenseEntry];
            fuJiaAttributeItem.transform.Find("BaseAttributeCount").GetComponent<TextMeshProUGUI>().text =
                item.Value + "%";
        }
        
        foreach (var item in equip.damageEntryInfos)
        {
            var fuJiaAttributeItem =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/XiLianFuJiaAttribute"),fuJiaContent.transform);
            fuJiaAttributeItem.transform.Find("BaseAttributeName").GetComponent<Text>().text =
                EntryConfig.DamageEntryNameDic[item.DamageEntry];
            fuJiaAttributeItem.transform.Find("BaseAttributeCount").GetComponent<TextMeshProUGUI>().text =
                item.Value + "%";
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("XiLian",XiLianEquip);
        ObserverModuleManager.S.UnRegisterEvent("JinJie",JinJieEquip);
        ObserverModuleManager.S.UnRegisterEvent("XiangQian",XiangQianEquipObj);

    }

    public void XiangQianEquipObj(object[] obj)
    {
        EquipTable equip=obj[0] as EquipTable;
        XiangQianEquipTable = equip;
        XiangQianEquip(equip);
    }

    public void XiangQianEquip(EquipTable equip)
    {
        foreach (Transform item in XiangQianKongContent.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var baoshi in equip.BaoShiDic)
        {
            var baoshikong=Instantiate(Resources.Load("Prefabs/Equip/XiangQianEquipKong"),XiangQianKongContent.transform)as  GameObject;
            EquipKong equipKong=baoshikong.GetComponent<EquipKong>();
            equipKong.SetKong(baoshi.Value);
        }
        
        XiangQianEquipPanel.gameObject.SetActive(true);
        XiangQianGreenName.gameObject.SetActive(false);
        XiangQianBlueName.gameObject.SetActive(false);
        XiangQianPurpleName.gameObject.SetActive(false);
        XiangQianOrangeName.gameObject.SetActive(false);
        XiangQianRedName.gameObject.SetActive(false);
        
        XiangQianBlueQuality.gameObject.SetActive(false);
        XiangQianGreenQuality.gameObject.SetActive(false);
        XiangQianPurpleQuality.gameObject.SetActive(false);
        XiangQianOrangeQuality.gameObject.SetActive(false);
        XiangQianRedQuality.gameObject.SetActive(false);

        Quality.text=LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Quality+"：";
        level.text="等级：";
        LevelCount.text = equip.EquipLevel.ToString();
        XiangQianEquipImage.sprite = ResourcesConfig.GetEquipSprite(equip);
        switch (equip.Quality)
        {
            case 2:
                XiangQianGreenName.gameObject.SetActive(true);
                XiangQianGreenQuality.gameObject.SetActive(true);
                if (equip.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                {
                    XiangQianGreenName.text = EquipName.EquipNameDic[equip.EquipName];
                }
                else
                {
                    XiangQianGreenName.text = EntryConfig.OrangeIdNameDic[equip.orangeid];
                }
                XiangQianGreenQuality.text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.GreenQuality;
                XiangQianEquipBg.sprite = ResourcesConfig.GreenBg;
                break;
            
            case 3:
                XiangQianBlueName.gameObject.SetActive(true);
                XiangQianBlueQuality.gameObject.SetActive(true);
                if (equip.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                {
                    XiangQianBlueName.text = EquipName.EquipNameDic[equip.EquipName];
                }
                else
                {
                    XiangQianBlueName.text = EntryConfig.OrangeIdNameDic[equip.orangeid];
                }                XiangQianBlueQuality.text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.BlueQuality;
                XiangQianEquipBg.sprite = ResourcesConfig.BlueBg;
                break;
            case 4:
                XiangQianPurpleName.gameObject.SetActive(true);
                XiangQianPurpleQuality.gameObject.SetActive(true);
                if (equip.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                {
                    XiangQianPurpleName.text = EquipName.EquipNameDic[equip.EquipName];
                }
                else
                {
                    XiangQianPurpleName.text = EntryConfig.OrangeIdNameDic[equip.orangeid];
                }                XiangQianPurpleQuality.text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.PurpleQuality;
                XiangQianEquipBg.sprite = ResourcesConfig.PurpleBg;
                break;
            
            case 5:
                XiangQianOrangeName.gameObject.SetActive(true);
                XiangQianOrangeQuality.gameObject.SetActive(true);
                
                if (equip.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                {
                    XiangQianOrangeName.text = EquipName.EquipNameDic[equip.EquipName];
                }
                else
                {
                    XiangQianOrangeName.text =EntryConfig.OrangeIdNameDic[equip.orangeid];
                }                XiangQianOrangeQuality.text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.OrangeQuality;
                XiangQianEquipBg.sprite = ResourcesConfig.OrangeBg;
                break;
            
            case 6:
                XiangQianRedName.gameObject.SetActive(true);
                XiangQianRedQuality.gameObject.SetActive(true);
                if (equip.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                {
                    XiangQianRedName.text = EquipName.EquipNameDic[equip.EquipName];
                }
                else
                {
                    XiangQianRedName.text =EntryConfig.OrangeIdNameDic[equip.orangeid];
                }                XiangQianRedQuality.text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.RedQuality;
                XiangQianEquipBg.sprite = ResourcesConfig.RedBg;
                break;
        }
    }

    public String GetBaoShiName(BaoShiInfo baoShiInfo)
    {
        switch (baoShiInfo.BaoShiType)
        {
            case BaoShiType.HH:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return "HH1";
                    case 2:
                        return "HH2";
                    case 3:
                        return "HH3";
                    case 4:
                        return "HH4";
                    case 5:
                        return "HH5";
                    case 6:
                        return "HH6";
                }
                break;
            
            case BaoShiType.HA:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return "HA1";
                    case 2:
                        return "HA2";
                    case 3:
                        return "HA3";
                    case 4:
                        return "HA4";
                    case 5:
                        return "HA5";
                    case 6:
                        return "HA6";
                }
                break;
            
            case BaoShiType.HC:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return "HC1";
                    case 2:
                        return "HC2";
                    case 3:
                        return "HC3";
                    case 4:
                        return "HC4";
                    case 5:
                        return "HC5";
                    case 6:
                        return "HC6";
                }
                break;
            
            case BaoShiType.HD:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return "HD1";
                    case 2:
                        return "HD2";
                    case 3:
                        return "HD3";
                    case 4:
                        return "HD4";
                    case 5:
                        return "HD5";
                    case 6:
                        return "HD6";
                }
                break;
            
            case BaoShiType.AA:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return "AA1";
                    case 2:
                        return "AA2";
                    case 3:
                        return "AA3";
                    case 4:
                        return "AA4";
                    case 5:
                        return "AA5";
                    case 6:
                        return "AA6";
                }
                break;
            
            case BaoShiType.AC:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return "AC1";
                    case 2:
                        return "AC2";
                    case 3:
                        return "AC3";
                    case 4:
                        return "AC4";
                    case 5:
                        return "AC5";
                    case 6:
                        return "AC6";
                }
                break;
            
            case BaoShiType.AD:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return "AD1";
                    case 2:
                        return "AD2";
                    case 3:
                        return "AD3";
                    case 4:
                        return "AD4";
                    case 5:
                        return "AD5";
                    case 6:
                        return "AD6";
                }
                break;
            
            case BaoShiType.CC:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return "CC1";
                    case 2:
                        return "CC2";
                    case 3:
                        return "CC3";
                    case 4:
                        return "CC4";
                    case 5:
                        return "CC5";
                    case 6:
                        return "CC6";
                }
                break;
            
            case BaoShiType.CD:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return "CD1";
                    case 2:
                        return "CD2";
                    case 3:
                        return "CD3";
                    case 4:
                        return "CD4";
                    case 5:
                        return "CD5";
                    case 6:
                        return "CD6";
                }
                break;
            
            case BaoShiType.DD:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return "DD1";
                    case 2:
                        return "DD2";
                    case 3:
                        return "DD3";
                    case 4:
                        return "DD4";
                    case 5:
                        return "DD5";
                    case 6:
                        return "DD6";
                }
                break;
        }

        return "";
    }

    public int GetBaoShiCode(BaoShiInfo baoShiInfo)
    {
        switch (baoShiInfo.BaoShiType)
        {
            case BaoShiType.HH:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return 601;
                    case 2:
                        return 602;
                    case 3:
                        return 603;
                    case 4:
                        return 604;
                    case 5:
                        return 605;
                    case 6:
                        return 606;
                }
                break;
            
            case BaoShiType.HA:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return 701;
                    case 2:
                        return 702;
                    case 3:
                        return 703;
                    case 4:
                        return 704;
                    case 5:
                        return 705;
                    case 6:
                        return 706;
                }
                break;
            
            case BaoShiType.HC:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return 801;
                    case 2:
                        return 802;
                    case 3:
                        return 803;
                    case 4:
                        return 804;
                    case 5:
                        return 805;
                    case 6:
                        return 806;
                }
                break;
            
            case BaoShiType.HD:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return 901;
                    case 2:
                        return 902;
                    case 3:
                        return 903;
                    case 4:
                        return 904;
                    case 5:
                        return 905;
                    case 6:
                        return 906;
                }
                break;
            
            case BaoShiType.AD:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return 1001;
                    case 2:
                        return 1002;
                    case 3:
                        return 1003;
                    case 4:
                        return 1004;
                    case 5:
                        return 1005;
                    case 6:
                        return 1006;
                }
                break;
            
            case BaoShiType.AC:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return 1101;
                    case 2:
                        return 1102;
                    case 3:
                        return 1103;
                    case 4:
                        return 1104;
                    case 5:
                        return 1105;
                    case 6:
                        return 1106;
                }
                break;
            
            case BaoShiType.AA:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return 1201;
                    case 2:
                        return 1202;
                    case 3:
                        return 1203;
                    case 4:
                        return 1204;
                    case 5:
                        return 1205;
                    case 6:
                        return 1206;
                }
                break;
            
            case BaoShiType.CC:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return 1301;
                    case 2:
                        return 1302;
                    case 3:
                        return 1303;
                    case 4:
                        return 1304;
                    case 5:
                        return 1305;
                    case 6:
                        return 1306;
                }
                break;
            
            case BaoShiType.CD:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return 1401;
                    case 2:
                        return 1402;
                    case 3:
                        return 1403;
                    case 4:
                        return 1404;
                    case 5:
                        return 1405;
                    case 6:
                        return 1406;
                }
                break;
            
            case BaoShiType.DD:
                switch (baoShiInfo.Quality)
                {
                    case 1:
                        return 1501;
                    case 2:
                        return 1502;
                    case 3:
                        return 1503;
                    case 4:
                        return 1504;
                    case 5:
                        return 1505;
                    case 6:
                        return 1506;
                }
                break;
        }

        return 0;
    }

    public void RefreshBaoshi(XiangQianBaoShiGrid baoshi,int count)
    {
        if (count <= 0)
        {
            baoshi.canvasGroup.alpha = 0;
        }
        else
        {
            baoshi.gameObject.transform.Find("parent/Count").GetComponent<TextMeshProUGUI>().text = count.ToString();
        }
    }
    public void XiangQianButtonClick()
    {
        if (ClickBaoShi == null || XiangQianEquipTable == null)
        {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"请选择宝石或装备");
            return;
        }
        BaoShiType baoShiType;
        switch (ClickBaoShi.propTable.PropType)
        {
            case PropConfig.PropType.HH:
                baoShiType = BaoShiType.HH;
                break;
            case PropConfig.PropType.HA:
                baoShiType = BaoShiType.HA;
                break;
            case PropConfig.PropType.HC:
                baoShiType = BaoShiType.HC;
                break;
            case PropConfig.PropType.HD:
                baoShiType = BaoShiType.HD;
                break;
            case PropConfig.PropType.AA:
                baoShiType = BaoShiType.AA;
                break;
            case PropConfig.PropType.AC:
                baoShiType = BaoShiType.AC;
                break;
            case PropConfig.PropType.AD:
                baoShiType = BaoShiType.AD;
                break;
            case PropConfig.PropType.CC:
                baoShiType = BaoShiType.CC;
                break;
            case PropConfig.PropType.CD:
                baoShiType = BaoShiType.CD;
                break;
            case PropConfig.PropType.DD:
                baoShiType = BaoShiType.DD;
                break;
            default:
                baoShiType = BaoShiType.None;
                break;
        }
        BaoShiInfo baoshiinfo=new BaoShiInfo(){BaoShiType = baoShiType,Quality = ClickBaoShi.propTable.Quality};
        int code = GetBaoShiCode(baoshiinfo);
        if (BagController.S.PropList[code].Count <= 0)
        {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"宝石数量不足");
            return;
        }
        foreach (var item in XiangQianEquipTable.BaoShiDic)
        {
            if (item.Value.BaoShiType == BaoShiType.None)
            {
                item.Value.BaoShiType = baoShiType;
                item.Value.Quality=ClickBaoShi.propTable.Quality;
                BagController.S.PropList[code].Count--;
                RefreshBaoshi(ClickBaoShi, BagController.S.PropList[code].Count);
                XiangQianEquip(XiangQianEquipTable);
                BagController.S.CheckBaoShiTitle();
                return;
            }
        }
        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"装备孔不足");
    }

    public GameObject GetBaoShiGrid(BaoShiInfo baoshi)
    {
        if (isEquipPage)
        {
            return null;
        }
        foreach (Transform item in XiangQianEquipContent.transform)
        {
            var proptable = item.gameObject.GetComponent<XiangQianBaoShiGrid>().propTable;
            if ((int)(proptable.PropType - 5) == (int)baoshi.BaoShiType && proptable.Quality == baoshi.Quality)
            {
                return item.gameObject;
            }
        }

        return null;
    }

    public void QuXia()
    {
        foreach (var item in XiangQianEquipTable.BaoShiDic)
        {
            int code = GetBaoShiCode(item.Value);
            item.Value.BaoShiType=BaoShiType.None;
            if (BagController.S.PropList.ContainsKey(code))
            {
                BagController.S.PropList[code].Count++;
            }
            else
            {
                BagController.S.PropList.Add(code,new PropTable(){Count = 1,Desc = "",EquipName = GetBaoShiName(item.Value),PropType = (PropConfig.PropType)(item.Value.BaoShiType+5),Quality = item.Value.Quality});
            }
        }
        XiangQianEquip(XiangQianEquipTable);
        ShowXiangQianBag();
    }

    public void XiangQianBaoShi(object[] obj)
    {
        XiangQianBaoShiGrid baoshi = obj[0] as XiangQianBaoShiGrid;
        ClickBaoShi = baoshi;
        if (XiangQianEquipContent == null)
        {
            Debug.LogError("XiangQianEquipContent is null");
            return;
        }
        foreach (Transform item in XiangQianEquipContent.transform)
        {
            XiangQianBaoShiGrid itembaoshi = item.gameObject.GetComponent<XiangQianBaoShiGrid>();
            if (baoshi.propTable.PropType == itembaoshi.propTable.PropType &&
                baoshi.propTable.Quality == itembaoshi.propTable.Quality)
            {
                itembaoshi.Gou.SetActive(true);
            }
            else
            {
                itembaoshi.Gou.SetActive(false);
            }
        }
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("XiLian",XiLianEquip);
        ObserverModuleManager.S.RegisterEvent("JinJie",JinJieEquip);
        ObserverModuleManager.S.RegisterEvent("XiangQian",XiangQianEquipObj);
        ObserverModuleManager.S.RegisterEvent("XiangQianBaoShi",XiangQianBaoShi);

        XiangQianEquipButton.onClick.AddListener(() =>
        {
            isEquipPage = true;
            XiangQianPageNum = 1;
            XiangQianPageNumText.text = XiangQianPageNum.ToString();
            ShowXiangQianBag();
        });
        
        XiangQianBaoShiButton.onClick.AddListener(() =>
        {
            isEquipPage = false;
            XiangQianPageNum = 1;
            XiangQianPageNumText.text = XiangQianPageNum.ToString();
            ShowXiangQianBag();
        });
        
        XiangQianRight.onClick.AddListener(() =>
        {
            if (XiangQianPageNum >= 6)
            {
                return;
            }
            XiangQianPageNum++;
            XiangQianPageNumText.text = XiangQianPageNum.ToString();
            ShowXiangQianBag();
        });
        
        XiangQianLeft.onClick.AddListener(() =>
        {
            if (XiangQianPageNum <= 1)
            {
                return;
            }
            XiangQianPageNum--;
            XiangQianPageNumText.text = XiangQianPageNum.ToString();
            ShowXiangQianBag();
        });
        
        //镶嵌
        XiangQian.onClick.AddListener(() =>
        {
            XiangQianButtonClick();
        });
        XiangQianQuXiaButton.onClick.AddListener(() =>
        {
            QuXia();
        });


        ShowPanel(PanelType.HeCheng);
        heCheng.onClick.AddListener(()=>
        {
            HeCheng();
        });
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        xiLianButton.onClick.AddListener(() =>
        {
            ShowPanel(PanelType.XiLian);
        });
        heChongButton.onClick.AddListener(() =>
        {
            ShowPanel(PanelType.HeCheng);
        });
        jinJieButton.onClick.AddListener(() =>
        {
            ShowPanel(PanelType.JinJie);
        });
        TopXiangQianButton.onClick.AddListener(() =>
        {
            ShowPanel(PanelType.XiangQian);
        });
        
        weaponFragmentButton.onClick.AddListener(() =>
        {
            weaponFragmentItem1Button.transform.parent.gameObject.SetActive(!weaponFragmentItem1Button.transform.parent.gameObject.activeSelf);
            weaponFragmentItem2Button.transform.parent.gameObject.SetActive(!weaponFragmentItem2Button.transform.parent.gameObject.activeSelf);
            weaponFragmentItem3Button.transform.parent.gameObject.SetActive(!weaponFragmentItem3Button.transform.parent.gameObject.activeSelf);
            weaponFragmentItem4Button.transform.parent.gameObject.SetActive(!weaponFragmentItem4Button.transform.parent.gameObject.activeSelf);
            weaponFragmentItem5Button.transform.parent.gameObject.SetActive(!weaponFragmentItem5Button.transform.parent.gameObject.activeSelf);
        });
        
        jingCuiButton.onClick.AddListener(() =>
        {
            jingCuiItem1Button.transform.parent.gameObject.SetActive(!jingCuiItem1Button.transform.parent.gameObject.activeSelf);
            jingCuiItem2Button.transform.parent.gameObject.SetActive(!jingCuiItem2Button.transform.parent.gameObject.activeSelf);
            jingCuiItem3Button.transform.parent.gameObject.SetActive(!jingCuiItem3Button.transform.parent.gameObject.activeSelf);
            jingCuiItem4Button.transform.parent.gameObject.SetActive(!jingCuiItem4Button.transform.parent.gameObject.activeSelf);
            jingCuiItem5Button.transform.parent.gameObject.SetActive(!jingCuiItem5Button.transform.parent.gameObject.activeSelf);
            LayoutRebuilder.ForceRebuildLayoutImmediate(heChongPanel.GetComponent<RectTransform>());
        });
        
        weaponFragmentItem1Button.onClick.AddListener(()=>
        {
           ShowWeaponFragmentItem1();
        });
        
        weaponFragmentItem2Button.onClick.AddListener(()=>
        {
            ShowWeaponFragmentItem2();
        });
        
        weaponFragmentItem3Button.onClick.AddListener(()=>
        {
            ShowWeaponFragmentItem3();
        });
        
        weaponFragmentItem4Button.onClick.AddListener(()=>
        {
            ShowWeaponFragmentItem4();
        });
        
        weaponFragmentItem5Button.onClick.AddListener(()=>
        {
            ShowWeaponFragmentItem5();
        });
        
        jingCuiItem1Button.onClick.AddListener(() =>
        {
            ShowJingCUiItem1();
        });
        
        jingCuiItem2Button.onClick.AddListener(() =>
        {
            ShowJingCUiItem2();
        });
        
        jingCuiItem3Button.onClick.AddListener(() =>
        {
            ShowJingCUiItem3();
        });
        
        jingCuiItem4Button.onClick.AddListener(() =>
        {
            ShowJingCUiItem4();
        });
        
        jingCuiItem5Button.onClick.AddListener(() =>
        {
            ShowJingCUiItem5();
        });
        
        toggle.onValueChanged.AddListener(_=>SetGou());
        
        left.onClick.AddListener(() =>
        {
            if (PageNum < 2)
            {
                return;
            }

            PageNum--;
            pageNumText.text = PageNum.ToString();
            ShowXiLianBag();
        });
        
        right.onClick.AddListener(() =>
        {
            if (PageNum >= 5)
            {
                return;
            }

            PageNum++;
            pageNumText.text = PageNum.ToString();
            ShowXiLianBag();
        });
        otherButton.onClick.AddListener(() =>
        {
            shenHuaZhiXinButton.transform.parent.gameObject.SetActive(!shenHuaZhiXinButton.transform.parent.gameObject.activeSelf);
        });
        xiLian.onClick.AddListener(() =>
        {
            if (clickEquipid == 0)
            {
                return;
            }
            BagController.S.EquipIdList[clickEquipid].defenseEntryInfos.Clear();
            BagController.S.EquipIdList[clickEquipid].damageEntryInfos.Clear();
            if (BagController.S.EquipIdList[clickEquipid].EquipType == PlayerEquipConfig.EquipType.Cloak || BagController.S.EquipIdList[clickEquipid].EquipType == PlayerEquipConfig.EquipType.Ring ||
                BagController.S.EquipIdList[clickEquipid].EquipType == PlayerEquipConfig.EquipType.Necklace)
            {
                for (int i = 1; i < BagController.S.EquipIdList[clickEquipid].Quality; i++)
                {
                    var damageEntryInfo=new DamageEntryInfo();
                    int randomIndex = Random.Range(0, EntryConfig.DamageEntryList.Count);
                    damageEntryInfo.DamageEntry = EntryConfig.DamageEntryList[randomIndex];
                    float randomValue=Random.Range(EntryConfig.DamageEntryConfigs[damageEntryInfo.DamageEntry].minValue, EntryConfig.DamageEntryConfigs[damageEntryInfo.DamageEntry].maxValue);
                    float value = Mathf.Round(randomValue*100)/100;
                    damageEntryInfo.Value = value;
                    BagController.S.EquipIdList[clickEquipid].damageEntryInfos.Add(damageEntryInfo);
                }
            }
            else
            {
                for (int i = 1; i < BagController.S.EquipIdList[clickEquipid].Quality; i++)
                {
                    var DefenseEntryInfo=new DefenseEntryInfo();
                    int randomIndex = Random.Range(0, EntryConfig.DefenseEntryList.Count);
                    DefenseEntryInfo.DefenseEntry = EntryConfig.DefenseEntryList[randomIndex];
                    float randomValue=Random.Range(EntryConfig.DefenseEntryConfigs[DefenseEntryInfo.DefenseEntry].minValue, EntryConfig.DefenseEntryConfigs[DefenseEntryInfo.DefenseEntry].maxValue);
                    float value = Mathf.Round(randomValue*100)/100;
                    DefenseEntryInfo.Value = value;
                    BagController.S.EquipIdList[clickEquipid].defenseEntryInfos.Add(DefenseEntryInfo);
                }
            }

            object[] obj=new object[1];
            obj[0] = BagController.S.EquipIdList[clickEquipid];
            XiLianEquip(obj);
        });
        
        shenHuaZhiXinButton.onClick.AddListener(() =>
        {
            ShowShenHuaZhiXinItem();
        });
        
        jinJieLeft.onClick.AddListener(() =>
        {
            if (jinJiePageNum < 2)
            {
                return;
            }

            jinJiePageNum--;
            jinJiePageNumText.text = jinJiePageNum.ToString();
            ShowJinJieBag();
        });
        
        jinJieRight.onClick.AddListener(() =>
        {
            if (jinJiePageNum > 4)
            {
                return;
            }

            jinJiePageNum++;
            jinJiePageNumText.text = jinJiePageNum.ToString();
            ShowJinJieBag();
        });
        jinJie.onClick.AddListener(() =>
        {
            JinJie();
        });
    }

    public void SetGou()
    {
        _toggleState=!_toggleState;
        gou.gameObject.SetActive(_toggleState);
    }
    
}
