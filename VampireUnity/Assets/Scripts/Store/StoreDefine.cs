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
        public List<ChongWuTable> ChongWuList = new List<ChongWuTable>();


        
        
        
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
         
         ChongWuList=runtime.ChongWuList;
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
            runtime.ChongWuList=ChongWuList;
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
        public bool IceSkill1Auto=false;
        public bool DianSkill2Auto=false;
        public bool DianSkill3Auto=false;
        public bool HuoSkill3Auto=false;
        public bool HuoSkill2Auto=false;
        public bool HuoSkill1Auto=false;
        public bool HeiAnSkill1Auto=false;
        public bool HeiAnSkill2Auto=false;
        public bool HeiAnSkill3Auto=false;


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
            
            IceSkill1Auto=runtime.IceSkill1Auto;
            DianSkill2Auto=runtime.DianSkill2Auto;
            DianSkill3Auto=runtime.DianSkill3Auto;
            HuoSkill3Auto=runtime.HuoSkill3Auto;
            HuoSkill2Auto=runtime.HuoSkill2Auto;
            HuoSkill1Auto=runtime.HuoSkill1Auto;
            HeiAnSkill1Auto=runtime.HeiAnSkill1Auto;
            HeiAnSkill2Auto=runtime.HeiAnSkill2Auto;
            HeiAnSkill3Auto=runtime.HeiAnSkill3Auto;
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
            
            runtime.IceSkill1Auto=IceSkill1Auto;
            runtime.HeiAnSkill1Auto=HeiAnSkill1Auto;
            runtime.HeiAnSkill2Auto=HeiAnSkill2Auto;
            runtime.HeiAnSkill3Auto=HeiAnSkill3Auto;
            runtime.DianSkill2Auto=DianSkill2Auto;
            runtime.DianSkill3Auto=DianSkill3Auto;
            runtime.HuoSkill1Auto=HuoSkill1Auto;
            runtime.HuoSkill2Auto=HuoSkill2Auto;
            runtime.HuoSkill3Auto=HuoSkill3Auto;

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
    
        public int DianSkill1Damage=0;
        public int DianSkill1Cd=0;
        public int DianSkill1Range=0;
        public int DianSkill1YuanSu=0;
    
        public int DianSkill2=0;
        public int DianSkill2Cd=0;
        public int DianSkill2Duration=0;
        public int DianSkill2YuanSu=0;
    
        public int DianSkill3=0;
        public int DianSkill3Cd=0;
        public int DianSkill3Count=0;
        public int DianSkill3YuanSu=0;
    
        public int IceSkill1=0;
        public int IceSkill1Cd=0;
        public int IceSkill1Range=0;
        public int IceSkill1YuanSu=0;
    
        public int IceSkill2Damage=0;
        public int IceSkill2Cd=0;
        public int IceSkill2Time=0;
        public int IceSkill2YuanSu=0;
    
        public int IceSkill3Damage=0;
        public int IceSkill3Cd=0;
        public int IceSkill3Range=0;
        public int IceSkill3YuanSu=0;
    
    
        public int HuoSkill1=0;
        public int HuoSkill1Cd=0;
        public int HuoSkill1Count=0;
        public int HuoSkill1YuanSu=0;
    
        public int HuoSkill2=0;
        public int HuoSkill2Cd=0;
        public int HuoSkill2Time=0;
        public int HuoSkill2YuanSu=0;
    
        public int HuoSkill3=0;
        public int HuoSkill3Cd=0;
        public int HuoSkill3Count=0;
        public int HuoSkill3YuanSu=0;
    
    
        public int HeiAnSkill1=0;
        public int HeiAnSkill1Cd=0;
        public int HeiAnSkill1Range=0;
        public int HeiAnSkill1YuanSu=0;
    
        public int HeiAnSkill2Damage=0;
        public int HeiAnSkill2Cd=0;
        public int HeiAnSkill2Time=0;
        public int HeiAnSkill2YuanSu=0;
    
        public int HeiAnSkill3Damage=0;
        public int HeiAnSkill3Cd=0;
        public int HeiAnSkill3Range=0;
        public int HeiAnSkill3YuanSu=0;
        
        
        
        public int MonsterAttack;
        public int MonsterCrit;
        public int MonsterHp;
        public int MonsterDefense;
        
        public SkillYuanSuType skill1Type=SkillYuanSuType.None;
        public SkillYuanSuType skill2Type=SkillYuanSuType.None;
        public SkillYuanSuType skill3Type=SkillYuanSuType.None;

        
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
            
            DianSkill1Damage=runtime.DianSkill1Damage;
            DianSkill1Cd=runtime.DianSkill1Cd;
            DianSkill1Range=runtime.DianSkill1Range;
            DianSkill1YuanSu=runtime.DianSkill1YuanSu;
            
            DianSkill2 = runtime.DianSkill2;
            DianSkill2Cd=runtime.DianSkill2Cd;
            DianSkill2Duration=runtime.DianSkill2Duration;
            DianSkill2YuanSu=runtime.DianSkill2YuanSu;
            
            DianSkill3 = runtime.DianSkill3;
            DianSkill3Cd=runtime.DianSkill3Cd;
            DianSkill3Count=runtime.DianSkill3Count;
            DianSkill3YuanSu=runtime.DianSkill3YuanSu;
            
            IceSkill2Damage=runtime.IceSkill2Damage;
            IceSkill2Cd=runtime.IceSkill2Cd;
            IceSkill2Time=runtime.IceSkill2Time;
            IceSkill2YuanSu=runtime.IceSkill2YuanSu;
            
            
            IceSkill3Damage=runtime.IceSkill3Damage;
            IceSkill3Cd=runtime.IceSkill3Cd;
            IceSkill3Range=runtime.IceSkill3Range;
            IceSkill3YuanSu=runtime.IceSkill3YuanSu;
            
            HeiAnSkill2Damage = runtime.HeiAnSkill2Damage;
            HeiAnSkill2Cd=runtime.HeiAnSkill2Cd;
            HeiAnSkill2Time=runtime.HeiAnSkill2Time;
            HeiAnSkill2YuanSu=runtime.HeiAnSkill2YuanSu;
            
            HuoSkill2 = runtime.HuoSkill2;
            HuoSkill2Cd=runtime.HuoSkill2Cd;
            HuoSkill2Time=runtime.HuoSkill2Time;
            HuoSkill2YuanSu=runtime.HuoSkill2YuanSu;
            
            IceSkill1=runtime.IceSkill1;
            IceSkill1Range=runtime.IceSkill1Range;
            IceSkill1Cd=runtime.IceSkill1Cd;
            IceSkill1YuanSu=runtime.IceSkill1YuanSu;
            
            HuoSkill1=runtime.HuoSkill1;
            HuoSkill1Count=runtime.HuoSkill1Count;
            HuoSkill1Cd=runtime.HuoSkill1Cd;
            HuoSkill1YuanSu=runtime.HuoSkill1YuanSu;
            
            HuoSkill3=runtime.HuoSkill3;
            HuoSkill3Count=runtime.HuoSkill3Count;
            HuoSkill3Cd=runtime.HuoSkill3Cd;
            HuoSkill3YuanSu=runtime.HuoSkill3YuanSu;
            
            HeiAnSkill1=runtime.HeiAnSkill1;
            HeiAnSkill1Range=runtime.HeiAnSkill1Range;
            HeiAnSkill1Cd=runtime.HeiAnSkill1Cd;
            HeiAnSkill1YuanSu=runtime.HeiAnSkill1YuanSu;
            
            HeiAnSkill3Damage=runtime.HeiAnSkill3Damage;
            HeiAnSkill3Range=runtime.HeiAnSkill3Range;
            HeiAnSkill3Cd=runtime.HeiAnSkill3Cd;
            HeiAnSkill3YuanSu=runtime.HeiAnSkill3YuanSu;
            
            MonsterAttack = runtime.MonsterAttack;
            MonsterCrit = runtime.MonsterCrit;
            MonsterDefense = runtime.MonsterDefense;
            MonsterHp = runtime.MonsterHp;
            
            skill1Type=runtime.skill1Type;
            skill2Type=runtime.skill2Type;
            skill3Type=runtime.skill3Type;
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
            
            
            
            runtime.DianSkill1Damage=DianSkill1Damage;
            runtime.DianSkill1Cd=DianSkill1Cd;
            runtime.DianSkill1Range=DianSkill1Range;
            runtime.DianSkill1YuanSu=DianSkill1YuanSu;
            
            runtime.DianSkill2=DianSkill2;
            runtime.DianSkill2Cd=DianSkill2Cd;
            runtime.DianSkill2Duration=DianSkill2Duration;
            runtime.DianSkill2YuanSu=DianSkill2YuanSu;
            
            runtime.DianSkill3=DianSkill3;
            runtime.DianSkill3Cd=DianSkill3Cd;
            runtime.DianSkill3Count=DianSkill3Count;
            runtime.DianSkill3YuanSu=DianSkill3YuanSu;
            
            runtime.IceSkill2Damage=IceSkill2Damage;
            runtime.IceSkill2Cd=IceSkill2Cd;
            runtime.IceSkill2Time=IceSkill2Time;
            runtime.IceSkill2YuanSu=IceSkill2YuanSu;
            
            
            runtime.IceSkill3Damage=IceSkill3Damage;
            runtime.IceSkill3Cd=IceSkill3Cd;
            runtime.IceSkill3Range=IceSkill3Range;
            runtime.IceSkill3YuanSu=IceSkill3YuanSu;
            
            runtime.HeiAnSkill2Damage=HeiAnSkill2Damage;
            runtime.HeiAnSkill2Cd=HeiAnSkill2Cd;
            runtime.HeiAnSkill2Time=HeiAnSkill2Time;
            runtime.HeiAnSkill2YuanSu=HeiAnSkill2YuanSu;
            
            runtime.HuoSkill2=HuoSkill2;
            runtime.HuoSkill2Cd=HuoSkill2Cd;
            runtime.HuoSkill2Time=HuoSkill2Time;
            runtime.HuoSkill2YuanSu=HuoSkill2YuanSu;
            
            runtime.IceSkill1=IceSkill1;
            runtime.IceSkill1Range=IceSkill1Range;
            runtime.IceSkill1Cd=IceSkill1Cd;
            runtime.IceSkill1YuanSu=IceSkill1YuanSu;
            
            runtime.HuoSkill1=HuoSkill1;
            runtime.HuoSkill1Count=HuoSkill1Count;
            runtime.HuoSkill1Cd=HuoSkill1Cd;
            runtime.HuoSkill1YuanSu=HuoSkill1YuanSu;
            
            runtime.HuoSkill3=HuoSkill3;
            runtime.HuoSkill3Count=HuoSkill3Count;
            runtime.HuoSkill3Cd=HuoSkill3Cd;
            runtime.HuoSkill3YuanSu=HuoSkill3YuanSu;
            
            runtime.HeiAnSkill1=HeiAnSkill1;
            runtime.HeiAnSkill1Range=HeiAnSkill1Range;
            runtime.HeiAnSkill1Cd=HeiAnSkill1Cd;
            runtime.HeiAnSkill1YuanSu=HeiAnSkill1YuanSu;
            
            runtime.HeiAnSkill3Damage=HeiAnSkill3Damage;
            runtime.HeiAnSkill3Range=HeiAnSkill3Range;
            runtime.HeiAnSkill3Cd=HeiAnSkill3Cd;
            runtime.HeiAnSkill3YuanSu=HeiAnSkill3YuanSu;

            
            
            
            runtime.MonsterAttack = MonsterAttack;
            runtime.MonsterCrit = MonsterCrit;
            runtime.MonsterDefense = MonsterDefense;
            runtime.MonsterHp = MonsterHp;
            
            runtime.skill1Type=skill1Type;
            runtime.skill2Type=skill2Type;
            runtime.skill3Type=skill3Type;

        }

    }
}
