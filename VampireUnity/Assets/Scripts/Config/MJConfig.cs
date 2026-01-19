using System.Collections.Generic;
public enum MJLevel
{
    None,
    White,
    Green,
    Red1,
    Blue,
    Purple,
    Orange,
    Red2,
    Red3,
    Red4,
    Red5,
    Red6,
    Red7,
    Red8,
    Red9,
    Red10,
    Red11,
    Red12,
    Red13,
    Red14,
    Red15,
}
namespace Config
{
    public class MonsterAttribute
    {
        public int hp;
        public int atk;
        public int def;
    }

    public class PlayerAttribute
    {
        public int linhun;
        public int ex;
        public int bao;
    }

    public class JiangLi
    {
        public int ex;
        public int linhun;
        public int jingcui;
    }

    public class BaseMonsterAttribute
    {
        public int hp = 15000;
        public int atk = 1200;
        public int def = 600;
        public int ex = 80;
        public int linhun = 8;
    }
    public class MJConfig
    {
        public static BaseMonsterAttribute BaseMonsterAttribute;
        public static Dictionary<MJLevel, MonsterAttribute> MonsterAttributeDic = new Dictionary<MJLevel, MonsterAttribute>()
        {
            { MJLevel.White ,new MonsterAttribute{hp=100,atk=100,def=100}},
            { MJLevel.Green ,new MonsterAttribute{hp=150,atk=120,def=120}},
            { MJLevel.Blue ,new MonsterAttribute{hp=200,atk=150,def=150}},
            { MJLevel.Purple ,new MonsterAttribute{hp=300,atk=200,def=200}},
            { MJLevel.Orange ,new MonsterAttribute{hp=500,atk=250,def=250}},
            { MJLevel.Red1 ,new MonsterAttribute{hp=800,atk=300,def=300}},
            { MJLevel.Red2 ,new MonsterAttribute{hp=1000,atk=400,def=400}},
            { MJLevel.Red3 ,new MonsterAttribute{hp=1200,atk=500,def=500}},
            { MJLevel.Red4 ,new MonsterAttribute{hp=1500,atk=600,def=600}},
            { MJLevel.Red5 ,new MonsterAttribute{hp=1800,atk=700,def=700}},
            { MJLevel.Red6 ,new MonsterAttribute{hp=2000,atk=800,def=800}},
            { MJLevel.Red7 ,new MonsterAttribute{hp=2300,atk=900,def=900}},
            { MJLevel.Red8 ,new MonsterAttribute{hp=2600,atk=1000,def=1000}},
            { MJLevel.Red9 ,new MonsterAttribute{hp=3000,atk=1100,def=1100}},
            { MJLevel.Red10 ,new MonsterAttribute{hp=3500,atk=1200,def=1200}},
            { MJLevel.Red11 ,new MonsterAttribute{hp=4000,atk=1300,def=1300}},
            { MJLevel.Red12 ,new MonsterAttribute{hp=4500,atk=1400,def=1400}},
            { MJLevel.Red13 ,new MonsterAttribute{hp=5000,atk=1500,def=1500}},
            { MJLevel.Red14 ,new MonsterAttribute{hp=6000,atk=1700,def=1700}},
            { MJLevel.Red15 ,new MonsterAttribute{hp=7000,atk=2000,def=2000}},
        };
        
