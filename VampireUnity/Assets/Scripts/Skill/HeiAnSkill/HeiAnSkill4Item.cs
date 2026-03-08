using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class HeiAnSkill4Item : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;

    private void Update()
    {
        transform.localPosition = Vector3.zero;
    }

    private void OnEnable()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            bool isCrit = GameController.S.GetIsCrit();
            GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.DianYuanSuDamage,isCrit,DamageFrom.Normal);
        }
    }
}
