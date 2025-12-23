using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class TreeManDiLie : MonoBehaviour
{
  public SkeletonAnimation ske;
  public float damage;

  private void OnEnable()
  {
    ske.AnimationState.SetAnimation(0, "animation", false);
    Invoke(nameof(Hide),2f);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      GameController.S.gamePlayer.PlayerHurt(damage,true);
    }
  }

  public void Hide()
  {
    gameObject.SetActive(false);
    GameController.S.TreeManDiLieQueue.Enqueue(this);
  }
}
