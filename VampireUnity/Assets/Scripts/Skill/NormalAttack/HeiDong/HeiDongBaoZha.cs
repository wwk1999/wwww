using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeiDongBaoZha : MonoBehaviour
{
    public Collider2D attackCollider;
    /// <summary>
    /// 动画事件：检测碰撞体与所有怪物的碰撞
    /// </summary>
    public void CheckCollisionWithMonsters()
    {
        if (attackCollider == null)
        {
            Debug.LogWarning("攻击碰撞体未设置！");
            return;
        }
    
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        attackCollider.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster") || col.CompareTag("Boss"))
            {
                MonsterBase monster = col.transform.parent.GetComponent<MonsterBase>();
                monster.Hurt(GlobalPlayerAttribute.TotalDamage,GameController.S.GetIsCrit());
                var hit = GameController.S.HeiDongPengQueue.Dequeue();
                hit.transform.position = monster.transform.position;
                hit.SetActive(true);
            }
        }
    }
}
