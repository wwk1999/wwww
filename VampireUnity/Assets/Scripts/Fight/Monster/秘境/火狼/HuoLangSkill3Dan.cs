using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;

public class HuoLangSkill3Dan : MonoBehaviour
{
   public Rigidbody2D rg;
   public SkeletonAnimation ske;
   public GameObject parent;
   public Transform trans;
   [NonSerialized] public float damage = 0;
   [NonSerialized] public Vector2 pos;

   private void Start()
   {
      Vector2 dir = (pos - new Vector2(transform.position.x,transform.position.y)).normalized;
      float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
      parent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
      rg.velocity = dir * 10;
      ske.AnimationState.SetAnimation(0, "action", true);
   }

   private void Update()
   {
      if (Vector2.Distance(trans.position, pos) <= 0.2f)
      {
         GameObject HuoLangSkill3BaoZha = Instantiate(Resources.Load("Prefabs/Monster/MJ/HuoLang/HuoLangSkill3BaoZha"))as GameObject;
         HuoLangSkill3BaoZha.transform.position = pos;
         Destroy(gameObject);
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         QueueController.S.gamePlayer.PlayerHurt(damage,true);
      }
   }
}
