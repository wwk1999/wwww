using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiTri1 : MonoBehaviour
{
   public ShuYaoBoss _Boss;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         _Boss.IsCiTri1 = true;
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         _Boss.IsCiTri1 = false;
      }
   }
}
