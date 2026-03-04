using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillData : XSingleton<SkillData>
{
    public SkillJiaDian JiaDian=new SkillJiaDian();
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
