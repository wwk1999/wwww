using System;
using Mysql;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagEquipAttributeTool : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // 优先使用 inspector 指定的 prefab；若为空则尝试 Resources.Load(resourcePath)
    public GameObject prefab;
    private string resourcePath = "Prefabs/Window/EquipAttributeWhite";
    private Vector2 offset = new Vector2(50f, 0f); // 在右下角的偏移（像素/画布单位）

    private GameObject instance;
    private RectTransform rt;
    private Canvas parentCanvas;
    public BagGrid bagGrid;



    void Awake()
    {
        rt = GetComponent<RectTransform>();
        parentCanvas = GetComponentInParent<Canvas>();
        if (parentCanvas == null)
            Debug.LogWarning("EquipAttributeHover: 没有在父级中找到 Canvas。");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (instance != null) return;
        EquipTable equipTable = bagGrid.tableBase as EquipTable;

        if (prefab == null)
        {
            switch (equipTable.Quality)
            {
                case 1:
                    prefab = Resources.Load<GameObject>("Prefabs/Window/EquipAttributeWhite");
                    break;
                case 2:
                    prefab = Resources.Load<GameObject>("Prefabs/Window/EquipAttributeWhite");
                    break;
                case 3:
                    prefab = Resources.Load<GameObject>("Prefabs/Window/EquipAttributeWhite");
                    break;
                case 4:
                    prefab = Resources.Load<GameObject>("Prefabs/Window/EquipAttributeWhite");
                    break;
                case 5:
                    prefab = Resources.Load<GameObject>("Prefabs/Window/EquipAttributeWhite");
                    break;
                case 6:
                    prefab = Resources.Load<GameObject>("Prefabs/Window/EquipAttributeWhite");
                    break;
            }
        }
        if (prefab == null)
        {
            Debug.LogWarning($"EquipAttributeHover: 无法找到预制体（请在 inspector 指定或放入 Resources/{resourcePath}）");
            return;
        }

        // 实例化到 Canvas 下（保证是 UI）
        var canvasRect = parentCanvas.GetComponent<RectTransform>();
        instance = Instantiate(prefab, parentCanvas.transform);
        var instRt = instance.GetComponent<RectTransform>();

        // 计算按钮右下角世界坐标
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners); // 0:bottom-left, 1:top-left, 2:top-right, 3:bottom-right
        Vector3 worldBR = corners[3];

        // 将世界坐标转换为 Canvas 的本地 anchoredPosition（处理各种 Canvas 渲染模式）
        Camera cam = parentCanvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : parentCanvas.worldCamera;
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(cam, worldBR);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, cam, out Vector2 localPoint);

        // 向右偏移实例化物体宽度的一半（再加上原有 offset）
        float halfWidth = instRt.rect.width * 0.5f;
        instRt.anchoredPosition = localPoint + offset + new Vector2(halfWidth, 0f);

        instance.transform.SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (instance != null)
        {
            Destroy(instance);
            instance = null;
        }
    }

    void OnDisable()
    {
        if (instance != null)
        {
            Destroy(instance);
            instance = null;
        }
    }
}