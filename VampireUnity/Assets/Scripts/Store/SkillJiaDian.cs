public enum SkillYuanSuType
{
    None,
    Ice,
    Huo,
    Dian,
    HeiAn
}

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
    
    public int DianSkill1Damage=0;
    public int DianSkill1Cd=0;
    public int DianSkill1Range=0;
    public int DianSkill1YuanSu=0;
    
    public int DianSkill2=0;
    public int DianSkill2Cd=0;
    public int DianSkill2Duration=0;
    public int DianSkill2YuanSu=0;
    
    public int DianSkill3=0;
    public int DianSkill3Cd=0;
    public int DianSkill3Count=0;
    public int DianSkill3YuanSu=0;
    
    public int IceSkill1=0;
    public int IceSkill1Cd=0;
    public int IceSkill1Range=0;
    public int IceSkill1YuanSu=0;
    
    public int IceSkill2Damage=0;
    public int IceSkill2Cd=0;
    public int IceSkill2Time=0;
    public int IceSkill2YuanSu=0;
    
    public int IceSkill3Damage=0;
    public int IceSkill3Cd=0;
    public int IceSkill3Range=0;
    public int IceSkill3YuanSu=0;
    
    
    public int HuoSkill1=0;
    public int HuoSkill1Cd=0;
    public int HuoSkill1Count=0;
    public int HuoSkill1YuanSu=0;
    
    public int HuoSkill2=0;
    public int HuoSkill2Cd=0;
    public int HuoSkill2Time=0;
    public int HuoSkill2YuanSu=0;
    
    public int HuoSkill3=0;
    public int HuoSkill3Cd=0;
    public int HuoSkill3Count=0;
    public int HuoSkill3YuanSu=0;
    
    
    public int HeiAnSkill1=0;
    public int HeiAnSkill1Cd=0;
    public int HeiAnSkill1Range=0;
    public int HeiAnSkill1YuanSu=0;
    
    public int HeiAnSkill2Damage=0;
    public int HeiAnSkill2Cd=0;
    public int HeiAnSkill2Time=0;
    public int HeiAnSkill2YuanSu=0;
    
    public int HeiAnSkill3Damage=0;
    public int HeiAnSkill3Cd=0;
    public int HeiAnSkill3Range=0;
    public int HeiAnSkill3YuanSu=0;
    
    

    public int MonsterAttack;
    public int MonsterCrit;
    public int MonsterHp;
    public int MonsterDefense;

    public SkillYuanSuType skill1Type=SkillYuanSuType.None;
    public SkillYuanSuType skill2Type=SkillYuanSuType.None;
    public SkillYuanSuType skill3Type=SkillYuanSuType.None;


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}