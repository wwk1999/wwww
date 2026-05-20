using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LvZhuiZong : MonoBehaviour
{
    public Animator animator;
    [NonSerialized] public float damage;
    public Rigidbody2D rg;
    [NonSerialized]public Vector2 MoveDirection;
    [NonSerialized]public float  damageTime=0.5f;
    [NonSerialized]public float  currentDamageTime=0f;


    
    private void OnEnable()
    {
        currentDamageTime = 0;
        animator.Play("NewSequenceAnim");
        rg.velocity = MoveDirection * 7f;
        float random=Random.Range(1f, 1.5f);
        StartCoroutine(Stop(random));
        Invoke("Hide", 8f);
    }

    IEnumerator Stop(float time)
    {
        yield return new WaitForSeconds(time);
        rg.velocity = Vector2.zero;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            QueueController.S.gamePlayer.PlayerHurt(damage,true);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            currentDamageTime+=Time.deltaTime;
            if (currentDamageTime >= damageTime)
            {
                currentDamageTime = 0;
                QueueController.S.gamePlayer.PlayerHurt(damage,true);
            }
        }
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
        QueueController.S.LvZhuiZongQueue.Enqueue(this);
    }
}
