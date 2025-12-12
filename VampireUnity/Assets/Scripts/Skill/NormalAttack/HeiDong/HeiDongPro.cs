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
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        GameController.S.HeiDongQueue.Enqueue(gameObject);
        var heidongnext = GameController.S.HeiDongNextQueue.Dequeue();
        heidongnext.transform.position = transform.position;
        heidongnext.gameObject.SetActive(true);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = GameController.S.HeiDongPengQueue.Dequeue();
            hit.transform.position = closestPoint;
            bool isCrit = GameController.S.GetIsCrit();
            GameController.S.MonsterColliderDic[other].Hurt(GlobalPlayerAttribute.TotalDamage,isCrit,DamageFrom.Normal);
            hit.SetActive(true);
        }
    }
}
