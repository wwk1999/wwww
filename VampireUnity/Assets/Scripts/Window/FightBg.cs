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
    
    public Image RMBBg;
    public Image RMB;
    public Image skill1Bg;
    public Image skill1;
    public Image skill2Bg;
    public Image skill2;
    public Image skill3Bg;
    public Image skill3;

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

        RMB.fillAmount = GetFillAmout(SkillData.S.RMB);
        skill1.fillAmount = GetFillAmout(SkillData.S.Alpha1);
        skill2.fillAmount = GetFillAmout(SkillData.S.Alpha2);
        skill3.fillAmount = GetFillAmout(SkillData.S.Alpha3);
    }

    public float GetFillAmout(SkillType skillType)
    {
        switch (skillType)
        {
            case SkillType.Skill1:
                return SkillController.S.DianQuanCoolingtime / SkillController.S.DianQuantime;
            case SkillType.Skill2:
                return SkillController.S.IceBallCoolingtime / SkillController.S.IceBalltime;
            case SkillType.Skill3:
                return SkillController.S.IceExplosionCoolingtime / SkillController.S.IceExplosiontime;
            case SkillType.Dash:
                return SkillController.S.DashCoolingtime / SkillController.S.Dashtime;
            case SkillType.IceSkill1:
                return SkillController.S.IceSkill1Coolingtime / SkillController.S.IceSkill1Time;
            case SkillType.DianSkill2:
                return SkillController.S.DianSkill2Coolingtime / SkillController.S.DianSkill2Time;
            case SkillType.DianSkill3:
                return SkillController.S.DianSkill3Coolingtime / SkillController.S.DianSkill3Time;
            case SkillType.HuoSkill1:
                return SkillController.S.HuoSkill1Coolingtime / SkillController.S.HuoSkill1Time;
            case SkillType.HuoSkill2:
                return SkillController.S.HuoSkill2Coolingtime / SkillController.S.HuoSkill2Time;
            case SkillType.HuoSkill3:
                return SkillController.S.HuoSkill3Coolingtime / SkillController.S.HuoSkill3Time;
            
            case SkillType.HeiAnSkill1:
                return SkillController.S.HeiAnSkill1Coolingtime / SkillController.S.HeiAnSkill1Time;
            case SkillType.HeiAnSkill2:
                return SkillController.S.HeiAnSkill2Coolingtime / SkillController.S.HeiAnSkill2Time;
            case SkillType.HeiAnSkill3:
                return SkillController.S.HeiAnSkill3Coolingtime / SkillController.S.HeiAnSkill3Time;
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
            GameController.S.gamePlayer.HideArrow();
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
        
        
        
        
        if (GetSkillSprite(SkillController.S.RMB) == null)
        {
            RMB.gameObject.SetActive(false);
            RMBBg.gameObject.SetActive(false);
        }
        else
        {
            RMB.sprite=GetSkillSprite(SkillController.S.RMB);
            RMBBg.sprite=GetSkillSprite(SkillController.S.RMB);
        }
        
        if (GetSkillSprite(SkillController.S.Alpha1) == null)
        {
            skill1.gameObject.SetActive(false);
            skill1Bg.gameObject.SetActive(false);
        }
        else
        {
            skill1Bg.sprite=GetSkillSprite(SkillController.S.Alpha1);
            skill1.sprite=GetSkillSprite(SkillController.S.Alpha1);
        }
        
        if (GetSkillSprite(SkillController.S.Alpha2) == null)
        {
            skill2.gameObject.SetActive(false);
            skill2Bg.gameObject.SetActive(false);
        }
        else
        {
            skill2.sprite=GetSkillSprite(SkillController.S.Alpha2);
            skill2Bg.sprite=GetSkillSprite(SkillController.S.Alpha2);

        }
        
        if (GetSkillSprite(SkillController.S.Alpha3) == null)
        {
            skill3.gameObject.SetActive(false);
            skill3Bg.gameObject.SetActive(false);
        }
        else
        {
            skill3.sprite=GetSkillSprite(SkillController.S.Alpha3);
            skill3Bg.sprite=GetSkillSprite(SkillController.S.Alpha3);

        }
        
    }

    public Sprite GetSkillSprite(SkillType skillType)
    {
        switch (skillType)
        {
            case SkillType.Skill1:
                return ResourcesConfig.Skill1;
            case SkillType.Skill2:
                return ResourcesConfig.Skill2;
            case SkillType.Skill3:
                return ResourcesConfig.Skill3;
            case SkillType.Dash:
                return ResourcesConfig.Dash;
            case SkillType.IceSkill1:
                return ResourcesConfig.IceSkill1;
            case SkillType.DianSkill2:
                return ResourcesConfig.DianSkill2;
            case SkillType.DianSkill3:
                return ResourcesConfig.DianSkill3;
            case SkillType.HuoSkill1:
                return ResourcesConfig.HuoSkill1;
            case SkillType.HuoSkill2:
                return ResourcesConfig.HuoSkill2;
            case SkillType.HuoSkill3:
                return ResourcesConfig.HuoSkill3;
            case SkillType.HeiAnSkill1:
                return ResourcesConfig.HeiAnSkill1;
            case SkillType.HeiAnSkill2:
                return ResourcesConfig.HeiAnSkill2;
            case SkillType.HeiAnSkill3:
                return ResourcesConfig.HeiAnSkill3;
        }

        return null;
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
