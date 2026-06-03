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
    NormalAttack,
    Skill,
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
    [NonSerialized] public float zhuoShaoCurrentTime = 0;//灼烧间隔时间
    [NonSerialized] public float CurrentZhuoShaoCeng = 0;

    
    
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
    [NonSerialized]public bool isSkill4 = false;


    [NonSerialized]public bool isBeatback = true;

    public Collider2D collider2D;
    public Rigidbody2D rigidbody2D;

    
    [NonSerialized]public bool isJianSu=false;
    [NonSerialized]public float JianSuTime=0;

    public void ShotDanMu(Vector2 trans, Sprite sprite, float attack, Vector3 dir, bool isBoss,float scale=1)
    {
        DanMu danmu = QueueController.S.DanMuQueue.Dequeue();
        danmu.SetDanMu(sprite, attack, dir, isBoss);
        danmu.transform.position = trans;
        danmu.transform.localScale = new Vector3(danmu.transform.localScale.x*scale, danmu.transform.localScale.y*scale, danmu.transform.localScale.z*scale);
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
        NormalYuanChenCurrentTime+=Time.deltaTime;
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
            CurrentZhuoShaoCeng = 0;
            zhuoshao.gameObject.SetActive(false);
        }

        if (zhuoShaoCurrentTime >= GlobalPlayerAttribute.HuoDamageJianGe)
        {
            zhuoShaoCurrentTime = 0;
            ShowHurtText(Mathf.RoundToInt(GlobalPlayerAttribute.HuoZhuoShaoDamage*CurrentZhuoShaoCeng), false,YiChangState.ZhuoShao);
            CurrentHp -= GlobalPlayerAttribute.HuoZhuoShaoDamage*CurrentZhuoShaoCeng;
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
        IsDead = true;
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
        int replyHp = Mathf.RoundToInt(QueueController.S.GameMaxHp * GlobalPlayerAttribute.KillReplyHpPercent/100f);
        GlobalPlayerAttribute.ReplyHp(replyHp);
        PlayerData.S.MonsterCount++;
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AddSoul))
        {
            GlobalPlayerAttribute.BloodEnergy += Mathf.RoundToInt(BloodEnergy*(1.0f+GlobalPlayerAttribute.LinHun)*1.25f);
            PlayerData.S.AllLingHun += Mathf.RoundToInt(BloodEnergy*(1.0f+GlobalPlayerAttribute.LinHun)*1.25f);
        }
        else
        {
            GlobalPlayerAttribute.BloodEnergy += Mathf.RoundToInt(BloodEnergy*(1.0f+GlobalPlayerAttribute.LinHun));
            PlayerData.S.AllLingHun += Mathf.RoundToInt(BloodEnergy*(1.0f+GlobalPlayerAttribute.LinHun));
        }
        
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

        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.JianSuAddAttack))
        {
            if (JianSuTime > 0)
            {
                finalDamage*= (1.0f+SkillJiaDian.S.IceBei4*5/100.0f);
            }
        }

        return Mathf.RoundToInt(finalDamage);
    }

    public float SetYuanSuSkillDamage(float damage,YuanSuType yuansutype)
    {
        switch (yuansutype)
        {
            case YuanSuType.Ice:
                damage*=((SkillJiaDian.S.IceBei2 + SkillJiaDian.S.IceBei4) * 5 / 100+1f);
                break;
        }
        return damage;
    }

    public float SetOrangeEntry(float finalDamage, DamageFrom damageFrom,YuanSuType yuanSuType)
    {
        switch (yuanSuType)
        {
            case YuanSuType.Dian:
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DianDamageAdd))
                {
                    finalDamage *= (1.15f);
                }
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DianSkillDamageAdd)&&damageFrom==DamageFrom.Skill)
                {
                    finalDamage *= (1.25f);
                }
                
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DianWeapponDamageAdd)&&damageFrom==DamageFrom.NormalAttack)
                {
                    finalDamage *= (1.25f);
                }
                break;
            
            case YuanSuType.Ice:
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.IceDamageAdd))
                {
                    finalDamage *= (1.15f);
                }
                
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.IceSkillDamageAdd)&&damageFrom==DamageFrom.Skill)
                {
                    finalDamage *= (1.25f);
                }
                
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.IceWeapponDamageAdd)&&damageFrom==DamageFrom.NormalAttack)
                {
                    finalDamage *= (1.25f);
                }
                break;
            
            case YuanSuType.Huo:
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HuoDamageAdd))
                {
                    finalDamage *= (1.15f);
                }
                
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HuoSkillDamageAdd)&&damageFrom==DamageFrom.Skill)
                {
                    finalDamage *= (1.25f);
                }
                
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HuoWeapponDamageAdd)&&damageFrom==DamageFrom.NormalAttack)
                {
                    finalDamage *= (1.25f);
                }
                break;
            
            case YuanSuType.HeiAn:
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HeiAnDamageAdd))
                {
                    finalDamage *= (1.15f);
                }
                
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HeiAnSkillDamageAdd)&&damageFrom==DamageFrom.Skill)
                {
                    finalDamage *= (1.25f);
                }
                
                if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HeiAnWeapponDamageAdd)&&damageFrom==DamageFrom.NormalAttack)
                {
                    finalDamage *= (1.25f);
                }
                break;
        }
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.NoSkill))
        {
            finalDamage *= 2;
        }
        
        
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AddWeaponReduceSkill))
        {
            switch (damageFrom)
            {
                case DamageFrom.NormalAttack:
                    finalDamage *= 1.5f;
                    break;
                case DamageFrom.Skill:
                    finalDamage *= 0.7f;
                    break;
            }
        }
        
        
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AddSkillReduceWeapon))
        {
            switch (damageFrom)
            {
                case DamageFrom.Skill:
                    finalDamage *= 1.5f;
                    break;
                case DamageFrom.NormalAttack:
                    finalDamage *= 0.7f;
                    break;
            }
        }
        
        return  finalDamage;
    }
  
    public virtual void Hurt(float baseDamage,bool isCrit,DamageFrom damageFrom,YuanSuType yuansutype)
    {
        if (IsDead) return;
        if(MonsterState== State.Die) return;

        switch (yuansutype)
        {
            case YuanSuType.Ice:
                JianSuTime = GlobalPlayerAttribute.JianSuTime;
                break;
            case YuanSuType.Huo:
                CurrentZhuoShaoCeng += 1;
                CurrentZhuoShaoCeng=MathF.Min(CurrentZhuoShaoCeng,GlobalPlayerAttribute.HuoMaxCengShu);
                break;
        }
        
        float finalDamage = GetFinalDamage(baseDamage,isCrit,damageFrom);
        finalDamage *= (1.0f+GlobalPlayerAttribute.FinalDamage);//最终伤害
        finalDamage=SetOrangeEntry(finalDamage,damageFrom,yuansutype);
        finalDamage *= (1.0f + GlobalPlayerAttribute.AllDamage);
        finalDamage=SetYuanSuSkillDamage(finalDamage,yuansutype);
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
                QueueController.S.EquipBaseSet.Add(equipbase);
                equipbase.enabled = true;
                equip.gameObject.SetActive(true);
                //设置装备位置为怪物位置
                equip.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }

        if (info.orangeEquip)
        {
            float random = Random.Range(0, 100f);
            if (random <= 100f*(1.0f+GlobalPlayerAttribute.Forture))
            {
                //生成装备
                EquipBase equip = QueueController.S.OrangeEquipQueue.Dequeue();
                QueueController.S.EquipBaseSet.Add(equip);
                equip.enabled = true;
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
                QueueController.S.PropBaseSet.Add(propObj.GetComponent<PropBase>());
                propObj.gameObject.SetActive(true);
                //设置装备位置为怪物位置
                propObj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }
}
