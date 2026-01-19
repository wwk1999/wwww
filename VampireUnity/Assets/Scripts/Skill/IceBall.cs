using System;
using Spine.Unity;
using UnityEngine;

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
            GameController.S.MonsterColliderDic[other].Hurt(GlobalPlayerAttribute.TotalDamage*2f,isCrit,DamageFrom.Skill2);
        }
    }
}
