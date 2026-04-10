using System.Collections;
using System.Collections.Generic;
using Equip;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterInfo
{
    public float attack;
    public float defence;
    public float hp;
    public float ex;
    public float linghun;
    public bool orangeEquip=false;
    public List<MonsterEquip>  MonsterEquipList=new List<MonsterEquip>();
    public List<MonsterProp>  MonsterPropList=new List<MonsterProp>();
}

public class MonsterDiaoLuoType
{
    public int GameLevel;
    public MonsterType MonsterType;
}

public class MonsterConfig
{
    public static Dictionary<MonsterDiaoLuoType, MonsterInfo> MonsterInfoDic =
        new Dictionary<MonsterDiaoLuoType, MonsterInfo>()
        {
            {
                new MonsterDiaoLuoType() { GameLevel = 3, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 3, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 3, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 6, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 6, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 6, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 9, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 9, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 9, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 12, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 12, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 12, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 15, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 15, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 15, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterEquipList = new List<MonsterEquip>()
                        { new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Green, 2) }
                }
            },
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 16, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 16, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 16, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 17, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 17, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 17, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 18, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 18, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 18, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 19, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 19, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 19, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 20, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 20, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 20, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 21, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 21, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 21, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 22, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 22, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 22, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 23, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 23, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 23, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 24, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 24, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 24, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 25, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 25, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 25, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 26, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 26, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 26, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 27, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 27, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 27, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 28, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 28, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 28, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 29, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 29, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 29, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 30, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 30, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 30, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,orangeEquip = true
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 101, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 101, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 101, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 102, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 102, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 102, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 103, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 103, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 103, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 104, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 104, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 104, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 105, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 105, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 105, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 106, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 106, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 106, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 201, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 201, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 201, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 202, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 202, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 202, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 203, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 203, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 203, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 204, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 204, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 204, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 205, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 205, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 205, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 206, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 206, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 206, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
           
            
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 301, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 301, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 301, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 302, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 302, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 302, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 303, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 303, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 303, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 304, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 304, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 304, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 305, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 305, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 305, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            
            
            
            
            
            
            {
                new MonsterDiaoLuoType() { GameLevel = 306, MonsterType = MonsterType.Normal },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 306, MonsterType = MonsterType.Elite },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },
            {
                new MonsterDiaoLuoType() { GameLevel = 306, MonsterType = MonsterType.Boss },
                new MonsterInfo()
                {
                    attack = 100, defence = 100, hp = 10000, ex = 10, linghun = 10,
                    MonsterPropList = new List<MonsterProp>()
                    {
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5),
                        new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5)
                    }
                }
            },

        };

}
