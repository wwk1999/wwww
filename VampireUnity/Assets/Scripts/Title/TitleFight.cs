using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleFight : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    
    public SpriteRenderer Level5SpriteRenderer;
    public SpriteRenderer Level15SpriteRenderer;
    public SpriteRenderer Level30SpriteRenderer;
    public SpriteRenderer Level50SpriteRenderer;
    public SpriteRenderer Level75SpriteRenderer;
    public SpriteRenderer Level100SpriteRenderer;

    public SpriteRenderer MonsterCount1SpriteRenderer;
    public SpriteRenderer MonsterCount2SpriteRenderer;
    public SpriteRenderer MonsterCount3SpriteRenderer;
    public SpriteRenderer MonsterCount4SpriteRenderer;
    public SpriteRenderer MonsterCount5SpriteRenderer;
    public SpriteRenderer MonsterCount6SpriteRenderer;

    public SpriteRenderer LingHun1SpriteRenderer;
    public SpriteRenderer LingHun2SpriteRenderer;
    public SpriteRenderer LingHun3SpriteRenderer;
    public SpriteRenderer LingHun4SpriteRenderer;
    public SpriteRenderer LingHun5SpriteRenderer;
    public SpriteRenderer LingHun6SpriteRenderer;

    public SpriteRenderer GuanKa1SpriteRenderer;
    public SpriteRenderer GuanKa2SpriteRenderer;
    public SpriteRenderer GuanKa3SpriteRenderer;
    public SpriteRenderer GuanKa4SpriteRenderer;
    public SpriteRenderer GuanKa5SpriteRenderer;
    public SpriteRenderer GuanKa6SpriteRenderer;

    public SpriteRenderer Ice1SpriteRenderer;
    public SpriteRenderer Ice2SpriteRenderer;
    public SpriteRenderer Ice3SpriteRenderer;
    public SpriteRenderer Ice4SpriteRenderer;
    public SpriteRenderer Ice5SpriteRenderer;
    public SpriteRenderer Ice6SpriteRenderer;

    public SpriteRenderer Huo1SpriteRenderer;
    public SpriteRenderer Huo2SpriteRenderer;
    public SpriteRenderer Huo3SpriteRenderer;
    public SpriteRenderer Huo4SpriteRenderer;
    public SpriteRenderer Huo5SpriteRenderer;
    public SpriteRenderer Huo6SpriteRenderer;

    public SpriteRenderer HeiAn1SpriteRenderer;
    public SpriteRenderer HeiAn2SpriteRenderer;
    public SpriteRenderer HeiAn3SpriteRenderer;
    public SpriteRenderer HeiAn4SpriteRenderer;
    public SpriteRenderer HeiAn5SpriteRenderer;
    public SpriteRenderer HeiAn6SpriteRenderer;

    public SpriteRenderer Dian1SpriteRenderer;
    public SpriteRenderer Dian2SpriteRenderer;
    public SpriteRenderer Dian3SpriteRenderer;
    public SpriteRenderer Dian4SpriteRenderer;
    public SpriteRenderer Dian5SpriteRenderer;
    public SpriteRenderer Dian6SpriteRenderer;


    public SpriteRenderer DiaoLuoSpriteRenderer;
    
    
    public Canvas Level5Canvas;
    public Canvas Level15Canvas;
    public Canvas Level30Canvas;
    public Canvas Level50Canvas;
    public Canvas Level75Canvas;
    public Canvas Level100Canvas;

    public Canvas MonsterCount1Canvas;
    public Canvas MonsterCount2Canvas;
    public Canvas MonsterCount3Canvas;
    public Canvas MonsterCount4Canvas;
    public Canvas MonsterCount5Canvas;
    public Canvas MonsterCount6Canvas;

    public Canvas LingHun1Canvas;
    public Canvas LingHun2Canvas;
    public Canvas LingHun3Canvas;
    public Canvas LingHun4Canvas;
    public Canvas LingHun5Canvas;
    public Canvas LingHun6Canvas;

    public Canvas GuanKa1Canvas;
    public Canvas GuanKa2Canvas;
    public Canvas GuanKa3Canvas;
    public Canvas GuanKa4Canvas;
    public Canvas GuanKa5Canvas;
    public Canvas GuanKa6Canvas;

    public Canvas Ice1Canvas;
    public Canvas Ice2Canvas;
    public Canvas Ice3Canvas;
    public Canvas Ice4Canvas;
    public Canvas Ice5Canvas;
    public Canvas Ice6Canvas;

    public Canvas Huo1Canvas;
    public Canvas Huo2Canvas;
    public Canvas Huo3Canvas;
    public Canvas Huo4Canvas;
    public Canvas Huo5Canvas;
    public Canvas Huo6Canvas;

    public Canvas HeiAn1Canvas;
    public Canvas HeiAn2Canvas;
    public Canvas HeiAn3Canvas;
    public Canvas HeiAn4Canvas;
    public Canvas HeiAn5Canvas;
    public Canvas HeiAn6Canvas;

    public Canvas Dian1Canvas;
    public Canvas Dian2Canvas;
    public Canvas Dian3Canvas;
    public Canvas Dian4Canvas;
    public Canvas Dian5Canvas;
    public Canvas Dian6Canvas;


    public Canvas DiaoLuoCanvas;
    
    
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
    

    private void Update()
    {
        switch (PlayerData.S.CurrentInstallTitle)
        {
            case TitleType.Level5:
                Level5SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Level5Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Level15:
                Level15SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Level15Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Level30:
                Level30SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Level30Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Level50:
                Level50SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Level50Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Level75:
                Level75SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Level75Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Level100:
                Level100SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Level100Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.MonsterCount1:
                MonsterCount1SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                MonsterCount1Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.MonsterCount2:
                MonsterCount2SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                MonsterCount2Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.MonsterCount3:
                MonsterCount3SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                MonsterCount3Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.MonsterCount4:
                MonsterCount4SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                MonsterCount4Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.MonsterCount5:
                MonsterCount5SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                MonsterCount5Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.MonsterCount6:
                MonsterCount6SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                MonsterCount6Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.LingHun1:
                LingHun1SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                LingHun1Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.LingHun2:
                LingHun2SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                LingHun2Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.LingHun3:
                LingHun3SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                LingHun3Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.LingHun4:
                LingHun4SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                LingHun4Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.LingHun5:
                LingHun5SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                LingHun5Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.LingHun6:
                LingHun6SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                LingHun6Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.GuanKa1:
                GuanKa1SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                GuanKa1Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.GuanKa2:
                GuanKa2SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                GuanKa2Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.GuanKa3:
                GuanKa3SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                GuanKa3Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.GuanKa4:
                GuanKa4SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                GuanKa4Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.GuanKa5:
                GuanKa5SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                GuanKa5Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.GuanKa6:
                GuanKa6SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                GuanKa6Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Huo1:
                Huo1SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Huo1Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Huo2:
                Huo2SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Huo2Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Huo3:
                Huo3SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Huo3Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Huo4:
                Huo4SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Huo4Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Huo5:
                Huo5SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Huo5Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Huo6:
                Huo6SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Huo6Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Ice1:
                Ice1SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Ice1Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Ice2:
                Ice2SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Ice2Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Ice3:
                Ice3SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Ice3Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Ice4:
                Ice4SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Ice4Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Ice5:
                Ice5SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Ice5Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Ice6:
                Ice6SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Ice6Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Dian1:
                Dian1SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Dian1Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Dian2:
                Dian2SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Dian2Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Dian3:
                Dian3SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Dian3Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Dian4:
                Dian4SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Dian4Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Dian5:
                Dian5SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Dian5Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.Dian6:
                Dian6SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                Dian6Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.HeiAn1:
                HeiAn1SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                HeiAn1Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.HeiAn2:
                HeiAn2SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                HeiAn2Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.HeiAn3:
                HeiAn3SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                HeiAn3Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.HeiAn4:
                HeiAn4SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                HeiAn4Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.HeiAn5:
                HeiAn5SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                HeiAn5Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.HeiAn6:
                HeiAn6SpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                HeiAn6Canvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.DiaoLuo:
                DiaoLuoSpriteRenderer.sortingOrder = SpriteRenderer.sortingOrder;
                DiaoLuoCanvas.sortingOrder = SpriteRenderer.sortingOrder+1;
                break;
            case TitleType.None:
            default:
                break;
        }
    }

    public void ShowTitle(object[] obj)
    {
        ShowTitle(PlayerData.S.CurrentInstallTitle);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("ShowTitle",ShowTitle);
        ShowTitle(PlayerData.S.CurrentInstallTitle);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("ShowTitle",ShowTitle);
    }

    public void ShowTitle(TitleType titleType)
    {
        // 禁用所有标题对象
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

        // 根据类型启用对应对象并设置文本
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
