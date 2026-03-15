using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoYanBaoZhaNext : MonoBehaviour
{
    public Animator animator;

    private void OnEnable()
    {
        animator.Play("NewSequenceAnim");
    }
}
