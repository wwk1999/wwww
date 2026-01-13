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
   public SkeletonAnimation startButtonSke;

   public void Complete(TrackEntry trackEntry)
   {
       bgSke.AnimationState.SetAnimation(0, "循环", true);
   }
   public void Complete1(TrackEntry trackEntry)
   {
       if (trackEntry.Animation.Name == "chuchuang")
       {
           bgSke.AnimationState.SetAnimation(0, "xunhuan", true);
       }
       if (trackEntry.Animation.Name == "dianji")
       {
           _isgameStart = true;
           gameObject.SetActive(false);
           WindowController.S.RoleWindow.SetActive(true);       
       }
   }
   
   private void Start()
   {
       _=PlayerInfoController.S;
       bgSke.AnimationState.Complete += Complete;
       startButtonSke.AnimationState.Complete += Complete1;

       bgSke.AnimationState.SetAnimation(0, "开始", false);
       startButtonSke.AnimationState.SetAnimation(0, "chuchang", false);
       bgSke.timeScale = 2;
      startButton.onClick.AddListener(async () =>
      {
          Debug.Log("点击进入末世");
          startButtonSke.AnimationState.SetAnimation(0, "dianji", false);
      });
   }
}
