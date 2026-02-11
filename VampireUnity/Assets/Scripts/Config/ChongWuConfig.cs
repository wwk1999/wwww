using System.Collections.Generic;
using UnityEngine;

public class ChongWuConfig
{
    public class MinMax
    {
        public float min;
        public float max;
    }
    public static Dictionary<int, float> NormalChongWuDanGaiLv = new Dictionary<int, float>()
    {
        { 1, 40 },
        { 2, 30 },
        { 3, 20 },
        { 4, 10 },
    };
    
    public static Dictionary<int, float> GaoJiChongWuDanGaiLv = new Dictionary<int, float>()
    {
        { 1, 20 },
        { 2, 25 },
        { 3, 30 },
        { 4, 20 },
        { 5, 5 },
    };

    public static Dictionary<int, List<ChongWuType>> ChongWuQualityDic = new Dictionary<int, List<ChongWuType>>()
    {
        { 1, new List<ChongWuType>() { ChongWuType.icewhite1, ChongWuType.dianwhite1,ChongWuType.heianwhite1,ChongWuType.huowhite1,ChongWuType.heianwhite2,} },
        { 2, new List<ChongWuType>() { ChongWuType.icegreen1, ChongWuType.icegreen2,ChongWuType.icegreen3,ChongWuType.huogreen1,ChongWuType.huogreen2,ChongWuType.diangreen1,ChongWuType.diangreen2,ChongWuType.heiangreen1,ChongWuType.heiangreen2,ChongWuType.heiangreen3} },
        { 3, new List<ChongWuType>() { ChongWuType.iceblue1, ChongWuType.iceblue2,ChongWuType.huoblue1,ChongWuType.huoblue2,ChongWuType.huoblue3,ChongWuType.dianblue1,ChongWuType.dianblue2,ChongWuType.heianblue1,ChongWuType.heianblue2,ChongWuType.heianblue3} },
        { 4, new List<ChongWuType>() { ChongWuType.icepurple1_q, ChongWuType.icepurple2_q,ChongWuType.icepurple3_q,ChongWuType.huopurple1_q,ChongWuType.huopurple2_q,ChongWuType.huopurple3_q,ChongWuType.dianpurple1_q,ChongWuType.dianpurple2_q,ChongWuType.dianpurple3_q,ChongWuType.heianpurple1_q,ChongWuType.heianpurple2_q,ChongWuType.heianpurple3_q} },
        { 5, new List<ChongWuType>() { ChongWuType.iceorange1_q,ChongWuType.huoorange1_q,ChongWuType.dianorange1_q,ChongWuType.heianorange1_q} },
    };

    public static Dictionary<int, MinMax> ChongWuZiZhiDic = new Dictionary<int, MinMax>()
    {
        {1,new MinMax(){min = 60,max = 100} },
        {2,new MinMax(){min = 80,max = 120} },
        {3,new MinMax(){min = 100,max = 140} },
        {4,new MinMax(){min = 120,max = 160} },
        {5,new MinMax(){min = 150,max = 200} },
        {6,new MinMax(){min = 200,max = 300} },
    };
    
    public static Dictionary<int, MinMax> ChongWuXueMaiDic = new Dictionary<int, MinMax>()
    {
        {1,new MinMax(){min = 0.6f,max = 1f} },
        {2,new MinMax(){min = 0.8f,max = 1.2f} },
        {3,new MinMax(){min = 1f,max = 1.4f} },
        {4,new MinMax(){min = 1.2f,max = 1.6f} },
        {5,new MinMax(){min = 1.5f,max = 2f} },
        {6,new MinMax(){min = 2f,max = 3f} },
    };

