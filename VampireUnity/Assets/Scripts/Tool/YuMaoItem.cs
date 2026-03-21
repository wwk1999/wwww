using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class YuMaoItem : MonoBehaviour
{
    public Image bg;
    public Image image;
    public Animator edge;
    public TextMeshProUGUI count;
    public Button button;
    [NonSerialized] public int propId;

    public void SetYuMao()
    {
        button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("YuMaoClick",propId);
        });
        switch (propId%10)
        {
            case 1:
                bg.sprite = ResourcesConfig.WhiteBg;
                image.sprite = ResourcesConfig.WhiteChiBang;
                edge.Play("WhiteEdge");
                count.text=BagController.S.PropList[propId].Count.ToString();
                break;
            case 2:
                bg.sprite = ResourcesConfig.GreenBg;
                image.sprite = ResourcesConfig.GreenChiBang;
                edge.Play("GreenEdge");
                count.text=BagController.S.PropList[propId].Count.ToString();
                break;
            case 3:
                bg.sprite = ResourcesConfig.BlueBg;
                image.sprite = ResourcesConfig.BlueChiBang;
                edge.Play("BlueEdge");
                count.text=BagController.S.PropList[propId].Count.ToString();
                break;
            case 4:
                bg.sprite = ResourcesConfig.PurpleBg;
                image.sprite = ResourcesConfig.PurpleChiBang;
                edge.Play("PurpleEdge");
                count.text=BagController.S.PropList[propId].Count.ToString();
                break;
            case 5:
                bg.sprite = ResourcesConfig.OrangeBg;
                image.sprite = ResourcesConfig.OrangeChiBang;
                edge.Play("OrangeEdge");
                count.text=BagController.S.PropList[propId].Count.ToString();
                break;
            case 6:
                bg.sprite = ResourcesConfig.RedBg;
                image.sprite = ResourcesConfig.RedChiBang;
                edge.Play("RedEdge");
                count.text=BagController.S.PropList[propId].Count.ToString();
                break;
        }
    }
}
