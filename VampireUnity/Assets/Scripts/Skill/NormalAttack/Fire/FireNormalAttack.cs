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
    public SkeletonAnimation skeletonAnimation;
    public GameObject bullet;
    private void OnEnable()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, "action", true);
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        //粒子朝向MoveDirection
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取当前对象的碰撞器
        Collider2D myCollider = GetComponent<Collider2D>();
    
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
    
        // 或者反过来，获取当前碰撞器到对方碰撞器的最近点
        Vector2 closestPointOnOther = myCollider.ClosestPoint(other.transform.position);
    
        Debug.Log("碰撞点世界坐标: " + closestPoint);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = GameController.S.FirePengQueue.Dequeue();
            hit.SetActive(true);
            hit.transform.position = closestPointOnOther;
            bool isCrit = GameController.S.GetIsCrit();
            other.transform.parent.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage,isCrit);
            gameObject.SetActive(false);
            GameController.S.FireQueue.Enqueue(gameObject);
        }
    }
}
