using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Mysql;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddUserSourceStoneData
{
    public int id;
    public int userid;
    public int sourcestoneid;
    public int sourcestonecount;
}
public class RoleWindow1 : MonoBehaviour
{
    public SkeletonGraphic playerSkeleton;
    public Text yuanLinText;
    public Text yuanNengText;
    public Button weaponButton; // 武器按钮
    public Button monsterBookButton; // 怪物图鉴按钮
    public Button bagButton; // 背包按钮
    public Button skillButton;
    public Button taskButton;
    public Button settingButton;
    public Button shopButton;
    public Button startButton;
    public Button yuanlinButton;
    public Button bloodEnergyButton;
    public Text levelText; // 等级文本
    public Slider expSlider; // 经验条
    public Button debugLevel;
    public Button debugLingHun;
    public Button debugSkillCount;
    public Button debugWeaponFragment;
    public Button debugJingCui;
    public Button debugPlayerLevel;
    public Button debugBaoshi;
    public Button debugChongWu;


    
    
    public Button duanzaoButton;
    public Button chibangButton;
    public Button chongwuButton;

    public Animator whiteChiBang;
    public Animator greenChiBang;
    public Animator blueChiBang;
    public Animator purpleChiBang;
    public Animator orangeChiBang;
    public Animator redChiBang;

    public TextMeshProUGUI TuJian;
    public TextMeshProUGUI Weapon;
    public TextMeshProUGUI Bag;
    public TextMeshProUGUI ChiBang;
    public TextMeshProUGUI Skill;
    public TextMeshProUGUI Setting;
    public TextMeshProUGUI DuanZao;
    public TextMeshProUGUI StartGame;


    public Button TitleButton;

