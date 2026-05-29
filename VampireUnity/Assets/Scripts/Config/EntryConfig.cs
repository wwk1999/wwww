using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class DefenseEntryInfo
{
    public EntryConfig.DefenseEntry  DefenseEntry;
    public float Value;
}

public class DamageEntryInfo
{
    public EntryConfig.DamageEntry  DamageEntry;
    public float Value;
}

public class DefenseEntryConfig
{
    public EntryConfig.DefenseEntry  DefenseEntry;
    public float minValue;
    public float maxValue;
}

public class DamageEntryConfig
{
    public EntryConfig.DamageEntry  DamageEntry;
    public float minValue;
    public float maxValue;
}
public class EntryConfig : MonoBehaviour
{
   public static Dictionary<DefenseEntry, DefenseEntryConfig> DefenseEntryConfigs =
    new Dictionary<DefenseEntry, DefenseEntryConfig>()
{
    { DefenseEntry.KillReplyHpPercent,       new DefenseEntryConfig { DefenseEntry = DefenseEntry.KillReplyHpPercent,       minValue = 1, maxValue = 2 } },
    { DefenseEntry.MaxHpPercent,             new DefenseEntryConfig { DefenseEntry = DefenseEntry.MaxHpPercent,             minValue = 2, maxValue = 3 } },
    { DefenseEntry.MaxDefensePercent,        new DefenseEntryConfig { DefenseEntry = DefenseEntry.MaxDefensePercent,        minValue = 2, maxValue = 3 } },
    { DefenseEntry.DamageReductionPercent,   new DefenseEntryConfig { DefenseEntry = DefenseEntry.DamageReductionPercent,   minValue = 2, maxValue = 3 } },
    { DefenseEntry.DamageReductionPercentForNormal, new DefenseEntryConfig { DefenseEntry = DefenseEntry.DamageReductionPercentForNormal, minValue = 2, maxValue = 4 } },
    { DefenseEntry.DamageReductionPercentForBoss,   new DefenseEntryConfig { DefenseEntry = DefenseEntry.DamageReductionPercentForBoss,   minValue = 2, maxValue = 4 } },
    { DefenseEntry.ReplyHpPercent,           new DefenseEntryConfig { DefenseEntry = DefenseEntry.ReplyHpPercent,           minValue = 1, maxValue = 2 } },
};

public static Dictionary<DamageEntry, DamageEntryConfig> DamageEntryConfigs =
    new Dictionary<DamageEntry, DamageEntryConfig>()
{
    { DamageEntry.CRITDamage,        new DamageEntryConfig { DamageEntry = DamageEntry.CRITDamage,        minValue = 3, maxValue = 6 } },
    { DamageEntry.DamageSpeed,       new DamageEntryConfig { DamageEntry = DamageEntry.DamageSpeed,       minValue = 3, maxValue = 6 } },
    { DamageEntry.DamageAddForNormal,new DamageEntryConfig { DamageEntry = DamageEntry.DamageAddForNormal,minValue = 3, maxValue = 5 } },
    { DamageEntry.DamageAddForBoss,  new DamageEntryConfig { DamageEntry = DamageEntry.DamageAddForBoss,  minValue = 3, maxValue = 5 } },
    { DamageEntry.Penetrate,         new DamageEntryConfig { DamageEntry = DamageEntry.Penetrate,         minValue = 3, maxValue = 5 } },
    { DamageEntry.DamageAddPercent,  new DamageEntryConfig { DamageEntry = DamageEntry.DamageAddPercent,  minValue = 2, maxValue = 3 } },
    { DamageEntry.BloodSuck,         new DamageEntryConfig { DamageEntry = DamageEntry.BloodSuck,         minValue = 0.15f, maxValue = 0.3f } },
};

public static Dictionary<DefenseEntry, string> DefenseEntryNameDic = new Dictionary<DefenseEntry, string>()
{
    { DefenseEntry.KillReplyHpPercent,LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.KillReplyHpPercent+ " :" },
    { DefenseEntry.MaxHpPercent, LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.MaxHpPercent+" :" },
    { DefenseEntry.MaxDefensePercent, LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.MaxDefensePercent+" :" },
    { DefenseEntry.DamageReductionPercent, LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.DamageReductionPercent+" :" },
    { DefenseEntry.DamageReductionPercentForNormal, LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.DamageReductionPercentForNormal+" :" },
    { DefenseEntry.DamageReductionPercentForBoss,LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.DamageReductionPercentForBoss+ " :" },
    { DefenseEntry.ReplyHpPercent, LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.ReplyHpPercent+" :" },
};
public static Dictionary<DamageEntry, string> DamageEntryNameDic = new Dictionary<DamageEntry, string>()
{
    { DamageEntry.CRITDamage, LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.CRITDamage+" :" },
    { DamageEntry.DamageSpeed, LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.DamageSpeed+" :" },
    { DamageEntry.DamageAddForNormal, LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.DamageAddForNormal+" :" },
    { DamageEntry.DamageAddForBoss, LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.DamageAddForBoss+" :" },
    { DamageEntry.Penetrate, LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.Penetrate+" :" },
    { DamageEntry.DamageAddPercent, LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.DamageAddPercent+" :" },
    { DamageEntry.BloodSuck,LanguageConfig.LanguageItems[PlayerData.S.langType].EquipLanguage.BloodSuck+ " :" },
};
public static Dictionary<OrangeEntry, string> OrangeEntryNameDic = new Dictionary<OrangeEntry, string>()
{
    // 防御
    { OrangeEntry.FinalDamageReductionFixed, "不朽圣袍" },
    { OrangeEntry.FinalDamageReductionPercent, "终焉壁垒" },
    { OrangeEntry.AllReplyAddPercent, "涌泉圣衣" },
    { OrangeEntry.AddHpForTime, "不息之冠" },
    { OrangeEntry.AddDefenseForTime, "磐石心甲" },
    { OrangeEntry.ReplyDeath, "不死羽衣" },
    { OrangeEntry.DelayDamage, "时砂面甲" },
    { OrangeEntry.HpReductionReplyAdd50, "背水战袍" },
    { OrangeEntry.HpReductionAddDefense, "绝境铁盔" },

    // 攻击
    { OrangeEntry.FinalDamageAddPercent, "裁决吊坠" },
    { OrangeEntry.KillNormal, "诛灭指环" },
    { OrangeEntry.AddAttackForTime, "怒意魔戒" },
    { OrangeEntry.NormalAddDamage, "凡骨逆鳞" },
    { OrangeEntry.RecudeHpAddAttack, "血戮项链" },
    { OrangeEntry.JianSuAddAttack, "霜噬战靴" },

    // 普攻
    { OrangeEntry.FanPuGuiZhen, "归真宝戒" },
    { OrangeEntry.NoSkill, "禁法颈链" },
    

    // Dash
    { OrangeEntry.DashCd, "瞬步战靴" },
    { OrangeEntry.DashRange, "幻影胫甲" },

    // 特殊
    { OrangeEntry.MoveSpeedAdd, "追风便靴" },
    { OrangeEntry.ExAdd, "贤者之靴" },
    { OrangeEntry.ClothFortureAdd, "命运长袍" },
    { OrangeEntry.ShoeFortureAdd, "幸运之靴" },
    { OrangeEntry.CloakFortureAdd, "锦鲤披风" },
    { OrangeEntry.NecklaceFortureAdd, "天佑项链" },
    { OrangeEntry.RingFortureAdd, "探宝指环" },
    { OrangeEntry.HelmetFortureAdd, "探知头盔" },
};


public static Dictionary<OrangeEntry, string> OrangeEntryAttributeDescDic = new Dictionary<OrangeEntry, string>()
{
    // 防御
    { OrangeEntry.FinalDamageReductionFixed, "最终伤害减少300" },
    { OrangeEntry.FinalDamageReductionPercent, "最终伤害减少10%" },
    { OrangeEntry.AllReplyAddPercent, "所有的治疗效果增加20%" },
    { OrangeEntry.AddHpForTime, "战斗时每5s增加3%最大生命值，上限100%" },
    { OrangeEntry.AddDefenseForTime, "战斗时每5s增加2%防御，最多叠加10层" },
    { OrangeEntry.ReplyDeath, "免疫一次死亡,恢复到30%最大生命值" },
    { OrangeEntry.DelayDamage, "将收到的伤害的30%存储起来在3s内缓慢施加" },
    { OrangeEntry.HpReductionReplyAdd50, "血量减少到50%增加30%回复效果" },
    { OrangeEntry.HpReductionAddDefense, "血量减少到50%增加15%免伤" },

    // 攻击
    { OrangeEntry.FinalDamageAddPercent, "最终伤害增加15%" },
    { OrangeEntry.KillNormal, "5%概率秒杀小怪" },
    { OrangeEntry.AddAttackForTime, "战斗中每5s增加3%攻击，最多叠加10层" },
    { OrangeEntry.NormalAddDamage, "每穿戴一件传说以下品质装备增加最终伤害30%" },
    { OrangeEntry.RecudeHpAddAttack, "减少50%hp增加30%attack" },
    { OrangeEntry.JianSuAddAttack, "对被减速的敌人增加15%伤害" },

    // 普攻
    { OrangeEntry.FanPuGuiZhen, "装备白色武器最终伤害增加200%，绿色150%，蓝色100%，紫色50%" },
    { OrangeEntry.NoSkill, "普通攻击伤害增加100%，但是不能使用技能" },
    

    // Dash
    { OrangeEntry.DashCd, "Dash基础Cd减少30%" },
    { OrangeEntry.DashRange, "Dash距离增加30%" },

    // 特殊
    { OrangeEntry.MoveSpeedAdd, "移动速度增加25%" },
    { OrangeEntry.ExAdd, "经验获取增加20%" },
    { OrangeEntry.ClothFortureAdd, "掉落率增加30%" },
    { OrangeEntry.ShoeFortureAdd, "掉落率增加30%" },
    { OrangeEntry.CloakFortureAdd, "掉落率增加30%" },
    { OrangeEntry.NecklaceFortureAdd, "掉落率增加30%" },
    { OrangeEntry.RingFortureAdd, "掉落率增加30%" },
    { OrangeEntry.HelmetFortureAdd, "掉落率增加30%" },
};



