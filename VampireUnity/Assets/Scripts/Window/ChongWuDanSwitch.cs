using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChongWuDanSwitch : MonoBehaviour
{
    [NonSerialized]public int propType;
    [NonSerialized]public PropGrid propGrid;
    public Button DaKaiButton;
    public Button AllDaKaiButton;

    private void Start()
    {
        AllDaKaiButton.onClick.AddListener(() =>
        {
             if (propType == 1603)
            {
                for (int i = 0; i < BagController.S.PropList[1603].Count; i++)
                {

                    int quality = 0;
                    float random = Random.Range(0, 1.0f);
                    if (random <= 0.4f)
                    {
                        quality = 1;
                    }
                    else if (random <= 0.7f && random > 0.4f)
                    {
                        quality = 2;
                    }
                    else if (random <= 0.9f && random > 0.7f)
                    {
                        quality = 3;
                    }
                    else if (random <= 1.0f && random > 0.9f)
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
                    PlayerData.S.ChongWuDic[chongWuTable.ChongWuId]=chongWuTable;
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "恭喜获得宠物：" + chongWuTable.Name);
                }
                BagController.S.PropList[1603].Count=0;
                ObserverModuleManager.S.SendEvent("HideChongWuDanMask");
                propGrid.SetCount(BagController.S.PropList[1603].Count);
                StoreController.S.SaveStoreData();
                Destroy(gameObject);
            }else if (propType == 1605)
            {
                for (int i = 0; i < BagController.S.PropList[1605].Count; i++)
                {

                    int quality = 0;
                    float random = Random.Range(0, 1.0f);
                    if (random <= 0.2f)
                    {
                        quality = 1;
                    }
                    else if (random <= 0.45f && random > 0.2f)
                    {
                        quality = 2;
                    }
                    else if (random <= 0.75f && random > 0.45f)
                    {
                        quality = 3;
                    }
                    else if (random <= 0.95f && random > 0.75f)
                    {
                        quality = 4;
                    }
                    else if (random <= 1.0f && random > 0.95f)
                    {
                        quality = 5;
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
                        case 5:
                            chongWuType = ChongWuConfig.GetChongWuType(5);
                            break;
                    }

                    ChongWuTable chongWuTable = ChongWuController.S.GetOriginChongWuTable(chongWuType);
                    PlayerData.S.ChongWuDic[chongWuTable.ChongWuId]=chongWuTable;
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "恭喜获得宠物：" + chongWuTable.Name);
                }
                ObserverModuleManager.S.SendEvent("HideChongWuDanMask");
                BagController.S.PropList[1605].Count=0;
                propGrid.SetCount(BagController.S.PropList[1605].Count);
                StoreController.S.SaveStoreData();
                Destroy(gameObject);
            }
        });
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
                PlayerData.S.ChongWuDic[chongWuTable.ChongWuId]=chongWuTable;
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"恭喜获得宠物："+chongWuTable.Name);
                BagController.S.PropList[1603].Count--;
                ObserverModuleManager.S.SendEvent("HideChongWuDanMask");
                propGrid.SetCount(BagController.S.PropList[1603].Count);
                StoreController.S.SaveStoreData();
                Destroy(gameObject);
            }else if (propType == 1605)
            {
                int quality = 0;
                float random = Random.Range(0, 1.0f);
                if (random <= 0.2f)
                {
                    quality = 1;
                }
                else if(random <= 0.45f&&random>0.2f)
                {
                    quality = 2;
                }else if(random <= 0.75f&&random>0.45f)
                {
                    quality = 3;
                }else if(random <= 0.95f&&random>0.75f)
                {
                    quality = 4;
                }else if(random <= 1.0f&&random>0.95f)
                {
                    quality = 5;
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
                    case 5:
                        chongWuType = ChongWuConfig.GetChongWuType(5);
                        break;
                }
                ChongWuTable chongWuTable = ChongWuController.S.GetOriginChongWuTable(chongWuType);
                PlayerData.S.ChongWuDic[chongWuTable.ChongWuId]=chongWuTable;
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"恭喜获得宠物："+chongWuTable.Name);
                BagController.S.PropList[1605].Count--;
                ObserverModuleManager.S.SendEvent("HideChongWuDanMask");
                propGrid.SetCount(BagController.S.PropList[1605].Count);
                StoreController.S.SaveStoreData();
                Destroy(gameObject);
            }
        });
    }
}
