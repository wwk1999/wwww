using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaEYuShuiPenAnim : MonoBehaviour
{
    public DaEYuShuiPen DaEYuShuiPen;
    public Collider2D  Collider;

    public void Hide()
    {
        QueueController.S.DaEYuShuiPenQueue.Enqueue(DaEYuShuiPen);
        DaEYuShuiPen.gameObject.SetActive(false);
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
                QueueController.S.gamePlayer.PlayerHurt(DaEYuShuiPen.damage, true);
            }
        }
    }   
}
