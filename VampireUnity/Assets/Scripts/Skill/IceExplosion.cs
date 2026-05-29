using System;
using Config;
using Spine;
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

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
      QueueController.S.IceExQueue.Enqueue(this);
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
         QueueController.S.MonsterColliderDic[other].Hurt(QueueController.S.GameAttack*SkillConfig.Ice3Damage/100f*damageCount*SkillController.S.IceYuanSuDamage*(GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillDamage+1.0f)*(1.0f),isCrit,DamageFrom.Skill,YuanSuType.Ice);
         Vector2 closestPoint = other.ClosestPoint(transform.position);
         var hit = QueueController.S.IcePengQueue.Dequeue();
         hit.transform.position = closestPoint;
         hit.SetActive(true);
      }
   }
}
