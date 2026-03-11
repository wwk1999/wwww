using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class Ice4BaoZha : MonoBehaviour
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
        GameController.S.Ice4BaoZhaQueue.Enqueue(this);
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
            GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.HuoYuanSuDamage,isCrit,DamageFrom.Normal);
            hit.SetActive(true);
            GameController.S.Ice4BaoZhaQueue.Enqueue(this);
            var baozha1=GameController.S.Ice4BaoZhaItemQueue.Dequeue();
            baozha1.transform.position = hit.transform.position+new Vector3(0.8f,0,0);
            baozha1.MeshRenderer.sortingOrder = 2001;

            baozha1.gameObject.SetActive(true);
            
            var baozha2=GameController.S.Ice4BaoZhaItemQueue.Dequeue();
            baozha2.transform.position = hit.transform.position+new Vector3(-0.8f,0,0);
            baozha2.MeshRenderer.sortingOrder = 2002;

            baozha2.gameObject.SetActive(true);
            
            var baozha3=GameController.S.Ice4BaoZhaItemQueue.Dequeue();
            baozha3.transform.position = hit.transform.position+new Vector3(0,0.5f,0);
            baozha3.MeshRenderer.sortingOrder = 2003;
            baozha3.gameObject.SetActive(true);
            
            var baozha4=GameController.S.Ice4BaoZhaItemQueue.Dequeue();
            baozha4.transform.position = hit.transform.position+new Vector3(0,-0.5f,0);
            baozha4.gameObject.SetActive(true);
            baozha4.MeshRenderer.sortingOrder = 2000;
            gameObject.SetActive(false);
        }
    }
}
