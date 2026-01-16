using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttributePanel : MonoBehaviour
{
    public TextMeshProUGUI attack;
    public TextMeshProUGUI defense;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI crit;
    public TextMeshProUGUI critdamage;
    public TextMeshProUGUI movespeed;
    public TextMeshProUGUI attackSpeed;

    private void OnEnable()
    {
        attack.text = Mathf.RoundToInt(GlobalPlayerAttribute.TotalDamage).ToString();
        defense.text = Mathf.RoundToInt(GlobalPlayerAttribute.TotalDefense).ToString();
        hp.text = Mathf.RoundToInt(GlobalPlayerAttribute.TotalMaxHp).ToString();
        crit.text = Mathf.RoundToInt(GlobalPlayerAttribute.TotalCRIT).ToString();
        critdamage.text = Mathf.RoundToInt(GlobalPlayerAttribute.TotalDamage).ToString();
        movespeed.text = GlobalPlayerAttribute.PlayerMoveSpeed.ToString();
        attackSpeed.text = GlobalPlayerAttribute.TotalAttackSpeed.ToString();

    }
}
