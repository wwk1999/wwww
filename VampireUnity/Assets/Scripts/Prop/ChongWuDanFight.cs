using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChongWuDanFight : PropBase
{
    public ChongWuDanFight() : base( new PropTable()){}
    [NonSerialized]public int quality;
    public SpriteRenderer image;
    public GameObject BlueBeam;
    public GameObject OrangeBeam;

    public void OnEnable()
    {
        base.OnEnable();
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.ChongWuDan;
        propTables.Quality = quality;
        if (quality == 3)
        {
            BlueBeam.gameObject.SetActive(true);
            OrangeBeam.gameObject.SetActive(false);
            image.sprite = ResourcesConfig.NormalChongWuDan;
            propTables.EquipName = "ChongWuDan3";
        }
        else
        {
            BlueBeam.gameObject.SetActive(false);
            OrangeBeam.gameObject.SetActive(true);
            image.sprite = ResourcesConfig.GaoJiChongWuDan;
            propTables.EquipName = "ChongWuDan5";
        }
    }
}
