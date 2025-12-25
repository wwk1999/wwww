using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AddSourceStoneData
{
    public int sourcestoneid { get; set; }
    public int sourcestonecount { get; set; }
}

public class GetUserSourceStoneData
{
    public bool with_details { get; set; }
}

public class BatchRemoveSourceStoneData
{
    public int[] sourcestoneids { get; set; }
}


public class SourceStoneServer : XSingleton<SourceStoneServer>
{
}
