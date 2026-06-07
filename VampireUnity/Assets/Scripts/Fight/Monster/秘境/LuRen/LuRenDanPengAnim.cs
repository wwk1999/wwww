using UnityEngine;

namespace Fight.Monster.秘境.LuRen
{
    public class LuRenDanPengAnim:MonoBehaviour
    {
        public LuRenDanPeng peng;
        public void Hide()
        {
            QueueController.S.LuRenDanPengQueue.Enqueue(peng);
            peng.gameObject.SetActive(false);
        }
    }
}