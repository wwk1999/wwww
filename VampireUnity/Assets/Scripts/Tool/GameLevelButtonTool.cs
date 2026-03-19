using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameLevelButtonTool : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Sprite Liang;
    public Sprite An;

    public float LiangScale;
    public float AnScale;
    public bool Down = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = Liang;
        transform.localScale=new Vector3(LiangScale,LiangScale,LiangScale);
        if (Down)
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition =
                new Vector2(rectTransform.anchoredPosition.x-5, rectTransform.anchoredPosition.y - 10);
        }
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = An;
        transform.localScale=new Vector3(AnScale,AnScale,AnScale);
        if (Down)
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition =
                new Vector2(rectTransform.anchoredPosition.x+5, rectTransform.anchoredPosition.y + 10);
        }
    }
}
