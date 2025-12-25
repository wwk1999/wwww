using System;
using System.Collections;
using System.Collections.Generic;
using Mysql;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class LoginWindow1 : MonoBehaviour
{
    public InputField usernameInputField; 
    public InputField passwordInputField;
    public Button loginBtn;
    public Button registerBtn;
    public Button closeBtn;
    public string username;
    public string password;
    void Start()
    {
        closeBtn.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        loginBtn.onClick.AddListener(() =>
        {
            Debug.Log("点击登陆按钮");
             username = usernameInputField.text;
            password = passwordInputField.text;
        });
        registerBtn.onClick.AddListener(() =>
        {
            UserController.S.GetMaxUserId(); // 获取当前最大userid
            int newUserId = UserController.S.maxUserid + 1;
            UserController.S.InsertUser(newUserId,usernameInputField.text,passwordInputField.text);
            PlayerInfoController.S.RegisterInit(newUserId);
            Debug.Log("注册成功");
            gameObject.SetActive(false);
        });
    }
}
