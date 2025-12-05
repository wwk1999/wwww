using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class FireNormalAttack : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public SkeletonAnimation skeletonAnimation;
    public GameObject bullet;
    private void OnEnable()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, "action", true);
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        //粒子朝向MoveDirection
    }
    private void Update()
    {
       
        //粒子朝向MoveDirection
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = GameController.S.FirePengQueue.Dequeue();
            hit.SetActive(true);
            hit.transform.position = transform.position;
            other.transform.parent.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage);
            gameObject.SetActive(false);
        }
    }
}
