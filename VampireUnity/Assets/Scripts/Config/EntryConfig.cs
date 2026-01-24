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
    { OrangeEntry.BuWangChuXin, "连星斗篷" },
    { OrangeEntry.HeiDongAddSpeed, "奇点披风" },
    { OrangeEntry.DuAddDuQuan, "疫病斗篷" },
    { OrangeEntry.LvQuanAddScale, "生命披风" },
    { OrangeEntry.XuKongAdd2Dan, "增生披风" },
    { OrangeEntry.PuTong3ChuanTou, "贯穿斗篷" },
    { OrangeEntry.FireBaoZha, "爆炎斗篷" },

    // Skill1
    { OrangeEntry.Skill1ReplaceNormalAttack, "技极项链" },
    { OrangeEntry.Skill1YiDianDouble, "蓄雷指环" },
    { OrangeEntry.Skill1AddRange, "扩散头盔" },

    // Skill2
    { OrangeEntry.Skill2AddDan, "双子项链" },
    { OrangeEntry.Skill2RotateAdd, "回旋指环" },
    { OrangeEntry.Skill2AddRange, "引力头盔" },

    // Skill3
    { OrangeEntry.Skill3Bian3, "三重项链" },
    { OrangeEntry.Skill3AddRange, "回响指环" },

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
    { OrangeEntry.AddDefenseForTime, "战斗时每5s增加2%防御，上限60%" },
    { OrangeEntry.ReplyDeath, "免疫一次死亡,恢复到30%最大生命值" },
    { OrangeEntry.DelayDamage, "将收到的伤害的30%存储起来在3s内缓慢施加" },
    { OrangeEntry.HpReductionReplyAdd50, "血量减少到50%增加30%回复效果" },
    { OrangeEntry.HpReductionAddDefense, "血量减少到50%增加15%免伤" },

    // 攻击
    { OrangeEntry.FinalDamageAddPercent, "最终伤害增加15%" },
    { OrangeEntry.KillNormal, "5%概率秒杀小怪" },
    { OrangeEntry.AddAttackForTime, "战斗中每5s增加3%攻击，上限100%" },
    { OrangeEntry.NormalAddDamage, "每穿戴一件传说以下品质装备增加最终伤害30%" },
    { OrangeEntry.RecudeHpAddAttack, "减少50%hp增加30%attack" },
    { OrangeEntry.JianSuAddAttack, "对被减速的敌人增加15%伤害" },

    // 普攻
    { OrangeEntry.FanPuGuiZhen, "装备白色武器最终伤害增加200%，绿色150%，蓝色100%，紫色50%" },
    { OrangeEntry.NoSkill, "普通攻击伤害增加100%，但是不能使用技能" },
    { OrangeEntry.BuWangChuXin, "原木法杖改为连射发射模式，一次发射的弹道数量*2" },
    { OrangeEntry.HeiDongAddSpeed, "湮灭之杖的攻击速度增加100%" },
    { OrangeEntry.DuAddDuQuan, "腐蚀权杖击中敌人在原地留下毒圈" },
    { OrangeEntry.LvQuanAddScale, "增加源极杖50%大小" },
    { OrangeEntry.XuKongAdd2Dan, "虚空杖增加2个魔法弹" },
    { OrangeEntry.PuTong3ChuanTou, "三叉法杖可以穿透敌人" },
    { OrangeEntry.FireBaoZha, "爆炎杖弹爆炸范围增大50%" },

    // Skill1
    { OrangeEntry.Skill1ReplaceNormalAttack, "skill1代替普通攻击，最终伤害增加100%，不能普通攻击" },
    { OrangeEntry.Skill1YiDianDouble, "易电状态伤害增加翻倍" },
    { OrangeEntry.Skill1AddRange, "skill1范围增加20%" },

    // Skill2
    { OrangeEntry.Skill2AddDan, "Skill2增加一个魔法弹" },
    { OrangeEntry.Skill2RotateAdd, "Skill2转速增加30%" },
    { OrangeEntry.Skill2AddRange, "增加Skill2范围30%,体积增大30%" },

    // Skill3
    { OrangeEntry.Skill3Bian3, "skill3变为发射3波，每一波伤害减少50%" },
    { OrangeEntry.Skill3AddRange, "Skill3增加范围30%" },

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
        AddHpForTime,//战斗时每5s增加3%最大生命值，上限100%         Hlemet     1111
        AddDefenseForTime,//战斗时每5s增加2%防御，上限60%         Cloth      1111
        ReplyDeath,//免疫一次死亡                            Cloth          1111
        DelayDamage,//将收到的伤害的30%存储起来在3s内缓慢施加         helmet     1111
        HpReductionReplyAdd50,//血量减少到50%增加30%回复效果        cloth     1111
        HpReductionAddDefense,//血量减少到50%增加15%免伤           helmet    1111
        //攻击词条
        FinalDamageAddPercent,//最终伤害增加15%                   necklace    1111
        KillNormal,//5%概率秒杀小怪                               ring        1111
        AddAttackForTime,//战斗中每5s增加3%攻击，上限100%           ring        1111
        NormalAddDamage,//每穿戴一件传说以下品质装备增加最终伤害30%    necklace    1111
        RecudeHpAddAttack,//减少50%hp增加30%attack               necklace    1111
        JianSuAddAttack,//对被减速的敌人增加15%伤害                 Shoe        1111
        //普通攻击
        FanPuGuiZhen,//装备白色武器最终伤害增加200%，绿色武器最终伤害增加150%，蓝色100%，紫色50%    ring
        NoSkill,//普通攻击伤害增加100%，但是不能使用技能（技能伤害）          necklace
        BuWangChuXin,//最初武器改为连射发射模式，一次发射的弹道数量*2         cloak
        HeiDongAddSpeed,//黑洞武器的攻击速度增加100%                      cloak
        DuAddDuQuan,//毒武器击中敌人在原地留下毒圈                         cloak
        LvQuanAddScale,//增加绿圈武器50%大小                            cloak
        XuKongAdd2Dan,//虚空武器增加2个魔法弹                            cloak
        PuTong3ChuanTou,//普通3可以穿透敌人                             cloak
        FireBaoZha,//火焰弹爆炸范围增大50%                              cloak
        //skill1
        Skill1ReplaceNormalAttack,//skill1代替普通攻击，skill1CD减少50%，最终伤害增加50%，不能普通攻击       necklace   1111
        Skill1YiDianDouble,//易电状态伤害增加翻倍                                 ring              1111
        Skill1AddRange,//skill1范围增加20%                                      helmet           1111
        //skill2
        Skill2AddDan,//Skill2增加一个魔法弹                                       necklace        1111
        Skill2RotateAdd,//Skill2转速增加30%                                      ring            1111
        Skill2AddRange,//增加Skill2范围30%,体积增大30%                             helmet          1111
        //Skill3
        Skill3Bian3,//skill3变为发射3波，每一波伤害减少30%                           necklace         2222
        Skill3AddRange,//Skill3增加范围30%                                       ring             1111
        //Dash
        DashCd,//Dash基础Cd减少30%                 shoe                                           1111
        DashRange,//Dash距离增加30%                shoe                                           1111
        //特殊词条
        MoveSpeedAdd,//移动速度增加25%              shoe                                           1111
        ExAdd,//经验获取增加20%                     shoe                                           1111
        ClothFortureAdd,//掉落率增加30%             cloth                                          1111
        ShoeFortureAdd,//掉落率增加30%              shoe                                           1111
        CloakFortureAdd,//掉落率增加30%             cloak                                          1111
        NecklaceFortureAdd,//掉落率增加30%          necklace                                       1111
        RingFortureAdd,//掉落率增加30%              ring                                           1111
        HelmetFortureAdd,//掉落率增加30%            helmet                                         1111
    }
    
    
}
