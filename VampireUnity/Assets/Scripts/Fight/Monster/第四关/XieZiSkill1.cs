using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class XieZiSkill1 : MonoBehaviour
{
   public Rigidbody2D rg;
   public SkeletonAnimation skeletonAnimation;
   [NonSerialized]public Vector2 MoveDirection;
   [NonSerialized]public int Damage;

   private void OnEnable()
   {
      skeletonAnimation.AnimationState.SetAnimation(0, "idle", true);
      rg.velocity = MoveDirection * 5f;
   }
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         GameController.S.gamePlayer.PlayerHurt(Damage,true);
      }
      if (other.CompareTag("BgEdge"))
      {
         gameObject.SetActive(false);
         GameController.S.XieZiSkill1Queue.Enqueue(this);
      }
   }
}
