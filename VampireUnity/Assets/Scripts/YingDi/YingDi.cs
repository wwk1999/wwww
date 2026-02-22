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
    public SpriteRenderer PenQuan;
    public SpriteRenderer ZhangPen;
    public SpriteRenderer Tanzi;
    public Collider2D TanZiTri;
    public SpriteRenderer ChongWuDian;
    public Collider2D ChongWuDianTri;
    
    public SpriteRenderer shu;


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
    
    public void CheckCollider(Collider2D collider2D,SpriteRenderer spriteRenderer)
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        collider2D.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Player"))
            {
                spriteRenderer.sortingOrder = 1;
                return;
            }
            else
            {
                spriteRenderer.sortingOrder = 3;
            }
        }
    }
    

    private void Update()
    {
        CheckCollider(TanZiTri,Tanzi);
        CheckCollider(ChongWuDianTri,ChongWuDian);
        if (player.transform.position.y > 2)
        {
            shu.sortingOrder = 3;
        }
        else
        {
            shu.sortingOrder = 1;
        }
        
        if (player.transform.position.y > -1)
        {
            ZhangPen.sortingOrder = 3;
        }
        else
        {
            ZhangPen.sortingOrder = 1;
        }
        
        if (player.transform.position.y > 0)
        {
            PenQuan.sortingOrder = 3;
        }
        else
        {
            PenQuan.sortingOrder = 1;
        }
        
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
