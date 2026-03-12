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
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            bool isCrit = GameController.S.GetIsCrit();
            GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack,isCrit,DamageFrom.Normal);
        }
    }
}
