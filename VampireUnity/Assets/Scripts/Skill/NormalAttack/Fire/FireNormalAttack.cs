using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class FireNormalAttack : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public Animator animator;
    public GameObject bullet;
    private void OnEnable()
    {
        animator.Play("NewSequenceAnim");
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        //粒子朝向MoveDirection
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var firebaozha = QueueController.S.FireBaoZha1Queue.Dequeue();
            firebaozha.SetActive(true);
            firebaozha.transform.position = closestPoint;
            bool isCrit = GameController.S.GetIsCrit();
            QueueController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.DianYuanSuDamage,isCrit,DamageFrom.Normal,YuanSuType.Huo);
            gameObject.SetActive(false);
            QueueController.S.FireQueue.Enqueue(gameObject);
        }
    }
}
