using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuoLeiPeng : MonoBehaviour
{
    public Animator animator;

    private void OnEnable()
    {
        animator.Play("LuoLeiPeng");
        StartCoroutine(DelayHide());
    }

    IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        GameController.S.LuoLeiPengQueue.Enqueue(gameObject);
    }
}
