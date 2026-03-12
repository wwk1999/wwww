using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoQuXian : MonoBehaviour
{
    [NonSerialized]public float speed;
    public IEnumerator Move(Vector2 start,Vector2 mid,Vector2 target)
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            Vector2 p1=Vector2.Lerp(start,mid,i);
            Vector2 p2=Vector2.Lerp(mid,target,i);
            Vector2 p=Vector2.Lerp(p1,p2,i);
           yield return StartCoroutine(MoveToPoint(p));
        }
    }

    private void OnEnable()
    {
        Invoke(nameof(Hide),2f);
    }

    public void Hide()
    {
        GameController.S.HuoQuXianQueue.Enqueue(this);
        gameObject.SetActive(false);
    }

    IEnumerator MoveToPoint(Vector2 p)
    {
        while (Vector2.Distance(transform.position,p)>0.1f)
        {
            Vector2 dir=p-new Vector2(transform.position.x,transform.position.y);
            transform.right = dir;
            transform.position=Vector2.MoveTowards(transform.position,p,Time.deltaTime*speed);
        }
        yield return null;
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        Debug.Log("碰撞点世界坐标: " + closestPoint);
        if (other.CompareTag("Monster")||other.CompareTag("Boss"))
        {
            var hit = GameController.S.HuoPengQueue.Dequeue();
            hit.transform.position = closestPoint;
            bool isCrit = GameController.S.GetIsCrit();
            GameController.S.MonsterColliderDic[other].Hurt(GameController.S.GameAttack*SkillController.S.HuoYuanSuDamage,isCrit,DamageFrom.Normal);
            hit.SetActive(true);
            GameController.S.HuoQuXianQueue.Enqueue(this);
            gameObject.SetActive(false);
        }
    }
}
