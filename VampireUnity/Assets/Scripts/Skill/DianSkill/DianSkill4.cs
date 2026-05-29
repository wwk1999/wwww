using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine.Unity;
using UnityEngine;

public class DianSkill4 : MonoBehaviour
{
   public Animator animator;
   public SkeletonAnimation skeleton;
   public Collider2D collider;
   private float time = 0;

   
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
            monster.Hurt(QueueController.S.GameAttack*SkillConfig.Dian4Damage/100f*SkillController.S.IceYuanSuDamage*(GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillDamage+1.0f)*(1.0f),GameController.S.GetIsCrit(),DamageFrom.Skill,YuanSuType.Dian);
            // var hit = GameController.S.HeiDongPengQueue.Dequeue();
            //hit.transform.position = monster.transform.position;
            //hit.SetActive(true);
         }
      }
   }

   private void Update()
   {
      time+= Time.deltaTime;
      if (time > 0.4f)
      {
         time = 0;
         CheckCollisionWithMonsters();
      }
   }

   private void OnEnable()
   {
      time = 1;
      animator.Play("DianSkill4Enter");
      skeleton.AnimationState.SetAnimation(0, "play",true);
      Invoke(nameof(Hide),2f);
   }

   public void Hide()
   {
      QueueController.S.DianSkill4Queue.Enqueue(this);
      gameObject.SetActive(false);
   }
   
}
