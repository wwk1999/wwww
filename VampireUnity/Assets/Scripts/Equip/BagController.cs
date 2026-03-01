using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Gloabl;
using Mysql;
using MySqlConnector;
using TMPro;
using Tool;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class SavaEquipData
{
    public int Equipid{ get; set; }
    public int Quality { get; set; }
    public int Damage { get; set; }
    public int Crit { get; set; }
    public int Critdamage { get; set; }
    public int Damagespeed { get; set; }
    public int Bloodsuck { get; set; }
    public int Hp { get; set; }
    public int Movespeed { get; set; }
    public string Equipname { get; set; }
    public int Suitid { get; set; }
    public string Suitname { get; set; }
    public int Equip_type_id { get; set; }
    public string Equip_type_name { get; set; }
    public int Userid { get; set; }
    public int Defense { get; set; }
    public int Goodfortune { get; set; }
    public int Type { get; set; }
}

public class BagController : XSingleton<BagController>
{
    [NonSerialized] public bool IsInit = false;

    [NonSerialized]
    public Dictionary<string, Sprite> EquipidSpriteConfig = new Dictionary<string, Sprite>(); //装备的Sprite配置

    [NonSerialized] public Dictionary<int, Sprite> EquipidSprite = new Dictionary<int, Sprite>(); //背包里所有的装备的Sprite

    //[NonSerialized] public List<EquipTable> EquipidTable = new List<EquipTable>(); //背包里所有的装备的属性
    public Dictionary<int, EquipTable> EquipIdList
    {
        get => EquipIDData.S.equipIds;
        set => EquipIDData.S.equipIds = value;
    }

    public Dictionary<int, PropTable> PropList
    {
        get => EquipIDData.S.propTables;
        set => EquipIDData.S.propTables = value;
    }

    [NonSerialized] public List<EquipTable> WhiteEquipidTable = new List<EquipTable>(); //背包里所有的白色装备
    [NonSerialized] public List<EquipTable> GreenEquipidTable = new List<EquipTable>(); //背包里所有的绿色装备
    [NonSerialized] public List<EquipTable> BlueEquipidTable = new List<EquipTable>(); //背包里所有的蓝色色装备
    [NonSerialized] public List<EquipTable> PurpleEquipidTable = new List<EquipTable>(); //背包里所有的紫色色装备
    [NonSerialized] public List<EquipTable> OrangeEquipidTable = new List<EquipTable>(); //背包里所有的橙色装备
    [NonSerialized] public List<EquipTable> RedEquipidTable = new List<EquipTable>(); //背包里所有的红色装备


    //源石相关
    [NonSerialized] public List<SourceStoneTable> SourceStoneTable = new List<SourceStoneTable>(); //源石列表

    [NonSerialized]
    public List<SourceStoneTable> WhiteWeaponSourceStoneTable = new List<SourceStoneTable>(); //背包里所有的白色源石

    [NonSerialized]
    public List<SourceStoneTable> GreenWeaponSourceStoneTable = new List<SourceStoneTable>(); //背包里所有的绿色源石

    [NonSerialized]
    public List<SourceStoneTable> BlueWeaponSourceStoneTable = new List<SourceStoneTable>(); //背包里所有的蓝色源石

    [NonSerialized]
    public List<SourceStoneTable> PurpleWeaponSourceStoneTable = new List<SourceStoneTable>(); //背包里所有的紫色源石

    [NonSerialized]
    public List<SourceStoneTable> OrangeWeaponSourceStoneTable = new List<SourceStoneTable>(); //背包里所有的橙色源石



    [NonSerialized] public Dictionary<string, int> MaxEquipid = new Dictionary<string, int>(); //存储最大的装备ID



    // //数据库里的装备，暂时获取所有装备，后面要换成获取自己userid的装备
    // [NonSerialized] public Dictionary<int, EquipTable> MysqlEquipDic = new Dictionary<int, EquipTable>();
    [NonSerialized] public GameObject bagGrid; //背包格子
    [NonSerialized] public GameObject bag; //背包
    [NonSerialized] public GameObject MaskLayer; //蒙层
    [NonSerialized] public bool IsShowPlayerPanel = true;
    [NonSerialized] public GameObject PlayerPanel; //玩家面板
    [NonSerialized] public GameObject AttributePanel; //属性面板
    public GameObject playerCloth; //玩家面板的衣服
    public GameObject playerCloak; //玩家面板的披风
    public GameObject playerRing;
    public GameObject playerNecklace;
    public GameObject playerShoe;
    public GameObject playerHelmet;
    [NonSerialized] private bool IsInstallCloth = false; //是否穿了衣服
    [NonSerialized] private bool IsInstallCloak = false;
    [NonSerialized] private bool IsInstallRing = false;
    [NonSerialized] private bool IsInstallNecklace = false;
    [NonSerialized] private bool IsInstallShoe = false;
    [NonSerialized] private bool IsInstallHelmet = false;
    [NonSerialized] public int PageNum = 1; //第几页   


    //装备颜色背景的sprite
    public Sprite whiteBg;
    public Sprite greenBg;
    public Sprite blueBg;
    public Sprite purpleBg;
    public Sprite orangeBg;

    //装备颜色背景的material
    public Material whiteMaterial;
    public Material greenMaterial;
    public Material blueMaterial;
    public Material purpleMaterial;
    public Material orangeMaterial;


    //player穿的装备的属性,是背包里面的

    [NonSerialized] public BagGrid PlayerClothGrid = new BagGrid();
    [NonSerialized] public BagGrid PlayerCloakGrid = new BagGrid();
    [NonSerialized] public BagGrid PlayerRingGrid = new BagGrid();
    [NonSerialized] public BagGrid PlayerNecklaceGrid = new BagGrid();
    [NonSerialized] public BagGrid PlayerShoeGrid = new BagGrid();
    [NonSerialized] public BagGrid PlayerHelmetGrid = new BagGrid();

    public float time = 0;

    public void JingCuiDebug()
    {
        if (PropList.ContainsKey(201))
        {
            PropList[201].Count += 100;
        }
        else
        {
            PropList.Add(201,new PropTable(){PropType = PropConfig.PropType.JingCui,Count = 100,Desc = "",EquipName = "WhiteJingCui",Quality = 1});
        }
        
        if (S.PropList.ContainsKey(202))
        {
            S.PropList[202].Count += 100;
        }
        else
        {
            S.PropList.Add(202,new PropTable(){PropType = PropConfig.PropType.JingCui,Count = 100,Desc = "",EquipName = "GreenJingCui",Quality = 2});
        }                    
        
        if (PropList.ContainsKey(203))
        {
            PropList[203].Count += 100;
        }
        else
        {
            PropList.Add(203,new PropTable(){PropType = PropConfig.PropType.JingCui,Count = 100,Desc = "",EquipName = "BlueJingCui",Quality = 3});
        }
        
        if (PropList.ContainsKey(204))
        {
            PropList[204].Count += 100;
        }
        else
        {
            PropList.Add(204,new PropTable(){PropType = PropConfig.PropType.JingCui,Count = 100,Desc = "",EquipName = "PurpleJingCui",Quality = 4});
        }
        
        if (PropList.ContainsKey(205))
        {
            PropList[205].Count += 100;
        }
        else
        {
            PropList.Add(205,new PropTable(){PropType = PropConfig.PropType.JingCui,Count = 100,Desc = "",EquipName = "OrangeJingCui",Quality = 5});
        }
        
        if (PropList.ContainsKey(206))
        {
            PropList[206].Count += 100;
        }
        else
        {
            PropList.Add(206,new PropTable(){PropType = PropConfig.PropType.JingCui,Count = 100,Desc = "",EquipName = "RedJingCui",Quality = 6});
        }
    }

