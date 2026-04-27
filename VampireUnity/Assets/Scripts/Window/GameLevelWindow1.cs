using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameLevelWindow1 : MonoBehaviour
{
    //public GameObject loopScrollRect;
    public Button exitButton;
    
    public Button level3Button;
    public Button level6Button;
    public Button level9Button;
    public Button level12Button;
    public Button level15Button;
    public GameObject levelInfo;
    public GameObject MJInfo;
    public Button MJButton;
    public GameObject MjGameObject;

    public Image Level2Image;
    public Image Level3Image;
    public Image Level4Image;
    public Image Level5Image;
    public Image Level6Image;
    
    public GameObject Level2Suo;
    public GameObject Level3Suo;
    public GameObject Level4Suo;
    public GameObject Level5Suo;
    public GameObject Level6Suo;

    public GameObject ChongWuInfo;
    public Button ChongWuButton;
    public Button ChiBangButton;
    public GameObject ChiBangInfo;
    public Button LinHunButton;
    public GameObject LinHunInfo;

    public void HideLevelInfo()
    {
        levelInfo.SetActive(false);
    }

    public void ShowDiTu()
    {
        if (PlayerData.S.maxGameLevel >= 6)
        {
            ChongWuButton.image.color=new Color(1, 1, 1);
            ChongWuButton.interactable = true;
        }
        else
        {
            ChongWuButton.image.color=new Color(60/255, 60/255, 60/255);
            ChongWuButton.interactable = false;

        }
        
        
        if (PlayerData.S.maxGameLevel >= 9)
        {
            ChiBangButton.image.color=new Color(1, 1, 1);
            ChiBangButton.interactable = true;
        }
        else
        {
            ChiBangButton.image.color=new Color(60/255, 60/255, 60/255);
            ChiBangButton.interactable = false;

        }
        
        
        if (PlayerData.S.maxGameLevel >= 12)
        {
            LinHunButton.image.color=new Color(1, 1, 1);
            LinHunButton.interactable = true;
        }
        else
        {
            LinHunButton.image.color=new Color(60/255, 60/255, 60/255);
            LinHunButton.interactable = false;

        }
        
        
        if (PlayerData.S.maxGameLevel >= 6)
        {
            Level2Image.sprite = ResourcesConfig.Level2Liang;
            Level2Suo.gameObject.SetActive(false);
            level6Button.gameObject.SetActive(true);
        }
        else
        {
            Level2Image.sprite = ResourcesConfig.Level2An;
            Level2Suo.gameObject.SetActive(true);
            level6Button.gameObject.SetActive(false);

        }
        
        if (PlayerData.S.maxGameLevel >= 9)
        {
            Level3Image.sprite = ResourcesConfig.Level3Liang;
            Level3Suo.gameObject.SetActive(false);
            level9Button.gameObject.SetActive(true);

        }
        else
        {
            Level3Image.sprite = ResourcesConfig.Level3An;
            Level3Suo.gameObject.SetActive(true);
            level9Button.gameObject.SetActive(false);

        }
        
        if (PlayerData.S.maxGameLevel >= 12)
        {
            Level4Image.sprite = ResourcesConfig.Level4Liang;
            Level4Suo.gameObject.SetActive(false);
            level12Button.gameObject.SetActive(true);

        }
        else
        {
            Level4Image.sprite = ResourcesConfig.Level4An;
            Level4Suo.gameObject.SetActive(true);
            level12Button.gameObject.SetActive(false);

        }
        
        
        if (PlayerData.S.maxGameLevel >= 15)
        {
            Level5Image.sprite = ResourcesConfig.Level5Liang;
            Level5Suo.gameObject.SetActive(false);
            level15Button.gameObject.SetActive(true);
        }
        else
        {
            Level5Image.sprite = ResourcesConfig.Level5An;
            Level5Suo.gameObject.SetActive(true);
            level15Button.gameObject.SetActive(false);
        }
        
        if (PlayerData.S.maxGameLevel > 15)
        {
            Level6Image.sprite = ResourcesConfig.Level6Liang;
            Level6Image.raycastTarget = true;
            Level6Suo.gameObject.SetActive(false);

        }
        else
        {
            Level6Image.raycastTarget = false;
            Level6Image.sprite = ResourcesConfig.Level6An;
            Level6Suo.gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        ShowDiTu();
    }

    void Start()
    {
        ChongWuButton.onClick.AddListener(() =>
        {
            ChongWuInfo.gameObject.SetActive(true);
        });
        
        ChiBangButton.onClick.AddListener(() =>
        {
            ChiBangInfo.gameObject.SetActive(true);
        });
        
        LinHunButton.onClick.AddListener(() =>
        {
            LinHunInfo.gameObject.SetActive(true);
        });
        MJButton.onClick.AddListener(() =>
        {
            MJInfo.gameObject.SetActive(true);
        });
        
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            WindowController.S.Message.SetActive(false);
            WindowController.S.RoleWindow.SetActive(true);
        });
        
        
        level3Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡3");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Boss;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 3;
           levelInfo.SetActive(true);
           levelInfo.GetComponent<GameLevelInfo>().CurrentClickLevel = 3;
           levelInfo.GetComponent<GameLevelInfo>().Show(); 
        });
        
        level6Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡6");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Boss;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 6;
           levelInfo.SetActive(true);
           levelInfo.GetComponent<GameLevelInfo>().CurrentClickLevel = 6;
           levelInfo.GetComponent<GameLevelInfo>().Show(); 
        });
        
        level9Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡9");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Boss;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 9;
           levelInfo.SetActive(true);
           levelInfo.GetComponent<GameLevelInfo>().CurrentClickLevel = 9;
           levelInfo.GetComponent<GameLevelInfo>().Show(); 
        });
       
        level12Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡12");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Boss;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 12;
           levelInfo.SetActive(true);
           levelInfo.GetComponent<GameLevelInfo>().CurrentClickLevel = 12;
           levelInfo.GetComponent<GameLevelInfo>().Show(); 
        });
        level15Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡15");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Boss;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 15;
           levelInfo.SetActive(true);
           levelInfo.GetComponent<GameLevelInfo>().CurrentClickLevel = 15;
           levelInfo.GetComponent<GameLevelInfo>().Show(); 
        });
        
    }
    
}
