using System.Collections.Generic;
using Config;

namespace Tool
{
    public static class EquipName
    {
        public static Dictionary<string, string> EquipNameDic = new Dictionary<string, string>()
        {
            {"PrimaryCloak", "新手披风"},
            {"PrimaryCloth", "新手衣服"},
            {"PrimaryHelmet", "新手头盔"},
            {"PrimaryNecklace", "新手项链"},
            {"PrimaryRing", "新手戒指"},
            {"PrimaryShoe", "新手鞋子"},
            
            {"GreenCloak", "中级法师披风"},
            {"GreenCloth", "中级法师衣服"},
            {"GreenHelmet", "中级法师头盔"},
            {"GreenNecklace", "中级法师项链"},
            {"GreenRing", "中级法师戒指"},
            {"GreenShoe", "中级法师鞋子"},
            
            {"BlueCloak", "高级法师披风"},
            {"BlueCloth", "高级法师衣服"},
            {"BlueHelmet", "高级法师头盔"},
            {"BlueNecklace", "高级法师项链"},
            {"BlueRing", "高级法师戒指"},
            {"BlueShoe", "高级法师鞋子"},
            
            
            {"TreeManCloak", "树人披风"},
            {"TreeManCloth", "树人衣服"},
            {"TreeManHelmet", "树人头盔"},
            {"TreeManNecklace", "树人项链"},
            {"TreeManRing", "树人戒指"},
            {"TreeManShoe", "树人鞋子"},
            
            
            {"Purple1Cloak", "树人披风"},
            {"Purple1Cloth", "树人衣服"},
            {"Purple1Helmet", "树人头盔"},
            {"Purple1Necklace", "树人项链"},
            {"Purple1Ring", "树人戒指"},
            {"Purple1Shoe", "树人鞋子"},
            
            
            
            {"ZhaoZeCloak", "水泽护手"},
            {"ZhaoZeCloth", "水泽护身衣"},
            {"ZhaoZeHelmet", "水泽盔"},
            {"ZhaoZeNecklace", "水泽项链"},
            {"ZhaoZeRing", "水泽戒指"},
            {"ZhaoZeShoe", "水泽靴"},
            
            
            {"HuoShanCloak", "火山披风"},
            {"HuoShanCloth", "火山衣服"},
            {"HuoShanHelmet", "火山头盔"},
            {"HuoShanNecklace", "火山项链"},
            {"HuoShanRing", "火山戒指"},
            {"HuoShanShoe", "火山鞋子"},
            
            {"PurpleCloak", "虚空披风"},
            {"PurpleCloth", "虚空衣服"},
            {"PurpleHelmet", "虚空头盔"},
            {"PurpleNecklace", "虚空项链"},
            {"PurpleRing", "虚空戒指"},
            {"PurpleShoe", "虚空鞋子"},
            
            {"PurpleCloak1", "雪域披风"},
            {"PurpleCloth1", "雪域衣"},
            {"PurpleHelmet1", "雪域头盔"},
            {"PurpleNecklace1", "雪域项链"},
            {"PurpleRing1", "雪域戒指"},
            {"PurpleShoe1", "雪域鞋子"},
            
            {"OrangeCloak", "炽炎披风"},
            {"OrangeCloth", "炽炎衣服"},
            {"OrangeHelmet", "炽炎头盔"},
            {"OrangeNecklace", "炽炎项链"},
            {"OrangeRing", "炽炎戒指"},
            {"OrangeShoe", "炽炎鞋子"},
            
            {"WhiteJingCui", "白色精粹"},
            {"GreenJingCui", "绿色精粹"},
            {"BlueJingCui", "蓝色精粹"},
            {"PurpleJingCui", "紫色精粹"},
            {"OrangeJingCui", "橙色精粹"},
            {"RedJingCui", "红色精粹"},
            
            {"WhiteWeaponFragment", "白色武器碎片"},
            {"GreenWeaponFragment", "绿色武器碎片"},
            {"BlueWeaponFragment", "蓝色武器碎片"},
            {"PurpleWeaponFragment", "紫色武器碎片"},
            {"OrangeWeaponFragment", "橙色武器碎片"},
            {"RedWeaponFragment", "红色武器碎片"},
            
            {"FuMoZhiGu", "附魔之骨"},
            {"GoldBlood", "黄金之血"},
            {"JuDaYaChi", "巨大牙齿"},
            {"ZuiEYanZhu", "罪恶眼珠"},
            
            {"WhiteChiBang", "碧蓝之羽"},
            {"GreenChiBang", "羽翎之羽"},
            {"BlueChiBang", "深空之羽"},
            {"PurpleChiBang", "妖异之羽"},
            {"OrangeChiBang", "黑虚之羽"},
            {"RedChiBang", "无端之羽"},
            
            {"HH1", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName},
            {"HH2", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName},
            {"HH3", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName},
            {"HH4", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName},
            {"HH5", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName},
            {"HH6", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName},
            
            {"HA1", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName},
            {"HA2", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName},
            {"HA3", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName},
            {"HA4", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName},
            {"HA5", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName},
            {"HA6", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName},
            
            {"HC1", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName},
            {"HC2", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName},
            {"HC3", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName},
            {"HC4", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName},
            {"HC5", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName},
            {"HC6", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName},
            
            {"HD1", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName},
            {"HD2", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName},
            {"HD3", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName},
            {"HD4", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName},
            {"HD5", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName},
            {"HD6", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName},
            
            {"AA1", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName},
            {"AA2", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName},
            {"AA3", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName},
            {"AA4", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName},
            {"AA5", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName},
            {"AA6", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName},
            
            {"AC1", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName},
            {"AC2", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName},
            {"AC3", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName},
            {"AC4", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName},
            {"AC5", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName},
            {"AC6", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName},
            
            {"AD1", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName},
            {"AD2", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName},
            {"AD3", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName},
            {"AD4", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName},
            {"AD5", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName},
            {"AD6", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName},
            
            {"CC1", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName},
            {"CC2", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName},
            {"CC3", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName},
            {"CC4", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName},
            {"CC5", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName},
            {"CC6", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName},
            
            {"CD1", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName},
            {"CD2", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName},
            {"CD3", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName},
            {"CD4", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName},
            {"CD5", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName},
            {"CD6", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName},
            
            {"DD1", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName},
            {"DD2", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName},
            {"DD3", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName},
            {"DD4", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName},
            {"DD5", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName},
            {"DD6", LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName},
        };
    }
}