using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillWindow1 : MonoBehaviour
{
    [Header("基础UI组件")]
    public Button exitButton; // 退出按钮
    public Button maskButton;
    public GameObject skillSwitchObj;

    [Header("技能计数显示")]
    public TextMeshProUGUI skillCount;
    public TextMeshProUGUI monsterCount;

    private GameObject IcePanel;
    private GameObject HuoPanel;
    private GameObject DianPanel;
    private GameObject HeiAnPanel;
    private GameObject ZJPanel;
 
    
    private Button IceButton;
    private Button HuoButton;
    private Button DianButton;
    private Button HeiAnButton;
    private Button ZJButton;

    public void Start()
    {
     IcePanel = transform.Find("Bg/Panel/IcePanel").gameObject;
     HuoPanel = transform.Find("Bg/Panel/HuoPanel").gameObject;
     DianPanel = transform.Find("Bg/Panel/DianPanel").gameObject;
     HeiAnPanel = transform.Find("Bg/Panel/HeiAnPanel").gameObject;
     ZJPanel = transform.Find("Bg/Panel/ZJPanel").gameObject;

     IceButton = transform.Find("YuanSuButtonPanel/Ice").GetComponent<Button>();
     HuoButton = transform.Find("YuanSuButtonPanel/Huo").GetComponent<Button>();
     DianButton = transform.Find("YuanSuButtonPanel/Dian").GetComponent<Button>();
     HeiAnButton = transform.Find("YuanSuButtonPanel/HeiAn").GetComponent<Button>();
     ZJButton = transform.Find("YuanSuButtonPanel/ZhuanJing").GetComponent<Button>();

     IceMainBg = transform.Find("Bg/Panel/IcePanel/Main/bg").GetComponent<Image>();
     IceMainIcon = transform.Find("Bg/Panel/IcePanel/Main/icon").GetComponent<Image>();
     IceMainLevelBg = transform.Find("Bg/Panel/IcePanel/Main/Level/bg").GetComponent<Image>();
     IceMainLevelCount = transform.Find("Bg/Panel/IcePanel/Main/Level/level").GetComponent<TextMeshProUGUI>();
     IceMainXuanZhong = transform.Find("Bg/Panel/IcePanel/Main/xuanzhong").GetComponent<Image>();


     IceBei1Bg = transform.Find("Bg/Panel/IcePanel/Bei1/bg").GetComponent<Image>();
     IceBei1Icon = transform.Find("Bg/Panel/IcePanel/Bei1/icon").GetComponent<Image>();
     IceBei1LevelBg = transform.Find("Bg/Panel/IcePanel/Bei1/Level/bg").GetComponent<Image>();
     IceBei1LevelCount = transform.Find("Bg/Panel/IcePanel/Bei1/Level/level").GetComponent<TextMeshProUGUI>();
     IceBei1XuanZhong = transform.Find("Bg/Panel/IcePanel/Bei1/xuanzhong").GetComponent<Image>();


     IceBei2Bg = transform.Find("Bg/Panel/IcePanel/Bei2/bg").GetComponent<Image>();
     IceBei2Icon = transform.Find("Bg/Panel/IcePanel/Bei2/icon").GetComponent<Image>();
     IceBei2LevelBg = transform.Find("Bg/Panel/IcePanel/Bei2/Level/bg").GetComponent<Image>();
     IceBei2LevelCount = transform.Find("Bg/Panel/IcePanel/Bei2/Level/level").GetComponent<TextMeshProUGUI>();
     IceBei2XuanZhong = transform.Find("Bg/Panel/IcePanel/Bei2/xuanzhong").GetComponent<Image>();

     IceBei3Bg = transform.Find("Bg/Panel/IcePanel/Bei3/bg").GetComponent<Image>();
     IceBei3Icon = transform.Find("Bg/Panel/IcePanel/Bei3/icon").GetComponent<Image>();
     IceBei3LevelBg = transform.Find("Bg/Panel/IcePanel/Bei3/Level/bg").GetComponent<Image>();
     IceBei3LevelCount = transform.Find("Bg/Panel/IcePanel/Bei3/Level/level").GetComponent<TextMeshProUGUI>();
     IceBei3XuanZhong = transform.Find("Bg/Panel/IcePanel/Bei3/xuanzhong").GetComponent<Image>();

     IceBei4Bg = transform.Find("Bg/Panel/IcePanel/Bei4/bg").GetComponent<Image>();
     IceBei4Icon = transform.Find("Bg/Panel/IcePanel/Bei4/icon").GetComponent<Image>();
     IceBei4LevelBg = transform.Find("Bg/Panel/IcePanel/Bei4/Level/bg").GetComponent<Image>();
     IceBei4LevelCount = transform.Find("Bg/Panel/IcePanel/Bei4/Level/level").GetComponent<TextMeshProUGUI>();
     IceBei4XuanZhong = transform.Find("Bg/Panel/IcePanel/Bei4/xuanzhong").GetComponent<Image>();


     //IcePanel

     Ice1Bg = transform.Find("Bg/Panel/IcePanel/Ice1/ice/bg").GetComponent<Image>();
     Ice1Icon = transform.Find("Bg/Panel/IcePanel/Ice1/ice/icon").GetComponent<Image>();
     Ice1XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice1/ice/xuanzhong").GetComponent<Image>();
     Ice1LevelBg = transform.Find("Bg/Panel/IcePanel/Ice1/ice/Level/bg").GetComponent<Image>();
     Ice1LevelCount = transform.Find("Bg/Panel/IcePanel/Ice1/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Ice1AutoBg = transform.Find("Bg/Panel/IcePanel/Ice1/ice/Auto/bg").GetComponent<Image>();
     Ice1AutoCount = transform.Find("Bg/Panel/IcePanel/Ice1/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Ice1KeyBg = transform.Find("Bg/Panel/IcePanel/Ice1/ice/key/bg").GetComponent<Image>();
     Ice1KeyCount = transform.Find("Bg/Panel/IcePanel/Ice1/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Ice1_1Bg = transform.Find("Bg/Panel/IcePanel/Ice1/ice1/bg").GetComponent<Image>();
     Ice1_1Icon = transform.Find("Bg/Panel/IcePanel/Ice1/ice1/icon").GetComponent<Image>();
     Ice1_1LevelBg = transform.Find("Bg/Panel/IcePanel/Ice1/ice1/Level/bg").GetComponent<Image>();
     Ice1_1LevelCount = transform.Find("Bg/Panel/IcePanel/Ice1/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Ice1_1XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice1/ice1/xuanzhong").GetComponent<Image>();

     Ice1_2Bg = transform.Find("Bg/Panel/IcePanel/Ice1/ice2/bg").GetComponent<Image>();
     Ice1_2Icon = transform.Find("Bg/Panel/IcePanel/Ice1/ice2/icon").GetComponent<Image>();
     Ice1_2LevelBg = transform.Find("Bg/Panel/IcePanel/Ice1/ice2/Level/bg").GetComponent<Image>();
     Ice1_2LevelCount = transform.Find("Bg/Panel/IcePanel/Ice1/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Ice1_2XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice1/ice2/xuanzhong").GetComponent<Image>();




     Ice2Bg = transform.Find("Bg/Panel/IcePanel/Ice2/ice/bg").GetComponent<Image>();
     Ice2Icon = transform.Find("Bg/Panel/IcePanel/Ice2/ice/icon").GetComponent<Image>();
     Ice2XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice2/ice/xuanzhong").GetComponent<Image>();
     Ice2LevelBg = transform.Find("Bg/Panel/IcePanel/Ice2/ice/Level/bg").GetComponent<Image>();
     Ice2LevelCount = transform.Find("Bg/Panel/IcePanel/Ice2/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Ice2AutoBg = transform.Find("Bg/Panel/IcePanel/Ice2/ice/Auto/bg").GetComponent<Image>();
     Ice2AutoCount = transform.Find("Bg/Panel/IcePanel/Ice2/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Ice2KeyBg = transform.Find("Bg/Panel/IcePanel/Ice2/ice/key/bg").GetComponent<Image>();
     Ice2KeyCount = transform.Find("Bg/Panel/IcePanel/Ice2/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Ice2_1Bg = transform.Find("Bg/Panel/IcePanel/Ice2/ice1/bg").GetComponent<Image>();
     Ice2_1Icon = transform.Find("Bg/Panel/IcePanel/Ice2/ice1/icon").GetComponent<Image>();
     Ice2_1LevelBg = transform.Find("Bg/Panel/IcePanel/Ice2/ice1/Level/bg").GetComponent<Image>();
     Ice2_1LevelCount = transform.Find("Bg/Panel/IcePanel/Ice2/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Ice2_1XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice2/ice1/xuanzhong").GetComponent<Image>();

     Ice2_2Bg = transform.Find("Bg/Panel/IcePanel/Ice2/ice2/bg").GetComponent<Image>();
     Ice2_2Icon = transform.Find("Bg/Panel/IcePanel/Ice2/ice2/icon").GetComponent<Image>();
     Ice2_2LevelBg = transform.Find("Bg/Panel/IcePanel/Ice2/ice2/Level/bg").GetComponent<Image>();
     Ice2_2LevelCount = transform.Find("Bg/Panel/IcePanel/Ice2/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Ice2_2XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice2/ice2/xuanzhong").GetComponent<Image>();



     Ice3Bg = transform.Find("Bg/Panel/IcePanel/Ice3/ice/bg").GetComponent<Image>();
     Ice3Icon = transform.Find("Bg/Panel/IcePanel/Ice3/ice/icon").GetComponent<Image>();
     Ice3XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice3/ice/xuanzhong").GetComponent<Image>();
     Ice3LevelBg = transform.Find("Bg/Panel/IcePanel/Ice3/ice/Level/bg").GetComponent<Image>();
     Ice3LevelCount = transform.Find("Bg/Panel/IcePanel/Ice3/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Ice3AutoBg = transform.Find("Bg/Panel/IcePanel/Ice3/ice/Auto/bg").GetComponent<Image>();
     Ice3AutoCount = transform.Find("Bg/Panel/IcePanel/Ice3/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Ice3KeyBg = transform.Find("Bg/Panel/IcePanel/Ice3/ice/key/bg").GetComponent<Image>();
     Ice3KeyCount = transform.Find("Bg/Panel/IcePanel/Ice3/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Ice3_1Bg = transform.Find("Bg/Panel/IcePanel/Ice3/ice1/bg").GetComponent<Image>();
     Ice3_1Icon = transform.Find("Bg/Panel/IcePanel/Ice3/ice1/icon").GetComponent<Image>();
     Ice3_1LevelBg = transform.Find("Bg/Panel/IcePanel/Ice3/ice1/Level/bg").GetComponent<Image>();
     Ice3_1LevelCount = transform.Find("Bg/Panel/IcePanel/Ice3/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Ice3_1XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice3/ice1/xuanzhong").GetComponent<Image>();

     Ice3_2Bg = transform.Find("Bg/Panel/IcePanel/Ice3/ice2/bg").GetComponent<Image>();
     Ice3_2Icon = transform.Find("Bg/Panel/IcePanel/Ice3/ice2/icon").GetComponent<Image>();
     Ice3_2LevelBg = transform.Find("Bg/Panel/IcePanel/Ice3/ice2/Level/bg").GetComponent<Image>();
     Ice3_2LevelCount = transform.Find("Bg/Panel/IcePanel/Ice3/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Ice3_2XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice3/ice2/xuanzhong").GetComponent<Image>();


     Ice4Bg = transform.Find("Bg/Panel/IcePanel/Ice4/ice/bg").GetComponent<Image>();
     Ice4Icon = transform.Find("Bg/Panel/IcePanel/Ice4/ice/icon").GetComponent<Image>();
     Ice4XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice4/ice/xuanzhong").GetComponent<Image>();
     Ice4LevelBg = transform.Find("Bg/Panel/IcePanel/Ice4/ice/Level/bg").GetComponent<Image>();
     Ice4LevelCount = transform.Find("Bg/Panel/IcePanel/Ice4/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Ice4AutoBg = transform.Find("Bg/Panel/IcePanel/Ice4/ice/Auto/bg").GetComponent<Image>();
     Ice4AutoCount = transform.Find("Bg/Panel/IcePanel/Ice4/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Ice4KeyBg = transform.Find("Bg/Panel/IcePanel/Ice4/ice/key/bg").GetComponent<Image>();
     Ice4KeyCount = transform.Find("Bg/Panel/IcePanel/Ice4/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Ice4_1Bg = transform.Find("Bg/Panel/IcePanel/Ice4/ice1/bg").GetComponent<Image>();
     Ice4_1Icon = transform.Find("Bg/Panel/IcePanel/Ice4/ice1/icon").GetComponent<Image>();
     Ice4_1LevelBg = transform.Find("Bg/Panel/IcePanel/Ice4/ice1/Level/bg").GetComponent<Image>();
     Ice4_1LevelCount = transform.Find("Bg/Panel/IcePanel/Ice4/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Ice4_1XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice4/ice1/xuanzhong").GetComponent<Image>();

     Ice4_2Bg = transform.Find("Bg/Panel/IcePanel/Ice4/ice2/bg").GetComponent<Image>();
     Ice4_2Icon = transform.Find("Bg/Panel/IcePanel/Ice4/ice2/icon").GetComponent<Image>();
     Ice4_2LevelBg = transform.Find("Bg/Panel/IcePanel/Ice4/ice2/Level/bg").GetComponent<Image>();
     Ice4_2LevelCount = transform.Find("Bg/Panel/IcePanel/Ice4/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Ice4_2XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice4/ice2/xuanzhong").GetComponent<Image>();



     Ice5Bg = transform.Find("Bg/Panel/IcePanel/Ice5/ice/bg").GetComponent<Image>();
     Ice5Icon = transform.Find("Bg/Panel/IcePanel/Ice5/ice/icon").GetComponent<Image>();
     Ice5XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice5/ice/xuanzhong").GetComponent<Image>();
     Ice5LevelBg = transform.Find("Bg/Panel/IcePanel/Ice5/ice/Level/bg").GetComponent<Image>();
     Ice5LevelCount = transform.Find("Bg/Panel/IcePanel/Ice5/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Ice5AutoBg = transform.Find("Bg/Panel/IcePanel/Ice5/ice/Auto/bg").GetComponent<Image>();
     Ice5AutoCount = transform.Find("Bg/Panel/IcePanel/Ice5/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Ice5KeyBg = transform.Find("Bg/Panel/IcePanel/Ice5/ice/key/bg").GetComponent<Image>();
     Ice5KeyCount = transform.Find("Bg/Panel/IcePanel/Ice5/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Ice5_1Bg = transform.Find("Bg/Panel/IcePanel/Ice5/ice1/bg").GetComponent<Image>();
     Ice5_1Icon = transform.Find("Bg/Panel/IcePanel/Ice5/ice1/icon").GetComponent<Image>();
     Ice5_1LevelBg = transform.Find("Bg/Panel/IcePanel/Ice5/ice1/Level/bg").GetComponent<Image>();
     Ice5_1LevelCount = transform.Find("Bg/Panel/IcePanel/Ice5/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Ice5_1XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice5/ice1/xuanzhong").GetComponent<Image>();

     Ice5_2Bg = transform.Find("Bg/Panel/IcePanel/Ice5/ice2/bg").GetComponent<Image>();
     Ice5_2Icon = transform.Find("Bg/Panel/IcePanel/Ice5/ice2/icon").GetComponent<Image>();
     Ice5_2LevelBg = transform.Find("Bg/Panel/IcePanel/Ice5/ice2/Level/bg").GetComponent<Image>();
     Ice5_2LevelCount = transform.Find("Bg/Panel/IcePanel/Ice5/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Ice5_2XuanZhong = transform.Find("Bg/Panel/IcePanel/Ice5/ice2/xuanzhong").GetComponent<Image>();








     //IcePanel
     Huo1Bg = transform.Find("Bg/Panel/HuoPanel/Ice1/ice/bg").GetComponent<Image>();
     Huo1Icon = transform.Find("Bg/Panel/HuoPanel/Ice1/ice/icon").GetComponent<Image>();
     Huo1XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice1/ice/xuanzhong").GetComponent<Image>();
     Huo1LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice1/ice/Level/bg").GetComponent<Image>();
     Huo1LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice1/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Huo1AutoBg = transform.Find("Bg/Panel/HuoPanel/Ice1/ice/Auto/bg").GetComponent<Image>();
     Huo1AutoCount = transform.Find("Bg/Panel/HuoPanel/Ice1/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Huo1KeyBg = transform.Find("Bg/Panel/HuoPanel/Ice1/ice/key/bg").GetComponent<Image>();
     Huo1KeyCount = transform.Find("Bg/Panel/HuoPanel/Ice1/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Huo1_1Bg = transform.Find("Bg/Panel/HuoPanel/Ice1/ice1/bg").GetComponent<Image>();
     Huo1_1Icon = transform.Find("Bg/Panel/HuoPanel/Ice1/ice1/icon").GetComponent<Image>();
     Huo1_1LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice1/ice1/Level/bg").GetComponent<Image>();
     Huo1_1LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice1/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Huo1_1XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice1/ice1/xuanzhong").GetComponent<Image>();

     Huo1_2Bg = transform.Find("Bg/Panel/HuoPanel/Ice1/ice2/bg").GetComponent<Image>();
     Huo1_2Icon = transform.Find("Bg/Panel/HuoPanel/Ice1/ice2/icon").GetComponent<Image>();
     Huo1_2LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice1/ice2/Level/bg").GetComponent<Image>();
     Huo1_2LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice1/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Huo1_2XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice1/ice2/xuanzhong").GetComponent<Image>();




     Huo2Bg = transform.Find("Bg/Panel/HuoPanel/Ice2/ice/bg").GetComponent<Image>();
     Huo2Icon = transform.Find("Bg/Panel/HuoPanel/Ice2/ice/icon").GetComponent<Image>();
     Huo2XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice2/ice/xuanzhong").GetComponent<Image>();
     Huo2LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice2/ice/Level/bg").GetComponent<Image>();
     Huo2LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice2/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Huo2AutoBg = transform.Find("Bg/Panel/HuoPanel/Ice2/ice/Auto/bg").GetComponent<Image>();
     Huo2AutoCount = transform.Find("Bg/Panel/HuoPanel/Ice2/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Huo2KeyBg = transform.Find("Bg/Panel/HuoPanel/Ice2/ice/key/bg").GetComponent<Image>();
     Huo2KeyCount = transform.Find("Bg/Panel/HuoPanel/Ice2/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Huo2_1Bg = transform.Find("Bg/Panel/HuoPanel/Ice2/ice1/bg").GetComponent<Image>();
     Huo2_1Icon = transform.Find("Bg/Panel/HuoPanel/Ice2/ice1/icon").GetComponent<Image>();
     Huo2_1LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice2/ice1/Level/bg").GetComponent<Image>();
     Huo2_1LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice2/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Huo2_1XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice2/ice1/xuanzhong").GetComponent<Image>();

     Huo2_2Bg = transform.Find("Bg/Panel/HuoPanel/Ice2/ice2/bg").GetComponent<Image>();
     Huo2_2Icon = transform.Find("Bg/Panel/HuoPanel/Ice2/ice2/icon").GetComponent<Image>();
     Huo2_2LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice2/ice2/Level/bg").GetComponent<Image>();
     Huo2_2LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice2/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Huo2_2XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice2/ice2/xuanzhong").GetComponent<Image>();




     Huo3Bg = transform.Find("Bg/Panel/HuoPanel/Ice3/ice/bg").GetComponent<Image>();
     Huo3Icon = transform.Find("Bg/Panel/HuoPanel/Ice3/ice/icon").GetComponent<Image>();
     Huo3XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice3/ice/xuanzhong").GetComponent<Image>();
     Huo3LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice3/ice/Level/bg").GetComponent<Image>();
     Huo3LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice3/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Huo3AutoBg = transform.Find("Bg/Panel/HuoPanel/Ice3/ice/Auto/bg").GetComponent<Image>();
     Huo3AutoCount = transform.Find("Bg/Panel/HuoPanel/Ice3/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Huo3KeyBg = transform.Find("Bg/Panel/HuoPanel/Ice3/ice/key/bg").GetComponent<Image>();
     Huo3KeyCount = transform.Find("Bg/Panel/HuoPanel/Ice3/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Huo3_1Bg = transform.Find("Bg/Panel/HuoPanel/Ice3/ice1/bg").GetComponent<Image>();
     Huo3_1Icon = transform.Find("Bg/Panel/HuoPanel/Ice3/ice1/icon").GetComponent<Image>();
     Huo3_1LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice3/ice1/Level/bg").GetComponent<Image>();
     Huo3_1LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice3/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Huo3_1XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice3/ice1/xuanzhong").GetComponent<Image>();

     Huo3_2Bg = transform.Find("Bg/Panel/HuoPanel/Ice3/ice2/bg").GetComponent<Image>();
     Huo3_2Icon = transform.Find("Bg/Panel/HuoPanel/Ice3/ice2/icon").GetComponent<Image>();
     Huo3_2LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice3/ice2/Level/bg").GetComponent<Image>();
     Huo3_2LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice3/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Huo3_2XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice3/ice2/xuanzhong").GetComponent<Image>();


     Huo4Bg = transform.Find("Bg/Panel/HuoPanel/Ice4/ice/bg").GetComponent<Image>();
     Huo4Icon = transform.Find("Bg/Panel/HuoPanel/Ice4/ice/icon").GetComponent<Image>();
     Huo4XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice4/ice/xuanzhong").GetComponent<Image>();
     Huo4LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice4/ice/Level/bg").GetComponent<Image>();
     Huo4LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice4/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Huo4AutoBg = transform.Find("Bg/Panel/HuoPanel/Ice4/ice/Auto/bg").GetComponent<Image>();
     Huo4AutoCount = transform.Find("Bg/Panel/HuoPanel/Ice4/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Huo4KeyBg = transform.Find("Bg/Panel/HuoPanel/Ice4/ice/key/bg").GetComponent<Image>();
     Huo4KeyCount = transform.Find("Bg/Panel/HuoPanel/Ice4/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Huo4_1Bg = transform.Find("Bg/Panel/HuoPanel/Ice4/ice1/bg").GetComponent<Image>();
     Huo4_1Icon = transform.Find("Bg/Panel/HuoPanel/Ice4/ice1/icon").GetComponent<Image>();
     Huo4_1LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice4/ice1/Level/bg").GetComponent<Image>();
     Huo4_1LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice4/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Huo4_1XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice4/ice1/xuanzhong").GetComponent<Image>();

     Huo4_2Bg = transform.Find("Bg/Panel/HuoPanel/Ice4/ice2/bg").GetComponent<Image>();
     Huo4_2Icon = transform.Find("Bg/Panel/HuoPanel/Ice4/ice2/icon").GetComponent<Image>();
     Huo4_2LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice4/ice2/Level/bg").GetComponent<Image>();
     Huo4_2LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice4/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Huo4_2XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice4/ice2/xuanzhong").GetComponent<Image>();




     Huo5Bg = transform.Find("Bg/Panel/HuoPanel/Ice5/ice/bg").GetComponent<Image>();
     Huo5Icon = transform.Find("Bg/Panel/HuoPanel/Ice5/ice/icon").GetComponent<Image>();
     Huo5XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice5/ice/xuanzhong").GetComponent<Image>();
     Huo5LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice5/ice/Level/bg").GetComponent<Image>();
     Huo5LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice5/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Huo5AutoBg = transform.Find("Bg/Panel/HuoPanel/Ice5/ice/Auto/bg").GetComponent<Image>();
     Huo5AutoCount = transform.Find("Bg/Panel/HuoPanel/Ice5/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Huo5KeyBg = transform.Find("Bg/Panel/HuoPanel/Ice5/ice/key/bg").GetComponent<Image>();
     Huo5KeyCount = transform.Find("Bg/Panel/HuoPanel/Ice5/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Huo5_1Bg = transform.Find("Bg/Panel/HuoPanel/Ice5/ice1/bg").GetComponent<Image>();
     Huo5_1Icon = transform.Find("Bg/Panel/HuoPanel/Ice5/ice1/icon").GetComponent<Image>();
     Huo5_1LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice5/ice1/Level/bg").GetComponent<Image>();
     Huo5_1LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice5/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Huo5_1XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice5/ice1/xuanzhong").GetComponent<Image>();

     Huo5_2Bg = transform.Find("Bg/Panel/HuoPanel/Ice5/ice2/bg").GetComponent<Image>();
     Huo5_2Icon = transform.Find("Bg/Panel/HuoPanel/Ice5/ice2/icon").GetComponent<Image>();
     Huo5_2LevelBg = transform.Find("Bg/Panel/HuoPanel/Ice5/ice2/Level/bg").GetComponent<Image>();
     Huo5_2LevelCount = transform.Find("Bg/Panel/HuoPanel/Ice5/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Huo5_2XuanZhong = transform.Find("Bg/Panel/HuoPanel/Ice5/ice2/xuanzhong").GetComponent<Image>();






     Dian1Bg = transform.Find("Bg/Panel/DianPanel/Ice1/ice/bg").GetComponent<Image>();
     Dian1Icon = transform.Find("Bg/Panel/DianPanel/Ice1/ice/icon").GetComponent<Image>();
     Dian1XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice1/ice/xuanzhong").GetComponent<Image>();
     Dian1LevelBg = transform.Find("Bg/Panel/DianPanel/Ice1/ice/Level/bg").GetComponent<Image>();
     Dian1LevelCount = transform.Find("Bg/Panel/DianPanel/Ice1/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Dian1AutoBg = transform.Find("Bg/Panel/DianPanel/Ice1/ice/Auto/bg").GetComponent<Image>();
     Dian1AutoCount = transform.Find("Bg/Panel/DianPanel/Ice1/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Dian1KeyBg = transform.Find("Bg/Panel/DianPanel/Ice1/ice/key/bg").GetComponent<Image>();
     Dian1KeyCount = transform.Find("Bg/Panel/DianPanel/Ice1/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Dian1_1Bg = transform.Find("Bg/Panel/DianPanel/Ice1/ice1/bg").GetComponent<Image>();
     Dian1_1Icon = transform.Find("Bg/Panel/DianPanel/Ice1/ice1/icon").GetComponent<Image>();
     Dian1_1LevelBg = transform.Find("Bg/Panel/DianPanel/Ice1/ice1/Level/bg").GetComponent<Image>();
     Dian1_1LevelCount = transform.Find("Bg/Panel/DianPanel/Ice1/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Dian1_1XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice1/ice1/xuanzhong").GetComponent<Image>();

     Dian1_2Bg = transform.Find("Bg/Panel/DianPanel/Ice1/ice2/bg").GetComponent<Image>();
     Dian1_2Icon = transform.Find("Bg/Panel/DianPanel/Ice1/ice2/icon").GetComponent<Image>();
     Dian1_2LevelBg = transform.Find("Bg/Panel/DianPanel/Ice1/ice2/Level/bg").GetComponent<Image>();
     Dian1_2LevelCount = transform.Find("Bg/Panel/DianPanel/Ice1/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Dian1_2XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice1/ice2/xuanzhong").GetComponent<Image>();




     Dian2Bg = transform.Find("Bg/Panel/DianPanel/Ice2/ice/bg").GetComponent<Image>();
     Dian2Icon = transform.Find("Bg/Panel/DianPanel/Ice2/ice/icon").GetComponent<Image>();
     Dian2XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice2/ice/xuanzhong").GetComponent<Image>();
     Dian2LevelBg = transform.Find("Bg/Panel/DianPanel/Ice2/ice/Level/bg").GetComponent<Image>();
     Dian2LevelCount = transform.Find("Bg/Panel/DianPanel/Ice2/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Dian2AutoBg = transform.Find("Bg/Panel/DianPanel/Ice2/ice/Auto/bg").GetComponent<Image>();
     Dian2AutoCount = transform.Find("Bg/Panel/DianPanel/Ice2/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Dian2KeyBg = transform.Find("Bg/Panel/DianPanel/Ice2/ice/key/bg").GetComponent<Image>();
     Dian2KeyCount = transform.Find("Bg/Panel/DianPanel/Ice2/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Dian2_1Bg = transform.Find("Bg/Panel/DianPanel/Ice2/ice1/bg").GetComponent<Image>();
     Dian2_1Icon = transform.Find("Bg/Panel/DianPanel/Ice2/ice1/icon").GetComponent<Image>();
     Dian2_1LevelBg = transform.Find("Bg/Panel/DianPanel/Ice2/ice1/Level/bg").GetComponent<Image>();
     Dian2_1LevelCount = transform.Find("Bg/Panel/DianPanel/Ice2/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Dian2_1XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice2/ice1/xuanzhong").GetComponent<Image>();

     Dian2_2Bg = transform.Find("Bg/Panel/DianPanel/Ice2/ice2/bg").GetComponent<Image>();
     Dian2_2Icon = transform.Find("Bg/Panel/DianPanel/Ice2/ice2/icon").GetComponent<Image>();
     Dian2_2LevelBg = transform.Find("Bg/Panel/DianPanel/Ice2/ice2/Level/bg").GetComponent<Image>();
     Dian2_2LevelCount = transform.Find("Bg/Panel/DianPanel/Ice2/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Dian2_2XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice2/ice2/xuanzhong").GetComponent<Image>();




     Dian3Bg = transform.Find("Bg/Panel/DianPanel/Ice3/ice/bg").GetComponent<Image>();
     Dian3Icon = transform.Find("Bg/Panel/DianPanel/Ice3/ice/icon").GetComponent<Image>();
     Dian3XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice3/ice/xuanzhong").GetComponent<Image>();
     Dian3LevelBg = transform.Find("Bg/Panel/DianPanel/Ice3/ice/Level/bg").GetComponent<Image>();
     Dian3LevelCount = transform.Find("Bg/Panel/DianPanel/Ice3/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Dian3AutoBg = transform.Find("Bg/Panel/DianPanel/Ice3/ice/Auto/bg").GetComponent<Image>();
     Dian3AutoCount = transform.Find("Bg/Panel/DianPanel/Ice3/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Dian3KeyBg = transform.Find("Bg/Panel/DianPanel/Ice3/ice/key/bg").GetComponent<Image>();
     Dian3KeyCount = transform.Find("Bg/Panel/DianPanel/Ice3/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Dian3_1Bg = transform.Find("Bg/Panel/DianPanel/Ice3/ice1/bg").GetComponent<Image>();
     Dian3_1Icon = transform.Find("Bg/Panel/DianPanel/Ice3/ice1/icon").GetComponent<Image>();
     Dian3_1LevelBg = transform.Find("Bg/Panel/DianPanel/Ice3/ice1/Level/bg").GetComponent<Image>();
     Dian3_1LevelCount = transform.Find("Bg/Panel/DianPanel/Ice3/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Dian3_1XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice3/ice1/xuanzhong").GetComponent<Image>();

     Dian3_2Bg = transform.Find("Bg/Panel/DianPanel/Ice3/ice2/bg").GetComponent<Image>();
     Dian3_2Icon = transform.Find("Bg/Panel/DianPanel/Ice3/ice2/icon").GetComponent<Image>();
     Dian3_2LevelBg = transform.Find("Bg/Panel/DianPanel/Ice3/ice2/Level/bg").GetComponent<Image>();
     Dian3_2LevelCount = transform.Find("Bg/Panel/DianPanel/Ice3/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Dian3_2XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice3/ice2/xuanzhong").GetComponent<Image>();


     Dian4Bg = transform.Find("Bg/Panel/DianPanel/Ice4/ice/bg").GetComponent<Image>();
     Dian4Icon = transform.Find("Bg/Panel/DianPanel/Ice4/ice/icon").GetComponent<Image>();
     Dian4XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice4/ice/xuanzhong").GetComponent<Image>();
     Dian4LevelBg = transform.Find("Bg/Panel/DianPanel/Ice4/ice/Level/bg").GetComponent<Image>();
     Dian4LevelCount = transform.Find("Bg/Panel/DianPanel/Ice4/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Dian4AutoBg = transform.Find("Bg/Panel/DianPanel/Ice4/ice/Auto/bg").GetComponent<Image>();
     Dian4AutoCount = transform.Find("Bg/Panel/DianPanel/Ice4/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Dian4KeyBg = transform.Find("Bg/Panel/DianPanel/Ice4/ice/key/bg").GetComponent<Image>();
     Dian4KeyCount = transform.Find("Bg/Panel/DianPanel/Ice4/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Dian4_1Bg = transform.Find("Bg/Panel/DianPanel/Ice4/ice1/bg").GetComponent<Image>();
     Dian4_1Icon = transform.Find("Bg/Panel/DianPanel/Ice4/ice1/icon").GetComponent<Image>();
     Dian4_1LevelBg = transform.Find("Bg/Panel/DianPanel/Ice4/ice1/Level/bg").GetComponent<Image>();
     Dian4_1LevelCount = transform.Find("Bg/Panel/DianPanel/Ice4/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Dian4_1XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice4/ice1/xuanzhong").GetComponent<Image>();

     Dian4_2Bg = transform.Find("Bg/Panel/DianPanel/Ice4/ice2/bg").GetComponent<Image>();
     Dian4_2Icon = transform.Find("Bg/Panel/DianPanel/Ice4/ice2/icon").GetComponent<Image>();
     Dian4_2LevelBg = transform.Find("Bg/Panel/DianPanel/Ice4/ice2/Level/bg").GetComponent<Image>();
     Dian4_2LevelCount = transform.Find("Bg/Panel/DianPanel/Ice4/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Dian4_2XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice4/ice2/xuanzhong").GetComponent<Image>();




     Dian5Bg = transform.Find("Bg/Panel/DianPanel/Ice5/ice/bg").GetComponent<Image>();
     Dian5Icon = transform.Find("Bg/Panel/DianPanel/Ice5/ice/icon").GetComponent<Image>();
     Dian5XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice5/ice/xuanzhong").GetComponent<Image>();
     Dian5LevelBg = transform.Find("Bg/Panel/DianPanel/Ice5/ice/Level/bg").GetComponent<Image>();
     Dian5LevelCount = transform.Find("Bg/Panel/DianPanel/Ice5/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     Dian5AutoBg = transform.Find("Bg/Panel/DianPanel/Ice5/ice/Auto/bg").GetComponent<Image>();
     Dian5AutoCount = transform.Find("Bg/Panel/DianPanel/Ice5/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     Dian5KeyBg = transform.Find("Bg/Panel/DianPanel/Ice5/ice/key/bg").GetComponent<Image>();
     Dian5KeyCount = transform.Find("Bg/Panel/DianPanel/Ice5/ice/key/icon").GetComponent<TextMeshProUGUI>();


     Dian5_1Bg = transform.Find("Bg/Panel/DianPanel/Ice5/ice1/bg").GetComponent<Image>();
     Dian5_1Icon = transform.Find("Bg/Panel/DianPanel/Ice5/ice1/icon").GetComponent<Image>();
     Dian5_1LevelBg = transform.Find("Bg/Panel/DianPanel/Ice5/ice1/Level/bg").GetComponent<Image>();
     Dian5_1LevelCount = transform.Find("Bg/Panel/DianPanel/Ice5/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     Dian5_1XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice5/ice1/xuanzhong").GetComponent<Image>();

     Dian5_2Bg = transform.Find("Bg/Panel/DianPanel/Ice5/ice2/bg").GetComponent<Image>();
     Dian5_2Icon = transform.Find("Bg/Panel/DianPanel/Ice5/ice2/icon").GetComponent<Image>();
     Dian5_2LevelBg = transform.Find("Bg/Panel/DianPanel/Ice5/ice2/Level/bg").GetComponent<Image>();
     Dian5_2LevelCount = transform.Find("Bg/Panel/DianPanel/Ice5/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     Dian5_2XuanZhong = transform.Find("Bg/Panel/DianPanel/Ice5/ice2/xuanzhong").GetComponent<Image>();




     HeiAn1Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice/bg").GetComponent<Image>();
     HeiAn1Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice/icon").GetComponent<Image>();
     HeiAn1XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice/xuanzhong").GetComponent<Image>();
     HeiAn1LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice/Level/bg").GetComponent<Image>();
     HeiAn1LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     HeiAn1AutoBg = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice/Auto/bg").GetComponent<Image>();
     HeiAn1AutoCount = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     HeiAn1KeyBg = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice/key/bg").GetComponent<Image>();
     HeiAn1KeyCount = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice/key/icon").GetComponent<TextMeshProUGUI>();


     HeiAn1_1Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice1/bg").GetComponent<Image>();
     HeiAn1_1Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice1/icon").GetComponent<Image>();
     HeiAn1_1LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice1/Level/bg").GetComponent<Image>();
     HeiAn1_1LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAn1_1XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice1/xuanzhong").GetComponent<Image>();

     HeiAn1_2Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice2/bg").GetComponent<Image>();
     HeiAn1_2Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice2/icon").GetComponent<Image>();
     HeiAn1_2LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice2/Level/bg").GetComponent<Image>();
     HeiAn1_2LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAn1_2XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice1/ice2/xuanzhong").GetComponent<Image>();




     HeiAn2Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice/bg").GetComponent<Image>();
     HeiAn2Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice/icon").GetComponent<Image>();
     HeiAn2XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice/xuanzhong").GetComponent<Image>();
     HeiAn2LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice/Level/bg").GetComponent<Image>();
     HeiAn2LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     HeiAn2AutoBg = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice/Auto/bg").GetComponent<Image>();
     HeiAn2AutoCount = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     HeiAn2KeyBg = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice/key/bg").GetComponent<Image>();
     HeiAn2KeyCount = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice/key/icon").GetComponent<TextMeshProUGUI>();


     HeiAn2_1Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice1/bg").GetComponent<Image>();
     HeiAn2_1Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice1/icon").GetComponent<Image>();
     HeiAn2_1LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice1/Level/bg").GetComponent<Image>();
     HeiAn2_1LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAn2_1XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice1/xuanzhong").GetComponent<Image>();

     HeiAn2_2Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice2/bg").GetComponent<Image>();
     HeiAn2_2Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice2/icon").GetComponent<Image>();
     HeiAn2_2LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice2/Level/bg").GetComponent<Image>();
     HeiAn2_2LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAn2_2XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice2/ice2/xuanzhong").GetComponent<Image>();




     HeiAn3Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice/bg").GetComponent<Image>();
     HeiAn3Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice/icon").GetComponent<Image>();
     HeiAn3XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice/xuanzhong").GetComponent<Image>();
     HeiAn3LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice/Level/bg").GetComponent<Image>();
     HeiAn3LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     HeiAn3AutoBg = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice/Auto/bg").GetComponent<Image>();
     HeiAn3AutoCount = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     HeiAn3KeyBg = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice/key/bg").GetComponent<Image>();
     HeiAn3KeyCount = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice/key/icon").GetComponent<TextMeshProUGUI>();


     HeiAn3_1Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice1/bg").GetComponent<Image>();
     HeiAn3_1Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice1/icon").GetComponent<Image>();
     HeiAn3_1LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice1/Level/bg").GetComponent<Image>();
     HeiAn3_1LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAn3_1XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice1/xuanzhong").GetComponent<Image>();

     HeiAn3_2Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice2/bg").GetComponent<Image>();
     HeiAn3_2Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice2/icon").GetComponent<Image>();
     HeiAn3_2LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice2/Level/bg").GetComponent<Image>();
     HeiAn3_2LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAn3_2XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice3/ice2/xuanzhong").GetComponent<Image>();


     HeiAn4Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice/bg").GetComponent<Image>();
     HeiAn4Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice/icon").GetComponent<Image>();
     HeiAn4XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice/xuanzhong").GetComponent<Image>();
     HeiAn4LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice/Level/bg").GetComponent<Image>();
     HeiAn4LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     HeiAn4AutoBg = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice/Auto/bg").GetComponent<Image>();
     HeiAn4AutoCount = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     HeiAn4KeyBg = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice/key/bg").GetComponent<Image>();
     HeiAn4KeyCount = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice/key/icon").GetComponent<TextMeshProUGUI>();


     HeiAn4_1Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice1/bg").GetComponent<Image>();
     HeiAn4_1Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice1/icon").GetComponent<Image>();
     HeiAn4_1LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice1/Level/bg").GetComponent<Image>();
     HeiAn4_1LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAn4_1XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice1/xuanzhong").GetComponent<Image>();

     HeiAn4_2Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice2/bg").GetComponent<Image>();
     HeiAn4_2Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice2/icon").GetComponent<Image>();
     HeiAn4_2LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice2/Level/bg").GetComponent<Image>();
     HeiAn4_2LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAn4_2XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice4/ice2/xuanzhong").GetComponent<Image>();




     HeiAn5Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice/bg").GetComponent<Image>();
     HeiAn5Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice/icon").GetComponent<Image>();
     HeiAn5XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice/xuanzhong").GetComponent<Image>();
     HeiAn5LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice/Level/bg").GetComponent<Image>();
     HeiAn5LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice/Level/icon").GetComponent<TextMeshProUGUI>();
     HeiAn5AutoBg = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice/Auto/bg").GetComponent<Image>();
     HeiAn5AutoCount = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice/Auto/icon").GetComponent<TextMeshProUGUI>();
     HeiAn5KeyBg = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice/key/bg").GetComponent<Image>();
     HeiAn5KeyCount = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice/key/icon").GetComponent<TextMeshProUGUI>();


     HeiAn5_1Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice1/bg").GetComponent<Image>();
     HeiAn5_1Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice1/icon").GetComponent<Image>();
     HeiAn5_1LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice1/Level/bg").GetComponent<Image>();
     HeiAn5_1LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice1/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAn5_1XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice1/xuanzhong").GetComponent<Image>();

     HeiAn5_2Bg = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice2/bg").GetComponent<Image>();
     HeiAn5_2Icon = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice2/icon").GetComponent<Image>();
     HeiAn5_2LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice2/Level/bg").GetComponent<Image>();
     HeiAn5_2LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice2/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAn5_2XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Ice5/ice2/xuanzhong").GetComponent<Image>();

     IceZJ1Bg = transform.Find("Bg/Panel/ZJPanel/Ice/1/bg").GetComponent<Image>();
     IceZJ1Icon = transform.Find("Bg/Panel/ZJPanel/Ice/1/icon").GetComponent<Image>();
     IceZJ1LevelBg = transform.Find("Bg/Panel/ZJPanel/Ice/1/Level/bg").GetComponent<Image>();
     IceZJ1LevelCount = transform.Find("Bg/Panel/ZJPanel/Ice/1/Level/level").GetComponent<TextMeshProUGUI>();
     IceZJ1XuanZhong = transform.Find("Bg/Panel/ZJPanel/Ice/1/xuanzhong").GetComponent<Image>();


     IceZJ2Bg = transform.Find("Bg/Panel/ZJPanel/Ice/2/bg").GetComponent<Image>();
     IceZJ2Icon = transform.Find("Bg/Panel/ZJPanel/Ice/2/icon").GetComponent<Image>();
     IceZJ2LevelBg = transform.Find("Bg/Panel/ZJPanel/Ice/2/Level/bg").GetComponent<Image>();
     IceZJ2LevelCount = transform.Find("Bg/Panel/ZJPanel/Ice/2/Level/level").GetComponent<TextMeshProUGUI>();
     IceZJ2XuanZhong = transform.Find("Bg/Panel/ZJPanel/Ice/2/xuanzhong").GetComponent<Image>();


     IceZJ3Bg = transform.Find("Bg/Panel/ZJPanel/Ice/3/bg").GetComponent<Image>();
     IceZJ3Icon = transform.Find("Bg/Panel/ZJPanel/Ice/3/icon").GetComponent<Image>();
     IceZJ3LevelBg = transform.Find("Bg/Panel/ZJPanel/Ice/3/Level/bg").GetComponent<Image>();
     IceZJ3LevelCount = transform.Find("Bg/Panel/ZJPanel/Ice/3/Level/level").GetComponent<TextMeshProUGUI>();
     IceZJ3XuanZhong = transform.Find("Bg/Panel/ZJPanel/Ice/3/xuanzhong").GetComponent<Image>();


     IceZJ4Bg = transform.Find("Bg/Panel/ZJPanel/Ice/4/bg").GetComponent<Image>();
     IceZJ4Icon = transform.Find("Bg/Panel/ZJPanel/Ice/4/icon").GetComponent<Image>();
     IceZJ4LevelBg = transform.Find("Bg/Panel/ZJPanel/Ice/4/Level/bg").GetComponent<Image>();
     IceZJ4LevelCount = transform.Find("Bg/Panel/ZJPanel/Ice/4/Level/level").GetComponent<TextMeshProUGUI>();
     IceZJ4XuanZhong = transform.Find("Bg/Panel/ZJPanel/Ice/4/xuanzhong").GetComponent<Image>();


     IceZJ5Bg = transform.Find("Bg/Panel/ZJPanel/Ice/5/bg").GetComponent<Image>();
     IceZJ5Icon = transform.Find("Bg/Panel/ZJPanel/Ice/5/icon").GetComponent<Image>();
     IceZJ5LevelBg = transform.Find("Bg/Panel/ZJPanel/Ice/5/Level/bg").GetComponent<Image>();
     IceZJ5LevelCount = transform.Find("Bg/Panel/ZJPanel/Ice/5/Level/level").GetComponent<TextMeshProUGUI>();
     IceZJ5XuanZhong = transform.Find("Bg/Panel/ZJPanel/Ice/5/xuanzhong").GetComponent<Image>();


     IceZJ6Bg = transform.Find("Bg/Panel/ZJPanel/Ice/6/bg").GetComponent<Image>();
     IceZJ6Icon = transform.Find("Bg/Panel/ZJPanel/Ice/6/icon").GetComponent<Image>();
     IceZJ6LevelBg = transform.Find("Bg/Panel/ZJPanel/Ice/6/Level/bg").GetComponent<Image>();
     IceZJ6LevelCount = transform.Find("Bg/Panel/ZJPanel/Ice/6/Level/level").GetComponent<TextMeshProUGUI>();
     IceZJ6XuanZhong = transform.Find("Bg/Panel/ZJPanel/Ice/6/xuanzhong").GetComponent<Image>();


     IceZJMainBg = transform.Find("Bg/Panel/ZJPanel/Ice/Main/bg").GetComponent<Image>();
     IceZJMainIcon = transform.Find("Bg/Panel/ZJPanel/Ice/Main/icon").GetComponent<Image>();
     IceZJMainLevelBg = transform.Find("Bg/Panel/ZJPanel/Ice/Main/Level/bg").GetComponent<Image>();
     IceZJMainLevelCount = transform.Find("Bg/Panel/ZJPanel/Ice/Main/Level/level").GetComponent<TextMeshProUGUI>();
     IceZJMainXuanZhong = transform.Find("Bg/Panel/ZJPanel/Ice/Main/xuanzhong").GetComponent<Image>();





     HuoZJ1Bg = transform.Find("Bg/Panel/ZJPanel/Huo/1/bg").GetComponent<Image>();
     HuoZJ1Icon = transform.Find("Bg/Panel/ZJPanel/Huo/1/icon").GetComponent<Image>();
     HuoZJ1LevelBg = transform.Find("Bg/Panel/ZJPanel/Huo/1/Level/bg").GetComponent<Image>();
     HuoZJ1LevelCount = transform.Find("Bg/Panel/ZJPanel/Huo/1/Level/level").GetComponent<TextMeshProUGUI>();
     HuoZJ1XuanZhong = transform.Find("Bg/Panel/ZJPanel/Huo/1/xuanzhong").GetComponent<Image>();


     HuoZJ2Bg = transform.Find("Bg/Panel/ZJPanel/Huo/2/bg").GetComponent<Image>();
     HuoZJ2Icon = transform.Find("Bg/Panel/ZJPanel/Huo/2/icon").GetComponent<Image>();
     HuoZJ2LevelBg = transform.Find("Bg/Panel/ZJPanel/Huo/2/Level/bg").GetComponent<Image>();
     HuoZJ2LevelCount = transform.Find("Bg/Panel/ZJPanel/Huo/2/Level/level").GetComponent<TextMeshProUGUI>();
     HuoZJ2XuanZhong = transform.Find("Bg/Panel/ZJPanel/Huo/2/xuanzhong").GetComponent<Image>();


     HuoZJ3Bg = transform.Find("Bg/Panel/ZJPanel/Huo/3/bg").GetComponent<Image>();
     HuoZJ3Icon = transform.Find("Bg/Panel/ZJPanel/Huo/3/icon").GetComponent<Image>();
     HuoZJ3LevelBg = transform.Find("Bg/Panel/ZJPanel/Huo/3/Level/bg").GetComponent<Image>();
     HuoZJ3LevelCount = transform.Find("Bg/Panel/ZJPanel/Huo/3/Level/level").GetComponent<TextMeshProUGUI>();
     HuoZJ3XuanZhong = transform.Find("Bg/Panel/ZJPanel/Huo/3/xuanzhong").GetComponent<Image>();


     HuoZJ4Bg = transform.Find("Bg/Panel/ZJPanel/Huo/4/bg").GetComponent<Image>();
     HuoZJ4Icon = transform.Find("Bg/Panel/ZJPanel/Huo/4/icon").GetComponent<Image>();
     HuoZJ4LevelBg = transform.Find("Bg/Panel/ZJPanel/Huo/4/Level/bg").GetComponent<Image>();
     HuoZJ4LevelCount = transform.Find("Bg/Panel/ZJPanel/Huo/4/Level/level").GetComponent<TextMeshProUGUI>();
     HuoZJ4XuanZhong = transform.Find("Bg/Panel/ZJPanel/Huo/4/xuanzhong").GetComponent<Image>();


     HuoZJ5Bg = transform.Find("Bg/Panel/ZJPanel/Huo/5/bg").GetComponent<Image>();
     HuoZJ5Icon = transform.Find("Bg/Panel/ZJPanel/Huo/5/icon").GetComponent<Image>();
     HuoZJ5LevelBg = transform.Find("Bg/Panel/ZJPanel/Huo/5/Level/bg").GetComponent<Image>();
     HuoZJ5LevelCount = transform.Find("Bg/Panel/ZJPanel/Huo/5/Level/level").GetComponent<TextMeshProUGUI>();
     HuoZJ5XuanZhong = transform.Find("Bg/Panel/ZJPanel/Huo/5/xuanzhong").GetComponent<Image>();


     HuoZJ6Bg = transform.Find("Bg/Panel/ZJPanel/Huo/6/bg").GetComponent<Image>();
     HuoZJ6Icon = transform.Find("Bg/Panel/ZJPanel/Huo/6/icon").GetComponent<Image>();
     HuoZJ6LevelBg = transform.Find("Bg/Panel/ZJPanel/Huo/6/Level/bg").GetComponent<Image>();
     HuoZJ6LevelCount = transform.Find("Bg/Panel/ZJPanel/Huo/6/Level/level").GetComponent<TextMeshProUGUI>();
     HuoZJ6XuanZhong = transform.Find("Bg/Panel/ZJPanel/Huo/6/xuanzhong").GetComponent<Image>();


     HuoZJMainBg = transform.Find("Bg/Panel/ZJPanel/Huo/Main/bg").GetComponent<Image>();
     HuoZJMainIcon = transform.Find("Bg/Panel/ZJPanel/Huo/Main/icon").GetComponent<Image>();
     HuoZJMainLevelBg = transform.Find("Bg/Panel/ZJPanel/Huo/Main/Level/bg").GetComponent<Image>();
     HuoZJMainLevelCount = transform.Find("Bg/Panel/ZJPanel/Huo/Main/Level/level").GetComponent<TextMeshProUGUI>();
     HuoZJMainXuanZhong = transform.Find("Bg/Panel/ZJPanel/Huo/Main/xuanzhong").GetComponent<Image>();







     DianZJ1Bg = transform.Find("Bg/Panel/ZJPanel/Dian/1/bg").GetComponent<Image>();
     DianZJ1Icon = transform.Find("Bg/Panel/ZJPanel/Dian/1/icon").GetComponent<Image>();
     DianZJ1LevelBg = transform.Find("Bg/Panel/ZJPanel/Dian/1/Level/bg").GetComponent<Image>();
     DianZJ1LevelCount = transform.Find("Bg/Panel/ZJPanel/Dian/1/Level/level").GetComponent<TextMeshProUGUI>();
     DianZJ1XuanZhong = transform.Find("Bg/Panel/ZJPanel/Dian/1/xuanzhong").GetComponent<Image>();


     DianZJ2Bg = transform.Find("Bg/Panel/ZJPanel/Dian/2/bg").GetComponent<Image>();
     DianZJ2Icon = transform.Find("Bg/Panel/ZJPanel/Dian/2/icon").GetComponent<Image>();
     DianZJ2LevelBg = transform.Find("Bg/Panel/ZJPanel/Dian/2/Level/bg").GetComponent<Image>();
     DianZJ2LevelCount = transform.Find("Bg/Panel/ZJPanel/Dian/2/Level/level").GetComponent<TextMeshProUGUI>();
     DianZJ2XuanZhong = transform.Find("Bg/Panel/ZJPanel/Dian/2/xuanzhong").GetComponent<Image>();


     DianZJ3Bg = transform.Find("Bg/Panel/ZJPanel/Dian/3/bg").GetComponent<Image>();
     DianZJ3Icon = transform.Find("Bg/Panel/ZJPanel/Dian/3/icon").GetComponent<Image>();
     DianZJ3LevelBg = transform.Find("Bg/Panel/ZJPanel/Dian/3/Level/bg").GetComponent<Image>();
     DianZJ3LevelCount = transform.Find("Bg/Panel/ZJPanel/Dian/3/Level/level").GetComponent<TextMeshProUGUI>();
     DianZJ3XuanZhong = transform.Find("Bg/Panel/ZJPanel/Dian/3/xuanzhong").GetComponent<Image>();


     DianZJ4Bg = transform.Find("Bg/Panel/ZJPanel/Dian/4/bg").GetComponent<Image>();
     DianZJ4Icon = transform.Find("Bg/Panel/ZJPanel/Dian/4/icon").GetComponent<Image>();
     DianZJ4LevelBg = transform.Find("Bg/Panel/ZJPanel/Dian/4/Level/bg").GetComponent<Image>();
     DianZJ4LevelCount = transform.Find("Bg/Panel/ZJPanel/Dian/4/Level/level").GetComponent<TextMeshProUGUI>();
     DianZJ4XuanZhong = transform.Find("Bg/Panel/ZJPanel/Dian/4/xuanzhong").GetComponent<Image>();


     DianZJ5Bg = transform.Find("Bg/Panel/ZJPanel/Dian/5/bg").GetComponent<Image>();
     DianZJ5Icon = transform.Find("Bg/Panel/ZJPanel/Dian/5/icon").GetComponent<Image>();
     DianZJ5LevelBg = transform.Find("Bg/Panel/ZJPanel/Dian/5/Level/bg").GetComponent<Image>();
     DianZJ5LevelCount = transform.Find("Bg/Panel/ZJPanel/Dian/5/Level/level").GetComponent<TextMeshProUGUI>();
     DianZJ5XuanZhong = transform.Find("Bg/Panel/ZJPanel/Dian/5/xuanzhong").GetComponent<Image>();


     DianZJ6Bg = transform.Find("Bg/Panel/ZJPanel/Dian/6/bg").GetComponent<Image>();
     DianZJ6Icon = transform.Find("Bg/Panel/ZJPanel/Dian/6/icon").GetComponent<Image>();
     DianZJ6LevelBg = transform.Find("Bg/Panel/ZJPanel/Dian/6/Level/bg").GetComponent<Image>();
     DianZJ6LevelCount = transform.Find("Bg/Panel/ZJPanel/Dian/6/Level/level").GetComponent<TextMeshProUGUI>();
     DianZJ6XuanZhong = transform.Find("Bg/Panel/ZJPanel/Dian/6/xuanzhong").GetComponent<Image>();


     DianZJMainBg = transform.Find("Bg/Panel/ZJPanel/Dian/Main/bg").GetComponent<Image>();
     DianZJMainIcon = transform.Find("Bg/Panel/ZJPanel/Dian/Main/icon").GetComponent<Image>();
     DianZJMainLevelBg = transform.Find("Bg/Panel/ZJPanel/Dian/Main/Level/bg").GetComponent<Image>();
     DianZJMainLevelCount = transform.Find("Bg/Panel/ZJPanel/Dian/Main/Level/level").GetComponent<TextMeshProUGUI>();
     DianZJMainXuanZhong = transform.Find("Bg/Panel/ZJPanel/Dian/Main/xuanzhong").GetComponent<Image>();










     HeiAnZJ1Bg = transform.Find("Bg/Panel/ZJPanel/HeiAn/1/bg").GetComponent<Image>();
     HeiAnZJ1Icon = transform.Find("Bg/Panel/ZJPanel/HeiAn/1/icon").GetComponent<Image>();
     HeiAnZJ1LevelBg = transform.Find("Bg/Panel/ZJPanel/HeiAn/1/Level/bg").GetComponent<Image>();
     HeiAnZJ1LevelCount = transform.Find("Bg/Panel/ZJPanel/HeiAn/1/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAnZJ1XuanZhong = transform.Find("Bg/Panel/ZJPanel/HeiAn/1/xuanzhong").GetComponent<Image>();


     HeiAnZJ2Bg = transform.Find("Bg/Panel/ZJPanel/HeiAn/2/bg").GetComponent<Image>();
     HeiAnZJ2Icon = transform.Find("Bg/Panel/ZJPanel/HeiAn/2/icon").GetComponent<Image>();
     HeiAnZJ2LevelBg = transform.Find("Bg/Panel/ZJPanel/HeiAn/2/Level/bg").GetComponent<Image>();
     HeiAnZJ2LevelCount = transform.Find("Bg/Panel/ZJPanel/HeiAn/2/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAnZJ2XuanZhong = transform.Find("Bg/Panel/ZJPanel/HeiAn/2/xuanzhong").GetComponent<Image>();


     HeiAnZJ3Bg = transform.Find("Bg/Panel/ZJPanel/HeiAn/3/bg").GetComponent<Image>();
     HeiAnZJ3Icon = transform.Find("Bg/Panel/ZJPanel/HeiAn/3/icon").GetComponent<Image>();
     HeiAnZJ3LevelBg = transform.Find("Bg/Panel/ZJPanel/HeiAn/3/Level/bg").GetComponent<Image>();
     HeiAnZJ3LevelCount = transform.Find("Bg/Panel/ZJPanel/HeiAn/3/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAnZJ3XuanZhong = transform.Find("Bg/Panel/ZJPanel/HeiAn/3/xuanzhong").GetComponent<Image>();


     HeiAnZJ4Bg = transform.Find("Bg/Panel/ZJPanel/HeiAn/4/bg").GetComponent<Image>();
     HeiAnZJ4Icon = transform.Find("Bg/Panel/ZJPanel/HeiAn/4/icon").GetComponent<Image>();
     HeiAnZJ4LevelBg = transform.Find("Bg/Panel/ZJPanel/HeiAn/4/Level/bg").GetComponent<Image>();
     HeiAnZJ4LevelCount = transform.Find("Bg/Panel/ZJPanel/HeiAn/4/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAnZJ4XuanZhong = transform.Find("Bg/Panel/ZJPanel/HeiAn/4/xuanzhong").GetComponent<Image>();


     HeiAnZJ5Bg = transform.Find("Bg/Panel/ZJPanel/HeiAn/5/bg").GetComponent<Image>();
     HeiAnZJ5Icon = transform.Find("Bg/Panel/ZJPanel/HeiAn/5/icon").GetComponent<Image>();
     HeiAnZJ5LevelBg = transform.Find("Bg/Panel/ZJPanel/HeiAn/5/Level/bg").GetComponent<Image>();
     HeiAnZJ5LevelCount = transform.Find("Bg/Panel/ZJPanel/HeiAn/5/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAnZJ5XuanZhong = transform.Find("Bg/Panel/ZJPanel/HeiAn/5/xuanzhong").GetComponent<Image>();


     HeiAnZJ6Bg = transform.Find("Bg/Panel/ZJPanel/HeiAn/6/bg").GetComponent<Image>();
     HeiAnZJ6Icon = transform.Find("Bg/Panel/ZJPanel/HeiAn/6/icon").GetComponent<Image>();
     HeiAnZJ6LevelBg = transform.Find("Bg/Panel/ZJPanel/HeiAn/6/Level/bg").GetComponent<Image>();
     HeiAnZJ6LevelCount = transform.Find("Bg/Panel/ZJPanel/HeiAn/6/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAnZJ6XuanZhong = transform.Find("Bg/Panel/ZJPanel/HeiAn/6/xuanzhong").GetComponent<Image>();


     HeiAnZJMainBg = transform.Find("Bg/Panel/ZJPanel/HeiAn/Main/bg").GetComponent<Image>();
     HeiAnZJMainIcon = transform.Find("Bg/Panel/ZJPanel/HeiAn/Main/icon").GetComponent<Image>();
     HeiAnZJMainLevelBg = transform.Find("Bg/Panel/ZJPanel/HeiAn/Main/Level/bg").GetComponent<Image>();
     HeiAnZJMainLevelCount = transform.Find("Bg/Panel/ZJPanel/HeiAn/Main/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAnZJMainXuanZhong = transform.Find("Bg/Panel/ZJPanel/HeiAn/Main/xuanzhong").GetComponent<Image>();


     IceBeiLine1Liang = transform.Find("Bg/Panel/IcePanel/BeiLine1/liang").GetComponent<GameObject>();
     IceBeiLine1An = transform.Find("Bg/Panel/IcePanel/BeiLine1/An").GetComponent<GameObject>();
     IceBeiLine2Liang = transform.Find("Bg/Panel/IcePanel/BeiLine2/liang").GetComponent<GameObject>();
     IceBeiLine2An = transform.Find("Bg/Panel/IcePanel/BeiLine2/An").GetComponent<GameObject>();

     Ice1Line1An = transform.Find("Bg/Panel/IcePanel/Ice1/Line1/An").GetComponent<GameObject>();
     Ice1Line1Liang = transform.Find("Bg/Panel/IcePanel/Ice1/Line1/liang").GetComponent<GameObject>();
     Ice1Line2An = transform.Find("Bg/Panel/IcePanel/Ice1/Line2/An").GetComponent<GameObject>();
     Ice1Line2Liang = transform.Find("Bg/Panel/IcePanel/Ice1/Line2/liang").GetComponent<GameObject>();

     Ice2Line1An = transform.Find("Bg/Panel/IcePanel/Ice2/Line1/An").GetComponent<GameObject>();
     Ice2Line1Liang = transform.Find("Bg/Panel/IcePanel/Ice2/Line1/liang").GetComponent<GameObject>();
     Ice2Line2An = transform.Find("Bg/Panel/IcePanel/Ice2/Line2/An").GetComponent<GameObject>();
     Ice2Line2Liang = transform.Find("Bg/Panel/IcePanel/Ice2/Line2/liang").GetComponent<GameObject>();

     Ice3Line1An = transform.Find("Bg/Panel/IcePanel/Ice3/Line1/An").GetComponent<GameObject>();
     Ice3Line1Liang = transform.Find("Bg/Panel/IcePanel/Ice3/Line1/liang").GetComponent<GameObject>();
     Ice3Line2An = transform.Find("Bg/Panel/IcePanel/Ice3/Line2/An").GetComponent<GameObject>();
     Ice3Line2Liang = transform.Find("Bg/Panel/IcePanel/Ice3/Line2/liang").GetComponent<GameObject>();

     Ice4Line1An = transform.Find("Bg/Panel/IcePanel/Ice4/Line1/An").GetComponent<GameObject>();
     Ice4Line1Liang = transform.Find("Bg/Panel/IcePanel/Ice4/Line1/liang").GetComponent<GameObject>();
     Ice4Line2An = transform.Find("Bg/Panel/IcePanel/Ice4/Line2/An").GetComponent<GameObject>();
     Ice4Line2Liang = transform.Find("Bg/Panel/IcePanel/Ice4/Line2/liang").GetComponent<GameObject>();

     Ice5Line1An = transform.Find("Bg/Panel/IcePanel/Ice5/Line1/An").GetComponent<GameObject>();
     Ice5Line1Liang = transform.Find("Bg/Panel/IcePanel/Ice5/Line1/liang").GetComponent<GameObject>();
     Ice5Line2An = transform.Find("Bg/Panel/IcePanel/Ice5/Line2/An").GetComponent<GameObject>();
     Ice5Line2Liang = transform.Find("Bg/Panel/IcePanel/Ice5/Line2/liang").GetComponent<GameObject>();

     HuoBeiLine1Liang = transform.Find("Bg/Panel/HuoPanel/BeiLine1/liang").GetComponent<GameObject>();
     HuoBeiLine1An = transform.Find("Bg/Panel/HuoPanel/BeiLine1/An").GetComponent<GameObject>();
     HuoBeiLine2Liang = transform.Find("Bg/Panel/HuoPanel/BeiLine2/liang").GetComponent<GameObject>();
     HuoBeiLine2An = transform.Find("Bg/Panel/HuoPanel/BeiLine2/An").GetComponent<GameObject>();

     Huo1Line1An = transform.Find("Bg/Panel/HuoPanel/Ice1/Line1/An").GetComponent<GameObject>();
     Huo1Line1Liang = transform.Find("Bg/Panel/HuoPanel/Ice1/Line1/liang").GetComponent<GameObject>();
     Huo1Line2An = transform.Find("Bg/Panel/HuoPanel/Ice1/Line2/An").GetComponent<GameObject>();
     Huo1Line2Liang = transform.Find("Bg/Panel/HuoPanel/Ice1/Line2/liang").GetComponent<GameObject>();

     Huo2Line1An = transform.Find("Bg/Panel/HuoPanel/Ice2/Line1/An").GetComponent<GameObject>();
     Huo2Line1Liang = transform.Find("Bg/Panel/HuoPanel/Ice2/Line1/liang").GetComponent<GameObject>();
     Huo2Line2An = transform.Find("Bg/Panel/HuoPanel/Ice2/Line2/An").GetComponent<GameObject>();
     Huo2Line2Liang = transform.Find("Bg/Panel/HuoPanel/Ice2/Line2/liang").GetComponent<GameObject>();

     Huo3Line1An = transform.Find("Bg/Panel/HuoPanel/Ice3/Line1/An").GetComponent<GameObject>();
     Huo3Line1Liang = transform.Find("Bg/Panel/HuoPanel/Ice3/Line1/liang").GetComponent<GameObject>();
     Huo3Line2An = transform.Find("Bg/Panel/HuoPanel/Ice3/Line2/An").GetComponent<GameObject>();
     Huo3Line2Liang = transform.Find("Bg/Panel/HuoPanel/Ice3/Line2/liang").GetComponent<GameObject>();

     Huo4Line1An = transform.Find("Bg/Panel/HuoPanel/Ice4/Line1/An").GetComponent<GameObject>();
     Huo4Line1Liang = transform.Find("Bg/Panel/HuoPanel/Ice4/Line1/liang").GetComponent<GameObject>();
     Huo4Line2An = transform.Find("Bg/Panel/HuoPanel/Ice4/Line2/An").GetComponent<GameObject>();
     Huo4Line2Liang = transform.Find("Bg/Panel/HuoPanel/Ice4/Line2/liang").GetComponent<GameObject>();

     Huo5Line1An = transform.Find("Bg/Panel/HuoPanel/Ice5/Line1/An").GetComponent<GameObject>();
     Huo5Line1Liang = transform.Find("Bg/Panel/HuoPanel/Ice5/Line1/liang").GetComponent<GameObject>();
     Huo5Line2An = transform.Find("Bg/Panel/HuoPanel/Ice5/Line2/An").GetComponent<GameObject>();
     Huo5Line2Liang = transform.Find("Bg/Panel/HuoPanel/Ice5/Line2/liang").GetComponent<GameObject>();



     DianBeiLine1Liang = transform.Find("Bg/Panel/DianPanel/BeiLine1/liang").GetComponent<GameObject>();
     DianBeiLine1An = transform.Find("Bg/Panel/DianPanel/BeiLine1/An").GetComponent<GameObject>();
     DianBeiLine2Liang = transform.Find("Bg/Panel/DianPanel/BeiLine2/liang").GetComponent<GameObject>();
     DianBeiLine2An = transform.Find("Bg/Panel/DianPanel/BeiLine2/An").GetComponent<GameObject>();

     Dian1Line1An = transform.Find("Bg/Panel/DianPanel/Ice1/Line1/An").GetComponent<GameObject>();
     Dian1Line1Liang = transform.Find("Bg/Panel/DianPanel/Ice1/Line1/liang").GetComponent<GameObject>();
     Dian1Line2An = transform.Find("Bg/Panel/DianPanel/Ice1/Line2/An").GetComponent<GameObject>();
     Dian1Line2Liang = transform.Find("Bg/Panel/DianPanel/Ice1/Line2/liang").GetComponent<GameObject>();

     Dian2Line1An = transform.Find("Bg/Panel/DianPanel/Ice2/Line1/An").GetComponent<GameObject>();
     Dian2Line1Liang = transform.Find("Bg/Panel/DianPanel/Ice2/Line1/liang").GetComponent<GameObject>();
     Dian2Line2An = transform.Find("Bg/Panel/DianPanel/Ice2/Line2/An").GetComponent<GameObject>();
     Dian2Line2Liang = transform.Find("Bg/Panel/DianPanel/Ice2/Line2/liang").GetComponent<GameObject>();

     Dian3Line1An = transform.Find("Bg/Panel/DianPanel/Ice3/Line1/An").GetComponent<GameObject>();
     Dian3Line1Liang = transform.Find("Bg/Panel/DianPanel/Ice3/Line1/liang").GetComponent<GameObject>();
     Dian3Line2An = transform.Find("Bg/Panel/DianPanel/Ice3/Line2/An").GetComponent<GameObject>();
     Dian3Line2Liang = transform.Find("Bg/Panel/DianPanel/Ice3/Line2/liang").GetComponent<GameObject>();

     Dian4Line1An = transform.Find("Bg/Panel/DianPanel/Ice4/Line1/An").GetComponent<GameObject>();
     Dian4Line1Liang = transform.Find("Bg/Panel/DianPanel/Ice4/Line1/liang").GetComponent<GameObject>();
     Dian4Line2An = transform.Find("Bg/Panel/DianPanel/Ice4/Line2/An").GetComponent<GameObject>();
     Dian4Line2Liang = transform.Find("Bg/Panel/DianPanel/Ice4/Line2/liang").GetComponent<GameObject>();

     Dian5Line1An = transform.Find("Bg/Panel/DianPanel/Ice5/Line1/An").GetComponent<GameObject>();
     Dian5Line1Liang = transform.Find("Bg/Panel/DianPanel/Ice5/Line1/liang").GetComponent<GameObject>();
     Dian5Line2An = transform.Find("Bg/Panel/DianPanel/Ice5/Line2/An").GetComponent<GameObject>();
     Dian5Line2Liang = transform.Find("Bg/Panel/DianPanel/Ice5/Line2/liang").GetComponent<GameObject>();


     HeiAnBeiLine1Liang = transform.Find("Bg/Panel/HeiAnPanel/BeiLine1/liang").GetComponent<GameObject>();
     HeiAnBeiLine1An = transform.Find("Bg/Panel/HeiAnPanel/BeiLine1/An").GetComponent<GameObject>();
     HeiAnBeiLine2Liang = transform.Find("Bg/Panel/HeiAnPanel/BeiLine2/liang").GetComponent<GameObject>();
     HeiAnBeiLine2An = transform.Find("Bg/Panel/HeiAnPanel/BeiLine2/An").GetComponent<GameObject>();

     HeiAn1Line1An = transform.Find("Bg/Panel/HeiAnPanel/Ice1/Line1/An").GetComponent<GameObject>();
     HeiAn1Line1Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice1/Line1/liang").GetComponent<GameObject>();
     HeiAn1Line2An = transform.Find("Bg/Panel/HeiAnPanel/Ice1/Line2/An").GetComponent<GameObject>();
     HeiAn1Line2Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice1/Line2/liang").GetComponent<GameObject>();

     HeiAn2Line1An = transform.Find("Bg/Panel/HeiAnPanel/Ice2/Line1/An").GetComponent<GameObject>();
     HeiAn2Line1Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice2/Line1/liang").GetComponent<GameObject>();
     HeiAn2Line2An = transform.Find("Bg/Panel/HeiAnPanel/Ice2/Line2/An").GetComponent<GameObject>();
     HeiAn2Line2Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice2/Line2/liang").GetComponent<GameObject>();

     HeiAn3Line1An = transform.Find("Bg/Panel/HeiAnPanel/Ice3/Line1/An").GetComponent<GameObject>();
     HeiAn3Line1Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice3/Line1/liang").GetComponent<GameObject>();
     HeiAn3Line2An = transform.Find("Bg/Panel/HeiAnPanel/Ice3/Line2/An").GetComponent<GameObject>();
     HeiAn3Line2Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice3/Line2/liang").GetComponent<GameObject>();

     HeiAn4Line1An = transform.Find("Bg/Panel/HeiAnPanel/Ice4/Line1/An").GetComponent<GameObject>();
     HeiAn4Line1Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice4/Line1/liang").GetComponent<GameObject>();
     HeiAn4Line2An = transform.Find("Bg/Panel/HeiAnPanel/Ice4/Line2/An").GetComponent<GameObject>();
     HeiAn4Line2Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice4/Line2/liang").GetComponent<GameObject>();

     HeiAn5Line1An = transform.Find("Bg/Panel/HeiAnPanel/Ice5/Line1/An").GetComponent<GameObject>();
     HeiAn5Line1Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice5/Line1/liang").GetComponent<GameObject>();
     HeiAn5Line2An = transform.Find("Bg/Panel/HeiAnPanel/Ice5/Line2/An").GetComponent<GameObject>();
     HeiAn5Line2Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice5/Line2/liang").GetComponent<GameObject>();


     IceZJLine1An = transform.Find("Bg/Panel/ZJPanel/Ice/Line1/An").GetComponent<GameObject>();
     IceZJLine1Liang = transform.Find("Bg/Panel/ZJPanel/Ice/Line1/liang").GetComponent<GameObject>();
     IceZJLine2An = transform.Find("Bg/Panel/ZJPanel/Ice/Line2/An").GetComponent<GameObject>();
     IceZJLine2Liang = transform.Find("Bg/Panel/ZJPanel/Ice/Line2/liang").GetComponent<GameObject>();
     IceZJLine3An = transform.Find("Bg/Panel/ZJPanel/Ice/Line3/An").GetComponent<GameObject>();
     IceZJLine3Liang = transform.Find("Bg/Panel/ZJPanel/Ice/Line3/liang").GetComponent<GameObject>();
     IceZJLine4An = transform.Find("Bg/Panel/ZJPanel/Ice/Line4/An").GetComponent<GameObject>();
     IceZJLine4Liang = transform.Find("Bg/Panel/ZJPanel/Ice/Line4/liang").GetComponent<GameObject>();
     IceZJLine5An = transform.Find("Bg/Panel/ZJPanel/Ice/Line5/An").GetComponent<GameObject>();
     IceZJLine5Liang = transform.Find("Bg/Panel/ZJPanel/Ice/Line5/liang").GetComponent<GameObject>();
     
     
     
     HuoZJLine1An = transform.Find("Bg/Panel/ZJPanel/Huo/Line1/An").GetComponent<GameObject>();
     HuoZJLine1Liang = transform.Find("Bg/Panel/ZJPanel/Huo/Line1/liang").GetComponent<GameObject>();
     HuoZJLine2An = transform.Find("Bg/Panel/ZJPanel/Huo/Line2/An").GetComponent<GameObject>();
     HuoZJLine2Liang = transform.Find("Bg/Panel/ZJPanel/Huo/Line2/liang").GetComponent<GameObject>();
     HuoZJLine3An = transform.Find("Bg/Panel/ZJPanel/Huo/Line3/An").GetComponent<GameObject>();
     HuoZJLine3Liang = transform.Find("Bg/Panel/ZJPanel/Huo/Line3/liang").GetComponent<GameObject>();
     HuoZJLine4An = transform.Find("Bg/Panel/ZJPanel/Huo/Line4/An").GetComponent<GameObject>();
     HuoZJLine4Liang = transform.Find("Bg/Panel/ZJPanel/Huo/Line4/liang").GetComponent<GameObject>();
     HuoZJLine5An = transform.Find("Bg/Panel/ZJPanel/Huo/Line5/An").GetComponent<GameObject>();
     HuoZJLine5Liang = transform.Find("Bg/Panel/ZJPanel/Huo/Line5/liang").GetComponent<GameObject>();
     
     
     DianZJLine1An = transform.Find("Bg/Panel/ZJPanel/Dian/Line1/An").GetComponent<GameObject>();
     DianZJLine1Liang = transform.Find("Bg/Panel/ZJPanel/Dian/Line1/liang").GetComponent<GameObject>();
     DianZJLine2An = transform.Find("Bg/Panel/ZJPanel/Dian/Line2/An").GetComponent<GameObject>();
     DianZJLine2Liang = transform.Find("Bg/Panel/ZJPanel/Dian/Line2/liang").GetComponent<GameObject>();
     DianZJLine3An = transform.Find("Bg/Panel/ZJPanel/Dian/Line3/An").GetComponent<GameObject>();
     DianZJLine3Liang = transform.Find("Bg/Panel/ZJPanel/Dian/Line3/liang").GetComponent<GameObject>();
     DianZJLine4An = transform.Find("Bg/Panel/ZJPanel/Dian/Line4/An").GetComponent<GameObject>();
     DianZJLine4Liang = transform.Find("Bg/Panel/ZJPanel/Dian/Line4/liang").GetComponent<GameObject>();
     DianZJLine5An = transform.Find("Bg/Panel/ZJPanel/Dian/Line5/An").GetComponent<GameObject>();
     DianZJLine5Liang = transform.Find("Bg/Panel/ZJPanel/Dian/Line5/liang").GetComponent<GameObject>();
     
     
     
     HeiAnZJLine1An = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line1/An").GetComponent<GameObject>();
     HeiAnZJLine1Liang = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line1/liang").GetComponent<GameObject>();
     HeiAnZJLine2An = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line2/An").GetComponent<GameObject>();
     HeiAnZJLine2Liang = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line2/liang").GetComponent<GameObject>();
     HeiAnZJLine3An = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line3/An").GetComponent<GameObject>();
     HeiAnZJLine3Liang = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line3/liang").GetComponent<GameObject>();
     HeiAnZJLine4An = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line4/An").GetComponent<GameObject>();
     HeiAnZJLine4Liang = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line4/liang").GetComponent<GameObject>();
     HeiAnZJLine5An = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line5/An").GetComponent<GameObject>();
     HeiAnZJLine5Liang = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line5/liang").GetComponent<GameObject>();
    }

    [Header("IcePanel")]
    public Image IceMainBg;
    public Image IceMainIcon;
    public TextMeshProUGUI IceMainLevelCount;
    public Image IceMainLevelBg;
    public Image IceMainXuanZhong;

    public Image IceBei1Bg;
    public Image IceBei1Icon;
    public TextMeshProUGUI IceBei1LevelCount;
    public Image IceBei1LevelBg;
    public Image IceBei1XuanZhong;

    public Image IceBei2Bg;
    public Image IceBei2Icon;
    public TextMeshProUGUI IceBei2LevelCount;
    public Image IceBei2LevelBg;
    public Image IceBei2XuanZhong;
    
    public Image IceBei3Bg;
    public Image IceBei3Icon;
    public TextMeshProUGUI IceBei3LevelCount;
    public Image IceBei3LevelBg;
    public Image IceBei3XuanZhong;
    
    public Image IceBei4Bg;
    public Image IceBei4Icon;
    public TextMeshProUGUI IceBei4LevelCount;
    public Image IceBei4LevelBg;
    public Image IceBei4XuanZhong;
    
    
    public Image Ice1Bg;
    public Image Ice1Icon;
    public TextMeshProUGUI Ice1LevelCount;
    public Image Ice1LevelBg;
    public Image Ice1XuanZhong;
    public TextMeshProUGUI Ice1AutoCount;
    public Image Ice1AutoBg;
    public TextMeshProUGUI Ice1KeyCount;
    public Image Ice1KeyBg;
    
    
    public Image Ice1_1Bg;
    public Image Ice1_1Icon;
    public TextMeshProUGUI Ice1_1LevelCount;
    public Image Ice1_1LevelBg;
    public Image Ice1_1XuanZhong;
    
    public Image Ice1_2Bg;
    public Image Ice1_2Icon;
    public TextMeshProUGUI Ice1_2LevelCount;
    public Image Ice1_2LevelBg;
    public Image Ice1_2XuanZhong;
    
    
    public Image Ice2Bg;
    public Image Ice2Icon;
    public TextMeshProUGUI Ice2LevelCount;
    public Image Ice2LevelBg;
    public Image Ice2XuanZhong;
    public TextMeshProUGUI Ice2AutoCount;
    public Image Ice2AutoBg;
    public TextMeshProUGUI Ice2KeyCount;
    public Image Ice2KeyBg;
    
    
    public Image Ice2_1Bg;
    public Image Ice2_1Icon;
    public TextMeshProUGUI Ice2_1LevelCount;
    public Image Ice2_1LevelBg;
    public Image Ice2_1XuanZhong;
    
    public Image Ice2_2Bg;
    public Image Ice2_2Icon;
    public TextMeshProUGUI Ice2_2LevelCount;
    public Image Ice2_2LevelBg;
    public Image Ice2_2XuanZhong;
    
    
    
    
    public Image Ice3Bg;
    public Image Ice3Icon;
    public TextMeshProUGUI Ice3LevelCount;
    public Image Ice3LevelBg;
    public Image Ice3XuanZhong;
    public TextMeshProUGUI Ice3AutoCount;
    public Image Ice3AutoBg;
    public TextMeshProUGUI Ice3KeyCount;
    public Image Ice3KeyBg;
    
    
    public Image Ice3_1Bg;
    public Image Ice3_1Icon;
    public TextMeshProUGUI Ice3_1LevelCount;
    public Image Ice3_1LevelBg;
    public Image Ice3_1XuanZhong;
    
    public Image Ice3_2Bg;
    public Image Ice3_2Icon;
    public TextMeshProUGUI Ice3_2LevelCount;
    public Image Ice3_2LevelBg;
    public Image Ice3_2XuanZhong;
    
    
    
    
    
    public Image Ice4Bg;
    public Image Ice4Icon;
    public TextMeshProUGUI Ice4LevelCount;
    public Image Ice4LevelBg;
    public Image Ice4XuanZhong;
    public TextMeshProUGUI Ice4AutoCount;
    public Image Ice4AutoBg;
    public TextMeshProUGUI Ice4KeyCount;
    public Image Ice4KeyBg;
    
    
    public Image Ice4_1Bg;
    public Image Ice4_1Icon;
    public TextMeshProUGUI Ice4_1LevelCount;
    public Image Ice4_1LevelBg;
    public Image Ice4_1XuanZhong;
    
    public Image Ice4_2Bg;
    public Image Ice4_2Icon;
    public TextMeshProUGUI Ice4_2LevelCount;
    public Image Ice4_2LevelBg;
    public Image Ice4_2XuanZhong;
    
    
    
    public Image Ice5Bg;
    public Image Ice5Icon;
    public TextMeshProUGUI Ice5LevelCount;
    public Image Ice5LevelBg;
    public Image Ice5XuanZhong;
    public TextMeshProUGUI Ice5AutoCount;
    public Image Ice5AutoBg;
    public TextMeshProUGUI Ice5KeyCount;
    public Image Ice5KeyBg;
    
    
    public Image Ice5_1Bg;
    public Image Ice5_1Icon;
    public TextMeshProUGUI Ice5_1LevelCount;
    public Image Ice5_1LevelBg;
    public Image Ice5_1XuanZhong;
    
    public Image Ice5_2Bg;
    public Image Ice5_2Icon;
    public TextMeshProUGUI Ice5_2LevelCount;
    public Image Ice5_2LevelBg;
    public Image Ice5_2XuanZhong;

    public GameObject IceBeiLine1Liang;
    public GameObject IceBeiLine1An;
    public GameObject IceBeiLine2Liang;
    public GameObject IceBeiLine2An;
    public GameObject Ice1Line1Liang;
    public GameObject Ice1Line1An;
    public GameObject Ice1Line2Liang;
    public GameObject Ice1Line2An;
   
    public GameObject Ice2Line1Liang;
    public GameObject Ice2Line1An;
    public GameObject Ice2Line2Liang;
    public GameObject Ice2Line2An;
    
    public GameObject Ice3Line1Liang;
    public GameObject Ice3Line1An;
    public GameObject Ice3Line2Liang;
    public GameObject Ice3Line2An;
    
    public GameObject Ice4Line1Liang;
    public GameObject Ice4Line1An;
    public GameObject Ice4Line2Liang;
    public GameObject Ice4Line2An;
    
    public GameObject Ice5Line1Liang;
    public GameObject Ice5Line1An;
    public GameObject Ice5Line2Liang;
    public GameObject Ice5Line2An;
    
     [Header("HuoPanel")]
    public Image HuoMainBg;
    public Image HuoMainIcon;
    public TextMeshProUGUI HuoMainLevelCount;
    public Image HuoMainLevelBg;
    public Image HuoMainXuanZhong;

    public Image HuoBei1Bg;
    public Image HuoBei1Icon;
    public TextMeshProUGUI HuoBei1LevelCount;
    public Image HuoBei1LevelBg;
    public Image HuoBei1XuanZhong;

    public Image HuoBei2Bg;
    public Image HuoBei2Icon;
    public TextMeshProUGUI HuoBei2LevelCount;
    public Image HuoBei2LevelBg;
    public Image HuoBei2XuanZhong;
    
    public Image HuoBei3Bg;
    public Image HuoBei3Icon;
    public TextMeshProUGUI HuoBei3LevelCount;
    public Image HuoBei3LevelBg;
    public Image HuoBei3XuanZhong;
    
    public Image HuoBei4Bg;
    public Image HuoBei4Icon;
    public TextMeshProUGUI HuoBei4LevelCount;
    public Image HuoBei4LevelBg;
    public Image HuoBei4XuanZhong;
    
    
    public Image Huo1Bg;
    public Image Huo1Icon;
    public TextMeshProUGUI Huo1LevelCount;
    public Image Huo1LevelBg;
    public Image Huo1XuanZhong;
    public TextMeshProUGUI Huo1AutoCount;
    public Image Huo1AutoBg;
    public TextMeshProUGUI Huo1KeyCount;
    public Image Huo1KeyBg;
    
    
    public Image Huo1_1Bg;
    public Image Huo1_1Icon;
    public TextMeshProUGUI Huo1_1LevelCount;
    public Image Huo1_1LevelBg;
    public Image Huo1_1XuanZhong;
    
    public Image Huo1_2Bg;
    public Image Huo1_2Icon;
    public TextMeshProUGUI Huo1_2LevelCount;
    public Image Huo1_2LevelBg;
    public Image Huo1_2XuanZhong;
    
    
    public Image Huo2Bg;
    public Image Huo2Icon;
    public TextMeshProUGUI Huo2LevelCount;
    public Image Huo2LevelBg;
    public Image Huo2XuanZhong;
    public TextMeshProUGUI Huo2AutoCount;
    public Image Huo2AutoBg;
    public TextMeshProUGUI Huo2KeyCount;
    public Image Huo2KeyBg;
    
    
    public Image Huo2_1Bg;
    public Image Huo2_1Icon;
    public TextMeshProUGUI Huo2_1LevelCount;
    public Image Huo2_1LevelBg;
    public Image Huo2_1XuanZhong;
    
    public Image Huo2_2Bg;
    public Image Huo2_2Icon;
    public TextMeshProUGUI Huo2_2LevelCount;
    public Image Huo2_2LevelBg;
    public Image Huo2_2XuanZhong;
    
    
    
    
    public Image Huo3Bg;
    public Image Huo3Icon;
    public TextMeshProUGUI Huo3LevelCount;
    public Image Huo3LevelBg;
    public Image Huo3XuanZhong;
    public TextMeshProUGUI Huo3AutoCount;
    public Image Huo3AutoBg;
    public TextMeshProUGUI Huo3KeyCount;
    public Image Huo3KeyBg;
    
    
    public Image Huo3_1Bg;
    public Image Huo3_1Icon;
    public TextMeshProUGUI Huo3_1LevelCount;
    public Image Huo3_1LevelBg;
    public Image Huo3_1XuanZhong;
    
    public Image Huo3_2Bg;
    public Image Huo3_2Icon;
    public TextMeshProUGUI Huo3_2LevelCount;
    public Image Huo3_2LevelBg;
    public Image Huo3_2XuanZhong;
    
    
    
    
    
    public Image Huo4Bg;
    public Image Huo4Icon;
    public TextMeshProUGUI Huo4LevelCount;
    public Image Huo4LevelBg;
    public Image Huo4XuanZhong;
    public TextMeshProUGUI Huo4AutoCount;
    public Image Huo4AutoBg;
    public TextMeshProUGUI Huo4KeyCount;
    public Image Huo4KeyBg;
    
    
    public Image Huo4_1Bg;
    public Image Huo4_1Icon;
    public TextMeshProUGUI Huo4_1LevelCount;
    public Image Huo4_1LevelBg;
    public Image Huo4_1XuanZhong;
    
    public Image Huo4_2Bg;
    public Image Huo4_2Icon;
    public TextMeshProUGUI Huo4_2LevelCount;
    public Image Huo4_2LevelBg;
    public Image Huo4_2XuanZhong;
    
    
    
    public Image Huo5Bg;
    public Image Huo5Icon;
    public TextMeshProUGUI Huo5LevelCount;
    public Image Huo5LevelBg;
    public Image Huo5XuanZhong;
    public TextMeshProUGUI Huo5AutoCount;
    public Image Huo5AutoBg;
    public TextMeshProUGUI Huo5KeyCount;
    public Image Huo5KeyBg;
    
    
    public Image Huo5_1Bg;
    public Image Huo5_1Icon;
    public TextMeshProUGUI Huo5_1LevelCount;
    public Image Huo5_1LevelBg;
    public Image Huo5_1XuanZhong;
    
    public Image Huo5_2Bg;
    public Image Huo5_2Icon;
    public TextMeshProUGUI Huo5_2LevelCount;
    public Image Huo5_2LevelBg;
    public Image Huo5_2XuanZhong;
    
    public GameObject HuoBeiLine1Liang;
    public GameObject HuoBeiLine1An;
    public GameObject HuoBeiLine2Liang;
    public GameObject HuoBeiLine2An;
    public GameObject Huo1Line1Liang;
    public GameObject Huo1Line1An;
    public GameObject Huo1Line2Liang;
    public GameObject Huo1Line2An;
   
    public GameObject Huo2Line1Liang;
    public GameObject Huo2Line1An;
    public GameObject Huo2Line2Liang;
    public GameObject Huo2Line2An;
    
    public GameObject Huo3Line1Liang;
    public GameObject Huo3Line1An;
    public GameObject Huo3Line2Liang;
    public GameObject Huo3Line2An;
    
    public GameObject Huo4Line1Liang;
    public GameObject Huo4Line1An;
    public GameObject Huo4Line2Liang;
    public GameObject Huo4Line2An;
    
    public GameObject Huo5Line1Liang;
    public GameObject Huo5Line1An;
    public GameObject Huo5Line2Liang;
    public GameObject Huo5Line2An;
    
    
    
    
    
     [Header("DianPanel")]
    public Image DianMainBg;
    public Image DianMainIcon;
    public TextMeshProUGUI DianMainLevelCount;
    public Image DianMainLevelBg;
    public Image DianMainXuanZhong;

    public Image DianBei1Bg;
    public Image DianBei1Icon;
    public TextMeshProUGUI DianBei1LevelCount;
    public Image DianBei1LevelBg;
    public Image DianBei1XuanZhong;

    public Image DianBei2Bg;
    public Image DianBei2Icon;
    public TextMeshProUGUI DianBei2LevelCount;
    public Image DianBei2LevelBg;
    public Image DianBei2XuanZhong;
    
    public Image DianBei3Bg;
    public Image DianBei3Icon;
    public TextMeshProUGUI DianBei3LevelCount;
    public Image DianBei3LevelBg;
    public Image DianBei3XuanZhong;
    
    public Image DianBei4Bg;
    public Image DianBei4Icon;
    public TextMeshProUGUI DianBei4LevelCount;
    public Image DianBei4LevelBg;
    public Image DianBei4XuanZhong;
    
    
    public Image Dian1Bg;
    public Image Dian1Icon;
    public TextMeshProUGUI Dian1LevelCount;
    public Image Dian1LevelBg;
    public Image Dian1XuanZhong;
    public TextMeshProUGUI Dian1AutoCount;
    public Image Dian1AutoBg;
    public TextMeshProUGUI Dian1KeyCount;
    public Image Dian1KeyBg;
    
    
    public Image Dian1_1Bg;
    public Image Dian1_1Icon;
    public TextMeshProUGUI Dian1_1LevelCount;
    public Image Dian1_1LevelBg;
    public Image Dian1_1XuanZhong;
    
    public Image Dian1_2Bg;
    public Image Dian1_2Icon;
    public TextMeshProUGUI Dian1_2LevelCount;
    public Image Dian1_2LevelBg;
    public Image Dian1_2XuanZhong;
    
    
    public Image Dian2Bg;
    public Image Dian2Icon;
    public TextMeshProUGUI Dian2LevelCount;
    public Image Dian2LevelBg;
    public Image Dian2XuanZhong;
    public TextMeshProUGUI Dian2AutoCount;
    public Image Dian2AutoBg;
    public TextMeshProUGUI Dian2KeyCount;
    public Image Dian2KeyBg;
    
    
    public Image Dian2_1Bg;
    public Image Dian2_1Icon;
    public TextMeshProUGUI Dian2_1LevelCount;
    public Image Dian2_1LevelBg;
    public Image Dian2_1XuanZhong;
    
    public Image Dian2_2Bg;
    public Image Dian2_2Icon;
    public TextMeshProUGUI Dian2_2LevelCount;
    public Image Dian2_2LevelBg;
    public Image Dian2_2XuanZhong;
    
    
    
    
    public Image Dian3Bg;
    public Image Dian3Icon;
    public TextMeshProUGUI Dian3LevelCount;
    public Image Dian3LevelBg;
    public Image Dian3XuanZhong;
    public TextMeshProUGUI Dian3AutoCount;
    public Image Dian3AutoBg;
    public TextMeshProUGUI Dian3KeyCount;
    public Image Dian3KeyBg;
    
    
    public Image Dian3_1Bg;
    public Image Dian3_1Icon;
    public TextMeshProUGUI Dian3_1LevelCount;
    public Image Dian3_1LevelBg;
    public Image Dian3_1XuanZhong;
    
    public Image Dian3_2Bg;
    public Image Dian3_2Icon;
    public TextMeshProUGUI Dian3_2LevelCount;
    public Image Dian3_2LevelBg;
    public Image Dian3_2XuanZhong;
    
    
    
    
    
    public Image Dian4Bg;
    public Image Dian4Icon;
    public TextMeshProUGUI Dian4LevelCount;
    public Image Dian4LevelBg;
    public Image Dian4XuanZhong;
    public TextMeshProUGUI Dian4AutoCount;
    public Image Dian4AutoBg;
    public TextMeshProUGUI Dian4KeyCount;
    public Image Dian4KeyBg;
    
    
    public Image Dian4_1Bg;
    public Image Dian4_1Icon;
    public TextMeshProUGUI Dian4_1LevelCount;
    public Image Dian4_1LevelBg;
    public Image Dian4_1XuanZhong;
    
    public Image Dian4_2Bg;
    public Image Dian4_2Icon;
    public TextMeshProUGUI Dian4_2LevelCount;
    public Image Dian4_2LevelBg;
    public Image Dian4_2XuanZhong;
    
    
    
    public Image Dian5Bg;
    public Image Dian5Icon;
    public TextMeshProUGUI Dian5LevelCount;
    public Image Dian5LevelBg;
    public Image Dian5XuanZhong;
    public TextMeshProUGUI Dian5AutoCount;
    public Image Dian5AutoBg;
    public TextMeshProUGUI Dian5KeyCount;
    public Image Dian5KeyBg;
    
    
    public Image Dian5_1Bg;
    public Image Dian5_1Icon;
    public TextMeshProUGUI Dian5_1LevelCount;
    public Image Dian5_1LevelBg;
    public Image Dian5_1XuanZhong;
    
    public Image Dian5_2Bg;
    public Image Dian5_2Icon;
    public TextMeshProUGUI Dian5_2LevelCount;
    public Image Dian5_2LevelBg;
    public Image Dian5_2XuanZhong;
    
    
    public GameObject DianBeiLine1Liang;
    public GameObject DianBeiLine1An;
    public GameObject DianBeiLine2Liang;
    public GameObject DianBeiLine2An;
    public GameObject Dian1Line1Liang;
    public GameObject Dian1Line1An;
    public GameObject Dian1Line2Liang;
    public GameObject Dian1Line2An;
   
    public GameObject Dian2Line1Liang;
    public GameObject Dian2Line1An;
    public GameObject Dian2Line2Liang;
    public GameObject Dian2Line2An;
    
    public GameObject Dian3Line1Liang;
    public GameObject Dian3Line1An;
    public GameObject Dian3Line2Liang;
    public GameObject Dian3Line2An;
    
    public GameObject Dian4Line1Liang;
    public GameObject Dian4Line1An;
    public GameObject Dian4Line2Liang;
    public GameObject Dian4Line2An;
    
    public GameObject Dian5Line1Liang;
    public GameObject Dian5Line1An;
    public GameObject Dian5Line2Liang;
    public GameObject Dian5Line2An;
    
    
     [Header("HeiAnPanel")]
    public Image HeiAnMainBg;
    public Image HeiAnMainIcon;
    public TextMeshProUGUI HeiAnMainLevelCount;
    public Image HeiAnMainLevelBg;
    public Image HeiAnMainXuanZhong;

    public Image HeiAnBei1Bg;
    public Image HeiAnBei1Icon;
    public TextMeshProUGUI HeiAnBei1LevelCount;
    public Image HeiAnBei1LevelBg;
    public Image HeiAnBei1XuanZhong;

    public Image HeiAnBei2Bg;
    public Image HeiAnBei2Icon;
    public TextMeshProUGUI HeiAnBei2LevelCount;
    public Image HeiAnBei2LevelBg;
    public Image HeiAnBei2XuanZhong;
    
    public Image HeiAnBei3Bg;
    public Image HeiAnBei3Icon;
    public TextMeshProUGUI HeiAnBei3LevelCount;
    public Image HeiAnBei3LevelBg;
    public Image HeiAnBei3XuanZhong;
    
    public Image HeiAnBei4Bg;
    public Image HeiAnBei4Icon;
    public TextMeshProUGUI HeiAnBei4LevelCount;
    public Image HeiAnBei4LevelBg;
    public Image HeiAnBei4XuanZhong;
    
    
    public Image HeiAn1Bg;
    public Image HeiAn1Icon;
    public TextMeshProUGUI HeiAn1LevelCount;
    public Image HeiAn1LevelBg;
    public Image HeiAn1XuanZhong;
    public TextMeshProUGUI HeiAn1AutoCount;
    public Image HeiAn1AutoBg;
    public TextMeshProUGUI HeiAn1KeyCount;
    public Image HeiAn1KeyBg;
    
    
    public Image HeiAn1_1Bg;
    public Image HeiAn1_1Icon;
    public TextMeshProUGUI HeiAn1_1LevelCount;
    public Image HeiAn1_1LevelBg;
    public Image HeiAn1_1XuanZhong;
    
    public Image HeiAn1_2Bg;
    public Image HeiAn1_2Icon;
    public TextMeshProUGUI HeiAn1_2LevelCount;
    public Image HeiAn1_2LevelBg;
    public Image HeiAn1_2XuanZhong;
    
    
    public Image HeiAn2Bg;
    public Image HeiAn2Icon;
    public TextMeshProUGUI HeiAn2LevelCount;
    public Image HeiAn2LevelBg;
    public Image HeiAn2XuanZhong;
    public TextMeshProUGUI HeiAn2AutoCount;
    public Image HeiAn2AutoBg;
    public TextMeshProUGUI HeiAn2KeyCount;
    public Image HeiAn2KeyBg;
    
    
    public Image HeiAn2_1Bg;
    public Image HeiAn2_1Icon;
    public TextMeshProUGUI HeiAn2_1LevelCount;
    public Image HeiAn2_1LevelBg;
    public Image HeiAn2_1XuanZhong;
    
    public Image HeiAn2_2Bg;
    public Image HeiAn2_2Icon;
    public TextMeshProUGUI HeiAn2_2LevelCount;
    public Image HeiAn2_2LevelBg;
    public Image HeiAn2_2XuanZhong;
    
    
    
    
    public Image HeiAn3Bg;
    public Image HeiAn3Icon;
    public TextMeshProUGUI HeiAn3LevelCount;
    public Image HeiAn3LevelBg;
    public Image HeiAn3XuanZhong;
    public TextMeshProUGUI HeiAn3AutoCount;
    public Image HeiAn3AutoBg;
    public TextMeshProUGUI HeiAn3KeyCount;
    public Image HeiAn3KeyBg;
    
    
    public Image HeiAn3_1Bg;
    public Image HeiAn3_1Icon;
    public TextMeshProUGUI HeiAn3_1LevelCount;
    public Image HeiAn3_1LevelBg;
    public Image HeiAn3_1XuanZhong;
    
    public Image HeiAn3_2Bg;
    public Image HeiAn3_2Icon;
    public TextMeshProUGUI HeiAn3_2LevelCount;
    public Image HeiAn3_2LevelBg;
    public Image HeiAn3_2XuanZhong;
    
    
    
    
    
    public Image HeiAn4Bg;
    public Image HeiAn4Icon;
    public TextMeshProUGUI HeiAn4LevelCount;
    public Image HeiAn4LevelBg;
    public Image HeiAn4XuanZhong;
    public TextMeshProUGUI HeiAn4AutoCount;
    public Image HeiAn4AutoBg;
    public TextMeshProUGUI HeiAn4KeyCount;
    public Image HeiAn4KeyBg;
    
    
    public Image HeiAn4_1Bg;
    public Image HeiAn4_1Icon;
    public TextMeshProUGUI HeiAn4_1LevelCount;
    public Image HeiAn4_1LevelBg;
    public Image HeiAn4_1XuanZhong;
    
    public Image HeiAn4_2Bg;
    public Image HeiAn4_2Icon;
    public TextMeshProUGUI HeiAn4_2LevelCount;
    public Image HeiAn4_2LevelBg;
    public Image HeiAn4_2XuanZhong;
    
    
    
    public Image HeiAn5Bg;
    public Image HeiAn5Icon;
    public TextMeshProUGUI HeiAn5LevelCount;
    public Image HeiAn5LevelBg;
    public Image HeiAn5XuanZhong;
    public TextMeshProUGUI HeiAn5AutoCount;
    public Image HeiAn5AutoBg;
    public TextMeshProUGUI HeiAn5KeyCount;
    public Image HeiAn5KeyBg;
    
    
    public Image HeiAn5_1Bg;
    public Image HeiAn5_1Icon;
    public TextMeshProUGUI HeiAn5_1LevelCount;
    public Image HeiAn5_1LevelBg;
    public Image HeiAn5_1XuanZhong;
    
    public Image HeiAn5_2Bg;
    public Image HeiAn5_2Icon;
    public TextMeshProUGUI HeiAn5_2LevelCount;
    public Image HeiAn5_2LevelBg;
    public Image HeiAn5_2XuanZhong;
    
    
    public GameObject HeiAnBeiLine1Liang;
    public GameObject HeiAnBeiLine1An;
    public GameObject HeiAnBeiLine2Liang;
    public GameObject HeiAnBeiLine2An;
    public GameObject HeiAn1Line1Liang;
    public GameObject HeiAn1Line1An;
    public GameObject HeiAn1Line2Liang;
    public GameObject HeiAn1Line2An;
   
    public GameObject HeiAn2Line1Liang;
    public GameObject HeiAn2Line1An;
    public GameObject HeiAn2Line2Liang;
    public GameObject HeiAn2Line2An;
    
    public GameObject HeiAn3Line1Liang;
    public GameObject HeiAn3Line1An;
    public GameObject HeiAn3Line2Liang;
    public GameObject HeiAn3Line2An;
    
    public GameObject HeiAn4Line1Liang;
    public GameObject HeiAn4Line1An;
    public GameObject HeiAn4Line2Liang;
    public GameObject HeiAn4Line2An;
    
    public GameObject HeiAn5Line1Liang;
    public GameObject HeiAn5Line1An;
    public GameObject HeiAn5Line2Liang;
    public GameObject HeiAn5Line2An;
    
    
    [Header("ZJPanel")]
    public Image IceZJMainBg;
    public Image IceZJMainIcon;
    public TextMeshProUGUI IceZJMainLevelCount;
    public Image IceZJMainLevelBg;
    public Image IceZJMainXuanZhong;
    
    
    public Image IceZJ1Bg;
    public Image IceZJ1Icon;
    public TextMeshProUGUI IceZJ1LevelCount;
    public Image IceZJ1LevelBg;
    public Image IceZJ1XuanZhong;
    
    
    public Image IceZJ2Bg;
    public Image IceZJ2Icon;
    public TextMeshProUGUI IceZJ2LevelCount;
    public Image IceZJ2LevelBg;
    public Image IceZJ2XuanZhong;
    
    public Image IceZJ3Bg;
    public Image IceZJ3Icon;
    public TextMeshProUGUI IceZJ3LevelCount;
    public Image IceZJ3LevelBg;
    public Image IceZJ3XuanZhong;
    
    public Image IceZJ4Bg;
    public Image IceZJ4Icon;
    public TextMeshProUGUI IceZJ4LevelCount;
    public Image IceZJ4LevelBg;
    public Image IceZJ4XuanZhong;
    
    public Image IceZJ5Bg;
    public Image IceZJ5Icon;
    public TextMeshProUGUI IceZJ5LevelCount;
    public Image IceZJ5LevelBg;
    public Image IceZJ5XuanZhong;
    
    
    public Image IceZJ6Bg;
    public Image IceZJ6Icon;
    public TextMeshProUGUI IceZJ6LevelCount;
    public Image IceZJ6LevelBg;
    public Image IceZJ6XuanZhong;


    public GameObject IceZJLine1Liang;
    public GameObject IceZJLine1An;
    public GameObject IceZJLine2Liang;
    public GameObject IceZJLine2An;
    public GameObject IceZJLine3Liang;
    public GameObject IceZJLine3An;
    public GameObject IceZJLine4Liang;
    public GameObject IceZJLine4An;
    public GameObject IceZJLine5Liang;
    public GameObject IceZJLine5An;
    
    
    
    public Image HuoZJMainBg;
    public Image HuoZJMainIcon;
    public TextMeshProUGUI HuoZJMainLevelCount;
    public Image HuoZJMainLevelBg;
    public Image HuoZJMainXuanZhong;

    
    
    public Image HuoZJ1Bg;
    public Image HuoZJ1Icon;
    public TextMeshProUGUI HuoZJ1LevelCount;
    public Image HuoZJ1LevelBg;
    public Image HuoZJ1XuanZhong;
    
    
    public Image HuoZJ2Bg;
    public Image HuoZJ2Icon;
    public TextMeshProUGUI HuoZJ2LevelCount;
    public Image HuoZJ2LevelBg;
    public Image HuoZJ2XuanZhong;
    
    public Image HuoZJ3Bg;
    public Image HuoZJ3Icon;
    public TextMeshProUGUI HuoZJ3LevelCount;
    public Image HuoZJ3LevelBg;
    public Image HuoZJ3XuanZhong;
    
    public Image HuoZJ4Bg;
    public Image HuoZJ4Icon;
    public TextMeshProUGUI HuoZJ4LevelCount;
    public Image HuoZJ4LevelBg;
    public Image HuoZJ4XuanZhong;
    
    public Image HuoZJ5Bg;
    public Image HuoZJ5Icon;
    public TextMeshProUGUI HuoZJ5LevelCount;
    public Image HuoZJ5LevelBg;
    public Image HuoZJ5XuanZhong;
    
    
    public Image HuoZJ6Bg;
    public Image HuoZJ6Icon;
    public TextMeshProUGUI HuoZJ6LevelCount;
    public Image HuoZJ6LevelBg;
    public Image HuoZJ6XuanZhong;
    
    public GameObject HuoZJLine1Liang;
    public GameObject HuoZJLine1An;
    public GameObject HuoZJLine2Liang;
    public GameObject HuoZJLine2An;
    public GameObject HuoZJLine3Liang;
    public GameObject HuoZJLine3An;
    public GameObject HuoZJLine4Liang;
    public GameObject HuoZJLine4An;
    public GameObject HuoZJLine5Liang;
    public GameObject HuoZJLine5An;
    
    
    
    
    
    
    public Image DianZJMainBg;
    public Image DianZJMainIcon;
    public TextMeshProUGUI DianZJMainLevelCount;
    public Image DianZJMainLevelBg;
    public Image DianZJMainXuanZhong;

    
    public Image DianZJ1Bg;
    public Image DianZJ1Icon;
    public TextMeshProUGUI DianZJ1LevelCount;
    public Image DianZJ1LevelBg;
    public Image DianZJ1XuanZhong;
    
    
    public Image DianZJ2Bg;
    public Image DianZJ2Icon;
    public TextMeshProUGUI DianZJ2LevelCount;
    public Image DianZJ2LevelBg;
    public Image DianZJ2XuanZhong;
    
    public Image DianZJ3Bg;
    public Image DianZJ3Icon;
    public TextMeshProUGUI DianZJ3LevelCount;
    public Image DianZJ3LevelBg;
    public Image DianZJ3XuanZhong;
    
    public Image DianZJ4Bg;
    public Image DianZJ4Icon;
    public TextMeshProUGUI DianZJ4LevelCount;
    public Image DianZJ4LevelBg;
    public Image DianZJ4XuanZhong;
    
    public Image DianZJ5Bg;
    public Image DianZJ5Icon;
    public TextMeshProUGUI DianZJ5LevelCount;
    public Image DianZJ5LevelBg;
    public Image DianZJ5XuanZhong;
    
    
    public Image DianZJ6Bg;
    public Image DianZJ6Icon;
    public TextMeshProUGUI DianZJ6LevelCount;
    public Image DianZJ6LevelBg;
    public Image DianZJ6XuanZhong;
    
    public GameObject DianZJLine1Liang;
    public GameObject DianZJLine1An;
    public GameObject DianZJLine2Liang;
    public GameObject DianZJLine2An;
    public GameObject DianZJLine3Liang;
    public GameObject DianZJLine3An;
    public GameObject DianZJLine4Liang;
    public GameObject DianZJLine4An;
    public GameObject DianZJLine5Liang;
    public GameObject DianZJLine5An;
    
    
    
    
    
    public Image HeiAnZJMainBg;
    public Image HeiAnZJMainIcon;
    public TextMeshProUGUI HeiAnZJMainLevelCount;
    public Image HeiAnZJMainLevelBg;
    public Image HeiAnZJMainXuanZhong;

    
    public Image HeiAnZJ1Bg;
    public Image HeiAnZJ1Icon;
    public TextMeshProUGUI HeiAnZJ1LevelCount;
    public Image HeiAnZJ1LevelBg;
    public Image HeiAnZJ1XuanZhong;
    
    
    public Image HeiAnZJ2Bg;
    public Image HeiAnZJ2Icon;
    public TextMeshProUGUI HeiAnZJ2LevelCount;
    public Image HeiAnZJ2LevelBg;
    public Image HeiAnZJ2XuanZhong;
    
    public Image HeiAnZJ3Bg;
    public Image HeiAnZJ3Icon;
    public TextMeshProUGUI HeiAnZJ3LevelCount;
    public Image HeiAnZJ3LevelBg;
    public Image HeiAnZJ3XuanZhong;
    
    public Image HeiAnZJ4Bg;
    public Image HeiAnZJ4Icon;
    public TextMeshProUGUI HeiAnZJ4LevelCount;
    public Image HeiAnZJ4LevelBg;
    public Image HeiAnZJ4XuanZhong;
    
    public Image HeiAnZJ5Bg;
    public Image HeiAnZJ5Icon;
    public TextMeshProUGUI HeiAnZJ5LevelCount;
    public Image HeiAnZJ5LevelBg;
    public Image HeiAnZJ5XuanZhong;
    
    
    public Image HeiAnZJ6Bg;
    public Image HeiAnZJ6Icon;
    public TextMeshProUGUI HeiAnZJ6LevelCount;
    public Image HeiAnZJ6LevelBg;
    public Image HeiAnZJ6XuanZhong;
    
    public GameObject HeiAnZJLine1Liang;
    public GameObject HeiAnZJLine1An;
    public GameObject HeiAnZJLine2Liang;
    public GameObject HeiAnZJLine2An;
    public GameObject HeiAnZJLine3Liang;
    public GameObject HeiAnZJLine3An;
    public GameObject HeiAnZJLine4Liang;
    public GameObject HeiAnZJLine4An;
    public GameObject HeiAnZJLine5Liang;
    public GameObject HeiAnZJLine5An;
    
    
    
    
    
    public Image ZhiYeZJ1Bg;
    public Image ZhiYeZJ1Icon;
    public TextMeshProUGUI ZhiYeZJ1LevelCount;
    public Image ZhiYeZJ1LevelBg;
    public Image ZhiYeZJ1XuanZhong;
    
    
    public Image ZhiYeZJ2Bg;
    public Image ZhiYeZJ2Icon;
    public TextMeshProUGUI ZhiYeZJ2LevelCount;
    public Image ZhiYeZJ2LevelBg;
    public Image ZhiYeZJ2XuanZhong;
    
    public Image ZhiYeZJ3Bg;
    public Image ZhiYeZJ3Icon;
    public TextMeshProUGUI ZhiYeZJ3LevelCount;
    public Image ZhiYeZJ3LevelBg;
    public Image ZhiYeZJ3XuanZhong;
    
    public Image ZhiYeZJ4Bg;
    public Image ZhiYeZJ4Icon;
    public TextMeshProUGUI ZhiYeZJ4LevelCount;
    public Image ZhiYeZJ4LevelBg;
    public Image ZhiYeZJ4XuanZhong;
    
    public Image ZhiYeZJ5Bg;
    public Image ZhiYeZJ5Icon;
    public TextMeshProUGUI ZhiYeZJ5LevelCount;
    public Image ZhiYeZJ5LevelBg;
    public Image ZhiYeZJ5XuanZhong;
    
    
    public Image ZhiYeZJ6Bg;
    public Image ZhiYeZJ6Icon;
    public TextMeshProUGUI ZhiYeZJ6LevelCount;
    public Image ZhiYeZJ6LevelBg;
    public Image ZhiYeZJ6XuanZhong;
    
    public GameObject ZhiYeZJLine1Liang;
    public GameObject ZhiYeZJLine1An;
    public GameObject ZhiYeZJLine2Liang;
    public GameObject ZhiYeZJLine2An;
    public GameObject ZhiYeZJLine3Liang;
    public GameObject ZhiYeZJLine3An;
    public GameObject ZhiYeZJLine4Liang;
    public GameObject ZhiYeZJLine4An;
    public GameObject ZhiYeZJLine5Liang;
    public GameObject ZhiYeZJLine5An;
    
    

    public Button ResetButton;

 
}
