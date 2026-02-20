using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class YingDi : MonoBehaviour
{
    public GameObject player;
    public GameObject shangren;
    public GameObject duanzao;
    public GameObject chongwu;
    public Button shangrenButton;
    public Button duanzaoButton;
    public Button chongwuButton;

    private void Start()
    {
        
    }
    
    private bool IsMouseOverUIObject(GameObject targetObject)
    {
        if (targetObject == null) return false;
        
        // 获取EventSystem（如果没有则返回false）
        if (EventSystem.current == null) return false;
        
        // 创建PointerEventData
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;
        
        // 执行射线检测
        var raycastResults = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);
        
        // 遍历所有检测到的UI元素
        foreach (var result in raycastResults)
        {
            // 如果检测到的物体就是目标物体
            if (result.gameObject == targetObject)
            {
                return true;
            }
            
            // 可选：如果要检测子物体也算（比如点击Image，但targetObject是父级Canvas）
            // if (result.gameObject.transform.IsChildOf(targetObject.transform))
            // {
            //     return true;
            // }
        }
        
        return false;
    }
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsMouseOverUIObject(shangrenButton.gameObject))
            {
                GameObject shangdian=Instantiate(Resources.Load<GameObject>("Prefabs/Window/ShangDianWindow"));

            }
            
            if (IsMouseOverUIObject(duanzaoButton.gameObject))
            {
                GameObject duanzao=Instantiate(Resources.Load<GameObject>("Prefabs/Window/DuanZaoWindow"));
            }
            
            if (IsMouseOverUIObject(chongwuButton.gameObject))
            {
                WindowController.S.ChongWuWindow.gameObject.SetActive(true);
            }
        }

        if (IsMouseOverUIObject(shangrenButton.gameObject))
        {
            ColorBlock colors = shangrenButton.colors;
            colors.normalColor = new Color(0.8f, 0.8f, 0.8f);
            shangrenButton.colors = colors;        
        }
        else
        {
            ColorBlock colors = shangrenButton.colors;
            colors.normalColor = new Color(1f, 1f, 1f);
            shangrenButton.colors = colors;      
        }
        
        if (IsMouseOverUIObject(duanzaoButton.gameObject))
        {
            ColorBlock colors = duanzaoButton.colors;
            colors.normalColor = new Color(0.8f, 0.8f, 0.8f);
            duanzaoButton.colors = colors;        
        }
        else
        {
            ColorBlock colors = duanzaoButton.colors;
            colors.normalColor = new Color(1f, 1f, 1f);
            duanzaoButton.colors = colors;      
        }
        
        if (IsMouseOverUIObject(chongwuButton.gameObject))
        {
            ColorBlock colors = chongwuButton.colors;
            colors.normalColor = new Color(0.8f, 0.8f, 0.8f);
            chongwuButton.colors = colors;        
        }
        else
        {
            ColorBlock colors = chongwuButton.colors;
            colors.normalColor = new Color(1f, 1f, 1f);
            chongwuButton.colors = colors;      
        }
        
        
        if (Vector2.Distance(player.transform.position, shangren.transform.position) > 1)
        {
            shangrenButton.gameObject.SetActive(false);
        }
        else
        {
            shangrenButton.gameObject.SetActive(true);
        }
        
        if (Vector2.Distance(player.transform.position, duanzao.transform.position) > 1)
        {
            duanzaoButton.gameObject.SetActive(false);
        }
        else
        {
            duanzaoButton.gameObject.SetActive(true);
        }
        
        if (Vector2.Distance(player.transform.position, chongwu.transform.position) > 1)
        {
            chongwuButton.gameObject.SetActive(false);
        }
        else
        {
            chongwuButton.gameObject.SetActive(true);
        }
    }
}
