using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TitleType
{
    None,
    Level5,
    Level15,
    Level30,
    Level50,
    Level75,
    Level100,
    MonsterCount1,
    MonsterCount2,
    MonsterCount3,
    MonsterCount4,
    MonsterCount5,
    MonsterCount6,
    LinHun,
    BaoShi,
    HunQi3,
    HunQi4,
    HunQi5,
    ChiBang4,
    ChiBang5,
    GuanKa3,
    GuanKa4,
    GuanKa5,
    DiaoLuo,
}

public enum TitleAttributeType
{
    None,
    Attack,
    Defense,
    Hp,
    Crit,
    FinalDamage,
    AllBaseAttribute,
    AllDamage,
    BaoShiTeXiao,
    DiaoLuo,
    LinHun,
    NormalAttackDamage,
    MoveSpeed,
}
public class TitleItemInfo
{
    public int Quality;
    public string Name;
}

public class TitleAttributeItem
{
    public TitleAttributeType  Type;
    public float Value;
}

public class TitleAttribute
{
    public List<TitleAttributeItem> JiHuoList = new List<TitleAttributeItem>();
   public List<TitleAttributeItem> InstallList = new List<TitleAttributeItem>();
}

public class TitleConfig : MonoBehaviour
{
    public static Dictionary<TitleType, TitleAttribute> TitleAttributeDic = new Dictionary<TitleType, TitleAttribute>()
    {
        {
            TitleType.Level5,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 5f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },
                }
            }
        },
        
        
        
        {
            TitleType.Level15,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 25f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 15f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 15f },
                }
            }
        },
        
        
        
        {
            TitleType.Level30,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 50f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 40f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 40f },
                }
            }
        },
        
        
        
        {
            TitleType.Level50,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 25f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.AllBaseAttribute, Value = 0.05f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.AllBaseAttribute, Value = 0.1f },
                }
            }
        },
        
        
        
        {
            TitleType.Level75,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 500f },
                    new TitleAttributeItem() { Type = TitleAttributeType.AllBaseAttribute, Value = 0.1f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 200f },
                    new TitleAttributeItem() { Type = TitleAttributeType.AllBaseAttribute, Value = 0.2f },
                }
            }
        },
        
        
        {
            TitleType.Level100,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 1000f },
                    new TitleAttributeItem() { Type = TitleAttributeType.AllBaseAttribute, Value = 0.15f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 500f },
                    new TitleAttributeItem() { Type = TitleAttributeType.AllBaseAttribute, Value = 0.3f },
                }
            }
        },
        
        
        
        
        
        
        
        
        {
            TitleType.MonsterCount1,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 5f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Crit, Value = 25f },
                }
            }
        },
        
        
        
        {
            TitleType.MonsterCount2,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 25f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 15f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Crit, Value = 75f },
                }
            }
        },
        
        
        
        {
            TitleType.MonsterCount3,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 50f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 40f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Crit, Value = 200f },
                }
            }
        },
        
        
        
        {
            TitleType.MonsterCount4,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 25f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.AllDamage, Value = 0.05f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.AllDamage, Value = 0.1f },
                }
            }
        },
        
        
        
        {
            TitleType.MonsterCount5,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 500f },
                    new TitleAttributeItem() { Type = TitleAttributeType.AllDamage, Value = 0.1f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 200f },
                    new TitleAttributeItem() { Type = TitleAttributeType.AllDamage, Value = 0.2f },
                }
            }
        },
        
        
        {
            TitleType.MonsterCount6,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 1000f },
                    new TitleAttributeItem() { Type = TitleAttributeType.AllDamage, Value = 0.15f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 500f },
                    new TitleAttributeItem() { Type = TitleAttributeType.AllDamage, Value = 0.3f },
                }
            }
        },
        
        
        {
            TitleType.LinHun,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 25f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 25f },
                    new TitleAttributeItem() { Type = TitleAttributeType.LinHun, Value = 0.2f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.LinHun, Value = 0.5f },
                }
            }
        },
        
        
        {
            TitleType.BaoShi,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 25f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 25f },
                    new TitleAttributeItem() { Type = TitleAttributeType.BaoShiTeXiao, Value = 0.2f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.BaoShiTeXiao, Value = 0.5f },
                }
            }
        },
        
        
        
        
        {
            TitleType.HunQi3,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.NormalAttackDamage, Value = 0.05f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 40f },
                    new TitleAttributeItem() { Type = TitleAttributeType.NormalAttackDamage, Value = 0.1f },
                }
            }
        },
        
        
        {
            TitleType.HunQi4,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 25f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 25f },
                    new TitleAttributeItem() { Type = TitleAttributeType.NormalAttackDamage, Value = 0.1f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.NormalAttackDamage, Value = 0.2f },
                }
            }
        },
        
        
        {
            TitleType.HunQi5,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.NormalAttackDamage, Value = 0.15f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 200f },
                    new TitleAttributeItem() { Type = TitleAttributeType.NormalAttackDamage, Value = 0.3f },
                }
            }
        },
        
        
        
        {
            TitleType.GuanKa3,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.FinalDamage, Value = 0.05f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 40f },
                    new TitleAttributeItem() { Type = TitleAttributeType.FinalDamage, Value = 0.1f },
                }
            }
        },
        
        
        
        {
            TitleType.GuanKa4,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 25f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 25f },
                    new TitleAttributeItem() { Type = TitleAttributeType.FinalDamage, Value = 0.1f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.FinalDamage, Value = 0.2f },
                }
            }
        },
        
        
        
        
        {
            TitleType.GuanKa5,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.FinalDamage, Value = 0.15f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 200f },
                    new TitleAttributeItem() { Type = TitleAttributeType.FinalDamage, Value = 0.3f },
                }
            }
        },
        
        
        
        
        {
            TitleType.ChiBang4,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 25f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 25f },
                    new TitleAttributeItem() { Type = TitleAttributeType.MoveSpeed, Value = 0.3f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.MoveSpeed, Value = 1f },
                }
            }
        },
        
        
        
        {
            TitleType.ChiBang5,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.MoveSpeed, Value = 0.5f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 200f },
                    new TitleAttributeItem() { Type = TitleAttributeType.MoveSpeed, Value = 1.5f },
                }
            }
        },
        
        
        
        {
            TitleType.DiaoLuo,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.DiaoLuo, Value = 0.15f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 200f },
                    new TitleAttributeItem() { Type = TitleAttributeType.DiaoLuo, Value = 0.3f },
                }
            }
        },
    };
}