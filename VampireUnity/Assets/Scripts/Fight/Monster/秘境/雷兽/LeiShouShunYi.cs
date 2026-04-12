using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeiShouShunYi : MonoBehaviour
{
  public Animator Animator;
  public float damage;
  private void Start()
  {
    Animator.Play("LeiShouShunYi",10000,0);
    Invoke(nameof(Destroy1),3f);
  }

  public void Destroy1()
  {
    Destroy(gameObject);
  }
}
