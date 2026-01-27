using System.Collections.Generic;

namespace Config
{
    public enum BaoShiType
    {
        None,
        HH,
        HA,
        HC,
        HD,
        AA,
        AC,
        AD,
        CC,
        CD,
        DD
    }

    public enum BaseAttribute
    {
        None,
        Attack,
        Crit,
        Defense,
        Hp
    }

    public class BaoShiInfo
    {
        public BaoShiType BaoShiType;
        public int Quality;
    }
    public class BaoShiAttribute
    {
        public BaoShiAttributeItem BaoShiAttributeItem1;
        public BaoShiAttributeItem BaoShiAttributeItem2;
    }

    public class BaoShiAttributeItem
    {
        public BaseAttribute BaseAttribute;
        public float Count;
    }

    public class BaoShiTeXiao
    {
        public string TeXiao3;
        public string TeXiao5;
    }
    public class BaoShiConfig
    {
        public static Dictionary<BaoShiType, string> BaoShiNameDic = new Dictionary<BaoShiType, string>()
        {
            { BaoShiType.HH, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHName},
            { BaoShiType.HA, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HAName},
            { BaoShiType.HC, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCName},
            { BaoShiType.HD, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDName},
            { BaoShiType.AA, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AAName},
            { BaoShiType.AC, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACName},
            { BaoShiType.AD, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADName},
            { BaoShiType.CC, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCName},
            { BaoShiType.CD, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDName},
            { BaoShiType.DD, LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDName},
        };

        public static Dictionary<BaoShiType, BaoShiTeXiao> BaoShiTeXiaoDic = new Dictionary<BaoShiType, BaoShiTeXiao>()
        {
            { BaoShiType.HH,new BaoShiTeXiao(){TeXiao3 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao3,TeXiao5 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HHTeXiao5}},
            { BaoShiType.HA,new BaoShiTeXiao(){TeXiao3 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao3,TeXiao5 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HATeXiao5}},
            { BaoShiType.HC,new BaoShiTeXiao(){TeXiao3 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao3,TeXiao5 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HCTeXiao5}},
            { BaoShiType.HD,new BaoShiTeXiao(){TeXiao3 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao3,TeXiao5 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.HDTeXiao5}},
            { BaoShiType.AA,new BaoShiTeXiao(){TeXiao3 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao3,TeXiao5 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.AATeXiao5}},
            { BaoShiType.AC,new BaoShiTeXiao(){TeXiao3 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao3,TeXiao5 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ACTeXiao5}},
            { BaoShiType.AD,new BaoShiTeXiao(){TeXiao3 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao3,TeXiao5 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.ADTeXiao5}},
            { BaoShiType.CC,new BaoShiTeXiao(){TeXiao3 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao3,TeXiao5 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CCTeXiao5}},
            { BaoShiType.CD,new BaoShiTeXiao(){TeXiao3 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao3,TeXiao5 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.CDTeXiao5}},
            { BaoShiType.DD,new BaoShiTeXiao(){TeXiao3 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao3,TeXiao5 = LanguageConfig.LanguageItems[PlayerData.S.langType].BaoShiLanguage.DDTeXiao5}},
        };

        public static Dictionary<BaoShiInfo, BaoShiAttribute> BaoShiAttributeDic =
            new Dictionary<BaoShiInfo, BaoShiAttribute>()
            {
                {new BaoShiInfo(){BaoShiType = BaoShiType.AA,Quality = 1},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.3f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.3f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AA,Quality = 2},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.4f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.4f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AA,Quality = 3},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.5f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.5f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AA,Quality = 4},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.6f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.6f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AA,Quality = 5},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.8f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.8f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AA,Quality = 6},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 1f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 1f}}},
                
                {new BaoShiInfo(){BaoShiType = BaoShiType.AC,Quality = 1},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.3f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.3f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AC,Quality = 2},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.4f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.4f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AC,Quality = 3},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.5f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.5f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AC,Quality = 4},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.6f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.6f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AC,Quality = 5},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.8f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.8f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AC,Quality = 6},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 1f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 1f}}},
                
                {new BaoShiInfo(){BaoShiType = BaoShiType.AD,Quality = 1},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.3f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.3f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AD,Quality = 2},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.4f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.4f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AD,Quality = 3},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.5f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.5f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AD,Quality = 4},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.6f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.6f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AD,Quality = 5},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.8f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.8f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.AD,Quality = 6},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 1f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 1f}}},
                
                {new BaoShiInfo(){BaoShiType = BaoShiType.HH,Quality = 1},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.3f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.3f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HH,Quality = 2},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.4f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.4f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HH,Quality = 3},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.5f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.5f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HH,Quality = 4},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.6f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.6f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HH,Quality = 5},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.8f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.8f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HH,Quality = 6},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 1f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 1f}}},
                
                {new BaoShiInfo(){BaoShiType = BaoShiType.HA,Quality = 1},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.3f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.3f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HA,Quality = 2},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.4f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.4f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HA,Quality = 3},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.5f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.5f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HA,Quality = 4},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.6f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.6f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HA,Quality = 5},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.8f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 0.8f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HA,Quality = 6},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 1f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Attack,Count = 1f}}},
                
                {new BaoShiInfo(){BaoShiType = BaoShiType.HC,Quality = 1},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.3f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.3f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HC,Quality = 2},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.4f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.4f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HC,Quality = 3},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.5f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.5f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HC,Quality = 4},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.6f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.6f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HC,Quality = 5},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.8f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.8f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HC,Quality = 6},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 1f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 1f}}},
                
                {new BaoShiInfo(){BaoShiType = BaoShiType.HD,Quality = 1},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.3f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.3f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HD,Quality = 2},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.4f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.4f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HD,Quality = 3},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.5f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.5f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HD,Quality = 4},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.6f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.6f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HD,Quality = 5},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 0.8f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.8f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.HD,Quality = 6},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Hp,Count = 1f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 1f}}},
                
                {new BaoShiInfo(){BaoShiType = BaoShiType.CC,Quality = 1},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.3f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.3f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.CC,Quality = 2},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.4f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.4f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.CC,Quality = 3},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.5f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.5f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.CC,Quality = 4},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.6f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.6f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.CC,Quality = 5},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.8f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.8f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.CC,Quality = 6},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 1f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 1f}}},
                
                {new BaoShiInfo(){BaoShiType = BaoShiType.CD,Quality = 1},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.3f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.3f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.CD,Quality = 2},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.4f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.4f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.CD,Quality = 3},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.5f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.5f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.CD,Quality = 4},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.6f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.6f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.CD,Quality = 5},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 0.8f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.8f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.CD,Quality = 6},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Crit,Count = 1f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 1f}}},
                
                {new BaoShiInfo(){BaoShiType = BaoShiType.DD,Quality = 1},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.3f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.3f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.DD,Quality = 2},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.4f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.4f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.DD,Quality = 3},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.5f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.5f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.DD,Quality = 4},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.6f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.6f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.DD,Quality = 5},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.8f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 0.8f}}},
                {new BaoShiInfo(){BaoShiType = BaoShiType.DD,Quality = 6},new BaoShiAttribute(){BaoShiAttributeItem1=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 1f},BaoShiAttributeItem2=new BaoShiAttributeItem(){BaseAttribute=BaseAttribute.Defense,Count = 1f}}},
                
            };
    }
}