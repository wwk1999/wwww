using System;
using System.Collections;
using System.Collections.Generic;
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
    
    
    public Button normalAttack;
    public Button attackSpeed;
    
    public Button dash;
    public Button dashCd;
    
    public Button crit;
    public Button critDamage;
    
    public Button moveSpeed;
    public Button moveAddDefense;
    public Button moveAddAttack;
    
    public Button skill1;
    public Button skill2;
    public Button skill3;
    public Button skill1Cd;
    public Button skill2Cd;
    public Button skill3Cd;
    public Button skill1Range;
    public Button skill1YiDian;
    public Button skill2Time;
    public Button skill2AddDefense;
    public Button skill3Range;
    public Button skill3JianSu;
    public Button attack;
    public Button hp;
    public Button defense;
    public Button critMonster;
    
    
    
    
    
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
        attackSpeed.interactable = SkillJiaDian.S.NormalAttack>0;
        dashCd.interactable = SkillJiaDian.S.Dash>0;
        moveAddAttack.interactable=SkillJiaDian.S.MoveSpeed>0;
        moveAddDefense.interactable=SkillJiaDian.S.MoveSpeed>0;
        
        
        critDamage.interactable=SkillJiaDian.S.Crit>0;
        skill1Range.interactable=SkillJiaDian.S.Skill1Damage>0;
        skill1Cd.interactable=SkillJiaDian.S.Skill1Damage>0;
        skill1YiDian.interactable=SkillJiaDian.S.Skill1Range>0&&SkillJiaDian.S.Skill1Cd>0;
        
        skill2Time.interactable=SkillJiaDian.S.Skill2Damage>0;
        skill2Cd.interactable=SkillJiaDian.S.Skill2Damage>0;
        skill2AddDefense.interactable=SkillJiaDian.S.Skill2Time>0&&SkillJiaDian.S.Skill2Cd>0;
        
        skill3Range.interactable=SkillJiaDian.S.Skill3Damage>0;
        skill3Cd.interactable=SkillJiaDian.S.Skill3Damage>0;
        skill3JianSu.interactable=SkillJiaDian.S.Skill3Range>0&&SkillJiaDian.S.Skill3Cd>0;

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
        
        
        normalAttack.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.NormalAttack++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        attackSpeed.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.AttackSpeed++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        dash.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Dash++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        dashCd.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.DashCd++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        crit.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Crit++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        critDamage.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.CritDamage++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        moveSpeed.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MoveSpeed++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        moveAddDefense.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MoveAddDefense++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        moveAddAttack.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MoveAddAttack++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill1.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill1Damage++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill2.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill2Damage++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill3.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill3Damage++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill1Cd.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill1Cd++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill2Cd.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill2Cd++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill3Cd.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill3Cd++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill1Range.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill1Range++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill1YiDian.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill1YiDian++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill2Time.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill2Time++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill2AddDefense.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill2AddDefense++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill3Range.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill3Range++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        skill3JianSu.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.Skill3JianSu++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        attack.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MonsterAttack++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        hp.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MonsterHp++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        defense.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MonsterDefense++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
        
        critMonster.onClick.AddListener(() =>
        {
            if (SkillJiaDian.S.CurrentSkillCount <= 0)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"当前技能点数不足");
                return;
            }
            SkillJiaDian.S.CurrentSkillCount--;
            SkillJiaDian.S.MonsterCrit++;
            StoreController.S.SaveStoreData();
            SetShowLevel();
            SetButtonDisable();
        });
    }
}
