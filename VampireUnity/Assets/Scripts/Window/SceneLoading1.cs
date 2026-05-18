using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading1 : MonoBehaviour
{
    public Image bg;
    public Slider loadSlider;
    void Start()
    {
        bg.sprite = ResourcesConfig.GetLoadingBg();
        GlobalPlayerAttribute.IsGame = true;
        StartCoroutine(LoadAndPreload());
    }

    public IEnumerator PreloadAllPools()
    {
        GameController.S.fightBG = Instantiate(Resources.Load<GameObject>("Prefabs/Window/FightBG"),
            GameController.S.transform);
        GameController.S.fightBG.transform.position = new Vector3(0, 0, 0.1f);
        
        
        //赋值
        FightBGController.S.WeaponButton= GameController.S.fightBG.GetComponent<FightBg>().weaponButton;
        FightBGController.S.normalAttackButton=GameController.S.fightBG.GetComponent<FightBg>().normalAttackButton;
        FightBGController.S.FightStopButton=GameController.S.fightBG.GetComponent<FightBg>().fightStopButton;
        FightBGController.S.dashButton=GameController.S.fightBG.GetComponent<FightBg>().dashButton;
        FightBGController.S.rageButton=GameController.S.fightBG.GetComponent<FightBg>().rageButton;
        FightBGController.S.shieldButton=GameController.S.fightBG.GetComponent<FightBg>().shieldButton;
        FightBGController.S.iceArrowButton=GameController.S.fightBG.GetComponent<FightBg>().iceArrowButton;
        FightBGController.S.iceExButton=GameController.S.fightBG.GetComponent<FightBg>().iceExButton;
        FightBGController.S.iceBallButton=GameController.S.fightBG.GetComponent<FightBg>().iceBallButton;
        FightBGController.S.IceExYellowCd=GameController.S.fightBG.GetComponent<FightBg>().iceExYellowCd;
        FightBGController.S.IceBallYellowCd=GameController.S.fightBG.GetComponent<FightBg>().iceBallYellowCd;
        FightBGController.S.IceArrowYellowCd=GameController.S.fightBG.GetComponent<FightBg>().iceArrowYellowCd;
        FightBGController.S.BossEnergySlider=GameController.S.fightBG.GetComponent<FightBg>().bossEnergySlider;


        FightBGController.S.playerHpSlider=GameController.S.fightBG.GetComponent<FightBg>().playerHpSlider;
        FightBGController.S.playerExSlider=GameController.S.fightBG.GetComponent<FightBg>().playerExSlider;
        FightBGController.S.playerLevelText=GameController.S.fightBG.GetComponent<FightBg>().playerLevelText;
        FightBGController.S.GameMaxHp=GameController.S.fightBG.GetComponent<FightBg>().GameMaxHp;
        FightBGController.S.GameCurrentHp=GameController.S.fightBG.GetComponent<FightBg>().GameCurrentHp;

        GameController.S.CreatePlayer();
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
        EntranceAwake();
    }
    
    private IEnumerator LoadAndPreload()
    {
        // 1. 开始异步加载战斗场景
        AsyncOperation async = SceneManager.LoadSceneAsync("FightScene");
        async.allowSceneActivation = false;  // 先不激活

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
        Debug.LogError("加载完成");

        // 5. 可选：隐藏 Loading 界面（战斗场景激活后会自动显示）
        // 等待一帧让场景切换
        yield return null;
        GameObject.Find("UIRoot")?.SetActive(false);
    }


    public void EntranceAwake()
    {
         GameController.S.MonsterList = GameController.S.SelectTwoUniqueNumbers();
        GameController.S.MonsterColliderDic.Clear();
        Application.targetFrameRate = 30;
        GlobalPlayerAttribute.CurrentHp = GlobalPlayerAttribute.TotalMaxHp;
        LevelInfoConfig.IsOneGame = false;

        AudioController.S.BGAudioSource.clip = Resources.Load<AudioClip>("Audio/BG/Level1BG");
        AudioController.S.BGAudioSource.Play();

        GameController.S.GameMaxHp = GlobalPlayerAttribute.TotalMaxHp;
        GameController.S.GameCurrentHp = GlobalPlayerAttribute.TotalMaxHp;
        //GameController.S.GameDefense = GlobalPlayerAttribute.TotalDefense;
        //GameController.S.GameAttack = GlobalPlayerAttribute.TotalDamage;
        GameController.S.GameCrit = GlobalPlayerAttribute.TotalCRIT;
        GameController.S.isFuHuo = true;
        GameController.S.TotalAddHp = 0;

        //初始化装备和道具队列和怪物

        //初始化最大boss能量值
        GameController.S.MaxBossEnergyNum =
            LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel] *
            2; //这时小怪数量，精英不算数量，每10只普通怪出一只精英，所以正好是2倍
        GameController.S.MaxBossEnergyNum = 10;

        //初始化异界

        if (LevelInfoConfig.CurrentGameLevel > 15)
        {

            if (LevelInfoConfig.CurrentGameLevel == 16)
            {
                for (int i = 0; i < 30; i++)
                {
                    var Monster1 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LeiShou/LeiShouSkill3")
                                .GetComponent<LeiShouSkill3>(),
                            GameController.S.transform);
                    Monster1.gameObject.SetActive(false);
                    GameController.S.LeiShouSkill3Queue.Enqueue(Monster1.GetComponent<LeiShouSkill3>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 17)
            {
                for (int i = 0; i < 30; i++)
                {
                    var Monster2 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/KuiJia/HeiXuanFen")
                                .GetComponent<HeiXuanFen>(),
                            GameController.S.transform);
                    Monster2.gameObject.SetActive(false);
                    GameController.S.HeiXuanFenQueue.Enqueue(Monster2.GetComponent<HeiXuanFen>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 18)
            {
                for (int i = 0; i < 30; i++)
                {
                    var Monster3 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/BaoZi/LvZhuiZong")
                                .GetComponent<LvZhuiZong>(),
                            GameController.S.transform);
                    Monster3.gameObject.SetActive(false);
                    GameController.S.LvZhuiZongQueue.Enqueue(Monster3.GetComponent<LvZhuiZong>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 18)
            {
                for (int i = 0; i < 30; i++)
                {
                    var Monster4 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/BaoZi/LvXuanFen")
                                .GetComponent<LvXuanFen>(),
                            GameController.S.transform);
                    Monster4.gameObject.SetActive(false);
                    GameController.S.LvXuanFenQueue.Enqueue(Monster4.GetComponent<LvXuanFen>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 18)
            {
                for (int i = 0; i < 30; i++)
                {

                    var Monster5 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/BaoZi/BaoZiSkill2")
                                .GetComponent<BaoZiSkill2>(),
                            GameController.S.transform);
                    Monster5.gameObject.SetActive(false);
                    GameController.S.BaoZiSkill2Queue.Enqueue(Monster5.GetComponent<BaoZiSkill2>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 19)
            {
                for (int i = 0; i < 30; i++)
                {

                    var Monster6 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/HuoLang/HuoLangSkill2")
                                .GetComponent<HuoLangSkill2>(),
                            GameController.S.transform);
                    Monster6.gameObject.SetActive(false);
                    GameController.S.HuoLangSkill2Queue.Enqueue(Monster6.GetComponent<HuoLangSkill2>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 20)
            {
                for (int i = 0; i < 30; i++)
                {

                    var Monster7 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/ShuangDao/ShuangDaoSkill2")
                                .GetComponent<ShuangDaoSkill2>(),
                            GameController.S.transform);
                    Monster7.gameObject.SetActive(false);
                    GameController.S.ShuangDaoSkill2Queue.Enqueue(Monster7.GetComponent<ShuangDaoSkill2>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 20)
            {
                for (int i = 0; i < 30; i++)
                {
                    var Monster8 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/ShuangDao/ShuangDaoSkill3")
                                .GetComponent<ShuangDaoSkill3>(),
                            GameController.S.transform);
                    Monster8.gameObject.SetActive(false);
                    GameController.S.ShuangDaoSkill3Queue.Enqueue(Monster8.GetComponent<ShuangDaoSkill3>());
                }
            }

        }


        //秘境怪物
        if (LevelInfoConfig.CurrentGameLevel > 15)
        {

            if (LevelInfoConfig.CurrentGameLevel == 18)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster1 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/DaLong").GetComponent<DaLong>(),
                            GameController.S.transform);
                    Monster1.gameObject.SetActive(false);
                    GameController.S.DaLongQueue.Enqueue(Monster1.GetComponent<DaLong>());
                    Collider2D collider2D = Monster1.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D, Monster1.GetComponent<MonsterBase>());
                }
            }



            if (LevelInfoConfig.CurrentGameLevel == 16)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster2 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/EMo1").GetComponent<EMo1>(),
                            GameController.S.transform);
                    Monster2.gameObject.SetActive(false);
                    GameController.S.EMo1Queue.Enqueue(Monster2.GetComponent<EMo1>());
                    Collider2D collider2D2 =
                        Monster2.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D2,
                        Monster2.GetComponent<MonsterBase>());
                }
            }



            if (LevelInfoConfig.CurrentGameLevel == 19)
            {
                for (int i = 0; i < 150; i++)
                {

                    var Monster3 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/EMo2").GetComponent<EMo2>(),
                            GameController.S.transform);
                    Monster3.gameObject.SetActive(false);
                    GameController.S.EMo2Queue.Enqueue(Monster3.GetComponent<EMo2>());
                    Collider2D collider2D3 =
                        Monster3.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D3,
                        Monster3.GetComponent<MonsterBase>());
                }
            }



            if (LevelInfoConfig.CurrentGameLevel == 22)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster4 =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Monster/MJ/EMo3").GetComponent<EMo3>(),
                            GameController.S.transform);
                    Monster4.gameObject.SetActive(false);
                    GameController.S.EMo3Queue.Enqueue(Monster4.GetComponent<EMo3>());
                    Collider2D collider2D4 = Monster4.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D4, Monster4.GetComponent<MonsterBase>());
                }
            }



            if (LevelInfoConfig.CurrentGameLevel == 16)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster5 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/HongLong1")
                                .GetComponent<HongLong1>(), GameController.S.transform);
                    Monster5.gameObject.SetActive(false);
                    GameController.S.HongLong1Queue.Enqueue(Monster5.GetComponent<HongLong1>());
                    Collider2D collider2D5 =
                        Monster5.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D5,
                        Monster5.GetComponent<MonsterBase>());
                }
            }



            if (LevelInfoConfig.CurrentGameLevel == 19)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster6 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/HongLong2")
                                .GetComponent<HongLong2>(), GameController.S.transform);
                    Monster6.gameObject.SetActive(false);
                    GameController.S.HongLong2Queue.Enqueue(Monster6.GetComponent<HongLong2>());
                    Collider2D collider2D6 =
                        Monster6.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D6,
                        Monster6.GetComponent<MonsterBase>());
                }
            }



            if (LevelInfoConfig.CurrentGameLevel == 22)
            {
                for (int i = 0; i < 150; i++)
                {

                    var Monster7 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/HongLong3")
                                .GetComponent<HongLong3>(), GameController.S.transform);
                    Monster7.gameObject.SetActive(false);
                    GameController.S.HongLong3Queue.Enqueue(Monster7.GetComponent<HongLong3>());
                    Collider2D collider2D7 = Monster7.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D7, Monster7.GetComponent<MonsterBase>());
                }
            }




            if (LevelInfoConfig.CurrentGameLevel == 17)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster8 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LanLong1")
                                .GetComponent<LanLong1>(),
                            GameController.S.transform);
                    Monster8.gameObject.SetActive(false);
                    GameController.S.LanLong1Queue.Enqueue(Monster8.GetComponent<LanLong1>());
                    Collider2D collider2D8 =
                        Monster8.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D8,
                        Monster8.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 20)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster9 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LanLong2")
                                .GetComponent<LanLong2>(),
                            GameController.S.transform);
                    Monster9.gameObject.SetActive(false);
                    GameController.S.LanLong2Queue.Enqueue(Monster9.GetComponent<LanLong2>());
                    Collider2D collider2D9 =
                        Monster9.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D9,
                        Monster9.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 23)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster10 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LanLong3").GetComponent<LanLong3>(),
                            GameController.S.transform);
                    Monster10.gameObject.SetActive(false);
                    GameController.S.LanLong3Queue.Enqueue(Monster10.GetComponent<LanLong3>());
                    Collider2D collider2D10 = Monster10.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D10, Monster10.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 18)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster11 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LvLang")
                                .GetComponent<LvLang>(),
                            GameController.S.transform);
                    Monster11.gameObject.SetActive(false);
                    GameController.S.LvLangQueue.Enqueue(Monster11.GetComponent<LvLang>());
                    Collider2D collider2D11 =
                        Monster11.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D11,
                        Monster11.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 17)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster12 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LvLong1")
                                .GetComponent<LvLong1>(),
                            GameController.S.transform);
                    Monster12.gameObject.SetActive(false);
                    GameController.S.LvLong1Queue.Enqueue(Monster12.GetComponent<LvLong1>());
                    Collider2D collider2D12 =
                        Monster12.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D12,
                        Monster12.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 20)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster13 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LvLong2")
                                .GetComponent<LvLong2>(),
                            GameController.S.transform);
                    Monster13.gameObject.SetActive(false);
                    GameController.S.LvLong2Queue.Enqueue(Monster13.GetComponent<LvLong2>());
                    Collider2D collider2D13 =
                        Monster13.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D13,
                        Monster13.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 21)
            {
                for (int i = 0; i < 150; i++)
                {
                    var huangshu =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level4/HuangShuMonster")
                                .GetComponent<HuangShu>(),
                            GameController.S.transform);
                    huangshu.gameObject.SetActive(false);
                    GameController.S.HuangShuQueue.Enqueue(huangshu.GetComponent<HuangShu>());

                    Collider2D Huangshucollider2D = huangshu.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(Huangshucollider2D,
                        huangshu.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 21)
            {
                for (int i = 0; i < 150; i++)
                {

                    var Huangzhu =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level4/HuangZhuMonster")
                                .GetComponent<Huangzhu>(),
                            GameController.S.transform);
                    Huangzhu.gameObject.SetActive(false);
                    GameController.S.HuangZhuQueue.Enqueue(Huangzhu.GetComponent<Huangzhu>());
                    Collider2D Huangzhucollider2D = Huangzhu.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(Huangzhucollider2D, Huangzhu.GetComponent<MonsterBase>());
                }
            }



            if (LevelInfoConfig.CurrentGameLevel == 23)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster14 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LvLong3").GetComponent<LvLong3>(),
                            GameController.S.transform);
                    Monster14.gameObject.SetActive(false);
                    GameController.S.LvLong3Queue.Enqueue(Monster14.GetComponent<LvLong3>());
                    Collider2D collider2D14 = Monster14.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D14, Monster14.GetComponent<MonsterBase>());
                }
            }
        }

        //实例化
        

        for (int i = 0; i < 10; i++)
        {
            var circleAttack = Instantiate(Resources.Load("Prefabs/Tool/CircleAttack"), new Vector3(0, 0, 0),
                Quaternion.identity) as GameObject;
            circleAttack.SetActive(false);
            FightBGController.S.CircleAttackQueue.Enqueue(circleAttack.GetComponent<CircleAttack>());
            var fire = Instantiate(Resources.Load("Prefabs/Skill/TreeManFire"), new Vector3(0, 0, 0),
                Quaternion.identity) as GameObject;
            fire.SetActive(false);
            FightBGController.S.TreeManFireQueue.Enqueue(fire.GetComponent<TreeManFire>());
            var sqrtattack = Instantiate(Resources.Load("Prefabs/Tool/SqrtAttack"), new Vector3(0, 0, 0),
                Quaternion.identity) as GameObject;
            sqrtattack.SetActive(false);
            FightBGController.S.SqrtAttackQueue.Enqueue(sqrtattack.GetComponent<SqrtAttack>());
            var playerhit = Instantiate(Resources.Load("Prefabs/Player/PlayerHit"), new Vector3(0, 0, 0),
                Quaternion.identity) as GameObject;
            playerhit.SetActive(false);
            FightBGController.S.PlayerHitQueue.Enqueue(playerhit.GetComponent<PlayerHit>());
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
            for (int i = 0; i < 5; i++)
            {
                var DiLie = Instantiate(
                    Resources.Load<GameObject>("Prefabs/Skill/DiLie").GetComponent<TreeManDiLie>(),
                    GameController.S.transform);
                DiLie.gameObject.SetActive(false);
                GameController.S.TreeManDiLieQueue.Enqueue(DiLie.GetComponent<TreeManDiLie>());
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 3)
        {
            for (int i = 0; i < 50; i++)
            {
                var treemanSkill =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level1/TreeManSkill")
                            .GetComponent<TreeManSkill>(),
                        GameController.S.transform);
                treemanSkill.gameObject.SetActive(false);
                GameController.S.TreeManSkillQueue.Enqueue(treemanSkill.GetComponent<TreeManSkill>());
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 6)
        {
            for (int i = 0; i < 3; i++)
            {
                var jianqi =
                    Instantiate(Resources.Load<HuoShanJianQi>("Prefabs/Monster/Level2/HuoShanJianQi"),
                        GameController.S.transform);
                jianqi.gameObject.SetActive(false);
                GameController.S.HuoShanJianQiQueue.Enqueue(jianqi);
            }

            for (int i = 0; i < 51; i++)
            {
                var huoshanskill2 =
                    Instantiate(Resources.Load<HuoShanSkill2>("Prefabs/Monster/Level2/HuoShanSkill2"),
                        GameController.S.transform);
                huoshanskill2.gameObject.SetActive(false);
                GameController.S.HuoShanSkill2QiQueue.Enqueue(huoshanskill2);
            }

        }


        if (LevelInfoConfig.CurrentGameLevel == 9)
        {
            for (int i = 0; i < 10; i++)
            {
                var zhaozeSkill = Instantiate(Resources.Load<ZhaoZeSkill>("Prefabs/Monster/Level3/ZhaoZeBossSkill"),
                    GameController.S.transform);
                zhaozeSkill.gameObject.SetActive(false);
                GameController.S.ZhaoZeSkillQueue.Enqueue(zhaozeSkill);
            }
        }



        if (LevelInfoConfig.CurrentGameLevel == 13 || LevelInfoConfig.CurrentGameLevel == 14 ||
            LevelInfoConfig.CurrentGameLevel == 15)
        {
            for (int i = 0; i < 100; i++)
            {
                var XueRenJian =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level5/XueRenJian").GetComponent<XueRenJian>(),
                        GameController.S.transform);
                XueRenJian.gameObject.SetActive(false);
                GameController.S.XueRenJianQueue.Enqueue(XueRenJian.GetComponent<XueRenJian>());
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 15)
        {
            var XueRenBossSkill1 =
                Instantiate(
                    Resources.Load<GameObject>("Prefabs/Monster/Level5/XueRenBossSkill1")
                        .GetComponent<XueRenBossSkill1>(), GameController.S.transform);
            XueRenBossSkill1.gameObject.SetActive(false);
            GameController.S.XueRenBossSkill1Queue.Enqueue(XueRenBossSkill1.GetComponent<XueRenBossSkill1>());
        }
    }

    
}
