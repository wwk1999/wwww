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

    public int IceBei1;
    public int IceBei2;
    public int IceBei3;
    public int IceBei4;
    
    public int Ice1;
    public int Ice1_1;
    public int Ice1_2;
    public int Ice2;
    public int Ice2_1;
    public int Ice2_2;
    public int Ice3;
    public int Ice3_1;
    public int Ice3_2;
    public int Ice4;
    public int Ice4_1;
    public int Ice4_2;
    public int Ice5;
    public int Ice5_1;
    public int Ice5_2;

    
    public int HuoBei1;
    public int HuoBei2;
    public int HuoBei3;
    public int HuoBei4;
    
    public int Huo1;
    public int Huo1_1;
    public int Huo1_2;
    public int Huo2;
    public int Huo2_1;
    public int Huo2_2;
    public int Huo3;
    public int Huo3_1;
    public int Huo3_2;
    public int Huo4;
    public int Huo4_1;
    public int Huo4_2;
    public int Huo5;
    public int Huo5_1;
    public int Huo5_2;
    
    
    
    public int HeiAnBei1;
    public int HeiAnBei2;
    public int HeiAnBei3;
    public int HeiAnBei4;
    
    public int HeiAn1;
    public int HeiAn1_1;
    public int HeiAn1_2;
    public int HeiAn2;
    public int HeiAn2_1;
    public int HeiAn2_2;
    public int HeiAn3;
    public int HeiAn3_1;
    public int HeiAn3_2;
    public int HeiAn4;
    public int HeiAn4_1;
    public int HeiAn4_2;
    public int HeiAn5;
    public int HeiAn5_1;
    public int HeiAn5_2;
    
    
    public int DianBei1;
    public int DianBei2;
    public int DianBei3;
    public int DianBei4;
    
    public int Dian1;
    public int Dian1_1;
    public int Dian1_2;
    public int Dian2;
    public int Dian2_1;
    public int Dian2_2;
    public int Dian3;
    public int Dian3_1;
    public int Dian3_2;
    public int Dian4;
    public int Dian4_1;
    public int Dian4_2;
    public int Dian5;
    public int Dian5_1;
    public int Dian5_2;



    public int IceZJ1;
    public int IceZJ2;
    public int IceZJ3;
    public int IceZJ4;
    public int IceZJ5;
    public int IceZJ6;
    
    public int HuoZJ1;
    public int HuoZJ2;
    public int HuoZJ3;
    public int HuoZJ4;
    public int HuoZJ5;
    public int HuoZJ6;
    
    public int DianZJ1;
    public int DianZJ2;
    public int DianZJ3;
    public int DianZJ4;
    public int DianZJ5;
    public int DianZJ6;
    
    public int HeiAnZJ1;
    public int HeiAnZJ2;
    public int HeiAnZJ3;
    public int HeiAnZJ4;
    public int HeiAnZJ5;
    public int HeiAnZJ6;

    
    public SkillYuanSuType skill1Type=SkillYuanSuType.None;
    public SkillYuanSuType skill2Type=SkillYuanSuType.None;
    public SkillYuanSuType skill3Type=SkillYuanSuType.None;
    public SkillYuanSuType skill4Type=SkillYuanSuType.None;
    public SkillYuanSuType skill5Type=SkillYuanSuType.None;


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}