        public static Dictionary<MJLevel, PlayerAttribute> PlayerAttributeDic = new Dictionary<MJLevel, PlayerAttribute>()
        {
            { MJLevel.White ,new PlayerAttribute{linhun=100,ex=100,bao=100}},
            { MJLevel.Green ,new PlayerAttribute{linhun=120,ex=150,bao=110}},
            { MJLevel.Blue ,new PlayerAttribute{linhun=150,ex=200,bao=120}},
            { MJLevel.Purple ,new PlayerAttribute{linhun=175,ex=250,bao=130}},
            { MJLevel.Orange ,new PlayerAttribute{linhun=200,ex=300,bao=140}},
            { MJLevel.Red1 ,new PlayerAttribute{linhun=225,ex=450,bao=150}},
            { MJLevel.Red2 ,new PlayerAttribute{linhun=250,ex=600,bao=160}},
            { MJLevel.Red3 ,new PlayerAttribute{linhun=275,ex=800,bao=170}},
            { MJLevel.Red4 ,new PlayerAttribute{linhun=300,ex=1000,bao=180}},
            { MJLevel.Red5 ,new PlayerAttribute{linhun=350,ex=1200,bao=190}},
            { MJLevel.Red6 ,new PlayerAttribute{linhun=400,ex=1400,bao=200}},
            { MJLevel.Red7 ,new PlayerAttribute{linhun=450,ex=1600,bao=210}},
            { MJLevel.Red8 ,new PlayerAttribute{linhun=500,ex=1800,bao=220}},
            { MJLevel.Red9 ,new PlayerAttribute{linhun=550,ex=2000,bao=230}},
            { MJLevel.Red10 ,new PlayerAttribute{linhun=600,ex=2200,bao=240}},
            { MJLevel.Red11 ,new PlayerAttribute{linhun=650,ex=2500,bao=250}},
            { MJLevel.Red12 ,new PlayerAttribute{linhun=700,ex=2800,bao=260}},
            { MJLevel.Red13 ,new PlayerAttribute{linhun=800,ex=3100,bao=270}},
            { MJLevel.Red14 ,new PlayerAttribute{linhun=900,ex=3500,bao=280}},
            { MJLevel.Red15 ,new PlayerAttribute{linhun=1000,ex=4000,bao=290}},
        };
        
        public static Dictionary<MJLevel, JiangLi> JiangLiDic = new Dictionary<MJLevel, JiangLi>()
        {
            { MJLevel.White ,new JiangLi{ex=100,linhun=100,jingcui = 1}},
            { MJLevel.Green ,new JiangLi{ex=150,linhun=120,jingcui = 2}},
            { MJLevel.Blue ,new JiangLi{ex=200,linhun=150,jingcui = 3}},
            { MJLevel.Purple ,new JiangLi{ex=300,linhun=200,jingcui = 4}},
            { MJLevel.Orange ,new JiangLi{ex=500,linhun=250,jingcui = 5}},
            { MJLevel.Red1 ,new JiangLi{ex=800,linhun=300,jingcui = 6}},
            { MJLevel.Red2 ,new JiangLi{ex=1000,linhun=400,jingcui = 7}},
            { MJLevel.Red3 ,new JiangLi{ex=1200,linhun=500,jingcui = 8}},
            { MJLevel.Red4 ,new JiangLi{ex=1500,linhun=600,jingcui = 9}},
            { MJLevel.Red5 ,new JiangLi{ex=1800,linhun=700,jingcui = 10}},
            { MJLevel.Red6 ,new JiangLi{ex=2000,linhun=800,jingcui = 11}},
            { MJLevel.Red7 ,new JiangLi{ex=2300,linhun=900,jingcui = 12}},
            { MJLevel.Red8 ,new JiangLi{ex=2600,linhun=1000,jingcui = 13}},
            { MJLevel.Red9 ,new JiangLi{ex=3000,linhun=1100,jingcui = 14}},
            { MJLevel.Red10 ,new JiangLi{ex=3500,linhun=1200,jingcui = 15}},
            { MJLevel.Red11 ,new JiangLi{ex=4000,linhun=1300,jingcui = 16}},
            { MJLevel.Red12 ,new JiangLi{ex=4500,linhun=1400,jingcui = 17}},
            { MJLevel.Red13 ,new JiangLi{ex=5000,linhun=1500,jingcui = 18}},
            { MJLevel.Red14 ,new JiangLi{ex=6000,linhun=1700,jingcui = 19}},
            { MJLevel.Red15 ,new JiangLi{ex=7000,linhun=2000,jingcui = 20}},
        };
    }
}