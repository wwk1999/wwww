using System.Collections.Generic;
using UnityEngine;

namespace Fight.Monster.秘境.HuoGuai
{
    public class HuoGuaiQiuBaoZhaAnim:MonoBehaviour
    {
        public HuoGuaiQiuBaoZha HuoGuaiQiuBaoZha;
        public Collider2D  Collider;

        public void Hide()
        {
            QueueController.S.HuoGuaiQiuBaoZhaQueue.Enqueue(HuoGuaiQiuBaoZha);
            HuoGuaiQiuBaoZha.gameObject.SetActive(false);
        }
    
        public void CheckCollisionWithMonsters()
        {
            // 检测所有重叠的碰撞体
            List<Collider2D> results = new List<Collider2D>();
            ContactFilter2D filter = new ContactFilter2D();
            filter.NoFilter();
            filter.useTriggers = true;

            Collider.OverlapCollider(filter, results);

            // 找出所有怪物并处理
            foreach (Collider2D col in results)
            {
                if (col.gameObject == gameObject) continue;

                if (col.CompareTag("Player"))
                {
                    QueueController.S.gamePlayer.PlayerHurt(HuoGuaiQiuBaoZha.damage, true);
                }
            }
        }  
    }
}