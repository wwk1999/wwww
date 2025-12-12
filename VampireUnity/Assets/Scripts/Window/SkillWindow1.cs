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
    }

    private void Start()
    {
        SetButtonDisable();
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
    }
}
