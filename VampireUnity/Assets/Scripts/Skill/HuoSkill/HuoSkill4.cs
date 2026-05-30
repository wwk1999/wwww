using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoSkill4 : MonoBehaviour
{
   public Animator animator;

   private void Awake()
   {
      if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HuoSkill4))
      {
         transform.localScale=new Vector3(transform.localScale.x*(1.15f),transform.localScale.y*(1.15f),transform.localScale.z);
      }
   }

   private void OnEnable()
   {
      animator.Play("NewSequenceAnim");
   }
}
