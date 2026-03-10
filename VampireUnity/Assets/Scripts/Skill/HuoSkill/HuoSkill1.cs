using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class HuoSkill1 : MonoBehaviour
{
  public Rigidbody2D rg;
  [NonSerialized]public float MoveSpeed;
  [NonSerialized]public Vector2 MoveDirection;
  public SkeletonAnimation ske;
  public GameObject bullet;  
  
  private void OnEnable()
  {
    ske.AnimationState.SetAnimation(0, "fly_22", true);
    float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
    bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    rg.velocity = MoveDirection * MoveSpeed;
    Invoke(nameof(Hide),3f);
  }

  public void Hide()
  {
    gameObject.SetActive(false);
    GameController.S.HuoSkill1Queue.Enqueue(this);
  }
    
  private void OnTriggerEnter2D(Collider2D other)
  {
    // 获取两个碰撞器之间的最近点（世界坐标）
    Vector2 closestPoint = other.ClosestPoint(transform.position);
    Debug.Log("碰撞点世界坐标: " + closestPoint);
    if (other.CompareTag("Monster")||other.CompareTag("Boss"))
    {
      var hit = GameController.S.DuPengQueue.Dequeue();
      hit.transform.position = closestPoint;
      bool isCrit = GameController.S.GetIsCrit();
      GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.Huo1Damage*(GlobalPlayerAttribute.FinalChongWuAttribute.HuoSkillDamage+1.0f)*SkillController.S.HuoYuanSuDamage*(1.0f),isCrit,DamageFrom.Skill1);
      hit.SetActive(true);
    }
  }
  
}
