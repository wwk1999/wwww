using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleBag : MonoBehaviour
{
    public TextMeshProUGUI Level5TextMeshProUGUI;
    public TextMeshProUGUI Level15TextMeshProUGUI;
    public TextMeshProUGUI Level30TextMeshProUGUI;
    public TextMeshProUGUI Level50TextMeshProUGUI;
    public TextMeshProUGUI Level75TextMeshProUGUI;
    public TextMeshProUGUI Level100TextMeshProUGUI;

    public TextMeshProUGUI MonsterCount1TextMeshProUGUI;
    public TextMeshProUGUI MonsterCount2TextMeshProUGUI;
    public TextMeshProUGUI MonsterCount3TextMeshProUGUI;
    public TextMeshProUGUI MonsterCount4TextMeshProUGUI;
    public TextMeshProUGUI MonsterCount5TextMeshProUGUI;
    public TextMeshProUGUI MonsterCount6TextMeshProUGUI;

    public TextMeshProUGUI LingHun1TextMeshProUGUI;
    public TextMeshProUGUI LingHun2TextMeshProUGUI;
    public TextMeshProUGUI LingHun3TextMeshProUGUI;
    public TextMeshProUGUI LingHun4TextMeshProUGUI;
    public TextMeshProUGUI LingHun5TextMeshProUGUI;
    public TextMeshProUGUI LingHun6TextMeshProUGUI;

    public TextMeshProUGUI GuanKa1TextMeshProUGUI;
    public TextMeshProUGUI GuanKa2TextMeshProUGUI;
    public TextMeshProUGUI GuanKa3TextMeshProUGUI;
    public TextMeshProUGUI GuanKa4TextMeshProUGUI;
    public TextMeshProUGUI GuanKa5TextMeshProUGUI;
    public TextMeshProUGUI GuanKa6TextMeshProUGUI;

    public TextMeshProUGUI Ice1TextMeshProUGUI;
    public TextMeshProUGUI Ice2TextMeshProUGUI;
    public TextMeshProUGUI Ice3TextMeshProUGUI;
    public TextMeshProUGUI Ice4TextMeshProUGUI;
    public TextMeshProUGUI Ice5TextMeshProUGUI;
    public TextMeshProUGUI Ice6TextMeshProUGUI;

    public TextMeshProUGUI Huo1TextMeshProUGUI;
    public TextMeshProUGUI Huo2TextMeshProUGUI;
    public TextMeshProUGUI Huo3TextMeshProUGUI;
    public TextMeshProUGUI Huo4TextMeshProUGUI;
    public TextMeshProUGUI Huo5TextMeshProUGUI;
    public TextMeshProUGUI Huo6TextMeshProUGUI;

    public TextMeshProUGUI HeiAn1TextMeshProUGUI;
    public TextMeshProUGUI HeiAn2TextMeshProUGUI;
    public TextMeshProUGUI HeiAn3TextMeshProUGUI;
    public TextMeshProUGUI HeiAn4TextMeshProUGUI;
    public TextMeshProUGUI HeiAn5TextMeshProUGUI;
    public TextMeshProUGUI HeiAn6TextMeshProUGUI;

    public TextMeshProUGUI Dian1TextMeshProUGUI;
    public TextMeshProUGUI Dian2TextMeshProUGUI;
    public TextMeshProUGUI Dian3TextMeshProUGUI;
    public TextMeshProUGUI Dian4TextMeshProUGUI;
    public TextMeshProUGUI Dian5TextMeshProUGUI;
    public TextMeshProUGUI Dian6TextMeshProUGUI;


    public TextMeshProUGUI DiaoLuoTextMeshProUGUI;

    
    
     public GameObject Level5GameObject;
    public GameObject Level15GameObject;
    public GameObject Level30GameObject;
    public GameObject Level50GameObject;
    public GameObject Level75GameObject;
    public GameObject Level100GameObject;

    public GameObject MonsterCount1GameObject;
    public GameObject MonsterCount2GameObject;
    public GameObject MonsterCount3GameObject;
    public GameObject MonsterCount4GameObject;
    public GameObject MonsterCount5GameObject;
    public GameObject MonsterCount6GameObject;

    public GameObject LingHun1GameObject;
    public GameObject LingHun2GameObject;
    public GameObject LingHun3GameObject;
    public GameObject LingHun4GameObject;
    public GameObject LingHun5GameObject;
    public GameObject LingHun6GameObject;

    public GameObject GuanKa1GameObject;
    public GameObject GuanKa2GameObject;
    public GameObject GuanKa3GameObject;
    public GameObject GuanKa4GameObject;
    public GameObject GuanKa5GameObject;
    public GameObject GuanKa6GameObject;

    public GameObject Ice1GameObject;
    public GameObject Ice2GameObject;
    public GameObject Ice3GameObject;
    public GameObject Ice4GameObject;
    public GameObject Ice5GameObject;
    public GameObject Ice6GameObject;

    public GameObject Huo1GameObject;
    public GameObject Huo2GameObject;
    public GameObject Huo3GameObject;
    public GameObject Huo4GameObject;
    public GameObject Huo5GameObject;
    public GameObject Huo6GameObject;

    public GameObject HeiAn1GameObject;
    public GameObject HeiAn2GameObject;
    public GameObject HeiAn3GameObject;
    public GameObject HeiAn4GameObject;
    public GameObject HeiAn5GameObject;
    public GameObject HeiAn6GameObject;

    public GameObject Dian1GameObject;
    public GameObject Dian2GameObject;
    public GameObject Dian3GameObject;
    public GameObject Dian4GameObject;
    public GameObject Dian5GameObject;
    public GameObject Dian6GameObject;


    public GameObject DiaoLuoGameObject;

    private void OnEnable()
    {
        ShowTitleBag();
    }

    public void ShowTitleBag()
    {
        
         Level5GameObject.gameObject.SetActive(false);
        Level15GameObject.gameObject.SetActive(false);
        Level30GameObject.gameObject.SetActive(false);
        Level50GameObject.gameObject.SetActive(false);
        Level75GameObject.gameObject.SetActive(false);
        Level100GameObject.gameObject.SetActive(false);

        MonsterCount1GameObject.gameObject.SetActive(false);
        MonsterCount2GameObject.gameObject.SetActive(false);
        MonsterCount3GameObject.gameObject.SetActive(false);
        MonsterCount4GameObject.gameObject.SetActive(false);
        MonsterCount5GameObject.gameObject.SetActive(false);
        MonsterCount6GameObject.gameObject.SetActive(false);

        LingHun1GameObject.gameObject.SetActive(false);
        LingHun2GameObject.gameObject.SetActive(false);
        LingHun3GameObject.gameObject.SetActive(false);
        LingHun4GameObject.gameObject.SetActive(false);
        LingHun5GameObject.gameObject.SetActive(false);
        LingHun6GameObject.gameObject.SetActive(false);

        GuanKa1GameObject.gameObject.SetActive(false);
        GuanKa2GameObject.gameObject.SetActive(false);
        GuanKa3GameObject.gameObject.SetActive(false);
        GuanKa4GameObject.gameObject.SetActive(false);
        GuanKa5GameObject.gameObject.SetActive(false);
        GuanKa6GameObject.gameObject.SetActive(false);

        Ice1GameObject.gameObject.SetActive(false);
        Ice2GameObject.gameObject.SetActive(false);
        Ice3GameObject.gameObject.SetActive(false);
        Ice4GameObject.gameObject.SetActive(false);
        Ice5GameObject.gameObject.SetActive(false);
        Ice6GameObject.gameObject.SetActive(false);

        Huo1GameObject.gameObject.SetActive(false);
        Huo2GameObject.gameObject.SetActive(false);
        Huo3GameObject.gameObject.SetActive(false);
        Huo4GameObject.gameObject.SetActive(false);
        Huo5GameObject.gameObject.SetActive(false);
        Huo6GameObject.gameObject.SetActive(false);

        HeiAn1GameObject.gameObject.SetActive(false);
        HeiAn2GameObject.gameObject.SetActive(false);
        HeiAn3GameObject.gameObject.SetActive(false);
        HeiAn4GameObject.gameObject.SetActive(false);
        HeiAn5GameObject.gameObject.SetActive(false);
        HeiAn6GameObject.gameObject.SetActive(false);

        Dian1GameObject.gameObject.SetActive(false);
        Dian2GameObject.gameObject.SetActive(false);
        Dian3GameObject.gameObject.SetActive(false);
        Dian4GameObject.gameObject.SetActive(false);
        Dian5GameObject.gameObject.SetActive(false);
        Dian6GameObject.gameObject.SetActive(false);

        DiaoLuoGameObject.gameObject.SetActive(false);
        var titleType = PlayerData.S.CurrentInstallTitle;
        switch (titleType)
        {
           case TitleType.Level5:
                Level5GameObject.gameObject.SetActive(true);
                Level5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Level15:
                Level15GameObject.gameObject.SetActive(true);
                Level15TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Level30:
                Level30GameObject.gameObject.SetActive(true);
                Level30TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Level50:
                Level50GameObject.gameObject.SetActive(true);
                Level50TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Level75:
                Level75GameObject.gameObject.SetActive(true);
                Level75TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Level100:
                Level100GameObject.gameObject.SetActive(true);
                Level100TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.MonsterCount1:
                MonsterCount1GameObject.gameObject.SetActive(true);
                MonsterCount1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.MonsterCount2:
                MonsterCount2GameObject.gameObject.SetActive(true);
                MonsterCount2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.MonsterCount3:
                MonsterCount3GameObject.gameObject.SetActive(true);
                MonsterCount3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.MonsterCount4:
                MonsterCount4GameObject.gameObject.SetActive(true);
                MonsterCount4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.MonsterCount5:
                MonsterCount5GameObject.gameObject.SetActive(true);
                MonsterCount5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.MonsterCount6:
                MonsterCount6GameObject.gameObject.SetActive(true);
                MonsterCount6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.LingHun1:
                LingHun1GameObject.gameObject.SetActive(true);
                LingHun1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.LingHun2:
                LingHun2GameObject.gameObject.SetActive(true);
                LingHun2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.LingHun3:
                LingHun3GameObject.gameObject.SetActive(true);
                LingHun3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.LingHun4:
                LingHun4GameObject.gameObject.SetActive(true);
                LingHun4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.LingHun5:
                LingHun5GameObject.gameObject.SetActive(true);
                LingHun5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.LingHun6:
                LingHun6GameObject.gameObject.SetActive(true);
                LingHun6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.GuanKa1:
                GuanKa1GameObject.gameObject.SetActive(true);
                GuanKa1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.GuanKa2:
                GuanKa2GameObject.gameObject.SetActive(true);
                GuanKa2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.GuanKa3:
                GuanKa3GameObject.gameObject.SetActive(true);
                GuanKa3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.GuanKa4:
                GuanKa4GameObject.gameObject.SetActive(true);
                GuanKa4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.GuanKa5:
                GuanKa5GameObject.gameObject.SetActive(true);
                GuanKa5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.GuanKa6:
                GuanKa6GameObject.gameObject.SetActive(true);
                GuanKa6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Huo1:
                Huo1GameObject.gameObject.SetActive(true);
                Huo1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Huo2:
                Huo2GameObject.gameObject.SetActive(true);
                Huo2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Huo3:
                Huo3GameObject.gameObject.SetActive(true);
                Huo3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Huo4:
                Huo4GameObject.gameObject.SetActive(true);
                Huo4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Huo5:
                Huo5GameObject.gameObject.SetActive(true);
                Huo5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Huo6:
                Huo6GameObject.gameObject.SetActive(true);
                Huo6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Ice1:
                Ice1GameObject.gameObject.SetActive(true);
                Ice1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Ice2:
                Ice2GameObject.gameObject.SetActive(true);
                Ice2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Ice3:
                Ice3GameObject.gameObject.SetActive(true);
                Ice3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Ice4:
                Ice4GameObject.gameObject.SetActive(true);
                Ice4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Ice5:
                Ice5GameObject.gameObject.SetActive(true);
                Ice5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Ice6:
                Ice6GameObject.gameObject.SetActive(true);
                Ice6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Dian1:
                Dian1GameObject.gameObject.SetActive(true);
                Dian1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Dian2:
                Dian2GameObject.gameObject.SetActive(true);
                Dian2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Dian3:
                Dian3GameObject.gameObject.SetActive(true);
                Dian3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Dian4:
                Dian4GameObject.gameObject.SetActive(true);
                Dian4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Dian5:
                Dian5GameObject.gameObject.SetActive(true);
                Dian5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.Dian6:
                Dian6GameObject.gameObject.SetActive(true);
                Dian6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.HeiAn1:
                HeiAn1GameObject.gameObject.SetActive(true);
                HeiAn1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.HeiAn2:
                HeiAn2GameObject.gameObject.SetActive(true);
                HeiAn2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.HeiAn3:
                HeiAn3GameObject.gameObject.SetActive(true);
                HeiAn3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.HeiAn4:
                HeiAn4GameObject.gameObject.SetActive(true);
                HeiAn4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.HeiAn5:
                HeiAn5GameObject.gameObject.SetActive(true);
                HeiAn5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.HeiAn6:
                HeiAn6GameObject.gameObject.SetActive(true);
                HeiAn6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.DiaoLuo:
                DiaoLuoGameObject.gameObject.SetActive(true);
                DiaoLuoTextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                break;
            case TitleType.None:
            default:
                // 无操作，所有对象已禁用
                break;
            
        }
    }
}
