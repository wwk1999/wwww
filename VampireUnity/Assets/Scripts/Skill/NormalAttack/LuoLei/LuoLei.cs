using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuoLei : MonoBehaviour
{
    public Animator animator;
    public Vector2 position;
    private void OnEnable()
    {
        transform.position = position;
        animator.Play("LuoLei");
        StartCoroutine(DelayHide());
    }

    IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        QueueController.S.LuoLeiQueue.Enqueue(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            bool isCrit = GameController.S.GetIsCrit();
            QueueController.S.MonsterColliderDic[other].Hurt(QueueController.S.GameAttack,isCrit,DamageFrom.Normal,YuanSuType.Dian);
        }
    }
}
