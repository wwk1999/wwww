using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Mysql;
using Spine.Unity;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FightBGController : XSingleton<FightBGController>
{
    [NonSerialized]public Button normalAttackButton;//普通攻击按钮
    [NonSerialized]public Button FightStopButton;//战斗暂停按钮
    [NonSerialized]public Button dashButton;
    [NonSerialized]public Button rageButton;
    [NonSerialized]public Button shieldButton;
    [NonSerialized]public Button iceArrowButton;
    [NonSerialized]public Button iceExButton;
    [NonSerialized]public Button iceBallButton;
    [NonSerialized] public Image IceExYellowCd;
    [NonSerialized] public Image IceBallYellowCd;
    [NonSerialized] public Image IceArrowYellowCd;
    [NonSerialized]public Slider playerHpSlider;
    [NonSerialized]public Slider playerExSlider;
    [NonSerialized]public Text playerLevelText;

    [NonSerialized]public TextMeshProUGUI GameMaxHp;
    [NonSerialized]public TextMeshProUGUI GameCurrentHp;
    
    
    
    [NonSerialized]public Button WeaponButton;
    [NonSerialized]public GameObject CircleAttack;
    [NonSerialized] public GameObject DiLie;
    [NonSerialized]public Queue<TreeManFire> TreeManFireQueue = new Queue<TreeManFire>();
    [NonSerialized]public Queue<CircleAttack> CircleAttackQueue = new Queue<CircleAttack>();
    [NonSerialized]public Queue<SqrtAttack> SqrtAttackQueue = new Queue<SqrtAttack>();
    [NonSerialized]public Queue<SpiderWeb> SpiderWebQueue = new Queue<SpiderWeb>();
    [NonSerialized]public Queue<PlayerHit> PlayerHitQueue = new Queue<PlayerHit>();
    [NonSerialized] public Queue<GameObject> PrimaryNormalAttackExQueue = new Queue<GameObject>();//初始武器普通攻击爆炸队列





    [NonSerialized] public bool HaveCircleAttack = false;
    [NonSerialized] public Slider BossEnergySlider;
    [NonSerialized] public bool IsBossJiHuo = false;


    private float RefreshEx = 0.5f;
    private float currentExTime = 0;
    private float RefreshHp = 0.1f;
    private float currentHpTime = 0;

    private float ReplyHpTime = 3f;
    private float currentReplyHpTime = 0;
    
    public bool isShowAgain = false;
    
    
    public void GetMJJiangLi()
    {
        var jiangli=MJConfig.JiangLiDic[PlayerData.S.mJLevel];
        GlobalPlayerAttribute.Exp+=jiangli.ex;
        while (GlobalPlayerAttribute.Exp > GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level])
        {
            //升级
            SkillJiaDian.S.CurrentSkillCount++;
            ObserverModuleManager.S.SendEvent(ConstKeys.LevelUpAnim);
            GameController.S.gamePlayer.LevelUp.SetActive(true);
            GameController.S.gamePlayer.LevelUpParticle.Play();
            GlobalPlayerAttribute.Level++;
            ObserverModuleManager.S.SendEvent("ShenJi");
            playerLevelText.text =  GlobalPlayerAttribute.Level.ToString();
            GlobalPlayerAttribute.Exp=GlobalPlayerAttribute.Exp-GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level-1];

            if (GlobalPlayerAttribute.Level == 5)
            {
                PlayerData.S.Level5 = true;
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"解锁新称号");
            }
            
            if (GlobalPlayerAttribute.Level == 15)
            {
                PlayerData.S.Level15 = true;
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"解锁新称号");
            }
            
            if (GlobalPlayerAttribute.Level == 30)
            {
                PlayerData.S.Level30 = true;
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"解锁新称号");
            }
            
            if (GlobalPlayerAttribute.Level == 50)
            {
                PlayerData.S.Level50 = true;
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"解锁新称号");
            }
            
            if (GlobalPlayerAttribute.Level == 75)
            {
                PlayerData.S.Level75 = true;
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"解锁新称号");
            }
            
            if (GlobalPlayerAttribute.Level == 100)
            {
                PlayerData.S.Level100 = true;
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"解锁新称号");
            }
        }
        playerExSlider.maxValue=GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level];
        playerExSlider.value=GlobalPlayerAttribute.Exp ;
        GlobalPlayerAttribute.BloodEnergy += jiangli.linhun;
        if (BagController.S.PropList.ContainsKey(205))
        {
            BagController.S.PropList[205].Count += jiangli.jingcui;
        }
        else
        {
            BagController.S.PropList.Add(205,new PropTable(){PropType = PropConfig.PropType.JingCui,Count = jiangli.jingcui,Desc = "",EquipName = "OrangeJingCui",Quality = 5});
        }

        PlayerData.S.zhuanjinCount += jiangli.zhuanjin;
        var MJtoast=Instantiate(Resources.Load<GameObject>("Prefabs/Window/MJToast"));
        
        StoreController.S.SaveStoreData();
    }

    private void Update()
    {
        currentHpTime+=Time.deltaTime;
        currentExTime += Time.deltaTime;
        currentReplyHpTime+=Time.deltaTime;
        if (currentReplyHpTime > ReplyHpTime)
        {
            currentReplyHpTime = 0;
            float replyHp = GameController.S.GameMaxHp * GlobalPlayerAttribute.ReplyHpPercent/100f;
            GlobalPlayerAttribute.ReplyHp(replyHp);
        }
        
        if (currentHpTime > RefreshHp)
        {
            currentHpTime = 0;
            SetHp();
        }
        
        //战斗场景固定存档刷新
        if (currentExTime > RefreshEx)
        {
            currentExTime = 0;
            if(GlobalPlayerAttribute.Exp>GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level])
            {
                //升级
                SkillJiaDian.S.CurrentSkillCount++;
                ObserverModuleManager.S.SendEvent(ConstKeys.LevelUpAnim);
                GameController.S.gamePlayer.LevelUp.SetActive(true);
                GameController.S.gamePlayer.LevelUpParticle.Play();
                GlobalPlayerAttribute.Level++;
                ObserverModuleManager.S.SendEvent("ShenJi");
                playerLevelText.text =  GlobalPlayerAttribute.Level.ToString();
                GlobalPlayerAttribute.Exp=GlobalPlayerAttribute.Exp-GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level-1];

                if (PlayerData.S.Level5 == false&&GlobalPlayerAttribute.Level>=5)
                {
                    PlayerData.S.Level5 = true;
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"解锁新称号");
                }
                
                if (PlayerData.S.Level15 == false&&GlobalPlayerAttribute.Level>=15)
                {
                    PlayerData.S.Level15 = true;
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"解锁新称号");
                }
                
                if (PlayerData.S.Level30 == false&&GlobalPlayerAttribute.Level>=30)
                {
                    PlayerData.S.Level30 = true;
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"解锁新称号");
                }
                
                if (PlayerData.S.Level50 == false&&GlobalPlayerAttribute.Level>=50)
                {
                    PlayerData.S.Level50 = true;
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"解锁新称号");
                }
                
                if (PlayerData.S.Level75 == false&&GlobalPlayerAttribute.Level>=75)
                {
                    PlayerData.S.Level75 = true;
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"解锁新称号");
                }
                
                if (PlayerData.S.Level100 == false&&GlobalPlayerAttribute.Level>=100)
                {
                    PlayerData.S.Level100 = true;
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"解锁新称号");
                }
                
            }
            playerExSlider.maxValue=GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level];
            playerExSlider.value=GlobalPlayerAttribute.Exp ;
            AddHunQiLevel();
            if (PlayerData.S.MonsterCount > 100)
            {
                if (PlayerData.S.MonsterCount1 == false)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
                }
                PlayerData.S.MonsterCount1 = true;
            }
            
            if (PlayerData.S.MonsterCount > 500)
            {
                if (PlayerData.S.MonsterCount2 == false)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
                }
                PlayerData.S.MonsterCount2 = true;
            }
            
            if (PlayerData.S.MonsterCount > 2000)
            {
                if (PlayerData.S.MonsterCount3 == false)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
                }
                PlayerData.S.MonsterCount3 = true;
            }
            
            
            if (PlayerData.S.MonsterCount > 5000)
            {
                if (PlayerData.S.MonsterCount4 == false)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
                }
                PlayerData.S.MonsterCount4 = true;
            }
            
            
            if (PlayerData.S.MonsterCount > 10000)
            {
                if (PlayerData.S.MonsterCount5 == false)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
                }
                PlayerData.S.MonsterCount5 = true;
            }
            
            
            if (PlayerData.S.MonsterCount > 20000)
            {
                if (PlayerData.S.MonsterCount6 == false)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
                }
                PlayerData.S.MonsterCount6 = true;
            }

            if (PlayerData.S.LinHun >= 100000)
            {
                if (PlayerData.S.LingHun == false)
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
                }
                PlayerData.S.LingHun = true;
            }
            StoreController.S.SaveStoreData();
        }
    }

    public void AddHunQiLevel()
    {
        switch (PlayerData.S.playerWeaponType)
        {
            case WeaponType.Primary:
                switch (PlayerData.S.primaryHunQiLevel)
                {
                    case 0:
                        if (PlayerData.S.primaryHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Primary].Level1)
                        {
                            PlayerData.S.primaryHunQiLevel++;
                            PlayerData.S.primaryHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Primary].Level1;
                        }
                        break;
                    case 1:
                        if (PlayerData.S.primaryHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Primary].Level2)
                        {
                            PlayerData.S.primaryHunQiLevel++;
                            PlayerData.S.primaryHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Primary].Level2;
                        }
                        break;
                    case 2:
                        if (PlayerData.S.primaryHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Primary].Level3)
                        {
                            PlayerData.S.primaryHunQiLevel++;
                            PlayerData.S.primaryHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Primary].Level3;
                        }
                        break;
                    case 3:
                        if (PlayerData.S.primaryHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Primary].Level4)
                        {
                            PlayerData.S.primaryHunQiLevel++;
                            PlayerData.S.primaryHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Primary].Level4;
                        }
                        break;
                    case 4:
                        if (PlayerData.S.primaryHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Primary].Level5)
                        {
                            PlayerData.S.primaryHunQiLevel++;
                            PlayerData.S.primaryHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Primary].Level5;
                            PlayerData.S.HunQiCount++;
                        }
                        break;
                }
                break;
            
            
             case WeaponType.Du:
                switch (PlayerData.S.duHunQiLevel)
                {
                    case 0:
                        if (PlayerData.S.duHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Du].Level1)
                        {
                            PlayerData.S.duHunQiLevel++;
                            PlayerData.S.duHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Du].Level1;
                        }
                        break;
                    case 1:
                        if (PlayerData.S.duHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Du].Level2)
                        {
                            PlayerData.S.duHunQiLevel++;
                            PlayerData.S.duHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Du].Level2;
                        }
                        break;
                    case 2:
                        if (PlayerData.S.duHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Du].Level3)
                        {
                            PlayerData.S.duHunQiLevel++;
                            PlayerData.S.duHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Du].Level3;
                        }
                        break;
                    case 3:
                        if (PlayerData.S.duHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Du].Level4)
                        {
                            PlayerData.S.duHunQiLevel++;
                            PlayerData.S.duHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Du].Level4;
                        }
                        break;
                    case 4:
                        if (PlayerData.S.duHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Du].Level5)
                        {
                            PlayerData.S.duHunQiLevel++;
                            PlayerData.S.duHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Du].Level5;
                            PlayerData.S.HunQiCount++;
                        }
                        break;
                }
                break;
             
             
              case WeaponType.PuTong3:
                switch (PlayerData.S.puTong3HunQiLevel)
                {
                    case 0:
                        if (PlayerData.S.puTong3HunQiEx >= WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level1)
                        {
                            PlayerData.S.puTong3HunQiLevel++;
                            PlayerData.S.puTong3HunQiEx -= WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level1;
                        }
                        break;
                    case 1:
                        if (PlayerData.S.puTong3HunQiEx >= WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level2)
                        {
                            PlayerData.S.puTong3HunQiLevel++;
                            PlayerData.S.puTong3HunQiEx -= WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level2;
                        }
                        break;
                    case 2:
                        if (PlayerData.S.puTong3HunQiEx >= WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level3)
                        {
                            PlayerData.S.puTong3HunQiLevel++;
                            PlayerData.S.puTong3HunQiEx -= WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level3;
                        }
                        break;
                    case 3:
                        if (PlayerData.S.puTong3HunQiEx >= WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level4)
                        {
                            PlayerData.S.puTong3HunQiLevel++;
                            PlayerData.S.puTong3HunQiEx -= WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level4;
                        }
                        break;
                    case 4:
                        if (PlayerData.S.puTong3HunQiEx >= WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level5)
                        {
                            PlayerData.S.puTong3HunQiLevel++;
                            PlayerData.S.puTong3HunQiEx -= WeaponConfig.HunQiExDic[WeaponType.PuTong3].Level5;
                            PlayerData.S.HunQiCount++;
                        }
                        break;
                }
                break;
              
              
               case WeaponType.XuKong:
                switch (PlayerData.S.xuKongHunQiLevel)
                {
                    case 0:
                        if (PlayerData.S.xuKongHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.XuKong].Level1)
                        {
                            PlayerData.S.xuKongHunQiLevel++;
                            PlayerData.S.xuKongHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.XuKong].Level1;
                        }
                        break;
                    case 1:
                        if (PlayerData.S.xuKongHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.XuKong].Level2)
                        {
                            PlayerData.S.xuKongHunQiLevel++;
                            PlayerData.S.xuKongHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.XuKong].Level2;
                        }
                        break;
                    case 2:
                        if (PlayerData.S.xuKongHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.XuKong].Level3)
                        {
                            PlayerData.S.xuKongHunQiLevel++;
                            PlayerData.S.xuKongHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.XuKong].Level3;
                        }
                        break;
                    case 3:
                        if (PlayerData.S.xuKongHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.XuKong].Level4)
                        {
                            PlayerData.S.xuKongHunQiLevel++;
                            PlayerData.S.xuKongHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.XuKong].Level4;
                        }
                        break;
                    case 4:
                        if (PlayerData.S.xuKongHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.XuKong].Level5)
                        {
                            PlayerData.S.xuKongHunQiLevel++;
                            PlayerData.S.xuKongHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.XuKong].Level5;
                            PlayerData.S.HunQiCount++;
                        }
                        break;
                }
                break;
               
               
               
                case WeaponType.Fire:
                switch (PlayerData.S.fireHunQiLevel)
                {
                    case 0:
                        if (PlayerData.S.fireHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Fire].Level1)
                        {
                            PlayerData.S.fireHunQiLevel++;
                            PlayerData.S.fireHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Fire].Level1;
                        }
                        break;
                    case 1:
                        if (PlayerData.S.fireHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Fire].Level2)
                        {
                            PlayerData.S.fireHunQiLevel++;
                            PlayerData.S.fireHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Fire].Level2;
                        }
                        break;
                    case 2:
                        if (PlayerData.S.fireHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Fire].Level3)
                        {
                            PlayerData.S.fireHunQiLevel++;
                            PlayerData.S.fireHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Fire].Level3;
                        }
                        break;
                    case 3:
                        if (PlayerData.S.fireHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Fire].Level4)
                        {
                            PlayerData.S.fireHunQiLevel++;
                            PlayerData.S.fireHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Fire].Level4;
                        }
                        break;
                    case 4:
                        if (PlayerData.S.fireHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.Fire].Level5)
                        {
                            PlayerData.S.fireHunQiLevel++;
                            PlayerData.S.fireHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.Fire].Level5;
                            PlayerData.S.HunQiCount++;
                        }
                        break;
                }
                break;
                
                
                
                
                 case WeaponType.LvQuan:
                switch (PlayerData.S.lvQuanHunQiLevel)
                {
                    case 0:
                        if (PlayerData.S.lvQuanHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level1)
                        {
                            PlayerData.S.lvQuanHunQiLevel++;
                            PlayerData.S.lvQuanHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level1;
                        }
                        break;
                    case 1:
                        if (PlayerData.S.lvQuanHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level2)
                        {
                            PlayerData.S.lvQuanHunQiLevel++;
                            PlayerData.S.lvQuanHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level2;
                        }
                        break;
                    case 2:
                        if (PlayerData.S.lvQuanHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level3)
                        {
                            PlayerData.S.lvQuanHunQiLevel++;
                            PlayerData.S.lvQuanHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level3;
                        }
                        break;
                    case 3:
                        if (PlayerData.S.lvQuanHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level4)
                        {
                            PlayerData.S.lvQuanHunQiLevel++;
                            PlayerData.S.lvQuanHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level4;
                        }
                        break;
                    case 4:
                        if (PlayerData.S.lvQuanHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level5)
                        {
                            PlayerData.S.lvQuanHunQiLevel++;
                            PlayerData.S.lvQuanHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.LvQuan].Level5;
                            PlayerData.S.HunQiCount++;

                        }
                        break;
                }
                break;
                 
                 
                 
                 
                  case WeaponType.HeiDong:
                switch (PlayerData.S.heiDongHunQiLevel)
                {
                    case 0:
                        if (PlayerData.S.heiDongHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level1)
                        {
                            PlayerData.S.heiDongHunQiLevel++;
                            PlayerData.S.heiDongHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level1;
                        }
                        break;
                    case 1:
                        if (PlayerData.S.heiDongHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level2)
                        {
                            PlayerData.S.heiDongHunQiLevel++;
                            PlayerData.S.heiDongHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level2;
                        }
                        break;
                    case 2:
                        if (PlayerData.S.heiDongHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level3)
                        {
                            PlayerData.S.heiDongHunQiLevel++;
                            PlayerData.S.heiDongHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level3;
                        }
                        break;
                    case 3:
                        if (PlayerData.S.heiDongHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level4)
                        {
                            PlayerData.S.heiDongHunQiLevel++;
                            PlayerData.S.heiDongHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level4;
                        }
                        break;
                    case 4:
                        if (PlayerData.S.heiDongHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level5)
                        {
                            PlayerData.S.heiDongHunQiLevel++;
                            PlayerData.S.heiDongHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.HeiDong].Level5;
                            PlayerData.S.HunQiCount++;

                        }
                        break;
                }
                break;
                  
                  
                  
                  
                  
                   case WeaponType.JianQi:
                switch (PlayerData.S.jianQiHunQiLevel)
                {
                    case 0:
                        if (PlayerData.S.jianQiHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.JianQi].Level1)
                        {
                            PlayerData.S.jianQiHunQiLevel++;
                            PlayerData.S.jianQiHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.JianQi].Level1;
                        }
                        break;
                    case 1:
                        if (PlayerData.S.jianQiHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.JianQi].Level2)
                        {
                            PlayerData.S.jianQiHunQiLevel++;
                            PlayerData.S.jianQiHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.JianQi].Level2;
                        }
                        break;
                    case 2:
                        if (PlayerData.S.jianQiHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.JianQi].Level3)
                        {
                            PlayerData.S.jianQiHunQiLevel++;
                            PlayerData.S.jianQiHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.JianQi].Level3;
                        }
                        break;
                    case 3:
                        if (PlayerData.S.jianQiHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.JianQi].Level4)
                        {
                            PlayerData.S.jianQiHunQiLevel++;
                            PlayerData.S.jianQiHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.JianQi].Level4;
                        }
                        break;
                    case 4:
                        if (PlayerData.S.jianQiHunQiEx >= WeaponConfig.HunQiExDic[WeaponType.JianQi].Level5)
                        {
                            PlayerData.S.jianQiHunQiLevel++;
                            PlayerData.S.jianQiHunQiEx -= WeaponConfig.HunQiExDic[WeaponType.JianQi].Level5;
                            PlayerData.S.HunQiCount++;
                        }
                        break;
                }
                break;
        }
        if (PlayerData.S.HunQi3 ==false&&PlayerData.S.HunQiCount>=1)
        {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
            PlayerData.S.HunQi3 = true;
        }
        
        if (PlayerData.S.HunQi4 ==false&&PlayerData.S.HunQiCount>=3)
        {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
            PlayerData.S.HunQi4 = true;
        }
        
        if (PlayerData.S.HunQi5 ==false&&PlayerData.S.HunQiCount>=5)
        {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
            PlayerData.S.HunQi5 = true;
        }
    }

    public void SetHp()
    {
        
        if (GameController.S.GameCurrentHp < 0)
        {
            GameController.S.GameCurrentHp = 0f;
        }

        if (GameController.S.GameCurrentHp > GameController.S.GameMaxHp)
        {
            GameController.S.GameCurrentHp=GameController.S.GameMaxHp;
        }

        GameMaxHp.text = Mathf.RoundToInt(GameController.S.GameMaxHp).ToString();
        GameCurrentHp.text = Mathf.RoundToInt(GameController.S.GameCurrentHp).ToString();
        playerHpSlider.maxValue = GameController.S.GameMaxHp;
        playerHpSlider.value = GameController.S.GameCurrentHp;
    }

    public void CheckGuanKaTitle()
    {
        if (PlayerData.S.GuanKa3 == false)
        {
            if (LevelInfoConfig.CurrentGameLevel == 9)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
                PlayerData.S.GuanKa3 = true;
            }
        }
        
        if (PlayerData.S.GuanKa4 == false)
        {
            if (LevelInfoConfig.CurrentGameLevel == 15)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
                PlayerData.S.GuanKa4 = true;
            }
        }
        
        if (PlayerData.S.GuanKa5 == false)
        {
            if (LevelInfoConfig.CurrentGameLevel == 16&&PlayerData.S.mJLevel==MJLevel.Red1)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
                PlayerData.S.GuanKa5 = true;
            }
        }
    }

    
    //胜利动画
    public void PlaySuccessAnim()
    {
        var success= Instantiate(Resources.Load<GameObject>("Prefabs/Success/Success"),transform);
        SkeletonGraphic skeletonGraphic= success.transform.Find("Canvas/Content").GetComponent<SkeletonGraphic>();
        var skAnim = skeletonGraphic.GetComponent<SkeletonAnimation>();
        if (skAnim != null) {
            skAnim.AnimationName = "bui_9_1";
        }

        LevelInfoConfig.FaBaoShi();

        CheckGuanKaTitle();
        
        StartCoroutine(DelayPlaySuccessAnim(skeletonGraphic));
        if (LevelInfoConfig.CurrentGameLevel + 3 > LevelInfoConfig.MaxGameLevel)
        {
            LevelInfoConfig.MaxGameLevel= LevelInfoConfig.CurrentGameLevel + 3;
            StoreController.S.SaveStoreData();
        }

        if (LevelInfoConfig.CurrentGameLevel >15)
        {
            StartCoroutine(DelayGetMJjiangli());
        }

        StartCoroutine(DelayDisable(success));
    }

    IEnumerator DelayGetMJjiangli()
    {
        yield return new WaitForSeconds(1f);
        GetMJJiangLi();
    }
    IEnumerator DelayPlaySuccessAnim(SkeletonGraphic skeletonGraphic)
    {
        yield return new WaitForSeconds(1.67f);
        var skAnim = skeletonGraphic.GetComponent<SkeletonAnimation>();
        if (skAnim != null) {
            skAnim.AnimationName = "bui_9_2";
        }
    }
    
    IEnumerator DelayDisable(GameObject obj)
    {
        yield return new WaitForSeconds(5f);
        Destroy(obj);
    }
    
}