    public void BaoShiDebug()
    {
        DebugTool(601, "HH1");
        DebugTool(602, "HH2");
        DebugTool(603, "HH3");
        DebugTool(604, "HH4");
        DebugTool(605, "HH5");
        DebugTool(606, "HH6");
        
        DebugTool(701, "HA1");
        DebugTool(702, "HA2");
        DebugTool(703, "HA3");
        DebugTool(704, "HA4");
        DebugTool(705, "HA5");
        DebugTool(706, "HA6");
        
        DebugTool(801, "HC1");
        DebugTool(802, "HC2");
        DebugTool(803, "HC3");
        DebugTool(804, "HC4");
        DebugTool(805, "HC5");
        DebugTool(806, "HC6");
        
        DebugTool(901, "HD1");
        DebugTool(902, "HD2");
        DebugTool(903, "HD3");
        DebugTool(904, "HD4");
        DebugTool(905, "HD5");
        DebugTool(906, "HD6");
        
        DebugTool(1001, "AA1");
        DebugTool(1002, "AA2");
        DebugTool(1003, "AA3");
        DebugTool(1004, "AA4");
        DebugTool(1005, "AA5");
        DebugTool(1006, "AA6");
        
        DebugTool(1101, "AC1");
        DebugTool(1102, "AC2");
        DebugTool(1103, "AC3");
        DebugTool(1104, "AC4");
        DebugTool(1105, "AC5");
        DebugTool(1106, "AC6");
        
        DebugTool(1201, "AD1");
        DebugTool(1202, "AD2");
        DebugTool(1203, "AD3");
        DebugTool(1204, "AD4");
        DebugTool(1205, "AD5");
        DebugTool(1206, "AD6");
        
        DebugTool(1301, "CC1");
        DebugTool(1302, "CC2");
        DebugTool(1303, "CC3");
        DebugTool(1304, "CC4");
        DebugTool(1305, "CC5");
        DebugTool(1306, "CC6");
        
        DebugTool(1401, "CD1");
        DebugTool(1402, "CD2");
        DebugTool(1403, "CD3");
        DebugTool(1404, "CD4");
        DebugTool(1405, "CD5");
        DebugTool(1406, "CD6");
        
        DebugTool(1501, "DD1");
        DebugTool(1502, "DD2");
        DebugTool(1503, "DD3");
        DebugTool(1504, "DD4");
        DebugTool(1505, "DD5");
        DebugTool(1506, "DD6");
    }

    public void DebugTool(int code,string Name)
    {
        if (PropList.ContainsKey(code))
        {
            PropList[code].Count += 100;
        }
        else
        {
            PropList.Add(code,new PropTable(){PropType = (PropConfig.PropType)(code/100),Count = 100,Desc = "",EquipName = Name,Quality = code%100});
        }
    }
    
    public void DebugTool1(int code,string Name)
    {
        if (PropList.ContainsKey(code))
        {
            PropList[code].Count += 1;
        }
        else
        {
            PropList.Add(code,new PropTable(){PropType = (PropConfig.PropType)(code/100),Count = 1,Desc = "",EquipName = Name,Quality = code%100});
        }
    }
    
    
    public void WeaponFragmentDebug()
    {
        if (PropList.ContainsKey(101))
        {
            PropList[101].Count += 100;
        }
        else
        {
            PropList.Add(101,new PropTable(){PropType = PropConfig.PropType.WeaponFragment,Count = 100,Desc = "",EquipName = "WhiteWeaponFragment",Quality = 1});
        }
        
        if (S.PropList.ContainsKey(102))
        {
            S.PropList[102].Count += 100;
        }
        else
        {
            S.PropList.Add(102,new PropTable(){PropType = PropConfig.PropType.WeaponFragment,Count = 100,Desc = "",EquipName = "GreenWeaponFragment",Quality = 2});
        }                    
        
        if (PropList.ContainsKey(103))
        {
            PropList[103].Count += 100;
        }
        else
        {
            PropList.Add(103,new PropTable(){PropType = PropConfig.PropType.WeaponFragment,Count = 100,Desc = "",EquipName = "BlueWeaponFragment",Quality = 3});
        }
        
        if (PropList.ContainsKey(104))
        {
            PropList[104].Count += 100;
        }
        else
        {
            PropList.Add(104,new PropTable(){PropType = PropConfig.PropType.WeaponFragment,Count = 100,Desc = "",EquipName = "PurpleWeaponFragment",Quality = 4});
        }
        
        if (PropList.ContainsKey(105))
        {
            PropList[105].Count += 100;
        }
        else
        {
            PropList.Add(105,new PropTable(){PropType = PropConfig.PropType.WeaponFragment,Count = 100,Desc = "",EquipName = "OrangeWeaponFragment",Quality = 5});
        }
        
        if (PropList.ContainsKey(106))
        {
            PropList[106].Count += 100;
        }
        else
        {
            PropList.Add(106,new PropTable(){PropType = PropConfig.PropType.WeaponFragment,Count = 100,Desc = "",EquipName = "RedWeaponFragment",Quality = 6});
        }
    }



    protected override void Awake()
    {
        InitBag();
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 场景加载后重新初始化UI
        // InitBag();
    }

    public void InitBag()
    {

        // 加载装备背景图
        whiteBg = ResourcesConfig.WhiteBg;
        greenBg = ResourcesConfig.GreenBg;
        blueBg = ResourcesConfig.BlueBg;
        purpleBg = ResourcesConfig.PurpleBg;
        orangeBg = ResourcesConfig.OrangeBg;

        whiteMaterial = ResourcesConfig.WhiteMaterial;
        greenMaterial = ResourcesConfig.GreenMaterial;
        blueMaterial = ResourcesConfig.BlueMaterial;
        purpleMaterial = ResourcesConfig.PurpleMaterial;
        orangeMaterial = ResourcesConfig.OrangeMaterial;


        // 检查装备背景图是否加载成功
        if (whiteBg == null || greenBg == null || blueBg == null || purpleBg == null || orangeBg == null)
        {
            Debug.LogError(
                $"InitBag出错: 装备背景图加载失败，whiteBg: {whiteBg != null}, greenBg: {greenBg != null}, blueBg: {blueBg != null}, purpleBg: {purpleBg != null}, orangeBg: {orangeBg != null}");
        }

        // 查找UIRoot
        GameObject uiRoot = GameObject.Find("UIRoot");
        if (uiRoot == null)
        {
            Debug.LogError("InitBag出错: 找不到UIRoot对象");
            return;
        }


        // 加载背包预制体
        GameObject bagPrefab = Resources.Load("Prefabs/Window/Bag") as GameObject;
        if (bagPrefab == null)
        {
            Debug.LogError("InitBag出错: 无法加载背包预制体");
            return;
        }

        // 销毁旧的背包UI
        if (bag != null)
        {
            Destroy(bag.gameObject);
        }

        // 实例化新的背包UI

        bag = Instantiate(bagPrefab);
        bag.gameObject.SetActive(false);


        // 加载背包格子预制体
        bagGrid = Resources.Load("Prefabs/Equip/BagGrid") as GameObject;
        if (bagGrid == null)
        {
            Debug.LogError("InitBag出错: 无法加载背包格子预制体");
        }

        // 查找背包内的组件

        PlayerPanel = bag.GetComponent<BagPanel>().playerPanel;
        if (PlayerPanel == null)
        {
            Debug.LogError("InitBag出错: 找不到PlayerPanel");
        }

        AttributePanel = bag.GetComponent<BagPanel>().attributePanel;
        if (AttributePanel == null)
        {
            Debug.LogError("InitBag出错: 找不到AttributePanel");
        }

        playerCloth = bag.GetComponent<BagPanel>().playerCloth;
        playerCloak = bag.GetComponent<BagPanel>().playerCloak;
        playerRing = bag.GetComponent<BagPanel>().playerRing;
        playerNecklace = bag.GetComponent<BagPanel>().playerNecklace;
        playerShoe = bag.GetComponent<BagPanel>().playerShoe;
        playerHelmet = bag.GetComponent<BagPanel>().playerHelmet;

        if (playerCloth == null || playerCloak == null || playerRing == null ||
            playerNecklace == null || playerShoe == null || playerHelmet == null)
        {
            Debug.LogError(
                $"InitBag出错: 装备槽对象缺失，playerCloth: {playerCloth != null}, playerCloak: {playerCloak != null}, playerRing: {playerRing != null}, playerNecklace: {playerNecklace != null}, playerShoe: {playerShoe != null}, playerHelmet: {playerHelmet != null}");
        }



        // 初始化装备图标配置

        InitEquipidSpriteConfig();

        // 检查装备数据是否已初始化
        if (EquipIdList == null)
        {
            EquipIdList = new Dictionary<int, EquipTable>();
        }

        if (EquipidSprite == null)
        {
            EquipidSprite = new Dictionary<int, Sprite>();
        }
    }


