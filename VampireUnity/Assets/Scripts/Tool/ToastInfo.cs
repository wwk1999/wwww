using System.Collections;
using System.Collections.Generic;
using Config;
using Mysql;
using Prop.BaoShi;
using TMPro;
using Tool;
using UnityEngine;
using UnityEngine.UI;

public class ToastInfo : MonoBehaviour
{
    public TextMeshProUGUI redName;
    public TextMeshProUGUI purpleName;
    public TextMeshProUGUI orangeName;
    public TextMeshProUGUI blueName;
    public TextMeshProUGUI greenName;
    public TextMeshProUGUI whiteName;

    public Image bg;
    public Image image;

    public Animation toastAnim;

    void Start()
    {
        if (toastAnim != null)
        {
            toastAnim.Play("ToastInfoAnim");
        }

        StartCoroutine(DelayDestroy());
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

    public void SetEquipToast(EquipTable equipTable)
    {
        redName.gameObject.SetActive(false);
        orangeName.gameObject.SetActive(false);
        purpleName.gameObject.SetActive(false);
        blueName.gameObject.SetActive(false);
        greenName.gameObject.SetActive(false);
        whiteName.gameObject.SetActive(false);

        if (equipTable != null)
        {
            switch (equipTable.Quality)
            {
                case 1:
                    whiteName.gameObject.SetActive(true);
                    bg.sprite = ResourcesConfig.WhiteBg;
                    if (equipTable.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                    {
                        whiteName.text = EquipName.EquipNameDic[equipTable.EquipName];
                    }
                    else
                    {
                        whiteName.text = EntryConfig.OrangeEntryNameDic[equipTable.OrangeEntry1];
                    }

                    break;
                case 2:
                    greenName.gameObject.SetActive(true);
                    bg.sprite = ResourcesConfig.GreenBg;
                    if (equipTable.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                    {
                        greenName.text = EquipName.EquipNameDic[equipTable.EquipName];
                    }
                    else
                    {
                        greenName.text = EntryConfig.OrangeEntryNameDic[equipTable.OrangeEntry1];
                    }

                    break;
                case 3:
                    blueName.gameObject.SetActive(true);
                    bg.sprite = ResourcesConfig.BlueBg;
                    if (equipTable.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                    {
                        blueName.text = EquipName.EquipNameDic[equipTable.EquipName];
                    }
                    else
                    {
                        blueName.text = EntryConfig.OrangeEntryNameDic[equipTable.OrangeEntry1];
                    }

                    break;
                case 4:
                    purpleName.gameObject.SetActive(true);
                    bg.sprite = ResourcesConfig.PurpleBg;
                    if (equipTable.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                    {
                        purpleName.text = EquipName.EquipNameDic[equipTable.EquipName];
                    }
                    else
                    {
                        purpleName.text = EntryConfig.OrangeEntryNameDic[equipTable.OrangeEntry1];
                    }

                    break;
                case 5:
                    orangeName.gameObject.SetActive(true);
                    bg.sprite = ResourcesConfig.OrangeBg;
                    if (equipTable.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                    {
                        orangeName.text = EquipName.EquipNameDic[equipTable.EquipName];
                    }
                    else
                    {
                        orangeName.text = EntryConfig.OrangeEntryNameDic[equipTable.OrangeEntry1];
                    }

                    break;
                case 6:
                    redName.gameObject.SetActive(true);
                    bg.sprite = ResourcesConfig.RedBg;
                    if (equipTable.OrangeEntry1 == EntryConfig.OrangeEntry.None)
                    {
                        redName.text = EquipName.EquipNameDic[equipTable.EquipName];
                    }
                    else
                    {
                        redName.text = EntryConfig.OrangeEntryNameDic[equipTable.OrangeEntry1];
                    }

                    break;
            }

            image.sprite = ResourcesConfig.GetEquipSprite(equipTable);
        }
    }

    public void SetPropToast(PropTable propTable)
    {
        redName.gameObject.SetActive(false);
        orangeName.gameObject.SetActive(false);
        purpleName.gameObject.SetActive(false);
        blueName.gameObject.SetActive(false);
        greenName.gameObject.SetActive(false);
        whiteName.gameObject.SetActive(false);

        if (propTable != null)
        {
            if (propTable.ChiBangType != ChiBangType.None)
            {
                image.sprite = ChiBangConfig.GetChiBangSprite(propTable.ChiBangType);
                int quality = ChiBangConfig.GetChiBangQuality(propTable.ChiBangType);
                switch (quality)
                {
                    case 2:
                        greenName.gameObject.SetActive(true);
                        bg.sprite = ResourcesConfig.GreenBg;
                        greenName.text = ChiBangConfig.GetChiBangName(propTable.ChiBangType);
                        break;
                    case 3:
                        blueName.gameObject.SetActive(true);
                        bg.sprite = ResourcesConfig.BlueBg;
                        blueName.text = ChiBangConfig.GetChiBangName(propTable.ChiBangType);
                        break;
                    case 4:
                        purpleName.gameObject.SetActive(true);
                        bg.sprite = ResourcesConfig.PurpleBg;
                        purpleName.text = ChiBangConfig.GetChiBangName(propTable.ChiBangType);
                        break;
                    case 5:
                        orangeName.gameObject.SetActive(true);
                        bg.sprite = ResourcesConfig.OrangeBg;
                        orangeName.text = ChiBangConfig.GetChiBangName(propTable.ChiBangType);
                        break;
                    case 6:
                        redName.gameObject.SetActive(true);
                        bg.sprite = ResourcesConfig.RedBg;
                        redName.text = ChiBangConfig.GetChiBangName(propTable.ChiBangType);
                        break;
                }
            }
            else
            {
                switch (propTable.Quality)
                {
                    case 1:
                        whiteName.gameObject.SetActive(true);
                        bg.sprite = ResourcesConfig.WhiteBg;
                        whiteName.text = EquipName.EquipNameDic[propTable.EquipName];
                        break;
                    case 2:
                        greenName.gameObject.SetActive(true);
                        bg.sprite = ResourcesConfig.GreenBg;
                        greenName.text = EquipName.EquipNameDic[propTable.EquipName];

                        break;
                    case 3:
                        blueName.gameObject.SetActive(true);
                        bg.sprite = ResourcesConfig.BlueBg;
                        blueName.text = EquipName.EquipNameDic[propTable.EquipName];
                        break;
                    case 4:
                        purpleName.gameObject.SetActive(true);
                        bg.sprite = ResourcesConfig.PurpleBg;
                        purpleName.text = EquipName.EquipNameDic[propTable.EquipName];
                        break;
                    case 5:
                        orangeName.gameObject.SetActive(true);
                        bg.sprite = ResourcesConfig.OrangeBg;
                        orangeName.text = EquipName.EquipNameDic[propTable.EquipName];
                        break;
                    case 6:
                        redName.gameObject.SetActive(true);
                        bg.sprite = ResourcesConfig.RedBg;
                        redName.text = EquipName.EquipNameDic[propTable.EquipName];
                        break;
                }

                if (propTable.PropType == PropConfig.PropType.HH || propTable.PropType == PropConfig.PropType.HA ||
                    propTable.PropType == PropConfig.PropType.HC || propTable.PropType == PropConfig.PropType.HD ||
                    propTable.PropType == PropConfig.PropType.AA || propTable.PropType == PropConfig.PropType.AC ||
                    propTable.PropType == PropConfig.PropType.AD || propTable.PropType == PropConfig.PropType.CC ||
                    propTable.PropType == PropConfig.PropType.DD || propTable.PropType == PropConfig.PropType.CD)
                {
                    BaoShiInfo baoshi = new BaoShiInfo();
                    baoshi.BaoShiType = (BaoShiType)(propTable.PropType - 5);
                    baoshi.Quality = propTable.Quality;
                    image.sprite = ResourcesConfig.GetBaoShiSprite(baoshi);
                }
                else
                {
                    image.sprite = ResourcesConfig.GetPropSprite(propTable);
                }
            }
        }

    }
}
