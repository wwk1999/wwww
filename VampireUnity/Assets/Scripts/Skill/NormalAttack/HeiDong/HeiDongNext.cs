using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeiDongNext : MonoBehaviour
{
    public Animator animator;
    private void OnEnable()
    {
        animator.Play("HeiDongNext");
        StartCoroutine(DelayHide());
    }
    
    IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        GameController.S.HeiDongNextQueue.Enqueue(gameObject);
    }
}
