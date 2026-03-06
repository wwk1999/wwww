using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SkillSwitch : MonoBehaviour
{
    public Button Alpha1;
    public Button Alpha2;
    public Button Alpha3;
    public Button Alpha4;
    public Button Alpha5;
    public Button Auto;
    public GameObject mask;
    [NonSerialized] public SkillType ClickType;


    public GameObject Ice1Auto;
    public GameObject Ice2Auto;
    public GameObject Ice3Auto;
    public GameObject Ice4Auto;
    public GameObject Ice5Auto;
    public GameObject Ice1AutoBg;
    public GameObject Ice2AutoBg;
    public GameObject Ice3AutoBg;
    public GameObject Ice4AutoBg;
    public GameObject Ice5AutoBg;
    public GameObject Ice1Key;
    public GameObject Ice2Key;
    public GameObject Ice3Key;
    public GameObject Ice4Key;
    public GameObject Ice5Key;
    
    public GameObject Huo1Auto;
    public GameObject Huo2Auto;
    public GameObject Huo3Auto;
    public GameObject Huo4Auto;
    public GameObject Huo5Auto;
    public GameObject Huo1AutoBg;
    public GameObject Huo2AutoBg;
    public GameObject Huo3AutoBg;
    public GameObject Huo4AutoBg;
    public GameObject Huo5AutoBg;
    public GameObject Huo1Key;
    public GameObject Huo2Key;
    public GameObject Huo3Key;
    public GameObject Huo4Key;
    public GameObject Huo5Key;
    
    public GameObject Dian1Auto;
    public GameObject Dian2Auto;
    public GameObject Dian3Auto;
    public GameObject Dian4Auto;
    public GameObject Dian5Auto;
    public GameObject Dian1AutoBg;
    public GameObject Dian2AutoBg;
    public GameObject Dian3AutoBg;
    public GameObject Dian4AutoBg;
    public GameObject Dian5AutoBg;
    public GameObject Dian1Key;
    public GameObject Dian2Key;
    public GameObject Dian3Key;
    public GameObject Dian4Key;
    public GameObject Dian5Key;
    
    public GameObject HeiAn1Auto;
    public GameObject HeiAn2Auto;
    public GameObject HeiAn3Auto;
    public GameObject HeiAn4Auto;
    public GameObject HeiAn5Auto;
    public GameObject HeiAn1AutoBg;
    public GameObject HeiAn2AutoBg;
    public GameObject HeiAn3AutoBg;
    public GameObject HeiAn4AutoBg;
    public GameObject HeiAn5AutoBg;
    public GameObject HeiAn1Key;
    public GameObject HeiAn2Key;
    public GameObject HeiAn3Key;
    public GameObject HeiAn4Key;
    public GameObject HeiAn5Key;

    public SkillWindow1 skillWindow1;

    public void SetKey()
    {
        Ice1Key.SetActive(false);
        Ice2Key.SetActive(false);
        Ice3Key.SetActive(false);
        Ice4Key.SetActive(false);
        Ice5Key.SetActive(false);
        
        HeiAn1Key.SetActive(false);
        HeiAn2Key.SetActive(false);
        HeiAn3Key.SetActive(false);
        HeiAn4Key.SetActive(false);
        HeiAn5Key.SetActive(false);
        
        Dian1Key.SetActive(false);
        Dian2Key.SetActive(false);
        Dian3Key.SetActive(false);
        Dian4Key.SetActive(false);
        Dian5Key.SetActive(false);
        
        Huo1Key.SetActive(false);
        Huo2Key.SetActive(false);
        Huo3Key.SetActive(false);
        Huo4Key.SetActive(false);
        Huo5Key.SetActive(false);

        ShowKey(SkillJiaDian.S.Alpha1, "1");
        ShowKey(SkillJiaDian.S.Alpha2, "2");
        ShowKey(SkillJiaDian.S.Alpha3, "3");
        ShowKey(SkillJiaDian.S.Alpha4, "4");
        ShowKey(SkillJiaDian.S.Alpha5, "5");

    }

    public void ShowKey(SkillType skillType,string str)
    {
         switch (skillType)
        {
            case SkillType.Ice1:
                Ice1Key.SetActive(true);
                Ice1Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.Ice2:
                Ice2Key.SetActive(true);
                Ice2Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.Ice3:
                Ice3Key.SetActive(true);
                Ice3Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.Ice4:
                Ice4Key.SetActive(true);
                Ice4Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.Ice5:
                Ice5Key.SetActive(true);
                Ice5Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            
            
            case SkillType.Huo1:
                Huo1Key.SetActive(true);
                Huo1Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.Huo2:
                Huo2Key.SetActive(true);
                Huo2Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.Huo3:
                Huo3Key.SetActive(true);
                Huo3Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.Huo4:
                Huo4Key.SetActive(true);
                Huo4Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.Huo5:
                Huo5Key.SetActive(true);
                Huo5Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            
            case SkillType.Dian1:
                Dian1Key.SetActive(true);
                Dian1Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.Dian2:
                Dian2Key.SetActive(true);
                Dian2Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.Dian3:
                Dian3Key.SetActive(true);
                Dian3Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.Dian4:
                Dian4Key.SetActive(true);
                Dian4Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.Dian5:
                Dian5Key.SetActive(true);
                Dian5Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            
            case SkillType.HeiAn1:
                HeiAn1Key.SetActive(true);
                HeiAn1Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.HeiAn2:
                HeiAn2Key.SetActive(true);
                HeiAn2Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.HeiAn3:
                HeiAn3Key.SetActive(true);
                HeiAn3Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.HeiAn4:
                HeiAn4Key.SetActive(true);
                HeiAn4Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
            
            case SkillType.HeiAn5:
                HeiAn5Key.SetActive(true);
                HeiAn5Key.GetComponent<TextMeshProUGUI>().text = str;
                break;
        }
    }
    
    public void SetAuto(SkillType skillType,bool Active)
    {
        switch (skillType)
        {
            case SkillType.Ice1:
                SkillJiaDian.S.Ice1Auto = Active;
                Ice1Auto.SetActive(Active);
                Ice1AutoBg.SetActive(Active);
                break;
            case SkillType.Ice2:
                SkillJiaDian.S.Ice2Auto = Active;
                Ice2Auto.SetActive(Active);
                Ice2AutoBg.SetActive(Active);
                break;
            case SkillType.Ice3:
                SkillJiaDian.S.Ice3Auto = Active;

                Ice3Auto.SetActive(Active);
                Ice3AutoBg.SetActive(Active);

                break;
            case SkillType.Ice4:
                SkillJiaDian.S.Ice4Auto = Active;

                Ice4Auto.SetActive(Active);
                Ice4AutoBg.SetActive(Active);

                break;
            case SkillType.Ice5:
                SkillJiaDian.S.Ice5Auto = Active;

                Ice5Auto.SetActive(Active);
                Ice5AutoBg.SetActive(Active);

                break;
            
            
            case SkillType.Huo1:
                SkillJiaDian.S.Huo1Auto = Active;

                Huo1Auto.SetActive(Active);
                Ice1AutoBg.SetActive(Active);

                break;
            case SkillType.Huo2:
                SkillJiaDian.S.Huo2Auto = Active;

                Huo2Auto.SetActive(Active);
                Ice2AutoBg.SetActive(Active);

                break;
            case SkillType.Huo3:
                SkillJiaDian.S.Huo3Auto = Active;

                Huo3Auto.SetActive(Active);
                Ice3AutoBg.SetActive(Active);

                break;
            case SkillType.Huo4:
                SkillJiaDian.S.Huo4Auto = Active;

                Huo4Auto.SetActive(Active);
                Ice4AutoBg.SetActive(Active);

                break;
            case SkillType.Huo5:
                SkillJiaDian.S.Huo5Auto = Active;

                Huo5Auto.SetActive(Active);
                Ice5AutoBg.SetActive(Active);

                break;
            
            
            case SkillType.Dian1:
                SkillJiaDian.S.Dian1Auto = Active;

                Dian1Auto.SetActive(Active);
                Dian1AutoBg.SetActive(Active);

                break;
            case SkillType.Dian2:
                SkillJiaDian.S.Dian2Auto = Active;

                Dian2Auto.SetActive(Active);
                Dian2AutoBg.SetActive(Active);

                break;
            case SkillType.Dian3:
                SkillJiaDian.S.Dian3Auto = Active;

                Dian3Auto.SetActive(Active);
                Dian3AutoBg.SetActive(Active);

                break;
            case SkillType.Dian4:
                SkillJiaDian.S.Dian4Auto = Active;

                Dian4Auto.SetActive(Active);
                Dian4AutoBg.SetActive(Active);

                break;
            case SkillType.Dian5:
                SkillJiaDian.S.Dian5Auto = Active;

                Dian5Auto.SetActive(Active);
                Dian5AutoBg.SetActive(Active);

                break;
            
            
            case SkillType.HeiAn1:
                SkillJiaDian.S.HeiAn1Auto = Active;

                HeiAn1Auto.SetActive(Active);
                HeiAn1AutoBg.SetActive(Active);

                break;
            case SkillType.HeiAn2:
                SkillJiaDian.S.HeiAn2Auto = Active;

                HeiAn2Auto.SetActive(Active);
                HeiAn2AutoBg.SetActive(Active);

                break;
            case SkillType.HeiAn3:
                SkillJiaDian.S.HeiAn3Auto = Active;

                HeiAn3Auto.SetActive(Active);
                HeiAn3AutoBg.SetActive(Active);

                break;
            case SkillType.HeiAn4:
                SkillJiaDian.S.HeiAn4Auto = Active;

                HeiAn4Auto.SetActive(Active);
                HeiAn4AutoBg.SetActive(Active);

                break;
            case SkillType.HeiAn5:
                SkillJiaDian.S.HeiAn5Auto = Active;

                HeiAn5Auto.SetActive(Active);
                HeiAn5AutoBg.SetActive(Active);

                break;
        }
    }

    
    [NonSerialized]public SkillType buttonType=SkillType.None;

    
    [NonSerialized]public MouseRightListen ClickMouseRightListen;

    private void OnEnable()
    {
        mask.SetActive(true);
        mask.GetComponent<Button>().onClick.AddListener(() =>
        {
            mask.SetActive(false);
        });
    }

    private void Start()
    {
        Alpha1.onClick.AddListener(() =>
        {
            switch (ClickType)
            {
                case SkillType.Ice1:
                    SkillJiaDian.S.Alpha1 = SkillType.Ice1;
                    break;
                case SkillType.Ice2:
                    SkillJiaDian.S.Alpha1 = SkillType.Ice2;
                    break;
                case SkillType.Ice3:
                    SkillJiaDian.S.Alpha1 = SkillType.Ice3;
                    break;
                case SkillType.Ice4:
                    SkillJiaDian.S.Alpha1 = SkillType.Ice4;
                    break;
                case SkillType.Ice5:
                    SkillJiaDian.S.Alpha1 = SkillType.Ice5;
                    break;
                
                case SkillType.Huo1:
                    SkillJiaDian.S.Alpha1 = SkillType.Huo1;
                    break;
                case SkillType.Huo2:
                    SkillJiaDian.S.Alpha1 = SkillType.Huo2;
                    break;
                case SkillType.Huo3:
                    SkillJiaDian.S.Alpha1 = SkillType.Huo3;
                    break;
                case SkillType.Huo4:
                    SkillJiaDian.S.Alpha1 = SkillType.Huo4;
                    break;
                case SkillType.Huo5:
                    SkillJiaDian.S.Alpha1 = SkillType.Huo5;
                    break;
                
                case SkillType.Dian1:
                    SkillJiaDian.S.Alpha1 = SkillType.Dian1;
                    break;
                case SkillType.Dian2:
                    SkillJiaDian.S.Alpha1 = SkillType.Dian2;
                    break;
                case SkillType.Dian3:
                    SkillJiaDian.S.Alpha1 = SkillType.Dian3;
                    break;
                case SkillType.Dian4:
                    SkillJiaDian.S.Alpha1 = SkillType.Dian4;
                    break;
                case SkillType.Dian5:
                    SkillJiaDian.S.Alpha1 = SkillType.Dian5;
                    break;
                
                case SkillType.HeiAn1:
                    SkillJiaDian.S.Alpha1 = SkillType.HeiAn1;
                    break;
                case SkillType.HeiAn2:
                    SkillJiaDian.S.Alpha1 = SkillType.HeiAn2;
                    break;
                case SkillType.HeiAn3:
                    SkillJiaDian.S.Alpha1 = SkillType.HeiAn3;
                    break;
                case SkillType.HeiAn4:
                    SkillJiaDian.S.Alpha1 = SkillType.HeiAn4;
                    break;
                case SkillType.HeiAn5:
                    SkillJiaDian.S.Alpha1 = SkillType.HeiAn5;
                    break;
            }
            SetKey();
            gameObject.SetActive(false);
        });
        
        
         Alpha2.onClick.AddListener(() =>
        {
            switch (ClickType)
            {
                case SkillType.Ice1:
                    SkillJiaDian.S.Alpha2 = SkillType.Ice1;
                    break;
                case SkillType.Ice2:
                    SkillJiaDian.S.Alpha2 = SkillType.Ice2;
                    break;
                case SkillType.Ice3:
                    SkillJiaDian.S.Alpha2 = SkillType.Ice3;
                    break;
                case SkillType.Ice4:
                    SkillJiaDian.S.Alpha2 = SkillType.Ice4;
                    break;
                case SkillType.Ice5:
                    SkillJiaDian.S.Alpha2 = SkillType.Ice5;
                    break;
                
                case SkillType.Huo1:
                    SkillJiaDian.S.Alpha2 = SkillType.Huo1;
                    break;
                case SkillType.Huo2:
                    SkillJiaDian.S.Alpha2 = SkillType.Huo2;
                    break;
                case SkillType.Huo3:
                    SkillJiaDian.S.Alpha2 = SkillType.Huo3;
                    break;
                case SkillType.Huo4:
                    SkillJiaDian.S.Alpha2 = SkillType.Huo4;
                    break;
                case SkillType.Huo5:
                    SkillJiaDian.S.Alpha2 = SkillType.Huo5;
                    break;
                
                case SkillType.Dian1:
                    SkillJiaDian.S.Alpha2 = SkillType.Dian1;
                    break;
                case SkillType.Dian2:
                    SkillJiaDian.S.Alpha2 = SkillType.Dian2;
                    break;
                case SkillType.Dian3:
                    SkillJiaDian.S.Alpha2 = SkillType.Dian3;
                    break;
                case SkillType.Dian4:
                    SkillJiaDian.S.Alpha2 = SkillType.Dian4;
                    break;
                case SkillType.Dian5:
                    SkillJiaDian.S.Alpha2 = SkillType.Dian5;
                    break;
                
                case SkillType.HeiAn1:
                    SkillJiaDian.S.Alpha2 = SkillType.HeiAn1;
                    break;
                case SkillType.HeiAn2:
                    SkillJiaDian.S.Alpha2 = SkillType.HeiAn2;
                    break;
                case SkillType.HeiAn3:
                    SkillJiaDian.S.Alpha2 = SkillType.HeiAn3;
                    break;
                case SkillType.HeiAn4:
                    SkillJiaDian.S.Alpha2 = SkillType.HeiAn4;
                    break;
                case SkillType.HeiAn5:
                    SkillJiaDian.S.Alpha2 = SkillType.HeiAn5;
                    break;
            }
            SetKey();
            gameObject.SetActive(false);
        });
         
         
          Alpha3.onClick.AddListener(() =>
        {
            switch (ClickType)
            {
                case SkillType.Ice1:
                    SkillJiaDian.S.Alpha3 = SkillType.Ice1;
                    break;
                case SkillType.Ice2:
                    SkillJiaDian.S.Alpha3 = SkillType.Ice2;
                    break;
                case SkillType.Ice3:
                    SkillJiaDian.S.Alpha3 = SkillType.Ice3;
                    break;
                case SkillType.Ice4:
                    SkillJiaDian.S.Alpha3 = SkillType.Ice4;
                    break;
                case SkillType.Ice5:
                    SkillJiaDian.S.Alpha3 = SkillType.Ice5;
                    break;
                
                case SkillType.Huo1:
                    SkillJiaDian.S.Alpha3 = SkillType.Huo1;
                    break;
                case SkillType.Huo2:
                    SkillJiaDian.S.Alpha3 = SkillType.Huo2;
                    break;
                case SkillType.Huo3:
                    SkillJiaDian.S.Alpha3 = SkillType.Huo3;
                    break;
                case SkillType.Huo4:
                    SkillJiaDian.S.Alpha3 = SkillType.Huo4;
                    break;
                case SkillType.Huo5:
                    SkillJiaDian.S.Alpha3 = SkillType.Huo5;
                    break;
                
                case SkillType.Dian1:
                    SkillJiaDian.S.Alpha3 = SkillType.Dian1;
                    break;
                case SkillType.Dian2:
                    SkillJiaDian.S.Alpha3 = SkillType.Dian2;
                    break;
                case SkillType.Dian3:
                    SkillJiaDian.S.Alpha3 = SkillType.Dian3;
                    break;
                case SkillType.Dian4:
                    SkillJiaDian.S.Alpha3 = SkillType.Dian4;
                    break;
                case SkillType.Dian5:
                    SkillJiaDian.S.Alpha3 = SkillType.Dian5;
                    break;
                
                case SkillType.HeiAn1:
                    SkillJiaDian.S.Alpha3 = SkillType.HeiAn1;
                    break;
                case SkillType.HeiAn2:
                    SkillJiaDian.S.Alpha3 = SkillType.HeiAn2;
                    break;
                case SkillType.HeiAn3:
                    SkillJiaDian.S.Alpha3 = SkillType.HeiAn3;
                    break;
                case SkillType.HeiAn4:
                    SkillJiaDian.S.Alpha3 = SkillType.HeiAn4;
                    break;
                case SkillType.HeiAn5:
                    SkillJiaDian.S.Alpha3 = SkillType.HeiAn5;
                    break;
            }
            SetKey();
            gameObject.SetActive(false);
        });
          
          
           Alpha4.onClick.AddListener(() =>
        {
            switch (ClickType)
            {
                case SkillType.Ice1:
                    SkillJiaDian.S.Alpha4 = SkillType.Ice1;
                    break;
                case SkillType.Ice2:
                    SkillJiaDian.S.Alpha4 = SkillType.Ice2;
                    break;
                case SkillType.Ice3:
                    SkillJiaDian.S.Alpha4 = SkillType.Ice3;
                    break;
                case SkillType.Ice4:
                    SkillJiaDian.S.Alpha4 = SkillType.Ice4;
                    break;
                case SkillType.Ice5:
                    SkillJiaDian.S.Alpha4 = SkillType.Ice5;
                    break;
                
                case SkillType.Huo1:
                    SkillJiaDian.S.Alpha4 = SkillType.Huo1;
                    break;
                case SkillType.Huo2:
                    SkillJiaDian.S.Alpha4 = SkillType.Huo2;
                    break;
                case SkillType.Huo3:
                    SkillJiaDian.S.Alpha4 = SkillType.Huo3;
                    break;
                case SkillType.Huo4:
                    SkillJiaDian.S.Alpha4 = SkillType.Huo4;
                    break;
                case SkillType.Huo5:
                    SkillJiaDian.S.Alpha4 = SkillType.Huo5;
                    break;
                
                case SkillType.Dian1:
                    SkillJiaDian.S.Alpha4 = SkillType.Dian1;
                    break;
                case SkillType.Dian2:
                    SkillJiaDian.S.Alpha4 = SkillType.Dian2;
                    break;
                case SkillType.Dian3:
                    SkillJiaDian.S.Alpha4 = SkillType.Dian3;
                    break;
                case SkillType.Dian4:
                    SkillJiaDian.S.Alpha4 = SkillType.Dian4;
                    break;
                case SkillType.Dian5:
                    SkillJiaDian.S.Alpha4 = SkillType.Dian5;
                    break;
                
                case SkillType.HeiAn1:
                    SkillJiaDian.S.Alpha4 = SkillType.HeiAn1;
                    break;
                case SkillType.HeiAn2:
                    SkillJiaDian.S.Alpha4 = SkillType.HeiAn2;
                    break;
                case SkillType.HeiAn3:
                    SkillJiaDian.S.Alpha4 = SkillType.HeiAn3;
                    break;
                case SkillType.HeiAn4:
                    SkillJiaDian.S.Alpha4 = SkillType.HeiAn4;
                    break;
                case SkillType.HeiAn5:
                    SkillJiaDian.S.Alpha4 = SkillType.HeiAn5;
                    break;
            }
            SetKey();
            gameObject.SetActive(false);
        });
           
           
            Alpha5.onClick.AddListener(() =>
        {
            switch (ClickType)
            {
                case SkillType.Ice1:
                    SkillJiaDian.S.Alpha5 = SkillType.Ice1;
                    break;
                case SkillType.Ice2:
                    SkillJiaDian.S.Alpha5 = SkillType.Ice2;
                    break;
                case SkillType.Ice3:
                    SkillJiaDian.S.Alpha5 = SkillType.Ice3;
                    break;
                case SkillType.Ice4:
                    SkillJiaDian.S.Alpha5 = SkillType.Ice4;
                    break;
                case SkillType.Ice5:
                    SkillJiaDian.S.Alpha5 = SkillType.Ice5;
                    break;
                
                case SkillType.Huo1:
                    SkillJiaDian.S.Alpha5 = SkillType.Huo1;
                    break;
                case SkillType.Huo2:
                    SkillJiaDian.S.Alpha5 = SkillType.Huo2;
                    break;
                case SkillType.Huo3:
                    SkillJiaDian.S.Alpha5 = SkillType.Huo3;
                    break;
                case SkillType.Huo4:
                    SkillJiaDian.S.Alpha5 = SkillType.Huo4;
                    break;
                case SkillType.Huo5:
                    SkillJiaDian.S.Alpha5 = SkillType.Huo5;
                    break;
                
                case SkillType.Dian1:
                    SkillJiaDian.S.Alpha5 = SkillType.Dian1;
                    break;
                case SkillType.Dian2:
                    SkillJiaDian.S.Alpha5 = SkillType.Dian2;
                    break;
                case SkillType.Dian3:
                    SkillJiaDian.S.Alpha5 = SkillType.Dian3;
                    break;
                case SkillType.Dian4:
                    SkillJiaDian.S.Alpha5 = SkillType.Dian4;
                    break;
                case SkillType.Dian5:
                    SkillJiaDian.S.Alpha5 = SkillType.Dian5;
                    break;
                
                case SkillType.HeiAn1:
                    SkillJiaDian.S.Alpha5 = SkillType.HeiAn1;
                    break;
                case SkillType.HeiAn2:
                    SkillJiaDian.S.Alpha5 = SkillType.HeiAn2;
                    break;
                case SkillType.HeiAn3:
                    SkillJiaDian.S.Alpha5 = SkillType.HeiAn3;
                    break;
                case SkillType.HeiAn4:
                    SkillJiaDian.S.Alpha5 = SkillType.HeiAn4;
                    break;
                case SkillType.HeiAn5:
                    SkillJiaDian.S.Alpha5 = SkillType.HeiAn5;
                    break;
            }
            SetKey();
            gameObject.SetActive(false);
        });
            
        Auto.onClick.AddListener(() =>
        {
            switch (ClickType)
            {
                case SkillType.Ice1:
                    SetAuto(SkillType.Ice1,!SkillJiaDian.S.Ice1Auto);   
                    break;
                case SkillType.Ice2:
                    SetAuto(SkillType.Ice2,!SkillJiaDian.S.Ice2Auto);   
                    break;
                case SkillType.Ice3:
                    SetAuto(SkillType.Ice3,!SkillJiaDian.S.Ice3Auto);   
                    break;
                case SkillType.Ice4:
                    SetAuto(SkillType.Ice4,!SkillJiaDian.S.Ice4Auto);   
                    break;
                case SkillType.Ice5:
                    SetAuto(SkillType.Ice5,!SkillJiaDian.S.Ice5Auto);   
                    break;
                
                
                case SkillType.Huo1:
                    SetAuto(SkillType.Huo1,!SkillJiaDian.S.Huo1Auto);   
                    break;
                case SkillType.Huo2:
                    SetAuto(SkillType.Huo2,!SkillJiaDian.S.Huo2Auto);   
                    break;
                case SkillType.Huo3:
                    SetAuto(SkillType.Huo3,!SkillJiaDian.S.Huo3Auto);   
                    break;
                case SkillType.Huo4:
                    SetAuto(SkillType.Huo4,!SkillJiaDian.S.Huo4Auto);   
                    break;
                case SkillType.Huo5:
                    SetAuto(SkillType.Huo5,!SkillJiaDian.S.Huo5Auto);   
                    break;
                
                
                case SkillType.Dian1:
                    SetAuto(SkillType.Dian1,!SkillJiaDian.S.Dian1Auto);   
                    break;
                case SkillType.Dian2:
                    SetAuto(SkillType.Dian2,!SkillJiaDian.S.Dian2Auto);   
                    break;
                case SkillType.Dian3:
                    SetAuto(SkillType.Dian3,!SkillJiaDian.S.Dian3Auto);   
                    break;
                case SkillType.Dian4:
                    SetAuto(SkillType.Dian4,!SkillJiaDian.S.Dian4Auto);   
                    break;
                case SkillType.Dian5:
                    SetAuto(SkillType.Dian5,!SkillJiaDian.S.Dian5Auto);   
                    break;
                
                
                case SkillType.HeiAn1:
                    SetAuto(SkillType.HeiAn1,!SkillJiaDian.S.HeiAn1Auto);   
                    break;
                case SkillType.HeiAn2:
                    SetAuto(SkillType.HeiAn2,!SkillJiaDian.S.HeiAn2Auto);   
                    break;
                case SkillType.HeiAn3:
                    SetAuto(SkillType.HeiAn3,!SkillJiaDian.S.HeiAn3Auto);   
                    break;
                case SkillType.HeiAn4:
                    SetAuto(SkillType.HeiAn4,!SkillJiaDian.S.HeiAn4Auto);   
                    break;
                case SkillType.HeiAn5:
                    SetAuto(SkillType.HeiAn5,!SkillJiaDian.S.HeiAn5Auto);   
                    break;
            }
            gameObject.SetActive(false);
        });
    }
}
