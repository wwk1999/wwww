using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Equip;
using Mysql;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Slider = UnityEngine.UI.Slider;

//怪物类型枚举
public enum MonsterType
{
    None = 0,
    Normal = 1,
    Elite = 2,
    Boss = 3,
}

public enum State
{
    None,
    Idle,
    Move,
    Attack,
    Skill1,
    Skill2,
    Skill3,
    Die
}

public enum DamageFrom
{
    None,
    Normal,
    Skill1,
    Skill2,
    Skill3
}

public class MonsterProp
{
    public PropItem PropItem;
    public int Probability;
    
    public MonsterProp(PropItem propItem, int probability)
    {
        PropItem = propItem;
        Probability = probability;
    }

    public override bool Equals(object obj)
    {
        if (obj is MonsterProp other)
        {
            // 只比较 PropItem，忽略 Probability
            return Equals(PropItem, other.PropItem);
        }
        return false;
    }

    public override int GetHashCode()
    {
        // 只基于 PropItem 计算哈希码
        return PropItem?.GetHashCode() ?? 0;
    }
}

public class MonsterSpineName
{
    public string MoveName;
    public string HitName;
    public string DieName;
    public string IdleName;
    public string AttackName;
    public string Skill1Name;
    public string Skill2Name;
    public string Skill3Name;
    public string AppearName;
}
public abstract class MonsterBase : MonoBehaviour
{
    [NonSerialized] public bool IsYuanChen = false;
    [NonSerialized] public float NormalYuanChenSize = 4f;
    [NonSerialized] public float EliteYuanChenSize = 6f;

    [NonSerialized]  public MonsterTypeByName MonsterTypeByName;
    public GameObject du;
    public GameObject jiansu;
    public GameObject yidian;
    public GameObject zhuoshao;
    [NonSerialized] public float NormalYuanChenTime = 2f;
    [NonSerialized] public float NormalYuanChenCurrentTime = 2f;

    [NonSerialized] public float zhuoShaoTime = 0;
    [NonSerialized] public float zhuoShaoCurrentTime = 0;//毒间隔时间
    public float zhuoShaoDamage =>GameController.S.GameAttack*0.2f;
    
    
    
    [NonSerialized] public float baseSpeed = 0;

    
    
    public Canvas  hpSliderCanvas;
    public MeshRenderer  meshRenderer;
   
    [NonSerialized] public MonsterSpineName MonsterSpineName=new MonsterSpineName();
    public GameObject parent;
    
    
    [NonSerialized]public MonsterType MonsterType;//怪物类型
    [NonSerialized]public string MonsterName;//怪物名称
    [NonSerialized]public int MonsterLevel;//怪物等级
    [NonSerialized]public float CurrentHp;//当前血量
    [NonSerialized]public  float MaxHp;//最大血量
    [NonSerialized]public float Speed;//速度
    [NonSerialized]public float Attack;//攻击力
    [NonSerialized]public float Defense;//防御力
    [NonSerialized]public float Exp;//经验值
    [NonSerialized]public float BloodEnergy;//血能
    [NonSerialized]public int EvolutionEnergy;//源能
    [NonSerialized]public bool IsDead=false;//是否死亡
    [NonSerialized]public bool IsDash=false;//是否攻击
    [NonSerialized]public State MonsterState = State.None;
    [NonSerialized]public bool IsSkill=false;//是否在放技能
    [NonSerialized]public bool IsAttack=false;//是否在放技能
    [NonReorderable] public float size;//怪物大小
    public SkeletonAnimation monsterSkeletonAnimation;
    //public SpriteRenderer monsterSpriteRenderer;
    //public Animator monsterAnimator;
    public Slider hpSlider;


    //经验相关
    [NonSerialized]public Text playerLevelText;
    [NonSerialized]public bool isMove = true;
    [NonSerialized]public bool isHit = false;
    [NonSerialized] public bool isAttack = false;
    [NonSerialized]public bool isSkill1 = false;
    [NonSerialized]public bool isSkill2 = false;
    [NonSerialized]public bool isSkill3 = false;


    [NonSerialized]public bool isBeatback = true;

    public Collider2D collider2D;
    public Rigidbody2D rigidbody2D;

    
    [NonSerialized]public bool isJianSu=false;
    [NonSerialized]public float JianSuTime=0;

