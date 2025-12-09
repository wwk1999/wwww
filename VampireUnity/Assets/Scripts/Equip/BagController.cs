using System;
using System.Collections.Generic;
using System.Linq;
using Gloabl;
using Mysql;
using MySqlConnector;
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
    [NonSerialized]public bool IsInit = false;
    [NonSerialized] public Dictionary<string, Sprite>EquipidSpriteConfig = new Dictionary<string, Sprite>(); //装备的Sprite配置
    [NonSerialized] public Dictionary<int, Sprite> EquipidSprite = new Dictionary<int, Sprite>(); //背包里所有的装备的Sprite
    //[NonSerialized] public List<EquipTable> EquipidTable = new List<EquipTable>(); //背包里所有的装备的属性
    public Dictionary<int,EquipTable> EquipIdList
    {
        get => EquipIDData.S.equipIds;
        set => EquipIDData.S.equipIds = value;
    }

    public Dictionary<PropItem, PropTable> PropList
    {
        get => EquipIDData.S.propTables;
        set => EquipIDData.S.propTables = value;
    }
    
    [NonSerialized] public List<EquipTable> WhiteEquipidTable = new List<EquipTable>(); //背包里所有的白色装备
    [NonSerialized] public List<EquipTable> GreenEquipidTable = new List<EquipTable>(); //背包里所有的绿色装备
    [NonSerialized] public List<EquipTable> BlueEquipidTable = new List<EquipTable>(); //背包里所有的蓝色色装备
    [NonSerialized] public List<EquipTable> PurpleEquipidTable = new List<EquipTable>(); //背包里所有的紫色色装备
    [NonSerialized] public List<EquipTable> OrangeEquipidTable = new List<EquipTable>(); //背包里所有的橙色装备
    
    //源石相关
    [NonSerialized]public List<SourceStoneTable>SourceStoneTable = new List<SourceStoneTable>();//源石列表
    
    [NonSerialized] public List<SourceStoneTable> WhiteWeaponSourceStoneTable = new List<SourceStoneTable>(); //背包里所有的白色源石
    [NonSerialized] public List<SourceStoneTable> GreenWeaponSourceStoneTable = new List<SourceStoneTable>(); //背包里所有的绿色源石
    [NonSerialized] public List<SourceStoneTable> BlueWeaponSourceStoneTable = new List<SourceStoneTable>(); //背包里所有的蓝色源石
    [NonSerialized] public List<SourceStoneTable> PurpleWeaponSourceStoneTable = new List<SourceStoneTable>(); //背包里所有的紫色源石
    [NonSerialized] public List<SourceStoneTable> OrangeWeaponSourceStoneTable = new List<SourceStoneTable>(); //背包里所有的橙色源石
    
    
    
    [NonSerialized] public Dictionary<string,int> MaxEquipid = new Dictionary<string,int>();//存储最大的装备ID

    

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
    [NonSerialized] public  int PageNum = 1;//第几页   
    
    
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

    
    //player穿的装备的属性
    
    [NonSerialized] public BagGrid PlayerClothGrid=new BagGrid();
    [NonSerialized] public BagGrid PlayerCloakGrid=new BagGrid();
    [NonSerialized] public BagGrid PlayerRingGrid=new BagGrid();
    [NonSerialized] public BagGrid PlayerNecklaceGrid=new BagGrid();
    [NonSerialized] public BagGrid PlayerShoeGrid=new BagGrid();
    [NonSerialized] public BagGrid PlayerHelmetGrid=new BagGrid();




    protected override void Awake()
    {
        Debug.Log("BagController Awake方法被调用");
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
        blueBg =ResourcesConfig.BlueBg;
        purpleBg = ResourcesConfig.PurpleBg;
        orangeBg = ResourcesConfig.OrangeBg;
        
        whiteMaterial= ResourcesConfig.WhiteMaterial;
        greenMaterial= ResourcesConfig.GreenMaterial;
        blueMaterial= ResourcesConfig.BlueMaterial;
        purpleMaterial= ResourcesConfig.PurpleMaterial;
        orangeMaterial= ResourcesConfig.OrangeMaterial;
        
        
        // 检查装备背景图是否加载成功
        if (whiteBg == null || greenBg == null || blueBg == null || purpleBg == null || orangeBg == null)
        {
            Debug.LogError($"InitBag出错: 装备背景图加载失败，whiteBg: {whiteBg != null}, greenBg: {greenBg != null}, blueBg: {blueBg != null}, purpleBg: {purpleBg != null}, orangeBg: {orangeBg != null}");
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
            playerCloak =bag.GetComponent<BagPanel>().playerCloak;
            playerRing = bag.GetComponent<BagPanel>().playerRing;
            playerNecklace = bag.GetComponent<BagPanel>().playerNecklace;
            playerShoe = bag.GetComponent<BagPanel>().playerShoe;
            playerHelmet = bag.GetComponent<BagPanel>().playerHelmet;
            
            if (playerCloth == null || playerCloak == null || playerRing == null || 
                playerNecklace == null || playerShoe == null || playerHelmet == null)
            {
                Debug.LogError($"InitBag出错: 装备槽对象缺失，playerCloth: {playerCloth != null}, playerCloak: {playerCloak != null}, playerRing: {playerRing != null}, playerNecklace: {playerNecklace != null}, playerShoe: {playerShoe != null}, playerHelmet: {playerHelmet != null}");
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
            EquipidSpriteConfig.Add("PrimaryNecklace",ResourcesConfig.PrimaryNecklace);
        }
        if (!EquipidSpriteConfig.ContainsKey("PrimaryShoe"))
        {
            EquipidSpriteConfig.Add("PrimaryShoe", ResourcesConfig.PrimaryShoe);
        }
        if (!EquipidSpriteConfig.ContainsKey("PrimaryHelmet"))
        {
            EquipidSpriteConfig.Add("PrimaryHelmet",ResourcesConfig.PrimaryHelmet);
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
            EquipidSpriteConfig.Add("TreeManRing",ResourcesConfig.TreeManRing);
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
            EquipidSpriteConfig.Add("GreenRing",ResourcesConfig.GreenRing);
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
            EquipidSpriteConfig.Add("BlueRing",ResourcesConfig.BlueRing);
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
            EquipidSpriteConfig.Add("HuoShanRing",ResourcesConfig.HuoShanRing);
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
            EquipidSpriteConfig.Add("ZhaoZeRing",ResourcesConfig.ZhaoZeRing);
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
    
    

    /// <summary>
    /// 出售所有白色装备
    /// </summary>
    public void SellAllWhite()
    {
        // 检查 WhiteEquipidTable 是否为空
        if (WhiteEquipidTable.Count == 0)
        {
            Debug.LogWarning("No white equips to delete.");
            return;
        }
        
        
        // 同步处理Unity部分：清除内存中的数据
        foreach (var equip in WhiteEquipidTable)
        {
            EquipIdList.Remove(equip.equipid); // 删除 EquipIdList 中的记录
            // EquipidSprite.Remove(equip); // 删除 EquipidSprite 中的记录
        }

        WhiteEquipidTable.Clear(); // 清空白色装备表
        Debug.Log("已从内存中移除白色装备。");
        
        // 启动异步任务处理MySQL操作
       // System.Threading.Tasks.Task.Run(() => DeleteWhiteEquipsFromDatabase(equipIdsToRemove));
    }

    
    
    /// <summary>
    /// 出售所有绿色装备
    /// </summary>
    public void SellAllGreen()
    {
        // 检查 GreenEquipidTable 是否为空
        if (GreenEquipidTable.Count == 0)
        {
            Debug.LogWarning("No Green equips to delete.");
            return;
        }
        
        
        // 同步处理Unity部分：清除内存中的数据
        foreach (var equip in GreenEquipidTable)
        {
            EquipIdList.Remove(equip.equipid); // 删除 EquipIdList 中的记录
           // EquipidSprite.Remove(equipId); // 删除 EquipidSprite 中的记录
        }

        GreenEquipidTable.Clear(); // 清空绿色装备表
        Debug.Log("已从内存中移除绿色装备。");
        
        // 启动异步任务处理MySQL操作
        //System.Threading.Tasks.Task.Run(() => DeleteGreenEquipsFromDatabase(equipIdsToRemove));
    }

    
    
    /// <summary>
    /// 出售所有蓝色装备
    /// </summary>
    public void SellAllBlue()
    {
        // 检查 BlueEquipidTable 是否为空
        if (BlueEquipidTable.Count == 0)
        {
            Debug.LogWarning("No blue equips to delete.");
            return;
        }
        
        // 同步处理Unity部分：清除内存中的数据
        foreach (var equip in BlueEquipidTable)
        {
            EquipIdList.Remove(equip.equipid); // 删除 EquipIdList 中的记录
            //EquipidSprite.Remove(equip); // 删除 EquipidSprite 中的记录
        }

        BlueEquipidTable.Clear(); // 清空蓝色装备表
        Debug.Log("已从内存中移除蓝色装备。");
        
        // 启动异步任务处理MySQL操作
        //System.Threading.Tasks.Task.Run(() => DeleteBlueEquipsFromDatabase(equipIdsToRemove));
    }
    
    
    /// <summary>
    /// 显示玩家面板
    /// </summary>
    public void ShowPlayerPanel()
    {
        IsShowPlayerPanel = true;
        PlayerPanel.gameObject.SetActive(true);
        AttributePanel.gameObject.SetActive(false);
    }

    /// <summary>
    /// 显示属性面板
    /// </summary>
    public void ShowAttributePanel()
    {
        IsShowPlayerPanel = false;
        PlayerPanel.gameObject.SetActive(false);
        AttributePanel.gameObject.SetActive(true);
    }

    /// <summary>
    /// 生成蒙层
    /// </summary>
    public void CreateMaskLayer()
    {
        Debug.Log("开始创建MaskLayer");
        
        // 先检查是否已有蒙层，如果有就先销毁
        if (MaskLayer != null)
        {
            Debug.LogWarning("CreateMaskLayer警告: 已存在MaskLayer，先销毁旧的");
            DestroyMaskLayer();
        }
        
        GameObject maskLayerPrefab = Resources.Load<GameObject>("Prefabs/Equip/MaskLayer");
        if (maskLayerPrefab == null)
        {
            Debug.LogError("CreateMaskLayer出错: 找不到MaskLayer预制体");
            return;
        }
        
        try
        {
            MaskLayer = Instantiate(maskLayerPrefab, transform);
            Debug.Log("MaskLayer创建成功");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"CreateMaskLayer出错: 实例化MaskLayer失败: {e.Message}");
        }
    }

    /// <summary>
    /// 销毁蒙层
    /// </summary>
    public void DestroyMaskLayer()
    {
        Debug.Log("开始销毁MaskLayer");
        
        if (MaskLayer == null)
        {
            Debug.LogWarning("DestroyMaskLayer警告: MaskLayer已经是null");
            return;
        }
        
        Destroy(MaskLayer);
        MaskLayer = null;  // 重要：确保引用被清除
        
        Debug.Log("MaskLayer已销毁并置为null");
    }

    public void SetPlayerWearGrid(BagGrid equipGrid)
    {
        EquipTable equipTable = equipGrid.tableBase as EquipTable;
        switch (equipTable.equip_type_id)
        {
            case 1:
                if(PlayerEquipConfig.CloakId== equipTable.equipid)
                {
                    PlayerCloakGrid = equipGrid;
                }
                break;
            case 2:
                if(PlayerEquipConfig.ClothId== equipTable.equipid)
                {
                    PlayerClothGrid = equipGrid;
                }
                break;
            case 3:
                if(PlayerEquipConfig.HelmetId== equipTable.equipid)
                {
                    PlayerHelmetGrid = equipGrid;
                }
                break;
            case 4:
                if(PlayerEquipConfig.NecklaceId== equipTable.equipid)
                {
                    PlayerNecklaceGrid= equipGrid;
                }
                break;
            case 5:
                if(PlayerEquipConfig.RingId== equipTable.equipid)
                {
                    PlayerRingGrid = equipGrid;
                }
                break;
            case 6:
                if(PlayerEquipConfig.ShoeId== equipTable.equipid)
                {
                    PlayerShoeGrid = equipGrid;
                }
                break;
        }
    }


    /// <summary>
    /// 显示背包的装备，源石和道具
    /// </summary>
    public void ShowEquip()
    {
        Debug.Log("开始执行ShowEquip方法");
        // 检查bag是否为空
        if (bag == null)
        {
            Debug.LogError("ShowEquip出错: bag对象为null");
            return;
        }
        

        // 查找装备内容面板
        Transform bagPanelContent = bag.GetComponent<BagPanel>().content.transform;

        if (bagPanelContent == null)
        {
            Debug.LogError("ShowEquip出错: 找不到装备内容面板路径 Bag/Mask/BagBg/BagBG (1)/EquipPanel/BagScrollView/Viewport/EquipContent");
            return;
        }

        
        GameObject equipContent = bagPanelContent.gameObject;
        
        // 清空装备内容面板
        foreach (Transform child in equipContent.transform)
        {
            Destroy(child.gameObject);
        }
        
        // 检查装备列表是否为空
        if (EquipIdList == null)
        {
            Debug.LogError("ShowEquip出错: EquipIdList为null");
            return;
        }

        
        
        // 检查背包格子预制体是否为空
        if (bagGrid == null)
        {
            Debug.LogError("ShowEquip出错: bagGrid预制体为null");
            return;
        }

        if (equipContent != null)
        {
            foreach (Transform item in equipContent.transform)
            {
                Destroy(item.gameObject);
            }
        }
        // 计算显示的装备范围
        int startIndex = (PageNum - 1) * 35;
        int endIndex = Mathf.Min(PageNum * 35, EquipIdList.Count);

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
                    SetPlayerWearGrid(bagGridComponent);

                    // 设置装备背景颜色
                    Transform equipGridBGTransform = bagGridins.transform.Find("parent/EquipGridBG");

                    Image equipGridBGImage = equipGridBGTransform.GetComponent<Image>();

                    switch (list[i].Quality)
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
                    GlobalPlayerAttribute.RefreshFuJiaAttribute();
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"ShowEquip异常: 处理索引 {i} 的装备时出错: {e.Message}\n{e.StackTrace}");
                }
            }
            SetE();
        }else if (bag.GetComponent<BagPanel>().currentBagType == 2)//如果是显示源石
        {
            foreach (var item in SourceStoneTable)
            {
                // 实例化背包格子
                GameObject bagGridins = Instantiate(bagGrid, equipContent.transform);
                // 设置装备图标
                Transform bagGridImageTransform = bagGridins.transform.Find("parent/BagGridImage");

                Button bagGridButton = bagGridImageTransform.GetComponent<Button>();

                bagGridButton.image.sprite = WeaponSourceConfig.GetWeaponSourceStoneSprite(item.SourceStoneId);
                
                // 设置装备属性图标
                BagGrid bagGridComponent = bagGridins.GetComponent<BagGrid>();

                bagGridComponent.equipAttributeImage =
                    WeaponSourceConfig.GetWeaponSourceStoneSprite(item.SourceStoneId);
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

    public void SetE()
    {
        if (PlayerCloakGrid!=null)
        {
            PlayerCloakGrid.E.gameObject.SetActive(true);
        }
        if (PlayerClothGrid!=null)
        {
            PlayerClothGrid.E.gameObject.SetActive(true);
        }
        if (PlayerRingGrid!=null)
        {
            PlayerRingGrid.E.gameObject.SetActive(true);
        }
        if (PlayerNecklaceGrid!=null)
        {
            PlayerNecklaceGrid.E.gameObject.SetActive(true);
        }
        if (PlayerShoeGrid!=null)
        {
            PlayerShoeGrid.E.gameObject.SetActive(true);
        }
        if (PlayerHelmetGrid!=null)
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

    public void PlayEdge(Animator animator,int quality)
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

    public void RefreshPlayerEquip()
    {
        GlobalPlayerAttribute.RefreshFuJiaAttribute();
        if (PlayerEquipConfig.CloakId == 0)
        {
            IsInstallCloak = false;
            playerCloak.transform.Find("parent/Image").gameObject.SetActive(false);
            playerCloak.transform.Find("parent/ImageBG").gameObject.SetActive(false);
            playerCloak.transform.Find("parent/Edge").gameObject.SetActive(false);
        }
        else
        {
            IsInstallCloak = true;
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
            playerCloth.transform.Find("parent/Image").gameObject.SetActive(false);
            playerCloth.transform.Find("parent/ImageBG").gameObject.SetActive(false);
            playerCloth.transform.Find("parent/Edge").gameObject.SetActive(false);

        }
        else
        {
            IsInstallCloth = true;
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
            playerShoe.transform.Find("parent/Image").gameObject.SetActive(false);
            playerShoe.transform.Find("parent/ImageBG").gameObject.SetActive(false);
            playerShoe.transform.Find("parent/Edge").gameObject.SetActive(false);

        }
        else
        {
            IsInstallShoe = true;
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
            playerHelmet.transform.Find("parent/Image").gameObject.SetActive(false);
            playerHelmet.transform.Find("parent/ImageBG").gameObject.SetActive(false);
            playerHelmet.transform.Find("parent/Edge").gameObject.SetActive(false);

        }
        else
        {
            IsInstallHelmet = true;
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
            playerNecklace.transform.Find("parent/Image").gameObject.SetActive(false);
            playerNecklace.transform.Find("parent/ImageBG").gameObject.SetActive(false);
            playerNecklace.transform.Find("parent/Edge").gameObject.SetActive(false);
        }
        else
        {
            IsInstallNecklace = true;
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
            playerRing.transform.Find("parent/Image").gameObject.SetActive(false);
            playerRing.transform.Find("parent/ImageBG").gameObject.SetActive(false);
            playerRing.transform.Find("parent/Edge").gameObject.SetActive(false);
        }
        else
        {
            IsInstallRing = true;
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
    }
    
    
    public bool IsClickInstalled(EquipTable equiptable)
    {
        switch (equiptable.equip_type_id)
        {
            case 1:
                return equiptable.equipid== PlayerEquipConfig.CloakId;
            case 2:
                return equiptable.equipid== PlayerEquipConfig.ClothId;
            case 3:
                return equiptable.equipid== PlayerEquipConfig.HelmetId;
            case 4:
                return equiptable.equipid== PlayerEquipConfig.NecklaceId;
            case 5:
                return equiptable.equipid== PlayerEquipConfig.RingId;
            case 6:
                return equiptable.equipid== PlayerEquipConfig.ShoeId;
            default:
                return false;
        }
    }

    public void ShowEquipAttributePanel(TableBase tablebase, EquipType EquipType,GameObject bagGrid )
    {
        if (EquipType == EquipType.Equip)
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
            if (attributePrefab == null)
            {
                Debug.LogError("ShowEquipAttributePanel出错: 找不到EquipAttribute预制体");
                DestroyMaskLayer();
                return;
            }
            
            // 实例化预制体
            GameObject equipAttribute = null;
            try
            {
                equipAttribute = Instantiate(attributePrefab, transform);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"ShowEquipAttributePanel出错: 实例化预制体异常: {e.Message}\n{e.StackTrace}");
                DestroyMaskLayer();
                return;
            }
            
            equipAttribute.GetComponent<EquipAttributePanel>().tableBase = tablebase;
            equipAttribute.GetComponent<EquipAttributePanel>().grid = bagGrid.GetComponent<BagGrid>();
            
            
            //设置是否显示卸下按钮
             if(IsClickInstalled(equipTable))
             {
                 equipAttribute.GetComponent<EquipAttributePanel>().uninstallButton.gameObject.SetActive(true);  
                 equipAttribute.GetComponent<EquipAttributePanel>().installButton.gameObject.SetActive(false);      
                 equipAttribute.GetComponent<EquipAttributePanel>().sellButton.gameObject.SetActive(false);      
             }else
             {
                 equipAttribute.GetComponent<EquipAttributePanel>().uninstallButton.gameObject.SetActive(false);  
                 equipAttribute.GetComponent<EquipAttributePanel>().installButton.gameObject.SetActive(true);      
                 equipAttribute.GetComponent<EquipAttributePanel>().sellButton.gameObject.SetActive(true);      
             }
             equipAttribute.GetComponent<EquipAttributePanel>().Init();
            
            Debug.Log("装备属性面板显示成功");
        }
        else if (EquipType == EquipType.SourceStone) // 源石
        {
            SourceStoneTable sourceStoneTable = (SourceStoneTable)tablebase;
            // 加载预制体
            GameObject attributePrefab = Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute");
            if (attributePrefab == null)
            {
                Debug.LogError("ShowEquipAttributePanel出错: 找不到EquipAttribute预制体");
                DestroyMaskLayer();
                return;
            }

            // 实例化预制体
            GameObject equipAttribute = null;
            try
            {
                equipAttribute = Instantiate(attributePrefab, transform);
                
                // 隐藏装备和出售按钮
                equipAttribute.transform.Find("InstallButton").gameObject.SetActive(false);
                equipAttribute.transform.Find("SellButton").gameObject.SetActive(false);
                
                 // 设置装备ID
                 equipAttribute.GetComponent<EquipAttributePanel>().tableBase = tablebase;

                // 设置源石图标
                GameObject equipAttributeEquip = equipAttribute.transform.Find("EquipAttributeEquip").gameObject;
                GameObject equipAttributeEquipImage = equipAttributeEquip.transform.Find("EquipAttributeEquipImage").gameObject;
                equipAttributeEquipImage.GetComponent<Image>().sprite =  WeaponSourceConfig.GetWeaponSourceStoneSprite(sourceStoneTable.SourceStoneId);
                // 设置源石名称
                GameObject equipAttributeName = equipAttribute.transform.Find("EquipAttributeName").gameObject;
                equipAttributeName.GetComponent<Text>().text = sourceStoneTable.SourceStoneName;
                
                // 显示源石介绍
                GameObject equipAttributeContent = equipAttribute.transform.Find("ScrollView").Find("Viewport").Find("Content").gameObject;
                
                // 清空旧的内容
                foreach (Transform child in equipAttributeContent.transform)
                {
                    Destroy(child.gameObject);
                }
                
                // 添加源石介绍
                GameObject EquipAttributeItem = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"),
                    equipAttributeContent.transform);
                    
                switch (sourceStoneTable.SourceStoneType)
                {
                    case 1:
                        EquipAttributeItem.GetComponent<Text>().text = SourceStoneText.WhitePenetrate;
                        break;
                    case 2:
                        EquipAttributeItem.GetComponent<Text>().text = SourceStoneText.WhiteDivision;
                        break;
                    case 3:
                        EquipAttributeItem.GetComponent<Text>().text = SourceStoneText.WhiteExtremeSpeed;
                        break;
                    case 4:
                        EquipAttributeItem.GetComponent<Text>().text = SourceStoneText.WhiteExplosion;
                        break;
                    case 5:
                        EquipAttributeItem.GetComponent<Text>().text = SourceStoneText.WhiteScale;
                        break;
                    case 6:
                        EquipAttributeItem.GetComponent<Text>().text = SourceStoneText.WhiteDuration;
                        break;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError($"ShowEquipAttributePanel出错: 设置源石属性面板异常: {e.Message}\n{e.StackTrace}");
                if (equipAttribute != null)
                {
                    Destroy(equipAttribute);
                }
                DestroyMaskLayer();
                return;
            }
            
            Debug.Log("源石属性面板显示成功");
        }
    }
    
    // 辅助方法：显示装备属性
    private void DisplayEquipAttribute(EquipTable equipTable, GameObject contentPanel)
    {
        if (equipTable.Damage != 0)
        {
            CreateAttributeItem(contentPanel, "攻击力：" + equipTable.Damage);
        }

        if (equipTable.HP != 0)
        {
            CreateAttributeItem(contentPanel, "生命值：" + equipTable.HP);
        }

        if (equipTable.Defense != 0)
        {
            CreateAttributeItem(contentPanel, "防御力：" + equipTable.Defense);
        }

        if (equipTable.CRIT != 0)
        {
            CreateAttributeItem(contentPanel, "暴击率：" + equipTable.CRIT);
        }
    }
    
    // 辅助方法：创建属性项
    private GameObject CreateAttributeItem(GameObject parent, string text)
    {
        GameObject itemPrefab = Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem");
        if (itemPrefab == null)
        {
            Debug.LogError("CreateAttributeItem出错: 找不到EquipAttributeItem预制体");
            return null;
        }
        
        GameObject item = Instantiate(itemPrefab, parent.transform);
        item.GetComponent<Text>().text = text;
        return item;
    }

    
    /// <summary>
    /// 出售所有选中类型的装备
    /// </summary>
    public void SellAllSelectedEquips(bool isWhite, bool isGreen, bool isBlue)
    {
        // 从内存中同步移除装备数据
        if(isWhite)
        {
            // 从内存中移除白色装备
            WhiteEquipidTable.RemoveAll(item =>
            {
                if (item.equipid == PlayerEquipConfig.CloakId || item.equipid == PlayerEquipConfig.ClothId ||
                    item.equipid == PlayerEquipConfig.NecklaceId || item.equipid == PlayerEquipConfig.RingId ||
                    item.equipid == PlayerEquipConfig.HelmetId || item.equipid == PlayerEquipConfig.ShoeId)
                {
                    return false;
                }
                
                EquipIdList.Remove(item.equipid);
                return true;
            });
            Debug.Log("已从内存中移除白色装备。");
        }
        
        if(isGreen)
        {
            // 从内存中移除绿色装备
            GreenEquipidTable.RemoveAll(item =>
            {
                if (item.equipid == PlayerEquipConfig.CloakId || item.equipid == PlayerEquipConfig.ClothId ||
                    item.equipid == PlayerEquipConfig.NecklaceId || item.equipid == PlayerEquipConfig.RingId ||
                    item.equipid == PlayerEquipConfig.HelmetId || item.equipid == PlayerEquipConfig.ShoeId)
                {
                    return false;
                }
                
                EquipIdList.Remove(item.equipid);
                return true;
            });
            Debug.Log("已从内存中移除绿色装备。");
        }
        if(isBlue)
        {
            // 从内存中移除蓝色装备
            BlueEquipidTable.RemoveAll(item =>
            {
                if (item.equipid == PlayerEquipConfig.CloakId || item.equipid == PlayerEquipConfig.ClothId ||
                    item.equipid == PlayerEquipConfig.NecklaceId || item.equipid == PlayerEquipConfig.RingId ||
                    item.equipid == PlayerEquipConfig.HelmetId || item.equipid == PlayerEquipConfig.ShoeId)
                {
                    return false;
                }
                
                EquipIdList.Remove(item.equipid);
                return true;
            });
            Debug.Log("已从内存中移除蓝色装备。");
        }
        StoreController.S.SaveStoreData();
    }
    
    
    public void SellAllSelectedSourceStones(bool isWhite, bool isGreen, bool isBlue)
    {
        // 从内存中同步移除装备数据
        if(isWhite)
        {
            // 从内存中移除白色装备
            foreach (var item in WhiteWeaponSourceStoneTable)
            {
                SourceStoneTable.Remove(item);
            }
            Debug.Log("已从内存中移除白色源石。");
            WhiteWeaponSourceStoneTable.Clear();
        }
        
        if(isGreen)
        {
            // 从内存中移除绿色装备
            foreach (var item in GreenWeaponSourceStoneTable)
            {
                SourceStoneTable.Remove(item);
            }
            Debug.Log("已从内存中移除绿色源石。");
            GreenWeaponSourceStoneTable.Clear();

        }
        if(isBlue)
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
