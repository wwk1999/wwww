using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChongWuShiWuFight : PropBase
{
    public ChongWuShiWuFight() : base( new PropTable()){}
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
        propTables.PropType = PropConfig.PropType.ChongWuShiWu;
        propTables.Quality = quality;
        switch (quality)
        {
            case 1:
                Beam1.gameObject.SetActive(true);
                propTables.EquipName = "ChongWuShiWu1";
                image.sprite = ResourcesConfig.ChongWuShiWuWhite;
                break;
            case 2:
                Beam2.gameObject.SetActive(true);
                propTables.EquipName = "ChongWuShiWu2";
                image.sprite = ResourcesConfig.ChongWuShiWuGreen;
                break;
            case 3:
                Beam3.gameObject.SetActive(true);
                propTables.EquipName = "ChongWuShiWu3";
                image.sprite = ResourcesConfig.ChongWuShiWuBlue;
                break;
            case 4:
                Beam4.gameObject.SetActive(true);
                propTables.EquipName = "ChongWuShiWu4";
                image.sprite = ResourcesConfig.ChongWuShiWuPurple;
                break;
            case 5:
                Beam5.gameObject.SetActive(true);
                propTables.EquipName = "ChongWuShiWu5";
                image.sprite = ResourcesConfig.ChongWuShiWuOrange;
                break;
            case 6:
                Beam6.gameObject.SetActive(true);
                propTables.EquipName = "ChongWuShiWu6";
                image.sprite = ResourcesConfig.ChongWuShiWuRed;
                break;
        }
    }
}
