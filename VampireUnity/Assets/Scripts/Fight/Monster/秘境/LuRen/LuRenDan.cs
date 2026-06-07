using System;
using Spine.Unity;
using UnityEngine;

namespace Fight.Monster.秘境.LuRen
{
    public class LuRenDan:MonoBehaviour
    {
        public Rigidbody2D rg;
        [NonSerialized]public float Damage;
        [NonSerialized]public float MoveSpeed=6;
        [NonSerialized]public Vector2 MoveDirection;
        public Animator Animator;
        public GameObject bullet;

        public void Hide()
        {
            QueueController.S.LuRenDanQueue.Enqueue(this);
            gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            CancelInvoke();
            Animator.Play("NewSequenceAnim");
            float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
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
                var hit = QueueController.S.LuRenDanPengQueue.Dequeue();
                hit.transform.position = closestPoint; 
                hit.MoveDirection = MoveDirection;
                hit.gameObject.SetActive(true);
                QueueController.S.gamePlayer.PlayerHurt(Damage,true);
                QueueController.S.LuRenDanQueue.Enqueue(this);
                gameObject.SetActive(false);
                
            }
        }
    }
}