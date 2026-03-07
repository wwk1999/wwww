public enum SkillType
{
    None,
    Normal,
    Dash,
    Ice1,
    Ice2,
    Ice3,
    Ice4,
    Ice5,
  
    Huo1,
    Huo2,
    Huo3,
    Huo4,
    Huo5,
    
    Dian1,
    Dian2,
    Dian3,
    Dian4,
    Dian5,
    
    HeiAn1,
    HeiAn2,
    HeiAn3,
    HeiAn4,
    HeiAn5,
}

public enum SkillInfoType
{
    None,
    Ice1,
    Ice2,
    Ice3,
    Ice4,
    Ice5,
    
    Ice1_1,
    Ice2_1,
    Ice3_1,
    Ice4_1,
    Ice5_1,
    
    Ice1_2,
    Ice2_2,
    Ice3_2,
    Ice4_2,
    Ice5_2,
    
    IceBei1,
    IceBei2,
    IceBei3,
    IceBei4,
    IceMain,
  
    Huo1,
    Huo2,
    Huo3,
    Huo4,
    Huo5,
    
    Huo1_1,
    Huo2_1,
    Huo3_1,
    Huo4_1,
    Huo5_1,
    
    Huo1_2,
    Huo2_2,
    Huo3_2,
    Huo4_2,
    Huo5_2,
    
    HuoBei1,
    HuoBei2,
    HuoBei3,
    HuoBei4,
    HuoMain,
    
    
    
    Dian1,
    Dian2,
    Dian3,
    Dian4,
    Dian5,
    
    Dian1_1,
    Dian2_1,
    Dian3_1,
    Dian4_1,
    Dian5_1,
    
    Dian1_2,
    Dian2_2,
    Dian3_2,
    Dian4_2,
    Dian5_2,
    
    DianBei1,
    DianBei2,
    DianBei3,
    DianBei4,
    DianMain,
    
    
    
    
    HeiAn1,
    HeiAn2,
    HeiAn3,
    HeiAn4,
    HeiAn5,
    
    HeiAn1_1,
    HeiAn2_1,
    HeiAn3_1,
    HeiAn4_1,
    HeiAn5_1,
    
    HeiAn1_2,
    HeiAn2_2,
    HeiAn3_2,
    HeiAn4_2,
    HeiAn5_2,
    
    HeiAnBei1,
    HeiAnBei2,
    HeiAnBei3,
    HeiAnBei4,
    HeiAnMain,
}

public class SkillJiaDian : XSingleton<SkillJiaDian>
{
    public int CurrentSkillCount = 0;

    public int IceBei1;
    public int IceBei2;
    public int IceBei3;
    public int IceBei4;
    
    public int Ice1=2;
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

    public int ZhiYeZJ1;
    public int ZhiYeZJ2;
    public int ZhiYeZJ3;
    public int ZhiYeZJ4;
    public int ZhiYeZJ5;
    public int ZhiYeZJ6;

    public int IceAll=>GetIceAll();
    public int HuoAll=>GetHuoAll();
    public int DianAll=>GetDianAll();
    public int HeiAnAll=>GetHeiAnAll();
    public int ZJIceAll=>GetZJIceAll();
    public int ZJHuoAll=>GetZJHuoAll();
    public int ZJDianAll=>GetZJDianAll();
    public int ZJHeiAnAll=>GetZJHeiAnAll();
    public int ZJZhiYeAll=>GetZJZhiYeAll();
    
    public SkillType LMB = SkillType.Normal;
    public SkillType RMB = SkillType.Dash;
    public SkillType Alpha1 = SkillType.None;//当前装备的技能类型
    public SkillType Alpha2 = SkillType.None;
    public SkillType Alpha3 = SkillType.None;
    public SkillType Alpha4 = SkillType.None;
    public SkillType Alpha5 = SkillType.None;


    public bool Ice1Auto = false;
    public bool Ice2Auto = false;
    public bool Ice3Auto = false;
    public bool Ice4Auto = false;
    public bool Ice5Auto = false;

    
    public bool Huo1Auto = false;
    public bool Huo2Auto = false;
    public bool Huo3Auto = false;
    public bool Huo4Auto = false;
    public bool Huo5Auto = false;
    
    public bool Dian1Auto = false;
    public bool Dian2Auto = false;
    public bool Dian3Auto = false;
    public bool Dian4Auto = false;
    public bool Dian5Auto = false;
    
    public bool HeiAn1Auto = false;
    public bool HeiAn2Auto = false;
    public bool HeiAn3Auto = false;
    public bool HeiAn4Auto = false;
    public bool HeiAn5Auto = false;
    
    public int GetIceAll()
    {
        int value = 0;
        value += IceBei1+IceBei2+IceBei3+IceBei4+Ice1+Ice1_1+Ice1_2+Ice2+Ice2_1+Ice2_2+Ice3+Ice3_1+Ice3_2+Ice4+Ice4_1+Ice4_2+Ice5+Ice5_1+Ice5_2;
        return value;
    }
    
    public int GetHuoAll()
    {
        int value = 0;
        value += HuoBei1+HuoBei2+HuoBei3+HuoBei4+Huo1+Huo1_1+Huo1_2+Huo2+Huo2_1+Huo2_2+Huo3+Huo3_1+Huo3_2+Huo4+Huo4_1+Huo4_2+Huo5+Huo5_1+Huo5_2;
        return value;
    }
    
    public int GetDianAll()
    {
        int value = 0;
        value += DianBei1+DianBei2+DianBei3+DianBei4+Dian1+Dian1_1+Dian1_2+Dian2+Dian2_1+Dian2_2+Dian3+Dian3_1+Dian3_2+Dian4+Dian4_1+Dian4_2+Dian5+Dian5_1+Dian5_2;
        return value;
    }
    
    
    public int GetHeiAnAll()
    {
        int value = 0;
        value += HeiAnBei1+HeiAnBei2+HeiAnBei3+HeiAnBei4+HeiAn1+HeiAn1_1+HeiAn1_2+HeiAn2+HeiAn2_1+HeiAn2_2+HeiAn3+HeiAn3_1+HeiAn3_2+HeiAn4+HeiAn4_1+HeiAn4_2+HeiAn5+HeiAn5_1+HeiAn5_2;
        return value;
    }
    
    
    public int GetZJIceAll()
    {
        int value = 0;
        value+=IceZJ1+IceZJ2+IceZJ3+IceZJ4+IceZJ5+IceZJ6;
        return value;
    }
    
    public int GetZJHuoAll()
    {
        int value = 0;
        value+=HuoZJ1+HuoZJ2+HuoZJ3+HuoZJ4+HuoZJ5+HuoZJ6;
        return value;
    }
    
    public int GetZJDianAll()
    {
        int value = 0;
        value+=DianZJ1+DianZJ2+DianZJ3+DianZJ4+DianZJ5+DianZJ6;
        return value;
    }
    
    public int GetZJHeiAnAll()
    {
        int value = 0;
        value+=HeiAnZJ1+HeiAnZJ2+HeiAnZJ3+HeiAnZJ4+HeiAnZJ5+HeiAnZJ6;
        return value;
    }
    
    public int GetZJZhiYeAll()
    {
        int value = 0;
        value+=ZhiYeZJ1+ZhiYeZJ2+ZhiYeZJ3+ZhiYeZJ4+ZhiYeZJ5+ZhiYeZJ6;
        return value;
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}