using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.EventSystems;

public class XuKong : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public Animator animator;
    public GameObject bullet;
    private void OnEnable()
    {
        animator.Play("XuKong");
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        StartCoroutine(DelayHide(gameObject));
        //粒子朝向MoveDirection
    }
    
    IEnumerator DelayHide(GameObject obj)
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
        GameController.S.XuKongQueue.Enqueue(obj);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = GameController.S.XuKongPengQueue.Dequeue();
            hit.SetActive(true);
            hit.transform.position = closestPoint;
            bool isCrit = GameController.S.GetIsCrit();
            GameController.S.MonsterColliderDic[other].Hurt(GlobalPlayerAttribute.TotalDamage,isCrit,DamageFrom.Normal);
        }
    }
}
