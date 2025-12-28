using System;
using Mysql;
using TMPro;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EquipAttributePanel : MonoBehaviour
{
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
    public Animator animator;

    public GameObject fuJiaAttributeContent;
    public TextMeshProUGUI orangeEntryDesc;

    public Text level;
    
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
    
    public void Init()
    {
        EquipTable equip=(EquipTable)tableBase;
        if (equip == null)
        {
            return;
        }
        //获取装备名

        if (equip.OrangeEntry1 == EntryConfig.OrangeEntry.None)
        {
            equipName.text = EquipName.EquipNameDic[equip.EquipName];
        }
        else
        {
            equipName.text = EntryConfig.OrangeEntryNameDic[equip.OrangeEntry1];
        }
        equipImage.sprite=ResourcesConfig.GetEquipSprite(equip);
        level.text = equip.EquipLevel.ToString();

        //基础属性
        if (equip.equip_type_id == 1 || equip.equip_type_id == 4 || equip.equip_type_id == 5)
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
        
        
        switch (equip.Quality)
        {
            case 1:
                quality.text = "普通";
                animator.Play("WhiteEdge");
                equipBg.sprite = ResourcesConfig.WhiteBg;
                break;
            case 2:
                quality.text = "优秀";
                animator.Play("GreenEdge");
                equipBg.sprite = ResourcesConfig.GreenBg;
                SetFuJiaAttribute(equip);
                break;
            case 3:
                quality.text = "精良";
                animator.Play("BlueEdge");
                equipBg.sprite = ResourcesConfig.BlueBg;
                SetFuJiaAttribute(equip);
                break;
            case 4:
                quality.text = "史诗";
                animator.Play("PurpleEdge");
                equipBg.sprite = ResourcesConfig.PurpleBg;
                SetFuJiaAttribute(equip);
                break;
            case 5:
                quality.text = "传说";
                animator.Play("OrangeEdge");
                equipBg.sprite = ResourcesConfig.OrangeBg;
                SetFuJiaAttribute(equip);
                break;
            case 6:
                quality.text = "神话";
                animator.Play("RedEdge");
                equipBg.sprite = ResourcesConfig.OrangeBg;
                SetFuJiaAttribute(equip);
                break;
        }
    }
    
    
    public void UninstallE()
    {
        EquipTable equip=(EquipTable)tableBase;
        switch (equip.equip_type_id)
        {
            case 2:
                // 使用当前面板关联的 grid 来隐藏提示，而不是依赖 PlayerClothGrid，避免其未初始化导致空引用
                if (grid != null && grid.E != null)
                {
                    grid.E.gameObject.SetActive(false);
                }
                BagController.S.PlayerClothGrid = null;
                PlayerEquipConfig.ClothId = 0;
                break;
            case 6:
                if (grid != null && grid.E != null)
                {
                    grid.E.gameObject.SetActive(false);
                }
                BagController.S.PlayerShoeGrid = null;
                PlayerEquipConfig.ShoeId = 0;

                break;
            case 5:
                if (grid != null && grid.E != null)
                {
                    grid.E.gameObject.SetActive(false);
                }
                BagController.S.PlayerRingGrid = null;
                PlayerEquipConfig.RingId = 0;

                break;
            case 4:
                if (grid != null && grid.E != null)
                {
                    grid.E.gameObject.SetActive(false);
                }
                BagController.S.PlayerNecklaceGrid = null;
                PlayerEquipConfig.NecklaceId = 0;
                break;
            case 3:
                if (grid != null && grid.E != null)
                {
                    grid.E.gameObject.SetActive(false);
                }
                BagController.S.PlayerHelmetGrid = null;
                PlayerEquipConfig.HelmetId = 0;

                break;
            case 1:
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
                    PlayerData.S.SaveWearEquip(equip.equip_type_id, equip.equipid);
                    StoreController.S.SaveStoreData();
                    BagController.S.ResetE();
                    BagController.S.InstallPlayerWearGrid(grid);
                    BagController.S.SetE();
                    BagController.S.RefreshPlayerEquip();
                    Destroy(gameObject);
            });
        }
        sellButton.onClick.AddListener(() =>
        {
            grid.transform.Find("parent/EquipGridBG").GetComponent<Image>().color =new Color(1, 1, 1, 0);
            grid.transform.Find("parent/BagGridImage").GetComponent<Image>().color = new Color(1, 1, 1, 0);
            grid.transform.Find("parent/Edge").GetComponent<Image>().color = new Color(1, 1, 1, 0);
            grid.transform.Find("parent/Count").GetComponent<Text>().text = null;
            EquipTable equip = (EquipTable)tableBase;
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
