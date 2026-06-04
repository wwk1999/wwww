using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributeItem : MonoBehaviour
{
    [NonSerialized] public PlayerBaseAttribute type;

    public Image Icon;
    public TextMeshProUGUI Text;
    
    public void SetItem()
    {
        switch (type)
        {
            case PlayerBaseAttribute.Attack:
                Icon.sprite = ResourcesConfig.AttackIcon;
                Text.text = "魔力：" + (int)GlobalPlayerAttribute.TotalDamage;
                break;
            case PlayerBaseAttribute.Defense:
                Icon.sprite = ResourcesConfig.DefenseIcon;
                Text.text = "防御：" + (int)GlobalPlayerAttribute.TotalDefense;
                break;
            case PlayerBaseAttribute.Crit:
                Icon.sprite = ResourcesConfig.CritIcon;
                Text.text = "暴击率：" + (int)GlobalPlayerAttribute.TotalCRIT+"%";
                break;
            case PlayerBaseAttribute.Hp:
                Icon.sprite = ResourcesConfig.HpIcon;
                Text.text = "生命值：" + (int)GlobalPlayerAttribute.TotalMaxHp;
                break;
            case PlayerBaseAttribute.CritDamage:
                Icon.sprite = ResourcesConfig.CritDamageIcon;
                Text.text = "暴击伤害：" + (int)GlobalPlayerAttribute.TotalCritDamage+"%";
                break;
            case PlayerBaseAttribute.MoveSpeed:
                Icon.sprite = ResourcesConfig.MoveSpeedIcon;
                Text.text = "移动速度：" + GlobalPlayerAttribute.PlayerMoveSpeed.ToString("F2");
                break;
            case PlayerBaseAttribute.AttackSpeed:
                Icon.sprite = ResourcesConfig.AttackSpeedIcon;
                Text.text = "攻击速度：" + GlobalPlayerAttribute.TotalAttackSpeed.ToString("F2");
                break;
            case PlayerBaseAttribute.Huo:
                Icon.sprite = ResourcesConfig.HuoIcon;
                Text.text = "火焰掌控：" + (int)(GlobalPlayerAttribute.HuoYuanSuBase*100f);
                break;
            case PlayerBaseAttribute.Dian:
                Icon.sprite = ResourcesConfig.DianIcon;
                Text.text = "雷电掌控：" + (int)(GlobalPlayerAttribute.DianYuanSuBase*100);
                break;
            case PlayerBaseAttribute.Ice:
                Icon.sprite = ResourcesConfig.IceIcon;
                Text.text = "冰霜掌控：" + (int)(GlobalPlayerAttribute.IceYuanSuBase*100);
                break;
            case PlayerBaseAttribute.HeiAn:
                Icon.sprite = ResourcesConfig.HeiAnIcon;
                Text.text = "黑暗掌控：" + (int)(GlobalPlayerAttribute.HeiAnYuanSuBase*100);
                break;
            case PlayerBaseAttribute.FinalDamage:
                Icon.sprite = ResourcesConfig.FinalDamageIcon;
                Text.text = "最终伤害：" + (int)(GlobalPlayerAttribute.FinalDamage*100);
                break;
            
        }
    }
}
