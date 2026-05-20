using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailPanel : MonoBehaviour
{
   public SkeletonAnimation SkeletonAnimation;
   public Button exitButton;
   public Button againButton;

   private void Start()
   {
      if (SkeletonAnimation != null) {
         SkeletonAnimation.AnimationState.SetAnimation(0,"bui_10_1",false);
         SkeletonAnimation.AnimationState.Complete += Complete;
      }
      exitButton.onClick.AddListener(() =>
      {
         Time.timeScale = 1;
         GlobalPlayerAttribute.CurrentExitType = ExitType.Exit;
         SceneManager.LoadScene("UIScene");
         QueueController.S.FightExit();
      });
      againButton.onClick.AddListener(() =>
         {
            Time.timeScale = 1;
            GlobalPlayerAttribute.CurrentExitType = ExitType.Again;
            SceneManager.LoadScene("UIScene");
            QueueController.S.FightAgain();
         }
      );
   }

   private void OnDestroy()
   {
      SkeletonAnimation.AnimationState.Complete -= Complete;
   }

   public void Complete(TrackEntry trackEntry)
   {
      if (trackEntry.Animation.Name == "bui_10_1")
      {
         SkeletonAnimation.AnimationState.SetAnimation(0,"bui_10_2",true);         
      }
   }
   
}