    public void ShotDanMu(Vector2 trans, Sprite sprite, float attack, Vector3 dir, bool isBoss)
    {
        DanMu danmu = QueueController.S.DanMuQueue.Dequeue();
        danmu.SetDanMu(sprite, attack, dir, isBoss);
        danmu.transform.position = trans;
        danmu.gameObject.SetActive(true);
    }

    public void InitAttribute()
    {
        MonsterInfo info = MonsterConfig.MonsterInfoDic[
            new MonsterDiaoLuoType()
            {
                GameLevel = LevelInfoConfig.CurrentGameLevel,
                MonsterType = MonsterConfig.MonsterTypeDic[MonsterTypeByName]
            }];
        Speed = info.speed;
        Attack = info.attack;
        Defense = info.defence;
        MaxHp = info.hp;
        Exp = info.ex;
        BloodEnergy = info.linghun;
    }

    //构造方法
    public MonsterBase(MonsterTypeByName type)
    {
        MonsterTypeByName = type;
    }
    
    public void Awake()
    {
        if (MonsterConfig.MonsterTypeDic[MonsterTypeByName] != MonsterType.Boss)
        {
            hpSlider.gameObject.SetActive(false);
        }
    }
    
    
    public void SetOrder()
    {
        meshRenderer.sortingOrder = (int)((15f - transform.position.y) * 100f);
    }

    public void Start()
    {
        //monsterSkeletonAnimation.skeleton.SetColor(new Color(0,0,0.8f));
        InitAttribute();
        CurrentHp = MaxHp;
        baseSpeed = Speed;
        du.gameObject.SetActive(false);
        jiansu.gameObject.SetActive(false);
        yidian.gameObject.SetActive(false);
        zhuoshao.gameObject.SetActive(false);

        if (MonsterConfig.MonsterTypeDic[MonsterTypeByName] != MonsterType.Boss)
        {
            if (monsterSkeletonAnimation != null)
            {
                monsterSkeletonAnimation.AnimationState.Complete += OnAnimationComplete;
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
            }
        }
    }

