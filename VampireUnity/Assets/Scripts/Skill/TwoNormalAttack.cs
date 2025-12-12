using System;
using System.Collections;
using UnityEngine;

public class TwoNormalAttack : MonoBehaviour
{
    public Rigidbody2D rg;
    public ParticleSystem ps;
    [NonSerialized]public float MoveSpeed;
    [NonSerialized]public Vector2 MoveDirection;
    
    [NonSerialized] public float HitTime = 0.5f;
    [NonSerialized] public float CurrentTime = 0f;

    private void OnEnable()
    {
        rg.velocity = MoveDirection * MoveSpeed;
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
            other.transform.parent.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage,isCrit,DamageFrom.Normal);
            
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
                GameController.S.MonsterColliderDic[other].Hurt(GlobalPlayerAttribute.TotalDamage,isCrit,DamageFrom.Normal);
                
            }
        }
        
    }
}
