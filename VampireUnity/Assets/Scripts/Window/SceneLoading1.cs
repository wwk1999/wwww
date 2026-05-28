using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;

public class SceneLoading1 : MonoBehaviour
{
    public Image bg;
    public Slider loadSlider;
    public SkeletonAnimation Ske;

    void Start()
    {
        bg.sprite = ResourcesConfig.GetLoadingBg();
        GlobalPlayerAttribute.IsGame = true;
        Ske.AnimationState.SetAnimation(0, "loading", true);
        StartCoroutine(LoadAndPreload());
    }

    public IEnumerator PreloadAllPools()
    {
        if (QueueController.S.fightBG == null)
        {
            QueueController.S.fightBG = Instantiate(Resources.Load<GameObject>("Prefabs/Window/FightBG"),
                QueueController.S.transform);
            QueueController.S.fightBG.transform.position = new Vector3(0, 0, 0.1f);
        }

        //赋值
        FightBGController.S.WeaponButton = QueueController.S.fightBG.GetComponent<FightBg>().weaponButton;
        FightBGController.S.normalAttackButton = QueueController.S.fightBG.GetComponent<FightBg>().normalAttackButton;
        FightBGController.S.FightStopButton = QueueController.S.fightBG.GetComponent<FightBg>().fightStopButton;
        FightBGController.S.dashButton = QueueController.S.fightBG.GetComponent<FightBg>().dashButton;
        FightBGController.S.rageButton = QueueController.S.fightBG.GetComponent<FightBg>().rageButton;
        FightBGController.S.shieldButton = QueueController.S.fightBG.GetComponent<FightBg>().shieldButton;
        FightBGController.S.iceArrowButton = QueueController.S.fightBG.GetComponent<FightBg>().iceArrowButton;
        FightBGController.S.iceExButton = QueueController.S.fightBG.GetComponent<FightBg>().iceExButton;
        FightBGController.S.iceBallButton = QueueController.S.fightBG.GetComponent<FightBg>().iceBallButton;
        FightBGController.S.IceExYellowCd = QueueController.S.fightBG.GetComponent<FightBg>().iceExYellowCd;
        FightBGController.S.IceBallYellowCd = QueueController.S.fightBG.GetComponent<FightBg>().iceBallYellowCd;
        FightBGController.S.IceArrowYellowCd = QueueController.S.fightBG.GetComponent<FightBg>().iceArrowYellowCd;
        FightBGController.S.BossEnergySlider = QueueController.S.fightBG.GetComponent<FightBg>().bossEnergySlider;


        FightBGController.S.playerHpSlider = QueueController.S.fightBG.GetComponent<FightBg>().playerHpSlider;
        FightBGController.S.playerExSlider = QueueController.S.fightBG.GetComponent<FightBg>().playerExSlider;
        FightBGController.S.playerLevelText = QueueController.S.fightBG.GetComponent<FightBg>().playerLevelText;
        FightBGController.S.GameMaxHp = QueueController.S.fightBG.GetComponent<FightBg>().GameMaxHp;
        FightBGController.S.GameCurrentHp = QueueController.S.fightBG.GetComponent<FightBg>().GameCurrentHp;
        
        GameController.S.monsterHpSliderPrefabs = Resources.Load<GameObject>("Prefabs/Tool/MonsterHPBloodBar");
        yield return LevelInfoConfig.InitMonsterQueueAsync();
        yield return LevelInfoConfig.InitPropQueueAsync();
        yield return LevelInfoConfig.InitEquipQueueAsync();
        yield return LevelInfoConfig.InitSkillAsync();
        yield return LevelInfoConfig.InitPlayerHurtAndToolsAsync();
        yield return LevelInfoConfig.InitMonsterHurtTextAsync();
        yield return LevelInfoConfig.InitNormalAttackPoolAsync();
        yield return LevelInfoConfig.InitPengEffectsAsync();
        yield return LevelInfoConfig.InitSpecialWeaponPoolsAsync();
        yield return LevelInfoConfig.InitBaoXueAndDanMuAsync();
        yield return InitEntranceAsync();
        EntranceAwake();
        GameController.S.CreatePlayer();
    }

