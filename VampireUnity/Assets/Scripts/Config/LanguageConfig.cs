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

    public class LanguageItem
    {
        public RoleWindowLanguage RoleWindowLanguage;
        public MonsterBookWindowLanguage MonsterBookWindowLanguage;
        public WeaponWindowLanguage WeaponWindowLanguage;
    }
    public class LanguageConfig
    {
        public static Dictionary<LanguageType, LanguageItem> LanguageItems =
            new Dictionary<LanguageType, LanguageItem>()
            {
                {
                    LanguageType.Chinese ,new LanguageItem()
                    {
                        RoleWindowLanguage=new RoleWindowLanguage(){TuJian="图鉴",WuQi="武器",Bag="背包",ChiBang="翅膀",Skill="技能",Setting = "设置",DuanZao="锻造",StartGame = "开始游戏"},
                        MonsterBookWindowLanguage=new MonsterBookWindowLanguage(){MonsterName="怪物名称",DiDian="出没地点",MonsterType= "怪物类型",LevelName1= "寂静森林",LevelName2= "熔岩火山",LevelName3= "迷雾沼泽",LevelName4= "死亡沙漠",LevelName5= "北境雪域",DiaoLuoList= "掉落列表",Snot= "粘液怪",Bat= "夜翼蝠",Spider= "织网蛛",Bee= "刃翅魔蜂",TreeMan= "森林守护者",XiaoHuo= "熔岩鬼火",DunDi= "熔岩蠕虫",ChongZi= "火山虫",DaZui= "熔岩巨螯",HuoShanBoss= "熔岩行者",JiaChong= "刺壳兽",QingWa= "沼泽蟾蜍",WenZi= "红眼蝇",ShiRenHua= "血花妖",ZhaoZeBoss= "泥沼龙王",ShaNiao= "红羽鸟",ShaChong= "沙丘甲虫",XianRenZhang= "死亡仙人掌",ShaXiYi= "紫魔蜥",XieZi= "沙影蝎王",XueRen= "野雪人",XueZhangLang= "雪蟑螂",XueQiE= "雪企鹅",YingShu= "银角鼠",XueRenBoss= "雪山泰坦",},
                        WeaponWindowLanguage=new WeaponWindowLanguage(){Weapon="武器",Install="装备",YiInstall="已装备",ShenJi="升级",JieSuo="解锁",WeaponName1= "原木法杖",WeaponName2="腐蚀权杖",WeaponName3="三叉法杖",WeaponName4="虚空法杖",WeaponName5="爆炎杖",WeaponName6="源极杖",WeaponName7="湮灭之杖",WeaponName8="刀光剑影",Desc1= "新手法师的第一个武器，当你登临至高时或许会发现它的潜力！",Desc2= "腐蚀之毒缠绕杖尖，一击即中，血肉难复。",Desc3= "三叉聚灵，一念三分，子弹如雨，封锁前方空间。",Desc4= "虚空裂隙束于杖端，一束贯穿千军，无物可挡。",Desc5= "炽焰凝聚成核，命中即爆，烈焰焚尽视野之内。",Desc6= "源极之力缓缓涌动，圆形魔弹穿体蚀魂不止。",Desc7= "湮灭魔核缓缓前行，接触蚀骨，终至终点化作毁天之炎。",Desc8= "杖尖凝剑意，流光破空，一击贯长虹。",TeXiao1= "攻击特效：毫无特色的平A，造成100%攻击力的伤害",TeXiao2= "攻击特效：攻击造成100%的伤害，并且附带剧毒，每秒造成20%伤害，持续3s",TeXiao3= "攻击特效：一分为三，每个魔法弹造成100%攻击力伤害",TeXiao4= "攻击特效：魔法弹可以穿透敌人，并造成100%攻击力的伤害。",TeXiao5= "攻击特效：爆炎弹对击中敌人造成100%的攻击力伤害，击中敌人后爆炸，再次造成150%的伤害。",TeXiao6= "攻击特效：发射源弹对触碰的敌人持续造成150%攻击力的伤害。",TeXiao7= "攻击特效：湮灭弹对触碰的敌人持续造成100%的伤害，随后湮灭坍塌，造成500%的伤害。",TeXiao8= "攻击特效：快速发射剑气穿透敌人，并造成100%的伤害"}
                    }
                }
            };
    }
}