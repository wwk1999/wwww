using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class XueRenBossSkill1 : MonoBehaviour
{
    public Rigidbody2D rg;
    [NonSerialized]public int Damage;

    private void OnEnable()
    {
        var dir=(GameController.S.gamePlayer.transform.position-transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rg.velocity = dir*7f;
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
