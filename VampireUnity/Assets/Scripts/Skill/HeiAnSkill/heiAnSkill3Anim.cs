using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heiAnSkill3Anim : MonoBehaviour
{
    public GameObject obj;
    public HeiAnSkill3 HeiAnSkill3;
    public  Collider2D _collider2D;

    public void Hide()
    {
        obj.SetActive(false);
        GameController.S.HeiAnSkill3Queue.Enqueue(HeiAnSkill3);
    }
    
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
                monster.Hurt(GameController.S.GameAttack*2f,GameController.S.GetIsCrit(),DamageFrom.Normal);
                // var hit = GameController.S.HeiDongPengQueue.Dequeue();
                //hit.transform.position = monster.transform.position;
                //hit.SetActive(true);
            }
        }
    }
}
