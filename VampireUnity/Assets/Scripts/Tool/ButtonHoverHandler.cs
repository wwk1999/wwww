using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public enum SkillButtonType
{
    None,                    // 无
    NormalAttack,            // 普通攻击
    AttackSpeed,             // 攻击速度
    Dash,                    // 冲刺
    DashCd,                  // 冲刺冷却
    Crit,                    // 暴击
    CritDamage,              // 暴击伤害
    MoveSpeed,               // 移动速度
    MoveAddDefense,          // 移动时增加防御
    MoveAddAttack,           // 移动时增加攻击
    Skill1,                  // 技能1
    Skill2,                  // 技能2
    Skill3,                  // 技能3
    Skill1Cd,                // 技能1冷却
    Skill2Cd,                // 技能2冷却
    Skill3Cd,                // 技能3冷却
    Skill1Range,             // 技能1范围
    Skill1YiDian,            // 技能1易点
    Skill2Time,              // 技能2时间
    Skill2AddDefense,        // 技能2增加防御
    Skill3Range,             // 技能3范围
    Skill3JianSu,            // 技能3减速
    Attack,                  // 攻击
    Hp,                      // 生命值
    Defense,                 // 防御
    CritMonster              // 暴击怪物
}
public class ButtonHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("按钮类型")]
    public SkillButtonType buttonType = SkillButtonType.None;

    [Header("SkillInfo预制体路径")]
    public string skillInfoPrefabPath = "Prefabs/Window/SkillInfo";

    [Header("位置偏移")]
    private Vector2 positionOffset = new Vector2(60, 60);

    private GameObject skillInfoInstance;
    private RectTransform skillInfoRectTransform;
    private Canvas parentCanvas;
    private RectTransform buttonRectTransform;

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

    private void UpdateSkillInfoContent(SkillButtonType type)
    {
        if (skillInfoInstance == null) return;

        switch (type)
        {
            case SkillButtonType.NormalAttack:
                SetSkillInfoContent("普通攻击", true, $"提升普通攻击{GlobalPlayerAttribute.NormalAttackNum}%的伤害");
                break;
            case SkillButtonType.AttackSpeed:
                SetSkillInfoContent("攻击速度", false, $"提升普通攻击{GlobalPlayerAttribute.AttackSpeedNum/100f}的攻击速度");
                break;
            case SkillButtonType.Dash:
                SetSkillInfoContent("瞬身", true, "主角向前瞬移一段距离");
                break;
            case SkillButtonType.DashCd:
                SetSkillInfoContent("瞬身Cd", false, $"瞬身冷却时间减少{GlobalPlayerAttribute.DashCdNum/100f}%");
                break;
            case SkillButtonType.Crit:
                SetSkillInfoContent("暴击", false, $"提升主角{GlobalPlayerAttribute.CritDamageNum}%的暴击");
                break;
            case SkillButtonType.CritDamage:
                SetSkillInfoContent("暴击伤害", false, $"提升主角{GlobalPlayerAttribute.CritDamageNum}%的暴击伤害");
                break;
            case SkillButtonType.MoveSpeed:
                SetSkillInfoContent("移动速度", false, $"提升主角{GlobalPlayerAttribute.MoveSpeedNum/100f}的基础移动速度");
                break;
            case SkillButtonType.MoveAddDefense:
                SetSkillInfoContent("疾行如水", false, $"移动时提升主角{GlobalPlayerAttribute.MoveAddDefenseNum}%的防御");
                break;
            case SkillButtonType.MoveAddAttack:
                SetSkillInfoContent("疾行如火", false, $"提升主角{GlobalPlayerAttribute.MoveAddAttackNum}%的攻击力");
                break;
            case SkillButtonType.Skill1:
                SetSkillInfoContent("电光风暴", true, $"在指定位置召唤雷电风暴，造成{GlobalPlayerAttribute.Skill1DamageNum}%的持续伤害");
                break;
            case SkillButtonType.Skill2:
                SetSkillInfoContent("冰晶星轮", true, $"在主角周围召唤4个冰晶星轮，持续8s，造成{GlobalPlayerAttribute.Skill2DamageNum}%的伤害");
                break;
            case SkillButtonType.Skill3:
                SetSkillInfoContent("极寒冲击", true, $"朝四周喷发极寒冰，造成{GlobalPlayerAttribute.Skill3DamageNum}%的范围伤害");
                break;
            case SkillButtonType.Skill1Cd:
                SetSkillInfoContent("冷却缩减", false, $"减少电光风暴{GlobalPlayerAttribute.Skill1CdNum}%的冷却时间");
                break;
            case SkillButtonType.Skill2Cd:
                SetSkillInfoContent("冷却缩减", false, $"减少冰晶星轮{GlobalPlayerAttribute.Skill2CdNum}%的冷却时间");
                break;
            case SkillButtonType.Skill3Cd:
                SetSkillInfoContent("冷却缩减", false, $"减少极寒冲击{GlobalPlayerAttribute.Skill3CdNum}%的冷却时间");
                break;
            case SkillButtonType.Skill1Range:
                SetSkillInfoContent("风暴扩增", false, $"增加电光风暴{GlobalPlayerAttribute.Skill1RangeNum}%的作用范围");
                break;
            case SkillButtonType.Skill1YiDian:
                SetSkillInfoContent("易电状态", false, $"被电光风暴击中的怪物附加持续3s的易电状态，增加受到的{GlobalPlayerAttribute.Skill1YiDianNum}%的伤害");
                break;
            case SkillButtonType.Skill2Time:
                SetSkillInfoContent("持续时间", false, $"增加的冰晶星轮{GlobalPlayerAttribute.Skill2TimeNum/100f}s的持续时间");
                break;
            case SkillButtonType.Skill2AddDefense:
                SetSkillInfoContent("星轮护体", false, $"存在冰晶星轮时增加{GlobalPlayerAttribute.Skill2AddDefenseNum}%的防御");
                break;
            case SkillButtonType.Skill3Range:
                SetSkillInfoContent("极寒延伸", false, $"极寒冲击的作用范围增大{GlobalPlayerAttribute.Skill3RangeNum/100f}%");
                break;
            case SkillButtonType.Skill3JianSu:
                SetSkillInfoContent("极寒冰冻", false, $"极寒冲击对敌人造成{GlobalPlayerAttribute.Skill3JianSuNum/100f}%的减速效果，持续3s");
                break;
            case SkillButtonType.Attack:
                SetSkillInfoContent("攻击力", false, $"提升角色{GlobalPlayerAttribute.MonsterAttackNum}的基础攻击力");
                break;
            case SkillButtonType.Hp:
                SetSkillInfoContent("生命值", false, $"提升角色{GlobalPlayerAttribute.MonsterHpNum}的最大生命值");
                break;
            case SkillButtonType.Defense:
                SetSkillInfoContent("防御力", false, $"提升角色{GlobalPlayerAttribute.MonsterDefenseNum}的防御力");
                break;
            case SkillButtonType.CritMonster:
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
    }

    void OnDestroy()
    {
        DestroySkillInfo();
    }
}