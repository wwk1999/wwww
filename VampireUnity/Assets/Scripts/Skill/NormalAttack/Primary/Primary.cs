using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

public class Primary : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public SkeletonAnimation ske;
    public GameObject bullet;
    private void OnEnable()
    {
        CancelInvoke();
        ske.AnimationState.SetAnimation(0, "fly_10", true);
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        Invoke(nameof(Hide),2f);
    }

    public void Hide()
    {
        GameController.S.PrimaryQueue.Enqueue(gameObject);
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            bool isCrit = GameController.S.GetIsCrit();
            GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.IceYuanSuDamage,isCrit,DamageFrom.Normal,YuanSuType.Ice);
            gameObject.SetActive(false);
            GameController.S.PrimaryQueue.Enqueue(gameObject);
            Vector2 closestPoint = other.ClosestPoint(transform.position);
            var hit = GameController.S.IcePengQueue.Dequeue();
            hit.transform.position = closestPoint;
            hit.SetActive(true);
        }
    }
}