    public static Dictionary<ChongWuType, string> ChongWuNamDic = new Dictionary<ChongWuType, string>()
    {
        { ChongWuType.dianwhite1,"熔电粘液怪" },
        { ChongWuType.dianblue1,"胶电仔" },
        { ChongWuType.dianblue2,"雷葱头" },
        { ChongWuType.diangreen1,"电泡球" },
        { ChongWuType.diangreen2,"雷啾" },
        { ChongWuType.dianorange1_q,"雷翼龙" },
        { ChongWuType.dianorange1_h,"雷翼龙" },
        { ChongWuType.dianpurple1_q,"雷甲" },
        { ChongWuType.dianpurple1_h,"雷甲" },
        { ChongWuType.dianpurple2_q,"电翎凤" },
        { ChongWuType.dianpurple2_h,"电翎凤" },
        { ChongWuType.dianpurple3_q,"雷球姬" },
        { ChongWuType.dianpurple3_h,"雷球姬" },

        
        { ChongWuType.heianblue1,"黑魔仔" },
        { ChongWuType.heianblue2,"咒猫" },
        { ChongWuType.heianblue3,"岩魔猪" },
        { ChongWuType.heiangreen1,"暗泡" },
        { ChongWuType.heiangreen2,"虚空史莱姆" },
        { ChongWuType.heiangreen3,"岩猪" },
        { ChongWuType.heianorange1_q,"暗黑主宰" },
        { ChongWuType.heianorange1_h,"暗黑主宰" },
        { ChongWuType.heianpurple1_q,"魇龙" },
        { ChongWuType.heianpurple1_h,"魇龙" },
        { ChongWuType.heianpurple2_q,"恶魔之龙" },
        { ChongWuType.heianpurple2_h,"恶魔之龙" },
        { ChongWuType.heianpurple3_q,"魂狼" },
        { ChongWuType.heianpurple3_h,"魂狼" },
        { ChongWuType.heianwhite1,"黑暗粘液怪" },
        { ChongWuType.heianwhite2,"黑暗史莱姆" },
        
        
        { ChongWuType.huoblue1,"熔岩仔" },
        { ChongWuType.huoblue2,"烈焰魔狐" },
        { ChongWuType.huoblue3,"炎雀儿" },
        { ChongWuType.huogreen1,"熔岩史莱姆" },
        { ChongWuType.huogreen2,"烈焰狐" },
        { ChongWuType.huoorange1_q,"火焰行者" },
        { ChongWuType.huoorange1_h,"火焰行者" },
        { ChongWuType.huopurple1_q,"葫芦猫" },
        { ChongWuType.huopurple1_h,"葫芦猫" },
        { ChongWuType.huopurple2_q,"竹炎熊猫" },
        { ChongWuType.huopurple2_h,"竹炎熊猫" },
        { ChongWuType.huopurple3_q,"焰狐仙" },
        { ChongWuType.huopurple3_h,"焰狐仙" },
        { ChongWuType.huowhite1,"火叶球" },
        
        
        { ChongWuType.iceblue1,"冰霜仔" },
        { ChongWuType.iceblue2,"霜甲兽" },
        { ChongWuType.icegreen1,"冰史莱姆" },
        { ChongWuType.icegreen2,"冰滴仔" },
        { ChongWuType.icegreen3,"小霜甲兽" },
        { ChongWuType.iceorange1_q,"霜龙皇" },
        { ChongWuType.iceorange1_h,"霜龙皇" },
        { ChongWuType.icepurple1_q,"霜翼蝶" },
        { ChongWuType.icepurple1_h,"霜翼蝶" },
        { ChongWuType.icepurple2_q,"霜角猫" },
        { ChongWuType.icepurple2_h,"霜角猫" },
        { ChongWuType.icepurple3_q,"霜华狐" },
        { ChongWuType.icepurple3_h,"霜华狐" },
        { ChongWuType.icewhite1,"冰晶粘液怪" },
    };
    

    public static int GetChongWuQualityByType(ChongWuType chongWuType)
    {
        switch (chongWuType)
        {
            case ChongWuType.icewhite1:
            case ChongWuType.huowhite1:
            case ChongWuType.dianwhite1:
            case ChongWuType.heianwhite1:
            case ChongWuType.heianwhite2:
                return 1;
            case ChongWuType.icegreen1:
            case ChongWuType.icegreen2:
            case ChongWuType.icegreen3:
            case ChongWuType.huogreen1:
            case ChongWuType.huogreen2:
            case ChongWuType.diangreen1:
            case ChongWuType.diangreen2:
            case ChongWuType.heiangreen1:
            case ChongWuType.heiangreen2:
            case ChongWuType.heiangreen3:
                return 2;

            case ChongWuType.iceblue1:
            case ChongWuType.iceblue2:
            case ChongWuType.huoblue1:
            case ChongWuType.huoblue2:
            case ChongWuType.huoblue3:
            case ChongWuType.dianblue1:
            case ChongWuType.dianblue2:
            case ChongWuType.heianblue1:
            case ChongWuType.heianblue2:
            case ChongWuType.heianblue3:
                return 3;
            
            case ChongWuType.icepurple1_q:
            case ChongWuType.icepurple2_q:
            case ChongWuType.icepurple3_q:
            case ChongWuType.huopurple1_q:
            case ChongWuType.huopurple2_q:
            case ChongWuType.huopurple3_q:
            case ChongWuType.dianpurple1_q:
            case ChongWuType.dianpurple2_q:
            case ChongWuType.dianpurple3_q:
            case ChongWuType.heianpurple1_q:
            case ChongWuType.heianpurple2_q:
            case ChongWuType.heianpurple3_q:
                
            case ChongWuType.icepurple1_h:
            case ChongWuType.icepurple2_h:
            case ChongWuType.icepurple3_h:
            case ChongWuType.huopurple1_h:
            case ChongWuType.huopurple2_h:
            case ChongWuType.huopurple3_h:
            case ChongWuType.dianpurple1_h:
            case ChongWuType.dianpurple2_h:
            case ChongWuType.dianpurple3_h:
            case ChongWuType.heianpurple1_h:
            case ChongWuType.heianpurple2_h:
            case ChongWuType.heianpurple3_h:
                return 4;
            case ChongWuType.iceorange1_q:
            case ChongWuType.iceorange1_h:
            case ChongWuType.huoorange1_q:
            case ChongWuType.huoorange1_h:
            case ChongWuType.dianorange1_q:
            case ChongWuType.dianorange1_h:
            case ChongWuType.heianorange1_q:
            case ChongWuType.heianorange1_h:
                return 5;
        }
        return 0;
    }


