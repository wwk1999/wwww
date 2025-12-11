using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillWindow1 : MonoBehaviour
{
    public Button exitButton; // 退出按钮

    public Button maskButton;
    public GameObject skillSwitchObj;
    private void Start()
    {
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            Debug.Log("任务界面退出");
            WindowController.S.RoleWindow.SetActive(true);
        });
        maskButton.onClick.AddListener(() =>
        {
            skillSwitchObj.SetActive(false);
        });
    }
}
