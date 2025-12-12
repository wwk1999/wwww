public class SkillJiaDian : XSingleton<SkillJiaDian>
{
    public int CurrentSkillCount = 0;
    
    public int NormalAttack=0;
    public int AttackSpeed=0;
    
    public int Crit=0;
    public int CritDamage=0;
    
    public int MoveSpeed=0;
    public int MoveAddAttack=0;
    public int MoveAddDefense=0;
    
    public int Dash=0;
    public int DashCd=0;
    
    public int Skill1Damage=0;
    public int Skill1Cd=0;
    public int Skill1Range=0;
    public int Skill1YiDian=0;
    
    public int Skill2Damage=0;
    public int Skill2Cd=0;
    public int Skill2Time=0;
    public int Skill2AddDefense=0;
    
    public int Skill3Damage=0;
    public int Skill3Cd=0;
    public int Skill3Range=0;
    public int Skill3JianSu=0;

    public int MonsterAttack;
    public int MonsterCrit;
    public int MonsterHp;
    public int MonsterDefense;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}