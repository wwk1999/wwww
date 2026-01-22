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

    public class LanguageItem
    {
        public RoleWindowLanguage RoleWindowLanguage;
        public MonsterBookWindowLanguage MonsterBookWindowLanguage;
        public WeaponWindowLanguage WeaponWindowLanguage;
        public SkillWindowLanguage SkillWindowLanguage;
        public BaseLanguage BaseLanguage;
        public ChiBangWindowLanguage ChiBangWindowLanguage;
        public BagWindowLanguage BagWindowLanguage;
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
                            DuanZao = "锻造", StartGame = "开始游戏"
                        },
                        MonsterBookWindowLanguage = new MonsterBookWindowLanguage()
                        {
                            MonsterName = "怪物名称", DiDian = "出没地点", MonsterType = "怪物类型", LevelName1 = "寂静森林",
                            LevelName2 = "熔岩火山", LevelName3 = "迷雾沼泽", LevelName4 = "死亡沙漠", LevelName5 = "北境雪域",
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
                            AttackDesc = "每级提供基础攻击力 100",
    
                            HpName = "生命值",
                            HpDesc = "每级提供最大生命值 100",
    
                            DefenseName = "防御力",
                            DefenseDesc = "每级提供防御力 100",
    
                            CritMonsterName = "暴击",
                            CritMonsterDesc = "每级提供暴击 100"
                        },
                        BaseLanguage=new BaseLanguage()
                        {
                            Quality = "品质",NormalAttack = "攻击力",NormalAttackSpeed = "攻击速度",Crit = "暴击",CritDamage = "暴击伤害",Hp = "生命值",Defense = "防御",MoveSpeed = "移动速度",DiaoBao = "掉宝值",FinalDamage = "最终伤害",WhiteQuality = "普通",GreenQuality = "优秀",BlueQuality = "精良",PurpleQuality = "史诗",OrangeQuality = "传说",RedQuality = "神话",
                        },
                        ChiBangWindowLanguage = new ChiBangWindowLanguage()
                        {
                            JieSuoDesc="请使用羽毛提供经验来解锁升级翅膀！",ChiBangName1 = "碧蓝之翼",ChiBangName2 = "羽翎之翼",ChiBangName3 = "深空之翼",ChiBangName4 = "妖异之翼",ChiBangName5 = "黑虚之翼",ChiBangName6 = "无端之翼",Desc1 = "清澈如海，轻盈如云，初学者的第一双翅膀。",Desc2 = "羽翎轻舞，风随心动，展翅翱翔于天际之间。",Desc3 = "深邃如夜空，星光闪烁，承载着探索未知的勇气。",Desc4 = "妖异魅影，紫光流转，蕴含着古老而神秘的力量。",Desc5 = "撕裂虚空，吞噬光明，来自黑暗深渊的禁忌之翼。",Desc6 = "无端而生，超越常理，传说中触及神域的存在。"
                        },
                        BagWindowLanguage=new BagWindowLanguage()
                        {
                            Bag = "背包",Equip = "装备",Prop = "道具",DetailAttribute = "详细属性",FenJie = "一键分解"
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
                            Setting = "Settings", DuanZao = "Forge", StartGame = "Start Game"
                        },
                        MonsterBookWindowLanguage = new MonsterBookWindowLanguage()
                        {
                            MonsterName = "Monster Name", DiDian = "Location", MonsterType = "Monster Type",
                            LevelName1 = "Silent Forest", LevelName2 = "Lava Volcano", LevelName3 = "Misty Swamp",
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
                            DuanZao = "제작", StartGame = "게임 시작"
                        },
                        MonsterBookWindowLanguage = new MonsterBookWindowLanguage()
                        {
                            MonsterName = "몬스터 이름", DiDian = "출몰 장소", MonsterType = "몬스터 종류", LevelName1 = "고요한 숲",
                            LevelName2 = "용암 화산", LevelName3 = "안개 늪", LevelName4 = "죽음의 사막", LevelName5 = "북방 설원",
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
                        }
                    }
                },

                // 日语
                {
                    LanguageType.Ri, new LanguageItem()
                    {
                        RoleWindowLanguage = new RoleWindowLanguage()
                        {
                            TuJian = "図鑑", WuQi = "武器", Bag = "バッグ", ChiBang = "翼", Skill = "スキル", Setting = "設定",
                            DuanZao = "鍛造", StartGame = "ゲーム開始"
                        },
                        MonsterBookWindowLanguage = new MonsterBookWindowLanguage()
                        {
                            MonsterName = "モンスター名", DiDian = "出現場所", MonsterType = "モンスタータイプ", LevelName1 = "静寂の森",
                            LevelName2 = "溶岩火山", LevelName3 = "霧の沼地", LevelName4 = "死の砂漠", LevelName5 = "北境雪原",
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
                        }
                    }
                }
            };
    }
}