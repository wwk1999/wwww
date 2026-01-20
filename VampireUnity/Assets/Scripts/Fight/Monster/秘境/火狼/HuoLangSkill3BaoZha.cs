using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoLangSkill3BaoZha : MonoBehaviour
{
   public Animator animator;
   [NonSerialized]public float damage;

   private void Start()
   {
      animator.Play("NewSequenceAnim");
   }
}
