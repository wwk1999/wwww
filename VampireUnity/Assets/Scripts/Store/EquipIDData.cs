using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipIDData : XSingleton<EquipIDData>
{
    public Dictionary<int,EquipTable> equipIds = new Dictionary<int, EquipTable>();
    public Dictionary<PropItem,PropTable> propTables = new Dictionary<PropItem,PropTable>();
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
        var propItem = new PropItem()
        {
            PropType = prop.PropType,
            Quality = prop.Quality,
        };
        if (propTables.ContainsKey(propItem))
        {
            propTables[propItem].Count+=prop.Count;
        }
        else
        {
            propTables.Add(propItem,data);
        }
    }
}