    public static ChongWuYuanSuType GetChongWuYuanSuByType(ChongWuType chongWuType)
    {
        switch (chongWuType)
        {
            case  ChongWuType.icepurple1_q:
            case  ChongWuType.icepurple1_h:
            case  ChongWuType.icepurple2_q:
            case  ChongWuType.icepurple2_h:
            case  ChongWuType.icepurple3_q:
            case  ChongWuType.icepurple3_h:
            case  ChongWuType.iceorange1_h:
            case  ChongWuType.iceorange1_q:
            case  ChongWuType.icewhite1:
            case  ChongWuType.icegreen1:
            case  ChongWuType.icegreen2:
            case  ChongWuType.icegreen3:
            case  ChongWuType.iceblue1:
            case  ChongWuType.iceblue2:
                return ChongWuYuanSuType.Ice;
            
            case  ChongWuType.huopurple1_q:
            case  ChongWuType.huopurple1_h:
            case  ChongWuType.huopurple2_q:
            case  ChongWuType.huopurple2_h:
            case  ChongWuType.huopurple3_q:
            case  ChongWuType.huopurple3_h:
            case  ChongWuType.huoorange1_h:
            case  ChongWuType.huoorange1_q:
            case  ChongWuType.huowhite1:
            case  ChongWuType.huogreen1:
            case  ChongWuType.huogreen2:
            case  ChongWuType.huoblue1:
            case  ChongWuType.huoblue2:
            case  ChongWuType.huoblue3:
                return ChongWuYuanSuType.Huo;
            
            case  ChongWuType.dianpurple1_q:
            case  ChongWuType.dianpurple1_h:
            case  ChongWuType.dianpurple2_q:
            case  ChongWuType.dianpurple2_h:
            case  ChongWuType.dianpurple3_q:
            case  ChongWuType.dianpurple3_h:
            case  ChongWuType.dianorange1_h:
            case  ChongWuType.dianorange1_q:
            case  ChongWuType.dianwhite1:
            case  ChongWuType.diangreen1:
            case  ChongWuType.diangreen2:
            case  ChongWuType.dianblue1:
            case  ChongWuType.dianblue2:
                return ChongWuYuanSuType.Dian;

            
            case  ChongWuType.heianpurple1_q:
            case  ChongWuType.heianpurple1_h:
            case  ChongWuType.heianpurple2_q:
            case  ChongWuType.heianpurple2_h:
            case  ChongWuType.heianpurple3_q:
            case  ChongWuType.heianpurple3_h:
            case  ChongWuType.heianorange1_h:
            case  ChongWuType.heianorange1_q:
            case  ChongWuType.heianwhite1:
            case  ChongWuType.heianwhite2:
            case  ChongWuType.heiangreen1:
            case  ChongWuType.heiangreen2:
            case  ChongWuType.heiangreen3:
            case  ChongWuType.heianblue1:
            case  ChongWuType.heianblue2:
            case  ChongWuType.heianblue3:
                return ChongWuYuanSuType.HeiAn;
        }
        return ChongWuYuanSuType.None;
    }

    public static ChongWuType GetChongWuType(int Quality)
    {
        switch (Quality)
        {
            case 1:
                int count1=ChongWuQualityDic[1].Count;
                int random1=Random.Range(0, count1);
                return ChongWuQualityDic[1][random1];
            case 2:
                int count2=ChongWuQualityDic[2].Count;
                int random2=Random.Range(0, count2);
                return ChongWuQualityDic[2][random2];
            case 3:
                int count3=ChongWuQualityDic[3].Count;
                int random3=Random.Range(0, count3);
                return ChongWuQualityDic[3][random3];
            case 4:
                int count4=ChongWuQualityDic[4].Count;
                int random4=Random.Range(0, count4);
                return ChongWuQualityDic[4][random4];
            case 5:
                int count5=ChongWuQualityDic[5].Count;
                int random5=Random.Range(0, count5);
                return ChongWuQualityDic[5][random5];
        }

        return ChongWuType.None;
    }
}