    public void SwitchLanguage(LanguageType language)
    {
        switch (language)
        {
            case LanguageType.Chinese:
                TuJian.characterSpacing = 20;
                Weapon.characterSpacing = 20;
                Bag.characterSpacing = 20;
                ChiBang.characterSpacing = 20;
                Skill.characterSpacing =20;
                Setting.characterSpacing = 20;
                DuanZao.characterSpacing = 20;
                StartGame.characterSpacing =20;
                
                TuJian.text = LanguageConfig.LanguageItems[LanguageType.Chinese].RoleWindowLanguage.TuJian;
                Weapon.text = LanguageConfig.LanguageItems[LanguageType.Chinese].RoleWindowLanguage.WuQi;
                Bag.text = LanguageConfig.LanguageItems[LanguageType.Chinese].RoleWindowLanguage.Bag;
                ChiBang.text = LanguageConfig.LanguageItems[LanguageType.Chinese].RoleWindowLanguage.ChiBang;
                Skill.text = LanguageConfig.LanguageItems[LanguageType.Chinese].RoleWindowLanguage.Skill;
                Setting.text = LanguageConfig.LanguageItems[LanguageType.Chinese].RoleWindowLanguage.Setting;
                DuanZao.text = LanguageConfig.LanguageItems[LanguageType.Chinese].RoleWindowLanguage.DuanZao;
                StartGame.text = LanguageConfig.LanguageItems[LanguageType.Chinese].RoleWindowLanguage.StartGame;
                break;
            case LanguageType.English:
                TuJian.characterSpacing = 0;
                Weapon.characterSpacing = 0;
                Bag.characterSpacing = 0;
                ChiBang.characterSpacing = 0;
                Skill.characterSpacing =0;
                Setting.characterSpacing = 0;
                DuanZao.characterSpacing = 0;
                StartGame.characterSpacing =0;
                
                TuJian.text = LanguageConfig.LanguageItems[LanguageType.English].RoleWindowLanguage.TuJian;
                Weapon.text = LanguageConfig.LanguageItems[LanguageType.English].RoleWindowLanguage.WuQi;
                Bag.text = LanguageConfig.LanguageItems[LanguageType.English].RoleWindowLanguage.Bag;
                ChiBang.text = LanguageConfig.LanguageItems[LanguageType.English].RoleWindowLanguage.ChiBang;
                Skill.text = LanguageConfig.LanguageItems[LanguageType.English].RoleWindowLanguage.Skill;
                Setting.text = LanguageConfig.LanguageItems[LanguageType.English].RoleWindowLanguage.Setting;
                DuanZao.text = LanguageConfig.LanguageItems[LanguageType.English].RoleWindowLanguage.DuanZao;
                StartGame.text = LanguageConfig.LanguageItems[LanguageType.English].RoleWindowLanguage.StartGame;
                break;
            case LanguageType.Han:
                TuJian.characterSpacing = 20;
                Weapon.characterSpacing = 20;
                Bag.characterSpacing = 20;
                ChiBang.characterSpacing = 20;
                Skill.characterSpacing =20;
                Setting.characterSpacing = 20;
                DuanZao.characterSpacing = 20;
                StartGame.characterSpacing =20;
                
                TuJian.text = LanguageConfig.LanguageItems[LanguageType.Han].RoleWindowLanguage.TuJian;
                Weapon.text = LanguageConfig.LanguageItems[LanguageType.Han].RoleWindowLanguage.WuQi;
                Bag.text = LanguageConfig.LanguageItems[LanguageType.Han].RoleWindowLanguage.Bag;
                ChiBang.text = LanguageConfig.LanguageItems[LanguageType.Han].RoleWindowLanguage.ChiBang;
                Skill.text = LanguageConfig.LanguageItems[LanguageType.Han].RoleWindowLanguage.Skill;
                Setting.text = LanguageConfig.LanguageItems[LanguageType.Han].RoleWindowLanguage.Setting;
                DuanZao.text = LanguageConfig.LanguageItems[LanguageType.Han].RoleWindowLanguage.DuanZao;
                StartGame.text = LanguageConfig.LanguageItems[LanguageType.Han].RoleWindowLanguage.StartGame;
                break;
            case LanguageType.Ri:
                TuJian.characterSpacing = 20;
                Weapon.characterSpacing = 20;
                Bag.characterSpacing = 20;
                ChiBang.characterSpacing = 20;
                Skill.characterSpacing =20;
                Setting.characterSpacing = 20;
                DuanZao.characterSpacing = 20;
                StartGame.characterSpacing =20;
                
                TuJian.text = LanguageConfig.LanguageItems[LanguageType.Ri].RoleWindowLanguage.TuJian;
                Weapon.text = LanguageConfig.LanguageItems[LanguageType.Ri].RoleWindowLanguage.WuQi;
                Bag.text = LanguageConfig.LanguageItems[LanguageType.Ri].RoleWindowLanguage.Bag;
                ChiBang.text = LanguageConfig.LanguageItems[LanguageType.Ri].RoleWindowLanguage.ChiBang;
                Skill.text = LanguageConfig.LanguageItems[LanguageType.Ri].RoleWindowLanguage.Skill;
                Setting.text = LanguageConfig.LanguageItems[LanguageType.Ri].RoleWindowLanguage.Setting;
                DuanZao.text = LanguageConfig.LanguageItems[LanguageType.Ri].RoleWindowLanguage.DuanZao;
                StartGame.text = LanguageConfig.LanguageItems[LanguageType.Ri].RoleWindowLanguage.StartGame;
                break;
        }
    }
    
    

