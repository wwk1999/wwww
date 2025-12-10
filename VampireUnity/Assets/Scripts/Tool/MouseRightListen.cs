using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseRightListen : MonoBehaviour, IPointerClickHandler
{
    public int buttonType = 0;
    
    public RectTransform canvasRect; // Canvas 的 RectTransform
    private RectTransform _skillSwitch;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_skillSwitch != null)
            {
                Destroy(_skillSwitch.gameObject);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (_skillSwitch != null)
            {
                Destroy(_skillSwitch.gameObject);
            }
            _skillSwitch=Instantiate(Resources.Load("Prefabs/Window/SkillSwitch"),transform.parent).GetComponent<RectTransform>();
            _skillSwitch.SetAsLastSibling();
           Vector2 localPoint;
           var cam = canvasRect.GetComponentInParent<Canvas>().renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main;
           
           if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, cam, out localPoint))
           {
               // localPoint 是相对 canvas pivot 的局部坐标
               _skillSwitch.anchoredPosition = new Vector2(localPoint.x+_skillSwitch.sizeDelta.x/2, localPoint.y-_skillSwitch.sizeDelta.y/2);
           }
        }
    }
}