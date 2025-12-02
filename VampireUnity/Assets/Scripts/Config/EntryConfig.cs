using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryConfig : MonoBehaviour
{
    public enum DefenseEntry
    {
        None,
        KillReplyHpFixed,
        KillReplyHpPercent,
        MaxHpPercent,
        MaxDefensePercent,
        DamageReductionPercent,
        DamageReductionPercentForNormal,
        DamageReductionPercentForBoss,
        ReplyHpFixed,
        ReplyHpPercent,
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
    
    public enum OrangeEntryOrange
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
        AllAttributeAdd
        
        //技能
    }
}
