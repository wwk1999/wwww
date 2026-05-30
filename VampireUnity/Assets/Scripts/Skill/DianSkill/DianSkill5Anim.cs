using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class DianSkill5Anim : MonoBehaviour
{
   public DianSkill5 DianSkill5;
   public Collider2D collider;
   public void Hide()
   {
      QueueController.S.DianSkill5Queue.Enqueue(DianSkill5);
      gameObject.SetActive(false);
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
            float damage = QueueController.S.GameAttack * SkillConfig.Dian5Damage / 100f *
                           SkillController.S.IceYuanSuDamage *
                           (GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillDamage + 1.0f);
            if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DianSkill5))
            {
               damage *= 1.15f;
            }
            monster.Hurt(damage,GameController.S.GetIsCrit(),DamageFrom.Skill,YuanSuType.Dian);
            // var hit = GameController.S.HeiDongPengQueue.Dequeue();
            //hit.transform.position = monster.transform.position;
            //hit.SetActive(true);
         }
      }
   }
}
