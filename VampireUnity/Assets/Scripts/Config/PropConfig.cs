using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class PropConfig : MonoBehaviour
{
   public enum PropType
   {
      None,
      WeaponFragment,
      JingCui,
      ShenHuaCaiLiao,
      ChiBang,
      LingHun,
      HH,
      HA,
      HC,
      HD,
      AA,
      AC,
      AD,
      CC,
      CD,
      DD,
      ChongWuDan,
   }

   public static Dictionary<int, string> PropNameDic = new Dictionary<int, string>()
   {
      { 101,"普通武器碎片"},
      { 102,"优秀武器碎片"},
      { 103,"精良武器碎片"},
      { 104,"史诗武器碎片"},
      { 105,"传说武器碎片"},
      { 106,"神话武器碎片"},
      
      { 201,"普通精粹"},
      { 202,"优秀精粹"},
      { 203,"精良精粹"},
      { 204,"史诗精粹"},
      { 205,"传说精粹"},
      { 206,"神话精粹"},
      
      { 301,"附魔之骨"},
      { 302,"黄金之血"},
      { 303,"巨大牙齿"},
      { 304,"罪恶眼珠"},
      { 305,"神话之心"},
      
      { 401,"普通羽毛"},
      { 402,"优秀羽毛"},
      { 403,"精良羽毛"},
      { 404,"史诗羽毛"},
      { 405,"传说羽毛"},
      { 406,"神话羽毛"},
      
      { 601,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName},
      { 602,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName},
      { 603,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName},
      { 604,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName},
      { 605,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName},
      { 606,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName},
      
      { 701,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName},
      { 702,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName},
      { 703,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName},
      { 704,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName},
      { 705,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName},
      { 706,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName},
      
      { 801,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName},
      { 802,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName},
      { 803,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName},
      { 804,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName},
      { 805,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName},
      { 806,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName},
      
      { 901,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName},
      { 902,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName},
      { 903,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName},
      { 904,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName},
      { 905,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName},
      { 906,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName},
      
      { 1001,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName},
      { 1002,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName},
      { 1003,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName},
      { 1004,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName},
      { 1005,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName},
      { 1006,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName},
      
      { 1101,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName},
      { 1102,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName},
      { 1103,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName},
      { 1104,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName},
      { 1105,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName},
      { 1106,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName},
      
      { 1201,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName},
      { 1202,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName},
      { 1203,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName},
      { 1204,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName},
      { 1205,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName},
      { 1206,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName},
      
      { 1301,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName},
      { 1302,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName},
      { 1303,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName},
      { 1304,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName},
      { 1305,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName},
      { 1306,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName},
      
      { 1401,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName},
      { 1402,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName},
      { 1403,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName},
      { 1404,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName},
      { 1405,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName},
      { 1406,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName},
      
      { 1501,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName},
      { 1502,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName},
      { 1503,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName},
      { 1504,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName},
      { 1505,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName},
      { 1506,LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName},
   };


   public static Dictionary<int, string> PropDescDic = new Dictionary<int, string>()
   {
      {101,"普通武器破碎而成，可用于解锁初级武器" },
      {102,"带有一丝灵性的碎片，可以用来解锁武器"},
      {103,"难得一见的碎片，可解锁高级武器" },
      {104,"远古战场遗留，可用于解锁史诗武器" },
      {105,"传说中神器的碎片，或许可以拼凑出远古的神器！" },
      {106,"混沌中诞生，武器的终极！" },
      
      {201,"普通精粹，基础材料，用于初阶进阶" },
      {202,"蕴含微弱能量的精粹，可提升装备潜能" },
      {203,"纯度较高的精粹，可触发高级进阶" },
      {204,"远古残晶，能解锁史诗级潜能" },
      {205,"传说之精粹，或可唤醒古老力量" },
      {206,"创生与毁灭凝聚，进阶的终极芯核" },
      
      {301,"充满纹路的传说之骨，用于神话合成" },
      {302,"金黄色血液，用于神话合成" },
      {303,"传说生物的牙齿，用于神话合成" },
      {304,"恶魔的眼珠，用于神话合成" },
      {305,"诞生于创生与毁灭之间，用于进阶的终极材料！" },


      {401,"普通家禽羽毛，轻盈可作装饰" },
      {402,"精致羽毛，能稍增飞行与灵活" },
      {403,"稀有羽毛，强化翅膀增强战力" },
      {404,"战羽遗留，蕴含着磅礴之力" },
      {405,"传说羽翎，承载远古飞兽的力量印记" },
      {406,"羽端汇星辰，跨界之羽，进阶的终极之选" },
      
      {601,"天地灵气所钟，大幅增强生命本源" },
      {602,"天地灵气所钟，大幅增强生命本源" },
      {603,"天地灵气所钟，大幅增强生命本源" },
      {604,"天地灵气所钟，大幅增强生命本源" },
      {605,"天地灵气所钟，大幅增强生命本源" },
      {606,"天地灵气所钟，大幅增强生命本源" },
      
      {701,"龙血浇灌而成，赋予生命与毁灭之力" },
      {702,"龙血浇灌而成，赋予生命与毁灭之力" },
      {703,"龙血浇灌而成，赋予生命与毁灭之力" },
      {704,"龙血浇灌而成，赋予生命与毁灭之力" },
      {705,"龙血浇灌而成，赋予生命与毁灭之力" },
      {706,"龙血浇灌而成，赋予生命与毁灭之力" },
      
      {801,"温养魂魄之玉，让生命与暴击完美共鸣" },
      {802,"温养魂魄之玉，让生命与暴击完美共鸣" },
      {803,"温养魂魄之玉，让生命与暴击完美共鸣" },
      {804,"温养魂魄之玉，让生命与暴击完美共鸣" },
      {805,"温养魂魄之玉，让生命与暴击完美共鸣" },
      {806,"温养魂魄之玉，让生命与暴击完美共鸣" },
      
      {901,"不屈战魂所化，铸就钢铁般的生命防线" },
      {902,"不屈战魂所化，铸就钢铁般的生命防线" },
      {903,"不屈战魂所化，铸就钢铁般的生命防线" },
      {904,"不屈战魂所化，铸就钢铁般的生命防线" },
      {905,"不屈战魂所化，铸就钢铁般的生命防线" },
      {906,"不屈战魂所化，铸就钢铁般的生命防线" },
      
      {1001,"白虎凶星之力，纯粹追求极致的物理破坏" },
      {1002,"白虎凶星之力，纯粹追求极致的物理破坏" },
      {1003,"白虎凶星之力，纯粹追求极致的物理破坏" },
      {1004,"白虎凶星之力，纯粹追求极致的物理破坏" },
      {1005,"白虎凶星之力，纯粹追求极致的物理破坏" },
      {1006,"白虎凶星之力，纯粹追求极致的物理破坏" },
      
      {1101,"凝结杀戮精华，让每一次攻击都直指要害" },
      {1102,"凝结杀戮精华，让每一次攻击都直指要害" },
      {1103,"凝结杀戮精华，让每一次攻击都直指要害" },
      {1104,"凝结杀戮精华，让每一次攻击都直指要害" },
      {1105,"凝结杀戮精华，让每一次攻击都直指要害" },
      {1106,"凝结杀戮精华，让每一次攻击都直指要害" },
      
      {1201,"攻防一体奇石，在坚固堡垒中暗藏杀机" },
      {1202,"攻防一体奇石，在坚固堡垒中暗藏杀机" },
      {1203,"攻防一体奇石，在坚固堡垒中暗藏杀机" },
      {1204,"攻防一体奇石，在坚固堡垒中暗藏杀机" },
      {1205,"攻防一体奇石，在坚固堡垒中暗藏杀机" },
      {1206,"攻防一体奇石，在坚固堡垒中暗藏杀机" },
      
      {1301,"窥见命运裂隙，将战斗的胜负归于概率之神" },
      {1302,"窥见命运裂隙，将战斗的胜负归于概率之神" },
      {1303,"窥见命运裂隙，将战斗的胜负归于概率之神" },
      {1304,"窥见命运裂隙，将战斗的胜负归于概率之神" },
      {1305,"窥见命运裂隙，将战斗的胜负归于概率之神" },
      {1306,"窥见命运裂隙，将战斗的胜负归于概率之神" },
      
      {1401,"完美格挡反击，从绝对防御中寻得制胜一击" },
      {1402,"完美格挡反击，从绝对防御中寻得制胜一击" },
      {1403,"完美格挡反击，从绝对防御中寻得制胜一击" },
      {1404,"完美格挡反击，从绝对防御中寻得制胜一击" },
      {1405,"完美格挡反击，从绝对防御中寻得制胜一击" },
      {1406,"完美格挡反击，从绝对防御中寻得制胜一击" },
      
      {1501,"背负玄武汉子，将自身化为不可逾越的叹息之墙" },
      {1502,"背负玄武汉子，将自身化为不可逾越的叹息之墙" },
      {1503,"背负玄武汉子，将自身化为不可逾越的叹息之墙" },
      {1504,"背负玄武汉子，将自身化为不可逾越的叹息之墙" },
      {1505,"背负玄武汉子，将自身化为不可逾越的叹息之墙" },
      {1506,"背负玄武汉子，将自身化为不可逾越的叹息之墙" },
   };
}
