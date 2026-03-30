using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum AttributeType
{
    None,
    Attack,
    Defense,
    Crit,
    Hp,
    AttackSpeed
}
public class WeaponItem1 : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI Count;
    public Image Icon;

    public void SetWeaponItem(AttributeType type, int count)
    {
        switch (type)
        {
            case AttributeType.Attack:
                NameText.text = "魔力";
                Count.text = count.ToString();
                Icon.sprite = ResourcesConfig.AttackIcon;
                break;
            case AttributeType.Defense:
                NameText.text = "防御";
                Count.text = count.ToString();
                Icon.sprite = ResourcesConfig.DefenseIcon;

                break;
            case AttributeType.Hp:
                NameText.text = "生命值";
                Count.text = count.ToString();
                Icon.sprite = ResourcesConfig.HpIcon;

                break;
            case AttributeType.Crit:
                NameText.text = "暴击";
                Count.text = count.ToString();
                Icon.sprite = ResourcesConfig.CritIcon;

                break;
            case AttributeType.AttackSpeed:
                NameText.text = "攻击速度";
                Count.text = count.ToString();
                Icon.sprite = ResourcesConfig.AttackSpeedIcon;
                break;
        }
    }
}
