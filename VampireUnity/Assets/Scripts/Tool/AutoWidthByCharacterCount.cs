using TMPro;
using UnityEngine;

[ExecuteAlways] // 让脚本在编辑器下也能运行
[RequireComponent(typeof(TMP_Text))]
public class AutoWidthText : MonoBehaviour
{
    [Header("宽度设置")]
    [Tooltip("每个字符的宽度")]
    public float widthPerChar = 30f;
    
    [Tooltip("最小宽度")]
    public float minWidth = 40f;
    
    [Tooltip("边距")]
    public float padding = 20f;
    
    [Header("自动更新")]
    [Tooltip("在编辑器下自动更新")]
    public bool updateInEditor = true;
    
    [Tooltip("在游戏运行时自动更新")]
    public bool updateInRuntime = true;
    
    // 私有变量
    private TMP_Text _text;
    private RectTransform _rect;
    private string _lastText = "";
    
    void Start()
    {
        GetReferences();
        UpdateWidth();
    }
    
    void OnEnable()
    {
        GetReferences();
    }
    
    void Update()
    {
        // 在游戏运行时检查文本是否改变
        if (Application.isPlaying && updateInRuntime)
        {
            CheckTextChanged();
        }
    }
    
    #if UNITY_EDITOR
    void OnValidate()
    {
        // 当Inspector中的参数改变时更新
        if (updateInEditor)
        {
            // 使用延迟调用，避免在OnValidate中直接修改
            UnityEditor.EditorApplication.delayCall += () =>
            {
                if (this != null)
                {
                    UpdateWidth();
                }
            };
        }
    }
    #endif
    
    // 获取组件引用
    void GetReferences()
    {
        if (_text == null)
            _text = GetComponent<TMP_Text>();
        
        if (_rect == null)
            _rect = GetComponent<RectTransform>();
        
        // 确保文本不换行
        if (_text != null)
        {
            _text.enableWordWrapping = false;
            _text.overflowMode = TextOverflowModes.Overflow;
        }
    }
    
    // 检查文本是否改变
    void CheckTextChanged()
    {
        if (_text == null) return;
        
        if (_text.text != _lastText)
        {
            _lastText = _text.text;
            UpdateWidth();
        }
    }
    
    /// <summary>
    /// 更新文本框宽度
    /// </summary>
    [ContextMenu("更新宽度")]
    public void UpdateWidth()
    {
        GetReferences();
        
        if (_text == null || _rect == null) return;
        
        // 计算宽度：字符数 × 每个字符宽度 + 边距
        float width = (_text.text.Length * widthPerChar) + padding;
        
        // 确保不小于最小宽度
        if (width < minWidth)
        {
            width = minWidth;
        }
        
        // 更新宽度，高度保持不变
        _rect.sizeDelta = new Vector2(width, _rect.sizeDelta.y);
        
        // 记录当前文本
        _lastText = _text.text;
        
        #if UNITY_EDITOR
        // 在编辑器下标记对象为已修改
        if (!Application.isPlaying)
        {
            UnityEditor.EditorUtility.SetDirty(gameObject);
        }
        #endif
    }
    
    /// <summary>
    /// 设置文本并自动更新宽度
    /// </summary>
    /// <param name="text">要设置的文本</param>
    public void SetText(string text)
    {
        GetReferences();
        
        if (_text != null)
        {
            _text.text = text;
            UpdateWidth();
        }
    }
    
    /// <summary>
    /// 设置宽度参数
    /// </summary>
    public void SetWidthParams(float charWidth, float minW = 40f, float pad = 20f)
    {
        widthPerChar = charWidth;
        minWidth = minW;
        padding = pad;
        UpdateWidth();
    }
    
    /// <summary>
    /// 根据字符数获取预估宽度
    /// </summary>
    public float GetEstimatedWidth(int charCount)
    {
        float width = (charCount * widthPerChar) + padding;
        return Mathf.Max(width, minWidth);
    }
}