using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeButton  : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject prefab;
    public void OnPointerEnter(PointerEventData eventData)
    {
        prefab.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        prefab.SetActive(false);
    }
}
