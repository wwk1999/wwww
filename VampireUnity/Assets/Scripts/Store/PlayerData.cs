using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.Serialization;


public class PlayerData : XSingleton<PlayerData>
{
    public Dictionary<ChiBangType,ChiBangInfo> ChiBangList = new Dictionary<ChiBangType,ChiBangInfo>();
    public int AllChiBangLevel=>GetAllChiBangLevel();
    public int AllChiBangLevelEx=>GetAllChiBangLevelEx();
    public ChiBangType playerChiBangType;
    public float ChiBangAttack => GetChiBangAttack();
    public float ChiBangDefense => GetChiBangDefense();
    public float ChiBangHp => GetChiBangHp();
    public float ChiBangCrit => GetChiBangCrit();

    
    public  int level=1;
    public float exp=0;
    public float bloodEnergy=0;
    public int maxGameLevel=3;
    
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

    public int IceAllLevel => primaryWeaponLevel + iceBaoZhaLevel + puTong3WeaponLevel + Ice7WeaponLevel +
                              Ice4BaoZhaWeaponLevel + IcePenWeaponLevel;
    
    public int HuoAllLevel => primaryHuoLevel + HuoBaoZhaWeaponLevel + lvQuanWeaponLevel + Huo7WeaponLevel +
                              HuoFenLieWeaponLevel + jianQiWeaponLevel+HuoDiPenWeaponLevel;

    public float DianAllLevel => primaryDianLevel + dianBaoZhaLevel + fireWeaponLevel + DianJiSuWeaponLevel +
                                 DianSanSheWeaponLevel + DianLuoLei5WeaponLevel;
    
    public int HeiAnAllLevel => primaryHeiAnLevel + HeiAnBaoZhaWeaponLevel + xuKongWeaponLevel + HeiAnQuXianWeaponLevel +
                              HeiAnHuiXuanWeaponLevel + heiDongWeaponLevel;
    
    public float primaryWeaponExp;
    public float primaryDianExp;
    public float primaryHuoExp;
    public float primaryHeiAnExp;
    public float dianBaoZhaExp;
    public float iceBaoZhaExp;
    public float HuoBaoZhaExp;
    public float puTong3WeaponExp;
    public float xuKongWeaponExp;
    public float lvQuanWeaponExp;
    public float fireWeaponExp;
    public float heiDongWeaponExp;
    public float jianQiWeaponExp;
    public float Huo7WeaponExp;
    public float IcePenWeaponExp;
    public float Ice7WeaponExp;
    public float Ice4BaoZhaWeaponExp;
    public float HuoFenLieWeaponExp;
    public float HuoDiPenWeaponExp;
    public float HeiAnQuXianWeaponExp;
    public float HeiAnHuiXuanWeaponExp;
    public float HeiAnBaoZhaWeaponExp;
    public float DianSanSheWeaponExp;
    public float DianLuoLei5WeaponExp;
    public float DianJiSuWeaponExp;

    

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
    public MJLevel mJShowLevel = MJLevel.White;
    public int chongwuShowLevel = 1;
    public int yuyiShowLevel = 1;

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
    
    
    public ShiZhuangType shiZhuangType = ShiZhuangType.None;

    public float GetChiBangAttack()
    {
        if (playerChiBangType == ChiBangType.None)
        {
            return 0;
        }
        ChiBangInfo chiBangInfo=ChiBangList[playerChiBangType];
        ChiBangAttribute chiBangAttribute =ChiBangConfig.ChiBangBaseAttributeDic[ChiBangConfig.GetChiBangQuality(chiBangInfo.ChiBangType)];
        float scale=ChiBangConfig.ChiBangLevelAttributeDic[chiBangInfo.Level];
        float attack = chiBangAttribute.attack * scale*ChiBangConfig.ChiBangXjAttributeDic[chiBangInfo.Xj];
        return attack;
    }
    
    public float GetChiBangDefense()
    {
        if (playerChiBangType == ChiBangType.None)
        {
            return 0;
        }
        ChiBangInfo chiBangInfo=ChiBangList[playerChiBangType];
        ChiBangAttribute chiBangAttribute =ChiBangConfig.ChiBangBaseAttributeDic[ChiBangConfig.GetChiBangQuality(chiBangInfo.ChiBangType)];
        float scale=ChiBangConfig.ChiBangLevelAttributeDic[chiBangInfo.Level];
        float attack = chiBangAttribute.defense * scale*ChiBangConfig.ChiBangXjAttributeDic[chiBangInfo.Xj];
        return attack;
    }
    
    public float GetChiBangCrit()
    {
        if (playerChiBangType == ChiBangType.None)
        {
            return 0;
        }
        ChiBangInfo chiBangInfo=ChiBangList[playerChiBangType];
        ChiBangAttribute chiBangAttribute =ChiBangConfig.ChiBangBaseAttributeDic[ChiBangConfig.GetChiBangQuality(chiBangInfo.ChiBangType)];
        float scale=ChiBangConfig.ChiBangLevelAttributeDic[chiBangInfo.Level];
        float attack = chiBangAttribute.Crit * scale*ChiBangConfig.ChiBangXjAttributeDic[chiBangInfo.Xj];
        return attack;
    }
    
