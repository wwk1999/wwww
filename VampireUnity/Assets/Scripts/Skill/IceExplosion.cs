using System;
using Spine;
using Spine.Unity;
using UnityEngine;

public class IceExplosion : MonoBehaviour
{
   public Animator animator;
   public SkeletonAnimation skeletonAnimation;
   [NonSerialized] public float damageCount = 1;

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
      transform.localScale=new Vector3(transform.localScale.x*(1.0f),transform.localScale.y*(1.0f),transform.localScale.z);
      skeletonAnimation.AnimationState.SetAnimation(0, "animation", false);
   }
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Monster")||other.CompareTag("Boss"))
      {
         bool isCrit = GameController.S.GetIsCrit();
         GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.Ice3Damage*damageCount*SkillController.S.IceYuanSuDamage*(GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillDamage+1.0f)*(1.0f),isCrit,DamageFrom.Skill3);
      }
   }
}
