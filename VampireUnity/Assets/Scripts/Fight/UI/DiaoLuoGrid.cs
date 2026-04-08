using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaoLuoGrid : MonoBehaviour
{
    [NonSerialized] public int PropId;
    public Image Bg;
    public Image icon;

    public void SetItem()
    {
        int quality = PropId % 10;
        icon.sprite = ResourcesConfig.GetPropSprite(PropId);
        switch (quality)
        {
            case 1:
                Bg.sprite = ResourcesConfig.WhiteBg;
                break;
            case 2:
                Bg.sprite = ResourcesConfig.GreenBg;
                break;
            case 3:
                Bg.sprite = ResourcesConfig.BlueBg;
                break;
            case 4:
                Bg.sprite = ResourcesConfig.PurpleBg;
                break;
            case 5:
                Bg.sprite = ResourcesConfig.OrangeBg;
                break;
            case 6:
                Bg.sprite = ResourcesConfig.RedBg;
                break;
        }
    }
}
