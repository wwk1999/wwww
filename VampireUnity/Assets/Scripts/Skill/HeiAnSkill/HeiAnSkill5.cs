using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine.Unity;
using UnityEngine;

public class HeiAnSkill5 : MonoBehaviour
{
   public SkeletonAnimation SkeletonAnimation;
   public Collider2D collider;
   private float timer = 0;
   private void OnEnable()
   {
      timer = 1;
      SkeletonAnimation.AnimationState.SetAnimation(0, "play", true);
      Invoke(nameof(Hide),5f);
   }
   
   public void CheckCollisionWithMonsters()
   {
      // 检测所有重叠的碰撞体
      List<Collider2D> results = new List<Collider2D>();
      ContactFilter2D filter = new ContactFilter2D();
      filter.NoFilter();
      filter.useTriggers = true;
    
      collider.OverlapCollider(filter, results);
    
      // 找出所有怪物并处理
      foreach (Collider2D col in results)
      {
         if (col.gameObject == gameObject) continue;
        
         if (col.CompareTag("Monster") || col.CompareTag("Boss"))
         {
            MonsterBase monster = QueueController.S.MonsterColliderDic[col];
            monster.Hurt(QueueController.S.GameAttack*SkillConfig.HeiAn5Damage/100f*SkillController.S.IceYuanSuDamage*(GlobalPlayerAttribute.FinalChongWuAttribute.HeiAnSkillDamage+1.0f)*(1.0f),GameController.S.GetIsCrit(),DamageFrom.Normal,YuanSuType.HeiAn);
            // var hit = GameController.S.HeiDongPengQueue.Dequeue();
            //hit.transform.position = monster.transform.position;
            //hit.SetActive(true);
         }
      }
   }

   private void Update()
   {
      timer -= Time.deltaTime;
      if (timer > 0.5f)
      {
         timer = 0;
         CheckCollisionWithMonsters();
      }
   }


   public void Hide()
   {
      QueueController.S.HeiAnSkill5Queue.Enqueue(this);
      gameObject.SetActive(false);
   }
}
