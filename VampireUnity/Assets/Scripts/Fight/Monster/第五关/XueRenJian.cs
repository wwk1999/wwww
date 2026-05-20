using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XueRenJian : MonoBehaviour
{
  public Transform attacktrans;
  [NonSerialized] public float damage;
  public Rigidbody2D rb;

  private void OnEnable()
  {
    if(QueueController.S.gamePlayer==null)
    {
      return;
    }
    var dir=(QueueController.S.gamePlayer.transform.position-transform.position).normalized;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    rb.velocity = dir*7f;
    Invoke(nameof(Hide), 3f);
  }

  public void Hide()
  {
    gameObject.SetActive(false);
    QueueController.S.XueRenJianQueue.Enqueue(this);
  }

  private void Update()
  {
    if (Vector2.Distance(attacktrans.position, QueueController.S.gamePlayer.transform.position) <= 0.4f)
    {
      gameObject.SetActive(false);
      QueueController.S.gamePlayer.PlayerHurt(damage,false);
    }
  }
}
