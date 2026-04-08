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
        var DiaoLuoList = GetDiaoLuoList();
        if (MonsterList != null)
        {
            foreach (var item in MonsterList)
            {
                var MonsterSprite = ResourcesConfig.GetMonsterIcon(item);
                if (MonsterSprite != null)
                {
                    var MonsterGrid=Instantiate(Resources.Load<GameObject>("Prefabs/UI/MonsterGrid"),MonsterListContent.transform);
                    MonsterGrid.transform.Find("huan/MonsterIcon").GetComponent<Image>().sprite = MonsterSprite;
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
                            ResourcesConfig.GetEquipColorBgBySuitId(item.SuitId);
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
        switch (CurrentClickLevel)
        {
            case 1:
                return LevelInfoConfig.LevelMonster1;
            case 2:
                return LevelInfoConfig.LevelMonster2;
            case 3:
                return LevelInfoConfig.LevelMonster3;
            case 4:
                return LevelInfoConfig.LevelMonster4;
            case 5:
                return LevelInfoConfig.LevelMonster5;
            case 6:
                return LevelInfoConfig.LevelMonster6;
            case 7:
                return LevelInfoConfig.LevelMonster7;
            case 8:
                return LevelInfoConfig.LevelMonster8;
            case 9:
                return LevelInfoConfig.LevelMonster9;
            case 10:
                return LevelInfoConfig.LevelMonster10;
            case 11:
                return LevelInfoConfig.LevelMonster11;
            case 12:
                return LevelInfoConfig.LevelMonster12;
            case 13:
                return LevelInfoConfig.LevelMonster13;
            case 14:
                return LevelInfoConfig.LevelMonster14;
            case 15:
                return LevelInfoConfig.LevelMonster15;
        }

        return null;
    }
    
    public List<DiaoLuoConfig> GetDiaoLuoList()
    {
        switch (CurrentClickLevel)
        {
            case 1:
                return LevelInfoConfig.LevelDiaoLuo1;
            case 2:
                return LevelInfoConfig.LevelDiaoLuo2;
            case 3:
                return LevelInfoConfig.LevelDiaoLuo3;
            case 4:
                return LevelInfoConfig.LevelDiaoLuo4;
            case 5:
                return LevelInfoConfig.LevelDiaoLuo5;
            case 6:
                return LevelInfoConfig.LevelDiaoLuo6;
            case 7:
                return LevelInfoConfig.LevelDiaoLuo7;
            case 8:
                return LevelInfoConfig.LevelDiaoLuo8;
            case 9:
                return LevelInfoConfig.LevelDiaoLuo9;
            case 10:
                return LevelInfoConfig.LevelDiaoLuo10;
            case 11:
                return LevelInfoConfig.LevelDiaoLuo11;
            case 12:
                return LevelInfoConfig.LevelDiaoLuo12;
            case 13:
                return LevelInfoConfig.LevelDiaoLuo13;
            case 14:
                return LevelInfoConfig.LevelDiaoLuo14;
            case 15:
                return LevelInfoConfig.LevelDiaoLuo15;
        }

        return null;
    }
}
