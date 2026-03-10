using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class HeiAnBaoZha : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public SkeletonAnimation ske;
    public GameObject bullet;
    private void OnEnable()
    {
        ske.AnimationState.SetAnimation(0, "fly_58", true);
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取两个碰撞器之间的最近点（世界坐标）
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            Vector2 closestPoint = other.ClosestPoint(transform.position);
            var baozha = GameController.S.HeiAnBaoZhaNextQueue.Dequeue();
            baozha.transform.position = closestPoint;
            baozha.gameObject.SetActive(true);
            GameController.S.HeiAnBaoZhaQueue.Enqueue(gameObject);
            gameObject.SetActive(false);
        }
    }
}
