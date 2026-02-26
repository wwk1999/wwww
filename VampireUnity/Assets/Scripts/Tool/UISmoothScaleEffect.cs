using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 挂载在UI元素上，实现鼠标悬停平滑放大、鼠标按下时播放脉冲放大效果。
/// 要求UI元素必须包含Graphic组件（如Image、Text等）以接收事件。
/// </summary>
[RequireComponent(typeof(Graphic))]
public class UISmoothScaleEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("缩放设置")]
    [SerializeField] private float hoverScale = 1.2f;          // 悬停时的目标缩放
    [SerializeField] private float clickScale = 1.4f;          // 点击时的目标缩放
    [SerializeField] private float duration = 0.15f;            // 缩放动画的持续时间（秒）

    [Header("可选动画曲线")]
    [SerializeField] private AnimationCurve scaleCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f); // 默认平滑缓动

    private Vector3 originalScale;                              // 记录原始缩放
    private Coroutine scaleCoroutine;                           // 当前运行的缩放协程
    private bool isPointerOver = false;                         // 鼠标是否悬停在UI上

    private void Awake()
    {
        // 初始化记录原始缩放（基于RectTransform）
        originalScale = GetComponent<RectTransform>().localScale;
    }

    /// <summary>
    /// 鼠标进入UI时调用：平滑缩放到悬停大小
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;
        
        // 如果当前没有按下状态，才执行悬停动画
        // （避免在按下时被悬停动画干扰）
        if (!Input.GetMouseButton(0))
        {
            StopScaleCoroutine();
            scaleCoroutine = StartCoroutine(ScaleOverTime(GetCurrentScale(), hoverScale));
        }
    }

    /// <summary>
    /// 鼠标退出UI时调用：平滑恢复到原始大小
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
        
        // 鼠标离开时，无论什么状态都恢复原大小
        StopScaleCoroutine();
        scaleCoroutine = StartCoroutine(ScaleOverTime(GetCurrentScale(), 1f));
    }

    /// <summary>
    /// 鼠标按下时立即调用：播放放大缩小动画
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        StopScaleCoroutine();
        // 启动点击脉冲协程：先缩放到点击大小，再回到合适的大小
        // 如果鼠标还悬停在UI上，则回到悬停大小，否则回到原始大小
        scaleCoroutine = StartCoroutine(ClickPulseSequence());
    }

    /// <summary>
    /// 鼠标松开时调用
    /// </summary>
    public void OnPointerUp(PointerEventData eventData)
    {
        // 松开鼠标时，根据鼠标是否还在UI上决定缩放状态
        StopScaleCoroutine();
        
        if (isPointerOver)
        {
            // 如果鼠标还在UI上，缩放到悬停大小
            scaleCoroutine = StartCoroutine(ScaleOverTime(GetCurrentScale(), hoverScale));
        }
        else
        {
            // 如果鼠标已经离开UI，缩放到原始大小
            scaleCoroutine = StartCoroutine(ScaleOverTime(GetCurrentScale(), 1f));
        }
    }

    /// <summary>
    /// 停止当前正在运行的缩放协程（如果有）
    /// </summary>
    private void StopScaleCoroutine()
    {
        if (scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
            scaleCoroutine = null;
        }
    }

    /// <summary>
    /// 获取当前实际的缩放值（考虑可能被其他动画修改）
    /// </summary>
    private float GetCurrentScale()
    {
        // 基于RectTransform的localScale.x，假设是等比缩放，取x即可
        return GetComponent<RectTransform>().localScale.x;
    }

    /// <summary>
    /// 核心协程：在duration时间内，从startScale平滑过渡到targetScale
    /// </summary>
    /// <param name="startScale">起始缩放值</param>
    /// <param name="targetScale">目标缩放值</param>
    private IEnumerator ScaleOverTime(float startScale, float targetScale)
    {
        float elapsed = 0f;
        RectTransform rectTransform = GetComponent<RectTransform>();

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            // 应用动画曲线，使运动更平滑
            float curvedT = scaleCurve.Evaluate(t);
            float currentScale = Mathf.LerpUnclamped(startScale, targetScale, curvedT);
            rectTransform.localScale = Vector3.one * currentScale;
            yield return null;
        }

        // 确保最终值精确为目标值，避免累积误差
        rectTransform.localScale = Vector3.one * targetScale;
        scaleCoroutine = null;
    }

    /// <summary>
    /// 点击脉冲序列：放大到clickScale，再缩回到合适的大小
    /// </summary>
    private IEnumerator ClickPulseSequence()
    {
        // 第一部分：放大到 clickScale
        yield return ScaleOverTime(GetCurrentScale(), clickScale);

        // 第二部分：根据鼠标是否还在UI上决定缩放到悬停大小还是原始大小
        float targetScale = isPointerOver ? hoverScale : 1f;
        yield return ScaleOverTime(clickScale, targetScale);

        scaleCoroutine = null;
    }

    // 可选：当脚本被禁用或销毁时，停止协程防止错误
    private void OnDisable()
    {
        StopScaleCoroutine();
    }
}