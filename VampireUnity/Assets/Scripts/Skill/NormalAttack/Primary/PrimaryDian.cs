using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrimaryDian : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public SkeletonAnimation skeletonAnimation;
    public GameObject bullet;
    private void OnEnable()
    {
        CancelInvoke();
        skeletonAnimation.AnimationState.SetAnimation(0, "dian", true);
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        Invoke(nameof(Hide),2f);
    }
    
    public void Hide()
    {
        QueueController.S.PrimaryDianQueue.Enqueue(this);
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            bool isCrit = GameController.S.GetIsCrit();
            QueueController.S.MonsterColliderDic[other].Hurt(QueueController.S.GameAttack*SkillController.S.IceYuanSuDamage,isCrit,DamageFrom.NormalAttack,YuanSuType.Dian);
            gameObject.SetActive(false);
            QueueController.S.PrimaryDianQueue.Enqueue(this);
            Vector2 closestPoint = other.ClosestPoint(transform.position);
            var hit = QueueController.S.DianPengQueue.Dequeue();
            hit.transform.position = closestPoint;
            hit.SetActive(true);
        }
    }
}
