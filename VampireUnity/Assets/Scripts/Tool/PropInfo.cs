using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class PropInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("Resources 下的路径（不含 Resources/ 前缀），例如 Prefabs/Window/Propinfo")]
    private string resourcePath = "Prefabs/Window/Propinfo";
    private string baoshiInfoPath = "Prefabs/Window/BaoShiInfo";
    private string chongwudanInfoPath = "Prefabs/Window/ChongWuDanInfo";
    private string chongwuYaoShuiInfoPath = "Prefabs/Window/ChongWuYaoShuiInfo";


    [Tooltip("相对于按钮右下角的偏移（x 向右为正，y 向上为正）。右 50、下 50 => (50, -50)")]
    private Vector2 offset = new Vector2(250f, 0f);

    [Tooltip("可选：指定父物体（若为空则以 Canvas 为父）")]
    public Transform parentOverride;

    private GameObject instance;
    
    public PropGrid propGrid;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Spawn();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DestroyInstance();
    }

    public void Spawn()
    {
        if (instance != null) return;
        GameObject prefab = null;
        if (propGrid.propType < 500)
        {
            prefab = Resources.Load<GameObject>(resourcePath);
        }
        else if(propGrid.propType<1600)
        {
            prefab = Resources.Load<GameObject>(baoshiInfoPath);
        }
        else if (propGrid.propType < 1700)
        {
            prefab = Resources.Load<GameObject>(chongwudanInfoPath);
        }
        else if (propGrid.propType < 1900)
        {
            prefab = Resources.Load<GameObject>(chongwuYaoShuiInfoPath);
        }
        if (prefab == null)
        {
            Debug.LogError($"PropInfoSpawner: 找不到 Resources/{resourcePath} 的预制体。");
            return;
        }

        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("PropInfoSpawner: 找不到父级 Canvas。");
            return;
        }

        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        RectTransform buttonRect = GetComponent<RectTransform>();

        instance = Instantiate(prefab, canvas.transform);
        SetInstance(propGrid.propType);
        
        RectTransform instRect = instance.GetComponent<RectTransform>();

        Vector3[] corners = new Vector3[4];
        buttonRect.GetWorldCorners(corners); // corners: 0=BL,1=TL,2=TR,3=BR for some rects; using corners[3] as bottom-right in previous code — safe to use TR depending on anchor. We'll use corners[3] to match previous behavior.

        // 使用按钮的右下角（world）转换到屏幕坐标，再加偏移（屏幕空间）
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, corners[3]);
        screenPoint += offset;
        //screenPoint += new Vector2(0, -instance.GetComponent<RectTransform>().sizeDelta.y);

        Vector3 worldPos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasRect, screenPoint, canvas.worldCamera, out worldPos);
        instance.transform.position = worldPos;

        // 设置父（保留世界坐标），把实例置于最上层
        instance.transform.SetParent(parentOverride != null ? parentOverride : canvas.transform, true);
        instance.transform.SetAsLastSibling();
    }

    public void ShowQuality(int quality)
    {
        instance.transform.Find("bg/quality/quality1").gameObject.SetActive(quality==1);
        instance.transform.Find("bg/quality/quality2").gameObject.SetActive(quality==2);
        instance.transform.Find("bg/quality/quality3").gameObject.SetActive(quality==3);
        instance.transform.Find("bg/quality/quality4").gameObject.SetActive(quality==4);
        instance.transform.Find("bg/quality/quality5").gameObject.SetActive(quality==5);
        instance.transform.Find("bg/quality/quality6").gameObject.SetActive(quality==6);
    }

    public void ShowName(int Name)
    {
        instance.transform.Find("bg/Name/Name1").gameObject.SetActive(Name==1);
        instance.transform.Find("bg/Name/Name2").gameObject.SetActive(Name==2);
        instance.transform.Find("bg/Name/Name3").gameObject.SetActive(Name==3);
        instance.transform.Find("bg/Name/Name4").gameObject.SetActive(Name==4);
        instance.transform.Find("bg/Name/Name5").gameObject.SetActive(Name==5);
        instance.transform.Find("bg/Name/Name6").gameObject.SetActive(Name==6);
    }

    public void SetChongWuDan()
    {
        
    }

    public void SetBaoShi()
    {
        switch (propGrid.propType)
        {
            case 601:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HH, Quality = 1 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HH, Quality = 1 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao5;
                break;
            
            case 602:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HH, Quality = 2 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HH, Quality = 2 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao5;
                break;
            
            case 603:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HH, Quality = 3 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HH, Quality = 3 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao5;
                break;
            
            case 604:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HH, Quality = 4 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HH, Quality = 4 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao5;
                break;
            case 605:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HH, Quality = 5 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HH, Quality = 5 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao5;
                break;
            
            case 606:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HH, Quality = 6 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HH, Quality = 6 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao5;
                break;
            
            
            
            
            case 701:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HA, Quality = 1 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HA, Quality = 1 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao5;
                break;
            
            case 702:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HA, Quality = 2 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HA, Quality = 2 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao5;
                break;
            
            case 703:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HA, Quality = 3 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HA, Quality = 3 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao5;
                break;
            
            case 704:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HA, Quality = 4 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HA, Quality = 4 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao5;
                break;
            case 705:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HA, Quality = 5 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HA, Quality = 5 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao5;
                break;
            
            case 706:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HA, Quality = 6 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HA, Quality = 6 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao5;
                break;
            
            
            
            
            case 801:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HC, Quality = 1 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HC, Quality = 1 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao5;
                break;
            
            case 802:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HC, Quality = 2 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HC, Quality = 2 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao5;
                break;
            
            case 803:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HC, Quality = 3 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HC, Quality = 3 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao5;
                break;
            
            case 804:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HC, Quality = 4 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HC, Quality = 4 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao5;
                break;
            case 805:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HC, Quality = 5 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HC, Quality = 5 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao5;
                break;
            
            case 806:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HC, Quality = 6 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HC, Quality = 6 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao5;
                break;
            
            
            
            
            
            case 901:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HD, Quality = 1 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HD, Quality = 1 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao5;
                break;
            
            case 902:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HD, Quality = 2 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HD, Quality = 2 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao5;
                break;
            
            case 903:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HD, Quality = 3 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HD, Quality = 3 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao5;
                break;
            
            case 904:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HD, Quality = 4 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HD, Quality = 4 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao5;
                break;
            case 905:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HD, Quality = 5 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HD, Quality = 5 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao5;
                break;
            
            case 906:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Hp + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HD, Quality = 6 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.HD, Quality = 6 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao5;
                break;
            
            
            
            
            
            case 1001:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AA, Quality = 1 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AA, Quality = 1 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao5;
                break;
            
            case 1002:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AA, Quality = 2 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AA, Quality = 2 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao5;
                break;
            
            case 1003:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AA, Quality = 3 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AA, Quality = 3 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao5;
                break;
            
            case 1004:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AA, Quality = 4 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AA, Quality = 4 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao5;
                break;
            case 1005:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AA, Quality = 5 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AA, Quality = 5 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao5;
                break;
            
            case 1006:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AA, Quality = 6 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AA, Quality = 6 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao5;
                break;
            
            
            
            
            
            case 1101:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AC, Quality = 1 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AC, Quality = 1 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao5;
                break;
            
            case 1102:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AC, Quality = 2 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AC, Quality = 2 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao5;
                break;
            
            case 1103:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AC, Quality = 3 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AC, Quality = 3 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao5;
                break;
            
            case 1104:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AC, Quality = 4 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AC, Quality = 4 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao5;
                break;
            case 1105:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AC, Quality = 5 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AC, Quality = 5 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao5;
                break;
            
            case 1106:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AC, Quality = 6 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AC, Quality = 6 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao5;
                break;
            
            
            
            
            
            
            case 1201:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AD, Quality = 1 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AD, Quality = 1 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao5;
                break;
            
            case 1202:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AD, Quality = 2 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AD, Quality = 2 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao5;
                break;
            
            case 1203:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AD, Quality = 3 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AD, Quality = 3 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao5;
                break;
            
            case 1204:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AD, Quality = 4 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AD, Quality = 4 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao5;
                break;
            case 1205:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AD, Quality = 5 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AD, Quality = 5 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao5;
                break;
            
            case 1206:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.NormalAttack + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AD, Quality = 6 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.AD, Quality = 6 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao5;
                break;
            
            
            
            
            
            case 1301:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CC, Quality = 1 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CC, Quality = 1 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao5;
                break;
            
            case 1302:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CC, Quality = 2 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CC, Quality = 2 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao5;
                break;
            
            case 1303:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CC, Quality = 3 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CC, Quality = 3 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao5;
                break;
            
            case 1304:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CC, Quality = 4 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CC, Quality = 4 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao5;
                break;
            case 1305:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CC, Quality = 5 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CC, Quality = 5 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao5;
                break;
            
            case 1306:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CC, Quality = 6 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CC, Quality = 6 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao5;
                break;
            
            
            
            
            
            
            
            case 1401:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CD, Quality = 1 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CD, Quality = 1 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao5;
                break;
            
            case 1402:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CD, Quality = 2 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CD, Quality = 2 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao5;
                break;
            
            case 1403:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CD, Quality = 3 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CD, Quality = 3 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao5;
                break;
            
            case 1404:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CD, Quality = 4 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CD, Quality = 4 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao5;
                break;
            case 1405:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CD, Quality = 5 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CD, Quality = 5 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao5;
                break;
            
            case 1406:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Crit + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CD, Quality = 6 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.CD, Quality = 6 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao5;
                break;
            
            
            
            
            
            
            
            case 1501:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.DD, Quality = 1 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.DD, Quality = 1 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao5;
                break;
            
            case 1502:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.DD, Quality = 2 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.DD, Quality = 2 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao5;
                break;
            
            case 1503:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.DD, Quality = 3 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.DD, Quality = 3 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao5;
                break;
            
            case 1504:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.DD, Quality = 4 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.DD, Quality = 4 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao5;
                break;
            case 1505:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.DD, Quality = 5 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.DD, Quality = 5 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao5;
                break;
            
            case 1506:
                instance.transform.Find("bg/BaoShi/Attribute/Attribute1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.DD, Quality = 6 }]
                        .BaoShiAttributeItem1.Count + "%";
                
                instance.transform.Find("bg/BaoShi/Attribute/Attribute2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaseLanguage.Defense + "：" + BaoShiConfig
                        .BaoShiAttributeDic[new BaoShiInfo() { BaoShiType = BaoShiType.DD, Quality = 6 }]
                        .BaoShiAttributeItem2.Count + "%";

                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao1").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao3;
                
                instance.transform.Find("bg/BaoShi/TeXiao/TeXiao2").GetComponent<TextMeshProUGUI>().text =
                    LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao5;
                break;
            
            
        }
    }

    public void SetInstance(int prop)
    {
        if (prop > 500&&prop<1600)
        {
            SetBaoShi();
        }
        if (prop / 100 != 3)
        {
            switch (prop%100)
            {
                case 1:
                    ShowQuality(1);
                    ShowName(1);
                    instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                    instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("WhiteEdge");
                    break;
                case 2:
                    ShowQuality(2);
                    ShowName(2);
                    instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
                    instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("GreenEdge");
                    break;
                case 3:
                    ShowQuality(3);
                    ShowName(3);
                    instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                    instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("BlueEdge");
                    break;
                case 4:
                    ShowQuality(4);
                    ShowName(4);
                    instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
                    instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("PurpleEdge");
                    break;
                case 5:
                    ShowQuality(5);
                    ShowName(5);
                    instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                    instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("OrangeEdge");
                    break;
                case 6:
                    ShowQuality(6);
                    ShowName(6);
                    instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
                    instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("RedEdge");
                    break;
            }
        }
        else
        {
            if (prop % 100 == 1 || prop % 100 == 2 || prop % 100 == 3 || prop % 100 == 4)
            {
                ShowQuality(5);
                ShowName(5);
                instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("OrangeEdge");
            }
            else
            {
                ShowQuality(6);
                ShowName(6);
                instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
                instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("RedEdge");
            }
        }

        switch (prop)
        {
            case 101:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.WhiteWeaponFragment;
                instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 102:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.GreenWeaponFragment;
                instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 103:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.BlueWeaponFragment;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 104:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.PurpleWeaponFragment;
                instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 105:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.OrangeWeaponFragment;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 106:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.RedWeaponFragment;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            
            
            case 201:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.WhiteJingCui;
                instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 202:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.GreenJingCui;
                instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 203:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.BlueJingCui;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 204:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.PurpleJingCui;
                instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 205:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.OrangeJingCui;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 206:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.RedJingCui;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            
            
            case 301:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.FuMoZhiGu;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 302:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.GoldBlood;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 303:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.JuDaYaChi;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 304:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.ZuiEYanZhu;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 305:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.ShenHuaZhiXin;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
         
            
            
            case 401:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.WhiteChiBang;
                instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 402:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.GreenChiBang;
                instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 403:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.BlueChiBang;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 404:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.PurpleChiBang;
                instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 405:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.OrangeChiBang;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 406:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.RedChiBang;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            
            
            
            
            case 601:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HH1;
                instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 602:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HH2;
                instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 603:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HH3;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 604:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HH4;
                instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 605:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HH5;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 606:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HH6;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            
            
            
            
            case 701:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HA1;
                instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 702:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HA2;
                instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 703:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HA3;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 704:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HA4;
                instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 705:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HA5;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 706:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HA6;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            
            case 801:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HC1;
                instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 802:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HC2;
                instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 803:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HC3;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 804:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HC4;
                instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 805:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HC5;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 806:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HC6;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            
            case 901:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HD1;
                instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 902:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HD2;
                instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 903:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HD3;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 904:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HD4;
                instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 905:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HD5;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 906:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.HD6;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            
            case 1001:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AA1;
                instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1002:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AA2;
                instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1003:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AA3;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1004:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AA4;
                instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1005:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AA5;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1006:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AA6;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            
            case 1101:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AC1;
                instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1102:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AC2;
                instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1103:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AC3;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1104:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AC4;
                instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1105:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AC5;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1106:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AC6;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            
            case 1201:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AD1;
                instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1202:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AD2;
                instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1203:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AD3;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1204:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AD4;
                instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1205:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AD5;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1206:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.AD6;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            
            case 1301:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.CC1;
                instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1302:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.CC2;
                instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1303:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.CC3;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1304:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.CC4;
                instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1305:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.CC5;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1306:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.CC6;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            
            case 1401:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.CD1;
                instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1402:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.CD2;
                instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1403:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.CD3;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1404:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.CD4;
                instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1405:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.CD5;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1406:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.CD6;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            
            case 1501:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.DD1;
                instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1502:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.DD2;
                instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1503:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.DD3;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1504:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.DD4;
                instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1505:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.DD5;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            case 1506:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.DD6;
                instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[prop];
                instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text= PropConfig.PropDescDic[prop];
                break;
            
            case 1603:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.NormalChongWuDan;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = "普通宠物蛋";
                instance.transform.Find("bg/Desc3").gameObject.SetActive(true);
                instance.transform.Find("bg/Desc5").gameObject.SetActive(false);

                break;
            case 1605:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.GaoJiChongWuDan;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = "高级宠物蛋";
                instance.transform.Find("bg/Desc3").gameObject.SetActive(false);
                instance.transform.Find("bg/Desc5").gameObject.SetActive(true);
                break;
            
            case 1703:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.NormalXiSuiYe;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = "普通洗髓液";
                instance.transform.Find("bg/XiSuiYeDesc3").gameObject.SetActive(true);
                instance.transform.Find("bg/XiSuiYeDesc5").gameObject.SetActive(false);
                instance.transform.Find("bg/XueMaiDanDesc3").gameObject.SetActive(false);
                instance.transform.Find("bg/XueMaiDanDesc5").gameObject.SetActive(false);


                break;
            case 1705:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.GaoJiXiSuiYe;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = "高级洗髓液";
                instance.transform.Find("bg/XiSuiYeDesc3").gameObject.SetActive(false);
                instance.transform.Find("bg/XiSuiYeDesc5").gameObject.SetActive(true);
                instance.transform.Find("bg/XueMaiDanDesc3").gameObject.SetActive(false);
                instance.transform.Find("bg/XueMaiDanDesc5").gameObject.SetActive(false);
                break;
            
            case 1803:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.NormalXueMaiDan;
                instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = "普通血脉丹";
                instance.transform.Find("bg/XiSuiYeDesc3").gameObject.SetActive(false);
                instance.transform.Find("bg/XiSuiYeDesc5").gameObject.SetActive(false);
                instance.transform.Find("bg/XueMaiDanDesc3").gameObject.SetActive(true);
                instance.transform.Find("bg/XueMaiDanDesc5").gameObject.SetActive(false);
                break;
            
            case 1805:
                instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite = ResourcesConfig.GaoJiXueMaiDan;
                instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = "高级血脉丹";
                instance.transform.Find("bg/XiSuiYeDesc3").gameObject.SetActive(false);
                instance.transform.Find("bg/XiSuiYeDesc5").gameObject.SetActive(false);
                instance.transform.Find("bg/XueMaiDanDesc3").gameObject.SetActive(false);
                instance.transform.Find("bg/XueMaiDanDesc5").gameObject.SetActive(true);
                break;
        }
    }
    

    public void DestroyInstance()
    {
        if (instance != null)
        {
            Destroy(instance);
            instance = null;
        }
    }

    private void OnDisable()
    {
        DestroyInstance();
    }
}