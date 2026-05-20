using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoLangSkill3Anim : MonoBehaviour
{
    public Collider2D collider;
    public HuoLangSkill3BaoZha HuoLangSkill3BaoZha;


    public void CheckCollisionWithMonsters()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;

        collider.OverlapCollider(filter, results);

        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;

            if (col.CompareTag("Player"))
            {
                QueueController.S.gamePlayer.PlayerHurt(HuoLangSkill3BaoZha.damage, true);
            }
        }
    }

    public void Hide()
    {
        Destroy(gameObject);
    }
}
