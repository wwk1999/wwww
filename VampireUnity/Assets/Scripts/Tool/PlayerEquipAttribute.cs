using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tool;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum PlayerEquipType
{
   None,
   Cloth,
   Cloak,
   Shoe,
   Helmet,
   Ring,
   Necklace
}
public class PlayerEquipAttribute :  MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public PlayerEquipType playerEquipType;
   // 优先使用 inspector 指定的 prefab；若为空则尝试 Resources.Load(resourcePath)
   public GameObject prefab;
   private string resourcePath = "Prefabs/Window/EquipAttributeWhite";
   private Vector2 offset = new Vector2(50f, 0f); // 在右下角的偏移（像素/画布单位）

   private GameObject instance;
   private RectTransform rt;
   private Canvas parentCanvas;
   
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
   
   
   
   public void OnPointerEnter(PointerEventData eventData)
    {
        if (instance != null) return;
        EquipTable equipTable = null;
        switch (playerEquipType)
        {
            case PlayerEquipType.Cloak:
                if (PlayerData.S.cloakid != 0)
                {
                    equipTable = BagController.S.EquipIdList[PlayerData.S.cloakid];
                }
                break;
            case PlayerEquipType.Cloth:
                if (PlayerData.S.clothid != 0)
                {
                    equipTable = BagController.S.EquipIdList[PlayerData.S.clothid];
                }
                break;
            case PlayerEquipType.Helmet:
                if (PlayerData.S.helmetid != 0)
                {
                    equipTable = BagController.S.EquipIdList[PlayerData.S.helmetid];
                }
                break;
            case PlayerEquipType.Ring:
                if (PlayerData.S.ringid != 0)
                {
                    equipTable = BagController.S.EquipIdList[PlayerData.S.ringid];
                }
                break;
            case PlayerEquipType.Necklace:
                if (PlayerData.S.necklaceid != 0)
                {
                    equipTable = BagController.S.EquipIdList[PlayerData.S.necklaceid];
                }
                break;
            case PlayerEquipType.Shoe:
                if (PlayerData.S.shoeid != 0)
                {
                    equipTable = BagController.S.EquipIdList[PlayerData.S.shoeid];
                }
                break;
        }

        if (equipTable == null)
        {
            return;
        }
        if (prefab == null)
        {
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
        }
        if (prefab == null)
        {
            Debug.LogWarning($"EquipAttributeHover: 无法找到预制体（请在 inspector 指定或放入 Resources/{resourcePath}）");
            return;
        }

        // 实例化到 Canvas 下（保证是 UI）
        var canvasRect = parentCanvas.GetComponent<RectTransform>();
        instance = Instantiate(prefab, parentCanvas.transform);
        BagEquipAttributeInfo bagEquipAttributeInfo=instance.GetComponent<BagEquipAttributeInfo>();
        
        if (equipTable.OrangeEntry1 == EntryConfig.OrangeEntry.None)
        {
            bagEquipAttributeInfo.equipName.text = EquipName.EquipNameDic[equipTable.EquipName];
        }
        else
        {
            bagEquipAttributeInfo.equipName.text = EntryConfig.OrangeEntryNameDic[equipTable.OrangeEntry1];
        }
        bagEquipAttributeInfo.equipImage.sprite=ResourcesConfig.GetEquipSprite(equipTable);
        bagEquipAttributeInfo.level.text = equipTable.EquipLevel.ToString();
        
        //基础属性
        if (equipTable.equip_type_id == 1 || equipTable.equip_type_id == 4 || equipTable.equip_type_id == 5)
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
                bagEquipAttributeInfo.animator.Play("WhiteEdge");
                bagEquipAttributeInfo.equipBg.sprite = ResourcesConfig.WhiteBg;
                break;
            case 2:
                bagEquipAttributeInfo.quality.text = "优秀";
                bagEquipAttributeInfo.animator.Play("GreenEdge");
                bagEquipAttributeInfo.equipBg.sprite = ResourcesConfig.GreenBg;
                SetFuJiaAttribute(equipTable,bagEquipAttributeInfo);
                break;
            case 3:
                bagEquipAttributeInfo.quality.text = "精良";
                bagEquipAttributeInfo.animator.Play("BlueEdge");
                bagEquipAttributeInfo.equipBg.sprite = ResourcesConfig.BlueBg;
                SetFuJiaAttribute(equipTable,bagEquipAttributeInfo);
                break;
            case 4:
                bagEquipAttributeInfo.quality.text = "史诗";
                bagEquipAttributeInfo.animator.Play("PurpleEdge");
                bagEquipAttributeInfo.equipBg.sprite = ResourcesConfig.PurpleBg;
                SetFuJiaAttribute(equipTable,bagEquipAttributeInfo);
                break;
            case 5:
                bagEquipAttributeInfo.quality.text = "传说";
                bagEquipAttributeInfo.animator.Play("OrangeEdge");
                bagEquipAttributeInfo.equipBg.sprite = ResourcesConfig.OrangeBg;
                SetFuJiaAttribute(equipTable,bagEquipAttributeInfo);
                break;
            case 6:
                bagEquipAttributeInfo.quality.text = "神话";
                bagEquipAttributeInfo.animator.Play("RedEdge");
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

        // 向右偏移实例化物体宽度的一半（再加上原有 offset）
        float halfWidth = instRt.rect.width * 0.5f;
        instRt.anchoredPosition = localPoint + offset + new Vector2(halfWidth, 0f);

        instance.transform.SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (instance != null)
        {
            Destroy(instance);
            instance = null;
        }
    }

    void OnDisable()
    {
        if (instance != null)
        {
            Destroy(instance);
            instance = null;
        }
    }
}
