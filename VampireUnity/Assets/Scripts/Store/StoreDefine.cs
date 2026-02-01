using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class StoreDefine : XSingleton<StoreDefine>
{
    [System.Serializable]
    public class StoreData
    {
        public EquipData Equip = new EquipData();
        public PlayData Player = new PlayData();
        public SkillData1 Skill = new SkillData1();
        public SkillJiaDian1 SkillJiaDian1 = new SkillJiaDian1();
    }

    [System.Serializable]
    public class EquipData
    {
        public Dictionary<int,EquipTable> equipIds = new Dictionary<int, EquipTable>();
        public Dictionary<int,PropTable> propTables = new Dictionary<int,PropTable>();
        public int nextEquipId;

        public void CopyFromRuntime(EquipIDData runtime)
        {
            if (runtime == null) return;

            nextEquipId = runtime.nextEquipId;
            equipIds.Clear();
            foreach (var pair in runtime.equipIds)
            {
                equipIds.Add(pair.Key,pair.Value);
            }
            propTables.Clear();
            foreach (var pair in runtime.propTables)
            {
                propTables.Add(pair.Key, pair.Value);
            }
        }

        public void ApplyToRuntime(EquipIDData runtime)
        {
            if (runtime == null) return;

            runtime.nextEquipId = nextEquipId;
            runtime.equipIds.Clear();
            foreach (var pair in equipIds)
            {
                runtime.equipIds.Add(pair.Key,pair.Value);
            }
            runtime.propTables.Clear();
            foreach (var pair in propTables)
            {
                runtime.propTables.Add(pair.Key, pair.Value);
            }
        }
    }

    [System.Serializable]
    public class PlayData
    {
        public int level;
        public int exp;
        public int bloodEnergy;
        public int gameLevel;
        public int ChiBangLevel;
        public int ChiBangEx;
        
        public int clothid;
        public int cloakid;
        public int helmetid;
        public int ringid;
        public int shoeid;
        public int necklaceid;
        
        public int primaryWeaponLevel=1;
        public int duWeaponLevel;
        public int puTong3WeaponLevel;
        public int xuKongWeaponLevel;
        public int lvQuanWeaponLevel;
        public int fireWeaponLevel;
        public int heiDongWeaponLevel;
        public int jianQiWeaponLevel;
        
        public int primaryHunQiLevel=0;
        public int duHunQiLevel=0;
        public int puTong3HunQiLevel=0;
        public int xuKongHunQiLevel=0;
        public int lvQuanHunQiLevel=0;
        public int fireHunQiLevel=0;
        public int heiDongHunQiLevel=0;
        public int jianQiHunQiLevel=0;
        
        
        public int primaryHunQiEx=0;
        public int duHunQiEx=0;
        public int puTong3HunQiEx=0;
        public int xuKongHunQiEx=0;
        public int lvQuanHunQiEx=0;
        public int fireHunQiEx=0;
        public int heiDongHunQiEx=0;
        public int jianQiHunQiEx=0;

        public int zhuanjinCount = 0;
        
        
        public WeaponType playerWeaponType=WeaponType.Primary;
        public MJLevel mJLevel = MJLevel.White;
        public LanguageType langType=LanguageType.Chinese;


        
        
        
        public bool Level5 = false;
        public bool Level15 = false;
        public bool Level30 = false;
        public bool Level50 = false;
        public bool Level75 = false;
        public bool Level100 = false;
    
        public bool MonsterCount1 = false;
        public bool MonsterCount2 = false;
        public bool MonsterCount3 = false;
        public bool MonsterCount4 = false;
        public bool MonsterCount5 = false;
        public bool MonsterCount6 = false;

        public bool LingHun = false;
        public bool BaoShi = false;
        public bool GuanKa3 = false;
        public bool GuanKa4 = false;
        public bool GuanKa5 = false;
        public bool HunQi3 = false;
        public bool HunQi4 = false;
        public bool HunQi5 = false;
        public bool ChiBang4 = false;
        public bool ChiBang5 = false;
        public bool DiaoLuo = false;
        
        
        public int MonsterCount = 0;
        public int LinHun = 0;

        public TitleType CurrentInstallTitle = TitleType.None;



        public void CopyFromRuntime(PlayerData runtime)
        {
            level = runtime.level;
            exp = runtime.exp;
            bloodEnergy = runtime.bloodEnergy;
            gameLevel = runtime.maxGameLevel;
            ChiBangLevel = runtime.ChiBangLevel;
            ChiBangEx = runtime.ChiBangEx;
            
            clothid = runtime.clothid;
            cloakid = runtime.cloakid;
            helmetid = runtime.helmetid;
            ringid = runtime.ringid;
            shoeid = runtime.shoeid;
            necklaceid = runtime.necklaceid;

            primaryWeaponLevel = runtime.primaryWeaponLevel;
            duWeaponLevel = runtime.duWeaponLevel;
            puTong3WeaponLevel = runtime.puTong3WeaponLevel;
            xuKongWeaponLevel = runtime.xuKongWeaponLevel;
            lvQuanWeaponLevel = runtime.lvQuanWeaponLevel;
            fireWeaponLevel = runtime.fireWeaponLevel;
            heiDongWeaponLevel = runtime.heiDongWeaponLevel;
            jianQiWeaponLevel = runtime.jianQiWeaponLevel;
            zhuanjinCount=runtime.zhuanjinCount;
            
            
            primaryHunQiLevel = runtime.primaryHunQiLevel;
            duHunQiLevel = runtime.duHunQiLevel;
            puTong3HunQiLevel = runtime.puTong3HunQiLevel;
            xuKongHunQiLevel = runtime.xuKongHunQiLevel;
            lvQuanHunQiLevel = runtime.lvQuanHunQiLevel;
            fireHunQiLevel = runtime.fireHunQiLevel;
            heiDongHunQiLevel = runtime.heiDongHunQiLevel;
            jianQiHunQiLevel = runtime.jianQiHunQiLevel;
            
            
            primaryHunQiEx = runtime.primaryHunQiEx;
            duHunQiEx = runtime.duHunQiEx;
            puTong3HunQiEx = runtime.puTong3HunQiEx;
            xuKongHunQiEx = runtime.xuKongHunQiEx;
            lvQuanHunQiEx = runtime.lvQuanHunQiEx;
            fireHunQiEx = runtime.fireHunQiEx;
            heiDongHunQiEx = runtime.heiDongHunQiEx;
            jianQiHunQiEx = runtime.jianQiHunQiEx;


            playerWeaponType = runtime.playerWeaponType;
            mJLevel = runtime.mJLevel;
            langType = runtime.langType;
            
         Level5 = runtime.Level5;
         Level15 = runtime.Level15;
         Level30 = runtime.Level30;
         Level50 = runtime.Level50;
         Level75 = runtime.Level75;
         Level100 = runtime.Level100;
    
         MonsterCount1 = runtime.MonsterCount1;
         MonsterCount2 = runtime.MonsterCount2;
         MonsterCount3 = runtime.MonsterCount3;
         MonsterCount4 = runtime.MonsterCount4;
         MonsterCount5 = runtime.MonsterCount5;
         MonsterCount6 = runtime.MonsterCount6;

         LingHun = runtime.LingHun;
         BaoShi = runtime.BaoShi;
         GuanKa3 = runtime.GuanKa3;
         GuanKa4 = runtime.GuanKa4;
         GuanKa5 = runtime.GuanKa5;
         HunQi3 = runtime.HunQi3;
         HunQi4 = runtime.HunQi4;
         HunQi5 = runtime.HunQi5;
         ChiBang4 = runtime.ChiBang4;
         ChiBang5 = runtime.ChiBang5;
         DiaoLuo = runtime.DiaoLuo;

         MonsterCount=runtime.MonsterCount;
         LinHun=runtime.LinHun;
         CurrentInstallTitle=runtime.CurrentInstallTitle;
        }

        public void ApplyToRuntime(PlayerData runtime)
        {
            runtime.level = level;
            runtime.exp = exp;
            runtime.bloodEnergy = bloodEnergy;
            runtime.maxGameLevel = gameLevel;
            runtime.ChiBangLevel = ChiBangLevel;
            runtime.ChiBangEx = ChiBangEx;
            
            runtime.clothid = clothid;
            runtime.cloakid = cloakid;
            runtime.helmetid = helmetid;
            runtime.ringid = ringid;
            runtime.shoeid = shoeid;
            runtime.necklaceid = necklaceid;
            
            runtime.primaryWeaponLevel = primaryWeaponLevel;
            runtime.duWeaponLevel = duWeaponLevel;
            runtime.puTong3WeaponLevel = puTong3WeaponLevel;
            runtime.xuKongWeaponLevel = xuKongWeaponLevel;
            runtime.lvQuanWeaponLevel = lvQuanWeaponLevel;
            runtime.fireWeaponLevel = fireWeaponLevel;
            runtime.heiDongWeaponLevel = heiDongWeaponLevel;
            runtime.jianQiWeaponLevel = jianQiWeaponLevel;
            
            runtime.primaryHunQiLevel = primaryHunQiLevel;
            runtime.duHunQiLevel = duHunQiLevel;
            runtime.puTong3HunQiLevel = puTong3HunQiLevel;
            runtime.xuKongHunQiLevel = xuKongHunQiLevel;
            runtime.lvQuanHunQiLevel = lvQuanHunQiLevel;
            runtime.fireHunQiLevel = fireHunQiLevel;
            runtime.heiDongHunQiLevel = heiDongHunQiLevel;
            runtime.jianQiHunQiLevel = jianQiHunQiLevel;
            
            
            runtime.primaryHunQiEx = primaryHunQiEx;
            runtime.duHunQiEx = duHunQiEx;
            runtime.puTong3HunQiEx = puTong3HunQiEx;
            runtime.xuKongHunQiEx = xuKongHunQiEx;
            runtime.lvQuanHunQiEx = lvQuanHunQiEx;
            runtime.fireHunQiEx = fireHunQiEx;
            runtime.heiDongHunQiEx = heiDongHunQiEx;
            runtime.jianQiHunQiEx = jianQiHunQiEx;
            
            
            runtime.zhuanjinCount = zhuanjinCount;
            
            
            runtime.playerWeaponType = playerWeaponType;
            runtime.mJLevel = mJLevel;
            runtime.langType = langType;
            
            
            
            runtime.Level5=Level5;
            runtime.Level15=Level15;
            runtime.Level30=Level30;
            runtime.Level50=Level50;
            runtime.Level75=Level75;
            runtime.Level100=Level100;
            runtime.MonsterCount1=MonsterCount1;
            runtime.MonsterCount2=MonsterCount2;
            runtime.MonsterCount3=MonsterCount3;
            runtime.MonsterCount4=MonsterCount4;
            runtime.MonsterCount5=MonsterCount5;
            runtime.MonsterCount6=MonsterCount6;

            runtime.LingHun=LingHun;
            runtime.BaoShi=BaoShi;
            runtime.GuanKa3=GuanKa3;
            runtime.GuanKa4=GuanKa4;
            runtime.GuanKa5=GuanKa5;
            runtime.HunQi3=HunQi3;
            runtime.HunQi4=HunQi4;
            runtime.HunQi5=HunQi5;
            runtime.ChiBang4=ChiBang4;
            runtime.ChiBang5=ChiBang5;
            runtime.DiaoLuo=DiaoLuo;


            runtime.MonsterCount = MonsterCount;
            runtime.LinHun=LinHun;
            
            runtime.CurrentInstallTitle=CurrentInstallTitle;
        }
    }
    
    [System.Serializable]
    public class SkillData1
    {
        public SkillType LMB = SkillType.Normal;
        public SkillType RMB = SkillType.None;
        public SkillType Alpha1 = SkillType.None;
        public SkillType Alpha2 = SkillType.None;
        public SkillType Alpha3 = SkillType.None;
        
        public bool skill1Auto=false;
        public bool skill2Auto=false;
        public bool skill3Auto=false;
        public bool dashAuto=false;

        public void CopyFromRuntime(SkillData runtime)
        {
            LMB=runtime.LMB;
            RMB=runtime.RMB;
            Alpha1=runtime.Alpha1;
            Alpha2=runtime.Alpha2;
            Alpha3=runtime.Alpha3;
            skill1Auto=runtime.skill1Auto;
            skill2Auto=runtime.skill2Auto;
            skill3Auto=runtime.skill3Auto;
            dashAuto=runtime.dashAuto;
        }

        public void ApplyToRuntime(SkillData runtime)
        {
            runtime.LMB=LMB;
            runtime.RMB=RMB;
            runtime.Alpha1=Alpha1;
            runtime.Alpha2=Alpha2;
            runtime.Alpha3=Alpha3;
            runtime.skill1Auto=skill1Auto;
            runtime.skill2Auto=skill2Auto;
            runtime.skill3Auto=skill3Auto;
            runtime.dashAuto = dashAuto;
        }
    }
    
    [System.Serializable]
    public class SkillJiaDian1
    {
        public int CurrentSkillCount = 0;
        
        public int NormalAttack=0;
        public int AttackSpeed=0;
    
        public int Crit=0;
        public int CritDamage=0;
    
        public int MoveSpeed=0;
        public int MoveAddAttack=0;
        public int MoveAddDefense=0;
    
        public int Dash=0;
        public int DashCd=0;
    
        public int Skill1Damage=0;
        public int Skill1Cd=0;
        public int Skill1Range=0;
        public int Skill1YiDian=0;
    
        public int Skill2Damage=0;
        public int Skill2Cd=0;
        public int Skill2Time=0;
        public int Skill2AddDefense=0;
    
        public int Skill3Damage=0;
        public int Skill3Cd=0;
        public int Skill3Range=0;
        public int Skill3JianSu=0;
        
        public int MonsterAttack;
        public int MonsterCrit;
        public int MonsterHp;
        public int MonsterDefense;

        
        public void CopyFromRuntime(SkillJiaDian runtime)
        {
            CurrentSkillCount=runtime.CurrentSkillCount;
            NormalAttack=runtime.NormalAttack;
            AttackSpeed=runtime.AttackSpeed;
            Crit=runtime.Crit;
            CritDamage=runtime.CritDamage;
            MoveSpeed=runtime.MoveSpeed;
            MoveAddAttack = runtime.MoveAddAttack;
            MoveAddDefense=runtime.MoveAddDefense;
            DashCd=runtime.DashCd;
            Dash=runtime.Dash;
            Skill1Damage=runtime.Skill1Damage;
            Skill1Cd=runtime.Skill1Cd;
            Skill1Range=runtime.Skill1Range;
            Skill1YiDian=runtime.Skill1YiDian;
            Skill2Damage=runtime.Skill2Damage;
            Skill2Cd=runtime.Skill2Cd;
            Skill2Time=runtime.Skill2Time;
            Skill2AddDefense=runtime.Skill2AddDefense;
            Skill3Damage=runtime.Skill3Damage;
            Skill3Cd=runtime.Skill3Cd;
            Skill3Range=runtime.Skill3Range;
            Skill3JianSu=runtime.Skill3JianSu;

            MonsterAttack = runtime.MonsterAttack;
            MonsterCrit = runtime.MonsterCrit;
            MonsterDefense = runtime.MonsterDefense;
            MonsterHp = runtime.MonsterHp;

        }

        public void ApplyToRuntime(SkillJiaDian runtime)
        {
            runtime.CurrentSkillCount = CurrentSkillCount;
            runtime.NormalAttack=NormalAttack;
            runtime.AttackSpeed=AttackSpeed;
            runtime.Crit=Crit;
            runtime.CritDamage=CritDamage; 
            runtime.MoveSpeed=MoveSpeed;
            runtime.MoveAddAttack=MoveAddAttack;
            runtime.MoveAddDefense=MoveAddDefense;
            runtime.DashCd=DashCd;
            runtime.Dash=Dash;
            runtime.Skill1Damage=Skill1Damage;
            runtime.Skill1Cd=Skill1Cd;
            runtime.Skill1Range=Skill1Range;
            runtime.Skill1YiDian=Skill1YiDian;
            runtime.Skill2Damage=Skill2Damage;
            runtime.Skill2Cd=Skill2Cd;
            runtime.Skill2Time=Skill2Time;
            runtime.Skill2AddDefense=Skill2AddDefense;
            runtime.Skill3Damage=Skill3Damage;
            runtime.Skill3Cd=Skill3Cd;
            runtime.Skill3Range=Skill3Range;
            runtime.Skill3JianSu=Skill3JianSu;

            runtime.MonsterAttack = MonsterAttack;
            runtime.MonsterCrit = MonsterCrit;
            runtime.MonsterDefense = MonsterDefense;
            runtime.MonsterHp = MonsterHp;
        }

    }
}
