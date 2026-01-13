using System.Collections;
using System.Collections.Generic;
using Mysql;
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
    public Animator anim;

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
                    anim.Play("WhiteEdge");
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
                    anim.Play("GreenEdge");
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
                    anim.Play("BlueEdge");
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
                    anim.Play("PurpleEdge");
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
                    anim.Play("OrangeEdge");
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
                    anim.Play("RedEdge");
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
            switch (propTable.Quality)
            {
                case 1:
                    whiteName.gameObject.SetActive(true);
                    bg.sprite = ResourcesConfig.WhiteBg;
                    anim.Play("WhiteEdge");
                    whiteName.text = EquipName.EquipNameDic[propTable.EquipName];
                    break;
                case 2:
                    greenName.gameObject.SetActive(true);
                    bg.sprite = ResourcesConfig.GreenBg;
                    anim.Play("GreenEdge");
                    greenName.text = EquipName.EquipNameDic[propTable.EquipName];

                    break;
                case 3:
                    blueName.gameObject.SetActive(true);
                    bg.sprite = ResourcesConfig.BlueBg;
                    anim.Play("BlueEdge");
                    blueName.text = EquipName.EquipNameDic[propTable.EquipName];
                    break;
                case 4:
                    purpleName.gameObject.SetActive(true);
                    bg.sprite = ResourcesConfig.PurpleBg;
                    anim.Play("PurpleEdge");
                    purpleName.text = EquipName.EquipNameDic[propTable.EquipName];
                    break;
                case 5:
                    orangeName.gameObject.SetActive(true);
                    bg.sprite = ResourcesConfig.OrangeBg;
                    anim.Play("OrangeEdge");
                    orangeName.text = EquipName.EquipNameDic[propTable.EquipName];
                    break;
                case 6:
                    redName.gameObject.SetActive(true);
                    bg.sprite = ResourcesConfig.RedBg;
                    anim.Play("RedEdge");
                    redName.text = EquipName.EquipNameDic[propTable.EquipName];
                    break;
            }

            image.sprite = ResourcesConfig.GetPropSprite(propTable);
        }

    }
}
