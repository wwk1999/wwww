using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class BaoZiSkill2 : MonoBehaviour
{
    public Rigidbody2D rg;
    public Animator Animator;
    [NonSerialized] public Vector2 direction;
    [NonSerialized] public float damage = 0;

    private void OnEnable()
    {
        Animator.Play("NewSequenceAnim");
        Invoke(nameof(EnQueue), 5f);
        rg.velocity = direction * 7;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            QueueController.S.gamePlayer.PlayerHurt(damage,false);
        }
    }

    public void EnQueue()
    {
        gameObject.SetActive(false);
        QueueController.S.BaoZiSkill2Queue.Enqueue(this);
    }
}
