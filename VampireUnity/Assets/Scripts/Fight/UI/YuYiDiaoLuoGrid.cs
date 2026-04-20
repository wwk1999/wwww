using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YuYiDiaoLuoGrid : MonoBehaviour
{
    [NonSerialized] public ChiBangType ChiBangType;
    public Image Bg;
    public Image icon;

    public void SetItem()
    {
        switch (ChiBangType)
        {
            case ChiBangType.Green1:
                Bg.sprite = ResourcesConfig.GreenBg;
                icon.sprite = ResourcesConfig.Green1;
                break;
            case ChiBangType.Green2:
                Bg.sprite = ResourcesConfig.GreenBg;
                icon.sprite = ResourcesConfig.Green2;
                break;
            case ChiBangType.Green3:
                Bg.sprite = ResourcesConfig.GreenBg;
                icon.sprite = ResourcesConfig.Green3;
                break;
            case ChiBangType.Green4:
                Bg.sprite = ResourcesConfig.GreenBg;
                icon.sprite = ResourcesConfig.Green4;
                break;
            case ChiBangType.Green5:
                Bg.sprite = ResourcesConfig.GreenBg;
                icon.sprite = ResourcesConfig.Green5;
                break;
            case ChiBangType.Green6:
                Bg.sprite = ResourcesConfig.GreenBg;
                icon.sprite = ResourcesConfig.Green6;
                break;
            
            
            case ChiBangType.Blue1:
                Bg.sprite = ResourcesConfig.BlueBg;
                icon.sprite = ResourcesConfig.Blue1;
                break;
            case ChiBangType.Blue2:
                Bg.sprite = ResourcesConfig.BlueBg;
                icon.sprite = ResourcesConfig.Blue2;
                break;
            case ChiBangType.Blue3:
                Bg.sprite = ResourcesConfig.BlueBg;
                icon.sprite = ResourcesConfig.Blue3;
                break;
            case ChiBangType.Blue4:
                Bg.sprite = ResourcesConfig.BlueBg;
                icon.sprite = ResourcesConfig.Blue4;
                break;
            case ChiBangType.Blue5:
                Bg.sprite = ResourcesConfig.BlueBg;
                icon.sprite = ResourcesConfig.Blue5;
                break;
            case ChiBangType.Blue6:
                Bg.sprite = ResourcesConfig.BlueBg;
                icon.sprite = ResourcesConfig.Blue6;
                break;
            
            case ChiBangType.Blue7:
                Bg.sprite = ResourcesConfig.BlueBg;
                icon.sprite = ResourcesConfig.Blue7;
                break;
            
            case ChiBangType.Blue8:
                Bg.sprite = ResourcesConfig.BlueBg;
                icon.sprite = ResourcesConfig.Blue8;
                break;
            
            
            
            case ChiBangType.Purple1:
                Bg.sprite = ResourcesConfig.PurpleBg;
                icon.sprite = ResourcesConfig.Purple1;
                break;
            case ChiBangType.Purple2:
                Bg.sprite = ResourcesConfig.PurpleBg;
                icon.sprite = ResourcesConfig.Purple2;
                break;
            case ChiBangType.Purple3:
                Bg.sprite = ResourcesConfig.PurpleBg;
                icon.sprite = ResourcesConfig.Purple3;
                break;
            case ChiBangType.Purple4:
                Bg.sprite = ResourcesConfig.PurpleBg;
                icon.sprite = ResourcesConfig.Purple4;
                break;
            case ChiBangType.Purple5:
                Bg.sprite = ResourcesConfig.PurpleBg;
                icon.sprite = ResourcesConfig.Purple5;
                break;
            case ChiBangType.Purple6:
                Bg.sprite = ResourcesConfig.PurpleBg;
                icon.sprite = ResourcesConfig.Purple6;
                break;
            
            case ChiBangType.Purple7:
                Bg.sprite = ResourcesConfig.PurpleBg;
                icon.sprite = ResourcesConfig.Purple7;
                break;
            
            
            
            
            
            case ChiBangType.Orange1:
                Bg.sprite = ResourcesConfig.OrangeBg;
                icon.sprite = ResourcesConfig.Orange1;
                break;
            case ChiBangType.Orange2:
                Bg.sprite = ResourcesConfig.OrangeBg;
                icon.sprite = ResourcesConfig.Orange2;
                break;
            case ChiBangType.Orange3:
                Bg.sprite = ResourcesConfig.OrangeBg;
                icon.sprite = ResourcesConfig.Orange3;
                break;
            
            
            
            case ChiBangType.Red1:
                Bg.sprite = ResourcesConfig.RedBg;
                icon.sprite = ResourcesConfig.Red1;
                break;
           
        }
    }
}
