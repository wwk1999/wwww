using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeiShouSkill3 : MonoBehaviour
{
    public Animator Animator;
    public int damage;

    private void OnEnable()
    {
        Animator.Play("NewSequenceAnim",10000,0);
        Invoke(nameof(Hide),2f);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        GameController.S.LeiShouSkill3Queue.Enqueue(this);
    }
    
}
