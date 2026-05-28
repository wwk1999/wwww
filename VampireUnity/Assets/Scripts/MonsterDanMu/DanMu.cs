using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanMu : MonoBehaviour
{
   public SpriteRenderer image;
   [NonSerialized] public Vector3 dir;
   [NonSerialized] public float size=0.35f;
   [NonSerialized] public float attack;
   [NonSerialized] public bool isBoss;


   private void OnEnable()
   {
      CancelInvoke();
      Invoke(nameof(Hide),5f);
   }

   public void Hide()
   {
      QueueController.S.DanMuQueue.Enqueue(this);
      gameObject.SetActive(false);
   }


   public void SetDanMu(Sprite sprite,float attack,Vector3 dir,bool isBoss)
   {
      this.attack = attack;
      image.sprite=sprite;
      this.dir = dir;
      this.isBoss = isBoss;
   }

   private void Update()
   {
      transform.position += dir * 4 * Time.deltaTime;
      if (Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position) <= size)
      {
         QueueController.S.gamePlayer.PlayerHurt(attack,isBoss);
         QueueController.S.DanMuQueue.Enqueue(this);
         gameObject.SetActive(false);
      }
   }
}
