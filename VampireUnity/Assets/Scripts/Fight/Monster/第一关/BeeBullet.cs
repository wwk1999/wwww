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
        Vector3 direction = Vector2.zero;
        skeletonAnimation.AnimationState.SetAnimation(0, "action", true);
        Invoke(nameof(EnQueue), 5f);
        if (GameController.S.gamePlayer != null)
        {
            direction = (GameController.S.gamePlayer.transform.position - transform.position).normalized;
            //设置枪的位置
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            parent.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            rg.velocity = direction * 7;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.S.gamePlayer.PlayerHurt(damage,false);
            gameObject.SetActive(false);
        }
    }

    public void EnQueue()
    {
        gameObject.SetActive(false);
        GameController.S.BeeBulletQueue.Enqueue(this);
    }
}
