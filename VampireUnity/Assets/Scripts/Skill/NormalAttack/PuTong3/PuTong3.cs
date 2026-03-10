using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class PuTong3 : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public SkeletonAnimation skeletonAnimation;
    public GameObject bullet;
    private void OnEnable()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, "fly_13", true);
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        Invoke(nameof(EnQueue),3f);
        //粒子朝向MoveDirection
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void EnQueue()
    {
        gameObject.SetActive(false);
        GameController.S.PuTong3Queue.Enqueue(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            bool isCrit = GameController.S.GetIsCrit();
            GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.IceYuanSuDamage,isCrit,DamageFrom.Normal);
            gameObject.SetActive(false);
            Vector2 closestPoint = other.ClosestPoint(transform.position);
            var hit = GameController.S.IcePengQueue.Dequeue();
            hit.transform.position = closestPoint;
            hit.SetActive(true);
        }
    }
}
