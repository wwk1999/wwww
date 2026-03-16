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
    public int maxGameLevel=3;
    public int ChiBangLevel=0;
    public int ChiBangEx=0;
    
    public int clothid;
    public int cloakid;
    public int helmetid;
    public int ringid;
    public int shoeid;
    public int necklaceid;


    public int primaryWeaponLevel=1;
    public int primaryDianLevel=1;
    public int primaryHuoLevel=1;
    public int primaryHeiAnLevel=1;
    public int dianBaoZhaLevel;
    public int iceBaoZhaLevel;
    public int HuoBaoZhaWeaponLevel;
    public int puTong3WeaponLevel;
    public int xuKongWeaponLevel;
    public int lvQuanWeaponLevel;
    public int fireWeaponLevel;
    public int heiDongWeaponLevel;
    public int jianQiWeaponLevel;
    public int Huo7WeaponLevel;
    public int IcePenWeaponLevel;
    public int Ice7WeaponLevel;
    public int Ice4BaoZhaWeaponLevel;
    public int HuoFenLieWeaponLevel;
    public int HuoDiPenWeaponLevel;
    public int HeiAnQuXianWeaponLevel;
    public int HeiAnHuiXuanWeaponLevel;
    public int HeiAnBaoZhaWeaponLevel;
    public int DianSanSheWeaponLevel;
    public int DianLuoLei5WeaponLevel;
    public int DianJiSuWeaponLevel;

    
    public int primaryWeaponExp;
    public int primaryDianExp;
    public int primaryHuoExp;
    public int primaryHeiAnExp;
    public int dianBaoZhaExp;
    public int iceBaoZhaExp;
    public int HuoBaoZhaExp;
    public int puTong3WeaponExp;
    public int xuKongWeaponExp;
    public int lvQuanWeaponExp;
    public int fireWeaponExp;
    public int heiDongWeaponExp;
    public int jianQiWeaponExp;
    public int Huo7WeaponExp;
    public int IcePenWeaponExp;
    public int Ice7WeaponExp;
    public int Ice4BaoZhaWeaponExp;
    public int HuoFenLieWeaponExp;
    public int HuoDiPenWeaponExp;
    public int HeiAnQuXianWeaponExp;
    public int HeiAnHuiXuanWeaponExp;
    public int HeiAnBaoZhaWeaponExp;
    public int DianSanSheWeaponExp;
    public int DianLuoLei5WeaponExp;
    public int DianJiSuWeaponExp;

    

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
    
    public Dictionary<int,ChongWuTable> ChongWuDic = new Dictionary<int,ChongWuTable>();

    public int FlagChongWuId=1;
    public int ZhuChongWuId=0;
    public int FuChongWuId1=0;
    public int FuChongWuId2=0;
    public int FuChongWuId3=0;

    public int ChongWuJingHua = 0;

    public int ChongWuShiWu1 = 0;
    public int ChongWuShiWu2 = 0;
    public int ChongWuShiWu3 = 0;
    public int ChongWuShiWu4 = 0;
    public int ChongWuShiWu5 = 0;
    public int ChongWuShiWu6 = 0;

    public int RateX=1920;
    public int RateY=1080;
    public bool IsQuanPing=false;

    public int GameTime = 0;

    
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
