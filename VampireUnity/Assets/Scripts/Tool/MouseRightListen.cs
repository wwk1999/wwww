using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseRightListen : MonoBehaviour, IPointerClickHandler
{
    public SkillType buttonType = 0;
    public KeyCodeType keyCode = KeyCodeType.None;
    public RectTransform canvasRect; // Canvas 的 RectTransform
    public RectTransform _skillSwitch;
    
    public Text keyCodeText;

    public List<MouseRightListen>  mouseRightListens = new List<MouseRightListen>();

    public GameObject skillSwitchObj;
    public GameObject mask;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
           Vector2 localPoint;
           var cam = canvasRect.GetComponentInParent<Canvas>().renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main;
           
           if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, cam, out localPoint))
           {
               skillSwitchObj.gameObject.SetActive(true);
               mask.SetActive(true);
               skillSwitchObj.GetComponent<SkillSwitch>().mouseRightListens= mouseRightListens;
               skillSwitchObj.GetComponent<SkillSwitch>().ClickMouseRightListen= this;
               _skillSwitch.anchoredPosition =  new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x+_skillSwitch.sizeDelta.x/2, gameObject.GetComponent<RectTransform>().anchoredPosition.y-_skillSwitch.sizeDelta.y/2);
           }
        }
    }
}