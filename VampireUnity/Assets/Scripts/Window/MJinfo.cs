using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MJinfo : MonoBehaviour
{
    public GameObject whiteName;
    public GameObject greenName;
    public GameObject blueName;
    public GameObject purpleName;
    public GameObject orangeName;
    public TextMeshProUGUI redName;

    public Button leftButton;
    public Button rightButton;

    public TextMeshProUGUI MonsterHp;
    public TextMeshProUGUI MonsterAtk;
    public TextMeshProUGUI MonsterDef;

    public TextMeshProUGUI PlayerLinhun;
    public TextMeshProUGUI PlayerEx;
    public TextMeshProUGUI PlayerBao;



    public GameObject JiangLiContent;

    public Button TiaoZhanButton;

    
    public Button ExitButton;

    public void ShowName(MJLevel mJLevel)
    {
        whiteName.gameObject.SetActive(false);
        greenName.gameObject.SetActive(false);
        blueName.gameObject.SetActive(false);
        purpleName.gameObject.SetActive(false);
        orangeName.gameObject.SetActive(false);
        redName.gameObject.SetActive(false);
        switch (mJLevel)
        {
            case MJLevel.White:
                whiteName.gameObject.SetActive(true);
                break;
            case MJLevel.Green:
                greenName.gameObject.SetActive(true);
                break;
            case MJLevel.Blue:
                blueName.gameObject.SetActive(true);
                break;
            case MJLevel.Purple:
                purpleName.gameObject.SetActive(true);
                break;
            case MJLevel.Orange:
                orangeName.gameObject.SetActive(true);
                break;
            case MJLevel.Red1:
                redName.gameObject.SetActive(true);
                redName.text = "神话I";
                break;
            case MJLevel.Red2:
                redName.gameObject.SetActive(true);
                redName.text = "神话II";
                break;
            case MJLevel.Red3:
                redName.gameObject.SetActive(true);
                redName.text = "神话III";
                break;
            case MJLevel.Red4:
                redName.gameObject.SetActive(true);
                redName.text = "神话IV";
                break;
            case MJLevel.Red5:
                redName.gameObject.SetActive(true);
                redName.text = "神话V";
                break;
            case MJLevel.Red6:
                redName.gameObject.SetActive(true);
                redName.text = "神话VI";
                break;
            case MJLevel.Red7:
                redName.gameObject.SetActive(true);
                redName.text = "神话VII";
                break;
            case MJLevel.Red8:
                redName.gameObject.SetActive(true);
                redName.text = "神话VIII";
                break;
            case MJLevel.Red9:
                redName.gameObject.SetActive(true);
                redName.text = "神话IX";
                break;
            case MJLevel.Red10:
                redName.gameObject.SetActive(true);
                redName.text = "神话X";
                break;
            case MJLevel.Red11:
                redName.gameObject.SetActive(true);
                redName.text = "神话XI";
                break;
            case MJLevel.Red12:
                redName.gameObject.SetActive(true);
                redName.text = "神话XII";
                break;
            case MJLevel.Red13:
                redName.gameObject.SetActive(true);
                redName.text = "神话XIII";
                break;
            case MJLevel.Red14:
                redName.gameObject.SetActive(true);
                redName.text = "神话XIV";
                break;
            case MJLevel.Red15:
                redName.gameObject.SetActive(true);
                redName.text = "神话XV";
                break;
            
        }
    }
    public void ShowMJInfo(MJLevel mJLevel)
    {
        ShowName(mJLevel);
        MonsterHp.text=MJConfig.MonsterAttributeDic[mJLevel].hp+"%生命值";
        MonsterAtk.text = MJConfig.MonsterAttributeDic[mJLevel].atk+"%伤害";
        MonsterDef.text = MJConfig.MonsterAttributeDic[mJLevel].def+"%防御";
        PlayerLinhun.text = MJConfig.PlayerAttributeDic[mJLevel].linhun+"%灵魂";
        PlayerEx.text = MJConfig.PlayerAttributeDic[mJLevel].ex+"%经验";
        PlayerBao.text = MJConfig.PlayerAttributeDic[mJLevel].bao+"%寻宝值";
        foreach (Transform item in JiangLiContent.transform)
        {
            Destroy(item.gameObject);
        }

        var jiangliitem1 = Instantiate(Resources.Load<GameObject>("Prefabs/UI/jiangliItem"), JiangLiContent.transform).GetComponent<JiangLiItem>();
        jiangliitem1.type = JiangLiType.LingHun;
        jiangliitem1.SetItem(mJLevel);
        
        var jiangliitem2 = Instantiate(Resources.Load<GameObject>("Prefabs/UI/jiangliItem"), JiangLiContent.transform).GetComponent<JiangLiItem>();
        jiangliitem2.type = JiangLiType.Exp;
        jiangliitem2.SetItem(mJLevel);
        
        var jiangliitem3 = Instantiate(Resources.Load<GameObject>("Prefabs/UI/jiangliItem"), JiangLiContent.transform).GetComponent<JiangLiItem>();
        jiangliitem3.type = JiangLiType.JingCui;
        jiangliitem3.SetItem(mJLevel);
    }

    private void OnEnable()
    {
        ShowMJInfo(PlayerData.S.mJShowLevel);
    }

    private void Start()
    {
        ExitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        
        TiaoZhanButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            LevelInfoConfig.CurrentGameLevel = 15 + (int)PlayerData.S.mJShowLevel;
            LevelInfoConfig.CurrentGameLevelType = LevelType.MJ;
            WindowController.S.Message.SetActive(false);
            WindowController.S.SceneLoadingWindow.SetActive(true);
        });
        
        leftButton.onClick.AddListener(() =>
        {
            switch (PlayerData.S.mJShowLevel)
            {
                case MJLevel.White:
                    break;
                case MJLevel.Green:
                    PlayerData.S.mJShowLevel=MJLevel.White;
                    break;
                case MJLevel.Blue:
                    PlayerData.S.mJShowLevel=MJLevel.Green;
                    break;
                case MJLevel.Purple:
                    PlayerData.S.mJShowLevel=MJLevel.Blue;
                    break;
                case MJLevel.Orange:
                    PlayerData.S.mJShowLevel=MJLevel.Purple;
                    break;
                case MJLevel.Red1:
                    PlayerData.S.mJShowLevel=MJLevel.Orange;
                    break;
                case MJLevel.Red2:
                    PlayerData.S.mJShowLevel=MJLevel.Red1;
                    break;
                case MJLevel.Red3:
                    PlayerData.S.mJShowLevel=MJLevel.Red2;
                    break;
                case MJLevel.Red4:
                    PlayerData.S.mJShowLevel=MJLevel.Red3;
                    break;
                case MJLevel.Red5:
                    PlayerData.S.mJShowLevel=MJLevel.Red4;
                    break;
                case MJLevel.Red6:
                    PlayerData.S.mJShowLevel=MJLevel.Red5;
                    break;
                case MJLevel.Red7:
                    PlayerData.S.mJShowLevel=MJLevel.Red6;
                    break;
                case MJLevel.Red8:
                    PlayerData.S.mJShowLevel=MJLevel.Red7;
                    break;
                case MJLevel.Red9:
                    PlayerData.S.mJShowLevel=MJLevel.Red8;
                    break;
                case MJLevel.Red10:
                    PlayerData.S.mJShowLevel=MJLevel.Red9;
                    break;
                case MJLevel.Red11:
                    PlayerData.S.mJShowLevel=MJLevel.Red10;
                    break;
                case MJLevel.Red12:
                    PlayerData.S.mJShowLevel=MJLevel.Red11;
                    break;
                case MJLevel.Red13:
                    PlayerData.S.mJShowLevel=MJLevel.Red12;
                    break;
                case MJLevel.Red14:
                    PlayerData.S.mJShowLevel=MJLevel.Red13;
                    break;
                case MJLevel.Red15:
                    PlayerData.S.mJShowLevel=MJLevel.Red14;
                    break;
            }
            ShowMJInfo(PlayerData.S.mJShowLevel);
            StoreController.S.SaveStoreData();
        });
        
        rightButton.onClick.AddListener(() =>
        {
            switch (PlayerData.S.mJShowLevel)
            {
                case MJLevel.White:
                    PlayerData.S.mJShowLevel=MJLevel.Green;
                    break;
                case MJLevel.Green:
                    PlayerData.S.mJShowLevel=MJLevel.Blue;
                    break;
                case MJLevel.Blue:
                    PlayerData.S.mJShowLevel=MJLevel.Purple;
                    break;
                case MJLevel.Purple:
                    PlayerData.S.mJShowLevel=MJLevel.Orange;
                    break;
                case MJLevel.Orange:
                    PlayerData.S.mJShowLevel=MJLevel.Red1;
                    break;
                case MJLevel.Red1:
                    PlayerData.S.mJShowLevel=MJLevel.Red2;
                    break;
                case MJLevel.Red2:
                    PlayerData.S.mJShowLevel=MJLevel.Red3;
                    break;
                case MJLevel.Red3:
                    PlayerData.S.mJShowLevel=MJLevel.Red4;
                    break;
                case MJLevel.Red4:
                    PlayerData.S.mJShowLevel=MJLevel.Red5;
                    break;
                case MJLevel.Red5:
                    PlayerData.S.mJShowLevel=MJLevel.Red6;
                    break;
                case MJLevel.Red6:
                    PlayerData.S.mJShowLevel=MJLevel.Red7;
                    break;
                case MJLevel.Red7:
                    PlayerData.S.mJShowLevel=MJLevel.Red8;
                    break;
                case MJLevel.Red8:
                    PlayerData.S.mJShowLevel=MJLevel.Red9;
                    break;
                case MJLevel.Red9:
                    PlayerData.S.mJShowLevel=MJLevel.Red10;
                    break;
                case MJLevel.Red10:
                    PlayerData.S.mJShowLevel=MJLevel.Red11;
                    break;
                case MJLevel.Red11:
                    PlayerData.S.mJShowLevel=MJLevel.Red12;
                    break;
                case MJLevel.Red12:
                    PlayerData.S.mJShowLevel=MJLevel.Red13;
                    break;
                case MJLevel.Red13:
                    PlayerData.S.mJShowLevel=MJLevel.Red14;
                    break;
                case MJLevel.Red14:
                    PlayerData.S.mJShowLevel=MJLevel.Red15;
                    break;
                case MJLevel.Red15:
                    break;
            }
            ShowMJInfo(PlayerData.S.mJShowLevel);
            StoreController.S.SaveStoreData();
        });
    }
}
