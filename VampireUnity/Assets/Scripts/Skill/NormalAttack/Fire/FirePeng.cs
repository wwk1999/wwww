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
        StartCoroutine(DelayHide());
    }

    IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        QueueController.S.FirePengQueue.Enqueue(gameObject);
    }
}
