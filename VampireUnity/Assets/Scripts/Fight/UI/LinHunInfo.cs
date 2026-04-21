using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LinHunInfo : MonoBehaviour
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
            if (PlayerData.S.chongwuShowLevel > 1)
            {
                PlayerData.S.chongwuShowLevel--;
                Show();
            }
        });
        RightArrow.onClick.AddListener(() =>
        {
            if (PlayerData.S.chongwuShowLevel < 6)
            {
                PlayerData.S.chongwuShowLevel++;
                Show();
            }
        });
        TiaoZhanButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            LevelInfoConfig.CurrentGameLevel = 300+PlayerData.S.chongwuShowLevel;
            LevelInfoConfig.CurrentGameLevelType = LevelType.LingHun;
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
        

        List<MonsterTypeByName> monsterList = null;
        switch (PlayerData.S.chongwuShowLevel)
        {
            case 1:
                Name1.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[301];
                break;
            case 2:
                Name2.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[302];

                break;
            case 3:
                Name3.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[303];

                break;
            case 4:
                Name4.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[304];

                break;
            case 5:
                Name5.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonsterDic[305];

                break;
            case 6:
                Name6.gameObject.SetActive(true);                
                monsterList = LevelInfoConfig.LevelMonsterDic[306];

                break;
        }

        foreach (var item in monsterList)
        {
            var monstergrid = Instantiate(Resources.Load<GameObject>("Prefabs/UI/MonsterGrid"),MonsterContent.transform)
                .GetComponent<MonsterGrid>();
            monstergrid.type = item;
            monstergrid.SetItem();
        }
        
    }
}
