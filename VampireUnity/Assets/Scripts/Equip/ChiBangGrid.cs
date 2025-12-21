using System;
using Config;
using UnityEngine;
using UnityEngine.UI;

namespace Equip
{
    public class ChiBangGrid:MonoBehaviour
    {
        public Button chibangButton;
        [NonSerialized] public int chibangType;
        private void Start()
        {
            chibangButton.onClick.AddListener(() =>
            {
                switch (chibangType)
                {
                    case 401:
                        PlayerData.S.ChiBangEx += 1;
                        break;
                    case 402:
                        PlayerData.S.ChiBangEx += 5;
                        break;
                    case 403:
                        PlayerData.S.ChiBangEx += 25;
                        break;
                    case 404:
                        PlayerData.S.ChiBangEx += 120;
                        break;
                    case 405:
                        PlayerData.S.ChiBangEx += 600;
                        break;
                    case 406:
                        PlayerData.S.ChiBangEx += 3000;
                        break;
                }

                if (PlayerData.S.ChiBangEx > ChiBangConfig.ChiBangExDic[PlayerData.S.ChiBangLevel])
                {
                    PlayerData.S.ChiBangEx -= ChiBangConfig.ChiBangExDic[PlayerData.S.ChiBangLevel];
                    PlayerData.S.ChiBangLevel += 1;
                }
                StoreController.S.SaveStoreData();
                ObserverModuleManager.S.SendEvent("ChiBang");
            });
        }
    }
}