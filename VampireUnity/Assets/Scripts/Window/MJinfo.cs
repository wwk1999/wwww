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
    
    public TextMeshProUGUI jiangliEx;
    public TextMeshProUGUI jiangliLinhun;
    public TextMeshProUGUI jinCuiCount;

    public TextMeshProUGUI MonsterName;
    public TextMeshProUGUI PlayerName;

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
                MonsterName.text = "普通 怪物属性";
                PlayerName.text = "普通 人物属性";
                whiteName.gameObject.SetActive(true);
                break;
            case MJLevel.Green:
                MonsterName.text = "困难 怪物属性";
                PlayerName.text = "困难 人物属性";
                greenName.gameObject.SetActive(true);
                break;
            case MJLevel.Blue:
                MonsterName.text = "超难 怪物属性";
                PlayerName.text = "超难 人物属性";
                blueName.gameObject.SetActive(true);
                break;
            case MJLevel.Purple:
                MonsterName.text = "史诗 怪物属性";
                PlayerName.text = "史诗 人物属性";
                purpleName.gameObject.SetActive(true);
                break;
            case MJLevel.Orange:
                MonsterName.text = "传说 怪物属性";
                PlayerName.text = "传说 人物属性";
                orangeName.gameObject.SetActive(true);
                break;
            case MJLevel.Red1:
                MonsterName.text = "神话I 怪物属性";
                PlayerName.text = "神话I 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话I";
                break;
            case MJLevel.Red2:
                MonsterName.text = "神话II 怪物属性";
                PlayerName.text = "神话II 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话II";
                break;
            case MJLevel.Red3:
                MonsterName.text = "神话III 怪物属性";
                PlayerName.text = "神话III 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话III";
                break;
            case MJLevel.Red4:
                MonsterName.text = "神话IV 怪物属性";
                PlayerName.text = "神话IV 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话IV";
                break;
            case MJLevel.Red5:
                MonsterName.text = "神话V 怪物属性";
                PlayerName.text = "神话V 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话V";
                break;
            case MJLevel.Red6:
                MonsterName.text = "神话VI 怪物属性";
                PlayerName.text = "神话VI 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话VI";
                break;
            case MJLevel.Red7:
                MonsterName.text = "神话VII 怪物属性";
                PlayerName.text = "神话VII 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话VII";
                break;
            case MJLevel.Red8:
                MonsterName.text = "神话VIII 怪物属性";
                PlayerName.text = "神话VIII 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话VIII";
                break;
            case MJLevel.Red9:
                MonsterName.text = "神话IX 怪物属性";
                PlayerName.text = "神话IX 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话IX";
                break;
            case MJLevel.Red10:
                MonsterName.text = "神话X 怪物属性";
                PlayerName.text = "神话X 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话X";
                break;
            case MJLevel.Red11:
                MonsterName.text = "神话XI 怪物属性";
                PlayerName.text = "神话XI 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话XI";
                break;
            case MJLevel.Red12:
                MonsterName.text = "神话XII 怪物属性";
                PlayerName.text = "神话XII 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话XII";
                break;
            case MJLevel.Red13:
                MonsterName.text = "神话XIII 怪物属性";
                PlayerName.text = "神话XIII 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话XIII";
                break;
            case MJLevel.Red14:
                MonsterName.text = "神话XIV 怪物属性";
                PlayerName.text = "神话XIV 人物属性";
                redName.gameObject.SetActive(true);
                redName.text = "神话XIV";
                break;
            case MJLevel.Red15:
                MonsterName.text = "神话XV 怪物属性";
                PlayerName.text = "神话XV 人物属性";
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
        jiangliEx.text=MJConfig.JiangLiDic[mJLevel].ex+"经验";
        jiangliLinhun.text=MJConfig.JiangLiDic[mJLevel].linhun+"灵魂";
        jinCuiCount.text="X"+MJConfig.JiangLiDic[mJLevel].jingcui;
    }

    private void OnEnable()
    {
        ShowMJInfo(PlayerData.S.mJLevel);
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
            LevelInfoConfig.CurrentGameLevel = 15 + (int)PlayerData.S.mJLevel;
            LevelInfoConfig.CurrentGameLevelType = LevelType.MJ;
            WindowController.S.Message.SetActive(false);
            WindowController.S.SceneLoadingWindow.SetActive(true);
        });
        
        leftButton.onClick.AddListener(() =>
        {
            switch (PlayerData.S.mJLevel)
            {
                case MJLevel.White:
                    break;
                case MJLevel.Green:
                    PlayerData.S.mJLevel=MJLevel.White;
                    break;
                case MJLevel.Blue:
                    PlayerData.S.mJLevel=MJLevel.Green;
                    break;
                case MJLevel.Purple:
                    PlayerData.S.mJLevel=MJLevel.Blue;
                    break;
                case MJLevel.Orange:
                    PlayerData.S.mJLevel=MJLevel.Purple;
                    break;
                case MJLevel.Red1:
                    PlayerData.S.mJLevel=MJLevel.Orange;
                    break;
                case MJLevel.Red2:
                    PlayerData.S.mJLevel=MJLevel.Red1;
                    break;
                case MJLevel.Red3:
                    PlayerData.S.mJLevel=MJLevel.Red2;
                    break;
                case MJLevel.Red4:
                    PlayerData.S.mJLevel=MJLevel.Red3;
                    break;
                case MJLevel.Red5:
                    PlayerData.S.mJLevel=MJLevel.Red4;
                    break;
                case MJLevel.Red6:
                    PlayerData.S.mJLevel=MJLevel.Red5;
                    break;
                case MJLevel.Red7:
                    PlayerData.S.mJLevel=MJLevel.Red6;
                    break;
                case MJLevel.Red8:
                    PlayerData.S.mJLevel=MJLevel.Red7;
                    break;
                case MJLevel.Red9:
                    PlayerData.S.mJLevel=MJLevel.Red8;
                    break;
                case MJLevel.Red10:
                    PlayerData.S.mJLevel=MJLevel.Red9;
                    break;
                case MJLevel.Red11:
                    PlayerData.S.mJLevel=MJLevel.Red10;
                    break;
                case MJLevel.Red12:
                    PlayerData.S.mJLevel=MJLevel.Red11;
                    break;
                case MJLevel.Red13:
                    PlayerData.S.mJLevel=MJLevel.Red12;
                    break;
                case MJLevel.Red14:
                    PlayerData.S.mJLevel=MJLevel.Red13;
                    break;
                case MJLevel.Red15:
                    PlayerData.S.mJLevel=MJLevel.Red14;
                    break;
            }
            ShowMJInfo(PlayerData.S.mJLevel);
            StoreController.S.SaveStoreData();
        });
        
        rightButton.onClick.AddListener(() =>
        {
            switch (PlayerData.S.mJLevel)
            {
                case MJLevel.White:
                    PlayerData.S.mJLevel=MJLevel.Green;
                    break;
                case MJLevel.Green:
                    PlayerData.S.mJLevel=MJLevel.Blue;
                    break;
                case MJLevel.Blue:
                    PlayerData.S.mJLevel=MJLevel.Purple;
                    break;
                case MJLevel.Purple:
                    PlayerData.S.mJLevel=MJLevel.Orange;
                    break;
                case MJLevel.Orange:
                    PlayerData.S.mJLevel=MJLevel.Red1;
                    break;
                case MJLevel.Red1:
                    PlayerData.S.mJLevel=MJLevel.Red2;
                    break;
                case MJLevel.Red2:
                    PlayerData.S.mJLevel=MJLevel.Red3;
                    break;
                case MJLevel.Red3:
                    PlayerData.S.mJLevel=MJLevel.Red4;
                    break;
                case MJLevel.Red4:
                    PlayerData.S.mJLevel=MJLevel.Red5;
                    break;
                case MJLevel.Red5:
                    PlayerData.S.mJLevel=MJLevel.Red6;
                    break;
                case MJLevel.Red6:
                    PlayerData.S.mJLevel=MJLevel.Red7;
                    break;
                case MJLevel.Red7:
                    PlayerData.S.mJLevel=MJLevel.Red8;
                    break;
                case MJLevel.Red8:
                    PlayerData.S.mJLevel=MJLevel.Red9;
                    break;
                case MJLevel.Red9:
                    PlayerData.S.mJLevel=MJLevel.Red10;
                    break;
                case MJLevel.Red10:
                    PlayerData.S.mJLevel=MJLevel.Red11;
                    break;
                case MJLevel.Red11:
                    PlayerData.S.mJLevel=MJLevel.Red12;
                    break;
                case MJLevel.Red12:
                    PlayerData.S.mJLevel=MJLevel.Red13;
                    break;
                case MJLevel.Red13:
                    PlayerData.S.mJLevel=MJLevel.Red14;
                    break;
                case MJLevel.Red14:
                    PlayerData.S.mJLevel=MJLevel.Red15;
                    break;
                case MJLevel.Red15:
                    break;
            }
            ShowMJInfo(PlayerData.S.mJLevel);
            StoreController.S.SaveStoreData();
        });
    }
}
