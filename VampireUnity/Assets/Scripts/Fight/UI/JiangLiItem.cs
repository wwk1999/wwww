using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum JiangLiType
{
    None,
    LingHun,
    Exp,
    JingCui
}
public class JiangLiItem : MonoBehaviour
{
    [NonSerialized] public JiangLiType type;
    public Image bg;
    public Image image;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;

    public void SetItem(MJLevel mJLevel)
    {
        switch (type)
        {
            case JiangLiType.Exp:
                bg.sprite = ResourcesConfig.BlueBg;
                image.sprite = ResourcesConfig.EXP;
                name.text = "经验值";
                count.text = MJConfig.JiangLiDic[mJLevel].ex.ToString();;
                break;
            case JiangLiType.LingHun:
                bg.sprite = ResourcesConfig.BlueBg;
                image.sprite = ResourcesConfig.LingHun;
                name.text = "灵魂";
                count.text = MJConfig.JiangLiDic[mJLevel].linhun.ToString();;
                break;
            case JiangLiType.JingCui:
                bg.sprite = ResourcesConfig.OrangeBg;
                image.sprite = ResourcesConfig.OrangeJingCui;
                name.text = "传说精粹";
                count.text = MJConfig.JiangLiDic[mJLevel].jingcui.ToString();;
                break;
        }
    }
}