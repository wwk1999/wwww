using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using Mysql;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

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


public abstract class MonsterBase : MonoBehaviour
{
    [NonSerialized]public MonsterType MonsterType;//怪物类型
    [NonSerialized]public string MonsterName;//怪物名称
    [NonSerialized]public int MonsterLevel;//怪物等级
    [NonSerialized]public int CurrentHp;//当前血量
    [NonSerialized]public  int MaxHp;//最大血量
    [NonSerialized]public float Speed;//速度
    [NonSerialized]public int Attack;//攻击力
    [NonSerialized]public int Defense;//防御力
    [NonSerialized]public int Exp;//经验值
    [NonSerialized]public int BloodEnergy;//血能
    [NonSerialized]public int EvolutionEnergy;//源能
    [NonSerialized]public bool IsDead=false;//是否死亡
    [NonSerialized]public bool IsAttack=false;//是否攻击
    [NonSerialized]public State MonsterState = State.None;
    [NonSerialized]public bool IsSkill=false;//是否在放技能
    [NonReorderable] public float size;//怪物大小
    public SkeletonAnimation monsterSkeletonAnimation;
    //public SpriteRenderer monsterSpriteRenderer;
    //public Animator monsterAnimator;
    public Slider hpSlider;
    [NonSerialized]public List<MonsterEquip> MonsterEquipList=new List<MonsterEquip>() ;//怪物装备列表
    [NonSerialized]public List<MonsterWeaponSource> MonsterWeaponSourceStoneList=new List<MonsterWeaponSource>() ;//怪物源石列表

    //经验相关
    [NonSerialized]public Text playerLevelText;

    
    public SpriteRenderer monsterSprite;
    public Animator monsterAnimator;

    [NonSerialized]public bool isMove = true;
    [NonSerialized]public bool isHit = false;
    [NonSerialized] public bool isAttack = false;
    [NonSerialized]public bool isSkill1 = false;
    [NonSerialized]public bool isSkill2 = false;

    [NonSerialized]public bool isBeatback = true;

    public Collider2D collider2D;
    public Rigidbody2D rigidbody2D;

    private SkeletonData skeletonData = null;


    //构造方法
    public MonsterBase(MonsterType monsterType, string monsterName, int monsterLevel, int maxHp, float speed, int attack, int defense, int exp, int bloodEnergy, int evolutionEnergy)
    {
        MonsterType = monsterType;
        MonsterName = monsterName;
        MonsterLevel = monsterLevel;
        MaxHp = maxHp;
        Speed = speed;
        Attack = attack;
        Defense = defense;
        Exp = exp;
        BloodEnergy = bloodEnergy;
        EvolutionEnergy = evolutionEnergy;
    }

    public abstract void AddMonsterEquip();
    public abstract void AddMonsterSourceStone();
    
    public void Awake()
    {
        skeletonData = monsterSkeletonAnimation.SkeletonDataAsset.GetSkeletonData(false);
        ObserverModuleManager.S.RegisterEvent(ConstKeys.Resumemonster,Resumemonster);
        Spine.Animation walkAnimation = skeletonData.FindAnimation("walk");
        if (walkAnimation != null)
        {
            monsterSkeletonAnimation.AnimationState.Complete += OnAnimationComplete;
        }
        else
        {
            monsterSkeletonAnimation.AnimationState.Complete += OnAnimationComplete1;
        }
        
        CurrentHp = MaxHp;
        if (MonsterType != MonsterType.Boss)
        {
            hpSlider.gameObject.SetActive(false);
        }
    }

