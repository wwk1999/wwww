using System;
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
        private void OnEnable()
        {
            CancelInvoke();
            ske.AnimationState.SetAnimation(0, "fly_48",true);
            float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            rg.velocity = MoveDirection * MoveSpeed;
            Invoke(nameof(Hide),2f);
        }
    
        public void Hide()
        {
            GameController.S.PrimaryHuoQueue.Enqueue(this);
            gameObject.SetActive(false);
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Monster")||other.CompareTag("Boss"))
            {
                bool isCrit = GameController.S.GetIsCrit();
                GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.IceYuanSuDamage,isCrit,DamageFrom.Normal);
                gameObject.SetActive(false);
                GameController.S.PrimaryHuoQueue.Enqueue(this);
                Vector2 closestPoint = other.ClosestPoint(transform.position);
                var hit = GameController.S.HuoPengQueue.Dequeue();
                hit.transform.position = closestPoint;
                hit.SetActive(true);
            }
        }
    }
}