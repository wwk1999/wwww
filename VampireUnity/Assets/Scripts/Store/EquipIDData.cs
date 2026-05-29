using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class EquipIDData : XSingleton<EquipIDData>
{
    public Dictionary<int,EquipTable> equipIds = new Dictionary<int, EquipTable>();
    public Dictionary<int,PropTable> propTables = new Dictionary<int,PropTable>();
    public int nextEquipId = 1;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    public int GenerateEquipId()
    {
        return nextEquipId++;
    }

    public void SavaEquip(EquipTable equip)
    {
        var data = new EquipTable()
        {
            equipid = GenerateEquipId(),
            Quality = equip.Quality,
            EquipLevel = equip.EquipLevel,
            Damage = equip.Damage,
            CRIT = equip.CRIT,
            HP = equip.HP,
            EquipType = equip.EquipType,
            EquipQuality = equip.EquipQuality,
            Defense = equip.Defense,
            EquipName = equip.EquipName,
            damageEntryInfos= new List<DamageEntryInfo>(equip.damageEntryInfos),
            defenseEntryInfos= new List<DefenseEntryInfo>(equip.defenseEntryInfos),
            OrangeEntry1 = equip.OrangeEntry1,
            OrangeEntry2 = equip.OrangeEntry2,
            BaoShiDic = equip.BaoShiDic,
            orangeid = equip.orangeid,
        };
        equipIds.Add(data.equipid,data);
    }
    /// <summary>
    ///保存道具，1开头是武器碎片，2开头是精粹，3开头是神话材料
    /// </summary>
    /// <param name="prop"></param>

    public void SaveProp(PropTable prop)
    {
        if (prop.PropType == PropConfig.PropType.ChiBangFight)//翅膀道具
        {
            if(PlayerData.S.ChiBangList.ContainsKey(prop.ChiBangType))
            {
                PlayerData.S.ChiBangList[prop.ChiBangType].XjEx++;
                if (PlayerData.S.ChiBangList[prop.ChiBangType].XjEx >=
                    ChiBangConfig.ChiBangXjDic[PlayerData.S.ChiBangList[prop.ChiBangType].Xj])
                {
                    PlayerData.S.ChiBangList[prop.ChiBangType].Xj++;
                    PlayerData.S.ChiBangList[prop.ChiBangType].XjEx=0;
                }
            }
            else
            {
                ChiBangInfo chiBangInfo = new ChiBangInfo();
                chiBangInfo.ChiBangType = prop.ChiBangType;
                PlayerData.S.ChiBangList[prop.ChiBangType]=chiBangInfo;
            }

            return;
        }
        
        var data = new PropTable()
        {
            PropType =  prop.PropType,
            Quality =  prop.Quality,
            Desc =  prop.Desc,
            Count =  prop.Count,
            EquipName =  prop.EquipName,
        };
        int value = 0;
        switch (prop.PropType)
        {
            case PropConfig.PropType.WeaponFragment:
                switch (prop.Quality)
                {
                    case 1:
                        value = 101;
                        break;
                    case 2:
                        value = 102;
                        break;
                    case 3:
                        value = 103;
                        break;
                    case 4:
                        value = 104;
                        break;
                    case 5:
                        value = 105;
                        break;
                    case 6:
                        value = 106;
                        break;
                }
                break;
            case PropConfig.PropType.ShenHuaCaiLiao:
                switch (prop.Quality)
                {
                    case 1:
                        value = 301;
                        break;
                    case 2:
                        value = 302;
                        break;
                    case 3:
                        value = 303;
                        break;
                    case 4:
                        value = 304;
                        break;
                }
                break;
            
            case PropConfig.PropType.ChiBang:
                switch (prop.Quality)
                {
                    case 1:
                        value = 401;
                        break;
                    case 2:
                        value = 402;
                        break;
                    case 3:
                        value = 403;
                        break;
                    case 4:
                        value = 404;
                        break;
                    case 5:
                        value = 405;
                        break;
                    case 6:
                        value = 406;
                        break;
                }
                break;
            case PropConfig.PropType.HH:
                switch (prop.Quality)
                {
                    case 1:
                        value = 601;
                        break;
                    case 2:
                        value = 602;
                        break;
                    case 3:
                        value = 603;
                        break;
                    case 4:
                        value = 604;
                        break;
                    case 5:
                        value = 605;
                        break;
                    case 6:
                        value = 606;
                        break;
                }
                break;
            
            case PropConfig.PropType.HA:
                switch (prop.Quality)
                {
                    case 1:
                        value = 701;
                        break;
                    case 2:
                        value = 702;
                        break;
                    case 3:
                        value = 703;
                        break;
                    case 4:
                        value = 704;
                        break;
                    case 5:
                        value = 705;
                        break;
                    case 6:
                        value = 706;
                        break;
                }
                break;
            
            case PropConfig.PropType.HC:
                switch (prop.Quality)
                {
                    case 1:
                        value = 801;
                        break;
                    case 2:
                        value = 802;
                        break;
                    case 3:
                        value = 803;
                        break;
                    case 4:
                        value = 804;
                        break;
                    case 5:
                        value = 805;
                        break;
                    case 6:
                        value = 806;
                        break;
                }
                break;
            
            case PropConfig.PropType.HD:
                switch (prop.Quality)
                {
                    case 1:
                        value = 901;
                        break;
                    case 2:
                        value = 902;
                        break;
                    case 3:
                        value = 903;
                        break;
                    case 4:
                        value = 904;
                        break;
                    case 5:
                        value = 905;
                        break;
                    case 6:
                        value = 906;
                        break;
                }
                break;
            case PropConfig.PropType.AD:
                switch (prop.Quality)
                {
                    case 1:
                        value = 1001;
                        break;
                    case 2:
                        value = 1002;
                        break;
                    case 3:
                        value = 1003;
                        break;
                    case 4:
                        value = 1004;
                        break;
                    case 5:
                        value = 1005;
                        break;
                    case 6:
                        value = 1006;
                        break;
                }
                break;
            
            case PropConfig.PropType.AC:
                switch (prop.Quality)
                {
                    case 1:
                        value = 1101;
                        break;
                    case 2:
                        value = 1102;
                        break;
                    case 3:
                        value = 1103;
                        break;
                    case 4:
                        value = 1104;
                        break;
                    case 5:
                        value = 1105;
                        break;
                    case 6:
                        value = 1106;
                        break;
                }
                break;
            
            case PropConfig.PropType.AA:
                switch (prop.Quality)
                {
                    case 1:
                        value = 1201;
                        break;
                    case 2:
                        value = 1202;
                        break;
                    case 3:
                        value = 1203;
                        break;
                    case 4:
                        value = 1204;
                        break;
                    case 5:
                        value = 1205;
                        break;
                    case 6:
                        value = 1206;
                        break;
                }
                break;
            
            case PropConfig.PropType.CC:
                switch (prop.Quality)
                {
                    case 1:
                        value = 1301;
                        break;
                    case 2:
                        value = 1302;
                        break;
                    case 3:
                        value = 1303;
                        break;
                    case 4:
                        value = 1304;
                        break;
                    case 5:
                        value = 1305;
                        break;
                    case 6:
                        value = 1306;
                        break;
                }
                break;
            
            case PropConfig.PropType.CD:
                switch (prop.Quality)
                {
                    case 1:
                        value = 1401;
                        break;
                    case 2:
                        value = 1402;
                        break;
                    case 3:
                        value = 1403;
                        break;
                    case 4:
                        value = 1404;
                        break;
                    case 5:
                        value = 1405;
                        break;
                    case 6:
                        value = 1406;
                        break;
                }
                break;
            
            case PropConfig.PropType.DD:
                switch (prop.Quality)
                {
                    case 1:
                        value = 1501;
                        break;
                    case 2:
                        value = 1502;
                        break;
                    case 3:
                        value = 1503;
                        break;
                    case 4:
                        value = 1504;
                        break;
                    case 5:
                        value = 1505;
                        break;
                    case 6:
                        value = 1506;
                        break;
                }
                break;
            
            case PropConfig.PropType.ChongWuDan:
                switch (prop.Quality)
                {
                    case 3:
                        value = 1603;
                        break;
                    case 5:
                        value = 1605;
                        break;
                }
                break;
            
            
            case PropConfig.PropType.XiSuiYe:
                switch (prop.Quality)
                {
                    case 3:
                        value = 1703;
                        break;
                    case 5:
                        value = 1705;
                        break;
                }
                break;
            
            case PropConfig.PropType.XueMaiDan:
                switch (prop.Quality)
                {
                    case 3:
                        value = 1803;
                        break;
                    case 5:
                        value = 1805;
                        break;
                }
                break;
            
            
            
            case PropConfig.PropType.SkillShu:
                switch (prop.Quality)
                {
                    case 1:
                        value = 2201;
                        break;
                    case 2:
                        value = 2202;
                        break;
                    case 3:
                        value = 2203;
                        break;
                    case 4:
                        value = 2204;
                        break;
                    case 5:
                        value = 2205;
                        break;
                    case 6:
                        value = 2206;
                        break;
                }
                break;
            
            
            
            case PropConfig.PropType.ChongWuShiWu:
                switch (prop.Quality)
                {
                    case 1:
                        value = 2301;
                        break;
                    case 2:
                        value = 2302;
                        break;
                    case 3:
                        value = 2303;
                        break;
                    case 4:
                        value = 2304;
                        break;
                    case 5:
                        value = 2305;
                        break;
                    case 6:
                        value = 2306;
                        break;
                }

                break;
                
            case PropConfig.PropType.DaKongShi:
                switch (prop.Quality)
                {
                    case 5:
                        value = 2405;
                        break;
                }
                break;
        }
       
        if (propTables.ContainsKey(value))
        {
            propTables[value].Count+=prop.Count;
        }
        else
        {
            propTables.Add(value,data);
        }
    }
}
