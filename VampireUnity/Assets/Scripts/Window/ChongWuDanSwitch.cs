using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChongWuDanSwitch : MonoBehaviour
{
    [NonSerialized]public int propType;
    public Button DaKaiButton;
    public Button AllDaKaiButton;

    private void Start()
    {
        DaKaiButton.onClick.AddListener(() =>
        {
            if (propType == 1603)
            {
                int quality = 0;
                float random = Random.Range(0, 1.0f);
                if (random <= 0.4f)
                {
                    quality = 1;
                }
                else if(random <= 0.7f&&random>0.4f)
                {
                    quality = 2;
                }else if(random <= 0.9f&&random>0.7f)
                {
                    quality = 3;
                }else if(random <= 1.0f&&random>0.9f)
                {
                    quality = 4;
                }

                ChongWuType chongWuType = ChongWuType.None;
                switch (quality)
                {
                    case 1:
                        chongWuType = ChongWuConfig.GetChongWuType(1);
                        break;
                    case 2:
                        chongWuType = ChongWuConfig.GetChongWuType(2);
                        break;
                    case 3:
                        chongWuType = ChongWuConfig.GetChongWuType(3);
                        break;
                    case 4:
                        chongWuType = ChongWuConfig.GetChongWuType(4);
                        break;
                }
                ChongWuTable chongWuTable = ChongWuController.S.GetOriginChongWuTable(chongWuType);
                PlayerData.S.ChongWuList.Add(chongWuTable);
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"恭喜获得宠物："+chongWuTable.Name);
            }else if (propType == 1605)
            {
                
            }
        });
    }
}
