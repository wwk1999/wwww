using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
   public SkeletonAnimation skeletonAnimation;
   private void OnEnable()
   {
      skeletonAnimation.AnimationState.SetAnimation(0,"animation",false);
      Invoke(nameof(Hide),2f);
   }

   public void Hide()
   {
      gameObject.SetActive(false);
      GameController.S.PlayerHurtQueue.Enqueue(this);
   }
}
