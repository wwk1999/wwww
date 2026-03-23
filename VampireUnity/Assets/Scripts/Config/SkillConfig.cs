using System;
using System.Collections.Generic;

namespace Config
{

    public enum MonsterType
    {
        None,
        Attack,
        Defense,
        Hp,
        Crit
    }
    public class SkillConfig
    {
        public enum SkillButtonType
        {
            None,                    // 无
            NormalAttack,            // 普通攻击
            AttackSpeed,             // 攻击速度
            Dash,                    // 冲刺
            DashCd,                  // 冲刺冷却
            Crit,                    // 暴击
            CritDamage,              // 暴击伤害
            MoveSpeed,               // 移动速度
            MoveAddDefense,          // 移动时增加防御
            MoveAddAttack,           // 移动时增加攻击
            Skill1,                  // 技能1
            Skill2,                  // 技能2
            Skill3,                  // 技能3
            Skill1Cd,                // 技能1冷却
            Skill2Cd,                // 技能2冷却
            Skill3Cd,                // 技能3冷却
            Skill1Range,             // 技能1范围
            Skill1YuanSu,            // 技能1易点
            Skill2Time,              // 技能2时间
            Skill2YuanSu,        // 技能2增加防御
            Skill3Range,             // 技能3范围
            Skill3YuanSu,            // 技能3减速
            Attack,                  // 攻击
            Hp,                      // 生命值
            Defense,                 // 防御
            CritMonster,              // 暴击怪物
            IceSkill1,
            IceSkill1Range,
            IceSkill1CD,
            IceSkill1YuanSu,
            DianSkill2,
            DianSkill2Time,
            DianSkill2CD,
            DianSkill2YuanSu,
            
            DianSkill3,
            DianSkill3Count,
            DianSkill3CD,
            DianSkill3YuanSu,
            
            
            HuoSkill1,
            HuoSkill1Count,
            HuoSkill1CD,
            HuoSkill1YuanSu,
            
            HuoSkill2,
            HuoSkill2Time,
            HuoSkill2CD,
            HuoSkill2YuanSu,
            
            HuoSkill3,
            HuoSkill3Count,
            HuoSkill3CD,
            HuoSkill3YuanSu,
            
            HeiAnSkill1,
            HeiAnSkill1Range,
            HeiAnSkill1CD,
            HeiAnSkill1YuanSu,
            
            HeiAnSkill2,
            HeiAnSkill2Time,
            HeiAnSkill2CD,
            HeiAnSkill2YuanSu,
            
            HeiAnSkill3,
            HeiAnSkill3Range,
            HeiAnSkill3CD,
            HeiAnSkill3YuanSu,
        }

        public enum ZhuDongSkillTime
        {
            None,
            IceSkill1,
            IceSkill2,
            IceSkill3,
            IceSkill4,
            IceSkill5,
            
            DianSkill1,
            DianSkill2,
            DianSkill3,
            HuoSkill4,
            HuoSkill5,
            
            HuoSkill1,
            HuoSkill2,
            HuoSkill3,
            DianSkill4,
            DianSkill5,
            
            HeiAnSkill1,
            HeiAnSkill2,
            HeiAnSkill3,
            HeiAnSkill4,
            HeiAnSkill5,
        }

