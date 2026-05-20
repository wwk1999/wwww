using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnim : MonoBehaviour
{
    public void Hide()
    {
        gameObject.SetActive(false);
        QueueController.S.FirePengQueue.Enqueue(gameObject);
    }
}
