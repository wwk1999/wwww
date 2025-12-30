using System;
using System.Collections;
using System.Collections.Generic;
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
}

public class MonsterSpineName
{
    public string MoveName;
    public string HitName;
    public string DieName;
    public string AttackName;
    public string Skill1Name;
    public string Skill2Name;
    public string Skill3Name;
    public string AppearName;
}
public abstract class MonsterBase : MonoBehaviour
{
    public GameObject du;
    public GameObject jiansu;
    [NonSerialized] public float duTime = 0;
    [NonSerialized] public float duDamage = 0;
    [NonSerialized] public float jiansuTime = 0;
    [NonSerialized] public float duCurrentTime = 0;

    
    
    public Canvas  hpSliderCanvas;
    public MeshRenderer  meshRenderer;
    [NonSerialized] public float YiDianTime = 0;
    [NonSerialized] public float JianSuTime = 0;
    [NonSerialized] public MonsterSpineName MonsterSpineName=new MonsterSpineName();
    public GameObject parent;

    
    
    [NonSerialized]public MonsterType MonsterType;//怪物类型
    [NonSerialized]public string MonsterName;//怪物名称
    [NonSerialized]public int MonsterLevel;//怪物等级
    [NonSerialized]public float CurrentHp;//当前血量
    [NonSerialized]public  float MaxHp;//最大血量
    [NonSerialized]public float Speed;//速度
    [NonSerialized]public int Attack;//攻击力
    [NonSerialized]public int Defense;//防御力
    [NonSerialized]public int Exp;//经验值
    [NonSerialized]public int BloodEnergy;//血能
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
    [NonSerialized]public List<MonsterEquip> MonsterEquipList=new List<MonsterEquip>() ;//怪物装备列表
    [NonSerialized]public List<MonsterOrangeEntryEquip> MonsterOrangeEntryEquip=new List<MonsterOrangeEntryEquip>() ;//怪物装备列表
    [NonSerialized]public List<MonsterProp> MonsterPropList=new List<MonsterProp>() ;//怪物源石列表


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
    public abstract void AddMonsterProp();
    
    public void Awake()
    {
        CurrentHp = MaxHp;
        if (MonsterType != MonsterType.Boss)
        {
            hpSlider.gameObject.SetActive(false);
        }
    }

    public void Start()
    {
        if (MonsterType != MonsterType.Boss)
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

    private float hurtTime = 0.75f;
    private float currentHurtTime = 0;

    private void OnEnable()
    {
        duCurrentTime = 0;
    }

    public void Update()
    {
        if (duTime > 0)
        {
            duTime -= Time.deltaTime;
            duCurrentTime+=Time.deltaTime;
            du.gameObject.SetActive(true);
        }
        else
        {
            du.gameObject.SetActive(false);
        }

        if (duCurrentTime >= 1)
        {
            duCurrentTime = 0;
            ShowHurtText(Mathf.RoundToInt(duDamage), false,YiChangState.Du);
            CurrentHp -= duDamage;
            //设置血条
            hpSlider.value = CurrentHp;
            hpSlider.maxValue = MaxHp;
            if (CurrentHp <= 0 && !IsDead)
            {
                IsDead = true;
                Die();
            }
        }
        if (jiansuTime > 0)
        {
            jiansuTime -= Time.deltaTime;
            jiansu.gameObject.SetActive(true);
        }
        else
        {
            jiansu.gameObject.SetActive(false);
        }
        
        if (YiDianTime > 0)
        {
            YiDianTime -= Time.deltaTime;
        }
        
        if (JianSuTime > 0)
        {
            JianSuTime -= Time.deltaTime;
            Speed *= (1 - GlobalPlayerAttribute.Skill3JianSuNum / 100.0f);
        }
        currentHurtTime += Time.deltaTime;
        float dis= Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);

        if (dis < 5f)
        {
             if(transform.position.y < GameController.S.gamePlayer.transform.position.y-4)
                return;
            if(transform.position.y > GameController.S.gamePlayer.transform.position.y+4)
                return;
        }
    }
    

    public abstract void Skill();

