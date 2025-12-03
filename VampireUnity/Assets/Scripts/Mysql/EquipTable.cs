using System;
using System.Collections.Generic;
using Mysql;
using Tool;

public class EquipTable:TableBase
{
    public int EquipLevel { get; set; }
    public int equipid { get; set; }
    public int suitid { get; set; } // 套装ID
    public int equip_type_id{ get; set; } // 装备类型ID
    public int Damage { get; set; }
    public int CRIT { get; set; }
    public int Defense { get; set; }
    public int HP { get; set; }
    
    public List<DamageEntryInfo> damageEntryInfos=new List<DamageEntryInfo>();
    public List<DefenseEntryInfo> defenseEntryInfos=new List<DefenseEntryInfo>();

    public EquipTable(
        int equipid = 0,
        string equipName = null,
        int quality = 0, 
        int damage = 0, 
        int crit = 0, 
        int defense = 0, 
        int hp = 0, 
        int suitid = 0,
        int equip_type_id = 0,
        List<DamageEntryInfo> damageEntryInfos=null,
        List<DefenseEntryInfo> defenseEntryInfos=null)
    {
        this.equipid = equipid;
        EquipName = equipName;
        Quality = quality;
        Damage = damage;
        CRIT = crit;
        Defense = defense;
        HP = hp;
        TableType = TableType.EquipTable;
        this.suitid = suitid;
        this.equip_type_id = equip_type_id;
        this.damageEntryInfos = damageEntryInfos ?? new List<DamageEntryInfo>();
        this.defenseEntryInfos = defenseEntryInfos ?? new List<DefenseEntryInfo>();
    }
}