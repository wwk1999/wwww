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
    
    public GameObject Level5Info;
    public GameObject Level15Info;
    public GameObject Level30Info;
    public GameObject Level50Info;
    public GameObject Level75Info;
    public GameObject Level100Info;

    public GameObject MonsterCount1Info;
    public GameObject MonsterCount2Info;
    public GameObject MonsterCount3Info;
    public GameObject MonsterCount4Info;
    public GameObject MonsterCount5Info;
    public GameObject MonsterCount6Info;
    
    public GameObject LinHun;
    public GameObject BaoShi;
    public GameObject HunQi3;
    public GameObject HunQi4;
    public GameObject HunQi5;
    public GameObject GuanKa3;
    public GameObject GuanKa4;
    public GameObject GuanKa5;
    public GameObject ChiBang4;
    public GameObject ChiBang5;
    public GameObject DiaoLuo;


    public Button InstallButton;
    private TitleType CurrentTitleType;
    private void Start()
    {
        ExitButton.onClick.AddListener(() =>
        {
            WindowController.S.TitleWindow.gameObject.SetActive(false);
        });
        
        ObserverModuleManager.S.RegisterEvent("TitleInfo",TitleInfo);
    }

    public void TitleInfo(object[] obj)
    {
        InstallButton.gameObject.SetActive(true);
     Level5Info.SetActive(false);
     Level15Info.SetActive(false);
     Level30Info.SetActive(false);
     Level50Info.SetActive(false);
     Level75Info.SetActive(false);
     Level100Info.SetActive(false);

     MonsterCount1Info.SetActive(false);
     MonsterCount2Info.SetActive(false);
     MonsterCount3Info.SetActive(false);
     MonsterCount4Info.SetActive(false);
     MonsterCount5Info.SetActive(false);
     MonsterCount6Info.SetActive(false);
    
     LinHun.SetActive(false);
     BaoShi.SetActive(false);
     HunQi3.SetActive(false);
     HunQi4.SetActive(false);
     HunQi5.SetActive(false);
     GuanKa3.SetActive(false);
     GuanKa4.SetActive(false);
     GuanKa5.SetActive(false);
     ChiBang4.SetActive(false);
     ChiBang5.SetActive(false);
     DiaoLuo.SetActive(false);
        TitleType  titleType = (TitleType)obj[0];
        switch (titleType)
        {
            case TitleType.Level5:
                Level5Info.SetActive(true);
                CurrentTitleType = TitleType.Level5;
                break;
            case TitleType.Level15:
                Level15Info.SetActive(true);
                CurrentTitleType = TitleType.Level15;
                break;
            case TitleType.Level30:
                Level30Info.SetActive(true);
                CurrentTitleType = TitleType.Level30;
                break;
            case TitleType.Level50:
                Level50Info.SetActive(true);
                CurrentTitleType = TitleType.Level50;
                break;
            case TitleType.Level75:
                Level75Info.SetActive(true);
                CurrentTitleType = TitleType.Level75;
                break;
            case TitleType.Level100:
                Level100Info.SetActive(true);
                CurrentTitleType = TitleType.Level100;
                break;
            case TitleType.MonsterCount1:
                MonsterCount1Info.SetActive(true);
                CurrentTitleType = TitleType.MonsterCount1;
                break;
            case TitleType.MonsterCount2:
                MonsterCount2Info.SetActive(true);
                CurrentTitleType = TitleType.MonsterCount2;
                break;
            case TitleType.MonsterCount3:
                MonsterCount3Info.SetActive(true);
                CurrentTitleType = TitleType.MonsterCount3;
                break;
            case TitleType.MonsterCount4:
                MonsterCount4Info.SetActive(true);
                CurrentTitleType = TitleType.MonsterCount4;
                break;
            case TitleType.MonsterCount5:
                MonsterCount5Info.SetActive(true);
                CurrentTitleType = TitleType.MonsterCount5;
                break;
            case TitleType.MonsterCount6:
                MonsterCount6Info.SetActive(true);
                CurrentTitleType = TitleType.MonsterCount6;
                break;
            case TitleType.LinHun:
                LinHun.SetActive(true);
                CurrentTitleType = TitleType.LinHun;
                break;
            case TitleType.BaoShi:
                BaoShi.SetActive(true);
                CurrentTitleType = TitleType.BaoShi;
                break;
            case TitleType.HunQi3:
                HunQi3.SetActive(true);
                CurrentTitleType = TitleType.HunQi3;
                break;
            case TitleType.HunQi4:
                HunQi4.SetActive(true);
                CurrentTitleType = TitleType.HunQi4;
                break;
            case TitleType.HunQi5:
                HunQi5.SetActive(true);
                CurrentTitleType = TitleType.HunQi5;
                break;
            case TitleType.ChiBang4:
                ChiBang4.SetActive(true);
                CurrentTitleType = TitleType.ChiBang4;
                break;
            case TitleType.ChiBang5:
                ChiBang5.SetActive(true);
                CurrentTitleType = TitleType.ChiBang5;
                break;
            case TitleType.GuanKa3:
                GuanKa3.SetActive(true);
                CurrentTitleType = TitleType.GuanKa3;
                break;
            case TitleType.GuanKa4:
                GuanKa4.SetActive(true);
                CurrentTitleType = TitleType.GuanKa4;
                break;
            case TitleType.GuanKa5:
                GuanKa5.SetActive(true);
                CurrentTitleType = TitleType.GuanKa5;
                break;
            case TitleType.DiaoLuo:
                DiaoLuo.SetActive(true);
                CurrentTitleType = TitleType.DiaoLuo;
                break;
        }
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
