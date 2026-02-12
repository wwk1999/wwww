using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ChongWuListItem:MonoBehaviour, IPointerClickHandler
{
    public Image Image;
    public TextMeshProUGUI Level;
    public Image QualityIcon;
    public Image XX1;
    public Image XX2;
    public Image XX3;
    public Image XX4;
    public Image XX5;
    public AspectRatioFitter  aspectRatioFitter;
    private RectTransform canvasRect; // Canvas 的 RectTransform

    [NonSerialized]public ChongWuTable chongWuTable;

    public GameObject Gou;

    public void ShowGou()
    {
        Gou.SetActive(true);
    }
    public void HideGou()
    {
        Gou.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            ObserverModuleManager.S.SendEvent("ShowChongWuItemMask");
            canvasRect = GetComponentInParent<Canvas>().transform as RectTransform;
            Vector2 localPoint;
            var cam = canvasRect.GetComponentInParent<Canvas>().renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, cam, out localPoint))
            {
                GameObject ChongWuItemSwitch=Instantiate(Resources.Load("Prefabs/Window/ChongWuItemSwitch"),canvasRect) as GameObject;
                RectTransform _ChongWuItemSwitch=ChongWuItemSwitch.transform as RectTransform;
                ChongWuItemSwitch.gameObject.SetActive(true);
                _ChongWuItemSwitch.anchoredPosition =  new Vector2(localPoint.x+_ChongWuItemSwitch.sizeDelta.x/2, localPoint.y-_ChongWuItemSwitch.sizeDelta.y/2);
                ChongWuItemSwitch.GetComponent<ChongWuItemSwitch>().ClickChongWuItem = this;
            }
        }
    }



    public void SetChongWuListItem(ChongWuTable info)
    {
        chongWuTable=info;
        Image.sprite = ResourcesConfig.GetChongWuSprite(info.ChongWuType);
        float aspectRatio = ResourcesConfig.GetChongWuSprite(info.ChongWuType).rect.width / ResourcesConfig.GetChongWuSprite(info.ChongWuType).rect.height;
        aspectRatioFitter.aspectRatio = aspectRatio;
        Level.text = "Lv. "+info.Level;
        switch (info.Quality)
        {
            case 1:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality1;
                break;
            case 2:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality2;
                break;
            case 3:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality3;
                break;
            case 4:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality4;
                break;
            case 5:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality5;
                break;
            case 6:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality6;
                break;
        }

        if (info.XingJi >= 1)
        {
            XX1.sprite = ResourcesConfig.XXLiang;
        }
        else
        {
            XX1.sprite = ResourcesConfig.XXAn;
        }
        
        if (info.XingJi >= 2)
        {
            XX2.sprite = ResourcesConfig.XXLiang;
        }
        else
        {
            XX2.sprite = ResourcesConfig.XXAn;
        }
        
        if (info.XingJi >= 3)
        {
            XX3.sprite = ResourcesConfig.XXLiang;
        }
        else
        {
            XX3.sprite = ResourcesConfig.XXAn;
        }
        
        if (info.XingJi >= 4)
        {
            XX4.sprite = ResourcesConfig.XXLiang;
        }
        else
        {
            XX4.sprite = ResourcesConfig.XXAn;
        }
        
        if (info.XingJi >= 5)
        {
            XX5.sprite = ResourcesConfig.XXLiang;
        }
        else
        {
            XX5.sprite = ResourcesConfig.XXAn;
        }
    }
}
