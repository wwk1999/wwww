using System;
using Mysql;
using Tool;
using UnityEngine;
using UnityEngine.UI;

public enum EquipType
{
    None,
    Equip,
    SourceStone
}
public class BagGrid : MonoBehaviour
{
    [NonSerialized]public TableBase tableBase;
    [NonSerialized]public EquipType EquipType;
    public Button gridButton;
    [NonSerialized]public Sprite equipAttributeImage;
    public GameObject E;
    public Animator animator;

    private void Awake()
    {
        
        // 移除旧的监听器，防止重复添加
        gridButton.onClick.RemoveAllListeners();
        
        // 添加新的点击监听器
        gridButton.onClick.AddListener(() =>
        {
            BagController.S.ShowEquipAttributePanel(tableBase, EquipType,gameObject);
        });
    }

    private void OnDestroy()
    {
        // 确保监听器被移除
        if (gridButton != null)
        {
            gridButton.onClick.RemoveAllListeners();
        }
    }
}
