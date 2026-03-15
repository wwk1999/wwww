using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBaoZhaNext : MonoBehaviour
{
    public Animator animator;

    private void OnEnable()
    {
        animator.Play("NewSequenceAnim");
    }
}
