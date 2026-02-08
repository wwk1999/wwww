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
            {SkillButtonType.HuoSkill1Count,5},
            {SkillButtonType.HuoSkill1CD,5},
            {SkillButtonType.HuoSkill1YuanSu,5},
            
            {SkillButtonType.HuoSkill2,5},
            {SkillButtonType.HuoSkill2Time,5},
            {SkillButtonType.HuoSkill2CD,5},
            {SkillButtonType.HuoSkill2YuanSu,5},
            
            {SkillButtonType.HuoSkill3,5},
            {SkillButtonType.HuoSkill3Count,5},
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