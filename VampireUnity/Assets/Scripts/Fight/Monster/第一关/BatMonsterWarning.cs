using UnityEngine;

public class BatMonsterWarning : MonoBehaviour
{
    //bat动画结束开始攻击
    public void AnimationEvent()
    {
        if (!transform.parent.GetComponent<BatMonster>().IsDead)
        {
            transform.parent.GetComponent<BatMonster>().monsterSkeletonAnimation.AnimationState.SetAnimation(0,"attack", false);
            transform.parent.GetComponent<BatMonster>().Speed = 8;
            transform.parent.GetComponent<BatMonster>().MonsterMove();
            Invoke("AttackEnd",0.5f);
        }
    }
    
    
    public void AttackEnd()
    {
        gameObject.SetActive(false);
        MonsterBase monsterBase = transform.parent.GetComponent<BatMonster>();
        monsterBase.IsDash = false;
        monsterBase.Speed = monsterBase.baseSpeed;
    }
}
