using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameLevelButtonTool : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Sprite Liang;
    public Sprite An;


    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = Liang;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = An;
    }
}
