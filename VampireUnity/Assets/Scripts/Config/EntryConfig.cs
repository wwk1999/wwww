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
public static Dictionary<int, string> OrangeIdNameDic = new Dictionary<int, string>()
{
    { 1, "不朽圣袍" },   // FinalDamageReductionFixed 衣:最终减伤300
    { 2, "坚毅头冠" },   // FinalDamageReductionPercent 盔:最终减伤10%
    { 3, "慈爱法衣" },   // AllReplyAddPercent 衣:治疗+20%
    { 4, "生命礼赞" },   // AddHpForTime 盔:每5s +3%最大生命
    { 5, "磐石铠甲" },   // AddDefenseForTime 衣:每5s +2%防御
    { 6, "重生之靴" },   // ReplyDeath 鞋:免死一次
    { 7, "缓痛之冠" },   // DelayDamage 盔:延迟伤害30%分摊3s
    { 8, "血愈披风" },   // HpReductionReplyAdd50 衣:半血+30%回复
    { 9, "危命护盔" },   // HpReductionAddDefense 盔:半血+15%免伤
    { 10, "破军之履" },  // FinalDamageAddPercent 鞋:最终伤害+15%
    { 11, "诛邪指环" },  // KillNormal 戒:5%秒杀小怪
    { 12, "狂战戒律" },  // AddAttackForTime 戒:每5s +3%攻击
    { 13, "血契之靴" },  // NormalAddDamage 鞋:-30%攻+50%血
    { 14, "献祭步履" },  // RecudeHpAddAttack 鞋:-50%血+30%攻
    { 15, "追猎之鞋" },  // JianSuAddAttack 鞋:对减速敌人+15%伤
    { 16, "返璞指环" },  // FanPuGuiZhen 戒:白武+200%,绿+150%...
    { 17, "禁咒魔戒" },  // NoSkill 戒:普攻+100%但禁用技能
    { 18, "战法斗篷" },  // AddWeaponReduceSkill 披风:武器+50%,技能-50%
    { 19, "疾影披风" },  // AddAttackSpeedEntry 披风:攻速+50%
    { 20, "秘法披风" },  // AddSkillReduceWeapon 披风:技能+50%,武器-50%
    { 21, "闪影之靴" },  // DashCd 鞋:冲刺CD-30%
    { 22, "追风之履" },  // DashRange 鞋:冲刺距离+30%
    { 23, "神行靴" },    // MoveSpeedAdd 鞋:移速+25%
    { 24, "求知靴" },    // ExAdd 鞋:经验+25%
    { 25, "贪欲法袍" },  // ClothFortureAdd 衣:掉落率+30%
    { 26, "聚财之靴" },  // ShoeFortureAdd 鞋:掉落率+30%
    { 27, "幸运斗篷" },  // CloakFortureAdd 披风:掉落率+30%
    { 28, "命运项链" },  // NecklaceFortureAdd 项链:掉落率+30%
    { 29, "财富指环" },  // RingFortureAdd 戒:掉落率+30%
    { 30, "寻宝头盔" },  // HelmetFortureAdd 盔:掉落率+30%
    { 31, "汲魂披风" },  // AddSoul 披风:灵魂+25%
    { 32, "传说之证" },  // OrangeEquip 鞋:每传说+5%最终伤
    { 33, "凡人之志" },  // NoOrangeEquip 鞋:每非传说+15%最终伤
    { 34, "炎龙披肩" },  // HuoAdd 披风:火掌控+15%
    { 35, "霜语披风" },  // IceAdd 披风:冰掌控+15%
    { 36, "雷灵斗篷" },  // DianAdd 披风:雷掌控+15%
    { 37, "暗影斗篷" },  // HeiAnAdd 披风:暗掌控+15%
    { 38, "烈火之冠" },  // HuoDamageAdd 盔:火伤+15%
    { 39, "寒冰面甲" },  // IceDamageAdd 盔:冰伤+15%
    { 40, "雷霆头盔" },  // DianDamageAdd 盔:雷伤+15%
    { 41, "暗夜之颅" },  // HeiAnDamageAdd 盔:暗伤+15%
    { 42, "炎息项链" },  // HuoSkillCdAdd 项链:火技能CD-15%
    { 43, "冰心吊坠" },  // IceSkillCdAdd 项链:冰技能CD-15%
    { 44, "雷音项链" },  // DianSkillCdAdd 项链:雷技能CD-15%
    { 45, "暗语项圈" },  // HeiAnSkillCdAdd 项链:暗技能CD-15%
    { 46, "火龙指环" },  // HuoSkillDamageAdd 戒:火技能伤+15%
    { 47, "冰霜之戒" },  // IceSkillDamageAdd 戒:冰技能伤+15%
    { 48, "雷霆指环" },  // DianSkillDamageAdd 戒:雷技能伤+15%
    { 49, "暗星戒指" },  // HeiAnSkillDamageAdd 戒:暗技能伤+15%
    { 50, "焰刃法袍" },  // HuoWeapponDamageAdd 衣:火武器伤+15%
    { 51, "冰刃圣衣" },  // IceWeapponDamageAdd 衣:冰武器伤+15%
    { 52, "雷刃战袍" },  // DianWeapponDamageAdd 衣:雷武器伤+15%
    { 53, "暗刃魔衣" },  // HeiAnWeapponDamageAdd 衣:暗武器伤+15%
    { 54, "万象之靴" },  // AddAllYuanSu 鞋:全掌控+20%
    { 55, "极冰之心" },  // IceMaster 项链:冰专精(全转冰)
    { 56, "烈焰之心" },  // HuoMaster 项链:火专精
    { 57, "雷霆之心" },  // DianMaster 项链:雷专精
    { 58, "暗渊之心" },  // HeiAnMaster 项链:暗专精
    { 59, "寒霜法衣" },  // IceSkill1 衣:冰技1范围伤CD
    { 60, "冰旋披风" },  // IceSkill2 披风:冰技2转速伤CD
    { 61, "凛冬之盔" },  // IceSkill3 盔:冰技3范围伤CD
    { 62, "冰晶指环" },  // IceSkill4 戒:冰技4伤CD
    { 63, "极寒项链" },  // IceSkill5 项链:冰技5+5冰晶
    { 64, "炽焰法袍" },  // HuoSkill1 衣:火技1伤CD
    { 65, "炎爆斗篷" },  // HuoSkill2 披风:火技2持续CD
    { 66, "陨火头盔" },  // HuoSkill3 盔:火技3+2流星
    { 67, "焚天指环" },  // HuoSkill4 戒:火技4范围伤CD
    { 68, "流星项链" },  // HuoSkill5 项链:火技5+2陨石
    { 69, "雷衣法袍" },  // DianSkill1 衣:雷技1范围伤CD
    { 70, "雷暴斗篷" },  // DianSkill2 披风:雷技2持续CD
    { 71, "雷霆之冠" },  // DianSkill3 盔:雷技3+5闪电
    { 72, "电弧指环" },  // DianSkill4 戒:雷技4范围伤CD
    { 73, "雷链项链" },  // DianSkill5 项链:雷技5范围伤CD
    { 74, "暗影法袍" },  // HeiAnSkill1 衣:暗技1范围伤CD
    { 75, "暗涌斗篷" },  // HeiAnSkill2 披风:暗技2持续CD
    { 76, "幽暗面甲" },  // HeiAnSkill3 盔:暗技3范围伤CD
    { 77, "黑涡指环" },  // HeiAnSkill4 戒:暗技4转速伤CD
    { 78, "深渊项链" },  // HeiAnSkill5 项链:暗技5+2漩涡
};


