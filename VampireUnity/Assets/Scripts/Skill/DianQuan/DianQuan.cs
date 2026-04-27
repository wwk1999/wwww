using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine;
using Spine.Unity;
using UnityEngine;

public class DianQuan : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public Collider2D collider;
    private bool isAttacking = false;
    private float attackTime = 0.2f;
    private float currentAttackTime = 0.2f;

    private void Start()
    {
        skeletonAnimation.AnimationState.Event += OnSpineEvent;
        skeletonAnimation.AnimationState.Complete += Complete;
    }
    
    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "hit")
        {
            isAttacking=true;
        }
    }

    public void Complete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "action")
        {
            gameObject.SetActive(false);
            GameController.S.DianQuanQueue.Enqueue(gameObject);
        }
    }

    private void OnEnable()
    {
        transform.localScale=new Vector3(transform.localScale.x*(1.0f),transform.localScale.y*(1.0f),transform.localScale.z);
        isAttacking = false;
        skeletonAnimation.AnimationState.SetAnimation(0,"action",false);
    }

    private void Update()
    {
        currentAttackTime += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isAttacking)
        {
            if (other.CompareTag("Monster") || other.CompareTag("Boss"))
            {
                if (currentAttackTime >= attackTime)
                {
                    currentAttackTime = 0;
                    CheckCollisionWithMonsters(collider);
                }
            }
        }
    }
    
    public void CheckCollisionWithMonsters(Collider2D collider2D)
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
            if (col.CompareTag("Monster") || col.CompareTag("Boss"))
            {
                MonsterBase monster = GameController.S.MonsterColliderDic[col];
                monster.Hurt(GameController.S.GameAttack*SkillConfig.Dian1Damage*SkillController.S.DianYuanSuDamage*(GlobalPlayerAttribute.FinalChongWuAttribute.DianSkillDamage+1.0f),GameController.S.GetIsCrit(),DamageFrom.Skill1,YuanSuType.Dian);
                var hit = GameController.S.DianQuanPengQueue.Dequeue();
                hit.transform.position = monster.transform.position;
                hit.SetActive(true);
            }
        }
    }
}
