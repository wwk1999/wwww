using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuangDaoSkill2Anim : MonoBehaviour
{
   public Collider2D Collider2D;
   public ShuangDaoSkill2 ShuangDaoSkill2;

   public void Hide()
   {
      gameObject.SetActive(false);
      GameController.S.ShuangDaoSkill2Queue.Enqueue(ShuangDaoSkill2);
   }
   
   public void CheckCollisionWithMonsters()
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

         if (col.CompareTag("Player"))
         {
            GameController.S.gamePlayer.PlayerHurt(ShuangDaoSkill2.damage, true);
         }
      }
   }   
}
