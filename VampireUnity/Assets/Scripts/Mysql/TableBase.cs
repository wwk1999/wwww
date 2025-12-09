namespace Mysql
{
    public enum TableType
    {
        None,
        SourceStoneTable,
        EquipTable
    }
    public class TableBase
    {
        public TableType TableType;
        public int Quality { get; set; }
        public string EquipName { get; set; }
    }
}