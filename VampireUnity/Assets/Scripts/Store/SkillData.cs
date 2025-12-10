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
public class SkillData : XSingleton<SkillData>
{
    public SkillType LMB = SkillType.Normal;
    public SkillType RMB = SkillType.Dash;
    public SkillType Alpha1 = SkillType.Skill1;
    public SkillType Alpha2 = SkillType.Skill2;
    public SkillType Alpha3 = SkillType.Skill3;
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
