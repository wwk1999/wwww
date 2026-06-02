using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleCiTiaoItem : MonoBehaviour
{
    public TextMeshProUGUI text;
    [NonSerialized]public TitleAttributeType Type;
    [NonSerialized]public float Value;

    public void SetItem()
    {
        switch (Type)
        {
            case TitleAttributeType.AllBaseAttribute:
                text.text = $"所有基本属性增加{Value}%";
                break;
            case TitleAttributeType.Huo:
                text.text = $"火元素掌控增加{Value}";
                break;
            case TitleAttributeType.Defense:
                text.text = $"防御增加{Value}";
                break;
            case TitleAttributeType.DiaoLuo:
                text.text = $"掉宝率增加{Value}";
                break;
            case TitleAttributeType.Hp:
                text.text = $"生命值增加{Value}";
                break;
            case TitleAttributeType.AllDamage:
                text.text = $"所有伤害增加{Value}%";
                break;
            case TitleAttributeType.Attack:
                text.text = $"魔力增加{Value}";
                break;
            case TitleAttributeType.Crit:
                text.text = $"暴击增加{Value}";
                break;
            case TitleAttributeType.Dian:
                text.text = $"电元素掌控增加{Value}";
                break;
            case TitleAttributeType.FinalDamage:
                text.text = $"最终伤害增加{Value}%";
                break;
            case TitleAttributeType.HeiAn:
                text.text = $"黑暗元素掌控增加{Value}";
                break;
            case TitleAttributeType.Ice:
                text.text = $"冰霜元素掌控增加{Value}";
                break;
            case TitleAttributeType.LinHun:
                text.text = $"灵魂掉落增加{Value}%";
                break;
        }
    }
}
