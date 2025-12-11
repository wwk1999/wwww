using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MaskMouseRight :  MonoBehaviour, IPointerClickHandler
{
    public GameObject skillSwitchObj;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right||eventData.button == PointerEventData.InputButton.Left)
        {
            skillSwitchObj.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
