using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class Du : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public SkeletonAnimation ske;
    public GameObject bullet;
    private void OnEnable()
    {
        ske.AnimationState.SetAnimation(0, "fly_48", true);
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        Debug.Log("碰撞点世界坐标: " + closestPoint);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = QueueController.S.DuPengQueue.Dequeue();
            hit.transform.position = closestPoint;
            bool isCrit = GameController.S.GetIsCrit();
            QueueController.S.MonsterColliderDic[other].zhuoShaoTime = 3.1f;
            QueueController.S.MonsterColliderDic[other].Hurt(QueueController.S.GameAttack*SkillController.S.HuoYuanSuDamage,isCrit,DamageFrom.Normal,YuanSuType.Huo);
            hit.SetActive(true);
            gameObject.SetActive(false);
            QueueController.S.DuQueue.Enqueue(gameObject);
        }
    }
}
