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
 [Header("基础UI组件")] public Button exitButton; // 退出按钮
 private Button maskButton;
 private GameObject skillSwitchObj;

 [Header("技能计数显示")] 
 public TextMeshProUGUI skillCount;
 private TextMeshProUGUI monsterCount;

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
 
 private void Awake()
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
 }

 private void SetIcePanelImageColorAndJiaoHuAndLine()
 {
  if (SkillJiaDian.S.IceBei1 < 1)
  {
   IceBei2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f, 1f);
   IceBeiLine1Liang.gameObject.SetActive(false);
   IceBeiLine1An.gameObject.SetActive(true);
   IceBei2Icon.GetComponent<Button>().interactable = false;
   IceBei2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;

  }
  else
  {
   IceBei2Icon.color = new Color(1, 1, 1);
   IceBeiLine1Liang.gameObject.SetActive(true);
   IceBeiLine1An.gameObject.SetActive(false);
   IceBei2Icon.GetComponent<Button>().interactable = true;
   IceBei2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;

  }

  if (SkillJiaDian.S.IceBei3 < 1)
  {
   IceBei4Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f, 1f);
   IceBeiLine2Liang.gameObject.SetActive(false);
   IceBeiLine2An.gameObject.SetActive(true);
   IceBei4Icon.GetComponent<Button>().interactable = false;
   IceBei4Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   IceBei4Icon.color = new Color(1, 1, 1);
   IceBeiLine2Liang.gameObject.SetActive(true);
   IceBeiLine2An.gameObject.SetActive(false);
   IceBei4Icon.GetComponent<Button>().interactable = true;
   IceBei4Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.Ice1 < 1)
  {
   Ice1_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Ice1Line1Liang.gameObject.SetActive(false);
   Ice1Line1An.gameObject.SetActive(true);
   Ice1_1Icon.GetComponent<Button>().interactable = false;
   Ice1_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Ice1_1Icon.color = new Color(1, 1, 1);
   Ice1Line1Liang.gameObject.SetActive(true);
   Ice1Line1An.gameObject.SetActive(false);
   Ice1_1Icon.GetComponent<Button>().interactable = true;
   Ice1_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;

  }


  if (SkillJiaDian.S.Ice1_1 < 1)
  {
   Ice1_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Ice1Line2Liang.gameObject.SetActive(false);
   Ice1Line2An.gameObject.SetActive(true);
   Ice1_2Icon.GetComponent<Button>().interactable = false;
   Ice1_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;

  }
  else
  {
   Ice1_2Icon.color = new Color(1, 1, 1);
   Ice1Line2Liang.gameObject.SetActive(true);
   Ice1Line2An.gameObject.SetActive(false);
   Ice1_2Icon.GetComponent<Button>().interactable = true;
   Ice1_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;

  }



  if (SkillJiaDian.S.Ice2 < 1)
  {
   Ice2_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Ice2Line1Liang.gameObject.SetActive(false);
   Ice2Line1An.gameObject.SetActive(true);
   Ice2_1Icon.GetComponent<Button>().interactable = false;
   Ice2_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;

  }
  else
  {
   Ice2_1Icon.color = new Color(1, 1, 1);
   Ice2Line1Liang.gameObject.SetActive(true);
   Ice2Line1An.gameObject.SetActive(false);
   Ice2_1Icon.GetComponent<Button>().interactable = true;
   Ice2_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;

  }


  if (SkillJiaDian.S.Ice2_1 < 1)
  {
   Ice2_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Ice2Line2Liang.gameObject.SetActive(false);
   Ice2Line2An.gameObject.SetActive(true);
   Ice2_2Icon.GetComponent<Button>().interactable = false;
   Ice2_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;

  }
  else
  {
   Ice2_2Icon.color = new Color(1, 1, 1);
   Ice2Line2Liang.gameObject.SetActive(true);
   Ice2Line2An.gameObject.SetActive(false);
   Ice2_2Icon.GetComponent<Button>().interactable = true;
   Ice2_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;

  }



  if (SkillJiaDian.S.Ice3 < 1)
  {
   Ice3_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Ice3Line1Liang.gameObject.SetActive(false);
   Ice3Line1An.gameObject.SetActive(true);
   Ice3_1Icon.GetComponent<Button>().interactable = false;
   Ice3_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;

  }
  else
  {
   Ice3_1Icon.color = new Color(1, 1, 1);
   Ice3Line1Liang.gameObject.SetActive(true);
   Ice3Line1An.gameObject.SetActive(false);
   Ice3_1Icon.GetComponent<Button>().interactable = true;
   Ice3_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;

  }


  if (SkillJiaDian.S.Ice3_1 < 1)
  {
   Ice3_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Ice3Line2Liang.gameObject.SetActive(false);
   Ice3Line2An.gameObject.SetActive(true);
   Ice3_2Icon.GetComponent<Button>().interactable = false;
   Ice3_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;

  }
  else
  {
   Ice3_2Icon.color = new Color(1, 1, 1);
   Ice3Line2Liang.gameObject.SetActive(true);
   Ice3Line2An.gameObject.SetActive(false);
   Ice3_2Icon.GetComponent<Button>().interactable = true;
   Ice3_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;

  }



  if (SkillJiaDian.S.Ice4 < 1)
  {
   Ice4_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Ice4Line1Liang.gameObject.SetActive(false);
   Ice4Line1An.gameObject.SetActive(true);
   Ice4_1Icon.GetComponent<Button>().interactable = false;
   Ice4_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;

  }
  else
  {
   Ice4_1Icon.color = new Color(1, 1, 1);
   Ice4Line1Liang.gameObject.SetActive(true);
   Ice4Line1An.gameObject.SetActive(false);
   Ice4_1Icon.GetComponent<Button>().interactable = true;
   Ice4_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;

  }


  if (SkillJiaDian.S.Ice4_1 < 1)
  {
   Ice4_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Ice4Line2Liang.gameObject.SetActive(false);
   Ice4Line2An.gameObject.SetActive(true);
   Ice4_2Icon.GetComponent<Button>().interactable = false;
   Ice4_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;

  }
  else
  {
   Ice4_2Icon.color = new Color(1, 1, 1);
   Ice4Line2Liang.gameObject.SetActive(true);
   Ice4Line2An.gameObject.SetActive(false);
   Ice4_2Icon.GetComponent<Button>().interactable = true;
   Ice4_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;

  }



  if (SkillJiaDian.S.Ice5 < 1)
  {
   Ice5_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Ice5Line1Liang.gameObject.SetActive(false);
   Ice5Line1An.gameObject.SetActive(true);
   Ice5_1Icon.GetComponent<Button>().interactable = false;
   Ice5_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;

  }
  else
  {
   Ice5_1Icon.color = new Color(1, 1, 1);
   Ice5Line1Liang.gameObject.SetActive(true);
   Ice5Line1An.gameObject.SetActive(false);
   Ice5_1Icon.GetComponent<Button>().interactable = true;
   Ice5_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;

  }


  if (SkillJiaDian.S.Ice5_1 < 1)
  {
   Ice5_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Ice5Line2Liang.gameObject.SetActive(false);
   Ice5Line2An.gameObject.SetActive(true);
   Ice5_2Icon.GetComponent<Button>().interactable = false;
   Ice5_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;

  }
  else
  {
   Ice5_2Icon.color = new Color(1, 1, 1);
   Ice5Line2Liang.gameObject.SetActive(true);
   Ice5Line2An.gameObject.SetActive(false);
   Ice5_2Icon.GetComponent<Button>().interactable = true;
   Ice5_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;

  }

 }


 private void SetHuoPanelImageColorAndJiaoHuAndLine()
 {
  if (SkillJiaDian.S.HuoBei1 < 1)
  {
   HuoBei2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f, 1f);
   HuoBeiLine1Liang.gameObject.SetActive(false);
   HuoBeiLine1An.gameObject.SetActive(true);
   HuoBei2Icon.GetComponent<Button>().interactable = false;
   HuoBei2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HuoBei2Icon.color = new Color(1, 1, 1);
   HuoBeiLine1Liang.gameObject.SetActive(true);
   HuoBeiLine1An.gameObject.SetActive(false);
   HuoBei2Icon.GetComponent<Button>().interactable = true;
   HuoBei2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }

  if (SkillJiaDian.S.HuoBei3 < 1)
  {
   HuoBei4Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f, 1f);
   HuoBeiLine2Liang.gameObject.SetActive(false);
   HuoBeiLine2An.gameObject.SetActive(true);
   HuoBei4Icon.GetComponent<Button>().interactable = false;
   HuoBei4Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HuoBei4Icon.color = new Color(1, 1, 1);
   HuoBeiLine2Liang.gameObject.SetActive(true);
   HuoBeiLine2An.gameObject.SetActive(false);
   HuoBei4Icon.GetComponent<Button>().interactable = true;
   HuoBei4Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.Huo1 < 1)
  {
   Huo1_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Huo1Line1Liang.gameObject.SetActive(false);
   Huo1Line1An.gameObject.SetActive(true);
   Huo1_1Icon.GetComponent<Button>().interactable = false;
   Huo1_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Huo1_1Icon.color = new Color(1, 1, 1);
   Huo1Line1Liang.gameObject.SetActive(true);
   Huo1Line1An.gameObject.SetActive(false);
   Huo1_1Icon.GetComponent<Button>().interactable = true;
   Huo1_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.Huo1_1 < 1)
  {
   Huo1_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Huo1Line2Liang.gameObject.SetActive(false);
   Huo1Line2An.gameObject.SetActive(true);
   Huo1_2Icon.GetComponent<Button>().interactable = false;
   Huo1_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Huo1_2Icon.color = new Color(1, 1, 1);
   Huo1Line2Liang.gameObject.SetActive(true);
   Huo1Line2An.gameObject.SetActive(false);
   Huo1_2Icon.GetComponent<Button>().interactable = true;
   Huo1_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }



  if (SkillJiaDian.S.Huo2 < 1)
  {
   Huo2_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Huo2Line1Liang.gameObject.SetActive(false);
   Huo2Line1An.gameObject.SetActive(true);
   Huo2_1Icon.GetComponent<Button>().interactable = false;
   Huo2_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Huo2_1Icon.color = new Color(1, 1, 1);
   Huo2Line1Liang.gameObject.SetActive(true);
   Huo2Line1An.gameObject.SetActive(false);
   Huo2_1Icon.GetComponent<Button>().interactable = true;
   Huo2_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.Huo2_1 < 1)
  {
   Huo2_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Huo2Line2Liang.gameObject.SetActive(false);
   Huo2Line2An.gameObject.SetActive(true);
   Huo2_2Icon.GetComponent<Button>().interactable = false;
   Huo2_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Huo2_2Icon.color = new Color(1, 1, 1);
   Huo2Line2Liang.gameObject.SetActive(true);
   Huo2Line2An.gameObject.SetActive(false);
   Huo2_2Icon.GetComponent<Button>().interactable = true;
   Huo2_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }



  if (SkillJiaDian.S.Huo3 < 1)
  {
   Huo3_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Huo3Line1Liang.gameObject.SetActive(false);
   Huo3Line1An.gameObject.SetActive(true);
   Huo3_1Icon.GetComponent<Button>().interactable = false;
   Huo3_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Huo3_1Icon.color = new Color(1, 1, 1);
   Huo3Line1Liang.gameObject.SetActive(true);
   Huo3Line1An.gameObject.SetActive(false);
   Huo3_1Icon.GetComponent<Button>().interactable = true;
   Huo3_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.Huo3_1 < 1)
  {
   Huo3_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Huo3Line2Liang.gameObject.SetActive(false);
   Huo3Line2An.gameObject.SetActive(true);
   Huo3_2Icon.GetComponent<Button>().interactable = false;
   Huo3_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Huo3_2Icon.color = new Color(1, 1, 1);
   Huo3Line2Liang.gameObject.SetActive(true);
   Huo3Line2An.gameObject.SetActive(false);
   Huo3_2Icon.GetComponent<Button>().interactable = true;
   Huo3_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }



  if (SkillJiaDian.S.Huo4 < 1)
  {
   Huo4_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Huo4Line1Liang.gameObject.SetActive(false);
   Huo4Line1An.gameObject.SetActive(true);
   Huo4_1Icon.GetComponent<Button>().interactable = false;
   Huo4_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Huo4_1Icon.color = new Color(1, 1, 1);
   Huo4Line1Liang.gameObject.SetActive(true);
   Huo4Line1An.gameObject.SetActive(false);
   Huo4_1Icon.GetComponent<Button>().interactable = true;
   Huo4_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.Huo4_1 < 1)
  {
   Huo4_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Huo4Line2Liang.gameObject.SetActive(false);
   Huo4Line2An.gameObject.SetActive(true);
   Huo4_2Icon.GetComponent<Button>().interactable = false;
   Huo4_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Huo4_2Icon.color = new Color(1, 1, 1);
   Huo4Line2Liang.gameObject.SetActive(true);
   Huo4Line2An.gameObject.SetActive(false);
   Huo4_2Icon.GetComponent<Button>().interactable = true;
   Huo4_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }



  if (SkillJiaDian.S.Huo5 < 1)
  {
   Huo5_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Huo5Line1Liang.gameObject.SetActive(false);
   Huo5Line1An.gameObject.SetActive(true);
   Huo5_1Icon.GetComponent<Button>().interactable = false;
   Huo5_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Huo5_1Icon.color = new Color(1, 1, 1);
   Huo5Line1Liang.gameObject.SetActive(true);
   Huo5Line1An.gameObject.SetActive(false);
   Huo5_1Icon.GetComponent<Button>().interactable = true;
   Huo5_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.Huo5_1 < 1)
  {
   Huo5_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Huo5Line2Liang.gameObject.SetActive(false);
   Huo5Line2An.gameObject.SetActive(true);
   Huo5_2Icon.GetComponent<Button>().interactable = false;
   Huo5_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Huo5_2Icon.color = new Color(1, 1, 1);
   Huo5Line2Liang.gameObject.SetActive(true);
   Huo5Line2An.gameObject.SetActive(false);
   Huo5_2Icon.GetComponent<Button>().interactable = true;
   Huo5_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }

 }


 private void SetDianPanelImageColorAndJiaoHuAndLine()
 {
  if (SkillJiaDian.S.DianBei1 < 1)
  {
   DianBei2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f, 1f);
   DianBeiLine1Liang.gameObject.SetActive(false);
   DianBeiLine1An.gameObject.SetActive(true);
   DianBei2Icon.GetComponent<Button>().interactable = false;
   DianBei2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   DianBei2Icon.color = new Color(1, 1, 1);
   DianBeiLine1Liang.gameObject.SetActive(true);
   DianBeiLine1An.gameObject.SetActive(false);
   DianBei2Icon.GetComponent<Button>().interactable = true;
   DianBei2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }

  if (SkillJiaDian.S.DianBei3 < 1)
  {
   DianBei4Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f, 1f);
   DianBeiLine2Liang.gameObject.SetActive(false);
   DianBeiLine2An.gameObject.SetActive(true);
   DianBei4Icon.GetComponent<Button>().interactable = false;
   DianBei4Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   DianBei4Icon.color = new Color(1, 1, 1);
   DianBeiLine2Liang.gameObject.SetActive(true);
   DianBeiLine2An.gameObject.SetActive(false);
   DianBei4Icon.GetComponent<Button>().interactable = true;
   DianBei4Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.Dian1 < 1)
  {
   Dian1_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Dian1Line1Liang.gameObject.SetActive(false);
   Dian1Line1An.gameObject.SetActive(true);
   Dian1_1Icon.GetComponent<Button>().interactable = false;
   Dian1_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Dian1_1Icon.color = new Color(1, 1, 1);
   Dian1Line1Liang.gameObject.SetActive(true);
   Dian1Line1An.gameObject.SetActive(false);
   Dian1_1Icon.GetComponent<Button>().interactable = true;
   Dian1_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.Dian1_1 < 1)
  {
   Dian1_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Dian1Line2Liang.gameObject.SetActive(false);
   Dian1Line2An.gameObject.SetActive(true);
   Dian1_2Icon.GetComponent<Button>().interactable = false;
   Dian1_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Dian1_2Icon.color = new Color(1, 1, 1);
   Dian1Line2Liang.gameObject.SetActive(true);
   Dian1Line2An.gameObject.SetActive(false);
   Dian1_2Icon.GetComponent<Button>().interactable = true;
   Dian1_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }



  if (SkillJiaDian.S.Dian2 < 1)
  {
   Dian2_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Dian2Line1Liang.gameObject.SetActive(false);
   Dian2Line1An.gameObject.SetActive(true);
   Dian2_1Icon.GetComponent<Button>().interactable = false;
   Dian2_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Dian2_1Icon.color = new Color(1, 1, 1);
   Dian2Line1Liang.gameObject.SetActive(true);
   Dian2Line1An.gameObject.SetActive(false);
   Dian2_1Icon.GetComponent<Button>().interactable = true;
   Dian2_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.Dian2_1 < 1)
  {
   Dian2_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Dian2Line2Liang.gameObject.SetActive(false);
   Dian2Line2An.gameObject.SetActive(true);
   Dian2_2Icon.GetComponent<Button>().interactable = false;
   Dian2_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Dian2_2Icon.color = new Color(1, 1, 1);
   Dian2Line2Liang.gameObject.SetActive(true);
   Dian2Line2An.gameObject.SetActive(false);
   Dian2_2Icon.GetComponent<Button>().interactable = true;
   Dian2_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }



  if (SkillJiaDian.S.Dian3 < 1)
  {
   Dian3_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Dian3Line1Liang.gameObject.SetActive(false);
   Dian3Line1An.gameObject.SetActive(true);
   Dian3_1Icon.GetComponent<Button>().interactable = false;
   Dian3_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Dian3_1Icon.color = new Color(1, 1, 1);
   Dian3Line1Liang.gameObject.SetActive(true);
   Dian3Line1An.gameObject.SetActive(false);
   Dian3_1Icon.GetComponent<Button>().interactable = true;
   Dian3_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.Dian3_1 < 1)
  {
   Dian3_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Dian3Line2Liang.gameObject.SetActive(false);
   Dian3Line2An.gameObject.SetActive(true);
   Dian3_2Icon.GetComponent<Button>().interactable = false;
   Dian3_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Dian3_2Icon.color = new Color(1, 1, 1);
   Dian3Line2Liang.gameObject.SetActive(true);
   Dian3Line2An.gameObject.SetActive(false);
   Dian3_2Icon.GetComponent<Button>().interactable = true;
   Dian3_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }



  if (SkillJiaDian.S.Dian4 < 1)
  {
   Dian4_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Dian4Line1Liang.gameObject.SetActive(false);
   Dian4Line1An.gameObject.SetActive(true);
   Dian4_1Icon.GetComponent<Button>().interactable = false;
   Dian4_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Dian4_1Icon.color = new Color(1, 1, 1);
   Dian4Line1Liang.gameObject.SetActive(true);
   Dian4Line1An.gameObject.SetActive(false);
   Dian4_1Icon.GetComponent<Button>().interactable = true;
   Dian4_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.Dian4_1 < 1)
  {
   Dian4_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Dian4Line2Liang.gameObject.SetActive(false);
   Dian4Line2An.gameObject.SetActive(true);
   Dian4_2Icon.GetComponent<Button>().interactable = false;
   Dian4_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Dian4_2Icon.color = new Color(1, 1, 1);
   Dian4Line2Liang.gameObject.SetActive(true);
   Dian4Line2An.gameObject.SetActive(false);
   Dian4_2Icon.GetComponent<Button>().interactable = true;
   Dian4_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }



  if (SkillJiaDian.S.Dian5 < 1)
  {
   Dian5_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Dian5Line1Liang.gameObject.SetActive(false);
   Dian5Line1An.gameObject.SetActive(true);
   Dian5_1Icon.GetComponent<Button>().interactable = false;
   Dian5_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Dian5_1Icon.color = new Color(1, 1, 1);
   Dian5Line1Liang.gameObject.SetActive(true);
   Dian5Line1An.gameObject.SetActive(false);
   Dian5_1Icon.GetComponent<Button>().interactable = true;
   Dian5_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.Dian5_1 < 1)
  {
   Dian5_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   Dian5Line2Liang.gameObject.SetActive(false);
   Dian5Line2An.gameObject.SetActive(true);
   Dian5_2Icon.GetComponent<Button>().interactable = false;
   Dian5_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   Dian5_2Icon.color = new Color(1, 1, 1);
   Dian5Line2Liang.gameObject.SetActive(true);
   Dian5Line2An.gameObject.SetActive(false);
   Dian5_2Icon.GetComponent<Button>().interactable = true;
   Dian5_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }

 }

 private void SetHeiAnPanelImageColorAndJiaoHuAndLine()
 {
  if (SkillJiaDian.S.HeiAnBei1 < 1)
  {
   HeiAnBei2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f, 1f);
   HeiAnBeiLine1Liang.gameObject.SetActive(false);
   HeiAnBeiLine1An.gameObject.SetActive(true);
   HeiAnBei2Icon.GetComponent<Button>().interactable = false;
   HeiAnBei2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HeiAnBei2Icon.color = new Color(1, 1, 1);
   HeiAnBeiLine1Liang.gameObject.SetActive(true);
   HeiAnBeiLine1An.gameObject.SetActive(false);
   HeiAnBei2Icon.GetComponent<Button>().interactable = true;
   HeiAnBei2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }

  if (SkillJiaDian.S.HeiAnBei3 < 1)
  {
   HeiAnBei4Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f, 1f);
   HeiAnBeiLine2Liang.gameObject.SetActive(false);
   HeiAnBeiLine2An.gameObject.SetActive(true);
   HeiAnBei4Icon.GetComponent<Button>().interactable = false;
   HeiAnBei4Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HeiAnBei4Icon.color = new Color(1, 1, 1);
   HeiAnBeiLine2Liang.gameObject.SetActive(true);
   HeiAnBeiLine2An.gameObject.SetActive(false);
   HeiAnBei4Icon.GetComponent<Button>().interactable = true;
   HeiAnBei4Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.HeiAn1 < 1)
  {
   HeiAn1_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   HeiAn1Line1Liang.gameObject.SetActive(false);
   HeiAn1Line1An.gameObject.SetActive(true);
   HeiAn1_1Icon.GetComponent<Button>().interactable = false;
   HeiAn1_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HeiAn1_1Icon.color = new Color(1, 1, 1);
   HeiAn1Line1Liang.gameObject.SetActive(true);
   HeiAn1Line1An.gameObject.SetActive(false);
   HeiAn1_1Icon.GetComponent<Button>().interactable = true;
   HeiAn1_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.HeiAn1_1 < 1)
  {
   HeiAn1_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   HeiAn1Line2Liang.gameObject.SetActive(false);
   HeiAn1Line2An.gameObject.SetActive(true);
   HeiAn1_2Icon.GetComponent<Button>().interactable = false;
   HeiAn1_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HeiAn1_2Icon.color = new Color(1, 1, 1);
   HeiAn1Line2Liang.gameObject.SetActive(true);
   HeiAn1Line2An.gameObject.SetActive(false);
   HeiAn1_2Icon.GetComponent<Button>().interactable = true;
   HeiAn1_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }



  if (SkillJiaDian.S.HeiAn2 < 1)
  {
   HeiAn2_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   HeiAn2Line1Liang.gameObject.SetActive(false);
   HeiAn2Line1An.gameObject.SetActive(true);
   HeiAn2_1Icon.GetComponent<Button>().interactable = false;
   HeiAn2_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HeiAn2_1Icon.color = new Color(1, 1, 1);
   HeiAn2Line1Liang.gameObject.SetActive(true);
   HeiAn2Line1An.gameObject.SetActive(false);
   HeiAn2_1Icon.GetComponent<Button>().interactable = true;
   HeiAn2_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.HeiAn2_1 < 1)
  {
   HeiAn2_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   HeiAn2Line2Liang.gameObject.SetActive(false);
   HeiAn2Line2An.gameObject.SetActive(true);
   HeiAn2_2Icon.GetComponent<Button>().interactable = false;
   HeiAn2_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HeiAn2_2Icon.color = new Color(1, 1, 1);
   HeiAn2Line2Liang.gameObject.SetActive(true);
   HeiAn2Line2An.gameObject.SetActive(false);
   HeiAn2_2Icon.GetComponent<Button>().interactable = true;
   HeiAn2_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }



  if (SkillJiaDian.S.HeiAn3 < 1)
  {
   HeiAn3_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   HeiAn3Line1Liang.gameObject.SetActive(false);
   HeiAn3Line1An.gameObject.SetActive(true);
   HeiAn3_1Icon.GetComponent<Button>().interactable = false;
   HeiAn3_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HeiAn3_1Icon.color = new Color(1, 1, 1);
   HeiAn3Line1Liang.gameObject.SetActive(true);
   HeiAn3Line1An.gameObject.SetActive(false);
   HeiAn3_1Icon.GetComponent<Button>().interactable = true;
   HeiAn3_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.HeiAn3_1 < 1)
  {
   HeiAn3_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   HeiAn3Line2Liang.gameObject.SetActive(false);
   HeiAn3Line2An.gameObject.SetActive(true);
   HeiAn3_2Icon.GetComponent<Button>().interactable = false;
   HeiAn3_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HeiAn3_2Icon.color = new Color(1, 1, 1);
   HeiAn3Line2Liang.gameObject.SetActive(true);
   HeiAn3Line2An.gameObject.SetActive(false);
   HeiAn3_2Icon.GetComponent<Button>().interactable = true;
   HeiAn3_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }



  if (SkillJiaDian.S.HeiAn4 < 1)
  {
   HeiAn4_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   HeiAn4Line1Liang.gameObject.SetActive(false);
   HeiAn4Line1An.gameObject.SetActive(true);
   HeiAn4_1Icon.GetComponent<Button>().interactable = false;
   HeiAn4_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HeiAn4_1Icon.color = new Color(1, 1, 1);
   HeiAn4Line1Liang.gameObject.SetActive(true);
   HeiAn4Line1An.gameObject.SetActive(false);
   HeiAn4_1Icon.GetComponent<Button>().interactable = true;
   HeiAn4_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.HeiAn4_1 < 1)
  {
   HeiAn4_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   HeiAn4Line2Liang.gameObject.SetActive(false);
   HeiAn4Line2An.gameObject.SetActive(true);
   HeiAn4_2Icon.GetComponent<Button>().interactable = false;
   HeiAn4_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HeiAn4_2Icon.color = new Color(1, 1, 1);
   HeiAn4Line2Liang.gameObject.SetActive(true);
   HeiAn4Line2An.gameObject.SetActive(false);
   HeiAn4_2Icon.GetComponent<Button>().interactable = true;
   HeiAn4_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }



  if (SkillJiaDian.S.HeiAn5 < 1)
  {
   HeiAn5_1Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   HeiAn5Line1Liang.gameObject.SetActive(false);
   HeiAn5Line1An.gameObject.SetActive(true);
   HeiAn5_1Icon.GetComponent<Button>().interactable = false;
   HeiAn5_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HeiAn5_1Icon.color = new Color(1, 1, 1);
   HeiAn5Line1Liang.gameObject.SetActive(true);
   HeiAn5Line1An.gameObject.SetActive(false);
   HeiAn5_1Icon.GetComponent<Button>().interactable = true;
   HeiAn5_1Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }


  if (SkillJiaDian.S.HeiAn5_1 < 1)
  {
   HeiAn5_2Icon.color = new Color(93 / 255f, 79 / 255f, 79 / 255f);
   HeiAn5Line2Liang.gameObject.SetActive(false);
   HeiAn5Line2An.gameObject.SetActive(true);
   HeiAn5_2Icon.GetComponent<Button>().interactable = false;
   HeiAn5_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = false;
  }
  else
  {
   HeiAn5_2Icon.color = new Color(1, 1, 1);
   HeiAn5Line2Liang.gameObject.SetActive(true);
   HeiAn5Line2An.gameObject.SetActive(false);
   HeiAn5_2Icon.GetComponent<Button>().interactable = true;
   HeiAn5_2Icon.transform.parent.GetComponent<UISmoothScaleEffect1>().Active = true;
  }

 }
 


 private void SetIcePanelLevel()
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

 private void SetHuoPanelLevel()
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

 private void SetDianPanelLevel()
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



 private void SetHeiAnPanelLevel()
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


 



 private int GetKey(SkillType skillType)
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

 private void SetIcePanelAutoAndKey()
 {
  Ice1AutoCount.gameObject.SetActive(SkillJiaDian.S.Ice1Auto);
  Ice2AutoCount.gameObject.SetActive(SkillJiaDian.S.Ice2Auto);
  Ice3AutoCount.gameObject.SetActive(SkillJiaDian.S.Ice3Auto);
  Ice4AutoCount.gameObject.SetActive(SkillJiaDian.S.Ice4Auto);
  Ice5AutoCount.gameObject.SetActive(SkillJiaDian.S.Ice5Auto);
  Ice1AutoBg.gameObject.SetActive(SkillJiaDian.S.Ice1Auto);
  Ice2AutoBg.gameObject.SetActive(SkillJiaDian.S.Ice2Auto);
  Ice3AutoBg.gameObject.SetActive(SkillJiaDian.S.Ice3Auto);
  Ice4AutoBg.gameObject.SetActive(SkillJiaDian.S.Ice4Auto);
  Ice5AutoBg.gameObject.SetActive(SkillJiaDian.S.Ice5Auto);

  Ice1KeyCount.gameObject.SetActive(GetKey(SkillType.Ice1) != 0);
  if (GetKey(SkillType.Ice1) != 0)
  {
   Ice1KeyCount.text = GetKey(SkillType.Ice1).ToString();
  }

  Ice2KeyCount.gameObject.SetActive(GetKey(SkillType.Ice2) != 0);
  if (GetKey(SkillType.Ice2) != 0)
  {
   Ice2KeyCount.text = GetKey(SkillType.Ice2).ToString();
  }

  Ice3KeyCount.gameObject.SetActive(GetKey(SkillType.Ice3) != 0);
  if (GetKey(SkillType.Ice3) != 0)
  {
   Ice3KeyCount.text = GetKey(SkillType.Ice3).ToString();
  }

  Ice4KeyCount.gameObject.SetActive(GetKey(SkillType.Ice4) != 0);
  if (GetKey(SkillType.Ice4) != 0)
  {
   Ice4KeyCount.text = GetKey(SkillType.Ice4).ToString();
  }

  Ice5KeyCount.gameObject.SetActive(GetKey(SkillType.Ice5) != 0);
  if (GetKey(SkillType.Ice5) != 0)
  {
   Ice5KeyCount.text = GetKey(SkillType.Ice5).ToString();
  }

 }


 private void SetHuoPanelAutoAndKey()
 {
  Huo1AutoCount.gameObject.SetActive(SkillJiaDian.S.Huo1Auto);
  Huo2AutoCount.gameObject.SetActive(SkillJiaDian.S.Huo2Auto);
  Huo3AutoCount.gameObject.SetActive(SkillJiaDian.S.Huo3Auto);
  Huo4AutoCount.gameObject.SetActive(SkillJiaDian.S.Huo4Auto);
  Huo5AutoCount.gameObject.SetActive(SkillJiaDian.S.Huo5Auto);

  Huo1KeyCount.gameObject.SetActive(GetKey(SkillType.Huo1) != 0);
  if (GetKey(SkillType.Huo1) != 0)
  {
   Huo1KeyCount.text = GetKey(SkillType.Huo1).ToString();
  }

  Huo2KeyCount.gameObject.SetActive(GetKey(SkillType.Huo2) != 0);
  if (GetKey(SkillType.Huo2) != 0)
  {
   Huo2KeyCount.text = GetKey(SkillType.Huo2).ToString();
  }

  Huo3KeyCount.gameObject.SetActive(GetKey(SkillType.Huo3) != 0);
  if (GetKey(SkillType.Huo3) != 0)
  {
   Huo3KeyCount.text = GetKey(SkillType.Huo3).ToString();
  }

  Huo4KeyCount.gameObject.SetActive(GetKey(SkillType.Huo4) != 0);
  if (GetKey(SkillType.Huo4) != 0)
  {
   Huo4KeyCount.text = GetKey(SkillType.Huo4).ToString();
  }

  Huo5KeyCount.gameObject.SetActive(GetKey(SkillType.Huo5) != 0);
  if (GetKey(SkillType.Huo5) != 0)
  {
   Huo5KeyCount.text = GetKey(SkillType.Huo5).ToString();
  }

 }


 private void SetDianPanelAutoAndKey()
 {
  Dian1AutoCount.gameObject.SetActive(SkillJiaDian.S.Dian1Auto);
  Dian2AutoCount.gameObject.SetActive(SkillJiaDian.S.Dian2Auto);
  Dian3AutoCount.gameObject.SetActive(SkillJiaDian.S.Dian3Auto);
  Dian4AutoCount.gameObject.SetActive(SkillJiaDian.S.Dian4Auto);
  Dian5AutoCount.gameObject.SetActive(SkillJiaDian.S.Dian5Auto);

  Dian1KeyCount.gameObject.SetActive(GetKey(SkillType.Dian1) != 0);
  if (GetKey(SkillType.Dian1) != 0)
  {
   Dian1KeyCount.text = GetKey(SkillType.Dian1).ToString();
  }

  Dian2KeyCount.gameObject.SetActive(GetKey(SkillType.Dian2) != 0);
  if (GetKey(SkillType.Dian2) != 0)
  {
   Dian2KeyCount.text = GetKey(SkillType.Dian2).ToString();
  }

  Dian3KeyCount.gameObject.SetActive(GetKey(SkillType.Dian3) != 0);
  if (GetKey(SkillType.Dian3) != 0)
  {
   Dian3KeyCount.text = GetKey(SkillType.Dian3).ToString();
  }

  Dian4KeyCount.gameObject.SetActive(GetKey(SkillType.Dian4) != 0);
  if (GetKey(SkillType.Dian4) != 0)
  {
   Dian4KeyCount.text = GetKey(SkillType.Dian4).ToString();
  }

  Dian5KeyCount.gameObject.SetActive(GetKey(SkillType.Dian5) != 0);
  if (GetKey(SkillType.Dian5) != 0)
  {
   Dian5KeyCount.text = GetKey(SkillType.Dian5).ToString();
  }

 }



 private void SetHeiAnPanelAutoAndKey()
 {
  HeiAn1AutoCount.gameObject.SetActive(SkillJiaDian.S.HeiAn1Auto);
  HeiAn2AutoCount.gameObject.SetActive(SkillJiaDian.S.HeiAn2Auto);
  HeiAn3AutoCount.gameObject.SetActive(SkillJiaDian.S.HeiAn3Auto);
  HeiAn4AutoCount.gameObject.SetActive(SkillJiaDian.S.HeiAn4Auto);
  HeiAn5AutoCount.gameObject.SetActive(SkillJiaDian.S.HeiAn5Auto);

  HeiAn1KeyCount.gameObject.SetActive(GetKey(SkillType.HeiAn1) != 0);
  if (GetKey(SkillType.HeiAn1) != 0)
  {
   HeiAn1KeyCount.text = GetKey(SkillType.HeiAn1).ToString();
  }

  HeiAn2KeyCount.gameObject.SetActive(GetKey(SkillType.HeiAn2) != 0);
  if (GetKey(SkillType.HeiAn2) != 0)
  {
   HeiAn2KeyCount.text = GetKey(SkillType.HeiAn2).ToString();
  }

  HeiAn3KeyCount.gameObject.SetActive(GetKey(SkillType.HeiAn3) != 0);
  if (GetKey(SkillType.HeiAn3) != 0)
  {
   HeiAn3KeyCount.text = GetKey(SkillType.HeiAn3).ToString();
  }

  HeiAn4KeyCount.gameObject.SetActive(GetKey(SkillType.HeiAn4) != 0);
  if (GetKey(SkillType.HeiAn4) != 0)
  {
   HeiAn4KeyCount.text = GetKey(SkillType.HeiAn4).ToString();
  }

  HeiAn5KeyCount.gameObject.SetActive(GetKey(SkillType.HeiAn5) != 0);
  if (GetKey(SkillType.HeiAn5) != 0)
  {
   HeiAn5KeyCount.text = GetKey(SkillType.HeiAn5).ToString();
  }

 }

 private void ShowPanel()
 {
  skillCount.text = SkillJiaDian.S.CurrentSkillCount.ToString();
  switch (PanelType)
  {
   case 1:
    ShowIcePanel();
    break;
   case 2:
    ShowHuoPanel();
    break;
   case 3:
    ShowDianPanel();
    break;
   case 4:
    ShowHeiAnPanel();
    break;
  }
 }

 private void ShowIcePanel()
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

 private void ShowHuoPanel()
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

 private void ShowDianPanel()
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


 private void ShowHeiAnPanel()
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




 private void OnEnable()
 {
  skillCount.text = SkillJiaDian.S.CurrentSkillCount.ToString();
  PanelType = 1;
  ShowPanel();
 }

 private void Start()
 {
  ResetButton.onClick.AddListener(() =>
  {
   SkillJiaDian.S.ResetSkillCount();
   ShowPanel();
  });
  exitButton.onClick.AddListener(() =>
  {
    WindowController.S.SkillWindow.gameObject.SetActive(false);
    WindowController.S.RoleWindow.gameObject.SetActive(true);

  });
  IceButton.onClick.AddListener(() => { PanelType = 1;ShowPanel(); });

  HuoButton.onClick.AddListener(() => { PanelType = 2;ShowPanel(); });

  DianButton.onClick.AddListener(() => { PanelType = 3;ShowPanel(); });

  HeiAnButton.onClick.AddListener(() => { PanelType = 4;ShowPanel(); });


  
  // IceBei系列
    IceBei1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.IceBei1, (value) => SkillJiaDian.S.IceBei1 = value, 5, "冰霜之杯1"));
    IceBei2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.IceBei2, (value) => SkillJiaDian.S.IceBei2 = value, 5, "冰霜之杯2"));
    IceBei3Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.IceBei3, (value) => SkillJiaDian.S.IceBei3 = value, 5, "冰霜之杯3"));
    IceBei4Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.IceBei4, (value) => SkillJiaDian.S.IceBei4 = value, 5, "冰霜之杯4"));

    // Ice1系列
    Ice1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice1, (value) => SkillJiaDian.S.Ice1 = value, 10, "冰霜1"));
    Ice1_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice1_1, (value) => SkillJiaDian.S.Ice1_1 = value, 5, "冰霜1-1"));
    Ice1_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice1_2, (value) => SkillJiaDian.S.Ice1_2 = value, 5, "冰霜1-2"));
    
    // Ice2系列
    Ice2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice2, (value) => SkillJiaDian.S.Ice2 = value, 10, "冰霜2",5));
    Ice2_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice2_1, (value) => SkillJiaDian.S.Ice2_1 = value, 5, "冰霜2-1"));
    Ice2_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice2_2, (value) => SkillJiaDian.S.Ice2_2 = value, 5, "冰霜2-2"));
    
    // Ice3系列
    Ice3Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice3, (value) => SkillJiaDian.S.Ice3 = value, 10, "冰霜3",10));
    Ice3_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice3_1, (value) => SkillJiaDian.S.Ice3_1 = value, 5, "冰霜3-1"));
    Ice3_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice3_2, (value) => SkillJiaDian.S.Ice3_2 = value, 5, "冰霜3-2"));
    
    // Ice4系列
    Ice4Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice4, (value) => SkillJiaDian.S.Ice4 = value, 10, "冰霜4",20));
    Ice4_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice4_1, (value) => SkillJiaDian.S.Ice4_1 = value, 5, "冰霜4-1"));
    Ice4_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice4_2, (value) => SkillJiaDian.S.Ice4_2 = value, 5, "冰霜4-2"));
    
    // Ice5系列
    Ice5Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice5, (value) => SkillJiaDian.S.Ice5 = value, 10, "冰霜5",30));
    Ice5_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice5_1, (value) => SkillJiaDian.S.Ice5_1 = value, 5, "冰霜5-1"));
    Ice5_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Ice5_2, (value) => SkillJiaDian.S.Ice5_2 = value, 5, "冰霜5-2"));

    BindDianPanelEvents();
    BindHuoPanelEvents();
    BindHeiAnPanelEvents();
 }
