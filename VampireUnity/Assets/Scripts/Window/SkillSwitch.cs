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
                        listen.keyCodeText.text = "";
                    }
                }
                break;
            case KeyCodeType.RMB:
                foreach (MouseRightListen listen in mouseRightListens)
                {
                    if (listen.keyCode == KeyCodeType.RMB)
                    {
                        listen.keyCode=KeyCodeType.None;
                        listen.keyCodeText.text = "";
                    }
                }
                break;
            case KeyCodeType.Alpha1:
                foreach (MouseRightListen listen in mouseRightListens)
                {
                    if (listen.keyCode == KeyCodeType.Alpha1)
                    {
                        listen.keyCode=KeyCodeType.None;
                        listen.keyCodeText.text = "";
                    }
                }
                break;
            case KeyCodeType.Alpha2:
                foreach (MouseRightListen listen in mouseRightListens)
                {
                    if (listen.keyCode == KeyCodeType.Alpha2)
                    {
                        listen.keyCode=KeyCodeType.None;
                        listen.keyCodeText.text = "";
                    }
                }
                break;
            case KeyCodeType.Alpha3:
                foreach (MouseRightListen listen in mouseRightListens)
                {
                    if (listen.keyCode == KeyCodeType.Alpha3)
                    {
                        listen.keyCode=KeyCodeType.None;
                        listen.keyCodeText.text = "";
                    }
                }
                break;
        }
    }
    private void Start()
    {
        LMB.onClick.AddListener(() =>
        {
            ClickMouseRightListen.keyCodeText.text = "[LMB]";
            ResetKeyCode(KeyCodeType.LMB);
            ClickMouseRightListen.keyCode=KeyCodeType.LMB;
            gameObject.SetActive(false);
            mask.SetActive(false);
        });
        RMB.onClick.AddListener(() =>
        {
            ClickMouseRightListen.keyCodeText.text = "[RMB]";
            ResetKeyCode(KeyCodeType.RMB);
            ClickMouseRightListen.keyCode=KeyCodeType.RMB;
            gameObject.SetActive(false);
            mask.SetActive(false);
        });
        Alpha1.onClick.AddListener(() =>
        {
            ClickMouseRightListen.keyCodeText.text = "[1]";
            ResetKeyCode(KeyCodeType.Alpha1);
            ClickMouseRightListen.keyCode=KeyCodeType.Alpha1;
            gameObject.SetActive(false);
            mask.SetActive(false);
        });
        Alpha2.onClick.AddListener(() =>
        {
            ClickMouseRightListen.keyCodeText.text = "[2]";
            ResetKeyCode(KeyCodeType.Alpha2);
            ClickMouseRightListen.keyCode=KeyCodeType.Alpha2;
            gameObject.SetActive(false);
            mask.SetActive(false);
        });
        Alpha3.onClick.AddListener(() =>
        {
            ClickMouseRightListen.keyCodeText.text = "[3]";
            ResetKeyCode(KeyCodeType.Alpha3);
            ClickMouseRightListen.keyCode=KeyCodeType.Alpha3;
            gameObject.SetActive(false);
            mask.SetActive(false);
        });
    }
}
