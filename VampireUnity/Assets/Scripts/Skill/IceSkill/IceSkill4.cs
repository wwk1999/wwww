using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSkill4 : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer render;


    private void OnEnable()
    {
        animator.Play("NewSequenceAnim");
    }
}
