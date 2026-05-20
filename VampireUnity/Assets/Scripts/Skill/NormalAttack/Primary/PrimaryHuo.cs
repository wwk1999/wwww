using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;

namespace Skill.NormalAttack.Primary
{
    public class PrimaryHuo:MonoBehaviour
    {
        public Rigidbody2D rg;
        [NonSerialized]public float MoveSpeed;
        [NonSerialized]public Vector2 MoveDirection;
        public SkeletonAnimation ske;
        public GameObject bullet;
        private Vector2 currentMoveDirection;
        private float currentMoveSpeed;
        private bool isInitialized = false;
        
        private void OnEnable()
        {
            // 立即停止所有Invoke，防止之前的Hide调用
            CancelInvoke(nameof(Hide));
            StopAllCoroutines();
            
            // 重置状态
            rg.velocity = Vector2.zero;
            isInitialized = false;
            currentMoveDirection = MoveDirection;
            float angle = Mathf.Atan2(currentMoveDirection.y, currentMoveDirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            // 延迟一帧初始化，确保GunBase.cs已经设置好所有值
            StartCoroutine(DelayedInit());
        }
        
        private IEnumerator DelayedInit()
        {
            // 等待到下一帧，确保GunBase.cs的赋值已经完成
            yield return null;
            
            // 现在安全地读取值
            currentMoveSpeed = MoveSpeed;
            isInitialized = true;
            
            // 检查值是否有效
            if (currentMoveDirection == Vector2.zero || currentMoveSpeed <= 0)
            {
                // 值无效，直接隐藏
                Hide();
                yield break;
            } currentMoveDirection = MoveDirection;
            float angle = Mathf.Atan2(currentMoveDirection.y, currentMoveDirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            
            // 设置动画和旋转
            ske.AnimationState.SetAnimation(0, "fly_48", true);
            
            // 设置速度
            rg.velocity = currentMoveDirection * currentMoveSpeed;
            
            // 启动自动隐藏计时器
            Invoke(nameof(Hide), 2f);
        }
    
        public void Hide()
        {
            // 停止所有协程和Invoke
            StopAllCoroutines();
            CancelInvoke(nameof(Hide));
            
            // 重置物理状态
            rg.velocity = Vector2.zero;
            
            // 重置标记
            isInitialized = false;
            
            // 回收对象
            QueueController.S.PrimaryHuoQueue.Enqueue(this);
            gameObject.SetActive(false);
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Monster") || other.CompareTag("Boss"))
            {
                // 只有在初始化完成后才处理碰撞
                if (!isInitialized) return;
                
                bool isCrit = GameController.S.GetIsCrit();
                QueueController.S.MonsterColliderDic[other].Hurt(QueueController.S.GameAttack * SkillController.S.IceYuanSuDamage, isCrit, DamageFrom.Normal,YuanSuType.Huo);
                
                Hide();
                
                Vector2 closestPoint = other.ClosestPoint(transform.position);
                var hit = QueueController.S.HuoPengQueue.Dequeue();
                hit.transform.position = closestPoint;
                hit.SetActive(true);
            }
        }
        
        private void OnDisable()
        {
            // 确保在禁用时清理所有状态
            StopAllCoroutines();
            CancelInvoke(nameof(Hide));
            rg.velocity = Vector2.zero;
            isInitialized = false;
        }
    }
}