    // public void UpdateMaxEquipId()
    // {
    //      GlobalMaxEquipId.MaxWhiteClothId= EquipController.S.MaxClothID(1);
    //      GlobalMaxEquipId.MaxGreenClothId= EquipController.S.MaxClothID(2);
    //      GlobalMaxEquipId.MaxBlueClothId= EquipController.S.MaxClothID(3);
    //      GlobalMaxEquipId.MaxPurpleClothId= EquipController.S.MaxClothID(4);
    //      GlobalMaxEquipId.MaxOrangeClothId= EquipController.S.MaxClothID(5);
    //
    // }

    private void Update()
    {
        time+=Time.deltaTime;
        if (time >= 60)
        {
            time = 0;
            PlayerData.S.GameTime++;
        }
    }


    public void InitEquipidSpriteConfig()
    {
        if (!EquipidSpriteConfig.ContainsKey("PrimaryCloth"))
        {
            EquipidSpriteConfig.Add("PrimaryCloth", ResourcesConfig.PrimaryCloth);
        }

        if (!EquipidSpriteConfig.ContainsKey("PrimaryCloak"))
        {
            EquipidSpriteConfig.Add("PrimaryCloak", ResourcesConfig.PrimaryCloak);
        }

        if (!EquipidSpriteConfig.ContainsKey("PrimaryRing"))
        {
            EquipidSpriteConfig.Add("PrimaryRing", ResourcesConfig.PrimaryRing);
        }

        if (!EquipidSpriteConfig.ContainsKey("PrimaryNecklace"))
        {
            EquipidSpriteConfig.Add("PrimaryNecklace", ResourcesConfig.PrimaryNecklace);
        }

        if (!EquipidSpriteConfig.ContainsKey("PrimaryShoe"))
        {
            EquipidSpriteConfig.Add("PrimaryShoe", ResourcesConfig.PrimaryShoe);
        }

        if (!EquipidSpriteConfig.ContainsKey("PrimaryHelmet"))
        {
            EquipidSpriteConfig.Add("PrimaryHelmet", ResourcesConfig.PrimaryHelmet);
        }



        if (!EquipidSpriteConfig.ContainsKey("TreeManCloth"))
        {
            EquipidSpriteConfig.Add("TreeManCloth", ResourcesConfig.TreeManCloth);
        }

        if (!EquipidSpriteConfig.ContainsKey("TreeManCloak"))
        {
            EquipidSpriteConfig.Add("TreeManCloak", ResourcesConfig.TreeManCloak);
        }

        if (!EquipidSpriteConfig.ContainsKey("TreeManRing"))
        {
            EquipidSpriteConfig.Add("TreeManRing", ResourcesConfig.TreeManRing);
        }

        if (!EquipidSpriteConfig.ContainsKey("TreeManNecklace"))
        {
            EquipidSpriteConfig.Add("TreeManNecklace", ResourcesConfig.TreeManNecklace);
        }

        if (!EquipidSpriteConfig.ContainsKey("TreeManShoe"))
        {
            EquipidSpriteConfig.Add("TreeManShoe", ResourcesConfig.TreeManShoe);
        }

        if (!EquipidSpriteConfig.ContainsKey("TreeManHelmet"))
        {
            EquipidSpriteConfig.Add("TreeManHelmet", ResourcesConfig.TreeManHelmet);
        }



        if (!EquipidSpriteConfig.ContainsKey("GreenCloth"))
        {
            EquipidSpriteConfig.Add("GreenCloth", ResourcesConfig.GreenCloth);
        }

        if (!EquipidSpriteConfig.ContainsKey("GreenCloak"))
        {
            EquipidSpriteConfig.Add("GreenCloak", ResourcesConfig.GreenCloak);
        }

        if (!EquipidSpriteConfig.ContainsKey("GreenRing"))
        {
            EquipidSpriteConfig.Add("GreenRing", ResourcesConfig.GreenRing);
        }

        if (!EquipidSpriteConfig.ContainsKey("GreenNecklace"))
        {
            EquipidSpriteConfig.Add("GreenNecklace", ResourcesConfig.GreenNecklace);
        }

        if (!EquipidSpriteConfig.ContainsKey("GreenShoe"))
        {
            EquipidSpriteConfig.Add("GreenShoe", ResourcesConfig.GreenShoe);
        }

        if (!EquipidSpriteConfig.ContainsKey("GreenHelmet"))
        {
            EquipidSpriteConfig.Add("GreenHelmet", ResourcesConfig.GreenHelmet);
        }


        if (!EquipidSpriteConfig.ContainsKey("BlueCloth"))
        {
            EquipidSpriteConfig.Add("BlueCloth", ResourcesConfig.BlueCloth);
        }

        if (!EquipidSpriteConfig.ContainsKey("BlueCloak"))
        {
            EquipidSpriteConfig.Add("BlueCloak", ResourcesConfig.BlueCloak);
        }

        if (!EquipidSpriteConfig.ContainsKey("BlueRing"))
        {
            EquipidSpriteConfig.Add("BlueRing", ResourcesConfig.BlueRing);
        }

        if (!EquipidSpriteConfig.ContainsKey("BlueNecklace"))
        {
            EquipidSpriteConfig.Add("BlueNecklace", ResourcesConfig.BlueNecklace);
        }

        if (!EquipidSpriteConfig.ContainsKey("BlueShoe"))
        {
            EquipidSpriteConfig.Add("BlueShoe", ResourcesConfig.BlueShoe);
        }

        if (!EquipidSpriteConfig.ContainsKey("BlueHelmet"))
        {
            EquipidSpriteConfig.Add("BlueHelmet", ResourcesConfig.BlueHelmet);
        }


        if (!EquipidSpriteConfig.ContainsKey("HuoShanCloth"))
        {
            EquipidSpriteConfig.Add("HuoShanCloth", ResourcesConfig.HuoShanCloth);
        }

        if (!EquipidSpriteConfig.ContainsKey("HuoShanCloak"))
        {
            EquipidSpriteConfig.Add("HuoShanCloak", ResourcesConfig.HuoShanCloak);
        }

        if (!EquipidSpriteConfig.ContainsKey("HuoShanRing"))
        {
            EquipidSpriteConfig.Add("HuoShanRing", ResourcesConfig.HuoShanRing);
        }

        if (!EquipidSpriteConfig.ContainsKey("HuoShanNecklace"))
        {
            EquipidSpriteConfig.Add("HuoShanNecklace", ResourcesConfig.HuoShanNecklace);
        }

        if (!EquipidSpriteConfig.ContainsKey("HuoShanShoe"))
        {
            EquipidSpriteConfig.Add("HuoShanShoe", ResourcesConfig.HuoShanShoe);
        }

        if (!EquipidSpriteConfig.ContainsKey("HuoShanHelmet"))
        {
            EquipidSpriteConfig.Add("HuoShanHelmet", ResourcesConfig.HuoShanHelmet);
        }


        if (!EquipidSpriteConfig.ContainsKey("ZhaoZeCloth"))
        {
            EquipidSpriteConfig.Add("ZhaoZeCloth", ResourcesConfig.ZhaoZeCloth);
        }

        if (!EquipidSpriteConfig.ContainsKey("ZhaoZeCloak"))
        {
            EquipidSpriteConfig.Add("ZhaoZeCloak", ResourcesConfig.ZhaoZeCloak);
        }

        if (!EquipidSpriteConfig.ContainsKey("ZhaoZeRing"))
        {
            EquipidSpriteConfig.Add("ZhaoZeRing", ResourcesConfig.ZhaoZeRing);
        }

        if (!EquipidSpriteConfig.ContainsKey("ZhaoZeNecklace"))
        {
            EquipidSpriteConfig.Add("ZhaoZeNecklace", ResourcesConfig.ZhaoZeNecklace);
        }

        if (!EquipidSpriteConfig.ContainsKey("ZhaoZeShoe"))
        {
            EquipidSpriteConfig.Add("ZhaoZeShoe", ResourcesConfig.ZhaoZeShoe);
        }

        if (!EquipidSpriteConfig.ContainsKey("ZhaoZeHelmet"))
        {
            EquipidSpriteConfig.Add("ZhaoZeHelmet", ResourcesConfig.ZhaoZeHelmet);
        }
    }

