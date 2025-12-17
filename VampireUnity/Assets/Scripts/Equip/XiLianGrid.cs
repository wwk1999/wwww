using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XiLianGrid : MonoBehaviour
{
    [NonSerialized]public EquipTable equipTable;
    public Button imageButton;

    private void Start()
    {
        imageButton.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("XiLian",equipTable);
        });
    }
}