    public static List<DefenseEntry> DefenseEntryList = new List<DefenseEntry>()
    {
        DefenseEntry.KillReplyHpPercent,
        DefenseEntry.MaxHpPercent,  
        DefenseEntry.MaxDefensePercent,
        DefenseEntry.DamageReductionPercent,
        DefenseEntry.DamageReductionPercentForNormal,
        DefenseEntry.DamageReductionPercentForBoss,
        DefenseEntry.ReplyHpPercent,
    };

    public static List<DamageEntry> DamageEntryList = new List<DamageEntry>()
    {
        DamageEntry.CRITDamage,
        DamageEntry.DamageSpeed,
        DamageEntry.DamageAddForNormal,
        DamageEntry.DamageAddForBoss,
        DamageEntry.Penetrate,
        DamageEntry.DamageAddPercent,
        DamageEntry.BloodSuck,
    };
    public enum DefenseEntry
    {
        None,
        KillReplyHpPercent,
        MaxHpPercent,
        MaxDefensePercent,
        DamageReductionPercent,
        DamageReductionPercentForNormal,
        DamageReductionPercentForBoss,
        ReplyHpPercent,//每3s回复一次体力
    }

    public enum DamageEntry
    {
        None,
        CRITDamage,
        DamageSpeed, 
        DamageAddForNormal,
        DamageAddForBoss,
        Penetrate,
        DamageAddPercent,
        BloodSuck,
    }

