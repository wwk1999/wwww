using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class TitleWindow : MonoBehaviour
{
    public GameObject TitleListContent;
    public Button ExitButton;


    private void Start()
    {
        ExitButton.onClick.AddListener(() =>
        {
            WindowController.S.TitleWindow.gameObject.SetActive(false);
        });
    }

    private void OnEnable()
    {
        foreach (Transform item in TitleListContent.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic)
        {
            TitleItem titleitem=Instantiate(Resources.Load<GameObject>("Prefabs/Title/TitleItem"),TitleListContent.transform).GetComponent<TitleItem>();
            titleitem.SetTitle(item.Key,true);
        }
    }
}
