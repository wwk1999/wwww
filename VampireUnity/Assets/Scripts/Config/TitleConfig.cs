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
    
    LingHun1,
    LingHun2,
    LingHun3,
    LingHun4,
    LingHun5,
    LingHun6,
    
    GuanKa1,
    GuanKa2,
    GuanKa3,
    GuanKa4,
    GuanKa5,
    GuanKa6,
    
    Huo1,
    Huo2,
    Huo3,
    Huo4,
    Huo5,
    Huo6,
    
    Ice1,
    Ice2,
    Ice3,
    Ice4,
    Ice5,
    Ice6,
    
    Dian1,
    Dian2,
    Dian3,
    Dian4,
    Dian5,
    Dian6,
    
    HeiAn1,
    HeiAn2,
    HeiAn3,
    HeiAn4,
    HeiAn5,
    HeiAn6,
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
    DiaoLuo,
    LinHun,
    Huo,
    Ice,
    HeiAn,
    Dian,
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
    public static Dictionary<TitleType, string> TitleJiHuoDic = new Dictionary<TitleType, string>()
    {
        { TitleType.Dian1 ,"雷电系武器总等级>10"},
        { TitleType.Dian2 ,"雷电系武器总等级>20"},
        { TitleType.Dian3 ,"雷电系武器总等级>40"},
        { TitleType.Dian4 ,"雷电系武器总等级>80"},
        { TitleType.Dian5 ,"雷电系武器总等级>150"},
        { TitleType.Dian6 ,"雷电系武器总等级>300"},
        
        
        { TitleType.HeiAn1 ,"黑暗系武器总等级>10"},
        { TitleType.HeiAn2 ,"黑暗系武器总等级>20"},
        { TitleType.HeiAn3 ,"黑暗系武器总等级>40"},
        { TitleType.HeiAn4 ,"黑暗系武器总等级>80"},
        { TitleType.HeiAn5 ,"黑暗系武器总等级>150"},
        { TitleType.HeiAn6 ,"黑暗系武器总等级>300"},
        
        { TitleType.Huo1 ,"火焰系武器总等级>10"},
        { TitleType.Huo2 ,"火焰系武器总等级>20"},
        { TitleType.Huo3 ,"火焰系武器总等级>40"},
        { TitleType.Huo4 ,"火焰系武器总等级>80"},
        { TitleType.Huo5 ,"火焰系武器总等级>150"},
        { TitleType.Huo6 ,"火焰系武器总等级>300"},
        
        { TitleType.Ice1 ,"冰系武器总等级>10"},
        { TitleType.Ice2 ,"冰系武器总等级>20"},
        { TitleType.Ice3 ,"冰系武器总等级>40"},
        { TitleType.Ice4 ,"冰系武器总等级>80"},
        { TitleType.Ice5 ,"冰系武器总等级>150"},
        { TitleType.Ice6 ,"冰系武器总等级>300"},
        
        
        { TitleType.MonsterCount1 ,"总杀怪数量>100"},
        { TitleType.MonsterCount2 ,"总杀怪数量>500"},
        { TitleType.MonsterCount3 ,"总杀怪数量>2000"},
        { TitleType.MonsterCount4 ,"总杀怪数量>5000"},
        { TitleType.MonsterCount5 ,"总杀怪数量>10000"},
        { TitleType.MonsterCount6 ,"总杀怪数量>20000"},
        
        { TitleType.LingHun1 ,"总灵魂数量>1000"},
        { TitleType.LingHun2 ,"总灵魂数量>10000"},
        { TitleType.LingHun3 ,"总灵魂数量>50000"},
        { TitleType.LingHun4 ,"总灵魂数量>100000"},
        { TitleType.LingHun5 ,"总灵魂数量>200000"},
        { TitleType.LingHun6 ,"总灵魂数量>500000"},
        
        
        { TitleType.GuanKa1 ,"通关寂静森林关卡"},
        { TitleType.GuanKa2 ,"通关迷雾沼泽关卡"},
        { TitleType.GuanKa3 ,"通关无尽雪域关卡"},
        { TitleType.GuanKa4 ,"通关异界超难难度"},
        { TitleType.GuanKa5 ,"通关异界神话难度"},
        { TitleType.GuanKa6 ,"通关异界神话Ⅴ难度"},
        
        { TitleType.Level5 ,"人物等级>5"},
        { TitleType.Level15 ,"人物等级>15"},
        { TitleType.Level30 ,"人物等级>30"},
        { TitleType.Level50 ,"人物等级>50"},
        { TitleType.Level75 ,"人物等级>75"},
        { TitleType.Level100 ,"人物等级>100"},
        
        { TitleType.DiaoLuo ,"收集传说装备>50"},
    };
    
    
    
    public static Dictionary<TitleType, string> TitleNameDic = new Dictionary<TitleType, string>()
    {
        { TitleType.Dian1 ,"逐电者"},
        { TitleType.Dian2 ,"驭雷师"},
        { TitleType.Dian3 ,"惊雷将"},
        { TitleType.Dian4 ,"紫电侯"},
        { TitleType.Dian5 ,"雷尊"},
        { TitleType.Dian6 ,"九霄神雷帝"},
        
        
        { TitleType.HeiAn1 ,"逐暗者"},
        { TitleType.HeiAn2 ,"驱影手"},
        { TitleType.HeiAn3 ,"惊夜将"},
        { TitleType.HeiAn4 ,"幽冥侯"},
        { TitleType.HeiAn5 ,"暗尊"},
        { TitleType.HeiAn6 ,"九霄神暗帝"},
        
        { TitleType.Huo1 ,"燃火者"},
        { TitleType.Huo2 ,"驭焰手"},
        { TitleType.Huo3 ,"烈焰使"},
        { TitleType.Huo4 ,"紫炎侯"},
        { TitleType.Huo5 ,"焚炎尊"},
        { TitleType.Huo6 ,"九霄神炎帝"},
        
        { TitleType.Ice1 ,"逐霜者"},
        { TitleType.Ice2 ,"凝冰手"},
        { TitleType.Ice3 ,"惊霜将"},
        { TitleType.Ice4 ,"玄冰侯"},
        { TitleType.Ice5 ,"极寒尊"},
        { TitleType.Ice6 ,"九霄神霜帝"},
        
        
        { TitleType.MonsterCount1 ,"屠兽者"},
        { TitleType.MonsterCount2 ,"斩妖手"},
        { TitleType.MonsterCount3 ,"屠魔将"},
        { TitleType.MonsterCount4 ,"修罗侯"},
        { TitleType.MonsterCount5 ,"万斩尊"},
        { TitleType.MonsterCount6 ,"九霄血帝"},
        
        { TitleType.LingHun1 ,"引魂者"},
        { TitleType.LingHun2 ,"缚灵手"},
        { TitleType.LingHun3 ,"摄魂将"},
        { TitleType.LingHun4 ,"噬灵侯"},
        { TitleType.LingHun5 ,"万魂尊"},
        { TitleType.LingHun6 ,"九幽灵帝"},
        
        
        { TitleType.GuanKa1 ,"踏关者"},
        { TitleType.GuanKa2 ,"破关手"},
        { TitleType.GuanKa3 ,"征关将"},
        { TitleType.GuanKa4 ,"掠城侯"},
        { TitleType.GuanKa5 ,"千关尊"},
        { TitleType.GuanKa6 ,"万界征帝"},
        
        { TitleType.Level5 ,"魔法学徒"},
        { TitleType.Level15 ,"施法师"},
        { TitleType.Level30 ,"大法师"},
        { TitleType.Level50 ,"大魔导"},
        { TitleType.Level75 ,"圣法尊"},
        { TitleType.Level100 ,"九霄法帝"},
        
        { TitleType.DiaoLuo ,"寻宝大师"},
    };
    
    
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 10f },
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 30f },
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 80f },
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 100f },
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 200f },
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 500f },
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Crit, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 10f }
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 10f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 15f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 15f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 30f }
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 20f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 20f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 20f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 50f }
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 200f },
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 400f },
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Hp, Value = 1000f },
                    new TitleAttributeItem() { Type = TitleAttributeType.AllDamage, Value = 0.3f },
                }
            }
        },
        
        
        {
            TitleType.LingHun1,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.LinHun, Value = 0.02f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.LinHun, Value = 0.05f },
                }
            }
        },
        
        
        {
            TitleType.LingHun2,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.LinHun, Value = 0.05f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 15f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 15f },
                    new TitleAttributeItem() { Type = TitleAttributeType.LinHun, Value = 0.1f },
                }
            }
        },
        
        
        {
            TitleType.LingHun3,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.LinHun, Value = 0.1f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 30f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 30f },
                    new TitleAttributeItem() { Type = TitleAttributeType.LinHun, Value = 0.2f },
                }
            }
        },
        
        
        
        {
            TitleType.LingHun4,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 15f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 15f },
                    new TitleAttributeItem() { Type = TitleAttributeType.LinHun, Value = 0.15f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.LinHun, Value = 0.3f },
                }
            }
        },
        
        
        {
            TitleType.LingHun5,
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.LinHun, Value = 0.4f },
                }
            }
        },
        
        
        
        
        
        
        {
            TitleType.LingHun6,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.LinHun, Value = 0.3f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 200f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 200f },
                    new TitleAttributeItem() { Type = TitleAttributeType.LinHun, Value = 0.6f },
                }
            }
        },
        
        {
            TitleType.GuanKa1,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.FinalDamage, Value = 0.01f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },

                    new TitleAttributeItem() { Type = TitleAttributeType.FinalDamage, Value = 0.02f },
                }
            }
        },
        
        {
            TitleType.GuanKa2,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.FinalDamage, Value = 0.02f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 20f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 20f },

                    new TitleAttributeItem() { Type = TitleAttributeType.FinalDamage, Value = 0.05f },
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 40f },

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
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 100f },

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
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 200f },

                    new TitleAttributeItem() { Type = TitleAttributeType.FinalDamage, Value = 0.3f },
                }
            }
        },
        
        
        {
            TitleType.GuanKa6,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.FinalDamage, Value = 0.2f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 500f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 500f },

                    new TitleAttributeItem() { Type = TitleAttributeType.FinalDamage, Value = 0.4f },
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 50f },

                    new TitleAttributeItem() { Type = TitleAttributeType.DiaoLuo, Value = 0.3f },
                }
            }
        },
        
        
        
        
        
        {
            TitleType.Huo1,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Huo, Value = 0.01f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Huo, Value = 0.02f },
                }
            }
        },
        
        {
            TitleType.Huo2,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Huo, Value = 0.02f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 20f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 20f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Huo, Value = 0.05f },
                }
            }
        },
        
        
        {
            TitleType.Huo3,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Huo, Value = 0.05f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 40f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 40f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Huo, Value = 0.1f },
                }
            }
        },
        
        
        
        {
            TitleType.Huo4,
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 100f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Huo, Value = 0.2f },
                }
            }
        },
        
        
        
        
        {
            TitleType.Huo5,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Huo, Value = 0.15f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 200f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 200f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Huo, Value = 0.3f },
                }
            }
        },
        
        
        {
            TitleType.Huo6,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Huo, Value = 0.2f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 500f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 500f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Huo, Value = 0.4f },
                }
            }
        },
        
        
        
        
        
        {
            TitleType.HeiAn1,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.HeiAn, Value = 0.01f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },

                    new TitleAttributeItem() { Type = TitleAttributeType.HeiAn, Value = 0.02f },
                }
            }
        },
        
        {
            TitleType.HeiAn2,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.HeiAn, Value = 0.02f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 20f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 20f },

                    new TitleAttributeItem() { Type = TitleAttributeType.HeiAn, Value = 0.05f },
                }
            }
        },
        
        
        {
            TitleType.HeiAn3,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.HeiAn, Value = 0.05f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 40f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 40f },

                    new TitleAttributeItem() { Type = TitleAttributeType.HeiAn, Value = 0.1f },
                }
            }
        },
        
        
        
        {
            TitleType.HeiAn4,
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 100f },

                    new TitleAttributeItem() { Type = TitleAttributeType.HeiAn, Value = 0.2f },
                }
            }
        },
        
        
        
        
        {
            TitleType.HeiAn5,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.HeiAn, Value = 0.15f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 200f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 200f },

                    new TitleAttributeItem() { Type = TitleAttributeType.HeiAn, Value = 0.3f },
                }
            }
        },
        
        
        {
            TitleType.HeiAn6,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.HeiAn, Value = 0.2f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 500f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 500f },

                    new TitleAttributeItem() { Type = TitleAttributeType.HeiAn, Value = 0.4f },
                }
            }
        },
        
        
        
        
        
         {
            TitleType.Ice1,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Ice, Value = 0.01f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Ice, Value = 0.02f },
                }
            }
        },
        
        {
            TitleType.Ice2,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Ice, Value = 0.02f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 20f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 20f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Ice, Value = 0.05f },
                }
            }
        },
        
        
        {
            TitleType.Ice3,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Ice, Value = 0.05f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 40f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 40f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Ice, Value = 0.1f },
                }
            }
        },
        
        
        
        {
            TitleType.Ice4,
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 100f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Ice, Value = 0.2f },
                }
            }
        },
        
        
        
        
        {
            TitleType.Ice5,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Ice, Value = 0.15f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 200f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 200f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Ice, Value = 0.3f },
                }
            }
        },
        
        
        {
            TitleType.Ice6,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Ice, Value = 0.2f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 500f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 500f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Ice, Value = 0.4f },
                }
            }
        },
        
        
        
        
        
        
        
        
        
         {
            TitleType.Dian1,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 1f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Dian, Value = 0.01f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Dian, Value = 0.02f },
                }
            }
        },
        
        {
            TitleType.Dian2,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 5f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Dian, Value = 0.02f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 20f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 20f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Dian, Value = 0.05f },
                }
            }
        },
        
        
        {
            TitleType.Dian3,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 10f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Dian, Value = 0.05f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 40f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 40f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Dian, Value = 0.1f },
                }
            }
        },
        
        
        
        {
            TitleType.Dian4,
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
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 100f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Dian, Value = 0.2f },
                }
            }
        },
        
        
        
        
        {
            TitleType.Dian5,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 50f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Dian, Value = 0.15f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 200f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 200f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Dian, Value = 0.3f },
                }
            }
        },
        
        
        {
            TitleType.Dian6,
            new TitleAttribute()
            {
                JiHuoList = new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 100f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Dian, Value = 0.2f }
                },
                InstallList =  new List<TitleAttributeItem>()
                {
                    new TitleAttributeItem() { Type = TitleAttributeType.Attack, Value = 500f },
                    new TitleAttributeItem() { Type = TitleAttributeType.Defense, Value = 500f },

                    new TitleAttributeItem() { Type = TitleAttributeType.Dian, Value = 0.4f },
                }
            }
        },
        
        
        
        
        
    };
}