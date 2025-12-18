namespace Prop
{
    public class GoldBlood:PropBase
    {
        public GoldBlood() : base( new PropTable()){}
            
        private void Awake()
        {
            propTables.EquipName = "GoldBlood";
            propTables.Count = 1;
            propTables.Desc = null;
            propTables.PropType = PropConfig.PropType.ShenHuaCaiLiao;
            propTables.Quality = 2;
        }
    }
}