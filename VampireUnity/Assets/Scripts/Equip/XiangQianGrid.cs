using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XiangQianGrid : MonoBehaviour
{
    [NonSerialized]public EquipTable equipTable;
    public Button imageButton;

    private void Start()
    {
        imageButton.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("XiangQian",equipTable);
        });
    }
}
