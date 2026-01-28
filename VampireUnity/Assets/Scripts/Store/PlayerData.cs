using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.Serialization;


public class PlayerData : XSingleton<PlayerData>
{
    public  int level=1;
    public int exp=0;
    public int bloodEnergy=0;
    public int maxGameLevel=1;
    public int ChiBangLevel=0;
    public int ChiBangEx=0;
    
    public int clothid;
    public int cloakid;
    public int helmetid;
    public int ringid;
    public int shoeid;
    public int necklaceid;


    public int primaryWeaponLevel=1;
    public int duWeaponLevel;
    public int puTong3WeaponLevel;
    public int xuKongWeaponLevel;
    public int lvQuanWeaponLevel;
    public int fireWeaponLevel;
    public int heiDongWeaponLevel;
    public int jianQiWeaponLevel;
    
    public int primaryHunQiLevel=0;
    public int duHunQiLevel=0;
    public int puTong3HunQiLevel=0;
    public int xuKongHunQiLevel=0;
    public int lvQuanHunQiLevel=0;
    public int fireHunQiLevel=0;
    public int heiDongHunQiLevel=0;
    public int jianQiHunQiLevel=0;
    
    public int primaryHunQiEx=0;
    public int duHunQiEx=0;
    public int puTong3HunQiEx=0;
    public int xuKongHunQiEx=0;
    public int lvQuanHunQiEx=0;
    public int fireHunQiEx=0;
    public int heiDongHunQiEx=0;
    public int jianQiHunQiEx=0;

    public int zhuanjinCount = 0;


    public WeaponType playerWeaponType=WeaponType.Primary;
    public MJLevel mJLevel = MJLevel.White;
    public LanguageType langType=LanguageType.Chinese;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void SaveWearEquip(int equipType, int equipid)
    {
        switch (equipType)
        {
            case 1:
                cloakid = equipid;
                break;
            case 2:
                clothid = equipid;
                break;
            case 3:
                helmetid = equipid;
                break;
            case 4:
                necklaceid = equipid;
                break;
            case 5:
                ringid = equipid;
                break;
            case 6:
                shoeid = equipid;
                break;
        }
    }
}
