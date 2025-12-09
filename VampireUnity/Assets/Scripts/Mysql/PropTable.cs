using Mysql;

public class PropItem
{
    public int Quality{ get; set; }
    public PropConfig.PropType PropType { get; set; }
    public PropItem(
        PropConfig.PropType propType=PropConfig.PropType.None,
        int quality = 1)
    {
        this.PropType = propType;
        this.Quality = quality;
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
