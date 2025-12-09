using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipIDData : XSingleton<EquipIDData>
{
    public Dictionary<int,EquipTable> equipIds = new Dictionary<int, EquipTable>();
    public Dictionary<int,PropTable> propTables = new Dictionary<int,PropTable>();
    public int nextEquipId = 1;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    public int GenerateEquipId()
    {
        return nextEquipId++;
    }

    public void SavaEquip(EquipTable equip)
    {
        var data = new EquipTable()
        {
            equipid = GenerateEquipId(),
            Quality = equip.Quality,
            Damage = equip.Damage,
            CRIT = equip.CRIT,
            HP = equip.HP,
            suitid = equip.suitid,
            equip_type_id = equip.equip_type_id,
            Defense = equip.Defense,
            EquipName = equip.EquipName,
            damageEntryInfos= new List<DamageEntryInfo>(equip.damageEntryInfos),
            defenseEntryInfos= new List<DefenseEntryInfo>(equip.defenseEntryInfos)
        };
        equipIds.Add(data.equipid,data);
    }

    public void SaveProp(PropTable prop)
    {
        var data = new PropTable()
        {
            PropType =  prop.PropType,
            Quality =  prop.Quality,
            Desc =  prop.Desc,
            Count =  prop.Count,
            EquipName =  prop.EquipName,
        };
        int value = 0;
        switch (prop.Quality)
        {
            case 1:
                value = 101;
                break;
            case 2:
                value = 102;
                break;
            case 3:
                value = 103;
                break;
            case 4:
                value = 104;
                break;
            case 5:
                value = 105;
                break;
            case 6:
                value = 106;
                break;
        }
        if (propTables.ContainsKey(value))
        {
            propTables[value].Count+=prop.Count;
        }
        else
        {
            propTables.Add(value,data);
        }
    }
}
