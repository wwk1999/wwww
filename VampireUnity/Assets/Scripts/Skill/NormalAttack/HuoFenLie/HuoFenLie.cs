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
        GameController.S.HuoFenLieQueue.Enqueue(gameObject);
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        Debug.Log("碰撞点世界坐标: " + closestPoint);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = GameController.S.HuoPengQueue.Dequeue();
            hit.transform.position = closestPoint;
            bool isCrit = GameController.S.GetIsCrit();
            GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.HuoYuanSuDamage,isCrit,DamageFrom.Normal);
            hit.SetActive(true);
            GameController.S.HuoFenLieQueue.Enqueue(gameObject);
            var dan1 = GameController.S.HuoFenLieDanQueue.Dequeue();
            dan1.GetComponent<HuoFenLieDan>().dir = 1;
            dan1.transform.position = closestPoint;
            dan1.gameObject.SetActive(true);
            var dan2 = GameController.S.HuoFenLieDanQueue.Dequeue();
            dan2.GetComponent<HuoFenLieDan>().dir = 2;
            dan2.transform.position = closestPoint;
            dan2.gameObject.SetActive(true);
            
            var dan3 = GameController.S.HuoFenLieDanQueue.Dequeue();
            dan3.GetComponent<HuoFenLieDan>().dir = 3;
            dan3.transform.position = closestPoint;
            dan3.gameObject.SetActive(true);
            
            var dan4 = GameController.S.HuoFenLieDanQueue.Dequeue();
            dan4.GetComponent<HuoFenLieDan>().dir = 4;
            dan4.transform.position = closestPoint;
            dan4.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
