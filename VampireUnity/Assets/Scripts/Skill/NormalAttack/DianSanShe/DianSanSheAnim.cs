using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianSanSheAnim : MonoBehaviour
{

    public Collider2D Collider2D1;
    public Collider2D Collider2D2;
    public Collider2D Collider2D3;

    
    public void CheckCollider1()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        Collider2D1.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster")||col.CompareTag("Boss"))
            {
                var crit = GameController.S.GetIsCrit();
                QueueController.S.MonsterColliderDic[col].Hurt(QueueController.S.GameAttack*1.5f*SkillController.S.DianYuanSuDamage,crit,DamageFrom.NormalAttack,YuanSuType.Dian);
            }
        }
    }
    
    
    public void CheckCollider2()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        Collider2D2.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster")||col.CompareTag("Boss"))
            {
                var crit = GameController.S.GetIsCrit();
                QueueController.S.MonsterColliderDic[col].Hurt(QueueController.S.GameAttack*1.5f*SkillController.S.DianYuanSuDamage,crit,DamageFrom.NormalAttack,YuanSuType.Dian);
            }
        }
    }
    
    
    
    public void CheckCollider3()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        Collider2D3.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster")||col.CompareTag("Boss"))
            {
                var crit = GameController.S.GetIsCrit();
                QueueController.S.MonsterColliderDic[col].Hurt(QueueController.S.GameAttack*1.5f*SkillController.S.DianYuanSuDamage,crit,DamageFrom.NormalAttack,YuanSuType.Dian);
            }
        }
    }
}
