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
            if (!CheckSkillLevel())
            {
                return;
            }
           Vector2 localPoint;
           var cam = canvasRect.GetComponentInParent<Canvas>().renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main;
           
           if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, cam, out localPoint))
           {
               skillSwitchObj.gameObject.SetActive(true);
               mask.SetActive(true);
               skillSwitchObj.GetComponent<SkillSwitch>().mouseRightListens= mouseRightListens;
               skillSwitchObj.GetComponent<SkillSwitch>().ClickMouseRightListen= this;
               skillSwitchObj.GetComponent<SkillSwitch>().buttonType= buttonType;
               _skillSwitch.anchoredPosition =  new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x+_skillSwitch.sizeDelta.x/2, gameObject.GetComponent<RectTransform>().anchoredPosition.y-_skillSwitch.sizeDelta.y/2);
           }
        }
    }

    public bool CheckSkillLevel()
    {
        switch (buttonType)
        {
            case SkillType.Skill1:
                return SkillJiaDian.S.DianSkill1Damage >= 1;
            case SkillType.Skill2:
                return SkillJiaDian.S.IceSkill2Damage >= 1;
            case SkillType.Skill3:
                return SkillJiaDian.S.IceSkill3Damage >= 1;
            case SkillType.Dash:
                return SkillJiaDian.S.Dash >= 1;
            case SkillType.IceSkill1:
                return SkillJiaDian.S.IceSkill1 >= 1;
            
            case SkillType.DianSkill2:
                return SkillJiaDian.S.DianSkill2 >= 1;
            
            case SkillType.DianSkill3:
                return SkillJiaDian.S.DianSkill3 >= 1;
            case SkillType.HuoSkill1:
                return SkillJiaDian.S.HuoSkill1 >= 1;
            case SkillType.HuoSkill2:
                return SkillJiaDian.S.HuoSkill2 >= 1;
            case SkillType.HuoSkill3:
                return SkillJiaDian.S.HuoSkill3 >= 1;
            case SkillType.HeiAnSkill1:
                return SkillJiaDian.S.HeiAnSkill1 >= 1;
            case SkillType.HeiAnSkill2:
                return SkillJiaDian.S.HeiAnSkill2Damage >= 1;
            case SkillType.HeiAnSkill3:
                return SkillJiaDian.S.HeiAnSkill3Damage >= 1;
        }
        return false;
    }

    public KeyCodeType GetKeyCodeSkill(SkillType skillType)
    {

        if (SkillData.S.LMB == skillType)
        {
            return KeyCodeType.LMB;
        }

        if (SkillData.S.RMB == skillType)
        {
            return KeyCodeType.RMB;
        }
        if (SkillData.S.Alpha1 == skillType)
        {
            return KeyCodeType.Alpha1;
        }
        if (SkillData.S.Alpha2 == skillType)
        {
            return KeyCodeType.Alpha2;
        }
        if (SkillData.S.Alpha3 == skillType)
        {
            return KeyCodeType.Alpha3;
        }
        return KeyCodeType.None;
    }

    public void LoadSkillKeyCode()
    {
        foreach (MouseRightListen listen in mouseRightListens)
        {
            switch (listen.buttonType)
            {
                case SkillType.Skill1:
                    listen.keyCode=GetKeyCodeSkill(SkillType.Skill1);
                    break;
                case SkillType.Skill2:
                    listen.keyCode=GetKeyCodeSkill(SkillType.Skill2);
                    break;
                case SkillType.Skill3:
                    listen.keyCode=GetKeyCodeSkill(SkillType.Skill3);
                    break;
                case SkillType.Dash:
                    listen.keyCode=GetKeyCodeSkill(SkillType.Dash);
                    break;
                case SkillType.Normal:
                    listen.keyCode=GetKeyCodeSkill(SkillType.Normal);
                    break;
            }
        }
    }

    private void Start()
    {
        LoadSkillKeyCode();
        SetKeyCodeText();
    }

    public void SetKeyCodeText()
    {
        foreach (MouseRightListen listen in mouseRightListens)
        {
            switch (listen.keyCode)
            {
                case KeyCodeType.LMB:
                    listen.keyCodeText.text = "LMB";
                    break;
                case KeyCodeType.RMB:
                    listen.keyCodeText.text = "RMB";
                    break;
                case KeyCodeType.Alpha1:
                    listen.keyCodeText.text = "[1]";
                    break;
                case KeyCodeType.Alpha2:
                    listen.keyCodeText.text = "[2]";
                    break;
                case KeyCodeType.Alpha3:
                    listen.keyCodeText.text = "[3]";
                    break;
                case KeyCodeType.None:
                    listen.keyCodeText.text = "";
                    break;
            }
        }
    }
}