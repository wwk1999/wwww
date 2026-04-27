using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice7Item : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public Animator Animator;
    public GameObject bullet;
    private void OnEnable()
    {
        Animator.Play("NewSequenceAnim");
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        Invoke(nameof(Hide),2f);
    }

    public void Hide()
    {
        GameController.S.Ice7Queue.Enqueue(this);
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        Debug.Log("碰撞点世界坐标: " + closestPoint);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = GameController.S.IcePengQueue.Dequeue();
            hit.transform.position = closestPoint;
            bool isCrit = GameController.S.GetIsCrit();
            GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.HuoYuanSuDamage,isCrit,DamageFrom.Normal,YuanSuType.Ice);
            hit.SetActive(true);
            GameController.S.Ice7Queue.Enqueue(this);
            gameObject.SetActive(false);
        }
    }
}