    public void UnInstallPlayerWearGrid(BagGrid equipGrid)
    {
        if (equipGrid == null || equipGrid.tableBase == null)
        {
            Debug.LogWarning("UnInstallPlayerWearGrid: equipGrid 或 tableBase 为空，直接返回");
            return;
        }

        EquipTable equipTable = equipGrid.tableBase as EquipTable;
        if (equipTable == null)
        {
            Debug.LogWarning("UnInstallPlayerWearGrid: tableBase 不是 EquipTable 类型");
            return;
        }

        switch (equipTable.equip_type_id)
        {
            case 1:
                if (PlayerEquipConfig.CloakId == equipTable.equipid)
                {
                    PlayerCloakGrid = null;
                }

                break;
            case 2:
                if (PlayerEquipConfig.ClothId == equipTable.equipid)
                {
                    PlayerClothGrid = null;
                }

                break;
            case 3:
                if (PlayerEquipConfig.HelmetId == equipTable.equipid)
                {
                    PlayerHelmetGrid = null;
                }

                break;
            case 4:
                if (PlayerEquipConfig.NecklaceId == equipTable.equipid)
                {
                    PlayerNecklaceGrid = null;
                }

                break;
            case 5:
                if (PlayerEquipConfig.RingId == equipTable.equipid)
                {
                    PlayerRingGrid = null;
                }

                break;
            case 6:
                if (PlayerEquipConfig.ShoeId == equipTable.equipid)
                {
                    PlayerShoeGrid = null;
                }

                break;
        }
    }

    public void InstallPlayerWearGrid(BagGrid equipGrid)
    {
        EquipTable equipTable = equipGrid.tableBase as EquipTable;
        switch (equipTable.equip_type_id)
        {
            case 1:
                if (PlayerEquipConfig.CloakId == equipTable.equipid)
                {
                    PlayerCloakGrid = equipGrid;
                }

                break;
            case 2:
                if (PlayerEquipConfig.ClothId == equipTable.equipid)
                {
                    PlayerClothGrid = equipGrid;
                }

                break;
            case 3:
                if (PlayerEquipConfig.HelmetId == equipTable.equipid)
                {
                    PlayerHelmetGrid = equipGrid;
                }

                break;
            case 4:
                if (PlayerEquipConfig.NecklaceId == equipTable.equipid)
                {
                    PlayerNecklaceGrid = equipGrid;
                }

                break;
            case 5:
                if (PlayerEquipConfig.RingId == equipTable.equipid)
                {
                    PlayerRingGrid = equipGrid;
                }

                break;
            case 6:
                if (PlayerEquipConfig.ShoeId == equipTable.equipid)
                {
                    PlayerShoeGrid = equipGrid;
                }

                break;
        }
    }

