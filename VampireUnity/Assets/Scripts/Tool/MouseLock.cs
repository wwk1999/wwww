using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseLock : MonoBehaviour, IPointerClickHandler
{
    public BagGrid bagGrid;

    public void RefreshLock()
    {
        EquipTable equipTable = bagGrid.tableBase as EquipTable;
        if (equipTable.Lock)
        {
            bagGrid.Lock.gameObject.SetActive(true);
        }
        else
        {
            bagGrid.Lock.gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            EquipTable equipTable = bagGrid.tableBase as EquipTable;
            equipTable.Lock=!equipTable.Lock;
            RefreshLock();
        }
    }
}
