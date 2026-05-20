using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeiDongPro : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public Animator animator;
    private void OnEnable()
    {
        animator.Play("HeiDong");
        rg.velocity = MoveDirection * MoveSpeed;
        StartCoroutine(DelayBaoZha());
    }

    IEnumerator DelayBaoZha()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        QueueController.S.HeiDongQueue.Enqueue(gameObject);
        var heidongnext = QueueController.S.HeiDongNextQueue.Dequeue();
        heidongnext.transform.position = transform.position;
        heidongnext.gameObject.SetActive(true);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = QueueController.S.HeiDongPengQueue.Dequeue();
            hit.transform.position = closestPoint;
            bool isCrit = GameController.S.GetIsCrit();
            QueueController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.HeiAnYuanSuDamage,isCrit,DamageFrom.Normal,YuanSuType.HeiAn);
            hit.SetActive(true);
        }
    }
}
