using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianSkill5 : MonoBehaviour
{
    public Animator animator;

    private void OnEnable()
    {
        animator.Play("NewSequenceAnim");
    }
}
