using System;
using System.Collections;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("按钮类型")]
    public SkillInfoType buttonType = SkillInfoType.None;

    public RectTransform canvasRect;

    [Header("SkillInfo预制体路径")]
    public string skillInfoPrefabPath = "Prefabs/Window/SkillInfo";
    public string MainskillInfoPrefabPath = "Prefabs/Window/MainSkillInfo";

    [Header("位置偏移")]
    private Vector2 positionOffset = new Vector2(60, 60);

    private GameObject skillInfoInstance;
    private RectTransform skillInfoRectTransform;
    private Canvas parentCanvas;
    private RectTransform buttonRectTransform;

    // hover scale parameters
    private Vector3 originalScale = Vector3.one;
    private Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1.2f);
    [UnityEngine.SerializeField] private float scaleDuration = 0.2f;
    private Coroutine scaleCoroutine;

    void Start()
    {
        parentCanvas = GetComponentInParent<Canvas>();
        if (parentCanvas == null)
        {
            GameObject uiRoot = GameObject.Find("UIRoot");
            if (uiRoot != null)
                parentCanvas = uiRoot.GetComponentInChildren<Canvas>();
        }

        buttonRectTransform = GetComponent<RectTransform>();
        // Ensure default scale is 1 if current scale is zero (prevents buttons appearing invisible)
        if (transform.localScale.sqrMagnitude < 1e-6f)
        {
            transform.localScale = Vector3.one;
            originalScale = Vector3.one;
        }
        else
        {
            originalScale = transform.localScale;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (skillInfoInstance == null)
            CreateSkillInfo();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DestroySkillInfo();
    }

    private void CreateSkillInfo()
    {
        if (skillInfoInstance != null)
            return;

        GameObject prefab = null;
        if (buttonType == SkillInfoType.IceMain || buttonType == SkillInfoType.HuoMain ||
            buttonType == SkillInfoType.DianMain || buttonType == SkillInfoType.HeiAnMain)
        {
             prefab = Resources.Load<GameObject>(MainskillInfoPrefabPath);
        }
        else
        {
            prefab = Resources.Load<GameObject>(skillInfoPrefabPath);
        }
       
        if (prefab == null)
        {
            Debug.LogError($"无法加载SkillInfo预制体: {skillInfoPrefabPath}");
            return;
        }
        Vector2 localPoint;
        var cam = canvasRect.GetComponentInParent<Canvas>().renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main;

        Transform parent = parentCanvas != null ? parentCanvas.transform : (GameObject.Find("UIRoot")?.transform);
        skillInfoInstance = Instantiate(prefab, parent);
        skillInfoRectTransform = skillInfoInstance.GetComponent<RectTransform>();
        CanvasGroup cg = skillInfoInstance.GetComponent<CanvasGroup>();
        if (cg == null) cg = skillInfoInstance.AddComponent<CanvasGroup>();
        cg.blocksRaycasts = false;
        cg.interactable = false;
        if (buttonType == SkillInfoType.IceMain || buttonType == SkillInfoType.HuoMain ||
            buttonType == SkillInfoType.DianMain || buttonType == SkillInfoType.HeiAnMain)
        {
            skillInfoInstance.GetComponent<MainSkillInfo>().type = buttonType;
            skillInfoInstance.GetComponent<MainSkillInfo>().SetMainSkillInfo();
        }
        else
        {
            skillInfoInstance.GetComponent<SkillInfo>().SkillType = buttonType;
            skillInfoInstance.GetComponent<SkillInfo>().SetSkillInfo();
        }
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, cam, out localPoint))
        {
            RectTransform skillInforect = skillInfoInstance.GetComponent<RectTransform>();
            switch (buttonType)
            {
                case SkillInfoType.Ice1:
                case SkillInfoType.Ice1_1:
                case SkillInfoType.Ice1_2:
                case SkillInfoType.Ice2:
                case SkillInfoType.Ice2_1:
                case SkillInfoType.Ice3:
                case SkillInfoType.Ice3_1:
                case SkillInfoType.IceBei1:
                case SkillInfoType.IceBei2:
                    skillInforect.anchoredPosition =  new Vector2(localPoint.x+skillInforect.sizeDelta.x/2, localPoint.y-skillInforect.sizeDelta.y/2);
                    break;
                case SkillInfoType.Ice2_2:
                case SkillInfoType.IceBei3:
                case SkillInfoType.IceBei4:
                    skillInforect.anchoredPosition =  new Vector2(localPoint.x+skillInforect.sizeDelta.x/2+25, localPoint.y);
                    break;
                case SkillInfoType.Ice3_2:
                case SkillInfoType.Ice5:
                case SkillInfoType.Ice5_1:
                case SkillInfoType.Ice5_2:
                    skillInforect.anchoredPosition =  new Vector2(localPoint.x-skillInforect.sizeDelta.x/2-25, localPoint.y);
                    break;
                case SkillInfoType.Ice4:
                case SkillInfoType.Ice4_1:
                case SkillInfoType.Ice4_2:
                    skillInforect.anchoredPosition =  new Vector2(localPoint.x, localPoint.y+skillInforect.sizeDelta.y/2+25);
                    break;
                case SkillInfoType.IceMain:
                case SkillInfoType.HuoMain:
                case SkillInfoType.DianMain:
                case SkillInfoType.HeiAnMain:
                    skillInforect.anchoredPosition =  new Vector2(localPoint.x+skillInforect.sizeDelta.x/2, localPoint.y-skillInforect.sizeDelta.y/2);
                    break;

                
            }
        }

        // 确保布局更新后再读取尺寸
        Canvas.ForceUpdateCanvases();
        skillInfoInstance.transform.SetAsLastSibling();
        
        
    }
    
    private void DestroySkillInfo()
    {
        if (skillInfoInstance != null)
        {
            Destroy(skillInfoInstance);
            skillInfoInstance = null;
            skillInfoRectTransform = null;
        }
    }
    
    
    void OnDisable()
    {
        DestroySkillInfo();
        if (scaleCoroutine != null) StopCoroutine(scaleCoroutine);
        transform.localScale = originalScale;
    }

    void OnDestroy()
    {
        DestroySkillInfo();
        if (scaleCoroutine != null) StopCoroutine(scaleCoroutine);
        transform.localScale = originalScale;
    }
}