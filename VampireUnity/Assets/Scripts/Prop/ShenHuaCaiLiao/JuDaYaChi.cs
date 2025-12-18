namespace Prop
{
    public class JuDaYaChi:PropBase
    {
        public JuDaYaChi() : base( new PropTable()){}

        private void Awake()
        {
            propTables.EquipName = "JuDaYaChi";
            propTables.Count = 1;
            propTables.Desc = null;
            propTables.PropType = PropConfig.PropType.ShenHuaCaiLiao;
            propTables.Quality = 3;
        }
    }
}