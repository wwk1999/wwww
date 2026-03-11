using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePen : MonoBehaviour
{
    public Animator  animator;
    public GameObject bullet;
    private void OnEnable()
    {
        animator.Play("NewSequenceAnim");
    }
}