    IEnumerator DelayXieZi()
    {
        yield return new WaitForSeconds(2f);
        transform.position=GameController.S.gamePlayer.transform.position;
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill3", false);
    }
    
    
    public void OnAnimationComplete(TrackEntry trackEntry)
    {
        if (this is EliteDaZuiMonster)
        {
            return;
        }
        if (trackEntry.Animation.Name ==MonsterSpineName.DieName)
        {
            Destroy(gameObject);
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
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
        }
    }

    public void ExitYinShen()
    {
        var skeleton = monsterSkeletonAnimation.Skeleton;
        skeleton.SetSkin("skin_yinshen_qian");
        skeleton.SetupPoseSlots();
        collider2D.tag = "Monster";
    }
    
    void DelayDestroy()
    {
        gameObject.SetActive(false);
         //第一关怪物死亡
           if (this is SnotMonster snotMonster)
            {
                GameController.S.SnotMonsterQueue.Enqueue(snotMonster);
            }
            else if (this is BatMonster batMonster)
            {
                GameController.S.BatMonsterQueue.Enqueue(batMonster);
            }
            else if (this is SpiderMonster spiderMonster)
            {
                GameController.S.SpiderMonsterQueue.Enqueue(spiderMonster);
            }
            else if (this is EliteBeeMonster eliteBeeMonster)
            {
                GameController.S.EliteBeeMonsterQueue.Enqueue(eliteBeeMonster);
            }
            // 第二关怪物死亡
            else if (this is ChongZiMonster chongZiMonster)
            {
                GameController.S.ChongZiMonsterQueue.Enqueue(chongZiMonster);
            }
            else if (this is XiaoHuoMonster xiaoHuoMonster)
            {
                GameController.S.XiaoHuoMonsterQueue.Enqueue(xiaoHuoMonster);
            }
            else if (this is DunDiMonster dunDiMonster)
            {
                GameController.S.DunDiMonsterQueue.Enqueue(dunDiMonster);
            }
            else if (this is EliteDaZuiMonster eliteDaZuiMonster)
            {
                GameController.S.EliteDaZuiMonsterQueue.Enqueue(eliteDaZuiMonster);
            }
            else if (this is XiNiuMonster xiNiuMonster)
            {
                GameController.S.XiNiuMonsterQueue.Enqueue(xiNiuMonster);
            }
            else if (this is HuangShu huangshu)
            {
                GameController.S.HuangShuQueue.Enqueue(huangshu);
            } 
            // 第三关怪物死亡
            else if (this is WenZiMonster wenZiMonster)
            {
                GameController.S.WenZiMonsterQueue.Enqueue(wenZiMonster);
            }
            else if (this is QingWaMonster qingWaMonster)
            {
                GameController.S.QingWaMonsterQueue.Enqueue(qingWaMonster);
            }
            else if (this is JiaChongMonster jiaChongMonster)
            {
                GameController.S.JiaChongMonsterQueue.Enqueue(jiaChongMonster);
            }
            else if (this is ShiRenHuaMonster shiRenHuaMonster)
            {
                GameController.S.ShiRenHuaMonsterQueue.Enqueue(shiRenHuaMonster);
            }
            // 第四关怪物死亡
            else if (this is KuLou kuLou)
            {
                GameController.S.KuLouQueue.Enqueue(kuLou);
            }
            else if (this is Huangzhu huangzhu)
            {
                GameController.S.HuangZhuQueue.Enqueue(huangzhu);
            }
            else if (this is ShaChong shaChong)
            {
                GameController.S.ShaChongQueue.Enqueue(shaChong);
            } else if (this is ShaNiao shaniao)
            {
                GameController.S.ShaNiaoQueue.Enqueue(shaniao);
            } else if (this is XianRenZhang xianrenzhang)
            {
                GameController.S.XianRenZhangQueue.Enqueue(xianrenzhang);
            }  else if (this is ShaXiYi shaxiyi)
            {
                GameController.S.ShaXiYiQueue.Enqueue(shaxiyi);
            } 
    }

