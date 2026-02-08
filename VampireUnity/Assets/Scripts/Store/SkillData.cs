using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    None,
    Skill1,
    Skill2,
    Skill3,
    Normal,
    Dash,
    IceSkill1,
    DianSkill2,
    DianSkill3,
    HuoSkill1,
    HuoSkill2,
    HuoSkill3,
    HeiAnSkill1,
    HeiAnSkill2,
    HeiAnSkill3,
}

public enum KeyCodeType
{
    None,
    LMB,
    RMB,
    Alpha1,
    Alpha2,
    Alpha3,
}

public class SkillData : XSingleton<SkillData>
{
    public SkillType LMB = SkillType.Normal;
    public SkillType RMB = SkillType.None;
    public SkillType Alpha1 = SkillType.None;
    public SkillType Alpha2 = SkillType.None;
    public SkillType Alpha3 = SkillType.None;
    
    public bool skill1Auto=false;
    public bool skill2Auto=false;
    public bool skill3Auto=false;
    public bool dashAuto=false;

    public bool IceSkill1Auto=false;
    public bool DianSkill2Auto=false;
    public bool DianSkill3Auto=false;
    public bool HuoSkill3Auto=false;
    public bool HuoSkill2Auto=false;
    public bool HuoSkill1Auto=false;
    public bool HeiAnSkill1Auto=false;
    public bool HeiAnSkill2Auto=false;
    public bool HeiAnSkill3Auto=false;

    
    public SkillJiaDian JiaDian=new SkillJiaDian();
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
