using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleItem : MonoBehaviour
{
    
    public Button Level5Button;
    public Button Level15Button;
    public Button Level30Button;
    public Button Level50Button;
    public Button Level75Button;
    public Button Level100Button;
    
    public Button MonsterCount1Button;
    public Button MonsterCount2Button;
    public Button MonsterCount3Button;
    public Button MonsterCount4Button;
    public Button MonsterCount5Button;
    public Button MonsterCount6Button;

    public Button LingHun1Button;
    public Button LingHun2Button;
    public Button LingHun3Button;
    public Button LingHun4Button;
    public Button LingHun5Button;
    public Button LingHun6Button;

    public Button GuanKa1Button;
    public Button GuanKa2Button;
    public Button GuanKa3Button;
    public Button GuanKa4Button;
    public Button GuanKa5Button;
    public Button GuanKa6Button;
   
    public Button Ice1Button;
    public Button Ice2Button;
    public Button Ice3Button;
    public Button Ice4Button;
    public Button Ice5Button;
    public Button Ice6Button;
    
    public Button Huo1Button;
    public Button Huo2Button;
    public Button Huo3Button;
    public Button Huo4Button;
    public Button Huo5Button;
    public Button Huo6Button;
    
    public Button HeiAn1Button;
    public Button HeiAn2Button;
    public Button HeiAn3Button;
    public Button HeiAn4Button;
    public Button HeiAn5Button;
    public Button HeiAn6Button;
    
    public Button Dian1Button;
    public Button Dian2Button;
    public Button Dian3Button;
    public Button Dian4Button;
    public Button Dian5Button;
    public Button Dian6Button;
    
    
    public Button DiaoLuoButton;

    
    
    
    
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
    public GameObject Gou;

    public TitleType TitleItemType = TitleType.None;


    public void SetItem()
    {
        Gou.gameObject.SetActive(PlayerData.S.CurrentInstallTitle==TitleItemType);
        switch (TitleItemType)
        {
            case TitleType.Dian1:
                Dian1Button.gameObject.SetActive(true);
                ColorBlock cb333 = Dian1Button.colors;          
                cb333.normalColor = PlayerData.S.Dian1 ? Color.white : Color.gray;  
                Dian1Button.colors = cb333;
                Dian1TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Dian2:
                Dian2Button.gameObject.SetActive(true);
                ColorBlock cb3331 = Dian2Button.colors;          
                cb3331.normalColor = PlayerData.S.Dian2 ? Color.white : Color.gray;  
                Dian2Button.colors = cb3331;
                Dian2TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Dian3:
                Dian3Button.gameObject.SetActive(true);
                ColorBlock cb3332 = Dian3Button.colors;          
                cb3332.normalColor = PlayerData.S.Dian3 ? Color.white : Color.gray;  
                Dian3Button.colors = cb3332;
                Dian3TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Dian4:
                Dian4Button.gameObject.SetActive(true);
                ColorBlock cb3333 = Dian4Button.colors;          
                cb3333.normalColor = PlayerData.S.Dian4 ? Color.white : Color.gray;  
                Dian4Button.colors = cb3333;
                Dian4TextMeshProUGUI.text =TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Dian5:
                Dian5Button.gameObject.SetActive(true);
                ColorBlock cb3334 = Dian5Button.colors;          
                cb3334.normalColor = PlayerData.S.Dian5 ? Color.white : Color.gray;  
                Dian5Button.colors = cb3334;
                Dian5TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Dian6:
                Dian6Button.gameObject.SetActive(true);
                ColorBlock cb3335 = Dian6Button.colors;          
                cb3335.normalColor = PlayerData.S.Dian6 ? Color.white : Color.gray;  
                Dian6Button.colors = cb3335;
                Dian6TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            
            
            
            
            case TitleType.Ice1:
                Ice1Button.gameObject.SetActive(true);
                ColorBlock cb222 = Ice1Button.colors;          
                cb222.normalColor = PlayerData.S.Ice1 ? Color.white : Color.gray;  
                Ice1Button.colors = cb222;
                Ice1TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Ice2:
                Ice2Button.gameObject.SetActive(true);
                ColorBlock cb2221 = Ice2Button.colors;          
                cb2221.normalColor = PlayerData.S.Ice2 ? Color.white : Color.gray;  
                Ice2Button.colors = cb2221;
                Ice2TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Ice3:
                Ice3Button.gameObject.SetActive(true);
                ColorBlock cb2222 = Ice3Button.colors;          
                cb2222.normalColor = PlayerData.S.Ice3 ? Color.white : Color.gray;  
                Ice3Button.colors = cb2222;
                Ice3TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Ice4:
                Ice4Button.gameObject.SetActive(true);
                ColorBlock cb2223 = Ice4Button.colors;          
                cb2223.normalColor = PlayerData.S.Ice4 ? Color.white : Color.gray;  
                Ice4Button.colors = cb2223;
                Ice4TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Ice5:
                Ice5Button.gameObject.SetActive(true);
                ColorBlock cb2224 = Ice5Button.colors;          
                cb2224.normalColor = PlayerData.S.Ice5 ? Color.white : Color.gray;  
                Ice5Button.colors = cb2224;
                Ice5TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Ice6:
                Ice6Button.gameObject.SetActive(true);
                ColorBlock cb2225 = Ice6Button.colors;          
                cb2225.normalColor = PlayerData.S.Ice6 ? Color.white : Color.gray;  
                Ice6Button.colors = cb2225;
                Ice6TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            
            
            
            
            
            
            case TitleType.Huo1:
                Huo1Button.gameObject.SetActive(true);
                ColorBlock cb11 = Huo1Button.colors;          
                cb11.normalColor = PlayerData.S.Huo1 ? Color.white : Color.gray;  
                Huo1Button.colors = cb11;
                Huo1TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Huo2:
                Huo2Button.gameObject.SetActive(true);
                ColorBlock cb111 = Huo2Button.colors;          
                cb111.normalColor = PlayerData.S.Huo2 ? Color.white : Color.gray;  
                Huo2Button.colors = cb111;
                Huo2TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Huo3:
                Huo3Button.gameObject.SetActive(true);
                ColorBlock cb112 = Huo3Button.colors;          
                cb112.normalColor = PlayerData.S.Huo3 ? Color.white : Color.gray;  
                Huo3Button.colors = cb112;
                Huo3TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Huo4:
                Huo4Button.gameObject.SetActive(true);
                ColorBlock cb113 = Huo4Button.colors;          
                cb113.normalColor = PlayerData.S.Huo4 ? Color.white : Color.gray;  
                Huo4Button.colors = cb113;
                Huo4TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Huo5:
                Huo5Button.gameObject.SetActive(true);
                ColorBlock cb114 = Huo5Button.colors;          
                cb114.normalColor = PlayerData.S.Huo5 ? Color.white : Color.gray;  
                Huo5Button.colors = cb114;
                Huo5TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Huo6:
                Huo6Button.gameObject.SetActive(true);
                ColorBlock cb115 = Huo6Button.colors;          
                cb115.normalColor = PlayerData.S.Huo6 ? Color.white : Color.gray;  
                Huo6Button.colors = cb115;
                Huo6TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            
            
            
            
            
            
            case TitleType.HeiAn1:
                HeiAn1Button.gameObject.SetActive(true);
                ColorBlock cb = HeiAn1Button.colors;          
                cb.normalColor = PlayerData.S.HeiAn1 ? Color.white : Color.gray;  
                HeiAn1Button.colors = cb;
                HeiAn1TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.HeiAn2:
                HeiAn2Button.gameObject.SetActive(true);
                ColorBlock cb1 = HeiAn2Button.colors;          
                cb1.normalColor = PlayerData.S.HeiAn2 ? Color.white : Color.gray;  
                HeiAn2Button.colors = cb1;
                HeiAn2TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.HeiAn3:
                HeiAn3Button.gameObject.SetActive(true);
                ColorBlock cb2 = HeiAn3Button.colors;          
                cb2.normalColor = PlayerData.S.HeiAn3 ? Color.white : Color.gray;  
                HeiAn3Button.colors = cb2;
                HeiAn3TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.HeiAn4:
                HeiAn4Button.gameObject.SetActive(true);
                ColorBlock cb3 = HeiAn4Button.colors;          
                cb3.normalColor = PlayerData.S.HeiAn4 ? Color.white : Color.gray;  
                HeiAn4Button.colors = cb3;
                HeiAn4TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.HeiAn5:
                HeiAn5Button.gameObject.SetActive(true);
                ColorBlock cb4 = HeiAn5Button.colors;          
                cb4.normalColor = PlayerData.S.HeiAn5 ? Color.white : Color.gray;  
                HeiAn5Button.colors = cb4;
                HeiAn5TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.HeiAn6:
                HeiAn6Button.gameObject.SetActive(true);
                ColorBlock cb5 = HeiAn6Button.colors;          
                cb5.normalColor = PlayerData.S.HeiAn6 ? Color.white : Color.gray;  
                HeiAn6Button.colors = cb5;
                HeiAn6TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            
            
            
            
            
            case TitleType.LingHun1:
                LingHun1Button.gameObject.SetActive(true);
                ColorBlock cb444 = LingHun1Button.colors;          
                cb444.normalColor = PlayerData.S.LingHun1 ? Color.white : Color.gray;  
                LingHun1Button.colors = cb444;
                LingHun1TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.LingHun2:
                LingHun2Button.gameObject.SetActive(true);
                ColorBlock cb4441 = LingHun2Button.colors;          
                cb4441.normalColor = PlayerData.S.LingHun2 ? Color.white : Color.gray;  
                LingHun2Button.colors = cb4441;
                LingHun2TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.LingHun3:
                LingHun3Button.gameObject.SetActive(true);
                ColorBlock cb4442 = LingHun3Button.colors;          
                cb4442.normalColor = PlayerData.S.LingHun3 ? Color.white : Color.gray;  
                LingHun3Button.colors = cb4442;
                LingHun3TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.LingHun4:
                LingHun4Button.gameObject.SetActive(true);
                ColorBlock cb4443 = LingHun4Button.colors;          
                cb4443.normalColor = PlayerData.S.LingHun4 ? Color.white : Color.gray;  
                LingHun4Button.colors = cb4443;
                LingHun4TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.LingHun5:
                LingHun5Button.gameObject.SetActive(true);
                ColorBlock cb4444 = LingHun5Button.colors;          
                cb4444.normalColor = PlayerData.S.LingHun5 ? Color.white : Color.gray;  
                LingHun5Button.colors = cb4444;
                LingHun5TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.LingHun6:
                LingHun6Button.gameObject.SetActive(true);
                ColorBlock cb4445 = LingHun6Button.colors;          
                cb4445.normalColor = PlayerData.S.LingHun6 ? Color.white : Color.gray;  
                LingHun6Button.colors = cb4445;
                LingHun6TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            
            
            
            
            case TitleType.GuanKa1:
                GuanKa1Button.gameObject.SetActive(true);
                ColorBlock cb555 = GuanKa1Button.colors;          
                cb555.normalColor = PlayerData.S.GuanKa1 ? Color.white : Color.gray;  
                GuanKa1Button.colors = cb555;
                GuanKa1TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.GuanKa2:
                GuanKa2Button.gameObject.SetActive(true);
                ColorBlock cb5551 = GuanKa2Button.colors;          
                cb5551.normalColor = PlayerData.S.GuanKa2 ? Color.white : Color.gray;  
                GuanKa2Button.colors = cb5551;
                GuanKa2TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.GuanKa3:
                GuanKa3Button.gameObject.SetActive(true);
                ColorBlock cb5552 = GuanKa3Button.colors;          
                cb5552.normalColor = PlayerData.S.GuanKa3 ? Color.white : Color.gray;  
                GuanKa3Button.colors = cb5552;
                GuanKa3TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.GuanKa4:
                GuanKa4Button.gameObject.SetActive(true);
                ColorBlock cb5553 = GuanKa4Button.colors;          
                cb5553.normalColor = PlayerData.S.GuanKa4 ? Color.white : Color.gray;  
                GuanKa4Button.colors = cb5553;
                GuanKa4TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.GuanKa5:
                GuanKa5Button.gameObject.SetActive(true);
                ColorBlock cb5554 = GuanKa5Button.colors;          
                cb5554.normalColor = PlayerData.S.GuanKa5 ? Color.white : Color.gray;  
                GuanKa5Button.colors = cb5554;
                GuanKa5TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.GuanKa6:
                GuanKa6Button.gameObject.SetActive(true);
                ColorBlock cb5555 = GuanKa6Button.colors;          
                cb5555.normalColor = PlayerData.S.GuanKa6 ? Color.white : Color.gray;  
                GuanKa6Button.colors = cb5555;
                GuanKa6TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            
            
            
            
            
            
            case TitleType.MonsterCount1:
                MonsterCount1Button.gameObject.SetActive(true);
                ColorBlock cb666 = MonsterCount1Button.colors;          
                cb666.normalColor = PlayerData.S.MonsterCount1 ? Color.white : Color.gray;  
                MonsterCount1Button.colors = cb666;
                MonsterCount1TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.MonsterCount2:
                MonsterCount2Button.gameObject.SetActive(true);
                ColorBlock cb6661 = MonsterCount2Button.colors;          
                cb6661.normalColor = PlayerData.S.MonsterCount2 ? Color.white : Color.gray;  
                MonsterCount2Button.colors = cb6661;
                MonsterCount2TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.MonsterCount3:
                MonsterCount3Button.gameObject.SetActive(true);
                ColorBlock cb6662 = MonsterCount3Button.colors;          
                cb6662.normalColor = PlayerData.S.MonsterCount3 ? Color.white : Color.gray;  
                MonsterCount3Button.colors = cb6662;
                MonsterCount3TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.MonsterCount4:
                MonsterCount4Button.gameObject.SetActive(true);
                ColorBlock cb6663 = MonsterCount4Button.colors;          
                cb6663.normalColor = PlayerData.S.MonsterCount4 ? Color.white : Color.gray;  
                MonsterCount4Button.colors = cb6663;
                MonsterCount4TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.MonsterCount5:
                MonsterCount5Button.gameObject.SetActive(true);
                ColorBlock cb6664 = MonsterCount5Button.colors;          
                cb6664.normalColor = PlayerData.S.MonsterCount5 ? Color.white : Color.gray;  
                MonsterCount5Button.colors = cb6664;
                MonsterCount5TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.MonsterCount6:
                MonsterCount6Button.gameObject.SetActive(true);
                ColorBlock cb6665 = MonsterCount6Button.colors;          
                cb6665.normalColor = PlayerData.S.MonsterCount6 ? Color.white : Color.gray;  
                MonsterCount6Button.colors = cb6665;
                MonsterCount6TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            
            
            
            
            
            case TitleType.Level5:
                Level5Button.gameObject.SetActive(true);
                ColorBlock cb777 = Level5Button.colors;          
                cb777.normalColor = PlayerData.S.Level5 ? Color.white : Color.gray;  
                Level5Button.colors = cb777;
                Level5TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Level15:
                Level15Button.gameObject.SetActive(true);
                ColorBlock cb7771 = Level15Button.colors;          
                cb7771.normalColor = PlayerData.S.Level15 ? Color.white : Color.gray;  
                Level15Button.colors = cb7771;
                Level15TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Level30:
                Level30Button.gameObject.SetActive(true);
                ColorBlock cb7772 = Level30Button.colors;          
                cb7772.normalColor = PlayerData.S.Level30 ? Color.white : Color.gray;  
                Level30Button.colors = cb7772;
                Level30TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Level50:
                Level50Button.gameObject.SetActive(true);
                ColorBlock cb7773 = Level50Button.colors;          
                cb7773.normalColor = PlayerData.S.Level50 ? Color.white : Color.gray;  
                Level50Button.colors = cb7773;
                Level50TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Level75:
                Level75Button.gameObject.SetActive(true);
                ColorBlock cb7774 = Level75Button.colors;          
                cb7774.normalColor = PlayerData.S.Level75 ? Color.white : Color.gray;  
                Level75Button.colors = cb7774;
                Level75TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.Level100:
                Level100Button.gameObject.SetActive(true);
                ColorBlock cb7775 = Level100Button.colors;          
                cb7775.normalColor = PlayerData.S.Level100 ? Color.white : Color.gray;  
                Level100Button.colors = cb7775;
                Level100TextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
            
            case TitleType.DiaoLuo:
                DiaoLuoButton.gameObject.SetActive(true);
                ColorBlock cb0 = DiaoLuoButton.colors;          
                cb0.normalColor = PlayerData.S.DiaoLuo ? Color.white : Color.gray;  
                DiaoLuoButton.colors = cb0;
                DiaoLuoTextMeshProUGUI.text = TitleConfig.TitleNameDic[TitleItemType];
                break;
        }
    }
    
    private void Start()
    {
        Level5Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Level5);
        });
        
        Level15Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Level15);
        });
        
        Level30Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Level30);
        });
        
        Level50Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Level50);
        });
        
        Level75Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Level75);
        });
        
        Level100Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Level100);
        });
        
        MonsterCount1Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.MonsterCount1);
        });
        
        MonsterCount2Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.MonsterCount2);
        });
        
        MonsterCount3Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.MonsterCount3);
        });
        
        MonsterCount4Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.MonsterCount4);
        });
        
        MonsterCount5Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.MonsterCount5);
        });
        
        MonsterCount6Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.MonsterCount6);
        });
        
        
        
        GuanKa1Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.GuanKa1);
        });
        GuanKa2Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.GuanKa2);
        });
        
        GuanKa3Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.GuanKa3);
        });
        
        GuanKa4Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.GuanKa4);
        });
        
        GuanKa5Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.GuanKa5);
        });
        
        GuanKa6Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.GuanKa6);
        });
        
        
        
        
        LingHun1Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.LingHun1);
        });
        LingHun2Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.LingHun2);
        });
        
        LingHun3Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.LingHun3);
        });
        
        LingHun4Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.LingHun4);
        });
        
        LingHun5Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.LingHun5);
        });
        
        LingHun6Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.LingHun6);
        });
        
        
        
        
        
        Dian1Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Dian1);
        });
        Dian2Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Dian2);
        });
        
        Dian3Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Dian3);
        });
        
        Dian4Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Dian4);
        });
        
        Dian5Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Dian5);
        });
        
        Dian6Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Dian6);
        });
        
        
        
        
        
        
        HeiAn1Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.HeiAn1);
        });
        HeiAn2Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.HeiAn2);
        });
        
        HeiAn3Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.HeiAn3);
        });
        
        HeiAn4Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.HeiAn4);
        });
        
        HeiAn5Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.HeiAn5);
        });
        
        HeiAn6Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.HeiAn6);
        });
        
        
        
        
        
        
        
        
        Ice1Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Ice1);
        });
        Ice2Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Ice2);
        });
        
        Ice3Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Ice3);
        });
        
        Ice4Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Ice4);
        });
        
        Ice5Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Ice5);
        });
        
        Ice6Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Ice6);
        });
        
        
        
        
        
        
        
        Huo1Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Huo1);
        });
        Huo2Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Huo2);
        });
        
        Huo3Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Huo3);
        });
        
        Huo4Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Huo4);
        });
        
        Huo5Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Huo5);
        });
        
        Huo6Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.Huo6);
        });
        
       
        
        DiaoLuoButton.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("TitleInfo",TitleType.DiaoLuo);
        });
        
    }
}
