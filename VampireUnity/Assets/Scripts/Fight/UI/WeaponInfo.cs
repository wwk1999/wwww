using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfo : MonoBehaviour
{
    public TextMeshProUGUI Name1;
    public TextMeshProUGUI Name2;
    public TextMeshProUGUI Name3;
    public TextMeshProUGUI Name4;
    public TextMeshProUGUI Name5;
    public TextMeshProUGUI Name6;

    public Button LeftArrow;
    public Button RightArrow;

    public GameObject MonsterContent;
    public GameObject DiaoLuoContent;

    public Button TiaoZhanButton;
    public Button ExitButton;

    private void OnEnable()
    {
        Show();
    }

    private void Start()
    {
        LeftArrow.onClick.AddListener(() =>
        {
            if (PlayerData.S.weaponShowLevel > 1)
            {
                PlayerData.S.weaponShowLevel--;
                Show();
            }
        });
        RightArrow.onClick.AddListener(() =>
        {
            if (PlayerData.S.weaponShowLevel < 6)
            {
                PlayerData.S.weaponShowLevel++;
                Show();
            }
        });
        TiaoZhanButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            LevelInfoConfig.CurrentGameLevel = 100+PlayerData.S.chongwuShowLevel;
            LevelInfoConfig.CurrentGameLevelType = LevelType.ChongWu;
            WindowController.S.Message.SetActive(false);
            WindowController.S.SceneLoadingWindow.SetActive(true);
        });
        
        ExitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        
        
    }

    public void Show()
    {
        Name1.gameObject.SetActive(false);
        Name2.gameObject.SetActive(false);
        Name3.gameObject.SetActive(false);
        Name4.gameObject.SetActive(false);
        Name5.gameObject.SetActive(false);
        Name6.gameObject.SetActive(false);
        foreach (Transform item in MonsterContent.transform)
        {
            Destroy(item.gameObject);
        }
        
        foreach (Transform item in DiaoLuoContent.transform)
        {
            Destroy(item.gameObject);
        }

        List<MonsterTypeByName> monsterList = null;
        List<ChongWuDiaoLuoItem> diaoluolist = null;
        switch (PlayerData.S.weaponShowLevel)
        {
            case 1:
                Name1.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[101];
                diaoluolist = LevelInfoConfig.WeaponDiaoLuoDic[1];
                break;
            case 2:
                Name2.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[102];
                diaoluolist = LevelInfoConfig.WeaponDiaoLuoDic[2];

                break;
            case 3:
                Name3.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[103];
                diaoluolist = LevelInfoConfig.WeaponDiaoLuoDic[3];

                break;
            case 4:
                Name4.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[104];
                diaoluolist = LevelInfoConfig.WeaponDiaoLuoDic[4];

                break;
            case 5:
                Name5.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[105];
                diaoluolist = LevelInfoConfig.WeaponDiaoLuoDic[5];

                break;
            case 6:
                Name6.gameObject.SetActive(true);                
                monsterList = LevelInfoConfig.LevelMonsterDic[106];
                diaoluolist = LevelInfoConfig.WeaponDiaoLuoDic[6];

                break;
        }

        foreach (var item in monsterList)
        {
            var monstergrid = Instantiate(Resources.Load<GameObject>("Prefabs/UI/MonsterGrid"),MonsterContent.transform)
                .GetComponent<MonsterGrid>();
            monstergrid.type = item;
            monstergrid.SetItem();
        }

        foreach (var item in diaoluolist)
        {
            int propid=PropConfig.GetPropId(item.type,item.Quality);
            var diaoluogrid=Instantiate(Resources.Load<GameObject>("Prefabs/UI/DiaoLuoGrid"),DiaoLuoContent.transform)
                .GetComponent<DiaoLuoGrid>();
            diaoluogrid.PropId=propid;
            diaoluogrid.SetItem();
        }
    }
}
