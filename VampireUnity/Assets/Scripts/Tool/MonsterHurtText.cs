using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHurtText : MonoBehaviour
{
    public Rigidbody2D equipRb;
    public Text text;
    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0,0,UnityEngine.Random.Range(-30f, 30f)));
        equipRb.velocity = new Vector2(UnityEngine.Random.Range(-1.5f, 1.5f), UnityEngine.Random.Range(2f, 4f));
        Invoke(nameof(StopVelocityAfterDelay),0.4f);
    }
    public void StopVelocityAfterDelay()
    {
        equipRb.velocity = Vector2.zero;
        //设置重力为0
        equipRb.gravityScale = 0;
        gameObject.SetActive(false);
        GameController.S.MonsterHurtTextQueue.Enqueue(this);
    }
    
}
