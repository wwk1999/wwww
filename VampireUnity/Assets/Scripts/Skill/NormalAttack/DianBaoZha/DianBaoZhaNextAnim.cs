using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianBaoZhaNextAnim : MonoBehaviour
{
    public Collider2D collider2D;
    public DianBaoZhaNext DianBaoZhaNext;
    public void Hide()
    {
        QueueController.S.DianBaoZhaNextQueue.Enqueue(DianBaoZhaNext);
        DianBaoZhaNext.gameObject.SetActive(false);
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
                var crit = GameController.S.GetIsCrit();
                QueueController.S.MonsterColliderDic[col].Hurt(QueueController.S.GameAttack*1.5f*SkillController.S.DianYuanSuDamage,crit,DamageFrom.Normal,YuanSuType.Dian);
            }
        }
    }
}
