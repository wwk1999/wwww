using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChongWuSkillShuFight : PropBase
{
    public ChongWuSkillShuFight() : base( new PropTable()){}
    [NonSerialized]public int quality;
    public Sprite image;

    public void OnEnable()
    {
        base.OnEnable();
        propTables.EquipName = "ChongWuSkillShu";
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.SkillShu;
        propTables.Quality = quality;
        switch (quality)
        {
            case 1:
                image = ResourcesConfig.ChongWuSkill1;
                break;
            case 2:
                image = ResourcesConfig.ChongWuSkill2;
                break;
            case 3:
                image = ResourcesConfig.ChongWuSkill3;
                break;
            case 4:
                image = ResourcesConfig.ChongWuSkill4;
                break;
            case 5:
                image = ResourcesConfig.ChongWuSkill5;
                break;
            case 6:
                image = ResourcesConfig.ChongWuSkill6;
                break;
        }
    }
}
