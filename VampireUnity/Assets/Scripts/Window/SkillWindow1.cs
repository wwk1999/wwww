using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillWindow1 : MonoBehaviour
{
    [Header("基础UI组件")]
    public Button exitButton; // 退出按钮
    public Button maskButton;
    public GameObject skillSwitchObj;

    [Header("技能计数显示")]
    public TextMeshProUGUI skillCount;
    public TextMeshProUGUI monsterCount;

    [Header("基础技能按钮")]
    public Button normalAttackButton;
    public Button attackSpeedButton;
    public Button dashButton;
    public Button dashCdButton;
    public Button critButton;
    public Button critDamageButton;
    public Button moveSpeedButton;
    public Button moveAddDefenseButton;
    public Button moveAddAttackButton;

    [Header("技能系统按钮")]
    public Button skill1Button;
    public Button skill2Button;
    public Button skill3Button;
    public Button skill1CdButton;
    public Button skill2CdButton;
    public Button skill3CdButton;
    public Button skill1RangeButton;
    public Button skill1YiDianButton;
    public Button skill2TimeButton;
    public Button skill2AddDefenseButton;
    public Button skill3RangeButton;
    public Button skill3JianSuButton;


    [Header("攻击相关按钮")]
    public Button attackButton;
    public Button hpButton;
    public Button defenseButton;
    public Button critMonsterButton;
    
    
    
    

    [Header("基础技能等级显示")]
    public TextMeshProUGUI normalAttackLevel;
    public TextMeshProUGUI attackSpeedLevel;
    
    public TextMeshProUGUI dashLevel;
    public TextMeshProUGUI dashCdLevel;
    
    public TextMeshProUGUI critLevel;
    public TextMeshProUGUI critDamageLevel;
    
    public TextMeshProUGUI moveSpeedLevel;
    public TextMeshProUGUI moveAddDefenseLevel;
    public TextMeshProUGUI moveAddAttackLevel;

    [Header("技能系统等级显示")]
    public TextMeshProUGUI skill1Level;
    public TextMeshProUGUI skill2Level;
    public TextMeshProUGUI skill3Level;
    public TextMeshProUGUI skill1CdLevel;
    public TextMeshProUGUI skill2CdLevel;
    public TextMeshProUGUI skill3CdLevel;
    public TextMeshProUGUI skill1RangeLevel;
    public TextMeshProUGUI skill1YiDianLevel;
    public TextMeshProUGUI skill2TimeLevel;
    public TextMeshProUGUI skill2AddDefenseLevel;
    public TextMeshProUGUI skill3RangeLevel;
    public TextMeshProUGUI skill3JianSuLevel;

    [Header("攻击相关等级显示")]
    public TextMeshProUGUI attackLevel;
    public TextMeshProUGUI hpLevel;
    public TextMeshProUGUI defenseLevel;
    public TextMeshProUGUI critMonsterLevel;
    
    


    [Header("图像组件")]
    public Image attackSpeedImage;

    public Image dashCdImage;

    public Image critDamageImage;

    public Image moveAddDefenseImage;
    public Image moveAddAttackImage;
    
    public Image skill1CdImage;
    public Image skill2CdImage;
    public Image skill3CdImage;
    public Image skill1RangeImage;
    public Image skill1YiDianImage;
    public Image skill2TimeImage;
    public Image skill2AddDefenseImage;
    public Image skill3RangeImage;
    public Image skill3JianSuImage;


    [Header("线条对象")]
    public GameObject skill1RangeLine;
    public GameObject skill1CdLine;
    public GameObject skill1YiDianLine1;
    public GameObject skill1YiDianLine2;
    public GameObject skill2CdLine;
    public GameObject skill2TimeLine;
    public GameObject skill2DefenseLine1;
    public GameObject skill2DefenseLine2;
    public GameObject skill3CdLine;
    public GameObject skill3RangeLine;
    public GameObject skill3JianSuLine1;
    public GameObject skill3JianSuLine2;
    public GameObject attackSpeedLine;
    public GameObject dashCdLine;
    public GameObject moveAddAttackLine;
    public GameObject moveAddDefenseLine;
    public GameObject critDamageLine;

    [Header("自动技能对象")]
    public GameObject skill1Auto;
    public GameObject skill2Auto;
    public GameObject skill3Auto;
    public GameObject dashAuto;
    public GameObject IceSkill1Auto;
    public GameObject DianSKill2Auto;
    public GameObject DianSkill3Auto;
    public GameObject HuoSkill1Auto;
    public GameObject HuoSkill2Auto;
    public GameObject HuoSkill3Auto;
    public GameObject HeiAnSkill1Auto;
    public GameObject HeiAnSkill2Auto;
    public GameObject HeiAnSkill3Auto;


    [Header("元素技能选择")]
    public Button jia1;
    public Button jia2;
    public Button jia3;
    public GameObject SkillYuanSuWindow;

    [Header("元素技能UI对象")]
    public GameObject IceSkill1;
    public GameObject HuoSkill1;
    public GameObject HeiAnSkill1;
    public GameObject DianSkill1;
    public GameObject IceSkill2;
    public GameObject HuoSkill2;
    public GameObject HeiAnSkill2;
    public GameObject DianSkill2;
    public GameObject IceSkill3;
    public GameObject HuoSkill3;
    public GameObject HeiAnSkill3;
    public GameObject DianSkill3;


    [Header("冰元素技能1组件")]
    public Button IceSkill1Button;
    public Button IceSkill1TopButton;
    public Button IceSkill1BottomButton;
    public Button IceSkill1RightButton;
    public TextMeshProUGUI IceSkill1Text;
    public TextMeshProUGUI IceSkill1TopText;
    public TextMeshProUGUI IceSkill1BottomText;
    public TextMeshProUGUI IceSkill1RightText;
    public GameObject IceSkill1Top1Line;
    public GameObject IceSkill1Bottom1Line;
    public GameObject IceSkill1Top2Line;
    public GameObject IceSkill1Bottom2Line;
    public Image IceSkill1Image;
    public Image IceSkill1TopImage;
    public Image IceSkill1BottomImage;
    public Image IceSkill1RightImage;

    [Header("雷元素技能2组件")]
    public Button DianSkill2Button;
    public Button DianSkill2TopButton;
    public Button DianSkill2BottomButton;
    public Button DianSkill2RightButton;
    public TextMeshProUGUI DianSkill2Text;
    public TextMeshProUGUI DianSkill2TopText;
    public TextMeshProUGUI DianSkill2BottomText;
    public TextMeshProUGUI DianSkill2RightText;
    public GameObject DianSkill2Top1Line;
    public GameObject DianSkill2Bottom1Line;
    public GameObject DianSkill2Top2Line;
    public GameObject DianSkill2Bottom2Line;
    public Image DianSkill2Image;
    public Image DianSkill2TopImage;
    public Image DianSkill2BottomImage;
    public Image DianSkill2RightImage;
    


    [Header("雷元素技能3组件")]
    private Button DianSkill3Button;
    private Button DianSkill3TopButton;
    private Button DianSkill3BottomButton;
    private Button DianSkill3RightButton;
    private TextMeshProUGUI DianSkill3Text;
    private TextMeshProUGUI DianSkill3TopText;
    private TextMeshProUGUI DianSkill3BottomText;
    private TextMeshProUGUI DianSkill3RightText;
    private GameObject DianSkill3Top1Line;
    private GameObject DianSkill3Bottom1Line;
    private GameObject DianSkill3Top2Line;
    private GameObject DianSkill3Bottom2Line;
    private Image DianSkill3Image;
    private Image DianSkill3TopImage;
    private Image DianSkill3BottomImage;
    private Image DianSkill3RightImage;


    [Header("火元素技能3组件")]
    private Button HuoSkill3Button;
    private Button HuoSkill3TopButton;
    private Button HuoSkill3BottomButton;
    private Button HuoSkill3RightButton;
    private TextMeshProUGUI HuoSkill3Text;
    private TextMeshProUGUI HuoSkill3TopText;
    private TextMeshProUGUI HuoSkill3BottomText;
    private TextMeshProUGUI HuoSkill3RightText;
    private GameObject HuoSkill3Top1Line;
    private GameObject HuoSkill3Bottom1Line;
    private GameObject HuoSkill3Top2Line;
    private GameObject HuoSkill3Bottom2Line;
    private Image HuoSkill3Image;
    private Image HuoSkill3TopImage;
    private Image HuoSkill3BottomImage;
    private Image HuoSkill3RightImage;


    [Header("火元素技能2组件")]
    private Button HuoSkill2Button;
    private Button HuoSkill2TopButton;
    private Button HuoSkill2BottomButton;
    private Button HuoSkill2RightButton;
    private TextMeshProUGUI HuoSkill2Text;
    private TextMeshProUGUI HuoSkill2TopText;
    private TextMeshProUGUI HuoSkill2BottomText;
    private TextMeshProUGUI HuoSkill2RightText;
    private GameObject HuoSkill2Top1Line;
    private GameObject HuoSkill2Bottom1Line;
    private GameObject HuoSkill2Top2Line;
    private GameObject HuoSkill2Bottom2Line;
    private Image HuoSkill2Image;
    private Image HuoSkill2TopImage;
    private Image HuoSkill2BottomImage;
    private Image HuoSkill2RightImage;
    


    [Header("火元素技能1组件")]
    private Button HuoSkill1Button;
    private Button HuoSkill1TopButton;
    private Button HuoSkill1BottomButton;
    private Button HuoSkill1RightButton;
    private TextMeshProUGUI HuoSkill1Text;
    private TextMeshProUGUI HuoSkill1TopText;
    private TextMeshProUGUI HuoSkill1BottomText;
    private TextMeshProUGUI HuoSkill1RightText;
    private GameObject HuoSkill1Top1Line;
    private GameObject HuoSkill1Bottom1Line;
    private GameObject HuoSkill1Top2Line;
    private GameObject HuoSkill1Bottom2Line;
    private Image HuoSkill1Image;
    private Image HuoSkill1TopImage;
    private Image HuoSkill1BottomImage;
    private Image HuoSkill1RightImage;
    


    [Header("黑暗元素技能1组件")]
    private Button HeiAnSkill1Button;
    private Button HeiAnSkill1TopButton;
    private Button HeiAnSkill1BottomButton;
    private Button HeiAnSkill1RightButton;
    private TextMeshProUGUI HeiAnSkill1Text;
    private TextMeshProUGUI HeiAnSkill1TopText;
    private TextMeshProUGUI HeiAnSkill1BottomText;
    private TextMeshProUGUI HeiAnSkill1RightText;
    private GameObject HeiAnSkill1Top1Line;
    private GameObject HeiAnSkill1Bottom1Line;
    private GameObject HeiAnSkill1Top2Line;
    private GameObject HeiAnSkill1Bottom2Line;
    private Image HeiAnSkill1Image;
    private Image HeiAnSkill1TopImage;
    private Image HeiAnSkill1BottomImage;
    private Image HeiAnSkill1RightImage;
    
    
    
    
    
    private Button HeiAnSkill2Button;
    private Button HeiAnSkill2TopButton;
    private Button HeiAnSkill2BottomButton;
    private Button HeiAnSkill2RightButton;
    private TextMeshProUGUI HeiAnSkill2Text;
    private TextMeshProUGUI HeiAnSkill2TopText;
    private TextMeshProUGUI HeiAnSkill2BottomText;
    private TextMeshProUGUI HeiAnSkill2RightText;
    private GameObject HeiAnSkill2Top1Line;
    private GameObject HeiAnSkill2Bottom1Line;
    private GameObject HeiAnSkill2Top2Line;
    private GameObject HeiAnSkill2Bottom2Line;
    private Image HeiAnSkill2Image;
    private Image HeiAnSkill2TopImage;
    private Image HeiAnSkill2BottomImage;
    private Image HeiAnSkill2RightImage;
    
    
    
    
    
    private Button HeiAnSkill3Button;
    private Button HeiAnSkill3TopButton;
    private Button HeiAnSkill3BottomButton;
    private Button HeiAnSkill3RightButton;
    private TextMeshProUGUI HeiAnSkill3Text;
    private TextMeshProUGUI HeiAnSkill3TopText;
    private TextMeshProUGUI HeiAnSkill3BottomText;
    private TextMeshProUGUI HeiAnSkill3RightText;
    private GameObject HeiAnSkill3Top1Line;
    private GameObject HeiAnSkill3Bottom1Line;
    private GameObject HeiAnSkill3Top2Line;
    private GameObject HeiAnSkill3Bottom2Line;
    private Image HeiAnSkill3Image;
    private Image HeiAnSkill3TopImage;
    private Image HeiAnSkill3BottomImage;
    private Image HeiAnSkill3RightImage;

    public Button ResetButton;

    public void Reset()
    {
        SkillJiaDian.S.skill1Type = SkillYuanSuType.None;
        SkillJiaDian.S.skill2Type = SkillYuanSuType.None;
        SkillJiaDian.S.skill3Type = SkillYuanSuType.None;
        
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.IceSkill1;
        SkillJiaDian.S.IceSkill1 = 0;
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.IceSkill1Cd;
        SkillJiaDian.S.IceSkill1Cd = 0;
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.IceSkill1Range;
        SkillJiaDian.S.IceSkill1Range = 0;
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.IceSkill1YuanSu;
        SkillJiaDian.S.IceSkill1YuanSu = 0;
        
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.HuoSkill1;
        SkillJiaDian.S.HuoSkill1 = 0;
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.HuoSkill1Cd;
        SkillJiaDian.S.HuoSkill1Cd = 0;
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.HuoSkill1Count;
        SkillJiaDian.S.HuoSkill1Count = 0;
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.HuoSkill1YuanSu;
        SkillJiaDian.S.HuoSkill1YuanSu = 0;
        
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.DianSkill1Damage;
        SkillJiaDian.S.DianSkill1Damage = 0;
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.DianSkill1Cd;
        SkillJiaDian.S.DianSkill1Cd = 0;
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.DianSkill1Range;
        SkillJiaDian.S.DianSkill1Range = 0;
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.DianSkill1YuanSu;
        SkillJiaDian.S.DianSkill1YuanSu = 0;
        
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.HeiAnSkill1;
        SkillJiaDian.S.HeiAnSkill1 = 0;
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.HeiAnSkill1Cd;
        SkillJiaDian.S.HeiAnSkill1Cd = 0;
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.HeiAnSkill1Range;
        SkillJiaDian.S.HeiAnSkill1Range = 0;
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.HeiAnSkill1YuanSu;
        SkillJiaDian.S.HeiAnSkill1YuanSu = 0;
        
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.NormalAttack;
        SkillJiaDian.S.NormalAttack = 0;
        
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.AttackSpeed;
        SkillJiaDian.S.AttackSpeed = 0;
        
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.DashCd;
        SkillJiaDian.S.DashCd = 0;
        
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.Dash;
        SkillJiaDian.S.Dash = 0;
        
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.MoveSpeed;
        SkillJiaDian.S.MoveSpeed = 0;
        
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.MoveAddAttack;
        SkillJiaDian.S.MoveAddAttack = 0;
        
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.MoveAddDefense;
        SkillJiaDian.S.MoveAddDefense = 0;
        
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.Crit;
        SkillJiaDian.S.Crit = 0;
        
        SkillJiaDian.S.CurrentSkillCount+=SkillJiaDian.S.CritDamage;
        SkillJiaDian.S.CritDamage = 0;
        
        SetButtonDisable();
        SetShowLevel();
        SetAuto();
        ResfreshSkillCount();
        RefreshSkill();
    }
    
    public void RefreshSkill()
    {
        IceSkill1.gameObject.SetActive(false);
        HuoSkill1.gameObject.SetActive(false);
        HeiAnSkill1.gameObject.SetActive(false);
        DianSkill1.gameObject.SetActive(false);
        
        IceSkill2.gameObject.SetActive(false);
        HuoSkill2.gameObject.SetActive(false);
        HeiAnSkill2.gameObject.SetActive(false);
        DianSkill2.gameObject.SetActive(false);
        
        IceSkill3.gameObject.SetActive(false);
        HuoSkill3.gameObject.SetActive(false);
        HeiAnSkill3.gameObject.SetActive(false);
        DianSkill3.gameObject.SetActive(false);

        switch (SkillJiaDian.S.skill1Type)
        {
            case SkillYuanSuType.Ice:
                jia1.gameObject.SetActive(false);
                IceSkill1.gameObject.SetActive(true);
                break;
            case SkillYuanSuType.Huo:
                jia1.gameObject.SetActive(false);
                HuoSkill1.gameObject.SetActive(true);
                break;
            case SkillYuanSuType.HeiAn:
                jia1.gameObject.SetActive(false);

                HeiAnSkill1.gameObject.SetActive(true);
                break;
            case SkillYuanSuType.Dian:
                jia1.gameObject.SetActive(false);

                DianSkill1.gameObject.SetActive(true);
                break;
            case SkillYuanSuType.None:
                jia1.gameObject.SetActive(true);
                break;

        }
        
        switch (SkillJiaDian.S.skill2Type)
        {
            case SkillYuanSuType.Ice:
                jia2.gameObject.SetActive(false);

                IceSkill2.gameObject.SetActive(true);
                break;
            case SkillYuanSuType.Huo:
                jia2.gameObject.SetActive(false);

                HuoSkill2.gameObject.SetActive(true);
                break;
            case SkillYuanSuType.HeiAn:
                jia2.gameObject.SetActive(false);

                HeiAnSkill2.gameObject.SetActive(true);
                break;
            case SkillYuanSuType.Dian:
                jia2.gameObject.SetActive(false);

                DianSkill2.gameObject.SetActive(true);
                break;
            case SkillYuanSuType.None:
                jia2.gameObject.SetActive(true);
                break;
        }
        
        switch (SkillJiaDian.S.skill3Type)
        {
            case SkillYuanSuType.Ice:
                jia3.gameObject.SetActive(false);

                IceSkill3.gameObject.SetActive(true);
                break;
            case SkillYuanSuType.Huo:
                jia3.gameObject.SetActive(false);

                HuoSkill3.gameObject.SetActive(true);
                break;
            case SkillYuanSuType.HeiAn:
                jia3.gameObject.SetActive(false);

                HeiAnSkill3.gameObject.SetActive(true);
                break;
            case SkillYuanSuType.Dian:
                jia3.gameObject.SetActive(false);

                DianSkill3.gameObject.SetActive(true);
                break;
            case SkillYuanSuType.None:
                jia3.gameObject.SetActive(true);
                break;
        }
    }

    
    public void SetAuto()
    {
        skill1Auto.gameObject.SetActive(SkillData.S.skill1Auto);
        skill2Auto.gameObject.SetActive(SkillData.S.skill2Auto);
        skill3Auto.gameObject.SetActive(SkillData.S.skill3Auto);
        dashAuto.gameObject.SetActive(SkillData.S.dashAuto);
        IceSkill1Auto.gameObject.SetActive(SkillData.S.IceSkill1Auto);
        
        DianSKill2Auto.gameObject.SetActive(SkillData.S.DianSkill2Auto);
        DianSkill3Auto.gameObject.SetActive(SkillData.S.DianSkill3Auto);

        HuoSkill1Auto.gameObject.SetActive(SkillData.S.HuoSkill1Auto);
        HuoSkill2Auto.gameObject.SetActive(SkillData.S.HuoSkill2Auto);
        HuoSkill3Auto.gameObject.SetActive(SkillData.S.HuoSkill3Auto);

        HeiAnSkill1Auto.gameObject.SetActive(SkillData.S.HeiAnSkill1Auto);
        HeiAnSkill2Auto.gameObject.SetActive(SkillData.S.HeiAnSkill2Auto);
        HeiAnSkill3Auto.gameObject.SetActive(SkillData.S.HeiAnSkill3Auto);

    }

    private void TriggerButtonClickAnim(Button btn)
    {
        var anim = btn.gameObject.GetComponent<Animator>();
        anim.Play("SkillClick",0,0);
    }

    public void SetLine()
    {
        skill1RangeLine.SetActive(SkillJiaDian.S.DianSkill1Range >= 1);
        skill1CdLine.SetActive(SkillJiaDian.S.DianSkill1Cd >= 1);
        skill1YiDianLine1.SetActive(SkillJiaDian.S.DianSkill1YuanSu >= 1);
        skill1YiDianLine2.SetActive(SkillJiaDian.S.DianSkill1YuanSu >= 1);
        skill2CdLine.SetActive(SkillJiaDian.S.IceSkill2Cd >= 1);
        skill2TimeLine.SetActive(SkillJiaDian.S.IceSkill2Time >= 1);
        skill2DefenseLine1.SetActive(SkillJiaDian.S.IceSkill2YuanSu >= 1);
        skill2DefenseLine2.SetActive(SkillJiaDian.S.IceSkill2YuanSu >= 1);
        skill3RangeLine.SetActive(SkillJiaDian.S.IceSkill3Range >= 1);
        skill3CdLine.SetActive(SkillJiaDian.S.IceSkill3Cd >= 1);
        skill3JianSuLine1.SetActive(SkillJiaDian.S.IceSkill3YuanSu >= 1);
        skill3JianSuLine2.SetActive(SkillJiaDian.S.IceSkill3YuanSu >= 1);
        attackSpeedLine.SetActive(SkillJiaDian.S.AttackSpeed >= 1);
        dashCdLine.SetActive(SkillJiaDian.S.DashCd >= 1);
        moveAddAttackLine.SetActive(SkillJiaDian.S.MoveAddAttack >= 1);
        moveAddDefenseLine.SetActive(SkillJiaDian.S.MoveAddDefense >= 1);
        critDamageLine.SetActive(SkillJiaDian.S.CritDamage >= 1);
        
        
        IceSkill1Top1Line.SetActive(SkillJiaDian.S.IceSkill1Range>=1);
        IceSkill1Bottom1Line.SetActive(SkillJiaDian.S.IceSkill1Cd>=1);
        IceSkill1Top2Line.SetActive(SkillJiaDian.S.IceSkill1YuanSu>=1);
        IceSkill1Bottom2Line.SetActive(SkillJiaDian.S.IceSkill1YuanSu>=1);
        
        
        DianSkill2Top1Line.SetActive(SkillJiaDian.S.DianSkill2Duration>=1);
        DianSkill2Bottom1Line.SetActive(SkillJiaDian.S.DianSkill2Cd>=1);
        DianSkill2Top2Line.SetActive(SkillJiaDian.S.DianSkill2YuanSu>=1);
        DianSkill2Bottom2Line.SetActive(SkillJiaDian.S.DianSkill2YuanSu>=1);
        
        
        DianSkill3Top1Line.SetActive(SkillJiaDian.S.DianSkill3Count>=1);
        DianSkill3Bottom1Line.SetActive(SkillJiaDian.S.DianSkill3Cd>=1);
        DianSkill3Top2Line.SetActive(SkillJiaDian.S.DianSkill3YuanSu>=1);
        DianSkill3Bottom2Line.SetActive(SkillJiaDian.S.DianSkill3YuanSu>=1);
        
        
        HuoSkill1Top1Line.SetActive(SkillJiaDian.S.HuoSkill1Count>=1);
        HuoSkill1Bottom1Line.SetActive(SkillJiaDian.S.HuoSkill1Cd>=1);
        HuoSkill1Top2Line.SetActive(SkillJiaDian.S.HuoSkill1YuanSu>=1);
        HuoSkill1Bottom2Line.SetActive(SkillJiaDian.S.HuoSkill1YuanSu>=1);
        
        
        HuoSkill2Top1Line.SetActive(SkillJiaDian.S.HuoSkill2Time>=1);
        HuoSkill2Bottom1Line.SetActive(SkillJiaDian.S.HuoSkill2Cd>=1);
        HuoSkill2Top2Line.SetActive(SkillJiaDian.S.HuoSkill2YuanSu>=1);
        HuoSkill2Bottom2Line.SetActive(SkillJiaDian.S.HuoSkill2YuanSu>=1);
        
        HuoSkill3Top1Line.SetActive(SkillJiaDian.S.HuoSkill3Count>=1);
        HuoSkill3Bottom1Line.SetActive(SkillJiaDian.S.HuoSkill3Cd>=1);
        HuoSkill3Top2Line.SetActive(SkillJiaDian.S.HuoSkill3YuanSu>=1);
        HuoSkill3Bottom2Line.SetActive(SkillJiaDian.S.HuoSkill3YuanSu>=1);
        
        
        HeiAnSkill1Top1Line.SetActive(SkillJiaDian.S.HeiAnSkill1Range>=1);
        HeiAnSkill1Bottom1Line.SetActive(SkillJiaDian.S.HeiAnSkill1Cd>=1);
        HeiAnSkill1Top2Line.SetActive(SkillJiaDian.S.HeiAnSkill1YuanSu>=1);
        HeiAnSkill1Bottom2Line.SetActive(SkillJiaDian.S.HeiAnSkill1YuanSu>=1);
        
        
        HeiAnSkill2Top1Line.SetActive(SkillJiaDian.S.HeiAnSkill2Time>=1);
        HeiAnSkill2Bottom1Line.SetActive(SkillJiaDian.S.HeiAnSkill2Cd>=1);
        HeiAnSkill2Top2Line.SetActive(SkillJiaDian.S.HeiAnSkill2YuanSu>=1);
        HeiAnSkill2Bottom2Line.SetActive(SkillJiaDian.S.HeiAnSkill2YuanSu>=1);
        
        HeiAnSkill3Top1Line.SetActive(SkillJiaDian.S.HeiAnSkill3Range>=1);
        HeiAnSkill3Bottom1Line.SetActive(SkillJiaDian.S.HeiAnSkill3Cd>=1);
        HeiAnSkill3Top2Line.SetActive(SkillJiaDian.S.HeiAnSkill3YuanSu>=1);
        HeiAnSkill3Bottom2Line.SetActive(SkillJiaDian.S.HeiAnSkill3YuanSu>=1);

    }

    public void ResfreshSkillCount()
    {
        skillCount.text = SkillJiaDian.S.CurrentSkillCount.ToString();
        monsterCount.text=PlayerData.S.zhuanjinCount.ToString();
    }


   public void SetShowLevel()
{
    // Normal Attack
    normalAttackLevel.gameObject.SetActive(SkillJiaDian.S.NormalAttack > 0);
    normalAttackLevel.text = "["+SkillJiaDian.S.NormalAttack+"]";
    
    // Attack Speed
    attackSpeedLevel.gameObject.SetActive(SkillJiaDian.S.AttackSpeed > 0);
    attackSpeedLevel.text = "["+SkillJiaDian.S.AttackSpeed+"]";
    
    // Dash
    dashLevel.gameObject.SetActive(SkillJiaDian.S.Dash > 0);
    dashLevel.text = "["+SkillJiaDian.S.Dash+"]";
    
    // Dash CD
    dashCdLevel.gameObject.SetActive(SkillJiaDian.S.DashCd > 0);
    dashCdLevel.text = "["+SkillJiaDian.S.DashCd+"]";
    
    // Crit
    critLevel.gameObject.SetActive(SkillJiaDian.S.Crit > 0);
    critLevel.text = "["+SkillJiaDian.S.Crit+"]";
    
    // Crit Damage
    critDamageLevel.gameObject.SetActive(SkillJiaDian.S.CritDamage > 0);
    critDamageLevel.text = "["+SkillJiaDian.S.CritDamage+"]";
    
    // Move Speed
    moveSpeedLevel.gameObject.SetActive(SkillJiaDian.S.MoveSpeed > 0);
    moveSpeedLevel.text = "["+SkillJiaDian.S.MoveSpeed+"]";
    
    // Move Add Defense
    moveAddDefenseLevel.gameObject.SetActive(SkillJiaDian.S.MoveAddDefense > 0);
    moveAddDefenseLevel.text = "["+SkillJiaDian.S.MoveAddDefense+"]";
    
    // Move Add Attack
    moveAddAttackLevel.gameObject.SetActive(SkillJiaDian.S.MoveAddAttack > 0);
    moveAddAttackLevel.text = "["+SkillJiaDian.S.MoveAddAttack+"]";
    
    // Skill1 Level (Damage)
    skill1Level.gameObject.SetActive(SkillJiaDian.S.DianSkill1Damage > 0);
    skill1Level.text = "["+SkillJiaDian.S.DianSkill1Damage+"]";
    
    // Skill2 Level (Damage)
    skill2Level.gameObject.SetActive(SkillJiaDian.S.IceSkill2Damage > 0);
    skill2Level.text = "["+SkillJiaDian.S.IceSkill2Damage+"]";
    
    // Skill3 Level (Damage)
    skill3Level.gameObject.SetActive(SkillJiaDian.S.IceSkill3Damage > 0);
    skill3Level.text = "["+SkillJiaDian.S.IceSkill3Damage+"]";
    
    // Skill1 CD
    skill1CdLevel.gameObject.SetActive(SkillJiaDian.S.DianSkill1Cd > 0);
    skill1CdLevel.text = "["+SkillJiaDian.S.DianSkill1Cd+"]";
    
    // Skill2 CD
    skill2CdLevel.gameObject.SetActive(SkillJiaDian.S.IceSkill2Cd > 0);
    skill2CdLevel.text = "["+SkillJiaDian.S.IceSkill2Cd+"]";
    
    // Skill3 CD
    skill3CdLevel.gameObject.SetActive(SkillJiaDian.S.IceSkill3Cd > 0);
    skill3CdLevel.text = "["+SkillJiaDian.S.IceSkill3Cd+"]";
    
    // Skill1 Range
    skill1RangeLevel.gameObject.SetActive(SkillJiaDian.S.DianSkill1Range > 0);
    skill1RangeLevel.text = "["+SkillJiaDian.S.DianSkill1Range+"]";
    
    // Skill1 YiDian
    skill1YiDianLevel.gameObject.SetActive(SkillJiaDian.S.DianSkill1YuanSu > 0);
    skill1YiDianLevel.text = "["+SkillJiaDian.S.DianSkill1YuanSu+"]";
    
    // Skill2 Time
    skill2TimeLevel.gameObject.SetActive(SkillJiaDian.S.IceSkill2Time > 0);
    skill2TimeLevel.text = "["+SkillJiaDian.S.IceSkill2Time+"]";
    
    // Skill2 Add Defense
    skill2AddDefenseLevel.gameObject.SetActive(SkillJiaDian.S.IceSkill2YuanSu > 0);
    skill2AddDefenseLevel.text = "["+SkillJiaDian.S.IceSkill2YuanSu+"]";
    
    // Skill3 Range
    skill3RangeLevel.gameObject.SetActive(SkillJiaDian.S.IceSkill3Range > 0);
    skill3RangeLevel.text = "["+SkillJiaDian.S.IceSkill3Range+"]";
    
    // Skill3 JianSu
    skill3JianSuLevel.gameObject.SetActive(SkillJiaDian.S.IceSkill3YuanSu > 0);
    skill3JianSuLevel.text = "["+SkillJiaDian.S.IceSkill3YuanSu+"]";
    
    
    attackLevel.gameObject.SetActive(SkillJiaDian.S.MonsterAttack > 0);
    attackLevel.text = "["+SkillJiaDian.S.MonsterAttack+"]";
    
    critMonsterLevel.gameObject.SetActive(SkillJiaDian.S.MonsterCrit > 0);
    critMonsterLevel.text = "["+SkillJiaDian.S.MonsterCrit+"]";
    
    hpLevel.gameObject.SetActive(SkillJiaDian.S.MonsterHp > 0);
    hpLevel.text = "["+SkillJiaDian.S.MonsterHp+"]";
    
    defenseLevel.gameObject.SetActive(SkillJiaDian.S.MonsterDefense > 0);
    defenseLevel.text = "["+SkillJiaDian.S.MonsterDefense+"]";
    
    IceSkill1Text.gameObject.SetActive(SkillJiaDian.S.IceSkill1>0);
    IceSkill1Text.text = "["+SkillJiaDian.S.IceSkill1+"]";
    IceSkill1TopText.gameObject.SetActive(SkillJiaDian.S.IceSkill1Range>0);
    IceSkill1TopText.text = "["+SkillJiaDian.S.IceSkill1Range+"]";
    IceSkill1BottomText.gameObject.SetActive(SkillJiaDian.S.IceSkill1Cd>0);
    IceSkill1BottomText.text = "["+SkillJiaDian.S.IceSkill1Cd+"]";
    IceSkill1RightText.gameObject.SetActive(SkillJiaDian.S.IceSkill1YuanSu>0);
    IceSkill1RightText.text = "["+SkillJiaDian.S.IceSkill1YuanSu+"]";
    
    
    
    DianSkill2Text.gameObject.SetActive(SkillJiaDian.S.DianSkill2>0);
    DianSkill2Text.text = "["+SkillJiaDian.S.DianSkill2+"]";
    DianSkill2TopText.gameObject.SetActive(SkillJiaDian.S.DianSkill2Duration>0);
    DianSkill2TopText.text = "["+SkillJiaDian.S.DianSkill2Duration+"]";
    DianSkill2BottomText.gameObject.SetActive(SkillJiaDian.S.DianSkill2Cd>0);
    DianSkill2BottomText.text = "["+SkillJiaDian.S.DianSkill2Cd+"]";
    DianSkill2RightText.gameObject.SetActive(SkillJiaDian.S.DianSkill2YuanSu>0);
    DianSkill2RightText.text = "["+SkillJiaDian.S.DianSkill2YuanSu+"]";
    
    
    DianSkill3Text.gameObject.SetActive(SkillJiaDian.S.DianSkill3>0);
    DianSkill3Text.text = "["+SkillJiaDian.S.DianSkill3+"]";
    DianSkill3TopText.gameObject.SetActive(SkillJiaDian.S.DianSkill3Count>0);
    DianSkill3TopText.text = "["+SkillJiaDian.S.DianSkill3Count+"]";
    DianSkill3BottomText.gameObject.SetActive(SkillJiaDian.S.DianSkill3Cd>0);
    DianSkill3BottomText.text = "["+SkillJiaDian.S.DianSkill3Cd+"]";
    DianSkill3RightText.gameObject.SetActive(SkillJiaDian.S.DianSkill3YuanSu>0);
    DianSkill3RightText.text = "["+SkillJiaDian.S.DianSkill3YuanSu+"]";
    
    
    
    HuoSkill1Text.gameObject.SetActive(SkillJiaDian.S.HuoSkill1>0);
    HuoSkill1Text.text = "["+SkillJiaDian.S.HuoSkill1+"]";
    HuoSkill1TopText.gameObject.SetActive(SkillJiaDian.S.HuoSkill1Count>0);
    HuoSkill1TopText.text = "["+SkillJiaDian.S.HuoSkill1Count+"]";
    HuoSkill1BottomText.gameObject.SetActive(SkillJiaDian.S.HuoSkill1Cd>0);
    HuoSkill1BottomText.text = "["+SkillJiaDian.S.HuoSkill1Cd+"]";
    HuoSkill1RightText.gameObject.SetActive(SkillJiaDian.S.HuoSkill1YuanSu>0);
    HuoSkill1RightText.text = "["+SkillJiaDian.S.HuoSkill1YuanSu+"]";
    
    
    
    HuoSkill2Text.gameObject.SetActive(SkillJiaDian.S.HuoSkill2>0);
    HuoSkill2Text.text = "["+SkillJiaDian.S.HuoSkill2+"]";
    HuoSkill2TopText.gameObject.SetActive(SkillJiaDian.S.HuoSkill2Time>0);
    HuoSkill2TopText.text = "["+SkillJiaDian.S.HuoSkill2Time+"]";
    HuoSkill2BottomText.gameObject.SetActive(SkillJiaDian.S.HuoSkill2Cd>0);
    HuoSkill2BottomText.text = "["+SkillJiaDian.S.HuoSkill2Cd+"]";
    HuoSkill2RightText.gameObject.SetActive(SkillJiaDian.S.HuoSkill2YuanSu>0);
    HuoSkill2RightText.text = "["+SkillJiaDian.S.HuoSkill2YuanSu+"]";
    
    
    HuoSkill3Text.gameObject.SetActive(SkillJiaDian.S.HuoSkill3>0);
    HuoSkill3Text.text = "["+SkillJiaDian.S.HuoSkill3+"]";
    HuoSkill3TopText.gameObject.SetActive(SkillJiaDian.S.HuoSkill3Count>0);
    HuoSkill3TopText.text = "["+SkillJiaDian.S.HuoSkill3Count+"]";
    HuoSkill3BottomText.gameObject.SetActive(SkillJiaDian.S.HuoSkill3Cd>0);
    HuoSkill3BottomText.text = "["+SkillJiaDian.S.HuoSkill3Cd+"]";
    HuoSkill3RightText.gameObject.SetActive(SkillJiaDian.S.HuoSkill3YuanSu>0);
    HuoSkill3RightText.text = "["+SkillJiaDian.S.HuoSkill3YuanSu+"]";
    
    
    
    HeiAnSkill1Text.gameObject.SetActive(SkillJiaDian.S.HeiAnSkill1>0);
    HeiAnSkill1Text.text = "["+SkillJiaDian.S.HeiAnSkill1+"]";
    HeiAnSkill1TopText.gameObject.SetActive(SkillJiaDian.S.HeiAnSkill1Range>0);
    HeiAnSkill1TopText.text = "["+SkillJiaDian.S.HeiAnSkill1Range+"]";
    HeiAnSkill1BottomText.gameObject.SetActive(SkillJiaDian.S.HeiAnSkill1Cd>0);
    HeiAnSkill1BottomText.text = "["+SkillJiaDian.S.HeiAnSkill1Cd+"]";
    HeiAnSkill1RightText.gameObject.SetActive(SkillJiaDian.S.HeiAnSkill1YuanSu>0);
    HeiAnSkill1RightText.text = "["+SkillJiaDian.S.HeiAnSkill1YuanSu+"]";
    
    
    HeiAnSkill2Text.gameObject.SetActive(SkillJiaDian.S.HeiAnSkill2Damage>0);
    HeiAnSkill2Text.text = "["+SkillJiaDian.S.HeiAnSkill2Damage+"]";
    HeiAnSkill2TopText.gameObject.SetActive(SkillJiaDian.S.HeiAnSkill2Time>0);
    HeiAnSkill2TopText.text = "["+SkillJiaDian.S.HeiAnSkill2Time+"]";
    HeiAnSkill2BottomText.gameObject.SetActive(SkillJiaDian.S.HeiAnSkill2Cd>0);
    HeiAnSkill2BottomText.text = "["+SkillJiaDian.S.HeiAnSkill2Cd+"]";
    HeiAnSkill2RightText.gameObject.SetActive(SkillJiaDian.S.HeiAnSkill2YuanSu>0);
    HeiAnSkill2RightText.text = "["+SkillJiaDian.S.HeiAnSkill2YuanSu+"]";
    
    
    
    HeiAnSkill3Text.gameObject.SetActive(SkillJiaDian.S.HeiAnSkill3Damage>0);
    HeiAnSkill3Text.text = "["+SkillJiaDian.S.HeiAnSkill3Damage+"]";
    HeiAnSkill3TopText.gameObject.SetActive(SkillJiaDian.S.HeiAnSkill3Range>0);
    HeiAnSkill3TopText.text = "["+SkillJiaDian.S.HeiAnSkill3Range+"]";
    HeiAnSkill3BottomText.gameObject.SetActive(SkillJiaDian.S.HeiAnSkill3Cd>0);
    HeiAnSkill3BottomText.text = "["+SkillJiaDian.S.HeiAnSkill3Cd+"]";
    HeiAnSkill3RightText.gameObject.SetActive(SkillJiaDian.S.HeiAnSkill3YuanSu>0);
    HeiAnSkill3RightText.text = "["+SkillJiaDian.S.HeiAnSkill3YuanSu+"]";
}


    public void SetButtonDisable()
    {
        SetImage();
        SetLine();
        attackSpeedButton.interactable = SkillJiaDian.S.NormalAttack>0;
        dashCdButton.interactable = SkillJiaDian.S.Dash>0;
        moveAddAttackButton.interactable=SkillJiaDian.S.MoveSpeed>0;
        moveAddDefenseButton.interactable=SkillJiaDian.S.MoveSpeed>0;
        
        
        critDamageButton.interactable=SkillJiaDian.S.Crit>0;
        skill1RangeButton.interactable=SkillJiaDian.S.DianSkill1Damage>0;
        skill1CdButton.interactable=SkillJiaDian.S.DianSkill1Damage>0;
        skill1YiDianButton.interactable=SkillJiaDian.S.DianSkill1Range>0&&SkillJiaDian.S.DianSkill1Cd>0;
        
        skill2TimeButton.interactable=SkillJiaDian.S.IceSkill2Damage>0;
        skill2CdButton.interactable=SkillJiaDian.S.IceSkill2Damage>0;
        skill2AddDefenseButton.interactable=SkillJiaDian.S.IceSkill2Time>0&&SkillJiaDian.S.IceSkill2Cd>0;
        
        skill3RangeButton.interactable=SkillJiaDian.S.IceSkill3Damage>0;
        skill3CdButton.interactable=SkillJiaDian.S.IceSkill3Damage>0;
        skill3JianSuButton.interactable=SkillJiaDian.S.IceSkill3Range>0&&SkillJiaDian.S.IceSkill3Cd>0;

        IceSkill1TopButton.interactable = SkillJiaDian.S.IceSkill1 > 0;
        IceSkill1BottomButton.interactable = SkillJiaDian.S.IceSkill1 > 0;
        IceSkill1RightButton.interactable = SkillJiaDian.S.IceSkill1Cd > 0&&SkillJiaDian.S.IceSkill1Range > 0;

        
        DianSkill2TopButton.interactable = SkillJiaDian.S.DianSkill2 > 0;
        DianSkill2BottomButton.interactable = SkillJiaDian.S.DianSkill2 > 0;
        DianSkill2RightButton.interactable = SkillJiaDian.S.DianSkill2Cd > 0&&SkillJiaDian.S.DianSkill2Duration > 0;
        
        
        DianSkill3TopButton.interactable = SkillJiaDian.S.DianSkill3 > 0;
        DianSkill3BottomButton.interactable = SkillJiaDian.S.DianSkill3 > 0;
        DianSkill3RightButton.interactable = SkillJiaDian.S.DianSkill3Cd > 0&&SkillJiaDian.S.DianSkill3Count > 0;
        
        
        HuoSkill1TopButton.interactable = SkillJiaDian.S.HuoSkill1 > 0;
        HuoSkill1BottomButton.interactable = SkillJiaDian.S.HuoSkill1 > 0;
        HuoSkill1RightButton.interactable = SkillJiaDian.S.HuoSkill1Cd > 0&&SkillJiaDian.S.HuoSkill1Count > 0;
        
        
        HuoSkill2TopButton.interactable = SkillJiaDian.S.HuoSkill2 > 0;
        HuoSkill2BottomButton.interactable = SkillJiaDian.S.HuoSkill2 > 0;
        HuoSkill2RightButton.interactable = SkillJiaDian.S.HuoSkill2Cd > 0&&SkillJiaDian.S.HuoSkill2Time > 0;
        
        
        HuoSkill3TopButton.interactable = SkillJiaDian.S.HuoSkill3 > 0;
        HuoSkill3BottomButton.interactable = SkillJiaDian.S.HuoSkill3 > 0;
        HuoSkill3RightButton.interactable = SkillJiaDian.S.HuoSkill3Cd > 0&&SkillJiaDian.S.HuoSkill3Count > 0;
        
        
        HeiAnSkill1TopButton.interactable = SkillJiaDian.S.HeiAnSkill1 > 0;
        HeiAnSkill1BottomButton.interactable = SkillJiaDian.S.HeiAnSkill1 > 0;
        HeiAnSkill1RightButton.interactable = SkillJiaDian.S.HeiAnSkill1Cd > 0&&SkillJiaDian.S.HeiAnSkill1Range > 0;
        
        
        HeiAnSkill2TopButton.interactable = SkillJiaDian.S.HeiAnSkill2Damage > 0;
        HeiAnSkill2BottomButton.interactable = SkillJiaDian.S.HeiAnSkill2Damage > 0;
        HeiAnSkill2RightButton.interactable = SkillJiaDian.S.HeiAnSkill2Cd > 0&&SkillJiaDian.S.HeiAnSkill2Time > 0;
        
        
        HeiAnSkill3TopButton.interactable = SkillJiaDian.S.HeiAnSkill3Damage > 0;
        HeiAnSkill3BottomButton.interactable = SkillJiaDian.S.HeiAnSkill3Damage > 0;
        HeiAnSkill3RightButton.interactable = SkillJiaDian.S.HeiAnSkill3Cd > 0&&SkillJiaDian.S.HeiAnSkill3Range > 0;
    }

    public void SetImage()
    {
        if (SkillJiaDian.S.DianSkill1Damage < 1)
        {
             skill1RangeImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill1RangeImage.color=new Color32(255, 255, 255, 255);
        }
        
        if (SkillJiaDian.S.DianSkill1Damage < 1)
        {
            skill1CdImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill1CdImage.color=new Color32(255, 255, 255, 255);
        }
        
        if (SkillJiaDian.S.DianSkill1Range < 1||SkillJiaDian.S.DianSkill1Cd<1)
        {
            skill1YiDianImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill1YiDianImage.color=new Color32(255, 255, 255, 255);
        }
        
        
        
        if (SkillJiaDian.S.IceSkill2Damage < 1)
        {
            skill2TimeImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill2TimeImage.color=new Color32(255, 255, 255, 255);
        }
        
        if (SkillJiaDian.S.IceSkill2Damage < 1)
        {
            skill2CdImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill2CdImage.color=new Color32(255, 255, 255, 255);
        }
        
        if (SkillJiaDian.S.IceSkill2Time < 1||SkillJiaDian.S.IceSkill2Cd<1)
        {
            skill2AddDefenseImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill2AddDefenseImage.color=new Color32(255, 255, 255, 255);
        }
        
        
        
        if (SkillJiaDian.S.IceSkill3Damage < 1)
        {
            skill3RangeImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill3RangeImage.color=new Color32(255, 255, 255, 255);
        }
        
        if (SkillJiaDian.S.IceSkill3Damage < 1)
        {
            skill3CdImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill3CdImage.color=new Color32(255, 255, 255, 255);
        }
        
        if (SkillJiaDian.S.IceSkill3Range < 1||SkillJiaDian.S.IceSkill3Cd<1)
        {
            skill3JianSuImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill3JianSuImage.color=new Color32(255, 255, 255, 255);
        }


        if (SkillJiaDian.S.NormalAttack < 1)
        {
            attackSpeedImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            attackSpeedImage.color=new Color32(255, 255, 255, 255);
        }
        
        
        if(SkillJiaDian.S.MoveSpeed<1)
        {
            moveAddAttackImage.color=new Color32(76,76, 76, 255);
            moveAddDefenseImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            moveAddAttackImage.color=new Color32(255, 255, 255, 255);
            moveAddDefenseImage.color=new Color32(255, 255, 255, 255);
        }

        if (SkillJiaDian.S.Crit < 1)
        {
            critDamageImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            critDamageImage.color=new Color32(255, 255, 255, 255);
        }
        
        if (SkillJiaDian.S.Dash < 1)
        {
            dashCdImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            dashCdImage.color=new Color32(255, 255, 255, 255);
        }

        if (SkillJiaDian.S.IceSkill1 < 1)
        {
            IceSkill1TopImage.color=new Color32(76,76, 76, 255);
            IceSkill1BottomImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            IceSkill1TopImage.color=new Color32(255, 255, 255, 255);
            IceSkill1BottomImage.color=new Color32(255, 255, 255, 255);
        }

        if (SkillJiaDian.S.IceSkill1Cd < 1 || SkillJiaDian.S.IceSkill1Range < 1)
        {
            IceSkill1RightImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            IceSkill1RightImage.color=new Color32(255, 255, 255, 255);
        }
        
        
        
        
        
        if (SkillJiaDian.S.DianSkill2 < 1)
        {
            DianSkill2TopImage.color=new Color32(76,76, 76, 255);
            DianSkill2BottomImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            DianSkill2TopImage.color=new Color32(255, 255, 255, 255);
            DianSkill2BottomImage.color=new Color32(255, 255, 255, 255);
        }

        if (SkillJiaDian.S.DianSkill2Cd < 1 || SkillJiaDian.S.DianSkill2Duration < 1)
        {
            DianSkill2RightImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            DianSkill2RightImage.color=new Color32(255, 255, 255, 255);
        }
        
        
        
        
        if (SkillJiaDian.S.DianSkill3 < 1)
        {
            DianSkill3TopImage.color=new Color32(76,76, 76, 255);
            DianSkill3BottomImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            DianSkill3TopImage.color=new Color32(255, 255, 255, 255);
            DianSkill3BottomImage.color=new Color32(255, 255, 255, 255);
        }

        if (SkillJiaDian.S.DianSkill3Cd < 1 || SkillJiaDian.S.DianSkill3Count < 1)
        {
            DianSkill3RightImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            DianSkill3RightImage.color=new Color32(255, 255, 255, 255);
        }
        
        
        
        
        
        
        if (SkillJiaDian.S.HuoSkill1 < 1)
        {
            HuoSkill1TopImage.color=new Color32(76,76, 76, 255);
            HuoSkill1BottomImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            HuoSkill1TopImage.color=new Color32(255, 255, 255, 255);
            HuoSkill1BottomImage.color=new Color32(255, 255, 255, 255);
        }

        if (SkillJiaDian.S.HuoSkill1Cd < 1 || SkillJiaDian.S.HuoSkill1Count < 1)
        {
            HuoSkill1RightImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            HuoSkill1RightImage.color=new Color32(255, 255, 255, 255);
        }
        
        
        
        
        
        if (SkillJiaDian.S.HuoSkill2 < 1)
        {
            HuoSkill2TopImage.color=new Color32(76,76, 76, 255);
            HuoSkill2BottomImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            HuoSkill2TopImage.color=new Color32(255, 255, 255, 255);
            HuoSkill2BottomImage.color=new Color32(255, 255, 255, 255);
        }

        if (SkillJiaDian.S.HuoSkill2Cd < 1 || SkillJiaDian.S.HuoSkill2Time < 1)
        {
            HuoSkill2RightImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            HuoSkill2RightImage.color=new Color32(255, 255, 255, 255);
        }
        
        
        
        
        
        if (SkillJiaDian.S.HuoSkill3 < 1)
        {
            HuoSkill3TopImage.color=new Color32(76,76, 76, 255);
            HuoSkill3BottomImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            HuoSkill3TopImage.color=new Color32(255, 255, 255, 255);
            HuoSkill3BottomImage.color=new Color32(255, 255, 255, 255);
        }

        if (SkillJiaDian.S.HuoSkill3Cd < 1 || SkillJiaDian.S.HuoSkill3Count < 1)
        {
            HuoSkill3RightImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            HuoSkill3RightImage.color=new Color32(255, 255, 255, 255);
        }
        
        
        
        
        if (SkillJiaDian.S.HeiAnSkill1 < 1)
        {
            HeiAnSkill1TopImage.color=new Color32(76,76, 76, 255);
            HeiAnSkill1BottomImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            HeiAnSkill1TopImage.color=new Color32(255, 255, 255, 255);
            HeiAnSkill1BottomImage.color=new Color32(255, 255, 255, 255);
        }

        if (SkillJiaDian.S.HeiAnSkill1Cd < 1 || SkillJiaDian.S.HeiAnSkill1Range < 1)
        {
            HeiAnSkill1RightImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            HeiAnSkill1RightImage.color=new Color32(255, 255, 255, 255);
        }
        
        
        
        
        
        if (SkillJiaDian.S.HeiAnSkill2Damage < 1)
        {
            HeiAnSkill2TopImage.color=new Color32(76,76, 76, 255);
            HeiAnSkill2BottomImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            HeiAnSkill2TopImage.color=new Color32(255, 255, 255, 255);
            HeiAnSkill2BottomImage.color=new Color32(255, 255, 255, 255);
        }

        if (SkillJiaDian.S.HeiAnSkill2Cd < 1 || SkillJiaDian.S.HeiAnSkill2Time < 1)
        {
            HeiAnSkill2RightImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            HeiAnSkill2RightImage.color=new Color32(255, 255, 255, 255);
        }
        
        
        
        
        
        if (SkillJiaDian.S.HeiAnSkill3Damage < 1)
        {
            HeiAnSkill3TopImage.color=new Color32(76,76, 76, 255);
            HeiAnSkill3BottomImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            HeiAnSkill3TopImage.color=new Color32(255, 255, 255, 255);
            HeiAnSkill3BottomImage.color=new Color32(255, 255, 255, 255);
        }

        if (SkillJiaDian.S.HeiAnSkill3Cd < 1 || SkillJiaDian.S.HeiAnSkill3Range < 1)
        {
            HeiAnSkill3RightImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            HeiAnSkill3RightImage.color=new Color32(255, 255, 255, 255);
        }
        
        
    }

    private void OnEnable()
    {
        SetButtonDisable();
        SetShowLevel();
        SetAuto();
        ResfreshSkillCount();
        RefreshSkill();
    }

    private void Awake()
    {
  DianSkill3Button=transform.Find("Bg/DianSkill3/Skill3").GetComponent<Button>();
    DianSkill3TopButton=transform.Find("Bg/DianSkill3/Range").GetComponent<Button>();
    DianSkill3BottomButton=transform.Find("Bg/DianSkill3/CD").GetComponent<Button>();
    DianSkill3RightButton=transform.Find("Bg/DianSkill3/YuanSu").GetComponent<Button>();
    DianSkill3Text=transform.Find("Bg/DianSkill3/Skill3/Count").GetComponent<TextMeshProUGUI>();
    DianSkill3TopText=transform.Find("Bg/DianSkill3/Range/Count").GetComponent<TextMeshProUGUI>();
    DianSkill3BottomText=transform.Find("Bg/DianSkill3/CD/Count").GetComponent<TextMeshProUGUI>();
    DianSkill3RightText=transform.Find("Bg/DianSkill3/YuanSu/Count").GetComponent<TextMeshProUGUI>();
    DianSkill3Top1Line=transform.Find("Bg/DianSkill3/HuangLine (1)").gameObject;
    DianSkill3Bottom1Line=transform.Find("Bg/DianSkill3/HuangLine").gameObject;
    DianSkill3Top2Line=transform.Find("Bg/DianSkill3/LanLineTop").gameObject;
    DianSkill3Bottom2Line=transform.Find("Bg/DianSkill3/LanLineDown").gameObject;
    DianSkill3Image=transform.Find("Bg/DianSkill3/Skill3/image").GetComponent<Image>();
    DianSkill3TopImage=transform.Find("Bg/DianSkill3/Range/image").GetComponent<Image>();
    DianSkill3BottomImage=transform.Find("Bg/DianSkill3/CD/image").GetComponent<Image>();
    DianSkill3RightImage=transform.Find("Bg/DianSkill3/YuanSu/image").GetComponent<Image>();

    
    
    HuoSkill1Button=transform.Find("Bg/HuoSkill1/Skill1").GetComponent<Button>();
    HuoSkill1TopButton=transform.Find("Bg/HuoSkill1/Range").GetComponent<Button>();
    HuoSkill1BottomButton=transform.Find("Bg/HuoSkill1/CD").GetComponent<Button>();
    HuoSkill1RightButton=transform.Find("Bg/HuoSkill1/YuanSu").GetComponent<Button>();
    HuoSkill1Text=transform.Find("Bg/HuoSkill1/Skill1/Count").GetComponent<TextMeshProUGUI>();
    HuoSkill1TopText=transform.Find("Bg/HuoSkill1/Range/Count").GetComponent<TextMeshProUGUI>();
    HuoSkill1BottomText=transform.Find("Bg/HuoSkill1/CD/Count").GetComponent<TextMeshProUGUI>();
    HuoSkill1RightText=transform.Find("Bg/HuoSkill1/YuanSu/Count").GetComponent<TextMeshProUGUI>();
    HuoSkill1Top1Line=transform.Find("Bg/HuoSkill1/HuangLine (1)").gameObject;
    HuoSkill1Bottom1Line=transform.Find("Bg/HuoSkill1/HuangLine").gameObject;
    HuoSkill1Top2Line=transform.Find("Bg/HuoSkill1/LanLineTop").gameObject;
    HuoSkill1Bottom2Line=transform.Find("Bg/HuoSkill1/LanLineDown").gameObject;
    HuoSkill1Image=transform.Find("Bg/HuoSkill1/Skill1/image").GetComponent<Image>();
    HuoSkill1TopImage=transform.Find("Bg/HuoSkill1/Range/image").GetComponent<Image>();
    HuoSkill1BottomImage=transform.Find("Bg/HuoSkill1/CD/image").GetComponent<Image>();
    HuoSkill1RightImage=transform.Find("Bg/HuoSkill1/YuanSu/image").GetComponent<Image>();

        
        
    HuoSkill2Button=transform.Find("Bg/HuoSkill2/Skill2").GetComponent<Button>();
    HuoSkill2TopButton=transform.Find("Bg/HuoSkill2/Range").GetComponent<Button>();
    HuoSkill2BottomButton=transform.Find("Bg/HuoSkill2/CD").GetComponent<Button>();
    HuoSkill2RightButton=transform.Find("Bg/HuoSkill2/YuanSu").GetComponent<Button>();
    HuoSkill2Text=transform.Find("Bg/HuoSkill2/Skill2/Count").GetComponent<TextMeshProUGUI>();
    HuoSkill2TopText=transform.Find("Bg/HuoSkill2/Range/Count").GetComponent<TextMeshProUGUI>();
    HuoSkill2BottomText=transform.Find("Bg/HuoSkill2/CD/Count").GetComponent<TextMeshProUGUI>();
    HuoSkill2RightText=transform.Find("Bg/HuoSkill2/YuanSu/Count").GetComponent<TextMeshProUGUI>();
    HuoSkill2Top1Line=transform.Find("Bg/HuoSkill2/HuangLine (1)").gameObject;
    HuoSkill2Bottom1Line=transform.Find("Bg/HuoSkill2/HuangLine").gameObject;
    HuoSkill2Top2Line=transform.Find("Bg/HuoSkill2/LanLineTop").gameObject;
    HuoSkill2Bottom2Line=transform.Find("Bg/HuoSkill2/LanLineDown").gameObject;
    HuoSkill2Image=transform.Find("Bg/HuoSkill2/Skill2/image").GetComponent<Image>();
    HuoSkill2TopImage=transform.Find("Bg/HuoSkill2/Range/image").GetComponent<Image>();
    HuoSkill2BottomImage=transform.Find("Bg/HuoSkill2/CD/image").GetComponent<Image>();
    HuoSkill2RightImage=transform.Find("Bg/HuoSkill2/YuanSu/image").GetComponent<Image>();

    
    
    HuoSkill3Button=transform.Find("Bg/HuoSkill3/Skill3").GetComponent<Button>();
    HuoSkill3TopButton=transform.Find("Bg/HuoSkill3/Range").GetComponent<Button>();
    HuoSkill3BottomButton=transform.Find("Bg/HuoSkill3/CD").GetComponent<Button>();
    HuoSkill3RightButton=transform.Find("Bg/HuoSkill3/YuanSu").GetComponent<Button>();
    HuoSkill3Text=transform.Find("Bg/HuoSkill3/Skill3/Count").GetComponent<TextMeshProUGUI>();
    HuoSkill3TopText=transform.Find("Bg/HuoSkill3/Range/Count").GetComponent<TextMeshProUGUI>();
    HuoSkill3BottomText=transform.Find("Bg/HuoSkill3/CD/Count").GetComponent<TextMeshProUGUI>();
    HuoSkill3RightText=transform.Find("Bg/HuoSkill3/YuanSu/Count").GetComponent<TextMeshProUGUI>();
    HuoSkill3Top1Line=transform.Find("Bg/HuoSkill3/HuangLine (1)").gameObject;
    HuoSkill3Bottom1Line=transform.Find("Bg/HuoSkill3/HuangLine").gameObject;
    HuoSkill3Top2Line=transform.Find("Bg/HuoSkill3/LanLineTop").gameObject;
    HuoSkill3Bottom2Line=transform.Find("Bg/HuoSkill3/LanLineDown").gameObject;
    HuoSkill3Image=transform.Find("Bg/HuoSkill3/Skill3/image").GetComponent<Image>();
    HuoSkill3TopImage=transform.Find("Bg/HuoSkill3/Range/image").GetComponent<Image>();
    HuoSkill3BottomImage=transform.Find("Bg/HuoSkill3/CD/image").GetComponent<Image>();
    HuoSkill3RightImage=transform.Find("Bg/HuoSkill3/YuanSu/image").GetComponent<Image>();

    
    
    
    HeiAnSkill1Button=transform.Find("Bg/HeiAnSkill1/Skill1").GetComponent<Button>();
    HeiAnSkill1TopButton=transform.Find("Bg/HeiAnSkill1/Range").GetComponent<Button>();
    HeiAnSkill1BottomButton=transform.Find("Bg/HeiAnSkill1/CD").GetComponent<Button>();
    HeiAnSkill1RightButton=transform.Find("Bg/HeiAnSkill1/YuanSu").GetComponent<Button>();
    HeiAnSkill1Text=transform.Find("Bg/HeiAnSkill1/Skill1/Count").GetComponent<TextMeshProUGUI>();
    HeiAnSkill1TopText=transform.Find("Bg/HeiAnSkill1/Range/Count").GetComponent<TextMeshProUGUI>();
    HeiAnSkill1BottomText=transform.Find("Bg/HeiAnSkill1/CD/Count").GetComponent<TextMeshProUGUI>();
    HeiAnSkill1RightText=transform.Find("Bg/HeiAnSkill1/YuanSu/Count").GetComponent<TextMeshProUGUI>();
    HeiAnSkill1Top1Line=transform.Find("Bg/HeiAnSkill1/HuangLine (1)").gameObject;
    HeiAnSkill1Bottom1Line=transform.Find("Bg/HeiAnSkill1/HuangLine").gameObject;
    HeiAnSkill1Top2Line=transform.Find("Bg/HeiAnSkill1/LanLineTop").gameObject;
    HeiAnSkill1Bottom2Line=transform.Find("Bg/HeiAnSkill1/LanLineDown").gameObject;
    HeiAnSkill1Image=transform.Find("Bg/HeiAnSkill1/Skill1/image").GetComponent<Image>();
    HeiAnSkill1TopImage=transform.Find("Bg/HeiAnSkill1/Range/image").GetComponent<Image>();
    HeiAnSkill1BottomImage=transform.Find("Bg/HeiAnSkill1/CD/image").GetComponent<Image>();
    HeiAnSkill1RightImage=transform.Find("Bg/HeiAnSkill1/YuanSu/image").GetComponent<Image>();

    
    
    
    HeiAnSkill2Button=transform.Find("Bg/HeiAnSkill2/Skill2").GetComponent<Button>();
    HeiAnSkill2TopButton=transform.Find("Bg/HeiAnSkill2/Range").GetComponent<Button>();
    HeiAnSkill2BottomButton=transform.Find("Bg/HeiAnSkill2/CD").GetComponent<Button>();
    HeiAnSkill2RightButton=transform.Find("Bg/HeiAnSkill2/YuanSu").GetComponent<Button>();
    HeiAnSkill2Text=transform.Find("Bg/HeiAnSkill2/Skill2/Count").GetComponent<TextMeshProUGUI>();
    HeiAnSkill2TopText=transform.Find("Bg/HeiAnSkill2/Range/Count").GetComponent<TextMeshProUGUI>();
    HeiAnSkill2BottomText=transform.Find("Bg/HeiAnSkill2/CD/Count").GetComponent<TextMeshProUGUI>();
    HeiAnSkill2RightText=transform.Find("Bg/HeiAnSkill2/YuanSu/Count").GetComponent<TextMeshProUGUI>();
    HeiAnSkill2Top1Line=transform.Find("Bg/HeiAnSkill2/HuangLine (1)").gameObject;
    HeiAnSkill2Bottom1Line=transform.Find("Bg/HeiAnSkill2/HuangLine").gameObject;
    HeiAnSkill2Top2Line=transform.Find("Bg/HeiAnSkill2/LanLineTop").gameObject;
    HeiAnSkill2Bottom2Line=transform.Find("Bg/HeiAnSkill2/LanLineDown").gameObject;
    HeiAnSkill2Image=transform.Find("Bg/HeiAnSkill2/Skill2/image").GetComponent<Image>();
    HeiAnSkill2TopImage=transform.Find("Bg/HeiAnSkill2/Range/image").GetComponent<Image>();
    HeiAnSkill2BottomImage=transform.Find("Bg/HeiAnSkill2/CD/image").GetComponent<Image>();
    HeiAnSkill2RightImage=transform.Find("Bg/HeiAnSkill2/YuanSu/image").GetComponent<Image>();

    
    
    
    HeiAnSkill3Button=transform.Find("Bg/HeiAnSkill3/Skill3").GetComponent<Button>();
    HeiAnSkill3TopButton=transform.Find("Bg/HeiAnSkill3/Range").GetComponent<Button>();
    HeiAnSkill3BottomButton=transform.Find("Bg/HeiAnSkill3/CD").GetComponent<Button>();
    HeiAnSkill3RightButton=transform.Find("Bg/HeiAnSkill3/YuanSu").GetComponent<Button>();
    HeiAnSkill3Text=transform.Find("Bg/HeiAnSkill3/Skill3/Count").GetComponent<TextMeshProUGUI>();
    HeiAnSkill3TopText=transform.Find("Bg/HeiAnSkill3/Range/Count").GetComponent<TextMeshProUGUI>();
    HeiAnSkill3BottomText=transform.Find("Bg/HeiAnSkill3/CD/Count").GetComponent<TextMeshProUGUI>();
    HeiAnSkill3RightText=transform.Find("Bg/HeiAnSkill3/YuanSu/Count").GetComponent<TextMeshProUGUI>();
    HeiAnSkill3Top1Line=transform.Find("Bg/HeiAnSkill3/HuangLine (1)").gameObject;
    HeiAnSkill3Bottom1Line=transform.Find("Bg/HeiAnSkill3/HuangLine").gameObject;
    HeiAnSkill3Top2Line=transform.Find("Bg/HeiAnSkill3/LanLineTop").gameObject;
    HeiAnSkill3Bottom2Line=transform.Find("Bg/HeiAnSkill3/LanLineDown").gameObject;
    HeiAnSkill3Image=transform.Find("Bg/HeiAnSkill3/Skill3/image").GetComponent<Image>();
    HeiAnSkill3TopImage=transform.Find("Bg/HeiAnSkill3/Range/image").GetComponent<Image>();
    HeiAnSkill3BottomImage=transform.Find("Bg/HeiAnSkill3/CD/image").GetComponent<Image>();
    HeiAnSkill3RightImage=transform.Find("Bg/HeiAnSkill3/YuanSu/image").GetComponent<Image>();
    }

    private void Start()
    {
        ResetButton.onClick.AddListener(() =>
        {
            Reset();
        });
        
        
        IceSkill1Button.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.IceSkill1 >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.IceSkill1])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(IceSkill1Button);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.IceSkill1++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        IceSkill1TopButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.IceSkill1Range >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.IceSkill1Range])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(IceSkill1TopButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.IceSkill1Range++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        IceSkill1BottomButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.IceSkill1Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.IceSkill1CD])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(IceSkill1BottomButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.IceSkill1Cd++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        IceSkill1RightButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.IceSkill1YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.IceSkill1YuanSu])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(IceSkill1RightButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.IceSkill1YuanSu++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        DianSkill2Button.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.DianSkill2 >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.DianSkill2])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(DianSkill2Button);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DianSkill2++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        DianSkill2BottomButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.DianSkill2Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.DianSkill2CD])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(DianSkill2BottomButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DianSkill2Cd++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        DianSkill2TopButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.DianSkill2Duration >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.DianSkill2Time])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(DianSkill2TopButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DianSkill2Duration++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        DianSkill2RightButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.DianSkill2YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.DianSkill2YuanSu])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(DianSkill2RightButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DianSkill2YuanSu++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        DianSkill3Button.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.DianSkill3 >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.DianSkill3])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(DianSkill3Button);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DianSkill3++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        DianSkill3TopButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.DianSkill3Count >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.DianSkill3Count])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(DianSkill3TopButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DianSkill3Count++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        DianSkill3BottomButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.DianSkill3Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.DianSkill3CD])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(DianSkill3BottomButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DianSkill3Cd++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        DianSkill3RightButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.DianSkill3YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.DianSkill3YuanSu])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(DianSkill3RightButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DianSkill3YuanSu++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HuoSkill1Button.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HuoSkill1 >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HuoSkill1])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HuoSkill1Button);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HuoSkill1++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HeiAnSkill1Button.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HeiAnSkill1 >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HeiAnSkill1])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HeiAnSkill1Button);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HeiAnSkill1++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HeiAnSkill1BottomButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HeiAnSkill1Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HeiAnSkill1CD])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HeiAnSkill1BottomButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HeiAnSkill1Cd++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HeiAnSkill1TopButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HeiAnSkill1Range >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HeiAnSkill1Range])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HeiAnSkill1TopButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HeiAnSkill1Range++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HeiAnSkill1RightButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HeiAnSkill1YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HeiAnSkill1YuanSu])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HeiAnSkill1RightButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HeiAnSkill1YuanSu++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HuoSkill1BottomButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HuoSkill1Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HuoSkill1CD])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HuoSkill1BottomButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HuoSkill1Cd++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HuoSkill1TopButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HuoSkill1Count >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HuoSkill1Count])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HuoSkill1TopButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HuoSkill1Count++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HuoSkill1RightButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HuoSkill1YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HuoSkill1YuanSu])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HuoSkill1RightButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HuoSkill1YuanSu++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        
        HuoSkill2Button.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HuoSkill2 >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HuoSkill2])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HuoSkill2Button);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HuoSkill2++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HuoSkill2BottomButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HuoSkill2Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HuoSkill2CD])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HuoSkill2BottomButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HuoSkill2Cd++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HuoSkill2TopButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HuoSkill2Time >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HuoSkill2Time])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HuoSkill2TopButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HuoSkill2Time++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        
        HuoSkill2RightButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HuoSkill2YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HuoSkill2YuanSu])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HuoSkill2RightButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HuoSkill2YuanSu++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        
        HuoSkill3RightButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HuoSkill3YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HuoSkill3YuanSu])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HuoSkill3RightButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HuoSkill3YuanSu++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HuoSkill3Button.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HuoSkill3 >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HuoSkill3])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HuoSkill3Button);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HuoSkill3++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HuoSkill3BottomButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HuoSkill3Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HuoSkill3CD])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HuoSkill3BottomButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HuoSkill3Cd++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HuoSkill3TopButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HuoSkill3Count >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HuoSkill3Count])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HuoSkill3TopButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HuoSkill3Count++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
          HeiAnSkill2RightButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HeiAnSkill2YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HeiAnSkill2YuanSu])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HeiAnSkill2RightButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HeiAnSkill2YuanSu++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HeiAnSkill2Button.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HeiAnSkill2Damage >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HeiAnSkill2])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HeiAnSkill2Button);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HeiAnSkill2Damage++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HeiAnSkill2BottomButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HeiAnSkill2Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HeiAnSkill2CD])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HeiAnSkill2BottomButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HeiAnSkill2Cd++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HeiAnSkill2TopButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HeiAnSkill2Time >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HeiAnSkill2Time])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HeiAnSkill2TopButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HeiAnSkill2Time++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        
        
        
        
        
        
        
        
        
        
        
         HeiAnSkill3RightButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HeiAnSkill3YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HeiAnSkill3YuanSu])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HeiAnSkill3RightButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HeiAnSkill3YuanSu++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HeiAnSkill3Button.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HeiAnSkill3Damage >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HeiAnSkill3])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HeiAnSkill3Button);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HeiAnSkill3Damage++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HeiAnSkill3BottomButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HeiAnSkill3Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HeiAnSkill3CD])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HeiAnSkill3BottomButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HeiAnSkill3Cd++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        HeiAnSkill3TopButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.HeiAnSkill3Range >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.HeiAnSkill3Range])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(HeiAnSkill3TopButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.HeiAnSkill3Range++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        
        
        jia1.onClick.AddListener(() =>
        {
            SkillYuanSuWindow.gameObject.SetActive(true);
            SkillYuanSuWindow skillYuanSuWindow = SkillYuanSuWindow.GetComponent<SkillYuanSuWindow>();
            skillYuanSuWindow.skillType = 1;
            skillYuanSuWindow.Refresh();
        });
        jia3.onClick.AddListener(() =>
        {
            SkillYuanSuWindow.gameObject.SetActive(true);
            SkillYuanSuWindow skillYuanSuWindow = SkillYuanSuWindow.GetComponent<SkillYuanSuWindow>();
            skillYuanSuWindow.skillType = 3;
            skillYuanSuWindow.Refresh();
        });
        jia2.onClick.AddListener(() =>
        {
            SkillYuanSuWindow.gameObject.SetActive(true);
            SkillYuanSuWindow skillYuanSuWindow = SkillYuanSuWindow.GetComponent<SkillYuanSuWindow>();
            skillYuanSuWindow.skillType = 2;
            skillYuanSuWindow.Refresh();
        });
        
        
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            Debug.Log("任务界面退出");
            WindowController.S.RoleWindow.SetActive(true);
        });
        maskButton.onClick.AddListener(() =>
        {
            skillSwitchObj.SetActive(false);
        });
        
        
        normalAttackButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }

            if (SkillJiaDian.S.NormalAttack >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.NormalAttack])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            
            TriggerButtonClickAnim(normalAttackButton);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.NormalAttack++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        attackSpeedButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.AttackSpeed >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.AttackSpeed])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(attackSpeedButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.AttackSpeed++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        dashButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.Dash >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Dash])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(dashButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Dash++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        dashCdButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.DashCd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.DashCd])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(dashCdButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DashCd++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        critButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.Crit >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Crit])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(critButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Crit++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        critDamageButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.CritDamage >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.CritDamage])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(critDamageButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.CritDamage++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        moveSpeedButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.MoveSpeed >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.MoveSpeed])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(moveSpeedButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MoveSpeed++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        moveAddDefenseButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.MoveAddDefense >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.MoveAddDefense])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(moveAddDefenseButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MoveAddDefense++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        moveAddAttackButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.MoveAddAttack >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.MoveAddAttack])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(moveAddAttackButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MoveAddAttack++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill1Button.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.DianSkill1Damage >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill1])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(skill1Button);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DianSkill1Damage++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill2Button.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.IceSkill2Damage >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill2])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(skill2Button);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.IceSkill2Damage++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill3Button.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.IceSkill3Damage >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill3])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(skill3Button);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.IceSkill3Damage++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill1CdButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.DianSkill1Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill1Cd])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(skill1CdButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DianSkill1Cd++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill2CdButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.IceSkill2Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill2Cd])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(skill2CdButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.IceSkill2Cd++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill3CdButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.IceSkill3Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill3Cd])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(skill3CdButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.IceSkill3Cd++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill1RangeButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.DianSkill1Range >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill1Range])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(skill1RangeButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DianSkill1Range++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill1YiDianButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.DianSkill1YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill1YuanSu])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(skill1YiDianButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DianSkill1YuanSu++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill2TimeButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.IceSkill2Time >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill2Time])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(skill2TimeButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.IceSkill2Time++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill2AddDefenseButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.IceSkill2YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill2YuanSu])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(skill2AddDefenseButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.IceSkill2YuanSu++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill3RangeButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.IceSkill3Range >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill3Range])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(skill3RangeButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.IceSkill3Range++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill3JianSuButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.IceSkill3YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill3YuanSu])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            TriggerButtonClickAnim(skill3JianSuButton);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.IceSkill3YuanSu++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
            SetButtonDisable();
        });
        
        attackButton.onClick.AddListener(() =>
        {
            if (PlayerData.S.zhuanjinCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前专精点数不足");
                return;
            }
          
            TriggerButtonClickAnim(attackButton);

            PlayerData.S.zhuanjinCount--;
            SkillJiaDian.S.MonsterAttack++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
        });
        
        hpButton.onClick.AddListener(() =>
        {
            if (PlayerData.S.zhuanjinCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前专精点数不足");
                return;
            }
          
            TriggerButtonClickAnim(attackButton);

            PlayerData.S.zhuanjinCount--;
            SkillJiaDian.S.MonsterHp++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
        });
        
        defenseButton.onClick.AddListener(() =>
        {
            if (PlayerData.S.zhuanjinCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前专精点数不足");
                return;
            }
          
            TriggerButtonClickAnim(attackButton);

            PlayerData.S.zhuanjinCount--;
            SkillJiaDian.S.MonsterDefense++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
        });
        
        critMonsterButton.onClick.AddListener(() =>
        {
            if (PlayerData.S.zhuanjinCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前专精点数不足");
                return;
            }
          
            TriggerButtonClickAnim(attackButton);

            PlayerData.S.zhuanjinCount--;
            SkillJiaDian.S.MonsterCrit++;
            StoreController.S.SaveStoreData();
            ResfreshSkillCount();
            SetShowLevel();
        });
    }
}