    public void UpdateRoleWindow()
    {
        ShowChiBang();
        yuanLinText.text = GlobalPlayerAttribute.BloodEnergy.ToString();// 元灵数量text
        levelText.text= GlobalPlayerAttribute.Level.ToString();
        expSlider.maxValue=GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level];
        expSlider.value=GlobalPlayerAttribute.Exp ;
    }

    public void ShowChiBang()
    {
        whiteChiBang.gameObject.SetActive(false);
        greenChiBang.gameObject.SetActive(false);
        blueChiBang.gameObject.SetActive(false);
        purpleChiBang.gameObject.SetActive(false);
        orangeChiBang.gameObject.SetActive(false);
        redChiBang.gameObject.SetActive(false);

        switch (PlayerData.S.ChiBangLevel)
        {
            case 1:
                whiteChiBang.gameObject.SetActive(true);
                whiteChiBang.Play("ChiBangWhite");
                break;
            case 2:
                greenChiBang.gameObject.SetActive(true);
                greenChiBang.Play("ChiBangGreen");
                break;
            case 3:
                blueChiBang.gameObject.SetActive(true);
                blueChiBang.Play("ChiBangBlue");
                break;
            case 4:
                purpleChiBang.gameObject.SetActive(true);
                purpleChiBang.Play("ChiBangPurple");
                break;
            case 5:
                orangeChiBang.gameObject.SetActive(true);
                orangeChiBang.Play("ChiBangOrange");
                break;
            case 6:
                redChiBang.gameObject.SetActive(true);
                redChiBang.Play("ChiBangRed");
                break;
        }
    }

    private void OnEnable()
    {
        UpdateRoleWindow();
        SwitchLanguage(PlayerData.S.langType);
    }

    public void RefreshChiBang(object[] obj)
    {
        UpdateRoleWindow();
    }

    public void SwitchLanguageObj(object[] obj)
    {
        LanguageType langType = (LanguageType)obj[0];
        SwitchLanguage(langType);
    }
    
    
    private void Start()
    {
        Debug.Log("点击进入角色界面");
        InitEquip();
        chongwuButton.onClick.AddListener(() =>
        {
            WindowController.S.ChongWuWindow.gameObject.SetActive(true);
        });
        debugChongWu.onClick.AddListener(() =>
        {
            var data3 = new PropTable()
            {
                PropType =  PropConfig.PropType.ChongWuDan,
                Quality = 3,
                Desc = "",
                Count =  100,
                EquipName = "NormalChongWuDan",
            };
            if (BagController.S.PropList.ContainsKey(1603))
            {
                BagController.S.PropList[1603].Count+=data3.Count;
            }
            else
            {
                BagController.S.PropList.Add(1603,data3);
            }
            
            
            var data5 = new PropTable()
            {
                PropType =  PropConfig.PropType.ChongWuDan,
                Quality = 5,
                Desc = "",
                Count =  100,
                EquipName = "GaoJiChongWuDan",
            };
            if (BagController.S.PropList.ContainsKey(1605))
            {
                BagController.S.PropList[1605].Count+=data5.Count;
            }
            else
            {
                BagController.S.PropList.Add(1605,data5);
            }

            PlayerData.S.ChongWuShiWu1 += 10;
            PlayerData.S.ChongWuShiWu2 += 10;
            PlayerData.S.ChongWuShiWu3 += 10;
            PlayerData.S.ChongWuShiWu4 += 10;
            PlayerData.S.ChongWuShiWu5 += 10;
            PlayerData.S.ChongWuShiWu6 += 10;
            
            var XiSuiYeData3 = new PropTable()
            {
                PropType =  PropConfig.PropType.XiSuiYe,
                Quality = 3,
                Desc = "",
                Count =  100,
                EquipName = "NormalXiSuiYe",
            };
            if (BagController.S.PropList.ContainsKey(1703))
            {
                BagController.S.PropList[1703].Count+=XiSuiYeData3.Count;
            }
            else
            {
                BagController.S.PropList.Add(1703,XiSuiYeData3);
            }
            
            var XiSuiYeData5 = new PropTable()
            {
                PropType =  PropConfig.PropType.XiSuiYe,
                Quality = 5,
                Desc = "",
                Count =  100,
                EquipName = "GaoJiXiSuiYe",
            };
            if (BagController.S.PropList.ContainsKey(1705))
            {
                BagController.S.PropList[1705].Count+=XiSuiYeData5.Count;
            }
            else
            {
                BagController.S.PropList.Add(1705,XiSuiYeData5);
            }
            
            
            var XueMaiDanData3 = new PropTable()
            {
                PropType =  PropConfig.PropType.XueMaiDan,
                Quality = 3,
                Desc = "",
                Count =  100,
                EquipName = "NormalXueMaiDan",
            };
            if (BagController.S.PropList.ContainsKey(1803))
            {
                BagController.S.PropList[1803].Count+=XueMaiDanData3.Count;
            }
            else
            {
                BagController.S.PropList.Add(1803,XueMaiDanData3);
            }
            
            var XueMaiDanData5 = new PropTable()
            {
                PropType =  PropConfig.PropType.XueMaiDan,
                Quality = 5,
                Desc = "",
                Count =  100,
                EquipName = "GaoJiXueMaiDan",
            };
            if (BagController.S.PropList.ContainsKey(1805))
            {
                BagController.S.PropList[1805].Count+=XueMaiDanData5.Count;
            }
            else
            {
                BagController.S.PropList.Add(1805,XueMaiDanData5);
            }

        });
        TitleButton.onClick.AddListener(() =>
        {
            WindowController.S.TitleWindow.gameObject.SetActive(true);
        });
        ObserverModuleManager.S.RegisterEvent(ConstKeys.SwitchLanguage,SwitchLanguageObj);
        debugBaoshi.onClick.AddListener(() =>
        {
           BagController.S.BaoShiDebug();
        });
        settingButton.onClick.AddListener(() =>
        {
            WindowController.S.SettingWindow.SetActive(true);
        });
        ObserverModuleManager.S.RegisterEvent("ChiBang",RefreshChiBang);

        GlobalPlayerAttribute.RefreshFuJiaAttribute();

        debugPlayerLevel.onClick.AddListener(() =>
        {
            {
                GlobalPlayerAttribute.Level++;
                StoreController.S.SaveStoreData();
            }
        });
        
        BagController.S.IsInit = true;
        chibangButton.onClick.AddListener(() =>
        {
            Instantiate(Resources.Load("Prefabs/Window/ChiBangWindow"));
        });
        debugLingHun.onClick.AddListener(() =>
        {
            GlobalPlayerAttribute.BloodEnergy += 100000;
            StoreController.S.SaveStoreData();
        });
        debugSkillCount.onClick.AddListener(()=>
        {
            SkillJiaDian.S.CurrentSkillCount += 10;
            StoreController.S.SaveStoreData();
        });
        
        debugJingCui.onClick.AddListener(() =>
        {
            BagController.S.JingCuiDebug();
        });
        
        debugWeaponFragment.onClick.AddListener(() =>
        {
            BagController.S.WeaponFragmentDebug();
        });
        
        duanzaoButton.onClick.AddListener(() =>
        {
            GameObject duanzao=Instantiate(Resources.Load<GameObject>("Prefabs/Window/DuanZaoWindow"));
        });
        
        
        debugLevel.onClick.AddListener(() =>
        {
            GlobalPlayerAttribute.GameLevel = 100;
            StoreController.S.SaveStoreData();
        });
        
        monsterBookButton.onClick.AddListener(() =>
        {
            Debug.Log("点击进入怪物图鉴界面");
            WindowController.S.MonsterBookWindow.SetActive(true);
        });
        bagButton.onClick.AddListener(() =>
        {
            Debug.Log("开始执行ShowBag方法");
        
            // 检查背包对象是否为空
            if (BagController.S.bag == null)
            {
                Debug.LogError("ShowBag出错: bag对象为null，尝试重新初始化背包");
                BagController.S.InitBag();
            
                // 再次检查背包对象
                if (BagController.S.bag == null)
                {
                    Debug.LogError("ShowBag出错: 重新初始化背包后bag仍为null，无法显示背包");
                    return;
                }
            }
        
            // 检查装备列表是否为空
            if (BagController.S.EquipIdList == null)
            {
                Debug.LogWarning("ShowBag警告: EquipIdList为null，初始化为空列表");
                BagController.S.EquipIdList = new Dictionary<int, EquipTable>();
            }
        
            Debug.Log($"暂停游戏，当前EquipIdList中有 {BagController.S.EquipIdList.Count} 件装备");
        
            // 暂停游戏
            BagController.S.bag.gameObject.SetActive(true);
        
            
            Debug.Log("调用ShowEquip方法显示装备");
            BagController.S.ShowEquip();
            BagController.S.RefreshPlayerEquip();
            BagController.S.SetE();
        
            Debug.Log("ShowBag方法执行完成");
        });
        weaponButton.onClick.AddListener(() =>
        {
            Debug.Log("点击进入武器界面");
            WindowController.S.WeaponWindow.SetActive(true);
            gameObject.SetActive(false);
        });
        startButton.onClick.AddListener(() =>
        {
            Debug.Log("点击进入关卡界面");
            WindowController.S.GameLevelWindow.SetActive(true);
            gameObject.SetActive(false);
        });
        taskButton.onClick.AddListener(() =>
        {
            Debug.Log("点击进入任务界面");
            WindowController.S.TaskWindow.SetActive(true);
            gameObject.SetActive(false);
        });
        skillButton.onClick.AddListener(() =>
        {
            Debug.Log("点击进入技能界面");
            WindowController.S.SkillWindow.SetActive(true);
            gameObject.SetActive(false);
        });
        
    }
    
    public void InitEquip()
    {
        if (BagController.S.IsInit)
            return;
        BagController.S.InitEquipidSpriteConfig();
    }
}
