using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FuChongItem : MonoBehaviour
{
    public int FuChongItemIndex;
    public GameObject Suo;
    public GameObject bg;

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
        
        if (Input.GetMouseButtonUp(0))
        {
            if (ChongWuController.S.isLeftMouseDown)
            {
                // 检查松开时鼠标是否在当前UI物体上
                if (IsMouseOverUIObject(bg))
                {
                    if (ChongWuController.S.FuChongWuTable.ChongWuId == PlayerData.S.ZhuChongWuId)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"不能将主宠物设为副宠");
                        return;
                    }
                    
                    switch (FuChongItemIndex)
                    {
                        case 1:
                            if (PlayerData.S.level < 20)
                            {
                                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"等级不足");
                                return;
                            }
                            break;
                        case 2:
                            if (PlayerData.S.level < 40)
                            {
                                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"等级不足");
                                return;
                            }
                            break;
                        case 3:
                            if (PlayerData.S.level < 60)
                            {
                                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"等级不足");
                                return;
                            }
                            break;
                    }
                    switch (FuChongItemIndex)
                    {
                        case 1:
                            if (PlayerData.S.FuChongWuId2 == ChongWuController.S.FuChongWuTable.ChongWuId)
                            {
                                PlayerData.S.FuChongWuId2 = 0;
                            }
                            if (PlayerData.S.FuChongWuId3 == ChongWuController.S.FuChongWuTable.ChongWuId)
                            {
                                PlayerData.S.FuChongWuId3 = 0;
                            }
                            PlayerData.S.FuChongWuId1 = ChongWuController.S.FuChongWuTable.ChongWuId;
                            break;
                        
                        case 2:
                            if (PlayerData.S.FuChongWuId1 == ChongWuController.S.FuChongWuTable.ChongWuId)
                            {
                                PlayerData.S.FuChongWuId1 = 0;
                            }
                            if (PlayerData.S.FuChongWuId3 == ChongWuController.S.FuChongWuTable.ChongWuId)
                            {
                                PlayerData.S.FuChongWuId3 = 0;
                            }
                            PlayerData.S.FuChongWuId2 = ChongWuController.S.FuChongWuTable.ChongWuId;
                            break;
                        
                        case 3:
                            if (PlayerData.S.FuChongWuId2 == ChongWuController.S.FuChongWuTable.ChongWuId)
                            {
                                PlayerData.S.FuChongWuId2 = 0;
                            }
                            if (PlayerData.S.FuChongWuId1 == ChongWuController.S.FuChongWuTable.ChongWuId)
                            {
                                PlayerData.S.FuChongWuId1 = 0;
                            }
                            PlayerData.S.FuChongWuId3 = ChongWuController.S.FuChongWuTable.ChongWuId;
                            break;
                    }
                    ObserverModuleManager.S.SendEvent("ResetFuChongWu");
                }
            }
        }
    }

    public void ShowFuChong()
    {
        ChongWuTable table = null;
        switch (FuChongItemIndex)
        {
            case 1:
                if (PlayerData.S.FuChongWuId1 != 0)
                {
                    table = PlayerData.S.ChongWuDic[PlayerData.S.FuChongWuId1];
                }
                else
                {
                    transform.Find("Image").gameObject.SetActive(false);
                    transform.Find("colorbg").gameObject.SetActive(false);
                    transform.Find("Edge").gameObject.SetActive(false);
                }
                break;
            
            case 2:
                if (PlayerData.S.FuChongWuId2 != 0)
                {
                    table = PlayerData.S.ChongWuDic[PlayerData.S.FuChongWuId2];
                }
                else
                {
                    transform.Find("Image").gameObject.SetActive(false);
                    transform.Find("colorbg").gameObject.SetActive(false);
                    transform.Find("Edge").gameObject.SetActive(false);                }
                break;
            
            case 3:
                if (PlayerData.S.FuChongWuId3 != 0)
                {
                    table = PlayerData.S.ChongWuDic[PlayerData.S.FuChongWuId3];
                }
                else
                {
                    transform.Find("Image").gameObject.SetActive(false);
                    transform.Find("colorbg").gameObject.SetActive(false);
                    transform.Find("Edge").gameObject.SetActive(false);                }
                break;
        }

        if (table != null)
        {
            transform.Find("Image").gameObject.SetActive(true);
            transform.Find("colorbg").gameObject.SetActive(true);
            transform.Find("Edge").gameObject.SetActive(true);
            switch (table.Quality)
            {
                case 1:
                    transform.Find("colorbg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                    transform.Find("Edge").GetComponent<Animator>().Play("WhiteEdge");
                    break;
                case 2:
                    transform.Find("colorbg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
                    transform.Find("Edge").GetComponent<Animator>().Play("GreenEdge");
                    break;
                case 3:
                    transform.Find("colorbg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                    transform.Find("Edge").GetComponent<Animator>().Play("BlueEdge");
                    break;
                case 4:
                    transform.Find("colorbg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
                    transform.Find("Edge").GetComponent<Animator>().Play("PurpleEdge");
                    break;
                case 5:
                    transform.Find("colorbg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                    transform.Find("Edge").GetComponent<Animator>().Play("OrangeEdge");
                    break;
                case 6:
                    transform.Find("colorbg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
                    transform.Find("Edge").GetComponent<Animator>().Play("RedEdge");
                    break;
            }
            switch (FuChongItemIndex)
            {
                case 1:
                    if (PlayerData.S.FuChongWuId1 != 0)
                    {
                        transform.Find("Image").GetComponent<Image>().sprite =
                            ResourcesConfig.GetChongWuSprite(PlayerData.S.ChongWuDic[PlayerData.S.FuChongWuId1]
                                .ChongWuType);
                    }
                    else
                    {
                        transform.Find("Image").gameObject.SetActive(false);
                    }
                    break;
                
                case 2:
                    if (PlayerData.S.FuChongWuId2 != 0)
                    {
                        transform.Find("Image").GetComponent<Image>().sprite =
                            ResourcesConfig.GetChongWuSprite(PlayerData.S.ChongWuDic[PlayerData.S.FuChongWuId2]
                                .ChongWuType);
                    }
                    else
                    {
                        transform.Find("Image").gameObject.SetActive(false);
                    }
                    break;
                
                case 3:
                    if (PlayerData.S.FuChongWuId3 != 0)
                    {
                        transform.Find("Image").GetComponent<Image>().sprite =
                            ResourcesConfig.GetChongWuSprite(PlayerData.S.ChongWuDic[PlayerData.S.FuChongWuId3]
                                .ChongWuType);
                    }
                    else
                    {
                        transform.Find("Image").gameObject.SetActive(false);
                    }
                    break;
            }
        }
    }

    private void OnEnable()
    {
        switch (FuChongItemIndex)
        {
            case 1:
                Suo.gameObject.SetActive(PlayerData.S.level<20);
                break;
            case 2:
                Suo.gameObject.SetActive(PlayerData.S.level<40);
                break;
            case 3:
                Suo.gameObject.SetActive(PlayerData.S.level<60);
                break;
        }

        ShowFuChong();
    }
}
