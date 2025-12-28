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

    public void SetLine()
    {
        skill1RangeLine.SetActive(SkillJiaDian.S.Skill1Range >= 1);
        skill1CdLine.SetActive(SkillJiaDian.S.Skill1Cd >= 1);
        skill1YiDianLine1.SetActive(SkillJiaDian.S.Skill1YiDian >= 1);
        skill1YiDianLine2.SetActive(SkillJiaDian.S.Skill1YiDian >= 1);
        skill2CdLine.SetActive(SkillJiaDian.S.Skill2Cd >= 1);
        skill2TimeLine.SetActive(SkillJiaDian.S.Skill2Time >= 1);
        skill2DefenseLine1.SetActive(SkillJiaDian.S.Skill2AddDefense >= 1);
        skill2DefenseLine2.SetActive(SkillJiaDian.S.Skill2AddDefense >= 1);
        skill3RangeLine.SetActive(SkillJiaDian.S.Skill3Range >= 1);
        skill3CdLine.SetActive(SkillJiaDian.S.Skill3Cd >= 1);
        skill3JianSuLine1.SetActive(SkillJiaDian.S.Skill3JianSu >= 1);
        skill3JianSuLine2.SetActive(SkillJiaDian.S.Skill3JianSu >= 1);
        attackSpeedLine.SetActive(SkillJiaDian.S.AttackSpeed >= 1);
        dashCdLine.SetActive(SkillJiaDian.S.DashCd >= 1);
        moveAddAttackLine.SetActive(SkillJiaDian.S.MoveAddAttack >= 1);
        moveAddDefenseLine.SetActive(SkillJiaDian.S.MoveAddDefense >= 1);
        critDamageLine.SetActive(SkillJiaDian.S.CritDamage >= 1);
    }


   public void SetShowLevel()
{
    // Normal Attack
    normalAttackLevel.gameObject.SetActive(SkillJiaDian.S.NormalAttack > 0);
    normalAttackLevel.text = SkillJiaDian.S.NormalAttack.ToString();
    
    // Attack Speed
    attackSpeedLevel.gameObject.SetActive(SkillJiaDian.S.AttackSpeed > 0);
    attackSpeedLevel.text = SkillJiaDian.S.AttackSpeed.ToString();
    
    // Dash
    dashLevel.gameObject.SetActive(SkillJiaDian.S.Dash > 0);
    dashLevel.text = SkillJiaDian.S.Dash.ToString();
    
    // Dash CD
    dashCdLevel.gameObject.SetActive(SkillJiaDian.S.DashCd > 0);
    dashCdLevel.text = SkillJiaDian.S.DashCd.ToString();
    
    // Crit
    critLevel.gameObject.SetActive(SkillJiaDian.S.Crit > 0);
    critLevel.text = SkillJiaDian.S.Crit.ToString();
    
    // Crit Damage
    critDamageLevel.gameObject.SetActive(SkillJiaDian.S.CritDamage > 0);
    critDamageLevel.text = SkillJiaDian.S.CritDamage.ToString();
    
    // Move Speed
    moveSpeedLevel.gameObject.SetActive(SkillJiaDian.S.MoveSpeed > 0);
    moveSpeedLevel.text = SkillJiaDian.S.MoveSpeed.ToString();
    
    // Move Add Defense
    moveAddDefenseLevel.gameObject.SetActive(SkillJiaDian.S.MoveAddDefense > 0);
    moveAddDefenseLevel.text = SkillJiaDian.S.MoveAddDefense.ToString();
    
    // Move Add Attack
    moveAddAttackLevel.gameObject.SetActive(SkillJiaDian.S.MoveAddAttack > 0);
    moveAddAttackLevel.text = SkillJiaDian.S.MoveAddAttack.ToString();
    
    // Skill1 Level (Damage)
    skill1Level.gameObject.SetActive(SkillJiaDian.S.Skill1Damage > 0);
    skill1Level.text = SkillJiaDian.S.Skill1Damage.ToString();
    
    // Skill2 Level (Damage)
    skill2Level.gameObject.SetActive(SkillJiaDian.S.Skill2Damage > 0);
    skill2Level.text = SkillJiaDian.S.Skill2Damage.ToString();
    
    // Skill3 Level (Damage)
    skill3Level.gameObject.SetActive(SkillJiaDian.S.Skill3Damage > 0);
    skill3Level.text = SkillJiaDian.S.Skill3Damage.ToString();
    
    // Skill1 CD
    skill1CdLevel.gameObject.SetActive(SkillJiaDian.S.Skill1Cd > 0);
    skill1CdLevel.text = SkillJiaDian.S.Skill1Cd.ToString();
    
    // Skill2 CD
    skill2CdLevel.gameObject.SetActive(SkillJiaDian.S.Skill2Cd > 0);
    skill2CdLevel.text = SkillJiaDian.S.Skill2Cd.ToString();
    
    // Skill3 CD
    skill3CdLevel.gameObject.SetActive(SkillJiaDian.S.Skill3Cd > 0);
    skill3CdLevel.text = SkillJiaDian.S.Skill3Cd.ToString();
    
    // Skill1 Range
    skill1RangeLevel.gameObject.SetActive(SkillJiaDian.S.Skill1Range > 0);
    skill1RangeLevel.text = SkillJiaDian.S.Skill1Range.ToString();
    
    // Skill1 YiDian
    skill1YiDianLevel.gameObject.SetActive(SkillJiaDian.S.Skill1YiDian > 0);
    skill1YiDianLevel.text = SkillJiaDian.S.Skill1YiDian.ToString();
    
    // Skill2 Time
    skill2TimeLevel.gameObject.SetActive(SkillJiaDian.S.Skill2Time > 0);
    skill2TimeLevel.text = SkillJiaDian.S.Skill2Time.ToString();
    
    // Skill2 Add Defense
    skill2AddDefenseLevel.gameObject.SetActive(SkillJiaDian.S.Skill2AddDefense > 0);
    skill2AddDefenseLevel.text = SkillJiaDian.S.Skill2AddDefense.ToString();
    
    // Skill3 Range
    skill3RangeLevel.gameObject.SetActive(SkillJiaDian.S.Skill3Range > 0);
    skill3RangeLevel.text = SkillJiaDian.S.Skill3Range.ToString();
    
    // Skill3 JianSu
    skill3JianSuLevel.gameObject.SetActive(SkillJiaDian.S.Skill3JianSu > 0);
    skill3JianSuLevel.text = SkillJiaDian.S.Skill3JianSu.ToString();
    
    
    attackLevel.gameObject.SetActive(SkillJiaDian.S.MonsterAttack > 0);
    attackLevel.text = SkillJiaDian.S.MonsterAttack.ToString();
    
    critMonsterLevel.gameObject.SetActive(SkillJiaDian.S.MonsterCrit > 0);
    critMonsterLevel.text = SkillJiaDian.S.MonsterCrit.ToString();
    
    hpLevel.gameObject.SetActive(SkillJiaDian.S.MonsterHp > 0);
    hpLevel.text = SkillJiaDian.S.MonsterHp.ToString();
    
    defenseLevel.gameObject.SetActive(SkillJiaDian.S.MonsterDefense > 0);
    defenseLevel.text = SkillJiaDian.S.MonsterDefense.ToString();
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
        skill1RangeButton.interactable=SkillJiaDian.S.Skill1Damage>0;
        skill1CdButton.interactable=SkillJiaDian.S.Skill1Damage>0;
        skill1YiDianButton.interactable=SkillJiaDian.S.Skill1Range>0&&SkillJiaDian.S.Skill1Cd>0;
        
        skill2TimeButton.interactable=SkillJiaDian.S.Skill2Damage>0;
        skill2CdButton.interactable=SkillJiaDian.S.Skill2Damage>0;
        skill2AddDefenseButton.interactable=SkillJiaDian.S.Skill2Time>0&&SkillJiaDian.S.Skill2Cd>0;
        
        skill3RangeButton.interactable=SkillJiaDian.S.Skill3Damage>0;
        skill3CdButton.interactable=SkillJiaDian.S.Skill3Damage>0;
        skill3JianSuButton.interactable=SkillJiaDian.S.Skill3Range>0&&SkillJiaDian.S.Skill3Cd>0;

    }

    public void SetImage()
    {
        if (SkillJiaDian.S.Skill1Damage < 1)
        {
             skill1RangeImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill1RangeImage.color=new Color32(255, 255, 255, 255);
        }
        
        if (SkillJiaDian.S.Skill1Damage < 1)
        {
            skill1CdImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill1CdImage.color=new Color32(255, 255, 255, 255);
        }
        
        if (SkillJiaDian.S.Skill1Range < 1||SkillJiaDian.S.Skill1Cd<1)
        {
            skill1YiDianImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill1YiDianImage.color=new Color32(255, 255, 255, 255);
        }
        
        
        
        if (SkillJiaDian.S.Skill2Damage < 1)
        {
            skill2TimeImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill2TimeImage.color=new Color32(255, 255, 255, 255);
        }
        
        if (SkillJiaDian.S.Skill2Damage < 1)
        {
            skill2CdImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill2CdImage.color=new Color32(255, 255, 255, 255);
        }
        
        if (SkillJiaDian.S.Skill2Time < 1||SkillJiaDian.S.Skill2Cd<1)
        {
            skill2AddDefenseImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill2AddDefenseImage.color=new Color32(255, 255, 255, 255);
        }
        
        
        
        if (SkillJiaDian.S.Skill3Damage < 1)
        {
            skill3RangeImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill3RangeImage.color=new Color32(255, 255, 255, 255);
        }
        
        if (SkillJiaDian.S.Skill3Damage < 1)
        {
            skill3CdImage.color=new Color32(76,76, 76, 255);
        }
        else
        {
            skill3CdImage.color=new Color32(255, 255, 255, 255);
        }
        
        if (SkillJiaDian.S.Skill3Range < 1||SkillJiaDian.S.Skill3Cd<1)
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
    }

    private void OnEnable()
    {
        SetButtonDisable();
        SetShowLevel();
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
            
            normalAttackButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.NormalAttack++;
            StoreController.S.SaveStoreData();
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
            attackSpeedButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.AttackSpeed++;
            StoreController.S.SaveStoreData();
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
            dashButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Dash++;
            StoreController.S.SaveStoreData();
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
            dashCdButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DashCd++;
            StoreController.S.SaveStoreData();
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
            critButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Crit++;
            StoreController.S.SaveStoreData();
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
            critDamageButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.CritDamage++;
            StoreController.S.SaveStoreData();
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
            moveSpeedButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MoveSpeed++;
            StoreController.S.SaveStoreData();
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
            moveAddDefenseButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MoveAddDefense++;
            StoreController.S.SaveStoreData();
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
            moveAddAttackButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MoveAddAttack++;
            StoreController.S.SaveStoreData();
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
            if (SkillJiaDian.S.Skill1Damage >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill1])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            skill1Button.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill1Damage++;
            StoreController.S.SaveStoreData();
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
            if (SkillJiaDian.S.Skill2Damage >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill2])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            skill2Button.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill2Damage++;
            StoreController.S.SaveStoreData();
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
            if (SkillJiaDian.S.Skill3Damage >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill3])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            skill3Button.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill3Damage++;
            StoreController.S.SaveStoreData();
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
            if (SkillJiaDian.S.Skill1Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill1Cd])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            skill1CdButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill1Cd++;
            StoreController.S.SaveStoreData();
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
            if (SkillJiaDian.S.Skill2Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill2Cd])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            skill2CdButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill2Cd++;
            StoreController.S.SaveStoreData();
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
            if (SkillJiaDian.S.Skill3Cd >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill3Cd])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            skill3CdButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill3Cd++;
            StoreController.S.SaveStoreData();
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
            if (SkillJiaDian.S.Skill1Range >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill1Range])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            skill1RangeButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill1Range++;
            StoreController.S.SaveStoreData();
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
            if (SkillJiaDian.S.Skill1YiDian >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill1YiDian])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            skill1YiDianButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill1YiDian++;
            StoreController.S.SaveStoreData();
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
            if (SkillJiaDian.S.Skill2Time >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill2Time])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            skill2TimeButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill2Time++;
            StoreController.S.SaveStoreData();
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
            if (SkillJiaDian.S.Skill2AddDefense >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill2AddDefense])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            skill2AddDefenseButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill2AddDefense++;
            StoreController.S.SaveStoreData();
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
            if (SkillJiaDian.S.Skill3Range >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill3Range])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            skill3RangeButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill3Range++;
            StoreController.S.SaveStoreData();
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
            if (SkillJiaDian.S.Skill3JianSu >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Skill3JianSu])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            skill3JianSuButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill3JianSu++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        attackButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.MonsterAttack >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Attack])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            attackButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MonsterAttack++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        hpButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.MonsterHp >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Hp])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            hpButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MonsterHp++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        defenseButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.MonsterDefense >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.Defense])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            defenseButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MonsterDefense++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        critMonsterButton.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            if (SkillJiaDian.S.MonsterCrit >= SkillConfig.MaxSkillLevel[SkillConfig.SkillButtonType.CritMonster])
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"已达最大等级");
                return;
            }
            critMonsterButton.gameObject.GetComponent<Animator>().Play("SkillClick",0,0f);

            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MonsterCrit++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
    }
}
