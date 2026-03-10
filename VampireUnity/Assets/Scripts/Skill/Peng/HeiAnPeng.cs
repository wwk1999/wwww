using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class HeiAnPeng : MonoBehaviour
{
   public SkeletonAnimation SkeletonAnimation;


   private void Start()
   {
      SkeletonAnimation.AnimationState.Complete += OnAnimationComplete;
   }

   public void OnAnimationComplete(TrackEntry trackEntry)
   {
      GameController.S.HeiAnPengQueue.Enqueue(gameObject);
      gameObject.SetActive(false);
   }
   

   private void OnEnable()
   {
      SkeletonAnimation.AnimationState.SetAnimation(0,"play",false);
   }
}
