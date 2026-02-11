using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChongWuDanButtonRight : MonoBehaviour, IPointerClickHandler
{
    private RectTransform canvasRect; // Canvas 的 RectTransform
    public PropGrid propGrid;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (propGrid.propType<1600||propGrid.propType>1700)
            {
                return;
            }

            ObserverModuleManager.S.SendEvent("ShowChongWuDanMask");
            canvasRect = GetComponentInParent<Canvas>().transform as RectTransform;
            Vector2 localPoint;
            var cam = canvasRect.GetComponentInParent<Canvas>().renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, cam, out localPoint))
            {
                GameObject chongWuDanSwitch=Instantiate(Resources.Load("Prefabs/Window/ChongWuDanSwitch"),canvasRect) as GameObject;
                RectTransform _chongwudanSwitch=chongWuDanSwitch.transform as RectTransform;
                chongWuDanSwitch.gameObject.SetActive(true);
                _chongwudanSwitch.anchoredPosition =  new Vector2(localPoint.x+_chongwudanSwitch.sizeDelta.x/2, localPoint.y-_chongwudanSwitch.sizeDelta.y/2);
            }
        }
    }
}
