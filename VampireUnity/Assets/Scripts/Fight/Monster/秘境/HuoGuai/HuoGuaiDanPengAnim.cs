using UnityEngine;

namespace Fight.Monster.秘境.LuRen
{
    public class HuoGuaiDanPengAnim:MonoBehaviour
    {
        public HuoGuaiDanPeng peng;
        public void Hide()
        {
            QueueController.S.HuoGuaiDanPengQueue.Enqueue(peng);
            peng.gameObject.SetActive(false);
        }
    }
}