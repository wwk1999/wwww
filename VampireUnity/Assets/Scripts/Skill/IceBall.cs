using System;
using Config;
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

public class IceBall : MonoBehaviour
{
    public SkeletonAnimation Skeleton;
    private void OnEnable()
    {
        Skeleton.AnimationState.SetAnimation(0, "animation", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            bool isCrit = GameController.S.GetIsCrit();
            QueueController.S.MonsterColliderDic[other].Hurt(QueueController.S.GameAttack*SkillConfig.Ice2Damage/100f*SkillController.S.IceYuanSuDamage*(GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillDamage+1.0f),isCrit,DamageFrom.Skill,YuanSuType.Ice);
            Vector2 closestPoint = other.ClosestPoint(other.transform.position);
            var hit = QueueController.S.IcePengQueue.Dequeue();
            hit.transform.position = closestPoint;
            hit.SetActive(true);
        }
    }
}
