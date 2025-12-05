using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class HeiDongPeng : MonoBehaviour
{
    public Animator animator;
    private void OnEnable()
    {
        animator.Play("HeiDongPeng");
        StartCoroutine(DelayHide());
    }

    IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        GameController.S.HeiDongPengQueue.Enqueue(gameObject);
    }
}
