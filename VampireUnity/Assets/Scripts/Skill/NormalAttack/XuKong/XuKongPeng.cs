using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class XuKongPeng : MonoBehaviour
{
   public SkeletonAnimation skeleton;

   private void OnEnable()
   {
      skeleton.AnimationState.SetAnimation(0, "action",false);
      StartCoroutine(DelayHide());
   }

   IEnumerator DelayHide()
   {
      yield return new WaitForSeconds(2f);
      gameObject.SetActive(false);
      
   }
}
