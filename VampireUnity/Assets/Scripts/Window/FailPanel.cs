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
   public SkeletonGraphic skeletonGraphic;
   public Button exitButton;
   public Button againButton;

   private void Start()
   {
      var skAnim = skeletonGraphic.GetComponent<SkeletonAnimation>();
      if (skAnim != null) {
         skAnim.AnimationName = "bui_10_1";
         skAnim.AnimationState.Complete += Complete;
      }
      exitButton.onClick.AddListener(() =>
      {
         Time.timeScale = 1;
         GlobalPlayerAttribute.CurrentExitType = ExitType.Exit;
         SceneManager.LoadScene("UIScene");
      });
      againButton.onClick.AddListener(() =>
         {
            Time.timeScale = 1;
            GlobalPlayerAttribute.CurrentExitType = ExitType.Again;
            SceneManager.LoadScene("UIScene");
         }
      );
   }

   private void OnDestroy()
   {
      var skAnim = skeletonGraphic.GetComponent<SkeletonAnimation>();
      if (skAnim != null) skAnim.AnimationState.Complete -= Complete;
   }

   public void Complete(TrackEntry trackEntry)
   {
      if (trackEntry.Animation.Name == "bui_10_1")
      {
         var skAnim = skeletonGraphic.GetComponent<SkeletonAnimation>();
         if (skAnim != null) skAnim.AnimationName = "bui_10_2";
      }
   }
   
}
