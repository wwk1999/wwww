using System;
using Mysql;
using TMPro;
using Tool;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagEquipAttributeTool : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // 优先使用 inspector 指定的 prefab；若为空则尝试 Resources.Load(resourcePath)
    private string resourcePath = "Prefabs/Window/EquipAttributeWhite";
    private Vector2 offset = new Vector2(-70f, 0f); // 在右下角的偏移（像素/画布单位）

    private RectTransform rt;
    private Canvas parentCanvas;
    public BagGrid bagGrid;
    GameObject Leftinstance;
    GameObject Rightinstance;



    void Awake()
    {
        rt = GetComponent<RectTransform>();
        parentCanvas = GetComponentInParent<Canvas>();
        if (parentCanvas == null)
            Debug.LogWarning("EquipAttributeHover: 没有在父级中找到 Canvas。");
    }
    
    
    public void SetFuJiaAttribute(EquipTable equip,BagEquipAttributeInfo bagEquipAttributeInfo)
    {
        foreach (Transform child in bagEquipAttributeInfo.fuJiaAttributeContent.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (var item in equip.defenseEntryInfos)
        {
            var fuJiaAttributeItem =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/FuJiaAttributeItem"),bagEquipAttributeInfo.fuJiaAttributeContent.transform);
            fuJiaAttributeItem.transform.Find("BaseAttributeName").GetComponent<Text>().text =
                EntryConfig.DefenseEntryNameDic[item.DefenseEntry];
            fuJiaAttributeItem.transform.Find("BaseAttributeCount").GetComponent<TextMeshProUGUI>().text =
                item.Value + "%";
        }
                
        foreach (var item in equip.damageEntryInfos)
        {
            var fuJiaAttributeItem =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/FuJiaAttributeItem"),bagEquipAttributeInfo.fuJiaAttributeContent.transform);
            fuJiaAttributeItem.transform.Find("BaseAttributeName").GetComponent<Text>().text =
                EntryConfig.DamageEntryNameDic[item.DamageEntry];
            fuJiaAttributeItem.transform.Find("BaseAttributeCount").GetComponent<TextMeshProUGUI>().text =
                item.Value + "%";
        }
    }
    
    public void SetKong(GameObject instance)
    {
        EquipTable equip = bagGrid.tableBase as EquipTable;
        BagEquipAttributeInfo bagEquipAttributeInfo=instance.GetComponent<BagEquipAttributeInfo>();
        foreach (Transform item in bagEquipAttributeInfo.kongListContent.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in equip.BaoShiDic)
        {
            EquipKong baoShiKong=Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute/EquipKong"),bagEquipAttributeInfo.kongListContent.transform).GetComponent<EquipKong>();
            baoShiKong.SetKong(item.Value);
        }
    }

    public void ShowEquipAttriute(EquipTable equipTable,bool isInstall)
    {
         GameObject prefab = null;
         GameObject instance = null;
            switch (equipTable.Quality)
            {
                case 1:
                    prefab = Resources.Load<GameObject>("Prefabs/Window/EquipAttributeWhite");
                    break;
                case 2:
                    prefab = Resources.Load<GameObject>("Prefabs/Window/EquipAttributeGreen");
                    break;
                case 3:
                    prefab = Resources.Load<GameObject>("Prefabs/Window/EquipAttributeBlue");
                    break;
                case 4:
                    prefab = Resources.Load<GameObject>("Prefabs/Window/EquipAttributePurple");
                    break;
                case 5:
                    prefab = Resources.Load<GameObject>("Prefabs/Window/EquipAttributeOrange");
                    break;
                case 6:
                    prefab = Resources.Load<GameObject>("Prefabs/Window/EquipAttributeRed");
                    break;
            }
        
        if (prefab == null)
        {
            Debug.LogWarning($"EquipAttributeHover: 无法找到预制体（请在 inspector 指定或放入 Resources/{resourcePath}）");
            return;
        }

        // 实例化到 Canvas 下（保证是 UI）
        var canvasRect = parentCanvas.GetComponent<RectTransform>();
        if (!isInstall)
        {
            Rightinstance = Instantiate(prefab, parentCanvas.transform);
            instance = Rightinstance;
        }
        else
        {
            Leftinstance = Instantiate(prefab, parentCanvas.transform);
            instance = Leftinstance;

        }

        BagEquipAttributeInfo bagEquipAttributeInfo=instance.GetComponent<BagEquipAttributeInfo>();
        if (equipTable.Quality >= 2)
        {
            SetKong(instance); 
        }
        
        if (equipTable.OrangeEntry1 == EntryConfig.OrangeEntry.None)
        {
            bagEquipAttributeInfo.equipName.text = EquipName.EquipNameDic[equipTable.EquipName];
        }
        else
        {
            bagEquipAttributeInfo.equipName.text = EntryConfig.OrangeIdNameDic[equipTable.orangeid];
        }

        if (bagEquipAttributeInfo.orangeEntryDesc != null)
        {
            bagEquipAttributeInfo.orangeEntryDesc.text = EntryConfig.OrangeIdDescDic[equipTable.orangeid];
        }
        bagEquipAttributeInfo.equipImage.sprite=ResourcesConfig.GetEquipSprite(equipTable);
        bagEquipAttributeInfo.level.text = equipTable.EquipLevel.ToString();
        
        //基础属性
        if (equipTable.EquipType == PlayerEquipConfig.EquipType.Cloak || equipTable.EquipType == PlayerEquipConfig.EquipType.Necklace || equipTable.EquipType == PlayerEquipConfig.EquipType.Ring)
        {
            bagEquipAttributeInfo.baseAttributeText1.text = "攻击 :";
            bagEquipAttributeInfo.baseAttributeText2.text = "暴击 :";
            bagEquipAttributeInfo.baseAttributeCount1.text = Mathf.RoundToInt(equipTable.Damage).ToString();
            bagEquipAttributeInfo.baseAttributeCount2.text = Mathf.RoundToInt(equipTable.CRIT).ToString();
        }
        else
        {
            bagEquipAttributeInfo.baseAttributeText1.text = "生命值 :";
            bagEquipAttributeInfo.baseAttributeText2.text = "防御 :";
            bagEquipAttributeInfo.baseAttributeCount1.text = Mathf.RoundToInt(equipTable.HP).ToString();
            bagEquipAttributeInfo.baseAttributeCount2.text = Mathf.RoundToInt(equipTable.Defense).ToString();
        }
        
        switch (equipTable.Quality)
        {
            case 1:
                bagEquipAttributeInfo.quality.text = "普通";
                bagEquipAttributeInfo.equipBg.sprite = ResourcesConfig.WhiteBg;
                break;
            case 2:
                bagEquipAttributeInfo.quality.text = "优秀";
                bagEquipAttributeInfo.equipBg.sprite = ResourcesConfig.GreenBg;
                SetFuJiaAttribute(equipTable,bagEquipAttributeInfo);
                break;
            case 3:
                bagEquipAttributeInfo.quality.text = "精良";
                bagEquipAttributeInfo.equipBg.sprite = ResourcesConfig.BlueBg;
                SetFuJiaAttribute(equipTable,bagEquipAttributeInfo);
                break;
            case 4:
                bagEquipAttributeInfo.quality.text = "史诗";
                bagEquipAttributeInfo.equipBg.sprite = ResourcesConfig.PurpleBg;
                SetFuJiaAttribute(equipTable,bagEquipAttributeInfo);
                break;
            case 5:
                bagEquipAttributeInfo.quality.text = "传说";
                bagEquipAttributeInfo.equipBg.sprite = ResourcesConfig.OrangeBg;
                SetFuJiaAttribute(equipTable,bagEquipAttributeInfo);
                break;
            case 6:
                bagEquipAttributeInfo.quality.text = "神话";
                bagEquipAttributeInfo.equipBg.sprite = ResourcesConfig.OrangeBg;
                SetFuJiaAttribute(equipTable,bagEquipAttributeInfo);
                break;
        }
        var instRt = instance.GetComponent<RectTransform>();
        // 计算按钮右下角世界坐标
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners); // 0:bottom-left, 1:top-left, 2:top-right, 3:bottom-right
        Vector3 worldBR = corners[3];
// 将世界坐标转换为 Canvas 的本地 anchoredPosition（处理各种 Canvas 渲染模式）
        Camera cam = parentCanvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : parentCanvas.worldCamera;
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(cam, worldBR);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, cam, out Vector2 localPoint);
        float halfWidth = instRt.rect.width * 0.5f;
        Vector2 pos = localPoint + offset + new Vector2(-halfWidth, 0f);
        Vector2 posInstall = localPoint + offset + new Vector2(-halfWidth*3, 0f);

        if (!isInstall)
        {
           instRt.anchoredPosition = pos; 
        }
        else
        {
            instRt.anchoredPosition = posInstall; 
        }
        

        instance.transform.SetAsLastSibling();
    }
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        EquipTable equipTable = bagGrid.tableBase as EquipTable;
      
        ShowEquipAttriute(equipTable,false);
        PlayerEquipConfig.EquipType type = equipTable.EquipType;
        int InstallEquipId = 0;
        switch (type)
        {
            case  PlayerEquipConfig.EquipType.Necklace:
                if (PlayerData.S.necklaceid != 0)
                {
                    InstallEquipId = PlayerData.S.necklaceid;
                }
                break;
            case  PlayerEquipConfig.EquipType.Ring:
                if (PlayerData.S.ringid != 0)
                {
                    InstallEquipId = PlayerData.S.ringid;
                }
                break;
            case  PlayerEquipConfig.EquipType.Shoe:
                if (PlayerData.S.shoeid != 0)
                {
                    InstallEquipId = PlayerData.S.shoeid;
                }
                break;
            case  PlayerEquipConfig.EquipType.Helmet:
                if (PlayerData.S.helmetid != 0)
                {
                    InstallEquipId = PlayerData.S.helmetid;
                }
                break;
            case  PlayerEquipConfig.EquipType.Cloth:
                if (PlayerData.S.clothid != 0)
                {
                    InstallEquipId = PlayerData.S.clothid;
                }
                break;
            case  PlayerEquipConfig.EquipType.Cloak:
                if (PlayerData.S.cloakid != 0)
                {
                    InstallEquipId = PlayerData.S.cloakid;
                }
                break;
        }

        if (InstallEquipId != 0)
        {
            EquipTable InstallTable = BagController.S.EquipIdList[InstallEquipId];
            ShowEquipAttriute(InstallTable,true);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Leftinstance != null)
        {
            Destroy(Leftinstance);
            Leftinstance = null;
        }
        
        if (Rightinstance != null)
        {
            Destroy(Rightinstance);
            Rightinstance = null;
        }
    }

    void OnDisable()
    {
        if (Leftinstance != null)
        {
            Destroy(Leftinstance);
            Leftinstance = null;
        }
        
        if (Rightinstance != null)
        {
            Destroy(Rightinstance);
            Rightinstance = null;
        }
    }
}