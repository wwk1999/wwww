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
    var level = skillInfoInstance.transform.Find("bg/SkillLevelCount").GetComponent<TextMeshProUGUI>();
    switch (type)
    {
        case SkillConfig.SkillButtonType.NormalAttack:
            level.text = SkillJiaDian.S.NormalAttack.ToString();
            SetSkillInfoContent("普通攻击", true, $"每级提供普通攻击 5% 的伤害");
            break;

        case SkillConfig.SkillButtonType.AttackSpeed:
            level.text = SkillJiaDian.S.AttackSpeed.ToString();

            SetSkillInfoContent("攻击速度", false, $"每级提供攻击速度 5%");
            break;

        case SkillConfig.SkillButtonType.Dash:
            level.text = SkillJiaDian.S.Dash.ToString();

            SetSkillInfoContent("瞬身", true, $"向前瞬移一段距离");
            break;

        case SkillConfig.SkillButtonType.DashCd:
            level.text = SkillJiaDian.S.DashCd.ToString();

            SetSkillInfoContent("瞬身Cd", false, $"每级减少瞬身冷却 5%");
            break;

        case SkillConfig.SkillButtonType.Crit:
            level.text = SkillJiaDian.S.Crit.ToString();

            SetSkillInfoContent("暴击", false, $"每级提供暴击率 5%");
            break;

        case SkillConfig.SkillButtonType.CritDamage:
            level.text = SkillJiaDian.S.CritDamage.ToString();

            SetSkillInfoContent("暴击伤害", false, $"每级提供暴击伤害 5%");
            break;

        case SkillConfig.SkillButtonType.MoveSpeed:
            level.text = SkillJiaDian.S.MoveSpeed.ToString();

            SetSkillInfoContent("移动速度", false, $"每级提供基础移动速度 0.3");
            break;

        case SkillConfig.SkillButtonType.MoveAddDefense:
            level.text = SkillJiaDian.S.MoveAddDefense.ToString();

            SetSkillInfoContent("疾行如水", false, $"每级提供移动时防御 5%");
            break;

        case SkillConfig.SkillButtonType.MoveAddAttack:
            level.text = SkillJiaDian.S.MoveAddAttack.ToString();

            SetSkillInfoContent("疾行如火", false, $"每级提供移动时攻击力 5%");
            break;

        case SkillConfig.SkillButtonType.Skill1:
            level.text = SkillJiaDian.S.Skill1Damage.ToString();

            SetSkillInfoContent("电光风暴", true, $"每级额外提供电光风暴伤害 5%");
            break;

        case SkillConfig.SkillButtonType.Skill2:
            level.text = SkillJiaDian.S.Skill2Damage.ToString();

            SetSkillInfoContent("冰晶星轮", true, $"每级额外提供冰晶星轮伤害 5%");
            break;

        case SkillConfig.SkillButtonType.Skill3:
            level.text = SkillJiaDian.S.Skill3Damage.ToString();

            SetSkillInfoContent("极寒冲击", true, $"每级额外提供极寒冲击伤害 5%");
            break;

        case SkillConfig.SkillButtonType.Skill1Cd:
            level.text = SkillJiaDian.S.Skill1Cd.ToString();

            SetSkillInfoContent("冷却缩减", false, $"每级减少电光风暴冷却 5%");
            break;

        case SkillConfig.SkillButtonType.Skill2Cd:
            level.text = SkillJiaDian.S.Skill2Cd.ToString();

            SetSkillInfoContent("冷却缩减", false, $"每级减少冰晶星轮冷却 5%");
            break;

        case SkillConfig.SkillButtonType.Skill3Cd:
            level.text = SkillJiaDian.S.Skill3Cd.ToString();

            SetSkillInfoContent("冷却缩减", false, $"每级减少极寒冲击冷却 5%");
            break;

        case SkillConfig.SkillButtonType.Skill1Range:
            level.text = SkillJiaDian.S.Skill1Range.ToString();

            SetSkillInfoContent("风暴扩增", false, $"每级增加电光风暴作用范围 5%");
            break;

        case SkillConfig.SkillButtonType.Skill1YiDian:
            level.text = SkillJiaDian.S.Skill1YiDian.ToString();

            SetSkillInfoContent("易电状态", false, $"每级提供被电光风暴击中后额外受到 5% 的伤害");
            break;

        case SkillConfig.SkillButtonType.Skill2Time:
            level.text = SkillJiaDian.S.Skill2Time.ToString();

            SetSkillInfoContent("持续时间", false, $"每级增加冰晶星轮持续时间 0.5s");
            break;

        case SkillConfig.SkillButtonType.Skill2AddDefense:
            level.text = SkillJiaDian.S.Skill2AddDefense.ToString();

            SetSkillInfoContent("星轮护体", false, $"每级提供存在冰晶星轮时防御 5%");
            break;

        case SkillConfig.SkillButtonType.Skill3Range:
            level.text = SkillJiaDian.S.Skill3Range.ToString();

            SetSkillInfoContent("极寒延伸", false, $"每级增加极寒冲击作用范围 5%");
            break;

        case SkillConfig.SkillButtonType.Skill3JianSu:
            level.text = SkillJiaDian.S.Skill3JianSu.ToString();

            SetSkillInfoContent("极寒冰冻", false, $"每级提供减速效果 5%（持续 3s）");
            break;

        case SkillConfig.SkillButtonType.Attack:
            level.text = SkillJiaDian.S.MonsterAttack.ToString();

            SetSkillInfoContent("攻击力", false, $"每级提供基础攻击力 100");
            break;

        case SkillConfig.SkillButtonType.Hp:
            level.text = SkillJiaDian.S.MonsterHp.ToString();

            SetSkillInfoContent("生命值", false, $"每级提供最大生命值 100");
            break;

        case SkillConfig.SkillButtonType.Defense:
            level.text = SkillJiaDian.S.MonsterDefense.ToString();

            SetSkillInfoContent("防御力", false, $"每级提供防御力 100");
            break;

        case SkillConfig.SkillButtonType.CritMonster:
            level.text = SkillJiaDian.S.MonsterCrit.ToString();

            SetSkillInfoContent("暴击", false, $"每级提供暴击 100");
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