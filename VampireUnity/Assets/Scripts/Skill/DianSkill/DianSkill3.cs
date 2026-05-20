using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine.Unity;
using UnityEngine;

public class DianSkill3 : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public SkeletonAnimation ske;
    public GameObject bullet;
    
    private void OnEnable()
    {
        ske.AnimationState.SetAnimation(0, "action", true);
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        Invoke(nameof(Hide),3f);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        QueueController.S.DianSkill3Queue.Enqueue(this);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        Debug.Log("碰撞点世界坐标: " + closestPoint);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = QueueController.S.DianQuanPengQueue.Dequeue();
            hit.transform.position = closestPoint;
            bool isCrit = GameController.S.GetIsCrit();
            QueueController.S.MonsterColliderDic[other].zhuoShaoTime = 3.1f;
            QueueController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillConfig.Dian3Damage/100f*(GlobalPlayerAttribute.FinalChongWuAttribute.DianSkillDamage+1.0f)*SkillController.S.DianYuanSuDamage*(1.0f),isCrit,DamageFrom.Normal,YuanSuType.Dian);
            hit.SetActive(true);
        }
    }
}
