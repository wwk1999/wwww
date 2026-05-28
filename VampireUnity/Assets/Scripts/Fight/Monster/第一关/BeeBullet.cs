using System;
using Spine.Unity;
using UnityEngine;
using UnityEngine.EventSystems;

public class BeeBullet : MonoBehaviour
{
    public GameObject parent;
    public Rigidbody2D rg;
    public SkeletonAnimation skeletonAnimation;
    [NonSerialized] public float damage = 0;

    private void OnEnable()
    {
        CancelInvoke();
        Vector3 direction = Vector2.zero;
        Invoke(nameof(EnQueue), 3f);
        if (QueueController.S.gamePlayer != null)
        {
            direction = (QueueController.S.gamePlayer.transform.position - transform.position).normalized;
            //设置枪的位置
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            parent.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            rg.velocity = direction * 7;
        }
        skeletonAnimation.AnimationState.SetAnimation(0, "action", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            QueueController.S.gamePlayer.PlayerHurt(damage,false);
            EnQueue();
        }
    }

    public void EnQueue()
    {
        gameObject.SetActive(false);
        QueueController.S.BeeBulletQueue.Enqueue(this);
    }
}
