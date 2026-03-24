using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIMouseClickDetector : MonoBehaviour
{
    private EventSystem eventSystem;
    private GraphicRaycaster graphicRaycaster;

    void Start()
    {
        // 获取EventSystem（用于处理UI事件）
        eventSystem = EventSystem.current;
        if (eventSystem == null)
        {
            Debug.LogError("场景中缺少EventSystem，请在Hierarchy窗口右键创建UI/EventSystem");
        }

        // 获取Canvas上的GraphicRaycaster组件（用于UI射线检测）
        graphicRaycaster = GetComponent<GraphicRaycaster>();
        if (graphicRaycaster == null)
        {
            Debug.LogError("脚本所在的GameObject缺少GraphicRaycaster组件，请将脚本挂载到Canvas上");
        }
    }

    void Update()
    {
        // 检测鼠标左键点击
        if (Input.GetMouseButtonDown(0))
        {
            // 创建指针事件数据，设置为当前鼠标位置
            PointerEventData pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            // 存储射线检测结果
            List<RaycastResult> raycastResults = new List<RaycastResult>();

            // 执行UI射线检测
            graphicRaycaster.Raycast(pointerEventData, raycastResults);

            // 处理检测结果
            if (raycastResults.Count > 0)
            {
                // 打印第一个命中的UI元素名称（通常是最上层的UI）
                Debug.Log("点击的UI元素名称: " + raycastResults[0].gameObject.name);
            }
        }
    }
}