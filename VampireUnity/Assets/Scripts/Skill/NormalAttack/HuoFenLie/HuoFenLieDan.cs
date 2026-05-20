using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoFenLieDan : MonoBehaviour
{
    public int dir;
    public Rigidbody2D rg;
    public void Jump()
    {
        switch (dir)
        {
            case 1:
                rg.velocity = new Vector2(UnityEngine.Random.Range(-1f, 0f), UnityEngine.Random.Range(2.5f, 3.5f));
                break;
            case 2:
                rg.velocity = new Vector2(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(2.5f, 3.5f));
                break;
            case 3:
                rg.velocity = new Vector2(UnityEngine.Random.Range(-1f, 0f), UnityEngine.Random.Range(1f, 2f));
                break;
            case 4:
                rg.velocity = new Vector2(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(1f, 2f));
                break;
        }
    }

    private void OnEnable()
    {
        Jump();
        Invoke(nameof(BaoZha),0.5f);
    }

    public void BaoZha()
    {
        var baozha = QueueController.S.HuoFenLieBaoZhaQueue.Dequeue().gameObject;
        baozha.transform.position = transform.position;
        baozha.gameObject.SetActive(true);
        QueueController.S.HuoFenLieDanQueue.Enqueue(this);
        gameObject.SetActive(false);
    }
}
