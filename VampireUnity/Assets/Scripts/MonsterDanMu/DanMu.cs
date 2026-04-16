using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanMu : MonoBehaviour
{
   public SpriteRenderer image;
   [NonSerialized] public Vector3 dir;
   [NonSerialized] public float size;
   [NonSerialized] public float speed;
   [NonSerialized] public float attack;
   [NonSerialized] public bool isBoss;


   private void OnEnable()
   {
      CancelInvoke();
      Invoke(nameof(Hide),2f);
   }

   public void Hide()
   {
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
      transform.position+=dir*speed;
      if (Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) <= size)
      {
         GameController.S.gamePlayer.PlayerHurt(attack,isBoss);
         gameObject.SetActive(false);
      }
   }
}