    public enum DefenseEntryOrange
    {
        None,
        FinalDamageReductionFixed,
        FinalDamageReductionPercent,
        StartWithShield,
        AllReplyAddPercent,
        AddHpForTime,
        AddDefenseForTime,
        ReplyDeath,
        DelayDamage,
        HpReductionReplyAdd50,
        HpReductionAddDefense,
        AllAttributeAdd,
        KillAddHpPermanent,
        KillAddDefensePermanent,

        //技能
    }

    public enum OrangeEntry
    {
        None,
        //防御词条
        FinalDamageReductionFixed,//最终伤害减少300              cloth      1111
        FinalDamageReductionPercent,//最终伤害减少10%            helmet     1111
        AllReplyAddPercent,//所有的治疗效果增加20%                cloth      1111
        AddHpForTime,//战斗时每5s增加3%最大生命值，上限100%         Helmet     1111
        AddDefenseForTime,//战斗时每5s增加2%防御，最多叠加10层         Cloth      1111
        ReplyDeath,//免疫一次死亡                            Shoe          1111
        DelayDamage,//将收到的伤害的30%存储起来在3s内缓慢施加         helmet     1111
        HpReductionReplyAdd50,//血量减少到50%增加30%回复效果        cloth     1111
        HpReductionAddDefense,//血量减少到50%增加15%免伤           helmet    1111
        //攻击词条
        FinalDamageAddPercent,//最终伤害增加15%                   Shoe    1111
        KillNormal,//5%概率秒杀小怪                               ring        1111
        AddAttackForTime,//战斗中每5s增加3%攻击，最多10层%           ring        1111
        NormalAddDamage,//减少30%Attack增加50%hp                 Shoe    1111
        RecudeHpAddAttack,//减少50%hp增加30%attack               Shoe    1111
        JianSuAddAttack,//对被减速的敌人增加15%伤害                 Shoe        1111
        //普通攻击
        FanPuGuiZhen,//装备白色武器最终伤害增加200%，绿色武器最终伤害增加150%，蓝色100%，紫色50%    ring
        NoSkill,//普通攻击伤害增加100%，但是不能使用技能（技能伤害）          Ring
        AddWeaponReduceSkill,//增加50%武器伤害，减少50%技能伤害           Cloak
        AddAttackSpeed,//增加武器攻击速度50%                             Cloak
        AddSkillReduceWeapon,//增加50%技能伤害，减少50%武器伤害           Cloak

