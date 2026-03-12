using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoDiPen : MonoBehaviour
{
   public Animator animator;
   public SpriteRenderer  spriteRenderer;

   private void OnEnable()
   {
      animator.Play("NewSequenceAnim");
   }
}
