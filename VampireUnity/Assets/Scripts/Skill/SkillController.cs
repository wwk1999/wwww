using System;
using System.Collections;
using Coffee.UIExtensions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SkillController : XSingleton<SkillController>
{

    [NonSerialized]public bool IsDash=false;
    [NonSerialized]public int ShadowCount = 5;
    [NonSerialized]public int CurrentDashCount = 0;
    //技能相关
    [NonSerialized]public ParticleSystem NormalAttack;
    [NonSerialized]public GameObject NormalAttack2;
    [NonSerialized]public GameObject NormalAttack3;
    [NonSerialized]public GameObject NormalAttack4;
    [NonSerialized]public GameObject IceExTrigger;
    [NonSerialized]public float IceBallSpeed = 5f;
    [NonSerialized]public GameObject IceBallGameObject;
    //技能冷却时间
    public float IceArrowtime => (3f*(1-GlobalPlayerAttribute.Skill1CdNum/100.0f));
    public float IceExplosiontime => (10f*(1-GlobalPlayerAttribute.Skill3CdNum/100.0f));
    public float IceBalltime => (15f*(1-GlobalPlayerAttribute.Skill2CdNum/100.0f));
    public float IceBallDuration = 5;
    public float HuoSkill2Duration = 5;
    public float DianSkill2Duration = 5;
    public float HeiAnSkill2Duration = 5;

    public float Dashtime => GetDashCd();
    public float DianQuantime => GetDianQuanTime();



    public float HuoDamage => GetHuoDamage();
    public float DianDamage => GetDianDamage();
    public float HeiAnDamage => GetHeiAnDamage();


    public bool IsHuoSkill2=false;
    public bool IsDianSkill2=false;
    public bool IsHeiAnSkill2=false;



    public float GetHuoDamage()
    {
        float value = 1.0f;
        if (IsHuoSkill2)
        {
            value += 0.3f;
        }
        return value;
    }
    
    
    public float GetDianDamage()
    {
        float value = 1.0f;
        if (IsDianSkill2)
        {
            value += 0.3f;
        }
        return value;
    }
    
    public float GetHeiAnDamage()
    {
        float value = 1.0f;
        if (IsHeiAnSkill2)
        {
            value += 0.3f;
        }
        return value;
    }
    public float GetDianQuanTime()
    {
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.Skill1ReplaceNormalAttack))
        {
            return (10f * (1 - GlobalPlayerAttribute.Skill1CdNum / 100.0f)) * 0.5f;
        }

        return (10f * (1 - GlobalPlayerAttribute.Skill1CdNum / 100.0f));
    }
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
    }

    IEnumerator HuoSkill3(int count,int redis,float time)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);

        for (int i = 0; i < count; i++)
        {
            float offectX = Random.Range(0, 1.0f);
            float offectY = Random.Range(0, 1.0f);
            Vector3 dir = new Vector2(offectX, offectY);
            Vector2 pos = worldPos + dir * redis;
            var dianquan= GameController.S.HuoSkill3Queue.Dequeue();
            dianquan.gameObject.SetActive(true);
            dianquan.transform.position = pos;
            dianquan._renderer.sortingOrder = 10001 + i;
            yield return new WaitForSeconds(time);
        }
    }

    public void DianSKill3()
    {
        float waveOffset = Random.Range(0,30);
        int bulletCount = 12;
        float angleStep = 360f / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            var xieZiSkill1 = GameController.S.DianSkill3Queue.Dequeue();
            float angle = i * angleStep + waveOffset;
            float angleRad = angle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
            xieZiSkill1.transform.position = GameController.S.gamePlayer.transform.position;
            xieZiSkill1.MoveDirection = direction;
            xieZiSkill1.MoveSpeed = 10f;
            xieZiSkill1.gameObject.SetActive(true);
        }
    }

    public void HeiAnSkill1()
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        var dianquan= GameController.S.HeiAnSkill1Queue.Dequeue();
        dianquan.gameObject.SetActive(true);
        dianquan.transform.position = worldPos;
    }

    public void HuoSkill2()
    {
        GameController.S.gamePlayer.HuoSkill2.gameObject.SetActive(true);
        IsHuoSkill2 = true;
        Invoke(nameof(StopHuoSkill2),HuoSkill2Duration);
    }
    
    public void DianSkill2()
    {
        GameController.S.gamePlayer.DianSkill2.gameObject.SetActive(true);
        IsDianSkill2 = true;
        Invoke(nameof(StopDianSkill2),DianSkill2Duration);
    }
    
    public void HeiAnSkill2()
    {
        GameController.S.gamePlayer.HeiAnSkill2.gameObject.SetActive(true);
        IsHeiAnSkill2 = true;
        Invoke(nameof(StopHeiAnSkill2),HeiAnSkill2Duration);
    }

    public void StopHuoSkill2()
    {
        GameController.S.gamePlayer.HuoSkill2.gameObject.SetActive(false);
        IsHuoSkill2 = false;
    }
    
    public void StopDianSkill2()
    {
        GameController.S.gamePlayer.DianSkill2.gameObject.SetActive(false);
        IsDianSkill2 = false;
    }
    
    public void StopHeiAnSkill2()
    {
        GameController.S.gamePlayer.HeiAnSkill2.gameObject.SetActive(false);
        IsHeiAnSkill2 = false;
    }
    
    public void HuoSkill1()
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        // 原始方向
        Vector2 baseDir = (worldPos -GameController.S.gamePlayer.transform.position).normalized;

        int bulletCount = 3;
        // 两个偏移角度：+10° 和 -10°
      
        Vector2[] dirs5 =
        {
            Quaternion.AngleAxis( 0f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -3f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 3f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -5f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 5f, Vector3.forward) * baseDir,
        };
        Vector2[] dirs=dirs5;
       
        foreach (Vector2 dir in dirs)
        {
            HuoSkill1 bullet = GameController.S.HuoSkill1Queue.Dequeue();
            bullet.transform.position = GameController.S.gamePlayer.transform.position;
            
            bullet.MoveDirection = dir;
            bullet.MoveSpeed = 10f;
            bullet.gameObject.SetActive(true);
        }
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

    public void HeiAnSkill3()
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        var dianquan= GameController.S.HeiAnSkill3Queue.Dequeue();
        dianquan.gameObject.SetActive(true);
        dianquan.transform.position = worldPos;
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
                    if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.Skill3Bian3))
                    {
                        StartCoroutine(Skill3Bian3());
                    }
                    else
                    {
                        var iceex = GameController.S.IceExQueue.Dequeue();
                        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.Skill3AddRange))
                        {
                            iceex.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                        }

                        iceex.transform.position = GameController.S.gamePlayer.transform.position;
                        iceex.gameObject.SetActive(true);
                    }
                }
                break;
        }
    }


    IEnumerator Skill3Bian3()
    {
        for (int i = 0; i < 3; i++)
        {
            var iceex = GameController.S.IceExQueue.Dequeue();
            if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.Skill3AddRange))
            {
                iceex.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            }
            iceex.transform.position = GameController.S.gamePlayer.transform.position;
            iceex.damageCount = 0.7f;
            iceex.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
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
        
        if (Input.GetKey(KeyCode.Alpha4))
        {
            StartCoroutine(HuoSkill3(5,1,0.2f));
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
