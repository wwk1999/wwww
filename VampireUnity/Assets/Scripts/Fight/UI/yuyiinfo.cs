using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class yuyiinfo : MonoBehaviour
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
            if (PlayerData.S.yuyiShowLevel > 1)
            {
                PlayerData.S.yuyiShowLevel--;
                Show();
            }
        });
        RightArrow.onClick.AddListener(() =>
        {
            if (PlayerData.S.yuyiShowLevel < 6)
            {
                PlayerData.S.yuyiShowLevel++;
                Show();
            }
        });
        TiaoZhanButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            LevelInfoConfig.CurrentGameLevel = 300+PlayerData.S.yuyiShowLevel;
            LevelInfoConfig.CurrentGameLevelType = LevelType.ChiBang;
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
        List<ChiBangType> diaoluolist = null;
        switch (PlayerData.S.yuyiShowLevel)
        {
            case 1:
                Name1.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[301];
                diaoluolist = LevelInfoConfig.ChiBangDiaoLuoDic[1];
                break;
            case 2:
                Name2.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[302];
                diaoluolist = LevelInfoConfig.ChiBangDiaoLuoDic[2];

                break;
            case 3:
                Name3.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[303];
                diaoluolist = LevelInfoConfig.ChiBangDiaoLuoDic[3];

                break;
            case 4:
                Name4.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[304];
                diaoluolist = LevelInfoConfig.ChiBangDiaoLuoDic[4];

                break;
            case 5:
                Name5.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[305];
                diaoluolist = LevelInfoConfig.ChiBangDiaoLuoDic[5];

                break;
            case 6:
                Name6.gameObject.SetActive(true);                
                monsterList = LevelInfoConfig.LevelMonsterDic[306];
                diaoluolist = LevelInfoConfig.ChiBangDiaoLuoDic[6];

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
            var diaoluogrid=Instantiate(Resources.Load<GameObject>("Prefabs/UI/YuYiDiaoLuoGrid"),DiaoLuoContent.transform)
                .GetComponent<YuYiDiaoLuoGrid>();
            diaoluogrid.ChiBangType=item;
            diaoluogrid.SetItem();
        }
    }
}
