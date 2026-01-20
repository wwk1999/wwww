using System.Collections;
using System.Collections.Generic;
using Config;
using Equip;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace Fight.Monster.秘境.雷兽
{
    public class LeiShouBoss:MonsterBase
    {
        public LeiShouBoss() : base(MonsterType.Boss, "LeiShouBoss", 1, MJConfig.BossMonsterAttribute.hp*MJConfig.MonsterAttributeDic[MJLevel.White].hp, 0.8f, MJConfig.BossMonsterAttribute.atk*MJConfig.MonsterAttributeDic[MJLevel.White].atk, MJConfig.BossMonsterAttribute.def*MJConfig.MonsterAttributeDic[MJLevel.White].def, MJConfig.BossMonsterAttribute.ex*MJConfig.PlayerAttributeDic[MJLevel.White].ex, MJConfig.BossMonsterAttribute.linhun*MJConfig.PlayerAttributeDic[MJLevel.White].linhun, 0)
        {
        }
    
        public Transform attackTrans;
        private float skill1Time = 13;
        private float skill2Time = 17;
        private float skill3Time = 16;
        private float currentSkill1Time = 10;
        private float currentSkill2Time = 6;
        private float currentSkill3Time = 7;

        public GameObject skill1;
        public SkeletonAnimation skill1ske;
        public Collider2D Skill1Collider2D;
        public GameObject skill1parent;
        
        
         public  void Awake()
    {
        MaxHp /= 10000;
        Attack /= 100;
        Defense/= 100;
        Exp/= 100;
        BloodEnergy/= 100;
        base.Awake();
        MonsterSpineName.AttackName = "attack1";
        MonsterSpineName.HitName = "injured";
        MonsterSpineName.MoveName = "move";
        MonsterSpineName.DieName = "fail";
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;
        skill1ske.AnimationState.Event += Skill1OnSpineEvent;
        skill1ske.AnimationState.Complete += Skill1Complete;
    }

    public void ShowSkill1()
    {
        skill1.SetActive(true);
        var dir=(GameController.S.gamePlayer.transform.position-transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        skill1parent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        skill1parent.transform.localScale=parent.transform.localScale;
        skill1ske.AnimationState.SetAnimation(0, "heihuo", false);
        skill1ske.timeScale = 2.2f;
    }

    public void Skill1Complete(TrackEntry trackEntry)
    {
        skill1.gameObject.SetActive(false);
    }

    IEnumerator Skill3(float delay,Vector2 spawnPos)
    {
         GameController.S.CreateCircleAttack(spawnPos,1f);
         yield return new WaitForSeconds(delay);
         LeiShouSkill3 huoyan=GameController.S.LeiShouSkill3Queue.Dequeue();
         huoyan.transform.position = spawnPos;
         huoyan.damage = Attack;
         huoyan.gameObject.SetActive(true);
    }
    
    private IEnumerator Skill3Coroutine(float delay,Vector2 pos, float dis, float time, int count)
    {
        yield return  new WaitForSeconds(delay);
        for (int i = 0; i < count; i++)
        {
            // 随机点：Random.insideUnitCircle 返回单位圆内随机点，乘以 dis 后移到指定半径范围
            Vector2 randomOffset = Random.insideUnitCircle * dis;
            Vector2 spawnPos = pos + randomOffset;
            StartCoroutine(Skill3(0.5f,spawnPos));
            if (time > 0f)
                yield return new WaitForSeconds(time);
            else
                yield return null;
        }
    }
    

    IEnumerator ShunYiNext()
    {
        yield return new WaitForSeconds(2f);
        var pos = GameController.S.gamePlayer.transform.position;
        GameController.S.CreateCircleAttack(pos,1);
        yield return new WaitForSeconds(0.5f);
        transform.position = pos;
        collider2D.tag = "Boss";
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill5", false);
    }
    
     public void Complete(TrackEntry trackEntry)
    {
        monsterSkeletonAnimation.timeScale = 1f;
        if (trackEntry.Animation.Name == "skill1"||trackEntry.Animation.Name == "skill2"||trackEntry.Animation.Name == "skill3"||trackEntry.Animation.Name == "skill4"||trackEntry.Animation.Name == "skill5")
        {
            IsSkill=false;
        }

        if (trackEntry.Animation.Name == "skill4")
        {
            collider2D.tag = "Bullet";
            StartCoroutine(ShunYiNext());
            return;
        }
        
        if (isSkill1)
        {
            IsSkill=true;
            isSkill1=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill1", false);
            monsterSkeletonAnimation.timeScale = 1.5f;
            Invoke(nameof(ShowSkill1),1.5f);
        }else if (isSkill2)
        {
            IsSkill=true;
            isSkill2=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill4", false);
            monsterSkeletonAnimation.timeScale = 1f;
        }
        else if(isSkill3)
        {
            IsSkill=true;
            isSkill3=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill3", false);
            monsterSkeletonAnimation.timeScale = 2f;
            StartCoroutine(Skill3Coroutine(1f,transform.position,8f,0.3f,25));
        }
        else if(isAttack)
        {
            monsterSkeletonAnimation.timeScale = 1.5f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
        }
        else
        {
            monsterSkeletonAnimation.timeScale = 1.5f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
        }
    }

    public override void AddMonsterEquip()
    {
       // 防御词条

    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.FinalDamageReductionFixed, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.FinalDamageReductionPercent, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.AllReplyAddPercent, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.AddHpForTime, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.AddDefenseForTime, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.ReplyDeath, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.DelayDamage, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.HpReductionReplyAdd50, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.HpReductionAddDefense, 3));
    
    
    // 攻击词条
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.FinalDamageAddPercent, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.KillNormal, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.AddAttackForTime, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.NormalAddDamage, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.RecudeHpAddAttack, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.JianSuAddAttack, 3));
    
    // 普通攻击
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.FanPuGuiZhen, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.NoSkill, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.BuWangChuXin, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.HeiDongAddSpeed, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.DuAddDuQuan, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.LvQuanAddScale, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.XuKongAdd2Dan, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.PuTong3ChuanTou, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.FireBaoZha, 3));
    
    // Skill1
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill1ReplaceNormalAttack, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill1YiDianDouble, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill1AddRange, 3));
    
    // Skill2
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill2AddDan, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill2RotateAdd, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill2AddRange, 3));
    
    // Skill3
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill3Bian3, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill3AddRange, 3));
    
    // Dash
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.DashCd, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.DashRange, 3));
    
    // 特殊词条
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.MoveSpeedAdd, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.ExAdd, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.ClothFortureAdd, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.ShoeFortureAdd, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.CloakFortureAdd, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.NecklaceFortureAdd, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.RingFortureAdd, 3));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.HelmetFortureAdd, 3));
    
    }

   public override void Hurt(float damage,bool isCrit,DamageFrom damageFrom)
    {
        base.Hurt(damage,isCrit,damageFrom);
        if (!IsDead)
        {
            AudioController.S.PlayBatHit();
        }
    }

    public override void Skill()
    {
        // Implement the skill logic here
    }

    public override void Die()
    {

        //生成随机数
        int randomDelay = UnityEngine.Random.Range(0, 10);
        StartCoroutine(RandomDelayDie(randomDelay));
    }

    private IEnumerator RandomDelayDie(int delay)
    {
        for (int i = 0; i < delay; i++)
        {
            yield return null;
        }

        AudioController.S.PlaySnotDie();
        GeneralDie();
        GetEx();
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy, 1);
        CreateBloodEnergy();
        CreateEquip();
        CreateProp();
        FightBGController.S.PlaySuccessAnim();
        GameController.S.StartCoroutine(DelayChuanSongMen());
    }
    IEnumerator DelayChuanSongMen()
    {
        yield return new WaitForSeconds(1f);
        var chuansongmen = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChuanSongMen"));
        chuansongmen.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    
     private void Start()
    {
        base.Start();
        size = 1.2f;
        AddMonsterEquip();
        AddMonsterProp();
    }
    
    private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
    }

    public void Skill1Collider()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        Skill1Collider2D.OverlapCollider(filter, results);
    
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Player"))
            {
               GameController.S.gamePlayer.PlayerHurt(Attack*0.7f,true);
            }
        }
    }

    public void Skill1OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "huoyan")
        {
            Skill1Collider();
        }
    }
    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "lightning")
        {
            LeiShouShunYi light=Instantiate(Resources.Load<GameObject>("Prefabs/Monster/MJ/LeiShou/LeiShouShunYi")).GetComponent<LeiShouShunYi>();
            light.damage = Attack;
            light.transform.position = transform.position;
            light.gameObject.SetActive(true);
        }

        if (e.Data.Name == "draw" && trackEntry.Animation.Name == "attack1")
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size ||
                Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 1.5f)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,true);
            }
        }
    }
    
    
     public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,4),10));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,4),10));

    }
    
    public void MonsterMove1()
    {
        Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "move"||IsDash)
        {
            GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed; 
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = direction.normalized * 0; 
        }
    }
    
    public void SpriteFlipX1(bool isRight)
    {
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name != "move")
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


    void Update()
    {
        if (IsDead) return;
        base.Update();
       
        if (!IsSkill)  // 添加这个条件
        {
            currentSkill1Time += Time.deltaTime;
            currentSkill2Time += Time.deltaTime;
            currentSkill3Time += Time.deltaTime;
        }
        

        if (currentSkill1Time > skill1Time)
        {
            if (parent.transform.localScale.x > 0&&transform.position.x-GameController.S.gamePlayer.transform.position.x>1)
            {
                currentSkill1Time = 0;
                isSkill1 = true;
            }
            if (parent.transform.localScale.x < 0&&GameController.S.gamePlayer.transform.position.x-transform.position.x>1)
            {
                currentSkill1Time = 0;
                isSkill1 = true;
            }
        }
        
        if (currentSkill2Time > skill2Time)
        {
            currentSkill2Time = 0;
            isSkill2 = true;
        }

        if (currentSkill3Time > skill3Time)
        {
            currentSkill3Time = 0;
            isSkill3 = true;
        }
        
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size||Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 1.5f)
        {
            isAttack=true;
        }
        else
        {
            isAttack=false;
        }
        
        
        if (!IsDead)
        {
            MonsterMove1();
            SpriteFlipX1(false);
        }
    }
    }
}