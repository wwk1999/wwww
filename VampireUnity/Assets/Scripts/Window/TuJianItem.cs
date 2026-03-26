using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TuJianItem : MonoBehaviour
{
    [NonSerialized]public ChongWuConfig.ChongWuTuJianType type;
    public TextMeshProUGUI Name1;
    public TextMeshProUGUI Name2;
    public TextMeshProUGUI Name3;
    public TextMeshProUGUI Name4;
    public TextMeshProUGUI Name5;
    public TextMeshProUGUI Name6;

    public Button bgbutton;
    
    public void SetChongWuTuJianItem()
    {
        bgbutton.onClick.RemoveAllListeners();
        bgbutton.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TuJianClick",type);
        });
        Name1.gameObject.SetActive(false);
        Name2.gameObject.SetActive(false);
        Name3.gameObject.SetActive(false);
        Name4.gameObject.SetActive(false);
        Name5.gameObject.SetActive(false);
        Name6.gameObject.SetActive(false);
        int quality=ChongWuConfig.TuJianQualityDic[type];
        switch (quality)
        {
            case 1:
                Name1.gameObject.SetActive(true);
                Name1.text = ChongWuConfig.TuJianNameDic[type];
                break;
            case 2:
                Name2.gameObject.SetActive(true);
                Name2.text = ChongWuConfig.TuJianNameDic[type];
                break;
            case 3:
                Name3.gameObject.SetActive(true);
                Name3.text = ChongWuConfig.TuJianNameDic[type];
                break;
            case 4:
                Name4.gameObject.SetActive(true);
                Name4.text = ChongWuConfig.TuJianNameDic[type];
                break;
            case 5:
                Name5.gameObject.SetActive(true);
                Name5.text = ChongWuConfig.TuJianNameDic[type];
                break;
            case 6:
                Name6.gameObject.SetActive(true);
                Name6.text = ChongWuConfig.TuJianNameDic[type];
                break;
        }
    }
}
