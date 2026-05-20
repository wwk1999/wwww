using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightBg : MonoBehaviour
{
    public Button weaponButton;
    public Button normalAttackButton;
    public Button fightStopButton;
    public Button dashButton;
    public Button rageButton;
    public Button shieldButton;
    public Button iceArrowButton;
    public Button iceExButton;
    public Button iceBallButton;
    public Image iceExYellowCd;
    public Image iceBallYellowCd;
    public Image iceArrowYellowCd;
    public Slider bossEnergySlider;
    public Text fightTimeText;
    public Slider playerHpSlider;
    public Slider playerExSlider;
    public Text playerLevelText;

    public TextMeshProUGUI GameMaxHp;
    public TextMeshProUGUI GameCurrentHp;
    
    
    
    public UIParticle iceArrowUIFX;
    public UIParticle iceBallUIFX;
    public UIParticle iceExUIFX;

    public Button jiHuoButton;
    public GameObject toastContent;
    
    public Button againButton;
    public Button returnButton;
    
    public Image RMB;
    public Image skill1;
    public Image skill2;
    public Image skill3;
    public Image skill4;
    public Image skill5;
    public GameObject ChuanSongZhen;
    public Animator ChuanSongZhenAnimator;


    private void Update()
    {
        if (FightBGController.S.IsBossJiHuo&&!GameController.S.HaveBoss)
        {
            jiHuoButton.gameObject.SetActive(true);
        }
        else
        {
            jiHuoButton.gameObject.SetActive(false);
        }
        
        if (FightBGController.S.isShowAgain)
        {
            againButton.gameObject.SetActive(true);
            returnButton.gameObject.SetActive(true);
        }
        else
        {
            againButton.gameObject.SetActive(false);
            returnButton.gameObject.SetActive(false);
        }

        RMB.fillAmount = GetFillAmout(SkillJiaDian.S.RMB);
        skill1.fillAmount = GetFillAmout(SkillJiaDian.S.Alpha1);
        skill2.fillAmount = GetFillAmout(SkillJiaDian.S.Alpha2);
        skill3.fillAmount = GetFillAmout(SkillJiaDian.S.Alpha3);
        skill4.fillAmount = GetFillAmout(SkillJiaDian.S.Alpha4);
        skill5.fillAmount = GetFillAmout(SkillJiaDian.S.Alpha5);

    }

    public float GetFillAmout(SkillType skillType)
    {
        switch (skillType)
        {
            case SkillType.Dash:
                return SkillController.S.DashCoolingtime / SkillController.S.Dashtime;
            
             case SkillType.Ice1:
                 return SkillController.S.IceSkill1Coolingtime / SkillController.S.IceSkill1Time;
            case SkillType.Ice2:
                return SkillController.S.IceBallCoolingtime / SkillController.S.IceBalltime;
            case SkillType.Ice3:
                return SkillController.S.IceExplosionCoolingtime / SkillController.S.IceExplosiontime;
            case SkillType.Ice4:
                return SkillController.S.IceSkill4Coolingtime / SkillController.S.IceSkill4Time;
            case SkillType.Ice5:
                return SkillController.S.IceSkill5Coolingtime / SkillController.S.IceSkill5Time;
            
            case SkillType.Dian1:
                return SkillController.S.DianQuanCoolingtime / SkillController.S.DianQuantime;
            case SkillType.Dian2:
                return SkillController.S.DianSkill2Coolingtime / SkillController.S.DianSkill2Time;
            case SkillType.Dian3:
                return SkillController.S.DianSkill3Coolingtime / SkillController.S.DianSkill3Time;
            case SkillType.Dian4:
                return SkillController.S.DianSkill4Coolingtime / SkillController.S.DianSkill4Time;
            case SkillType.Dian5:
                return SkillController.S.DianSkill5Coolingtime / SkillController.S.DianSkill5Time;
            
            case SkillType.Huo1:
                return SkillController.S.HuoSkill1Coolingtime / SkillController.S.HuoSkill1Time;
            case SkillType.Huo2:
                return SkillController.S.HuoSkill2Coolingtime / SkillController.S.HuoSkill2Time;
            case SkillType.Huo3:
                return SkillController.S.HuoSkill3Coolingtime / SkillController.S.HuoSkill3Time;
            case SkillType.Huo4:
                return SkillController.S.HuoSkill4Coolingtime / SkillController.S.HuoSkill4Time;
            case SkillType.Huo5:
                return SkillController.S.HuoSkill5Coolingtime / SkillController.S.HuoSkill5Time;
            
            case SkillType.HeiAn1:
                return SkillController.S.HeiAnSkill1Coolingtime / SkillController.S.HeiAnSkill1Time;
            case SkillType.HeiAn2:
                return SkillController.S.HeiAnSkill2Coolingtime / SkillController.S.HeiAnSkill2Time;
            case SkillType.HeiAn3:
                return SkillController.S.HeiAnSkill3Coolingtime / SkillController.S.HeiAnSkill3Time;
            case SkillType.HeiAn4:
                return SkillController.S.HeiAnSkill4Coolingtime / SkillController.S.HeiAnSkill4Time;
            case SkillType.HeiAn5:
                return SkillController.S.HeiAnSkill5Coolingtime / SkillController.S.HeiAnSkill5Time;
        }

        return 0;
    }

    public void ShenJi(object[] obj)
    {
        playerLevelText.text = GlobalPlayerAttribute.Level.ToString();
    }

    private void Start()
    {
        //技能按钮点击特效
        playerLevelText.text = GlobalPlayerAttribute.Level.ToString();
        ObserverModuleManager.S.RegisterEvent(ConstKeys.ShowToast, ShowTaost);
        ObserverModuleManager.S.RegisterEvent("ShenJi", ShenJi);
        //召唤boss按钮监听事件
        jiHuoButton.onClick.AddListener(() =>
        {
            GameController.S.CollectEquip();
            QueueController.S.gamePlayer.HideArrow();
            GameObject boosQuan=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/BossQuan"));
            boosQuan.transform.position = new Vector3(0, 0, 0);
            GameController.S.JiHuoChuanSongZhen();
            GameController.S.CreateBoss();
        });
        againButton.onClick.AddListener(() =>
        {
            GlobalPlayerAttribute.CurrentExitType = ExitType.Again;
            SceneManager.LoadScene("UIScene");
        });
        
        returnButton.onClick.AddListener(() =>
        {
            GlobalPlayerAttribute.CurrentExitType = ExitType.Exit;
            SceneManager.LoadScene("UIScene");
        });
        
        
        if (SkillController.S.Alpha1 == SkillType.None)
        {
            skill1.gameObject.SetActive(false);
        }
        else
        {
            skill1.sprite=ResourcesConfig.GetZhuDongSkillSprite(SkillController.S.Alpha1);
        }
        
        if (SkillController.S.Alpha2 == SkillType.None)
        {
            skill2.gameObject.SetActive(false);
        }
        else
        {
            skill2.sprite=ResourcesConfig.GetZhuDongSkillSprite(SkillController.S.Alpha2);
        }
        
        
        if (SkillController.S.Alpha3== SkillType.None)
        {
            skill3.gameObject.SetActive(false);
        }
        else
        {
            skill3.sprite=ResourcesConfig.GetZhuDongSkillSprite(SkillController.S.Alpha3);
        }
        
        
        if (SkillController.S.Alpha4 == SkillType.None)
        {
            skill4.gameObject.SetActive(false);
        }
        else
        {
            skill4.sprite=ResourcesConfig.GetZhuDongSkillSprite(SkillController.S.Alpha4);
        }
        
        if (SkillController.S.Alpha5 == SkillType.None)
        {
            skill5.gameObject.SetActive(false);
        }
        else
        {
            skill5.sprite=ResourcesConfig.GetZhuDongSkillSprite(SkillController.S.Alpha5);
        }
        
    }
    
    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent(ConstKeys.ShowToast, ShowTaost);
        ObserverModuleManager.S.UnRegisterEvent("ShenJi", ShenJi);
    }

    public void ShowTaost(object[] obj)
    {
        var toast = Instantiate(Resources.Load("Prefabs/Tool/ToastInfo"), toastContent.transform);
        EquipTable equipTable = obj[0] as EquipTable;
        PropTable propTable = obj[0] as PropTable;
        if (equipTable != null)
        {
            toast.GetComponent<ToastInfo>().SetEquipToast(equipTable);
        }
        if (propTable != null)
        {
            toast.GetComponent<ToastInfo>().SetPropToast(propTable);

        }
    }
}
