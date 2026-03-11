using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class Ice4BaoZhaItem : MonoBehaviour
{
   public SkeletonAnimation SkeletonAnimation;
   public Collider2D Collider2D;
   public MeshRenderer MeshRenderer;

   
   public void CheckCollider()
   {
      // 检测所有重叠的碰撞体
      List<Collider2D> results = new List<Collider2D>();
      ContactFilter2D filter = new ContactFilter2D();
      filter.NoFilter();
      filter.useTriggers = true;
    
      Collider2D.OverlapCollider(filter, results);
    
      // 找出所有怪物并处理
      foreach (Collider2D col in results)
      {
         if (col.gameObject == gameObject) continue;
        
         if (col.CompareTag("Monster")||col.CompareTag("Boss"))
         {
            var crit = GameController.S.GetIsCrit();
            GameController.S.MonsterColliderDic[col].Hurt(GameController.S.GameAttack*1.5f*SkillController.S.DianYuanSuDamage,crit,DamageFrom.Normal);
         }
      }
   }
   public void Hide()
   {
      GameController.S.Ice4BaoZhaItemQueue.Enqueue(this);
      gameObject.SetActive(false);
   }

   private void OnDestroy()
   {
      SkeletonAnimation.AnimationState.Complete -= Complete;
      SkeletonAnimation.AnimationState.Event -= OnSpineEvent;
   }

   private void Start()
   {
      SkeletonAnimation.AnimationState.Complete += Complete;
      SkeletonAnimation.AnimationState.Event += OnSpineEvent;
   }

   private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
   {
      if (e.Data.Name == "hit")
      {
         CheckCollider();
      }
   }

   
   public void Complete(TrackEntry trackEntry)
   {
      Hide();
   }
}
