using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShouCangShiItemType
{
    None,
    Equip,
    ChiBang,
    ChongWu,
}
public class ShouCangShiConfig
{
    public static Dictionary<int, int> ShouCangShiQualityCountDic = new Dictionary<int, int>()
    {
        {1,1},
        {2,2},
        {3,4},
        {4,8},
        {5,15},
        {6,50},
    };

    public static float BaseAttack = 10f;
    public static float BaseHp = 20f;
    public static float BaseDefense = 10f;
    public static float BaseCrit = 20f;

}