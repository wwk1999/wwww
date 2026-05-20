using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

public class IceSkill5 : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    public SkeletonAnimation ske;
    public GameObject parent;
    
    private void OnEnable()
    {
        ske.AnimationState.SetAnimation(0, "play", true);
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        parent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = MoveDirection * MoveSpeed;
        StartCoroutine(DelayHide());
        //粒子朝向MoveDirection
    }
    
    IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        QueueController.S.IceSkill5Queue.Enqueue(this);
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            bool isCrit = GameController.S.GetIsCrit();
            QueueController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillConfig.Ice5Damage/100f*SkillController.S.DianYuanSuDamage*(GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillDamage+1.0f),isCrit,DamageFrom.Normal,YuanSuType.Ice);
            Vector2 closestPoint = other.ClosestPoint(transform.position);
            var hit = QueueController.S.IcePengQueue.Dequeue();
            hit.transform.position = closestPoint;
            hit.SetActive(true);
        }
    }
}
