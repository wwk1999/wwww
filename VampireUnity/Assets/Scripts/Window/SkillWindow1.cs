using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillWindow1 : MonoBehaviour
{
    public Button exitButton; // 退出按钮

    public Button maskButton;
    public GameObject skillSwitchObj;

    public TextMeshProUGUI skillCount;
    public TextMeshProUGUI monsterCount;


    public Button normalAttackButton;
    public Button attackSpeedButton;

    public Button dashButton;
    public Button dashCdButton;

    public Button critButton;
    public Button critDamageButton;

    public Button moveSpeedButton;
    public Button moveAddDefenseButton;
    public Button moveAddAttackButton;

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
    public Button attackButton;
    public Button hpButton;
    public Button defenseButton;
    public Button critMonsterButton;
    
    
    
    
    
    public TextMeshProUGUI normalAttackLevel;
    public TextMeshProUGUI attackSpeedLevel;
    
    public TextMeshProUGUI dashLevel;
    public TextMeshProUGUI dashCdLevel;
    
    public TextMeshProUGUI critLevel;
    public TextMeshProUGUI critDamageLevel;
    
    public TextMeshProUGUI moveSpeedLevel;
    public TextMeshProUGUI moveAddDefenseLevel;
    public TextMeshProUGUI moveAddAttackLevel;
    
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

    
    
    public TextMeshProUGUI attackLevel;
    public TextMeshProUGUI hpLevel;
    public TextMeshProUGUI defenseLevel;
    public TextMeshProUGUI critMonsterLevel;
    
    
    
    
    public Image normalAttackImage;
    public Image attackSpeedImage;

    public Image dashImage;
    public Image dashCdImage;

    public Image critImage;
    public Image critDamageImage;

    public Image moveSpeedImage;
    public Image moveAddDefenseImage;
    public Image moveAddAttackImage;

    public Image skill1Image;
    public Image skill2Image;
    public Image skill3Image;
    public Image skill1CdImage;
    public Image skill2CdImage;
    public Image skill3CdImage;
    public Image skill1RangeImage;
    public Image skill1YiDianImage;
    public Image skill2TimeImage;
    public Image skill2AddDefenseImage;
    public Image skill3RangeImage;
    public Image skill3JianSuImage;
 


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
    
    
    public GameObject skill1Auto;
    public GameObject skill2Auto;
    public GameObject skill3Auto;
    public GameObject dashAuto;

    public void SetAuto()
    {
        skill1Auto.gameObject.SetActive(SkillData.S.skill1Auto);
        skill2Auto.gameObject.SetActive(SkillData.S.skill2Auto);
        skill3Auto.gameObject.SetActive(SkillData.S.skill3Auto);
        dashAuto.gameObject.SetActive(SkillData.S.dashAuto);

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
    }

    private void OnEnable()
    {
        SetButtonDisable();
        SetShowLevel();
        SetAuto();
        ResfreshSkillCount();
    }

    private void Start()
    {
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
            if (SkillJiaDian.S.DianSkill1YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill1YiDian])
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
            if (SkillJiaDian.S.IceSkill2YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill2AddDefense])
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
            if (SkillJiaDian.S.IceSkill3YuanSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill3JianSu])
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
