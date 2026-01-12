using System;
using Spine;
using Spine.Unity;
using UnityEngine;

public class IceExplosion : MonoBehaviour
{
   public Animator animator;
   public SkeletonAnimation skeletonAnimation;

   private void Start()
   {
      skeletonAnimation.AnimationState.Complete += Complete;
   }

   public void Complete(TrackEntry trackEntry)
   {
      gameObject.SetActive(false);
      GameController.S.IceExQueue.Enqueue(this);
   }

   private void OnDestroy()
   {
      skeletonAnimation.AnimationState.Complete -= Complete;
   }


   private void OnEnable()
   {
      animator.Play("IceEx",1,0);
      skeletonAnimation.AnimationState.SetAnimation(0, "animation", false);
   }
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Monster")||other.CompareTag("Boss"))
      {
         bool isCrit = GameController.S.GetIsCrit();
         GameController.S.MonsterColliderDic[other].Hurt(GlobalPlayerAttribute.TotalDamage,isCrit,DamageFrom.Skill3);
      }
   }
}
