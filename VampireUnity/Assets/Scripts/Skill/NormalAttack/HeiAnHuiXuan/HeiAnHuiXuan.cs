using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class HeiAnHuiXuan : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public Animator Animator;
    public GameObject bullet;
    private bool isHuiXuan = false;
    private void OnEnable()
    {
        isHuiXuan = false;
        Animator.Play("NewSequenceAnim");
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        Invoke(nameof(Active),0.6f);
    }

    public void Active()
    {
        isHuiXuan=true;
    }

    private void Update()
    {
        if (isHuiXuan)
        {
            rg.velocity=Vector2.zero;
            Vector2 targetPos = QueueController.S.gamePlayer.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, 10 * Time.deltaTime
            );
            Vector2 direction = targetPos - (Vector2)transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        if (Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position) <= 0.1f)
        {
            isHuiXuan = false;
            QueueController.S.HeiAnHuiXuanQueue.Enqueue(this);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        Debug.Log("碰撞点世界坐标: " + closestPoint);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = QueueController.S.HeiAnPengQueue.Dequeue();
            hit.transform.position = closestPoint;
            bool isCrit = GameController.S.GetIsCrit();
            QueueController.S.MonsterColliderDic[other].Hurt(QueueController.S.GameAttack*SkillController.S.HuoYuanSuDamage,isCrit,DamageFrom.NormalAttack,YuanSuType.HeiAn);
            hit.SetActive(true);
        }
    }
}
