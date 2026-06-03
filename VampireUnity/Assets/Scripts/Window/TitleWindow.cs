using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Prop.BaoShi;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TitleWindow : MonoBehaviour
{
    [NonSerialized]public Dictionary<TitleType,TitleItem>TitleItemDic=new Dictionary<TitleType,TitleItem>();
    public GameObject ImageGameObject;
    public GameObject TitleListContent;
    
    public GameObject JiHuoTiaoJianGameObject;
    public TextMeshProUGUI JiHuoTiaoJianText;
    public GameObject JiHuoAttributeGameObject;
    public GameObject JiHuoAttributeContent;
    public GameObject InstallAttributeGameObject;
    public GameObject InstallAttributeContent;
    public Button ExitButton;

    public Image Level5Image;
    public Image Level15Image;
    public Image Level30Image;
    public Image Level50Image;
    public Image Level75Image;
    public Image Level100Image;

    public Image Monster1Image;
    public Image Monster2Image;
    public Image Monster3Image;
    public Image Monster4Image;
    public Image Monster5Image;
    public Image Monster6Image;
    
    public Image Dian1Image;
    public Image Dian2Image;
    public Image Dian3Image;
    public Image Dian4Image;
    public Image Dian5Image;
    public Image Dian6Image;
    
    public Image Huo1Image;
    public Image Huo2Image;
    public Image Huo3Image;
    public Image Huo4Image;
    public Image Huo5Image;
    public Image Huo6Image;
    
    public Image Ice1Image;
    public Image Ice2Image;
    public Image Ice3Image;
    public Image Ice4Image;
    public Image Ice5Image;
    public Image Ice6Image;
    
    public Image HeiAn1Image;
    public Image HeiAn2Image;
    public Image HeiAn3Image;
    public Image HeiAn4Image;
    public Image HeiAn5Image;
    public Image HeiAn6Image;
    
    public Image LingHun1Image;
    public Image LingHun2Image;
    public Image LingHun3Image;
    public Image LingHun4Image;
    public Image LingHun5Image;
    public Image LingHun6Image;
    
    public Image GuanKa1Image;
    public Image GuanKa2Image;
    public Image GuanKa3Image;
    public Image GuanKa4Image;
    public Image GuanKa5Image;
    public Image GuanKa6Image;

    public Image DiaoLuoImage;

    
    
    public TextMeshProUGUI Level5TextMeshProUGUI;
    public TextMeshProUGUI Level15TextMeshProUGUI;
    public TextMeshProUGUI Level30TextMeshProUGUI;
    public TextMeshProUGUI Level50TextMeshProUGUI;
    public TextMeshProUGUI Level75TextMeshProUGUI;
    public TextMeshProUGUI Level100TextMeshProUGUI;

    public TextMeshProUGUI Monster1TextMeshProUGUI;
    public TextMeshProUGUI Monster2TextMeshProUGUI;
    public TextMeshProUGUI Monster3TextMeshProUGUI;
    public TextMeshProUGUI Monster4TextMeshProUGUI;
    public TextMeshProUGUI Monster5TextMeshProUGUI;
    public TextMeshProUGUI Monster6TextMeshProUGUI;
    
    public TextMeshProUGUI Dian1TextMeshProUGUI;
    public TextMeshProUGUI Dian2TextMeshProUGUI;
    public TextMeshProUGUI Dian3TextMeshProUGUI;
    public TextMeshProUGUI Dian4TextMeshProUGUI;
    public TextMeshProUGUI Dian5TextMeshProUGUI;
    public TextMeshProUGUI Dian6TextMeshProUGUI;
    
    public TextMeshProUGUI Huo1TextMeshProUGUI;
    public TextMeshProUGUI Huo2TextMeshProUGUI;
    public TextMeshProUGUI Huo3TextMeshProUGUI;
    public TextMeshProUGUI Huo4TextMeshProUGUI;
    public TextMeshProUGUI Huo5TextMeshProUGUI;
    public TextMeshProUGUI Huo6TextMeshProUGUI;
    
    public TextMeshProUGUI Ice1TextMeshProUGUI;
    public TextMeshProUGUI Ice2TextMeshProUGUI;
    public TextMeshProUGUI Ice3TextMeshProUGUI;
    public TextMeshProUGUI Ice4TextMeshProUGUI;
    public TextMeshProUGUI Ice5TextMeshProUGUI;
    public TextMeshProUGUI Ice6TextMeshProUGUI;
    
    public TextMeshProUGUI HeiAn1TextMeshProUGUI;
    public TextMeshProUGUI HeiAn2TextMeshProUGUI;
    public TextMeshProUGUI HeiAn3TextMeshProUGUI;
    public TextMeshProUGUI HeiAn4TextMeshProUGUI;
    public TextMeshProUGUI HeiAn5TextMeshProUGUI;
    public TextMeshProUGUI HeiAn6TextMeshProUGUI;
    
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

    public TextMeshProUGUI DiaoLuoTextMeshProUGUI;

    public Button InstallButton;
    private TitleType CurrentTitleType;

    
    private void Start()
    {
        ExitButton.onClick.AddListener(() => { WindowController.S.TitleWindow.gameObject.SetActive(false); });
        InstallButton.onClick.AddListener(() =>
        {
            switch (CurrentTitleType)
            {
                case TitleType.Level5:
                    if (PlayerData.S.Level5 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Level15:
                    if (PlayerData.S.Level15 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Level30:
                    if (PlayerData.S.Level30 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Level50:
                    if (PlayerData.S.Level50 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Level75:
                    if (PlayerData.S.Level75 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Level100:
                    if (PlayerData.S.Level100 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.MonsterCount1:
                    if (PlayerData.S.MonsterCount1 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.MonsterCount2:
                    if (PlayerData.S.MonsterCount2 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.MonsterCount3:
                    if (PlayerData.S.MonsterCount3 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.MonsterCount4:
                    if (PlayerData.S.MonsterCount4 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.MonsterCount5:
                    if (PlayerData.S.MonsterCount5 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.MonsterCount6:
                    if (PlayerData.S.MonsterCount6 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.GuanKa1:
                    if (PlayerData.S.GuanKa1 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.GuanKa2:
                    if (PlayerData.S.GuanKa2 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
               
                
                case TitleType.GuanKa3:
                    if (PlayerData.S.GuanKa3 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.GuanKa4:
                    if (PlayerData.S.GuanKa4 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.GuanKa5:
                    if (PlayerData.S.GuanKa5 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.GuanKa6:
                    if (PlayerData.S.GuanKa6 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                
                
                
                
                
                case TitleType.LingHun1:
                    if (PlayerData.S.LingHun1 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.LingHun2:
                    if (PlayerData.S.LingHun2 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
               
                
                case TitleType.LingHun3:
                    if (PlayerData.S.LingHun3 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.LingHun4:
                    if (PlayerData.S.LingHun4 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.LingHun5:
                    if (PlayerData.S.LingHun5 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.LingHun6:
                    if (PlayerData.S.LingHun6 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                
                
                
                
                case TitleType.Huo1:
                    if (PlayerData.S.Huo1 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Huo2:
                    if (PlayerData.S.Huo2 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
               
                
                case TitleType.Huo3:
                    if (PlayerData.S.Huo3 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Huo4:
                    if (PlayerData.S.Huo4 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Huo5:
                    if (PlayerData.S.Huo5 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Huo6:
                    if (PlayerData.S.Huo6 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                
                
                
                case TitleType.HeiAn1:
                    if (PlayerData.S.HeiAn1 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.HeiAn2:
                    if (PlayerData.S.HeiAn2 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
               
                
                case TitleType.HeiAn3:
                    if (PlayerData.S.HeiAn3 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.HeiAn4:
                    if (PlayerData.S.HeiAn4 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.HeiAn5:
                    if (PlayerData.S.HeiAn5 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.HeiAn6:
                    if (PlayerData.S.HeiAn6 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                
                
                
                case TitleType.Ice1:
                    if (PlayerData.S.Ice1 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Ice2:
                    if (PlayerData.S.Ice2 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
               
                
                case TitleType.Ice3:
                    if (PlayerData.S.Ice3 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Ice4:
                    if (PlayerData.S.Ice4 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Ice5:
                    if (PlayerData.S.Ice5 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Ice6:
                    if (PlayerData.S.Ice6 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                
                
                case TitleType.Dian1:
                    if (PlayerData.S.Dian1 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Dian2:
                    if (PlayerData.S.Dian2 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
               
                
                case TitleType.Dian3:
                    if (PlayerData.S.Dian3 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Dian4:
                    if (PlayerData.S.Dian4 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Dian5:
                    if (PlayerData.S.Dian5 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                case TitleType.Dian6:
                    if (PlayerData.S.Dian6 == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
                
                
                
                
                
                
                case TitleType.DiaoLuo:
                    if (PlayerData.S.DiaoLuo == false)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"未激活");
                        return;
                    }
                    break;
            }
            
            ResetTitleGou(CurrentTitleType);
            PlayerData.S.CurrentInstallTitle = CurrentTitleType;
            ObserverModuleManager.S.SendEvent("ShowTitle");
        });
        ObserverModuleManager.S.RegisterEvent("TitleInfo", TitleInfo);
    }

    public void ResetTitleGou(TitleType type)
    {
        if (PlayerData.S.CurrentInstallTitle != TitleType.None)
        {
            TitleItemDic[PlayerData.S.CurrentInstallTitle].Gou.gameObject.SetActive(false);
        }
        TitleItemDic[type].Gou.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("TitleInfo", TitleInfo);
    }

    public void TitleInfo(object[] obj)
    {
        InstallButton.gameObject.SetActive(true);
        
        Level5Image.gameObject.SetActive(false);
        Level15Image.gameObject.SetActive(false);
        Level30Image.gameObject.SetActive(false);
        Level50Image.gameObject.SetActive(false);
        Level75Image.gameObject.SetActive(false);
        Level100Image.gameObject.SetActive(false);
        
        LingHun1Image.gameObject.SetActive(false);
        LingHun2Image.gameObject.SetActive(false);
        LingHun3Image.gameObject.SetActive(false);
        LingHun4Image.gameObject.SetActive(false);
        LingHun5Image.gameObject.SetActive(false);
        LingHun6Image.gameObject.SetActive(false);
        
        Monster1Image.gameObject.SetActive(false);
        Monster2Image.gameObject.SetActive(false);
        Monster3Image.gameObject.SetActive(false);
        Monster4Image.gameObject.SetActive(false);
        Monster5Image.gameObject.SetActive(false);
        Monster6Image.gameObject.SetActive(false);
        
        GuanKa1Image.gameObject.SetActive(false);
        GuanKa2Image.gameObject.SetActive(false);
        GuanKa3Image.gameObject.SetActive(false);
        GuanKa4Image.gameObject.SetActive(false);
        GuanKa5Image.gameObject.SetActive(false);
        GuanKa6Image.gameObject.SetActive(false);
        
        HeiAn1Image.gameObject.SetActive(false);
        HeiAn2Image.gameObject.SetActive(false);
        HeiAn3Image.gameObject.SetActive(false);
        HeiAn4Image.gameObject.SetActive(false);
        HeiAn5Image.gameObject.SetActive(false);
        HeiAn6Image.gameObject.SetActive(false);
        
        Huo1Image.gameObject.SetActive(false);
        Huo2Image.gameObject.SetActive(false);
        Huo3Image.gameObject.SetActive(false);
        Huo4Image.gameObject.SetActive(false);
        Huo5Image.gameObject.SetActive(false);
        Huo6Image.gameObject.SetActive(false);
        
        Dian1Image.gameObject.SetActive(false);
        Dian2Image.gameObject.SetActive(false);
        Dian3Image.gameObject.SetActive(false);
        Dian4Image.gameObject.SetActive(false);
        Dian5Image.gameObject.SetActive(false);
        Dian6Image.gameObject.SetActive(false);
        
        Ice1Image.gameObject.SetActive(false);
        Ice2Image.gameObject.SetActive(false);
        Ice3Image.gameObject.SetActive(false);
        Ice4Image.gameObject.SetActive(false);
        Ice5Image.gameObject.SetActive(false);
        Ice6Image.gameObject.SetActive(false);
        
        DiaoLuoImage.gameObject.SetActive(false);
        
        
        Level5TextMeshProUGUI.gameObject.SetActive(false);
        Level15TextMeshProUGUI.gameObject.SetActive(false);
        Level30TextMeshProUGUI.gameObject.SetActive(false);
        Level50TextMeshProUGUI.gameObject.SetActive(false);
        Level75TextMeshProUGUI.gameObject.SetActive(false);
        Level100TextMeshProUGUI.gameObject.SetActive(false);
        
        LingHun1TextMeshProUGUI.gameObject.SetActive(false);
        LingHun2TextMeshProUGUI.gameObject.SetActive(false);
        LingHun3TextMeshProUGUI.gameObject.SetActive(false);
        LingHun4TextMeshProUGUI.gameObject.SetActive(false);
        LingHun5TextMeshProUGUI.gameObject.SetActive(false);
        LingHun6TextMeshProUGUI.gameObject.SetActive(false);
        
        Monster1TextMeshProUGUI.gameObject.SetActive(false);
        Monster2TextMeshProUGUI.gameObject.SetActive(false);
        Monster3TextMeshProUGUI.gameObject.SetActive(false);
        Monster4TextMeshProUGUI.gameObject.SetActive(false);
        Monster5TextMeshProUGUI.gameObject.SetActive(false);
        Monster6TextMeshProUGUI.gameObject.SetActive(false);
        
        GuanKa1TextMeshProUGUI.gameObject.SetActive(false);
        GuanKa2TextMeshProUGUI.gameObject.SetActive(false);
        GuanKa3TextMeshProUGUI.gameObject.SetActive(false);
        GuanKa4TextMeshProUGUI.gameObject.SetActive(false);
        GuanKa5TextMeshProUGUI.gameObject.SetActive(false);
        GuanKa6TextMeshProUGUI.gameObject.SetActive(false);
        
        HeiAn1TextMeshProUGUI.gameObject.SetActive(false);
        HeiAn2TextMeshProUGUI.gameObject.SetActive(false);
        HeiAn3TextMeshProUGUI.gameObject.SetActive(false);
        HeiAn4TextMeshProUGUI.gameObject.SetActive(false);
        HeiAn5TextMeshProUGUI.gameObject.SetActive(false);
        HeiAn6TextMeshProUGUI.gameObject.SetActive(false);
        
        Huo1TextMeshProUGUI.gameObject.SetActive(false);
        Huo2TextMeshProUGUI.gameObject.SetActive(false);
        Huo3TextMeshProUGUI.gameObject.SetActive(false);
        Huo4TextMeshProUGUI.gameObject.SetActive(false);
        Huo5TextMeshProUGUI.gameObject.SetActive(false);
        Huo6TextMeshProUGUI.gameObject.SetActive(false);
        
        Dian1TextMeshProUGUI.gameObject.SetActive(false);
        Dian2TextMeshProUGUI.gameObject.SetActive(false);
        Dian3TextMeshProUGUI.gameObject.SetActive(false);
        Dian4TextMeshProUGUI.gameObject.SetActive(false);
        Dian5TextMeshProUGUI.gameObject.SetActive(false);
        Dian6TextMeshProUGUI.gameObject.SetActive(false);
        
        Ice1TextMeshProUGUI.gameObject.SetActive(false);
        Ice2TextMeshProUGUI.gameObject.SetActive(false);
        Ice3TextMeshProUGUI.gameObject.SetActive(false);
        Ice4TextMeshProUGUI.gameObject.SetActive(false);
        Ice5TextMeshProUGUI.gameObject.SetActive(false);
        Ice6TextMeshProUGUI.gameObject.SetActive(false);
        
        DiaoLuoTextMeshProUGUI.gameObject.SetActive(false);
        
        TitleType titleType = (TitleType)obj[0];
        switch (titleType)
        {
            case TitleType.Level5:
                Level5Image.gameObject.SetActive(true);
                Level5TextMeshProUGUI.gameObject.SetActive(true);
                Level5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Level5;
                break;
            case TitleType.Level15:
                Level15Image.gameObject.SetActive(true);
                Level15TextMeshProUGUI.gameObject.SetActive(true);
                Level15TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Level15;
                break;
            case TitleType.Level30:
                Level30Image.gameObject.SetActive(true);
                Level30TextMeshProUGUI.gameObject.SetActive(true);
                Level30TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Level30;
                break;
            case TitleType.Level50:
                Level50Image.gameObject.SetActive(true);
                Level50TextMeshProUGUI.gameObject.SetActive(true);
                Level50TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Level50;
                break;
            case TitleType.Level75:
                Level75Image.gameObject.SetActive(true);
                Level75TextMeshProUGUI.gameObject.SetActive(true);
                Level75TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Level75;
                break;
            case TitleType.Level100:
                Level100Image.gameObject.SetActive(true);
                Level100TextMeshProUGUI.gameObject.SetActive(true);
                Level100TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Level100;
                break;
            
            case TitleType.MonsterCount1:
                Monster1Image.gameObject.SetActive(true);
                Monster1TextMeshProUGUI.gameObject.SetActive(true);
                Monster1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.MonsterCount1;
                break;
            
            case TitleType.MonsterCount2:
                Monster2Image.gameObject.SetActive(true);
                Monster2TextMeshProUGUI.gameObject.SetActive(true);
                Monster2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.MonsterCount2;
                break;
            case TitleType.MonsterCount3:
                Monster3Image.gameObject.SetActive(true);
                Monster3TextMeshProUGUI.gameObject.SetActive(true);
                Monster3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.MonsterCount3;
                break;
            case TitleType.MonsterCount4:
                Monster4Image.gameObject.SetActive(true);
                Monster4TextMeshProUGUI.gameObject.SetActive(true);
                Monster4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.MonsterCount4;
                break;
            case TitleType.MonsterCount5:
                Monster5Image.gameObject.SetActive(true);
                Monster5TextMeshProUGUI.gameObject.SetActive(true);
                Monster5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.MonsterCount5;
                break;
            case TitleType.MonsterCount6:
                Monster6Image.gameObject.SetActive(true);
                Monster6TextMeshProUGUI.gameObject.SetActive(true);
                Monster6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.MonsterCount6;
                break;
            
            case TitleType.LingHun1:
                LingHun1Image.gameObject.SetActive(true);
                LingHun1TextMeshProUGUI.gameObject.SetActive(true);
                LingHun1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.LingHun1;
                break;
            
            case TitleType.LingHun2:
                LingHun2Image.gameObject.SetActive(true);
                LingHun2TextMeshProUGUI.gameObject.SetActive(true);
                LingHun2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.LingHun2;
                break;
            case TitleType.LingHun3:
                LingHun3Image.gameObject.SetActive(true);
                LingHun3TextMeshProUGUI.gameObject.SetActive(true);
                LingHun3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.LingHun3;
                break;
            case TitleType.LingHun4:
                LingHun4Image.gameObject.SetActive(true);
                LingHun4TextMeshProUGUI.gameObject.SetActive(true);
                LingHun4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.LingHun4;
                break;
            case TitleType.LingHun5:
                LingHun5Image.gameObject.SetActive(true);
                LingHun5TextMeshProUGUI.gameObject.SetActive(true);
                LingHun5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.LingHun5;
                break;
            case TitleType.LingHun6:
                LingHun6Image.gameObject.SetActive(true);
                LingHun6TextMeshProUGUI.gameObject.SetActive(true);
                LingHun6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.LingHun6;
                break;
            
            
            
            
            case TitleType.GuanKa1:
                GuanKa1Image.gameObject.SetActive(true);
                GuanKa1TextMeshProUGUI.gameObject.SetActive(true);
                GuanKa1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.GuanKa1;
                break;
            
            case TitleType.GuanKa2:
                GuanKa2Image.gameObject.SetActive(true);
                GuanKa2TextMeshProUGUI.gameObject.SetActive(true);
                GuanKa2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.GuanKa2;
                break;
            case TitleType.GuanKa3:
                GuanKa3Image.gameObject.SetActive(true);
                GuanKa3TextMeshProUGUI.gameObject.SetActive(true);
                GuanKa3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.GuanKa3;
                break;
            case TitleType.GuanKa4:
                GuanKa4Image.gameObject.SetActive(true);
                GuanKa4TextMeshProUGUI.gameObject.SetActive(true);
                GuanKa4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.GuanKa4;
                break;
            case TitleType.GuanKa5:
                GuanKa5Image.gameObject.SetActive(true);
                GuanKa5TextMeshProUGUI.gameObject.SetActive(true);
                GuanKa5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.GuanKa5;
                break;
            case TitleType.GuanKa6:
                GuanKa6Image.gameObject.SetActive(true);
                GuanKa6TextMeshProUGUI.gameObject.SetActive(true);
                GuanKa6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.GuanKa6;
                break;
            
            
            
            
            
            case TitleType.Dian1:
                Dian1Image.gameObject.SetActive(true);
                Dian1TextMeshProUGUI.gameObject.SetActive(true);
                Dian1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Dian1;
                break;
            
            case TitleType.Dian2:
                Dian2Image.gameObject.SetActive(true);
                Dian2TextMeshProUGUI.gameObject.SetActive(true);
                Dian2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Dian2;
                break;
            case TitleType.Dian3:
                Dian3Image.gameObject.SetActive(true);
                Dian3TextMeshProUGUI.gameObject.SetActive(true);
                Dian3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Dian3;
                break;
            case TitleType.Dian4:
                Dian4Image.gameObject.SetActive(true);
                Dian4TextMeshProUGUI.gameObject.SetActive(true);
                Dian4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Dian4;
                break;
            case TitleType.Dian5:
                Dian5Image.gameObject.SetActive(true);
                Dian5TextMeshProUGUI.gameObject.SetActive(true);
                Dian5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Dian5;
                break;
            case TitleType.Dian6:
                Dian6Image.gameObject.SetActive(true);
                Dian6TextMeshProUGUI.gameObject.SetActive(true);
                Dian6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Dian6;
                break;
            
            
            
            
            
            case TitleType.HeiAn1:
                HeiAn1Image.gameObject.SetActive(true);
                HeiAn1TextMeshProUGUI.gameObject.SetActive(true);
                HeiAn1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.HeiAn1;
                break;
            
            case TitleType.HeiAn2:
                HeiAn2Image.gameObject.SetActive(true);
                HeiAn2TextMeshProUGUI.gameObject.SetActive(true);
                HeiAn2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.HeiAn2;
                break;
            case TitleType.HeiAn3:
                HeiAn3Image.gameObject.SetActive(true);
                HeiAn3TextMeshProUGUI.gameObject.SetActive(true);
                HeiAn3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.HeiAn3;
                break;
            case TitleType.HeiAn4:
                HeiAn4Image.gameObject.SetActive(true);
                HeiAn4TextMeshProUGUI.gameObject.SetActive(true);
                HeiAn4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.HeiAn4;
                break;
            case TitleType.HeiAn5:
                HeiAn5Image.gameObject.SetActive(true);
                HeiAn5TextMeshProUGUI.gameObject.SetActive(true);
                HeiAn5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.HeiAn5;
                break;
            case TitleType.HeiAn6:
                HeiAn6Image.gameObject.SetActive(true);
                HeiAn6TextMeshProUGUI.gameObject.SetActive(true);
                HeiAn6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.HeiAn6;
                break;
            
            
            
            
            case TitleType.Ice1:
                Ice1Image.gameObject.SetActive(true);
                Ice1TextMeshProUGUI.gameObject.SetActive(true);
                Ice1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Ice1;
                break;
            
            case TitleType.Ice2:
                Ice2Image.gameObject.SetActive(true);
                Ice2TextMeshProUGUI.gameObject.SetActive(true);
                Ice2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Ice2;
                break;
            case TitleType.Ice3:
                Ice3Image.gameObject.SetActive(true);
                Ice3TextMeshProUGUI.gameObject.SetActive(true);
                Ice3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Ice3;
                break;
            case TitleType.Ice4:
                Ice4Image.gameObject.SetActive(true);
                Ice4TextMeshProUGUI.gameObject.SetActive(true);
                Ice4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Ice4;
                break;
            case TitleType.Ice5:
                Ice5Image.gameObject.SetActive(true);
                Ice5TextMeshProUGUI.gameObject.SetActive(true);
                Ice5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Ice5;
                break;
            case TitleType.Ice6:
                Ice6Image.gameObject.SetActive(true);
                Ice6TextMeshProUGUI.gameObject.SetActive(true);
                Ice6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Ice6;
                break;
            
            
            
            
            case TitleType.Huo1:
                Huo1Image.gameObject.SetActive(true);
                Huo1TextMeshProUGUI.gameObject.SetActive(true);
                Huo1TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Huo1;
                break;
            
            case TitleType.Huo2:
                Huo2Image.gameObject.SetActive(true);
                Huo2TextMeshProUGUI.gameObject.SetActive(true);
                Huo2TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Huo2;
                break;
            case TitleType.Huo3:
                Huo3Image.gameObject.SetActive(true);
                Huo3TextMeshProUGUI.gameObject.SetActive(true);
                Huo3TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Huo3;
                break;
            case TitleType.Huo4:
                Huo4Image.gameObject.SetActive(true);
                Huo4TextMeshProUGUI.gameObject.SetActive(true);
                Huo4TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Huo4;
                break;
            case TitleType.Huo5:
                Huo5Image.gameObject.SetActive(true);
                Huo5TextMeshProUGUI.gameObject.SetActive(true);
                Huo5TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Huo5;
                break;
            case TitleType.Huo6:
                Huo6Image.gameObject.SetActive(true);
                Huo6TextMeshProUGUI.gameObject.SetActive(true);
                Huo6TextMeshProUGUI.text = TitleConfig.TitleNameDic[titleType];
                CurrentTitleType = TitleType.Huo6;
                break;
            
        }
        ImageGameObject.gameObject.SetActive(true);
        JiHuoTiaoJianGameObject.gameObject.SetActive(true);
        JiHuoAttributeGameObject.gameObject.SetActive(true);
        InstallAttributeGameObject.gameObject.SetActive(true);
        JiHuoTiaoJianText.text=TitleConfig.TitleJiHuoDic[titleType];
        foreach (Transform item in JiHuoAttributeContent.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in TitleConfig.TitleAttributeDic[titleType].JiHuoList)
        {
            var TitleCiTiaoItem =
                Instantiate(Resources.Load("Prefabs/Title/TitleCiTiaoItem"), JiHuoAttributeContent.transform)
                    .GetComponent<TitleCiTiaoItem>();
            TitleCiTiaoItem.Type = item.Type;
            TitleCiTiaoItem.Value = item.Value;
            TitleCiTiaoItem.SetItem();
        }
        
        
        
        foreach (Transform item in InstallAttributeContent.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in TitleConfig.TitleAttributeDic[titleType].InstallList)
        {
            var TitleCiTiaoItem =
                Instantiate(Resources.Load("Prefabs/Title/TitleCiTiaoItem"), InstallAttributeContent.transform)
                    .GetComponent<TitleCiTiaoItem>();
            TitleCiTiaoItem.Type = item.Type;
            TitleCiTiaoItem.Value = item.Value;
            TitleCiTiaoItem.SetItem();
        }
    }

    public void ShowTitleList()
    {
        TitleItemDic.Clear();
        foreach (Transform item in TitleListContent.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in TitleConfig.TitleNameDic)
        {
            TitleItem titleitem = Instantiate(Resources.Load<GameObject>("Prefabs/Title/TitleItem"), TitleListContent.transform).GetComponent<TitleItem>();
            titleitem.TitleItemType=item.Key;
            titleitem.SetItem();
            TitleItemDic.Add(item.Key, titleitem);
        }
    }

    private void OnEnable()
    {
        ImageGameObject.gameObject.SetActive(false);
        JiHuoTiaoJianGameObject.gameObject.SetActive(false);
        JiHuoAttributeGameObject.gameObject.SetActive(false);
        InstallAttributeGameObject.gameObject.SetActive(false);
        InstallButton.gameObject.SetActive(false);
        ShowTitleList();
    }
}