    //显示道具
    public void ShowProp()
    {
        Transform bagPanelContent = bag.GetComponent<BagPanel>().content.transform;
        GameObject equipContent = bagPanelContent.gameObject;
        // 清空装备内容面板
        foreach (Transform child in equipContent.transform)
        {
            Destroy(child.gameObject);
        }
        int startIndex = (PageNum - 1) * 40;
        int endIndex = Mathf.Min(PageNum * 40, PropList.Count);
        List<PropTable> list = PropList.Values.ToList();
        List<int> keylist = PropList.Keys.ToList();

        for (int i = startIndex; i < endIndex; i++)
        {
            if (list[i].Count <= 0)
            {
                continue;
            }
            var propGrid = Instantiate(Resources.Load("Prefabs/Prop/PropGrid"), equipContent.transform) as GameObject;
            propGrid.GetComponent<PropGrid>().propType = keylist[i];
            propGrid.transform.Find("parent/Count").gameObject.SetActive(list[i].Count > 1);
            propGrid.transform.Find("parent/Count").GetComponent<TextMeshProUGUI>().text = list[i].Count.ToString();
            if (list[i].PropType == PropConfig.PropType.ShenHuaCaiLiao)
            {
                if (keylist[i] == 305)
                {
                    propGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("RedEdge");
                    propGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
                }
                else
                {
                    propGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("OrangeEdge");
                    propGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                }
                
            }
            else
            {
                switch (list[i].Quality)
                {
                    case 1:
                        propGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("WhiteEdge");
                        propGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.WhiteBg;
                        break;
                    case 2:
                        propGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("GreenEdge");
                        propGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.GreenBg;
                        break;
                    case 3:
                        propGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("BlueEdge");
                        propGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.BlueBg;
                        break;
                    case 4:
                        propGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("PurpleEdge");
                        propGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.PurpleBg;
                        break;
                    case 5:
                        propGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("OrangeEdge");
                        propGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.OrangeBg;
                        break;
                    case 6:
                        propGrid.transform.Find("parent/Edge").GetComponent<Animator>().Play("RedEdge");
                        propGrid.transform.Find("parent/EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.RedBg;
                        break;
                }
            }
            

            switch (list[i].PropType)
            {
                case PropConfig.PropType.WeaponFragment:
                    switch (list[i].Quality)
                    {
                        case 1:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.WhiteWeaponFragment;
                            break;
                        case 2:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.GreenWeaponFragment;
                            break;
                        case 3:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.BlueWeaponFragment;
                            break;
                        case 4:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.PurpleWeaponFragment;
                            break;
                        case 5:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.OrangeWeaponFragment;
                            break;
                        case 6:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.RedWeaponFragment;
                            break;
                    }

                    break;
                case PropConfig.PropType.JingCui:
                    switch (list[i].Quality)
                    {
                        case 1:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.WhiteJingCui;
                            break;
                        case 2:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.GreenJingCui;
                            break;
                        case 3:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.BlueJingCui;
                            break;
                        case 4:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.PurpleJingCui;
                            break;
                        case 5:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.OrangeJingCui;
                            break;
                        case 6:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.RedJingCui;
                            break;
                    }

                    break;
                
                
                case PropConfig.PropType.ChiBang:
                    switch (list[i].Quality)
                    {
                        case 1:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.WhiteChiBang;
                            break;
                        case 2:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.GreenChiBang;
                            break;
                        case 3:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.BlueChiBang;
                            break;
                        case 4:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.PurpleChiBang;
                            break;
                        case 5:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.OrangeChiBang;
                            break;
                        case 6:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.RedChiBang;
                            break;
                    }

                    break;
                
                case PropConfig.PropType.ShenHuaCaiLiao:
                    switch (list[i].Quality)
                    {
                        case 1:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.FuMoZhiGu;
                            break;
                        case 2:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.GoldBlood;
                            break;
                        case 3:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.JuDaYaChi;
                            break;
                        case 4:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.ZuiEYanZhu;
                            break;
                        case 6:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =
                                ResourcesConfig.ShenHuaZhiXin;
                            break;
                    }

                    break;
                
                case PropConfig.PropType.AA:
                case PropConfig.PropType.AC:
                case PropConfig.PropType.AD:
                case PropConfig.PropType.HH:
                case PropConfig.PropType.HD:
                case PropConfig.PropType.HC:
                case PropConfig.PropType.HA:
                case PropConfig.PropType.CC:
                case PropConfig.PropType.CD:
                case PropConfig.PropType.DD:
                    BaoShiInfo baoshi=new BaoShiInfo();
                    baoshi.BaoShiType = (BaoShiType)(list[i].PropType - 5);
                    baoshi.Quality=list[i].Quality;
                    propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite =ResourcesConfig.GetBaoShiSprite(baoshi);
                    break;
                case PropConfig.PropType.ChongWuDan:
                    switch (list[i].Quality)
                    {
                        case 3:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite = ResourcesConfig.NormalChongWuDan;
                            break;
                        case 5:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite = ResourcesConfig.GaoJiChongWuDan;
                            break;
                    }
                    break;
                
                case PropConfig.PropType.XiSuiYe:
                    switch (list[i].Quality)
                    {
                        case 3:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite = ResourcesConfig.NormalXiSuiYe;
                            break;
                        case 5:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite = ResourcesConfig.GaoJiXiSuiYe;
                            break;
                    }
                    break;
                
                case PropConfig.PropType.XueMaiDan:
                    switch (list[i].Quality)
                    {
                        case 3:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite = ResourcesConfig.NormalXueMaiDan;
                            break;
                        case 5:
                            propGrid.transform.Find("parent/BagGridImage").GetComponent<Image>().sprite = ResourcesConfig.GaoJiXueMaiDan;
                            break;
                    }
                    break;
            }
        }


    }


    /// <summary>
    /// 显示背包的装备，源石和道具
    /// </summary>
    public void ShowEquip()
    {
        // 查找装备内容面板
        Transform bagPanelContent = bag.GetComponent<BagPanel>().content.transform;
        GameObject equipContent = bagPanelContent.gameObject;

        // 清空装备内容面板
        foreach (Transform child in equipContent.transform)
        {
            Destroy(child.gameObject);
        }

        // 计算显示的装备范围
        int startIndex = (PageNum - 1) * 40;
        int endIndex = Mathf.Min(PageNum * 40, EquipIdList.Count);

        List<EquipTable> list = EquipIdList.Values.ToList();
        if (bag.GetComponent<BagPanel>().currentBagType == 1) //如果是显示装备
        {

            for (int i = startIndex; i < endIndex; i++)
            {
                try
                {
                    // 检查当前索引的装备是否为空
                    if (list[i] == null)
                    {
                        Debug.LogError($"ShowEquip出错: EquipIdList[{i}]为null");
                        continue;
                    }


                    // 实例化背包格子
                    GameObject bagGridins = Instantiate(bagGrid, equipContent.transform);



                    // 设置装备图标
                    Transform bagGridImageTransform = bagGridins.transform.Find("parent/BagGridImage");

                    Button bagGridButton = bagGridImageTransform.GetComponent<Button>();

                    bagGridButton.image.sprite = ResourcesConfig.GetEquipSprite(list[i]);

                    // 设置装备属性图标
                    BagGrid bagGridComponent = bagGridins.GetComponent<BagGrid>();

                    bagGridComponent.equipAttributeImage =
                        ResourcesConfig.GetEquipSprite(list[i]);
                    bagGridComponent.EquipType = EquipType.Equip;

                    if (list[i].Lock)
                    {
                        bagGridComponent.Lock.gameObject.SetActive(true);
                    }
                    else
                    {
                        bagGridComponent.Lock.gameObject.SetActive(false);
                    }
                    //播放边框动画
                    switch (list[i].Quality)
                    {
                        case 1:
                            bagGridComponent.animator.Play("WhiteEdge");
                            break;
                        case 2:
                            bagGridComponent.animator.Play("GreenEdge");
                            break;
                        case 3:
                            bagGridComponent.animator.Play("BlueEdge");
                            break;
                        case 4:
                            bagGridComponent.animator.Play("PurpleEdge");
                            break;
                        case 5:
                            bagGridComponent.animator.Play("OrangeEdge");
                            break;
                        case 6:
                            bagGridComponent.animator.Play("RedEdge");
                            break;

                    }

                    // 隐藏数量显示
                    Transform countTransform = bagGridins.transform.Find("parent/Count");

                    countTransform.gameObject.SetActive(false);

                    bagGridComponent.tableBase = list[i];
                    InstallPlayerWearGrid(bagGridComponent);

                    // 设置装备背景颜色
                    Transform equipGridBGTransform = bagGridins.transform.Find("parent/EquipGridBG");

                    Image equipGridBGImage = equipGridBGTransform.GetComponent<Image>();

                    switch (list[i].Quality)
                    {
                        case 1:
                            equipGridBGImage.sprite = ResourcesConfig.WhiteBg;
                            bagGridButton.image.material = whiteMaterial;
                            break;
                        case 2:
                            equipGridBGImage.sprite = ResourcesConfig.GreenBg;
                            bagGridButton.image.material = greenMaterial;
                            break;
                        case 3:
                            equipGridBGImage.sprite = ResourcesConfig.BlueBg;
                            bagGridButton.image.material = blueMaterial;
                            break;
                        case 4:
                            equipGridBGImage.sprite = ResourcesConfig.PurpleBg;
                            bagGridButton.image.material = purpleMaterial;
                            break;
                        case 5:
                            equipGridBGImage.sprite = ResourcesConfig.OrangeBg;
                            bagGridButton.image.material = orangeMaterial;
                            break;
                        case 6:
                            equipGridBGImage.sprite = ResourcesConfig.RedBg;
                            bagGridButton.image.material = orangeMaterial;
                            break;

                    }

                    GlobalPlayerAttribute.RefreshFuJiaAttribute();
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"ShowEquip异常: 处理索引 {i} 的装备时出错: {e.Message}\n{e.StackTrace}");
                }
            }

            SetE();
        }
        else if (bag.GetComponent<BagPanel>().currentBagType == 2) //如果是显示源石
        {
            foreach (var item in SourceStoneTable)
            {
                // 实例化背包格子
                GameObject bagGridins = Instantiate(bagGrid, equipContent.transform);
                // 设置装备图标
                Transform bagGridImageTransform = bagGridins.transform.Find("parent/BagGridImage");

                Button bagGridButton = bagGridImageTransform.GetComponent<Button>();


                // 设置装备属性图标
                BagGrid bagGridComponent = bagGridins.GetComponent<BagGrid>();
                
                bagGridComponent.EquipType = EquipType.SourceStone;

                // 设置bagGrid的TableBase属性
                bagGridComponent.tableBase = item;

                // 设置装备背景颜色
                Transform equipGridBGTransform = bagGridins.transform.Find("parent/EquipGridBG");

                Image equipGridBGImage = equipGridBGTransform.GetComponent<Image>();
                //设置数量
                Transform countTransform = bagGridins.transform.Find("parent/Count");
                countTransform.GetComponent<Text>().text = item.Count.ToString();
                countTransform.gameObject.SetActive(true);

                switch (item.Quality)
                {
                    case 1:
                        equipGridBGImage.sprite = whiteBg;
                        bagGridButton.image.material = whiteMaterial;
                        break;
                    case 2:
                        equipGridBGImage.sprite = greenBg;
                        bagGridButton.image.material = greenMaterial;
                        break;
                    case 3:
                        equipGridBGImage.sprite = blueBg;
                        bagGridButton.image.material = blueMaterial;
                        break;
                    case 4:
                        equipGridBGImage.sprite = purpleBg;
                        bagGridButton.image.material = purpleMaterial;
                        break;
                    case 5:
                        equipGridBGImage.sprite = orangeBg;
                        bagGridButton.image.material = orangeMaterial;
                        break;
                }
            }
        }

    }

    /// <summary>
    /// 打开背包面板
    /// </summary>
    public void ShowBag()
    {

        // 检查背包对象是否为空
        if (bag == null)
        {
            Debug.LogError("ShowBag出错: bag对象为null，尝试重新初始化背包");
            InitBag();

            // 再次检查背包对象
            if (bag == null)
            {
                Debug.LogError("ShowBag出错: 重新初始化背包后bag仍为null，无法显示背包");
                return;
            }
        }

        // 检查装备列表是否为空
        if (EquipIdList == null)
        {
            Debug.LogWarning("ShowBag警告: EquipIdList为null，初始化为空列表");
            EquipIdList = new Dictionary<int, EquipTable>();
        }

        Debug.Log($"暂停游戏，当前EquipIdList中有 {EquipIdList.Count} 件装备");

        // 暂停游戏
        Time.timeScale = 0;
        bag.gameObject.SetActive(true);

        try
        {
            Debug.Log("调用ShowEquip方法显示装备");
            ShowEquip();
            RefreshPlayerEquip();
            SetE();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"ShowBag出错: 调用ShowEquip方法时发生异常: {e.Message}\n{e.StackTrace}");
        }

