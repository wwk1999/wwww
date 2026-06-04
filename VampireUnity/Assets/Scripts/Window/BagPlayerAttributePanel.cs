using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BagPlayerAttributePanel : MonoBehaviour
{
    public GameObject Content;

    private void OnEnable()
    {
        foreach (Transform item in Content.transform)
        {
            Destroy(item.gameObject);
        }
        for (int i = 1; i <= 12; i++)
        {
            PlayerAttributeItem playerAttributeItem=Instantiate(Resources.Load("Prefabs/Window/PlayerAttributeItem"),Content.transform).GetComponent<PlayerAttributeItem>();
            PlayerBaseAttribute Type = (PlayerBaseAttribute)i;
            playerAttributeItem.type = Type;
            playerAttributeItem.SetItem();
        }
    }
}
