using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class ZhaoZeBossAttack : MonoBehaviour
{
   public MonsterBase monsterBase;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         monsterBase.isAttack=true;
      }
   }
   
   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         monsterBase.isAttack=false;
      }
   }
}