        //Dash
        DashCd,//Dash基础Cd减少30%                 shoe                                           1111
        DashRange,//Dash距离增加30%                shoe                                           1111
        //特殊词条
        MoveSpeedAdd,//移动速度增加25%              shoe                                           1111
        ExAdd,//经验获取增加25%                     shoe                                           1111
        ClothFortureAdd,//掉落率增加30%             cloth                                          1111
        ShoeFortureAdd,//掉落率增加30%              shoe                                           1111
        CloakFortureAdd,//掉落率增加30%             cloak                                          1111
        NecklaceFortureAdd,//掉落率增加30%          necklace                                       1111
        RingFortureAdd,//掉落率增加30%              ring                                           1111
        HelmetFortureAdd,//掉落率增加30%            helmet                                         1111
        AddSoul,//增加灵魂获取25%                    Cloak
        OrangeEquip,//每装备一件传说装备增加5%最终伤害   Shoe
        NoOrangeEquip,//每装备一件非传说装备增加15%最终伤害    Shoe
        
        
        
        //新加45个
        HuoAdd,//增加火元素掌控15%        Cloak
        IceAdd,//增加火元素掌控15%        Cloak
        DianAdd,//增加火元素掌控15%       Cloak
        HeiAnAdd,//增加火元素掌控15%      Cloak
        
        
        HuoDamageAdd,//增加火元素伤害15%        Helmet
        IceDamageAdd,//增加火元素伤害15%        Helmet
        DianDamageAdd,//增加火元素伤害15%       Helmet
        HeiAnDamageAdd,//增加火元素伤害15%      Helmet
        
        
        HuoSkillCdAdd,//火技能cd减少15%      Necklace
        IceSkillCdAdd,//冰技能cd减少15%        Necklace
        DianSkillCdAdd,//电技能cd减少15%       Necklace
        HeiAnSkillCdAdd,//黑暗技能cd减少15%     Necklace
        
        
        HuoSkillDamageAdd,//火技能cd减少15%      Ring
        IceSkillDamageAdd,//冰技能cd减少15%        Ring
        DianSkillDamageAdd,//电技能cd减少15%       Ring
        HeiAnSkillDamageAdd,//黑暗技能cd减少15%     Ring
        
