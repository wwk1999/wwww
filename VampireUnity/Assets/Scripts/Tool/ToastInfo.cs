using System.Collections;
using System.Collections.Generic;
using Mysql;
using TMPro;
using Tool;
using UnityEngine;
using UnityEngine.UI;

public class ToastInfo : MonoBehaviour
{
    public TextMeshProUGUI equipNameText;
    public Text countText;
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
        if (equipTable != null)
        {
            switch (equipTable.Quality)
            {
                case 1:
                    equipNameText.color = Color.white;
                    break;
                case 2:
                    equipNameText.color = Color.green;
                    break;
                case 3:
                    equipNameText.color = Color.blue;
                    break;
                case 4:
                    equipNameText.color = new Color32(241, 20, 231, 255);
                    break;
                case 5:
                    equipNameText.color = new Color(255,140,0,255);
                    break;
            }

            if (equipTable.OrangeEntry1 == EntryConfig.OrangeEntry.None)
            {
                equipNameText.text = EquipName.EquipNameDic[equipTable.EquipName];
            }
            else
            {
                equipNameText.text = EntryConfig.OrangeEntryNameDic[equipTable.OrangeEntry1];
            }
        }
    }
    
    public void SetPropToast(PropTable propTable)
    {
        if (propTable != null)
        {
            if (propTable.PropType == PropConfig.PropType.ShenHuaCaiLiao)
            {
                equipNameText.color = new Color(255,140,0,255);
            }
            else
            {
                switch (propTable.Quality)
                {
                    case 1:
                        equipNameText.color = Color.white;
                        break;
                    case 2:
                        equipNameText.color = Color.green;
                        break;
                    case 3:
                        equipNameText.color = Color.blue;
                        break;
                    case 4:
                        equipNameText.color = new Color32(241, 20, 231, 255);
                        break;
                    case 5:
                        equipNameText.color = new Color(255, 140, 0, 255);
                        break;
                }
            }

            equipNameText.text = EquipName.EquipNameDic[propTable.EquipName];
        }
    }
}
