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
    
    public bool Level5 = false;
    public bool Level15 = false;
    public bool Level30 = false;
    public bool Level50 = false;
    public bool Level75 = false;
    public bool Level100 = false;
    
    public bool MonsterCount1 = false;
    public bool MonsterCount2 = false;
    public bool MonsterCount3 = false;
    public bool MonsterCount4 = false;
    public bool MonsterCount5 = false;
    public bool MonsterCount6 = false;

    public bool LingHun = false;
    public bool BaoShi = false;
    public bool GuanKa3 = false;
    public bool GuanKa4 = false;
    public bool GuanKa5 = false;
    public bool HunQi3 = false;
    public bool HunQi4 = false;
    public bool HunQi5 = false;
    public bool ChiBang4 = false;
    public bool ChiBang5 = false;
    public bool DiaoLuo = false;


    public int MonsterCount = 0;
    public int LinHun = 0;
    public int HunQiCount = 0;
    public int OrangeCount = 0;
    
    public TitleType CurrentInstallTitle = TitleType.None;



    public WeaponType playerWeaponType=WeaponType.Primary;
    public MJLevel mJLevel = MJLevel.White;
    public LanguageType langType=LanguageType.Chinese;
    
    public List<ChongWuTable> ChongWuList = new List<ChongWuTable>();

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
