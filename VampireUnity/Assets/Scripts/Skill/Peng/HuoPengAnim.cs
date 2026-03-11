using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoPengAnim : MonoBehaviour
{
   public void Hide()
   {
      GameController.S.HuoPengQueue.Enqueue(gameObject);
      gameObject.SetActive(false);
   }
}
