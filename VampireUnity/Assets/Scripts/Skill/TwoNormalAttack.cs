using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;

public class TwoNormalAttack : MonoBehaviour
{
    public Rigidbody2D rg;
    public SkeletonAnimation skeleton;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    
    [NonSerialized] public float HitTime = 0.5f;
    [NonSerialized] public float CurrentTime = 0f;

    public GameObject parent;

    private void OnEnable()
    {
        rg.velocity = MoveDirection * MoveSpeed;
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        parent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        skeleton.AnimationState.SetAnimation(0, "play", true);
        skeleton.timeScale = 2f;
        StartCoroutine(DelayHide(rg.gameObject));
    }
    
    IEnumerator DelayHide(GameObject obj)
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
        GameController.S.XuKongQueue.Enqueue(obj);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            bool isCrit = GameController.S.GetIsCrit();
            other.transform.parent.GetComponent<MonsterBase>().Hurt(GameController.S.GameAttack*1.5f*SkillController.S.HeiAnYuanSuDamage,isCrit,DamageFrom.Normal);
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime >= HitTime)
            {
                CurrentTime = 0;
                bool isCrit = GameController.S.GetIsCrit();
                GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*1.5f*SkillController.S.HeiAnYuanSuDamage,isCrit,DamageFrom.Normal);
                
            }
        }
        
    }
}