    public float GetChiBangHp()
    {
        if (playerChiBangType == ChiBangType.None)
        {
            return 0;
        }
        ChiBangInfo chiBangInfo=ChiBangList[playerChiBangType];
        ChiBangAttribute chiBangAttribute =ChiBangConfig.ChiBangBaseAttributeDic[ChiBangConfig.GetChiBangQuality(chiBangInfo.ChiBangType)];
        float scale=ChiBangConfig.ChiBangLevelAttributeDic[chiBangInfo.Level];
        float attack = chiBangAttribute.maxHp * scale*ChiBangConfig.ChiBangXjAttributeDic[chiBangInfo.Xj];
        return attack;
    }
    
    public int GetAllChiBangLevel()
    {
        int value = 0;
        foreach (var item in ChiBangList)
        {
            switch (ChiBangConfig.GetChiBangQuality(item.Key))
            {
                case 2:
                    switch (item.Value.Xj)
                    {
                        case 1:
                            value += 10;
                            break;
                        case 2:
                            value += 20;
                            break;
                        case 3:
                            value += 40;
                            break;
                        case 4:
                            value += 80;
                            break;
                        case 5:
                            value += 150;
                            break;
                    }
                    break;
                
                case 3:
                    switch (item.Value.Xj)
                    {
                        case 1:
                            value += 20;
                            break;
                        case 2:
                            value += 40;
                            break;
                        case 3:
                            value += 80;
                            break;
                        case 4:
                            value += 160;
                            break;
                        case 5:
                            value += 300;
                            break;
                    }
                    break;
                
                case 4:
                    switch (item.Value.Xj)
                    {
                        case 1:
                            value += 40;
                            break;
                        case 2:
                            value += 80;
                            break;
                        case 3:
                            value += 160;
                            break;
                        case 4:
                            value += 320;
                            break;
                        case 5:
                            value += 600;
                            break;
                    }
                    break;
                
                case 5:
                    switch (item.Value.Xj)
                    {
                       
                        case 1:
                            value += 80;
                            break;
                        case 2:
                            value += 160;
                            break;
                        case 3:
                            value += 320;
                            break;
                        case 4:
                            value += 640;
                            break;
                        case 5:
                            value += 1200;
                            break;
                    }
                    break;
                
                case 6:
                    switch (item.Value.Xj)
                    {
                        case 1:
                            value += 160;
                            break;
                        case 2:
                            value += 320;
                            break;
                        case 3:
                            value += 640;
                            break;
                        case 4:
                            value += 1280;
                            break;
                        case 5:
                            value += 2400;
                            break;
                    }
                    break;
            }
        }
        return value/100;
    }
    
    
    
    public int GetAllChiBangLevelEx()
    {
        int value = 0;
        foreach (var item in ChiBangList)
        {
            switch (ChiBangConfig.GetChiBangQuality(item.Key))
            {
                case 2:
                    switch (item.Value.Xj)
                    {
                        case 1:
                            value += 10;
                            break;
                        case 2:
                            value += 20;
                            break;
                        case 3:
                            value += 40;
                            break;
                        case 4:
                            value += 80;
                            break;
                        case 5:
                            value += 150;
                            break;
                    }
                    break;
                
                case 3:
                    switch (item.Value.Xj)
                    {
                        case 1:
                            value += 20;
                            break;
                        case 2:
                            value += 40;
                            break;
                        case 3:
                            value += 80;
                            break;
                        case 4:
                            value += 160;
                            break;
                        case 5:
                            value += 300;
                            break;
                    }
                    break;
                
                case 4:
                    switch (item.Value.Xj)
                    {
                        case 1:
                            value += 40;
                            break;
                        case 2:
                            value += 80;
                            break;
                        case 3:
                            value += 160;
                            break;
                        case 4:
                            value += 320;
                            break;
                        case 5:
                            value += 600;
                            break;
                    }
                    break;
                
                case 5:
                    switch (item.Value.Xj)
                    {
                       
                        case 1:
                            value += 80;
                            break;
                        case 2:
                            value += 160;
                            break;
                        case 3:
                            value += 320;
                            break;
                        case 4:
                            value += 640;
                            break;
                        case 5:
                            value += 1200;
                            break;
                    }
                    break;
                
                case 6:
                    switch (item.Value.Xj)
                    {
                        case 1:
                            value += 160;
                            break;
                        case 2:
                            value += 320;
                            break;
                        case 3:
                            value += 640;
                            break;
                        case 4:
                            value += 1280;
                            break;
                        case 5:
                            value += 2400;
                            break;
                    }
                    break;
            }
        }
        return value%100;
    }
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void SaveWearEquip(PlayerEquipConfig.EquipType equipType, int equipid)
    {
        switch (equipType)
        {
            case PlayerEquipConfig.EquipType.Cloak:
                cloakid = equipid;
                break;
            case PlayerEquipConfig.EquipType.Cloth:
                clothid = equipid;
                break;
            case PlayerEquipConfig.EquipType.Helmet:
                helmetid = equipid;
                break;
            case PlayerEquipConfig.EquipType.Necklace:
                necklaceid = equipid;
                break;
            case PlayerEquipConfig.EquipType.Ring:
                ringid = equipid;
                break;
            case PlayerEquipConfig.EquipType.Shoe:
                shoeid = equipid;
                break;
        }
    }
}
