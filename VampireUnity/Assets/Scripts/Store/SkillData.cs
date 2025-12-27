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
    Dash
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
    
    public SkillJiaDian JiaDian=new SkillJiaDian();
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