private void BindHuoPanelEvents()
{
    // HuoBei系列
    HuoBei1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HuoBei1, (value) => SkillJiaDian.S.HuoBei1 = value, 5, "火焰之杯1"));
    HuoBei2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HuoBei2, (value) => SkillJiaDian.S.HuoBei2 = value, 5, "火焰之杯2"));
    HuoBei3Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HuoBei3, (value) => SkillJiaDian.S.HuoBei3 = value, 5, "火焰之杯3"));
    HuoBei4Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HuoBei4, (value) => SkillJiaDian.S.HuoBei4 = value, 5, "火焰之杯4"));

    // Huo1系列
    Huo1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo1, (value) => SkillJiaDian.S.Huo1 = value, 10, "火焰1"));
    Huo1_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo1_1, (value) => SkillJiaDian.S.Huo1_1 = value, 5, "火焰1-1"));
    Huo1_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo1_2, (value) => SkillJiaDian.S.Huo1_2 = value, 5, "火焰1-2"));
    
    // Huo2系列
    Huo2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo2, (value) => SkillJiaDian.S.Huo2 = value, 10, "火焰2",5));
    Huo2_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo2_1, (value) => SkillJiaDian.S.Huo2_1 = value, 5, "火焰2-1"));
    Huo2_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo2_2, (value) => SkillJiaDian.S.Huo2_2 = value, 5, "火焰2-2"));
    
    // Huo3系列
    Huo3Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo3, (value) => SkillJiaDian.S.Huo3 = value, 10, "火焰3",10));
    Huo3_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo3_1, (value) => SkillJiaDian.S.Huo3_1 = value, 5, "火焰3-1"));
    Huo3_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo3_2, (value) => SkillJiaDian.S.Huo3_2 = value, 5, "火焰3-2"));
    
    // Huo4系列
    Huo4Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo4, (value) => SkillJiaDian.S.Huo4 = value, 10, "火焰4",20));
    Huo4_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo4_1, (value) => SkillJiaDian.S.Huo4_1 = value, 5, "火焰4-1"));
    Huo4_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo4_2, (value) => SkillJiaDian.S.Huo4_2 = value, 5, "火焰4-2"));
    
    // Huo5系列
    Huo5Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo5, (value) => SkillJiaDian.S.Huo5 = value, 10, "火焰5",30));
    Huo5_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo5_1, (value) => SkillJiaDian.S.Huo5_1 = value, 5, "火焰5-1"));
    Huo5_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Huo5_2, (value) => SkillJiaDian.S.Huo5_2 = value, 5, "火焰5-2"));
}

