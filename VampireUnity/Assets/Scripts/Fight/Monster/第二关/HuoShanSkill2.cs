using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class HuoShanSkill2 : MonoBehaviour
{
   [NonSerialized] public float damage;
   public SkeletonAnimation skeletonAnimation;

   private void Start()
   {
      skeletonAnimation.AnimationState.Event += OnSpineEvent;
   }

   private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
   {
      if (e.Data.Name == "hit")
      {
         if (Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 1.2f)
         {
            GameController.S.gamePlayer.PlayerHurt(damage,true);
         }
      }
   }

   private void OnDisable()
   {
      CancelInvoke();
   }

   public void Show()
   {
      skeletonAnimation.AnimationState.SetAnimation(0,"action",false);
   }
   private void OnEnable()
   {
      Invoke(nameof(Show),1f);      
      Invoke(nameof(EnQueue),3f);
   }

   public void EnQueue()
   {
      gameObject.SetActive(false);
      GameController.S.HuoShanSkill2QiQueue.Enqueue(this);
   }
}
