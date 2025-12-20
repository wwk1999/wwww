using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 按钮鼠标悬停事件监听器
/// 挂载到Button上即可监听鼠标进入和移出事件
/// </summary>
public class ButtonHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    [Header("SkillInfo预制体路径")]
    public string skillInfoPrefabPath = "Prefabs/Window/SkillInfo";
    
    [Header("位置偏移")]
    public Vector2 positionOffset = new Vector2(10, -10); // 调整偏移，正值向右下，负值向左上
    
    private GameObject skillInfoInstance;
    private RectTransform skillInfoRectTransform;
    private Canvas parentCanvas;
    private bool isHovering = false;
    private float lastUpdateTime = 0f;
    private const float UPDATE_INTERVAL = 0.05f;
    
    void Start()
    {
        parentCanvas = GetComponentInParent<Canvas>();
        if (parentCanvas == null)
        {
            GameObject uiRoot = GameObject.Find("UIRoot");
            if (uiRoot != null)
            {
                parentCanvas = uiRoot.GetComponentInChildren<Canvas>();
            }
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (skillInfoInstance == null && !isHovering)
        {
            CreateSkillInfo(eventData.position);
            isHovering = true;
        }
    }
    
    public void OnPointerMove(PointerEventData eventData)
    {
        if (isHovering && skillInfoInstance != null)
        {
            if (Time.time - lastUpdateTime > UPDATE_INTERVAL)
            {
                UpdateSkillInfoPosition(eventData.position);
                lastUpdateTime = Time.time;
            }
        }
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isHovering)
        {
            DestroySkillInfo();
            isHovering = false;
        }
    }
    
    private void CreateSkillInfo(Vector2 screenPosition)
    {
        if (skillInfoInstance != null)
        {
            return;
        }
        
        GameObject prefab = Resources.Load<GameObject>(skillInfoPrefabPath);
        if (prefab == null)
        {
            Debug.LogError($"无法加载SkillInfo预制体: {skillInfoPrefabPath}");
            return;
        }
        
        Transform parent = null;
        if (parentCanvas != null)
        {
            parent = parentCanvas.transform;
        }
        else
        {
            GameObject uiRoot = GameObject.Find("UIRoot");
            if (uiRoot != null)
            {
                parent = uiRoot.transform;
            }
        }
        
        skillInfoInstance = Instantiate(prefab, parent);
        skillInfoInstance.name = "SkillInfo_Hover";
        skillInfoRectTransform = skillInfoInstance.GetComponent<RectTransform>();
        
        // 设置pivot为左上角 (0, 1)
        // 这样anchoredPosition就是相对于左上角的位置
        skillInfoRectTransform.pivot = new Vector2(0, 1);
        
        // 禁用 SkillSwitch
        SkillSwitch skillSwitch = skillInfoInstance.GetComponentInChildren<SkillSwitch>();
        if (skillSwitch != null)
        {
            skillSwitch.enabled = false;
        }
        
        // 设置CanvasGroup，防止阻挡鼠标
        CanvasGroup canvasGroup = skillInfoInstance.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = skillInfoInstance.AddComponent<CanvasGroup>();
        }
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
        
        UpdateSkillInfoPosition(screenPosition);
        skillInfoInstance.transform.SetAsLastSibling();
    }
    
    private void UpdateSkillInfoPosition(Vector2 screenPosition)
    {
        if (skillInfoRectTransform == null || parentCanvas == null)
            return;
        
        Vector2 localPoint;
        RectTransform canvasRect = parentCanvas.GetComponent<RectTransform>();
        
        // 将屏幕坐标转换为Canvas的本地坐标
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            screenPosition + positionOffset, // 添加偏移
            parentCanvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : parentCanvas.worldCamera,
            out localPoint))
        {
            // 由于pivot已经设置为(0,1)，直接设置位置即可
            skillInfoRectTransform.anchoredPosition = localPoint;
        }
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
        isHovering = false;
    }
    
    void OnDestroy()
    {
        DestroySkillInfo();
    }
}