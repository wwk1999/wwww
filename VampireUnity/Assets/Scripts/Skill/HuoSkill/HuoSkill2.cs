using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class HuoSkill2 : MonoBehaviour
{
  public SkeletonAnimation skeletonAnimation;

  private void OnEnable()
  {
    skeletonAnimation.AnimationState.SetAnimation(0, "action", true);
  }
}
