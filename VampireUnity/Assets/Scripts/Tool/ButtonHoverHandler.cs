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
            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.NormalAttackName, true, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.NormalAttackDesc);
            break;

        case SkillConfig.SkillButtonType.AttackSpeed:
            level.text = SkillJiaDian.S.AttackSpeed.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.AttackSpeedName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.AttackSpeedDesc);
            break;

        case SkillConfig.SkillButtonType.Dash:
            level.text = SkillJiaDian.S.Dash.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.DashName, true, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.DashDesc);
            break;

        case SkillConfig.SkillButtonType.DashCd:
            level.text = SkillJiaDian.S.DashCd.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.DashCdDesc, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.DashCdDesc);
            break;

        case SkillConfig.SkillButtonType.Crit:
            level.text = SkillJiaDian.S.Crit.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.CritName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.CritDesc);
            break;

        case SkillConfig.SkillButtonType.CritDamage:
            level.text = SkillJiaDian.S.CritDamage.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.CritDamageName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.CritDamageDesc);
            break;

        case SkillConfig.SkillButtonType.MoveSpeed:
            level.text = SkillJiaDian.S.MoveSpeed.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.MoveSpeedName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.MoveSpeedDesc);
            break;

        case SkillConfig.SkillButtonType.MoveAddDefense:
            level.text = SkillJiaDian.S.MoveAddDefense.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.MoveAddDefenseName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.MoveAddDefenseDesc);
            break;

        case SkillConfig.SkillButtonType.MoveAddAttack:
            level.text = SkillJiaDian.S.MoveAddAttack.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.MoveAddAttackName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.MoveAddAttackDesc);
            break;

        case SkillConfig.SkillButtonType.Skill1:
            level.text = SkillJiaDian.S.DianSkill1Damage.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill1Name, true, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill1Desc);
            break;

        case SkillConfig.SkillButtonType.Skill2:
            level.text = SkillJiaDian.S.IceSkill2Damage.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill2Name, true, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill2Desc);
            break;

        case SkillConfig.SkillButtonType.Skill3:
            level.text = SkillJiaDian.S.IceSkill3Damage.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill3Name, true, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill3Desc);
            break;

        case SkillConfig.SkillButtonType.Skill1Cd:
            level.text = SkillJiaDian.S.DianSkill1Cd.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill1CdName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill1CdDesc);
            break;

        case SkillConfig.SkillButtonType.Skill2Cd:
            level.text = SkillJiaDian.S.IceSkill2Cd.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill2Name, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill2Desc);
            break;

        case SkillConfig.SkillButtonType.Skill3Cd:
            level.text = SkillJiaDian.S.IceSkill3Cd.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill3Name, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill3Desc);
            break;

        case SkillConfig.SkillButtonType.Skill1Range:
            level.text = SkillJiaDian.S.DianSkill1Range.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill1RangeName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill1RangeDesc);
            break;

        case SkillConfig.SkillButtonType.Skill1YuanSu:
            level.text = SkillJiaDian.S.DianSkill1YuanSu.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill1YiDianName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill1YiDianDesc);
            break;

        case SkillConfig.SkillButtonType.Skill2Time:
            level.text = SkillJiaDian.S.IceSkill2Time.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill2TimeName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill2TimeDesc);
            break;

        case SkillConfig.SkillButtonType.Skill2YuanSu:
            level.text = SkillJiaDian.S.IceSkill2YuanSu.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill2AddDefenseName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill2AddDefenseDesc);
            break;

        case SkillConfig.SkillButtonType.Skill3Range:
            level.text = SkillJiaDian.S.IceSkill3Range.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill3Name, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill3Desc);
            break;

        case SkillConfig.SkillButtonType.Skill3YuanSu:
            level.text = SkillJiaDian.S.IceSkill3YuanSu.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill3JianSuName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Skill3JianSuDesc);
            break;

        case SkillConfig.SkillButtonType.Attack:
            level.text = SkillJiaDian.S.MonsterAttack.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.AttackName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.AttackDesc);
            break;

        case SkillConfig.SkillButtonType.Hp:
            level.text = SkillJiaDian.S.MonsterHp.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.HpName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.HpDesc);
            break;

        case SkillConfig.SkillButtonType.Defense:
            level.text = SkillJiaDian.S.MonsterDefense.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.DefenseName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.DefenseDesc);
            break;

        case SkillConfig.SkillButtonType.CritMonster:
            level.text = SkillJiaDian.S.MonsterCrit.ToString();

            SetSkillInfoContent(LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.CritName, false, LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.CritDesc);
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
        var level = skillInfoInstance.transform.Find("bg/SkillLevel")?.GetComponent<TextMeshProUGUI>();

        level.text = LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.Level;
        if (nameText != null) nameText.text = skillName;
        if (typeText != null) typeText.text = isZhuDong ? LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.ZhuDongSkill : LanguageConfig.LanguageItems[PlayerData.S.langType].SkillWindowLanguage.BeiDongSkill;
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