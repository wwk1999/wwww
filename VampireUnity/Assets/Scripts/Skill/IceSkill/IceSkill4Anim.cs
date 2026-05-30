using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class IceSkill4Anim : MonoBehaviour
{
    public Collider2D _collider2D;
    public IceSkill4 IceSkill4;
    public void CheckCollisionWithMonsters()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster") || col.CompareTag("Boss"))
            {
                MonsterBase monster = QueueController.S.MonsterColliderDic[col];
                float damage = QueueController.S.GameAttack * SkillConfig.Ice4Damage / 100f *
                               SkillController.S.IceYuanSuDamage *
                               (GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillDamage + 1.0f);
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.IceSkill4))
                {
                    damage *= 1.15f;
                }
                monster.Hurt(damage,GameController.S.GetIsCrit(),DamageFrom.Skill,YuanSuType.Ice);
                Vector2 closestPoint = col.ClosestPoint(transform.position);
                var hit = QueueController.S.IcePengQueue.Dequeue();
                hit.transform.position = closestPoint;
                hit.SetActive(true);
            }
        }
        
        
    }


    public void Hide()
    {
        QueueController.S.IceSkill4Queue.Enqueue(IceSkill4);
        IceSkill4.gameObject.SetActive(false);
    }
}
