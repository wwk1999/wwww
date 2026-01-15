using System;
using Coffee.UIExtensions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SkillController : XSingleton<SkillController>
{

    [NonSerialized]public bool IsDash=false;
    [NonSerialized]public int ShadowCount = 5;
    [NonSerialized]public int CurrentDashCount = 0;
    //技能相关
    [NonSerialized]public ParticleSystem IceArrow;
    [NonSerialized]public ParticleSystem NormalAttack;
    [NonSerialized]public GameObject NormalAttack2;
    [NonSerialized]public GameObject NormalAttack3;
    [NonSerialized]public GameObject NormalAttack4;
    [NonSerialized]public GameObject IceExplosion;
    [NonSerialized]public ParticleSystem IceExplosion1;
    [NonSerialized]public ParticleSystem IceExplosion2;
    [NonSerialized]public ParticleSystem IceExplosion3;
    [NonSerialized]public GameObject IceExTrigger;
    [NonSerialized]public float IceBallSpeed = 5f;
    [NonSerialized]public GameObject IceBallGameObject;
    //技能冷却时间
    public float IceArrowtime => (3f*(1-GlobalPlayerAttribute.Skill1CdNum/100.0f));
    public float IceExplosiontime => (10f*(1-GlobalPlayerAttribute.Skill3CdNum/100.0f));
    public float IceBalltime => (15f*(1-GlobalPlayerAttribute.Skill2CdNum/100.0f));
    public float IceBallDuration = 5;
    public float Dashtime => GetDashCd();
    public float DianQuantime => (10f*(1-GlobalPlayerAttribute.Skill1CdNum/100.0f));
    
    [NonSerialized]public float IceArrowCoolingtime = 0;
    [NonSerialized]public float IceExplosionCoolingtime = 0f;
    [NonSerialized]public float IceBallCoolingtime = 0f;
    public float DashCoolingtime = 0;
   

    [NonSerialized]public float DianQuanCoolingtime = 0f;
    
    public SkillType LMB
    {
        get => SkillData.S.LMB;
        set => SkillData.S.LMB = value;
    }
    public SkillType RMB
    {
        get => SkillData.S.RMB;
        set => SkillData.S.RMB = value;
    }
    public SkillType Alpha1
    {
        get => SkillData.S.Alpha1;
        set => SkillData.S.Alpha1 = value;
    }
    public SkillType Alpha2
    {
        get => SkillData.S.Alpha2;
        set => SkillData.S.Alpha2 = value;
    }
    public SkillType Alpha3
    {
        get => SkillData.S.Alpha3;
        set => SkillData.S.Alpha3 = value;
    }


    public float GetDashCd()
    {
        float cd = (10f * (1 - GlobalPlayerAttribute.DashCdNum / 100.0f));
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DashCd))
        {
            cd *= 0.7f;
        }

        return cd;
    }


    void Start()
    {
        //技能相关
        IceArrow = GameController.S.transform.Find("Player(Clone)/Pistol(Clone)/IceArrow/IceArrowParticleSystem").GetComponent<ParticleSystem>();
        IceArrow.Stop();
        NormalAttack= GameController.S.transform.Find("Player(Clone)/Pistol(Clone)/NormalAttack").GetComponent<ParticleSystem>();
        NormalAttack2= GameController.S.transform.Find("Player(Clone)/Pistol(Clone)/NormalAttack2").gameObject;
        NormalAttack3= GameController.S.transform.Find("Player(Clone)/Pistol(Clone)/NormalAttack3").gameObject;
        NormalAttack4= GameController.S.transform.Find("Player(Clone)/Pistol(Clone)/NormalAttack4").gameObject;
        ParticleSystem normalAttack21=NormalAttack2.transform.Find("NormalAttack-1").GetComponent<ParticleSystem>();
        ParticleSystem normalAttack22=NormalAttack2.transform.Find("NormalAttack-2").GetComponent<ParticleSystem>();
        ParticleSystem normalAttack31=NormalAttack3.transform.Find("NormalAttack-1").GetComponent<ParticleSystem>();
        ParticleSystem normalAttack32=NormalAttack3.transform.Find("NormalAttack-2").GetComponent<ParticleSystem>();
        ParticleSystem normalAttack33=NormalAttack3.transform.Find("NormalAttack-3").GetComponent<ParticleSystem>();
        ParticleSystem normalAttack41=NormalAttack4.transform.Find("NormalAttack-1").GetComponent<ParticleSystem>();
        ParticleSystem normalAttack42=NormalAttack4.transform.Find("NormalAttack-2").GetComponent<ParticleSystem>();
        ParticleSystem normalAttack43=NormalAttack4.transform.Find("NormalAttack-3").GetComponent<ParticleSystem>();
        ParticleSystem normalAttack44=NormalAttack4.transform.Find("NormalAttack-4").GetComponent<ParticleSystem>();

        normalAttack21.Stop();
        normalAttack22.Stop();
        normalAttack31.Stop();
        normalAttack32.Stop();
        normalAttack33.Stop();
        
        normalAttack41.Stop();
        normalAttack42.Stop();
        normalAttack43.Stop();
        normalAttack44.Stop();

        NormalAttack.Stop();
        
        IceExplosion= GameController.S.transform.Find("Player(Clone)/IceExplosion").gameObject;
        IceExplosion1= GameController.S.transform.Find("Player(Clone)/IceExplosion/IceExplosion1/IceExplosionP1").GetComponent<ParticleSystem>();
        IceExplosion2= GameController.S.transform.Find("Player(Clone)/IceExplosion/IceExplosion2/IceExplosionP2").GetComponent<ParticleSystem>();
        IceExplosion3= GameController.S.transform.Find("Player(Clone)/IceExplosion/IceExplosion2/IceExplosionP3").GetComponent<ParticleSystem>();
        IceExTrigger = GameController.S.transform.Find("Player(Clone)/IceExplosion/parent/IceExTrigger").gameObject;
        IceExTrigger.SetActive(false);
        IceExplosion1.Stop();
        IceExplosion2.Stop();
        IceExplosion3.Stop();
    }

    //普通攻击发射子弹
    public void ShotBulletInvoke()
    {
        switch (PlayerData.S.playerWeaponType)
        {
            case WeaponType.Primary:
                GameController.S.gamePlayer.currentGun.PrimaryShot();
                break;
            case WeaponType.LanBao:
                GameController.S.gamePlayer.currentGun.LanBaoShot();
                break;
            case WeaponType.Fire:
                GameController.S.gamePlayer.currentGun.FireShot();
                break;
            case WeaponType.XuKong:
                GameController.S.gamePlayer.currentGun.XuKongShot();
                break;
            case WeaponType.LvQuan:
                GameController.S.gamePlayer.currentGun.LvQuanShot();
                break;
            case WeaponType.HeiDong:
                GameController.S.gamePlayer.currentGun.HeiDongShot();
                break;
            case WeaponType.Du:
                GameController.S.gamePlayer.currentGun.DuShot();
                break;
            case WeaponType.LuoLei:
                GameController.S.gamePlayer.currentGun.LuoLeiShot();
                break;
            case WeaponType.PuTong3:
                GameController.S.gamePlayer.currentGun.PuTong3Shot();
                break;
            case WeaponType.JianQi:
                GameController.S.gamePlayer.currentGun.JianQiShot();
                break;
        }
    }

    //释放技能
    public void ExcuteSkill(SkillType skillType)
    {
        switch (skillType)
        {
            case SkillType.Dash:
                if (DashCoolingtime >= Dashtime)
                {
                    DashCoolingtime = 0;
                    IsDash = true;
                }
                break;
            case SkillType.Normal:
                break;
            case SkillType.Skill1:
                if (DianQuanCoolingtime>=DianQuantime)
                {
                    Vector3 mouseScreen = Input.mousePosition;
                    float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
                    mouseScreen.z = depth; 
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
                    IceArrowCoolingtime = 0;
                    DianQuanCoolingtime = 0;
                    var dianquan= GameController.S.DianQuanQueue.Dequeue();
                    dianquan.gameObject.SetActive(true);
                    dianquan.transform.localScale=new Vector3(dianquan.transform.localScale.x*(1+GlobalPlayerAttribute.Skill1RangeNum/100.0f),dianquan.transform.localScale.y*(1+GlobalPlayerAttribute.Skill1RangeNum/100.0f),1);
                    dianquan.transform.position = worldPos;
                }
                break;
            case SkillType.Skill2:
                if (IceBallCoolingtime >= IceBalltime)
                {
                    AudioController.S.PlayIceBall();
                    IceBallCoolingtime=0;
                    if(GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.Skill2AddDan))
                    {
                        StartIceBallSkill(5);
                    }
                    else
                    {
                        StartIceBallSkill(4);
                    }
                }
                break;
            case SkillType.Skill3:
                if (IceExplosionCoolingtime >= IceExplosiontime)
                {
                    AudioController.S.PlayIceEx();
                    IceExplosionCoolingtime=0;
                    var iceex = GameController.S.IceExQueue.Dequeue();
                    if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.Skill3AddRange))
                    {
                        iceex.transform.localScale=new Vector3(1.3f,1.3f,1.3f);
                    }
                    iceex.transform.position=GameController.S.gamePlayer.transform.position;
                   iceex.gameObject.SetActive(true);
                }
                break;
        }
    }
    void Update()
    {
        //技能冷却时间
        IceArrowCoolingtime+= Time.deltaTime;
        IceExplosionCoolingtime+=Time.deltaTime;
        IceBallCoolingtime+= Time.deltaTime;
        DashCoolingtime+=Time.deltaTime;
        DianQuanCoolingtime+= Time.deltaTime;

        if (DashCoolingtime >= Dashtime && SkillJiaDian.S.Dash >= 1&&SkillData.S.dashAuto)
        {
            ExcuteSkill(SkillType.Dash);
        }
        
        if (DianQuanCoolingtime >= DianQuantime && SkillJiaDian.S.Skill1Damage >= 1&&SkillData.S.skill1Auto)
        {
            ExcuteSkill(SkillType.Skill1);
        }
        
        if (IceBallCoolingtime >= IceBalltime && SkillJiaDian.S.Skill2Damage >= 1&&SkillData.S.skill2Auto)
        {
            ExcuteSkill(SkillType.Skill2);
        }
        
        if (IceExplosionCoolingtime >= IceExplosiontime && SkillJiaDian.S.Skill3Damage >= 1&&SkillData.S.skill3Auto)
        {
            ExcuteSkill(SkillType.Skill3);
        }
        
        
        //技能CD
        FightBGController.S.IceExYellowCd.GetComponent<Image>().fillAmount= IceExplosionCoolingtime / IceExplosiontime;
        FightBGController.S.iceExButton.GetComponent<Button>().image.fillAmount= IceExplosionCoolingtime / IceExplosiontime;
        FightBGController.S.IceArrowYellowCd.GetComponent<Image>().fillAmount= DianQuanCoolingtime / DianQuantime;
        FightBGController.S.iceArrowButton.GetComponent<Button>().image.fillAmount= DianQuanCoolingtime / DianQuantime;
        FightBGController.S.IceBallYellowCd.GetComponent<Image>().fillAmount= IceBallCoolingtime / IceBalltime;
        FightBGController.S.iceBallButton.GetComponent<Button>().image.fillAmount= IceBallCoolingtime / IceBalltime;


        //长按左键
        if (Input.GetMouseButton(0))
        {
            ExcuteSkill(LMB);
        }
        
        if (Input.GetMouseButton(1))
        {
            ExcuteSkill(RMB);
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            ExcuteSkill(Alpha1);
        }
        
        if (Input.GetKey(KeyCode.Alpha2))
        {
            ExcuteSkill(Alpha2);
        }
        
        if (Input.GetKey(KeyCode.Alpha3))
        {
            ExcuteSkill(Alpha3);
        }
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameController.S.gamePlayer.transform.Find("Shield").gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameController.S.gamePlayer.transform.Find("Rage").gameObject.SetActive(true);
        }
        //mac点击冰箭技能
        if (Input.GetKeyDown(KeyCode.U)&&IceArrowCoolingtime>= IceArrowtime)
        {
            Debug.Log("mac点击了冰箭技能");
            AudioController.S.PlayIceArrow();
           
            IceArrowCoolingtime = 0;
           IceArrow.Play();
           IceArrow.transform.Find("Trail").gameObject.SetActive(true);
        }
        
        if (IsDash )
        {
            float dashSpeed = 20;
            if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DashRange))
            {
                dashSpeed *=1.3f;
            }
            GlobalPlayerAttribute.PlayerMoveSpeed = dashSpeed;
            GameObject playerShadow = Instantiate(Resources.Load("Prefabs/Skill/DashShadowObject"),GameController.S.transform).GameObject().transform.Find("DashShadow").gameObject;
            playerShadow.gameObject.SetActive(true);
            playerShadow.transform.localPosition = new Vector3(GameController.S.gamePlayer.transform.Find("IceMage").position.x-0.15f, GameController.S.gamePlayer.transform.Find("IceMage").position.y+0.62f,GameController.S.gamePlayer.transform.Find("IceMage").position.z);
            playerShadow.GetComponent<DashShadow>().StartA = 120+CurrentDashCount*10;
            CurrentDashCount++;
            if (CurrentDashCount > ShadowCount)
            {
                CurrentDashCount = 0;
                IsDash = false;
                GlobalPlayerAttribute.PlayerMoveSpeed = 3;
            }
        }
    }

    public void StartIceBallSkill(int num)
    {
        switch (num)
        {
            case 4:
                GameController.S.gamePlayer.IceBall4.SetActive(true);
                break;
            case 5:
                GameController.S.gamePlayer.IceBall5.SetActive(true);
                break;
        }
    }
}
