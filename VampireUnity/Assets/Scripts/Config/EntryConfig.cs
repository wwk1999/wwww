using System.Collections;
using System.Collections.Generic;
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
    { DefenseEntry.MaxHpPercent,             new DefenseEntryConfig { DefenseEntry = DefenseEntry.MaxHpPercent,             minValue = 5, maxValue = 10 } },
    { DefenseEntry.MaxDefensePercent,        new DefenseEntryConfig { DefenseEntry = DefenseEntry.MaxDefensePercent,        minValue = 5, maxValue = 10 } },
    { DefenseEntry.DamageReductionPercent,   new DefenseEntryConfig { DefenseEntry = DefenseEntry.DamageReductionPercent,   minValue = 5, maxValue = 10 } },
    { DefenseEntry.DamageReductionPercentForNormal, new DefenseEntryConfig { DefenseEntry = DefenseEntry.DamageReductionPercentForNormal, minValue = 8, maxValue = 15 } },
    { DefenseEntry.DamageReductionPercentForBoss,   new DefenseEntryConfig { DefenseEntry = DefenseEntry.DamageReductionPercentForBoss,   minValue = 8, maxValue = 15 } },
    { DefenseEntry.ReplyHpPercent,           new DefenseEntryConfig { DefenseEntry = DefenseEntry.ReplyHpPercent,           minValue = 3, maxValue = 6 } },
};

public static Dictionary<DamageEntry, DamageEntryConfig> DamageEntryConfigs =
    new Dictionary<DamageEntry, DamageEntryConfig>()
{
    { DamageEntry.CRITDamage,        new DamageEntryConfig { DamageEntry = DamageEntry.CRITDamage,        minValue = 5, maxValue = 10 } },
    { DamageEntry.DamageSpeed,       new DamageEntryConfig { DamageEntry = DamageEntry.DamageSpeed,       minValue = 5, maxValue = 10 } },
    { DamageEntry.DamageAddForNormal,new DamageEntryConfig { DamageEntry = DamageEntry.DamageAddForNormal,minValue = 8, maxValue = 15 } },
    { DamageEntry.DamageAddForBoss,  new DamageEntryConfig { DamageEntry = DamageEntry.DamageAddForBoss,  minValue = 8, maxValue = 15 } },
    { DamageEntry.Penetrate,         new DamageEntryConfig { DamageEntry = DamageEntry.Penetrate,         minValue = 5, maxValue = 10 } },
    { DamageEntry.DamageAddPercent,  new DamageEntryConfig { DamageEntry = DamageEntry.DamageAddPercent,  minValue = 5, maxValue = 10 } },
    { DamageEntry.BloodSuck,         new DamageEntryConfig { DamageEntry = DamageEntry.BloodSuck,         minValue = 2, maxValue = 4 } },
};

public static Dictionary<DefenseEntry, string> DefenseEntryNameDic = new Dictionary<DefenseEntry, string>()
{
    { DefenseEntry.KillReplyHpPercent, "击杀回复Hp :" },
    { DefenseEntry.MaxHpPercent, "百分比增加Hp :" },
    { DefenseEntry.MaxDefensePercent, "百分比增加Def :" },
    { DefenseEntry.DamageReductionPercent, "伤害减免 :" },
    { DefenseEntry.DamageReductionPercentForNormal, "减免普通怪伤害 :" },
    { DefenseEntry.DamageReductionPercentForBoss, "减免Boss伤害 :" },
    { DefenseEntry.ReplyHpPercent, "每3s回复生命值 :" },
};
public static Dictionary<DamageEntry, string> DamageEntryNameDic = new Dictionary<DamageEntry, string>()
{
    { DamageEntry.CRITDamage, "暴击伤害 :" },
    { DamageEntry.DamageSpeed, "攻击速度 :" },
    { DamageEntry.DamageAddForNormal, "对普通怪伤害 :" },
    { DamageEntry.DamageAddForBoss, "对Boss伤害 :" },
    { DamageEntry.Penetrate, "防御穿透 :" },
    { DamageEntry.DamageAddPercent, "百分比增加Att :" },
    { DamageEntry.BloodSuck, "吸血 :" },
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
        FinalDamageReductionFixed,//最终伤害减少300
        FinalDamageReductionPercent,//最终伤害减少10%
        AllReplyAddPercent,//所有的治疗效果增加20%
        AddHpForTime,//战斗时每5s增加3%最大生命值，上限100%
        AddDefenseForTime,//战斗时每5s增加3%防御，上限100%
        ReplyDeath,//免疫死亡，cd60s
        DelayDamage,//将收到的伤害的30%存储起来在3s内缓慢施加
        HpReductionReplyAdd50,//血量减少到50%增加30%回复效果
        HpReductionAddDefense,//血量减少到50%增加20%防御
        //攻击词条
        FinalDamageAddPercent,//最终伤害增加15%
        KillNormal,//5%概率秒杀小怪
        AddAttackForTime,//战斗中每5s增加3%攻击，上限100%
        NormalAddDamage,//每穿戴一件传说以下品质装备增加最终伤害30%
        RecudeHpAddAttack,//减少50%hp增加30%attack
        //普通攻击
        FanPuGuiZhen,//装备白色武器最终伤害增加200%，绿色武器最终伤害增加150%，蓝色100%，紫色50%
        NoSkill,//普通攻击伤害增加100%，但是不能使用技能（技能伤害）
        BuWangChuXin,//最初武器改为连射发射模式，一次发射的弹道数量*2
        HeiDongAddSpeed,//黑洞武器的攻击速度增加100%
        DuAddDuQuan,//毒武器击中敌人在原地留下毒圈
        LvQuanAddScale,//增加绿圈武器50%大小
        XuKongAdd2Dan,//虚空武器增加2个魔法弹
        PuTong3ChuanTou,//普通3可以穿透敌人
        //skill1
        Skill1ReplaceNormalAttack,//skill1代替普通攻击，技能伤害增加100%，不能普通攻击
        Skill1YiDianDouble,//易电状态伤害增加翻倍
        Skill1AddRange,//skill1范围增加20%
        //skill2
        Skill2AddDan,//Skill2增加一个魔法弹
        Skill2RotateAdd,//Skill2转速增加30%
        Skill2AddRange,//增加Skill2范围30%
        //Skill3
        Skill3Bian3,//skill3变为发射3波，每一波伤害减少50%
        Skill3AddRange,//Skill3增加范围30%
        //Dash
        DashCd,//Dash基础Cd减少30%
        DashRange,//Dash距离增加30%
        //特殊词条
        MoveSpeedAdd,//移动速度增加50%
        ExAdd,//经验获取增加20%
        ClothFortureAdd,//掉落率增加30%
        ShoeFortureAdd,//掉落率增加30%
        CloakFortureAdd,//掉落率增加30%
        NecklaceFortureAdd,//掉落率增加30%
        RingFortureAdd,//掉落率增加30%
        HelmetFortureAdd,//掉落率增加30%
    }
    
    
}
