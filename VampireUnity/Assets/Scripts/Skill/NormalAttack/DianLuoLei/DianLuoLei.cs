using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class DianLuoLei : MonoBehaviour
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
        GameController.S.DianLuoLeiQueue.Enqueue(this);
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        Debug.Log("碰撞点世界坐标: " + closestPoint);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            bool isCrit = GameController.S.GetIsCrit();
            GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.HuoYuanSuDamage,isCrit,DamageFrom.Normal,YuanSuType.Dian);
            gameObject.SetActive(false);
            var next = GameController.S.DianLuoLeiNextQueue.Dequeue();
            next.transform.position = closestPoint;
            next.SpriteRenderer.sortingOrder = 3003;

            next.gameObject.SetActive(true);
            
            var next1 = GameController.S.DianLuoLeiNextQueue.Dequeue();
            next1.transform.position = closestPoint+new Vector2(0.8f,0);
            next1.SpriteRenderer.sortingOrder = 3001;
            next1.gameObject.SetActive(true);
            
            var next2 = GameController.S.DianLuoLeiNextQueue.Dequeue();
            next2.transform.position = closestPoint+new Vector2(-0.8f,0);
            next2.SpriteRenderer.sortingOrder = 3002;
            next2.gameObject.SetActive(true);
            
            var next3 = GameController.S.DianLuoLeiNextQueue.Dequeue();
            next3.transform.position = closestPoint+new Vector2(0,0.5f);
            next3.SpriteRenderer.sortingOrder = 3004;
            next3.gameObject.SetActive(true);
            
            var next4 = GameController.S.DianLuoLeiNextQueue.Dequeue();
            next4.transform.position = closestPoint+new Vector2(0,-0.5f);
            next1.SpriteRenderer.sortingOrder = 3000;
            next4.gameObject.SetActive(true);
           
            GameController.S.DianLuoLeiQueue.Enqueue(this);
        }
    }
}
