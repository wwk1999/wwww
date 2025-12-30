using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class XieZiSkill4 : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public Collider2D collider2D;
    [NonSerialized] public float damage;

    private void Start()
    {
        skeletonAnimation.AnimationState.Complete += Complete;
        skeletonAnimation.AnimationState.Event += OnSpineEvent;
    }
    
    
    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "hit")
        {
            CheckCollider();
        }
    }
   
    public void CheckCollider()
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
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Player"))
            {
               GameController.S.gamePlayer.PlayerHurt(damage,true);
            }
        }
    }

    public void Complete(TrackEntry trackEntry)
    {
        gameObject.SetActive(false);
        GameController.S.XieZiSkill4Queue.Enqueue(this);
    }

    private void OnEnable()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, "action", false);
    }
}