public static Dictionary<int, string> OrangeIdDescDic
{
    get
    {
        var dic = new Dictionary<int, string>
        {
            { 1, "最终受到的伤害减少300点" },
            { 2, "最终受到的伤害减少10%" },
            { 3, "所有治疗效果增加20%" },
            { 4, "战斗时每5秒增加3%最大生命值，最多增加100%" },
            { 5, "战斗时每5秒增加2%防御，最多叠加10层" },
            { 6, "免疫一次死亡，触发后回复30%最大生命值" },
            { 7, "将受到的伤害的30%储存起来，在3秒内缓慢施加" },
            { 8, "当生命值减少到50%时，增加30%的回复效果" },
            { 9, "当生命值减少到50%时，增加15%的免伤" },
            { 10, "最终造成的伤害增加15%" },
            { 11, "有5%的几率秒杀普通怪物" },
            { 12, "战斗时每5秒增加3%攻击力，最多叠加10层" },
            { 13, "减少30%攻击力，增加50%生命值" },
            { 14, "减少50%生命值，增加30%攻击力" },
            { 15, "对被减速的敌人造成的伤害增加15%" },
            { 16, "根据武器品质提升最终伤害：白色+200%，绿色+150%，蓝色+100%，紫色+50%" },
            { 17, "普通攻击伤害增加100%，但无法使用技能" },
            { 18, "武器伤害增加50%，技能伤害减少50%" },
            { 19, "武器攻击速度增加50%" },
            { 20, "技能伤害增加50%，武器伤害减少50%" },
            { 21, "冲刺的基础冷却时间减少30%" },
            { 22, "冲刺的距离增加30%" },
            { 23, "移动速度增加25%" },
            { 24, "获得的经验值增加25%" },
            { 25, "装备掉落率增加30%" },
            { 26, "装备掉落率增加30%" },
            { 27, "装备掉落率增加30%" },
            { 28, "装备掉落率增加30%" },
            { 29, "装备掉落率增加30%" },
            { 30, "装备掉落率增加30%" },
            { 31, "获得的灵魂数量增加25%" },
            { 32, "每装备一件传说装备，最终伤害增加5%" },
            { 33, "每装备一件非传说装备，最终伤害增加15%" },
            { 34, "火元素掌控增加15%" },
            { 35, "冰元素掌控增加15%" },
            { 36, "雷元素掌控增加15%" },
            { 37, "暗元素掌控增加15%" },
            { 38, "火元素伤害增加15%" },
            { 39, "冰元素伤害增加15%" },
            { 40, "雷元素伤害增加15%" },
            { 41, "暗元素伤害增加15%" },
            { 42, "火系技能的冷却时间减少15%" },
            { 43, "冰系技能的冷却时间减少15%" },
            { 44, "雷系技能的冷却时间减少15%" },
            { 45, "暗系技能的冷却时间减少15%" },
            { 46, "火系技能的伤害增加15%" },
            { 47, "冰系技能的伤害增加15%" },
            { 48, "雷系技能的伤害增加15%" },
            { 49, "暗系技能的伤害增加15%" },
            { 50, "火属性武器的伤害增加15%" },
            { 51, "冰属性武器的伤害增加15%" },
            { 52, "雷属性武器的伤害增加15%" },
            { 53, "暗属性武器的伤害增加15%" },
            { 54, "所有属性元素掌控增加20%" },
            { 55, "将所有元素掌控的数值全部转化为冰元素掌控" },
            { 56, "将所有元素掌控的数值全部转化为火元素掌控" },
            { 57, "将所有元素掌控的数值全部转化为雷元素掌控" },
            { 58, "将所有元素掌控的数值全部转化为暗元素掌控" },
        };

        // 技能类描述动态获取技能名
        dic.Add(59, $"{SkillConfig.SkillNameDic[SkillType.Ice1]}：效果范围增加15%，伤害增加15%，冷却时间减少15%");
        dic.Add(60, $"{SkillConfig.SkillNameDic[SkillType.Ice2]}：转速增加25%，伤害增加15%，冷却时间减少15%");
        dic.Add(61, $"{SkillConfig.SkillNameDic[SkillType.Ice3]}：效果范围增加15%，伤害增加15%，冷却时间减少15%");
        dic.Add(62, $"{SkillConfig.SkillNameDic[SkillType.Ice4]}：冰锥数量增加2，伤害增加15%，冷却时间减少15%");
        dic.Add(63, $"{SkillConfig.SkillNameDic[SkillType.Ice5]}：冰晶数量增加5个，伤害增加15%，冷却时间减少15%");
        dic.Add(64, $"{SkillConfig.SkillNameDic[SkillType.Huo1]}：火焰弹数量+2，伤害增加15%，冷却时间减少15%");
        dic.Add(65, $"{SkillConfig.SkillNameDic[SkillType.Huo2]}：持续时间增加25%，冷却时间减少25%");
        dic.Add(66, $"{SkillConfig.SkillNameDic[SkillType.Huo3]}：火焰流星数量增加2个，伤害增加15%，冷却时间减少15%");
        dic.Add(67, $"{SkillConfig.SkillNameDic[SkillType.Huo4]}：效果范围增加25%，伤害增加15%，冷却时间减少15%");
        dic.Add(68, $"{SkillConfig.SkillNameDic[SkillType.Huo5]}：陨石数量增加2个，伤害增加15%，冷却时间减少15%");
        dic.Add(69, $"{SkillConfig.SkillNameDic[SkillType.Dian1]}：效果范围增加15%，伤害增加15%，冷却时间减少15%");
        dic.Add(70, $"{SkillConfig.SkillNameDic[SkillType.Dian2]}：持续时间增加25%，冷却时间减少25%");
        dic.Add(71, $"{SkillConfig.SkillNameDic[SkillType.Dian3]}：闪电数量增加5个，伤害增加15%，冷却时间减少15%");
        dic.Add(72, $"{SkillConfig.SkillNameDic[SkillType.Dian4]}：效果范围增加15%，伤害增加15%，冷却时间减少15%");
        dic.Add(73, $"{SkillConfig.SkillNameDic[SkillType.Dian5]}：效果范围增加15%，伤害增加15%，冷却时间减少15%");
        dic.Add(74, $"{SkillConfig.SkillNameDic[SkillType.HeiAn1]}：效果范围增加15%，伤害增加15%，冷却时间减少15%");
        dic.Add(75, $"{SkillConfig.SkillNameDic[SkillType.HeiAn2]}：持续时间增加25%，冷却时间减少25%");
        dic.Add(76, $"{SkillConfig.SkillNameDic[SkillType.HeiAn3]}：效果范围增加15%，伤害增加15%，冷却时间减少15%");
        dic.Add(77, $"{SkillConfig.SkillNameDic[SkillType.HeiAn4]}：转速增加25%，伤害增加15%，冷却时间减少15%");
        dic.Add(78, $"{SkillConfig.SkillNameDic[SkillType.HeiAn5]}：黑暗漩涡数量增加2个，伤害增加15%，冷却时间减少15%");

        return dic;
    }
}


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
        FanPuGuiZhen,//装备非传说武器增加50%最终伤害                ring          1111    
        NoSkill,//普通攻击伤害增加100%，但是不能使用技能（技能伤害）          Ring     11111
        AddWeaponReduceSkill,//增加50%武器伤害，减少30%技能伤害           Cloak      111111
        AddAttackSpeedEntry,//增加武器攻击速度30%                       Cloak      111111
        AddSkillReduceWeapon,//增加50%技能伤害，减少30%武器伤害           Cloak      11111

        //Dash
        DashCd,//Dash基础Cd减少30%                 shoe                           1111
        DashRange,//Dash距离增加30%                shoe                          1111
        //特殊词条
        MoveSpeedAdd,//移动速度增加25%              shoe                          1111
        ExAdd,//经验获取增加25%                     shoe                         1111
        ClothFortureAdd,//掉落率增加30%             cloth                         1111
        ShoeFortureAdd,//掉落率增加30%              shoe                         1111
        CloakFortureAdd,//掉落率增加30%             cloak                        1111
        NecklaceFortureAdd,//掉落率增加30%          necklace                     1111
        RingFortureAdd,//掉落率增加30%              ring                        1111
        HelmetFortureAdd,//掉落率增加30%            helmet                       1111
        AddSoul,//增加灵魂获取25%                    Cloak                       1111
        OrangeEquip,//每装备一件传说装备增加5%最终伤害   Shoe                        1111
        NoOrangeEquip,//每装备一件非传说装备增加15%最终伤害    Shoe                  1111
        
        
        
        //新加45个
        HuoAdd,//增加火元素掌控15%        Cloak     1111
        IceAdd,//增加火元素掌控15%        Cloak     1111
        DianAdd,//增加火元素掌控15%       Cloak     1111
        HeiAnAdd,//增加火元素掌控15%      Cloak     1111
        
        
        HuoDamageAdd,//增加火元素伤害15%        Helmet     1111
        IceDamageAdd,//增加火元素伤害15%        Helmet     1111
        DianDamageAdd,//增加火元素伤害15%       Helmet     1111
        HeiAnDamageAdd,//增加火元素伤害15%      Helmet     1111
        
        
        HuoSkillCdAdd,//火技能cd减少20%      Necklace     1111
        IceSkillCdAdd,//冰技能cd减少20%        Necklace    1111
        DianSkillCdAdd,//电技能cd减少20%       Necklace    1111
        HeiAnSkillCdAdd,//黑暗技能cd减少20%     Necklace    1111
        
        
        HuoSkillDamageAdd,//火技能伤害增加25%      Ring       1111
        IceSkillDamageAdd,//冰技能伤害增加25%        Ring     1111
        DianSkillDamageAdd,//电技能伤害增加25%       Ring     1111
        HeiAnSkillDamageAdd,//黑暗技能伤害增加25%     Ring    1111
        
        HuoWeapponDamageAdd,//火武器伤害增加25%      Cloth     1111
        IceWeapponDamageAdd,//冰武器伤害增加25%        Cloth   1111
        DianWeapponDamageAdd,//电武器伤害增加25%       Cloth   1111
        HeiAnWeapponDamageAdd,//黑暗武器伤害增加25%     Cloth   1111
        
        AddAllYuanSu,//增加所有属性元素掌控20%          Shoe      1111
        
        IceMaster,//将所有的元素掌控增加到冰元素上        Necklace    1111
        HuoMaster,//将所有的元素掌控增加到火元素上        Necklace    1111
        DianMaster,//将所有的元素掌控增加到电元素上        Necklace    1111
        HeiAnMaster,//将所有的元素掌控增加到黑暗元素上       Necklace   1111
        
        IceSkill1,//IceSkill1效果范围增加15%，伤害增加15%，cd减少15%       Cloth
        IceSkill2,//IceSkill2转速增加25%，伤害增加15%，cd减少15%          Cloak
        IceSkill3,//IceSkill3效果范围增加15%，伤害增加15%，cd减少15%       Helmet
        IceSkill4,//IceSkill4冰锥数量增加2，伤害增加15%，cd减少15%                      Ring
        IceSkill5,//IceSkill5冰晶数量增加5，伤害增加15%，cd减少15%         Necklace


        HuoSkill1,//HuoSkill1 火焰弹数量增加2，伤害增加15%，cd减少15%                     Cloth
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
