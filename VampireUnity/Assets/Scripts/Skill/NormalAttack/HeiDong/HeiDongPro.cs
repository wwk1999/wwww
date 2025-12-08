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
        // 获取当前对象的碰撞器
        Collider2D myCollider = GetComponent<Collider2D>();
    
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
    
        // 或者反过来，获取当前碰撞器到对方碰撞器的最近点
        Vector2 closestPointOnOther = myCollider.ClosestPoint(other.transform.position);
    
        Debug.Log("碰撞点世界坐标: " + closestPoint);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = GameController.S.HeiDongPengQueue.Dequeue();
            hit.transform.position = closestPointOnOther;
            bool isCrit = GameController.S.GetIsCrit();
            other.transform.parent.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage,isCrit);
            hit.SetActive(true);
        }
    }
}
