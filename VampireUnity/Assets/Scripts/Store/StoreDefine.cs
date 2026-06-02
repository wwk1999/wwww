using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Config;
using UnityEngine;

public class StoreDefine : XSingleton<StoreDefine>
{
    [System.Serializable]
    public class StoreData
    {
        public EquipData Equip = new EquipData();
        public PlayData Player = new PlayData();
        public SkillData1 Skill = new SkillData1();
        public SkillJiaDian1 SkillJiaDian1 = new SkillJiaDian1();
    }

    [System.Serializable]
    public class EquipData
    {
        public Dictionary<int, EquipTable> equipIds = new Dictionary<int, EquipTable>();
        public Dictionary<int, PropTable> propTables = new Dictionary<int, PropTable>();
        public int nextEquipId;

        public void CopyFromRuntime(EquipIDData runtime)
        {
            if (runtime == null) return;

            nextEquipId = runtime.nextEquipId;
            equipIds.Clear();
            foreach (var pair in runtime.equipIds)
            {
                equipIds.Add(pair.Key, pair.Value);
            }

            propTables.Clear();
            foreach (var pair in runtime.propTables)
            {
                propTables.Add(pair.Key, pair.Value);
            }
        }

        public void ApplyToRuntime(EquipIDData runtime)
        {
            if (runtime == null) return;

            runtime.nextEquipId = nextEquipId;
            runtime.equipIds.Clear();
            foreach (var pair in equipIds)
            {
                runtime.equipIds.Add(pair.Key, pair.Value);
            }

            runtime.propTables.Clear();
            foreach (var pair in propTables)
            {
                runtime.propTables.Add(pair.Key, pair.Value);
            }
        }
    }

    [System.Serializable]
    public class PlayData
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
        
        
        public ChiBangType playerChiBangType;
        public Dictionary<ChiBangType,ChiBangInfo> ChiBangList = new Dictionary<ChiBangType,ChiBangInfo>();
        public int level;
        public float exp;
        public float bloodEnergy;
        public int gameLevel;

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
        public int dianBaoZha;
        public int iceBaoZha;

        public int duWeaponLevel;
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

        public float primaryWeaponExp;
        public float primaryDianExp;
        public float primaryHuoExp;
        public float primaryHeiAnExp;
        public float dianBaoZhaExp;
        public float iceBaoZhaExp;
        public float duWeaponExp;
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


        public WeaponType playerWeaponType = WeaponType.Primary;
        public MJLevel mJLevel = MJLevel.White;
        public LanguageType langType = LanguageType.Chinese;
        public Dictionary<int, ChongWuTable> ChongWuDic = new Dictionary<int, ChongWuTable>();





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

        public bool HeiAn1 = false;
        public bool HeiAn2 = false;
        public bool HeiAn3 = false;
        public bool HeiAn4 = false;
        public bool HeiAn5 = false;
        public bool HeiAn6 = false;
    
        public bool Huo1 = false;
        public bool Huo2 = false;
        public bool Huo3 = false;
        public bool Huo4 = false;
        public bool Huo5 = false;
        public bool Huo6 = false;
    
        public bool Ice1 = false;
        public bool Ice2 = false;
        public bool Ice3 = false;
        public bool Ice4 = false;
        public bool Ice5 = false;
        public bool Ice6 = false;
    
        public bool Dian1 = false;
        public bool Dian2 = false;
        public bool Dian3 = false;
        public bool Dian4 = false;
        public bool Dian5 = false;
        public bool Dian6 = false;
    
        public bool DiaoLuo = false;


        public int MonsterCount = 0;
        public int LinHun = 0;

        public TitleType CurrentInstallTitle = TitleType.None;
        public int ChongWuId = 1;
        public int ZhuChongWuId = 0;
        public int FuChongWuId1 = 0;
        public int FuChongWuId2 = 0;
        public int FuChongWuId3 = 0;
        public int ChongWuJingHua = 0;

        public int ChongWuShiWu1 = 0;
        public int ChongWuShiWu2 = 0;
        public int ChongWuShiWu3 = 0;
        public int ChongWuShiWu4 = 0;
        public int ChongWuShiWu5 = 0;
        public int ChongWuShiWu6 = 0;

        public int RateX = 1920;
        public int RateY = 1080;
        public bool IsQuanPing = false;

        public int GameTime = 0;
        
        public ShiZhuangType shiZhuangType = ShiZhuangType.None;



