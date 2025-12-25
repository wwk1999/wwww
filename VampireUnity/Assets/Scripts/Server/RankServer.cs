using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GetLevelRankData
{
    public string rank_type { get; set; }
    public int limit { get; set; }
}
public class GetUserLevelRankData
{
    public string rank_type { get; set; }
}
public class MonsterCountData
{
    public int normal { get; set; }
    public int elite { get; set; }
    public int boss { get; set; }
}

public class MonsterCountRankData
{
    public int limit { get; set; }
}


public class RankServer : XSingleton<RankServer>
{
}
