using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class HuoSkill4Anim : MonoBehaviour
{
    public Collider2D _collider2D;
    public HuoSkill4 HuoSkill4;
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
                monster.Hurt(QueueController.S.GameAttack*SkillConfig.Huo4Damage/100f*SkillController.S.IceYuanSuDamage*(GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillDamage+1.0f)*(1.0f),GameController.S.GetIsCrit(),DamageFrom.Normal,YuanSuType.Huo);
            }
        }
        
        
    }


    public void Hide()
    {
        QueueController.S.HuoSkill4Queue.Enqueue(HuoSkill4);
        gameObject.SetActive(false);
    }
}
