using UnityEngine;

public class BossWarning : MonoBehaviour
{
   public void SendCameraMoveToBoss()
   {
       Destroy(transform.parent.gameObject);
   }
}
