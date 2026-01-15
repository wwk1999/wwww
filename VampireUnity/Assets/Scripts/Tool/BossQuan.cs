using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class BossQuan : MonoBehaviour
{
   public SkeletonAnimation skeletonAnimation;

   private void Start()
   {
      skeletonAnimation.AnimationState.SetAnimation(0,"chuchang",false);
      skeletonAnimation.AnimationState.Complete += Complete;
   }

   public void Complete(TrackEntry trackEntry)
   {
      skeletonAnimation.AnimationState.SetAnimation(0,"xunhuan",false);
   }
}
