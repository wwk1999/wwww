using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ChongWuListItem:MonoBehaviour, IPointerClickHandler,IPointerDownHandler 
{
    public Image bg;
    public TextMeshProUGUI name1;
    public TextMeshProUGUI name2;
    public TextMeshProUGUI name3;
    public TextMeshProUGUI name4;
    public TextMeshProUGUI name5;
    public TextMeshProUGUI name6;

    public Image Image;
    public TextMeshProUGUI Level;
    public GameObject XX;
    public GameObject XXContent;


    public AspectRatioFitter  aspectRatioFitter;
    private RectTransform canvasRect; // Canvas 的 RectTransform
    public bool isLeftMouseDown = false;

    [NonSerialized]public ChongWuTable chongWuTable;

    public GameObject Gou;
    public Image YuanSuIcon;
    
    public Button XiangQingButton;

    private float isLeftMouseDownTime = 0;
    private GameObject ChongWuImage=null;
    public void ShowGou()
    {
        Gou.SetActive(true);
    }
    public void HideGou()
    {
        Gou.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isLeftMouseDown = true;
        }
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isLeftMouseDown = true;
        }
    }

  
    

    private void Update()
    {
        if (isLeftMouseDown)
        {
            isLeftMouseDownTime+=Time.deltaTime;
        }

        if (isLeftMouseDownTime >= 0.2f && ChongWuImage == null)
        {
            canvasRect = GetComponentInParent<Canvas>().transform as RectTransform;
            Vector2 localPoint;
            var cam = canvasRect.GetComponentInParent<Canvas>().renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, cam, out localPoint))
            {
                ChongWuImage=Instantiate(Resources.Load("Prefabs/Window/ChongWuImage"),canvasRect) as GameObject;
                RectTransform _ChongWuImage=ChongWuImage.transform as RectTransform;
                ChongWuImage.gameObject.SetActive(true);
                _ChongWuImage.anchoredPosition =  new Vector2(localPoint.x, localPoint.y);
                _ChongWuImage.transform.Find("Image").GetComponent<Image>().sprite =
                    ResourcesConfig.GetChongWuSprite(chongWuTable.ChongWuType);
                ChongWuController.S.FuChongWuTable = chongWuTable;
                ChongWuController.S.isLeftMouseDown = true;
            }
        }
        
        if (isLeftMouseDown&&ChongWuImage!=null)
        {
            canvasRect = GetComponentInParent<Canvas>().transform as RectTransform;
            Vector2 localPoint;
            var cam = canvasRect.GetComponentInParent<Canvas>().renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, cam, out localPoint))
            {
                RectTransform _ChongWuImage=ChongWuImage.transform as RectTransform;
                _ChongWuImage.anchoredPosition =  new Vector2(localPoint.x, localPoint.y);
            }

        }
        if (isLeftMouseDown && Input.GetMouseButtonUp(0))
        {
            isLeftMouseDown = false;
            isLeftMouseDownTime = 0;
            StartCoroutine(SetFlagNextFrame());
            if (ChongWuImage != null)
            {
                 Destroy(ChongWuImage.gameObject);
            }
        }
    }
    
    IEnumerator SetFlagNextFrame()
    {
        yield return null; // 等待一帧
        ChongWuController.S.isLeftMouseDown = false;
    }


    private void Start()
    {
        XiangQingButton.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("ShowPeiYangWindow",chongWuTable.ChongWuId);
        });
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
        name1.gameObject.SetActive(false);
        name2.gameObject.SetActive(false);
        name3.gameObject.SetActive(false);
        name4.gameObject.SetActive(false);
        name5.gameObject.SetActive(false);
        name6.gameObject.SetActive(false);

        switch (info.Quality)
        {
            case 1:
                name1.gameObject.SetActive(true);
                name1.text = info.Name;
                bg.sprite = ResourcesConfig.ChongWuItemBgWhite;
                break;
            case 2:
                name2.gameObject.SetActive(true);
                name2.text = info.Name;
                bg.sprite = ResourcesConfig.ChongWuItemBgGreen;
                break;
            case 3:
                name3.gameObject.SetActive(true);
                name3.text = info.Name;
                bg.sprite = ResourcesConfig.ChongWuItemBgBlue;
                break;
            case 4:
                name4.gameObject.SetActive(true);
                name4.text = info.Name;
                bg.sprite = ResourcesConfig.ChongWuItemBgPurple;
                break;
            case 5:
                name5.gameObject.SetActive(true);
                name5.text = info.Name;
                bg.sprite = ResourcesConfig.ChongWuItemBgOrange;
                break;
            case 6:
                name6.gameObject.SetActive(true);
                name6.text = info.Name;
                bg.sprite = ResourcesConfig.ChongWuItemBgRed;
                break;
        }
        switch (info.YuanSuType)
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
        foreach (Transform item in XXContent.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 0; i < info.XingJi; i++)
        {
            var xx = Instantiate(XX, XXContent.transform);
        }
        
    }
}
