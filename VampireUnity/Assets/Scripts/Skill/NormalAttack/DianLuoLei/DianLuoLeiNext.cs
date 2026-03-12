using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianLuoLeiNext : MonoBehaviour
{
    public Animator  Animator;
    public SpriteRenderer SpriteRenderer;

    private void OnEnable()
    {
        Animator.Play("NewSequenceAnim");
    }
}
