using Spine.Unity;
using UnityEngine;

public class TreeManSkill : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public float damage;
    
    private void OnEnable()
    {
        Invoke(nameof(show), 1f);
    }
    
    private void OnDisable()
    {
        CancelInvoke();
    }

    public void show()
    {
        Debug.LogError("show");
        skeletonAnimation.AnimationState.SetAnimation(0, "action", false);
        Invoke(nameof(Damage), 0.5f);
        Invoke(nameof(DelayHide), 1.5f);
    }

    public void Damage()
    {
        if (Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 1.8f)
        {
            GameController.S.gamePlayer.PlayerHurt(damage, true);
        }
    }

    public void DelayHide()
    {
        gameObject.SetActive(false);
        GameController.S.TreeManSkillQueue.Enqueue(this);
    }
}