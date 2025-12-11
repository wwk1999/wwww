using System.Collections;
using System.Collections.Generic;
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
        
        public int clothid;
        public int cloakid;
        public int helmetid;
        public int ringid;
        public int shoeid;
        public int necklaceid;

        public void CopyFromRuntime(PlayerData runtime)
        {
            level = runtime.level;
            exp = runtime.exp;
            bloodEnergy = runtime.bloodEnergy;
            gameLevel = runtime.maxGameLevel;
            
            clothid = runtime.clothid;
            cloakid = runtime.cloakid;
            helmetid = runtime.helmetid;
            ringid = runtime.ringid;
            shoeid = runtime.shoeid;
            necklaceid = runtime.necklaceid;
        }

        public void ApplyToRuntime(PlayerData runtime)
        {
            runtime.level = level;
            runtime.exp = exp;
            runtime.bloodEnergy = bloodEnergy;
            runtime.maxGameLevel = gameLevel;
            runtime.clothid = clothid;
            runtime.cloakid = cloakid;
            runtime.helmetid = helmetid;
            runtime.ringid = ringid;
            runtime.shoeid = shoeid;
            runtime.necklaceid = necklaceid;
        }
    }
    
    [System.Serializable]
    public class SkillData1
    {
        public SkillType LMB = SkillType.Normal;
        public SkillType RMB = SkillType.Dash;
        public SkillType Alpha1 = SkillType.Skill1;
        public SkillType Alpha2 = SkillType.Skill2;
        public SkillType Alpha3 = SkillType.Skill3;
        

        public void CopyFromRuntime(SkillData runtime)
        {
            LMB=runtime.LMB;
            RMB=runtime.RMB;
            Alpha1=runtime.Alpha1;
            Alpha2=runtime.Alpha2;
            Alpha3=runtime.Alpha3;
        }

        public void ApplyToRuntime(SkillData runtime)
        {
            runtime.LMB=LMB;
            runtime.RMB=RMB;
            runtime.Alpha1=Alpha1;
            runtime.Alpha2=Alpha2;
            runtime.Alpha3=Alpha3;
        }
    }
    
    [System.Serializable]
    public class SkillJiaDian1
    {
        public float NormalAttack=0;
        public float NormalSpeed=0;
    
        public float Crit=0;
        public float CritDamage=0;
    
        public float MoveSpeed=0;
        public float MoveAddAttack=0;
        public float MoveAddDefense=0;
    
        public float DashCd=0;
        public float DashAddDefense=0;
    
        public float Skill1Damage=0;
        public float Skill1Cd=0;
        public float Skill1Range=0;
        public float Skill1YiDian=0;
    
        public float Skill2Damage=0;
        public float Skill2Cd=0;
        public float Skill2Time=0;
        public float Skill2AddDefense=0;
    
        public float Skill3Damage=0;
        public float Skill3Cd=0;
        public float Skill3Range=0;
        public float Skill3JianSu=0;
        
        public void CopyFromRuntime(SkillJiaDian runtime)
        {
            NormalAttack=runtime.NormalAttack;
            NormalSpeed=runtime.NormalSpeed;
            Crit=runtime.Crit;
            CritDamage=runtime.CritDamage;
            MoveSpeed=runtime.MoveSpeed;
            MoveAddAttack = runtime.MoveAddAttack;
            MoveAddDefense=runtime.MoveAddDefense;
            DashCd=runtime.DashCd;
            DashAddDefense=runtime.DashAddDefense;
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
        }

        public void ApplyToRuntime(SkillJiaDian runtime)
        {
            runtime.NormalAttack=NormalAttack;
            runtime.NormalSpeed=NormalSpeed;
            Crit=runtime.Crit;
            CritDamage=runtime.CritDamage; 
            MoveSpeed=runtime.MoveSpeed;
            MoveAddAttack = runtime.MoveAddAttack;
            MoveAddDefense=runtime.MoveAddDefense;
            DashCd=runtime.DashCd;
            DashAddDefense=runtime.DashAddDefense;
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
        }

    }
}
