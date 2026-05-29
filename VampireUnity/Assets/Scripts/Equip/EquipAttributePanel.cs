using System;
using Mysql;
using Prop.BaoShi;
using TMPro;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EquipAttributePanel : MonoBehaviour
{
    public Button MaskButton;
    
    public Button exitButton;
    public Button installButton;
    public Button sellButton;
    public Button uninstallButton;

    [NonSerialized]public TableBase tableBase;
    [NonSerialized]public BagGrid grid;

    public TextMeshProUGUI equipName;
    public TextMeshProUGUI quality;
    public Text baseAttributeText1;
    public Text baseAttributeText2;
    public TextMeshProUGUI baseAttributeCount1;
    public TextMeshProUGUI baseAttributeCount2;
    public Image equipBg;
    public Image equipImage;

    public GameObject fuJiaAttributeContent;
    public TextMeshProUGUI orangeEntryDesc;

    public Text level;

    public GameObject kongListContent;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void SetFuJiaAttribute(EquipTable equip)
    {
        foreach (Transform child in fuJiaAttributeContent.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (var item in equip.defenseEntryInfos)
        {
            var fuJiaAttributeItem =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/FuJiaAttributeItem"),fuJiaAttributeContent.transform);
            fuJiaAttributeItem.transform.Find("BaseAttributeName").GetComponent<Text>().text =
                EntryConfig.DefenseEntryNameDic[item.DefenseEntry];
            fuJiaAttributeItem.transform.Find("BaseAttributeCount").GetComponent<TextMeshProUGUI>().text =
                item.Value + "%";
        }
                
        foreach (var item in equip.damageEntryInfos)
        {
            var fuJiaAttributeItem =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/FuJiaAttributeItem"),fuJiaAttributeContent.transform);
            fuJiaAttributeItem.transform.Find("BaseAttributeName").GetComponent<Text>().text =
                EntryConfig.DamageEntryNameDic[item.DamageEntry];
            fuJiaAttributeItem.transform.Find("BaseAttributeCount").GetComponent<TextMeshProUGUI>().text =
                item.Value + "%";
        }
    }

    public void SetKong()
    {
        if (tableBase.Quality == 1)
        {
            return;
        }
        EquipTable equip=(EquipTable)tableBase;

        foreach (Transform item in kongListContent.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in equip.BaoShiDic)
        {
            EquipKong baoShiKong=Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/EquipKong"),kongListContent.transform).GetComponent<EquipKong>();
            baoShiKong.SetKong(item.Value);
        }
    }
    public void Init()
    {
        EquipTable equip=(EquipTable)tableBase;
        if (equip == null)
        {
            return;
        }
        //获取装备名
        SetKong();
        if (equip.OrangeEntry1 == EntryConfig.OrangeEntry.None)
        {
            equipName.text = EquipName.EquipNameDic[equip.EquipName];
        }
        else
        {
            equipName.text = EntryConfig.OrangeIdNameDic[equip.orangeid];
        }
        equipImage.sprite=ResourcesConfig.GetEquipSprite(equip);
        level.text = equip.EquipLevel.ToString();

        //基础属性
        if (equip.EquipType == PlayerEquipConfig.EquipType.Necklace || equip.EquipType == PlayerEquipConfig.EquipType.Cloak || equip.EquipType == PlayerEquipConfig.EquipType.Ring)
        {
            baseAttributeText1.text = "攻击 :";
            baseAttributeText2.text = "暴击 :";
            baseAttributeCount1.text = Mathf.RoundToInt(equip.Damage).ToString();
            baseAttributeCount2.text = Mathf.RoundToInt(equip.CRIT).ToString();
        }
        else
        {
            baseAttributeText1.text = "生命值 :";
            baseAttributeText2.text = "防御 :";
            baseAttributeCount1.text = Mathf.RoundToInt(equip.HP).ToString();
            baseAttributeCount2.text = Mathf.RoundToInt(equip.Defense).ToString();
        }
    }
    
    
    public void UninstallE()
    {
        EquipTable equip=(EquipTable)tableBase;
        switch (equip.EquipType)
        {
            case PlayerEquipConfig.EquipType.Cloth:
                // 使用当前面板关联的 grid 来隐藏提示，而不是依赖 PlayerClothGrid，避免其未初始化导致空引用
                if (grid != null && grid.E != null)
                {
                    grid.E.gameObject.SetActive(false);
                }
                BagController.S.PlayerClothGrid = null;
                PlayerEquipConfig.ClothId = 0;
                break;
            case PlayerEquipConfig.EquipType.Shoe:

                if (grid != null && grid.E != null)
                {
                    grid.E.gameObject.SetActive(false);
                }
                BagController.S.PlayerShoeGrid = null;
                PlayerEquipConfig.ShoeId = 0;

                break;
            case PlayerEquipConfig.EquipType.Ring:

                if (grid != null && grid.E != null)
                {
                    grid.E.gameObject.SetActive(false);
                }
                BagController.S.PlayerRingGrid = null;
                PlayerEquipConfig.RingId = 0;

                break;
            case PlayerEquipConfig.EquipType.Necklace:

                if (grid != null && grid.E != null)
                {
                    grid.E.gameObject.SetActive(false);
                }
                BagController.S.PlayerNecklaceGrid = null;
                PlayerEquipConfig.NecklaceId = 0;
                break;
            case PlayerEquipConfig.EquipType.Helmet:

                if (grid != null && grid.E != null)
                {
                    grid.E.gameObject.SetActive(false);
                }
                BagController.S.PlayerHelmetGrid = null;
                PlayerEquipConfig.HelmetId = 0;

                break;
            case PlayerEquipConfig.EquipType.Cloak:

                if (grid != null && grid.E != null)
                {
                    grid.E.gameObject.SetActive(false);
                }
                BagController.S.PlayerCloakGrid = null;
                PlayerEquipConfig.CloakId = 0;

                break;
        }
    }
    
    void Start()
    {
        
        // 退出按钮
        if (exitButton != null)
        {
            // 移除旧的监听器
            exitButton.onClick.RemoveAllListeners();
            
            exitButton.onClick.AddListener(() =>
            {
                Destroy(gameObject);
            });
        }
        
        
        if (MaskButton != null)
        {
            // 移除旧的监听器
            MaskButton.onClick.RemoveAllListeners();
            
            MaskButton.onClick.AddListener(() =>
            {
                Destroy(gameObject);
            });
        }
        
        
        
        if (uninstallButton != null)
        {
            // 移除旧的监听器
            uninstallButton.onClick.RemoveAllListeners();
            
            uninstallButton.onClick.AddListener(() =>
            {
                Scene active = SceneManager.GetActiveScene();
                if (active.name == "FightScene") 
                {
                    ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"战斗场景不能更换装备");
                    return;
                }
                    UninstallE();
                    BagController.S.UnInstallPlayerWearGrid(grid);
                    BagController.S.RefreshPlayerEquip();    
                    StoreController.S.SaveStoreData();
                    Destroy(gameObject);
            });
        }
        
        
        // 穿戴装备按钮
        if (installButton != null)
        {
            // 移除旧的监听器
            installButton.onClick.RemoveAllListeners();
            
            installButton.onClick.AddListener(() =>
            {
                Scene active = SceneManager.GetActiveScene();
                if (active.name == "FightScene") 
                {
                  ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"战斗场景不能更换装备");
                  return;
                }
                
                    EquipTable equip = (EquipTable)tableBase;
                    if (GlobalPlayerAttribute.Level < equip.EquipLevel)
                    {
                        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"等级不足！");
                        return;
                    }
                    foreach (var item in equip.damageEntryInfos)
                    {
                        switch (item.DamageEntry)
                        {
                            case EntryConfig.DamageEntry.BloodSuck:
                                
                                break;
                        }
                    }
                    PlayerData.S.SaveWearEquip(equip.EquipType, equip.equipid);
                    StoreController.S.SaveStoreData();
                    BagController.S.InstallPlayerWearGrid(grid);
                    BagController.S.RefreshPlayerEquip();
                    BagController.S.ShowEquip();
                    Destroy(gameObject);
            });
        }
        sellButton.onClick.AddListener(() =>
        {
            EquipTable equip = (EquipTable)tableBase;
            if (equip.Lock)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"装备已锁定，无法分解");
                return;
            }
            grid.transform.Find("parent/EquipGridBG").GetComponent<Image>().color =new Color(1, 1, 1, 0);
            grid.transform.Find("parent/BagGridImage").GetComponent<Image>().color = new Color(1, 1, 1, 0);
            grid.transform.Find("parent/Count").GetComponent<Text>().text = null;
            BagController.S.EquipIdList.Remove(equip.equipid);
            switch (equip.Quality)
            {
                case 1:
                    if (BagController.S.PropList.ContainsKey(201))
                    {
                        BagController.S.PropList[201].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(201,new PropTable(){PropType = PropConfig.PropType.JingCui,Count = 1,Desc = "",EquipName = "WhiteJingCui",Quality = 1});
                    }
                    BagController.S.WhiteEquipidTable.Remove(equip);
                    break;
                case 2:
                    if (BagController.S.PropList.ContainsKey(202))
                    {
                        BagController.S.PropList[202].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(202,new PropTable(){PropType = PropConfig.PropType.JingCui,Count = 1,Desc = "",EquipName = "GreenJingCui",Quality = 2});
                    }                    
                    BagController.S.GreenEquipidTable.Remove(equip);
                    break;
                case 3:
                    if (BagController.S.PropList.ContainsKey(203))
                    {
                        BagController.S.PropList[203].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(203,new PropTable(){PropType = PropConfig.PropType.JingCui,Count = 1,Desc = "",EquipName = "BlueJingCui",Quality = 3});
                    }                   
                    BagController.S.BlueEquipidTable.Remove(equip);
                    break;
                case 4:
                    if (BagController.S.PropList.ContainsKey(204))
                    {
                        BagController.S.PropList[204].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(204,new PropTable(){PropType = PropConfig.PropType.JingCui,Count = 1,Desc = "",EquipName = "PurpleJingCui",Quality = 4});
                    }                    
                    BagController.S.PurpleEquipidTable.Remove(equip);
                    break;
                case 5:
                    if (BagController.S.PropList.ContainsKey(205))
                    {
                        BagController.S.PropList[205].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(205,new PropTable(){PropType = PropConfig.PropType.JingCui,Count = 1,Desc = "",EquipName = "OrangeJingCui",Quality = 5});
                    }                   
                    BagController.S.OrangeEquipidTable.Remove(equip);
                    break;
                case 6:
                    if (BagController.S.PropList.ContainsKey(206))
                    {
                        BagController.S.PropList[206].Count += 1;
                    }
                    else
                    {
                        BagController.S.PropList.Add(206,new PropTable(){PropType = PropConfig.PropType.JingCui,Count = 1,Desc = "",EquipName = "RedJingCui",Quality = 6});
                    }                    
                    BagController.S.RedEquipidTable.Remove(equip);
                    break;
            }
            BagController.S.EquipIdList.Remove(equip.equipid);
            StoreController.S.SaveStoreData();
            Destroy(gameObject);
        });
       
    }
}
