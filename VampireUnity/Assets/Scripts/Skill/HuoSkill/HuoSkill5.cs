using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class HuoSkill5 : MonoBehaviour
{
    public SkeletonAnimation ske;
    public Collider2D _collider2D;
    public MeshRenderer _renderer;

    private void Awake()
    {
        ske.AnimationState.Event += OnSpineEvent;
        ske.AnimationState.Complete += Complete;
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
                monster.Hurt(GameController.S.GameAttack*SkillController.S.Huo5Damage*SkillController.S.IceYuanSuDamage*(GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillDamage+1.0f)*(1.0f),GameController.S.GetIsCrit(),DamageFrom.Normal);
            }
        }
        
        
    }

    private void OnEnable()
    {
        ske.AnimationState.SetAnimation(0, "Enemy_Demon_goat_skill1_BD", false);
    }

    public void Complete(TrackEntry trackEntry)
    {
        GameController.S.HuoSkill5Queue.Enqueue(this);
        gameObject.SetActive(false);
    }
    
    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "damage")
        {
            CheckCollisionWithMonsters();
        }
    }
}
