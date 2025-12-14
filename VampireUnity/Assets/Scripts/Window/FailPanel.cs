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
      skeletonGraphic.AnimationState.SetAnimation(0, "bui_10_1", false);
      skeletonGraphic.AnimationState.Complete += Complete;
      exitButton.onClick.AddListener(() =>
      {
         Time.timeScale = 1;
         GlobalPlayerAttribute.CurrentExitType = ExitType.Exit;
         PlayerInfoController.S.UpdatePlayerInfo( GlobalPlayerAttribute.Level, GlobalPlayerAttribute.Exp, GlobalPlayerAttribute.GameLevel, GlobalPlayerAttribute.BloodEnergy);
         SceneManager.LoadScene("UIScene");
      });
      againButton.onClick.AddListener(() =>
         {
            Time.timeScale = 1;
            GlobalPlayerAttribute.CurrentExitType = ExitType.Again;
            PlayerInfoController.S.UpdatePlayerInfo( GlobalPlayerAttribute.Level, GlobalPlayerAttribute.Exp, GlobalPlayerAttribute.GameLevel, GlobalPlayerAttribute.BloodEnergy);
            SceneManager.LoadScene("UIScene");
         }
      );
   }

   private void OnDestroy()
   {
      skeletonGraphic.AnimationState.Complete -= Complete;
   }

   public void Complete(TrackEntry trackEntry)
   {
      if (trackEntry.Animation.Name == "bui_10_1")
      {
         skeletonGraphic.AnimationState.SetAnimation(0, "bui_10_2", true);
      }
   }
   
}