    public static IEnumerator InitEntranceAsync(int perFrame = 10)
    {
        int count = 0;
        if (LevelInfoConfig.CurrentGameLevel == 16)
        {
            if (QueueController.S.LeiShouSkill3Queue.Count < 30)
            {
                for (int i = 0; i < 30; i++)
                {
                    var Monster1 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LeiShou/LeiShouSkill3")
                                .GetComponent<LeiShouSkill3>(),
                            QueueController.S.transform);
                    Monster1.gameObject.SetActive(false);
                    QueueController.S.LeiShouSkill3Queue.Enqueue(Monster1);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 17)
        {
            if (QueueController.S.HeiXuanFenQueue.Count < 30)
            {
                for (int i = 0; i < 30; i++)
                {
                    var Monster2 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/KuiJia/HeiXuanFen")
                                .GetComponent<HeiXuanFen>(),
                            QueueController.S.transform);
                    Monster2.gameObject.SetActive(false);
                    QueueController.S.HeiXuanFenQueue.Enqueue(Monster2);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 18)
        {
            if (QueueController.S.LvZhuiZongQueue.Count < 30)
            {
                for (int i = 0; i < 30; i++)
                {
                    var Monster3 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/BaoZi/LvZhuiZong")
                                .GetComponent<LvZhuiZong>(),
                            QueueController.S.transform);
                    Monster3.gameObject.SetActive(false);
                    QueueController.S.LvZhuiZongQueue.Enqueue(Monster3);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 18)
        {
            if (QueueController.S.LvXuanFenQueue.Count < 30)
            {

                for (int i = 0; i < 30; i++)
                {
                    var Monster4 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/BaoZi/LvXuanFen")
                                .GetComponent<LvXuanFen>(),
                            QueueController.S.transform);
                    Monster4.gameObject.SetActive(false);
                    QueueController.S.LvXuanFenQueue.Enqueue(Monster4);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 18)
        {
            if (QueueController.S.BaoZiSkill2Queue.Count < 30)
            {

                for (int i = 0; i < 30; i++)
                {

                    var Monster5 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/BaoZi/BaoZiSkill2")
                                .GetComponent<BaoZiSkill2>(),
                            QueueController.S.transform);
                    Monster5.gameObject.SetActive(false);
                    QueueController.S.BaoZiSkill2Queue.Enqueue(Monster5);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 19)
        {
            if (QueueController.S.HuoLangSkill2Queue.Count < 30)
            {

                for (int i = 0; i < 30; i++)
                {

                    var Monster6 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/HuoLang/HuoLangSkill2")
                                .GetComponent<HuoLangSkill2>(),
                            QueueController.S.transform);
                    Monster6.gameObject.SetActive(false);
                    QueueController.S.HuoLangSkill2Queue.Enqueue(Monster6);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 20)
        {
            if (QueueController.S.ShuangDaoSkill2Queue.Count < 30)
            {

                for (int i = 0; i < 30; i++)
                {

                    var Monster7 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/ShuangDao/ShuangDaoSkill2")
                                .GetComponent<ShuangDaoSkill2>(),
                            QueueController.S.transform);
                    Monster7.gameObject.SetActive(false);
                    QueueController.S.ShuangDaoSkill2Queue.Enqueue(Monster7);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 20)
        {
            if (QueueController.S.ShuangDaoSkill3Queue.Count < 30)
            {

                for (int i = 0; i < 30; i++)
                {
                    var Monster8 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/ShuangDao/ShuangDaoSkill3")
                                .GetComponent<ShuangDaoSkill3>(),
                            QueueController.S.transform);
                    Monster8.gameObject.SetActive(false);
                    QueueController.S.ShuangDaoSkill3Queue.Enqueue(Monster8);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
        }
        
        if (LevelInfoConfig.CurrentGameLevel == 21)
        {
            if (QueueController.S.HuoShouDiPenQueue.Count < 100)
            {

                for (int i = 0; i < 101; i++)
                {
                    var Monster8 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/HuoShou/HuoShouDiPen")
                                .GetComponent<HuoShouDiPen>(),
                            QueueController.S.transform);
                    Monster8.gameObject.SetActive(false);
                    QueueController.S.HuoShouDiPenQueue.Enqueue(Monster8);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
            
            
            if (QueueController.S.HuoShouDanQueue.Count < 5)
            {

                for (int i = 0; i < 5; i++)
                {
                    var Monster8 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/HuoShou/HuoShouDan")
                                .GetComponent<HuoShouDan>(),
                            QueueController.S.transform);
                    Monster8.gameObject.SetActive(false);
                    QueueController.S.HuoShouDanQueue.Enqueue(Monster8);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
            
            
            
            if (QueueController.S.HuoShouBaoZhaQueue.Count < 5)
            {

                for (int i = 0; i < 5; i++)
                {
                    var Monster8 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/HuoShou/HuoShouBaoZha")
                                .GetComponent<HuoShouBaoZha>(),
                            QueueController.S.transform);
                    Monster8.gameObject.SetActive(false);
                    QueueController.S.HuoShouBaoZhaQueue.Enqueue(Monster8);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
        }





        if (LevelInfoConfig.CurrentGameLevel == 22)
        {
            if (QueueController.S.DaEYuShuiPenQueue.Count < 100)
            {

                for (int i = 0; i < 101; i++)
                {
                    var Monster8 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/DaEYu/DaEYuShuiPen")
                                .GetComponent<DaEYuShuiPen>(),
                            QueueController.S.transform);
                    Monster8.gameObject.SetActive(false);
                    QueueController.S.DaEYuShuiPenQueue.Enqueue(Monster8);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
            
            
            
            if (QueueController.S.DaEYuDanXiaoQueue.Count < 10)
            {

                for (int i = 0; i < 10; i++)
                {
                    var Monster8 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/DaEYu/DaEYuDanXiao")
                                .GetComponent<DaEYuDanXiao>(),
                            QueueController.S.transform);
                    Monster8.gameObject.SetActive(false);
                    QueueController.S.DaEYuDanXiaoQueue.Enqueue(Monster8);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
            
            
            
            if (QueueController.S.DaEYuDanQueue.Count < 5)
            {

                for (int i = 0; i < 5; i++)
                {
                    var Monster8 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/DaEYu/DaEYuDan")
                                .GetComponent<DaEYuDan>(),
                            QueueController.S.transform);
                    Monster8.gameObject.SetActive(false);
                    QueueController.S.DaEYuDanQueue.Enqueue(Monster8);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
            
            
            
            if (QueueController.S.DaEYuBaoZhaQueue.Count < 5)
            {

                for (int i = 0; i < 5; i++)
                {
                    var Monster8 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/DaEYu/DaEYuBaoZha")
                                .GetComponent<DaEYuBaoZha>(),
                            QueueController.S.transform);
                    Monster8.gameObject.SetActive(false);
                    QueueController.S.DaEYuBaoZhaQueue.Enqueue(Monster8);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
        }


        //实例化


        for (int i = 0; i < 10; i++)
        {
            var circleAttack =
                Instantiate(Resources.Load("Prefabs/Tool/CircleAttack"), QueueController.S.transform) as GameObject;
            circleAttack.SetActive(false);
            FightBGController.S.CircleAttackQueue.Enqueue(circleAttack.GetComponent<CircleAttack>());
            var fire =
                Instantiate(Resources.Load("Prefabs/Skill/TreeManFire"), QueueController.S.transform) as GameObject;
            fire.SetActive(false);
            FightBGController.S.TreeManFireQueue.Enqueue(fire.GetComponent<TreeManFire>());
            var sqrtattack =
                Instantiate(Resources.Load("Prefabs/Tool/SqrtAttack"), QueueController.S.transform) as GameObject;
            sqrtattack.SetActive(false);
            FightBGController.S.SqrtAttackQueue.Enqueue(sqrtattack.GetComponent<SqrtAttack>());
            var playerhit =
                Instantiate(Resources.Load("Prefabs/Player/PlayerHit"), QueueController.S.transform) as GameObject;
            playerhit.SetActive(false);
            FightBGController.S.PlayerHitQueue.Enqueue(playerhit.GetComponent<PlayerHit>());
            yield return null;
        }




        //初始化技能队列



        FightBGController.S.DiLie = Instantiate(Resources.Load("Prefabs/Skill/BossGroundFissure"),
            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        FightBGController.S.DiLie.SetActive(false);

        FightBGController.S.CircleAttack =
            Instantiate(Resources.Load<GameObject>("Prefabs/Tool/CircleAttack")).gameObject;
        FightBGController.S.CircleAttack.SetActive(false);





        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 ||
            LevelInfoConfig.CurrentGameLevel == 3)
        {
            if (QueueController.S.TreeManDiLieQueue.Count < 5)
            {


                for (int i = 0; i < 5; i++)
                {
                    var DiLie = Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/DiLie").GetComponent<TreeManDiLie>(),
                        QueueController.S.transform);
                    DiLie.gameObject.SetActive(false);
                    QueueController.S.TreeManDiLieQueue.Enqueue(DiLie.GetComponent<TreeManDiLie>());
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 3)
        {
            if (QueueController.S.TreeManSkillQueue.Count < 50)
            {
                for (int i = 0; i < 50; i++)
                {
                    var treemanSkill =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level1/TreeManSkill")
                                .GetComponent<TreeManSkill>(),
                            QueueController.S.transform);
                    treemanSkill.gameObject.SetActive(false);
                    QueueController.S.TreeManSkillQueue.Enqueue(treemanSkill.GetComponent<TreeManSkill>());
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 6)
        {
            for (int i = 0; i < 3; i++)
            {
                var jianqi =
                    Instantiate(Resources.Load<HuoShanJianQi>("Prefabs/Monster/Level2/HuoShanJianQi"),
                        QueueController.S.transform);
                jianqi.gameObject.SetActive(false);
                QueueController.S.HuoShanJianQiQueue.Enqueue(jianqi);
            }

            if (QueueController.S.HuoShanSkill2QiQueue.Count < 51)
            {
                for (int i = 0; i < 51; i++)
                {
                    var huoshanskill2 =
                        Instantiate(Resources.Load<HuoShanSkill2>("Prefabs/Monster/Level2/HuoShanSkill2"),
                            QueueController.S.transform);
                    huoshanskill2.gameObject.SetActive(false);
                    QueueController.S.HuoShanSkill2QiQueue.Enqueue(huoshanskill2);
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }

        }


        if (LevelInfoConfig.CurrentGameLevel == 9)
        {
            for (int i = 0; i < 10; i++)
            {
                var zhaozeSkill = Instantiate(Resources.Load<ZhaoZeSkill>("Prefabs/Monster/Level3/ZhaoZeBossSkill"),
                    QueueController.S.transform);
                zhaozeSkill.gameObject.SetActive(false);
                QueueController.S.ZhaoZeSkillQueue.Enqueue(zhaozeSkill);
            }

            yield return null;
        }



        if (LevelInfoConfig.CurrentGameLevel == 13 || LevelInfoConfig.CurrentGameLevel == 14 ||
            LevelInfoConfig.CurrentGameLevel == 15)
        {
            if (QueueController.S.XueRenJianQueue.Count < 100)
            {
                for (int i = 0; i < 100; i++)
                {
                    var XueRenJian =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level5/XueRenJian")
                                .GetComponent<XueRenJian>(),
                            QueueController.S.transform);
                    XueRenJian.gameObject.SetActive(false);
                    QueueController.S.XueRenJianQueue.Enqueue(XueRenJian.GetComponent<XueRenJian>());
                    count++;
                    if (count % perFrame == 0)
                    {
                        yield return null;
                    }
                }
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 15)
        {
            var XueRenBossSkill1 =
                Instantiate(
                    Resources.Load<GameObject>("Prefabs/Monster/Level5/XueRenBossSkill1")
                        .GetComponent<XueRenBossSkill1>(), QueueController.S.transform);
            XueRenBossSkill1.gameObject.SetActive(false);
            QueueController.S.XueRenBossSkill1Queue.Enqueue(XueRenBossSkill1.GetComponent<XueRenBossSkill1>());
        }

    }


    private IEnumerator LoadAndPreload()
    {
        // 1. 开始异步加载战斗场景
        AsyncOperation async = SceneManager.LoadSceneAsync("FightScene");
        async.allowSceneActivation = false; // 先不激活

        // 2. 等待加载进度达到 0.9（此时场景所有资源已加载完成，但还未实例化）
        while (async.progress < 0.9f)
        {
            loadSlider.value = async.progress / 0.9f;
            yield return null;
        }

        loadSlider.value = 1f;

        // 3. 【关键】在激活场景之前，执行所有对象池预热（利用 Loading 场景的这段时间）
        //    注意：需要把原来放在 Entrance.Awake 里的预热代码移到这里来调用
        yield return StartCoroutine(PreloadAllPools());

        // 4. 预热完成，激活战斗场景
        async.allowSceneActivation = true;

        // 5. 可选：隐藏 Loading 界面（战斗场景激活后会自动显示）
        // 等待一帧让场景切换
        yield return null;
        GameObject.Find("UIRoot")?.SetActive(false);
    }


    public void EntranceAwake()
    {
        GameController.S.MonsterList = GameController.S.SelectTwoUniqueNumbers();
        Application.targetFrameRate = 30;
        GlobalPlayerAttribute.CurrentHp = GlobalPlayerAttribute.TotalMaxHp;
        LevelInfoConfig.IsOneGame = false;

        AudioController.S.BGAudioSource.clip = Resources.Load<AudioClip>("Audio/BG/Level1BG");
        AudioController.S.BGAudioSource.Play();

        QueueController.S.GameMaxHp = GlobalPlayerAttribute.TotalMaxHp;
        QueueController.S.GameCurrentHp = GlobalPlayerAttribute.TotalMaxHp;
        //QueueController.S.GameDefense = GlobalPlayerAttribute.TotalDefense;
        //QueueController.S.GameAttack = GlobalPlayerAttribute.TotalDamage;
        QueueController.S.GameCrit = GlobalPlayerAttribute.TotalCRIT;
        GameController.S.isFuHuo = true;
        GameController.S.TotalAddHp = 0;

        //初始化装备和道具队列和怪物

        //初始化最大boss能量值
        GameController.S.MaxBossEnergyNum =
            LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel] *
            2; //这时小怪数量，精英不算数量，每10只普通怪出一只精英，所以正好是2倍
        GameController.S.MaxBossEnergyNum = 10;

        //初始化异界

    }
}
