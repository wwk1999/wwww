using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public struct MonsterDiaoLuoListItem
{
    public int quality;
    public Sprite _buttonIcon;
}
public struct MonsterBookData
{
    public string _name;
    public string _location;
    public string _monsterType;
    public string _introduce;
    public float _scale;
    public List<MonsterDiaoLuoListItem> _diaoluoList;
}
public class MonsterBookConfig 
{
    
    //第一关怪物列表配置
    public static MonsterBookData snotBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.Snot,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName1,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.5f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteChiBang } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryCloth } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryCloak },
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryRing } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryNecklace },
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryHelmet } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryShoe },
        }
    };
    public static MonsterBookData spiderBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.Spider,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName1,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.5f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteChiBang } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryCloth } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryCloak },
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryRing } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryNecklace },
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryHelmet } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryShoe },
        }
    };
    public static MonsterBookData batBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.Bat,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName1,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.5f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteChiBang } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryCloth } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryCloak },
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryRing } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryNecklace },
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryHelmet } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryShoe },
        }
    };
    public static MonsterBookData eliteBeeBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.Bee,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName1,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.EliteMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteChiBang } ,
           
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryCloth } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryCloak },
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryRing } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryNecklace },
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryHelmet } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.PrimaryShoe },
            
             new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenWeaponFragment } ,
             new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenChiBang } ,
             
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloak },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenNecklace },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenHelmet } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenShoe },
        }
    };
    static public MonsterBookData bossTreeManBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.TreeMan,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName1,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.Boss,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.2f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenChiBang } ,
           
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloak },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenShoe } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenHelmet },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenNecklace },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.TreeManCloth } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.TreeManCloak },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.TreeManShoe } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.TreeManHelmet },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.TreeManRing } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.TreeManNecklace },
        }
    };
    
    
    
    //第二关怪物列表配置
    public static MonsterBookData chongziBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.ChongZi,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName2,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 1f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloak },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenShoe } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenHelmet },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenNecklace },
        }
    };
    public static MonsterBookData xiaohuoBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.XiaoHuo,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName2,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 1f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloak },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenShoe } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenHelmet },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenNecklace },
        }
    };
    public static MonsterBookData dundiBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.DunDi,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName2,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.6f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 1, _buttonIcon = ResourcesConfig.WhiteChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloak },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenShoe } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenHelmet },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenNecklace },
        }
    };
    public static MonsterBookData elitedazuiBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.DaZui,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName2,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.EliteMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.5f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloak },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenShoe } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenHelmet },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenNecklace },

        }
    };
    static public MonsterBookData bossHuoShanBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.HuoShanBoss,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName2,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.Boss,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenCloak },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenShoe } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenHelmet },
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenNecklace },
            
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.HuoShanCloth } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.HuoShanCloak },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.HuoShanShoe } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.HuoShanHelmet },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.HuoShanRing } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.HuoShanNecklace },
        }
    };
    
    
     //第三关怪物列表配置
    public static MonsterBookData wenziBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.WenZi,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName3,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.6f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueCloth } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueCloak },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueShoe } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueHelmet },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueRing } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueNecklace },
        }
    };
    public static MonsterBookData qingwaBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.QingWa,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName3,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.6f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueCloth } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueCloak },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueShoe } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueHelmet },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueRing } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueNecklace },
        }
    };
    public static MonsterBookData jiachongBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.JiaChong,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName3,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.5f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueCloth } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueCloak },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueShoe } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueHelmet },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueRing } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueNecklace },
        }
    };
    public static MonsterBookData shirenhuaBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.ShiRenHua,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName3,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.EliteMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.8f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.HuoShanCloth } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.HuoShanCloak },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.HuoShanShoe } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.HuoShanHelmet },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.HuoShanRing } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.HuoShanNecklace },

        }
    };
    static public MonsterBookData bossZhaoZeBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.ZhaoZeBoss,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName3,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.Boss,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeCloth } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeCloak },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeShoe } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeHelmet },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeRing } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeNecklace },
        }
    };
    
    static public MonsterBookData ShaChongBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.ShaChong,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName4,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueCloth } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueCloak },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueShoe } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueHelmet },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueRing } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueNecklace },
        }
    };
    
    static public MonsterBookData ShaNiaoZeBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.ShaNiao,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName4,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueCloth } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueCloak },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueShoe } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueHelmet },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueRing } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueNecklace },
        }
    };
    
    static public MonsterBookData XianRenZhangBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.XianRenZhang,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName4,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 2, _buttonIcon = ResourcesConfig.GreenChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueCloth } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueCloak },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueShoe } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueHelmet },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueRing } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueNecklace },
        }
    };
    
    static public MonsterBookData ShaXiYiBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.ShaXiYi,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName4,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.EliteMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeCloth } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeCloak },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeShoe } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeHelmet },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeRing } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeNecklace },
        }
    };
    
    static public MonsterBookData XieZiZeBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.XieZi,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName4,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.Boss,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleCloth } ,
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleCloak },
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleShoe } ,
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleHelmet },
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleRing } ,
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleNecklace },
        }
    };
    static public MonsterBookData XueQiEZeBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.XueQiE,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName4,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeCloth } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeCloak },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeShoe } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeHelmet },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeRing } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeNecklace },
        }
    };
    
    static public MonsterBookData XueRenBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.XueRen,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName4,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeCloth } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeCloak },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeShoe } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeHelmet },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeRing } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeNecklace },
        }
    };
    
    static public MonsterBookData XueZhangLangBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.XueZhangLang,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName4,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.NormalMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeCloth } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeCloak },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeShoe } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeHelmet },
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeRing } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.ZhaoZeNecklace },
        }
    };
    
    static public MonsterBookData YingShuBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.YingShu,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName4,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.EliteMonster,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 3, _buttonIcon = ResourcesConfig.BlueChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleCloth } ,
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleCloak },
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleShoe } ,
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleHelmet },
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleRing } ,
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleNecklace },
        }
    };
    
    static public MonsterBookData XueRenBossBookData = new MonsterBookData
    {
        _name = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.XueRenBoss,
        _location = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.LevelName4,
        _monsterType = LanguageConfig.LanguageItems[PlayerData.S.langType].MonsterBookWindowLanguage.Boss,
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleWeaponFragment } ,
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.PurpleChiBang } ,
            
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.Purple1Cloth } ,
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.Purple1Cloak },
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.Purple1Shoe } ,
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.Purple1Helmet },
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.Purple1Ring } ,
            new MonsterDiaoLuoListItem { quality = 4, _buttonIcon = ResourcesConfig.Purple1Necklace },
        }
    };
}
