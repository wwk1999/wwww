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
        transform.localScale=new Vector3(transform.localScale.x*(1.0f),transform.localScale.y*(1.0f),transform.localScale.z);
        skeletonAnimation.timeScale = 1.5f;
        skeletonAnimation.AnimationState.SetAnimation(0, "action", true);
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
                MonsterBase monster = GameController.S.MonsterColliderDic[col];
                monster.Hurt(GameController.S.GameAttack*SkillConfig.Ice1Damage*SkillController.S.IceYuanSuDamage*(GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillDamage+1.0f)*(1.0f),GameController.S.GetIsCrit(),DamageFrom.Normal,YuanSuType.Ice);
                Vector2 closestPoint = col.ClosestPoint(transform.position);
                var hit = GameController.S.IcePengQueue.Dequeue();
                hit.transform.position = closestPoint;
                hit.SetActive(true);
            }
        }
    }
    
    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "bing")
        {
            CheckCollisionWithMonsters();
        }
    }

    public void Complete(TrackEntry trackEntry)
    {
        GameController.S.IceSkill1Queue.Enqueue(this);
        gameObject.SetActive(false);
        
    }
}
