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
    public RectTransform canvasRect; // Canvas 的 RectTransform
    public RectTransform _skillSwitch;

    public GameObject skillSwitchObj;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
           Vector2 localPoint;
           var cam = canvasRect.GetComponentInParent<Canvas>().renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main;
           
           if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, cam, out localPoint))
           {
               skillSwitchObj.gameObject.SetActive(true);
               skillSwitchObj.GetComponent<SkillSwitch>().ClickMouseRightListen= this;
               skillSwitchObj.GetComponent<SkillSwitch>().buttonType= buttonType;
               skillSwitchObj.GetComponent<SkillSwitch>().ClickType= buttonType;
               switch (buttonType)
               {
                   case SkillType.Ice1:
                   case SkillType.Ice2:
                   case SkillType.Ice3:
                   case SkillType.Dian1:
                   case SkillType.Dian2:
                   case SkillType.Dian3:
                   case SkillType.HeiAn1:
                   case SkillType.HeiAn2:
                   case SkillType.HeiAn3:
                   case SkillType.Huo1:
                   case SkillType.Huo2:
                   case SkillType.Huo3:
                       _skillSwitch.anchoredPosition =  new Vector2(localPoint.x+_skillSwitch.sizeDelta.x/2+50, localPoint.y-_skillSwitch.sizeDelta.y/2);
                       break;
                   case SkillType.Ice4:
                   case SkillType.Huo4:
                   case SkillType.Dian4:
                   case SkillType.HeiAn4:
                       _skillSwitch.anchoredPosition =  new Vector2(localPoint.x+_skillSwitch.sizeDelta.x/2+50, localPoint.y+_skillSwitch.sizeDelta.y/10);
                       break;
                   case SkillType.Ice5:
                   case SkillType.Huo5:
                   case SkillType.Dian5:
                   case SkillType.HeiAn5:
                       _skillSwitch.anchoredPosition =  new Vector2(localPoint.x-_skillSwitch.sizeDelta.x/2-50, localPoint.y);
                       break;

               }
           }
        }
    }

    

   
    private void Start()
    {
    }

    
}