// DianPanel 按钮点击事件
private void BindDianPanelEvents()
{
    // DianBei系列
    DianBei1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.DianBei1, (value) => SkillJiaDian.S.DianBei1 = value, 5, "闪电之杯1"));
    DianBei2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.DianBei2, (value) => SkillJiaDian.S.DianBei2 = value, 5, "闪电之杯2"));
    DianBei3Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.DianBei3, (value) => SkillJiaDian.S.DianBei3 = value, 5, "闪电之杯3"));
    DianBei4Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.DianBei4, (value) => SkillJiaDian.S.DianBei4 = value, 5, "闪电之杯4"));

    // Dian1系列
    Dian1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian1, (value) => SkillJiaDian.S.Dian1 = value, 10, "闪电1"));
    Dian1_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian1_1, (value) => SkillJiaDian.S.Dian1_1 = value, 5, "闪电1-1"));
    Dian1_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian1_2, (value) => SkillJiaDian.S.Dian1_2 = value, 5, "闪电1-2"));
    
    // Dian2系列
    Dian2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian2, (value) => SkillJiaDian.S.Dian2 = value, 10, "闪电2",5));
    Dian2_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian2_1, (value) => SkillJiaDian.S.Dian2_1 = value, 5, "闪电2-1"));
    Dian2_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian2_2, (value) => SkillJiaDian.S.Dian2_2 = value, 5, "闪电2-2"));
    
    // Dian3系列
    Dian3Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian3, (value) => SkillJiaDian.S.Dian3 = value, 10, "闪电3",10));
    Dian3_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian3_1, (value) => SkillJiaDian.S.Dian3_1 = value, 5, "闪电3-1"));
    Dian3_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian3_2, (value) => SkillJiaDian.S.Dian3_2 = value, 5, "闪电3-2"));
    
    // Dian4系列
    Dian4Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian4, (value) => SkillJiaDian.S.Dian4 = value, 10, "闪电4",20));
    Dian4_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian4_1, (value) => SkillJiaDian.S.Dian4_1 = value, 5, "闪电4-1"));
    Dian4_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian4_2, (value) => SkillJiaDian.S.Dian4_2 = value, 5, "闪电4-2"));
    
    // Dian5系列
    Dian5Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian5, (value) => SkillJiaDian.S.Dian5 = value, 10, "闪电5",20));
    Dian5_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian5_1, (value) => SkillJiaDian.S.Dian5_1 = value, 5, "闪电5-1"));
    Dian5_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.Dian5_2, (value) => SkillJiaDian.S.Dian5_2 = value, 5, "闪电5-2"));
}

