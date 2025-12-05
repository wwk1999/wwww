using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class FirePeng : MonoBehaviour
{
    public Animator animator;

    private void OnEnable()
    {
        animator.Play("FirePengAnim");
    }
}
