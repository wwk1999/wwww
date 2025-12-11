using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillSwitch : MonoBehaviour
{
    [NonSerialized]public List<MouseRightListen>  mouseRightListens = new List<MouseRightListen>();
    public Button LMB;
    public Button RMB;
    public Button Alpha1;
    public Button Alpha2;
    public Button Alpha3;
    public Button Auto;
    public GameObject mask;

    
    [NonSerialized]public MouseRightListen ClickMouseRightListen;


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

    public void SaveSkillKeyCode()
    {
        SkillData.S.LMB = SkillType.None;
        SkillData.S.RMB = SkillType.None;
        SkillData.S.Alpha1 = SkillType.None;
        SkillData.S.Alpha2 = SkillType.None;
        SkillData.S.Alpha3 = SkillType.None;

        foreach (MouseRightListen listen in mouseRightListens)
        {
            switch (listen.keyCode)
            {
                case  KeyCodeType.LMB:
                    SkillData.S.LMB = listen.buttonType;
                    break;
                case  KeyCodeType.RMB:
                    SkillData.S.RMB = listen.buttonType;
                    break;
                case  KeyCodeType.Alpha1:
                    SkillData.S.Alpha1 = listen.buttonType;
                    break;
                case  KeyCodeType.Alpha2:
                    SkillData.S.Alpha2 = listen.buttonType;
                    break;
                case  KeyCodeType.Alpha3:
                    SkillData.S.Alpha3 = listen.buttonType;
                    break;
            }
        }
    }
    
    public void ResetKeyCode(KeyCodeType keyCodeType)
    {
        switch (keyCodeType)
        {
            case KeyCodeType.LMB:
                foreach (MouseRightListen listen in mouseRightListens)
                {
                    if (listen.keyCode == KeyCodeType.LMB)
                    {
                        listen.keyCode=KeyCodeType.None;
                    }
                }
                break;
            case KeyCodeType.RMB:
                foreach (MouseRightListen listen in mouseRightListens)
                {
                    if (listen.keyCode == KeyCodeType.RMB)
                    {
                        listen.keyCode=KeyCodeType.None;
                    }
                }
                break;
            case KeyCodeType.Alpha1:
                foreach (MouseRightListen listen in mouseRightListens)
                {
                    if (listen.keyCode == KeyCodeType.Alpha1)
                    {
                        listen.keyCode=KeyCodeType.None;
                    }
                }
                break;
            case KeyCodeType.Alpha2:
                foreach (MouseRightListen listen in mouseRightListens)
                {
                    if (listen.keyCode == KeyCodeType.Alpha2)
                    {
                        listen.keyCode=KeyCodeType.None;
                    }
                }
                break;
            case KeyCodeType.Alpha3:
                foreach (MouseRightListen listen in mouseRightListens)
                {
                    if (listen.keyCode == KeyCodeType.Alpha3)
                    {
                        listen.keyCode=KeyCodeType.None;
                    }
                }
                break;
        }
    }
    private void Start()
    {
        LMB.onClick.AddListener(() =>
        {
            ResetKeyCode(KeyCodeType.LMB);
            ClickMouseRightListen.keyCode=KeyCodeType.LMB;
            SetKeyCodeText();
            SaveSkillKeyCode();
            StoreController.S.SaveStoreData();
            gameObject.SetActive(false);
            mask.SetActive(false);
        });
        RMB.onClick.AddListener(() =>
        {
            ResetKeyCode(KeyCodeType.RMB);
            ClickMouseRightListen.keyCode=KeyCodeType.RMB;
            SetKeyCodeText();
            SaveSkillKeyCode();
            StoreController.S.SaveStoreData();
            gameObject.SetActive(false);
            mask.SetActive(false);
        });
        Alpha1.onClick.AddListener(() =>
        {
            ResetKeyCode(KeyCodeType.Alpha1);
            ClickMouseRightListen.keyCode=KeyCodeType.Alpha1;
            SetKeyCodeText();
            SaveSkillKeyCode();
            StoreController.S.SaveStoreData();
            gameObject.SetActive(false);
            mask.SetActive(false);
        });
        Alpha2.onClick.AddListener(() =>
        {
            ResetKeyCode(KeyCodeType.Alpha2);
            ClickMouseRightListen.keyCode=KeyCodeType.Alpha2;
            SetKeyCodeText();
            SaveSkillKeyCode();
            StoreController.S.SaveStoreData();
            gameObject.SetActive(false);
            mask.SetActive(false);
        });
        Alpha3.onClick.AddListener(() =>
        {
            ResetKeyCode(KeyCodeType.Alpha3);
            ClickMouseRightListen.keyCode=KeyCodeType.Alpha3;
            SetKeyCodeText();
            SaveSkillKeyCode();
            StoreController.S.SaveStoreData();
            gameObject.SetActive(false);
            mask.SetActive(false);
        });
    }
}
