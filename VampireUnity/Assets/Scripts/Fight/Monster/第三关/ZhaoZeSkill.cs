using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;
using Random = System.Random;

public class ZhaoZeSkill : MonoBehaviour
{
    public SkeletonAnimation  skeletonAnimation;
    public MeshRenderer MeshRenderer;
    public Collider2D tri;
    [NonSerialized] public float damage; 


    private void Start()
    {
        MeshRenderer.sortingOrder=new Random().Next(4000,5000);
        skeletonAnimation.AnimationState.Complete += OnAnimationComplete;
        skeletonAnimation.AnimationState.Event += OnSpineEvent;
    }

    public void CheckDamage()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        tri.OverlapCollider(filter, results);
    
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
    
    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "hit")
        {
            CheckDamage();
        }
    }

    public void OnAnimationComplete(TrackEntry trackEntry)
    {
        GameController.S.ZhaoZeSkillQueue.Enqueue(this);
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, "action", false);
    }
}
