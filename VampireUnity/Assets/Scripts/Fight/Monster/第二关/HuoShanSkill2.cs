using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using Unity.VisualScripting;
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
         if (Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position) < 1.2f)
         {
            QueueController.S.gamePlayer.PlayerHurt(damage,true);
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
      CancelInvoke();
      Invoke(nameof(Show),1f);      
      Invoke(nameof(EnQueue),3f);
   }

   public void EnQueue()
   {
      gameObject.SetActive(false);
      QueueController.S.HuoShanSkill2QiQueue.Enqueue(this);
   }
}
