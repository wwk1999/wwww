using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class MainWindow1 : MonoBehaviour
{
   public Button startButton;
   private bool _isgameStart = false;
   public static bool IsLogin = false;
   public SkeletonAnimation bgSke;

   public Button SettingButton;
   public void Complete(TrackEntry trackEntry)
   {
       bgSke.AnimationState.SetAnimation(0, "循环", true);
   }
   
   private void Start()
   {
       _=PlayerInfoController.S;
       bgSke.AnimationState.Complete += Complete;

       bgSke.AnimationState.SetAnimation(0, "开始", false);
       bgSke.timeScale = 2;
       
       SettingButton.onClick.AddListener(() =>
       {
           WindowController.S.SettingWindow.SetActive(true);
       });
       
      startButton.onClick.AddListener(async () =>
      {
          _isgameStart = true;
          WindowController.S.StoreWindow.SetActive(true);       
          Debug.Log("点击进入末世");
      });
   }
}
