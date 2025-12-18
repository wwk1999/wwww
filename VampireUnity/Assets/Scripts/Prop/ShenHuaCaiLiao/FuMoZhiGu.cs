namespace Prop
{
    public class FuMoZhiGu : PropBase
    {
         public FuMoZhiGu() : base( new PropTable()){}
            
            private void Awake()
            {
                propTables.EquipName = "FuMoZhiGu";
                propTables.Count = 1;
                propTables.Desc = null;
                propTables.PropType = PropConfig.PropType.ShenHuaCaiLiao;
                propTables.Quality = 1;
            }
    }
   
}