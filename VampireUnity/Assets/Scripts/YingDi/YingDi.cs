using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum JiaoHuType
{
    None,
    ShangRen,
    TieJiang,
    ChongWu,
    ShiZhuangDaShi,
}
public class YingDi : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer PenQuan;
    public SpriteRenderer ZhangPen;
    public SpriteRenderer Tanzi;
    public Collider2D TanZiTri;
    public SpriteRenderer ChongWuDian;
    public Collider2D ChongWuDianTri;
    public SpriteRenderer shu;
    public SpriteRenderer shu1;


    public GameObject TieJiang;
    public GameObject ChongWuShi;
    public GameObject ShiZhuangDaShi;
    public GameObject ShangRen;

    public GameObject TieJiangJiaoHu;
    public GameObject ChongWuShiJiaoHu;
    public GameObject ShiZhuangDaShiJiaoHu;
    public GameObject ShangRenJiaoHu;
    
    public SpriteRenderer shizhuang;

    public Collider2D ZhangPenTri;

    public SpriteRenderer ChongWuDaShi;

    private JiaoHuType jiaoHuType;

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
                spriteRenderer.sortingOrder = 2;
                return;
            }
            else
            {
                spriteRenderer.sortingOrder = 5;
            }
        }
    }
    
    public void CheckCollider1(Collider2D collider2D)
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
                ZhangPen.sortingOrder = 5;
                shizhuang.sortingOrder = 6;
                return;
            }
        }
    }

    

    private void Update()
    {
        if (Vector2.Distance(ShangRen.transform.position, player.transform.position) < 1)
        {
            jiaoHuType=JiaoHuType.ShangRen;
        }else if (Vector2.Distance(ChongWuShi.transform.position, player.transform.position) < 1)
        {
            jiaoHuType=JiaoHuType.ChongWu;
        }else if (Vector2.Distance(ShiZhuangDaShi.transform.position, player.transform.position) < 1)
        {
            jiaoHuType=JiaoHuType.ShiZhuangDaShi;
        }else if (Vector2.Distance(TieJiang.transform.position, player.transform.position) < 1)
        {
            jiaoHuType=JiaoHuType.TieJiang;
        }
        else
        {
            jiaoHuType=JiaoHuType.None;
        }

        ZhangPen.sortingOrder = 2;
        shizhuang.sortingOrder = 3;
        CheckCollider1(ZhangPenTri);

        TieJiangJiaoHu.gameObject.SetActive(jiaoHuType == JiaoHuType.TieJiang);
        ChongWuShiJiaoHu.gameObject.SetActive(jiaoHuType == JiaoHuType.ChongWu);
        ShiZhuangDaShiJiaoHu.gameObject.SetActive(jiaoHuType == JiaoHuType.ShiZhuangDaShi);
        ShangRenJiaoHu.gameObject.SetActive(jiaoHuType == JiaoHuType.ShangRen);

        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (jiaoHuType)
            {
                case  JiaoHuType.TieJiang:
                    WindowController.S.DuanZaoWindow.gameObject.SetActive(true);
                    break;
                case  JiaoHuType.ShiZhuangDaShi:
                    break;
                case  JiaoHuType.ShangRen:
                    WindowController.S.ShangDianWindow.gameObject.SetActive(true);
                    break;
                case  JiaoHuType.ChongWu:
                    WindowController.S.ChongWuWindow.gameObject.SetActive(true);
                    break;
            }
        }
        
        CheckCollider(TanZiTri,Tanzi);
        CheckCollider(ChongWuDianTri,ChongWuDian);
        ChongWuDaShi.sortingOrder=ChongWuDian.sortingOrder+1;
        if (player.transform.position.y > -3)
        {
            shu1.sortingOrder = 5;
        }
        else
        {
            shu1.sortingOrder = 3;
        }
        
        if (player.transform.position.y > 2)
        {
            shu.sortingOrder = 5;
        }
        else
        {
            shu.sortingOrder = 3;
        }
        
        if (player.transform.position.y > 0)
        {
            PenQuan.sortingOrder = 5;
        }
        else
        {
            PenQuan.sortingOrder = 3;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
           
        }
        
    }
}
