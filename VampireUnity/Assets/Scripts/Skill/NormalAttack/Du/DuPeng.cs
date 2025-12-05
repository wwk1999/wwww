using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuPeng : MonoBehaviour
{
    public Animator animator;

    private void OnEnable()
    {
        animator.Play("DuPeng");
        StartCoroutine(DelayHide());
    }

    IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        GameController.S.DuPengQueue.Enqueue(gameObject);
    }
}
