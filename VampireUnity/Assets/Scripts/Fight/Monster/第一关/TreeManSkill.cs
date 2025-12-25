using System;
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;


public class TreeManSkill : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public MeshRenderer meshRenderer;
    public float damage;
    private float time = 0;
    private bool isDamaged = false;
    
    private void OnEnable()
    {
        isDamaged=false;
        meshRenderer.sortingOrder=Random.Range(6000,7000);
        time = -1;
        Invoke(nameof(show), 1f);
    }

    private void Update()
    {
        time+= Time.deltaTime;
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void show()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, "action", false);
        Invoke(nameof(DelayHide), 2f);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&time<=0.5f&&time>=0&&isDamaged==false)
        {
            isDamaged=true;
            GameController.S.gamePlayer.PlayerHurt(damage,true);
        }
    }

    public void DelayHide()
    {
        gameObject.SetActive(false);
        GameController.S.TreeManSkillQueue.Enqueue(this);
    }
}