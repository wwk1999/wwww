using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class FireBaoZha1 : MonoBehaviour
{
   public Animator Animator;
   

   private void OnEnable()
   {
      Animator.Play("NewSequenceAnim");
   }
}
