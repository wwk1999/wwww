using System;
using UnityEngine;

namespace Fight.Monster.秘境.HuoGuai
{
    public class HuoGuaiQiu:MonoBehaviour
    {
        public Rigidbody2D rg;
        [NonSerialized]public float Damage;
        [NonSerialized]public float MoveSpeed=7;
        [NonSerialized]public Vector2 MoveDirection;
        public Animator Animator;
        [NonSerialized] public Vector2 targetPos;
        public void Hide()
        {
            QueueController.S.HuoGuaiQiuQueue.Enqueue(this);
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Vector2.Distance(transform.position, targetPos) <= 0.1f)
            {
                var baozha=QueueController.S.HuoGuaiQiuBaoZhaQueue.Dequeue();
                baozha.transform.position = transform.position;
                baozha.damage = Damage * 1.2f;
                baozha.gameObject.SetActive(true);
                Hide();
            }
        }

        private void OnEnable()
        {
            CancelInvoke();
            Animator.Play("NewSequenceAnim");
            rg.velocity = MoveDirection * MoveSpeed;
            Invoke(nameof(Hide),3);
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            // 获取两个碰撞器之间的最近点（世界坐标）
            Vector2 closestPoint = other.ClosestPoint(transform.position);
            Debug.Log("碰撞点世界坐标: " + closestPoint);
            if (other.CompareTag("Player"))
            {
                QueueController.S.gamePlayer.PlayerHurt(Damage,true);
            }
        }
    }
}