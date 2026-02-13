using System.Collections;
using System.Collections.Generic;
using Mysql;
using UnityEngine;

public enum ChongWuType
{
    None,
    
    icewhite1,
    huowhite1,
    dianwhite1,
    heianwhite1,
    heianwhite2,

    icegreen1,
    icegreen2,
    icegreen3,
    huogreen1,
    huogreen2,
    diangreen1,
    diangreen2,
    heiangreen1,
    heiangreen2,
    heiangreen3,


    iceblue1,
    iceblue2,
    huoblue1,
    huoblue2,
    huoblue3,
    dianblue1,
    dianblue2,
    heianblue1,
    heianblue2,
    heianblue3,


    icepurple1_q,
    icepurple1_h,
    icepurple2_q,
    icepurple2_h,
    icepurple3_q,
    icepurple3_h,

    huopurple1_q,
    huopurple1_h,
    huopurple2_q,
    huopurple2_h,
    huopurple3_q,
    huopurple3_h,

    dianpurple1_q,
    dianpurple1_h,
    dianpurple2_q,
    dianpurple2_h,
    dianpurple3_q,
    dianpurple3_h,

    heianpurple1_q,
    heianpurple1_h,
    heianpurple2_q,
    heianpurple2_h,
    heianpurple3_q,
    heianpurple3_h,


    iceorange1_q,
    iceorange1_h,
    huoorange1_q,
    huoorange1_h,
    dianorange1_q,
    dianorange1_h,
    heianorange1_q,
    heianorange1_h,
}

public enum ChongWuYuanSuType
{
    None,
    Ice,
    Huo,
    Dian,
    HeiAn
}

public class ChongWuSkillItem
{
    public int Level {get; set;}
    public ChongWuConfig.ChongWuSKillType SKillType {get; set;}
}
public class ChongWuTable
{
    public int ChongWuId { get; set;}
    public ChongWuType ChongWuType{ get; set; }
    public int Quality {get; set; }
    public int ZiZhi {get; set; }
    public float XueMai {get; set; }
    public ChongWuYuanSuType ChongWuYuanSuType { get; set; }
    public int XingJi { get; set; }
    public int Level {get; set;  }
    public int Ex {get; set;  }

    public string Name {get; set;  }
    public List<ChongWuSkillItem> SkillList {get; set;  }


    public ChongWuTable(
        int chongWuId=0,
        ChongWuType ChongWuType=ChongWuType.None,
        int quality = 1,
        int zizhi=0,
        float xuemai=0,
        ChongWuYuanSuType ChongWuYuanSuType=ChongWuYuanSuType.None,
        int xingji=1,
        int level=0,
        int ex=0,
        string Name="",
        List<ChongWuSkillItem> SkillList=null)
    {
        this.ChongWuId = chongWuId;
        this.ChongWuType = ChongWuType;
        this.Quality = quality;
        this.ZiZhi = zizhi;
        this.XueMai = xuemai;
        this.ChongWuYuanSuType=ChongWuYuanSuType;
        this.XingJi = xingji;
        this.Level = level;
        this.Ex = ex;
        this.Name = Name;
        this.SkillList = SkillList;
    }
}
