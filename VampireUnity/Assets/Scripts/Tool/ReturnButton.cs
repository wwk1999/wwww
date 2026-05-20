using System;
using System.Collections;
using System.Collections.Generic;
using Mysql;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ReturnButton : MonoBehaviour
{
   [NonSerialized]Button returnbutton;
    void Start()
    {
        returnbutton = GameController.S.transform.Find("FightBG(Clone)/Canvas/Mask/ReturnButton").GetComponent<Button>();
        returnbutton.onClick.AddListener(() =>
        {
            Debug.Log("返回按钮退出游戏");
            GlobalPlayerAttribute.CurrentExitType = ExitType.Exit;
            SceneManager.LoadScene("UIScene");
        });
    }

    void Update()
    {
        if(Vector2.Distance(transform.position,QueueController.S.gamePlayer.transform.position)<1)
        {
            returnbutton.gameObject.SetActive(true);
        }
        else
        {
            returnbutton.gameObject.SetActive(false);
        }
    }
}
