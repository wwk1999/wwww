public class SkillJiaDian : XSingleton<SkillJiaDian>
{
    public int CurrentSkillCount = 0;
    
    public float NormalAttack=0;
    public float NormalSpeed=0;
    
    public float Crit=0;
    public float CritDamage=0;
    
    public float MoveSpeed=0;
    public float MoveAddAttack=0;
    public float MoveAddDefense=0;
    
    public float Dash=0;
    public float DashCd=0;
    
    public float Skill1Damage=0;
    public float Skill1Cd=0;
    public float Skill1Range=0;
    public float Skill1YiDian=0;
    
    public float Skill2Damage=0;
    public float Skill2Cd=0;
    public float Skill2Time=0;
    public float Skill2AddDefense=0;
    
    public float Skill3Damage=0;
    public float Skill3Cd=0;
    public float Skill3Range=0;
    public float Skill3JianSu=0;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}