using System;
using System.Collections.Generic;
using Config;
using Mysql;
using Prop.BaoShi;
using Skill.NormalAttack.Primary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Entrance : MonoBehaviour
{

    private void Awake()
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



        //初始化最大boss能量值
        GameController.S.MaxBossEnergyNum =
            LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel] *
            2; //这时小怪数量，精英不算数量，每10只普通怪出一只精英，所以正好是2倍
        GameController.S.MaxBossEnergyNum = 10;

        if (SkillJiaDian.S.Alpha1 == SkillType.Ice3 || SkillJiaDian.S.Alpha2 == SkillType.Ice3 ||
            SkillJiaDian.S.Alpha3 == SkillType.Ice3 || SkillJiaDian.S.Alpha4 == SkillType.Ice3 || SkillJiaDian.S.Alpha5 == SkillType.Ice3)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/IceExplosion").GetComponent<IceExplosion>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.IceExQueue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.Huo1 || SkillJiaDian.S.Alpha2 == SkillType.Huo1 ||
            SkillJiaDian.S.Alpha3 == SkillType.Huo1|| SkillJiaDian.S.Alpha4 == SkillType.Huo1|| SkillJiaDian.S.Alpha5 == SkillType.Huo1)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HuoSkill/HuoSkill1").GetComponent<HuoSkill1>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HuoSkill1Queue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.Dian2 || SkillJiaDian.S.Alpha2 == SkillType.Dian2 ||
            SkillJiaDian.S.Alpha3 == SkillType.Dian2|| SkillJiaDian.S.Alpha4 == SkillType.Dian2|| SkillJiaDian.S.Alpha5 == SkillType.Dian2)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/DianSkill/DianSkill2").GetComponent<DianSkill2>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.DianSkill2Queue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.HeiAn3 || SkillJiaDian.S.Alpha2 == SkillType.HeiAn3 ||
            SkillJiaDian.S.Alpha3 == SkillType.HeiAn3|| SkillJiaDian.S.Alpha4 == SkillType.HeiAn3|| SkillJiaDian.S.Alpha5 == SkillType.HeiAn3)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HeiAnSkill/HeiAnSkill3")
                            .GetComponent<HeiAnSkill3>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HeiAnSkill3Queue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.HeiAn1 || SkillJiaDian.S.Alpha2 == SkillType.HeiAn1 ||
            SkillJiaDian.S.Alpha3 == SkillType.HeiAn1|| SkillJiaDian.S.Alpha4 == SkillType.HeiAn1|| SkillJiaDian.S.Alpha5 == SkillType.HeiAn1)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HeiAnSkill/HeiAnSkill1")
                            .GetComponent<HeiAnSkill1>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HeiAnSkill1Queue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.Dian3 || SkillJiaDian.S.Alpha2 == SkillType.Dian3 ||
            SkillJiaDian.S.Alpha3 == SkillType.Dian3|| SkillJiaDian.S.Alpha4 == SkillType.Dian3|| SkillJiaDian.S.Alpha5 == SkillType.Dian3)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/DianSkill/DianSkill3").GetComponent<DianSkill3>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.DianSkill3Queue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.Huo3 || SkillJiaDian.S.Alpha2 == SkillType.Huo3 ||
            SkillJiaDian.S.Alpha3 == SkillType.Huo3|| SkillJiaDian.S.Alpha4 == SkillType.Huo3|| SkillJiaDian.S.Alpha5 == SkillType.Huo3)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HuoSkill/HuoSkill3").GetComponent<HuoSkill3>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HuoSkill3Queue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.Ice1 || SkillJiaDian.S.Alpha2 == SkillType.Ice1 ||
            SkillJiaDian.S.Alpha3 == SkillType.Ice1|| SkillJiaDian.S.Alpha4 == SkillType.Ice1|| SkillJiaDian.S.Alpha5 == SkillType.Ice1)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/IceSkill/IceSkill1").GetComponent<IceSkill1>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.IceSkill1Queue.Enqueue(Monster1);
            }
        }
        
        if (SkillJiaDian.S.Alpha1 != SkillType.Ice4 || SkillJiaDian.S.Alpha2 == SkillType.Ice4 ||
            SkillJiaDian.S.Alpha3 == SkillType.Ice4|| SkillJiaDian.S.Alpha4 == SkillType.Ice4|| SkillJiaDian.S.Alpha5 == SkillType.Ice4)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/IceSkill/IceSkill4").GetComponent<IceSkill4>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.IceSkill4Queue.Enqueue(Monster1);
            }
        }
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.Ice5 || SkillJiaDian.S.Alpha2 == SkillType.Ice5 ||
            SkillJiaDian.S.Alpha3 == SkillType.Ice5|| SkillJiaDian.S.Alpha4 == SkillType.Ice5|| SkillJiaDian.S.Alpha5 == SkillType.Ice5)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/IceSkill/IceSkill5").GetComponent<IceSkill5>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.IceSkill5Queue.Enqueue(Monster1);
            }
        }
        
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.Huo4 || SkillJiaDian.S.Alpha2 == SkillType.Huo4 ||
            SkillJiaDian.S.Alpha3 == SkillType.Huo4|| SkillJiaDian.S.Alpha4 == SkillType.Huo4|| SkillJiaDian.S.Alpha5 == SkillType.Huo4)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HuoSkill/HuoSkill4").GetComponent<HuoSkill4>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HuoSkill4Queue.Enqueue(Monster1);
            }
        }
        
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.Huo5 || SkillJiaDian.S.Alpha2 == SkillType.Huo5 ||
            SkillJiaDian.S.Alpha3 == SkillType.Huo5|| SkillJiaDian.S.Alpha4 == SkillType.Huo5|| SkillJiaDian.S.Alpha5 == SkillType.Huo5)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HuoSkill/HuoSkill5").GetComponent<HuoSkill5>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HuoSkill5Queue.Enqueue(Monster1);
            }
        }
        
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.Dian4 || SkillJiaDian.S.Alpha2 == SkillType.Dian4 ||
            SkillJiaDian.S.Alpha3 == SkillType.Dian4|| SkillJiaDian.S.Alpha4 == SkillType.Dian4|| SkillJiaDian.S.Alpha5 == SkillType.Dian4)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/DianSkill/DianSkill4").GetComponent<DianSkill4>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.DianSkill4Queue.Enqueue(Monster1);
            }
        }
        
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.Dian5 || SkillJiaDian.S.Alpha2 == SkillType.Dian5 ||
            SkillJiaDian.S.Alpha3 == SkillType.Dian5|| SkillJiaDian.S.Alpha4 == SkillType.Dian5|| SkillJiaDian.S.Alpha5 == SkillType.Dian5)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/DianSkill/DianSkill5").GetComponent<DianSkill5>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.DianSkill5Queue.Enqueue(Monster1);
            }
        }
        
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.HeiAn4 || SkillJiaDian.S.Alpha2 == SkillType.HeiAn4 ||
            SkillJiaDian.S.Alpha3 == SkillType.HeiAn4|| SkillJiaDian.S.Alpha4 == SkillType.HeiAn4|| SkillJiaDian.S.Alpha5 == SkillType.HeiAn4)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HeiAnSkill/HeiAnSkill4").GetComponent<HeiAnSkill4>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HeiAnSkill4Queue.Enqueue(Monster1);
            }
        }
        
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.HeiAn5 || SkillJiaDian.S.Alpha2 == SkillType.HeiAn5 ||
            SkillJiaDian.S.Alpha3 == SkillType.HeiAn5|| SkillJiaDian.S.Alpha4 == SkillType.HeiAn5|| SkillJiaDian.S.Alpha5 == SkillType.HeiAn5)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HeiAnSkill/HeiAnSkill5").GetComponent<HeiAnSkill5>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HeiAnSkill5Queue.Enqueue(Monster1);
            }
        }


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

            if (LevelInfoConfig.CurrentGameLevel ==17)
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

            if (LevelInfoConfig.CurrentGameLevel ==18)
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

            if (LevelInfoConfig.CurrentGameLevel ==19)
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

            if (LevelInfoConfig.CurrentGameLevel ==20)
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
        //FightBGController


        //Boss攻击对象池
        for (int i = 0; i < 100; i++)
        {
            PlayerHurt playerHurt = Instantiate(Resources.Load<PlayerHurt>("Prefabs/Player/PlayerHurt"));
            playerHurt.gameObject.SetActive(false);
            GameController.S.PlayerHurtQueue.Enqueue(playerHurt);

            CircleAttack circle = Instantiate(Resources.Load<CircleAttack>("Prefabs/Tool/CircleAttack"));
            circle.gameObject.SetActive(false);
            GameController.S.CircleQueue.Enqueue(circle);

            SqrtAttack sqrt = Instantiate(Resources.Load<SqrtAttack>("Prefabs/Tool/SqrtAttack"));
            sqrt.gameObject.SetActive(false);
            GameController.S.SqrtQueue.Enqueue(sqrt);

            BaoShi BaoShi = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/BaoShi")).GetComponent<BaoShi>();
            BaoShi.gameObject.SetActive(false);
            GameController.S.BaoShiQueue.Enqueue(BaoShi);
        }



        //装备对象池
        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(0, 0, prop: 401)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject whiteChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBangWhite"));
                whiteChiBang.gameObject.SetActive(false);
                GameController.S.WhiteChiBang.Enqueue(whiteChiBang);
            }
        }


        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(),
                new DiaoLuoConfig(0, 0, prop: 402)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject GreenChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBangGreen"));
                GreenChiBang.gameObject.SetActive(false);
                GameController.S.GreenChiBang.Enqueue(GreenChiBang);
            }
        }

        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(),
                new DiaoLuoConfig(0, 0, prop: 403)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject BlueChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBangBlue"));
                BlueChiBang.gameObject.SetActive(false);
                GameController.S.BlueChiBang.Enqueue(BlueChiBang);
            }
        }

        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(),
                new DiaoLuoConfig(0, 0, prop: 404)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject PurpleChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBangPurple"));
                PurpleChiBang.gameObject.SetActive(false);
                GameController.S.PurpleChiBang.Enqueue(PurpleChiBang);
            }
        }

        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(),
                new DiaoLuoConfig(0, 0, prop: 405)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject OrangeChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBangOrange"));
                OrangeChiBang.gameObject.SetActive(false);
                GameController.S.OrangeChiBang.Enqueue(OrangeChiBang);
            }
        }

        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(),
                new DiaoLuoConfig(0, 0, prop: 406)))
        {
            for (int i = 0; i < 30; i++)
            {

                GameObject RedChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBangRed"));
                RedChiBang.gameObject.SetActive(false);
                GameController.S.RedChiBang.Enqueue(RedChiBang);
            }
        }


        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(),
                new DiaoLuoConfig(0, 0, prop: 101)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject whiteWeaponFragmeng =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/WhiteWeaponFragmeng"));
                whiteWeaponFragmeng.gameObject.SetActive(false);
                GameController.S.WhiteWeaponFragmengQueue.Enqueue(whiteWeaponFragmeng);
            }
        }

        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(),
                new DiaoLuoConfig(0, 0, prop: 102)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject GreenWeaponFragmeng =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/GreenWeaponFragmeng"));
                GreenWeaponFragmeng.gameObject.SetActive(false);
                GameController.S.GreenWeaponFragmengQueue.Enqueue(GreenWeaponFragmeng);
            }
        }

        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(),
                new DiaoLuoConfig(0, 0, prop: 103)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject BlueWeaponFragmeng =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/BlueWeaponFragmeng"));
                BlueWeaponFragmeng.gameObject.SetActive(false);
                GameController.S.BlueWeaponFragmengQueue.Enqueue(BlueWeaponFragmeng);
            }
        }

        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(),
                new DiaoLuoConfig(0, 0, prop: 104)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject PurpleWeaponFragmeng =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/PurpleWeaponFragmeng"));
                PurpleWeaponFragmeng.gameObject.SetActive(false);
                GameController.S.PurpleWeaponFragmengQueue.Enqueue(PurpleWeaponFragmeng);
            }
        }

        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(),
                new DiaoLuoConfig(0, 0, prop: 105)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject OrangeWeaponFragmeng =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/OrangeWeaponFragmeng"));
                OrangeWeaponFragmeng.gameObject.SetActive(false);
                GameController.S.OrangeWeaponFragmengQueue.Enqueue(OrangeWeaponFragmeng);
            }
        }

        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(),
                new DiaoLuoConfig(0, 0, prop: 106)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject RedWeaponFragmeng =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/RedWeaponFragmeng"));
                RedWeaponFragmeng.gameObject.SetActive(false);
                GameController.S.RedWeaponFragmengQueue.Enqueue(RedWeaponFragmeng);
            }
        }

        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(0, 0, prop: 303)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject JuDaYaChi = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/JuDaYaChi"));
                JuDaYaChi.gameObject.SetActive(false);
                GameController.S.JuDaYaChiQueue.Enqueue(JuDaYaChi);
            }
        }

        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(0, 0, prop: 302)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject GoldBlood = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/GoldBlood"));
                GoldBlood.gameObject.SetActive(false);
                GameController.S.GoldBloodQueue.Enqueue(GoldBlood);
            }
        }

        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(0, 0, prop: 304)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject ZuiEYanZhu = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ZuiEYanZhu"));
                ZuiEYanZhu.gameObject.SetActive(false);
                GameController.S.ZuiEYanZhuQueue.Enqueue(ZuiEYanZhu);
            }
        }


        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(0, 0, prop: 301)))
        {
            for (int i = 0; i < 30; i++)
            {
                GameObject FuMoZhiGu = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/FuMoZhiGu"));
                FuMoZhiGu.gameObject.SetActive(false);
                GameController.S.FuMoZhiGuQueue.Enqueue(FuMoZhiGu);
            }
        }

        




        if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(1, equipType: 1)))
        {
            for (int i = 0; i < 20; i++)
            {
                GameObject primaryCloakFight =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryCloakFight"));
                primaryCloakFight.gameObject.SetActive(false);
                GameController.S.PrimaryCloakQueue.Enqueue(primaryCloakFight);

                GameObject primaryClothFight =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryClothFight"));
                primaryClothFight.gameObject.SetActive(false);
                GameController.S.PrimaryClothQueue.Enqueue(primaryClothFight);

                GameObject primaryRingFight =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryRingFight"));
                primaryRingFight.gameObject.SetActive(false);
                GameController.S.PrimaryRingQueue.Enqueue(primaryRingFight);

                GameObject primaryShoeFight =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryShoeFight"));
                primaryShoeFight.gameObject.SetActive(false);
                GameController.S.PrimaryShoeQueue.Enqueue(primaryShoeFight);

                GameObject primaryNecklaceFight =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryNecklaceFight"));
                primaryNecklaceFight.gameObject.SetActive(false);
                GameController.S.PrimaryNecklaceQueue.Enqueue(primaryNecklaceFight);

                GameObject primaryHelmetFight =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryHelmetFight"));
                primaryHelmetFight.gameObject.SetActive(false);
                GameController.S.PrimaryHelmetQueue.Enqueue(primaryHelmetFight);

            }
            
            

            if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(2, equipType: 1)))
            {
                for (int i = 0; i < 20; i++)
                {

                    GameObject GreenCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenCloakFight"));
                    GreenCloakFight.gameObject.SetActive(false);
                    GameController.S.GreenCloakQueue.Enqueue(GreenCloakFight);

                    GameObject GreenClothFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenClothFight"));
                    GreenClothFight.gameObject.SetActive(false);
                    GameController.S.GreenClothQueue.Enqueue(GreenClothFight);

                    GameObject GreenRingFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenRingFight"));
                    GreenRingFight.gameObject.SetActive(false);
                    GameController.S.GreenRingQueue.Enqueue(GreenRingFight);

                    GameObject GreenShoeFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenShoeFight"));
                    GreenShoeFight.gameObject.SetActive(false);
                    GameController.S.GreenShoeQueue.Enqueue(GreenShoeFight);

                    GameObject GreenNecklaceFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenNecklaceFight"));
                    GreenNecklaceFight.gameObject.SetActive(false);
                    GameController.S.GreenNecklaceQueue.Enqueue(GreenNecklaceFight);

                    GameObject GreenHelmetFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenHelmetFight"));
                    GreenHelmetFight.gameObject.SetActive(false);
                    GameController.S.GreenHelmetQueue.Enqueue(GreenHelmetFight);

                }
            }
            

            if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(3, equipType: 1)))
            {
                for (int i = 0; i < 20; i++)
                {

                    GameObject BlueCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueCloakFight"));
                    BlueCloakFight.gameObject.SetActive(false);
                    GameController.S.BlueCloakQueue.Enqueue(BlueCloakFight);

                    GameObject BlueClothFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueClothFight"));
                    BlueClothFight.gameObject.SetActive(false);
                    GameController.S.BlueClothQueue.Enqueue(BlueClothFight);

                    GameObject BlueRingFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueRingFight"));
                    BlueRingFight.gameObject.SetActive(false);
                    GameController.S.BlueRingQueue.Enqueue(BlueRingFight);

                    GameObject BlueShoeFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueShoeFight"));
                    BlueShoeFight.gameObject.SetActive(false);
                    GameController.S.BlueShoeQueue.Enqueue(BlueShoeFight);

                    GameObject BlueNecklaceFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueNecklaceFight"));
                    BlueNecklaceFight.gameObject.SetActive(false);
                    GameController.S.BlueNecklaceQueue.Enqueue(BlueNecklaceFight);

                    GameObject BlueHelmetFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueHelmetFight"));
                    BlueHelmetFight.gameObject.SetActive(false);
                    GameController.S.BlueHelmetQueue.Enqueue(BlueHelmetFight);

                }
            }

            if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(6, equipType: 1)))
            {
                for (int i = 0; i < 20; i++)
                {


                    GameObject ZhaoZeCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeCloakFight"));
                    ZhaoZeCloakFight.gameObject.SetActive(false);
                    GameController.S.ZhaoZeCloakQueue.Enqueue(ZhaoZeCloakFight);

                    GameObject ZhaoZeClothFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeClothFight"));
                    ZhaoZeClothFight.gameObject.SetActive(false);
                    GameController.S.ZhaoZeClothQueue.Enqueue(ZhaoZeClothFight);

                    GameObject ZhaoZeRingFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeRingFight"));
                    ZhaoZeRingFight.gameObject.SetActive(false);
                    GameController.S.ZhaoZeRingQueue.Enqueue(ZhaoZeRingFight);

                    GameObject ZhaoZeShoeFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeShoeFight"));
                    ZhaoZeShoeFight.gameObject.SetActive(false);
                    GameController.S.ZhaoZeShoeQueue.Enqueue(ZhaoZeShoeFight);

                    GameObject ZhaoZeNecklaceFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeNecklaceFight"));
                    ZhaoZeNecklaceFight.gameObject.SetActive(false);
                    GameController.S.ZhaoZeNecklaceQueue.Enqueue(ZhaoZeNecklaceFight);

                    GameObject ZhaoZeHelmetFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeHelmetFight"));
                    ZhaoZeHelmetFight.gameObject.SetActive(false);
                    GameController.S.ZhaoZeHelmetQueue.Enqueue(ZhaoZeHelmetFight);

                }
            }





            if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(7, equipType: 1)))
            {
                for (int i = 0; i < 20; i++)
                {

                    GameObject PurpleCloakFight1 =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/PurpleCloakFight1"));
                    PurpleCloakFight1.gameObject.SetActive(false);
                    GameController.S.Purple1CloakQueue.Enqueue(PurpleCloakFight1);

                    GameObject PurpleClothFight1 =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/PurpleClothFight1"));
                    PurpleClothFight1.gameObject.SetActive(false);
                    GameController.S.Purple1ClothQueue.Enqueue(PurpleClothFight1);

                    GameObject PurpleRingFight1 =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/PurpleRingFight1"));
                    PurpleRingFight1.gameObject.SetActive(false);
                    GameController.S.Purple1RingQueue.Enqueue(PurpleRingFight1);

                    GameObject PurpleShoeFight1 =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/PurpleShoeFight1"));
                    PurpleShoeFight1.gameObject.SetActive(false);
                    GameController.S.Purple1ShoeQueue.Enqueue(PurpleShoeFight1);

                    GameObject PurpleNecklaceFight1 =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/PurpleNecklaceFight1"));
                    PurpleNecklaceFight1.gameObject.SetActive(false);
                    GameController.S.Purple1NecklaceQueue.Enqueue(PurpleNecklaceFight1);

                    GameObject PurpleHelmetFight1 =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/PurpleHelmetFight1"));
                    PurpleHelmetFight1.gameObject.SetActive(false);
                    GameController.S.Purple1HelmetQueue.Enqueue(PurpleHelmetFight1);

                }
            }





            if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(101, equipType: 1)))
            {
                for (int i = 0; i < 20; i++)
                {

                    GameObject TreeManCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManCloakFight"));
                    TreeManCloakFight.gameObject.SetActive(false);
                    GameController.S.TreeManCloakQueue.Enqueue(TreeManCloakFight);

                    GameObject TreeManClothFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManClothFight"));
                    TreeManClothFight.gameObject.SetActive(false);
                    GameController.S.TreeManClothQueue.Enqueue(TreeManClothFight);

                    GameObject TreeManRingFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManRingFight"));
                    TreeManRingFight.gameObject.SetActive(false);
                    GameController.S.TreeManRingQueue.Enqueue(TreeManRingFight);

                    GameObject TreeManShoeFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManShoeFight"));
                    TreeManShoeFight.gameObject.SetActive(false);
                    GameController.S.TreeManShoeQueue.Enqueue(TreeManShoeFight);

                    GameObject TreeManNecklaceFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManNecklaceFight"));
                    TreeManNecklaceFight.gameObject.SetActive(false);
                    GameController.S.TreeManNecklaceQueue.Enqueue(TreeManNecklaceFight);

                    GameObject TreeManHelmetFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManHelmetFight"));
                    TreeManHelmetFight.gameObject.SetActive(false);
                    GameController.S.TreeManHelmetQueue.Enqueue(TreeManHelmetFight);

                }
            }

            if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(102, equipType: 1)))
            {
                for (int i = 0; i < 20; i++)
                {

                    GameObject HuoShanCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanCloakFight"));
                    HuoShanCloakFight.gameObject.SetActive(false);
                    GameController.S.HuoShanCloakQueue.Enqueue(HuoShanCloakFight);

                    GameObject HuoShanClothFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanClothFight"));
                    HuoShanClothFight.gameObject.SetActive(false);
                    GameController.S.HuoShanClothQueue.Enqueue(HuoShanClothFight);

                    GameObject HuoShanRingFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanRingFight"));
                    HuoShanRingFight.gameObject.SetActive(false);
                    GameController.S.HuoShanRingQueue.Enqueue(HuoShanRingFight);

                    GameObject HuoShanShoeFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanShoeFight"));
                    HuoShanShoeFight.gameObject.SetActive(false);
                    GameController.S.HuoShanShoeQueue.Enqueue(HuoShanShoeFight);

                    GameObject HuoShanNecklaceFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanNecklaceFight"));
                    HuoShanNecklaceFight.gameObject.SetActive(false);
                    GameController.S.HuoShanNecklaceQueue.Enqueue(HuoShanNecklaceFight);

                    GameObject HuoShanHelmetFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanHelmetFight"));
                    HuoShanHelmetFight.gameObject.SetActive(false);
                    GameController.S.HuoShanHelmetQueue.Enqueue(HuoShanHelmetFight);

                }
            }

            if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(4, equipType: 1)))
            {
                for (int i = 0; i < 20; i++)
                {

                    GameObject PurpleCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleCloakFight"));
                    PurpleCloakFight.gameObject.SetActive(false);
                    GameController.S.PurpleCloakQueue.Enqueue(PurpleCloakFight);

                    GameObject PurpleClothFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleClothFight"));
                    PurpleClothFight.gameObject.SetActive(false);
                    GameController.S.PurpleClothQueue.Enqueue(PurpleClothFight);

                    GameObject PurpleRingFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleRingFight"));
                    PurpleRingFight.gameObject.SetActive(false);
                    GameController.S.PurpleRingQueue.Enqueue(PurpleRingFight);

                    GameObject PurpleShoeFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleShoeFight"));
                    PurpleShoeFight.gameObject.SetActive(false);
                    GameController.S.PurpleShoeQueue.Enqueue(PurpleShoeFight);

                    GameObject PurpleNecklaceFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleNecklaceFight"));
                    PurpleNecklaceFight.gameObject.SetActive(false);
                    GameController.S.PurpleNecklaceQueue.Enqueue(PurpleNecklaceFight);

                    GameObject PurpleHelmetFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleHelmetFight"));
                    PurpleHelmetFight.gameObject.SetActive(false);
                    GameController.S.PurpleHelmetQueue.Enqueue(PurpleHelmetFight);
                }
            }

            if (LevelInfoConfig.IsHaveDiaoLuo(LevelInfoConfig.GetDiaoLuoList(), new DiaoLuoConfig(5, equipType: 1)))
            {
                for (int i = 0; i < 20; i++)
                {

                    GameObject OrangeCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeCloakFight"));
                    OrangeCloakFight.gameObject.SetActive(false);
                    OrangeCloakFight.GetComponent<EquipBase>().enabled = true;
                    GameController.S.OrangeCloakQueue.Enqueue(OrangeCloakFight);

                    GameObject OrangeClothFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeClothFight"));
                    OrangeClothFight.gameObject.SetActive(false);
                    OrangeCloakFight.GetComponent<EquipBase>().enabled = true;
                    GameController.S.OrangeClothQueue.Enqueue(OrangeClothFight);

                    GameObject OrangeRingFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeRingFight"));
                    OrangeRingFight.gameObject.SetActive(false);
                    OrangeCloakFight.GetComponent<EquipBase>().enabled = true;
                    GameController.S.OrangeRingQueue.Enqueue(OrangeRingFight);

                    GameObject OrangeShoeFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeShoeFight"));
                    OrangeShoeFight.gameObject.SetActive(false);
                    OrangeCloakFight.GetComponent<EquipBase>().enabled = true;
                    GameController.S.OrangeShoeQueue.Enqueue(OrangeShoeFight);

                    GameObject OrangeNecklaceFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeNecklaceFight"));
                    OrangeNecklaceFight.gameObject.SetActive(false);
                    OrangeCloakFight.GetComponent<EquipBase>().enabled = true;
                    GameController.S.OrangeNecklaceQueue.Enqueue(OrangeNecklaceFight);

                    GameObject OrangeHelmetFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeHelmetFight"));
                    OrangeHelmetFight.gameObject.SetActive(false);
                    OrangeCloakFight.GetComponent<EquipBase>().enabled = true;
                    GameController.S.OrangeHelmetQueue.Enqueue(OrangeHelmetFight);
                }
            }
            

            if (LevelInfoConfig.CurrentGameLevel > 15)
            {
                for (int i = 0; i < 5; i++)
                {

                    //传说装备

                    GameObject FinalDamageReductionFixed =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/FinalDamageReductionFixed"));
                    FinalDamageReductionFixed.gameObject.SetActive(false);
                    GameController.S.FinalDamageReductionFixedQueue.Enqueue(FinalDamageReductionFixed);

                    GameObject FinalDamageReductionPercent =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/FinalDamageReductionPercent"));
                    FinalDamageReductionPercent.gameObject.SetActive(false);
                    GameController.S.FinalDamageReductionPercentQueue.Enqueue(FinalDamageReductionPercent);

                    GameObject AllReplyAddPercent =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/AllReplyAddPercent"));
                    AllReplyAddPercent.gameObject.SetActive(false);
                    GameController.S.AllReplyAddPercentQueue.Enqueue(AllReplyAddPercent);

                    GameObject AddHpForTime =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/AddHpForTime"));
                    AddHpForTime.gameObject.SetActive(false);
                    GameController.S.AddHpForTimeQueue.Enqueue(AddHpForTime);

                    GameObject AddDefenseForTime =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/AddDefenseForTime"));
                    AddDefenseForTime.gameObject.SetActive(false);
                    GameController.S.AddDefenseForTimeQueue.Enqueue(AddDefenseForTime);

                    GameObject ReplyDeath =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/ReplyDeath"));
                    ReplyDeath.gameObject.SetActive(false);
                    GameController.S.ReplyDeathQueue.Enqueue(ReplyDeath);

                    GameObject DelayDamage =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/DelayDamage"));
                    DelayDamage.gameObject.SetActive(false);
                    GameController.S.DelayDamageQueue.Enqueue(DelayDamage);

                    GameObject HpReductionReplyAdd50 =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/HpReductionReplyAdd50"));
                    HpReductionReplyAdd50.gameObject.SetActive(false);
                    GameController.S.HpReductionReplyAdd50Queue.Enqueue(HpReductionReplyAdd50);

                    GameObject HpReductionAddDefense =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/HpReductionAddDefense"));
                    HpReductionAddDefense.gameObject.SetActive(false);
                    GameController.S.HpReductionAddDefenseQueue.Enqueue(HpReductionAddDefense);

                    GameObject FinalDamageAddPercent =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/FinalDamageAddPercent"));
                    FinalDamageAddPercent.gameObject.SetActive(false);
                    GameController.S.FinalDamageAddPercentQueue.Enqueue(FinalDamageAddPercent);

                    GameObject KillNormal =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/KillNormal"));
                    KillNormal.gameObject.SetActive(false);
                    GameController.S.KillNormalQueue.Enqueue(KillNormal);

                    GameObject AddAttackForTime =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/AddAttackForTime"));
                    AddAttackForTime.gameObject.SetActive(false);
                    GameController.S.AddAttackForTimeQueue.Enqueue(AddAttackForTime);

                    GameObject NormalAddDamage =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/NormalAddDamage"));
                    NormalAddDamage.gameObject.SetActive(false);
                    GameController.S.NormalAddDamageQueue.Enqueue(NormalAddDamage);

                    GameObject RecudeHpAddAttack =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/RecudeHpAddAttack"));
                    RecudeHpAddAttack.gameObject.SetActive(false);
                    GameController.S.RecudeHpAddAttackQueue.Enqueue(RecudeHpAddAttack);

                    GameObject JianSuAddAttack =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/JianSuAddAttack"));
                    JianSuAddAttack.gameObject.SetActive(false);
                    GameController.S.JianSuAddAttackQueue.Enqueue(JianSuAddAttack);

                    GameObject FanPuGuiZhen =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/FanPuGuiZhen"));
                    FanPuGuiZhen.gameObject.SetActive(false);
                    GameController.S.FanPuGuiZhenQueue.Enqueue(FanPuGuiZhen);

                    GameObject NoSkill =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/NoSkill"));
                    NoSkill.gameObject.SetActive(false);
                    GameController.S.NoSkillQueue.Enqueue(NoSkill);

                    GameObject BuWangChuXin =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/BuWangChuXin"));
                    BuWangChuXin.gameObject.SetActive(false);
                    GameController.S.BuWangChuXinQueue.Enqueue(BuWangChuXin);

                    GameObject HeiDongAddSpeed =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/HeiDongAddSpeed"));
                    HeiDongAddSpeed.gameObject.SetActive(false);
                    GameController.S.HeiDongAddSpeedQueue.Enqueue(HeiDongAddSpeed);

                    GameObject DuAddDuQuan =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/DuAddDuQuan"));
                    DuAddDuQuan.gameObject.SetActive(false);
                    GameController.S.DuAddDuQuanQueue.Enqueue(DuAddDuQuan);

                    GameObject LvQuanAddScale =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/LvQuanAddScale"));
                    LvQuanAddScale.gameObject.SetActive(false);
                    GameController.S.LvQuanAddScaleQueue.Enqueue(LvQuanAddScale);

                    GameObject XuKongAdd2Dan =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/XuKongAdd2Dan"));
                    XuKongAdd2Dan.gameObject.SetActive(false);
                    GameController.S.XuKongAdd2DanQueue.Enqueue(XuKongAdd2Dan);

                    GameObject PuTong3ChuanTou =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/PuTong3ChuanTou"));
                    PuTong3ChuanTou.gameObject.SetActive(false);
                    GameController.S.PuTong3ChuanTouQueue.Enqueue(PuTong3ChuanTou);

                    GameObject FireBaoZha1 =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/FireBaoZha"));
                    FireBaoZha1.gameObject.SetActive(false);
                    GameController.S.FireBaoZhaQueue.Enqueue(FireBaoZha1);

                    GameObject Skill1ReplaceNormalAttack =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/Skill1ReplaceNormalAttack"));
                    Skill1ReplaceNormalAttack.gameObject.SetActive(false);
                    GameController.S.Skill1ReplaceNormalAttackQueue.Enqueue(Skill1ReplaceNormalAttack);

                    GameObject Skill1YiDianDouble =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/Skill1YiDianDouble"));
                    Skill1YiDianDouble.gameObject.SetActive(false);
                    GameController.S.Skill1YiDianDoubleQueue.Enqueue(Skill1YiDianDouble);

                    GameObject Skill1AddRange =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/Skill1AddRange"));
                    Skill1AddRange.gameObject.SetActive(false);
                    GameController.S.Skill1AddRangeQueue.Enqueue(Skill1AddRange);

                    GameObject Skill2AddDan =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/Skill2AddDan"));
                    Skill2AddDan.gameObject.SetActive(false);
                    GameController.S.Skill2AddDanQueue.Enqueue(Skill2AddDan);

                    GameObject Skill2RotateAdd =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/Skill2RotateAdd"));
                    Skill2RotateAdd.gameObject.SetActive(false);
                    GameController.S.Skill2RotateAddQueue.Enqueue(Skill2RotateAdd);

                    GameObject Skill2AddRange =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/Skill2AddRange"));
                    Skill2AddRange.gameObject.SetActive(false);
                    GameController.S.Skill2AddRangeQueue.Enqueue(Skill2AddRange);

                    GameObject Skill3Bian3 =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/Skill3Bian3"));
                    Skill3Bian3.gameObject.SetActive(false);
                    GameController.S.Skill3Bian3Queue.Enqueue(Skill3Bian3);

                    GameObject Skill3AddRange =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/Skill3AddRange"));
                    Skill3AddRange.gameObject.SetActive(false);
                    GameController.S.Skill3AddRangeQueue.Enqueue(Skill3AddRange);

                    GameObject DashCd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/DashCd"));
                    DashCd.gameObject.SetActive(false);
                    GameController.S.DashCdQueue.Enqueue(DashCd);

                    GameObject DashRange =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/DashRange"));
                    DashRange.gameObject.SetActive(false);
                    GameController.S.DashRangeQueue.Enqueue(DashRange);

                    GameObject MoveSpeedAdd =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/MoveSpeedAdd"));
                    MoveSpeedAdd.gameObject.SetActive(false);
                    GameController.S.MoveSpeedAddQueue.Enqueue(MoveSpeedAdd);

                    GameObject ExAdd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/ExAdd"));
                    ExAdd.gameObject.SetActive(false);
                    GameController.S.ExAddQueue.Enqueue(ExAdd);

                    GameObject ClothFortureAdd =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/ClothFortureAdd"));
                    ClothFortureAdd.gameObject.SetActive(false);
                    GameController.S.ClothFortureAddQueue.Enqueue(ClothFortureAdd);

                    GameObject ShoeFortureAdd =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/ShoeFortureAdd"));
                    ShoeFortureAdd.gameObject.SetActive(false);
                    GameController.S.ShoeFortureAddQueue.Enqueue(ShoeFortureAdd);

                    GameObject CloakFortureAdd =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/CloakFortureAdd"));
                    CloakFortureAdd.gameObject.SetActive(false);
                    GameController.S.CloakFortureAddQueue.Enqueue(CloakFortureAdd);

                    GameObject NecklaceFortureAdd =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/NecklaceFortureAdd"));
                    NecklaceFortureAdd.gameObject.SetActive(false);
                    GameController.S.NecklaceFortureAddQueue.Enqueue(NecklaceFortureAdd);

                    GameObject RingFortureAdd =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/RingFortureAdd"));
                    RingFortureAdd.gameObject.SetActive(false);
                    GameController.S.RingFortureAddQueue.Enqueue(RingFortureAdd);

                    GameObject HelmetFortureAdd =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/HelmetFortureAdd"));
                    HelmetFortureAdd.gameObject.SetActive(false);
                    GameController.S.HelmetFortureAddQueue.Enqueue(HelmetFortureAdd);

                }
            }




            /*
            for (int i = 0; i < 200; i++)
        {
            GameObject bloodEnergy = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/BloodEnergy"));
            bloodEnergy.gameObject.SetActive(false);
            GameController.S.BloodEnergyQueue.Enqueue(bloodEnergy);
        }
        */

            for (int i = 0; i < 200; i++)
            {
                GameObject monsterHurtText = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/MonsterHurtText"));
                monsterHurtText.gameObject.SetActive(false);
                GameController.S.MonsterHurtTextQueue.Enqueue(monsterHurtText.GetComponent<MonsterHurtText>());
            }

            if (SkillJiaDian.S.Alpha1 == SkillType.Dian1 || SkillJiaDian.S.Alpha2 == SkillType.Dian1 ||
                SkillJiaDian.S.Alpha3 == SkillType.Dian1|| SkillJiaDian.S.Alpha4 == SkillType.Dian1|| SkillJiaDian.S.Alpha5 == SkillType.Dian1)
            {
                for (int i = 0; i < 10; i++)
                {
                    GameObject dianQuanPeng =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Skill/DianQuan/DianPeng"));
                    dianQuanPeng.gameObject.SetActive(false);
                    GameController.S.DianQuanPengQueue.Enqueue(dianQuanPeng);

                    var dianqian = Instantiate(Resources.Load("Prefabs/Skill/DianQuan/DianQuan"), new Vector3(0, 0, 0),
                        Quaternion.identity) as GameObject;
                    dianqian.SetActive(false);
                    GameController.S.DianQuanQueue.Enqueue(dianqian);
                }
            }

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

            for (int i = 0; i < 100; i++)
            {
                switch (PlayerData.S.playerWeaponType)
                {
                    case WeaponType.Primary:
                        var PuTong31 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/Primary"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        PuTong31.SetActive(false);
                        GameController.S.PrimaryQueue.Enqueue(PuTong31);

                        var PuTong3Peng1 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/PuTongPeng3"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        PuTong3Peng1.SetActive(false);
                        GameController.S.PuTong3PengQueue.Enqueue(PuTong3Peng1);
                        break;
                    case WeaponType.LanBao:
                        var twoNormalAttack = Instantiate(Resources.Load("Prefabs/Skill/2NormalAttackPrefab"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        twoNormalAttack.SetActive(false);
                        GameController.S.LvQuanQueue.Enqueue(twoNormalAttack);
                        break;

                    case WeaponType.HeiDong:
                        var HeiDong = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/HeiDongPro"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        HeiDong.SetActive(false);
                        GameController.S.HeiDongQueue.Enqueue(HeiDong);

                        var HeiDongNext = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/HeiDongNext"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        HeiDongNext.SetActive(false);
                        GameController.S.HeiDongNextQueue.Enqueue(HeiDongNext);

                        var HeiDongPeng = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/HeiDongPeng"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        HeiDongPeng.SetActive(false);
                        GameController.S.HeiDongPengQueue.Enqueue(HeiDongPeng);
                        break;

                    case WeaponType.HuoBaoZha:
                        var Du = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/HuoBaoZha")).GetComponent<HuoBaoZha>();
                        Du.gameObject.SetActive(false);
                        GameController.S.HuoBaoZhaQueue.Enqueue(Du);

                        var DuPeng = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/HuoBaoZhaNext")).GetComponent<HuoYanBaoZhaNext>();
                        DuPeng.gameObject.SetActive(false);
                        GameController.S.HuoYanBaoZhaNextQueue.Enqueue(DuPeng);
                        break;
                    
                    
                    case WeaponType.IceBaoZha:
                        var Du1 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/IceBaoZha")).GetComponent<IceBaoZha>();
                        Du1.gameObject.SetActive(false);
                        GameController.S.IceBaoZhaQueue.Enqueue(Du1);

                        var DuPeng1 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/IceBaoZhaNext")).GetComponent<IceBaoZhaNext>();
                        DuPeng1.gameObject.SetActive(false);
                        GameController.S.IceBaoZhaNextQueue.Enqueue(DuPeng1);
                        break;
                    
                    case WeaponType.DianBaoZha:
                        var Du2 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/DianBaoZha")).GetComponent<DianBaoZha>();
                        Du2.gameObject.SetActive(false);
                        GameController.S.DianBaoZhaQueue.Enqueue(Du2);

                        var DuPeng2 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/DianBaoZhaNext")).GetComponent<DianBaoZhaNext>();
                        DuPeng2.gameObject.SetActive(false);
                        GameController.S.DianBaoZhaNextQueue.Enqueue(DuPeng2);
                        break;

                    case WeaponType.LuoLei:
                        var LuoLei = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/LuoLei"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        LuoLei.SetActive(false);
                        GameController.S.LuoLeiQueue.Enqueue(LuoLei);
                        break;

                    case WeaponType.PuTong3:
                        var PuTong3 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/PuTong3"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        PuTong3.SetActive(false);
                        GameController.S.PuTong3Queue.Enqueue(PuTong3);

                        var PuTong3Peng = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/PuTongPeng3"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        PuTong3Peng.SetActive(false);
                        GameController.S.PuTong3PengQueue.Enqueue(PuTong3Peng);
                        break;

                    case WeaponType.Fire:
                        var FireAttack = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/Fire"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        FireAttack.SetActive(false);
                        GameController.S.FireQueue.Enqueue(FireAttack);

                        var FirePengAttack = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/FirePeng"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        FirePengAttack.SetActive(false);
                        GameController.S.FirePengQueue.Enqueue(FirePengAttack);

                        var FireBaoZha = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/FireBaoZha"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        FireBaoZha.SetActive(false);
                        GameController.S.FireBaoZha1Queue.Enqueue(FireBaoZha);
                        break;

                    case WeaponType.XuKong:
                        var XuKongAttack = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/XuKong"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        XuKongAttack.SetActive(false);
                        GameController.S.XuKongQueue.Enqueue(XuKongAttack);

                        var XuKongPengAttack = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/XuKongPeng"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        XuKongPengAttack.SetActive(false);
                        GameController.S.XuKongPengQueue.Enqueue(XuKongPengAttack);
                        break;

                    case WeaponType.LvQuan:
                        var lvNormalAttack = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/LvQuan"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        lvNormalAttack.SetActive(false);
                        GameController.S.LvQuanQueue.Enqueue(lvNormalAttack);
                        break;

                    case WeaponType.JianQi:
                        var JianQi =
                            Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/PlayerJianQi"), new Vector3(0, 0, 0),
                                Quaternion.identity).GetComponent<PlayerJianQi>();
                        JianQi.gameObject.SetActive(false);
                        GameController.S.PlayerJianQiQueue.Enqueue(JianQi);

                        var zibaozha = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/ZiPeng"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        zibaozha.SetActive(false);
                        GameController.S.ZiBaoZhaQueue.Enqueue(zibaozha);
                        break;

                }
            }

            if (WeaponConfig.WeaponYuanSuTypeDic[PlayerData.S.playerWeaponType] == YuanSuType.Ice ||
                SkillJiaDian.S.Alpha1 == SkillType.Ice1 || SkillJiaDian.S.Alpha1 == SkillType.Ice2 ||
                SkillJiaDian.S.Alpha1 == SkillType.Ice3 || SkillJiaDian.S.Alpha1 == SkillType.Ice4 ||
                SkillJiaDian.S.Alpha1 == SkillType.Ice5
                || SkillJiaDian.S.Alpha2 == SkillType.Ice1 || SkillJiaDian.S.Alpha2 == SkillType.Ice2 ||
                SkillJiaDian.S.Alpha2 == SkillType.Ice3 || SkillJiaDian.S.Alpha2 == SkillType.Ice4 ||
                SkillJiaDian.S.Alpha2 == SkillType.Ice5
                || SkillJiaDian.S.Alpha3 == SkillType.Ice1 || SkillJiaDian.S.Alpha3 == SkillType.Ice2 ||
                SkillJiaDian.S.Alpha3 == SkillType.Ice3 || SkillJiaDian.S.Alpha3 == SkillType.Ice4 ||
                SkillJiaDian.S.Alpha3 == SkillType.Ice5
                || SkillJiaDian.S.Alpha4 == SkillType.Ice1 || SkillJiaDian.S.Alpha4 == SkillType.Ice2 ||
                SkillJiaDian.S.Alpha4 == SkillType.Ice3 || SkillJiaDian.S.Alpha4 == SkillType.Ice4 ||
                SkillJiaDian.S.Alpha4 == SkillType.Ice5
                || SkillJiaDian.S.Alpha5 == SkillType.Ice1 || SkillJiaDian.S.Alpha5 == SkillType.Ice2 ||
                SkillJiaDian.S.Alpha5 == SkillType.Ice3 || SkillJiaDian.S.Alpha5 == SkillType.Ice4 ||
                SkillJiaDian.S.Alpha5 == SkillType.Ice5)
            {
                for (int i = 0; i < 200; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/Peng/IcePeng"));
                    IcePeng.SetActive(false);
                    GameController.S.IcePengQueue.Enqueue(IcePeng);
                }
            }
            
            
            
            if (WeaponConfig.WeaponYuanSuTypeDic[PlayerData.S.playerWeaponType] == YuanSuType.HeiAn ||
                SkillJiaDian.S.Alpha1 == SkillType.HeiAn1 || SkillJiaDian.S.Alpha1 == SkillType.HeiAn2 ||
                SkillJiaDian.S.Alpha1 == SkillType.HeiAn3 || SkillJiaDian.S.Alpha1 == SkillType.HeiAn4 ||
                SkillJiaDian.S.Alpha1 == SkillType.HeiAn5
                || SkillJiaDian.S.Alpha2 == SkillType.HeiAn1 || SkillJiaDian.S.Alpha2 == SkillType.HeiAn2 ||
                SkillJiaDian.S.Alpha2 == SkillType.HeiAn3 || SkillJiaDian.S.Alpha2 == SkillType.HeiAn4 ||
                SkillJiaDian.S.Alpha2 == SkillType.HeiAn5
                || SkillJiaDian.S.Alpha3 == SkillType.HeiAn1 || SkillJiaDian.S.Alpha3 == SkillType.HeiAn2 ||
                SkillJiaDian.S.Alpha3 == SkillType.HeiAn3 || SkillJiaDian.S.Alpha3 == SkillType.HeiAn4 ||
                SkillJiaDian.S.Alpha3 == SkillType.HeiAn5
                || SkillJiaDian.S.Alpha4 == SkillType.HeiAn1 || SkillJiaDian.S.Alpha4 == SkillType.HeiAn2 ||
                SkillJiaDian.S.Alpha4 == SkillType.HeiAn3 || SkillJiaDian.S.Alpha4 == SkillType.HeiAn4 ||
                SkillJiaDian.S.Alpha4 == SkillType.HeiAn5
                || SkillJiaDian.S.Alpha5 == SkillType.HeiAn1 || SkillJiaDian.S.Alpha5 == SkillType.HeiAn2 ||
                SkillJiaDian.S.Alpha5 == SkillType.HeiAn3 || SkillJiaDian.S.Alpha5 == SkillType.HeiAn4 ||
                SkillJiaDian.S.Alpha5 == SkillType.HeiAn5)
            {
                for (int i = 0; i < 200; i++)
                {
                    var HeiAnPeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/Peng/HeiAnPeng"));
                    HeiAnPeng.SetActive(false);
                    GameController.S.HeiAnPengQueue.Enqueue(HeiAnPeng);
                }
            }
            
            
            
            if (WeaponConfig.WeaponYuanSuTypeDic[PlayerData.S.playerWeaponType] == YuanSuType.Huo ||
                SkillJiaDian.S.Alpha1 == SkillType.Huo1 || SkillJiaDian.S.Alpha1 == SkillType.Huo2 ||
                SkillJiaDian.S.Alpha1 == SkillType.Huo3 || SkillJiaDian.S.Alpha1 == SkillType.Huo4 ||
                SkillJiaDian.S.Alpha1 == SkillType.Huo5
                || SkillJiaDian.S.Alpha2 == SkillType.Huo1 || SkillJiaDian.S.Alpha2 == SkillType.Huo2 ||
                SkillJiaDian.S.Alpha2 == SkillType.Huo3 || SkillJiaDian.S.Alpha2 == SkillType.Huo4 ||
                SkillJiaDian.S.Alpha2 == SkillType.Huo5
                || SkillJiaDian.S.Alpha3 == SkillType.Huo1 || SkillJiaDian.S.Alpha3 == SkillType.Huo2 ||
                SkillJiaDian.S.Alpha3 == SkillType.Huo3 || SkillJiaDian.S.Alpha3 == SkillType.Huo4 ||
                SkillJiaDian.S.Alpha3 == SkillType.Huo5
                || SkillJiaDian.S.Alpha4 == SkillType.Huo1 || SkillJiaDian.S.Alpha4 == SkillType.Huo2 ||
                SkillJiaDian.S.Alpha4 == SkillType.Huo3 || SkillJiaDian.S.Alpha4 == SkillType.Huo4 ||
                SkillJiaDian.S.Alpha4 == SkillType.Huo5
                || SkillJiaDian.S.Alpha5 == SkillType.Huo1 || SkillJiaDian.S.Alpha5 == SkillType.Huo2 ||
                SkillJiaDian.S.Alpha5 == SkillType.Huo3 || SkillJiaDian.S.Alpha5 == SkillType.Huo4 ||
                SkillJiaDian.S.Alpha5 == SkillType.Huo5)
            {
                for (int i = 0; i < 200; i++)
                {
                    var HuoPeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/Peng/HuoPeng"));
                    HuoPeng.SetActive(false);
                    GameController.S.HuoPengQueue.Enqueue(HuoPeng);
                }
            }
            
            
            if (WeaponConfig.WeaponYuanSuTypeDic[PlayerData.S.playerWeaponType] == YuanSuType.Dian ||
                SkillJiaDian.S.Alpha1 == SkillType.Dian1 || SkillJiaDian.S.Alpha1 == SkillType.Dian2 ||
                SkillJiaDian.S.Alpha1 == SkillType.Dian3 || SkillJiaDian.S.Alpha1 == SkillType.Dian4 ||
                SkillJiaDian.S.Alpha1 == SkillType.Dian5
                || SkillJiaDian.S.Alpha2 == SkillType.Dian1 || SkillJiaDian.S.Alpha2 == SkillType.Dian2 ||
                SkillJiaDian.S.Alpha2 == SkillType.Dian3 || SkillJiaDian.S.Alpha2 == SkillType.Dian4 ||
                SkillJiaDian.S.Alpha2 == SkillType.Dian5
                || SkillJiaDian.S.Alpha3 == SkillType.Dian1 || SkillJiaDian.S.Alpha3 == SkillType.Dian2 ||
                SkillJiaDian.S.Alpha3 == SkillType.Dian3 || SkillJiaDian.S.Alpha3 == SkillType.Dian4 ||
                SkillJiaDian.S.Alpha3 == SkillType.Dian5
                || SkillJiaDian.S.Alpha4 == SkillType.Dian1 || SkillJiaDian.S.Alpha4 == SkillType.Dian2 ||
                SkillJiaDian.S.Alpha4 == SkillType.Dian3 || SkillJiaDian.S.Alpha4 == SkillType.Dian4 ||
                SkillJiaDian.S.Alpha4 == SkillType.Dian5
                || SkillJiaDian.S.Alpha5 == SkillType.Dian1 || SkillJiaDian.S.Alpha5 == SkillType.Dian2 ||
                SkillJiaDian.S.Alpha5 == SkillType.Dian3 || SkillJiaDian.S.Alpha5 == SkillType.Dian4 ||
                SkillJiaDian.S.Alpha5 == SkillType.Dian5)
            {
                for (int i = 0; i < 200; i++)
                {
                    var DianPeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/Peng/DianPeng"));
                    DianPeng.SetActive(false);
                    GameController.S.DianPengQueue.Enqueue(DianPeng);
                }
            }
            


            if (PlayerData.S.playerWeaponType == WeaponType.HeiAnBaoZha)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HeiAnBaoZha"));
                    IcePeng.SetActive(false);
                    GameController.S.HeiAnBaoZhaQueue.Enqueue(IcePeng);
                    var IcePeng1 =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HeiAnBaoZhaNext"));
                    IcePeng1.SetActive(false);
                    GameController.S.HeiAnBaoZhaNextQueue.Enqueue(IcePeng1);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.Huo7)
            {
                for (int i = 0; i < 100; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/Huo7Item").GetComponent<Huo7Item>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.Huo7Queue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.Ice7)
            {
                for (int i = 0; i < 100; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/Ice7Item").GetComponent<Ice7Item>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.Ice7Queue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.DianLuoLei5)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/DianLuoLei").GetComponent<DianLuoLei>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.DianLuoLeiQueue.Enqueue(IcePeng);
                    
                    var IcePeng1 = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/DianLuoLeiNext").GetComponent<DianLuoLeiNext>());
                    IcePeng1.gameObject.SetActive(false);
                    GameController.S.DianLuoLeiNextQueue.Enqueue(IcePeng1);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.PrimaryDian)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/PrimaryDian").GetComponent<PrimaryDian>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.PrimaryDianQueue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.PrimaryHuo)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/PrimaryHuo").GetComponent<PrimaryHuo>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.PrimaryHuoQueue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.PrimaryHeiAn)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/PrimaryHeiAn").GetComponent<PrimaryHeiAn>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.PrimaryHeiAnQueue.Enqueue(IcePeng);
                }
            }
            
            
            
            
            if (PlayerData.S.playerWeaponType == WeaponType.IcePen)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/IcePen").GetComponent<IcePen>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.IcePenQueue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.HuoFenLie)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HuoFenLie").GetComponent<HuoFenLie>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.HuoFenLieQueue.Enqueue(IcePeng);
                    var IcePeng1 = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HuoFenLieDan").GetComponent<HuoFenLieDan>());
                    IcePeng1.gameObject.SetActive(false);
                    GameController.S.HuoFenLieDanQueue.Enqueue(IcePeng1);
                    var IcePeng2 = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HuoFenLieBaoZha").GetComponent<HuoFenLieBaoZha>());
                    IcePeng2.gameObject.SetActive(false);
                    GameController.S.HuoFenLieBaoZhaQueue.Enqueue(IcePeng2);

                }
            }
            
            
            if (PlayerData.S.playerWeaponType == WeaponType.Ice4BaoZha)
            {
                for (int i = 0; i < 50; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/Ice4BaoZha").GetComponent<Ice4BaoZha>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.Ice4BaoZhaQueue.Enqueue(IcePeng);
                    var IcePeng1 = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/Ice4BaoZhaItem").GetComponent<Ice4BaoZhaItem>());
                    IcePeng1.gameObject.SetActive(false);
                    GameController.S.Ice4BaoZhaItemQueue.Enqueue(IcePeng1);
                }
            }
            
            
            if (PlayerData.S.playerWeaponType == WeaponType.DianJiSu)
            {
                for (int i = 0; i < 50; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/DianJiSu").GetComponent<DianJiSu>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.DianJiSuQueue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.HeiAnHuiXuan)
            {
                for (int i = 0; i < 50; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HeiAnHuiXuan").GetComponent<HeiAnHuiXuan>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.HeiAnHuiXuanQueue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.HuoDiPen)
            {
                for (int i = 0; i < 50; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HuoDiPen").GetComponent<HuoDiPen>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.HuoDiPenQueue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.HeiAnQuXian)
            {
                for (int i = 0; i < 50; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HeiAnQuXian").GetComponent<HuoQuXian>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.HeiAnQuXianQueue.Enqueue(IcePeng);
                }
            }

            
            

            FightBGController.S.DiLie = Instantiate(Resources.Load("Prefabs/Skill/BossGroundFissure"),
                new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            FightBGController.S.DiLie.SetActive(false);

            FightBGController.S.CircleAttack =
                Instantiate(Resources.Load<GameObject>("Prefabs/Tool/CircleAttack")).gameObject;
            FightBGController.S.CircleAttack.SetActive(false);

            //初始化怪物队列

            for (int i = 0; i < 100; i++)
{
    var baoxue = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/BaoXue").GetComponent<BaoXue>(), GameController.S.transform);
    baoxue.gameObject.SetActive(false);
    GameController.S.BaoXueQueue.Enqueue(baoxue);
    
    var dazongxiong = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/dazongxiong").GetComponent<dazongxiong>(), GameController.S.transform);
    dazongxiong.gameObject.SetActive(false);
    GameController.S.dazongxiongQueue.Enqueue(dazongxiong);
    MonsterBase dazongxiongmonsterBase = dazongxiong.GetComponent<MonsterBase>();
    Collider2D dazongxiong2D = dazongxiongmonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(dazongxiong2D, dazongxiongmonsterBase);
    
    var lujiaodoushi = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/lujiaodoushi").GetComponent<lujiaodoushi>(), GameController.S.transform);
    lujiaodoushi.gameObject.SetActive(false);
    GameController.S.lujiaodoushiQueue.Enqueue(lujiaodoushi);
    MonsterBase lujiaodoushimonsterBase = lujiaodoushi.GetComponent<MonsterBase>();
    Collider2D lujiaodoushi2D = lujiaodoushimonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(lujiaodoushi2D, lujiaodoushimonsterBase);
    
    var kuangshimuzhu = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/kuangshimuzhu").GetComponent<kuangshimuzhu>(), GameController.S.transform);
    kuangshimuzhu.gameObject.SetActive(false);
    GameController.S.kuangshimuzhuQueue.Enqueue(kuangshimuzhu);
    MonsterBase kuangshimuzhumonsterBase = kuangshimuzhu.GetComponent<MonsterBase>();
    Collider2D kuangshimuzhu2D = kuangshimuzhumonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(kuangshimuzhu2D, kuangshimuzhumonsterBase);
    
    var fengheguai = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/fengheguai").GetComponent<fengheguai>(), GameController.S.transform);
    fengheguai.gameObject.SetActive(false);
    GameController.S.fengheguaiQueue.Enqueue(fengheguai);
    MonsterBase fengheguaimonsterBase = fengheguai.GetComponent<MonsterBase>();
    Collider2D fengheguai2D = fengheguaimonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(fengheguai2D, fengheguaimonsterBase);
    
    var shuangtouren = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/shuangtouren").GetComponent<shuangtouren>(), GameController.S.transform);
    shuangtouren.gameObject.SetActive(false);
    GameController.S.shuangtourenQueue.Enqueue(shuangtouren);
    MonsterBase shuangtourenmonsterBase = shuangtouren.GetComponent<MonsterBase>();
    Collider2D shuangtouren2D = shuangtourenmonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(shuangtouren2D, shuangtourenmonsterBase);
    
    var daocaoren = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/daocaoren").GetComponent<daocaoren>(), GameController.S.transform);
    daocaoren.gameObject.SetActive(false);
    GameController.S.daocaorenQueue.Enqueue(daocaoren);
    MonsterBase daocaorenmonsterBase = daocaoren.GetComponent<MonsterBase>();
    Collider2D daocaoren2D = daocaorenmonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(daocaoren2D, daocaorenmonsterBase);
    
    var cizhu = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/cizhu").GetComponent<cizhu>(), GameController.S.transform);
    cizhu.gameObject.SetActive(false);
    GameController.S.cizhuQueue.Enqueue(cizhu);
    MonsterBase cizhumonsterBase = cizhu.GetComponent<MonsterBase>();
    Collider2D cizhu2D = cizhumonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(cizhu2D, cizhumonsterBase);
    
    
    var chailangren1 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/chailangren1").GetComponent<chailangren1>(), GameController.S.transform);
    chailangren1.gameObject.SetActive(false);
    GameController.S.chailangren1Queue.Enqueue(chailangren1);
    MonsterBase chailangren1monsterBase = chailangren1.GetComponent<MonsterBase>();
    Collider2D chailangren12D = chailangren1monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(chailangren12D, chailangren1monsterBase);

    var chailangren2 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/chailangren2").GetComponent<chailangren2>(), GameController.S.transform);
    chailangren2.gameObject.SetActive(false);
    GameController.S.chailangren2Queue.Enqueue(chailangren2);
    MonsterBase chailangren2monsterBase = chailangren2.GetComponent<MonsterBase>();
    Collider2D chailangren22D = chailangren2monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(chailangren22D, chailangren2monsterBase);

    var chailangren3 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/chailangren3").GetComponent<chailangren3>(), GameController.S.transform);
    chailangren3.gameObject.SetActive(false);
    GameController.S.chailangren3Queue.Enqueue(chailangren3);
    MonsterBase chailangren3monsterBase = chailangren3.GetComponent<MonsterBase>();
    Collider2D chailangren32D = chailangren3monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(chailangren32D, chailangren3monsterBase);

    var chailangren4 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/chailangren4").GetComponent<chailangren4>(), GameController.S.transform);
    chailangren4.gameObject.SetActive(false);
    GameController.S.chailangren4Queue.Enqueue(chailangren4);
    MonsterBase chailangren4monsterBase = chailangren4.GetComponent<MonsterBase>();
    Collider2D chailangren42D = chailangren4monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(chailangren42D, chailangren4monsterBase);

    var YeShouZhanShi = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/YeShouZhanShi").GetComponent<YeShouZhanShi>(), GameController.S.transform);
    YeShouZhanShi.gameObject.SetActive(false);
    GameController.S.YeShouZhanShiQueue.Enqueue(YeShouZhanShi);
    MonsterBase YeShouZhanShimonsterBase = YeShouZhanShi.GetComponent<MonsterBase>();
    Collider2D YeShouZhanShi2D = YeShouZhanShimonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(YeShouZhanShi2D, YeShouZhanShimonsterBase);

    var ZhiZhuNvWang = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/ZhiZhuNvWang").GetComponent<ZhiZhuNvWang>(), GameController.S.transform);
    ZhiZhuNvWang.gameObject.SetActive(false);
    GameController.S.ZhiZhuNvWangQueue.Enqueue(ZhiZhuNvWang);
    MonsterBase ZhiZhuNvWangmonsterBase = ZhiZhuNvWang.GetComponent<MonsterBase>();
    Collider2D ZhiZhuNvWang2D = ZhiZhuNvWangmonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(ZhiZhuNvWang2D, ZhiZhuNvWangmonsterBase);

    var dijing2 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijing2").GetComponent<dijing2>(), GameController.S.transform);
    dijing2.gameObject.SetActive(false);
    GameController.S.dijing2Queue.Enqueue(dijing2);
    MonsterBase dijing2monsterBase = dijing2.GetComponent<MonsterBase>();
    Collider2D dijing22D = dijing2monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(dijing22D, dijing2monsterBase);

    var dijing3 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijing3").GetComponent<dijing3>(), GameController.S.transform);
    dijing3.gameObject.SetActive(false);
    GameController.S.dijing3Queue.Enqueue(dijing3);
    MonsterBase dijing3monsterBase = dijing3.GetComponent<MonsterBase>();
    Collider2D dijing32D = dijing3monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(dijing32D, dijing3monsterBase);

    var dijingshouwei1 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijingshouwei1").GetComponent<dijingshouwei1>(), GameController.S.transform);
    dijingshouwei1.gameObject.SetActive(false);
    GameController.S.dijingshouwei1Queue.Enqueue(dijingshouwei1);
    MonsterBase dijingshouwei1monsterBase = dijingshouwei1.GetComponent<MonsterBase>();
    Collider2D dijingshouwei12D = dijingshouwei1monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(dijingshouwei12D, dijingshouwei1monsterBase);

    var dijingshouwei2 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijingshouwei2").GetComponent<dijingshouwei2>(), GameController.S.transform);
    dijingshouwei2.gameObject.SetActive(false);
    GameController.S.dijingshouwei2Queue.Enqueue(dijingshouwei2);
    MonsterBase dijingshouwei2monsterBase = dijingshouwei2.GetComponent<MonsterBase>();
    Collider2D dijingshouwei22D = dijingshouwei2monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(dijingshouwei22D, dijingshouwei2monsterBase);

    var dijingshouwei3 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijingshouwei3").GetComponent<dijingshouwei3>(), GameController.S.transform);
    dijingshouwei3.gameObject.SetActive(false);
    GameController.S.dijingshouwei3Queue.Enqueue(dijingshouwei3);
    MonsterBase dijingshouwei3monsterBase = dijingshouwei3.GetComponent<MonsterBase>();
    Collider2D dijingshouwei32D = dijingshouwei3monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(dijingshouwei32D, dijingshouwei3monsterBase);

    var heixiong = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/heixiong").GetComponent<heixiong>(), GameController.S.transform);
    heixiong.gameObject.SetActive(false);
    GameController.S.heixiongQueue.Enqueue(heixiong);
    MonsterBase heixiongmonsterBase = heixiong.GetComponent<MonsterBase>();
    Collider2D heixiong2D = heixiongmonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(heixiong2D, heixiongmonsterBase);

    var jianchizhu = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/jianchizhu").GetComponent<jianchizhu>(), GameController.S.transform);
    jianchizhu.gameObject.SetActive(false);
    GameController.S.jianchizhuQueue.Enqueue(jianchizhu);
    MonsterBase jianchizhumonsterBase = jianchizhu.GetComponent<MonsterBase>();
    Collider2D jianchizhu2D = jianchizhumonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(jianchizhu2D, jianchizhumonsterBase);

    var kulou1 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou1").GetComponent<kulou1>(), GameController.S.transform);
    kulou1.gameObject.SetActive(false);
    GameController.S.kulou1Queue.Enqueue(kulou1);
    MonsterBase kulou1monsterBase = kulou1.GetComponent<MonsterBase>();
    Collider2D kulou12D = kulou1monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(kulou12D, kulou1monsterBase);

    var kulou2 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou2").GetComponent<kulou2>(), GameController.S.transform);
    kulou2.gameObject.SetActive(false);
    GameController.S.kulou2Queue.Enqueue(kulou2);
    MonsterBase kulou2monsterBase = kulou2.GetComponent<MonsterBase>();
    Collider2D kulou22D = kulou2monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(kulou22D, kulou2monsterBase);

    var kulou3 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou3").GetComponent<kulou3>(), GameController.S.transform);
    kulou3.gameObject.SetActive(false);
    GameController.S.kulou3Queue.Enqueue(kulou3);
    MonsterBase kulou3monsterBase = kulou3.GetComponent<MonsterBase>();
    Collider2D kulou32D = kulou3monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(kulou32D, kulou3monsterBase);

    var kulou4 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou4").GetComponent<kulou4>(), GameController.S.transform);
    kulou4.gameObject.SetActive(false);
    GameController.S.kulou4Queue.Enqueue(kulou4);
    MonsterBase kulou4monsterBase = kulou4.GetComponent<MonsterBase>();
    Collider2D kulou42D = kulou4monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(kulou42D, kulou4monsterBase);

    var kulou5 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou5").GetComponent<kulou5>(), GameController.S.transform);
    kulou5.gameObject.SetActive(false);
    GameController.S.kulou5Queue.Enqueue(kulou5);
    MonsterBase kulou5monsterBase = kulou5.GetComponent<MonsterBase>();
    Collider2D kulou52D = kulou5monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(kulou52D, kulou5monsterBase);

    var kulou6 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou6").GetComponent<kulou6>(), GameController.S.transform);
    kulou6.gameObject.SetActive(false);
    GameController.S.kulou6Queue.Enqueue(kulou6);
    MonsterBase kulou6monsterBase = kulou6.GetComponent<MonsterBase>();
    Collider2D kulou62D = kulou6monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(kulou62D, kulou6monsterBase);

    var lujiaocike = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/lujiaocike").GetComponent<lujiaocike>(), GameController.S.transform);
    lujiaocike.gameObject.SetActive(false);
    GameController.S.lujiaocikeQueue.Enqueue(lujiaocike);
    MonsterBase lujiaocikemonsterBase = lujiaocike.GetComponent<MonsterBase>();
    Collider2D lujiaocike2D = lujiaocikemonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(lujiaocike2D, lujiaocikemonsterBase);

    var lujiaocike2 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/lujiaocike2").GetComponent<lujiaocike2>(), GameController.S.transform);
    lujiaocike2.gameObject.SetActive(false);
    GameController.S.lujiaocike2Queue.Enqueue(lujiaocike2);
    MonsterBase lujiaocike2monsterBase = lujiaocike2.GetComponent<MonsterBase>();
    Collider2D lujiaocike22D = lujiaocike2monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(lujiaocike22D, lujiaocike2monsterBase);

    var niutouren1 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/niutouren1").GetComponent<niutouren1>(), GameController.S.transform);
    niutouren1.gameObject.SetActive(false);
    GameController.S.niutouren1Queue.Enqueue(niutouren1);
    MonsterBase niutouren1monsterBase = niutouren1.GetComponent<MonsterBase>();
    Collider2D niutouren12D = niutouren1monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(niutouren12D, niutouren1monsterBase);

    var niutouren2 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/niutouren2").GetComponent<niutouren2>(), GameController.S.transform);
    niutouren2.gameObject.SetActive(false);
    GameController.S.niutouren2Queue.Enqueue(niutouren2);
    MonsterBase niutouren2monsterBase = niutouren2.GetComponent<MonsterBase>();
    Collider2D niutouren22D = niutouren2monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(niutouren22D, niutouren2monsterBase);

    var niutouren3 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/niutouren3").GetComponent<niutouren3>(), GameController.S.transform);
    niutouren3.gameObject.SetActive(false);
    GameController.S.niutouren3Queue.Enqueue(niutouren3);
    MonsterBase niutouren3monsterBase = niutouren3.GetComponent<MonsterBase>();
    Collider2D niutouren32D = niutouren3monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(niutouren32D, niutouren3monsterBase);

    var shanzei3 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shanzei3").GetComponent<shanzei3>(), GameController.S.transform);
    shanzei3.gameObject.SetActive(false);
    GameController.S.shanzei3Queue.Enqueue(shanzei3);
    MonsterBase shanzei3monsterBase = shanzei3.GetComponent<MonsterBase>();
    Collider2D shanzei32D = shanzei3monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(shanzei32D, shanzei3monsterBase);

    var shijiachong = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shijiachong").GetComponent<shijiachong>(), GameController.S.transform);
    shijiachong.gameObject.SetActive(false);
    GameController.S.shijiachongQueue.Enqueue(shijiachong);
    MonsterBase shijiachongmonsterBase = shijiachong.GetComponent<MonsterBase>();
    Collider2D shijiachong2D = shijiachongmonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(shijiachong2D, shijiachongmonsterBase);

    var shishigui = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shishigui").GetComponent<shishigui>(), GameController.S.transform);
    shishigui.gameObject.SetActive(false);
    GameController.S.shishiguiQueue.Enqueue(shishigui);
    MonsterBase shishiguimonsterBase = shishigui.GetComponent<MonsterBase>();
    Collider2D shishigui2D = shishiguimonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(shishigui2D, shishiguimonsterBase);

    var shixianggui = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shixianggui").GetComponent<shixianggui>(), GameController.S.transform);
    shixianggui.gameObject.SetActive(false);
    GameController.S.shixiangguiQueue.Enqueue(shixianggui);
    MonsterBase shixiangguimonsterBase = shixianggui.GetComponent<MonsterBase>();
    Collider2D shixianggui2D = shixiangguimonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(shixianggui2D, shixiangguimonsterBase);

    var shouren1 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shouren1").GetComponent<shouren1>(), GameController.S.transform);
    shouren1.gameObject.SetActive(false);
    GameController.S.shouren1Queue.Enqueue(shouren1);
    MonsterBase shouren1monsterBase = shouren1.GetComponent<MonsterBase>();
    Collider2D shouren12D = shouren1monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(shouren12D, shouren1monsterBase);

    var shouren2 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shouren2").GetComponent<shouren2>(), GameController.S.transform);
    shouren2.gameObject.SetActive(false);
    GameController.S.shouren2Queue.Enqueue(shouren2);
    MonsterBase shouren2monsterBase = shouren2.GetComponent<MonsterBase>();
    Collider2D shouren22D = shouren2monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(shouren22D, shouren2monsterBase);

    var shouren3 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shouren3").GetComponent<shouren3>(), GameController.S.transform);
    shouren3.gameObject.SetActive(false);
    GameController.S.shouren3Queue.Enqueue(shouren3);
    MonsterBase shouren3monsterBase = shouren3.GetComponent<MonsterBase>();
    Collider2D shouren32D = shouren3monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(shouren32D, shouren3monsterBase);

    var shuangtoulong = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shuangtoulong").GetComponent<shuangtoulong>(), GameController.S.transform);
    shuangtoulong.gameObject.SetActive(false);
    GameController.S.shuangtoulongQueue.Enqueue(shuangtoulong);
    MonsterBase shuangtoulongmonsterBase = shuangtoulong.GetComponent<MonsterBase>();
    Collider2D shuangtoulong2D = shuangtoulongmonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(shuangtoulong2D, shuangtoulongmonsterBase);

    var shuangtoulong2 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shuangtoulong2").GetComponent<shuangtoulong2>(), GameController.S.transform);
    shuangtoulong2.gameObject.SetActive(false);
    GameController.S.shuangtoulong2Queue.Enqueue(shuangtoulong2);
    MonsterBase shuangtoulong2monsterBase = shuangtoulong2.GetComponent<MonsterBase>();
    Collider2D shuangtoulong22D = shuangtoulong2monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(shuangtoulong22D, shuangtoulong2monsterBase);

    var shuangtoulong3 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shuangtoulong3").GetComponent<shuangtoulong3>(), GameController.S.transform);
    shuangtoulong3.gameObject.SetActive(false);
    GameController.S.shuangtoulong3Queue.Enqueue(shuangtoulong3);
    MonsterBase shuangtoulong3monsterBase = shuangtoulong3.GetComponent<MonsterBase>();
    Collider2D shuangtoulong32D = shuangtoulong3monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(shuangtoulong32D, shuangtoulong3monsterBase);

    var tujiu = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/tujiu").GetComponent<tujiu>(), GameController.S.transform);
    tujiu.gameObject.SetActive(false);
    GameController.S.tujiuQueue.Enqueue(tujiu);
    MonsterBase tujiumonsterBase = tujiu.GetComponent<MonsterBase>();
    Collider2D tujiu2D = tujiumonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(tujiu2D, tujiumonsterBase);

    var wuya = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/wuya").GetComponent<wuya>(), GameController.S.transform);
    wuya.gameObject.SetActive(false);
    GameController.S.wuyaQueue.Enqueue(wuya);
    MonsterBase wuyamonsterBase = wuya.GetComponent<MonsterBase>();
    Collider2D wuya2D = wuyamonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(wuya2D, wuyamonsterBase);

    var youhunlingzhu = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/youhunlingzhu").GetComponent<youhunlingzhu>(), GameController.S.transform);
    youhunlingzhu.gameObject.SetActive(false);
    GameController.S.youhunlingzhuQueue.Enqueue(youhunlingzhu);
    MonsterBase youhunlingzhumonsterBase = youhunlingzhu.GetComponent<MonsterBase>();
    Collider2D youhunlingzhu2D = youhunlingzhumonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(youhunlingzhu2D, youhunlingzhumonsterBase);

    var youlang = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/youlang").GetComponent<youlang>(), GameController.S.transform);
    youlang.gameObject.SetActive(false);
    GameController.S.youlangQueue.Enqueue(youlang);
    MonsterBase youlangmonsterBase = youlang.GetComponent<MonsterBase>();
    Collider2D youlang2D = youlangmonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(youlang2D, youlangmonsterBase);

    var youling = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/youling").GetComponent<youling>(), GameController.S.transform);
    youling.gameObject.SetActive(false);
    GameController.S.youlingQueue.Enqueue(youling);
    MonsterBase youlingmonsterBase = youling.GetComponent<MonsterBase>();
    Collider2D youling2D = youlingmonsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(youling2D, youlingmonsterBase);

    var youling2 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/youling2").GetComponent<youling2>(), GameController.S.transform);
    youling2.gameObject.SetActive(false);
    GameController.S.youling2Queue.Enqueue(youling2);
    MonsterBase youling2monsterBase = youling2.GetComponent<MonsterBase>();
    Collider2D youling22D = youling2monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(youling22D, youling2monsterBase);

    var yuren1 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/yuren1").GetComponent<yuren1>(), GameController.S.transform);
    yuren1.gameObject.SetActive(false);
    GameController.S.yuren1Queue.Enqueue(yuren1);
    MonsterBase yuren1monsterBase = yuren1.GetComponent<MonsterBase>();
    Collider2D yuren12D = yuren1monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(yuren12D, yuren1monsterBase);

    var yuren2 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/yuren2").GetComponent<yuren2>(), GameController.S.transform);
    yuren2.gameObject.SetActive(false);
    GameController.S.yuren2Queue.Enqueue(yuren2);
    MonsterBase yuren2monsterBase = yuren2.GetComponent<MonsterBase>();
    Collider2D yuren22D = yuren2monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(yuren22D, yuren2monsterBase);

    var yuren3 = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/yuren3").GetComponent<yuren3>(), GameController.S.transform);
    yuren3.gameObject.SetActive(false);
    GameController.S.yuren3Queue.Enqueue(yuren3);
    MonsterBase yuren3monsterBase = yuren3.GetComponent<MonsterBase>();
    Collider2D yuren32D = yuren3monsterBase.collider2D;
    GameController.S.MonsterColliderDic.Add(yuren32D, yuren3monsterBase);
}
            
            
            if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 ||
                LevelInfoConfig.CurrentGameLevel == 3)
            {
                for (int i = 0; i < 100; i++)
                {
                    var snotMonster =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level1/SnotMonster")
                                .GetComponent<SnotMonster>(), GameController.S.transform);
                    snotMonster.gameObject.SetActive(false);
                    GameController.S.SnotMonsterQueue.Enqueue(snotMonster);

                    var batMonster =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level1/BatMonster").GetComponent<BatMonster>(),
                            GameController.S.transform);
                    batMonster.gameObject.SetActive(false);
                    GameController.S.BatMonsterQueue.Enqueue(batMonster);


                    var beeBullet = Instantiate(Resources.Load<BeeBullet>("Prefabs/Monster/Level1/BeeBullet"),
                        GameController.S.transform);
                    beeBullet.gameObject.SetActive(false);
                    GameController.S.BeeBulletQueue.Enqueue(beeBullet.GetComponent<BeeBullet>());

                    var spiderMonster =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level1/SpiderMonster")
                                .GetComponent<SpiderMonster>(),
                            GameController.S.transform);
                    spiderMonster.gameObject.SetActive(false);
                    GameController.S.SpiderMonsterQueue.Enqueue(spiderMonster);

                    Collider2D spidercollider2D = spiderMonster.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(spidercollider2D,
                        spiderMonster.GetComponent<MonsterBase>());

                    Collider2D batcollider2D = batMonster.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(batcollider2D, batMonster.GetComponent<MonsterBase>());

                    Collider2D snotcollider2D = snotMonster.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(snotcollider2D, snotMonster.GetComponent<MonsterBase>());
                }
            }


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
                for (int i = 0; i < 10; i++)
                {
                    var jianqi =
                        Instantiate(Resources.Load<HuoShanJianQi>("Prefabs/Monster/Level2/HuoShanJianQi"),
                            GameController.S.transform);
                    jianqi.gameObject.SetActive(false);
                    GameController.S.HuoShanJianQiQueue.Enqueue(jianqi);
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




            if (LevelInfoConfig.CurrentGameLevel == 4 || LevelInfoConfig.CurrentGameLevel == 5 ||
                LevelInfoConfig.CurrentGameLevel == 6)
            {
                for (int i = 0; i < 100; i++)
                {

                    var chongziMonster =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level2/ChongZiMonster")
                                .GetComponent<ChongZiMonster>(),
                            GameController.S.transform);
                    chongziMonster.gameObject.SetActive(false);
                    GameController.S.ChongZiMonsterQueue.Enqueue(chongziMonster.GetComponent<ChongZiMonster>());

                    var XiNiuMonster =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level2/XiNiuMonster")
                                .GetComponent<XiNiuMonster>(),
                            GameController.S.transform);
                    XiNiuMonster.gameObject.SetActive(false);
                    GameController.S.XiNiuMonsterQueue.Enqueue(XiNiuMonster.GetComponent<XiNiuMonster>());

                    var xiaohuoMonster =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level2/XiaoHuoMonster")
                                .GetComponent<XiaoHuoMonster>(),
                            GameController.S.transform);
                    xiaohuoMonster.gameObject.SetActive(false);
                    GameController.S.XiaoHuoMonsterQueue.Enqueue(xiaohuoMonster.GetComponent<XiaoHuoMonster>());

                    var dundiMonster =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level2/DunDiMonster")
                                .GetComponent<DunDiMonster>(),
                            GameController.S.transform);
                    dundiMonster.gameObject.SetActive(false);
                    GameController.S.DunDiMonsterQueue.Enqueue(dundiMonster.GetComponent<DunDiMonster>());


                    Collider2D chongzicollider2D = chongziMonster.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(chongzicollider2D,
                        chongziMonster.GetComponent<MonsterBase>());

                    Collider2D xiaohuocollider2D = xiaohuoMonster.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(xiaohuocollider2D,
                        xiaohuoMonster.GetComponent<MonsterBase>());

                    Collider2D XiNiucollider2D = XiNiuMonster.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(XiNiucollider2D, XiNiuMonster.GetComponent<MonsterBase>());

                    Collider2D dundicollider2D = dundiMonster.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(dundicollider2D, dundiMonster.GetComponent<MonsterBase>());

                }
            }


            if (LevelInfoConfig.CurrentGameLevel == 7 || LevelInfoConfig.CurrentGameLevel == 8 ||
                LevelInfoConfig.CurrentGameLevel == 9)
            {
                for (int i = 0; i < 100; i++)
                {
                    var jiachongMonster =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level3/JiaChongMonster")
                                .GetComponent<JiaChongMonster>(),
                            GameController.S.transform);
                    jiachongMonster.gameObject.SetActive(false);
                    GameController.S.JiaChongMonsterQueue.Enqueue(jiachongMonster.GetComponent<JiaChongMonster>());


                    var wenziMonster =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level3/WenZiMonster")
                                .GetComponent<WenZiMonster>(),
                            GameController.S.transform);
                    wenziMonster.gameObject.SetActive(false);
                    GameController.S.WenZiMonsterQueue.Enqueue(wenziMonster.GetComponent<WenZiMonster>());

                    var qingwaMonster =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level3/QingWaMonster")
                                .GetComponent<QingWaMonster>(),
                            GameController.S.transform);
                    qingwaMonster.gameObject.SetActive(false);
                    GameController.S.QingWaMonsterQueue.Enqueue(qingwaMonster.GetComponent<QingWaMonster>());


                    Collider2D jiachongcollider2D =
                        jiachongMonster.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(jiachongcollider2D,
                        jiachongMonster.GetComponent<MonsterBase>());

                    Collider2D wenzicollider2D = wenziMonster.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(wenzicollider2D, wenziMonster.GetComponent<MonsterBase>());

                    Collider2D qingwacollider2D = qingwaMonster.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(qingwacollider2D,
                        qingwaMonster.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 10 || LevelInfoConfig.CurrentGameLevel == 11 ||
                LevelInfoConfig.CurrentGameLevel == 12)
            {
                for (int i = 0; i < 100; i++)
                {

                    var KuLou = Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level4/KuLouMonster").GetComponent<KuLou>(),
                        GameController.S.transform);
                    KuLou.gameObject.SetActive(false);
                    GameController.S.KuLouQueue.Enqueue(KuLou.GetComponent<KuLou>());

                    var ShaChong =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaChong").GetComponent<ShaChong>(),
                            GameController.S.transform);
                    ShaChong.gameObject.SetActive(false);
                    GameController.S.ShaChongQueue.Enqueue(ShaChong.GetComponent<ShaChong>());

                    var ShaNiao =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaNiao").GetComponent<ShaNiao>(),
                            GameController.S.transform);
                    ShaNiao.gameObject.SetActive(false);
                    GameController.S.ShaNiaoQueue.Enqueue(ShaNiao.GetComponent<ShaNiao>());

                    var XianRenZhang =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level4/XianRenZhang")
                                .GetComponent<XianRenZhang>(), GameController.S.transform);
                    XianRenZhang.gameObject.SetActive(false);
                    GameController.S.XianRenZhangQueue.Enqueue(XianRenZhang.GetComponent<XianRenZhang>());

                    Collider2D KuLoucollider2D =KuLou.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(KuLoucollider2D, KuLou.GetComponent<MonsterBase>());

                    Collider2D ShaChongcollider2D = ShaChong.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(ShaChongcollider2D, ShaChong.GetComponent<MonsterBase>());

                    Collider2D ShaNiaocollider2D = ShaNiao.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(ShaNiaocollider2D, ShaNiao.GetComponent<MonsterBase>());

                    Collider2D XianRenZhangcollider2D =
                        XianRenZhang.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(XianRenZhangcollider2D,
                        XianRenZhang.GetComponent<MonsterBase>());
                }
            }


            if (LevelInfoConfig.CurrentGameLevel == 13 || LevelInfoConfig.CurrentGameLevel == 14 ||
                LevelInfoConfig.CurrentGameLevel == 15)
            {
                for (int i = 0; i < 100; i++)
                {
                    var XueQiE =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level5/XueQiE").GetComponent<XueQiE>(),
                            GameController.S.transform);
                    XueQiE.gameObject.SetActive(false);
                    GameController.S.XueQiEQueue.Enqueue(XueQiE.GetComponent<XueQiE>());


                    Collider2D XueQiEcollider2D = XueQiE.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(XueQiEcollider2D, XueQiE.GetComponent<MonsterBase>());


                    var XueZhangLang =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level5/XueZhangLang")
                                .GetComponent<XueZhangLang>(), GameController.S.transform);
                    XueZhangLang.gameObject.SetActive(false);
                    GameController.S.XueZhangLangQueue.Enqueue(XueZhangLang.GetComponent<XueZhangLang>());


                    Collider2D XueZhangLangcollider2D =
                        XueZhangLang.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(XueZhangLangcollider2D,
                        XueZhangLang.GetComponent<MonsterBase>());

                    var XueRen =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level5/XueRen").GetComponent<XueRen>(),
                            GameController.S.transform);
                    XueRen.gameObject.SetActive(false);
                    GameController.S.XueRenQueue.Enqueue(XueRen.GetComponent<XueRen>());

                    Collider2D XueRencollider2D = XueRen.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(XueRencollider2D, XueRen.GetComponent<MonsterBase>());


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



            //精英怪队列
            if (LevelInfoConfig.CurrentGameLevel == 2 || LevelInfoConfig.CurrentGameLevel == 3)
            {
                for (int i = 0; i < 15; i++)
                {
                    var eliteBeeMonster =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level1/EliteBeeMonster")
                                .GetComponent<EliteBeeMonster>(),
                            GameController.S.transform);
                    eliteBeeMonster.gameObject.SetActive(false);
                    GameController.S.EliteBeeMonsterQueue.Enqueue(eliteBeeMonster.GetComponent<EliteBeeMonster>());

                    Collider2D eliteBeeMonstercollider2D =
                        eliteBeeMonster.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(eliteBeeMonstercollider2D,
                        eliteBeeMonster.GetComponent<MonsterBase>());

                }
            }



            if (LevelInfoConfig.CurrentGameLevel == 5 || LevelInfoConfig.CurrentGameLevel == 6)
            {
                for (int i = 0; i < 15; i++)
                {
                    var elitedazuiMonster =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level2/EliteDaZuiMonster")
                                .GetComponent<EliteDaZuiMonster>(),
                            GameController.S.transform);
                    elitedazuiMonster.gameObject.SetActive(false);
                    GameController.S.EliteDaZuiMonsterQueue.Enqueue(elitedazuiMonster
                        .GetComponent<EliteDaZuiMonster>());

                    Collider2D elitedazuiMonstercollider2D =
                        elitedazuiMonster.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(elitedazuiMonstercollider2D,
                        elitedazuiMonster.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 8 || LevelInfoConfig.CurrentGameLevel == 9)
            {
                for (int i = 0; i < 15; i++)
                {
                    var shirenhuaMonster =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level3/EliteShiRenHuaMonster")
                                .GetComponent<ShiRenHuaMonster>(), GameController.S.transform);
                    shirenhuaMonster.gameObject.SetActive(false);
                    GameController.S.ShiRenHuaMonsterQueue.Enqueue(shirenhuaMonster
                        .GetComponent<ShiRenHuaMonster>());

                    Collider2D shirenhuaMonstercollider2D =
                        shirenhuaMonster.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(shirenhuaMonstercollider2D,
                        shirenhuaMonster.GetComponent<MonsterBase>());
                }

            }

            if (LevelInfoConfig.CurrentGameLevel == 11 || LevelInfoConfig.CurrentGameLevel == 12)
            {
                for (int i = 0; i < 15; i++)
                {
                    var shamoElite =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaMoElite").GetComponent<ShaMoElite>(),
                            GameController.S.transform);
                    shamoElite.gameObject.SetActive(false);
                    GameController.S.ShaMoEliteQueue.Enqueue(shamoElite.GetComponent<ShaMoElite>());

                    var ShaXiYi =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaXiYi").GetComponent<ShaXiYi>(),
                            GameController.S.transform);
                    ShaXiYi.gameObject.SetActive(false);
                    GameController.S.ShaXiYiQueue.Enqueue(ShaXiYi.GetComponent<ShaXiYi>());

                    Collider2D shamoElitecollider2D = shamoElite.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(shamoElitecollider2D,
                        shamoElite.GetComponent<MonsterBase>());

                    Collider2D ShaXiYicollider2D = ShaXiYi.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(ShaXiYicollider2D, ShaXiYi.GetComponent<MonsterBase>());
                }

            }
            

            if (LevelInfoConfig.CurrentGameLevel == 14 || LevelInfoConfig.CurrentGameLevel == 15)
            {
                for (int i = 0; i < 15; i++)
                {
                    var YingShu =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level5/YingShu")
                                .GetComponent<YingShu>(), GameController.S.transform);
                    YingShu.gameObject.SetActive(false);
                    GameController.S.YingShuQueue.Enqueue(YingShu.GetComponent<YingShu>());

                    Collider2D Yingshucollider2D = YingShu.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(Yingshucollider2D, YingShu.GetComponent<MonsterBase>());
                }

            }


            //Boss技能队列
            if (LevelInfoConfig.CurrentGameLevel == 12)
            {
                for (int i = 0; i < 10; i++)
                {
                    var xieziskill1 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level4/XieZiSkill1")
                                .GetComponent<XieZiSkill1>(), GameController.S.transform);
                    xieziskill1.gameObject.SetActive(false);
                    GameController.S.XieZiSkill1Queue.Enqueue(xieziskill1);
                }

                for (int i = 0; i < 10; i++)
                {
                    var xieziskill4 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level4/XieZiSkill4")
                                .GetComponent<XieZiSkill4>(), GameController.S.transform);
                    xieziskill4.gameObject.SetActive(false);
                    GameController.S.XieZiSkill4Queue.Enqueue(xieziskill4);
                }
            }





            GameController.S.fightBG = Instantiate(Resources.Load<GameObject>("Prefabs/Window/FightBG"),
                GameController.S.transform);
            GameController.S.fightBG.transform.position = new Vector3(0, 0, 0.1f);
            GameController.S.monsterHpSliderPrefabs = Resources.Load<GameObject>("Prefabs/Tool/MonsterHPBloodBar");





            GameController.S.CreatePlayer();
        }
    }
}
