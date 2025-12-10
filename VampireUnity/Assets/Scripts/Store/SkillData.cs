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
    public SkillType LMB = SkillType.None;
    public SkillType RMB = SkillType.None;
    public SkillType Alpha1 = SkillType.None;
    public SkillType Alpha2 = SkillType.None;
    public SkillType Alpha3 = SkillType.None;
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
