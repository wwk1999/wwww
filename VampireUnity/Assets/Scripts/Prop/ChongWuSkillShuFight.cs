using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChongWuSkillShuFight : PropBase
{
    public ChongWuSkillShuFight() : base( new PropTable()){}
    [NonSerialized]public int quality;
    public SpriteRenderer image;
    public GameObject Beam1;
    public GameObject Beam2;
    public GameObject Beam3;
    public GameObject Beam4;
    public GameObject Beam5;
    public GameObject Beam6;

    public void OnEnable()
    {
        base.OnEnable();
        Beam1.gameObject.SetActive(false);
        Beam2.gameObject.SetActive(false);
        Beam3.gameObject.SetActive(false);
        Beam4.gameObject.SetActive(false);
        Beam5.gameObject.SetActive(false);
        Beam6.gameObject.SetActive(false);
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.SkillShu;
        propTables.Quality = quality;
        switch (quality)
        {
            case 1:
                Beam1.gameObject.SetActive(true);
                image.sprite = ResourcesConfig.ChongWuSkill1;
                propTables.EquipName = "ChongWuSkillShu1";
                break;
            case 2:
                Beam2.gameObject.SetActive(true);
                image.sprite = ResourcesConfig.ChongWuSkill2;
                propTables.EquipName = "ChongWuSkillShu2";
                break;
            case 3:
                Beam3.gameObject.SetActive(true);
                image.sprite = ResourcesConfig.ChongWuSkill3;
                propTables.EquipName = "ChongWuSkillShu3";
                break;
            case 4:
                Beam4.gameObject.SetActive(true);
                image.sprite = ResourcesConfig.ChongWuSkill4;
                propTables.EquipName = "ChongWuSkillShu4";
                break;
            case 5:
                Beam5.gameObject.SetActive(true);
                image.sprite = ResourcesConfig.ChongWuSkill5;
                propTables.EquipName = "ChongWuSkillShu5";
                break;
            case 6:
                Beam6.gameObject.SetActive(true);
                image.sprite = ResourcesConfig.ChongWuSkill6;
                propTables.EquipName = "ChongWuSkillShu6";
                break;
        }
    }
}
