using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ChongWuListItem:MonoBehaviour
{
    public Image Image;
    public TextMeshProUGUI Level;
    public Image QualityIcon;
    public Image XX1;
    public Image XX2;
    public Image XX3;
    public Image XX4;
    public Image XX5;


    public void SetChongWuListItem(ChongWuTable info)
    {
        Image.sprite = ResourcesConfig.GetChongWuSprite(info.ChongWuType);
        Level.text = "Lv. "+info.Level;
        switch (info.Quality)
        {
            case 1:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality1;
                break;
            case 2:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality2;
                break;
            case 3:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality3;
                break;
            case 4:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality4;
                break;
            case 5:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality5;
                break;
            case 6:
                QualityIcon.sprite = ResourcesConfig.ChongWuQuality6;
                break;
        }

        if (info.XingJi >= 1)
        {
            XX1.sprite = ResourcesConfig.XXLiang;
        }
        else
        {
            XX1.sprite = ResourcesConfig.XXAn;
        }
        
        if (info.XingJi >= 2)
        {
            XX2.sprite = ResourcesConfig.XXLiang;
        }
        else
        {
            XX2.sprite = ResourcesConfig.XXAn;
        }
        
        if (info.XingJi >= 3)
        {
            XX3.sprite = ResourcesConfig.XXLiang;
        }
        else
        {
            XX3.sprite = ResourcesConfig.XXAn;
        }
        
        if (info.XingJi >= 4)
        {
            XX4.sprite = ResourcesConfig.XXLiang;
        }
        else
        {
            XX4.sprite = ResourcesConfig.XXAn;
        }
        
        if (info.XingJi >= 5)
        {
            XX5.sprite = ResourcesConfig.XXLiang;
        }
        else
        {
            XX5.sprite = ResourcesConfig.XXAn;
        }
    }
}
