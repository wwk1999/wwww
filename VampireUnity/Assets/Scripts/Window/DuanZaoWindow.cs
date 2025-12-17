using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PanelType
{
    None,
    XiLian,
    HeCheng,
    JinJie,
}
public class DuanZaoWindow : MonoBehaviour
{
    public GameObject xiLianPanel;
    public GameObject heChongPanel;
    public GameObject jinJiePanel;
    
    public Button heChongButton;
    public Button jinJieButton;
    public Button xiLianButton;

    
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


    public void ShowWeaponFragmentItem1()
    {
        ShowItems();
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
                break;
            case PanelType.XiLian:
                xiLianPanel.SetActive(true);
                heChongPanel.SetActive(false);
                jinJiePanel.SetActive(false);
                break;
            case PanelType.JinJie:
                xiLianPanel.SetActive(false);
                heChongPanel.SetActive(false);
                jinJiePanel.SetActive(true);
                break;
        }
    }

    private void Start()
    {
        ShowPanel(PanelType.HeCheng);
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
    }
}