        public void CopyFromRuntime(PlayerData runtime)
        {
            ShouCangShiEquipDic = runtime.ShouCangShiEquipDic;
            ShouCangShiLastEquipDic = runtime.ShouCangShiLastEquipDic;
            
            ShouCangShiChongWu = runtime.ShouCangShiChongWu;
            ShouCangShiLastChongWu = runtime.ShouCangShiLastChongWu;
            
            ShouCangShiChiBangDic = runtime.ShouCangShiChiBangDic;
            ShouCangShiLastChiBangDic= runtime.ShouCangShiLastChiBangDic;
            
            playerChiBangType = runtime.playerChiBangType;
            ChiBangList.Clear();
            foreach (var item in runtime.ChiBangList)
            {
                ChiBangList.Add(item.Key, item.Value);
            }
            shiZhuangType = runtime.shiZhuangType;
            level = runtime.level;
            exp = runtime.exp;
            bloodEnergy = runtime.bloodEnergy;
            gameLevel = runtime.maxGameLevel;

            clothid = runtime.clothid;
            cloakid = runtime.cloakid;
            helmetid = runtime.helmetid;
            ringid = runtime.ringid;
            shoeid = runtime.shoeid;
            necklaceid = runtime.necklaceid;

        primaryWeaponLevel=runtime.primaryWeaponLevel;
        primaryDianLevel=runtime.primaryDianLevel;
        primaryHuoLevel=runtime.primaryHuoLevel;
        primaryHeiAnLevel=runtime.primaryHeiAnLevel;
        dianBaoZha=runtime.dianBaoZhaLevel;
        iceBaoZha=runtime.iceBaoZhaLevel;

        duWeaponLevel=runtime.HuoBaoZhaWeaponLevel;
        puTong3WeaponLevel=runtime.puTong3WeaponLevel;
        xuKongWeaponLevel=runtime.xuKongWeaponLevel;
        lvQuanWeaponLevel=runtime.lvQuanWeaponLevel;
        fireWeaponLevel=runtime.fireWeaponLevel;
        heiDongWeaponLevel=runtime.heiDongWeaponLevel;
        jianQiWeaponLevel=runtime.jianQiWeaponLevel;
    
        Huo7WeaponLevel=runtime.Huo7WeaponLevel;
        IcePenWeaponLevel=runtime.IcePenWeaponLevel;
        Ice7WeaponLevel=runtime.Ice7WeaponLevel;
        Ice4BaoZhaWeaponLevel=runtime.Ice4BaoZhaWeaponLevel;
        HuoFenLieWeaponLevel=runtime.HuoFenLieWeaponLevel;
        HuoDiPenWeaponLevel=runtime.HuoDiPenWeaponLevel;
        HeiAnQuXianWeaponLevel=runtime.HeiAnQuXianWeaponLevel;
        HeiAnHuiXuanWeaponLevel=runtime.HeiAnHuiXuanWeaponLevel;
        HeiAnBaoZhaWeaponLevel=runtime.HeiAnBaoZhaWeaponLevel;
        DianSanSheWeaponLevel=runtime.DianSanSheWeaponLevel;
        DianLuoLei5WeaponLevel=runtime.DianLuoLei5WeaponLevel;
        DianJiSuWeaponLevel=runtime.DianJiSuWeaponLevel;

        primaryWeaponExp=runtime.primaryWeaponExp;
        primaryDianExp=runtime.primaryDianExp;
        primaryHuoExp=runtime.primaryHuoExp;
        primaryHeiAnExp=runtime.primaryHeiAnExp;
        dianBaoZhaExp=runtime.dianBaoZhaExp;
        iceBaoZhaExp=runtime.iceBaoZhaExp;
        duWeaponExp=runtime.HuoBaoZhaExp;
        puTong3WeaponExp=runtime.puTong3WeaponExp;
        xuKongWeaponExp=runtime.xuKongWeaponExp;
        lvQuanWeaponExp=runtime.lvQuanWeaponExp;
        fireWeaponExp=runtime.fireWeaponExp;
        heiDongWeaponExp=runtime.heiDongWeaponExp;
        jianQiWeaponExp=runtime.jianQiWeaponExp;
        Huo7WeaponExp=runtime.Huo7WeaponExp;
        IcePenWeaponExp=runtime.IcePenWeaponExp;
        Ice7WeaponExp=runtime.Ice7WeaponExp;
        Ice4BaoZhaWeaponExp=runtime.Ice4BaoZhaWeaponExp;
        HuoFenLieWeaponExp=runtime.HuoFenLieWeaponExp;
        HuoDiPenWeaponExp=runtime.HuoDiPenWeaponExp;
        HeiAnQuXianWeaponExp=runtime.HeiAnQuXianWeaponExp;
        HeiAnHuiXuanWeaponExp=runtime.HeiAnHuiXuanWeaponExp;
        HeiAnBaoZhaWeaponExp=runtime.HeiAnBaoZhaWeaponExp;
        DianSanSheWeaponExp=runtime.DianSanSheWeaponExp;
        DianLuoLei5WeaponExp=runtime.DianLuoLei5WeaponExp;
        DianJiSuWeaponExp=runtime.DianJiSuWeaponExp;
           


            playerWeaponType = runtime.playerWeaponType;
            mJLevel = runtime.mJShowLevel;
            langType = runtime.langType;

            Level5 = runtime.Level5;
            Level15 = runtime.Level15;
            Level30 = runtime.Level30;
            Level50 = runtime.Level50;
            Level75 = runtime.Level75;
            Level100 = runtime.Level100;

            MonsterCount1 = runtime.MonsterCount1;
            MonsterCount2 = runtime.MonsterCount2;
            MonsterCount3 = runtime.MonsterCount3;
            MonsterCount4 = runtime.MonsterCount4;
            MonsterCount5 = runtime.MonsterCount5;
            MonsterCount6 = runtime.MonsterCount6;

            LingHun1 = runtime.LingHun1;
            LingHun2 = runtime.LingHun2;
            LingHun3 = runtime.LingHun3;
            LingHun4 = runtime.LingHun4;
            LingHun5 = runtime.LingHun5;
            LingHun6 = runtime.LingHun6;

            GuanKa1 = runtime.GuanKa1;
            GuanKa2 = runtime.GuanKa2;
            GuanKa3 = runtime.GuanKa3;
            GuanKa4 = runtime.GuanKa4;
            GuanKa5 = runtime.GuanKa5;
            GuanKa6 = runtime.GuanKa6;

            Dian1 = runtime.Dian1;
            Dian2 = runtime.Dian2;
            Dian3 = runtime.Dian3;
            Dian4 = runtime.Dian4;
            Dian5 = runtime.Dian5;
            Dian6 = runtime.Dian6;
            
            Huo1 = runtime.Huo1;
            Huo2 = runtime.Huo2;
            Huo3 = runtime.Huo3;
            Huo4 = runtime.Huo4;
            Huo5 = runtime.Huo5;
            Huo6 = runtime.Huo6;
            
            Ice1 = runtime.Ice1;
            Ice2 = runtime.Ice2;
            Ice3 = runtime.Ice3;
            Ice4 = runtime.Ice4;
            Ice5 = runtime.Ice5;
            Ice6 = runtime.Ice6;
            
            HeiAn1 = runtime.HeiAn1;
            HeiAn2 = runtime.HeiAn2;
            HeiAn3 = runtime.HeiAn3;
            HeiAn4 = runtime.HeiAn4;
            HeiAn5 = runtime.HeiAn5;
            HeiAn6 = runtime.HeiAn6;
            
            DiaoLuo = runtime.DiaoLuo;

            MonsterCount = runtime.MonsterCount;
            LinHun = runtime.AllLingHun;
            CurrentInstallTitle = runtime.CurrentInstallTitle;

            ChongWuDic = runtime.ChongWuDic;
            ChongWuId = runtime.FlagChongWuId;

            ZhuChongWuId = runtime.ZhuChongWuId;
            FuChongWuId1 = runtime.FuChongWuId1;
            FuChongWuId2 = runtime.FuChongWuId2;
            FuChongWuId3 = runtime.FuChongWuId3;

            ChongWuJingHua = runtime.ChongWuJingHua;

            ChongWuShiWu1 = runtime.ChongWuShiWu1;
            ChongWuShiWu2 = runtime.ChongWuShiWu2;
            ChongWuShiWu3 = runtime.ChongWuShiWu3;
            ChongWuShiWu4 = runtime.ChongWuShiWu4;
            ChongWuShiWu5 = runtime.ChongWuShiWu5;
            ChongWuShiWu6 = runtime.ChongWuShiWu6;

            RateX = runtime.RateX;
            RateY = runtime.RateY;
            IsQuanPing = runtime.IsQuanPing;

            GameTime = runtime.GameTime;
        }

