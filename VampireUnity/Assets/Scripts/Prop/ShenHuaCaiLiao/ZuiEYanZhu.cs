namespace Prop
{
    public class ZuiEYanZhu:PropBase
    {
        public ZuiEYanZhu() : base( new PropTable()){}

        private void Awake()
        {
            propTables.EquipName = "ZuiEYanZhu";
            propTables.Count = 1;
            propTables.Desc = null;
            propTables.PropType = PropConfig.PropType.ShenHuaCaiLiao;
            propTables.Quality = 4;
        }
    }
}