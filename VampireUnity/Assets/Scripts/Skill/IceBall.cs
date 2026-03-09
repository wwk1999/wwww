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
            GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.Ice2Damage*SkillController.S.IceYuanSuDamage*(GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillDamage+1.0f),isCrit,DamageFrom.Skill2);
        }
    }
}