    public void MonsterMove()
    {
        Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == MonsterSpineName.MoveName||IsDash)
        {
            GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed; 
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = direction.normalized * 0; 
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
                parent.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                parent.transform.localScale = new Vector3(-1, 1, 1);
            }
        }else
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
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
        int replyHp = Mathf.RoundToInt(GameController.S.GameMaxHp * GlobalPlayerAttribute.KillReplyHpPercent/100f);
        GlobalPlayerAttribute.ReplyHp(replyHp);
        
        
        //怪物数量排行榜
        switch (MonsterType)
        {
            case MonsterType.Normal:
                GlobalPlayerAttribute.BloodEnergy++;
                GameController.S.NormalCount++;
                break;
            case MonsterType.Elite:
                GlobalPlayerAttribute.BloodEnergy+=10;

                GameController.S.EliteCount++;
                break;
            case MonsterType.Boss:
                GlobalPlayerAttribute.BloodEnergy+=100;
                GameController.S.BossCount++;
                break;
        }

        GameController.S.KillMonsterCount++;
        //胜利
        switch (LevelInfoConfig.CurrentGameLevelType)
        {
            case LevelType.Elite:
                if (GameController.S.KillMonsterCount >= LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel] + LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel] / 10)
                {
                    var chuansongmen = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChuanSongMen"));
                    chuansongmen.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    FightBGController.S.PlaySuccessAnim();
                }
                break;
            case LevelType.Normal:
                if (GameController.S.KillMonsterCount >= LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel])
                {
                    var chuansongmen = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChuanSongMen"));
                    chuansongmen.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    FightBGController.S.PlaySuccessAnim();
                }
                break;
        }
       
        if (monsterSkeletonAnimation != null)
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.DieName, false);
            Invoke(nameof(DelayDestroy), 1f); // ← 几乎不分配内存
        }
        if(collider2D != null)
            collider2D.enabled = false;
        
        // 禁用移动
        if(rigidbody2D != null)
            rigidbody2D.velocity = Vector2.zero;
    }

    public abstract void Die();

    public void ShowHurtText(float damage,bool isCrit,YiChangState yiChangState=YiChangState.None)
    {
        MonsterHurtText monsterHpGameObject = GameController.S.MonsterHurtTextQueue.Dequeue();
        monsterHpGameObject.yiChangState=yiChangState;
        switch (yiChangState)
        {
            case YiChangState.Du:
                monsterHpGameObject.duText.text = "-" + damage;
                break;
        }

        monsterHpGameObject.isCrit=isCrit;
        if (isCrit)
        {
            monsterHpGameObject.critText.text = "-" + damage;
        }
        else
        {
            monsterHpGameObject.normalText.text = "-" + damage;
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
        if (isCrit)
        {
            finalDamage *= (2+GlobalPlayerAttribute.TotalCritDamage);
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
                finalDamage*=(1+GlobalPlayerAttribute.NormalAttackNum/100.0f);
                break;
            case DamageFrom.Skill1:
                finalDamage*=(1+GlobalPlayerAttribute.Skill1DamageNum/100.0f);
                break;
            case DamageFrom.Skill2:
                finalDamage*=(1+GlobalPlayerAttribute.Skill2DamageNum/100.0f);
                break;
            case DamageFrom.Skill3:
                finalDamage*=(1+GlobalPlayerAttribute.Skill3DamageNum/100.0f);
                break;
        }
        if (damageFrom == DamageFrom.Skill1&&YiDianTime>0)
        {
            if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.Skill1YiDianDouble))
            {
                finalDamage*=(1+GlobalPlayerAttribute.Skill1YiDianNum/50.0f);
            }
            else
            {
                finalDamage*=(1+GlobalPlayerAttribute.Skill1YiDianNum/100.0f);
            }
        }

        return Mathf.RoundToInt(finalDamage);
    }

    public float NormalAddDamage(float finalDamage)
    {
        if (PlayerEquipConfig.CloakId != 0)
        {
            if (BagController.S.EquipIdList[PlayerEquipConfig.CloakId].Quality < 5)
            {
                finalDamage += 0.3f;
            }
        }
            
        if (PlayerEquipConfig.ClothId != 0)
        {
            if (BagController.S.EquipIdList[PlayerEquipConfig.ClothId].Quality < 5)
            {
                finalDamage += 0.3f;
            }
        }
            
        if (PlayerEquipConfig.NecklaceId != 0)
        {
            if (BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId].Quality < 5)
            {
                finalDamage += 0.3f;
            }
        }
            
        if (PlayerEquipConfig.RingId != 0)
        {
            if (BagController.S.EquipIdList[PlayerEquipConfig.RingId].Quality < 5)
            {
                finalDamage += 0.3f;
            }
        }
            
        if (PlayerEquipConfig.ShoeId != 0)
        {
            if (BagController.S.EquipIdList[PlayerEquipConfig.ShoeId].Quality < 5)
            {
                finalDamage += 0.3f;
            }
        }
            
        if (PlayerEquipConfig.HelmetId != 0)
        {
            if (BagController.S.EquipIdList[PlayerEquipConfig.HelmetId].Quality < 5)
            {
                finalDamage += 0.3f;
            }
        }

        return finalDamage;
    }

    public float OrangeEntryDamage(float damage)
    {
        float finalDamage = 0;//最终伤害
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.FinalDamageAddPercent))
        {
            finalDamage += 0.15f;
        }

        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.NormalAddDamage))
        {
            finalDamage=NormalAddDamage(finalDamage);
        }
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.Skill1ReplaceNormalAttack))
        {
            finalDamage+=1f;
        }
        finalDamage+=GlobalPlayerAttribute.PlayerChiBangAttribute.finalDamage;
        return damage*(1+finalDamage);
    }
    public virtual void Hurt(float baseDamage,bool isCrit,DamageFrom damageFrom)
    {
        if (IsDead) return;
        if(MonsterState== State.Die) return;
        if (damageFrom == DamageFrom.Skill1&&GlobalPlayerAttribute.Skill1YiDianNum>0)
        {
            YiDianTime = 3;
        }
        if (damageFrom == DamageFrom.Skill3&&GlobalPlayerAttribute.Skill3JianSuNum>0)
        {
            JianSuTime = 3;
        }
        float finalDamage = GetFinalDamage(baseDamage,isCrit,damageFrom);
        finalDamage = OrangeEntryDamage(finalDamage);//最终伤害
        GlobalPlayerAttribute.ReplyHp(GlobalPlayerAttribute.BloodSuck/100.0f * finalDamage);
        ShowHurtText(finalDamage, isCrit);
        var random=Random.Range(0, 100);
        if (random < 5 && GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.KillNormal)&&MonsterType==MonsterType.Normal)
        {
            finalDamage = 999999;
        }
        
        
        if (MonsterType != MonsterType.Boss)
        {
            if (hpSlider.gameObject.activeSelf == false)
            {
                hpSlider.gameObject.SetActive(true);
            }

            if (monsterSkeletonAnimation != null)
            {
                if (!IsSkill)
                {
                    monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.HitName, false);
                }
            }
            CurrentHp -= finalDamage;
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
        //根据MonsterEquip的概率随机生成装备
        foreach (MonsterEquip monsterEquip in MonsterEquipList)
        {
            float random = Random.Range(0, 100f);
            if (random <= monsterEquip.Probability*(1+GlobalPlayerAttribute.Forture))
            {
                //生成装备
                GameObject equip = GameController.S.GetEquip(monsterEquip);
                equip.gameObject.SetActive(true);
                //设置装备位置为怪物位置
                equip.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
        
        foreach (MonsterOrangeEntryEquip monsterEquip in MonsterOrangeEntryEquip)
        {
            float random = Random.Range(0, 100f);
            if (random <= monsterEquip.Probability * (1 + GlobalPlayerAttribute.Forture))
            {
                GameObject equip = GameController.S.GetOrangeEntryEquip(monsterEquip);

                var comp = equip.GetComponent<EquipBase>();   // 对应的具体脚本
                Debug.Log($"生成前：{equip.name}, activeSelf={equip.activeSelf}, enabled={(comp != null && comp.enabled)}");

                equip.SetActive(true);
                equip.transform.position = transform.position;

                Debug.Log($"生成后：{equip.name}, activeSelf={equip.activeSelf}, enabled={(comp != null && comp.enabled)}");
            }
        }
    }

    public void CreateProp()
    {
        foreach (MonsterProp prop in MonsterPropList)
        {
            float random = Random.Range(0, 100f);
            if (random <= prop.Probability*(1+GlobalPlayerAttribute.Forture))
            {
                //生成装备
                GameObject propObj = GameController.S.GetProp(prop.PropItem);
                propObj.gameObject.SetActive(true);
                //设置装备位置为怪物位置
                propObj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }
}
