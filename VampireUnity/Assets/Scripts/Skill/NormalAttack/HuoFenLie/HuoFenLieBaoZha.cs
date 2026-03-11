using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoFenLieBaoZha : MonoBehaviour
{
   public Animator animator;

   private void OnEnable()
   {
      animator.Play("NewSequenceAnim");
   }

   private void Start()
   {
      transform.position = new Vector3(10f, 10f, 0);
   }
}