        Debug.Log("ShowBag方法执行完成");
    }

    public void ResetE()
    {
        if (PlayerCloakGrid != null)
        {
            PlayerCloakGrid.E.gameObject.SetActive(false);
        }

        if (PlayerClothGrid != null)
        {
            PlayerClothGrid.E.gameObject.SetActive(false);
        }

        if (PlayerRingGrid != null)
        {
            PlayerRingGrid.E.gameObject.SetActive(false);
        }

        if (PlayerNecklaceGrid != null)
        {
            PlayerNecklaceGrid.E.gameObject.SetActive(false);
        }

        if (PlayerShoeGrid != null)
        {
            PlayerShoeGrid.E.gameObject.SetActive(false);
        }

        if (PlayerHelmetGrid != null)
        {
            PlayerHelmetGrid.E.gameObject.SetActive(false);
        }
    }

    public void SetE()
    {
        if (PlayerCloakGrid != null)
        {
            PlayerCloakGrid.E.gameObject.SetActive(true);
        }

        if (PlayerClothGrid != null)
        {
            PlayerClothGrid.E.gameObject.SetActive(true);
        }

        if (PlayerRingGrid != null)
        {
            PlayerRingGrid.E.gameObject.SetActive(true);
        }

        if (PlayerNecklaceGrid != null)
        {
            PlayerNecklaceGrid.E.gameObject.SetActive(true);
        }

        if (PlayerShoeGrid != null)
        {
            PlayerShoeGrid.E.gameObject.SetActive(true);
        }

        if (PlayerHelmetGrid != null)
        {
            PlayerHelmetGrid.E.gameObject.SetActive(true);
        }
    }


    /// <summary>
    /// 隐藏背包面板
    /// </summary>
    public void HideBag()
    {
        //暂停游戏
        Time.timeScale = 1;
        bag.gameObject.SetActive(false);
    }

    public void PlayEdge(Animator animator, int quality)
    {
        switch (quality)
        {
            case 1:
                animator.Play("WhiteEdge");
                break;
            case 2:
                animator.Play("GreenEdge");
                break;
            case 3:
                animator.Play("BlueEdge");
                break;
            case 4:
                animator.Play("PurpleEdge");
                break;
            case 5:
                animator.Play("OrangeEdge");
                break;
            case 6:
                animator.Play("RedEdge");
                break;
        }
    }

    public void CheckBaoShiTitle()
    {
        if(PlayerData.S.BaoShi == true)
        {
            return;
        }
        int count = 0;
        if (PlayerEquipConfig.CloakId != 0)
        {
            foreach (var item in BagController.S.EquipIdList[PlayerEquipConfig.CloakId].BaoShiDic)
            {
                if (item.Value.BaoShiType != BaoShiType.None)
                {
                    count++;
                }
            }
        }
        
        if (PlayerEquipConfig.HelmetId != 0)
        {
            foreach (var item in BagController.S.EquipIdList[PlayerEquipConfig.HelmetId].BaoShiDic)
            {
                if (item.Value.BaoShiType != BaoShiType.None)
                {
                    count++;
                }
            }
        }
        
        if (PlayerEquipConfig.NecklaceId != 0)
        {
            foreach (var item in BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId].BaoShiDic)
            {
                if (item.Value.BaoShiType != BaoShiType.None)
                {
                    count++;
                }
            }
        }
        
        if (PlayerEquipConfig.RingId != 0)
        {
            foreach (var item in BagController.S.EquipIdList[PlayerEquipConfig.RingId].BaoShiDic)
            {
                if (item.Value.BaoShiType != BaoShiType.None)
                {
                    count++;
                }
            }
        }
        
        if (PlayerEquipConfig.ShoeId != 0)
        {
            foreach (var item in BagController.S.EquipIdList[PlayerEquipConfig.ShoeId].BaoShiDic)
            {
                if (item.Value.BaoShiType != BaoShiType.None)
                {
                    count++;
                }
            }
        }
        
        if (PlayerEquipConfig.ClothId != 0)
        {
            foreach (var item in BagController.S.EquipIdList[PlayerEquipConfig.ClothId].BaoShiDic)
            {
                if (item.Value.BaoShiType != BaoShiType.None)
                {
                    count++;
                }
            }
        }

        if (count>=25&&PlayerData.S.BaoShi == false)
        {
            PlayerData.S.BaoShi = true;
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"激活新称号");
        }
    }

    public void RefreshPlayerEquip()
    {
        GlobalPlayerAttribute.RefreshFuJiaAttribute();
        CheckBaoShiTitle();
        if (PlayerEquipConfig.CloakId == 0)
        {
            IsInstallCloak = false;
            playerCloak.GetComponent<BagGrid>().tableBase =null;
            playerCloak.transform.Find("parent/Image").gameObject.SetActive(false);
            playerCloak.transform.Find("parent/ImageBG").gameObject.SetActive(false);
            playerCloak.transform.Find("parent/Edge").gameObject.SetActive(false);
        }
        else
        {
            IsInstallCloak = true;
            playerCloak.GetComponent<BagGrid>().tableBase = EquipIdList[PlayerEquipConfig.CloakId];
            playerCloak.transform.Find("parent/Image").gameObject.SetActive(true);
            playerCloak.transform.Find("parent/ImageBG").gameObject.SetActive(true);
            playerCloak.transform.Find("parent/Image").GetComponent<Button>().image.sprite =
                ResourcesConfig.GetEquipSprite(EquipIdList[PlayerEquipConfig.CloakId]);

            playerCloak.transform.Find("parent/Edge").gameObject.SetActive(true);
            var animator = playerCloak.transform.Find("parent/Edge").GetComponent<Animator>();
            PlayEdge(animator, EquipIdList[PlayerEquipConfig.CloakId].Quality);
            switch (EquipIdList[PlayerEquipConfig.CloakId].Quality)
            {
                case 1:
                    playerCloak.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = whiteBg;
                    playerCloak.transform.Find("parent/Image").GetComponent<Image>().material = whiteMaterial;
                    break;
                case 2:
                    playerCloak.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = greenBg;
                    playerCloak.transform.Find("parent/Image").GetComponent<Image>().material = greenMaterial;
                    break;
                case 3:
                    playerCloak.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = blueBg;
                    playerCloak.transform.Find("parent/Image").GetComponent<Image>().material = blueMaterial;

                    break;
                case 4:
                    playerCloak.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = purpleBg;
                    playerCloak.transform.Find("parent/Image").GetComponent<Image>().material = purpleMaterial;
                    break;
                case 5:
                    playerCloak.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = orangeBg;
                    playerCloak.transform.Find("parent/Image").GetComponent<Image>().material = orangeMaterial;
                    break;
            }
        }



        if (PlayerEquipConfig.ClothId == 0)
        {
            IsInstallCloth = false;
            playerCloth.GetComponent<BagGrid>().tableBase = null;
            playerCloth.transform.Find("parent/Image").gameObject.SetActive(false);
            playerCloth.transform.Find("parent/ImageBG").gameObject.SetActive(false);
            playerCloth.transform.Find("parent/Edge").gameObject.SetActive(false);

        }
        else
        {
            IsInstallCloth = true;
            playerCloth.GetComponent<BagGrid>().tableBase = EquipIdList[PlayerEquipConfig.ClothId];
            playerCloth.transform.Find("parent/Image").gameObject.SetActive(true);
            playerCloth.transform.Find("parent/ImageBG").gameObject.SetActive(true);
            playerCloth.transform.Find("parent/Image").GetComponent<Button>().image.sprite =
                ResourcesConfig.GetEquipSprite(EquipIdList[PlayerEquipConfig.ClothId]);
            playerCloth.transform.Find("parent/Edge").gameObject.SetActive(true);
            var animator = playerCloth.transform.Find("parent/Edge").GetComponent<Animator>();
            PlayEdge(animator, EquipIdList[PlayerEquipConfig.ClothId].Quality);
            switch (EquipIdList[PlayerEquipConfig.ClothId].Quality)
            {
                case 1:
                    playerCloth.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = whiteBg;
                    playerCloth.transform.Find("parent/Image").GetComponent<Image>().material = whiteMaterial;
                    break;
                case 2:
                    playerCloth.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = greenBg;
                    playerCloth.transform.Find("parent/Image").GetComponent<Image>().material = greenMaterial;
                    break;
                case 3:
                    playerCloth.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = blueBg;
                    playerCloth.transform.Find("parent/Image").GetComponent<Image>().material = blueMaterial;

                    break;
                case 4:
                    playerCloth.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = purpleBg;
                    playerCloth.transform.Find("parent/Image").GetComponent<Image>().material = purpleMaterial;
                    break;
                case 5:
                    playerCloth.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = orangeBg;
                    playerCloth.transform.Find("parent/Image").GetComponent<Image>().material = orangeMaterial;
                    break;
            }
        }


        if (PlayerEquipConfig.ShoeId == 0)
        {
            IsInstallShoe = false;
            playerShoe.GetComponent<BagGrid>().tableBase = null;
            playerShoe.transform.Find("parent/Image").gameObject.SetActive(false);
            playerShoe.transform.Find("parent/ImageBG").gameObject.SetActive(false);
            playerShoe.transform.Find("parent/Edge").gameObject.SetActive(false);

        }
        else
        {
            IsInstallShoe = true;
            playerShoe.GetComponent<BagGrid>().tableBase = EquipIdList[PlayerEquipConfig.ShoeId];
            playerShoe.transform.Find("parent/Image").gameObject.SetActive(true);
            playerShoe.transform.Find("parent/ImageBG").gameObject.SetActive(true);
            playerShoe.transform.Find("parent/Image").GetComponent<Button>().image.sprite =
                ResourcesConfig.GetEquipSprite(EquipIdList[PlayerEquipConfig.ShoeId]);
            playerShoe.transform.Find("parent/Edge").gameObject.SetActive(true);
            var animator = playerShoe.transform.Find("parent/Edge").GetComponent<Animator>();
            PlayEdge(animator, EquipIdList[PlayerEquipConfig.ShoeId].Quality);
            switch (EquipIdList[PlayerEquipConfig.ShoeId].Quality)
            {
                case 1:
                    playerShoe.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = whiteBg;
                    playerShoe.transform.Find("parent/Image").GetComponent<Image>().material = whiteMaterial;
                    break;
                case 2:
                    playerShoe.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = greenBg;
                    playerShoe.transform.Find("parent/Image").GetComponent<Image>().material = greenMaterial;
                    break;
                case 3:
                    playerShoe.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = blueBg;
                    playerShoe.transform.Find("parent/Image").GetComponent<Image>().material = blueMaterial;

                    break;
                case 4:
                    playerShoe.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = purpleBg;
                    playerShoe.transform.Find("parent/Image").GetComponent<Image>().material = purpleMaterial;
                    break;
                case 5:
                    playerShoe.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = orangeBg;
                    playerShoe.transform.Find("parent/Image").GetComponent<Image>().material = orangeMaterial;
                    break;
            }
        }


        if (PlayerEquipConfig.HelmetId == 0)
        {
            IsInstallHelmet = false;
            playerHelmet.GetComponent<BagGrid>().tableBase = null;
            playerHelmet.transform.Find("parent/Image").gameObject.SetActive(false);
            playerHelmet.transform.Find("parent/ImageBG").gameObject.SetActive(false);
            playerHelmet.transform.Find("parent/Edge").gameObject.SetActive(false);

        }
        else
        {
            IsInstallHelmet = true;
            playerHelmet.GetComponent<BagGrid>().tableBase = EquipIdList[PlayerEquipConfig.HelmetId];
            playerHelmet.transform.Find("parent/Image").gameObject.SetActive(true);
            playerHelmet.transform.Find("parent/ImageBG").gameObject.SetActive(true);
            playerHelmet.transform.Find("parent/Image").GetComponent<Button>().image.sprite =
                ResourcesConfig.GetEquipSprite(EquipIdList[PlayerEquipConfig.HelmetId]);
            playerHelmet.transform.Find("parent/Edge").gameObject.SetActive(true);
            var animator = playerHelmet.transform.Find("parent/Edge").GetComponent<Animator>();
            PlayEdge(animator, EquipIdList[PlayerEquipConfig.HelmetId].Quality);
            switch (EquipIdList[PlayerEquipConfig.HelmetId].Quality)
            {
                case 1:
                    playerHelmet.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = whiteBg;
                    playerHelmet.transform.Find("parent/Image").GetComponent<Image>().material = whiteMaterial;
                    break;
                case 2:
                    playerHelmet.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = greenBg;
                    playerHelmet.transform.Find("parent/Image").GetComponent<Image>().material = greenMaterial;
                    break;
                case 3:
                    playerHelmet.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = blueBg;
                    playerHelmet.transform.Find("parent/Image").GetComponent<Image>().material = blueMaterial;

                    break;
                case 4:
                    playerHelmet.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = purpleBg;
                    playerHelmet.transform.Find("parent/Image").GetComponent<Image>().material = purpleMaterial;
                    break;
                case 5:
                    playerHelmet.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = orangeBg;
                    playerHelmet.transform.Find("parent/Image").GetComponent<Image>().material = orangeMaterial;
                    break;
            }
        }


        if (PlayerEquipConfig.NecklaceId == 0)
        {
            IsInstallNecklace = false;
            playerNecklace.GetComponent<BagGrid>().tableBase =null;
            playerNecklace.transform.Find("parent/Image").gameObject.SetActive(false);
            playerNecklace.transform.Find("parent/ImageBG").gameObject.SetActive(false);
            playerNecklace.transform.Find("parent/Edge").gameObject.SetActive(false);
        }
        else
        {
            IsInstallNecklace = true;
            playerNecklace.GetComponent<BagGrid>().tableBase = EquipIdList[PlayerEquipConfig.NecklaceId];
            playerNecklace.transform.Find("parent/Image").gameObject.SetActive(true);
            playerNecklace.transform.Find("parent/ImageBG").gameObject.SetActive(true);
            playerNecklace.transform.Find("parent/Image").GetComponent<Button>().image.sprite =
                ResourcesConfig.GetEquipSprite(EquipIdList[PlayerEquipConfig.NecklaceId]);
            playerNecklace.transform.Find("parent/Edge").gameObject.SetActive(true);
            var animator = playerNecklace.transform.Find("parent/Edge").GetComponent<Animator>();
            PlayEdge(animator, EquipIdList[PlayerEquipConfig.NecklaceId].Quality);
            switch (EquipIdList[PlayerEquipConfig.NecklaceId].Quality)
            {
                case 1:
                    playerNecklace.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = whiteBg;
                    playerNecklace.transform.Find("parent/Image").GetComponent<Image>().material = whiteMaterial;
                    break;
                case 2:
                    playerNecklace.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = greenBg;
                    playerNecklace.transform.Find("parent/Image").GetComponent<Image>().material = greenMaterial;
                    break;
                case 3:
                    playerNecklace.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = blueBg;
                    playerNecklace.transform.Find("parent/Image").GetComponent<Image>().material = blueMaterial;

                    break;
                case 4:
                    playerNecklace.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = purpleBg;
                    playerNecklace.transform.Find("parent/Image").GetComponent<Image>().material = purpleMaterial;
                    break;
                case 5:
                    playerNecklace.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = orangeBg;
                    playerNecklace.transform.Find("parent/Image").GetComponent<Image>().material = orangeMaterial;
                    break;
            }
        }

        if (PlayerEquipConfig.RingId == 0)
        {
            IsInstallRing = false;
            playerRing.GetComponent<BagGrid>().tableBase =null;
            playerRing.transform.Find("parent/Image").gameObject.SetActive(false);
            playerRing.transform.Find("parent/ImageBG").gameObject.SetActive(false);
            playerRing.transform.Find("parent/Edge").gameObject.SetActive(false);
        }
        else
        {
            IsInstallRing = true;
            IsInstallRing = false;
            playerRing.GetComponent<BagGrid>().tableBase = EquipIdList[PlayerEquipConfig.RingId];
            playerRing.transform.Find("parent/Image").gameObject.SetActive(true);
            playerRing.transform.Find("parent/ImageBG").gameObject.SetActive(true);
            playerRing.transform.Find("parent/Image").GetComponent<Button>().image.sprite =
                ResourcesConfig.GetEquipSprite(EquipIdList[PlayerEquipConfig.RingId]);
            playerRing.transform.Find("parent/Edge").gameObject.SetActive(true);
            var animator = playerRing.transform.Find("parent/Edge").GetComponent<Animator>();
            PlayEdge(animator, EquipIdList[PlayerEquipConfig.RingId].Quality);
            switch (EquipIdList[PlayerEquipConfig.RingId].Quality)
            {
                case 1:
                    playerRing.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = whiteBg;
                    playerRing.transform.Find("parent/Image").GetComponent<Image>().material = whiteMaterial;
                    break;
                case 2:
                    playerRing.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = greenBg;
                    playerRing.transform.Find("parent/Image").GetComponent<Image>().material = greenMaterial;
                    break;
                case 3:
                    playerRing.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = blueBg;
                    playerRing.transform.Find("parent/Image").GetComponent<Image>().material = blueMaterial;

                    break;
                case 4:
                    playerRing.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = purpleBg;
                    playerRing.transform.Find("parent/Image").GetComponent<Image>().material = purpleMaterial;
                    break;
                case 5:
                    playerRing.transform.Find("parent/ImageBG").GetComponent<Image>().sprite = orangeBg;
                    playerRing.transform.Find("parent/Image").GetComponent<Image>().material = orangeMaterial;
                    break;
            }
        }

        GlobalPlayerAttribute.RefreshOrangeEntry();
    }


    public bool IsClickInstalled(EquipTable equiptable)
    {
        switch (equiptable.equip_type_id)
        {
            case 1:
                return equiptable.equipid == PlayerEquipConfig.CloakId;
            case 2:
                return equiptable.equipid == PlayerEquipConfig.ClothId;
            case 3:
                return equiptable.equipid == PlayerEquipConfig.HelmetId;
            case 4:
                return equiptable.equipid == PlayerEquipConfig.NecklaceId;
            case 5:
                return equiptable.equipid == PlayerEquipConfig.RingId;
            case 6:
                return equiptable.equipid == PlayerEquipConfig.ShoeId;
            default:
                return false;
        }
    }

    //显示装备属性面板
    public void ShowEquipAttributePanel(TableBase tablebase, EquipType EquipType, GameObject bagGrid)
    {
        EquipTable equipTable = (EquipTable)tablebase;
        // 加载预制体
        GameObject attributePrefab = null;
        switch (equipTable.Quality)
        {
            case 1:
                attributePrefab = Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/EquipAttributeWhite");
                break;
            case 2:
                attributePrefab = Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/EquipAttributeGreen");
                break;
            case 3:
                attributePrefab = Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/EquipAttributeBlue");
                break;
            case 4:
                attributePrefab = Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/EquipAttributePurple");
                break;
            case 5:
                attributePrefab = Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/EquipAttributeOrange");
                break;
            case 6:
                attributePrefab = Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/EquipAttributeRed");
                break;
        }

        // 实例化预制体
        GameObject equipAttribute = null;
        equipAttribute = Instantiate(attributePrefab, transform);
        EquipAttributePanel equipAttributePanel = equipAttribute.GetComponent<EquipAttributePanel>();
        equipAttributePanel.tableBase = tablebase;
        equipAttributePanel.grid = bagGrid.GetComponent<BagGrid>();
        if (equipAttributePanel.orangeEntryDesc != null)
        {
            equipAttributePanel.orangeEntryDesc.text = EntryConfig.OrangeEntryAttributeDescDic[equipTable.OrangeEntry1];
        }


        //设置是否显示卸下按钮
        if (IsClickInstalled(equipTable))
        {
            equipAttributePanel.uninstallButton.gameObject.SetActive(true);
            equipAttributePanel.installButton.gameObject.SetActive(false);
            equipAttributePanel.sellButton.gameObject.SetActive(false);
        }
        else
        {
            equipAttributePanel.uninstallButton.gameObject.SetActive(false);
            equipAttributePanel.installButton.gameObject.SetActive(true);
            equipAttributePanel.sellButton.gameObject.SetActive(true);
        }

        equipAttributePanel.Init();

        Debug.Log("装备属性面板显示成功");
    }


    /// <summary>
    /// 出售所有选中类型的装备
    /// </summary>
    public void SellAllSelectedEquips(bool isWhite, bool isGreen, bool isBlue)
    {
        // 从内存中同步移除装备数据
        if (isWhite)
        {
            foreach (var item in WhiteEquipidTable)
            {
                if (item.equipid == PlayerEquipConfig.CloakId || item.equipid == PlayerEquipConfig.ClothId ||
                    item.equipid == PlayerEquipConfig.NecklaceId || item.equipid == PlayerEquipConfig.RingId ||
                    item.equipid == PlayerEquipConfig.HelmetId || item.equipid == PlayerEquipConfig.ShoeId)
                {
                    continue;
                }

                if (item.Lock)
                {
                    continue;
                }
                EquipIdList.Remove(item.equipid);
                if (PropList.ContainsKey(201))
                {
                    PropList[201].Count++;
                }
                else
                {
                    PropList.Add(201, new PropTable(PropConfig.PropType.JingCui,1,"",1,"WhiteJingCui"));
                }
            }
            WhiteEquipidTable.Clear();
        }

        if (isGreen)
        {
            foreach (var item in GreenEquipidTable)
            {
                if (item.equipid == PlayerEquipConfig.CloakId || item.equipid == PlayerEquipConfig.ClothId ||
                    item.equipid == PlayerEquipConfig.NecklaceId || item.equipid == PlayerEquipConfig.RingId ||
                    item.equipid == PlayerEquipConfig.HelmetId || item.equipid == PlayerEquipConfig.ShoeId)
                {
                    continue;
                }
                if (item.Lock)
                {
                    continue;
                }
                EquipIdList.Remove(item.equipid);
                if (PropList.ContainsKey(202))
                {
                    PropList[202].Count++;
                }
                else
                {
                    PropList.Add(202, new PropTable(PropConfig.PropType.JingCui,1,"",2,"GreenJingCui"));
                }
            }
            GreenEquipidTable.Clear();
        }

        if (isBlue)
        {
            foreach (var item in BlueEquipidTable)
            {
                if (item.equipid == PlayerEquipConfig.CloakId || item.equipid == PlayerEquipConfig.ClothId ||
                    item.equipid == PlayerEquipConfig.NecklaceId || item.equipid == PlayerEquipConfig.RingId ||
                    item.equipid == PlayerEquipConfig.HelmetId || item.equipid == PlayerEquipConfig.ShoeId)
                {
                    continue;
                }
                if (item.Lock)
                {
                    continue;
                }
                EquipIdList.Remove(item.equipid);
                if (PropList.ContainsKey(203))
                {
                    PropList[203].Count++;
                }
                else
                {
                    PropList.Add(203, new PropTable(PropConfig.PropType.JingCui,1,"",3,"BlueJingCui"));
                }
            }
            BlueEquipidTable.Clear();
        }

        StoreController.S.SaveStoreData();
    }


    public void SellAllSelectedSourceStones(bool isWhite, bool isGreen, bool isBlue)
    {
        // 从内存中同步移除装备数据
        if (isWhite)
        {
            // 从内存中移除白色装备
            foreach (var item in WhiteWeaponSourceStoneTable)
            {
                SourceStoneTable.Remove(item);
            }

            Debug.Log("已从内存中移除白色源石。");
            WhiteWeaponSourceStoneTable.Clear();
        }

        if (isGreen)
        {
            // 从内存中移除绿色装备
            foreach (var item in GreenWeaponSourceStoneTable)
            {
                SourceStoneTable.Remove(item);
            }

            Debug.Log("已从内存中移除绿色源石。");
            GreenWeaponSourceStoneTable.Clear();

        }

        if (isBlue)
        {
            // 从内存中移除蓝色装备
            foreach (var item in BlueWeaponSourceStoneTable)
            {
                SourceStoneTable.Remove(item);
            }

            Debug.Log("已从内存中移除蓝色源石。");
            BlueWeaponSourceStoneTable.Clear();
        }

    }

}
