using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class PlayerJianQi : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public SkeletonAnimation SkeletonAnimation;
    public GameObject parent;
    private void OnEnable()
    {
        SkeletonAnimation.AnimationState.SetAnimation(0, "animation", true);
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        parent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        Invoke(nameof(Hide),3f);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        QueueController.S.PlayerJianQiQueue.Enqueue(this);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = QueueController.S.ZiBaoZhaQueue.Dequeue();
            hit.transform.position = closestPoint;
            bool isCrit = GameController.S.GetIsCrit();
            QueueController.S.MonsterColliderDic[other].Hurt(QueueController.S.GameAttack*SkillController.S.HuoYuanSuDamage,isCrit,DamageFrom.Normal,YuanSuType.Huo);
            hit.SetActive(true);
        }
    }
}
