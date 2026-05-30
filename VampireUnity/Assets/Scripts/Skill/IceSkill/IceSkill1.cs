using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine;
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

public class IceSkill1 : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;

    public Collider2D _collider2D;
    private void OnEnable()
    {
        skeletonAnimation.timeScale = 1.5f;
        skeletonAnimation.AnimationState.SetAnimation(0, "action", true);
    }
    
    private void Awake()
    {
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.IceSkill1))
        {
            transform.localScale=new Vector3(transform.localScale.x*(1.15f),transform.localScale.y*(1.15f),transform.localScale.z);
        }
    }

    private void Start()
    {
        skeletonAnimation.AnimationState.Event += OnSpineEvent;
        skeletonAnimation.AnimationState.Complete += Complete;
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
                MonsterBase monster = QueueController.S.MonsterColliderDic[col];
                float damage = QueueController.S.GameAttack * SkillConfig.Ice1Damage / 100f *
                               SkillController.S.IceYuanSuDamage *
                               (GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillDamage + 1.0f) ;
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.IceSkill1))
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
    
    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "hit")
        {
            CheckCollisionWithMonsters();
        }
    }

    public void Complete(TrackEntry trackEntry)
    {
        QueueController.S.IceSkill1Queue.Enqueue(this);
        gameObject.SetActive(false);
        
    }
}
