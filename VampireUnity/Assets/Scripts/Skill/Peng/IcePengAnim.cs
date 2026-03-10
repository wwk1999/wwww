using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePengAnim : MonoBehaviour
{
   public void Hide()
   {
      GameController.S.IcePengQueue.Enqueue(gameObject);
      gameObject.SetActive(false);
   }
}
