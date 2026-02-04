using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianSkill2Anim : MonoBehaviour
{
    public GameObject obj;
    public DianSkill2 dianSkill2;
    public Collider2D collider11;
    public Collider2D collider12;
    public Collider2D collider13;
    public Collider2D collider21;
    public Collider2D collider22;
    public Collider2D collider23;
    public Collider2D collider31;
    public Collider2D collider32;
    public Collider2D collider33;
    public Collider2D collider41;
    public Collider2D collider42;
    public Collider2D collider43;
    public Collider2D collider44;
    public Collider2D collider45;
    public Collider2D collider51;
    public Collider2D collider52;
    public Collider2D collider53;
    public Collider2D collider54;
    public Collider2D collider55;
    public Collider2D collider56;


    public void Anim1()
    {
        CheckCollisionWithMonsters(collider11);
        CheckCollisionWithMonsters(collider12);
        CheckCollisionWithMonsters(collider13);
    }
    
    public void Anim2()
    {
        CheckCollisionWithMonsters(collider21);
        CheckCollisionWithMonsters(collider22);
        CheckCollisionWithMonsters(collider23);
    }
    
    public void Anim3()
    {
        CheckCollisionWithMonsters(collider31);
        CheckCollisionWithMonsters(collider32);
        CheckCollisionWithMonsters(collider33);
    }
    
    
    public void Anim4()
    {
        CheckCollisionWithMonsters(collider41);
        CheckCollisionWithMonsters(collider42);
        CheckCollisionWithMonsters(collider43);
        CheckCollisionWithMonsters(collider44);
        CheckCollisionWithMonsters(collider45);
    }
    
    
    public void Anim5()
    {
        CheckCollisionWithMonsters(collider51);
        CheckCollisionWithMonsters(collider52);
        CheckCollisionWithMonsters(collider53);
        CheckCollisionWithMonsters(collider54);
        CheckCollisionWithMonsters(collider55);
        CheckCollisionWithMonsters(collider56);
    }


    public void Hide()
    {
        obj.gameObject.SetActive(false);
        GameController.S.DianSkill2Queue.Enqueue(dianSkill2);
    }
    public void CheckCollisionWithMonsters(Collider2D collider2D)
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        collider2D.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster") || col.CompareTag("Boss"))
            {
                MonsterBase monster = GameController.S.MonsterColliderDic[col];
                monster.Hurt(GameController.S.GameAttack*2f,GameController.S.GetIsCrit(),DamageFrom.Normal);
               // var hit = GameController.S.HeiDongPengQueue.Dequeue();
                //hit.transform.position = monster.transform.position;
                //hit.SetActive(true);
            }
        }
    }
}
