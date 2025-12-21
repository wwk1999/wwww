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
                        BagController.S.PropList[401].Count--;
                        break;
                    case 402:
                        PlayerData.S.ChiBangEx += 5;
                        BagController.S.PropList[402].Count--;
                        break;
                    case 403:
                        PlayerData.S.ChiBangEx += 25;
                        BagController.S.PropList[403].Count--;
                        break;
                    case 404:
                        PlayerData.S.ChiBangEx += 120;
                        BagController.S.PropList[404].Count--;
                        break;
                    case 405:
                        PlayerData.S.ChiBangEx += 600;
                        BagController.S.PropList[405].Count--;
                        break;
                    case 406:
                        PlayerData.S.ChiBangEx += 3000;
                        BagController.S.PropList[406].Count--;
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