using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class HuoFenLie : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public SkeletonAnimation ske;
    public GameObject bullet;
    private void OnEnable()
    {
        ske.AnimationState.SetAnimation(0, "play", true);
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        Invoke(nameof(Hide),2f);
    }

    public void Hide()
    {
        QueueController.S.HuoFenLieQueue.Enqueue(this);
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        Debug.Log("碰撞点世界坐标: " + closestPoint);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = QueueController.S.HuoPengQueue.Dequeue();
            hit.transform.position = closestPoint;
            bool isCrit = GameController.S.GetIsCrit();
            QueueController.S.MonsterColliderDic[other].Hurt(QueueController.S.GameAttack*SkillController.S.HuoYuanSuDamage,isCrit,DamageFrom.Normal,YuanSuType.Huo);
            hit.SetActive(true);
            QueueController.S.HuoFenLieQueue.Enqueue(this);
            HuoFenLieDan dan1 = QueueController.S.HuoFenLieDanQueue.Dequeue();
            dan1.dir = 1;
            dan1.transform.position = closestPoint;
            dan1.gameObject.SetActive(true);
            HuoFenLieDan dan2 = QueueController.S.HuoFenLieDanQueue.Dequeue();
            dan2.dir = 2;
            dan2.transform.position = closestPoint;
            dan2.gameObject.SetActive(true);
            
            HuoFenLieDan dan3 = QueueController.S.HuoFenLieDanQueue.Dequeue();
            dan3.dir = 3;
            dan3.transform.position = closestPoint;
            dan3.gameObject.SetActive(true);
            
            HuoFenLieDan dan4 = QueueController.S.HuoFenLieDanQueue.Dequeue();
            dan4.dir = 4;
            dan4.transform.position = closestPoint;
            dan4.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
