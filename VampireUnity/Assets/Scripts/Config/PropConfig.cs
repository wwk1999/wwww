using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class PropConfig : MonoBehaviour
{

    public static int GetPropId(PropType type, int quality)
    {
        switch (type)
        {
            // 武器碎片 (100系列)
            case PropType.WeaponFragment:
                switch (quality)
                {
                    case 1: return 101;
                    case 2: return 102;
                    case 3: return 103;
                    case 4: return 104;
                    case 5: return 105;
                    case 6: return 106;
                    default: return 0;
                }

            // 精粹 (200系列)
            case PropType.JingCui:
                switch (quality)
                {
                    case 1: return 201;
                    case 2: return 202;
                    case 3: return 203;
                    case 4: return 204;
                    case 5: return 205;
                    case 6: return 206;
                    default: return 0;
                }

            // 神话材料 (300系列)
            case PropType.ShenHuaCaiLiao:
                switch (quality)
                {
                    case 1: return 301;
                    case 2: return 302;
                    case 3: return 303;
                    case 4: return 304;
                    case 5: return 305;
                    default: return 0;
                }

            // 翅膀/羽毛 (400系列)
            case PropType.ChiBang:
                switch (quality)
                {
                    case 1: return 401;
                    case 2: return 402;
                    case 3: return 403;
                    case 4: return 404;
                    case 5: return 405;
                    case 6: return 406;
                    default: return 0;
                }

            // 灵魂 (500系列) - 注意：字典中没有500系列，可能需要处理

            // HH宝石 (600系列)
            case PropType.HH:
                switch (quality)
                {
                    case 1: return 601;
                    case 2: return 602;
                    case 3: return 603;
                    case 4: return 604;
                    case 5: return 605;
                    case 6: return 606;
                    default: return 0;
                }

            // HA宝石 (700系列)
            case PropType.HA:
                switch (quality)
                {
                    case 1: return 701;
                    case 2: return 702;
                    case 3: return 703;
                    case 4: return 704;
                    case 5: return 705;
                    case 6: return 706;
                    default: return 0;
                }

            // HC宝石 (800系列)
            case PropType.HC:
                switch (quality)
                {
                    case 1: return 801;
                    case 2: return 802;
                    case 3: return 803;
                    case 4: return 804;
                    case 5: return 805;
                    case 6: return 806;
                    default: return 0;
                }

            // HD宝石 (900系列)
            case PropType.HD:
                switch (quality)
                {
                    case 1: return 901;
                    case 2: return 902;
                    case 3: return 903;
                    case 4: return 904;
                    case 5: return 905;
                    case 6: return 906;
                    default: return 0;
                }

            // AA宝石 (1000系列)
            case PropType.AA:
                switch (quality)
                {
                    case 1: return 1001;
                    case 2: return 1002;
                    case 3: return 1003;
                    case 4: return 1004;
                    case 5: return 1005;
                    case 6: return 1006;
                    default: return 0;
                }

            // AC宝石 (1100系列)
            case PropType.AC:
                switch (quality)
                {
                    case 1: return 1101;
                    case 2: return 1102;
                    case 3: return 1103;
                    case 4: return 1104;
                    case 5: return 1105;
                    case 6: return 1106;
                    default: return 0;
                }

            // AD宝石 (1200系列)
            case PropType.AD:
                switch (quality)
                {
                    case 1: return 1201;
                    case 2: return 1202;
                    case 3: return 1203;
                    case 4: return 1204;
                    case 5: return 1205;
                    case 6: return 1206;
                    default: return 0;
                }

            // CC宝石 (1300系列)
            case PropType.CC:
                switch (quality)
                {
                    case 1: return 1301;
                    case 2: return 1302;
                    case 3: return 1303;
                    case 4: return 1304;
                    case 5: return 1305;
                    case 6: return 1306;
                    default: return 0;
                }

            // CD宝石 (1400系列)
            case PropType.CD:
                switch (quality)
                {
                    case 1: return 1401;
                    case 2: return 1402;
                    case 3: return 1403;
                    case 4: return 1404;
                    case 5: return 1405;
                    case 6: return 1406;
                    default: return 0;
                }

            // DD宝石 (1500系列)
            case PropType.DD:
                switch (quality)
                {
                    case 1: return 1501;
                    case 2: return 1502;
                    case 3: return 1503;
                    case 4: return 1504;
                    case 5: return 1505;
                    case 6: return 1506;
                    default: return 0;
                }

            // 宠物蛋 (1600系列)
            case PropType.ChongWuDan:
                switch (quality)
                {
                    case 3: return 1603; // 普通宠物蛋
                    case 5: return 1605; // 高级宠物蛋
                    default: return 0;
                }

            // 洗髓液 (1700系列)
            case PropType.XiSuiYe:
                switch (quality)
                {
                    case 3: return 1703; // 普通洗髓液
                    case 5: return 1705; // 高级洗髓液
                    default: return 0;
                }

            // 血脉丹 (1800系列)
            case PropType.XueMaiDan:
                switch (quality)
                {
                    case 3: return 1803; // 普通血脉丹
                    case 5: return 1805; // 高级血脉丹
                    default: return 0;
                }

            // 生命药水 (1900系列)
            case PropType.HpYaoShui:
                switch (quality)
                {
                    case 1: return 1901;
                    case 2: return 1902;
                    case 3: return 1903;
                    case 4: return 1904;
                    case 5: return 1905;
                    case 6: return 1906;
                    default: return 0;
                }

            // 经验药水 (2000系列)
            case PropType.ExYaoShui:
                switch (quality)
                {
                    case 5: return 2005; // 经验加成药水
                    default: return 0;
                }

            // 掉落药水 (2100系列)
            case PropType.DiaoLuoYaoShui:
                switch (quality)
                {
                    case 5: return 2105; // 掉落加成药水
                    default: return 0;
                }

            // 技能书 (2200系列)
            case PropType.SkillShu:
                switch (quality)
                {
                    case 1: return 2201;
                    case 2: return 2202;
                    case 3: return 2203;
                    case 4: return 2204;
                    case 5: return 2205;
                    case 6: return 2206;
                    default: return 0;
                }

            // 打孔石 (2300系列)
            case PropType.DaKongShi:
                switch (quality)
                {
                    case 5: return 2405; // 打孔石
                    default: return 0;
                }
                
            case PropType.ChongWuShiWu:
                switch (quality)
                {
                    case 1:
                        return 2301;
                    case 2:
                        return 2302;
                    case 3:
                        return 2303;
                    case 4:
                        return 2304;
                    case 5:
                        return 2305;
                    case 6:
                        return 2306;
                    default:
                        return 0;
                }
            default:
                return 0;
        }
    }

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
        XiSuiYe,
        XueMaiDan,
        HpYaoShui,
        ExYaoShui,
        DiaoLuoYaoShui,
        SkillShu,
        ChongWuShiWu,
        DaKongShi,
        ChiBangFight
    }

    public static Dictionary<int, string> PropNameDic = new Dictionary<int, string>()
    {
        { 101, "普通武器碎片" },
        { 102, "优秀武器碎片" },
        { 103, "精良武器碎片" },
        { 104, "史诗武器碎片" },
        { 105, "传说武器碎片" },
        { 106, "神话武器碎片" },

        { 201, "普通精粹" },
        { 202, "优秀精粹" },
        { 203, "精良精粹" },
        { 204, "史诗精粹" },
        { 205, "传说精粹" },
        { 206, "神话精粹" },

        { 301, "附魔之骨" },
        { 302, "黄金之血" },
        { 303, "巨大牙齿" },
        { 304, "罪恶眼珠" },
        { 305, "神话之心" },

        { 401, "普通羽毛" },
        { 402, "优秀羽毛" },
        { 403, "精良羽毛" },
        { 404, "史诗羽毛" },
        { 405, "传说羽毛" },
        { 406, "神话羽毛" },

        { 601, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName },
        { 602, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName },
        { 603, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName },
        { 604, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName },
        { 605, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName },
        { 606, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName },

        { 701, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName },
        { 702, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName },
        { 703, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName },
        { 704, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName },
        { 705, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName },
        { 706, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName },

        { 801, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName },
        { 802, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName },
        { 803, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName },
        { 804, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName },
        { 805, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName },
        { 806, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName },

        { 901, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName },
        { 902, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName },
        { 903, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName },
        { 904, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName },
        { 905, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName },
        { 906, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName },

        { 1001, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName },
        { 1002, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName },
        { 1003, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName },
        { 1004, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName },
        { 1005, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName },
        { 1006, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName },

        { 1101, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName },
        { 1102, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName },
        { 1103, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName },
        { 1104, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName },
        { 1105, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName },
        { 1106, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName },

        { 1201, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName },
        { 1202, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName },
        { 1203, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName },
        { 1204, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName },
        { 1205, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName },
        { 1206, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName },

        { 1301, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName },
        { 1302, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName },
        { 1303, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName },
        { 1304, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName },
        { 1305, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName },
        { 1306, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName },

        { 1401, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName },
        { 1402, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName },
        { 1403, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName },
        { 1404, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName },
        { 1405, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName },
        { 1406, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName },

        { 1501, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName },
        { 1502, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName },
        { 1503, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName },
        { 1504, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName },
        { 1505, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName },
        { 1506, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName },
        
        { 1603,"普通宠物蛋" },
        { 1605,"高级宠物蛋" },
        
        { 1703,"普通洗髓液" },
        { 1705,"高级洗髓液" },
        
        { 1803,"普通血脉丹" },
        { 1805,"高级血脉丹" },
        
        { 1901,"初级治疗药剂" },
        { 1902,"中级治疗药剂" },
        { 1903,"高级治疗药剂" },
        { 1904,"史诗治疗药剂" },
        { 1905,"传说治疗药剂" },
        { 1906,"神话治疗药剂" },
        
        { 2005,"学识药剂" },
        { 2105,"幸运药剂" },

        { 2201,"初级宠物技能书" },
        { 2202,"中级宠物技能书" },
        { 2203,"高级宠物技能书" },
        { 2204,"史诗宠物技能书" },
        { 2205,"传说宠物技能书" },
        { 2206,"神话宠物技能书" },
        
        { 2305,"打孔石" },

    };


    public static Dictionary<int, string> PropDescDic = new Dictionary<int, string>()
    {
        { 101, "普通武器破碎而成，可用于解锁初级武器" },
        { 102, "带有一丝灵性的碎片，可以用来解锁武器" },
        { 103, "难得一见的碎片，可解锁高级武器" },
        { 104, "远古战场遗留，可用于解锁史诗武器" },
        { 105, "传说中神器的碎片，或许可以拼凑出远古的神器！" },
        { 106, "混沌中诞生，武器的终极！" },

        { 201, "普通精粹，基础材料，用于初阶进阶" },
        { 202, "蕴含微弱能量的精粹，可提升装备潜能" },
        { 203, "纯度较高的精粹，可触发高级进阶" },
        { 204, "远古残晶，能解锁史诗级潜能" },
        { 205, "传说之精粹，或可唤醒古老力量" },
        { 206, "创生与毁灭凝聚，进阶的终极芯核" },

        { 301, "充满纹路的传说之骨，用于神话合成" },
        { 302, "金黄色血液，用于神话合成" },
        { 303, "传说生物的牙齿，用于神话合成" },
        { 304, "恶魔的眼珠，用于神话合成" },
        { 305, "诞生于创生与毁灭之间，用于进阶的终极材料！" },


        { 401, "普通家禽羽毛，轻盈可作装饰" },
        { 402, "精致羽毛，能稍增飞行与灵活" },
        { 403, "稀有羽毛，强化翅膀增强战力" },
        { 404, "战羽遗留，蕴含着磅礴之力" },
        { 405, "传说羽翎，承载远古飞兽的力量印记" },
        { 406, "羽端汇星辰，跨界之羽，进阶的终极之选" },

        { 601, "天地灵气所钟，大幅增强生命本源" },
        { 602, "天地灵气所钟，大幅增强生命本源" },
        { 603, "天地灵气所钟，大幅增强生命本源" },
        { 604, "天地灵气所钟，大幅增强生命本源" },
        { 605, "天地灵气所钟，大幅增强生命本源" },
        { 606, "天地灵气所钟，大幅增强生命本源" },

        { 701, "龙血浇灌而成，赋予生命与毁灭之力" },
        { 702, "龙血浇灌而成，赋予生命与毁灭之力" },
        { 703, "龙血浇灌而成，赋予生命与毁灭之力" },
        { 704, "龙血浇灌而成，赋予生命与毁灭之力" },
        { 705, "龙血浇灌而成，赋予生命与毁灭之力" },
        { 706, "龙血浇灌而成，赋予生命与毁灭之力" },

        { 801, "温养魂魄之玉，让生命与暴击完美共鸣" },
        { 802, "温养魂魄之玉，让生命与暴击完美共鸣" },
        { 803, "温养魂魄之玉，让生命与暴击完美共鸣" },
        { 804, "温养魂魄之玉，让生命与暴击完美共鸣" },
        { 805, "温养魂魄之玉，让生命与暴击完美共鸣" },
        { 806, "温养魂魄之玉，让生命与暴击完美共鸣" },

        { 901, "不屈战魂所化，铸就钢铁般的生命防线" },
        { 902, "不屈战魂所化，铸就钢铁般的生命防线" },
        { 903, "不屈战魂所化，铸就钢铁般的生命防线" },
        { 904, "不屈战魂所化，铸就钢铁般的生命防线" },
        { 905, "不屈战魂所化，铸就钢铁般的生命防线" },
        { 906, "不屈战魂所化，铸就钢铁般的生命防线" },

        { 1001, "白虎凶星之力，纯粹追求极致的物理破坏" },
        { 1002, "白虎凶星之力，纯粹追求极致的物理破坏" },
        { 1003, "白虎凶星之力，纯粹追求极致的物理破坏" },
        { 1004, "白虎凶星之力，纯粹追求极致的物理破坏" },
        { 1005, "白虎凶星之力，纯粹追求极致的物理破坏" },
        { 1006, "白虎凶星之力，纯粹追求极致的物理破坏" },

        { 1101, "凝结杀戮精华，让每一次攻击都直指要害" },
        { 1102, "凝结杀戮精华，让每一次攻击都直指要害" },
        { 1103, "凝结杀戮精华，让每一次攻击都直指要害" },
        { 1104, "凝结杀戮精华，让每一次攻击都直指要害" },
        { 1105, "凝结杀戮精华，让每一次攻击都直指要害" },
        { 1106, "凝结杀戮精华，让每一次攻击都直指要害" },

        { 1201, "攻防一体奇石，在坚固堡垒中暗藏杀机" },
        { 1202, "攻防一体奇石，在坚固堡垒中暗藏杀机" },
        { 1203, "攻防一体奇石，在坚固堡垒中暗藏杀机" },
        { 1204, "攻防一体奇石，在坚固堡垒中暗藏杀机" },
        { 1205, "攻防一体奇石，在坚固堡垒中暗藏杀机" },
        { 1206, "攻防一体奇石，在坚固堡垒中暗藏杀机" },

        { 1301, "窥见命运裂隙，将战斗的胜负归于概率之神" },
        { 1302, "窥见命运裂隙，将战斗的胜负归于概率之神" },
        { 1303, "窥见命运裂隙，将战斗的胜负归于概率之神" },
        { 1304, "窥见命运裂隙，将战斗的胜负归于概率之神" },
        { 1305, "窥见命运裂隙，将战斗的胜负归于概率之神" },
        { 1306, "窥见命运裂隙，将战斗的胜负归于概率之神" },

        { 1401, "完美格挡反击，从绝对防御中寻得制胜一击" },
        { 1402, "完美格挡反击，从绝对防御中寻得制胜一击" },
        { 1403, "完美格挡反击，从绝对防御中寻得制胜一击" },
        { 1404, "完美格挡反击，从绝对防御中寻得制胜一击" },
        { 1405, "完美格挡反击，从绝对防御中寻得制胜一击" },
        { 1406, "完美格挡反击，从绝对防御中寻得制胜一击" },

        { 1501, "背负玄武之子，将自身化为不可逾越的叹息之墙" },
        { 1502, "背负玄武之子，将自身化为不可逾越的叹息之墙" },
        { 1503, "背负玄武之子，将自身化为不可逾越的叹息之墙" },
        { 1504, "背负玄武之子，将自身化为不可逾越的叹息之墙" },
        { 1505, "背负玄武之子，将自身化为不可逾越的叹息之墙" },
        { 1506, "背负玄武之子，将自身化为不可逾越的叹息之墙" },

        { 1603, "普通宠物蛋，开出普通，优秀，精良，史诗的概率分别为40%，30%，20%，10%" },
        { 1605, "高级宠物蛋，开出普通，优秀，精良，史诗，传说的概率分别为20%，25%，30%，20%，5%" },

        { 1703, "普通洗髓液，可以对史诗品质以下的宠物进行资质重置" },
        { 1705, "高级洗髓液，可以对所有品质的宠物进行资质重置" },

        { 1803, "普通血脉丹，可以对史诗品质以下的宠物进行血脉重置" },
        { 1805, "高级血脉丹，可以对所有品质的宠物进行血脉重置" },

        { 1901, "在战斗中使用可以回复100Hp" },
        { 1902, "在战斗中使用可以回复300Hp" },
        { 1903, "在战斗中使用可以回复500Hp" },
        { 1904, "在战斗中使用可以回复1000Hp" },
        { 1905, "在战斗中使用可以回复20%Hp" },
        { 1906, "在战斗中使用可以回复50%Hp" },

        { 2005, "使用后获得持续10分钟的30%经验加成" },

        { 2105, "使用后获得持续10分钟的20%掉落加成" },

        { 2201, "可以升级一级以下的宠物技能" },
        { 2202, "可以升级二级以下的宠物技能" },
        { 2203, "可以升级三级以下的宠物技能" },
        { 2204, "可以升级四级以下的宠物技能" },
        { 2205, "可以升级五级以下的宠物技能" },
        { 2206, "可以升级六级以下的宠物技能" },

        { 2305, "可以对五孔以下的装备打出一个孔，一个装备限用一次" },

    };
}