// HeiAnPanel 按钮点击事件
private void BindHeiAnPanelEvents()
{
    // HeiAnBei系列
    HeiAnBei1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAnBei1, (value) => SkillJiaDian.S.HeiAnBei1 = value, 5, "黑暗之杯1"));
    HeiAnBei2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAnBei2, (value) => SkillJiaDian.S.HeiAnBei2 = value, 5, "黑暗之杯2"));
    HeiAnBei3Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAnBei3, (value) => SkillJiaDian.S.HeiAnBei3 = value, 5, "黑暗之杯3"));
    HeiAnBei4Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAnBei4, (value) => SkillJiaDian.S.HeiAnBei4 = value, 5, "黑暗之杯4"));

    // HeiAn1系列
    HeiAn1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn1, (value) => SkillJiaDian.S.HeiAn1 = value, 10, "黑暗1"));
    HeiAn1_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn1_1, (value) => SkillJiaDian.S.HeiAn1_1 = value, 5, "黑暗1-1"));
    HeiAn1_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn1_2, (value) => SkillJiaDian.S.HeiAn1_2 = value, 5, "黑暗1-2"));
    
    // HeiAn2系列
    HeiAn2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn2, (value) => SkillJiaDian.S.HeiAn2 = value, 10, "黑暗2",5));
    HeiAn2_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn2_1, (value) => SkillJiaDian.S.HeiAn2_1 = value, 5, "黑暗2-1"));
    HeiAn2_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn2_2, (value) => SkillJiaDian.S.HeiAn2_2 = value, 5, "黑暗2-2"));
    
    // HeiAn3系列
    HeiAn3Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn3, (value) => SkillJiaDian.S.HeiAn3 = value, 10, "黑暗3",10));
    HeiAn3_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn3_1, (value) => SkillJiaDian.S.HeiAn3_1 = value, 5, "黑暗3-1"));
    HeiAn3_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn3_2, (value) => SkillJiaDian.S.HeiAn3_2 = value, 5, "黑暗3-2"));
    
    // HeiAn4系列
    HeiAn4Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn4, (value) => SkillJiaDian.S.HeiAn4 = value, 10, "黑暗4",20));
    HeiAn4_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn4_1, (value) => SkillJiaDian.S.HeiAn4_1 = value, 5, "黑暗4-1"));
    HeiAn4_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn4_2, (value) => SkillJiaDian.S.HeiAn4_2 = value, 5, "黑暗4-2"));
    
    // HeiAn5系列
    HeiAn5Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn5, (value) => SkillJiaDian.S.HeiAn5 = value, 10, "黑暗5",30));
    HeiAn5_1Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn5_1, (value) => SkillJiaDian.S.HeiAn5_1 = value, 5, "黑暗5-1"));
    HeiAn5_2Icon.GetComponent<Button>().onClick.AddListener(() => HandleSkillUpgrade(() => SkillJiaDian.S.HeiAn5_2, (value) => SkillJiaDian.S.HeiAn5_2 = value, 5, "黑暗5-2"));
}

