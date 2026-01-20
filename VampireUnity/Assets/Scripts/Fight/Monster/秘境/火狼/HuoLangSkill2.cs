using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoLangSkill2 : MonoBehaviour
{
   public Animator animator;
   [NonSerialized]public float damage;

   private void OnEnable()
   {
      animator.Play("NewSequenceAnim");
   }
}