    public void Start()
    {
        if (monsterSkeletonAnimation != null)
        {
            Spine.Animation walkAnimation = skeletonData.FindAnimation("walk");
            if (walkAnimation != null)
            {
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
            }
            else
            {
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "move", false);
            }
        }
        else
        {
            monsterAnimator.Play("move");
        }
    }

    private float hurtTime = 0.75f;
    private float currentHurtTime = 0;

    public void Update()
    {
        currentHurtTime += Time.deltaTime;
        float dis= Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        if (dis < GameController.S.gamePlayer.size + size&&currentHurtTime>hurtTime)
        {
            currentHurtTime = 0;
            GameController.S.gamePlayer.PlayerHurt(Attack,MonsterType==MonsterType.Boss);
        }

        if (dis < 5f)
        {
             if(transform.position.y < GameController.S.gamePlayer.transform.position.y-4)
                return;
            if(transform.position.y > GameController.S.gamePlayer.transform.position.y+4)
                return;
            GameController.S.monsterDetetor4.Add(this);
        }

        if (dis > 5f)
        {
            GameController.S.monsterDetetor4.Remove(this);
        }

        if (dis < 4f)
        {
            GameController.S.monsterDetetor3.Add(this);
            //如果_monsterDetetor3中存在monster，则移除
            if (GameController.S.monsterDetetor4.Contains(this))
            {
                GameController.S.monsterDetetor4.Remove(this);
            }
        }

        if (dis > 4f&&dis<5f)
        {
            GameController.S.monsterDetetor3.Remove(this);
            //如果_monsterDetetor4中不存在monster，则添加
            if (!GameController.S.monsterDetetor4.Contains(this))
            {
                GameController.S.monsterDetetor4.Add(this);
            }
        }

        if (dis < 3f)
        {
            GameController.S.monsterDetetor2.Add(this);
            //如果_monsterDetetor3中存在monster，则移除
            if (GameController.S.monsterDetetor3.Contains(this))
            {
                GameController.S.monsterDetetor3.Remove(this);
            }
        }

        if (dis > 3f && dis < 4f)
        {
            GameController.S.monsterDetetor2.Remove(this);
            //如果_monsterDetetor3中不存在monster，则添加
            if (!GameController.S.monsterDetetor3.Contains(this))
            {
                GameController.S.monsterDetetor3.Add(this);
            }
        }
        
        if (dis <2f)
        {
            GameController.S.monsterDetetor1.Add(this);
            //如果_monsterDetetor2中存在monster，则移除
            if (GameController.S.monsterDetetor2.Contains(this))
            {
                GameController.S.monsterDetetor2.Remove(this);
            }
        }

        if (dis > 2f && dis < 3f)
        {
            GameController.S.monsterDetetor1.Remove(this);
            //如果_monsterDetetor2中不存在monster，则添加
            if (!GameController.S.monsterDetetor2.Contains(this))
            {
                GameController.S.monsterDetetor2.Add(this);
            }
        }
    }

    public void Resumemonster(object[] args)
    {
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
        IsSkill = false;
        MonsterState= State.Move;
        CameraContraller.CameraStatus= CameraStatus.MoveToPlayer;
    }

    public abstract void Skill();


    public void OnAnimationComplete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "attack1")
        {
            MonsterState = State.Move;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "move", true);
        }
        //如果动画播放完毕
        if (trackEntry.Animation.Name == "hit"||trackEntry.Animation.Name == "attack"||trackEntry.Animation.Name == "skill"||trackEntry.Animation.Name == "skill_01"||trackEntry.Animation.Name == "skill_02"||trackEntry.Animation.Name == "skill_03")
        {
            //monsterAnimator.SetBool("isHurt", false);
            MonsterState = State.Move;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
        }
        if (trackEntry.Animation.Name == "Exit")
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
            MonsterState= State.Move;
            FightBGController.S.TreeManBoss.IsSkill = false;
            CameraContraller.CameraStatus= CameraStatus.MoveToPlayer;
        }
    }
    
    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "fail")
        {
            Destroy(gameObject);
            return;
        }
        if (isSkill2)
        {
            isSkill2 = false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill2", false);
        }
        else if (isSkill1)
        {
            isSkill1 = false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill1", false);
            if (this is ShaMoElite)
            {
                ShaMoElite shaMoElite=this as ShaMoElite;
                shaMoElite.CheckSkill();
            }
        }
        else if(isAttack)
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "attack1", false);
        }
        else
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "move", false);
        }
    }
    
    void DelayDestroy()
    {
         //第一关怪物死亡
           if (this is SnotMonster snotMonster)
            {
                gameObject.SetActive(false);
                GameController.S.SnotMonsterQueue.Enqueue(snotMonster);
            }
            else if (this is BatMonster batMonster)
            {
                gameObject.SetActive(false);
                GameController.S.BatMonsterQueue.Enqueue(batMonster);
            }
            else if (this is SpiderMonster spiderMonster)
            {
                gameObject.SetActive(false);
                GameController.S.SpiderMonsterQueue.Enqueue(spiderMonster);
            }
            else if (this is EliteBeeMonster eliteBeeMonster)
            {
                gameObject.SetActive(false);
                GameController.S.EliteBeeMonsterQueue.Enqueue(eliteBeeMonster);
            }
            // 第二关怪物死亡
            else if (this is ChongZiMonster chongZiMonster)
            {
                gameObject.SetActive(false);
                GameController.S.ChongZiMonsterQueue.Enqueue(chongZiMonster);
            }
            else if (this is XiaoHuoMonster xiaoHuoMonster)
            {
                gameObject.SetActive(false);
                GameController.S.XiaoHuoMonsterQueue.Enqueue(xiaoHuoMonster);
            }
            else if (this is DunDiMonster dunDiMonster)
            {
                gameObject.SetActive(false);
                GameController.S.DunDiMonsterQueue.Enqueue(dunDiMonster);
            }
            else if (this is EliteDaZuiMonster eliteDaZuiMonster)
            {
                gameObject.SetActive(false);
                GameController.S.EliteDaZuiMonsterQueue.Enqueue(eliteDaZuiMonster);
            }
            else if (this is XiNiuMonster xiNiuMonster)
            {
                gameObject.SetActive(false);
                GameController.S.XiNiuMonsterQueue.Enqueue(xiNiuMonster);
            }
            // 第三关怪物死亡
            else if (this is WenZiMonster wenZiMonster)
            {
                gameObject.SetActive(false);
                GameController.S.WenZiMonsterQueue.Enqueue(wenZiMonster);
            }
            else if (this is QingWaMonster qingWaMonster)
            {
                gameObject.SetActive(false);
                GameController.S.QingWaMonsterQueue.Enqueue(qingWaMonster);
            }
            else if (this is JiaChongMonster jiaChongMonster)
            {
                gameObject.SetActive(false);
                GameController.S.JiaChongMonsterQueue.Enqueue(jiaChongMonster);
            }
            else if (this is ShiRenHuaMonster shiRenHuaMonster)
            {
                gameObject.SetActive(false);
                GameController.S.ShiRenHuaMonsterQueue.Enqueue(shiRenHuaMonster);
            }
            // 第四关怪物死亡
            else if (this is KuLou kuLou)
            {
                gameObject.SetActive(false);
                GameController.S.KuLouQueue.Enqueue(kuLou);
            }
            else if (this is Huangzhu huangzhu)
            {
                gameObject.SetActive(false);
                GameController.S.HuangZhuQueue.Enqueue(huangzhu);
            }
            else if (this is HuangShu huangShu)
            {
                gameObject.SetActive(false);
                GameController.S.HuangShuQueue.Enqueue(huangShu);
            }
    }

    public void MonsterMove()
    {
        float dis= Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        if (dis < GameController.S.gamePlayer.size + size)
        {
            if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name != "attack")
            {
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "attack", true);
            }
            return;
        }
        //朝着主角以speed的速度前进
        Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
        //刚体移动
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0) == null)
        {
            GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed; 
        }
        else if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name != "Exit" && !IsSkill)
        {
            GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed; 
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
        float dis=Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position);
        if(dis<0.2f)
        {
            //如果距离小于0.2f，则不翻转
            return;
        }
        //翻转精灵
        if (isRight)
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
            {
                monsterSkeletonAnimation.skeleton.FlipX = false;
            }
            else
            {
                monsterSkeletonAnimation.skeleton.FlipX = true;
            }
        }else
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
            {
                monsterSkeletonAnimation.skeleton.FlipX = true;
            }
            else
            {
                monsterSkeletonAnimation.skeleton.FlipX = false;
            }
        }
        
    }
    
    public void SpriteFlipX1(bool isRight)
    {
        float dis=Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position);
        if(dis<0.2f)
        {
            //如果距离小于0.2f，则不翻转
            return;
        }
        //翻转精灵
        if (isRight)
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
            {
                monsterSprite.flipX = false;
            }
            else
            {
                monsterSprite.flipX = true;
            }
        }else
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
            {
                monsterSprite.flipX = true;
            }
            else
            {
                monsterSprite.flipX = false;
            }
        }
        
    }

    /// <summary>
    /// 获得经验
    /// </summary>
    public void GetEx()
    {
        GlobalPlayerAttribute.Exp+= Exp;
    }

    // /// <summary>
    // /// 获得BOSS能量
    // /// </summary>
    // public void GetBossEnergy()
    // {
    //     switch (MonsterType)
    //     {
    //         case MonsterType.Normal:
    //             GameController.S.BossEnergy+= 1;
    //             break;
    //         case MonsterType.Elite:
    //             GameController.S.BossEnergy+= 10;
    //             break;
    //     }
    // }

    /// <summary>
    /// 生成血能
    /// </summary>
    public void CreateBloodEnergy()
    {
        //生成血能
        GameObject bloodEnergy = GameController.S.BloodEnergyQueue.Dequeue();
        bloodEnergy.SetActive(true);
        //设置血能位置为怪物位置
        bloodEnergy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }


    /// <summary>
    /// 死亡通用
    /// </summary>
    public void GeneralDie()
    {
        
        //附加属性
        int replyHp = Mathf.RoundToInt(GlobalPlayerAttribute.TotalMaxHp * GlobalPlayerAttribute.KillReplyHpPercent);  
        GlobalPlayerAttribute.CurrentHp+= replyHp;
        GlobalPlayerAttribute.CurrentHp=Math.Min(GlobalPlayerAttribute.CurrentHp,GlobalPlayerAttribute.TotalMaxHp);
        
        
        //怪物数量排行榜
        switch (MonsterType)
        {
            case MonsterType.Normal:
                GameController.S.NormalCount++;
                break;
            case MonsterType.Elite:
                GameController.S.EliteCount++;
                break;
            case MonsterType.Boss:
                GameController.S.BossCount++;
                break;
        }

        GameController.S.KillMonsterCount++;
        switch (LevelInfoConfig.CurrentGameLevelType)
        {
            case LevelType.Elite:
                if (GameController.S.KillMonsterCount >= LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel] + LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel] / 10)
                {
                    FightBGController.S.PlaySuccessAnim();
                }
                break;
            case LevelType.Normal:
                if (GameController.S.KillMonsterCount >= LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel])
                {
                    FightBGController.S.PlaySuccessAnim();
                }
                break;
        }

        if (monsterSkeletonAnimation != null)
        {
             if (monsterSkeletonAnimation.timeScale == 0)
             {
                 monsterSkeletonAnimation.timeScale = 1;
            }
        }
       
        if (monsterSkeletonAnimation != null)
        {
            Spine.Animation walkAnimation = skeletonData.FindAnimation("fail");
            if (walkAnimation != null)
            {
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "fail", true);
                Invoke(nameof(DelayDestroy), 1f); // ← 几乎不分配内存
            }
            else
            {
                if (this is TreeManBoss)
                {
                    monsterSkeletonAnimation.AnimationState.SetAnimation(0, "die_02", false);
                }
                else
                {
                    monsterSkeletonAnimation.AnimationState.SetAnimation(0, "die", false);
                    Invoke(nameof(DelayDestroy), 1f); // ← 几乎不分配内存
                }
            }
        }
        else
        {
            isMove=false;
            monsterAnimator.Play("fail");
            Invoke(nameof(DelayDestroy), 1f); // ← 几乎不分配内存
        }

        // 从所有探测器列表中移除自己
        // 立即从所有探测器列表中移除自己
        if (GameController.S != null)
        {
            GameController.S.monsterDetetor1.Remove(this);
            GameController.S.monsterDetetor2.Remove(this);
            GameController.S.monsterDetetor3.Remove(this);
            GameController.S.monsterDetetor4.Remove(this);
        }
        // 禁用碰撞器，防止继续触发碰撞
        if(collider2D != null)
            collider2D.enabled = false;
        
        // 禁用移动
        if(rigidbody2D != null)
            rigidbody2D.velocity = Vector2.zero;
    }

    public abstract void Die();
  
    public virtual void Hurt(int damage)
    {
        if (IsDead) return;
        if (MonsterType != MonsterType.Boss)
        {
            if (hpSlider.gameObject.activeSelf == false)
            {
                hpSlider.gameObject.SetActive(true);
            }
            MonsterHurtText monsterHpGameObject = GameController.S.MonsterHurtTextQueue.Dequeue();
            monsterHpGameObject.gameObject.SetActive(true);
            monsterHpGameObject.transform.position = transform.position;
            //在monsterHpGameObject子类中查找Canvas的紫累HPText
            Text monsterHpText = monsterHpGameObject.text;
            //设置monsterHpText的text为-damage
            monsterHpText.text = "-" + damage.ToString();
            //设置monsterHpGameObject的position为怪物位置
            monsterHpGameObject.transform.position = new Vector3(transform.position.x + 0.1f,
                transform.position.y + 0.2f, transform.position.z);
            //设置monsterAnimator的ishuru为true
            // monsterAnimator.SetBool("isHurt", true);
            //重新播放Hurt动画
            //monsterAnimator.Play("SnotMonsterHit");
            if (monsterSkeletonAnimation != null)
            { 
                Spine.Animation walkAnimation = skeletonData.FindAnimation("hit");
                if (walkAnimation != null)
                {
                    monsterSkeletonAnimation.AnimationState.SetAnimation(0, "hit", false);
                }
                else
                {
                    
                    monsterSkeletonAnimation.AnimationState.SetAnimation(0, "beatback", false);
                }
            }
            else
            {
                isHit = true;
                monsterAnimator.Play("beatback");
            }
            CurrentHp -= damage;
            //设置血条
            hpSlider.value = (float)CurrentHp / MaxHp;
            if (CurrentHp <= 0 && !IsDead)
            {
                IsDead = true;
                Die();
            }
        }
        else
        {
            if(MonsterState== State.Die) return;
            if (MonsterState == State.Move)
            {
                Spine.Animation walkAnimation = skeletonData.FindAnimation("hit");
                if (walkAnimation != null)
                {
                    monsterSkeletonAnimation.AnimationState.SetAnimation(0, "hit", false);
                }
                else
                {
                    if (isBeatback)
                    {
                        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "beatback", false);
                    }
                    else
                    {
                        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "injured", false);
                    }
                }                
                CurrentHp -= damage;
                hpSlider.value = (float)CurrentHp / MaxHp;
                if (CurrentHp <= 0 && !IsDead)
                {
                    IsDead = true;
                    Die();
                }
            }else if (MonsterState == State.Skill1 || MonsterState == State.Skill2 || MonsterState == State.Skill3)
            {
                CurrentHp -= damage;
                hpSlider.value = (float)CurrentHp / MaxHp;
                if (CurrentHp <= 0 && !IsDead)
                {
                    IsDead = true;
                    Die();
                }
            }
        }
    }

     /// <summary>
     /// 生成装备
     /// </summary>
    public void CreateEquip()
    {
        //根据MonsterEquip的概率随机生成装备
        foreach (MonsterEquip monsterEquip in MonsterEquipList)
        {
            int random = UnityEngine.Random.Range(0, 100);
            if (random <= monsterEquip.Probability)
            {
                //生成装备
                GameObject equip = GameController.S.GetEquip(monsterEquip);
                equip.gameObject.SetActive(true);
                //设置装备位置为怪物位置
                equip.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }
     
     
    public void CreateWeaponSourceStone()
    {
        //根据MonsterEquip的概率随机生成装备
        foreach (MonsterWeaponSource monsterWeaponSource in MonsterWeaponSourceStoneList)
        {
            int random = UnityEngine.Random.Range(0, 100);
            if (random <= monsterWeaponSource.Probability)
            {
                //生成装备
                Debug.Log("生成源石");
                GameObject sourcestone;
                switch (monsterWeaponSource.SourceStoneType)
                {
                    case WeaponSourceStoneType.Penetrate:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponPenetrate"));
                        break;
                    case WeaponSourceStoneType.Division:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponDivision"));
                        break;
                    case WeaponSourceStoneType.Explosion:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponExplosion"));
                        break;
                    case WeaponSourceStoneType.ExtremeSpeed:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponExtremeSpeed"));
                        break;
                    case WeaponSourceStoneType.Scale:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponScale"));
                        break;
                    case WeaponSourceStoneType.Duration:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponDuration"));
                        break;
                    default:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponExtremeSpeed"));
                        break;
                }
                //设置装备位置为怪物位置
                sourcestone.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }
}
