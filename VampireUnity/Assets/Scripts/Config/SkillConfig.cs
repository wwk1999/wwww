using System.Collections.Generic;

namespace Config
{
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
            Skill1YiDian,            // 技能1易点
            Skill2Time,              // 技能2时间
            Skill2AddDefense,        // 技能2增加防御
            Skill3Range,             // 技能3范围
            Skill3JianSu,            // 技能3减速
            Attack,                  // 攻击
            Hp,                      // 生命值
            Defense,                 // 防御
            CritMonster              // 暴击怪物
        }

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
            {SkillButtonType.Skill1YiDian,5},
            {SkillButtonType.Skill2Time,5},
            {SkillButtonType.Skill2AddDefense,5},
            {SkillButtonType.Skill3Range,5},
            {SkillButtonType.Skill3JianSu,5},
            {SkillButtonType.Attack,9999},
            {SkillButtonType.Hp,9999},
            {SkillButtonType.Defense,9999},
            {SkillButtonType.CritMonster,9999},
        };
    }
}