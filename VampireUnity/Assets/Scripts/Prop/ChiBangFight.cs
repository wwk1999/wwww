using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class ChiBangFight : PropBase
{
     public ChiBangFight() : base( new PropTable()){}
    public ChiBangType ChiBangType;
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
        int quality=ChiBangConfig.GetChiBangQuality(ChiBangType);
        Beam1.gameObject.SetActive(false);
        Beam2.gameObject.SetActive(false);
        Beam3.gameObject.SetActive(false);
        Beam4.gameObject.SetActive(false);
        Beam5.gameObject.SetActive(false);
        Beam6.gameObject.SetActive(false);
        propTables.Count = 1;
        propTables.Desc = null;
        propTables.PropType = PropConfig.PropType.ChiBangFight;
        propTables.ChiBangType=ChiBangType;
        propTables.Quality = quality;
        image.sprite=ChiBangConfig.GetChiBangSprite(ChiBangType);
        switch (quality)
        {
            case 1:
                Beam1.gameObject.SetActive(true);
                break;
            case 2:
                Beam2.gameObject.SetActive(true);
                break;
            case 3:
                Beam3.gameObject.SetActive(true);
                break;
            case 4:
                Beam4.gameObject.SetActive(true);
                break;
            case 5:
                Beam5.gameObject.SetActive(true);
                break;
            case 6:
                Beam6.gameObject.SetActive(true);
                break;
        }
    }
}
