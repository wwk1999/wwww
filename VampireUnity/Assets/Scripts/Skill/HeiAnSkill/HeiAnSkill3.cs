using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeiAnSkill3 : MonoBehaviour
{
    public Animator animator;

    private void OnEnable()
    {
        animator.Play("NewSequenceAnim");
    }
}
