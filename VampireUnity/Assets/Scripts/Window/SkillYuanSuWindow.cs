using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillYuanSuWindow : MonoBehaviour
{
    public Button exitButton;
    public Button iceButton;
    public Button huoButton;
    public Button heianButton;
    public Button dianButton;
    public Text iceText;
    public Text huoText;
    public Text heianText;
    public Text dianText;
    
    public SkillWindow1 skillWindow1;

    [NonSerialized] public int skillType = 0;

    private void Start()
    {
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        iceButton.onClick.AddListener(() =>
        {
            switch (skillType)
            {
                case 1:
                    SkillJiaDian.S.skill1Type = SkillYuanSuType.Ice;
                    skillWindow1.RefreshSkill();
                    break;
                case 2:
                    SkillJiaDian.S.skill2Type = SkillYuanSuType.Ice;
                    skillWindow1.RefreshSkill();
                    break;
                case 3:
                    SkillJiaDian.S.skill3Type = SkillYuanSuType.Ice;
                    skillWindow1.RefreshSkill();
                    break;
            }
            gameObject.SetActive(false);
            StoreController.S.SaveStoreData();

        });
        
        heianButton.onClick.AddListener(() =>
        {
            switch (skillType)
            {
                case 1:
                    SkillJiaDian.S.skill1Type = SkillYuanSuType.HeiAn;
                    skillWindow1.RefreshSkill();
                    break;
                case 2:
                    SkillJiaDian.S.skill2Type = SkillYuanSuType.HeiAn;
                    skillWindow1.RefreshSkill();
                    break;
                case 3:
                    SkillJiaDian.S.skill3Type = SkillYuanSuType.HeiAn;
                    skillWindow1.RefreshSkill();
                    break;
            }
            gameObject.SetActive(false);

            StoreController.S.SaveStoreData();

        });
        
        huoButton.onClick.AddListener(() =>
        {
            switch (skillType)
            {
                case 1:
                    SkillJiaDian.S.skill1Type = SkillYuanSuType.Huo;
                    skillWindow1.RefreshSkill();
                    break;
                case 2:
                    SkillJiaDian.S.skill2Type = SkillYuanSuType.Huo;
                    skillWindow1.RefreshSkill();
                    break;
                case 3:
                    SkillJiaDian.S.skill3Type = SkillYuanSuType.Huo;
                    skillWindow1.RefreshSkill();
                    break;
            }
            gameObject.SetActive(false);

            StoreController.S.SaveStoreData();

        });
        
        dianButton.onClick.AddListener(() =>
        {
            switch (skillType)
            {
                case 1:
                    SkillJiaDian.S.skill1Type = SkillYuanSuType.Dian;
                    skillWindow1.RefreshSkill();
                    break;
                case 2:
                    SkillJiaDian.S.skill2Type = SkillYuanSuType.Dian;
                    skillWindow1.RefreshSkill();
                    break;
                case 3:
                    SkillJiaDian.S.skill3Type = SkillYuanSuType.Dian;
                    skillWindow1.RefreshSkill();
                    break;
            }
            gameObject.SetActive(false);

            StoreController.S.SaveStoreData();
        });
    }

    public void Refresh()
    {
        switch (skillType)
        {
            case 1:
                iceText.text = "冰Skill1";
                huoText.text = "火Skill1";
                heianText.text = "黑暗Skill1";
                dianText.text = "电Skill1";
                break;
            case 2:
                iceText.text = "冰Skill2";
                huoText.text = "火Skill2";
                heianText.text = "黑暗Skill2";
                dianText.text = "电Skill2";
                break;
            case 3:
                iceText.text = "冰Skill3";
                huoText.text = "火Skill3";
                heianText.text = "黑暗Skill3";
                dianText.text = "电Skill3";
                break;
        }
    }
}
