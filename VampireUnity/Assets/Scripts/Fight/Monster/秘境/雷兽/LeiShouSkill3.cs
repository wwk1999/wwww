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
        Animator.Play("NewSequenceAnim",0,0);
    }
    
    
}