// 通用技能升级处理方法
private void HandleSkillUpgrade(Func<int> getSkillLevel, Action<int> setSkillLevel, int maxLevel, string skillName,int Skilllimit=0)
{
    if (SkillJiaDian.S.CurrentSkillCount <= 0)
    {
        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "技能点不足");
        return;
    }
    
    if (getSkillLevel() >= maxLevel)
    {
        ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "已达等级上限");
        return;
    }

    if (PlayerData.S.level < Skilllimit)
    {
     ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast, "等级不足");
     return;
    }

    SkillJiaDian.S.CurrentSkillCount--;
    setSkillLevel(getSkillLevel() + 1);
    
    // 可以在这里添加升级成功后的UI更新逻辑
    UpdateSkillUI(skillName, getSkillLevel());
    ShowPanel();
    StoreController.S.SaveStoreData();
}

// 更新技能UI的方法（根据您的需求实现）
private void UpdateSkillUI(string skillName, int newLevel)
{
    // 根据技能名称更新对应的UI显示
    // 例如更新等级文本、图标状态等
    Debug.Log($"技能 {skillName} 升级到 {newLevel} 级");
}





[Header("IcePanel")] private int PanelType = 1;
 private Image IceMainBg;
 private Image IceMainIcon;
 private TextMeshProUGUI IceMainLevelCount;
 private Image IceMainLevelBg;
 private Image IceMainXuanZhong;

 private Image IceBei1Bg;
 private Image IceBei1Icon;
 private TextMeshProUGUI IceBei1LevelCount;
 private Image IceBei1LevelBg;
 private Image IceBei1XuanZhong;

 private Image IceBei2Bg;
 private Image IceBei2Icon;
 private TextMeshProUGUI IceBei2LevelCount;
 private Image IceBei2LevelBg;
 private Image IceBei2XuanZhong;

 private Image IceBei3Bg;
 private Image IceBei3Icon;
 private TextMeshProUGUI IceBei3LevelCount;
 private Image IceBei3LevelBg;
 private Image IceBei3XuanZhong;

 private Image IceBei4Bg;
 private Image IceBei4Icon;
 private TextMeshProUGUI IceBei4LevelCount;
 private Image IceBei4LevelBg;
 private Image IceBei4XuanZhong;


 private Image Ice1Bg;
 private Image Ice1Icon;
 private TextMeshProUGUI Ice1LevelCount;
 private Image Ice1LevelBg;
 private Image Ice1XuanZhong;
 private TextMeshProUGUI Ice1AutoCount;
 private Image Ice1AutoBg;
 private TextMeshProUGUI Ice1KeyCount;
 private Image Ice1KeyBg;


 private Image Ice1_1Bg;
 private Image Ice1_1Icon;
 private TextMeshProUGUI Ice1_1LevelCount;
 private Image Ice1_1LevelBg;
 private Image Ice1_1XuanZhong;

 private Image Ice1_2Bg;
 private Image Ice1_2Icon;
 private TextMeshProUGUI Ice1_2LevelCount;
 private Image Ice1_2LevelBg;
 private Image Ice1_2XuanZhong;


 private Image Ice2Bg;
 private Image Ice2Icon;
 private TextMeshProUGUI Ice2LevelCount;
 private Image Ice2LevelBg;
 private Image Ice2XuanZhong;
 private TextMeshProUGUI Ice2AutoCount;
 private Image Ice2AutoBg;
 private TextMeshProUGUI Ice2KeyCount;
 private Image Ice2KeyBg;


 private Image Ice2_1Bg;
 private Image Ice2_1Icon;
 private TextMeshProUGUI Ice2_1LevelCount;
 private Image Ice2_1LevelBg;
 private Image Ice2_1XuanZhong;

 private Image Ice2_2Bg;
 private Image Ice2_2Icon;
 private TextMeshProUGUI Ice2_2LevelCount;
 private Image Ice2_2LevelBg;
 private Image Ice2_2XuanZhong;




 private Image Ice3Bg;
 private Image Ice3Icon;
 private TextMeshProUGUI Ice3LevelCount;
 private Image Ice3LevelBg;
 private Image Ice3XuanZhong;
 private TextMeshProUGUI Ice3AutoCount;
 private Image Ice3AutoBg;
 private TextMeshProUGUI Ice3KeyCount;
 private Image Ice3KeyBg;


 private Image Ice3_1Bg;
 private Image Ice3_1Icon;
 private TextMeshProUGUI Ice3_1LevelCount;
 private Image Ice3_1LevelBg;
 private Image Ice3_1XuanZhong;

 private Image Ice3_2Bg;
 private Image Ice3_2Icon;
 private TextMeshProUGUI Ice3_2LevelCount;
 private Image Ice3_2LevelBg;
 private Image Ice3_2XuanZhong;





 private Image Ice4Bg;
 private Image Ice4Icon;
 private TextMeshProUGUI Ice4LevelCount;
 private Image Ice4LevelBg;
 private Image Ice4XuanZhong;
 private TextMeshProUGUI Ice4AutoCount;
 private Image Ice4AutoBg;
 private TextMeshProUGUI Ice4KeyCount;
 private Image Ice4KeyBg;


 private Image Ice4_1Bg;
 private Image Ice4_1Icon;
 private TextMeshProUGUI Ice4_1LevelCount;
 private Image Ice4_1LevelBg;
 private Image Ice4_1XuanZhong;

 private Image Ice4_2Bg;
 private Image Ice4_2Icon;
 private TextMeshProUGUI Ice4_2LevelCount;
 private Image Ice4_2LevelBg;
 private Image Ice4_2XuanZhong;



 private Image Ice5Bg;
 private Image Ice5Icon;
 private TextMeshProUGUI Ice5LevelCount;
 private Image Ice5LevelBg;
 private Image Ice5XuanZhong;
 private TextMeshProUGUI Ice5AutoCount;
 private Image Ice5AutoBg;
 private TextMeshProUGUI Ice5KeyCount;
 private Image Ice5KeyBg;


 private Image Ice5_1Bg;
 private Image Ice5_1Icon;
 private TextMeshProUGUI Ice5_1LevelCount;
 private Image Ice5_1LevelBg;
 private Image Ice5_1XuanZhong;

 private Image Ice5_2Bg;
 private Image Ice5_2Icon;
 private TextMeshProUGUI Ice5_2LevelCount;
 private Image Ice5_2LevelBg;
 private Image Ice5_2XuanZhong;

 private GameObject IceBeiLine1Liang;
 private GameObject IceBeiLine1An;
 private GameObject IceBeiLine2Liang;
 private GameObject IceBeiLine2An;
 private GameObject Ice1Line1Liang;
 private GameObject Ice1Line1An;
 private GameObject Ice1Line2Liang;
 private GameObject Ice1Line2An;

 private GameObject Ice2Line1Liang;
 private GameObject Ice2Line1An;
 private GameObject Ice2Line2Liang;
 private GameObject Ice2Line2An;

 private GameObject Ice3Line1Liang;
 private GameObject Ice3Line1An;
 private GameObject Ice3Line2Liang;
 private GameObject Ice3Line2An;

 private GameObject Ice4Line1Liang;
 private GameObject Ice4Line1An;
 private GameObject Ice4Line2Liang;
 private GameObject Ice4Line2An;

 private GameObject Ice5Line1Liang;
 private GameObject Ice5Line1An;
 private GameObject Ice5Line2Liang;
 private GameObject Ice5Line2An;

 [Header("HuoPanel")] private Image HuoMainBg;
 private Image HuoMainIcon;
 private TextMeshProUGUI HuoMainLevelCount;
 private Image HuoMainLevelBg;
 private Image HuoMainXuanZhong;

 private Image HuoBei1Bg;
 private Image HuoBei1Icon;
 private TextMeshProUGUI HuoBei1LevelCount;
 private Image HuoBei1LevelBg;
 private Image HuoBei1XuanZhong;

 private Image HuoBei2Bg;
 private Image HuoBei2Icon;
 private TextMeshProUGUI HuoBei2LevelCount;
 private Image HuoBei2LevelBg;
 private Image HuoBei2XuanZhong;

 private Image HuoBei3Bg;
 private Image HuoBei3Icon;
 private TextMeshProUGUI HuoBei3LevelCount;
 private Image HuoBei3LevelBg;
 private Image HuoBei3XuanZhong;

 private Image HuoBei4Bg;
 private Image HuoBei4Icon;
 private TextMeshProUGUI HuoBei4LevelCount;
 private Image HuoBei4LevelBg;
 private Image HuoBei4XuanZhong;


 private Image Huo1Bg;
 private Image Huo1Icon;
 private TextMeshProUGUI Huo1LevelCount;
 private Image Huo1LevelBg;
 private Image Huo1XuanZhong;
 private TextMeshProUGUI Huo1AutoCount;
 private Image Huo1AutoBg;
 private TextMeshProUGUI Huo1KeyCount;
 private Image Huo1KeyBg;


 private Image Huo1_1Bg;
 private Image Huo1_1Icon;
 private TextMeshProUGUI Huo1_1LevelCount;
 private Image Huo1_1LevelBg;
 private Image Huo1_1XuanZhong;

 private Image Huo1_2Bg;
 private Image Huo1_2Icon;
 private TextMeshProUGUI Huo1_2LevelCount;
 private Image Huo1_2LevelBg;
 private Image Huo1_2XuanZhong;


 private Image Huo2Bg;
 private Image Huo2Icon;
 private TextMeshProUGUI Huo2LevelCount;
 private Image Huo2LevelBg;
 private Image Huo2XuanZhong;
 private TextMeshProUGUI Huo2AutoCount;
 private Image Huo2AutoBg;
 private TextMeshProUGUI Huo2KeyCount;
 private Image Huo2KeyBg;


 private Image Huo2_1Bg;
 private Image Huo2_1Icon;
 private TextMeshProUGUI Huo2_1LevelCount;
 private Image Huo2_1LevelBg;
 private Image Huo2_1XuanZhong;

 private Image Huo2_2Bg;
 private Image Huo2_2Icon;
 private TextMeshProUGUI Huo2_2LevelCount;
 private Image Huo2_2LevelBg;
 private Image Huo2_2XuanZhong;




 private Image Huo3Bg;
 private Image Huo3Icon;
 private TextMeshProUGUI Huo3LevelCount;
 private Image Huo3LevelBg;
 private Image Huo3XuanZhong;
 private TextMeshProUGUI Huo3AutoCount;
 private Image Huo3AutoBg;
 private TextMeshProUGUI Huo3KeyCount;
 private Image Huo3KeyBg;


 private Image Huo3_1Bg;
 private Image Huo3_1Icon;
 private TextMeshProUGUI Huo3_1LevelCount;
 private Image Huo3_1LevelBg;
 private Image Huo3_1XuanZhong;

 private Image Huo3_2Bg;
 private Image Huo3_2Icon;
 private TextMeshProUGUI Huo3_2LevelCount;
 private Image Huo3_2LevelBg;
 private Image Huo3_2XuanZhong;





 private Image Huo4Bg;
 private Image Huo4Icon;
 private TextMeshProUGUI Huo4LevelCount;
 private Image Huo4LevelBg;
 private Image Huo4XuanZhong;
 private TextMeshProUGUI Huo4AutoCount;
 private Image Huo4AutoBg;
 private TextMeshProUGUI Huo4KeyCount;
 private Image Huo4KeyBg;


 private Image Huo4_1Bg;
 private Image Huo4_1Icon;
 private TextMeshProUGUI Huo4_1LevelCount;
 private Image Huo4_1LevelBg;
 private Image Huo4_1XuanZhong;

 private Image Huo4_2Bg;
 private Image Huo4_2Icon;
 private TextMeshProUGUI Huo4_2LevelCount;
 private Image Huo4_2LevelBg;
 private Image Huo4_2XuanZhong;



 private Image Huo5Bg;
 private Image Huo5Icon;
 private TextMeshProUGUI Huo5LevelCount;
 private Image Huo5LevelBg;
 private Image Huo5XuanZhong;
 private TextMeshProUGUI Huo5AutoCount;
 private Image Huo5AutoBg;
 private TextMeshProUGUI Huo5KeyCount;
 private Image Huo5KeyBg;


 private Image Huo5_1Bg;
 private Image Huo5_1Icon;
 private TextMeshProUGUI Huo5_1LevelCount;
 private Image Huo5_1LevelBg;
 private Image Huo5_1XuanZhong;

 private Image Huo5_2Bg;
 private Image Huo5_2Icon;
 private TextMeshProUGUI Huo5_2LevelCount;
 private Image Huo5_2LevelBg;
 private Image Huo5_2XuanZhong;

 private GameObject HuoBeiLine1Liang;
 private GameObject HuoBeiLine1An;
 private GameObject HuoBeiLine2Liang;
 private GameObject HuoBeiLine2An;
 private GameObject Huo1Line1Liang;
 private GameObject Huo1Line1An;
 private GameObject Huo1Line2Liang;
 private GameObject Huo1Line2An;

 private GameObject Huo2Line1Liang;
 private GameObject Huo2Line1An;
 private GameObject Huo2Line2Liang;
 private GameObject Huo2Line2An;

 private GameObject Huo3Line1Liang;
 private GameObject Huo3Line1An;
 private GameObject Huo3Line2Liang;
 private GameObject Huo3Line2An;

 private GameObject Huo4Line1Liang;
 private GameObject Huo4Line1An;
 private GameObject Huo4Line2Liang;
 private GameObject Huo4Line2An;

 private GameObject Huo5Line1Liang;
 private GameObject Huo5Line1An;
 private GameObject Huo5Line2Liang;
 private GameObject Huo5Line2An;





 [Header("DianPanel")] private Image DianMainBg;
 private Image DianMainIcon;
 private TextMeshProUGUI DianMainLevelCount;
 private Image DianMainLevelBg;
 private Image DianMainXuanZhong;

 private Image DianBei1Bg;
 private Image DianBei1Icon;
 private TextMeshProUGUI DianBei1LevelCount;
 private Image DianBei1LevelBg;
 private Image DianBei1XuanZhong;

 private Image DianBei2Bg;
 private Image DianBei2Icon;
 private TextMeshProUGUI DianBei2LevelCount;
 private Image DianBei2LevelBg;
 private Image DianBei2XuanZhong;

 private Image DianBei3Bg;
 private Image DianBei3Icon;
 private TextMeshProUGUI DianBei3LevelCount;
 private Image DianBei3LevelBg;
 private Image DianBei3XuanZhong;

 private Image DianBei4Bg;
 private Image DianBei4Icon;
 private TextMeshProUGUI DianBei4LevelCount;
 private Image DianBei4LevelBg;
 private Image DianBei4XuanZhong;


 private Image Dian1Bg;
 private Image Dian1Icon;
 private TextMeshProUGUI Dian1LevelCount;
 private Image Dian1LevelBg;
 private Image Dian1XuanZhong;
 private TextMeshProUGUI Dian1AutoCount;
 private Image Dian1AutoBg;
 private TextMeshProUGUI Dian1KeyCount;
 private Image Dian1KeyBg;


 private Image Dian1_1Bg;
 private Image Dian1_1Icon;
 private TextMeshProUGUI Dian1_1LevelCount;
 private Image Dian1_1LevelBg;
 private Image Dian1_1XuanZhong;

 private Image Dian1_2Bg;
 private Image Dian1_2Icon;
 private TextMeshProUGUI Dian1_2LevelCount;
 private Image Dian1_2LevelBg;
 private Image Dian1_2XuanZhong;


 private Image Dian2Bg;
 private Image Dian2Icon;
 private TextMeshProUGUI Dian2LevelCount;
 private Image Dian2LevelBg;
 private Image Dian2XuanZhong;
 private TextMeshProUGUI Dian2AutoCount;
 private Image Dian2AutoBg;
 private TextMeshProUGUI Dian2KeyCount;
 private Image Dian2KeyBg;


 private Image Dian2_1Bg;
 private Image Dian2_1Icon;
 private TextMeshProUGUI Dian2_1LevelCount;
 private Image Dian2_1LevelBg;
 private Image Dian2_1XuanZhong;

 private Image Dian2_2Bg;
 private Image Dian2_2Icon;
 private TextMeshProUGUI Dian2_2LevelCount;
 private Image Dian2_2LevelBg;
 private Image Dian2_2XuanZhong;




 private Image Dian3Bg;
 private Image Dian3Icon;
 private TextMeshProUGUI Dian3LevelCount;
 private Image Dian3LevelBg;
 private Image Dian3XuanZhong;
 private TextMeshProUGUI Dian3AutoCount;
 private Image Dian3AutoBg;
 private TextMeshProUGUI Dian3KeyCount;
 private Image Dian3KeyBg;


 private Image Dian3_1Bg;
 private Image Dian3_1Icon;
 private TextMeshProUGUI Dian3_1LevelCount;
 private Image Dian3_1LevelBg;
 private Image Dian3_1XuanZhong;

 private Image Dian3_2Bg;
 private Image Dian3_2Icon;
 private TextMeshProUGUI Dian3_2LevelCount;
 private Image Dian3_2LevelBg;
 private Image Dian3_2XuanZhong;





 private Image Dian4Bg;
 private Image Dian4Icon;
 private TextMeshProUGUI Dian4LevelCount;
 private Image Dian4LevelBg;
 private Image Dian4XuanZhong;
 private TextMeshProUGUI Dian4AutoCount;
 private Image Dian4AutoBg;
 private TextMeshProUGUI Dian4KeyCount;
 private Image Dian4KeyBg;


 private Image Dian4_1Bg;
 private Image Dian4_1Icon;
 private TextMeshProUGUI Dian4_1LevelCount;
 private Image Dian4_1LevelBg;
 private Image Dian4_1XuanZhong;

 private Image Dian4_2Bg;
 private Image Dian4_2Icon;
 private TextMeshProUGUI Dian4_2LevelCount;
 private Image Dian4_2LevelBg;
 private Image Dian4_2XuanZhong;



 private Image Dian5Bg;
 private Image Dian5Icon;
 private TextMeshProUGUI Dian5LevelCount;
 private Image Dian5LevelBg;
 private Image Dian5XuanZhong;
 private TextMeshProUGUI Dian5AutoCount;
 private Image Dian5AutoBg;
 private TextMeshProUGUI Dian5KeyCount;
 private Image Dian5KeyBg;


 private Image Dian5_1Bg;
 private Image Dian5_1Icon;
 private TextMeshProUGUI Dian5_1LevelCount;
 private Image Dian5_1LevelBg;
 private Image Dian5_1XuanZhong;

 private Image Dian5_2Bg;
 private Image Dian5_2Icon;
 private TextMeshProUGUI Dian5_2LevelCount;
 private Image Dian5_2LevelBg;
 private Image Dian5_2XuanZhong;


 private GameObject DianBeiLine1Liang;
 private GameObject DianBeiLine1An;
 private GameObject DianBeiLine2Liang;
 private GameObject DianBeiLine2An;
 private GameObject Dian1Line1Liang;
 private GameObject Dian1Line1An;
 private GameObject Dian1Line2Liang;
 private GameObject Dian1Line2An;

 private GameObject Dian2Line1Liang;
 private GameObject Dian2Line1An;
 private GameObject Dian2Line2Liang;
 private GameObject Dian2Line2An;

 private GameObject Dian3Line1Liang;
 private GameObject Dian3Line1An;
 private GameObject Dian3Line2Liang;
 private GameObject Dian3Line2An;

 private GameObject Dian4Line1Liang;
 private GameObject Dian4Line1An;
 private GameObject Dian4Line2Liang;
 private GameObject Dian4Line2An;

 private GameObject Dian5Line1Liang;
 private GameObject Dian5Line1An;
 private GameObject Dian5Line2Liang;
 private GameObject Dian5Line2An;


 [Header("HeiAnPanel")] private Image HeiAnMainBg;
 private Image HeiAnMainIcon;
 private TextMeshProUGUI HeiAnMainLevelCount;
 private Image HeiAnMainLevelBg;
 private Image HeiAnMainXuanZhong;

 private Image HeiAnBei1Bg;
 private Image HeiAnBei1Icon;
 private TextMeshProUGUI HeiAnBei1LevelCount;
 private Image HeiAnBei1LevelBg;
 private Image HeiAnBei1XuanZhong;

 private Image HeiAnBei2Bg;
 private Image HeiAnBei2Icon;
 private TextMeshProUGUI HeiAnBei2LevelCount;
 private Image HeiAnBei2LevelBg;
 private Image HeiAnBei2XuanZhong;

 private Image HeiAnBei3Bg;
 private Image HeiAnBei3Icon;
 private TextMeshProUGUI HeiAnBei3LevelCount;
 private Image HeiAnBei3LevelBg;
 private Image HeiAnBei3XuanZhong;

 private Image HeiAnBei4Bg;
 private Image HeiAnBei4Icon;
 private TextMeshProUGUI HeiAnBei4LevelCount;
 private Image HeiAnBei4LevelBg;
 private Image HeiAnBei4XuanZhong;


 private Image HeiAn1Bg;
 private Image HeiAn1Icon;
 private TextMeshProUGUI HeiAn1LevelCount;
 private Image HeiAn1LevelBg;
 private Image HeiAn1XuanZhong;
 private TextMeshProUGUI HeiAn1AutoCount;
 private Image HeiAn1AutoBg;
 private TextMeshProUGUI HeiAn1KeyCount;
 private Image HeiAn1KeyBg;


 private Image HeiAn1_1Bg;
 private Image HeiAn1_1Icon;
 private TextMeshProUGUI HeiAn1_1LevelCount;
 private Image HeiAn1_1LevelBg;
 private Image HeiAn1_1XuanZhong;

 private Image HeiAn1_2Bg;
 private Image HeiAn1_2Icon;
 private TextMeshProUGUI HeiAn1_2LevelCount;
 private Image HeiAn1_2LevelBg;
 private Image HeiAn1_2XuanZhong;


 private Image HeiAn2Bg;
 private Image HeiAn2Icon;
 private TextMeshProUGUI HeiAn2LevelCount;
 private Image HeiAn2LevelBg;
 private Image HeiAn2XuanZhong;
 private TextMeshProUGUI HeiAn2AutoCount;
 private Image HeiAn2AutoBg;
 private TextMeshProUGUI HeiAn2KeyCount;
 private Image HeiAn2KeyBg;


 private Image HeiAn2_1Bg;
 private Image HeiAn2_1Icon;
 private TextMeshProUGUI HeiAn2_1LevelCount;
 private Image HeiAn2_1LevelBg;
 private Image HeiAn2_1XuanZhong;

 private Image HeiAn2_2Bg;
 private Image HeiAn2_2Icon;
 private TextMeshProUGUI HeiAn2_2LevelCount;
 private Image HeiAn2_2LevelBg;
 private Image HeiAn2_2XuanZhong;




 private Image HeiAn3Bg;
 private Image HeiAn3Icon;
 private TextMeshProUGUI HeiAn3LevelCount;
 private Image HeiAn3LevelBg;
 private Image HeiAn3XuanZhong;
 private TextMeshProUGUI HeiAn3AutoCount;
 private Image HeiAn3AutoBg;
 private TextMeshProUGUI HeiAn3KeyCount;
 private Image HeiAn3KeyBg;


 private Image HeiAn3_1Bg;
 private Image HeiAn3_1Icon;
 private TextMeshProUGUI HeiAn3_1LevelCount;
 private Image HeiAn3_1LevelBg;
 private Image HeiAn3_1XuanZhong;

 private Image HeiAn3_2Bg;
 private Image HeiAn3_2Icon;
 private TextMeshProUGUI HeiAn3_2LevelCount;
 private Image HeiAn3_2LevelBg;
 private Image HeiAn3_2XuanZhong;





 private Image HeiAn4Bg;
 private Image HeiAn4Icon;
 private TextMeshProUGUI HeiAn4LevelCount;
 private Image HeiAn4LevelBg;
 private Image HeiAn4XuanZhong;
 private TextMeshProUGUI HeiAn4AutoCount;
 private Image HeiAn4AutoBg;
 private TextMeshProUGUI HeiAn4KeyCount;
 private Image HeiAn4KeyBg;


 private Image HeiAn4_1Bg;
 private Image HeiAn4_1Icon;
 private TextMeshProUGUI HeiAn4_1LevelCount;
 private Image HeiAn4_1LevelBg;
 private Image HeiAn4_1XuanZhong;

 private Image HeiAn4_2Bg;
 private Image HeiAn4_2Icon;
 private TextMeshProUGUI HeiAn4_2LevelCount;
 private Image HeiAn4_2LevelBg;
 private Image HeiAn4_2XuanZhong;



 private Image HeiAn5Bg;
 private Image HeiAn5Icon;
 private TextMeshProUGUI HeiAn5LevelCount;
 private Image HeiAn5LevelBg;
 private Image HeiAn5XuanZhong;
 private TextMeshProUGUI HeiAn5AutoCount;
 private Image HeiAn5AutoBg;
 private TextMeshProUGUI HeiAn5KeyCount;
 private Image HeiAn5KeyBg;


 private Image HeiAn5_1Bg;
 private Image HeiAn5_1Icon;
 private TextMeshProUGUI HeiAn5_1LevelCount;
 private Image HeiAn5_1LevelBg;
 private Image HeiAn5_1XuanZhong;

 private Image HeiAn5_2Bg;
 private Image HeiAn5_2Icon;
 private TextMeshProUGUI HeiAn5_2LevelCount;
 private Image HeiAn5_2LevelBg;
 private Image HeiAn5_2XuanZhong;


 private GameObject HeiAnBeiLine1Liang;
 private GameObject HeiAnBeiLine1An;
 private GameObject HeiAnBeiLine2Liang;
 private GameObject HeiAnBeiLine2An;
 private GameObject HeiAn1Line1Liang;
 private GameObject HeiAn1Line1An;
 private GameObject HeiAn1Line2Liang;
 private GameObject HeiAn1Line2An;

 private GameObject HeiAn2Line1Liang;
 private GameObject HeiAn2Line1An;
 private GameObject HeiAn2Line2Liang;
 private GameObject HeiAn2Line2An;

 private GameObject HeiAn3Line1Liang;
 private GameObject HeiAn3Line1An;
 private GameObject HeiAn3Line2Liang;
 private GameObject HeiAn3Line2An;

 private GameObject HeiAn4Line1Liang;
 private GameObject HeiAn4Line1An;
 private GameObject HeiAn4Line2Liang;
 private GameObject HeiAn4Line2An;

 private GameObject HeiAn5Line1Liang;
 private GameObject HeiAn5Line1An;
 private GameObject HeiAn5Line2Liang;
 private GameObject HeiAn5Line2An;


 public Button ResetButton;


}
