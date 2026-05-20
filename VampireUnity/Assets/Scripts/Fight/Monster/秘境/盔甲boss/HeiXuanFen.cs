using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeiXuanFen : MonoBehaviour
{
   public Animator animator;
   [NonSerialized] public float damage;
   public Rigidbody2D rg;
   [NonSerialized]public Vector2 MoveDirection;



   private void OnEnable()
   {
      animator.Play("NewSequenceAnim");
      rg.velocity = MoveDirection * 7f;
      Invoke("Hide", 5f);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.tag == "Player")
      {
         QueueController.S.gamePlayer.PlayerHurt(damage,true);
      }
   }

   public void Hide()
   {
      gameObject.SetActive(false);
      QueueController.S.HeiXuanFenQueue.Enqueue(this);
   }
}
