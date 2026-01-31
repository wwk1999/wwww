using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;

public class TitleItem : MonoBehaviour
{

    public GameObject mask;
    
    public GameObject Level5 ;
    public GameObject Level15 ;
    public GameObject Level30 ;
    public GameObject Level50 ;
    public GameObject Level75 ;
    public GameObject Level100 ;
    
    public GameObject MonsterCount1 ;
    public GameObject MonsterCount2 ;
    public GameObject MonsterCount3 ;
    public GameObject MonsterCount4 ;
    public GameObject MonsterCount5 ;
    public GameObject MonsterCount6 ;

    public GameObject LingHun ;
    public GameObject BaoShi ;
    public GameObject GuanKa3 ;
    public GameObject GuanKa4 ;
    public GameObject GuanKa5 ;
    public GameObject HunQi3 ;
    public GameObject HunQi4 ;
    public GameObject HunQi5 ;
    public GameObject ChiBang4 ;
    public GameObject ChiBang5 ;
    public GameObject DiaoLuo ;

    public void SetTitle(TitleType titleType,bool JieSuo)
    {
        mask.SetActive(!JieSuo);
        switch (titleType)
        {
            case TitleType.Level5:
                Level5.gameObject.SetActive(true);
                Level5.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.Level5].Name;
                break;
            case TitleType.Level15:
                Level15.gameObject.SetActive(true);
                Level15.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.Level15].Name;
                break;
            
            case TitleType.Level30:
                Level30.gameObject.SetActive(true);
                Level30.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.Level30].Name;
                break;
            
            case TitleType.Level50:
                Level50.gameObject.SetActive(true);
                Level50.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.Level50].Name;
                break;
            
            case TitleType.Level75:
                Level75.gameObject.SetActive(true);
                Level75.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.Level75].Name;
                break;
            
            case TitleType.Level100:
                Level100.gameObject.SetActive(true);
                Level100.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.Level100].Name;
                break;
            
            case TitleType.MonsterCount1:
                MonsterCount1.gameObject.SetActive(true);
                MonsterCount1.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.MonsterCount1].Name;
                break;
            
            case TitleType.MonsterCount2:
                MonsterCount2.gameObject.SetActive(true);
                MonsterCount2.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.MonsterCount2].Name;
                break;
            
            case TitleType.MonsterCount3:
                MonsterCount3.gameObject.SetActive(true);
                MonsterCount3.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.MonsterCount3].Name;
                break;
            
            case TitleType.MonsterCount4:
                MonsterCount4.gameObject.SetActive(true);
                MonsterCount4.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.MonsterCount4].Name;
                break;
            
            case TitleType.MonsterCount5:
                MonsterCount5.gameObject.SetActive(true);
                MonsterCount5.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.MonsterCount5].Name;
                break;
            
            case TitleType.MonsterCount6:
                MonsterCount6.gameObject.SetActive(true);
                MonsterCount6.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.MonsterCount6].Name;
                break;
            
            case TitleType.LinHun:
                LingHun.gameObject.SetActive(true);
                LingHun.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.LinHun].Name;
                break;
            
            case TitleType.BaoShi:
                BaoShi.gameObject.SetActive(true);
                BaoShi.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.BaoShi].Name;
                break;
            
            case TitleType.GuanKa3:
                GuanKa3.gameObject.SetActive(true);
                GuanKa3.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.GuanKa3].Name;
                break;
            
            case TitleType.GuanKa4:
                GuanKa4.gameObject.SetActive(true);
                GuanKa4.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.GuanKa4].Name;
                break;
            
            case TitleType.GuanKa5:
                GuanKa5.gameObject.SetActive(true);
                GuanKa5.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.GuanKa5].Name;
                break;
            
            case TitleType.ChiBang4:
                ChiBang4.gameObject.SetActive(true);
                ChiBang4.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.ChiBang4].Name;
                break;
            
            case TitleType.ChiBang5:
                ChiBang5.gameObject.SetActive(true);
                ChiBang5.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.ChiBang5].Name;
                break;
            
            case TitleType.HunQi3:
                HunQi3.gameObject.SetActive(true);
                HunQi3.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.HunQi3].Name;
                break;
            
            case TitleType.HunQi4:
                HunQi4.gameObject.SetActive(true);
                HunQi4.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.HunQi4].Name;
                break;
            
            case TitleType.HunQi5:
                HunQi5.gameObject.SetActive(true);
                HunQi5.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.HunQi5].Name;
                break;
            
            case TitleType.DiaoLuo:
                DiaoLuo.gameObject.SetActive(true);
                DiaoLuo.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = LanguageConfig.LanguageItems[PlayerData.S.langType].TitleLanguage.TitleInfoDic[TitleType.DiaoLuo].Name;
                break;
        }
    }
}
