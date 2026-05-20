using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBaoZhaAnim : MonoBehaviour
{
    public GameObject FireBaoZha;
    public Collider2D collider2D;

    public void Hide()
    {
        FireBaoZha.SetActive(false);
        QueueController.S.FireBaoZha1Queue.Enqueue(FireBaoZha);
    }
    
    
    public void CheckCollider()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        collider2D.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster")||col.CompareTag("Boss"))
            {
                Vector2 closestPoint = col.ClosestPoint(transform.position);
                var hit = QueueController.S.FirePengQueue.Dequeue();
                hit.SetActive(true);
                hit.transform.position = closestPoint;
                var crit = GameController.S.GetIsCrit();
                QueueController.S.MonsterColliderDic[col].Hurt(GameController.S.GameAttack*1.5f*SkillController.S.DianYuanSuDamage,crit,DamageFrom.Normal,YuanSuType.Huo);
            }
        }
    }
}
