using System;
using System.Collections.Generic;
using Mysql;
using Prop.BaoShi;
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
            GameController.S.MaxBossEnergyNum = LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel]*2;//这时小怪数量，精英不算数量，每10只普通怪出一只精英，所以正好是2倍
            GameController.S.MaxBossEnergyNum = 10;

            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/IceExplosion").GetComponent<IceExplosion>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.IceExQueue.Enqueue(Monster1);            
            }
            
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HuoSkill/HuoSkill1").GetComponent<HuoSkill1>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HuoSkill1Queue.Enqueue(Monster1);            
            }
            
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/DianSkill/DianSkill2").GetComponent<DianSkill2>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.DianSkill2Queue.Enqueue(Monster1);            
            }
            

            if (LevelInfoConfig.CurrentGameLevel > 15)
            {
                for (int i = 0; i < 100; i++)
                {
                    var Monster1 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LeiShou/LeiShouSkill3").GetComponent<LeiShouSkill3>(),
                            GameController.S.transform);
                    Monster1.gameObject.SetActive(false);
                    GameController.S.LeiShouSkill3Queue.Enqueue(Monster1.GetComponent<LeiShouSkill3>());
                    
                    var Monster2 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/KuiJia/HeiXuanFen").GetComponent<HeiXuanFen>(),
                            GameController.S.transform);
                    Monster2.gameObject.SetActive(false);
                    GameController.S.HeiXuanFenQueue.Enqueue(Monster2.GetComponent<HeiXuanFen>());
                    var Monster3 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/BaoZi/LvZhuiZong").GetComponent<LvZhuiZong>(),
                            GameController.S.transform);
                    Monster3.gameObject.SetActive(false);
                    GameController.S.LvZhuiZongQueue.Enqueue(Monster3.GetComponent<LvZhuiZong>());
                    
                    var Monster4 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/BaoZi/LvXuanFen").GetComponent<LvXuanFen>(),
                            GameController.S.transform);
                    Monster4.gameObject.SetActive(false);
                    GameController.S.LvXuanFenQueue.Enqueue(Monster4.GetComponent<LvXuanFen>());
                    
                    var Monster5 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/BaoZi/BaoZiSkill2").GetComponent<BaoZiSkill2>(),
                            GameController.S.transform);
                    Monster5.gameObject.SetActive(false);
                    GameController.S.BaoZiSkill2Queue.Enqueue(Monster5.GetComponent<BaoZiSkill2>());
                    
                    var Monster6 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/HuoLang/HuoLangSkill2").GetComponent<HuoLangSkill2>(),
                            GameController.S.transform);
                    Monster6.gameObject.SetActive(false);
                    GameController.S.HuoLangSkill2Queue.Enqueue(Monster6.GetComponent<HuoLangSkill2>());
                    var Monster7 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/ShuangDao/ShuangDaoSkill2").GetComponent<ShuangDaoSkill2>(),
                            GameController.S.transform);
                    Monster7.gameObject.SetActive(false);
                    GameController.S.ShuangDaoSkill2Queue.Enqueue(Monster7.GetComponent<ShuangDaoSkill2>());
                    
                    var Monster8 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/ShuangDao/ShuangDaoSkill3").GetComponent<ShuangDaoSkill3>(),
                            GameController.S.transform);
                    Monster8.gameObject.SetActive(false);
                    GameController.S.ShuangDaoSkill3Queue.Enqueue(Monster8.GetComponent<ShuangDaoSkill3>());
                    
                }
            }
            
            
            //秘境怪物
           
                for (int i = 0; i < 200; i++)
                {
                   
                            var Monster1 =
                                Instantiate(
                                    Resources.Load<GameObject>("Prefabs/Monster/MJ/DaLong").GetComponent<DaLong>(),
                                    GameController.S.transform);
                            Monster1.gameObject.SetActive(false);
                            GameController.S.DaLongQueue.Enqueue(Monster1.GetComponent<DaLong>());
                            Collider2D collider2D=Monster1.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D,Monster1.GetComponent<MonsterBase>());
                            
                            var Monster2 =
                                Instantiate(Resources.Load<GameObject>("Prefabs/Monster/MJ/EMo1").GetComponent<EMo1>(),
                                    GameController.S.transform);
                            Monster2.gameObject.SetActive(false);
                            GameController.S.EMo1Queue.Enqueue(Monster2.GetComponent<EMo1>());
                            Collider2D collider2D2=Monster2.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D2,Monster2.GetComponent<MonsterBase>());
                            var Monster3 =
                                Instantiate(Resources.Load<GameObject>("Prefabs/Monster/MJ/EMo2").GetComponent<EMo2>(),
                                    GameController.S.transform);
                            Monster3.gameObject.SetActive(false);
                            GameController.S.EMo2Queue.Enqueue(Monster3.GetComponent<EMo2>());
                            Collider2D collider2D3=Monster3.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D3,Monster3.GetComponent<MonsterBase>());
                            var Monster4 =
                                Instantiate(Resources.Load<GameObject>("Prefabs/Monster/MJ/EMo3").GetComponent<EMo3>(),
                                    GameController.S.transform);
                            Monster4.gameObject.SetActive(false);
                            GameController.S.EMo3Queue.Enqueue(Monster4.GetComponent<EMo3>());
                            Collider2D collider2D4=Monster4.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D4,Monster4.GetComponent<MonsterBase>());
                            var Monster5 =
                                Instantiate(
                                    Resources.Load<GameObject>("Prefabs/Monster/MJ/HongLong1")
                                        .GetComponent<HongLong1>(), GameController.S.transform);
                            Monster5.gameObject.SetActive(false);
                            GameController.S.HongLong1Queue.Enqueue(Monster5.GetComponent<HongLong1>());
                            Collider2D collider2D5=Monster5.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D5,Monster5.GetComponent<MonsterBase>());
                            var Monster6 =
                                Instantiate(
                                    Resources.Load<GameObject>("Prefabs/Monster/MJ/HongLong2")
                                        .GetComponent<HongLong2>(), GameController.S.transform);
                            Monster6.gameObject.SetActive(false);
                            GameController.S.HongLong2Queue.Enqueue(Monster6.GetComponent<HongLong2>());
                            Collider2D collider2D6=Monster6.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D6,Monster6.GetComponent<MonsterBase>());
                            var Monster7 =
                                Instantiate(
                                    Resources.Load<GameObject>("Prefabs/Monster/MJ/HongLong3")
                                        .GetComponent<HongLong3>(), GameController.S.transform);
                            Monster7.gameObject.SetActive(false);
                            GameController.S.HongLong3Queue.Enqueue(Monster7.GetComponent<HongLong3>());
                            Collider2D collider2D7=Monster7.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D7,Monster7.GetComponent<MonsterBase>());
                            var Monster8 =
                                Instantiate(
                                    Resources.Load<GameObject>("Prefabs/Monster/MJ/LanLong1").GetComponent<LanLong1>(),
                                    GameController.S.transform);
                            Monster8.gameObject.SetActive(false);
                            GameController.S.LanLong1Queue.Enqueue(Monster8.GetComponent<LanLong1>());
                            Collider2D collider2D8=Monster8.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D8,Monster8.GetComponent<MonsterBase>());
                            var Monster9 =
                                Instantiate(
                                    Resources.Load<GameObject>("Prefabs/Monster/MJ/LanLong2").GetComponent<LanLong2>(),
                                    GameController.S.transform);
                            Monster9.gameObject.SetActive(false);
                            GameController.S.LanLong2Queue.Enqueue(Monster9.GetComponent<LanLong2>());
                            Collider2D collider2D9=Monster9.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D9,Monster9.GetComponent<MonsterBase>());
                            var Monster10 =
                                Instantiate(
                                    Resources.Load<GameObject>("Prefabs/Monster/MJ/LanLong3").GetComponent<LanLong3>(),
                                    GameController.S.transform);
                            Monster10.gameObject.SetActive(false);
                            GameController.S.LanLong3Queue.Enqueue(Monster10.GetComponent<LanLong3>());
                            Collider2D collider2D10=Monster10.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D10,Monster10.GetComponent<MonsterBase>());
                            var Monster11 =
                                Instantiate(
                                    Resources.Load<GameObject>("Prefabs/Monster/MJ/LvLang").GetComponent<LvLang>(),
                                    GameController.S.transform);
                            Monster11.gameObject.SetActive(false);
                            GameController.S.LvLangQueue.Enqueue(Monster11.GetComponent<LvLang>());
                            Collider2D collider2D11=Monster11.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D11,Monster11.GetComponent<MonsterBase>());
                            var Monster12 =
                                Instantiate(
                                    Resources.Load<GameObject>("Prefabs/Monster/MJ/LvLong1").GetComponent<LvLong1>(),
                                    GameController.S.transform);
                            Monster12.gameObject.SetActive(false);
                            GameController.S.LvLong1Queue.Enqueue(Monster12.GetComponent<LvLong1>());
                            Collider2D collider2D12=Monster12.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D12,Monster12.GetComponent<MonsterBase>());
                            var Monster13 =
                                Instantiate(
                                    Resources.Load<GameObject>("Prefabs/Monster/MJ/LvLong2").GetComponent<LvLong2>(),
                                    GameController.S.transform);
                            Monster13.gameObject.SetActive(false);
                            GameController.S.LvLong2Queue.Enqueue(Monster13.GetComponent<LvLong2>());
                            Collider2D collider2D13=Monster13.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D13,Monster13.GetComponent<MonsterBase>());
                            var Monster14 =
                                Instantiate(
                                    Resources.Load<GameObject>("Prefabs/Monster/MJ/LvLong3").GetComponent<LvLong3>(),
                                    GameController.S.transform);
                            Monster14.gameObject.SetActive(false);
                            GameController.S.LvLong3Queue.Enqueue(Monster14.GetComponent<LvLong3>());
                            Collider2D collider2D14=Monster14.transform.Find("Collider").GetComponent<Collider2D>();
                            GameController.S.MonsterColliderDic.Add(collider2D14,Monster14.GetComponent<MonsterBase>());
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
        for (int i = 0; i < 30; i++)
        {
            
            GameObject whiteChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBangWhite"));
            whiteChiBang.gameObject.SetActive(false);
            GameController.S.WhiteChiBang.Enqueue(whiteChiBang);
            
            GameObject GreenChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBangGreen"));
            GreenChiBang.gameObject.SetActive(false);
            GameController.S.GreenChiBang.Enqueue(GreenChiBang);
            
            GameObject BlueChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBangBlue"));
            BlueChiBang.gameObject.SetActive(false);
            GameController.S.BlueChiBang.Enqueue(BlueChiBang);
            
            GameObject PurpleChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBangPurple"));
            PurpleChiBang.gameObject.SetActive(false);
            GameController.S.PurpleChiBang.Enqueue(PurpleChiBang);
            
            GameObject OrangeChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBangOrange"));
            OrangeChiBang.gameObject.SetActive(false);
            GameController.S.OrangeChiBang.Enqueue(OrangeChiBang);
            
            GameObject RedChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBangRed"));
            RedChiBang.gameObject.SetActive(false);
            GameController.S.RedChiBang.Enqueue(RedChiBang);
            
            
            GameObject whiteWeaponFragmeng = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/WhiteWeaponFragmeng"));
            whiteWeaponFragmeng.gameObject.SetActive(false);
            GameController.S.WhiteWeaponFragmengQueue.Enqueue(whiteWeaponFragmeng);
            
            GameObject GreenWeaponFragmeng = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/GreenWeaponFragmeng"));
            GreenWeaponFragmeng.gameObject.SetActive(false);
            GameController.S.GreenWeaponFragmengQueue.Enqueue(GreenWeaponFragmeng);
            
            GameObject BlueWeaponFragmeng = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/BlueWeaponFragmeng"));
            BlueWeaponFragmeng.gameObject.SetActive(false);
            GameController.S.BlueWeaponFragmengQueue.Enqueue(BlueWeaponFragmeng);
            
            GameObject PurpleWeaponFragmeng = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/PurpleWeaponFragmeng"));
            PurpleWeaponFragmeng.gameObject.SetActive(false);
            GameController.S.PurpleWeaponFragmengQueue.Enqueue(PurpleWeaponFragmeng);
            
            GameObject OrangeWeaponFragmeng = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/OrangeWeaponFragmeng"));
            OrangeWeaponFragmeng.gameObject.SetActive(false);
            GameController.S.OrangeWeaponFragmengQueue.Enqueue(OrangeWeaponFragmeng);
            
            GameObject RedWeaponFragmeng = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/RedWeaponFragmeng"));
            RedWeaponFragmeng.gameObject.SetActive(false);
            GameController.S.RedWeaponFragmengQueue.Enqueue(RedWeaponFragmeng);
            
            GameObject JuDaYaChi = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/JuDaYaChi"));
            JuDaYaChi.gameObject.SetActive(false);
            GameController.S.JuDaYaChiQueue.Enqueue(JuDaYaChi);
            
            GameObject GoldBlood = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/GoldBlood"));
            GoldBlood.gameObject.SetActive(false);
            GameController.S.GoldBloodQueue.Enqueue(GoldBlood);
            
            GameObject ZuiEYanZhu = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ZuiEYanZhu"));
            ZuiEYanZhu.gameObject.SetActive(false);
            GameController.S.ZuiEYanZhuQueue.Enqueue(ZuiEYanZhu);
            
            GameObject FuMoZhiGu = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/FuMoZhiGu"));
            FuMoZhiGu.gameObject.SetActive(false);
            GameController.S.FuMoZhiGuQueue.Enqueue(FuMoZhiGu);
            
            
            
            
            
            
            GameObject primaryCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryCloakFight"));
            primaryCloakFight.gameObject.SetActive(false);
            GameController.S.PrimaryCloakQueue.Enqueue(primaryCloakFight);
            
            GameObject primaryClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryClothFight"));
            primaryClothFight.gameObject.SetActive(false);
            GameController.S.PrimaryClothQueue.Enqueue(primaryClothFight);
            
            GameObject primaryRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryRingFight"));
            primaryRingFight.gameObject.SetActive(false);
            GameController.S.PrimaryRingQueue.Enqueue(primaryRingFight);
            
            GameObject primaryShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryShoeFight"));
            primaryShoeFight.gameObject.SetActive(false);
            GameController.S.PrimaryShoeQueue.Enqueue(primaryShoeFight);
            
            GameObject primaryNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryNecklaceFight"));
            primaryNecklaceFight.gameObject.SetActive(false);
            GameController.S.PrimaryNecklaceQueue.Enqueue(primaryNecklaceFight);
            
            GameObject primaryHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryHelmetFight"));
            primaryHelmetFight.gameObject.SetActive(false);
            GameController.S.PrimaryHelmetQueue.Enqueue(primaryHelmetFight);
            
            
            
            
            GameObject GreenCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenCloakFight"));
            GreenCloakFight.gameObject.SetActive(false);
            GameController.S.GreenCloakQueue.Enqueue(GreenCloakFight);
            
            GameObject GreenClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenClothFight"));
            GreenClothFight.gameObject.SetActive(false);
            GameController.S.GreenClothQueue.Enqueue(GreenClothFight);
            
            GameObject GreenRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenRingFight"));
            GreenRingFight.gameObject.SetActive(false);
            GameController.S.GreenRingQueue.Enqueue(GreenRingFight);
            
            GameObject GreenShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenShoeFight"));
            GreenShoeFight.gameObject.SetActive(false);
            GameController.S.GreenShoeQueue.Enqueue(GreenShoeFight);
            
            GameObject GreenNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenNecklaceFight"));
            GreenNecklaceFight.gameObject.SetActive(false);
            GameController.S.GreenNecklaceQueue.Enqueue(GreenNecklaceFight);
            
            GameObject GreenHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenHelmetFight"));
            GreenHelmetFight.gameObject.SetActive(false);
            GameController.S.GreenHelmetQueue.Enqueue(GreenHelmetFight);
            
            
            
            
            
            GameObject BlueCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueCloakFight"));
            BlueCloakFight.gameObject.SetActive(false);
            GameController.S.BlueCloakQueue.Enqueue(BlueCloakFight);
            
            GameObject BlueClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueClothFight"));
            BlueClothFight.gameObject.SetActive(false);
            GameController.S.BlueClothQueue.Enqueue(BlueClothFight);
            
            GameObject BlueRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueRingFight"));
            BlueRingFight.gameObject.SetActive(false);
            GameController.S.BlueRingQueue.Enqueue(BlueRingFight);
            
            GameObject BlueShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueShoeFight"));
            BlueShoeFight.gameObject.SetActive(false);
            GameController.S.BlueShoeQueue.Enqueue(BlueShoeFight);
            
            GameObject BlueNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueNecklaceFight"));
            BlueNecklaceFight.gameObject.SetActive(false);
            GameController.S.BlueNecklaceQueue.Enqueue(BlueNecklaceFight);
            
            GameObject BlueHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueHelmetFight"));
            BlueHelmetFight.gameObject.SetActive(false);
            GameController.S.BlueHelmetQueue.Enqueue(BlueHelmetFight);
            
            
            
            
            
            
            GameObject ZhaoZeCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeCloakFight"));
            ZhaoZeCloakFight.gameObject.SetActive(false);
            GameController.S.ZhaoZeCloakQueue.Enqueue(ZhaoZeCloakFight);
            
            GameObject ZhaoZeClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeClothFight"));
            ZhaoZeClothFight.gameObject.SetActive(false);
            GameController.S.ZhaoZeClothQueue.Enqueue(ZhaoZeClothFight);
            
            GameObject ZhaoZeRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeRingFight"));
            ZhaoZeRingFight.gameObject.SetActive(false);
            GameController.S.ZhaoZeRingQueue.Enqueue(ZhaoZeRingFight);
            
            GameObject ZhaoZeShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeShoeFight"));
            ZhaoZeShoeFight.gameObject.SetActive(false);
            GameController.S.ZhaoZeShoeQueue.Enqueue(ZhaoZeShoeFight);
            
            GameObject ZhaoZeNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeNecklaceFight"));
            ZhaoZeNecklaceFight.gameObject.SetActive(false);
            GameController.S.ZhaoZeNecklaceQueue.Enqueue(ZhaoZeNecklaceFight);
            
            GameObject ZhaoZeHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeHelmetFight"));
            ZhaoZeHelmetFight.gameObject.SetActive(false);
            GameController.S.ZhaoZeHelmetQueue.Enqueue(ZhaoZeHelmetFight);
            
            
            
            
            
            
            
            
            
            GameObject PurpleCloakFight1 = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/PurpleCloakFight1"));
            PurpleCloakFight1.gameObject.SetActive(false);
            GameController.S.Purple1CloakQueue.Enqueue(PurpleCloakFight1);
            
            GameObject PurpleClothFight1 = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/PurpleClothFight1"));
            PurpleClothFight1.gameObject.SetActive(false);
            GameController.S.Purple1ClothQueue.Enqueue(PurpleClothFight1);
            
            GameObject PurpleRingFight1 = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/PurpleRingFight1"));
            PurpleRingFight1.gameObject.SetActive(false);
            GameController.S.Purple1RingQueue.Enqueue(PurpleRingFight1);
            
            GameObject PurpleShoeFight1 = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/PurpleShoeFight1"));
            PurpleShoeFight1.gameObject.SetActive(false);
            GameController.S.Purple1ShoeQueue.Enqueue(PurpleShoeFight1);
            
            GameObject PurpleNecklaceFight1 = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/PurpleNecklaceFight1"));
            PurpleNecklaceFight1.gameObject.SetActive(false);
            GameController.S.Purple1NecklaceQueue.Enqueue(PurpleNecklaceFight1);
            
            GameObject PurpleHelmetFight1 = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/PurpleHelmetFight1"));
            PurpleHelmetFight1.gameObject.SetActive(false);
            GameController.S.Purple1HelmetQueue.Enqueue(PurpleHelmetFight1);
            
            
            
            
            
            
            
            
            
            
            GameObject TreeManCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManCloakFight"));
            TreeManCloakFight.gameObject.SetActive(false);
            GameController.S.TreeManCloakQueue.Enqueue(TreeManCloakFight);
            
            GameObject TreeManClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManClothFight"));
            TreeManClothFight.gameObject.SetActive(false);
            GameController.S.TreeManClothQueue.Enqueue(TreeManClothFight);
            
            GameObject TreeManRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManRingFight"));
            TreeManRingFight.gameObject.SetActive(false);
            GameController.S.TreeManRingQueue.Enqueue(TreeManRingFight);
            
            GameObject TreeManShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManShoeFight"));
            TreeManShoeFight.gameObject.SetActive(false);
            GameController.S.TreeManShoeQueue.Enqueue(TreeManShoeFight);
            
            GameObject TreeManNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManNecklaceFight"));
            TreeManNecklaceFight.gameObject.SetActive(false);
            GameController.S.TreeManNecklaceQueue.Enqueue(TreeManNecklaceFight);
            
            GameObject TreeManHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManHelmetFight"));
            TreeManHelmetFight.gameObject.SetActive(false);
            GameController.S.TreeManHelmetQueue.Enqueue(TreeManHelmetFight);
            
            
            
            
            
            GameObject HuoShanCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanCloakFight"));
            HuoShanCloakFight.gameObject.SetActive(false);
            GameController.S.HuoShanCloakQueue.Enqueue(HuoShanCloakFight);
            
            GameObject HuoShanClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanClothFight"));
            HuoShanClothFight.gameObject.SetActive(false);
            GameController.S.HuoShanClothQueue.Enqueue(HuoShanClothFight);
            
            GameObject HuoShanRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanRingFight"));
            HuoShanRingFight.gameObject.SetActive(false);
            GameController.S.HuoShanRingQueue.Enqueue(HuoShanRingFight);
            
            GameObject HuoShanShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanShoeFight"));
            HuoShanShoeFight.gameObject.SetActive(false);
            GameController.S.HuoShanShoeQueue.Enqueue(HuoShanShoeFight);
            
            GameObject HuoShanNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanNecklaceFight"));
            HuoShanNecklaceFight.gameObject.SetActive(false);
            GameController.S.HuoShanNecklaceQueue.Enqueue(HuoShanNecklaceFight);
            
            GameObject HuoShanHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanHelmetFight"));
            HuoShanHelmetFight.gameObject.SetActive(false);
            GameController.S.HuoShanHelmetQueue.Enqueue(HuoShanHelmetFight);
            
            
            GameObject PurpleCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleCloakFight"));
            PurpleCloakFight.gameObject.SetActive(false);
            GameController.S.PurpleCloakQueue.Enqueue(PurpleCloakFight);
            
            GameObject PurpleClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleClothFight"));
            PurpleClothFight.gameObject.SetActive(false);
            GameController.S.PurpleClothQueue.Enqueue(PurpleClothFight);
            
            GameObject PurpleRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleRingFight"));
            PurpleRingFight.gameObject.SetActive(false);
            GameController.S.PurpleRingQueue.Enqueue(PurpleRingFight);
            
            GameObject PurpleShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleShoeFight"));
            PurpleShoeFight.gameObject.SetActive(false);
            GameController.S.PurpleShoeQueue.Enqueue(PurpleShoeFight);
            
            GameObject PurpleNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleNecklaceFight"));
            PurpleNecklaceFight.gameObject.SetActive(false);
            GameController.S.PurpleNecklaceQueue.Enqueue(PurpleNecklaceFight);
            
            GameObject PurpleHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleHelmetFight"));
            PurpleHelmetFight.gameObject.SetActive(false);
            GameController.S.PurpleHelmetQueue.Enqueue(PurpleHelmetFight);
            
            
            
            GameObject OrangeCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeCloakFight"));
            OrangeCloakFight.gameObject.SetActive(false);
            OrangeCloakFight.GetComponent<EquipBase>().enabled = true;
            GameController.S.OrangeCloakQueue.Enqueue(OrangeCloakFight);
            
            GameObject OrangeClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeClothFight"));
            OrangeClothFight.gameObject.SetActive(false);
            OrangeCloakFight.GetComponent<EquipBase>().enabled = true;
            GameController.S.OrangeClothQueue.Enqueue(OrangeClothFight);
            
            GameObject OrangeRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeRingFight"));
            OrangeRingFight.gameObject.SetActive(false);
            OrangeCloakFight.GetComponent<EquipBase>().enabled = true;
            GameController.S.OrangeRingQueue.Enqueue(OrangeRingFight);
            
            GameObject OrangeShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeShoeFight"));
            OrangeShoeFight.gameObject.SetActive(false);
            OrangeCloakFight.GetComponent<EquipBase>().enabled = true;
            GameController.S.OrangeShoeQueue.Enqueue(OrangeShoeFight);
            
            GameObject OrangeNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeNecklaceFight"));
            OrangeNecklaceFight.gameObject.SetActive(false);
            OrangeCloakFight.GetComponent<EquipBase>().enabled = true;
            GameController.S.OrangeNecklaceQueue.Enqueue(OrangeNecklaceFight);
            
            GameObject OrangeHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeHelmetFight"));
            OrangeHelmetFight.gameObject.SetActive(false);
            OrangeCloakFight.GetComponent<EquipBase>().enabled = true;
            GameController.S.OrangeHelmetQueue.Enqueue(OrangeHelmetFight);
            
            //传说装备
            
            GameObject FinalDamageReductionFixed = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/FinalDamageReductionFixed"));
            FinalDamageReductionFixed.gameObject.SetActive(false);
            GameController.S.FinalDamageReductionFixedQueue.Enqueue(FinalDamageReductionFixed);
            
            GameObject FinalDamageReductionPercent = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/FinalDamageReductionPercent"));
            FinalDamageReductionPercent.gameObject.SetActive(false);
            GameController.S.FinalDamageReductionPercentQueue.Enqueue(FinalDamageReductionPercent);
            
            GameObject AllReplyAddPercent = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/AllReplyAddPercent"));
            AllReplyAddPercent.gameObject.SetActive(false);
            GameController.S.AllReplyAddPercentQueue.Enqueue(AllReplyAddPercent);
            
            GameObject AddHpForTime = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/AddHpForTime"));
            AddHpForTime.gameObject.SetActive(false);
            GameController.S.AddHpForTimeQueue.Enqueue(AddHpForTime);
            
            GameObject AddDefenseForTime = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/AddDefenseForTime"));
            AddDefenseForTime.gameObject.SetActive(false);
            GameController.S.AddDefenseForTimeQueue.Enqueue(AddDefenseForTime);
            
            GameObject ReplyDeath = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/ReplyDeath"));
            ReplyDeath.gameObject.SetActive(false);
            GameController.S.ReplyDeathQueue.Enqueue(ReplyDeath);
            
            GameObject DelayDamage = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/DelayDamage"));
            DelayDamage.gameObject.SetActive(false);
            GameController.S.DelayDamageQueue.Enqueue(DelayDamage);
            
            GameObject HpReductionReplyAdd50 = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/HpReductionReplyAdd50"));
            HpReductionReplyAdd50.gameObject.SetActive(false);
            GameController.S.HpReductionReplyAdd50Queue.Enqueue(HpReductionReplyAdd50);
            
            GameObject HpReductionAddDefense = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/HpReductionAddDefense"));
            HpReductionAddDefense.gameObject.SetActive(false);
            GameController.S.HpReductionAddDefenseQueue.Enqueue(HpReductionAddDefense);
            
            GameObject FinalDamageAddPercent = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/FinalDamageAddPercent"));
            FinalDamageAddPercent.gameObject.SetActive(false);
            GameController.S.FinalDamageAddPercentQueue.Enqueue(FinalDamageAddPercent);
            
            GameObject KillNormal = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/KillNormal"));
            KillNormal.gameObject.SetActive(false);
            GameController.S.KillNormalQueue.Enqueue(KillNormal);
            
            GameObject AddAttackForTime = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/AddAttackForTime"));
            AddAttackForTime.gameObject.SetActive(false);
            GameController.S.AddAttackForTimeQueue.Enqueue(AddAttackForTime);
            
            GameObject NormalAddDamage = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/NormalAddDamage"));
            NormalAddDamage.gameObject.SetActive(false);
            GameController.S.NormalAddDamageQueue.Enqueue(NormalAddDamage);
            
            GameObject RecudeHpAddAttack = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/RecudeHpAddAttack"));
            RecudeHpAddAttack.gameObject.SetActive(false);
            GameController.S.RecudeHpAddAttackQueue.Enqueue(RecudeHpAddAttack);
            
            GameObject JianSuAddAttack = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/JianSuAddAttack"));
            JianSuAddAttack.gameObject.SetActive(false);
            GameController.S.JianSuAddAttackQueue.Enqueue(JianSuAddAttack);
            
            GameObject FanPuGuiZhen = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/FanPuGuiZhen"));
            FanPuGuiZhen.gameObject.SetActive(false);
            GameController.S.FanPuGuiZhenQueue.Enqueue(FanPuGuiZhen);
            
            GameObject NoSkill = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/NoSkill"));
            NoSkill.gameObject.SetActive(false);
            GameController.S.NoSkillQueue.Enqueue(NoSkill);
            
            GameObject BuWangChuXin = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/BuWangChuXin"));
            BuWangChuXin.gameObject.SetActive(false);
            GameController.S.BuWangChuXinQueue.Enqueue(BuWangChuXin);
            
            GameObject HeiDongAddSpeed = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/HeiDongAddSpeed"));
            HeiDongAddSpeed.gameObject.SetActive(false);
            GameController.S.HeiDongAddSpeedQueue.Enqueue(HeiDongAddSpeed);
            
            GameObject DuAddDuQuan = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/DuAddDuQuan"));
            DuAddDuQuan.gameObject.SetActive(false);
            GameController.S.DuAddDuQuanQueue.Enqueue(DuAddDuQuan);
            
            GameObject LvQuanAddScale = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/LvQuanAddScale"));
            LvQuanAddScale.gameObject.SetActive(false);
            GameController.S.LvQuanAddScaleQueue.Enqueue(LvQuanAddScale);
            
            GameObject XuKongAdd2Dan = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/XuKongAdd2Dan"));
            XuKongAdd2Dan.gameObject.SetActive(false);
            GameController.S.XuKongAdd2DanQueue.Enqueue(XuKongAdd2Dan);
            
            GameObject PuTong3ChuanTou = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/PuTong3ChuanTou"));
            PuTong3ChuanTou.gameObject.SetActive(false);
            GameController.S.PuTong3ChuanTouQueue.Enqueue(PuTong3ChuanTou);
            
            GameObject FireBaoZha = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/FireBaoZha"));
            FireBaoZha.gameObject.SetActive(false);
            GameController.S.FireBaoZhaQueue.Enqueue(FireBaoZha);
            
            GameObject Skill1ReplaceNormalAttack = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/Skill1ReplaceNormalAttack"));
            Skill1ReplaceNormalAttack.gameObject.SetActive(false);
            GameController.S.Skill1ReplaceNormalAttackQueue.Enqueue(Skill1ReplaceNormalAttack);
            
            GameObject Skill1YiDianDouble = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/Skill1YiDianDouble"));
            Skill1YiDianDouble.gameObject.SetActive(false);
            GameController.S.Skill1YiDianDoubleQueue.Enqueue(Skill1YiDianDouble);
            
            GameObject Skill1AddRange = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/Skill1AddRange"));
            Skill1AddRange.gameObject.SetActive(false);
            GameController.S.Skill1AddRangeQueue.Enqueue(Skill1AddRange);
            
            GameObject Skill2AddDan = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/Skill2AddDan"));
            Skill2AddDan.gameObject.SetActive(false);
            GameController.S.Skill2AddDanQueue.Enqueue(Skill2AddDan);
            
            GameObject Skill2RotateAdd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/Skill2RotateAdd"));
            Skill2RotateAdd.gameObject.SetActive(false);
            GameController.S.Skill2RotateAddQueue.Enqueue(Skill2RotateAdd);
            
            GameObject Skill2AddRange = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/Skill2AddRange"));
            Skill2AddRange.gameObject.SetActive(false);
            GameController.S.Skill2AddRangeQueue.Enqueue(Skill2AddRange);
            
            GameObject Skill3Bian3 = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/Skill3Bian3"));
            Skill3Bian3.gameObject.SetActive(false);
            GameController.S.Skill3Bian3Queue.Enqueue(Skill3Bian3);
            
            GameObject Skill3AddRange = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/Skill3AddRange"));
            Skill3AddRange.gameObject.SetActive(false);
            GameController.S.Skill3AddRangeQueue.Enqueue(Skill3AddRange);
            
            GameObject DashCd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/DashCd"));
            DashCd.gameObject.SetActive(false);
            GameController.S.DashCdQueue.Enqueue(DashCd);
            
            GameObject DashRange = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/DashRange"));
            DashRange.gameObject.SetActive(false);
            GameController.S.DashRangeQueue.Enqueue(DashRange);
            
            GameObject MoveSpeedAdd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/MoveSpeedAdd"));
            MoveSpeedAdd.gameObject.SetActive(false);
            GameController.S.MoveSpeedAddQueue.Enqueue(MoveSpeedAdd);
            
            GameObject ExAdd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/ExAdd"));
            ExAdd.gameObject.SetActive(false);
            GameController.S.ExAddQueue.Enqueue(ExAdd);
            
            GameObject ClothFortureAdd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/ClothFortureAdd"));
            ClothFortureAdd.gameObject.SetActive(false);
            GameController.S.ClothFortureAddQueue.Enqueue(ClothFortureAdd);
            
            GameObject ShoeFortureAdd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/ShoeFortureAdd"));
            ShoeFortureAdd.gameObject.SetActive(false);
            GameController.S.ShoeFortureAddQueue.Enqueue(ShoeFortureAdd);
            
            GameObject CloakFortureAdd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/CloakFortureAdd"));
            CloakFortureAdd.gameObject.SetActive(false);
            GameController.S.CloakFortureAddQueue.Enqueue(CloakFortureAdd);
            
            GameObject NecklaceFortureAdd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/NecklaceFortureAdd"));
            NecklaceFortureAdd.gameObject.SetActive(false);
            GameController.S.NecklaceFortureAddQueue.Enqueue(NecklaceFortureAdd);
            
            GameObject RingFortureAdd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/RingFortureAdd"));
            RingFortureAdd.gameObject.SetActive(false);
            GameController.S.RingFortureAddQueue.Enqueue(RingFortureAdd);
            
            GameObject HelmetFortureAdd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/HelmetFortureAdd"));
            HelmetFortureAdd.gameObject.SetActive(false);
            GameController.S.HelmetFortureAddQueue.Enqueue(HelmetFortureAdd);
        }
        
        

        

        for (int i = 0; i < 200; i++)
        {
            GameObject bloodEnergy = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/BloodEnergy"));
            bloodEnergy.gameObject.SetActive(false);
            GameController.S.BloodEnergyQueue.Enqueue(bloodEnergy);
        }
        
        for (int i = 0; i < 1000; i++)
        {
            GameObject monsterHurtText = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/MonsterHurtText"));
            monsterHurtText.gameObject.SetActive(false);
            GameController.S.MonsterHurtTextQueue.Enqueue(monsterHurtText.GetComponent<MonsterHurtText>());
            
            GameObject dianQuanPeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/DianQuan/DianPeng"));
            dianQuanPeng.gameObject.SetActive(false);
            GameController.S.DianQuanPengQueue.Enqueue(dianQuanPeng);        
        }
        
        for (int i = 0; i < 10; i++)
        {
            var circleAttack = Instantiate(Resources.Load("Prefabs/Tool/CircleAttack"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            circleAttack.SetActive(false);
            FightBGController.S.CircleAttackQueue.Enqueue(circleAttack.GetComponent<CircleAttack>());
            var fire= Instantiate(Resources.Load("Prefabs/Skill/TreeManFire"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            fire.SetActive(false);
            FightBGController.S.TreeManFireQueue.Enqueue(fire.GetComponent<TreeManFire>());
            var sqrtattack= Instantiate(Resources.Load("Prefabs/Tool/SqrtAttack"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            sqrtattack.SetActive(false);
            FightBGController.S.SqrtAttackQueue.Enqueue(sqrtattack.GetComponent<SqrtAttack>());
            var playerhit= Instantiate(Resources.Load("Prefabs/Player/PlayerHit"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            playerhit.SetActive(false);
            FightBGController.S.PlayerHitQueue.Enqueue(playerhit.GetComponent<PlayerHit>());
            
        }
        

        
        
        //初始化技能队列
        for (int i = 0; i < 100; i++)
        {
            var dianqian= Instantiate(Resources.Load("Prefabs/Skill/DianQuan/DianQuan"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            dianqian.SetActive(false);
            GameController.S.DianQuanQueue.Enqueue(dianqian);
        }

        for (int i = 0; i < 1000; i++)
        {
            var spiderWeb= Instantiate(Resources.Load("Prefabs/Monster/Level1/SpiderWeb"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            spiderWeb.SetActive(false);
            FightBGController.S.SpiderWebQueue.Enqueue(spiderWeb.GetComponent<SpiderWeb>());

            switch ( PlayerData.S.playerWeaponType)
            {
                case WeaponType.Primary:
                    var PuTong31= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/Primary"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    PuTong31.SetActive(false);
                    GameController.S.PrimaryQueue.Enqueue(PuTong31);
                    
                    var PuTong3Peng1= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/PuTongPeng3"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    PuTong3Peng1.SetActive(false);
                    GameController.S.PuTong3PengQueue.Enqueue(PuTong3Peng1);
                    break;
                case WeaponType.LanBao:
                    var twoNormalAttack= Instantiate(Resources.Load("Prefabs/Skill/2NormalAttackPrefab"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    twoNormalAttack.SetActive(false);
                    GameController.S.LvQuanQueue.Enqueue(twoNormalAttack);
                    break;
                
                case WeaponType.HeiDong:
                    var HeiDong= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/HeiDongPro"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    HeiDong.SetActive(false);
                    GameController.S.HeiDongQueue.Enqueue(HeiDong);
                    
                    var HeiDongNext= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/HeiDongNext"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    HeiDongNext.SetActive(false);
                    GameController.S.HeiDongNextQueue.Enqueue(HeiDongNext);
                    
                    var HeiDongPeng= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/HeiDongPeng"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    HeiDongPeng.SetActive(false);
                    GameController.S.HeiDongPengQueue.Enqueue(HeiDongPeng);
                    break;
                
                case WeaponType.Du:
                    var Du= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/Du"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    Du.SetActive(false);
                    GameController.S.DuQueue.Enqueue(Du);
                    
                    var DuPeng= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/DuPeng"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    DuPeng.SetActive(false);
                    GameController.S.DuPengQueue.Enqueue(DuPeng);
                    break;
                
                case WeaponType.LuoLei:
                    var LuoLei= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/LuoLei"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    LuoLei.SetActive(false);
                    GameController.S.LuoLeiQueue.Enqueue(LuoLei);
                    
                    var LuoLeiPeng= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/LuoLeiPeng"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    LuoLeiPeng.SetActive(false);
                    GameController.S.LuoLeiPengQueue.Enqueue(LuoLeiPeng);
                    break;
                
                case WeaponType.PuTong3:
                    var PuTong3= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/PuTong3"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    PuTong3.SetActive(false);
                    GameController.S.PuTong3Queue.Enqueue(PuTong3);
                    
                    var PuTong3Peng= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/PuTongPeng3"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    PuTong3Peng.SetActive(false);
                    GameController.S.PuTong3PengQueue.Enqueue(PuTong3Peng);
                    break;
                
                case WeaponType.Fire:
                    var FireAttack= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/Fire"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    FireAttack.SetActive(false);
                    GameController.S.FireQueue.Enqueue(FireAttack);
                    
                    var FirePengAttack= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/FirePeng"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    FirePengAttack.SetActive(false);
                    GameController.S.FirePengQueue.Enqueue(FirePengAttack);
                    
                    var FireBaoZha= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/FireBaoZha"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    FireBaoZha.SetActive(false);
                    GameController.S.FireBaoZha1Queue.Enqueue(FireBaoZha);
                    break;
                
                case WeaponType.XuKong:
                    var XuKongAttack= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/XuKong"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    XuKongAttack.SetActive(false);
                    GameController.S.XuKongQueue.Enqueue(XuKongAttack);
                    
                    var XuKongPengAttack= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/XuKongPeng"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    XuKongPengAttack.SetActive(false);
                    GameController.S.XuKongPengQueue.Enqueue(XuKongPengAttack);
                    break;
                
                case WeaponType.LvQuan:
                    var lvNormalAttack= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/LvQuan"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    lvNormalAttack.SetActive(false);
                    GameController.S.LvQuanQueue.Enqueue(lvNormalAttack);
                    break;
                
                case WeaponType.JianQi:
                    var JianQi= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/PlayerJianQi"), new Vector3(0, 0, 0), Quaternion.identity).GetComponent<PlayerJianQi>();
                    JianQi.gameObject.SetActive(false);
                    GameController.S.PlayerJianQiQueue.Enqueue(JianQi);
                    
                    var zibaozha= Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/ZiPeng"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    zibaozha.SetActive(false);
                    GameController.S.ZiBaoZhaQueue.Enqueue(zibaozha);
                    break;
                    
            }
        }
        
        FightBGController.S.DiLie=Instantiate(Resources.Load("Prefabs/Skill/BossGroundFissure"), new Vector3(0,0,0), Quaternion.identity) as GameObject;
        FightBGController.S.DiLie.SetActive(false);
        
        FightBGController.S.CircleAttack = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/CircleAttack")).gameObject;
        FightBGController.S.CircleAttack.SetActive(false);

        //初始化怪物队列
        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 || LevelInfoConfig.CurrentGameLevel == 3)
        {
            for (int i = 0; i < 100; i++)
            {
                var snotMonster = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level1/SnotMonster").GetComponent<SnotMonster>(),GameController.S.transform);
                snotMonster.gameObject.SetActive(false);
                GameController.S.SnotMonsterQueue.Enqueue(snotMonster.GetComponent<SnotMonster>());

                var batMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level1/BatMonster").GetComponent<BatMonster>(),
                        GameController.S.transform);
                batMonster.gameObject.SetActive(false);
                GameController.S.BatMonsterQueue.Enqueue(batMonster.GetComponent<BatMonster>());
                
                
                var beeBullet = Instantiate(Resources.Load<BeeBullet>("Prefabs/Monster/Level1/BeeBullet"),
                        GameController.S.transform);
                beeBullet.gameObject.SetActive(false);
                GameController.S.BeeBulletQueue.Enqueue(beeBullet.GetComponent<BeeBullet>());

                var spiderMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level1/SpiderMonster").GetComponent<SpiderMonster>(),
                        GameController.S.transform);
                spiderMonster.gameObject.SetActive(false);
                GameController.S.SpiderMonsterQueue.Enqueue(spiderMonster.GetComponent<SpiderMonster>());

                Collider2D spidercollider2D=spiderMonster.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(spidercollider2D,spiderMonster.GetComponent<MonsterBase>());
                
                Collider2D batcollider2D=batMonster.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(batcollider2D,batMonster.GetComponent<MonsterBase>());
                
                Collider2D snotcollider2D=snotMonster.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(snotcollider2D,snotMonster.GetComponent<MonsterBase>());
            }
        }
        

        
        for (int i = 0; i < 100; i++)
        {
            var DiLie= Instantiate(Resources.Load<GameObject>("Prefabs/Skill/DiLie").GetComponent<TreeManDiLie>(), GameController.S.transform);
            DiLie.gameObject.SetActive(false);
            GameController.S.TreeManDiLieQueue.Enqueue(DiLie.GetComponent<TreeManDiLie>());
        }

        if (LevelInfoConfig.CurrentGameLevel == 3)
        {
            for (int i = 0; i < 100; i++)
            {
                var treemanSkill =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level1/TreeManSkill").GetComponent<TreeManSkill>(),
                        GameController.S.transform);
                treemanSkill.gameObject.SetActive(false);
                GameController.S.TreeManSkillQueue.Enqueue(treemanSkill.GetComponent<TreeManSkill>());
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 6)
        {
            for (int i = 0; i < 100; i++)
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
            for (int i = 0; i < 100; i++)
            {
                var zhaozeSkill = Instantiate(Resources.Load<ZhaoZeSkill>("Prefabs/Monster/Level3/ZhaoZeBossSkill"), GameController.S.transform);
                zhaozeSkill.gameObject.SetActive(false);
                GameController.S.ZhaoZeSkillQueue.Enqueue(zhaozeSkill);
            }
        }
        
        

        
        if (LevelInfoConfig.CurrentGameLevel == 4 || LevelInfoConfig.CurrentGameLevel == 5 || LevelInfoConfig.CurrentGameLevel == 6)
        {
            for (int i = 0; i < 100; i++)
            {
                var huangshu =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level4/HuangShuMonster").GetComponent<HuangShu>(),
                        GameController.S.transform);
                huangshu.gameObject.SetActive(false);
                GameController.S.HuangShuQueue.Enqueue(huangshu.GetComponent<HuangShu>());
                
                Collider2D Huangshucollider2D=huangshu.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(Huangshucollider2D,huangshu.GetComponent<MonsterBase>());
                
                var Huangzhu =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level4/HuangZhuMonster").GetComponent<Huangzhu>(),
                        GameController.S.transform);
                Huangzhu.gameObject.SetActive(false);
                GameController.S.HuangZhuQueue.Enqueue(Huangzhu.GetComponent<Huangzhu>());
                
                var chongziMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level2/ChongZiMonster").GetComponent<ChongZiMonster>(),
                        GameController.S.transform);
                chongziMonster.gameObject.SetActive(false);
                GameController.S.ChongZiMonsterQueue.Enqueue(chongziMonster.GetComponent<ChongZiMonster>());
                
                var XiNiuMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level2/XiNiuMonster").GetComponent<XiNiuMonster>(),
                        GameController.S.transform);
                XiNiuMonster.gameObject.SetActive(false);
                GameController.S.XiNiuMonsterQueue.Enqueue(XiNiuMonster.GetComponent<XiNiuMonster>());

                var xiaohuoMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level2/XiaoHuoMonster").GetComponent<XiaoHuoMonster>(),
                        GameController.S.transform);
                xiaohuoMonster.gameObject.SetActive(false);
                GameController.S.XiaoHuoMonsterQueue.Enqueue(xiaohuoMonster.GetComponent<XiaoHuoMonster>());

                var dundiMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level2/DunDiMonster").GetComponent<DunDiMonster>(),
                        GameController.S.transform);
                dundiMonster.gameObject.SetActive(false);
                GameController.S.DunDiMonsterQueue.Enqueue(dundiMonster.GetComponent<DunDiMonster>());
                
                Collider2D Huangzhucollider2D=Huangzhu.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(Huangzhucollider2D,Huangzhu.GetComponent<MonsterBase>());
                
                Collider2D chongzicollider2D=chongziMonster.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(chongzicollider2D,chongziMonster.GetComponent<MonsterBase>());
                
                Collider2D xiaohuocollider2D=xiaohuoMonster.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(xiaohuocollider2D,xiaohuoMonster.GetComponent<MonsterBase>());
                
                Collider2D XiNiucollider2D=XiNiuMonster.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(XiNiucollider2D,XiNiuMonster.GetComponent<MonsterBase>());
                
                Collider2D dundicollider2D=dundiMonster.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(dundicollider2D,dundiMonster.GetComponent<MonsterBase>());
                
            }
        }


        if (LevelInfoConfig.CurrentGameLevel == 7 || LevelInfoConfig.CurrentGameLevel == 8 ||
            LevelInfoConfig.CurrentGameLevel == 9)
        {
            for (int i = 0; i < 100; i++)
            {
                var jiachongMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level3/JiaChongMonster").GetComponent<JiaChongMonster>(),
                        GameController.S.transform);
                jiachongMonster.gameObject.SetActive(false);
                GameController.S.JiaChongMonsterQueue.Enqueue(jiachongMonster.GetComponent<JiaChongMonster>());


                var wenziMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level3/WenZiMonster").GetComponent<WenZiMonster>(),
                        GameController.S.transform);
                wenziMonster.gameObject.SetActive(false);
                GameController.S.WenZiMonsterQueue.Enqueue(wenziMonster.GetComponent<WenZiMonster>());

                var qingwaMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level3/QingWaMonster").GetComponent<QingWaMonster>(),
                        GameController.S.transform);
                qingwaMonster.gameObject.SetActive(false);
                GameController.S.QingWaMonsterQueue.Enqueue(qingwaMonster.GetComponent<QingWaMonster>());
                
                
                Collider2D jiachongcollider2D=jiachongMonster.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(jiachongcollider2D,jiachongMonster.GetComponent<MonsterBase>());
                
                Collider2D wenzicollider2D=wenziMonster.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(wenzicollider2D,wenziMonster.GetComponent<MonsterBase>());
                
                Collider2D qingwacollider2D=qingwaMonster.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(qingwacollider2D,qingwaMonster.GetComponent<MonsterBase>());
            }
        }
        
        if (LevelInfoConfig.CurrentGameLevel == 10 || LevelInfoConfig.CurrentGameLevel == 11 ||
            LevelInfoConfig.CurrentGameLevel == 12)
        {
            for (int i = 0; i < 100; i++)
            {
                
                var KuLou = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level4/KuLouMonster").GetComponent<KuLou>(), GameController.S.transform);
                KuLou.gameObject.SetActive(false);
                GameController.S.KuLouQueue.Enqueue(KuLou.GetComponent<KuLou>());
                
                var ShaChong = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaChong").GetComponent<ShaChong>(), GameController.S.transform);
                ShaChong.gameObject.SetActive(false);
                GameController.S.ShaChongQueue.Enqueue(ShaChong.GetComponent<ShaChong>());
                
                var ShaNiao = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaNiao").GetComponent<ShaNiao>(), GameController.S.transform);
                ShaNiao.gameObject.SetActive(false);
                GameController.S.ShaNiaoQueue.Enqueue(ShaNiao.GetComponent<ShaNiao>());
                
                var XianRenZhang = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level4/XianRenZhang").GetComponent<XianRenZhang>(), GameController.S.transform);
                XianRenZhang.gameObject.SetActive(false);
                GameController.S.XianRenZhangQueue.Enqueue(XianRenZhang.GetComponent<XianRenZhang>());
                
                Collider2D KuLoucollider2D=KuLou.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(KuLoucollider2D,KuLou.GetComponent<MonsterBase>());
                
                Collider2D ShaChongcollider2D=ShaChong.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(ShaChongcollider2D,ShaChong.GetComponent<MonsterBase>());
                
                Collider2D ShaNiaocollider2D=ShaNiao.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(ShaNiaocollider2D,ShaNiao.GetComponent<MonsterBase>());
                
                Collider2D XianRenZhangcollider2D=XianRenZhang.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(XianRenZhangcollider2D,XianRenZhang.GetComponent<MonsterBase>());
            }
        }
        

        if (LevelInfoConfig.CurrentGameLevel == 13 || LevelInfoConfig.CurrentGameLevel == 14 ||
            LevelInfoConfig.CurrentGameLevel == 15)
        {
            for (int i = 0; i < 100; i++)
            {
                var XueQiE =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level5/XueQiE").GetComponent<XueQiE>(), GameController.S.transform);
                XueQiE.gameObject.SetActive(false);
                GameController.S.XueQiEQueue.Enqueue(XueQiE.GetComponent<XueQiE>());
                
                
                Collider2D XueQiEcollider2D=XueQiE.transform.Find("Collider").GetComponent<Collider2D>();
                                GameController.S.MonsterColliderDic.Add(XueQiEcollider2D,XueQiE.GetComponent<MonsterBase>());
                                
                                
                var XueZhangLang =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level5/XueZhangLang").GetComponent<XueZhangLang>(), GameController.S.transform);
                XueZhangLang.gameObject.SetActive(false);
                GameController.S.XueZhangLangQueue.Enqueue(XueZhangLang.GetComponent<XueZhangLang>());
                
                
                 Collider2D XueZhangLangcollider2D=XueZhangLang.transform.Find("Collider").GetComponent<Collider2D>();
                                GameController.S.MonsterColliderDic.Add(XueZhangLangcollider2D,XueZhangLang.GetComponent<MonsterBase>());
                                
                var XueRen =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level5/XueRen").GetComponent<XueRen>(), GameController.S.transform);
                XueRen.gameObject.SetActive(false);
                GameController.S.XueRenQueue.Enqueue(XueRen.GetComponent<XueRen>());
                
                Collider2D XueRencollider2D=XueRen.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(XueRencollider2D,XueRen.GetComponent<MonsterBase>());
                
               
                var XueRenJian =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level5/XueRenJian").GetComponent<XueRenJian>(), GameController.S.transform);
                XueRenJian.gameObject.SetActive(false);
                GameController.S.XueRenJianQueue.Enqueue(XueRenJian.GetComponent<XueRenJian>());
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 15)
        {
            var XueRenBossSkill1 =
                Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level5/XueRenBossSkill1").GetComponent<XueRenBossSkill1>(), GameController.S.transform);
            XueRenBossSkill1.gameObject.SetActive(false);
            GameController.S.XueRenBossSkill1Queue.Enqueue(XueRenBossSkill1.GetComponent<XueRenBossSkill1>());
        }



        //精英怪队列
        if (LevelInfoConfig.CurrentGameLevel == 2|| LevelInfoConfig.CurrentGameLevel == 3)
        {
            for (int i = 0; i < 15; i++)
            {
                var eliteBeeMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level1/EliteBeeMonster").GetComponent<EliteBeeMonster>(),
                        GameController.S.transform);
                eliteBeeMonster.gameObject.SetActive(false);
                GameController.S.EliteBeeMonsterQueue.Enqueue(eliteBeeMonster.GetComponent<EliteBeeMonster>());
                
                Collider2D eliteBeeMonstercollider2D=eliteBeeMonster.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(eliteBeeMonstercollider2D,eliteBeeMonster.GetComponent<MonsterBase>());
                
            }
        }
        


        if (LevelInfoConfig.CurrentGameLevel == 5 || LevelInfoConfig.CurrentGameLevel == 6)
        {
            for (int i = 0; i < 15; i++)
            {
                var elitedazuiMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level2/EliteDaZuiMonster").GetComponent<EliteDaZuiMonster>(),
                        GameController.S.transform);
                elitedazuiMonster.gameObject.SetActive(false);
                GameController.S.EliteDaZuiMonsterQueue.Enqueue(elitedazuiMonster.GetComponent<EliteDaZuiMonster>());
                
                Collider2D elitedazuiMonstercollider2D=elitedazuiMonster.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(elitedazuiMonstercollider2D,elitedazuiMonster.GetComponent<MonsterBase>());
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
                
                Collider2D shirenhuaMonstercollider2D=shirenhuaMonster.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(shirenhuaMonstercollider2D,shirenhuaMonster.GetComponent<MonsterBase>());
            }

        }
        
        if (LevelInfoConfig.CurrentGameLevel == 11 || LevelInfoConfig.CurrentGameLevel == 12)
        {
            for (int i = 0; i < 15; i++)
            {
                var shamoElite =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaMoElite").GetComponent<ShaMoElite>(), GameController.S.transform);
                shamoElite.gameObject.SetActive(false);
                GameController.S.ShaMoEliteQueue.Enqueue(shamoElite.GetComponent<ShaMoElite>());
                
                var ShaXiYi =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaXiYi").GetComponent<ShaXiYi>(), GameController.S.transform);
                ShaXiYi.gameObject.SetActive(false);
                GameController.S.ShaXiYiQueue.Enqueue(ShaXiYi.GetComponent<ShaXiYi>());
                
                Collider2D shamoElitecollider2D=shamoElite.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(shamoElitecollider2D,shamoElite.GetComponent<MonsterBase>());
                
                Collider2D ShaXiYicollider2D=ShaXiYi.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(ShaXiYicollider2D,ShaXiYi.GetComponent<MonsterBase>());
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
                
                Collider2D Yingshucollider2D=YingShu.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(Yingshucollider2D,YingShu.GetComponent<MonsterBase>());
            }

        }
        
        
        //Boss技能队列
        if (LevelInfoConfig.CurrentGameLevel == 12)
        {
            for (int i = 0; i < 100; i++)
            {
                var xieziskill1= Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level4/XieZiSkill1").GetComponent<XieZiSkill1>(), GameController.S.transform);
                xieziskill1.gameObject.SetActive(false);
                GameController.S.XieZiSkill1Queue.Enqueue(xieziskill1);
            }
            
            for (int i = 0; i < 100; i++)
            {
                var xieziskill4= Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level4/XieZiSkill4").GetComponent<XieZiSkill4>(), GameController.S.transform);
                xieziskill4.gameObject.SetActive(false);
                GameController.S.XieZiSkill4Queue.Enqueue(xieziskill4);
            }
        }
        
        
        


        GameController.S.fightBG=Instantiate(Resources.Load<GameObject>("Prefabs/Window/FightBG"), GameController.S.transform);
        GameController.S.fightBG.transform.position = new Vector3(0, 0, 0.1f);
        GameController.S.monsterHpSliderPrefabs=Resources.Load<GameObject>("Prefabs/Tool/MonsterHPBloodBar");
        
        
        
        
        
        GameController.S.CreatePlayer();

        GameController.S.FirstlevelMonsterList.Add(GameController.S.snotMonster);
        GameController.S.FirstlevelMonsterList.Add(GameController.S.batMonster);
        GameController.S.FirstlevelMonsterList.Add(GameController.S.spiderMonster);
    }
}
