using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuangDaoSkill2 : MonoBehaviour
{
    public Animator  Animator;
    [NonSerialized]public float damage;

    private void OnEnable()
    {
        Animator.Play("NewSequenceAnim");
    }
}
