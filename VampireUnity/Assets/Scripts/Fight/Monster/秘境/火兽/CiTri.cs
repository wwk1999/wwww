using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiTri : MonoBehaviour
{
   public HuoShouBoss _huoShouBoss;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         _huoShouBoss.IsCiTri = true;
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         _huoShouBoss.IsCiTri = false;
      }
   }
}