        public static float Ice1Damage => SkillConfig.SkillBaseDamageDic[SkillType.Ice1] + MathF.Max(0,
        (SkillJiaDian.S.Ice1 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Ice1]);
    public  static float Ice2Damage => SkillConfig.SkillBaseDamageDic[SkillType.Ice2] + MathF.Max(0,
        (SkillJiaDian.S.Ice2 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Ice2]);
    public  static float Ice3Damage => SkillConfig.SkillBaseDamageDic[SkillType.Ice3] + MathF.Max(0,
        (SkillJiaDian.S.Ice3 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Ice3]);
    public  static float Ice4Damage => SkillConfig.SkillBaseDamageDic[SkillType.Ice4] + MathF.Max(0,
        (SkillJiaDian.S.Ice4 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Ice4]);
    public  static float Ice5Damage => SkillConfig.SkillBaseDamageDic[SkillType.Ice5] + MathF.Max(0,
        (SkillJiaDian.S.Ice5 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Ice5]);
    
    
    public  static float Dian1Damage => SkillConfig.SkillBaseDamageDic[SkillType.Dian1] + MathF.Max(0,
        (SkillJiaDian.S.Dian1 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Dian1]);
    public  static float Dian2Damage => SkillConfig.SkillBaseDamageDic[SkillType.Dian2] + MathF.Max(0,
        (SkillJiaDian.S.Dian2 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Dian2]);
    public  static float Dian3Damage => SkillConfig.SkillBaseDamageDic[SkillType.Dian3] + MathF.Max(0,
        (SkillJiaDian.S.Dian3 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Dian3]);
    public  static float Dian4Damage => SkillConfig.SkillBaseDamageDic[SkillType.Dian4] + MathF.Max(0,
        (SkillJiaDian.S.Dian4 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Dian4]);
    public  static float Dian5Damage => SkillConfig.SkillBaseDamageDic[SkillType.Dian5] + MathF.Max(0,
        (SkillJiaDian.S.Dian5 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Dian5]);
    
    
    public  static float HeiAn1Damage => SkillConfig.SkillBaseDamageDic[SkillType.HeiAn1] + MathF.Max(0,
        (SkillJiaDian.S.HeiAn1 - 1) * SkillConfig.SkillUpDamageDic[SkillType.HeiAn1]);
    public  static float HeiAn2Damage => SkillConfig.SkillBaseDamageDic[SkillType.HeiAn2] + MathF.Max(0,
        (SkillJiaDian.S.HeiAn2 - 1) * SkillConfig.SkillUpDamageDic[SkillType.HeiAn2]);
    public  static float HeiAn3Damage => SkillConfig.SkillBaseDamageDic[SkillType.HeiAn3] + MathF.Max(0,
        (SkillJiaDian.S.HeiAn3 - 1) * SkillConfig.SkillUpDamageDic[SkillType.HeiAn3]);
    public  static float HeiAn4Damage => SkillConfig.SkillBaseDamageDic[SkillType.HeiAn4] + MathF.Max(0,
        (SkillJiaDian.S.HeiAn4 - 1) * SkillConfig.SkillUpDamageDic[SkillType.HeiAn4]);
    public  static float HeiAn5Damage => SkillConfig.SkillBaseDamageDic[SkillType.HeiAn5] + MathF.Max(0,
        (SkillJiaDian.S.HeiAn5 - 1) * SkillConfig.SkillUpDamageDic[SkillType.HeiAn5]);
    
    
    public  static float Huo1Damage => SkillConfig.SkillBaseDamageDic[SkillType.Huo1] + MathF.Max(0,
        (SkillJiaDian.S.Huo1 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Huo1]);
    public  static float Huo2Damage => SkillConfig.SkillBaseDamageDic[SkillType.Huo2] + MathF.Max(0,
        (SkillJiaDian.S.Huo2 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Huo2]);
    public  static float Huo3Damage => SkillConfig.SkillBaseDamageDic[SkillType.Huo3] + MathF.Max(0,
        (SkillJiaDian.S.Huo3 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Huo3]);
    public  static float Huo4Damage => SkillConfig.SkillBaseDamageDic[SkillType.Huo4] + MathF.Max(0,
        (SkillJiaDian.S.Huo4 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Huo4]);
    public  static float Huo5Damage => SkillConfig.SkillBaseDamageDic[SkillType.Huo5] + MathF.Max(0,
        (SkillJiaDian.S.Huo5 - 1) * SkillConfig.SkillUpDamageDic[SkillType.Huo5]);
        public static Dictionary<SkillType, int> SkillBaseDamageDic = new Dictionary<SkillType, int>()
        {
            { SkillType.Ice1,300},
            { SkillType.Ice2,200},
            { SkillType.Ice3,300},
            { SkillType.Ice4,250},
            { SkillType.Ice5,250},
            
            { SkillType.Huo1,200},
            { SkillType.Huo2,20},
            { SkillType.Huo3,250},
            { SkillType.Huo4,250},
            { SkillType.Huo5,250},
            
            { SkillType.Dian1,200},
            { SkillType.Dian2,20},
            { SkillType.Dian3,250},
            { SkillType.Dian4,200},
            { SkillType.Dian5,250},
            
            { SkillType.HeiAn1,300},
            { SkillType.HeiAn2,20},
            { SkillType.HeiAn3,200},
            { SkillType.HeiAn4,200},
            { SkillType.HeiAn5,200},
        };

        public static Dictionary<SkillType, int> SkillUpDamageDic = new Dictionary<SkillType, int>()
        {
            { SkillType.Ice1,30},
            { SkillType.Ice2,20},
            { SkillType.Ice3,30},
            { SkillType.Ice4,25},
            { SkillType.Ice5,25},
            
            { SkillType.Huo1,20},
            { SkillType.Huo2,2},
            { SkillType.Huo3,25},
            { SkillType.Huo4,25},
            { SkillType.Huo5,25},
            
            { SkillType.Dian1,20},
            { SkillType.Dian2,2},
            { SkillType.Dian3,25},
            { SkillType.Dian4,20},
            { SkillType.Dian5,25},
            
            { SkillType.HeiAn1,30},
            { SkillType.HeiAn2,2},
            { SkillType.HeiAn3,20},
            { SkillType.HeiAn4,20},
            { SkillType.HeiAn5,20},
        };

