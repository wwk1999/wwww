using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class DianPeng : MonoBehaviour
{
  public SkeletonAnimation Skeleton;

  private void Start()
  {
    Skeleton.AnimationState.Complete += Complete;
  }

  public void Complete(TrackEntry trackEntry)
  {
    if (trackEntry.Animation.Name == "action")
    {
      gameObject.SetActive(false);
      GameController.S.DianQuanPengQueue.Enqueue(gameObject);
    }
  }

  private void OnEnable()
  {
    Skeleton.AnimationState.SetAnimation(0, "action",false);
  }
}
