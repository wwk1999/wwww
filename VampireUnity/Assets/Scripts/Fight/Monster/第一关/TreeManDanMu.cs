using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class TreeManDanMu : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public float damage;
    [NonSerialized]public Vector2 MoveDirection;
    public SkeletonAnimation ske;
    public GameObject bullet;
    private void OnEnable()
    {
        CancelInvoke();
        ske.AnimationState.SetAnimation(0, "du", true);
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        Invoke(nameof(Hide),3f);
    }

    public void Hide()
    {
        GameController.S.TreeManDanMuQueue.Enqueue(this);
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        Debug.Log("碰撞点世界坐标: " + closestPoint);
        if (other.CompareTag("Player"))
        {
            GameController.S.gamePlayer.PlayerHurt(damage,true);
            gameObject.SetActive(false);
        }
    }
}