    private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Complete -= OnAnimationComplete;
    }

    private void OnEnable()
    {
        zhuoShaoCurrentTime = 0;
    }

    public void SetBingKuai()
    {
        monsterSkeletonAnimation.gameObject.SetActive(!isJianSu);
    }

    public void Update()
    {
        SetBingKuai();
        SetOrder();
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == MonsterSpineName.MoveName&&Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position) <= size&&IsYuanChen)
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.IdleName, false);
        }
        if (zhuoShaoTime > 0)
        {
            zhuoShaoTime -= Time.deltaTime;
            zhuoShaoCurrentTime+=Time.deltaTime;
            zhuoshao.gameObject.SetActive(true);
        }
        else
        {
            zhuoshao.gameObject.SetActive(false);
        }

        if (zhuoShaoCurrentTime >= 1)
        {
            zhuoShaoCurrentTime = 0;
            ShowHurtText(Mathf.RoundToInt(zhuoShaoDamage), false,YiChangState.ZhuoShao);
            CurrentHp -= zhuoShaoDamage;
            //设置血条
            hpSlider.value = CurrentHp;
            hpSlider.maxValue = MaxHp;
            if (CurrentHp <= 0 && !IsDead)
            {
                IsDead = true;
                Die();
            }
        }
        if (JianSuTime > 0)
        {
            JianSuTime -= Time.deltaTime;
            Speed = baseSpeed*(1.0f-GlobalPlayerAttribute.JianSuRate/100.0f);
            monsterSkeletonAnimation.skeleton.SetColor(Color.blue);
        }
        else
        {
            Speed = baseSpeed;
            monsterSkeletonAnimation.skeleton.SetColor(Color.white);
        }
    }
    

    public abstract void Skill();

    IEnumerator DelayXieZi()
    {
        yield return new WaitForSeconds(2f);
        transform.position=QueueController.S.gamePlayer.transform.position;
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill3", false);
    }
    
    
    public void OnAnimationComplete(TrackEntry trackEntry)
    {
        if (this is EliteDaZuiMonster||this is XueRen)
        {
            return;
        }
        if (trackEntry.Animation.Name ==MonsterSpineName.DieName)
        {
            gameObject.SetActive(false);
            return;
        }

        if (trackEntry.Animation.Name == MonsterSpineName.AppearName)
        {
            IsSkill=false;
        }
        if (trackEntry.Animation.Name == MonsterSpineName.Skill1Name)//沙漠蜥蜴
        {
            IsSkill=false;
            isSkill1 = false;
        }
       
        if (isSkill2)
        {
            IsSkill=false;
            isSkill2 = false;
            if (this is ZhaoZeBoss)
            {
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.Skill2Name, false);
            }

            if (this is XieZi)
            {
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.Skill2Name, false);
                StartCoroutine(DelayXieZi());
            }
        }
        else if (isSkill1)
        {
            IsSkill=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.Skill1Name, false);
            if (this is ShaMoElite)
            {
                ShaMoElite shaMoElite=this as ShaMoElite;
                shaMoElite.CheckSkill();
            }

            if (this is ShaXiYi)
            {
                ShaXiYi shaxiyi = this as ShaXiYi;
                var skeleton = monsterSkeletonAnimation.Skeleton;
                skeleton.SetSkin("skin_yinshen_hou");
                skeleton.SetupPoseSlots(); // 添加这行来重置插槽
                collider2D.tag = "Bullet";
                var random = Random.Range(4f, 6f);
                Invoke(nameof(ExitYinShen), random);
            }

            if (this is EliteBeeMonster)
            {
                Skill();
            }
        }
        else if(isAttack)
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
        }
        else
        {
            monsterSkeletonAnimation.timeScale = 1;
            if (Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position) > size||IsYuanChen==false)
            {
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
            }
            else
            {
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.IdleName, false);
            }
        }
    }

    public void ExitYinShen()
    {
        var skeleton = monsterSkeletonAnimation.Skeleton;
        skeleton.SetSkin("skin_yinshen_qian");
        skeleton.SetupPoseSlots();
        collider2D.tag = "Monster";
    }
    
    public void DelayDestroy()
    {
        gameObject.SetActive(false);
         //第一关怪物死亡
           if (this is SnotMonster snotMonster)
            {
                QueueController.S.SnotMonsterQueue.Enqueue(snotMonster);
            }
            else if (this is BatMonster batMonster)
            {
                QueueController.S.BatMonsterQueue.Enqueue(batMonster);
            }
            else if (this is SpiderMonster spiderMonster)
            {
                QueueController.S.SpiderMonsterQueue.Enqueue(spiderMonster);
            }
            else if (this is EliteBeeMonster eliteBeeMonster)
            {
                QueueController.S.EliteBeeMonsterQueue.Enqueue(eliteBeeMonster);
            }
            // 第二关怪物死亡
            else if (this is ChongZiMonster chongZiMonster)
            {
                QueueController.S.ChongZiMonsterQueue.Enqueue(chongZiMonster);
            }
            else if (this is XiaoHuoMonster xiaoHuoMonster)
            {
                QueueController.S.XiaoHuoMonsterQueue.Enqueue(xiaoHuoMonster);
            }
            else if (this is DunDiMonster dunDiMonster)
            {
                QueueController.S.DunDiMonsterQueue.Enqueue(dunDiMonster);
            }
            else if (this is EliteDaZuiMonster eliteDaZuiMonster)
            {
                QueueController.S.EliteDaZuiMonsterQueue.Enqueue(eliteDaZuiMonster);
            }
            else if (this is XiNiuMonster xiNiuMonster)
            {
                QueueController.S.XiNiuMonsterQueue.Enqueue(xiNiuMonster);
            }
            else if (this is HuangShu huangshu)
            {
                QueueController.S.HuangShuQueue.Enqueue(huangshu);
            } 
            // 第三关怪物死亡
            else if (this is WenZiMonster wenZiMonster)
            {
                QueueController.S.WenZiMonsterQueue.Enqueue(wenZiMonster);
            }
            else if (this is QingWaMonster qingWaMonster)
            {
                QueueController.S.QingWaMonsterQueue.Enqueue(qingWaMonster);
            }
            else if (this is JiaChongMonster jiaChongMonster)
            {
                QueueController.S.JiaChongMonsterQueue.Enqueue(jiaChongMonster);
            }
            else if (this is ShiRenHuaMonster shiRenHuaMonster)
            {
                QueueController.S.ShiRenHuaMonsterQueue.Enqueue(shiRenHuaMonster);
            }
            // 第四关怪物死亡
            else if (this is KuLou kuLou)
            {
                QueueController.S.KuLouQueue.Enqueue(kuLou);
            }
            else if (this is Huangzhu huangzhu)
            {
                QueueController.S.HuangZhuQueue.Enqueue(huangzhu);
            }
            else if (this is ShaChong shaChong)
            {
                QueueController.S.ShaChongQueue.Enqueue(shaChong);
            } else if (this is ShaNiao shaniao)
            {
                QueueController.S.ShaNiaoQueue.Enqueue(shaniao);
            } else if (this is XianRenZhang xianrenzhang)
            {
                QueueController.S.XianRenZhangQueue.Enqueue(xianrenzhang);
            }  else if (this is ShaXiYi shaxiyi)
            {
                QueueController.S.ShaXiYiQueue.Enqueue(shaxiyi);
            } 
           
           //第五关怪物
           else if (this is XueQiE xueQiE)
           {
               QueueController.S.XueQiEQueue.Enqueue(xueQiE);
           } 
           else if (this is XueZhangLang xueZhangLang)
           {
               QueueController.S.XueZhangLangQueue.Enqueue(xueZhangLang);
           } else if (this is YingShu yingShu)
           {
               QueueController.S.YingShuQueue.Enqueue(yingShu);
           } 
    }

    public void MonsterMove()
    {
        Vector3 direction = QueueController.S.gamePlayer.transform.position - transform.position;
        if (isJianSu)
        {
            rigidbody2D.velocity = direction.normalized * 0; 
        }
        else
        {
            if ((monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == MonsterSpineName.MoveName ||
                IsDash || monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name ==
                MonsterSpineName.HitName)&&Vector2.Distance(transform.position,QueueController.S.gamePlayer.transform.position) >size)
            {
                rigidbody2D.velocity = direction.normalized * Speed;
            }
            else
            {
                rigidbody2D.velocity = direction.normalized * 0;
            }
        }
    }
    

    // //动画事件，设置isHurt
    // public void SetIsHurt()
    // {
    //     monsterAnimator.SetBool("isHurt", false);
    // }
    // //动画事件，销毁怪物
    // public void DestroyMonster()
    // {
    //     Destroy(this.gameObject);
    // }
    public void SpriteFlipX(bool isRight)
    {
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name != MonsterSpineName.MoveName)
        {
            return;
        }
        float dis=Vector2.Distance(transform.position,QueueController.S.gamePlayer.transform.position);
        if(dis<0.2f)
        {
            //如果距离小于0.2f，则不翻转
            return;
        }
        //翻转精灵
        if (isRight)
        {
            if (QueueController.S.gamePlayer.transform.position.x > transform.position.x)
            {
                parent.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                parent.transform.localScale = new Vector3(-1, 1, 1);
            }
        }else
        {
            if (QueueController.S.gamePlayer.transform.position.x > transform.position.x)
            {
                parent.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                parent.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        
    }
    
    public void GetEx()
    {
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.ExAdd))
        {
            GlobalPlayerAttribute.Exp+= (int)(Exp*1.2f);
        }
        else
        {
            GlobalPlayerAttribute.Exp+= Exp;
        }
    }
    

    /// <summary>
    /// 生成血能
    /// </summary>
    public void CreateBloodEnergy()
    {
        //生成血能
        GameObject bloodEnergy = QueueController.S.BloodEnergyQueue.Dequeue();
        bloodEnergy.SetActive(true);
        //设置血能位置为怪物位置
        bloodEnergy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void AddWeaponEx()
    {
        switch (PlayerData.S.playerWeaponType)
        {
            case WeaponType.Primary:
                PlayerData.S.primaryWeaponExp += Exp;
                if (PlayerData.S.primaryWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.primaryWeaponLevel])
                {
                    PlayerData.S.primaryWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.primaryWeaponLevel];
                    PlayerData.S.primaryWeaponLevel++;
                }
                break;
            case WeaponType.PrimaryHuo:
                PlayerData.S.primaryHuoExp += Exp;
                if (PlayerData.S.primaryHuoExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.primaryHuoLevel])
                {
                    PlayerData.S.primaryHuoExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.primaryHuoLevel];
                    PlayerData.S.primaryHuoLevel++;
                }
                break;
            case WeaponType.PrimaryDian:
                PlayerData.S.primaryDianExp += Exp; 
                if (PlayerData.S.primaryDianExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.primaryDianLevel])
                {
                    PlayerData.S.primaryDianExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.primaryDianLevel];
                    PlayerData.S.primaryDianLevel++;
                }
                break;
            case WeaponType.PrimaryHeiAn:
                PlayerData.S.primaryHeiAnExp += Exp;
                if (PlayerData.S.primaryHeiAnExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.primaryHeiAnLevel])
                {
                    PlayerData.S.primaryHeiAnExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.primaryHeiAnLevel];
                    PlayerData.S.primaryHeiAnLevel++;
                }
                break;
            case WeaponType.IceBaoZha:
                PlayerData.S.iceBaoZhaExp += Exp; 
                if (PlayerData.S.iceBaoZhaExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.iceBaoZhaLevel])
                {
                    PlayerData.S.iceBaoZhaExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.iceBaoZhaLevel];
                    PlayerData.S.iceBaoZhaLevel++;
                }
                break;
            case WeaponType.DianBaoZha:
                PlayerData.S.dianBaoZhaExp += Exp; 
                if (PlayerData.S.dianBaoZhaExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.dianBaoZhaLevel])
                {
                    PlayerData.S.dianBaoZhaExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.dianBaoZhaLevel];
                    PlayerData.S.dianBaoZhaLevel++;
                }
                break;
            case WeaponType.HuoBaoZha:
                PlayerData.S.HuoBaoZhaExp += Exp; 
                if (PlayerData.S.HuoBaoZhaExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.HuoBaoZhaWeaponLevel])
                {
                    PlayerData.S.HuoBaoZhaExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.HuoBaoZhaWeaponLevel];
                    PlayerData.S.HuoBaoZhaWeaponLevel++;
                }
                break;
            case WeaponType.HeiAnBaoZha:
                PlayerData.S.HeiAnBaoZhaWeaponExp += Exp;
                if (PlayerData.S.HeiAnBaoZhaWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.HeiAnBaoZhaWeaponLevel])
                {
                    PlayerData.S.HeiAnBaoZhaWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.HeiAnBaoZhaWeaponLevel];
                    PlayerData.S.HeiAnBaoZhaWeaponLevel++;
                }
                break;
            case WeaponType.XuKong:
                PlayerData.S.xuKongWeaponExp += Exp; 
                if (PlayerData.S.xuKongWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.xuKongWeaponLevel])
                {
                    PlayerData.S.xuKongWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.xuKongWeaponLevel];
                    PlayerData.S.xuKongWeaponLevel++;
                }
                break;
            case WeaponType.PuTong3:
                PlayerData.S.puTong3WeaponExp += Exp; 
                if (PlayerData.S.puTong3WeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.puTong3WeaponLevel])
                {
                    PlayerData.S.puTong3WeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.puTong3WeaponLevel];
                    PlayerData.S.puTong3WeaponLevel++;
                }
                break;
            case WeaponType.Fire:
                PlayerData.S.fireWeaponExp += Exp;
                if (PlayerData.S.fireWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.fireWeaponLevel])
                {
                    PlayerData.S.fireWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.fireWeaponLevel];
                    PlayerData.S.fireWeaponLevel++;
                }
                break;
            case WeaponType.LvQuan:
                PlayerData.S.lvQuanWeaponExp += Exp; 
                if (PlayerData.S.lvQuanWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.lvQuanWeaponLevel])
                {
                    PlayerData.S.lvQuanWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.lvQuanWeaponLevel];
                    PlayerData.S.lvQuanWeaponLevel++;
                }
                break;
            case WeaponType.DianJiSu:
                PlayerData.S.DianJiSuWeaponExp += Exp; 
                if (PlayerData.S.DianJiSuWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.DianJiSuWeaponLevel])
                {
                    PlayerData.S.DianJiSuWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.DianJiSuWeaponLevel];
                    PlayerData.S.DianJiSuWeaponLevel++;
                }
                break;
            case WeaponType.DianSanShe:
                PlayerData.S.DianSanSheWeaponExp += Exp;
                if (PlayerData.S.DianSanSheWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.DianSanSheWeaponLevel])
                {
                    PlayerData.S.DianSanSheWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.DianSanSheWeaponLevel];
                    PlayerData.S.DianSanSheWeaponLevel++;
                }
                break;
            case WeaponType.Huo7:
                PlayerData.S.Huo7WeaponExp += Exp; 
                if (PlayerData.S.Huo7WeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.Huo7WeaponLevel])
                {
                    PlayerData.S.Huo7WeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.Huo7WeaponLevel];
                    PlayerData.S.Huo7WeaponLevel++;
                }
                break;
            case WeaponType.HuoFenLie:
                PlayerData.S.HuoFenLieWeaponExp += Exp;
                if (PlayerData.S.HuoFenLieWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.HuoFenLieWeaponLevel])
                {
                    PlayerData.S.HuoFenLieWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.HuoFenLieWeaponLevel];
                    PlayerData.S.HuoFenLieWeaponLevel++;
                }
                break;
            case WeaponType.HeiAnHuiXuan:
                PlayerData.S.HeiAnHuiXuanWeaponExp += Exp;
                if (PlayerData.S.HeiAnHuiXuanWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.HeiAnHuiXuanWeaponLevel])
                {
                    PlayerData.S.HeiAnHuiXuanWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.HeiAnHuiXuanWeaponLevel];
                    PlayerData.S.HeiAnHuiXuanWeaponLevel++;
                }
                break;
            case WeaponType.HeiAnQuXian:
                PlayerData.S.HeiAnQuXianWeaponExp += Exp; 
                if (PlayerData.S.HeiAnBaoZhaWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.HeiAnBaoZhaWeaponLevel])
                {
                    PlayerData.S.HeiAnQuXianWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.HeiAnQuXianWeaponLevel];
                    PlayerData.S.HeiAnQuXianWeaponLevel++;
                }
                break;
            case WeaponType.Ice7:
                PlayerData.S.Ice7WeaponExp += Exp;
                if (PlayerData.S.Ice7WeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.Ice7WeaponLevel])
                {
                    PlayerData.S.Ice7WeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.Ice7WeaponLevel];
                    PlayerData.S.Ice7WeaponLevel++;
                }
                break;
            case WeaponType.Ice4BaoZha:
                PlayerData.S.Ice4BaoZhaWeaponExp += Exp; 
                if (PlayerData.S.Ice4BaoZhaWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.Ice4BaoZhaWeaponLevel])
                {
                    PlayerData.S.Ice4BaoZhaWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.Ice4BaoZhaWeaponLevel];
                    PlayerData.S.Ice4BaoZhaWeaponLevel++;
                }
                break;
            case WeaponType.JianQi:
                PlayerData.S.jianQiWeaponExp += Exp; 
                if (PlayerData.S.jianQiWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.jianQiWeaponLevel])
                {
                    PlayerData.S.jianQiWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.jianQiWeaponLevel];
                    PlayerData.S.jianQiWeaponLevel++;
                }
                break;
            case WeaponType.HuoDiPen:
                PlayerData.S.HuoDiPenWeaponExp += Exp; 
                if (PlayerData.S.HuoDiPenWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.HuoDiPenWeaponLevel])
                {
                    PlayerData.S.HuoDiPenWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.HuoDiPenWeaponLevel];
                    PlayerData.S.HuoDiPenWeaponLevel++;
                }
                break;
            case WeaponType.IcePen:
                PlayerData.S.IcePenWeaponExp += Exp;
                if (PlayerData.S.IcePenWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.IcePenWeaponLevel])
                {
                    PlayerData.S.IcePenWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.IcePenWeaponLevel];
                    PlayerData.S.IcePenWeaponLevel++;
                }
                break;
            case WeaponType.HeiDong:
                PlayerData.S.heiDongWeaponExp += Exp; 
                if (PlayerData.S.heiDongWeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.heiDongWeaponLevel])
                {
                    PlayerData.S.heiDongWeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.heiDongWeaponLevel];
                    PlayerData.S.heiDongWeaponLevel++;
                }
                break;
            case WeaponType.DianLuoLei5:
                PlayerData.S.DianLuoLei5WeaponExp += Exp;
                if (PlayerData.S.DianLuoLei5WeaponExp > GlobalPlayerAttribute.ExpDic[PlayerData.S.DianLuoLei5WeaponLevel])
                {
                    PlayerData.S.DianLuoLei5WeaponExp -= GlobalPlayerAttribute.ExpDic[PlayerData.S.DianLuoLei5WeaponLevel];
                    PlayerData.S.DianLuoLei5WeaponLevel++;
                }
                break;
        }
    }
    IEnumerator DelayChuanSongMen()
    {
        yield return new WaitForSeconds(1f);
        var chuansongmen = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChuanSongMen"));
        chuansongmen.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    /// <summary>
    /// 死亡通用
    /// </summary>
    public void GeneralDie()
    {
        GameController.S.KillMonsterCount++;
        if (LevelInfoConfig.CurrentGameLevelType == LevelType.Weapon ||
            LevelInfoConfig.CurrentGameLevelType == LevelType.ChongWu ||
            LevelInfoConfig.CurrentGameLevelType == LevelType.ChiBang ||
            LevelInfoConfig.CurrentGameLevelType == LevelType.LingHun)
        {
            if (GameController.S.KillMonsterCount > LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel])
            {
                QueueController.S.StartCoroutine(DelayChuanSongMen());
            }
        }
       
        //附加属性
        int replyHp = Mathf.RoundToInt(GameController.S.GameMaxHp * GlobalPlayerAttribute.KillReplyHpPercent/100f);
        GlobalPlayerAttribute.ReplyHp(replyHp);
        PlayerData.S.MonsterCount++;
        PlayerData.S.LinHun += Mathf.RoundToInt(BloodEnergy*(1.0f+GlobalPlayerAttribute.LinHun));

        AddWeaponEx();
        GlobalPlayerAttribute.BloodEnergy+=BloodEnergy;
        //胜利
        
        if(collider2D != null)
            collider2D.enabled = false;
        
        // 禁用移动
        if(rigidbody2D != null)
            rigidbody2D.velocity = Vector2.zero;
    }

    public abstract void Die();

    public static string FloatToSpriteString(float value)
    {
        long intPart = (long)Math.Abs(Math.Truncate(value));
        // 特判 0
        if (intPart == 0) return "<sprite=0>";

        string digits = intPart.ToString();
        var sb = new StringBuilder(digits.Length * 10);
        foreach (char c in digits)
        {
            if (c >= '0' && c <= '9')
            {
                int index = c - '0';
                sb.Append("<sprite=").Append(index).Append('>');
            }
        }
        return sb.ToString();
    }
    public void ShowHurtText(float damage,bool isCrit,YiChangState yiChangState=YiChangState.None)
    {
        MonsterHurtText monsterHpGameObject = QueueController.S.MonsterHurtTextQueue.Dequeue();
        monsterHpGameObject.yiChangState=yiChangState;
        switch (yiChangState)
        {
            case YiChangState.ZhuoShao:
                monsterHpGameObject.duText.text = "-" + FloatToSpriteString(damage);
                break;
        }

        monsterHpGameObject.isCrit=isCrit;
        if (isCrit)
        {
            monsterHpGameObject.critText.text = "-" + FloatToSpriteString(damage);
        }
        else
        {
            monsterHpGameObject.normalText.text = "-" + FloatToSpriteString(damage);
        }
        monsterHpGameObject.transform.position = transform.position;
        float offsetX=Random.Range(-0.3f,0.3f);
        float offsetY=Random.Range(-0.2f,0.2f);
        float bossOffsetY = 0;
        if (MonsterType == MonsterType.Boss)
        {
            bossOffsetY = 1;
        }
        monsterHpGameObject.transform.position = new Vector3(transform.position.x + 0.1f+offsetX,
            transform.position.y + 0.5f+offsetY+bossOffsetY, transform.position.z);
        monsterHpGameObject.gameObject.SetActive(true);
    }

    public int GetFinalDamage(float baseDamage,bool isCrit,DamageFrom damageFrom)
    {
        float finalDamage = baseDamage;
        var random = Random.Range(0.92f, 1.08f);
        finalDamage *= random;
        var monsterDenfense = Defense * (1 - GlobalPlayerAttribute.Penetrate/100f);
        finalDamage-=monsterDenfense;
        finalDamage=MathF.Max(0,finalDamage);
        if (isCrit)
        {
            finalDamage *= (2+GlobalPlayerAttribute.TotalCritDamage/100.0f);
        }

        if (MonsterType == MonsterType.Boss)
        {
            finalDamage *= (1 + GlobalPlayerAttribute.DamageAddForBoss/100f);
        }
        else
        {
            finalDamage *= (1 + GlobalPlayerAttribute.DamageAddForNormal/100f);
        }

        switch (damageFrom)
        {
            case DamageFrom.Normal:
                finalDamage*=(1);
                break;
            case DamageFrom.Skill1:
                finalDamage*=(1);
                break;
            case DamageFrom.Skill2:
                finalDamage*=(1);
                break;
            case DamageFrom.Skill3:
                finalDamage*=(1);
                break;
        }
        

        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.JianSuAddAttack))
        {
            if (JianSuTime > 0)
            {
                finalDamage*= (1.0f+SkillJiaDian.S.IceBei4*5/100.0f);
            }
        }

        return Mathf.RoundToInt(finalDamage);
    }
    
  
    public virtual void Hurt(float baseDamage,bool isCrit,DamageFrom damageFrom,YuanSuType yuansutype)
    {
        if (IsDead) return;
        if(MonsterState== State.Die) return;


        if (yuansutype == YuanSuType.Ice)
        {
            JianSuTime = SkillJiaDian.S.IceJianSuTime;
        }
        float finalDamage = GetFinalDamage(baseDamage,isCrit,damageFrom);
        finalDamage *= (1.0f+GlobalPlayerAttribute.FinalDamage);//最终伤害
        if (damageFrom == DamageFrom.Normal)
        {
            finalDamage *= (1.0f + GlobalPlayerAttribute.HunQiDamage);
        }

        finalDamage *= (1.0f + GlobalPlayerAttribute.AllDamage);
        GlobalPlayerAttribute.ReplyHp(GlobalPlayerAttribute.BloodSuck/100.0f * finalDamage);
        ShowHurtText(finalDamage, isCrit);
        var random=Random.Range(0, 100);
        if (random < 5 && GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.KillNormal)&&MonsterType==MonsterType.Normal)
        {
            finalDamage = 999999;
        }
        
        
        if (MonsterConfig.MonsterTypeDic[MonsterTypeByName] != MonsterType.Boss)
        {
            hpSlider.gameObject.SetActive(true);
            if (monsterSkeletonAnimation != null)
            {
                if (!IsSkill)
                {
                    monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.HitName, false);
                }
            }
            CurrentHp -= finalDamage;
            //设置血条
            hpSlider.maxValue = MaxHp;
            hpSlider.value = CurrentHp;            
            if (CurrentHp <= 0 && !IsDead)
            {
                IsDead = true;
                Die();
            }
        }
        else
        {
            CurrentHp -= finalDamage;
            hpSlider.maxValue = MaxHp;
            hpSlider.value = CurrentHp;
            if (CurrentHp <= 0 && !IsDead)
            {
                IsDead = true;
                Die();
            }
        }
    }

     /// <summary>
     /// 生成装备
     /// </summary>
    public void CreateEquip()
    {
        var monsterType = MonsterConfig.MonsterTypeDic[MonsterTypeByName];
        var info=MonsterConfig.MonsterInfoDic[
            new MonsterDiaoLuoType() { GameLevel = LevelInfoConfig.CurrentGameLevel, MonsterType = monsterType }];
        //根据MonsterEquip的概率随机生成装备
        var monsterEquipList=info.MonsterEquipList;
        foreach (MonsterEquip monsterEquip in monsterEquipList)
        {
            float random = Random.Range(0, 100f);
            if (random <= monsterEquip.Probability*(1.0f+GlobalPlayerAttribute.Forture))
            {
                //生成装备
                GameObject equip = GameController.S.GetEquip(monsterEquip);
                EquipBase equipbase=equip.GetComponent<EquipBase>();
                GameController.S.EquipBaseSet.Add(equipbase);
                equipbase.enabled = true;
                equip.gameObject.SetActive(true);
                //设置装备位置为怪物位置
                equip.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }

        if (info.orangeEquip)
        {
            float random = Random.Range(0, 100f);
            if (random <= 0.2f)
            {
                //生成装备
                GameObject equip = GameController.S.GetOrangeEquip(GameController.S.GetRandomOrangeEquip());
                EquipBase equipbase=equip.GetComponent<EquipBase>();
                GameController.S.EquipBaseSet.Add(equipbase);
                equipbase.enabled = true;
                equip.gameObject.SetActive(true);
                //设置装备位置为怪物位置
                equip.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }

    public void CreateProp()
    {
        var monsterType = MonsterConfig.MonsterTypeDic[MonsterTypeByName];
        var info=MonsterConfig.MonsterInfoDic[
            new MonsterDiaoLuoType() { GameLevel = LevelInfoConfig.CurrentGameLevel, MonsterType = monsterType }];
        foreach (MonsterProp prop in info.MonsterPropList)
        {
            float random = Random.Range(0, 100f);
            if (random <= prop.Probability*(1+GlobalPlayerAttribute.Forture))
            {
                
                //生成装备
                GameObject propObj = GameController.S.GetProp(prop.PropItem);
                GameController.S.PropBaseSet.Add(propObj.GetComponent<PropBase>());
                propObj.gameObject.SetActive(true);
                //设置装备位置为怪物位置
                propObj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }
}
