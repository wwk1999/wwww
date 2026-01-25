using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XiangQianBaoShiGrid : MonoBehaviour
{
    [NonSerialized]public PropTable propTable;
    public Button imageButton;

    private void Start()
    {
        imageButton.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("XiangQianBaoShi",propTable);
        });
    }
}
