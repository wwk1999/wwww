using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PanelType
{
    None,
    XiLian,
    HeCheng,
    JinJie,
}
public class DuanZaoWindow : MonoBehaviour
{
    public GameObject xiLianPanel;
    public GameObject heChongPanel;
    public GameObject jinJiePanel;
    
    public Button heChongButton;
    public Button jinJieButton;
    public Button xiLianButton;


    public void ShowPanel(PanelType panelType)
    {
        switch (panelType)
        {
            case PanelType.HeCheng:
                xiLianPanel.SetActive(false);
                heChongPanel.SetActive(true);
                jinJiePanel.SetActive(false);
                break;
            case PanelType.XiLian:
                xiLianPanel.SetActive(true);
                heChongPanel.SetActive(false);
                jinJiePanel.SetActive(false);
                break;
            case PanelType.JinJie:
                xiLianPanel.SetActive(false);
                heChongPanel.SetActive(false);
                jinJiePanel.SetActive(true);
                break;
        }
    }

    private void Start()
    {
        ShowPanel(PanelType.XiLian);
        xiLianButton.onClick.AddListener(() =>
        {
            ShowPanel(PanelType.XiLian);
        });
        heChongButton.onClick.AddListener(() =>
        {
            ShowPanel(PanelType.HeCheng);
        });
        jinJieButton.onClick.AddListener(() =>
        {
            ShowPanel(PanelType.JinJie);
        });
    }
}
