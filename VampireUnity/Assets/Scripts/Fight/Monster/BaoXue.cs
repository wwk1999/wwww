using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class BaoXue : MonoBehaviour
{
   public SkeletonAnimation Skeleton;

   private void OnDestroy()
   {
      Skeleton.AnimationState.Complete -= Complete;
   }

   private void Start()
   {
      Skeleton.AnimationState.Complete += Complete;
   }

   public void Complete(TrackEntry trackEntry)
   {
      GameController.S.BaoXueQueue.Enqueue(this);
      gameObject.SetActive(false);
   }


   private void OnEnable()
   {
      Skeleton.AnimationState.SetAnimation(0, "play",false);
      Skeleton.timeScale = 1.5f;
   }
}
