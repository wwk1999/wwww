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

    public void Awake()
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
      HuoMainBg = transform.Find("Bg/Panel/HuoPanel/Main/bg").GetComponent<Image>();
     HuoMainIcon = transform.Find("Bg/Panel/HuoPanel/Main/icon").GetComponent<Image>();
     HuoMainLevelBg = transform.Find("Bg/Panel/HuoPanel/Main/Level/bg").GetComponent<Image>();
     HuoMainLevelCount = transform.Find("Bg/Panel/HuoPanel/Main/Level/level").GetComponent<TextMeshProUGUI>();
     HuoMainXuanZhong = transform.Find("Bg/Panel/HuoPanel/Main/xuanzhong").GetComponent<Image>();


     HuoBei1Bg = transform.Find("Bg/Panel/HuoPanel/Bei1/bg").GetComponent<Image>();
     HuoBei1Icon = transform.Find("Bg/Panel/HuoPanel/Bei1/icon").GetComponent<Image>();
     HuoBei1LevelBg = transform.Find("Bg/Panel/HuoPanel/Bei1/Level/bg").GetComponent<Image>();
     HuoBei1LevelCount = transform.Find("Bg/Panel/HuoPanel/Bei1/Level/level").GetComponent<TextMeshProUGUI>();
     HuoBei1XuanZhong = transform.Find("Bg/Panel/HuoPanel/Bei1/xuanzhong").GetComponent<Image>();


     HuoBei2Bg = transform.Find("Bg/Panel/HuoPanel/Bei2/bg").GetComponent<Image>();
     HuoBei2Icon = transform.Find("Bg/Panel/HuoPanel/Bei2/icon").GetComponent<Image>();
     HuoBei2LevelBg = transform.Find("Bg/Panel/HuoPanel/Bei2/Level/bg").GetComponent<Image>();
     HuoBei2LevelCount = transform.Find("Bg/Panel/HuoPanel/Bei2/Level/level").GetComponent<TextMeshProUGUI>();
     HuoBei2XuanZhong = transform.Find("Bg/Panel/HuoPanel/Bei2/xuanzhong").GetComponent<Image>();

     HuoBei3Bg = transform.Find("Bg/Panel/HuoPanel/Bei3/bg").GetComponent<Image>();
     HuoBei3Icon = transform.Find("Bg/Panel/HuoPanel/Bei3/icon").GetComponent<Image>();
     HuoBei3LevelBg = transform.Find("Bg/Panel/HuoPanel/Bei3/Level/bg").GetComponent<Image>();
     HuoBei3LevelCount = transform.Find("Bg/Panel/HuoPanel/Bei3/Level/level").GetComponent<TextMeshProUGUI>();
     HuoBei3XuanZhong = transform.Find("Bg/Panel/HuoPanel/Bei3/xuanzhong").GetComponent<Image>();

     HuoBei4Bg = transform.Find("Bg/Panel/HuoPanel/Bei4/bg").GetComponent<Image>();
     HuoBei4Icon = transform.Find("Bg/Panel/HuoPanel/Bei4/icon").GetComponent<Image>();
     HuoBei4LevelBg = transform.Find("Bg/Panel/HuoPanel/Bei4/Level/bg").GetComponent<Image>();
     HuoBei4LevelCount = transform.Find("Bg/Panel/HuoPanel/Bei4/Level/level").GetComponent<TextMeshProUGUI>();
     HuoBei4XuanZhong = transform.Find("Bg/Panel/HuoPanel/Bei4/xuanzhong").GetComponent<Image>();

     
     
     
     
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





     
      DianMainBg = transform.Find("Bg/Panel/DianPanel/Main/bg").GetComponent<Image>();
     DianMainIcon = transform.Find("Bg/Panel/DianPanel/Main/icon").GetComponent<Image>();
     DianMainLevelBg = transform.Find("Bg/Panel/DianPanel/Main/Level/bg").GetComponent<Image>();
     DianMainLevelCount = transform.Find("Bg/Panel/DianPanel/Main/Level/level").GetComponent<TextMeshProUGUI>();
     DianMainXuanZhong = transform.Find("Bg/Panel/DianPanel/Main/xuanzhong").GetComponent<Image>();


     DianBei1Bg = transform.Find("Bg/Panel/DianPanel/Bei1/bg").GetComponent<Image>();
     DianBei1Icon = transform.Find("Bg/Panel/DianPanel/Bei1/icon").GetComponent<Image>();
     DianBei1LevelBg = transform.Find("Bg/Panel/DianPanel/Bei1/Level/bg").GetComponent<Image>();
     DianBei1LevelCount = transform.Find("Bg/Panel/DianPanel/Bei1/Level/level").GetComponent<TextMeshProUGUI>();
     DianBei1XuanZhong = transform.Find("Bg/Panel/DianPanel/Bei1/xuanzhong").GetComponent<Image>();


     DianBei2Bg = transform.Find("Bg/Panel/DianPanel/Bei2/bg").GetComponent<Image>();
     DianBei2Icon = transform.Find("Bg/Panel/DianPanel/Bei2/icon").GetComponent<Image>();
     DianBei2LevelBg = transform.Find("Bg/Panel/DianPanel/Bei2/Level/bg").GetComponent<Image>();
     DianBei2LevelCount = transform.Find("Bg/Panel/DianPanel/Bei2/Level/level").GetComponent<TextMeshProUGUI>();
     DianBei2XuanZhong = transform.Find("Bg/Panel/DianPanel/Bei2/xuanzhong").GetComponent<Image>();

     DianBei3Bg = transform.Find("Bg/Panel/DianPanel/Bei3/bg").GetComponent<Image>();
     DianBei3Icon = transform.Find("Bg/Panel/DianPanel/Bei3/icon").GetComponent<Image>();
     DianBei3LevelBg = transform.Find("Bg/Panel/DianPanel/Bei3/Level/bg").GetComponent<Image>();
     DianBei3LevelCount = transform.Find("Bg/Panel/DianPanel/Bei3/Level/level").GetComponent<TextMeshProUGUI>();
     DianBei3XuanZhong = transform.Find("Bg/Panel/DianPanel/Bei3/xuanzhong").GetComponent<Image>();

     DianBei4Bg = transform.Find("Bg/Panel/DianPanel/Bei4/bg").GetComponent<Image>();
     DianBei4Icon = transform.Find("Bg/Panel/DianPanel/Bei4/icon").GetComponent<Image>();
     DianBei4LevelBg = transform.Find("Bg/Panel/DianPanel/Bei4/Level/bg").GetComponent<Image>();
     DianBei4LevelCount = transform.Find("Bg/Panel/DianPanel/Bei4/Level/level").GetComponent<TextMeshProUGUI>();
     DianBei4XuanZhong = transform.Find("Bg/Panel/DianPanel/Bei4/xuanzhong").GetComponent<Image>();

     

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




     
     
     
      HeiAnMainBg = transform.Find("Bg/Panel/HeiAnPanel/Main/bg").GetComponent<Image>();
     HeiAnMainIcon = transform.Find("Bg/Panel/HeiAnPanel/Main/icon").GetComponent<Image>();
     HeiAnMainLevelBg = transform.Find("Bg/Panel/HeiAnPanel/Main/Level/bg").GetComponent<Image>();
     HeiAnMainLevelCount = transform.Find("Bg/Panel/HeiAnPanel/Main/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAnMainXuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Main/xuanzhong").GetComponent<Image>();


     HeiAnBei1Bg = transform.Find("Bg/Panel/HeiAnPanel/Bei1/bg").GetComponent<Image>();
     HeiAnBei1Icon = transform.Find("Bg/Panel/HeiAnPanel/Bei1/icon").GetComponent<Image>();
     HeiAnBei1LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Bei1/Level/bg").GetComponent<Image>();
     HeiAnBei1LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Bei1/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAnBei1XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Bei1/xuanzhong").GetComponent<Image>();


     HeiAnBei2Bg = transform.Find("Bg/Panel/HeiAnPanel/Bei2/bg").GetComponent<Image>();
     HeiAnBei2Icon = transform.Find("Bg/Panel/HeiAnPanel/Bei2/icon").GetComponent<Image>();
     HeiAnBei2LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Bei2/Level/bg").GetComponent<Image>();
     HeiAnBei2LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Bei2/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAnBei2XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Bei2/xuanzhong").GetComponent<Image>();

     HeiAnBei3Bg = transform.Find("Bg/Panel/HeiAnPanel/Bei3/bg").GetComponent<Image>();
     HeiAnBei3Icon = transform.Find("Bg/Panel/HeiAnPanel/Bei3/icon").GetComponent<Image>();
     HeiAnBei3LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Bei3/Level/bg").GetComponent<Image>();
     HeiAnBei3LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Bei3/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAnBei3XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Bei3/xuanzhong").GetComponent<Image>();

     HeiAnBei4Bg = transform.Find("Bg/Panel/HeiAnPanel/Bei4/bg").GetComponent<Image>();
     HeiAnBei4Icon = transform.Find("Bg/Panel/HeiAnPanel/Bei4/icon").GetComponent<Image>();
     HeiAnBei4LevelBg = transform.Find("Bg/Panel/HeiAnPanel/Bei4/Level/bg").GetComponent<Image>();
     HeiAnBei4LevelCount = transform.Find("Bg/Panel/HeiAnPanel/Bei4/Level/level").GetComponent<TextMeshProUGUI>();
     HeiAnBei4XuanZhong = transform.Find("Bg/Panel/HeiAnPanel/Bei4/xuanzhong").GetComponent<Image>();

     
     
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


     IceBeiLine1Liang = transform.Find("Bg/Panel/IcePanel/BeiLine1/liang").gameObject;
     IceBeiLine1An = transform.Find("Bg/Panel/IcePanel/BeiLine1/An").gameObject;
     IceBeiLine2Liang = transform.Find("Bg/Panel/IcePanel/BeiLine2/liang").gameObject;
     IceBeiLine2An = transform.Find("Bg/Panel/IcePanel/BeiLine2/An").gameObject;

     Ice1Line1An = transform.Find("Bg/Panel/IcePanel/Ice1/Line1/An").gameObject;
     Ice1Line1Liang = transform.Find("Bg/Panel/IcePanel/Ice1/Line1/liang").gameObject;
     Ice1Line2An = transform.Find("Bg/Panel/IcePanel/Ice1/Line2/An").gameObject;
     Ice1Line2Liang = transform.Find("Bg/Panel/IcePanel/Ice1/Line2/liang").gameObject;

     Ice2Line1An = transform.Find("Bg/Panel/IcePanel/Ice2/Line1/An").gameObject;
     Ice2Line1Liang = transform.Find("Bg/Panel/IcePanel/Ice2/Line1/liang").gameObject;
     Ice2Line2An = transform.Find("Bg/Panel/IcePanel/Ice2/Line2/An").gameObject;
     Ice2Line2Liang = transform.Find("Bg/Panel/IcePanel/Ice2/Line2/liang").gameObject;

     Ice3Line1An = transform.Find("Bg/Panel/IcePanel/Ice3/Line1/An").gameObject;
     Ice3Line1Liang = transform.Find("Bg/Panel/IcePanel/Ice3/Line1/liang").gameObject;
     Ice3Line2An = transform.Find("Bg/Panel/IcePanel/Ice3/Line2/An").gameObject;
     Ice3Line2Liang = transform.Find("Bg/Panel/IcePanel/Ice3/Line2/liang").gameObject;

     Ice4Line1An = transform.Find("Bg/Panel/IcePanel/Ice4/Line1/An").gameObject;
     Ice4Line1Liang = transform.Find("Bg/Panel/IcePanel/Ice4/Line1/liang").gameObject;
     Ice4Line2An = transform.Find("Bg/Panel/IcePanel/Ice4/Line2/An").gameObject;
     Ice4Line2Liang = transform.Find("Bg/Panel/IcePanel/Ice4/Line2/liang").gameObject;

     Ice5Line1An = transform.Find("Bg/Panel/IcePanel/Ice5/Line1/An").gameObject;
     Ice5Line1Liang = transform.Find("Bg/Panel/IcePanel/Ice5/Line1/liang").gameObject;
     Ice5Line2An = transform.Find("Bg/Panel/IcePanel/Ice5/Line2/An").gameObject;
     Ice5Line2Liang = transform.Find("Bg/Panel/IcePanel/Ice5/Line2/liang").gameObject;

     HuoBeiLine1Liang = transform.Find("Bg/Panel/HuoPanel/BeiLine1/liang").gameObject;
     HuoBeiLine1An = transform.Find("Bg/Panel/HuoPanel/BeiLine1/An").gameObject;
     HuoBeiLine2Liang = transform.Find("Bg/Panel/HuoPanel/BeiLine2/liang").gameObject;
     HuoBeiLine2An = transform.Find("Bg/Panel/HuoPanel/BeiLine2/An").gameObject;

     Huo1Line1An = transform.Find("Bg/Panel/HuoPanel/Ice1/Line1/An").gameObject;
     Huo1Line1Liang = transform.Find("Bg/Panel/HuoPanel/Ice1/Line1/liang").gameObject;
     Huo1Line2An = transform.Find("Bg/Panel/HuoPanel/Ice1/Line2/An").gameObject;
     Huo1Line2Liang = transform.Find("Bg/Panel/HuoPanel/Ice1/Line2/liang").gameObject;

     Huo2Line1An = transform.Find("Bg/Panel/HuoPanel/Ice2/Line1/An").gameObject;
     Huo2Line1Liang = transform.Find("Bg/Panel/HuoPanel/Ice2/Line1/liang").gameObject;
     Huo2Line2An = transform.Find("Bg/Panel/HuoPanel/Ice2/Line2/An").gameObject;
     Huo2Line2Liang = transform.Find("Bg/Panel/HuoPanel/Ice2/Line2/liang").gameObject;

     Huo3Line1An = transform.Find("Bg/Panel/HuoPanel/Ice3/Line1/An").gameObject;
     Huo3Line1Liang = transform.Find("Bg/Panel/HuoPanel/Ice3/Line1/liang").gameObject;
     Huo3Line2An = transform.Find("Bg/Panel/HuoPanel/Ice3/Line2/An").gameObject;
     Huo3Line2Liang = transform.Find("Bg/Panel/HuoPanel/Ice3/Line2/liang").gameObject;

     Huo4Line1An = transform.Find("Bg/Panel/HuoPanel/Ice4/Line1/An").gameObject;
     Huo4Line1Liang = transform.Find("Bg/Panel/HuoPanel/Ice4/Line1/liang").gameObject;
     Huo4Line2An = transform.Find("Bg/Panel/HuoPanel/Ice4/Line2/An").gameObject;
     Huo4Line2Liang = transform.Find("Bg/Panel/HuoPanel/Ice4/Line2/liang").gameObject;

     Huo5Line1An = transform.Find("Bg/Panel/HuoPanel/Ice5/Line1/An").gameObject;
     Huo5Line1Liang = transform.Find("Bg/Panel/HuoPanel/Ice5/Line1/liang").gameObject;
     Huo5Line2An = transform.Find("Bg/Panel/HuoPanel/Ice5/Line2/An").gameObject;
     Huo5Line2Liang = transform.Find("Bg/Panel/HuoPanel/Ice5/Line2/liang").gameObject;



     DianBeiLine1Liang = transform.Find("Bg/Panel/DianPanel/BeiLine1/liang").gameObject;
     DianBeiLine1An = transform.Find("Bg/Panel/DianPanel/BeiLine1/An").gameObject;
     DianBeiLine2Liang = transform.Find("Bg/Panel/DianPanel/BeiLine2/liang").gameObject;
     DianBeiLine2An = transform.Find("Bg/Panel/DianPanel/BeiLine2/An").gameObject;

     Dian1Line1An = transform.Find("Bg/Panel/DianPanel/Ice1/Line1/An").gameObject;
     Dian1Line1Liang = transform.Find("Bg/Panel/DianPanel/Ice1/Line1/liang").gameObject;
     Dian1Line2An = transform.Find("Bg/Panel/DianPanel/Ice1/Line2/An").gameObject;
     Dian1Line2Liang = transform.Find("Bg/Panel/DianPanel/Ice1/Line2/liang").gameObject;

     Dian2Line1An = transform.Find("Bg/Panel/DianPanel/Ice2/Line1/An").gameObject;
     Dian2Line1Liang = transform.Find("Bg/Panel/DianPanel/Ice2/Line1/liang").gameObject;
     Dian2Line2An = transform.Find("Bg/Panel/DianPanel/Ice2/Line2/An").gameObject;
     Dian2Line2Liang = transform.Find("Bg/Panel/DianPanel/Ice2/Line2/liang").gameObject;

     Dian3Line1An = transform.Find("Bg/Panel/DianPanel/Ice3/Line1/An").gameObject;
     Dian3Line1Liang = transform.Find("Bg/Panel/DianPanel/Ice3/Line1/liang").gameObject;
     Dian3Line2An = transform.Find("Bg/Panel/DianPanel/Ice3/Line2/An").gameObject;
     Dian3Line2Liang = transform.Find("Bg/Panel/DianPanel/Ice3/Line2/liang").gameObject;

     Dian4Line1An = transform.Find("Bg/Panel/DianPanel/Ice4/Line1/An").gameObject;
     Dian4Line1Liang = transform.Find("Bg/Panel/DianPanel/Ice4/Line1/liang").gameObject;
     Dian4Line2An = transform.Find("Bg/Panel/DianPanel/Ice4/Line2/An").gameObject;
     Dian4Line2Liang = transform.Find("Bg/Panel/DianPanel/Ice4/Line2/liang").gameObject;

     Dian5Line1An = transform.Find("Bg/Panel/DianPanel/Ice5/Line1/An").gameObject;
     Dian5Line1Liang = transform.Find("Bg/Panel/DianPanel/Ice5/Line1/liang").gameObject;
     Dian5Line2An = transform.Find("Bg/Panel/DianPanel/Ice5/Line2/An").gameObject;
     Dian5Line2Liang = transform.Find("Bg/Panel/DianPanel/Ice5/Line2/liang").gameObject;


     HeiAnBeiLine1Liang = transform.Find("Bg/Panel/HeiAnPanel/BeiLine1/liang").gameObject;
     HeiAnBeiLine1An = transform.Find("Bg/Panel/HeiAnPanel/BeiLine1/An").gameObject;
     HeiAnBeiLine2Liang = transform.Find("Bg/Panel/HeiAnPanel/BeiLine2/liang").gameObject;
     HeiAnBeiLine2An = transform.Find("Bg/Panel/HeiAnPanel/BeiLine2/An").gameObject;

     HeiAn1Line1An = transform.Find("Bg/Panel/HeiAnPanel/Ice1/Line1/An").gameObject;
     HeiAn1Line1Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice1/Line1/liang").gameObject;
     HeiAn1Line2An = transform.Find("Bg/Panel/HeiAnPanel/Ice1/Line2/An").gameObject;
     HeiAn1Line2Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice1/Line2/liang").gameObject;

     HeiAn2Line1An = transform.Find("Bg/Panel/HeiAnPanel/Ice2/Line1/An").gameObject;
     HeiAn2Line1Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice2/Line1/liang").gameObject;
     HeiAn2Line2An = transform.Find("Bg/Panel/HeiAnPanel/Ice2/Line2/An").gameObject;
     HeiAn2Line2Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice2/Line2/liang").gameObject;

     HeiAn3Line1An = transform.Find("Bg/Panel/HeiAnPanel/Ice3/Line1/An").gameObject;
     HeiAn3Line1Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice3/Line1/liang").gameObject;
     HeiAn3Line2An = transform.Find("Bg/Panel/HeiAnPanel/Ice3/Line2/An").gameObject;
     HeiAn3Line2Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice3/Line2/liang").gameObject;

     HeiAn4Line1An = transform.Find("Bg/Panel/HeiAnPanel/Ice4/Line1/An").gameObject;
     HeiAn4Line1Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice4/Line1/liang").gameObject;
     HeiAn4Line2An = transform.Find("Bg/Panel/HeiAnPanel/Ice4/Line2/An").gameObject;
     HeiAn4Line2Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice4/Line2/liang").gameObject;

     HeiAn5Line1An = transform.Find("Bg/Panel/HeiAnPanel/Ice5/Line1/An").gameObject;
     HeiAn5Line1Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice5/Line1/liang").gameObject;
     HeiAn5Line2An = transform.Find("Bg/Panel/HeiAnPanel/Ice5/Line2/An").gameObject;
     HeiAn5Line2Liang = transform.Find("Bg/Panel/HeiAnPanel/Ice5/Line2/liang").gameObject;


     IceZJLine1An = transform.Find("Bg/Panel/ZJPanel/Ice/Line1/An").gameObject;
     IceZJLine1Liang = transform.Find("Bg/Panel/ZJPanel/Ice/Line1/liang").gameObject;
     IceZJLine2An = transform.Find("Bg/Panel/ZJPanel/Ice/Line2/An").gameObject;
     IceZJLine2Liang = transform.Find("Bg/Panel/ZJPanel/Ice/Line2/liang").gameObject;
     IceZJLine3An = transform.Find("Bg/Panel/ZJPanel/Ice/Line3/An").gameObject;
     IceZJLine3Liang = transform.Find("Bg/Panel/ZJPanel/Ice/Line3/liang").gameObject;
     IceZJLine4An = transform.Find("Bg/Panel/ZJPanel/Ice/Line4/An").gameObject;
     IceZJLine4Liang = transform.Find("Bg/Panel/ZJPanel/Ice/Line4/liang").gameObject;
     IceZJLine5An = transform.Find("Bg/Panel/ZJPanel/Ice/Line5/An").gameObject;
     IceZJLine5Liang = transform.Find("Bg/Panel/ZJPanel/Ice/Line5/liang").gameObject;
     
     
     
     HuoZJLine1An = transform.Find("Bg/Panel/ZJPanel/Huo/Line1/An").gameObject;
     HuoZJLine1Liang = transform.Find("Bg/Panel/ZJPanel/Huo/Line1/liang").gameObject;
     HuoZJLine2An = transform.Find("Bg/Panel/ZJPanel/Huo/Line2/An").gameObject;
     HuoZJLine2Liang = transform.Find("Bg/Panel/ZJPanel/Huo/Line2/liang").gameObject;
     HuoZJLine3An = transform.Find("Bg/Panel/ZJPanel/Huo/Line3/An").gameObject;
     HuoZJLine3Liang = transform.Find("Bg/Panel/ZJPanel/Huo/Line3/liang").gameObject;
     HuoZJLine4An = transform.Find("Bg/Panel/ZJPanel/Huo/Line4/An").gameObject;
     HuoZJLine4Liang = transform.Find("Bg/Panel/ZJPanel/Huo/Line4/liang").gameObject;
     HuoZJLine5An = transform.Find("Bg/Panel/ZJPanel/Huo/Line5/An").gameObject;
     HuoZJLine5Liang = transform.Find("Bg/Panel/ZJPanel/Huo/Line5/liang").gameObject;
     
     
     DianZJLine1An = transform.Find("Bg/Panel/ZJPanel/Dian/Line1/An").gameObject;
     DianZJLine1Liang = transform.Find("Bg/Panel/ZJPanel/Dian/Line1/liang").gameObject;
     DianZJLine2An = transform.Find("Bg/Panel/ZJPanel/Dian/Line2/An").gameObject;
     DianZJLine2Liang = transform.Find("Bg/Panel/ZJPanel/Dian/Line2/liang").gameObject;
     DianZJLine3An = transform.Find("Bg/Panel/ZJPanel/Dian/Line3/An").gameObject;
     DianZJLine3Liang = transform.Find("Bg/Panel/ZJPanel/Dian/Line3/liang").gameObject;
     DianZJLine4An = transform.Find("Bg/Panel/ZJPanel/Dian/Line4/An").gameObject;
     DianZJLine4Liang = transform.Find("Bg/Panel/ZJPanel/Dian/Line4/liang").gameObject;
     DianZJLine5An = transform.Find("Bg/Panel/ZJPanel/Dian/Line5/An").gameObject;
     DianZJLine5Liang = transform.Find("Bg/Panel/ZJPanel/Dian/Line5/liang").gameObject;
     
     
     
     HeiAnZJLine1An = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line1/An").gameObject;
     HeiAnZJLine1Liang = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line1/liang").gameObject;
     HeiAnZJLine2An = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line2/An").gameObject;
     HeiAnZJLine2Liang = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line2/liang").gameObject;
     HeiAnZJLine3An = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line3/An").gameObject;
     HeiAnZJLine3Liang = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line3/liang").gameObject;
     HeiAnZJLine4An = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line4/An").gameObject;
     HeiAnZJLine4Liang = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line4/liang").gameObject;
     HeiAnZJLine5An = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line5/An").gameObject;
     HeiAnZJLine5Liang = transform.Find("Bg/Panel/ZJPanel/HeiAn/Line5/liang").gameObject;
     
     
     ZhiYeZJMainBg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Main/bg").GetComponent<Image>();
     ZhiYeZJMainIcon= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Main/icon").GetComponent<Image>();
     ZhiYeZJMainLevelCount= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Main/Level/level").GetComponent<TextMeshProUGUI>();
     ZhiYeZJMainLevelBg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Main/Level/bg").GetComponent<Image>();
     ZhiYeZJMainXuanZhong= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Main/xuanzhong").GetComponent<Image>();
     
     ZhiYeZJ1Bg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/1/bg").GetComponent<Image>();
     ZhiYeZJ1Icon= transform.Find("Bg/Panel/ZJPanel/ZhiYe/1/icon").GetComponent<Image>();
     ZhiYeZJ1LevelCount= transform.Find("Bg/Panel/ZJPanel/ZhiYe/1/Level/level").GetComponent<TextMeshProUGUI>();
     ZhiYeZJ1LevelBg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/1/Level/bg").GetComponent<Image>();
     ZhiYeZJ1XuanZhong= transform.Find("Bg/Panel/ZJPanel/ZhiYe/1/xuanzhong").GetComponent<Image>();
     
     ZhiYeZJ2Bg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/2/bg").GetComponent<Image>();
     ZhiYeZJ2Icon= transform.Find("Bg/Panel/ZJPanel/ZhiYe/2/icon").GetComponent<Image>();
     ZhiYeZJ2LevelCount= transform.Find("Bg/Panel/ZJPanel/ZhiYe/2/Level/level").GetComponent<TextMeshProUGUI>();
     ZhiYeZJ2LevelBg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/2/Level/bg").GetComponent<Image>();
     ZhiYeZJ2XuanZhong= transform.Find("Bg/Panel/ZJPanel/ZhiYe/2/xuanzhong").GetComponent<Image>();
     
     ZhiYeZJ3Bg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/3/bg").GetComponent<Image>();
     ZhiYeZJ3Icon= transform.Find("Bg/Panel/ZJPanel/ZhiYe/3/icon").GetComponent<Image>();
     ZhiYeZJ3LevelCount= transform.Find("Bg/Panel/ZJPanel/ZhiYe/3/Level/level").GetComponent<TextMeshProUGUI>();
     ZhiYeZJ3LevelBg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/3/Level/bg").GetComponent<Image>();
     ZhiYeZJ3XuanZhong= transform.Find("Bg/Panel/ZJPanel/ZhiYe/3/xuanzhong").GetComponent<Image>();
     
     ZhiYeZJ4Bg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/4/bg").GetComponent<Image>();
     ZhiYeZJ4Icon= transform.Find("Bg/Panel/ZJPanel/ZhiYe/4/icon").GetComponent<Image>();
     ZhiYeZJ4LevelCount= transform.Find("Bg/Panel/ZJPanel/ZhiYe/4/Level/level").GetComponent<TextMeshProUGUI>();
     ZhiYeZJ4LevelBg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/4/Level/bg").GetComponent<Image>();
     ZhiYeZJ4XuanZhong= transform.Find("Bg/Panel/ZJPanel/ZhiYe/4/xuanzhong").GetComponent<Image>();
     
     ZhiYeZJ5Bg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/5/bg").GetComponent<Image>();
     ZhiYeZJ5Icon= transform.Find("Bg/Panel/ZJPanel/ZhiYe/5/icon").GetComponent<Image>();
     ZhiYeZJ5LevelCount= transform.Find("Bg/Panel/ZJPanel/ZhiYe/5/Level/level").GetComponent<TextMeshProUGUI>();
     ZhiYeZJ5LevelBg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/5/Level/bg").GetComponent<Image>();
     ZhiYeZJ5XuanZhong= transform.Find("Bg/Panel/ZJPanel/ZhiYe/5/xuanzhong").GetComponent<Image>();
     
     ZhiYeZJ6Bg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/6/bg").GetComponent<Image>();
     ZhiYeZJ6Icon= transform.Find("Bg/Panel/ZJPanel/ZhiYe/6/icon").GetComponent<Image>();
     ZhiYeZJ6LevelCount= transform.Find("Bg/Panel/ZJPanel/ZhiYe/6/Level/level").GetComponent<TextMeshProUGUI>();
     ZhiYeZJ6LevelBg= transform.Find("Bg/Panel/ZJPanel/ZhiYe/6/Level/bg").GetComponent<Image>();
     ZhiYeZJ6XuanZhong= transform.Find("Bg/Panel/ZJPanel/ZhiYe/6/xuanzhong").GetComponent<Image>();
     
     ZhiYeZJLine1Liang= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Line1/liang").gameObject;
     ZhiYeZJLine1An= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Line1/An").gameObject;
     
     ZhiYeZJLine2Liang= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Line2/liang").gameObject;
     ZhiYeZJLine2An= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Line2/An").gameObject;
     
     ZhiYeZJLine3Liang= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Line3/liang").gameObject;
     ZhiYeZJLine3An= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Line3/An").gameObject;
     
     ZhiYeZJLine4Liang= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Line4/liang").gameObject;
     ZhiYeZJLine4An= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Line4/An").gameObject;
     
     ZhiYeZJLine5Liang= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Line5/liang").gameObject;
     ZhiYeZJLine5An= transform.Find("Bg/Panel/ZJPanel/ZhiYe/Line5/An").gameObject;

    }

    public void SetIcePanelImageColorAndJiaoHuAndLine()
    {
     if (SkillJiaDian.S.IceBei1 < 1)
     {
      IceBei2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      IceBei2Icon.GetComponent<Button>().interactable = false;
      IceBeiLine1Liang.gameObject.SetActive(false);
      IceBeiLine1An.gameObject.SetActive(true);
     }
     else
     {
      IceBei2Icon.color = new Color(1, 1, 1);
      IceBei2Icon.GetComponent<Button>().interactable = true;
      IceBeiLine1Liang.gameObject.SetActive(true);
      IceBeiLine1An.gameObject.SetActive(false);
     }

     if (SkillJiaDian.S.IceBei3 < 1)
     {
      IceBei4Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      IceBei4Icon.GetComponent<Button>().interactable = false;
      IceBeiLine2Liang.gameObject.SetActive(false);
      IceBeiLine2An.gameObject.SetActive(true);
     }
     else
     {
      IceBei4Icon.color = new Color(1, 1, 1);
      IceBei4Icon.GetComponent<Button>().interactable = true;
      IceBeiLine2Liang.gameObject.SetActive(true);
      IceBeiLine2An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Ice1 < 1)
     {
      Ice1_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Ice1_1Icon.GetComponent<Button>().interactable = false;
      Ice1Line1Liang.gameObject.SetActive(false);
      Ice1Line1An.gameObject.SetActive(true);
     }
     else
     {
      Ice1_1Icon.color = new Color(1,1,1);
      Ice1_1Icon.GetComponent<Button>().interactable = true;
      Ice1Line1Liang.gameObject.SetActive(true);
      Ice1Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Ice1_1 < 1)
     {
      Ice1_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Ice1_2Icon.GetComponent<Button>().interactable = false;
      Ice1Line2Liang.gameObject.SetActive(false);
      Ice1Line2An.gameObject.SetActive(true);
     }
     else
     {
      Ice1_2Icon.color = new Color(1,1,1);
      Ice1_2Icon.GetComponent<Button>().interactable = true;
      Ice1Line2Liang.gameObject.SetActive(true);
      Ice1Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.Ice2 < 1)
     {
      Ice2_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Ice2_1Icon.GetComponent<Button>().interactable = false;
      Ice2Line1Liang.gameObject.SetActive(false);
      Ice2Line1An.gameObject.SetActive(true);
     }
     else
     {
      Ice2_1Icon.color = new Color(1,1,1);
      Ice2_1Icon.GetComponent<Button>().interactable = true;
      Ice2Line1Liang.gameObject.SetActive(true);
      Ice2Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Ice2_1 < 1)
     {
      Ice2_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Ice2_2Icon.GetComponent<Button>().interactable = false;
      Ice2Line2Liang.gameObject.SetActive(false);
      Ice2Line2An.gameObject.SetActive(true);
     }
     else
     {
      Ice2_2Icon.color = new Color(1,1,1);
      Ice2_2Icon.GetComponent<Button>().interactable = true;
      Ice2Line2Liang.gameObject.SetActive(true);
      Ice2Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.Ice3 < 1)
     {
      Ice3_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Ice3_1Icon.GetComponent<Button>().interactable = false;
      Ice3Line1Liang.gameObject.SetActive(false);
      Ice3Line1An.gameObject.SetActive(true);
     }
     else
     {
      Ice3_1Icon.color = new Color(1,1,1);
      Ice3_1Icon.GetComponent<Button>().interactable = true;
      Ice3Line1Liang.gameObject.SetActive(true);
      Ice3Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Ice3_1 < 1)
     {
      Ice3_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Ice3_2Icon.GetComponent<Button>().interactable = false;
      Ice3Line2Liang.gameObject.SetActive(false);
      Ice3Line2An.gameObject.SetActive(true);
     }
     else
     {
      Ice3_2Icon.color = new Color(1,1,1);
      Ice3_2Icon.GetComponent<Button>().interactable = true;
      Ice3Line2Liang.gameObject.SetActive(true);
      Ice3Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.Ice4 < 1)
     {
      Ice4_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Ice4_1Icon.GetComponent<Button>().interactable = false;
      Ice4Line1Liang.gameObject.SetActive(false);
      Ice4Line1An.gameObject.SetActive(true);
     }
     else
     {
      Ice4_1Icon.color = new Color(1,1,1);
      Ice4_1Icon.GetComponent<Button>().interactable = true;
      Ice4Line1Liang.gameObject.SetActive(true);
      Ice4Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Ice4_1 < 1)
     {
      Ice4_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Ice4_2Icon.GetComponent<Button>().interactable = false;
      Ice4Line2Liang.gameObject.SetActive(false);
      Ice4Line2An.gameObject.SetActive(true);
     }
     else
     {
      Ice4_2Icon.color = new Color(1,1,1);
      Ice4_2Icon.GetComponent<Button>().interactable = true;
      Ice4Line2Liang.gameObject.SetActive(true);
      Ice4Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.Ice5 < 1)
     {
      Ice5_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Ice5_1Icon.GetComponent<Button>().interactable = false;
      Ice5Line1Liang.gameObject.SetActive(false);
      Ice5Line1An.gameObject.SetActive(true);
     }
     else
     {
      Ice5_1Icon.color = new Color(1,1,1);
      Ice5_1Icon.GetComponent<Button>().interactable = true;
      Ice5Line1Liang.gameObject.SetActive(true);
      Ice5Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Ice5_1 < 1)
     {
      Ice5_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Ice5_2Icon.GetComponent<Button>().interactable = false;
      Ice5Line2Liang.gameObject.SetActive(false);
      Ice5Line2An.gameObject.SetActive(true);
     }
     else
     {
      Ice5_2Icon.color = new Color(1,1,1);
      Ice5_2Icon.GetComponent<Button>().interactable = true;
      Ice5Line2Liang.gameObject.SetActive(true);
      Ice5Line2An.gameObject.SetActive(false);
     }

    }
    
    
     public void SetHuoPanelImageColorAndJiaoHuAndLine()
    {
     if (SkillJiaDian.S.HuoBei1 < 1)
     {
      HuoBei2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HuoBei2Icon.GetComponent<Button>().interactable = false;
      HuoBeiLine1Liang.gameObject.SetActive(false);
      HuoBeiLine1An.gameObject.SetActive(true);
     }
     else
     {
      HuoBei2Icon.color = new Color(1, 1, 1);
      HuoBei2Icon.GetComponent<Button>().interactable = true;
      HuoBeiLine1Liang.gameObject.SetActive(true);
      HuoBeiLine1An.gameObject.SetActive(false);
     }

     if (SkillJiaDian.S.HuoBei3 < 1)
     {
      HuoBei4Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HuoBei4Icon.GetComponent<Button>().interactable = false;
      HuoBeiLine2Liang.gameObject.SetActive(false);
      HuoBeiLine2An.gameObject.SetActive(true);
     }
     else
     {
      HuoBei4Icon.color = new Color(1, 1, 1);
      HuoBei4Icon.GetComponent<Button>().interactable = true;
      HuoBeiLine2Liang.gameObject.SetActive(true);
      HuoBeiLine2An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Huo1 < 1)
     {
      Huo1_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Huo1_1Icon.GetComponent<Button>().interactable = false;
      Huo1Line1Liang.gameObject.SetActive(false);
      Huo1Line1An.gameObject.SetActive(true);
     }
     else
     {
      Huo1_1Icon.color = new Color(1,1,1);
      Huo1_1Icon.GetComponent<Button>().interactable = true;
      Huo1Line1Liang.gameObject.SetActive(true);
      Huo1Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Huo1_1 < 1)
     {
      Huo1_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Huo1_2Icon.GetComponent<Button>().interactable = false;
      Huo1Line2Liang.gameObject.SetActive(false);
      Huo1Line2An.gameObject.SetActive(true);
     }
     else
     {
      Huo1_2Icon.color = new Color(1,1,1);
      Huo1_2Icon.GetComponent<Button>().interactable = true;
      Huo1Line2Liang.gameObject.SetActive(true);
      Huo1Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.Huo2 < 1)
     {
      Huo2_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Huo2_1Icon.GetComponent<Button>().interactable = false;
      Huo2Line1Liang.gameObject.SetActive(false);
      Huo2Line1An.gameObject.SetActive(true);
     }
     else
     {
      Huo2_1Icon.color = new Color(1,1,1);
      Huo2_1Icon.GetComponent<Button>().interactable = true;
      Huo2Line1Liang.gameObject.SetActive(true);
      Huo2Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Huo2_1 < 1)
     {
      Huo2_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Huo2_2Icon.GetComponent<Button>().interactable = false;
      Huo2Line2Liang.gameObject.SetActive(false);
      Huo2Line2An.gameObject.SetActive(true);
     }
     else
     {
      Huo2_2Icon.color = new Color(1,1,1);
      Huo2_2Icon.GetComponent<Button>().interactable = true;
      Huo2Line2Liang.gameObject.SetActive(true);
      Huo2Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.Huo3 < 1)
     {
      Huo3_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Huo3_1Icon.GetComponent<Button>().interactable = false;
      Huo3Line1Liang.gameObject.SetActive(false);
      Huo3Line1An.gameObject.SetActive(true);
     }
     else
     {
      Huo3_1Icon.color = new Color(1,1,1);
      Huo3_1Icon.GetComponent<Button>().interactable = true;
      Huo3Line1Liang.gameObject.SetActive(true);
      Huo3Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Huo3_1 < 1)
     {
      Huo3_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Huo3_2Icon.GetComponent<Button>().interactable = false;
      Huo3Line2Liang.gameObject.SetActive(false);
      Huo3Line2An.gameObject.SetActive(true);
     }
     else
     {
      Huo3_2Icon.color = new Color(1,1,1);
      Huo3_2Icon.GetComponent<Button>().interactable = true;
      Huo3Line2Liang.gameObject.SetActive(true);
      Huo3Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.Huo4 < 1)
     {
      Huo4_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Huo4_1Icon.GetComponent<Button>().interactable = false;
      Huo4Line1Liang.gameObject.SetActive(false);
      Huo4Line1An.gameObject.SetActive(true);
     }
     else
     {
      Huo4_1Icon.color = new Color(1,1,1);
      Huo4_1Icon.GetComponent<Button>().interactable = true;
      Huo4Line1Liang.gameObject.SetActive(true);
      Huo4Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Huo4_1 < 1)
     {
      Huo4_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Huo4_2Icon.GetComponent<Button>().interactable = false;
      Huo4Line2Liang.gameObject.SetActive(false);
      Huo4Line2An.gameObject.SetActive(true);
     }
     else
     {
      Huo4_2Icon.color = new Color(1,1,1);
      Huo4_2Icon.GetComponent<Button>().interactable = true;
      Huo4Line2Liang.gameObject.SetActive(true);
      Huo4Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.Huo5 < 1)
     {
      Huo5_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Huo5_1Icon.GetComponent<Button>().interactable = false;
      Huo5Line1Liang.gameObject.SetActive(false);
      Huo5Line1An.gameObject.SetActive(true);
     }
     else
     {
      Huo5_1Icon.color = new Color(1,1,1);
      Huo5_1Icon.GetComponent<Button>().interactable = true;
      Huo5Line1Liang.gameObject.SetActive(true);
      Huo5Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Huo5_1 < 1)
     {
      Huo5_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Huo5_2Icon.GetComponent<Button>().interactable = false;
      Huo5Line2Liang.gameObject.SetActive(false);
      Huo5Line2An.gameObject.SetActive(true);
     }
     else
     {
      Huo5_2Icon.color = new Color(1,1,1);
      Huo5_2Icon.GetComponent<Button>().interactable = true;
      Huo5Line2Liang.gameObject.SetActive(true);
      Huo5Line2An.gameObject.SetActive(false);
     }

    }
     
     
      public void SetDianPanelImageColorAndJiaoHuAndLine()
    {
     if (SkillJiaDian.S.DianBei1 < 1)
     {
      DianBei2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      DianBei2Icon.GetComponent<Button>().interactable = false;
      DianBeiLine1Liang.gameObject.SetActive(false);
      DianBeiLine1An.gameObject.SetActive(true);
     }
     else
     {
      DianBei2Icon.color = new Color(1, 1, 1);
      DianBei2Icon.GetComponent<Button>().interactable = true;
      DianBeiLine1Liang.gameObject.SetActive(true);
      DianBeiLine1An.gameObject.SetActive(false);
     }

     if (SkillJiaDian.S.DianBei3 < 1)
     {
      DianBei4Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      DianBei4Icon.GetComponent<Button>().interactable = false;
      DianBeiLine2Liang.gameObject.SetActive(false);
      DianBeiLine2An.gameObject.SetActive(true);
     }
     else
     {
      DianBei4Icon.color = new Color(1, 1, 1);
      DianBei4Icon.GetComponent<Button>().interactable = true;
      DianBeiLine2Liang.gameObject.SetActive(true);
      DianBeiLine2An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Dian1 < 1)
     {
      Dian1_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Dian1_1Icon.GetComponent<Button>().interactable = false;
      Dian1Line1Liang.gameObject.SetActive(false);
      Dian1Line1An.gameObject.SetActive(true);
     }
     else
     {
      Dian1_1Icon.color = new Color(1,1,1);
      Dian1_1Icon.GetComponent<Button>().interactable = true;
      Dian1Line1Liang.gameObject.SetActive(true);
      Dian1Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Dian1_1 < 1)
     {
      Dian1_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Dian1_2Icon.GetComponent<Button>().interactable = false;
      Dian1Line2Liang.gameObject.SetActive(false);
      Dian1Line2An.gameObject.SetActive(true);
     }
     else
     {
      Dian1_2Icon.color = new Color(1,1,1);
      Dian1_2Icon.GetComponent<Button>().interactable = true;
      Dian1Line2Liang.gameObject.SetActive(true);
      Dian1Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.Dian2 < 1)
     {
      Dian2_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Dian2_1Icon.GetComponent<Button>().interactable = false;
      Dian2Line1Liang.gameObject.SetActive(false);
      Dian2Line1An.gameObject.SetActive(true);
     }
     else
     {
      Dian2_1Icon.color = new Color(1,1,1);
      Dian2_1Icon.GetComponent<Button>().interactable = true;
      Dian2Line1Liang.gameObject.SetActive(true);
      Dian2Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Dian2_1 < 1)
     {
      Dian2_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Dian2_2Icon.GetComponent<Button>().interactable = false;
      Dian2Line2Liang.gameObject.SetActive(false);
      Dian2Line2An.gameObject.SetActive(true);
     }
     else
     {
      Dian2_2Icon.color = new Color(1,1,1);
      Dian2_2Icon.GetComponent<Button>().interactable = true;
      Dian2Line2Liang.gameObject.SetActive(true);
      Dian2Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.Dian3 < 1)
     {
      Dian3_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Dian3_1Icon.GetComponent<Button>().interactable = false;
      Dian3Line1Liang.gameObject.SetActive(false);
      Dian3Line1An.gameObject.SetActive(true);
     }
     else
     {
      Dian3_1Icon.color = new Color(1,1,1);
      Dian3_1Icon.GetComponent<Button>().interactable = true;
      Dian3Line1Liang.gameObject.SetActive(true);
      Dian3Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Dian3_1 < 1)
     {
      Dian3_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Dian3_2Icon.GetComponent<Button>().interactable = false;
      Dian3Line2Liang.gameObject.SetActive(false);
      Dian3Line2An.gameObject.SetActive(true);
     }
     else
     {
      Dian3_2Icon.color = new Color(1,1,1);
      Dian3_2Icon.GetComponent<Button>().interactable = true;
      Dian3Line2Liang.gameObject.SetActive(true);
      Dian3Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.Dian4 < 1)
     {
      Dian4_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Dian4_1Icon.GetComponent<Button>().interactable = false;
      Dian4Line1Liang.gameObject.SetActive(false);
      Dian4Line1An.gameObject.SetActive(true);
     }
     else
     {
      Dian4_1Icon.color = new Color(1,1,1);
      Dian4_1Icon.GetComponent<Button>().interactable = true;
      Dian4Line1Liang.gameObject.SetActive(true);
      Dian4Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Dian4_1 < 1)
     {
      Dian4_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Dian4_2Icon.GetComponent<Button>().interactable = false;
      Dian4Line2Liang.gameObject.SetActive(false);
      Dian4Line2An.gameObject.SetActive(true);
     }
     else
     {
      Dian4_2Icon.color = new Color(1,1,1);
      Dian4_2Icon.GetComponent<Button>().interactable = true;
      Dian4Line2Liang.gameObject.SetActive(true);
      Dian4Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.Dian5 < 1)
     {
      Dian5_1Icon.color = new Color(93/255f,79/255f,79/255f);
      Dian5_1Icon.GetComponent<Button>().interactable = false;
      Dian5Line1Liang.gameObject.SetActive(false);
      Dian5Line1An.gameObject.SetActive(true);
     }
     else
     {
      Dian5_1Icon.color = new Color(1,1,1);
      Dian5_1Icon.GetComponent<Button>().interactable = true;
      Dian5Line1Liang.gameObject.SetActive(true);
      Dian5Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.Dian5_1 < 1)
     {
      Dian5_2Icon.color = new Color(93/255f,79/255f,79/255f);
      Dian5_2Icon.GetComponent<Button>().interactable = false;
      Dian5Line2Liang.gameObject.SetActive(false);
      Dian5Line2An.gameObject.SetActive(true);
     }
     else
     {
      Dian5_2Icon.color = new Color(1,1,1);
      Dian5_2Icon.GetComponent<Button>().interactable = true;
      Dian5Line2Liang.gameObject.SetActive(true);
      Dian5Line2An.gameObject.SetActive(false);
     }

    }
      
       public void SetHeiAnPanelImageColorAndJiaoHuAndLine()
    {
     if (SkillJiaDian.S.HeiAnBei1 < 1)
     {
      HeiAnBei2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HeiAnBei2Icon.GetComponent<Button>().interactable = false;
      HeiAnBeiLine1Liang.gameObject.SetActive(false);
      HeiAnBeiLine1An.gameObject.SetActive(true);
     }
     else
     {
      HeiAnBei2Icon.color = new Color(1, 1, 1);
      HeiAnBei2Icon.GetComponent<Button>().interactable = true;
      HeiAnBeiLine1Liang.gameObject.SetActive(true);
      HeiAnBeiLine1An.gameObject.SetActive(false);
     }

     if (SkillJiaDian.S.HeiAnBei3 < 1)
     {
      HeiAnBei4Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HeiAnBei4Icon.GetComponent<Button>().interactable = false;
      HeiAnBeiLine2Liang.gameObject.SetActive(false);
      HeiAnBeiLine2An.gameObject.SetActive(true);
     }
     else
     {
      HeiAnBei4Icon.color = new Color(1, 1, 1);
      HeiAnBei4Icon.GetComponent<Button>().interactable = true;
      HeiAnBeiLine2Liang.gameObject.SetActive(true);
      HeiAnBeiLine2An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.HeiAn1 < 1)
     {
      HeiAn1_1Icon.color = new Color(93/255f,79/255f,79/255f);
      HeiAn1_1Icon.GetComponent<Button>().interactable = false;
      HeiAn1Line1Liang.gameObject.SetActive(false);
      HeiAn1Line1An.gameObject.SetActive(true);
     }
     else
     {
      HeiAn1_1Icon.color = new Color(1,1,1);
      HeiAn1_1Icon.GetComponent<Button>().interactable = true;
      HeiAn1Line1Liang.gameObject.SetActive(true);
      HeiAn1Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.HeiAn1_1 < 1)
     {
      HeiAn1_2Icon.color = new Color(93/255f,79/255f,79/255f);
      HeiAn1_2Icon.GetComponent<Button>().interactable = false;
      HeiAn1Line2Liang.gameObject.SetActive(false);
      HeiAn1Line2An.gameObject.SetActive(true);
     }
     else
     {
      HeiAn1_2Icon.color = new Color(1,1,1);
      HeiAn1_2Icon.GetComponent<Button>().interactable = true;
      HeiAn1Line2Liang.gameObject.SetActive(true);
      HeiAn1Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.HeiAn2 < 1)
     {
      HeiAn2_1Icon.color = new Color(93/255f,79/255f,79/255f);
      HeiAn2_1Icon.GetComponent<Button>().interactable = false;
      HeiAn2Line1Liang.gameObject.SetActive(false);
      HeiAn2Line1An.gameObject.SetActive(true);
     }
     else
     {
      HeiAn2_1Icon.color = new Color(1,1,1);
      HeiAn2_1Icon.GetComponent<Button>().interactable = true;
      HeiAn2Line1Liang.gameObject.SetActive(true);
      HeiAn2Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.HeiAn2_1 < 1)
     {
      HeiAn2_2Icon.color = new Color(93/255f,79/255f,79/255f);
      HeiAn2_2Icon.GetComponent<Button>().interactable = false;
      HeiAn2Line2Liang.gameObject.SetActive(false);
      HeiAn2Line2An.gameObject.SetActive(true);
     }
     else
     {
      HeiAn2_2Icon.color = new Color(1,1,1);
      HeiAn2_2Icon.GetComponent<Button>().interactable = true;
      HeiAn2Line2Liang.gameObject.SetActive(true);
      HeiAn2Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.HeiAn3 < 1)
     {
      HeiAn3_1Icon.color = new Color(93/255f,79/255f,79/255f);
      HeiAn3_1Icon.GetComponent<Button>().interactable = false;
      HeiAn3Line1Liang.gameObject.SetActive(false);
      HeiAn3Line1An.gameObject.SetActive(true);
     }
     else
     {
      HeiAn3_1Icon.color = new Color(1,1,1);
      HeiAn3_1Icon.GetComponent<Button>().interactable = true;
      HeiAn3Line1Liang.gameObject.SetActive(true);
      HeiAn3Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.HeiAn3_1 < 1)
     {
      HeiAn3_2Icon.color = new Color(93/255f,79/255f,79/255f);
      HeiAn3_2Icon.GetComponent<Button>().interactable = false;
      HeiAn3Line2Liang.gameObject.SetActive(false);
      HeiAn3Line2An.gameObject.SetActive(true);
     }
     else
     {
      HeiAn3_2Icon.color = new Color(1,1,1);
      HeiAn3_2Icon.GetComponent<Button>().interactable = true;
      HeiAn3Line2Liang.gameObject.SetActive(true);
      HeiAn3Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.HeiAn4 < 1)
     {
      HeiAn4_1Icon.color = new Color(93/255f,79/255f,79/255f);
      HeiAn4_1Icon.GetComponent<Button>().interactable = false;
      HeiAn4Line1Liang.gameObject.SetActive(false);
      HeiAn4Line1An.gameObject.SetActive(true);
     }
     else
     {
      HeiAn4_1Icon.color = new Color(1,1,1);
      HeiAn4_1Icon.GetComponent<Button>().interactable = true;
      HeiAn4Line1Liang.gameObject.SetActive(true);
      HeiAn4Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.HeiAn4_1 < 1)
     {
      HeiAn4_2Icon.color = new Color(93/255f,79/255f,79/255f);
      HeiAn4_2Icon.GetComponent<Button>().interactable = false;
      HeiAn4Line2Liang.gameObject.SetActive(false);
      HeiAn4Line2An.gameObject.SetActive(true);
     }
     else
     {
      HeiAn4_2Icon.color = new Color(1,1,1);
      HeiAn4_2Icon.GetComponent<Button>().interactable = true;
      HeiAn4Line2Liang.gameObject.SetActive(true);
      HeiAn4Line2An.gameObject.SetActive(false);
     }
     
     
     
     if (SkillJiaDian.S.HeiAn5 < 1)
     {
      HeiAn5_1Icon.color = new Color(93/255f,79/255f,79/255f);
      HeiAn5_1Icon.GetComponent<Button>().interactable = false;
      HeiAn5Line1Liang.gameObject.SetActive(false);
      HeiAn5Line1An.gameObject.SetActive(true);
     }
     else
     {
      HeiAn5_1Icon.color = new Color(1,1,1);
      HeiAn5_1Icon.GetComponent<Button>().interactable = true;
      HeiAn5Line1Liang.gameObject.SetActive(true);
      HeiAn5Line1An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.HeiAn5_1 < 1)
     {
      HeiAn5_2Icon.color = new Color(93/255f,79/255f,79/255f);
      HeiAn5_2Icon.GetComponent<Button>().interactable = false;
      HeiAn5Line2Liang.gameObject.SetActive(false);
      HeiAn5Line2An.gameObject.SetActive(true);
     }
     else
     {
      HeiAn5_2Icon.color = new Color(1,1,1);
      HeiAn5_2Icon.GetComponent<Button>().interactable = true;
      HeiAn5Line2Liang.gameObject.SetActive(true);
      HeiAn5Line2An.gameObject.SetActive(false);
     }

    }
       
       
         public void SetZJPanelImageColorAndJiaoHuAndLine()
    {
     if (SkillJiaDian.S.IceZJ1 < 1)
     {
      IceZJ2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      IceZJ2Icon.GetComponent<Button>().interactable = false;
      IceZJLine1Liang.gameObject.SetActive(false);
      IceZJLine1An.gameObject.SetActive(true);
     }
     else
     {
      IceZJ2Icon.color = new Color(1, 1, 1);
      IceZJ2Icon.GetComponent<Button>().interactable = true;
      IceZJLine1Liang.gameObject.SetActive(true);
      IceZJLine1An.gameObject.SetActive(false);
     }

     if (SkillJiaDian.S.IceZJ2 < 1)
     {
      IceZJ3Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      IceZJ3Icon.GetComponent<Button>().interactable = false;
      IceZJLine2Liang.gameObject.SetActive(false);
      IceZJLine2An.gameObject.SetActive(true);
     }
     else
     {
      IceZJ3Icon.color = new Color(1, 1, 1);
      IceZJ3Icon.GetComponent<Button>().interactable = true;
      IceZJLine2Liang.gameObject.SetActive(true);
      IceZJLine2An.gameObject.SetActive(false);
     }
     
     if (SkillJiaDian.S.IceZJ3 < 1)
     {
      IceZJ4Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      IceZJ4Icon.GetComponent<Button>().interactable = false;
      IceZJLine3Liang.gameObject.SetActive(false);
      IceZJLine3An.gameObject.SetActive(true);
     }
     else
     {
      IceZJ4Icon.color = new Color(1, 1, 1);
      IceZJ4Icon.GetComponent<Button>().interactable = true;
      IceZJLine3Liang.gameObject.SetActive(true);
      IceZJLine3An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.IceZJ4 < 1)
     {
      IceZJ5Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      IceZJ5Icon.GetComponent<Button>().interactable = false;
      IceZJLine4Liang.gameObject.SetActive(false);
      IceZJLine4An.gameObject.SetActive(true);
     }
     else
     {
      IceZJ5Icon.color = new Color(1, 1, 1);
      IceZJ5Icon.GetComponent<Button>().interactable = true;
      IceZJLine4Liang.gameObject.SetActive(true);
      IceZJLine4An.gameObject.SetActive(false);
     }
     
     if (SkillJiaDian.S.IceZJ5 < 1)
     {
      IceZJ6Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      IceZJ6Icon.GetComponent<Button>().interactable = false;
      IceZJLine5Liang.gameObject.SetActive(false);
      IceZJLine5An.gameObject.SetActive(true);
     }
     else
     {
      IceZJ6Icon.color = new Color(1, 1, 1);
      IceZJ6Icon.GetComponent<Button>().interactable = true;
      IceZJLine5Liang.gameObject.SetActive(true);
      IceZJLine5An.gameObject.SetActive(false);
     }
     
     
     
     
     
     if (SkillJiaDian.S.HuoZJ1 < 1)
     {
      HuoZJ2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HuoZJ2Icon.GetComponent<Button>().interactable = false;
      HuoZJLine1Liang.gameObject.SetActive(false);
      HuoZJLine1An.gameObject.SetActive(true);
     }
     else
     {
      HuoZJ2Icon.color = new Color(1, 1, 1);
      HuoZJ2Icon.GetComponent<Button>().interactable = true;
      HuoZJLine1Liang.gameObject.SetActive(true);
      HuoZJLine1An.gameObject.SetActive(false);
     }

     if (SkillJiaDian.S.HuoZJ2 < 1)
     {
      HuoZJ3Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HuoZJ3Icon.GetComponent<Button>().interactable = false;
      HuoZJLine2Liang.gameObject.SetActive(false);
      HuoZJLine2An.gameObject.SetActive(true);
     }
     else
     {
      HuoZJ3Icon.color = new Color(1, 1, 1);
      HuoZJ3Icon.GetComponent<Button>().interactable = true;
      HuoZJLine2Liang.gameObject.SetActive(true);
      HuoZJLine2An.gameObject.SetActive(false);
     }
     
     if (SkillJiaDian.S.HuoZJ3 < 1)
     {
      HuoZJ4Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HuoZJ4Icon.GetComponent<Button>().interactable = false;
      HuoZJLine3Liang.gameObject.SetActive(false);
      HuoZJLine3An.gameObject.SetActive(true);
     }
     else
     {
      HuoZJ4Icon.color = new Color(1, 1, 1);
      HuoZJ4Icon.GetComponent<Button>().interactable = true;
      HuoZJLine3Liang.gameObject.SetActive(true);
      HuoZJLine3An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.HuoZJ4 < 1)
     {
      HuoZJ5Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HuoZJ5Icon.GetComponent<Button>().interactable = false;
      HuoZJLine4Liang.gameObject.SetActive(false);
      HuoZJLine4An.gameObject.SetActive(true);
     }
     else
     {
      HuoZJ5Icon.color = new Color(1, 1, 1);
      HuoZJ5Icon.GetComponent<Button>().interactable = true;
      HuoZJLine4Liang.gameObject.SetActive(true);
      HuoZJLine4An.gameObject.SetActive(false);
     }
     
     if (SkillJiaDian.S.HuoZJ5 < 1)
     {
      HuoZJ6Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HuoZJ6Icon.GetComponent<Button>().interactable = false;
      HuoZJLine5Liang.gameObject.SetActive(false);
      HuoZJLine5An.gameObject.SetActive(true);
     }
     else
     {
      HuoZJ6Icon.color = new Color(1, 1, 1);
      HuoZJ6Icon.GetComponent<Button>().interactable = true;
      HuoZJLine5Liang.gameObject.SetActive(true);
      HuoZJLine5An.gameObject.SetActive(false);
     }
     
     
     
     
     if (SkillJiaDian.S.DianZJ1 < 1)
     {
      DianZJ2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      DianZJ2Icon.GetComponent<Button>().interactable = false;
      DianZJLine1Liang.gameObject.SetActive(false);
      DianZJLine1An.gameObject.SetActive(true);
     }
     else
     {
      DianZJ2Icon.color = new Color(1, 1, 1);
      DianZJ2Icon.GetComponent<Button>().interactable = true;
      DianZJLine1Liang.gameObject.SetActive(true);
      DianZJLine1An.gameObject.SetActive(false);
     }

     if (SkillJiaDian.S.DianZJ2 < 1)
     {
      DianZJ3Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      DianZJ3Icon.GetComponent<Button>().interactable = false;
      DianZJLine2Liang.gameObject.SetActive(false);
      DianZJLine2An.gameObject.SetActive(true);
     }
     else
     {
      DianZJ3Icon.color = new Color(1, 1, 1);
      DianZJ3Icon.GetComponent<Button>().interactable = true;
      DianZJLine2Liang.gameObject.SetActive(true);
      DianZJLine2An.gameObject.SetActive(false);
     }
     
     if (SkillJiaDian.S.DianZJ3 < 1)
     {
      DianZJ4Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      DianZJ4Icon.GetComponent<Button>().interactable = false;
      DianZJLine3Liang.gameObject.SetActive(false);
      DianZJLine3An.gameObject.SetActive(true);
     }
     else
     {
      DianZJ4Icon.color = new Color(1, 1, 1);
      DianZJ4Icon.GetComponent<Button>().interactable = true;
      DianZJLine3Liang.gameObject.SetActive(true);
      DianZJLine3An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.DianZJ4 < 1)
     {
      DianZJ5Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      DianZJ5Icon.GetComponent<Button>().interactable = false;
      DianZJLine4Liang.gameObject.SetActive(false);
      DianZJLine4An.gameObject.SetActive(true);
     }
     else
     {
      DianZJ5Icon.color = new Color(1, 1, 1);
      DianZJ5Icon.GetComponent<Button>().interactable = true;
      DianZJLine4Liang.gameObject.SetActive(true);
      DianZJLine4An.gameObject.SetActive(false);
     }
     
     if (SkillJiaDian.S.DianZJ5 < 1)
     {
      DianZJ6Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      DianZJ6Icon.GetComponent<Button>().interactable = false;
      DianZJLine5Liang.gameObject.SetActive(false);
      DianZJLine5An.gameObject.SetActive(true);
     }
     else
     {
      DianZJ6Icon.color = new Color(1, 1, 1);
      DianZJ6Icon.GetComponent<Button>().interactable = true;
      DianZJLine5Liang.gameObject.SetActive(true);
      DianZJLine5An.gameObject.SetActive(false);
     }
     
     
     
     
     if (SkillJiaDian.S.HeiAnZJ1 < 1)
     {
      HeiAnZJ2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HeiAnZJ2Icon.GetComponent<Button>().interactable = false;
      HeiAnZJLine1Liang.gameObject.SetActive(false);
      HeiAnZJLine1An.gameObject.SetActive(true);
     }
     else
     {
      HeiAnZJ2Icon.color = new Color(1, 1, 1);
      HeiAnZJ2Icon.GetComponent<Button>().interactable = true;
      HeiAnZJLine1Liang.gameObject.SetActive(true);
      HeiAnZJLine1An.gameObject.SetActive(false);
     }

     if (SkillJiaDian.S.HeiAnZJ2 < 1)
     {
      HeiAnZJ3Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HeiAnZJ3Icon.GetComponent<Button>().interactable = false;
      HeiAnZJLine2Liang.gameObject.SetActive(false);
      HeiAnZJLine2An.gameObject.SetActive(true);
     }
     else
     {
      HeiAnZJ3Icon.color = new Color(1, 1, 1);
      HeiAnZJ3Icon.GetComponent<Button>().interactable = true;
      HeiAnZJLine2Liang.gameObject.SetActive(true);
      HeiAnZJLine2An.gameObject.SetActive(false);
     }
     
     if (SkillJiaDian.S.HeiAnZJ3 < 1)
     {
      HeiAnZJ4Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HeiAnZJ4Icon.GetComponent<Button>().interactable = false;
      HeiAnZJLine3Liang.gameObject.SetActive(false);
      HeiAnZJLine3An.gameObject.SetActive(true);
     }
     else
     {
      HeiAnZJ4Icon.color = new Color(1, 1, 1);
      HeiAnZJ4Icon.GetComponent<Button>().interactable = true;
      HeiAnZJLine3Liang.gameObject.SetActive(true);
      HeiAnZJLine3An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.HeiAnZJ4 < 1)
     {
      HeiAnZJ5Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HeiAnZJ5Icon.GetComponent<Button>().interactable = false;
      HeiAnZJLine4Liang.gameObject.SetActive(false);
      HeiAnZJLine4An.gameObject.SetActive(true);
     }
     else
     {
      HeiAnZJ5Icon.color = new Color(1, 1, 1);
      HeiAnZJ5Icon.GetComponent<Button>().interactable = true;
      HeiAnZJLine4Liang.gameObject.SetActive(true);
      HeiAnZJLine4An.gameObject.SetActive(false);
     }
     
     if (SkillJiaDian.S.HeiAnZJ5 < 1)
     {
      HeiAnZJ6Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      HeiAnZJ6Icon.GetComponent<Button>().interactable = false;
      HeiAnZJLine5Liang.gameObject.SetActive(false);
      HeiAnZJLine5An.gameObject.SetActive(true);
     }
     else
     {
      HeiAnZJ6Icon.color = new Color(1, 1, 1);
      HeiAnZJ6Icon.GetComponent<Button>().interactable = true;
      HeiAnZJLine5Liang.gameObject.SetActive(true);
      HeiAnZJLine5An.gameObject.SetActive(false);
     }
     
     
     
     
     if (SkillJiaDian.S.ZhiYeZJ1 < 1)
     {
      ZhiYeZJ2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      ZhiYeZJ2Icon.GetComponent<Button>().interactable = false;
      ZhiYeZJLine1Liang.gameObject.SetActive(false);
      ZhiYeZJLine1An.gameObject.SetActive(true);
     }
     else
     {
      ZhiYeZJ2Icon.color = new Color(1, 1, 1);
      ZhiYeZJ2Icon.GetComponent<Button>().interactable = true;
      ZhiYeZJLine1Liang.gameObject.SetActive(true);
      ZhiYeZJLine1An.gameObject.SetActive(false);
     }

     if (SkillJiaDian.S.ZhiYeZJ2 < 1)
     {
      ZhiYeZJ3Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      ZhiYeZJ3Icon.GetComponent<Button>().interactable = false;
      ZhiYeZJLine2Liang.gameObject.SetActive(false);
      ZhiYeZJLine2An.gameObject.SetActive(true);
     }
     else
     {
      ZhiYeZJ3Icon.color = new Color(1, 1, 1);
      ZhiYeZJ3Icon.GetComponent<Button>().interactable = true;
      ZhiYeZJLine2Liang.gameObject.SetActive(true);
      ZhiYeZJLine2An.gameObject.SetActive(false);
     }
     
     if (SkillJiaDian.S.ZhiYeZJ3 < 1)
     {
      ZhiYeZJ4Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      ZhiYeZJ4Icon.GetComponent<Button>().interactable = false;
      ZhiYeZJLine3Liang.gameObject.SetActive(false);
      ZhiYeZJLine3An.gameObject.SetActive(true);
     }
     else
     {
      ZhiYeZJ4Icon.color = new Color(1, 1, 1);
      ZhiYeZJ4Icon.GetComponent<Button>().interactable = true;
      ZhiYeZJLine3Liang.gameObject.SetActive(true);
      ZhiYeZJLine3An.gameObject.SetActive(false);
     }
     
     
     if (SkillJiaDian.S.ZhiYeZJ4 < 1)
     {
      ZhiYeZJ5Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      ZhiYeZJ5Icon.GetComponent<Button>().interactable = false;
      ZhiYeZJLine4Liang.gameObject.SetActive(false);
      ZhiYeZJLine4An.gameObject.SetActive(true);
     }
     else
     {
      ZhiYeZJ5Icon.color = new Color(1, 1, 1);
      ZhiYeZJ5Icon.GetComponent<Button>().interactable = true;
      ZhiYeZJLine4Liang.gameObject.SetActive(true);
      ZhiYeZJLine4An.gameObject.SetActive(false);
     }
     
     if (SkillJiaDian.S.ZhiYeZJ5 < 1)
     {
      ZhiYeZJ6Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f,1f);
      ZhiYeZJ6Icon.GetComponent<Button>().interactable = false;
      ZhiYeZJLine5Liang.gameObject.SetActive(false);
      ZhiYeZJLine5An.gameObject.SetActive(true);
     }
     else
     {
      ZhiYeZJ6Icon.color = new Color(1, 1, 1);
      ZhiYeZJ6Icon.GetComponent<Button>().interactable = true;
      ZhiYeZJLine5Liang.gameObject.SetActive(true);
      ZhiYeZJLine5An.gameObject.SetActive(false);
     }

    }


    public void SetIcePanelLevel()
    {
     IceMainLevelCount.text = SkillJiaDian.S.IceAll.ToString();
     IceBei1LevelCount.text = SkillJiaDian.S.IceBei1.ToString();
     IceBei2LevelCount.text = SkillJiaDian.S.IceBei2.ToString();
     IceBei3LevelCount.text = SkillJiaDian.S.IceBei3.ToString();
     IceBei4LevelCount.text = SkillJiaDian.S.IceBei4.ToString();
     Ice1LevelCount.text = SkillJiaDian.S.Ice1.ToString();
     Ice1_1LevelCount.text = SkillJiaDian.S.Ice1_1.ToString();
     Ice1_2LevelCount.text = SkillJiaDian.S.Ice1_2.ToString();

     Ice2LevelCount.text = SkillJiaDian.S.Ice2.ToString();
     Ice2_1LevelCount.text = SkillJiaDian.S.Ice2_1.ToString();
     Ice2_2LevelCount.text = SkillJiaDian.S.Ice2_2.ToString();
     
     Ice3LevelCount.text = SkillJiaDian.S.Ice3.ToString();
     Ice3_1LevelCount.text = SkillJiaDian.S.Ice3_1.ToString();
     Ice3_2LevelCount.text = SkillJiaDian.S.Ice3_2.ToString();
     
     Ice4LevelCount.text = SkillJiaDian.S.Ice4.ToString();
     Ice4_1LevelCount.text = SkillJiaDian.S.Ice4_1.ToString();
     Ice4_2LevelCount.text = SkillJiaDian.S.Ice4_2.ToString();
     
     Ice5LevelCount.text = SkillJiaDian.S.Ice5.ToString();
     Ice5_1LevelCount.text = SkillJiaDian.S.Ice5_1.ToString();
     Ice5_2LevelCount.text = SkillJiaDian.S.Ice5_2.ToString();
    }
    
    public void SetHuoPanelLevel()
    {
     HuoMainLevelCount.text = SkillJiaDian.S.HuoAll.ToString();
     HuoBei1LevelCount.text = SkillJiaDian.S.HuoBei1.ToString();
     HuoBei2LevelCount.text = SkillJiaDian.S.HuoBei2.ToString();
     HuoBei3LevelCount.text = SkillJiaDian.S.HuoBei3.ToString();
     HuoBei4LevelCount.text = SkillJiaDian.S.HuoBei4.ToString();
     Huo1LevelCount.text = SkillJiaDian.S.Huo1.ToString();
     Huo1_1LevelCount.text = SkillJiaDian.S.Huo1_1.ToString();
     Huo1_2LevelCount.text = SkillJiaDian.S.Huo1_2.ToString();

     Huo2LevelCount.text = SkillJiaDian.S.Huo2.ToString();
     Huo2_1LevelCount.text = SkillJiaDian.S.Huo2_1.ToString();
     Huo2_2LevelCount.text = SkillJiaDian.S.Huo2_2.ToString();
     
     Huo3LevelCount.text = SkillJiaDian.S.Huo3.ToString();
     Huo3_1LevelCount.text = SkillJiaDian.S.Huo3_1.ToString();
     Huo3_2LevelCount.text = SkillJiaDian.S.Huo3_2.ToString();
     
     Huo4LevelCount.text = SkillJiaDian.S.Huo4.ToString();
     Huo4_1LevelCount.text = SkillJiaDian.S.Huo4_1.ToString();
     Huo4_2LevelCount.text = SkillJiaDian.S.Huo4_2.ToString();
     
     Huo5LevelCount.text = SkillJiaDian.S.Huo5.ToString();
     Huo5_1LevelCount.text = SkillJiaDian.S.Huo5_1.ToString();
     Huo5_2LevelCount.text = SkillJiaDian.S.Huo5_2.ToString();
    }
    
    public void SetDianPanelLevel()
    {
     DianMainLevelCount.text = SkillJiaDian.S.DianAll.ToString();
     DianBei1LevelCount.text = SkillJiaDian.S.DianBei1.ToString();
     DianBei2LevelCount.text = SkillJiaDian.S.DianBei2.ToString();
     DianBei3LevelCount.text = SkillJiaDian.S.DianBei3.ToString();
     DianBei4LevelCount.text = SkillJiaDian.S.DianBei4.ToString();
     Dian1LevelCount.text = SkillJiaDian.S.Dian1.ToString();
     Dian1_1LevelCount.text = SkillJiaDian.S.Dian1_1.ToString();
     Dian1_2LevelCount.text = SkillJiaDian.S.Dian1_2.ToString();

     Dian2LevelCount.text = SkillJiaDian.S.Dian2.ToString();
     Dian2_1LevelCount.text = SkillJiaDian.S.Dian2_1.ToString();
     Dian2_2LevelCount.text = SkillJiaDian.S.Dian2_2.ToString();
     
     Dian3LevelCount.text = SkillJiaDian.S.Dian3.ToString();
     Dian3_1LevelCount.text = SkillJiaDian.S.Dian3_1.ToString();
     Dian3_2LevelCount.text = SkillJiaDian.S.Dian3_2.ToString();
     
     Dian4LevelCount.text = SkillJiaDian.S.Dian4.ToString();
     Dian4_1LevelCount.text = SkillJiaDian.S.Dian4_1.ToString();
     Dian4_2LevelCount.text = SkillJiaDian.S.Dian4_2.ToString();
     
     Dian5LevelCount.text = SkillJiaDian.S.Dian5.ToString();
     Dian5_1LevelCount.text = SkillJiaDian.S.Dian5_1.ToString();
     Dian5_2LevelCount.text = SkillJiaDian.S.Dian5_2.ToString();
    }

    
    
    public void SetHeiAnPanelLevel()
    {
     HeiAnMainLevelCount.text = SkillJiaDian.S.HeiAnAll.ToString();
     HeiAnBei1LevelCount.text = SkillJiaDian.S.HeiAnBei1.ToString();
     HeiAnBei2LevelCount.text = SkillJiaDian.S.HeiAnBei2.ToString();
     HeiAnBei3LevelCount.text = SkillJiaDian.S.HeiAnBei3.ToString();
     HeiAnBei4LevelCount.text = SkillJiaDian.S.HeiAnBei4.ToString();
     HeiAn1LevelCount.text = SkillJiaDian.S.HeiAn1.ToString();
     HeiAn1_1LevelCount.text = SkillJiaDian.S.HeiAn1_1.ToString();
     HeiAn1_2LevelCount.text = SkillJiaDian.S.HeiAn1_2.ToString();

     HeiAn2LevelCount.text = SkillJiaDian.S.HeiAn2.ToString();
     HeiAn2_1LevelCount.text = SkillJiaDian.S.HeiAn2_1.ToString();
     HeiAn2_2LevelCount.text = SkillJiaDian.S.HeiAn2_2.ToString();
     
     HeiAn3LevelCount.text = SkillJiaDian.S.HeiAn3.ToString();
     HeiAn3_1LevelCount.text = SkillJiaDian.S.HeiAn3_1.ToString();
     HeiAn3_2LevelCount.text = SkillJiaDian.S.HeiAn3_2.ToString();
     
     HeiAn4LevelCount.text = SkillJiaDian.S.HeiAn4.ToString();
     HeiAn4_1LevelCount.text = SkillJiaDian.S.HeiAn4_1.ToString();
     HeiAn4_2LevelCount.text = SkillJiaDian.S.HeiAn4_2.ToString();
     
     HeiAn5LevelCount.text = SkillJiaDian.S.HeiAn5.ToString();
     HeiAn5_1LevelCount.text = SkillJiaDian.S.HeiAn5_1.ToString();
     HeiAn5_2LevelCount.text = SkillJiaDian.S.HeiAn5_2.ToString();
    }
    
    
    public void SetZJPanelLevel()
    {
     IceZJ1LevelCount.text = SkillJiaDian.S.IceZJ1.ToString();
     IceZJ2LevelCount.text = SkillJiaDian.S.IceZJ2.ToString();
     IceZJ3LevelCount.text = SkillJiaDian.S.IceZJ3.ToString();
     IceZJ4LevelCount.text = SkillJiaDian.S.IceZJ4.ToString();
     IceZJ5LevelCount.text = SkillJiaDian.S.IceZJ5.ToString();
     IceZJ6LevelCount.text = SkillJiaDian.S.IceZJ6.ToString();
     IceZJMainLevelCount.text = SkillJiaDian.S.ZJIceAll.ToString();

     HuoZJ1LevelCount.text = SkillJiaDian.S.HuoZJ1.ToString();
     HuoZJ2LevelCount.text = SkillJiaDian.S.HuoZJ2.ToString();
     HuoZJ3LevelCount.text = SkillJiaDian.S.HuoZJ3.ToString();
     HuoZJ4LevelCount.text = SkillJiaDian.S.HuoZJ4.ToString();
     HuoZJ5LevelCount.text = SkillJiaDian.S.HuoZJ5.ToString();
     HuoZJ6LevelCount.text = SkillJiaDian.S.HuoZJ6.ToString();
     HuoZJMainLevelCount.text = SkillJiaDian.S.ZJHuoAll.ToString();
     
     DianZJ1LevelCount.text = SkillJiaDian.S.DianZJ1.ToString();
     DianZJ2LevelCount.text = SkillJiaDian.S.DianZJ2.ToString();
     DianZJ3LevelCount.text = SkillJiaDian.S.DianZJ3.ToString();
     DianZJ4LevelCount.text = SkillJiaDian.S.DianZJ4.ToString();
     DianZJ5LevelCount.text = SkillJiaDian.S.DianZJ5.ToString();
     DianZJ6LevelCount.text = SkillJiaDian.S.DianZJ6.ToString();
     DianZJMainLevelCount.text = SkillJiaDian.S.ZJDianAll.ToString();
     
     HeiAnZJ1LevelCount.text = SkillJiaDian.S.HeiAnZJ1.ToString();
     HeiAnZJ2LevelCount.text = SkillJiaDian.S.HeiAnZJ2.ToString();
     HeiAnZJ3LevelCount.text = SkillJiaDian.S.HeiAnZJ3.ToString();
     HeiAnZJ4LevelCount.text = SkillJiaDian.S.HeiAnZJ4.ToString();
     HeiAnZJ5LevelCount.text = SkillJiaDian.S.HeiAnZJ5.ToString();
     HeiAnZJ6LevelCount.text = SkillJiaDian.S.HeiAnZJ6.ToString();
     HeiAnZJMainLevelCount.text = SkillJiaDian.S.ZJHeiAnAll.ToString();
     
     ZhiYeZJ1LevelCount.text = SkillJiaDian.S.ZhiYeZJ1.ToString();
     ZhiYeZJ2LevelCount.text = SkillJiaDian.S.ZhiYeZJ2.ToString();
     ZhiYeZJ3LevelCount.text = SkillJiaDian.S.ZhiYeZJ3.ToString();
     ZhiYeZJ4LevelCount.text = SkillJiaDian.S.ZhiYeZJ4.ToString();
     ZhiYeZJ5LevelCount.text = SkillJiaDian.S.ZhiYeZJ5.ToString();
     ZhiYeZJ6LevelCount.text = SkillJiaDian.S.ZhiYeZJ6.ToString();
     ZhiYeZJMainLevelCount.text = SkillJiaDian.S.ZJZhiYeAll.ToString();
    }



    public int GetKey(SkillType skillType)
    {
     if (SkillJiaDian.S.Alpha1 == skillType)
     {
      return 1;
     }
     if (SkillJiaDian.S.Alpha2 == skillType)
     {
      return 2;
     }
     if (SkillJiaDian.S.Alpha3 == skillType)
     {
      return 3;
     }
     if (SkillJiaDian.S.Alpha4 == skillType)
     {
      return 4;
     }
     if (SkillJiaDian.S.Alpha5 == skillType)
     {
      return 5;
     }

     return 0;
    }

    public void SetIcePanelAutoAndKey()
    {
     Ice1AutoCount.gameObject.SetActive(SkillJiaDian.S.Ice1Auto);
     Ice2AutoCount.gameObject.SetActive(SkillJiaDian.S.Ice2Auto);
     Ice3AutoCount.gameObject.SetActive(SkillJiaDian.S.Ice3Auto);
     Ice4AutoCount.gameObject.SetActive(SkillJiaDian.S.Ice4Auto);
     Ice5AutoCount.gameObject.SetActive(SkillJiaDian.S.Ice5Auto);
     
     Ice1KeyCount.gameObject.SetActive(GetKey(SkillType.Ice1)!=0);
     if (GetKey(SkillType.Ice1) != 0)
     {
      Ice1KeyCount.text = GetKey(SkillType.Ice1).ToString();
     }
     
     Ice2KeyCount.gameObject.SetActive(GetKey(SkillType.Ice2)!=0);
     if (GetKey(SkillType.Ice2) != 0)
     {
      Ice2KeyCount.text = GetKey(SkillType.Ice2).ToString();
     }
     
     Ice3KeyCount.gameObject.SetActive(GetKey(SkillType.Ice3)!=0);
     if (GetKey(SkillType.Ice3) != 0)
     {
      Ice3KeyCount.text = GetKey(SkillType.Ice3).ToString();
     }
     
     Ice4KeyCount.gameObject.SetActive(GetKey(SkillType.Ice4)!=0);
     if (GetKey(SkillType.Ice4) != 0)
     {
      Ice4KeyCount.text = GetKey(SkillType.Ice4).ToString();
     }
     
     Ice5KeyCount.gameObject.SetActive(GetKey(SkillType.Ice5)!=0);
     if (GetKey(SkillType.Ice5) != 0)
     {
      Ice5KeyCount.text = GetKey(SkillType.Ice5).ToString();
     }
     
    }
    
    
    public void SetHuoPanelAutoAndKey()
    {
     Huo1AutoCount.gameObject.SetActive(SkillJiaDian.S.Huo1Auto);
     Huo2AutoCount.gameObject.SetActive(SkillJiaDian.S.Huo2Auto);
     Huo3AutoCount.gameObject.SetActive(SkillJiaDian.S.Huo3Auto);
     Huo4AutoCount.gameObject.SetActive(SkillJiaDian.S.Huo4Auto);
     Huo5AutoCount.gameObject.SetActive(SkillJiaDian.S.Huo5Auto);
     
     Huo1KeyCount.gameObject.SetActive(GetKey(SkillType.Huo1)!=0);
     if (GetKey(SkillType.Huo1) != 0)
     {
      Huo1KeyCount.text = GetKey(SkillType.Huo1).ToString();
     }
     
     Huo2KeyCount.gameObject.SetActive(GetKey(SkillType.Huo2)!=0);
     if (GetKey(SkillType.Huo2) != 0)
     {
      Huo2KeyCount.text = GetKey(SkillType.Huo2).ToString();
     }
     
     Huo3KeyCount.gameObject.SetActive(GetKey(SkillType.Huo3)!=0);
     if (GetKey(SkillType.Huo3) != 0)
     {
      Huo3KeyCount.text = GetKey(SkillType.Huo3).ToString();
     }
     
     Huo4KeyCount.gameObject.SetActive(GetKey(SkillType.Huo4)!=0);
     if (GetKey(SkillType.Huo4) != 0)
     {
      Huo4KeyCount.text = GetKey(SkillType.Huo4).ToString();
     }
     
     Huo5KeyCount.gameObject.SetActive(GetKey(SkillType.Huo5)!=0);
     if (GetKey(SkillType.Huo5) != 0)
     {
      Huo5KeyCount.text = GetKey(SkillType.Huo5).ToString();
     }
     
    }
    
    
    public void SetDianPanelAutoAndKey()
    {
     Dian1AutoCount.gameObject.SetActive(SkillJiaDian.S.Dian1Auto);
     Dian2AutoCount.gameObject.SetActive(SkillJiaDian.S.Dian2Auto);
     Dian3AutoCount.gameObject.SetActive(SkillJiaDian.S.Dian3Auto);
     Dian4AutoCount.gameObject.SetActive(SkillJiaDian.S.Dian4Auto);
     Dian5AutoCount.gameObject.SetActive(SkillJiaDian.S.Dian5Auto);
     
     Dian1KeyCount.gameObject.SetActive(GetKey(SkillType.Dian1)!=0);
     if (GetKey(SkillType.Dian1) != 0)
     {
      Dian1KeyCount.text = GetKey(SkillType.Dian1).ToString();
     }
     
     Dian2KeyCount.gameObject.SetActive(GetKey(SkillType.Dian2)!=0);
     if (GetKey(SkillType.Dian2) != 0)
     {
      Dian2KeyCount.text = GetKey(SkillType.Dian2).ToString();
     }
     
     Dian3KeyCount.gameObject.SetActive(GetKey(SkillType.Dian3)!=0);
     if (GetKey(SkillType.Dian3) != 0)
     {
      Dian3KeyCount.text = GetKey(SkillType.Dian3).ToString();
     }
     
     Dian4KeyCount.gameObject.SetActive(GetKey(SkillType.Dian4)!=0);
     if (GetKey(SkillType.Dian4) != 0)
     {
      Dian4KeyCount.text = GetKey(SkillType.Dian4).ToString();
     }
     
     Dian5KeyCount.gameObject.SetActive(GetKey(SkillType.Dian5)!=0);
     if (GetKey(SkillType.Dian5) != 0)
     {
      Dian5KeyCount.text = GetKey(SkillType.Dian5).ToString();
     }
     
    }
    
    
    
    public void SetHeiAnPanelAutoAndKey()
    {
     HeiAn1AutoCount.gameObject.SetActive(SkillJiaDian.S.HeiAn1Auto);
     HeiAn2AutoCount.gameObject.SetActive(SkillJiaDian.S.HeiAn2Auto);
     HeiAn3AutoCount.gameObject.SetActive(SkillJiaDian.S.HeiAn3Auto);
     HeiAn4AutoCount.gameObject.SetActive(SkillJiaDian.S.HeiAn4Auto);
     HeiAn5AutoCount.gameObject.SetActive(SkillJiaDian.S.HeiAn5Auto);
     
     HeiAn1KeyCount.gameObject.SetActive(GetKey(SkillType.HeiAn1)!=0);
     if (GetKey(SkillType.HeiAn1) != 0)
     {
      HeiAn1KeyCount.text = GetKey(SkillType.HeiAn1).ToString();
     }
     
     HeiAn2KeyCount.gameObject.SetActive(GetKey(SkillType.HeiAn2)!=0);
     if (GetKey(SkillType.HeiAn2) != 0)
     {
      HeiAn2KeyCount.text = GetKey(SkillType.HeiAn2).ToString();
     }
     
     HeiAn3KeyCount.gameObject.SetActive(GetKey(SkillType.HeiAn3)!=0);
     if (GetKey(SkillType.HeiAn3) != 0)
     {
      HeiAn3KeyCount.text = GetKey(SkillType.HeiAn3).ToString();
     }
     
     HeiAn4KeyCount.gameObject.SetActive(GetKey(SkillType.HeiAn4)!=0);
     if (GetKey(SkillType.HeiAn4) != 0)
     {
      HeiAn4KeyCount.text = GetKey(SkillType.HeiAn4).ToString();
     }
     
     HeiAn5KeyCount.gameObject.SetActive(GetKey(SkillType.HeiAn5)!=0);
     if (GetKey(SkillType.HeiAn5) != 0)
     {
      HeiAn5KeyCount.text = GetKey(SkillType.HeiAn5).ToString();
     }
     
    }

    public void ShowIcePanel()
    {
      IcePanel.SetActive(true);
      HuoPanel.SetActive(false);
      DianPanel.SetActive(false);
      HeiAnPanel.SetActive(false);
      ZJPanel.SetActive(false);
      SetIcePanelImageColorAndJiaoHuAndLine();
      SetIcePanelLevel();
      SetIcePanelAutoAndKey();
    }
    
    public void ShowHuoPanel()
    {
     IcePanel.SetActive(false);
     HuoPanel.SetActive(true);
     DianPanel.SetActive(false);
     HeiAnPanel.SetActive(false);
     ZJPanel.SetActive(false);
     SetHuoPanelImageColorAndJiaoHuAndLine();
     SetHuoPanelLevel();
     SetHuoPanelAutoAndKey();
    }
    
    public void ShowDianPanel()
    {
     IcePanel.SetActive(false);
     HuoPanel.SetActive(false);
     DianPanel.SetActive(true);
     HeiAnPanel.SetActive(false);
     ZJPanel.SetActive(false);
     SetDianPanelImageColorAndJiaoHuAndLine();
     SetDianPanelLevel();
     SetDianPanelAutoAndKey();
    }
    
    
    public void ShowHeiAnPanel()
    {
     IcePanel.SetActive(false);
     HuoPanel.SetActive(false);
     DianPanel.SetActive(false);
     HeiAnPanel.SetActive(true);
     ZJPanel.SetActive(false);
     SetHeiAnPanelImageColorAndJiaoHuAndLine();
     SetHeiAnPanelLevel();
     SetHeiAnPanelAutoAndKey();
    }
    
    
    public void ShowZJPanel()
    {
     IcePanel.SetActive(false);
     HuoPanel.SetActive(false);
     DianPanel.SetActive(false);
     HeiAnPanel.SetActive(false);
     ZJPanel.SetActive(true);
     SetZJPanelImageColorAndJiaoHuAndLine();
     SetZJPanelLevel();
    }

    private void OnEnable()
    {
      ShowIcePanel();
    }

    private void Start()
    {
      IceButton.onClick.AddListener(() =>
      {
       ShowIcePanel();
      });
      
      HuoButton.onClick.AddListener(() =>
      {
       ShowHuoPanel();
      });
      
      DianButton.onClick.AddListener(() =>
      {
       ShowDianPanel();
      });
      
      HeiAnButton.onClick.AddListener(() =>
      {
       ShowHeiAnPanel();
      });
      
      ZJButton.onClick.AddListener(() =>
      {
       ShowZJPanel();
      });
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
    
    
    
    
    
    
    
    public Image ZhiYeZJMainBg;
    public Image ZhiYeZJMainIcon;
    public TextMeshProUGUI ZhiYeZJMainLevelCount;
    public Image ZhiYeZJMainLevelBg;
    public Image ZhiYeZJMainXuanZhong;

    
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
