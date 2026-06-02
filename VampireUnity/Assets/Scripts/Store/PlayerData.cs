using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Config;
using UnityEngine;
using UnityEngine.Serialization;


public class PlayerData : XSingleton<PlayerData>
{
    public Dictionary<int, bool> ShouCangShiLastEquipDic = Enumerable.Range(1, 78).ToDictionary(k => k, v => false);
    public Dictionary<int, bool> ShouCangShiEquipDic = Enumerable.Range(1, 78).ToDictionary(k => k, v => false);

    public Dictionary<ChongWuType, bool> ShouCangShiLastChongWu = new Dictionary<ChongWuType, bool>()
{
    { ChongWuType.None, false },
    { ChongWuType.icewhite1, false },
    { ChongWuType.huowhite1, false },
    { ChongWuType.dianwhite1, false },
    { ChongWuType.heianwhite1, false },
    { ChongWuType.heianwhite2, false },
    { ChongWuType.icegreen1, false },
    { ChongWuType.icegreen2, false },
    { ChongWuType.icegreen3, false },
    { ChongWuType.huogreen1, false },
    { ChongWuType.huogreen2, false },
    { ChongWuType.diangreen1, false },
    { ChongWuType.diangreen2, false },
    { ChongWuType.heiangreen1, false },
    { ChongWuType.heiangreen2, false },
    { ChongWuType.heiangreen3, false },
    { ChongWuType.iceblue1, false },
    { ChongWuType.iceblue2, false },
    { ChongWuType.huoblue1, false },
    { ChongWuType.huoblue2, false },
    { ChongWuType.huoblue3, false },
    { ChongWuType.dianblue1, false },
    { ChongWuType.dianblue2, false },
    { ChongWuType.heianblue1, false },
    { ChongWuType.heianblue2, false },
    { ChongWuType.heianblue3, false },
    { ChongWuType.icepurple1_q, false },
    { ChongWuType.icepurple1_h, false },
    { ChongWuType.icepurple2_q, false },
    { ChongWuType.icepurple2_h, false },
    { ChongWuType.icepurple3_q, false },
    { ChongWuType.icepurple3_h, false },
    { ChongWuType.huopurple1_q, false },
    { ChongWuType.huopurple1_h, false },
    { ChongWuType.huopurple2_q, false },
    { ChongWuType.huopurple2_h, false },
    { ChongWuType.huopurple3_q, false },
    { ChongWuType.huopurple3_h, false },
    { ChongWuType.dianpurple1_q, false },
    { ChongWuType.dianpurple1_h, false },
    { ChongWuType.dianpurple2_q, false },
    { ChongWuType.dianpurple2_h, false },
    { ChongWuType.dianpurple3_q, false },
    { ChongWuType.dianpurple3_h, false },
    { ChongWuType.heianpurple1_q, false },
    { ChongWuType.heianpurple1_h, false },
    { ChongWuType.heianpurple2_q, false },
    { ChongWuType.heianpurple2_h, false },
    { ChongWuType.heianpurple3_q, false },
    { ChongWuType.heianpurple3_h, false },
    { ChongWuType.iceorange1_q, false },
    { ChongWuType.iceorange1_h, false },
    { ChongWuType.huoorange1_q, false },
    { ChongWuType.huoorange1_h, false },
    { ChongWuType.dianorange1_q, false },
    { ChongWuType.dianorange1_h, false },
    { ChongWuType.heianorange1_q, false },
    { ChongWuType.heianorange1_h, false },
};
    
