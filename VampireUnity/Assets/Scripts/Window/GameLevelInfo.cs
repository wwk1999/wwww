using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelInfo : MonoBehaviour
{
    public Button exitButton;
    public Button tiaozhanButton;
    [NonSerialized] public int CurrentClickLevel=0;
    public Text LevelNameText;
    public Text TuiJianLevelText;
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
                var MonsterSprite = GetSpriteByMonsterName(item);
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
                var DiaoluoEquipSprite = ResourcesConfig.GetEquipSprite(item);
                if (DiaoluoEquipSprite != null)
                {
                    var DiaoLuoGrid=Instantiate(Resources.Load<GameObject>("Prefabs/UI/DiaoLuoGrid"),DiaoLuoListContent.transform);
                    DiaoLuoGrid.transform.Find("BagGridImage").GetComponent<Image>().sprite = DiaoluoEquipSprite;
                    DiaoLuoGrid.transform.Find("EquipGridBG").GetComponent<Image>().sprite = ResourcesConfig.GetEquipColorBgBySuitId(item.SuitId);
                    switch (item.SuitId)
                    {
                        case 1:
                            DiaoLuoGrid.transform.Find("Edge").GetComponent<Animator>().Play("WhiteEdge");
                            break;
                        case 2:
                        case 101:
                            DiaoLuoGrid.transform.Find("Edge").GetComponent<Animator>().Play("GreenEdge");
                            break;
                        case 3:
                        case 102:
                        case 103:
                            DiaoLuoGrid.transform.Find("Edge").GetComponent<Animator>().Play("BlueEdge");
                            break;
                        case 4:
                            DiaoLuoGrid.transform.Find("Edge").GetComponent<Animator>().Play("PurpleEdge");
                            break;
                        case 5:
                            DiaoLuoGrid.transform.Find("Edge").GetComponent<Animator>().Play("OrangeEdge");
                            break;
                    }
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
        }

        return null;
    }

    public Sprite GetSpriteByMonsterName(MonsterTypeByName monsterType)
    {
        switch (monsterType)
        {
            case MonsterTypeByName.Snot:
            return ResourcesConfig.SnotIcon;
            case MonsterTypeByName.Bat:
                return ResourcesConfig.BatIcon;
            case MonsterTypeByName.Spider:
                return ResourcesConfig.Spidericon;
            case MonsterTypeByName.Bee:
                return ResourcesConfig.EliteBeeIcon;
            case MonsterTypeByName.TreeMan:
                return ResourcesConfig.BossTreeManIcon;
            case MonsterTypeByName.XiaoHuo:
                return ResourcesConfig.XiaoHuoIcon;
            case MonsterTypeByName.ChongZi:
                return ResourcesConfig.ChongZiIcon;
            case MonsterTypeByName.DunDi:
                return ResourcesConfig.DunDiicon;
            case MonsterTypeByName.DaZui:
                return ResourcesConfig.DaZuiIcon;
            case MonsterTypeByName.HuoShanBoss:
                return ResourcesConfig.BossHuoShanIcon;
            case MonsterTypeByName.JiaChong:
                return ResourcesConfig.JiaChongIcon;
            case MonsterTypeByName.XiYi:
                return ResourcesConfig.XiYiicon;
            case MonsterTypeByName.QingWa:
                return ResourcesConfig.QingWaIcon;
            case MonsterTypeByName.ShiRenHua:
                return ResourcesConfig.ShiRenHuaIcon;
            case MonsterTypeByName.ShiRenBoss:
                return ResourcesConfig.BossShiRenIcon;
        }
        return null;
    }
}
