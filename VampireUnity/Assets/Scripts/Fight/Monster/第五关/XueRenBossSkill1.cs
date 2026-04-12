using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class XueRenBossSkill1 : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public float Damage;

    private void OnEnable()
    {
        transform.localScale = new Vector3(1, 1, 1);
        var dir=(GameController.S.gamePlayer.transform.position-transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (angle < 0)
        {
            angle += 10;
            transform.localScale = new Vector3(1, -1, 1);
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = dir*10f;
        Invoke(nameof(Hide), 3f);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
        GameController.S.XueRenBossSkill1Queue.Enqueue(this);
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.S.gamePlayer.PlayerHurt(Damage,true);
        }
        if (other.CompareTag("BgEdge"))
        {
            gameObject.SetActive(false);
            GameController.S.XueRenBossSkill1Queue.Enqueue(this);
        }
    }
}
