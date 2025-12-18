using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public Animator item1Edge;
    public Image item1Image;
    
    public Image item2ColorBg;
    public Animator item2Edge;
    public Image item2Image;
    
    public Image item3ColorBg;
    public Animator item3Edge;
    public Image item3Image;
    
    public Image item4ColorBg;
    public Animator item4Edge;
    public Image item4Image;
    
    public Image itemColorBg;
    public Animator itemEdge;
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
    public Animator edge;
    public Image image;
    public Text level;
    public Text baseAttribute1;
    public Text baseAttribute2;
    public TextMeshProUGUI baseAttribute1Value;
    public TextMeshProUGUI baseAttribute2Value;
    public GameObject fuJiaContent;
    public Text pageNumText;
    public Button right;
    public Button left;
    private int PageNum = 1;
    public TextMeshProUGUI redEquipName;
    public TextMeshProUGUI orangeEquipName;
    public TextMeshProUGUI purpleEquipName;
    public TextMeshProUGUI blueEquipName;
    public TextMeshProUGUI greenEquipName;
    public TextMeshProUGUI redQuality;
    public TextMeshProUGUI orangeQuality;
    public TextMeshProUGUI purpleQuality;
    public TextMeshProUGUI blueQuality;
    public TextMeshProUGUI greenQuality;
    private int clickEquipid=0;
    

    public void ShowXiLianBag()
    {
        equipInfo.gameObject.SetActive(false);
        foreach (Transform child in equipContent.transform)
        {
            Destroy(child.gameObject);
        }
        int startIndex = (PageNum - 1) * 35;
        int endIndex = Mathf.Min(PageNum * 35, BagController.S.EquipIdList.Count);

        List<EquipTable> list = BagController.S.EquipIdList.Values.ToList();

        for (int i = startIndex; i < endIndex; i++)
        {
            if (list[i].Quality < 2)
            {
                continue;
            }
            GameObject xilianGrid = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XiLianGrid"),equipContent.transform);
            xilianGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite = ResourcesConfig.GetEquipSprite(list[i]);
            xilianGrid.GetComponent<XiLianGrid>().equipTable = list[i];
            switch (list[i].Quality)
            {
                case 1:
                    xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.WhiteBg;
                    xilianGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("WhiteEdge");
                    break;
                case 2:
                    xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.GreenBg;
                    xilianGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("GreenEdge");
                    break;
                case 3:
                    xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.BlueBg;
                    xilianGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("BlueEdge");
                    break;
                case 4:
                    xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.PurpleBg;
                    xilianGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("PurpleEdge");
                    break;
                case 5:
                    xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.OrangeBg;
                    xilianGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("OrangeEdge");
                    break;
                case 6:
                    xilianGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.RedBg;
                    xilianGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("RedEdge");
                    break;
            }
        }
    }

    public void ShowWeaponFragmentItem1()
    {
        ShowItems();
        _heChengType = HeChengType.GreenWeaponFragment;
        item1ColorBg.sprite = ResourcesConfig.WhiteBg;
        item1Edge.Play("WhiteEdge");
        item1Image.sprite = ResourcesConfig.WhiteWeaponFragment;
        
        item2ColorBg.sprite = ResourcesConfig.WhiteBg;
        item2Edge.Play("WhiteEdge");
        item2Image.sprite = ResourcesConfig.WhiteWeaponFragment;
        
        item3ColorBg.sprite = ResourcesConfig.WhiteBg;
        item3Edge.Play("WhiteEdge");
        item3Image.sprite = ResourcesConfig.WhiteWeaponFragment;
        
        item4ColorBg.sprite = ResourcesConfig.WhiteBg;
        item4Edge.Play("WhiteEdge");
        item4Image.sprite = ResourcesConfig.WhiteWeaponFragment;
        
        itemColorBg.sprite = ResourcesConfig.GreenBg;
        itemEdge.Play("GreenEdge");
        itemImage.sprite = ResourcesConfig.GreenWeaponFragment;
    }
    
    public void ShowWeaponFragmentItem2()
    {
        ShowItems();
        _heChengType = HeChengType.BlueWeaponFragment;

        item1ColorBg.sprite = ResourcesConfig.GreenBg;
        item1Edge.Play("GreenEdge");
        item1Image.sprite = ResourcesConfig.GreenWeaponFragment;
        
        item2ColorBg.sprite = ResourcesConfig.GreenBg;
        item2Edge.Play("GreenEdge");
        item2Image.sprite = ResourcesConfig.GreenWeaponFragment;
        
        item3ColorBg.sprite = ResourcesConfig.GreenBg;
        item3Edge.Play("GreenEdge");
        item3Image.sprite = ResourcesConfig.GreenWeaponFragment;
        
        item4ColorBg.sprite = ResourcesConfig.GreenBg;
        item4Edge.Play("GreenEdge");
        item4Image.sprite = ResourcesConfig.GreenWeaponFragment;
        
        itemColorBg.sprite = ResourcesConfig.BlueBg;
        itemEdge.Play("BlueEdge");
        itemImage.sprite = ResourcesConfig.BlueWeaponFragment;
    }
    
    public void ShowWeaponFragmentItem3()
    {
        ShowItems();
        _heChengType = HeChengType.PurpleWeaponFragment;

        item1ColorBg.sprite = ResourcesConfig.BlueBg;
        item1Edge.Play("BlueEdge");
        item1Image.sprite = ResourcesConfig.BlueWeaponFragment;
        
        item2ColorBg.sprite = ResourcesConfig.BlueBg;
        item2Edge.Play("BlueEdge");
        item2Image.sprite = ResourcesConfig.BlueWeaponFragment;
        
        item3ColorBg.sprite = ResourcesConfig.BlueBg;
        item3Edge.Play("BlueEdge");
        item3Image.sprite = ResourcesConfig.BlueWeaponFragment;
        
        item4ColorBg.sprite = ResourcesConfig.BlueBg;
        item4Edge.Play("BlueEdge");
        item4Image.sprite = ResourcesConfig.BlueWeaponFragment;
        
        itemColorBg.sprite = ResourcesConfig.PurpleBg;
        itemEdge.Play("PurpleEdge");
        itemImage.sprite = ResourcesConfig.PurpleWeaponFragment;
    }
    
    public void ShowWeaponFragmentItem4()
    {
        ShowItems();
        _heChengType = HeChengType.OrangeWeaponFragment;

        item1ColorBg.sprite = ResourcesConfig.PurpleBg;
        item1Edge.Play("PurpleEdge");
        item1Image.sprite = ResourcesConfig.PurpleWeaponFragment;
        
        item2ColorBg.sprite = ResourcesConfig.PurpleBg;
        item2Edge.Play("PurpleEdge");
        item2Image.sprite = ResourcesConfig.PurpleWeaponFragment;
        
        item3ColorBg.sprite = ResourcesConfig.PurpleBg;
        item3Edge.Play("PurpleEdge");
        item3Image.sprite = ResourcesConfig.PurpleWeaponFragment;
        
        item4ColorBg.sprite = ResourcesConfig.PurpleBg;
        item4Edge.Play("PurpleEdge");
        item4Image.sprite = ResourcesConfig.PurpleWeaponFragment;
        
        itemColorBg.sprite = ResourcesConfig.OrangeBg;
        itemEdge.Play("OrangeEdge");
        itemImage.sprite = ResourcesConfig.OrangeWeaponFragment;
    }
    
    public void ShowWeaponFragmentItem5()
    {
        ShowItems();
        _heChengType = HeChengType.RedWeaponFragment;

        item1ColorBg.sprite = ResourcesConfig.OrangeBg;
        item1Edge.Play("OrangeEdge");
        item1Image.sprite = ResourcesConfig.OrangeWeaponFragment;
        
        item2ColorBg.sprite = ResourcesConfig.OrangeBg;
        item2Edge.Play("OrangeEdge");
        item2Image.sprite = ResourcesConfig.OrangeWeaponFragment;
        
        item3ColorBg.sprite = ResourcesConfig.OrangeBg;
        item3Edge.Play("OrangeEdge");
        item3Image.sprite = ResourcesConfig.OrangeWeaponFragment;
        
        item4ColorBg.sprite = ResourcesConfig.OrangeBg;
        item4Edge.Play("OrangeEdge");
        item4Image.sprite = ResourcesConfig.OrangeWeaponFragment;
        
        itemColorBg.sprite = ResourcesConfig.RedBg;
        itemEdge.Play("RedEdge");
        itemImage.sprite = ResourcesConfig.RedWeaponFragment;
    }
    
    public void ShowJingCUiItem1()
    {
        ShowItems();
        _heChengType = HeChengType.GreenJingCui;

        item1ColorBg.sprite = ResourcesConfig.WhiteBg;
        item1Edge.Play("WhiteEdge");
        item1Image.sprite = ResourcesConfig.WhiteJingCui;
        
        item2ColorBg.sprite = ResourcesConfig.WhiteBg;
        item2Edge.Play("WhiteEdge");
        item2Image.sprite = ResourcesConfig.WhiteJingCui;
        
        item3ColorBg.sprite = ResourcesConfig.WhiteBg;
        item3Edge.Play("WhiteEdge");
        item3Image.sprite = ResourcesConfig.WhiteJingCui;
        
        item4ColorBg.sprite = ResourcesConfig.WhiteBg;
        item4Edge.Play("WhiteEdge");
        item4Image.sprite = ResourcesConfig.WhiteJingCui;
        
        itemColorBg.sprite = ResourcesConfig.GreenBg;
        itemEdge.Play("GreenEdge");
        itemImage.sprite = ResourcesConfig.GreenJingCui;
    }
    
    public void ShowJingCUiItem2()
    {
        ShowItems();
        _heChengType = HeChengType.BlueJingCui;

        item1ColorBg.sprite = ResourcesConfig.GreenBg;
        item1Edge.Play("GreenEdge");
        item1Image.sprite = ResourcesConfig.GreenJingCui;
        
        item2ColorBg.sprite = ResourcesConfig.GreenBg;
        item2Edge.Play("GreenEdge");
        item2Image.sprite = ResourcesConfig.GreenJingCui;
        
        item3ColorBg.sprite = ResourcesConfig.GreenBg;
        item3Edge.Play("GreenEdge");
        item3Image.sprite = ResourcesConfig.GreenJingCui;
        
        item4ColorBg.sprite = ResourcesConfig.GreenBg;
        item4Edge.Play("GreenEdge");
        item4Image.sprite = ResourcesConfig.GreenJingCui;
        
        itemColorBg.sprite = ResourcesConfig.BlueBg;
        itemEdge.Play("BlueEdge");
        itemImage.sprite = ResourcesConfig.BlueJingCui;
    }
    
    public void ShowJingCUiItem3()
    {
        ShowItems();
        _heChengType = HeChengType.PurpleJingCui;

        item1ColorBg.sprite = ResourcesConfig.BlueBg;
        item1Edge.Play("BlueEdge");
        item1Image.sprite = ResourcesConfig.BlueJingCui;
        
        item2ColorBg.sprite = ResourcesConfig.BlueBg;
        item2Edge.Play("BlueEdge");
        item2Image.sprite = ResourcesConfig.BlueJingCui;
        
        item3ColorBg.sprite = ResourcesConfig.BlueBg;
        item3Edge.Play("BlueEdge");
        item3Image.sprite = ResourcesConfig.BlueJingCui;
        
        item4ColorBg.sprite = ResourcesConfig.BlueBg;
        item4Edge.Play("BlueEdge");
        item4Image.sprite = ResourcesConfig.BlueJingCui;
        
        itemColorBg.sprite = ResourcesConfig.PurpleBg;
        itemEdge.Play("PurpleEdge");
        itemImage.sprite = ResourcesConfig.PurpleJingCui;
    }
    
    public void ShowJingCUiItem4()
    {
        ShowItems();
        _heChengType = HeChengType.OrangeJingCui;

        item1ColorBg.sprite = ResourcesConfig.PurpleBg;
        item1Edge.Play("PurpleEdge");
        item1Image.sprite = ResourcesConfig.PurpleJingCui;
        
        item2ColorBg.sprite = ResourcesConfig.PurpleBg;
        item2Edge.Play("PurpleEdge");
        item2Image.sprite = ResourcesConfig.PurpleJingCui;
        
        item3ColorBg.sprite = ResourcesConfig.PurpleBg;
        item3Edge.Play("PurpleEdge");
        item3Image.sprite = ResourcesConfig.PurpleJingCui;
        
        item4ColorBg.sprite = ResourcesConfig.PurpleBg;
        item4Edge.Play("PurpleEdge");
        item4Image.sprite = ResourcesConfig.PurpleJingCui;
        
        itemColorBg.sprite = ResourcesConfig.OrangeBg;
        itemEdge.Play("OrangeEdge");
        itemImage.sprite = ResourcesConfig.OrangeJingCui;
    }
    
    public void ShowJingCUiItem5()
    {
        ShowItems();
        _heChengType = HeChengType.RedJingCui;

        item1ColorBg.sprite = ResourcesConfig.OrangeBg;
        item1Edge.Play("OrangeEdge");
        item1Image.sprite = ResourcesConfig.OrangeJingCui;
        
        item2ColorBg.sprite = ResourcesConfig.OrangeBg;
        item2Edge.Play("OrangeEdge");
        item2Image.sprite = ResourcesConfig.OrangeJingCui;
        
        item3ColorBg.sprite = ResourcesConfig.OrangeBg;
        item3Edge.Play("OrangeEdge");
        item3Image.sprite = ResourcesConfig.OrangeJingCui;
        
        item4ColorBg.sprite = ResourcesConfig.OrangeBg;
        item4Edge.Play("OrangeEdge");
        item4Image.sprite = ResourcesConfig.OrangeJingCui;
        
        itemColorBg.sprite = ResourcesConfig.RedBg;
        itemEdge.Play("RedEdge");
        itemImage.sprite = ResourcesConfig.RedJingCui;
    }
    
    public void ShowShenHuaZhiXinItem()
    {
        ShowItems();
        _heChengType = HeChengType.ShenHuaZhiXin;

        item1ColorBg.sprite = ResourcesConfig.JuDaYaChi;
        item1Edge.Play("OrangeEdge");
        item1Image.sprite = ResourcesConfig.OrangeJingCui;
        
        item2ColorBg.sprite = ResourcesConfig.FuMoZhiGu;
        item2Edge.Play("OrangeEdge");
        item2Image.sprite = ResourcesConfig.OrangeJingCui;
        
        item3ColorBg.sprite = ResourcesConfig.GoldBlood;
        item3Edge.Play("OrangeEdge");
        item3Image.sprite = ResourcesConfig.OrangeJingCui;
        
        item4ColorBg.sprite = ResourcesConfig.ZuiEYanZhu;
        item4Edge.Play("OrangeEdge");
        item4Image.sprite = ResourcesConfig.OrangeJingCui;
        
        itemColorBg.sprite = ResourcesConfig.ShenHuaZhiXin;
        itemEdge.Play("RedEdge");
        itemImage.sprite = ResourcesConfig.RedJingCui;
    }
    
    public void ShowItems()
    {
        item1ColorBg.gameObject.SetActive(true);
        item1Edge.gameObject.SetActive(true);
        item1Image.gameObject.SetActive(true);
        
        item2ColorBg.gameObject.SetActive(true);
        item2Edge.gameObject.SetActive(true);
        item2Image.gameObject.SetActive(true);
        
        item3ColorBg.gameObject.SetActive(true);
        item3Edge.gameObject.SetActive(true);
        item3Image.gameObject.SetActive(true);
        
        item4ColorBg.gameObject.SetActive(true);
        item4Edge.gameObject.SetActive(true);
        item4Image.gameObject.SetActive(true);
        
        itemColorBg.gameObject.SetActive(true);
        itemEdge.gameObject.SetActive(true);
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
                    BagController.S.PropList[102].Count += count / 4;
                }
                else
                {
                    BagController.S.PropList[101].Count -=  4;
                    BagController.S.PropList[102].Count += 1;
                }
                break;
            
            case HeChengType.BlueWeaponFragment:
                if (!BagController.S.PropList.ContainsKey(102) || BagController.S.PropList[102].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState == true)
                {
                    int count = BagController.S.PropList[102].Count;

                    BagController.S.PropList[102].Count %=  4;
                    BagController.S.PropList[103].Count += count / 4;
                }
                else
                {
                    BagController.S.PropList[102].Count -=  4;
                    BagController.S.PropList[103].Count += 1;
                }
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
                    BagController.S.PropList[104].Count += count / 4;
                }
                else
                {
                    BagController.S.PropList[103].Count -=  4;
                    BagController.S.PropList[104].Count += 1;
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
                    BagController.S.PropList[105].Count += count / 4;
                }
                else
                {
                    BagController.S.PropList[104].Count -=  4;
                    BagController.S.PropList[105].Count += 1;
                }
                break;
            
            case HeChengType.RedWeaponFragment:
                if (!BagController.S.PropList.ContainsKey(105) || BagController.S.PropList[105].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState == true)
                {
                    int count = BagController.S.PropList[105].Count;

                    BagController.S.PropList[105].Count %=  4;
                    BagController.S.PropList[106].Count += count / 4;
                }
                else
                {
                    BagController.S.PropList[105].Count -=  4;
                    BagController.S.PropList[106].Count += 1;
                }
                break;
            
            
            
            
            
            
            case HeChengType.GreenJingCui:
                if (!BagController.S.PropList.ContainsKey(201) || BagController.S.PropList[201].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState == true)
                {
                    int count = BagController.S.PropList[201].Count;

                    BagController.S.PropList[201].Count %=  4;
                    BagController.S.PropList[202].Count += count / 4;
                }
                else
                {
                    BagController.S.PropList[201].Count -=  4;
                    BagController.S.PropList[202].Count += 1;
                }
                break;
            
            case HeChengType.BlueJingCui:
                if (!BagController.S.PropList.ContainsKey(202) || BagController.S.PropList[202].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState == true)
                {
                    int count = BagController.S.PropList[202].Count;

                    BagController.S.PropList[202].Count %=  4;
                    BagController.S.PropList[203].Count += count / 4;
                }
                else
                {
                    BagController.S.PropList[202].Count -=  4;
                    BagController.S.PropList[203].Count += 1;
                }
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
                    BagController.S.PropList[204].Count += count / 4;
                }
                else
                {
                    BagController.S.PropList[203].Count -=  4;
                    BagController.S.PropList[204].Count += 1;
                }
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
                    BagController.S.PropList[205].Count += count / 4;
                }
                else
                {
                    BagController.S.PropList[204].Count -=  4;
                    BagController.S.PropList[205].Count += 1;
                }
                break;
            
            case HeChengType.RedJingCui:
                if (!BagController.S.PropList.ContainsKey(205) || BagController.S.PropList[205].Count < 4)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"材料不足");
                    return;
                }

                if (_toggleState == true)
                {
                    int count = BagController.S.PropList[205].Count;
                    BagController.S.PropList[205].Count %=  4;
                    BagController.S.PropList[206].Count += count / 4;
                }
                else
                {
                    BagController.S.PropList[205].Count -=  4;
                    BagController.S.PropList[206].Count += 1;
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
                    }                }
                break;
        }
        
        StoreController.S.SaveStoreData();
    }

    public void ResetItems()
    {
        item1ColorBg.gameObject.SetActive(false);
        item1Edge.gameObject.SetActive(false);
        item1Image.gameObject.SetActive(false);
        
        item2ColorBg.gameObject.SetActive(false);
        item2Edge.gameObject.SetActive(false);
        item2Image.gameObject.SetActive(false);
        
        item3ColorBg.gameObject.SetActive(false);
        item3Edge.gameObject.SetActive(false);
        item3Image.gameObject.SetActive(false);
        
        item4ColorBg.gameObject.SetActive(false);
        item4Edge.gameObject.SetActive(false);
        item4Image.gameObject.SetActive(false);
        
        itemColorBg.gameObject.SetActive(false);
        itemEdge.gameObject.SetActive(false);
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
                ResetItems();
                _toggleState = false;
                gou.gameObject.SetActive(_toggleState);
                break;
            case PanelType.XiLian:
                xiLianPanel.SetActive(true);
                heChongPanel.SetActive(false);
                jinJiePanel.SetActive(false);
                ShowXiLianBag();
                clickEquipid = 0;
                break;
            case PanelType.JinJie:
                xiLianPanel.SetActive(false);
                heChongPanel.SetActive(false);
                jinJiePanel.SetActive(true);
                break;
        }
    }

    public void XiLianEquip(object[] obj)
    {
        EquipTable equip=obj[0] as EquipTable;
        if (equip == null)
        {
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
                    greenEquipName.text = EntryConfig.OrangeEntryNameDic[equip.OrangeEntry1];
                }
                greenQuality.gameObject.SetActive(true);
                blueQuality.gameObject.SetActive(false);
                purpleQuality.gameObject.SetActive(false);
                orangeQuality.gameObject.SetActive(false);
                redQuality.gameObject.SetActive(false);
                edge.Play("GreenEdge");
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
                    blueEquipName.text = EntryConfig.OrangeEntryNameDic[equip.OrangeEntry1];
                }
                greenQuality.gameObject.SetActive(false);
                blueQuality.gameObject.SetActive(true);
                purpleQuality.gameObject.SetActive(false);
                orangeQuality.gameObject.SetActive(false);
                redQuality.gameObject.SetActive(false);
                edge.Play("BlueEdge");
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
                    purpleEquipName.text = EntryConfig.OrangeEntryNameDic[equip.OrangeEntry1];
                }
                greenQuality.gameObject.SetActive(false);
                blueQuality.gameObject.SetActive(false);
                purpleQuality.gameObject.SetActive(true);
                orangeQuality.gameObject.SetActive(false);
                redQuality.gameObject.SetActive(false);
                edge.Play("PurpleEdge");
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
                    orangeEquipName.text = EntryConfig.OrangeEntryNameDic[equip.OrangeEntry1];
                }
                greenQuality.gameObject.SetActive(false);
                blueQuality.gameObject.SetActive(false);
                purpleQuality.gameObject.SetActive(false);
                orangeQuality.gameObject.SetActive(true);
                redQuality.gameObject.SetActive(false);
                edge.Play("OrangeEdge");
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
                    redEquipName.text = EntryConfig.OrangeEntryNameDic[equip.OrangeEntry1];
                }
                greenQuality.gameObject.SetActive(false);
                blueQuality.gameObject.SetActive(false);
                purpleQuality.gameObject.SetActive(false);
                orangeQuality.gameObject.SetActive(false);
                redQuality.gameObject.SetActive(true);
                edge.Play("RedEdge");
                equipBg.sprite = ResourcesConfig.RedBg;
                break;
        }

        image.sprite = ResourcesConfig.GetEquipSprite(equip);
        baseAttribute1.text = (equip.equip_type_id == 2 || equip.equip_type_id == 3 || equip.equip_type_id == 5)
            ? "生命值 :"
            : "攻击力 :";
        baseAttribute2.text = (equip.equip_type_id == 2 || equip.equip_type_id == 3 || equip.equip_type_id == 5)
            ? "防御 :"
            : "暴击 :";

        baseAttribute1Value.text = (equip.equip_type_id == 2 || equip.equip_type_id == 3 || equip.equip_type_id == 5)
            ? equip.HP.ToString()
            : equip.Damage.ToString();
        
        baseAttribute2Value.text = (equip.equip_type_id == 2 || equip.equip_type_id == 3 || equip.equip_type_id == 5)
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
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("XiLian",XiLianEquip);
        ShowPanel(PanelType.HeCheng);
        heCheng.onClick.AddListener(()=>
        {
            HeCheng();
        });
        exitButton.onClick.AddListener(() =>
        {
            Destroy(gameObject);
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
            if (BagController.S.EquipIdList[clickEquipid].equip_type_id == 1 || BagController.S.EquipIdList[clickEquipid].equip_type_id == 4 ||
                BagController.S.EquipIdList[clickEquipid].equip_type_id == 5)
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
    }

    public void SetGou()
    {
        _toggleState=!_toggleState;
        gou.gameObject.SetActive(_toggleState);
    }
    
}
