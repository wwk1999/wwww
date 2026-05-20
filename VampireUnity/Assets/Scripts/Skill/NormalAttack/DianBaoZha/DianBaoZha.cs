using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianBaoZha : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public Animator Animator;
    public GameObject bullet;
    private void OnEnable()
    {
        CancelInvoke();
        Animator.Play("NewSequenceAnim");
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        Invoke(nameof(Hide),2f);
    }

    public void Hide()
    {
        QueueController.S.DianBaoZhaQueue.Enqueue(this);
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取两个碰撞器之间的最近点（世界坐标）
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            Vector2 closestPoint = other.ClosestPoint(transform.position);
            bool isCrit = GameController.S.GetIsCrit();
            QueueController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.HuoYuanSuDamage,isCrit,DamageFrom.Normal,YuanSuType.Dian);
            var baozha = QueueController.S.DianBaoZhaNextQueue.Dequeue();
            baozha.transform.position = closestPoint;
            baozha.gameObject.SetActive(true);
            QueueController.S.DianBaoZhaQueue.Enqueue(this);
            gameObject.SetActive(false);
        }
    }
}
