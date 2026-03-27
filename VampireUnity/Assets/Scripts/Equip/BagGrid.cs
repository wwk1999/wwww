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
    [NonSerialized]public EquipType EquipType=EquipType.Equip;
    public Button gridButton;
    [NonSerialized]public Sprite equipAttributeImage;
    public GameObject E;
    public GameObject Lock;
    public Image bg;

    public void SetBagGrid()
    {
        EquipTable table = (EquipTable)tableBase;
        gridButton.image.sprite = ResourcesConfig.GetEquipSprite(table);
        equipAttributeImage=ResourcesConfig.GetEquipSprite(table);
        if (table.Lock)
        {
            Lock.gameObject.SetActive(true);
        }
        else
        {
            Lock.gameObject.SetActive(false);
        }

        if (table.equipid == PlayerData.S.cloakid || table.equipid == PlayerData.S.clothid ||
            table.equipid == PlayerData.S.helmetid || table.equipid == PlayerData.S.necklaceid ||
            table.equipid == PlayerData.S.shoeid || table.equipid == PlayerData.S.ringid)
        {
            E.gameObject.SetActive(true);
        }
        else
        {
            E.gameObject.SetActive(false);
        }
        switch (table.Quality)
        {
            case 1:
                bg.sprite = ResourcesConfig.WhiteBg;
                break;
            case 2:
                bg.sprite = ResourcesConfig.GreenBg;
                break;
            case 3:
                bg.sprite = ResourcesConfig.BlueBg;
                break;
            case 4:
                bg.sprite = ResourcesConfig.PurpleBg;
                break;
            case 5:
                bg.sprite = ResourcesConfig.OrangeBg;
                break;
            case 6:
                bg.sprite = ResourcesConfig.RedBg;
                break;
        }
    }

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
