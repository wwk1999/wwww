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
        GameController.S.LuoLeiQueue.Enqueue(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = GameController.S.LuoLeiPengQueue.Dequeue();
            hit.transform.position = closestPoint;
            bool isCrit = GameController.S.GetIsCrit();
            GameController.S.MonsterColliderDic[other].Hurt(GlobalPlayerAttribute.TotalDamage,isCrit);
            hit.SetActive(true);
        }
    }
}