        public static Dictionary<ZhuDongSkillTime, float> SkillBaseTime = new Dictionary<ZhuDongSkillTime, float>()
        {
            { ZhuDongSkillTime.DianSkill1 ,8f},
            { ZhuDongSkillTime.DianSkill2 ,15f},
            { ZhuDongSkillTime.DianSkill3 ,12f},
            { ZhuDongSkillTime.DianSkill4 ,12f},
            { ZhuDongSkillTime.DianSkill5 ,12f},


            { ZhuDongSkillTime.HeiAnSkill1 ,8f},
            { ZhuDongSkillTime.HeiAnSkill2 ,15f},
            { ZhuDongSkillTime.HeiAnSkill3 ,12f},
            { ZhuDongSkillTime.HeiAnSkill4 ,15f},
            { ZhuDongSkillTime.HeiAnSkill5 ,15f},
            
            { ZhuDongSkillTime.HuoSkill1 ,8f},
            { ZhuDongSkillTime.HuoSkill2 ,15f},
            { ZhuDongSkillTime.HuoSkill3 ,12f},
            { ZhuDongSkillTime.HuoSkill4 ,12f},
            { ZhuDongSkillTime.HuoSkill5 ,15f},
            
            { ZhuDongSkillTime.IceSkill1 ,8f},
            { ZhuDongSkillTime.IceSkill2 ,15f},
            { ZhuDongSkillTime.IceSkill3 ,12f},
            { ZhuDongSkillTime.IceSkill4 ,12f},
            { ZhuDongSkillTime.IceSkill5 ,12f},

        };

        public static Dictionary<MonsterType, float> BaseMonsterDic = new Dictionary<MonsterType, float>()
        {
            { MonsterType.Attack, 1 },
            { MonsterType.Defense, 1 },
            { MonsterType.Hp, 3 },
            { MonsterType.Crit, 3 },
        };

        public static Dictionary<SkillButtonType, int> MaxSkillLevel = new Dictionary<SkillButtonType, int>()
        {
            {SkillButtonType.NormalAttack,5},
            {SkillButtonType.AttackSpeed,5},
            {SkillButtonType.Dash,1},
            {SkillButtonType.DashCd,5},
            {SkillButtonType.Crit,5},
            {SkillButtonType.CritDamage,5},
            {SkillButtonType.MoveSpeed,5},
            {SkillButtonType.MoveAddDefense,5},
            {SkillButtonType.MoveAddAttack,5},
            {SkillButtonType.Skill1,5},
            {SkillButtonType.Skill2,5},
            {SkillButtonType.Skill3,5},
            {SkillButtonType.Skill1Cd,5},
            {SkillButtonType.Skill2Cd,5},
            {SkillButtonType.Skill3Cd,5},
            {SkillButtonType.Skill1Range,5},
            {SkillButtonType.Skill1YuanSu,5},
            {SkillButtonType.Skill2Time,5},
            {SkillButtonType.Skill2YuanSu,5},
            {SkillButtonType.Skill3Range,5},
            {SkillButtonType.Skill3YuanSu,5},
            {SkillButtonType.Attack,9999},
            {SkillButtonType.Hp,9999},
            {SkillButtonType.Defense,9999},
            {SkillButtonType.CritMonster,9999},
            {SkillButtonType.IceSkill1,5},
            {SkillButtonType.IceSkill1Range,5},
            {SkillButtonType.IceSkill1CD,5},
            {SkillButtonType.IceSkill1YuanSu,5},

            {SkillButtonType.DianSkill2,5},
            {SkillButtonType.DianSkill2Time,5},
            {SkillButtonType.DianSkill2CD,5},
            {SkillButtonType.DianSkill2YuanSu,5},
            
            {SkillButtonType.DianSkill3,5},
            {SkillButtonType.DianSkill3Count,5},
            {SkillButtonType.DianSkill3CD,5},
            {SkillButtonType.DianSkill3YuanSu,5},
            
            {SkillButtonType.HuoSkill1,5},
            {SkillButtonType.HuoSkill1Count,3},
            {SkillButtonType.HuoSkill1CD,5},
            {SkillButtonType.HuoSkill1YuanSu,5},
            
            {SkillButtonType.HuoSkill2,5},
            {SkillButtonType.HuoSkill2Time,5},
            {SkillButtonType.HuoSkill2CD,5},
            {SkillButtonType.HuoSkill2YuanSu,5},
            
            {SkillButtonType.HuoSkill3,5},
            {SkillButtonType.HuoSkill3Count,3},
            {SkillButtonType.HuoSkill3CD,5},
            {SkillButtonType.HuoSkill3YuanSu,5},
            
            {SkillButtonType.HeiAnSkill1,5},
            {SkillButtonType.HeiAnSkill1Range,5},
            {SkillButtonType.HeiAnSkill1CD,5},
            {SkillButtonType.HeiAnSkill1YuanSu,5},
            
            {SkillButtonType.HeiAnSkill2,5},
            {SkillButtonType.HeiAnSkill2Time,5},
            {SkillButtonType.HeiAnSkill2CD,5},
            {SkillButtonType.HeiAnSkill2YuanSu,5},
            
            {SkillButtonType.HeiAnSkill3,5},
            {SkillButtonType.HeiAnSkill3Range,5},
            {SkillButtonType.HeiAnSkill3CD,5},
            {SkillButtonType.HeiAnSkill3YuanSu,5},
        };
    }
}