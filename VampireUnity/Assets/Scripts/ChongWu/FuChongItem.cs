using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FuChongItem : MonoBehaviour,IPointerUpHandler 
{
    public int FuChongItemIndex;
    public GameObject Suo;

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.LogError(1111);
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (ChongWuController.S.isLeftMouseDown == true)
            {
                switch (ChongWuController.S.FuChongWuTable.Quality)
                {
                    case 1:
                        transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                        transform.Find("Edge").GetComponent<Animator>().Play("WhiteEdge");
                        break;
                    case 2:
                        transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                        transform.Find("Edge").GetComponent<Animator>().Play("WhiteEdge");
                        break;
                    case 3:
                        transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                        transform.Find("Edge").GetComponent<Animator>().Play("WhiteEdge");
                        break;
                    case 4:
                        transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                        transform.Find("Edge").GetComponent<Animator>().Play("WhiteEdge");
                        break;
                    case 5:
                        transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                        transform.Find("Edge").GetComponent<Animator>().Play("WhiteEdge");
                        break;
                    case 6:
                        transform.Find("bg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                        transform.Find("Edge").GetComponent<Animator>().Play("WhiteEdge");
                        break;
                }

                transform.Find("Image").GetComponent<Image>().sprite =
                    ResourcesConfig.GetChongWuSprite(ChongWuController.S.FuChongWuTable.ChongWuType);
            }
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    
    private void OnEnable()
    {
        switch (FuChongItemIndex)
        {
            case 1:
                Suo.gameObject.SetActive(PlayerData.S.level>=20);
                break;
            case 2:
                Suo.gameObject.SetActive(PlayerData.S.level>=40);
                break;
            case 3:
                Suo.gameObject.SetActive(PlayerData.S.level>=60);
                break;
        }
    }
}
