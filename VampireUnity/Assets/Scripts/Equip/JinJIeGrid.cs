using System;
using UnityEngine;
using UnityEngine.UI;

namespace Equip
{
    public class JinJIeGrid: MonoBehaviour
    {
        [NonSerialized]public EquipTable equipTable;
        public Button imageButton;

        private void Start()
        {
            imageButton.onClick.AddListener(() =>
            {
                ObserverModuleManager.S.SendEvent("JinJie",equipTable);
            });
        }
    }
}