        public void ApplyToRuntime(PlayerData runtime)
        {
            runtime.ShouCangShiEquipDic = ShouCangShiEquipDic;
            runtime.ShouCangShiLastEquipDic = ShouCangShiLastEquipDic;
            
            
            runtime.ShouCangShiChiBangDic = ShouCangShiChiBangDic;
            runtime.ShouCangShiLastChiBangDic = ShouCangShiLastChiBangDic;
            
            runtime.ShouCangShiChongWu = ShouCangShiChongWu;
            runtime.ShouCangShiLastChongWu = ShouCangShiLastChongWu;
            
            
            runtime.playerChiBangType = playerChiBangType;

            runtime.ChiBangList.Clear();
            foreach (var item in ChiBangList)
            {
                runtime.ChiBangList.Add(item.Key, item.Value);
            }
            runtime.shiZhuangType = shiZhuangType;
            runtime.level = level;
            runtime.exp = exp;
            runtime.bloodEnergy = bloodEnergy;
            runtime.maxGameLevel = gameLevel;

            runtime.clothid = clothid;
            runtime.cloakid = cloakid;
            runtime.helmetid = helmetid;
            runtime.ringid = ringid;
            runtime.shoeid = shoeid;
            runtime.necklaceid = necklaceid;

            runtime.primaryWeaponLevel=primaryWeaponLevel;
            runtime.primaryDianLevel=primaryDianLevel;
            runtime.primaryHuoLevel=primaryHuoLevel;
            runtime.primaryHeiAnLevel=primaryHeiAnLevel;
            runtime.dianBaoZhaLevel=dianBaoZha;
            runtime.iceBaoZhaLevel=iceBaoZha;

            runtime.HuoBaoZhaWeaponLevel=duWeaponLevel;
            runtime.puTong3WeaponLevel=puTong3WeaponLevel;
            runtime.xuKongWeaponLevel=xuKongWeaponLevel;
            runtime.lvQuanWeaponLevel=lvQuanWeaponLevel;
            runtime.fireWeaponLevel=fireWeaponLevel;
            runtime.heiDongWeaponLevel=heiDongWeaponLevel;
            runtime.jianQiWeaponLevel=jianQiWeaponLevel;
    
            runtime.Huo7WeaponLevel=Huo7WeaponLevel;
            runtime.IcePenWeaponLevel=IcePenWeaponLevel;
            runtime.Ice7WeaponLevel=Ice7WeaponLevel;
            runtime.Ice4BaoZhaWeaponLevel=Ice4BaoZhaWeaponLevel;
            runtime.HuoFenLieWeaponLevel=HuoFenLieWeaponLevel;
            runtime.HuoDiPenWeaponLevel=HuoDiPenWeaponLevel;
            runtime.HeiAnQuXianWeaponLevel=HeiAnQuXianWeaponLevel;
            runtime.HeiAnHuiXuanWeaponLevel=HeiAnHuiXuanWeaponLevel;
            runtime.HeiAnBaoZhaWeaponLevel=HeiAnBaoZhaWeaponLevel;
            runtime.DianSanSheWeaponLevel=DianSanSheWeaponLevel;
            runtime.DianLuoLei5WeaponLevel=DianLuoLei5WeaponLevel;
            runtime.DianJiSuWeaponLevel=DianJiSuWeaponLevel;

            runtime.primaryWeaponExp=primaryWeaponExp;
            runtime.primaryDianExp=primaryDianExp;
            runtime.primaryHuoExp=primaryHuoExp;
            runtime.primaryHeiAnExp=primaryHeiAnExp;
            runtime.dianBaoZhaExp=dianBaoZhaExp;
            runtime.iceBaoZhaExp=iceBaoZhaExp;
            runtime.HuoBaoZhaExp=duWeaponExp;
            runtime.puTong3WeaponExp=puTong3WeaponExp;
            runtime.xuKongWeaponExp=xuKongWeaponExp;
            runtime.lvQuanWeaponExp=lvQuanWeaponExp;
            runtime.fireWeaponExp=fireWeaponExp;
            runtime.heiDongWeaponExp=heiDongWeaponExp;
            runtime.jianQiWeaponExp=jianQiWeaponExp;
            runtime.Huo7WeaponExp=Huo7WeaponExp;
            runtime.IcePenWeaponExp=IcePenWeaponExp;
            runtime.Ice7WeaponExp=Ice7WeaponExp;
            runtime.Ice4BaoZhaWeaponExp=Ice4BaoZhaWeaponExp;
            runtime.HuoFenLieWeaponExp=HuoFenLieWeaponExp;
            runtime.HuoDiPenWeaponExp=HuoDiPenWeaponExp;
            runtime.HeiAnQuXianWeaponExp=HeiAnQuXianWeaponExp;
            runtime.HeiAnHuiXuanWeaponExp=HeiAnHuiXuanWeaponExp;
            runtime.HeiAnBaoZhaWeaponExp=HeiAnBaoZhaWeaponExp;
            runtime.DianSanSheWeaponExp=DianSanSheWeaponExp;
            runtime.DianLuoLei5WeaponExp=DianLuoLei5WeaponExp;
            runtime.DianJiSuWeaponExp=DianJiSuWeaponExp;

            runtime.zhuanjinCount = zhuanjinCount;


            runtime.playerWeaponType = playerWeaponType;
            runtime.mJShowLevel = mJLevel;
            runtime.langType = langType;



            runtime.Level5 = Level5;
            runtime.Level15 = Level15;
            runtime.Level30 = Level30;
            runtime.Level50 = Level50;
            runtime.Level75 = Level75;
            runtime.Level100 = Level100;

            runtime.MonsterCount1 = MonsterCount1;
            runtime.MonsterCount2 = MonsterCount2;
            runtime.MonsterCount3 = MonsterCount3;
            runtime.MonsterCount4 = MonsterCount4;
            runtime.MonsterCount5 = MonsterCount5;
            runtime.MonsterCount6 = MonsterCount6;

            runtime.LingHun1 = LingHun1;
            runtime.LingHun2 = LingHun2;
            runtime.LingHun3 = LingHun3;
            runtime.LingHun4 = LingHun4;
            runtime.LingHun5 = LingHun5;
            runtime.LingHun6 = LingHun6;

            runtime.GuanKa1 = GuanKa1;
            runtime.GuanKa2 = GuanKa2;
            runtime.GuanKa3 = GuanKa3;
            runtime.GuanKa4 = GuanKa4;
            runtime.GuanKa5 = GuanKa5;
            runtime.GuanKa6 = GuanKa6;

            runtime.Dian1 = Dian1;
            runtime.Dian2 = Dian2;
            runtime.Dian3 = Dian3;
            runtime.Dian4 = Dian4;
            runtime.Dian5 = Dian5;
            runtime.Dian6 = Dian6;
            
            runtime.Huo1 = Huo1;
            runtime.Huo2 = Huo2;
            runtime.Huo3 = Huo3;
            runtime.Huo4 = Huo4;
            runtime.Huo5 = Huo5;
            runtime.Huo6 = Huo6;
            
            runtime.Ice1 = Ice1;
            runtime.Ice2 = Ice2;
            runtime.Ice3 = Ice3;
            runtime.Ice4 = Ice4;
            runtime.Ice5 = Ice5;
            runtime.Ice6 = Ice6;
            
            runtime.HeiAn1 = HeiAn1;
            runtime.HeiAn2 = HeiAn2;
            runtime.HeiAn3 = HeiAn3;
            runtime.HeiAn4 = HeiAn4;
            runtime.HeiAn5 = HeiAn5;
            runtime.HeiAn6 = HeiAn6;
            
            runtime.DiaoLuo = DiaoLuo;


            runtime.MonsterCount = MonsterCount;
            runtime.AllLingHun = LinHun;

            runtime.CurrentInstallTitle = CurrentInstallTitle;
            runtime.ChongWuDic = ChongWuDic;
            runtime.FlagChongWuId = ChongWuId;
            runtime.ZhuChongWuId = ZhuChongWuId;
            runtime.FuChongWuId1 = FuChongWuId1;
            runtime.FuChongWuId2 = FuChongWuId2;
            runtime.FuChongWuId3 = FuChongWuId3;

            runtime.ChongWuJingHua = ChongWuJingHua;

            runtime.ChongWuShiWu1 = ChongWuShiWu1;
            runtime.ChongWuShiWu2 = ChongWuShiWu2;
            runtime.ChongWuShiWu3 = ChongWuShiWu3;
            runtime.ChongWuShiWu4 = ChongWuShiWu4;
            runtime.ChongWuShiWu5 = ChongWuShiWu5;
            runtime.ChongWuShiWu6 = ChongWuShiWu6;


            runtime.RateX = RateX;
            runtime.RateY = RateY;
            runtime.IsQuanPing = IsQuanPing;

            runtime.GameTime = GameTime;
        }
    }

    [System.Serializable]
    public class SkillData1
    {
        public void CopyFromRuntime(SkillData runtime)
        {
        }

        public void ApplyToRuntime(SkillData runtime)
        {
        }
    }

    [System.Serializable]
    public class SkillJiaDian1
    {
      public int CurrentSkillCount = 0;

    public int IceBei1;
    public int IceBei2;
    public int IceBei3;
    public int IceBei4;
    
    public int Ice1=2;
    public int Ice1_1;
    public int Ice1_2;
    public int Ice2;
    public int Ice2_1;
    public int Ice2_2;
    public int Ice3;
    public int Ice3_1;
    public int Ice3_2;
    public int Ice4;
    public int Ice4_1;
    public int Ice4_2;
    public int Ice5;
    public int Ice5_1;
    public int Ice5_2;

    
    public int HuoBei1;
    public int HuoBei2;
    public int HuoBei3;
    public int HuoBei4;
    
    public int Huo1;
    public int Huo1_1;
    public int Huo1_2;
    public int Huo2;
    public int Huo2_1;
    public int Huo2_2;
    public int Huo3;
    public int Huo3_1;
    public int Huo3_2;
    public int Huo4;
    public int Huo4_1;
    public int Huo4_2;
    public int Huo5;
    public int Huo5_1;
    public int Huo5_2;
    
    
    
    public int HeiAnBei1;
    public int HeiAnBei2;
    public int HeiAnBei3;
    public int HeiAnBei4;
    
    public int HeiAn1;
    public int HeiAn1_1;
    public int HeiAn1_2;
    public int HeiAn2;
    public int HeiAn2_1;
    public int HeiAn2_2;
    public int HeiAn3;
    public int HeiAn3_1;
    public int HeiAn3_2;
    public int HeiAn4;
    public int HeiAn4_1;
    public int HeiAn4_2;
    public int HeiAn5;
    public int HeiAn5_1;
    public int HeiAn5_2;
    
    
    public int DianBei1;
    public int DianBei2;
    public int DianBei3;
    public int DianBei4;
    
    public int Dian1;
    public int Dian1_1;
    public int Dian1_2;
    public int Dian2;
    public int Dian2_1;
    public int Dian2_2;
    public int Dian3;
    public int Dian3_1;
    public int Dian3_2;
    public int Dian4;
    public int Dian4_1;
    public int Dian4_2;
    public int Dian5;
    public int Dian5_1;
    public int Dian5_2;



    public int IceZJ1;
    public int IceZJ2;
    public int IceZJ3;
    public int IceZJ4;
    public int IceZJ5;
    public int IceZJ6;
    
    public int HuoZJ1;
    public int HuoZJ2;
    public int HuoZJ3;
    public int HuoZJ4;
    public int HuoZJ5;
    public int HuoZJ6;
    
    public int DianZJ1;
    public int DianZJ2;
    public int DianZJ3;
    public int DianZJ4;
    public int DianZJ5;
    public int DianZJ6;
    
    public int HeiAnZJ1;
    public int HeiAnZJ2;
    public int HeiAnZJ3;
    public int HeiAnZJ4;
    public int HeiAnZJ5;
    public int HeiAnZJ6;

    public int ZhiYeZJ1;
    public int ZhiYeZJ2;
    public int ZhiYeZJ3;
    public int ZhiYeZJ4;
    public int ZhiYeZJ5;
    public int ZhiYeZJ6;

    public int IceAll=>GetIceAll();
    public int HuoAll=>GetHuoAll();
    public int DianAll=>GetDianAll();
    public int HeiAnAll=>GetHeiAnAll();
    public int ZJIceAll=>GetZJIceAll();
    public int ZJHuoAll=>GetZJHuoAll();
    public int ZJDianAll=>GetZJDianAll();
    public int ZJHeiAnAll=>GetZJHeiAnAll();
    public int ZJZhiYeAll=>GetZJZhiYeAll();
    
    public SkillType LMB = SkillType.Normal;
    public SkillType RMB = SkillType.Dash;
    public SkillType Alpha1 = SkillType.None;//当前装备的技能类型
    public SkillType Alpha2 = SkillType.None;
    public SkillType Alpha3 = SkillType.None;
    public SkillType Alpha4 = SkillType.None;
    public SkillType Alpha5 = SkillType.None;

    public bool Ice1Auto = false;
    public bool Ice2Auto = false;
    public bool Ice3Auto = false;
    public bool Ice4Auto = false;
    public bool Ice5Auto = false;

    
    public bool Huo1Auto = false;
    public bool Huo2Auto = false;
    public bool Huo3Auto = false;
    public bool Huo4Auto = false;
    public bool Huo5Auto = false;
    
    public bool Dian1Auto = false;
    public bool Dian2Auto = false;
    public bool Dian3Auto = false;
    public bool Dian4Auto = false;
    public bool Dian5Auto = false;
    
    public bool HeiAn1Auto = false;
    public bool HeiAn2Auto = false;
    public bool HeiAn3Auto = false;
    public bool HeiAn4Auto = false;
    public bool HeiAn5Auto = false;
    
    
    public int GetIceAll()
    {
        int value = 0;
        value += IceBei1+IceBei2+IceBei3+IceBei4+Ice1+Ice1_1+Ice1_2+Ice2+Ice2_1+Ice2_2+Ice3+Ice3_1+Ice3_2+Ice4+Ice4_1+Ice4_2+Ice5+Ice5_1+Ice5_2;
        return value;
    }
    
    public int GetHuoAll()
    {
        int value = 0;
        value += HuoBei1+HuoBei2+HuoBei3+HuoBei4+Huo1+Huo1_1+Huo1_2+Huo2+Huo2_1+Huo2_2+Huo3+Huo3_1+Huo3_2+Huo4+Huo4_1+Huo4_2+Huo5+Huo5_1+Huo5_2;
        return value;
    }
    
    public int GetDianAll()
    {
        int value = 0;
        value += DianBei1+DianBei2+DianBei3+DianBei4+Dian1+Dian1_1+Dian1_2+Dian2+Dian2_1+Dian2_2+Dian3+Dian3_1+Dian3_2+Dian4+Dian4_1+Dian4_2+Dian5+Dian5_1+Dian5_2;
        return value;
    }
    
    
    public int GetHeiAnAll()
    {
        int value = 0;
        value += HeiAnBei1+HeiAnBei2+HeiAnBei3+HeiAnBei4+HeiAn1+HeiAn1_1+HeiAn1_2+HeiAn2+HeiAn2_1+HeiAn2_2+HeiAn3+HeiAn3_1+HeiAn3_2+HeiAn4+HeiAn4_1+HeiAn4_2+HeiAn5+HeiAn5_1+HeiAn5_2;
        return value;
    }
    
    
    public int GetZJIceAll()
    {
        int value = 0;
        value+=IceZJ1+IceZJ2+IceZJ3+IceZJ4+IceZJ5+IceZJ6;
        return value;
    }
    
    public int GetZJHuoAll()
    {
        int value = 0;
        value+=HuoZJ1+HuoZJ2+HuoZJ3+HuoZJ4+HuoZJ5+HuoZJ6;
        return value;
    }
    
    public int GetZJDianAll()
    {
        int value = 0;
        value+=DianZJ1+DianZJ2+DianZJ3+DianZJ4+DianZJ5+DianZJ6;
        return value;
    }
    
    public int GetZJHeiAnAll()
    {
        int value = 0;
        value+=HeiAnZJ1+HeiAnZJ2+HeiAnZJ3+HeiAnZJ4+HeiAnZJ5+HeiAnZJ6;
        return value;
    }
    
    public int GetZJZhiYeAll()
    {
        int value = 0;
        value+=ZhiYeZJ1+ZhiYeZJ2+ZhiYeZJ3+ZhiYeZJ4+ZhiYeZJ5+ZhiYeZJ6;
        return value;
    }
    


        public void CopyFromRuntime(SkillJiaDian runtime)
        {
            CurrentSkillCount = runtime.CurrentSkillCount;
    
    IceBei1 = runtime.IceBei1;
    IceBei2 = runtime.IceBei2;
    IceBei3 = runtime.IceBei3;
    IceBei4 = runtime.IceBei4;
    
    Ice1 = runtime.Ice1;
    Ice1_1 = runtime.Ice1_1;
    Ice1_2 = runtime.Ice1_2;
    Ice2 = runtime.Ice2;
    Ice2_1 = runtime.Ice2_1;
    Ice2_2 = runtime.Ice2_2;
    Ice3 = runtime.Ice3;
    Ice3_1 = runtime.Ice3_1;
    Ice3_2 = runtime.Ice3_2;
    Ice4 = runtime.Ice4;
    Ice4_1 = runtime.Ice4_1;
    Ice4_2 = runtime.Ice4_2;
    Ice5 = runtime.Ice5;
    Ice5_1 = runtime.Ice5_1;
    Ice5_2 = runtime.Ice5_2;
    
    HuoBei1 = runtime.HuoBei1;
    HuoBei2 = runtime.HuoBei2;
    HuoBei3 = runtime.HuoBei3;
    HuoBei4 = runtime.HuoBei4;
    
    Huo1 = runtime.Huo1;
    Huo1_1 = runtime.Huo1_1;
    Huo1_2 = runtime.Huo1_2;
    Huo2 = runtime.Huo2;
    Huo2_1 = runtime.Huo2_1;
    Huo2_2 = runtime.Huo2_2;
    Huo3 = runtime.Huo3;
    Huo3_1 = runtime.Huo3_1;
    Huo3_2 = runtime.Huo3_2;
    Huo4 = runtime.Huo4;
    Huo4_1 = runtime.Huo4_1;
    Huo4_2 = runtime.Huo4_2;
    Huo5 = runtime.Huo5;
    Huo5_1 = runtime.Huo5_1;
    Huo5_2 = runtime.Huo5_2;
    
    HeiAnBei1 = runtime.HeiAnBei1;
    HeiAnBei2 = runtime.HeiAnBei2;
    HeiAnBei3 = runtime.HeiAnBei3;
    HeiAnBei4 = runtime.HeiAnBei4;
    
    HeiAn1 = runtime.HeiAn1;
    HeiAn1_1 = runtime.HeiAn1_1;
    HeiAn1_2 = runtime.HeiAn1_2;
    HeiAn2 = runtime.HeiAn2;
    HeiAn2_1 = runtime.HeiAn2_1;
    HeiAn2_2 = runtime.HeiAn2_2;
    HeiAn3 = runtime.HeiAn3;
    HeiAn3_1 = runtime.HeiAn3_1;
    HeiAn3_2 = runtime.HeiAn3_2;
    HeiAn4 = runtime.HeiAn4;
    HeiAn4_1 = runtime.HeiAn4_1;
    HeiAn4_2 = runtime.HeiAn4_2;
    HeiAn5 = runtime.HeiAn5;
    HeiAn5_1 = runtime.HeiAn5_1;
    HeiAn5_2 = runtime.HeiAn5_2;
    
    DianBei1 = runtime.DianBei1;
    DianBei2 = runtime.DianBei2;
    DianBei3 = runtime.DianBei3;
    DianBei4 = runtime.DianBei4;
    
    Dian1 = runtime.Dian1;
    Dian1_1 = runtime.Dian1_1;
    Dian1_2 = runtime.Dian1_2;
    Dian2 = runtime.Dian2;
    Dian2_1 = runtime.Dian2_1;
    Dian2_2 = runtime.Dian2_2;
    Dian3 = runtime.Dian3;
    Dian3_1 = runtime.Dian3_1;
    Dian3_2 = runtime.Dian3_2;
    Dian4 = runtime.Dian4;
    Dian4_1 = runtime.Dian4_1;
    Dian4_2 = runtime.Dian4_2;
    Dian5 = runtime.Dian5;
    Dian5_1 = runtime.Dian5_1;
    Dian5_2 = runtime.Dian5_2;
    
    // 注意：只读属性（IceAll等）不能直接赋值，它们是从其他字段计算得来的
    // 所以不需要复制它们
    
    LMB = runtime.LMB;
    RMB = runtime.RMB;
    Alpha1 = runtime.Alpha1;
    Alpha2 = runtime.Alpha2;
    Alpha3 = runtime.Alpha3;
    Alpha4 = runtime.Alpha4;
    Alpha5 = runtime.Alpha5;
    
    Ice1Auto = runtime.Ice1Auto;
    Ice2Auto = runtime.Ice2Auto;
    Ice3Auto = runtime.Ice3Auto;
    Ice4Auto = runtime.Ice4Auto;
    Ice5Auto = runtime.Ice5Auto;
    
    Huo1Auto = runtime.Huo1Auto;
    Huo2Auto = runtime.Huo2Auto;
    Huo3Auto = runtime.Huo3Auto;
    Huo4Auto = runtime.Huo4Auto;
    Huo5Auto = runtime.Huo5Auto;
    
    Dian1Auto = runtime.Dian1Auto;
    Dian2Auto = runtime.Dian2Auto;
    Dian3Auto = runtime.Dian3Auto;
    Dian4Auto = runtime.Dian4Auto;
    Dian5Auto = runtime.Dian5Auto;
    
    HeiAn1Auto = runtime.HeiAn1Auto;
    HeiAn2Auto = runtime.HeiAn2Auto;
    HeiAn3Auto = runtime.HeiAn3Auto;
    HeiAn4Auto = runtime.HeiAn4Auto;
    HeiAn5Auto = runtime.HeiAn5Auto;
        }

        public void ApplyToRuntime(SkillJiaDian runtime)
        {
           runtime.CurrentSkillCount = CurrentSkillCount;

runtime.IceBei1 = IceBei1;
runtime.IceBei2 = IceBei2;
runtime.IceBei3 = IceBei3;
runtime.IceBei4 = IceBei4;

runtime.Ice1 = Ice1;
runtime.Ice1_1 = Ice1_1;
runtime.Ice1_2 = Ice1_2;
runtime.Ice2 = Ice2;
runtime.Ice2_1 = Ice2_1;
runtime.Ice2_2 = Ice2_2;
runtime.Ice3 = Ice3;
runtime.Ice3_1 = Ice3_1;
runtime.Ice3_2 = Ice3_2;
runtime.Ice4 = Ice4;
runtime.Ice4_1 = Ice4_1;
runtime.Ice4_2 = Ice4_2;
runtime.Ice5 = Ice5;
runtime.Ice5_1 = Ice5_1;
runtime.Ice5_2 = Ice5_2;

runtime.HuoBei1 = HuoBei1;
runtime.HuoBei2 = HuoBei2;
runtime.HuoBei3 = HuoBei3;
runtime.HuoBei4 = HuoBei4;

runtime.Huo1 = Huo1;
runtime.Huo1_1 = Huo1_1;
runtime.Huo1_2 = Huo1_2;
runtime.Huo2 = Huo2;
runtime.Huo2_1 = Huo2_1;
runtime.Huo2_2 = Huo2_2;
runtime.Huo3 = Huo3;
runtime.Huo3_1 = Huo3_1;
runtime.Huo3_2 = Huo3_2;
runtime.Huo4 = Huo4;
runtime.Huo4_1 = Huo4_1;
runtime.Huo4_2 = Huo4_2;
runtime.Huo5 = Huo5;
runtime.Huo5_1 = Huo5_1;
runtime.Huo5_2 = Huo5_2;

runtime.HeiAnBei1 = HeiAnBei1;
runtime.HeiAnBei2 = HeiAnBei2;
runtime.HeiAnBei3 = HeiAnBei3;
runtime.HeiAnBei4 = HeiAnBei4;

runtime.HeiAn1 = HeiAn1;
runtime.HeiAn1_1 = HeiAn1_1;
runtime.HeiAn1_2 = HeiAn1_2;
runtime.HeiAn2 = HeiAn2;
runtime.HeiAn2_1 = HeiAn2_1;
runtime.HeiAn2_2 = HeiAn2_2;
runtime.HeiAn3 = HeiAn3;
runtime.HeiAn3_1 = HeiAn3_1;
runtime.HeiAn3_2 = HeiAn3_2;
runtime.HeiAn4 = HeiAn4;
runtime.HeiAn4_1 = HeiAn4_1;
runtime.HeiAn4_2 = HeiAn4_2;
runtime.HeiAn5 = HeiAn5;
runtime.HeiAn5_1 = HeiAn5_1;
runtime.HeiAn5_2 = HeiAn5_2;

runtime.DianBei1 = DianBei1;
runtime.DianBei2 = DianBei2;
runtime.DianBei3 = DianBei3;
runtime.DianBei4 = DianBei4;

runtime.Dian1 = Dian1;
runtime.Dian1_1 = Dian1_1;
runtime.Dian1_2 = Dian1_2;
runtime.Dian2 = Dian2;
runtime.Dian2_1 = Dian2_1;
runtime.Dian2_2 = Dian2_2;
runtime.Dian3 = Dian3;
runtime.Dian3_1 = Dian3_1;
runtime.Dian3_2 = Dian3_2;
runtime.Dian4 = Dian4;
runtime.Dian4_1 = Dian4_1;
runtime.Dian4_2 = Dian4_2;
runtime.Dian5 = Dian5;
runtime.Dian5_1 = Dian5_1;
runtime.Dian5_2 = Dian5_2;



// 注意：只读属性（IceAll等）不能赋值，因为它们是只读的
// runtime.IceAll = IceAll; // 这行会报错，因为IceAll只有getter

runtime.LMB = LMB;
runtime.RMB = RMB;
runtime.Alpha1 = Alpha1;
runtime.Alpha2 = Alpha2;
runtime.Alpha3 = Alpha3;
runtime.Alpha4 = Alpha4;
runtime.Alpha5 = Alpha5;

runtime.Ice1Auto = Ice1Auto;
runtime.Ice2Auto = Ice2Auto;
runtime.Ice3Auto = Ice3Auto;
runtime.Ice4Auto = Ice4Auto;
runtime.Ice5Auto = Ice5Auto;

runtime.Huo1Auto = Huo1Auto;
runtime.Huo2Auto = Huo2Auto;
runtime.Huo3Auto = Huo3Auto;
runtime.Huo4Auto = Huo4Auto;
runtime.Huo5Auto = Huo5Auto;

runtime.Dian1Auto = Dian1Auto;
runtime.Dian2Auto = Dian2Auto;
runtime.Dian3Auto = Dian3Auto;
runtime.Dian4Auto = Dian4Auto;
runtime.Dian5Auto = Dian5Auto;

runtime.HeiAn1Auto = HeiAn1Auto;
runtime.HeiAn2Auto = HeiAn2Auto;
runtime.HeiAn3Auto = HeiAn3Auto;
runtime.HeiAn4Auto = HeiAn4Auto;
runtime.HeiAn5Auto = HeiAn5Auto;
        }
    }
}
