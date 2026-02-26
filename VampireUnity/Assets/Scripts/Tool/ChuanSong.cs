using UnityEngine;

public class ChuanSong : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         Debug.Log("点击进入关卡界面");
         WindowController.S.GameLevelWindow.SetActive(true);
         gameObject.SetActive(false);
      }
   }
}
