using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XiangQianBaoShiGrid : MonoBehaviour
{
    [NonSerialized]public PropTable propTable;
    public Button imageButton;
    public GameObject Gou;
    public CanvasGroup  canvasGroup;
    public TextMeshProUGUI Count;

    private void Start()
    {
        imageButton.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("XiangQianBaoShi",this);
        });
    }
}
