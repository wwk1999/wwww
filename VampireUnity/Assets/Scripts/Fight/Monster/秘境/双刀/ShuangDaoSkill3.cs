using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuangDaoSkill3 : MonoBehaviour
{
  public Rigidbody2D rg;
  public Animator  animator;
  [NonSerialized]public Vector2 dir;
  [NonSerialized] public float damage;

  private void OnEnable()
  {
    animator.Play("NewSequenceAnim");
  }

  private void Update()
  {
    rg.velocity = dir*8f;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      QueueController.S.gamePlayer.PlayerHurt(damage,true);
    }

    if (other.CompareTag("BgEdge"))
    { 
      QueueController.S.ShuangDaoSkill3Queue.Enqueue(this);
      gameObject.SetActive(false);
    }
  }
}
