using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterGrid : MonoBehaviour
{
    [NonSerialized] public MonsterTypeByName type;
    public Image image;

    public void SetItem()
    {
        image.sprite=ResourcesConfig.GetMonsterIcon(type);
    }
}
