using System;
using System.Collections.Generic;
using Mysql;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Entrance : MonoBehaviour
{
    private void Awake()
    { 
            GameController.S.MonsterColliderDic.Clear();
        
            Application.targetFrameRate = 30;
            GlobalPlayerAttribute.CurrentHp = GlobalPlayerAttribute.TotalMaxHp;
            LevelInfoConfig.IsOneGame = false;
            
            AudioController.S.BGAudioSource.clip = Resources.Load<AudioClip>("Audio/BG/Level1BG");
            AudioController.S.BGAudioSource.Play();
            
            
            //初始化最大boss能量值
            GameController.S.MaxBossEnergyNum = LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel]*2;//这时小怪数量，精英不算数量，每10只普通怪出一只精英，所以正好是2倍
            GameController.S.MaxBossEnergyNum = 10;

    //实例化
        //FightBGController
        
        
        //装备对象池
        for (int i = 0; i < 10; i++)
        {
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
            GameController.S.OrangeCloakQueue.Enqueue(OrangeCloakFight);
            
            GameObject OrangeClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeClothFight"));
            OrangeClothFight.gameObject.SetActive(false);
            GameController.S.OrangeClothQueue.Enqueue(OrangeClothFight);
            
            GameObject OrangeRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeRingFight"));
            OrangeRingFight.gameObject.SetActive(false);
            GameController.S.OrangeRingQueue.Enqueue(OrangeRingFight);
            
            GameObject OrangeShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeShoeFight"));
            OrangeShoeFight.gameObject.SetActive(false);
            GameController.S.OrangeShoeQueue.Enqueue(OrangeShoeFight);
            
            GameObject OrangeNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeNecklaceFight"));
            OrangeNecklaceFight.gameObject.SetActive(false);
            GameController.S.OrangeNecklaceQueue.Enqueue(OrangeNecklaceFight);
            
            GameObject OrangeHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/OrangeHelmetFight"));
            OrangeHelmetFight.gameObject.SetActive(false);
            GameController.S.OrangeHelmetQueue.Enqueue(OrangeHelmetFight);
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
            
            var batskillparticle= Instantiate(Resources.Load("Prefabs/Skill/BatSkillParticle").GetComponent<ParticleSystem>(), new Vector3(0, 0, 0), Quaternion.identity);
            batskillparticle.gameObject.SetActive(false);
            FightBGController.S.BatSkillParticleQueue.Enqueue(batskillparticle.GetComponent<ParticleSystem>());
            
        }
        
        
        //初始化技能队列
        for (int i = 0; i < 100; i++)
        {
            var dianqian= Instantiate(Resources.Load("Prefabs/Skill/DianQuan/DianQuan"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            dianqian.SetActive(false);
            GameController.S.DianQuanQueue.Enqueue(dianqian);
        }

        for (int i = 0; i < 100; i++)
        {
            var spiderWeb= Instantiate(Resources.Load("Prefabs/Monster/Level1/SpiderWeb"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            spiderWeb.SetActive(false);
            FightBGController.S.SpiderWebQueue.Enqueue(spiderWeb.GetComponent<SpiderWeb>());

            switch ( GlobalPlayerAttribute.CurrentWeaponType)
            {
                case WeaponType.Primary:
                    var threeNormalAttack= Instantiate(Resources.Load("Prefabs/Skill/3NormalAttack"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    threeNormalAttack.SetActive(false);
                    GameController.S.ThreeNormalAttackQueue.Enqueue(threeNormalAttack);
                    
                    
                    var threeNormalAttackhit= Instantiate(Resources.Load("Prefabs/Skill/3NormalAttackHit"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    threeNormalAttackhit.SetActive(false);
                    GameController.S.ThreeNormalAttackHitQueue.Enqueue(threeNormalAttackhit);
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
                    var lvNormalAttack= Instantiate(Resources.Load("Prefabs/Skill/2NormalAttackPrefab"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    lvNormalAttack.SetActive(false);
                    GameController.S.LvQuanQueue.Enqueue(lvNormalAttack);
                    break;
                    
            }
        }
        
        FightBGController.S.DiLie=Instantiate(Resources.Load("Prefabs/Skill/BossGroundFissure"), new Vector3(0,0,0), Quaternion.identity) as GameObject;
        FightBGController.S.DiLie.SetActive(false);
        FightBGController.S.TreeManBoss=Instantiate(Resources.Load("Prefabs/Monster/Level1/TreeManBOSS"), new Vector3(0,0,0), Quaternion.identity).GetComponent<TreeManBoss>();
        FightBGController.S.TreeManBoss.gameObject.SetActive(false);
        
        FightBGController.S.CircleAttack = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/CircleAttack")).gameObject;
        FightBGController.S.CircleAttack.SetActive(false);

        
        //初始化怪物队列
        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 || LevelInfoConfig.CurrentGameLevel == 3)
        {
            for (int i = 0; i < 100; i++)
            {
                var snotMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level1/SnotMonster").GetComponent<SnotMonster>(),
                        GameController.S.transform);
                snotMonster.gameObject.SetActive(false);
                GameController.S.SnotMonsterQueue.Enqueue(snotMonster.GetComponent<SnotMonster>());

                var batMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level1/BatMonster").GetComponent<BatMonster>(),
                        GameController.S.transform);
                batMonster.gameObject.SetActive(false);
                GameController.S.BatMonsterQueue.Enqueue(batMonster.GetComponent<BatMonster>());

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
        
        if (LevelInfoConfig.CurrentGameLevel == 4 || LevelInfoConfig.CurrentGameLevel == 5 || LevelInfoConfig.CurrentGameLevel == 6)
        {
            for (int i = 0; i < 100; i++)
            {
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

                var daZuiSkillTriggerLeft =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Tool/DaZuiSkillTriggerLeft").GetComponent<DaZuiSkillTriggerLeft>(),
                        GameController.S.transform);
                daZuiSkillTriggerLeft.gameObject.SetActive(false);
                GameController.S.DaZuiSkillTriggerQueueLeft.Enqueue(daZuiSkillTriggerLeft.GetComponent<DaZuiSkillTriggerLeft>());
                var daZuiSkillTriggerRight =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Tool/DaZuiSkillTriggerRight").GetComponent<DaZuiSkillTriggerRight>(),
                        GameController.S.transform);
                daZuiSkillTriggerRight.gameObject.SetActive(false);
                GameController.S.DaZuiSkillTriggerQueueRight.Enqueue(daZuiSkillTriggerRight.GetComponent<DaZuiSkillTriggerRight>());
                
                
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
                var huangshu =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level4/HuangShuMonster").GetComponent<HuangShu>(),
                        GameController.S.transform);
                huangshu.gameObject.SetActive(false);
                GameController.S.HuangShuQueue.Enqueue(huangshu.GetComponent<HuangShu>());

                var Huangzhu =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level4/HuangZhuMonster").GetComponent<Huangzhu>(),
                        GameController.S.transform);
                Huangzhu.gameObject.SetActive(false);
                GameController.S.HuangZhuQueue.Enqueue(Huangzhu.GetComponent<Huangzhu>());
                
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
                
                Collider2D Huangshucollider2D=huangshu.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(Huangshucollider2D,huangshu.GetComponent<MonsterBase>());
                
                Collider2D Huangzhucollider2D=Huangzhu.transform.Find("Collider").GetComponent<Collider2D>();
                GameController.S.MonsterColliderDic.Add(Huangzhucollider2D,Huangzhu.GetComponent<MonsterBase>());
                
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
            }
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

                var beeMonsterSkillTrigger =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Tool/BeeSkillTrigger")
                            .GetComponent<BeeMonsterSkillTrigger>(), GameController.S.transform);
                beeMonsterSkillTrigger.gameObject.SetActive(false);
                GameController.S.BeeMonsterSkillTriggerQueue.Enqueue(beeMonsterSkillTrigger
                    .GetComponent<BeeMonsterSkillTrigger>());
                
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
        
        
        
        


        GameController.S.fightBG=Instantiate(Resources.Load<GameObject>("Prefabs/Window/FightBG"), GameController.S.transform);
        GameController.S.fightBG.transform.position = new Vector3(0, 0, 0.1f);
        GameController.S.monsterHpSliderPrefabs=Resources.Load<GameObject>("Prefabs/Tool/MonsterHPBloodBar");
        
        
        
        
        
        GameController.S.CreatePlayer();

        GameController.S.FirstlevelMonsterList.Add(GameController.S.snotMonster);
        GameController.S.FirstlevelMonsterList.Add(GameController.S.batMonster);
        GameController.S.FirstlevelMonsterList.Add(GameController.S.spiderMonster);

        GameController.S.monsterDetetor1 = new HashSet<MonsterBase>();
        GameController.S.monsterDetetor2 = new HashSet<MonsterBase>();
        GameController.S.monsterDetetor3 = new HashSet<MonsterBase>();
        GameController.S.monsterDetetor4 = new HashSet<MonsterBase>();
        
    }
}
