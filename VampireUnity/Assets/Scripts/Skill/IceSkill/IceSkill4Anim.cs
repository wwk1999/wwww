using System.Collections;
using System.Collections.Generic;
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
                MonsterBase monster = GameController.S.MonsterColliderDic[col];
                monster.Hurt(GameController.S.GameAttack*SkillController.S.Ice4Damage*SkillController.S.IceYuanSuDamage*(GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillDamage+1.0f)*(1.0f),GameController.S.GetIsCrit(),DamageFrom.Normal);
            }
        }
        
        
    }


    public void Hide()
    {
        GameController.S.IceSkill4Queue.Enqueue(IceSkill4);
        gameObject.SetActive(false);
    }
}
