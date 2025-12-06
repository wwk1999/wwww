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
        // 获取当前对象的碰撞器
        Collider2D myCollider = GetComponent<Collider2D>();
    
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
    
        // 或者反过来，获取当前碰撞器到对方碰撞器的最近点
        Vector2 closestPointOnOther = myCollider.ClosestPoint(other.transform.position);
    
        Debug.Log("碰撞点世界坐标: " + closestPoint);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = GameController.S.LuoLeiPengQueue.Dequeue();
            hit.transform.position = closestPointOnOther;
            other.transform.parent.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage);
            hit.SetActive(true);
        }
    }
}
