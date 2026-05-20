using System;
using UnityEngine;

public class CircleAttack : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Animator>().Play("CircleAttack");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        QueueController.S.CircleQueue.Enqueue(this);
    }
}
