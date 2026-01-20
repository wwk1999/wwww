using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvXuanFen : MonoBehaviour
{
   [NonSerialized] public float damage;
   public Animator animator;
   public Rigidbody2D rg;
   [NonSerialized]public float  damageTime=0.5f;
   [NonSerialized]public float  currentDamageTime=0f;

   private void OnEnable()
   {
      animator.Play("NewSequenceAnim");
      Invoke(nameof(Hide),30);
   }

   public void Hide()
   {
      gameObject.SetActive(false);
      GameController.S.LvXuanFenQueue.Enqueue(this);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.tag == "Player")
      {
         GameController.S.gamePlayer.PlayerHurt(damage,true);
      }
   }
    
   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.tag == "Player")
      {
         currentDamageTime+=Time.deltaTime;
         if (currentDamageTime >= damageTime)
         {
            currentDamageTime = 0;
            GameController.S.gamePlayer.PlayerHurt(damage,true);
         }
      }
   }

   private void Update()
   {
      Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
      rg.velocity = direction.normalized * 0.9f; 
   }
}
