using System.Collections.Generic;

namespace Config
{
    public enum LanguageType
    {
        None,
        English,
        Chinese,
        Han,
        Ri
    }

    public class RoleWindowLanguage
    {
        public string TuJian;
        public string WuQi;
        public string Bag;
        public string ChiBang;
        public string Skill;
        public string Setting;
        public string DuanZao;
        public string StartGame;
    }

    public class MonsterBookWindowLanguage
    {
        public string MonsterName;
        public string DiDian;
        public string MonsterType;
        public string LevelName1;
        public string LevelName2;
        public string LevelName3;
        public string LevelName4;
        public string LevelName5;
        public string LevelName6;
        public string DiaoLuoList;

        public string Snot;
        public string Spider;
        public string Bat;
        public string Bee;
        public string TreeMan;
        public string XiaoHuo;
        public string DaZui;
        public string DunDi;

        public string ChongZi;
        public string HuoShanBoss;
        public string QingWa;
        public string WenZi;
        public string ShiRenHua;
        public string JiaChong;
        public string ZhaoZeBoss;
        public string ShaNiao;

        public string ShaChong;
        public string ShaXiYi;
        public string XianRenZhang;
        public string XieZi;
        public string XueRen;
        public string XueZhangLang;
        public string XueQiE;
        public string YingShu;
        public string XueRenBoss;
    }

    public class WeaponWindowLanguage
    {
        public string Weapon;
        public string Install;
        public string YiInstall;
        public string ShenJi;
        public string JieSuo;

        public string WeaponName1;
        public string WeaponName2;
        public string WeaponName3;
        public string WeaponName4;
        public string WeaponName5;
        public string WeaponName6;
        public string WeaponName7;
        public string WeaponName8;

        public string Desc1;
        public string Desc2;
        public string Desc3;
        public string Desc4;
        public string Desc5;
        public string Desc6;
        public string Desc7;
        public string Desc8;

        public string TeXiao1;
        public string TeXiao2;
        public string TeXiao3;
        public string TeXiao4;
        public string TeXiao5;
        public string TeXiao6;
        public string TeXiao7;
        public string TeXiao8;
    }


    public class SkillWindowLanguage
    {
        public string Skill;
        public string SkillCount;
        public string ZhuanJinCount;
        public string ZhuDongSkill;
        public string BeiDongSkill;
        public string Level;

        public string NormalAttackName;
        public string NormalAttackDesc;

        public string AttackSpeedName;
        public string AttackSpeedDesc;

        public string DashName;
        public string DashDesc;

        public string DashCdName;
        public string DashCdDesc;

        public string CritName;
        public string CritDesc;

        public string CritDamageName;
        public string CritDamageDesc;

        public string MoveSpeedName;
        public string MoveSpeedDesc;

        public string MoveAddDefenseName;
        public string MoveAddDefenseDesc;

        public string MoveAddAttackName;
        public string MoveAddAttackDesc;

        public string Skill1Name;
        public string Skill1Desc;

        public string Skill2Name;
        public string Skill2Desc;

        public string Skill3Name;
        public string Skill3Desc;

        public string Skill1CdName;
        public string Skill1CdDesc;

        public string Skill2CdName;
        public string Skill2CdDesc;

        public string Skill3CdName;
        public string Skill3CdDesc;

        public string Skill1RangeName;
        public string Skill1RangeDesc;

        public string Skill1YiDianName;
        public string Skill1YiDianDesc;

        public string Skill2TimeName;
        public string Skill2TimeDesc;

        public string Skill2AddDefenseName;
        public string Skill2AddDefenseDesc;

        public string Skill3RangeName;
        public string Skill3RangeDesc;

        public string Skill3JianSuName;
        public string Skill3JianSuDesc;

        public string AttackName;
        public string AttackDesc;

        public string HpName;
        public string HpDesc;

        public string DefenseName;
        public string DefenseDesc;

        public string CritMonsterName;
        public string CritMonsterDesc;
    }

    public class BaseLanguage
    {
        public string Quality;
        public string NormalAttack;
        public string NormalAttackSpeed;
        public string Crit;
        public string CritDamage;
        public string Hp;
        public string Defense;
        public string MoveSpeed;
        public string DiaoBao;
        public string FinalDamage;
        public string WhiteQuality;
        public string GreenQuality;
        public string BlueQuality;
        public string PurpleQuality;
        public string OrangeQuality;
        public string RedQuality;
    }

    public class ChiBangWindowLanguage
    {
        public string JieSuoDesc;
        public string ChiBangName1;
        public string ChiBangName2;
        public string ChiBangName3;
        public string ChiBangName4;
        public string ChiBangName5;
        public string ChiBangName6;


        public string Desc1;
        public string Desc2;
        public string Desc3;
        public string Desc4;
        public string Desc5;
        public string Desc6;
    }

    public class BagWindowLanguage
    {
        public string Bag;
        public string Equip;
        public string Prop;
        public string DetailAttribute;
        public string FenJie;
    }

    public class PropLanguage
    {
        public string WhiteWeaponFragment;
        public string GreenWeaponFragment;
        public string BlueWeaponFragment;
        public string PurpleWeaponFragment;
        public string OrangeWeaponFragment;
        public string RedWeaponFragment;

        public string WhiteJingCui;
        public string GreenJingCui;
        public string BlueJingCui;
        public string PurpleJingCui;
        public string OrangeJingCui;
        public string RedJingCui;

        public string ShenHuaZhiXin;
        public string JuDaYaChi;
        public string FuMoZhiGu;
        public string GoldBlood;
        public string ZuiEYanZhu;

        public string LinHun;
    }

    public class DuanZaoWindowLanguage
    {
        public string HeCheng;
        public string XiLian;
        public string JinJie;
        public string WeaponFragment;
        public string JingCui;
        public string YiJianHeCheng;
    }

    public class GameLevelWindowLanguage
    {
        public string TuiJianLevel;
        public string MonsterList;
        public string TiaoZhan;
    }

    public class SettingWindowLanguage
    {
        public string Language;
        public string Audio;
        public string ZhongWen;
        public string YingWen;
        public string RiWen;
        public string HanWen;

    }

    public class LanguageItem
    {
        public RoleWindowLanguage RoleWindowLanguage;
        public MonsterBookWindowLanguage MonsterBookWindowLanguage;
        public WeaponWindowLanguage WeaponWindowLanguage;
        public SkillWindowLanguage SkillWindowLanguage;
        public BaseLanguage BaseLanguage;
        public ChiBangWindowLanguage ChiBangWindowLanguage;
        public BagWindowLanguage BagWindowLanguage;
        public PropLanguage PropLanguage;
        public DuanZaoWindowLanguage DuanZaoWindowLanguage;
        public GameLevelWindowLanguage GameLevelWindowLanguage;
        public SettingWindowLanguage SettingWindowLanguage;
    }

