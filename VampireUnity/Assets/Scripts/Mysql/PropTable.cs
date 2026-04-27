using System;
using Mysql;

public class PropItem
{
    public int Quality { get; set; }
    public PropConfig.PropType PropType { get; set; }

    public PropItem(PropConfig.PropType propType = PropConfig.PropType.None, int quality = 1)
    {
        PropType = propType;
        Quality = quality;
    }

    public override bool Equals(object obj)
    {
        if (obj is PropItem other)
        {
            return Quality == other.Quality && PropType == other.PropType;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Quality, PropType);
    }
}
public class PropTable:TableBase
{
        public PropConfig.PropType PropType { get; set; }
        public int Count { get; set; }
        public string Desc { get; set; }

        
        public PropTable(
                PropConfig.PropType propType=PropConfig.PropType.None,
                int count = 0,
                string desc = null,
                int quality = 1,
                string equipName=null)
        {
               this.PropType = propType;
               this.Count = count;
               this.Desc = desc;
               this.Quality = quality;
               this.EquipName = equipName;
        }
}
