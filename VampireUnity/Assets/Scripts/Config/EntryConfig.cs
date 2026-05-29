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
    
    
    public static Dictionary<int, EntryConfig.OrangeEntry> OrangeIdEntryDic =
    new Dictionary<int, EntryConfig.OrangeEntry>()
    {
        { 1, EntryConfig.OrangeEntry.FinalDamageReductionFixed },
        { 2, EntryConfig.OrangeEntry.FinalDamageReductionPercent },
        { 3, EntryConfig.OrangeEntry.AllReplyAddPercent },
        { 4, EntryConfig.OrangeEntry.AddHpForTime },
        { 5, EntryConfig.OrangeEntry.AddDefenseForTime },
        { 6, EntryConfig.OrangeEntry.ReplyDeath },
        { 7, EntryConfig.OrangeEntry.DelayDamage },
        { 8, EntryConfig.OrangeEntry.HpReductionReplyAdd50 },
        { 9, EntryConfig.OrangeEntry.HpReductionAddDefense },
        { 10, EntryConfig.OrangeEntry.FinalDamageAddPercent },
        { 11, EntryConfig.OrangeEntry.KillNormal },
        { 12, EntryConfig.OrangeEntry.AddAttackForTime },
        { 13, EntryConfig.OrangeEntry.NormalAddDamage },
        { 14, EntryConfig.OrangeEntry.RecudeHpAddAttack },
        { 15, EntryConfig.OrangeEntry.JianSuAddAttack },
        { 16, EntryConfig.OrangeEntry.FanPuGuiZhen },
        { 17, EntryConfig.OrangeEntry.NoSkill },
        { 18, EntryConfig.OrangeEntry.AddWeaponReduceSkill },
        { 19, EntryConfig.OrangeEntry.AddAttackSpeedEntry },
        { 20, EntryConfig.OrangeEntry.AddSkillReduceWeapon },
        { 21, EntryConfig.OrangeEntry.DashCd },
        { 22, EntryConfig.OrangeEntry.DashRange },
        { 23, EntryConfig.OrangeEntry.MoveSpeedAdd },
        { 24, EntryConfig.OrangeEntry.ExAdd },
        { 25, EntryConfig.OrangeEntry.ClothFortureAdd },
        { 26, EntryConfig.OrangeEntry.ShoeFortureAdd },
        { 27, EntryConfig.OrangeEntry.CloakFortureAdd },
        { 28, EntryConfig.OrangeEntry.NecklaceFortureAdd },
        { 29, EntryConfig.OrangeEntry.RingFortureAdd },
        { 30, EntryConfig.OrangeEntry.HelmetFortureAdd },
        { 31, EntryConfig.OrangeEntry.AddSoul },
        { 32, EntryConfig.OrangeEntry.OrangeEquip },
        { 33, EntryConfig.OrangeEntry.NoOrangeEquip },
        { 34, EntryConfig.OrangeEntry.HuoAdd },
        { 35, EntryConfig.OrangeEntry.IceAdd },
        { 36, EntryConfig.OrangeEntry.DianAdd },
        { 37, EntryConfig.OrangeEntry.HeiAnAdd },
        { 38, EntryConfig.OrangeEntry.HuoDamageAdd },
        { 39, EntryConfig.OrangeEntry.IceDamageAdd },
        { 40, EntryConfig.OrangeEntry.DianDamageAdd },
        { 41, EntryConfig.OrangeEntry.HeiAnDamageAdd },
        { 42, EntryConfig.OrangeEntry.HuoSkillCdAdd },
        { 43, EntryConfig.OrangeEntry.IceSkillCdAdd },
        { 44, EntryConfig.OrangeEntry.DianSkillCdAdd },
        { 45, EntryConfig.OrangeEntry.HeiAnSkillCdAdd },
        { 46, EntryConfig.OrangeEntry.HuoSkillDamageAdd },
        { 47, EntryConfig.OrangeEntry.IceSkillDamageAdd },
        { 48, EntryConfig.OrangeEntry.DianSkillDamageAdd },
        { 49, EntryConfig.OrangeEntry.HeiAnSkillDamageAdd },
        { 50, EntryConfig.OrangeEntry.HuoWeapponDamageAdd },
        { 51, EntryConfig.OrangeEntry.IceWeapponDamageAdd },
        { 52, EntryConfig.OrangeEntry.DianWeapponDamageAdd },
        { 53, EntryConfig.OrangeEntry.HeiAnWeapponDamageAdd },
        { 54, EntryConfig.OrangeEntry.AddAllYuanSu },
        { 55, EntryConfig.OrangeEntry.IceMaster },
        { 56, EntryConfig.OrangeEntry.HuoMaster },
        { 57, EntryConfig.OrangeEntry.DianMaster },
        { 58, EntryConfig.OrangeEntry.HeiAnMaster },
        { 59, EntryConfig.OrangeEntry.IceSkill1 },
        { 60, EntryConfig.OrangeEntry.IceSkill2 },
        { 61, EntryConfig.OrangeEntry.IceSkill3 },
        { 62, EntryConfig.OrangeEntry.IceSkill4 },
        { 63, EntryConfig.OrangeEntry.IceSkill5 },
        { 64, EntryConfig.OrangeEntry.HuoSkill1 },
        { 65, EntryConfig.OrangeEntry.HuoSkill2 },
        { 66, EntryConfig.OrangeEntry.HuoSkill3 },
        { 67, EntryConfig.OrangeEntry.HuoSkill4 },
        { 68, EntryConfig.OrangeEntry.HuoSkill5 },
        { 69, EntryConfig.OrangeEntry.DianSkill1 },
        { 70, EntryConfig.OrangeEntry.DianSkill2 },
        { 71, EntryConfig.OrangeEntry.DianSkill3 },
        { 72, EntryConfig.OrangeEntry.DianSkill4 },
        { 73, EntryConfig.OrangeEntry.DianSkill5 },
        { 74, EntryConfig.OrangeEntry.HeiAnSkill1 },
        { 75, EntryConfig.OrangeEntry.HeiAnSkill2 },
        { 76, EntryConfig.OrangeEntry.HeiAnSkill3 },
        { 77, EntryConfig.OrangeEntry.HeiAnSkill4 },
        { 78, EntryConfig.OrangeEntry.HeiAnSkill5 },
    };
    
    
    public static Dictionary<int, PlayerEquipConfig.EquipType> OrangeIdEquipTypeDic = new Dictionary<int, PlayerEquipConfig.EquipType>()
{
    { 1, PlayerEquipConfig.EquipType.Cloth },      // FinalDamageReductionFixed
    { 2, PlayerEquipConfig.EquipType.Helmet },     // FinalDamageReductionPercent
    { 3, PlayerEquipConfig.EquipType.Cloth },      // AllReplyAddPercent
    { 4, PlayerEquipConfig.EquipType.Helmet },     // AddHpForTime
    { 5, PlayerEquipConfig.EquipType.Cloth },      // AddDefenseForTime
    { 6, PlayerEquipConfig.EquipType.Shoe },       // ReplyDeath
    { 7, PlayerEquipConfig.EquipType.Helmet },     // DelayDamage
    { 8, PlayerEquipConfig.EquipType.Cloth },      // HpReductionReplyAdd50
    { 9, PlayerEquipConfig.EquipType.Helmet },     // HpReductionAddDefense
    { 10, PlayerEquipConfig.EquipType.Shoe },      // FinalDamageAddPercent
    { 11, PlayerEquipConfig.EquipType.Ring },      // KillNormal
    { 12, PlayerEquipConfig.EquipType.Ring },      // AddAttackForTime
    { 13, PlayerEquipConfig.EquipType.Shoe },      // NormalAddDamage
    { 14, PlayerEquipConfig.EquipType.Shoe },      // RecudeHpAddAttack
    { 15, PlayerEquipConfig.EquipType.Shoe },      // JianSuAddAttack
    { 16, PlayerEquipConfig.EquipType.Ring },      // FanPuGuiZhen
    { 17, PlayerEquipConfig.EquipType.Ring },      // NoSkill
    { 18, PlayerEquipConfig.EquipType.Cloak },     // AddWeaponReduceSkill
    { 19, PlayerEquipConfig.EquipType.Cloak },     // AddAttackSpeedEntry
    { 20, PlayerEquipConfig.EquipType.Cloak },     // AddSkillReduceWeapon
    { 21, PlayerEquipConfig.EquipType.Shoe },      // DashCd
    { 22, PlayerEquipConfig.EquipType.Shoe },      // DashRange
    { 23, PlayerEquipConfig.EquipType.Shoe },      // MoveSpeedAdd
    { 24, PlayerEquipConfig.EquipType.Shoe },      // ExAdd
    { 25, PlayerEquipConfig.EquipType.Cloth },     // ClothFortureAdd
    { 26, PlayerEquipConfig.EquipType.Shoe },      // ShoeFortureAdd
    { 27, PlayerEquipConfig.EquipType.Cloak },     // CloakFortureAdd
    { 28, PlayerEquipConfig.EquipType.Necklace },  // NecklaceFortureAdd
    { 29, PlayerEquipConfig.EquipType.Ring },      // RingFortureAdd
    { 30, PlayerEquipConfig.EquipType.Helmet },    // HelmetFortureAdd
    { 31, PlayerEquipConfig.EquipType.Cloak },     // AddSoul
    { 32, PlayerEquipConfig.EquipType.Shoe },      // OrangePlayerEquipConfig.Equip
    { 33, PlayerEquipConfig.EquipType.Shoe },      // NoOrangePlayerEquipConfig.Equip
    { 34, PlayerEquipConfig.EquipType.Cloak },     // HuoAdd
    { 35, PlayerEquipConfig.EquipType.Cloak },     // IceAdd
    { 36, PlayerEquipConfig.EquipType.Cloak },     // DianAdd
    { 37, PlayerEquipConfig.EquipType.Cloak },     // HeiAnAdd
    { 38, PlayerEquipConfig.EquipType.Helmet },    // HuoDamageAdd
    { 39, PlayerEquipConfig.EquipType.Helmet },    // IceDamageAdd
    { 40, PlayerEquipConfig.EquipType.Helmet },    // DianDamageAdd
    { 41, PlayerEquipConfig.EquipType.Helmet },    // HeiAnDamageAdd
    { 42, PlayerEquipConfig.EquipType.Necklace },  // HuoSkillCdAdd
    { 43, PlayerEquipConfig.EquipType.Necklace },  // IceSkillCdAdd
    { 44, PlayerEquipConfig.EquipType.Necklace },  // DianSkillCdAdd
    { 45, PlayerEquipConfig.EquipType.Necklace },  // HeiAnSkillCdAdd
    { 46, PlayerEquipConfig.EquipType.Ring },      // HuoSkillDamageAdd
    { 47, PlayerEquipConfig.EquipType.Ring },      // IceSkillDamageAdd
    { 48, PlayerEquipConfig.EquipType.Ring },      // DianSkillDamageAdd
    { 49, PlayerEquipConfig.EquipType.Ring },      // HeiAnSkillDamageAdd
    { 50, PlayerEquipConfig.EquipType.Cloth },     // HuoWeapponDamageAdd
    { 51, PlayerEquipConfig.EquipType.Cloth },     // IceWeapponDamageAdd
    { 52, PlayerEquipConfig.EquipType.Cloth },     // DianWeapponDamageAdd
    { 53, PlayerEquipConfig.EquipType.Cloth },     // HeiAnWeapponDamageAdd
    { 54, PlayerEquipConfig.EquipType.Shoe },      // AddAllYuanSu
    { 55, PlayerEquipConfig.EquipType.Necklace },  // IceMaster
    { 56, PlayerEquipConfig.EquipType.Necklace },  // HuoMaster
    { 57, PlayerEquipConfig.EquipType.Necklace },  // DianMaster
    { 58, PlayerEquipConfig.EquipType.Necklace },  // HeiAnMaster
    { 59, PlayerEquipConfig.EquipType.Cloth },     // IceSkill1
    { 60, PlayerEquipConfig.EquipType.Cloak },     // IceSkill2
    { 61, PlayerEquipConfig.EquipType.Helmet },    // IceSkill3
    { 62, PlayerEquipConfig.EquipType.Ring },      // IceSkill4
    { 63, PlayerEquipConfig.EquipType.Necklace },  // IceSkill5
    { 64, PlayerEquipConfig.EquipType.Cloth },     // HuoSkill1
    { 65, PlayerEquipConfig.EquipType.Cloak },     // HuoSkill2
    { 66, PlayerEquipConfig.EquipType.Helmet },    // HuoSkill3
    { 67, PlayerEquipConfig.EquipType.Ring },      // HuoSkill4
    { 68, PlayerEquipConfig.EquipType.Necklace },  // HuoSkill5
    { 69, PlayerEquipConfig.EquipType.Cloth },     // DianSkill1
    { 70, PlayerEquipConfig.EquipType.Cloak },     // DianSkill2
    { 71, PlayerEquipConfig.EquipType.Helmet },    // DianSkill3
    { 72, PlayerEquipConfig.EquipType.Ring },      // DianSkill4
    { 73, PlayerEquipConfig.EquipType.Necklace },  // DianSkill5
    { 74, PlayerEquipConfig.EquipType.Cloth },     // HeiAnSkill1
    { 75, PlayerEquipConfig.EquipType.Cloak },     // HeiAnSkill2
    { 76, PlayerEquipConfig.EquipType.Helmet },    // HeiAnSkill3
    { 77, PlayerEquipConfig.EquipType.Ring },      // HeiAnSkill4
    { 78, PlayerEquipConfig.EquipType.Necklace },  // HeiAnSkill5
};

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
        AddAttackSpeedEntry,//增加武器攻击速度50%                             Cloak
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