    public class LanguageConfig
    {
        public static Dictionary<LanguageType, LanguageItem> LanguageItems =
            new Dictionary<LanguageType, LanguageItem>()
            {
                // 中文（原有）
                {
                    LanguageType.Chinese, new LanguageItem()
                    {
                        RoleWindowLanguage = new RoleWindowLanguage()
                        {
                            TuJian = "图鉴", WuQi = "武器", Bag = "背包", ChiBang = "翅膀", Skill = "技能", Setting = "设置",
                            DuanZao = "锻造", StartGame = "开始"
                        },
                        MonsterBookWindowLanguage = new MonsterBookWindowLanguage()
                        {
                            MonsterName = "怪物名称", DiDian = "出没地点", MonsterType = "怪物类型", LevelName1 = "寂静森林",
                            LevelName2 = "熔岩火山", LevelName3 = "迷雾沼泽", LevelName4 = "死亡沙漠", LevelName5 = "北境雪域",
                            LevelName6 = "异界",
                            DiaoLuoList = "掉落列表", Snot = "粘液怪", Bat = "夜翼蝠", Spider = "织网蛛", Bee = "刃翅魔蜂",
                            TreeMan = "森林守护者", XiaoHuo = "熔岩鬼火", DunDi = "熔岩蠕虫", ChongZi = "火山虫", DaZui = "熔岩巨螯",
                            HuoShanBoss = "熔岩行者", JiaChong = "刺壳兽", QingWa = "沼泽蟾蜍", WenZi = "红眼蝇", ShiRenHua = "血花妖",
                            ZhaoZeBoss = "泥沼龙王", ShaNiao = "红羽鸟", ShaChong = "沙丘甲虫", XianRenZhang = "死亡仙人掌",
                            ShaXiYi = "紫魔蜥", XieZi = "沙影蝎王", XueRen = "野雪人", XueZhangLang = "雪蟑螂", XueQiE = "雪企鹅",
                            YingShu = "银角鼠", XueRenBoss = "雪山泰坦",
                        },
                        WeaponWindowLanguage = new WeaponWindowLanguage()
                        {
                            Weapon = "武器", Install = "装备", YiInstall = "已装备", ShenJi = "升级", JieSuo = "解锁",
                            WeaponName1 = "原木法杖", WeaponName2 = "腐蚀权杖", WeaponName3 = "三叉法杖", WeaponName4 = "虚空法杖",
                            WeaponName5 = "爆炎杖", WeaponName6 = "源极杖", WeaponName7 = "湮灭之杖", WeaponName8 = "刀光剑影",
                            Desc1 = "新手法师的第一个武器，当你登临至高时或许会发现它的潜力！", Desc2 = "腐蚀之毒缠绕杖尖，一击即中，血肉难复。",
                            Desc3 = "三叉聚灵，一念三分，子弹如雨，封锁前方空间。", Desc4 = "虚空裂隙束于杖端，一束贯穿千军，无物可挡。",
                            Desc5 = "炽焰凝聚成核，命中即爆，烈焰焚尽视野之内。", Desc6 = "源极之力缓缓涌动，圆形魔弹穿体蚀魂不止。",
                            Desc7 = "湮灭魔核缓缓前行，接触蚀骨，终至终点化作毁天之炎。", Desc8 = "杖尖凝剑意，流光破空，一击贯长虹。",
                            TeXiao1 = "攻击特效：毫无特色的平A，造成100%攻击力的伤害", TeXiao2 = "攻击特效：攻击造成100%的伤害，并且附带剧毒，每秒造成20%伤害，持续3s",
                            TeXiao3 = "攻击特效：一分为三，每个魔法弹造成100%攻击力伤害", TeXiao4 = "攻击特效：魔法弹可以穿透敌人，并造成100%攻击力的伤害。",
                            TeXiao5 = "攻击特效：爆炎弹对击中敌人造成100%的攻击力伤害，击中敌人后爆炸，再次造成150%的伤害。",
                            TeXiao6 = "攻击特效：发射源弹对触碰的敌人持续造成150%攻击力的伤害。",
                            TeXiao7 = "攻击特效：湮灭弹对触碰的敌人持续造成100%的伤害，随后湮灭坍塌，造成500%的伤害。",
                            TeXiao8 = "攻击特效：快速发射剑气穿透敌人，并造成100%的伤害"
                        },
                        SkillWindowLanguage = new SkillWindowLanguage()
                        {
                            Skill = "技能",
                            SkillCount = "技能点",
                            ZhuanJinCount = "专精点",
                            ZhuDongSkill = "主动技能",
                            BeiDongSkill = "被动技能",
                            Level = "等级",
                            NormalAttackName = "普通攻击",
                            NormalAttackDesc = "每级提供普通攻击 5% 的伤害",

                            AttackSpeedName = "攻击速度",
                            AttackSpeedDesc = "每级提供 5% 攻击速度",

                            DashName = "瞬身",
                            DashDesc = "向前瞬移一段距离",

                            DashCdName = "瞬身冷却",
                            DashCdDesc = "每级减少瞬身冷却 5%",

                            CritName = "暴击",
                            CritDesc = "每级提供暴击率 5%",

                            CritDamageName = "暴击伤害",
                            CritDamageDesc = "每级提供暴击伤害 5%",

                            MoveSpeedName = "移动速度",
                            MoveSpeedDesc = "每级提供基础移动速度 0.3",

                            MoveAddDefenseName = "疾行如水",
                            MoveAddDefenseDesc = "每级提供移动时防御 5%",

                            MoveAddAttackName = "疾行如火",
                            MoveAddAttackDesc = "每级提供移动时攻击力 5%",

                            Skill1Name = "电光风暴",
                            Skill1Desc = "每级额外提供电光风暴伤害 5%",

                            Skill2Name = "冰晶星轮",
                            Skill2Desc = "每级额外提供冰晶星轮伤害 5%",

                            Skill3Name = "极寒冲击",
                            Skill3Desc = "每级额外提供极寒冲击伤害 5%",

                            Skill1CdName = "冷却缩减",
                            Skill1CdDesc = "每级减少电光风暴冷却 5%",

                            Skill2CdName = "冷却缩减",
                            Skill2CdDesc = "每级减少冰晶星轮冷却 5%",

                            Skill3CdName = "冷却缩减",
                            Skill3CdDesc = "每级减少极寒冲击冷却 5%",

                            Skill1RangeName = "风暴扩增",
                            Skill1RangeDesc = "每级增加电光风暴作用范围 5%",

                            Skill1YiDianName = "易电状态",
                            Skill1YiDianDesc = "每级提供被电光风暴击中后额外受到 5% 的伤害",

                            Skill2TimeName = "持续时间",
                            Skill2TimeDesc = "每级增加冰晶星轮持续时间 0.5s",

                            Skill2AddDefenseName = "星轮护体",
                            Skill2AddDefenseDesc = "每级提供存在冰晶星轮时防御 5%",

                            Skill3RangeName = "极寒延伸",
                            Skill3RangeDesc = "每级增加极寒冲击作用范围 5%",

                            Skill3JianSuName = "极寒冰冻",
                            Skill3JianSuDesc = "每级提供减速效果 5%（持续 3s）",

                            AttackName = "攻击力",
                            AttackDesc = "每级提供基础攻击力 1",

                            HpName = "生命值",
                            HpDesc = "每级提供最大生命值 3",

                            DefenseName = "防御力",
                            DefenseDesc = "每级提供防御力 1",

                            CritMonsterName = "暴击",
                            CritMonsterDesc = "每级提供暴击 3"
                        },
                        BaseLanguage = new BaseLanguage()
                        {
                            Quality = "品质", NormalAttack = "攻击力", NormalAttackSpeed = "攻击速度", Crit = "暴击",
                            CritDamage = "暴击伤害", Hp = "生命值", Defense = "防御", MoveSpeed = "移动速度", DiaoBao = "掉宝值",
                            FinalDamage = "最终伤害", WhiteQuality = "普通", GreenQuality = "优秀", BlueQuality = "精良",
                            PurpleQuality = "史诗", OrangeQuality = "传说", RedQuality = "神话",
                        },
                        ChiBangWindowLanguage = new ChiBangWindowLanguage()
                        {
                            JieSuoDesc = "请使用羽毛提供经验来解锁升级翅膀！", ChiBangName1 = "碧蓝之翼", ChiBangName2 = "羽翎之翼",
                            ChiBangName3 = "深空之翼", ChiBangName4 = "妖异之翼", ChiBangName5 = "黑虚之翼", ChiBangName6 = "无端之翼",
                            Desc1 = "清澈如海，轻盈如云，初学者的第一双翅膀。", Desc2 = "羽翎轻舞，风随心动，展翅翱翔于天际之间。",
                            Desc3 = "深邃如夜空，星光闪烁，承载着探索未知的勇气。", Desc4 = "妖异魅影，紫光流转，蕴含着古老而神秘的力量。",
                            Desc5 = "撕裂虚空，吞噬光明，来自黑暗深渊的禁忌之翼。", Desc6 = "无端而生，超越常理，传说中触及神域的存在。"
                        },
                        BagWindowLanguage = new BagWindowLanguage()
                        {
                            Bag = "背包", Equip = "装备", Prop = "道具", DetailAttribute = "详细属性", FenJie = "一键分解"
                        },
                        PropLanguage = new PropLanguage()
                        {
                            WhiteWeaponFragment = "普通武器碎片", GreenWeaponFragment = "优秀武器碎片",
                            BlueWeaponFragment = "精良武器碎片", PurpleWeaponFragment = "史诗武器碎片",
                            OrangeWeaponFragment = "传说武器碎片", RedWeaponFragment = "神话武器碎片",
                            WhiteJingCui = "普通精粹", GreenJingCui = "优秀精粹", BlueJingCui = "精良精粹", PurpleJingCui = "史诗精粹",
                            OrangeJingCui = "传说精粹", RedJingCui = "神话精粹",
                            ShenHuaZhiXin = "神话之心", JuDaYaChi = "巨大牙齿", GoldBlood = "黄金之血", ZuiEYanZhu = "罪恶眼珠",
                            FuMoZhiGu = "附魔之骨", LinHun = "灵魂"
                        },
                        GameLevelWindowLanguage = new GameLevelWindowLanguage()
                        {
                            TuiJianLevel = "推荐等级", MonsterList = "怪物列表", TiaoZhan = "挑战",
                        },
                        SettingWindowLanguage =  new SettingWindowLanguage()
                        {
                            Language = "语言",Audio = "音效",ZhongWen = "中文",YingWen = "英文",RiWen = "日文",HanWen = "韩文"
                        },
                    }
                },

                // 英语
                {
                    LanguageType.English, new LanguageItem()
                    {
                        RoleWindowLanguage = new RoleWindowLanguage()
                        {
                            TuJian = "Bestiary", WuQi = "Weapon", Bag = "Bag", ChiBang = "Wings", Skill = "Skill",
                            Setting = "Settings", DuanZao = "Forge", StartGame = "Start"
                        },
                        MonsterBookWindowLanguage = new MonsterBookWindowLanguage()
                        {
                            MonsterName = "Monster Name", DiDian = "Location", MonsterType = "Monster Type",
                            LevelName1 = "Silent Forest", LevelName2 = "Lava Volcano", LevelName3 = "Misty Swamp",
                            LevelName6 = "OtherWorld",
                            LevelName4 = "Death Desert", LevelName5 = "Northern Snowfield", DiaoLuoList = "Drop List",
                            Snot = "Slime", Bat = "Nightwing Bat", Spider = "Webweaver Spider",
                            Bee = "Blade-wing Hornet", TreeMan = "Forest Guardian", XiaoHuo = "Lava Wisp",
                            DunDi = "Lava Worm", ChongZi = "Volcano Bug", DaZui = "Lava Pincer",
                            HuoShanBoss = "Lava Walker", JiaChong = "Spike Shell", QingWa = "Swamp Toad",
                            WenZi = "Red-eye Fly", ShiRenHua = "Blood Flower Demon",
                            ZhaoZeBoss = "Mud Swamp Dragon King", ShaNiao = "Red Feather Bird",
                            ShaChong = "Sand Dune Beetle", XianRenZhang = "Death Cactus",
                            ShaXiYi = "Purple Demon Lizard", XieZi = "Sand Shadow Scorpion King",
                            XueRen = "Wild Snowman", XueZhangLang = "Snow Cockroach", XueQiE = "Snow Penguin",
                            YingShu = "Silver Horn Rat", XueRenBoss = "Snow Mountain Titan",
                        },
                        WeaponWindowLanguage = new WeaponWindowLanguage()
                        {
                            Weapon = "Weapon", Install = "Equip", YiInstall = "Equipped", ShenJi = "Upgrade",
                            JieSuo = "Unlock", WeaponName1 = "Log Staff", WeaponName2 = "Corrosion Scepter",
                            WeaponName3 = "Trident Staff", WeaponName4 = "Void Staff", WeaponName5 = "Blazing Staff",
                            WeaponName6 = "Primordial Staff", WeaponName7 = "Annihilation Staff",
                            WeaponName8 = "Sword Light Staff",
                            Desc1 =
                                "The first weapon for novice mages. You might discover its potential when you reach the pinnacle!",
                            Desc2 =
                                "Corrosive poison coils around the tip - one strike, flesh and blood cannot recover.",
                            Desc3 =
                                "Three prongs gather spirit, one thought divides three ways. Bullets rain down, sealing the space ahead.",
                            Desc4 =
                                "Void fissures bound to the staff tip - one beam pierces through armies, nothing can block it.",
                            Desc5 =
                                "Blazing flames condense into a core - upon hit, it explodes, burning everything within sight.",
                            Desc6 =
                                "Primordial power flows slowly - round magic bullets pierce bodies and corrode souls endlessly.",
                            Desc7 =
                                "Annihilation core moves slowly forward - contact corrodes bones, finally collapsing into world-destroying flames.",
                            Desc8 =
                                "Sword intent condenses at the staff tip - flowing light pierces the air, one strike crosses the rainbow.",
                            TeXiao1 = "Attack Effect: Plain attack without special effects, dealing 100% ATK damage",
                            TeXiao2 =
                                "Attack Effect: Attack deals 100% damage and applies poison, dealing 20% damage per second for 3s",
                            TeXiao3 = "Attack Effect: Splits into three, each magic bullet dealing 100% ATK damage",
                            TeXiao4 = "Attack Effect: Magic bullets can penetrate enemies, dealing 100% ATK damage.",
                            TeXiao5 =
                                "Attack Effect: Blazing bullet deals 100% ATK damage on hit, then explodes dealing additional 150% damage.",
                            TeXiao6 =
                                "Attack Effect: Fires primordial bullets that continuously deal 150% ATK damage to touched enemies.",
                            TeXiao7 =
                                "Attack Effect: Annihilation bullet continuously deals 100% damage to touched enemies, then collapses causing 500% damage.",
                            TeXiao8 =
                                "Attack Effect: Rapidly fires sword energy that penetrates enemies, dealing 100% damage."
                        },
                        SkillWindowLanguage = new SkillWindowLanguage()
                        {
                            Skill = "Skill",
                            SkillCount = "Skill Points",
                            ZhuanJinCount = "Mastery Points",
                            ZhuDongSkill = "Active Skills",
                            BeiDongSkill = "Passive Skills",
                            Level = "Level",
                            NormalAttackName = "Normal Attack",
                            NormalAttackDesc = "Increases normal attack damage by 5% per level",

                            AttackSpeedName = "Attack Speed",
                            AttackSpeedDesc = "Increases attack speed by 5% per level",

                            DashName = "Blink",
                            DashDesc = "Teleport forward a short distance",

                            DashCdName = "Blink Cooldown",
                            DashCdDesc = "Reduces blink cooldown by 5% per level",

                            CritName = "Critical Chance",
                            CritDesc = "Increases critical chance by 5% per level",

                            CritDamageName = "Critical Damage",
                            CritDamageDesc = "Increases critical damage by 5% per level",

                            MoveSpeedName = "Movement Speed",
                            MoveSpeedDesc = "Increases base movement speed by 0.3 per level",

                            MoveAddDefenseName = "Swift as Water",
                            MoveAddDefenseDesc = "Increases defense by 5% while moving per level",

                            MoveAddAttackName = "Swift as Fire",
                            MoveAddAttackDesc = "Increases attack power by 5% while moving per level",

                            Skill1Name = "Lightning Storm",
                            Skill1Desc = "Increases Lightning Storm damage by 5% per level",

                            Skill2Name = "Crystal Star Wheel",
                            Skill2Desc = "Increases Crystal Star Wheel damage by 5% per level",

                            Skill3Name = "Arctic Impact",
                            Skill3Desc = "Increases Arctic Impact damage by 5% per level",

                            Skill1CdName = "Cooldown Reduction",
                            Skill1CdDesc = "Reduces Lightning Storm cooldown by 5% per level",

                            Skill2CdName = "Cooldown Reduction",
                            Skill2CdDesc = "Reduces Crystal Star Wheel cooldown by 5% per level",

                            Skill3CdName = "Cooldown Reduction",
                            Skill3CdDesc = "Reduces Arctic Impact cooldown by 5% per level",

                            Skill1RangeName = "Storm Expansion",
                            Skill1RangeDesc = "Increases Lightning Storm range by 5% per level",

                            Skill1YiDianName = "Electro Vulnerability",
                            Skill1YiDianDesc = "Enemies hit by Lightning Storm take 5% additional damage per level",

                            Skill2TimeName = "Duration",
                            Skill2TimeDesc = "Increases Crystal Star Wheel duration by 0.5s per level",

                            Skill2AddDefenseName = "Star Wheel Protection",
                            Skill2AddDefenseDesc =
                                "Increases defense by 5% while Crystal Star Wheel is active per level",

                            Skill3RangeName = "Arctic Extension",
                            Skill3RangeDesc = "Increases Arctic Impact range by 5% per level",

                            Skill3JianSuName = "Arctic Freeze",
                            Skill3JianSuDesc = "Applies 5% slow effect (lasts 3s) per level",

                            AttackName = "Attack Power",
                            AttackDesc = "Increases base attack power by 1 per level",

                            HpName = "Health",
                            HpDesc = "Increases maximum health by 3 per level",

                            DefenseName = "Defense",
                            DefenseDesc = "Increases defense by 1 per level",

                            CritMonsterName = "Critical",
                            CritMonsterDesc = "Increases critical chance by 3 per level"
                        },
                        BaseLanguage = new BaseLanguage()
                        {
                            Quality = "Quality",
                            NormalAttack = "Attack Power",
                            NormalAttackSpeed = "Attack Speed",
                            Crit = "Critical Chance",
                            CritDamage = "Critical Damage",
                            Hp = "Health",
                            Defense = "Defense",
                            MoveSpeed = "Movement Speed",
                            DiaoBao = "Drop Rate",
                            FinalDamage = "Final Damage",
                            WhiteQuality = "Common",
                            GreenQuality = "Uncommon",
                            BlueQuality = "Rare",
                            PurpleQuality = "Epic",
                            OrangeQuality = "Legendary",
                            RedQuality = "Mythic"
                        },
                        ChiBangWindowLanguage = new ChiBangWindowLanguage()
                        {
                            JieSuoDesc = "Please use feathers to provide experience to unlock and upgrade wings!",
                            ChiBangName1 = "Azure Wings",
                            ChiBangName2 = "Feather Plume Wings",
                            ChiBangName3 = "Deep Space Wings",
                            ChiBangName4 = "Eerie Wings",
                            ChiBangName5 = "Void Black Wings",
                            ChiBangName6 = "Ethereal Wings",
                            Desc1 = "Clear as the sea, light as clouds, the first pair of wings for beginners.",
                            Desc2 = "Feathers dance lightly, wind follows the heart, soaring freely through the skies.",
                            Desc3 =
                                "Deep as the night sky, stars twinkling, carrying the courage to explore the unknown.",
                            Desc4 = "Eerie phantom, purple light flowing, containing ancient and mysterious power.",
                            Desc5 = "Tearing through the void, devouring light, forbidden wings from the dark abyss.",
                            Desc6 = "Born without origin, surpassing reason, said to reach the divine realm."
                        },
                        BagWindowLanguage = new BagWindowLanguage()
                        {
                            Bag = "Bag",
                            Equip = "Equipment",
                            Prop = "Items",
                            DetailAttribute = "Detailed Attributes",
                            FenJie = "Auto Disassemble"
                        },
                        PropLanguage = new PropLanguage()
                        {
                            WhiteWeaponFragment = "Common Weapon Fragment",
                            GreenWeaponFragment = "Uncommon Weapon Fragment",
                            BlueWeaponFragment = "Rare Weapon Fragment",
                            PurpleWeaponFragment = "Epic Weapon Fragment",
                            OrangeWeaponFragment = "Legendary Weapon Fragment",
                            RedWeaponFragment = "Mythic Weapon Fragment",

                            WhiteJingCui = "Common Essence",
                            GreenJingCui = "Uncommon Essence",
                            BlueJingCui = "Rare Essence",
                            PurpleJingCui = "Epic Essence",
                            OrangeJingCui = "Legendary Essence",
                            RedJingCui = "Mythic Essence",

                            ShenHuaZhiXin = "Mythic Heart",
                            JuDaYaChi = "Giant Tooth",
                            GoldBlood = "Golden Blood",
                            ZuiEYanZhu = "Sinful Eye",
                            FuMoZhiGu = "Enchanted Bone",
                            LinHun = "Soul"
                        },
                        GameLevelWindowLanguage = new GameLevelWindowLanguage()
                        {
                            TuiJianLevel = "Recommended Level",
                            MonsterList = "Monster List",
                            TiaoZhan = "Challenge"
                        },
                        SettingWindowLanguage = new SettingWindowLanguage()
                        {
                            Language = "Language",
                            Audio = "Audio",
                            ZhongWen = "Chinese",
                            YingWen = "English",
                            RiWen = "Japanese",
                            HanWen = "Korean"
                        }
                    }
                },

                // 韩语
                {
                    LanguageType.Han, new LanguageItem()
                    {
                        RoleWindowLanguage = new RoleWindowLanguage()
                        {
                            TuJian = "도감", WuQi = "무기", Bag = "가방", ChiBang = "날개", Skill = "스킬", Setting = "설정",
                            DuanZao = "제작", StartGame = "시작"
                        },
                        MonsterBookWindowLanguage = new MonsterBookWindowLanguage()
                        {
                            MonsterName = "몬스터 이름", DiDian = "출몰 장소", MonsterType = "몬스터 종류", LevelName1 = "고요한 숲",
                            LevelName2 = "용암 화산", LevelName3 = "안개 늪", LevelName4 = "죽음의 사막", LevelName5 = "북방 설원",
                            LevelName6 = "이계",
                            DiaoLuoList = "드롭 목록", Snot = "슬라임", Bat = "나이트윙 박쥐", Spider = "거미줄 거미", Bee = "칼날 날개 말벌",
                            TreeMan = "숲의 수호자", XiaoHuo = "용암 정령", DunDi = "용암 벌레", ChongZi = "화산 벌레", DaZui = "용암 집게",
                            HuoShanBoss = "용암 행자", JiaChong = "가시 껍질", QingWa = "늪 두꺼비", WenZi = "붉은 눈 파리",
                            ShiRenHua = "피 꽃 요괴", ZhaoZeBoss = "진흙 늪 용왕", ShaNiao = "붉은 깃털 새", ShaChong = "모래 언덕 딱정벌레",
                            XianRenZhang = "죽음의 선인장", ShaXiYi = "보라 마왕 도마뱀", XieZi = "모래 그림자 전갈 왕", XueRen = "야생 설인",
                            XueZhangLang = "눈 바퀴벌레", XueQiE = "눈 펭귄", YingShu = "은 뿔 쥐", XueRenBoss = "설산 타이탄",
                        },
                        WeaponWindowLanguage = new WeaponWindowLanguage()
                        {
                            Weapon = "무기", Install = "장착", YiInstall = "장착됨", ShenJi = "업그레이드", JieSuo = "잠금 해제",
                            WeaponName1 = "통나무 지팡이", WeaponName2 = "부식의 홀", WeaponName3 = "삼지창 지팡이",
                            WeaponName4 = "보이드 지팡이", WeaponName5 = "폭염 지팡이", WeaponName6 = "원극 지팡이",
                            WeaponName7 = "소멸의 지팡이", WeaponName8 = "검광 검영",
                            Desc1 = "초심자 마법사의 첫 무기, 정점에 오를 때 그 잠재력을 발견할지도 모릅니다!",
                            Desc2 = "부식의 독이 지팡이 끝에 휘감겨, 한 방에 명중하면 살과 피가 회복되지 않습니다.",
                            Desc3 = "삼지창이 영기를 모으고, 하나의 생각이 셋으로 나뉘며, 탄환이 비처럼 쏟아져 전방 공간을 봉쇄합니다.",
                            Desc4 = "보이드 균열이 지팡이 끝에 묶여, 한 줄기가 천군을 관통하며 막을 수 있는 것이 없습니다.",
                            Desc5 = "작열하는 화염이 핵으로 응집되어 명중하면 폭발하며, 시야 안의 모든 것을 불태웁니다.",
                            Desc6 = "원극의 힘이 천천히 흐르며, 둥근 마법탄이 몸을 관통하고 영혼을 끊임없이 침식합니다.",
                            Desc7 = "소멸의 마핵이 천천히 전진하며, 접촉하면 뼈를 침식하고, 마침내 종점에 이르러 하늘을 파괴하는 불길로 변합니다.",
                            Desc8 = "지팡이 끝에 검의 의지가 응축되어, 흐르는 빛이 허공을 가르고, 일격이 무지개를 가로지릅니다.",
                            TeXiao1 = "공격 효과: 특색 없는 평타, 100% 공격력의 피해를 줍니다",
                            TeXiao2 = "공격 효과: 공격으로 100%의 피해를 주고, 맹독을 부여하여 초당 20%의 피해를 3초간 줍니다",
                            TeXiao3 = "공격 효과: 셋으로 나뉘어, 각 마법탄이 100% 공격력의 피해를 줍니다",
                            TeXiao4 = "공격 효과: 마법탄이 적을 관통하며, 100% 공격력의 피해를 줍니다.",
                            TeXiao5 = "공격 효과: 폭염탄이 명중한 적에게 100%의 공격력 피해를 주고, 명중한 후 폭발하여 150%의 추가 피해를 줍니다.",
                            TeXiao6 = "공격 효과: 원탄을 발사하여 접촉한 적에게 지속적으로 150% 공격력의 피해를 줍니다.",
                            TeXiao7 = "공격 효과: 소멸탄이 접촉한 적에게 지속적으로 100%의 피해를 주고, 이후 소멸 붕괴로 500%의 피해를 줍니다.",
                            TeXiao8 = "공격 효과: 빠르게 검기를 발사하여 적을 관통하고, 100%의 피해를 줍니다."
                        },
                        SkillWindowLanguage = new SkillWindowLanguage()
                        {
                            Skill = "스킬",
                            SkillCount = "스킬 포인트",
                            ZhuanJinCount = "숙련도 포인트",
                            ZhuDongSkill = "액티브 스킬",
                            BeiDongSkill = "패시브 스킬",
                            Level = "레벨",
                            NormalAttackName = "일반 공격",
                            NormalAttackDesc = "레벨마다 일반 공격 피해 5% 증가",

                            AttackSpeedName = "공격 속도",
                            AttackSpeedDesc = "레벨마다 공격 속도 5% 증가",

                            DashName = "순간이동",
                            DashDesc = "앞으로 짧은 거리 순간이동",

                            DashCdName = "순간이동 쿨다운",
                            DashCdDesc = "레벨마다 순간이동 쿨다운 5% 감소",

                            CritName = "치명타 확률",
                            CritDesc = "레벨마다 치명타 확률 5% 증가",

                            CritDamageName = "치명타 피해",
                            CritDamageDesc = "레벨마다 치명타 피해 5% 증가",

                            MoveSpeedName = "이동 속도",
                            MoveSpeedDesc = "레벨마다 기본 이동 속도 0.3 증가",

                            MoveAddDefenseName = "물처럼 빠름",
                            MoveAddDefenseDesc = "레벨마다 이동 중 방어력 5% 증가",

                            MoveAddAttackName = "불처럼 빠름",
                            MoveAddAttackDesc = "레벨마다 이동 중 공격력 5% 증가",

                            Skill1Name = "전광 폭풍",
                            Skill1Desc = "레벨마다 전광 폭풍 피해 5% 증가",

                            Skill2Name = "수정 별바퀴",
                            Skill2Desc = "레벨마다 수정 별바퀴 피해 5% 증가",

                            Skill3Name = "극한 냉기 충격",
                            Skill3Desc = "레벨마다 극한 냉기 충격 피해 5% 증가",

                            Skill1CdName = "쿨다운 감소",
                            Skill1CdDesc = "레벨마다 전광 폭풍 쿨다운 5% 감소",

                            Skill2CdName = "쿨다운 감소",
                            Skill2CdDesc = "레벨마다 수정 별바퀴 쿨다운 5% 감소",

                            Skill3CdName = "쿨다운 감소",
                            Skill3CdDesc = "레벨마다 극한 냉기 충격 쿨다운 5% 감소",

                            Skill1RangeName = "폭풍 확장",
                            Skill1RangeDesc = "레벨마다 전광 폭풍 범위 5% 증가",

                            Skill1YiDianName = "전기 취약 상태",
                            Skill1YiDianDesc = "레벨마다 전광 폭풍에 맞은 후 추가로 5% 피해를 받음",

                            Skill2TimeName = "지속 시간",
                            Skill2TimeDesc = "레벨마다 수정 별바퀴 지속 시간 0.5초 증가",

                            Skill2AddDefenseName = "별바퀴 보호",
                            Skill2AddDefenseDesc = "레벨마다 수정 별바퀴 발동 중 방어력 5% 증가",

                            Skill3RangeName = "냉기 확장",
                            Skill3RangeDesc = "레벨마다 극한 냉기 충격 범위 5% 증가",

                            Skill3JianSuName = "극한 냉기 동결",
                            Skill3JianSuDesc = "레벨마다 5% 감속 효과 부여 (3초간 지속)",

                            AttackName = "공격력",
                            AttackDesc = "레벨마다 기본 공격력 1 증가",

                            HpName = "체력",
                            HpDesc = "레벨마다 최대 체력 3 증가",

                            DefenseName = "방어력",
                            DefenseDesc = "레벨마다 방어력 1 증가",

                            CritMonsterName = "치명타",
                            CritMonsterDesc = "레벨마다 치명타 확률 3 증가"
                        },
                        BaseLanguage = new BaseLanguage()
                        {
                            Quality = "품질",
                            NormalAttack = "공격력",
                            NormalAttackSpeed = "공격 속도",
                            Crit = "치명타",
                            CritDamage = "치명타 피해",
                            Hp = "생명력",
                            Defense = "방어력",
                            MoveSpeed = "이동 속도",
                            DiaoBao = "드롭률",
                            FinalDamage = "최종 피해",
                            WhiteQuality = "일반",
                            GreenQuality = "고급",
                            BlueQuality = "희귀",
                            PurpleQuality = "에픽",
                            OrangeQuality = "전설",
                            RedQuality = "신화"
                        },
                        ChiBangWindowLanguage = new ChiBangWindowLanguage()
                        {
                            JieSuoDesc = "깃털을 사용하여 경험치를 제공하여 날개를 잠금 해제하고 업그레이드하세요!",
                            ChiBangName1 = "청록색 날개",
                            ChiBangName2 = "깃털 날개",
                            ChiBangName3 = "심우주 날개",
                            ChiBangName4 = "요사스러운 날개",
                            ChiBangName5 = "암흑 공허 날개",
                            ChiBangName6 = "무한한 날개",
                            Desc1 = "바다처럼 맑고 구름처럼 가벼운, 초보자를 위한 첫 번째 날개.",
                            Desc2 = "깃털이 가볍게 춤추며, 바람이 마음을 따라, 하늘 사이를 자유롭게 날아다닙니다.",
                            Desc3 = "밤하늘처럼 깊고 별이 반짝이는, 미지의 세계를 탐험하는 용기를 담았습니다.",
                            Desc4 = "요사스러운 환영, 보라빛이 흐르는, 고대하고 신비로운 힘을 품고 있습니다.",
                            Desc5 = "공허를 찢고 빛을 삼키는, 어둠의 심연에서 온 금기의 날개.",
                            Desc6 = "근원 없이 태어나 이성을 초월한, 신의 영역에 닿는다는 전설의 존재."
                        },
                        BagWindowLanguage = new BagWindowLanguage()
                        {
                            Bag = "가방",
                            Equip = "장비",
                            Prop = "아이템",
                            DetailAttribute = "상세 속성",
                            FenJie = "자동 분해"
                        },
                        PropLanguage = new PropLanguage()
                        {
                            WhiteWeaponFragment = "일반 무기 조각",
                            GreenWeaponFragment = "고급 무기 조각",
                            BlueWeaponFragment = "희귀 무기 조각",
                            PurpleWeaponFragment = "에픽 무기 조각",
                            OrangeWeaponFragment = "전설 무기 조각",
                            RedWeaponFragment = "신화 무기 조각",

                            WhiteJingCui = "일반 정수",
                            GreenJingCui = "고급 정수",
                            BlueJingCui = "희귀 정수",
                            PurpleJingCui = "에픽 정수",
                            OrangeJingCui = "전설 정수",
                            RedJingCui = "신화 정수",

                            ShenHuaZhiXin = "신화의 심장",
                            JuDaYaChi = "거대한 이빨",
                            GoldBlood = "황금의 피",
                            ZuiEYanZhu = "죄악의 눈동자",
                            FuMoZhiGu = "마법 부여된 뼈",
                            LinHun = "영혼"
                        },
                        GameLevelWindowLanguage = new GameLevelWindowLanguage()
                        {
                            TuiJianLevel = "권장 레벨",
                            MonsterList = "몬스터 목록",
                            TiaoZhan = "도전"
                        },
                        SettingWindowLanguage = new SettingWindowLanguage()
                        {
                            Language = "언어",
                            Audio = "오디오",
                            ZhongWen = "중국어",
                            YingWen = "영어",
                            RiWen = "일본어",
                            HanWen = "한국어"
                        },
                    }
                },

                // 日语
                {
                    LanguageType.Ri, new LanguageItem()
                    {
                        RoleWindowLanguage = new RoleWindowLanguage()
                        {
                            TuJian = "図鑑", WuQi = "武器", Bag = "バッグ", ChiBang = "翼", Skill = "スキル", Setting = "設定",
                            DuanZao = "鍛造", StartGame = "始める"
                        },
                        MonsterBookWindowLanguage = new MonsterBookWindowLanguage()
                        {
                            MonsterName = "モンスター名", DiDian = "出現場所", MonsterType = "モンスタータイプ", LevelName1 = "静寂の森",
                            LevelName2 = "溶岩火山", LevelName3 = "霧の沼地", LevelName4 = "死の砂漠", LevelName5 = "北境雪原",
                            LevelName6 = "異界",
                            DiaoLuoList = "ドロップリスト", Snot = "スライム", Bat = "ナイトウィングバット", Spider = "ウェブスパイダー",
                            Bee = "ブレードウィングホーネット", TreeMan = "森の守護者", XiaoHuo = "溶岩ウィスプ", DunDi = "溶岩ワーム",
                            ChongZi = "火山虫", DaZui = "溶岩ハサミ", HuoShanBoss = "溶岩歩き", JiaChong = "スパイクシェル",
                            QingWa = "沼ガエル", WenZi = "赤目ハエ", ShiRenHua = "血花妖魔", ZhaoZeBoss = "泥沼龍王", ShaNiao = "赤羽鳥",
                            ShaChong = "砂丘甲虫", XianRenZhang = "死のサボテン", ShaXiYi = "紫魔トカゲ", XieZi = "砂影蠍王",
                            XueRen = "野生雪男", XueZhangLang = "雪ゴキブリ", XueQiE = "雪ペンギン", YingShu = "銀角鼠",
                            XueRenBoss = "雪山タイタン",
                        },
                        WeaponWindowLanguage = new WeaponWindowLanguage()
                        {
                            Weapon = "武器", Install = "装備", YiInstall = "装備済み", ShenJi = "アップグレード", JieSuo = "アンロック",
                            WeaponName1 = "丸太の杖", WeaponName2 = "腐食の杖", WeaponName3 = "トライデント杖", WeaponName4 = "虚空の杖",
                            WeaponName5 = "爆炎の杖", WeaponName6 = "源極の杖", WeaponName7 = "湮滅の杖", WeaponName8 = "刀光剣影",
                            Desc1 = "初心者魔術師の最初の武器、頂点に立つ時、その可能性を発見するかもしれません！", Desc2 = "腐食の毒が杖先に絡みつき、一撃で血肉も回復できなくなる。",
                            Desc3 = "三又が霊を集め、一つの思いが三つに分かれ、弾丸が雨のように降り注ぎ、前方空間を封鎖する。",
                            Desc4 = "虚空の裂け目が杖先に束ねられ、一筋の光が千軍を貫き、遮るものは何もない。",
                            Desc5 = "灼熱の炎が核に凝縮され、命中すると爆発し、視界内の全てを焼き尽くす。", Desc6 = "源極の力がゆっくりと湧き出し、円形の魔弾が体を貫き、魂を蝕み続ける。",
                            Desc7 = "湮滅の魔核がゆっくりと前進し、接触すると骨を蝕み、最終的には天を壊す炎となる。",
                            Desc8 = "杖先に剣の意思が凝縮され、流れる光が虚空を破り、一撃が長虹を貫く。", TeXiao1 = "攻撃効果：特徴のない通常攻撃、100%攻撃力のダメージを与える",
                            TeXiao2 = "攻撃効果：攻撃で100%のダメージを与え、猛毒を付与し、3秒間毎秒20%のダメージを与える",
                            TeXiao3 = "攻撃効果：三つに分かれ、各魔法弾が100%攻撃力のダメージを与える", TeXiao4 = "攻撃効果：魔法弾が敵を貫通し、100%攻撃力のダメージを与える。",
                            TeXiao5 = "攻撃効果：爆炎弾が命中した敵に100%の攻撃力ダメージを与え、命中後に爆発して150%の追加ダメージを与える。",
                            TeXiao6 = "攻撃効果：源弾を発射し、触れた敵に持続的に150%攻撃力のダメージを与える。",
                            TeXiao7 = "攻撃効果：湮滅弾が触れた敵に持続的に100%のダメージを与え、その後湮滅崩壊で500%のダメージを与える。",
                            TeXiao8 = "攻撃効果：素早く剣気を発射し、敵を貫通して100%のダメージを与える。"
                        },
                        SkillWindowLanguage = new SkillWindowLanguage()
                        {
                            Skill = "スキル",
                            SkillCount = "スキルポイント",
                            ZhuanJinCount = "熟練ポイント",
                            ZhuDongSkill = "アクティブスキル",
                            BeiDongSkill = "パッシブスキル",
                            Level = "レベル",
                            NormalAttackName = "通常攻撃",
                            NormalAttackDesc = "レベルごとに通常攻撃ダメージが5%増加",

                            AttackSpeedName = "攻撃速度",
                            AttackSpeedDesc = "レベルごとに攻撃速度が5%増加",

                            DashName = "瞬身",
                            DashDesc = "前方に短距離テレポート",

                            DashCdName = "瞬身クールダウン",
                            DashCdDesc = "レベルごとに瞬身クールダウンが5%減少",

                            CritName = "クリティカル率",
                            CritDesc = "レベルごとにクリティカル率が5%増加",

                            CritDamageName = "クリティカルダメージ",
                            CritDamageDesc = "レベルごとにクリティカルダメージが5%増加",

                            MoveSpeedName = "移動速度",
                            MoveSpeedDesc = "レベルごとに基本移動速度が0.3増加",

                            MoveAddDefenseName = "疾行如水",
                            MoveAddDefenseDesc = "レベルごとに移動中防御力が5%増加",

                            MoveAddAttackName = "疾行如火",
                            MoveAddAttackDesc = "レベルごとに移動中攻撃力が5%増加",

                            Skill1Name = "電光嵐",
                            Skill1Desc = "レベルごとに電光嵐ダメージが5%増加",

                            Skill2Name = "氷晶星輪",
                            Skill2Desc = "レベルごとに氷晶星輪ダメージが5%増加",

                            Skill3Name = "極寒衝撃",
                            Skill3Desc = "レベルごとに極寒衝撃ダメージが5%増加",

                            Skill1CdName = "クールダウン減少",
                            Skill1CdDesc = "レベルごとに電光嵐クールダウンが5%減少",

                            Skill2CdName = "クールダウン減少",
                            Skill2CdDesc = "レベルごとに氷晶星輪クールダウンが5%減少",

                            Skill3CdName = "クールダウン減少",
                            Skill3CdDesc = "レベルごとに極寒衝撃クールダウンが5%減少",

                            Skill1RangeName = "嵐拡大",
                            Skill1RangeDesc = "レベルごとに電光嵐範囲が5%増加",

                            Skill1YiDianName = "電気脆弱状態",
                            Skill1YiDianDesc = "レベルごとに電光嵐に命中後追加で5%ダメージを受ける",

                            Skill2TimeName = "持続時間",
                            Skill2TimeDesc = "レベルごとに氷晶星輪持続時間が0.5秒増加",

                            Skill2AddDefenseName = "星輪護身",
                            Skill2AddDefenseDesc = "レベルごとに氷晶星輪発動中防御力が5%増加",

                            Skill3RangeName = "極寒拡張",
                            Skill3RangeDesc = "レベルごとに極寒衝撃範囲が5%増加",

                            Skill3JianSuName = "極寒凍結",
                            Skill3JianSuDesc = "レベルごとに5%減速効果を付与（3秒間持続）",

                            AttackName = "攻撃力",
                            AttackDesc = "レベルごとに基本攻撃力が 1 増加",

                            HpName = "体力",
                            HpDesc = "レベルごとに最大体力が 3 増加",

                            DefenseName = "防御力",
                            DefenseDesc = "レベルごとに防御力が 1 増加",

                            CritMonsterName = "クリティカル",
                            CritMonsterDesc = "レベルごとにクリティカル率が 3 増加"
                        },
                        BaseLanguage = new BaseLanguage()
                        {
                            Quality = "品質",
                            NormalAttack = "攻撃力",
                            NormalAttackSpeed = "攻撃速度",
                            Crit = "クリティカル率",
                            CritDamage = "クリティカルダメージ",
                            Hp = "体力",
                            Defense = "防御力",
                            MoveSpeed = "移動速度",
                            DiaoBao = "ドロップ率",
                            FinalDamage = "最終ダメージ",
                            WhiteQuality = "ノーマル",
                            GreenQuality = "アンコモン",
                            BlueQuality = "レア",
                            PurpleQuality = "エピック",
                            OrangeQuality = "レジェンダリー",
                            RedQuality = "神話級"
                        },
                        ChiBangWindowLanguage = new ChiBangWindowLanguage()
                        {
                            JieSuoDesc = "羽を使って経験値を提供し、翼のロック解除とアップグレードを行ってください！",
                            ChiBangName1 = "碧藍の翼",
                            ChiBangName2 = "羽翎の翼",
                            ChiBangName3 = "深空の翼",
                            ChiBangName4 = "妖異の翼",
                            ChiBangName5 = "黒虚の翼",
                            ChiBangName6 = "無端の翼",
                            Desc1 = "海のように澄み、雲のように軽やか、初心者にとって最初の一対の翼。",
                            Desc2 = "羽が軽やかに舞い、風が心に従い、空の間を自由に飛翔する。",
                            Desc3 = "夜空のように深く、星が輝く、未知を探求する勇気を担う。",
                            Desc4 = "妖しい幻影、紫の光が流れ、古代の神秘的な力を秘める。",
                            Desc5 = "虚空を引き裂き、光を飲み込む、暗黒の深淵からの禁忌の翼。",
                            Desc6 = "端無く生まれ、常理を超える、神域に触れると言われる存在。"
                        },
                        BagWindowLanguage = new BagWindowLanguage()
                        {
                            Bag = "バッグ",
                            Equip = "装備",
                            Prop = "アイテム",
                            DetailAttribute = "詳細属性",
                            FenJie = "自動分解"
                        },
                        PropLanguage = new PropLanguage()
                        {
                            WhiteWeaponFragment = "ノーマル武器の欠片",
                            GreenWeaponFragment = "アンコモン武器の欠片",
                            BlueWeaponFragment = "レア武器の欠片",
                            PurpleWeaponFragment = "エピック武器の欠片",
                            OrangeWeaponFragment = "レジェンダリー武器の欠片",
                            RedWeaponFragment = "神話級武器の欠片",

                            WhiteJingCui = "ノーマル精髄",
                            GreenJingCui = "アンコモン精髄",
                            BlueJingCui = "レア精髄",
                            PurpleJingCui = "エピック精髄",
                            OrangeJingCui = "レジェンダリー精髄",
                            RedJingCui = "神話級精髄",

                            ShenHuaZhiXin = "神話の心臓",
                            JuDaYaChi = "巨大な牙",
                            GoldBlood = "黄金の血",
                            ZuiEYanZhu = "罪悪の眼球",
                            FuMoZhiGu = "魔法付与の骨",
                            LinHun = "魂"
                        },
                        GameLevelWindowLanguage = new GameLevelWindowLanguage()
                        {
                            TuiJianLevel = "推奨レベル",
                            MonsterList = "モンスターリスト",
                            TiaoZhan = "挑戦"
                        },
                        SettingWindowLanguage = new SettingWindowLanguage()
                        {
                            Language = "言語",
                            Audio = "音声",
                            ZhongWen = "中国語",
                            YingWen = "英語",
                            RiWen = "日本語",
                            HanWen = "韓国語"
                        },
                    }
                }
            };
    }
}