     public Dictionary<ChongWuType, bool> ShouCangShiChongWu = new Dictionary<ChongWuType, bool>()
{
    { ChongWuType.None, false },
    { ChongWuType.icewhite1, false },
    { ChongWuType.huowhite1, false },
    { ChongWuType.dianwhite1, false },
    { ChongWuType.heianwhite1, false },
    { ChongWuType.heianwhite2, false },
    { ChongWuType.icegreen1, false },
    { ChongWuType.icegreen2, false },
    { ChongWuType.icegreen3, false },
    { ChongWuType.huogreen1, false },
    { ChongWuType.huogreen2, false },
    { ChongWuType.diangreen1, false },
    { ChongWuType.diangreen2, false },
    { ChongWuType.heiangreen1, false },
    { ChongWuType.heiangreen2, false },
    { ChongWuType.heiangreen3, false },
    { ChongWuType.iceblue1, false },
    { ChongWuType.iceblue2, false },
    { ChongWuType.huoblue1, false },
    { ChongWuType.huoblue2, false },
    { ChongWuType.huoblue3, false },
    { ChongWuType.dianblue1, false },
    { ChongWuType.dianblue2, false },
    { ChongWuType.heianblue1, false },
    { ChongWuType.heianblue2, false },
    { ChongWuType.heianblue3, false },
    { ChongWuType.icepurple1_q, false },
    { ChongWuType.icepurple1_h, false },
    { ChongWuType.icepurple2_q, false },
    { ChongWuType.icepurple2_h, false },
    { ChongWuType.icepurple3_q, false },
    { ChongWuType.icepurple3_h, false },
    { ChongWuType.huopurple1_q, false },
    { ChongWuType.huopurple1_h, false },
    { ChongWuType.huopurple2_q, false },
    { ChongWuType.huopurple2_h, false },
    { ChongWuType.huopurple3_q, false },
    { ChongWuType.huopurple3_h, false },
    { ChongWuType.dianpurple1_q, false },
    { ChongWuType.dianpurple1_h, false },
    { ChongWuType.dianpurple2_q, false },
    { ChongWuType.dianpurple2_h, false },
    { ChongWuType.dianpurple3_q, false },
    { ChongWuType.dianpurple3_h, false },
    { ChongWuType.heianpurple1_q, false },
    { ChongWuType.heianpurple1_h, false },
    { ChongWuType.heianpurple2_q, false },
    { ChongWuType.heianpurple2_h, false },
    { ChongWuType.heianpurple3_q, false },
    { ChongWuType.heianpurple3_h, false },
    { ChongWuType.iceorange1_q, false },
    { ChongWuType.iceorange1_h, false },
    { ChongWuType.huoorange1_q, false },
    { ChongWuType.huoorange1_h, false },
    { ChongWuType.dianorange1_q, false },
    { ChongWuType.dianorange1_h, false },
    { ChongWuType.heianorange1_q, false },
    { ChongWuType.heianorange1_h, false },
};
     
     
     public Dictionary<ChiBangType, bool> ShouCangShiLastChiBangDic = new Dictionary<ChiBangType, bool>()
{
    { ChiBangType.None, false },
    { ChiBangType.Blue1, false },
    { ChiBangType.Blue2, false },
    { ChiBangType.Blue3, false },
    { ChiBangType.Blue4, false },
    { ChiBangType.Blue5, false },
    { ChiBangType.Blue6, false },
    { ChiBangType.Blue7, false },
    { ChiBangType.Blue8, false },
    { ChiBangType.Green1, false },
    { ChiBangType.Green2, false },
    { ChiBangType.Green3, false },
    { ChiBangType.Green4, false },
    { ChiBangType.Green5, false },
    { ChiBangType.Green6, false },
    { ChiBangType.Purple1, false },
    { ChiBangType.Purple2, false },
    { ChiBangType.Purple3, false },
    { ChiBangType.Purple4, false },
    { ChiBangType.Purple5, false },
    { ChiBangType.Purple6, false },
    { ChiBangType.Purple7, false },
    { ChiBangType.Orange1, false },
    { ChiBangType.Orange2, false },
    { ChiBangType.Orange3, false },
    { ChiBangType.Red1, false },
};

public Dictionary<ChiBangType, bool> ShouCangShiChiBangDic = new Dictionary<ChiBangType, bool>()
{
    { ChiBangType.None, false },
    { ChiBangType.Blue1, false },
    { ChiBangType.Blue2, false },
    { ChiBangType.Blue3, false },
    { ChiBangType.Blue4, false },
    { ChiBangType.Blue5, false },
    { ChiBangType.Blue6, false },
    { ChiBangType.Blue7, false },
    { ChiBangType.Blue8, false },
    { ChiBangType.Green1, false },
    { ChiBangType.Green2, false },
    { ChiBangType.Green3, false },
    { ChiBangType.Green4, false },
    { ChiBangType.Green5, false },
    { ChiBangType.Green6, false },
    { ChiBangType.Purple1, false },
    { ChiBangType.Purple2, false },
    { ChiBangType.Purple3, false },
    { ChiBangType.Purple4, false },
    { ChiBangType.Purple5, false },
    { ChiBangType.Purple6, false },
    { ChiBangType.Purple7, false },
    { ChiBangType.Orange1, false },
    { ChiBangType.Orange2, false },
    { ChiBangType.Orange3, false },
    { ChiBangType.Red1, false },
};
        

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
    
    
    //称号属性
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

    public bool LingHun1 = false;
    public bool LingHun2 = false;
    public bool LingHun3 = false;
    public bool LingHun4 = false;
    public bool LingHun5 = false;
    public bool LingHun6 = false;

    public bool GuanKa1 = false;
    public bool GuanKa2 = false;
    public bool GuanKa3 = false;
    public bool GuanKa4 = false;
    public bool GuanKa5 = false;
    public bool GuanKa6 = false;

    public bool HeiAn1 => HeiAnAllLevel > 10;
    public bool HeiAn2 => HeiAnAllLevel > 20;
    public bool HeiAn3 => HeiAnAllLevel > 40;
    public bool HeiAn4 => HeiAnAllLevel > 80;
    public bool HeiAn5 => HeiAnAllLevel > 150;
    public bool HeiAn6 => HeiAnAllLevel > 300;
    
    public bool Huo1 => HuoAllLevel > 10;
    public bool Huo2 => HuoAllLevel > 20;
    public bool Huo3 => HuoAllLevel > 40;
    public bool Huo4 => HuoAllLevel > 80;
    public bool Huo5 => HuoAllLevel > 150;
    public bool Huo6 => HuoAllLevel > 300;
    
    public bool Ice1 => IceAllLevel > 10;
    public bool Ice2 => IceAllLevel > 20;
    public bool Ice3 => IceAllLevel > 40;
    public bool Ice4 => IceAllLevel > 80;
    public bool Ice5 => IceAllLevel > 150;
    public bool Ice6 => IceAllLevel > 300;
    
    public bool Dian1 => DianAllLevel > 10;
    public bool Dian2 => DianAllLevel > 20;
    public bool Dian3 => DianAllLevel > 40;
    public bool Dian4 => DianAllLevel > 80;
    public bool Dian5 => DianAllLevel > 150;
    public bool Dian6 => DianAllLevel > 300;
    
    public bool DiaoLuo = false;


    public int MonsterCount = 0;
    public int AllLingHun = 0;
    public int OrangeCount = 0;
    
    public TitleType CurrentInstallTitle = TitleType.None;



    public WeaponType playerWeaponType=WeaponType.Primary;
    public MJLevel mJShowLevel = MJLevel.White;
    public int chongwuShowLevel = 1;
    public int yuyiShowLevel = 1;
    public int weaponShowLevel = 1;


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
