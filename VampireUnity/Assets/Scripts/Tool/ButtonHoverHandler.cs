using System;
using System.Collections;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("按钮类型")]
    public SkillConfig.SkillButtonType buttonType = SkillConfig.SkillButtonType.None;

    [Header("SkillInfo预制体路径")]
    public string skillInfoPrefabPath = "Prefabs/Window/SkillInfo";

    [Header("位置偏移")]
    private Vector2 positionOffset = new Vector2(60, 60);

    private GameObject skillInfoInstance;
    private RectTransform skillInfoRectTransform;
    private Canvas parentCanvas;
    private RectTransform buttonRectTransform;

    // hover scale parameters
    private Vector3 originalScale = Vector3.one;
    private Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1.2f);
    [UnityEngine.SerializeField] private float scaleDuration = 0.2f;
    private Coroutine scaleCoroutine;

    void Start()
    {
        parentCanvas = GetComponentInParent<Canvas>();
        if (parentCanvas == null)
        {
            GameObject uiRoot = GameObject.Find("UIRoot");
            if (uiRoot != null)
                parentCanvas = uiRoot.GetComponentInChildren<Canvas>();
        }

        buttonRectTransform = GetComponent<RectTransform>();
        // Ensure default scale is 1 if current scale is zero (prevents buttons appearing invisible)
        if (transform.localScale.sqrMagnitude < 1e-6f)
        {
            transform.localScale = Vector3.one;
            originalScale = Vector3.one;
        }
        else
        {
            originalScale = transform.localScale;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (skillInfoInstance == null)
            CreateSkillInfo();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DestroySkillInfo();
    }

    private void CreateSkillInfo()
    {
        if (skillInfoInstance != null)
            return;

        GameObject prefab = Resources.Load<GameObject>(skillInfoPrefabPath);
        if (prefab == null)
        {
            Debug.LogError($"无法加载SkillInfo预制体: {skillInfoPrefabPath}");
            return;
        }

        Transform parent = parentCanvas != null ? parentCanvas.transform : (GameObject.Find("UIRoot")?.transform);
        skillInfoInstance = Instantiate(prefab, parent);
        skillInfoInstance.name = "SkillInfo_Hover";
        skillInfoRectTransform = skillInfoInstance.GetComponent<RectTransform>();
        skillInfoRectTransform.pivot = new Vector2(0, 1);

        SkillSwitch skillSwitch = skillInfoInstance.GetComponentInChildren<SkillSwitch>();
        if (skillSwitch != null) skillSwitch.enabled = false;

        CanvasGroup cg = skillInfoInstance.GetComponent<CanvasGroup>();
        if (cg == null) cg = skillInfoInstance.AddComponent<CanvasGroup>();
        cg.blocksRaycasts = false;
        cg.interactable = false;

        UpdateSkillInfoContent(buttonType);

        // 确保布局更新后再读取尺寸
        Canvas.ForceUpdateCanvases();
        PositionSkillInfoFixed();

        skillInfoInstance.transform.SetAsLastSibling();
    }

    private void UpdateSkillInfoContent(SkillConfig.SkillButtonType type)
    {
        if (skillInfoInstance == null) return;

        switch (type)
        {
            case SkillConfig.SkillButtonType.NormalAttack:
                SetSkillInfoContent("普通攻击", true, $"提升普通攻击{GlobalPlayerAttribute.NormalAttackNum}%的伤害");
                break;
            case SkillConfig.SkillButtonType.AttackSpeed:
                SetSkillInfoContent("攻击速度", false, $"提升普通攻击{GlobalPlayerAttribute.AttackSpeedNum/100f}的攻击速度");
                break;
            case SkillConfig.SkillButtonType.Dash:
                SetSkillInfoContent("瞬身", true, "主角向前瞬移一段距离");
                break;
            case SkillConfig.SkillButtonType.DashCd:
                SetSkillInfoContent("瞬身Cd", false, $"瞬身冷却时间减少{GlobalPlayerAttribute.DashCdNum/100f}%");
                break;
            case SkillConfig.SkillButtonType.Crit:
                SetSkillInfoContent("暴击", false, $"提升主角{GlobalPlayerAttribute.CritDamageNum}%的暴击");
                break;
            case SkillConfig.SkillButtonType.CritDamage:
                SetSkillInfoContent("暴击伤害", false, $"提升主角{GlobalPlayerAttribute.CritDamageNum}%的暴击伤害");
                break;
            case SkillConfig.SkillButtonType.MoveSpeed:
                SetSkillInfoContent("移动速度", false, $"提升主角{GlobalPlayerAttribute.MoveSpeedNum/100f}的基础移动速度");
                break;
            case SkillConfig.SkillButtonType.MoveAddDefense:
                SetSkillInfoContent("疾行如水", false, $"移动时提升主角{GlobalPlayerAttribute.MoveAddDefenseNum}%的防御");
                break;
            case SkillConfig.SkillButtonType.MoveAddAttack:
                SetSkillInfoContent("疾行如火", false, $"提升主角{GlobalPlayerAttribute.MoveAddAttackNum}%的攻击力");
                break;
            case SkillConfig.SkillButtonType.Skill1:
                SetSkillInfoContent("电光风暴", true, $"在指定位置召唤雷电风暴，造成{GlobalPlayerAttribute.Skill1DamageNum}%的持续伤害");
                break;
            case SkillConfig.SkillButtonType.Skill2:
                SetSkillInfoContent("冰晶星轮", true, $"在主角周围召唤4个冰晶星轮，持续8s，造成{GlobalPlayerAttribute.Skill2DamageNum}%的伤害");
                break;
            case SkillConfig.SkillButtonType.Skill3:
                SetSkillInfoContent("极寒冲击", true, $"朝四周喷发极寒冰，造成{GlobalPlayerAttribute.Skill3DamageNum}%的范围伤害");
                break;
            case SkillConfig.SkillButtonType.Skill1Cd:
                SetSkillInfoContent("冷却缩减", false, $"减少电光风暴{GlobalPlayerAttribute.Skill1CdNum}%的冷却时间");
                break;
            case SkillConfig.SkillButtonType.Skill2Cd:
                SetSkillInfoContent("冷却缩减", false, $"减少冰晶星轮{GlobalPlayerAttribute.Skill2CdNum}%的冷却时间");
                break;
            case SkillConfig.SkillButtonType.Skill3Cd:
                SetSkillInfoContent("冷却缩减", false, $"减少极寒冲击{GlobalPlayerAttribute.Skill3CdNum}%的冷却时间");
                break;
            case SkillConfig.SkillButtonType.Skill1Range:
                SetSkillInfoContent("风暴扩增", false, $"增加电光风暴{GlobalPlayerAttribute.Skill1RangeNum}%的作用范围");
                break;
            case SkillConfig.SkillButtonType.Skill1YiDian:
                SetSkillInfoContent("易电状态", false, $"被电光风暴击中的怪物附加持续3s的易电状态，增加受到的{GlobalPlayerAttribute.Skill1YiDianNum}%的伤害");
                break;
            case SkillConfig.SkillButtonType.Skill2Time:
                SetSkillInfoContent("持续时间", false, $"增加的冰晶星轮{GlobalPlayerAttribute.Skill2TimeNum/100f}s的持续时间");
                break;
            case SkillConfig.SkillButtonType.Skill2AddDefense:
                SetSkillInfoContent("星轮护体", false, $"存在冰晶星轮时增加{GlobalPlayerAttribute.Skill2AddDefenseNum}%的防御");
                break;
            case SkillConfig.SkillButtonType.Skill3Range:
                SetSkillInfoContent("极寒延伸", false, $"极寒冲击的作用范围增大{GlobalPlayerAttribute.Skill3RangeNum/100f}%");
                break;
            case SkillConfig.SkillButtonType.Skill3JianSu:
                SetSkillInfoContent("极寒冰冻", false, $"极寒冲击对敌人造成{GlobalPlayerAttribute.Skill3JianSuNum/100f}%的减速效果，持续3s");
                break;
            case SkillConfig.SkillButtonType.Attack:
                SetSkillInfoContent("攻击力", false, $"提升角色{GlobalPlayerAttribute.MonsterAttackNum}的基础攻击力");
                break;
            case SkillConfig.SkillButtonType.Hp:
                SetSkillInfoContent("生命值", false, $"提升角色{GlobalPlayerAttribute.MonsterHpNum}的最大生命值");
                break;
            case SkillConfig.SkillButtonType.Defense:
                SetSkillInfoContent("防御力", false, $"提升角色{GlobalPlayerAttribute.MonsterDefenseNum}的防御力");
                break;
            case SkillConfig.SkillButtonType.CritMonster:
                SetSkillInfoContent("暴击", false, $"提升角色{GlobalPlayerAttribute.MonsterCritNum}的暴击");
                break;
            default:
                SetSkillInfoContent("未知", false, "未定义的技能类型");
                break;
        }
    }

    private void SetSkillInfoContent(string skillName, bool isZhuDong, string skillDescription)
    {
        if (skillInfoInstance == null) return;

        var img = transform.Find("image")?.GetComponent<Image>();
        var dstImg = skillInfoInstance.transform.Find("bg/Image")?.GetComponent<Image>();
        if (img != null && dstImg != null) dstImg.sprite = img.sprite;

        var nameText = skillInfoInstance.transform.Find("bg/SkillName")?.GetComponent<TextMeshProUGUI>();
        var typeText = skillInfoInstance.transform.Find("bg/SkillType")?.GetComponent<TextMeshProUGUI>();
        var infoText = skillInfoInstance.transform.Find("bg/SkillInfo")?.GetComponent<TextMeshProUGUI>();

        if (nameText != null) nameText.text = skillName;
        if (typeText != null) typeText.text = isZhuDong ? "主动技能" : "被动技能";
        if (infoText != null) infoText.text = skillDescription;
    }

    private void PositionSkillInfoFixed()
    {
        if (skillInfoRectTransform == null || parentCanvas == null || buttonRectTransform == null)
            return;

        RectTransform canvasRect = parentCanvas.GetComponent<RectTransform>();
        Camera cam = parentCanvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : parentCanvas.worldCamera;

        Vector2 buttonScreenPos = RectTransformUtility.WorldToScreenPoint(cam, buttonRectTransform.position);
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, buttonScreenPos, cam, out Vector2 buttonLocalPoint))
        {
            Vector2 anchored = buttonLocalPoint + new Vector2(positionOffset.x, positionOffset.y);
            skillInfoRectTransform.anchoredPosition = anchored;
        }
    }

    private void DestroySkillInfo()
    {
        if (skillInfoInstance != null)
        {
            Destroy(skillInfoInstance);
            skillInfoInstance = null;
            skillInfoRectTransform = null;
        }
    }
    
    
    void OnDisable()
    {
        DestroySkillInfo();
        if (scaleCoroutine != null) StopCoroutine(scaleCoroutine);
        transform.localScale = originalScale;
    }

    void OnDestroy()
    {
        DestroySkillInfo();
        if (scaleCoroutine != null) StopCoroutine(scaleCoroutine);
        transform.localScale = originalScale;
    }
}