        HuoWeapponDamageAdd,//火武器伤害增加15%      Cloth
        IceWeapponDamageAdd,//冰武器伤害增加15%        Cloth
        DianWeapponDamageAdd,//电武器伤害增加15%       Cloth
        HeiAnWeapponDamageAdd,//黑暗武器伤害增加15%     Cloth
        
        AddAllYuanSu,//增加所有属性元素掌控20%          Shoe
        
        IceMaster,//将所有的元素掌控增加到冰元素上        Necklace
        HuoMaster,//将所有的元素掌控增加到冰元素上        Necklace
        DianMaster,//将所有的元素掌控增加到冰元素上        Necklace
        HeiAnMaster,//将所有的元素掌控增加到冰元素上       Necklace
        
        IceSkill1,//IceSkill1效果范围增加15%，伤害增加15%，cd减少15%       Cloth
        IceSkill2,//IceSkill2转速增加25%，伤害增加15%，cd减少15%          Cloak
        IceSkill3,//IceSkill3效果范围增加15%，伤害增加15%，cd减少15%       Helmet
        IceSkill4,//IceSkill4伤害增加25%，cd减少25%                      Ring
        IceSkill5,//IceSkill5冰晶数量增加5，伤害增加15%，cd减少15%         Necklace


        HuoSkill1,//HuoSkill1伤害增加25%，cd减少25%                     Cloth
        HuoSkill2,//HuoSkill2持续时间增加25%，cd减少25%                  Cloak
        HuoSkill3,//HuoSkill3火焰流星数量增加2，伤害增加15%，cd减少15%     Helmet
        HuoSkill4,//HuoSkill4效果范围增加25%，伤害增加15%，cd减少15%      Ring
        HuoSkill5,//HuoSkill5陨石数量增加2，伤害增加15%，cd减少15%        Necklace
        
        DianSkill1,//DianSkill1效果范围增加15%，伤害增加15%，cd减少15%     Cloth
        DianSkill2,//DianSkill2持续时间增加25%，cd减少25%                Cloak
        DianSkill3,//DianSkill3闪电数量增加5，伤害增加15%，cd减少15%       Helmet
        DianSkill4,//DianSkill4效果范围增加15%，伤害增加15%，cd减少15%     Ring
        DianSkill5,//DianSkill5效果范围增加15%，伤害增加15%，cd减少15%      Necklace
        
        HeiAnSkill1,//HeiAnSkill1效果范围增加15%，伤害增加15%，cd减少15%    Cloth
        HeiAnSkill2,//HeiAnSkill2持续时间增加25%，cd减少25%               Cloak
        HeiAnSkill3,//HeiAnSkill3效果范围增加15%，伤害增加15%，cd减少15%    Helmet
        HeiAnSkill4,//HeiAnSkill4转速增加25%，伤害增加15%，cd减少15%       Ring
        HeiAnSkill5,//HeiAnSkill5增加2个黑暗漩涡，伤害增加15%，cd减少15%    Necklace
        
        
    }
    
    
}
