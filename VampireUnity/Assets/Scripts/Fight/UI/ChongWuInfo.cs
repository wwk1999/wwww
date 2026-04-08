using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChongWuInfo : MonoBehaviour
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
                monsterList = LevelInfoConfig.LevelMonster101;
                break;
            case 2:
                Name2.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonster102;
                break;
            case 3:
                Name3.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonster103;
                break;
            case 4:
                Name4.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonster104;
                break;
            case 5:
                Name5.gameObject.SetActive(true);
                monsterList = LevelInfoConfig.LevelMonster105;
                break;
            case 6:
                Name6.gameObject.SetActive(true);                
                monsterList = LevelInfoConfig.LevelMonster106;
                break;
        }

        foreach (var item in monsterList)
        {
            
        }
    }
}
