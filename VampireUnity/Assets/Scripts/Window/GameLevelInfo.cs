using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelInfo : MonoBehaviour
{
    public Button exitButton;
    public Button tiaozhanButton;
    [NonSerialized] public int CurrentClickLevel=0;
    public TextMeshProUGUI LevelNameText;
    public TextMeshProUGUI TuiJianLevelText;
    public GameObject MonsterListContent;
    public GameObject DiaoLuoListContent;
    
    private void Start()
    {
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        tiaozhanButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            LevelInfoConfig.CurrentGameLevelType = LevelType.Normal;
            WindowController.S.Message.SetActive(false);
            WindowController.S.SceneLoadingWindow.SetActive(true);
        });
    }
    
    public void Show()
    {
        foreach (Transform child in MonsterListContent.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in DiaoLuoListContent.transform)
        {
            Destroy(child.gameObject);
        }
        var MonsterList = GetMonsterList();
        var DiaoLuoList = LevelInfoConfig.GetDiaoLuoList(CurrentClickLevel);
        if (MonsterList != null)
        {
            foreach (var item in MonsterList)
            {
                var MonsterSprite = ResourcesConfig.GetMonsterIcon(item);
                if (MonsterSprite != null)
                {
                    var MonsterGrid=Instantiate(Resources.Load<GameObject>("Prefabs/UI/MonsterGrid"),MonsterListContent.transform);
                    MonsterGrid.transform.Find("icon").GetComponent<Image>().sprite = MonsterSprite;
                }
            }
        }

        if (DiaoLuoList != null)
        {
            foreach (var item in DiaoLuoList)
            {
                if (item.PropId == 0)//是装备
                {
                    var DiaoluoEquipSprite = ResourcesConfig.GetEquipSprite(item);
                    if (DiaoluoEquipSprite != null)
                    {
                        var DiaoLuoGrid = Instantiate(Resources.Load<GameObject>("Prefabs/UI/DiaoLuoGrid"),
                            DiaoLuoListContent.transform);
                        DiaoLuoGrid.transform.Find("BagGridImage").GetComponent<Image>().sprite = DiaoluoEquipSprite;
                        DiaoLuoGrid.transform.Find("EquipGridBG").GetComponent<Image>().sprite =
                            ResourcesConfig.GetEquipColorBgBySuitId(item.EquipLevel);
                    }
                }
                else
                {
                    var DiaoluoPropSprite = ResourcesConfig.GetPropSprite(item.PropId);
                    var DiaoLuoGrid = Instantiate(Resources.Load<GameObject>("Prefabs/UI/DiaoLuoGrid"),
                        DiaoLuoListContent.transform);
                    DiaoLuoGrid.transform.Find("BagGridImage").GetComponent<Image>().sprite = DiaoluoPropSprite;
                    DiaoLuoGrid.transform.Find("EquipGridBG").GetComponent<Image>().sprite =
                        ResourcesConfig.GetPropColorBg(item.PropId);
                }
            }
        }
    }

    public List<MonsterTypeByName> GetMonsterList()
    {
        return LevelInfoConfig.LevelMonsterDic[CurrentClickLevel];
    }
    
}
