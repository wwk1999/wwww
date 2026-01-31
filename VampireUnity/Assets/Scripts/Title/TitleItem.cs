using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleItem : MonoBehaviour
{
    public TextMeshProUGUI WhiteName;
    public TextMeshProUGUI GreenName;
    public TextMeshProUGUI BlueName;
    public TextMeshProUGUI PurpleName;
    public TextMeshProUGUI OrangeName;
    public TextMeshProUGUI RedName;


    public void SetTitle(int Quality, string Title)
    {
        WhiteName.gameObject.SetActive(false);
        GreenName.gameObject.SetActive(false);
        BlueName.gameObject.SetActive(false);
        PurpleName.gameObject.SetActive(false);
        OrangeName.gameObject.SetActive(false);
        RedName.gameObject.SetActive(false);
        switch (Quality)
        {
            case 1:
                WhiteName.gameObject.SetActive(true);
                WhiteName.text = Title;
                break;
            case 2:
                GreenName.gameObject.SetActive(true);
                GreenName.text = Title;
                break;
            case 3:
                BlueName.gameObject.SetActive(true);
                BlueName.text = Title;
                break;
            case 4:
                PurpleName.gameObject.SetActive(true);
                PurpleName.text = Title;
                break;
            case 5:
                OrangeName.gameObject.SetActive(true);
                OrangeName.text = Title;
                break;
            case 6:
                RedName.gameObject.SetActive(true);
                RedName.text = Title;
                break;
        }
    }
}
