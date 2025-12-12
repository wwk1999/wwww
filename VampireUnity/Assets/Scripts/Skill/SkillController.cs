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
    [NonSerialized]public ParticleSystem IceExplosion1;
    [NonSerialized]public ParticleSystem IceExplosion2;
    [NonSerialized]public ParticleSystem IceExplosion3;
    [NonSerialized]public GameObject IceExTrigger;
    [NonSerialized]public int IceBallSpeed = 5;
    [NonSerialized]public GameObject IceBallGameObject;
    //技能冷却时间
    public float IceArrowtime => (3f*(1-GlobalPlayerAttribute.Skill1CdNum/100.0f));
    public float IceExplosiontime => (10f*(1-GlobalPlayerAttribute.Skill3CdNum/100.0f));
    public float IceBalltime => (10f*(1-GlobalPlayerAttribute.Skill2CdNum/100.0f));
    public float Dashtime => (10f*(1-GlobalPlayerAttribute.DashCdNum/100.0f));
    public float DianQuantime => (10f*(1-GlobalPlayerAttribute.Skill1CdNum/100.0f));
    
    [NonSerialized]public float NormalAttackCoolingtime = 1f;
    [NonSerialized]public float IceArrowCoolingtime = 3f;
    [NonSerialized]public float IceExplosionCoolingtime = 10f;
    [NonSerialized]public float IceBallCoolingtime = 10f;
    [NonSerialized]public float DashCoolingtime = 10f;
    [NonSerialized]public float DianQuanCoolingtime = 10f;
    
    //技能点击特效
    [NonSerialized]public UIParticle IceArrowUIFX;
    [NonSerialized]public UIParticle IceBallUIFX;
    [NonSerialized]public UIParticle IceExUIFX;
    
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
        
        
        IceExplosion1= GameController.S.transform.Find("Player(Clone)/IceExplosion/IceExplosion1/IceExplosionP1").GetComponent<ParticleSystem>();
        IceExplosion2= GameController.S.transform.Find("Player(Clone)/IceExplosion/IceExplosion2/IceExplosionP2").GetComponent<ParticleSystem>();
        IceExplosion3= GameController.S.transform.Find("Player(Clone)/IceExplosion/IceExplosion2/IceExplosionP3").GetComponent<ParticleSystem>();
        IceExTrigger = GameController.S.transform.Find("Player(Clone)/IceExplosion/IceExTrigger").gameObject;
        IceExTrigger.SetActive(false);
        IceExplosion1.Stop();
        IceExplosion2.Stop();
        IceExplosion3.Stop();
    }

    public void ShotBulletInvoke()
    {
        switch (GlobalPlayerAttribute.CurrentWeaponType)
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
        }
        NormalAttackCoolingtime+=Time.deltaTime;
    }

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
                var name = GameController.S.gamePlayer.playerSkeleton.AnimationState.GetCurrent(0).Animation.Name;
                if (name == "walk" || name == "idle")
                {
                    if (GameController.S.gamePlayer.playerState != PlayerState.Attack)
                    {
                        GameController.S.gamePlayer.playerSkeleton.AnimationState.SetAnimation(0, "attack", false);
                    }

                    GameController.S.gamePlayer.isAttack = true;
                    GameController.S.gamePlayer.playerState = PlayerState.Attack;
                }
                break;
            case SkillType.Skill1:
                if (DianQuanCoolingtime>=DianQuantime)
                {
                    Vector3 mouseScreen = Input.mousePosition;
                    float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
                    mouseScreen.z = depth; 
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
                    IceArrowUIFX.Play();
                    IceArrowCoolingtime = 0;
                    DianQuanCoolingtime = 0;
                    var dianquan= GameController.S.DianQuanQueue.Dequeue();
                    dianquan.gameObject.SetActive(true);
                    dianquan.transform.position = worldPos;
                }
                break;
            case SkillType.Skill2:
                if (IceBallCoolingtime >= IceBalltime)
                {
                    AudioController.S.PlayIceBall();
                    IceBallUIFX.Play();
           
                    IceBallCoolingtime=0;
                    StartIceBallSkill(3,3,3);
                }
                break;
            case SkillType.Skill3:
                if (IceExplosionCoolingtime >= IceExplosiontime)
                {
                    AudioController.S.PlayIceEx();
                    Debug.Log("mac点击了冰爆技能!");
                    IceExUIFX.Play();
         
                    IceExplosionCoolingtime=0;
                    IceExplosion1.Play();
                    IceExplosion2.Play();
                    IceExplosion3.Play();
                    IceExTrigger.gameObject.SetActive(true);
                }
                break;
        }
    }
    void Update()
    {
        //GameController.S.gamePlayer.iceBall.transform.rotation.z每帧+2
        if (IceBallGameObject != null)
        {
           IceBallGameObject.transform.Rotate(0, 0, IceBallSpeed);
        }
        
        //技能冷却时间
        NormalAttackCoolingtime+= Time.deltaTime;
        IceArrowCoolingtime+= Time.deltaTime;
        IceExplosionCoolingtime+=Time.deltaTime;
        IceBallCoolingtime+= Time.deltaTime;
        DashCoolingtime+=Time.deltaTime;
        DianQuanCoolingtime+= Time.deltaTime;
        
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
            IceArrowUIFX.Play();
           
            IceArrowCoolingtime = 0;
           IceArrow.Play();
           IceArrow.transform.Find("Trail").gameObject.SetActive(true);
        }
        
        if (IsDash )
        {
            GlobalPlayerAttribute.PlayerMoveSpeed = 20;
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

    public void StartIceBallSkill(int num, int scale, int speed)
    {
        switch (num)
        {
            case 1:
                IceBallGameObject = Instantiate(Resources.Load("Prefabs/Skill/IceBall").GameObject(), GameController.S.gamePlayer.transform);
                break;
            case 2:
                IceBallGameObject = Instantiate(Resources.Load("Prefabs/Skill/IceBall2").GameObject(), GameController.S.gamePlayer.transform);
                break;
            case 3:
                IceBallGameObject = Instantiate(Resources.Load("Prefabs/Skill/IceBall3").GameObject(), GameController.S.gamePlayer.transform);
                break;
            default:
                IceBallGameObject = Instantiate(Resources.Load("Prefabs/Skill/IceBall").GameObject(), GameController.S.gamePlayer.transform);
                break;
        }
        IceBallGameObject.transform.localScale = new Vector3(10, 10, 10);
        switch (scale)
        {
            case 1:
                IceBallGameObject.transform.localScale = new Vector3(10, 10, 10);
                break;
            case 2:
                IceBallGameObject.transform.localScale = new Vector3(13, 13, 13);
                break;
            case 3:
                IceBallGameObject.transform.localScale = new Vector3(16, 16, 16);
                break;
        }

        switch (speed)
        {
            case 1:
                IceBallSpeed =5;
                break;
            case 2:
                IceBallSpeed =8;                
                break;
            case 3:
                IceBallSpeed =11;                
                break;
        }
    }
}
