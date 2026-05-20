using System;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;


public class TreeManSkillAnim : MonoBehaviour
{
    public TreeManSkill TreeManSkill;
    public Collider2D  Collider;

    public void Hide()
    {
        QueueController.S.TreeManSkillQueue.Enqueue(TreeManSkill);
        TreeManSkill.gameObject.SetActive(false);
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
                QueueController.S.gamePlayer.PlayerHurt(TreeManSkill.damage, true);
            }
        }
    }   
    
}